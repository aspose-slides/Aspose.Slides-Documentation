---
title: TexteMath
type: docs
weight: 160
url: /fr/net/examples/elements/math-text/
keywords:
- exemple de texte mathématique
- ajouter du texte mathématique
- accéder au texte mathématique
- supprimer le texte mathématique
- formater le texte mathématique
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec du texte mathématique en C# à l'aide d'Aspose.Slides : créer et modifier des équations, fractions, radicaux, scripts, mise en forme, et rendre les résultats pour PPT et PPTX."
---

Illustre la manipulation de formes de texte mathématique et le formatage d’équations avec **Aspose.Slides for .NET**.

## **Ajouter du texte mathématique**

Créez une forme mathématique contenant une fraction et la formule de Pythagore.
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Ajouter une forme Math à la diapositive
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Accéder au paragraphe mathématique
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Ajouter une fraction simple : x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Ajouter une équation : c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```


## **Accéder au texte mathématique**

Localisez une forme qui contient un paragraphe mathématique sur la diapositive.
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Trouver la première forme qui contient un paragraphe mathématique
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Exemple : créer une fraction (non ajoutée ici)
        var fraction = new MathematicalText("x").Divide("y");

        // Utiliser mathParagraph ou fraction selon les besoins...
    }
}
```


## **Supprimer le texte mathématique**

Supprimez une forme mathématique de la diapositive.
```csharp
static void Remove_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```


## **Formater le texte mathématique**

Définissez les propriétés de police pour une partie mathématique.
```csharp
static void Format_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```
