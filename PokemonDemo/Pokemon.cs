using System;

public enum TipoPokemon
{
    fuoco, acqua, erba, normale, lotta, volante, elettro, vuoto
}

public enum NomePokemon
{
    Charizard, Blastoise, Venusaur, Pikachu, Victreebel, Pidgeot, Raticate, Fearow, Gyarados, Onix, Electabuzz, Magmar, Hitmonlee, Hitmonchan
}

public class PokemonBase
{
    string nomeSprite1, nomeSprite2;
    NomePokemon nome;
    TipoPokemon tipo1, tipo2;
    uint att, spAtt, def, spDef, spe, ps;

    public PokemonBase(NomePokemon _nome, TipoPokemon _tipo1, TipoPokemon _tipo2, uint _att, uint _spAtt, uint _def, 
        uint _spDef, uint _spe, uint _ps, string stringaImg1, string stringaImg2)
    {
        nome = _nome;
        nomeSprite1 = stringaImg1;
        nomeSprite2 = stringaImg2;
        att = _att;
        spAtt = _spAtt;
        def = _def;
        spDef = _spDef;
        spe = _spe;
        ps = _ps;
        tipo1 = _tipo1;
        tipo2 = _tipo2;
    }
    public TipoPokemon Tipo1 => tipo1;
    public TipoPokemon Tipo2 => tipo1;
    public NomePokemon Nome => nome;
    public uint Attacco => att;
    public uint Difesa => def;
    public uint AttSpeciale => spAtt;
    public uint DefSpeciale => spDef;
    public uint Speed => spe;
    public uint Ps => ps;
    public string ImgDavanti => nomeSprite1;
    public string ImgDietro => nomeSprite2;
}

public class Pokemon
{
    string nickname;
    PokemonBase nome;
    Mossa[] mosse = new Mossa[4];
    uint att, spAtt, def, spDef, spe, ps;
    uint livello;

    public Pokemon(PokemonBase _nome, string _nickname, uint _livello, Mossa m1, Mossa m2, Mossa m3, Mossa m4)
    {
        nickname = _nickname;
        nome = _nome;
        livello = _livello;
        mosse[0] = m1;
        mosse[1] = m2;
        mosse[2] = m3;
        mosse[3] = m4;
        att = nome.Attacco;
        spAtt = nome.AttSpeciale;
        def = nome.Difesa;
        spDef = nome.DefSpeciale;
        spe = nome.Speed;
        ps = nome.Ps;
    }

    public string Soprannome
    {
        get => nickname;
        set => nickname = value;
    }
    public Mossa Mossa1 => mosse[0];
    public Mossa Mossa2 => mosse[1];
    public Mossa Mossa3 => mosse[2];
    public Mossa Mossa4 => mosse[3];
    public string ImgDavanti => nome.ImgDavanti;
    public string ImgDietro => nome.ImgDietro;
    public uint Attacco
    {
        get => att;
        set => att = value;
    }
    public uint Difesa
    {
        get => def;
        set => def = value;
    }
    public uint AttSpeciale
    {
        get => spAtt;
        set => spAtt = value;
    }
    public uint DefSpeciale
    {
        get => spDef;
        set => spDef = value;
    }
    public uint Speed
    {
        get => spe;
        set => spe = value;
    }
    public uint Ps
    {
        get => ps;
        set => ps = value;
    }
}

public class Mossa
{
    TipoPokemon tipo;
    uint power, precisione;
    bool contatto;

    public Mossa(TipoPokemon _tipo, uint _power, uint _precisione, bool _contatto)
    {
        tipo = _tipo;
        power = _power;
        precisione = _precisione;
        contatto = _contatto;
    }

    public TipoPokemon Tipo
    {
        get => tipo;
        set => tipo = value;
    }

    public uint Potenza
    {
        get => power;
        set
        {
            uint tmp = value;
            if (tmp > 999 || tmp < 0)
                throw new Exception("Parametro invalido");

            power = tmp;
        }
    }

    public uint Precisione
    {
        get => precisione;
        set
        {
            uint tmp = value;
            if (tmp > 999 || tmp < 0)
                throw new Exception("Parametro invalido");

            precisione = tmp;
        }
    }

    public bool Contatto
    {
        get => contatto;
        set => contatto = value;
    }
}



