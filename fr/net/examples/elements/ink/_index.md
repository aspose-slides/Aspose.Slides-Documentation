---
title: Encre
type: docs
weight: 180
url: /fr/net/examples/elements/ink/
keywords:
- encre
- accéder à l'encre
- supprimer l'encre
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec l'encre dans Aspose.Slides pour .NET : dessinez, importez et modifiez les traits, ajustez la couleur et la largeur, et exportez vers PPT, PPTX et ODP à l'aide d'exemples C#."
---
Cet article fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide de **Aspose.Slides for .NET**.

> ❗ **Note :** Les formes d'encre représentent la saisie utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre par programmation, mais vous pouvez lire et modifier l'encre existante.

## **Accéder à l'encre**
Lisez les balises de la première forme d'encre sur une diapositive.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Utilisez tagName selon les besoins.
        }
    }
}
```

## **Supprimer l'encre**
Supprimez une forme d'encre de la diapositive si elle existe.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```