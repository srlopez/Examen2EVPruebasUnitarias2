using System.Collections.Generic;
using System;
using System.Linq;

using Parejas;
namespace Parejas
{
    public class Sistema
    {
        public List<Persona> Personas { get; } = new()
        {
            new Persona("Hombre1", Sexo.H, 19),
            new Persona("Mujer1", Sexo.M, 19),
            new Persona("Hombre2", Sexo.H, 29),
            new Persona("Mujer2", Sexo.M, 29),
            new Persona("Hombre3", Sexo.H, 39),
            new Persona("Mujer3", Sexo.M, 39),
            new Persona("Hombre4", Sexo.H, 49),
            new Persona("Mujer4", Sexo.M, 49),
            new Persona("Hombre5", Sexo.H, 59),
            new Persona("Mujer5", Sexo.M, 59),
            new Persona("Hombre6", Sexo.H, 69),
            new Persona("Mujer6", Sexo.M, 69),
            new Persona("Hombre7", Sexo.H, 21),
            new Persona("Mujer7", Sexo.M, 21),
            new Persona("Hombre8", Sexo.H, 31),
            new Persona("Mujer8", Sexo.M, 31),
        };

        public bool AdmitenDescendencia(Persona a, Persona b)
        {
            if (a.Sexo == b.Sexo) return false;
            if (Math.Abs(a.Edad - b.Edad) > 12) return false;
            if (Math.Abs(a.Rango - b.Rango) > 1) return false;
            return true;
        }

        public List<(Persona, Persona)> PosibleParejas(List<Persona> personas)
        {
            var parejas = new List<(Persona, Persona)>();
            for (var i = 0; i < personas.Count - 1; i++)
            {
                for (var j = i; j < personas.Count; j++)
                {
                    if (AdmitenDescendencia(personas[i], personas[j]))
                    {
                        if (personas[i].Sexo == Sexo.H)
                            parejas.Add((personas[i], personas[j]));
                        else
                            parejas.Add((personas[j], personas[i]));
                    }
                }
            }
            return parejas;

            // Inspirado por Christian
            // return personas
            //     .SelectMany((p1, i) => personas
            //     .GetRange(i + 1, personas.Count() - i - 1)
            //     .Select(p2 => (p1, p2))
            //     .Where(t => AdmitenDescendencia(t.p1, t.p2))
            //     .Select(t => t.p1.Sexo == Sexo.H ? t : (t.p2, t.p1)))
            //     .OrderBy(t=>t.Item1.Edad)
            //     .ThenBy(t=>t.Item2.Edad)
            //     .ToList();
        }

        public string Saludo(string nombre) => $"Saludos {nombre}!";


    }
}