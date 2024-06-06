using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Domain.Enum
{
    public enum Section
    {
        [Display(Name = "Целые числа")]
        WholeNumbers = 0,
        [Display(Name = "Алгебра и анализ")]
        AlgebraAndAnalysis = 1,
        [Display(Name = "Алгебраические уравнения и неравенства")]
        AlgebraicEquationsAndInequalities = 2,
        [Display(Name = "Тригонометрия")]
        Trigonometry = 3,
        [Display(Name = "Логарифмы")]
        Logarithm = 4,
        [Display(Name = "Задачи с параметрами")]
        ProblemsWithParameters = 5,
        [Display(Name = "Разное")]
        Miscellaneous = 6,
        [Display(Name = "Планиметрия")]
        Planimetry = 7,
        [Display(Name = "Стереометрия")]
        Stereometry = 8,
        [Display(Name = "Олимпиадная Геометрия")]
        OlympicGeometry = 9,
        [Display(Name = "Комбинаторика и вероятность")]
        CombinatoricsAndProbability = 10,
        [Display(Name = "Теория графов")]
        GraphTheory = 11,
        [Display(Name = "Комбинаторная геометрия")]
        CombinatorialGeometry = 12,
        [Display(Name = "Логика")]
        Logics = 12,
        [Display(Name = "Механика")]
        Mechanics = 13,
        [Display(Name = "Термодинамика")]
        Thermodynamics = 14,
        [Display(Name = "Оптика")]
        Optics = 15,
        [Display(Name = "Общефизическое")]
        GeneralPhysical = 16,
        [Display(Name = "Электродинамика")]
        Electrodynamics = 17,
        [Display(Name = "Квантовая физика")]
        QuantumPhysics = 17,

    }
}


