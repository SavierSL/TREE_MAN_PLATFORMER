using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem>
{
    public List<ScriptableExampleHero> ExampleHeroes { get; private set; }
    public List<ScriptableExampleEnemy> ExampleEnemies { get; private set; }
    private Dictionary<ExampleHeroType, ScriptableExampleHero> _ExampleHeroesDict;
    private Dictionary<ExampleEnemyType, ScriptableExampleEnemy> _ExampleEnemiesDict;

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        ExampleHeroes = Resources.LoadAll<ScriptableExampleHero>("ExampleHeroes").ToList();
        ExampleEnemies = Resources.LoadAll<ScriptableExampleEnemy>("ExampleEnemies").ToList();
        _ExampleHeroesDict = ExampleHeroes.ToDictionary(r => r.HeroType, r => r);
        _ExampleEnemiesDict = ExampleEnemies.ToDictionary(r => r.EnemyType, r => r);
    }

    public ScriptableExampleHero GetExampleHero(ExampleHeroType t) => _ExampleHeroesDict[t];
    public ScriptableExampleEnemy GetExampleEnemy(ExampleEnemyType t) => _ExampleEnemiesDict[t];
    public ScriptableExampleHero GetRandomHero() => ExampleHeroes[Random.Range(0, ExampleHeroes.Count)];
}