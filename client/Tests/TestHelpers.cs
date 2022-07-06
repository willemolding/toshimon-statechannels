namespace test;

using System.Collections.Immutable;

public static class TestHelpers {

	// an example monster card used throughout tests
    // It only has a single move and this is in every move slot 
	public static MonsterCard testMonster1(string moveAddress) {
        Stats stats = new Stats {
            Hp = 70,
            Attack = 70,
            Defense = 70,
            SpAttack = 90,
            SpDefense = 90,
            Speed = 90,
            PP = new List<uint>(new uint[]{10, 0, 0, 0}),
        };

        return new MonsterCard(
            stats,
            stats,
            new string[]{ moveAddress, moveAddress, moveAddress, moveAddress }
        );
    }

    // build a game state quickly where each player only has one monster
    public static GameState build1v1(MonsterCard one, MonsterCard two) {
    	return new GameState(
            new PlayerState(new MonsterCard[]{one}, new ItemCard[0]),
            new PlayerState(new MonsterCard[]{two}, new ItemCard[0])
        );
    }

    public static GameState build2v2(MonsterCard one, MonsterCard two) {
        return new GameState(
            new PlayerState(new MonsterCard[]{one, one}, new ItemCard[0]),
            new PlayerState(new MonsterCard[]{two, two}, new ItemCard[0])
        );
    }

}