using System;
using DIO.CrudSeries.Enumerable;

namespace DIO.CrudSeries.Classes
{
    public class Series: BaseEntity
    {
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private Genre Genre { get; set; }
        private bool deleted {get; set;}

        public Series(int id, string title, string description, int year, Genre genre)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Genre = genre;
            this.deleted = false;
        }

        public override string ToString()
        {
            var value = "";
            value += $"Título: {this.Title}{Environment.NewLine}";
            value += $"Descrição: {this.Description}{Environment.NewLine}";
            value += $"Gênero: {Enum.GetName(typeof(Genre), this.Genre)}{Environment.NewLine}";
            value += $"Ano: {this.Year}{Environment.NewLine}";
            return value;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public int getId()
        {
            return this.Id;
        }

        public void remove()
        {
            this.deleted = true;
        }

        public bool isDeleted()
        {
            return this.deleted;
        }
    }
}