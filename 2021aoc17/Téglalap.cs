namespace _2021aoc17
{
    struct Téglalap
    {
        public int bax { get; }
        public int bay { get; }
        public int jfx { get; }
        public int jfy { get; }

        public int bfx { get => bax; }
        public int bfy { get => jfy; }
        public int jax { get => jfx; }
        public int jay { get => bay; }
        public Vektor ba { get => new Vektor(bax, bay); }
        public Vektor jf { get => new Vektor(jfx, jfy); }
        public Vektor ja { get => new Vektor(jax, jay); }
        public Vektor bf { get => new Vektor(bfx, bfy); }
        public Téglalap(int bax, int bay, int jfx, int jfy) => (this.bax, this.bay, this.jfx, this.jfy) = (bax, bay, jfx, jfy);

        public bool Tartalmazza(Vektor p) => bax <= p.x && p.x <= jfx && bay <= p.y && p.y <= jfy;

        public bool Túlment(Vektor p) => jax < p.x || p.y < jay;
        public override string ToString() => $"({bax},{bay}) rectangle ({jfx},{jfy})";



    }
}