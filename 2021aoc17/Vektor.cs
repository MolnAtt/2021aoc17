using System;

namespace _2021aoc17
{
    struct Vektor
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Vektor(int x, int y) => (this.x, this.y) = (x, y);
        public static bool operator ==(Vektor u, Vektor v) => u.x == v.x && u.y == v.y;
        public static bool operator !=(Vektor u, Vektor v) => !(u == v);
        internal void x_Növelése() => x++;
        public void y_Csökkentése() { y--; }
        public void x_Nullához_közelítése() { x -= Math.Sign(x); }
        public void Soremelés(int baloldalt_soreleje) { x = baloldalt_soreleje; y_Csökkentése(); }
        public static Vektor operator +(Vektor v, int a) => v + a;
        public static Vektor operator -(Vektor v, int a) => v - a;
        public void Hozzáad(Vektor u) { x += u.x; y += u.y; }
        public override string ToString() => $"({x},{y})";

    }
}