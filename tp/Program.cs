
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPMoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();

            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.Moyenne(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.Moyenne() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.Moyenne(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.Moyenne() + "\n");
            Console.Read();
        }
    }
}
//Classes fournies par HNI Institut
class Note
{
    public int matiere { get; private set; }
    public float note { get; private set; }
    public Note(int m, float n)
    {
        matiere = m;
        note = n;
    }
}

class Classe
{
    public string nomClasse { get; private set; }
    public List<Eleve> eleves { get; private set; }
    public List<string> matieres { get; private set; }
    public Classe(string n)
    {
        nomClasse = n;
        eleves = new List<Eleve>();
        matieres = new List<string>();
    }

    public double Moyenne(int ind)
    {
        if (eleves.Count <= ind)
        {
            return 0;
        }
        double m = 0;
        for (int i = 0; i < eleves.Count; i++)
        {
            m += eleves[i].Moyenne(ind);
        }
        return Math.Round(m / eleves.Count, 2);
    }
    public double Moyenne()
    {
        double m = 0;
        for (int i = 0; i < eleves.Count; i++)
        {
            m += eleves[i].Moyenne();
        }
        return Math.Round(m / eleves.Count, 2);
    }
    public void ajouterEleve(string n, string p)
    {
        eleves.Add(new Eleve(n, p));
    }
    public void ajouterMatiere(string n)
    {
        matieres.Add(n);
    }
}

class Eleve
{
    public string nom { get; private set; }
    public string prenom { get; private set; }
    public List<Note> notes { get; private set; }
    public Eleve(string n, string p)
    {
        nom = n;
        prenom = p;
        notes = new List<Note>();
    }
    public double Moyenne(int m)
    {
        var n = notes.Find(n => n.matiere == m);
        if (notes.Count <= m || n == null)
        {
            return 0;
        }
        return Math.Round(n.note, 2);
    }
    public double Moyenne()
    {
        double m = 0;
        for (int i = 0; i < notes.Count; i++)
        {
            m += notes[i].note;
        }
        return Math.Round(m / notes.Count, 2);
    }
    public void ajouterNote(Note n)
    {
        notes.Add(n);
    }
}

