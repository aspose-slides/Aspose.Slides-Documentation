---
title: Texte mathématique
type: docs
weight: 160
url: /fr/net/examples/elements/math-text/
keywords:
- texte mathématique
- ajouter du texte mathématique
- accéder au texte mathématique
- supprimer le texte mathématique
- formater le texte mathématique
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez les exemples de MathematicalText d'Aspose.Slides for .NET : créez et mettez en forme des équations, des fractions, des matrices et des symboles avec C# dans des présentations PPT, PPTX et ODP."
---
Cet article montre comment travailler avec des formes de texte mathématique et mettre en forme des équations à l'aide de **Aspose.Slides for .NET**.

## **Ajouter du texte mathématique**

Créez une forme mathématique contenant une fraction et la formule de Pythagore.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ajouter une forme Math à la diapositive.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Accéder au paragraphe mathématique.
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

Localisez une forme contenant un paragraphe mathématique sur la diapositive.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Trouver la première forme qui contient un paragraphe mathématique.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Exemple : créer une fraction (non ajoutée ici).
        var fraction = new MathematicalText("x").Divide("y");

        // Utiliser mathParagraph ou fraction selon les besoins...
    }
}
```

## **Supprimer le texte mathématique**

Supprimez une forme mathématique de la diapositive.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

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
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```