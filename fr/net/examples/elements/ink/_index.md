---
title: Encre
type: docs
weight: 180
url: /fr/net/examples/elements/ink/
keywords:
- exemple d'encre
- accès à l'encre
- supprimer l'encre
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Manipulez l'encre numérique sur les diapositives en C# avec Aspose.Slides : ajoutez des traits de stylet, modifiez les tracés, définissez la couleur et la largeur, puis exportez les résultats vers PowerPoint et OpenDocument."
---

Fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide de **Aspose.Slides for .NET**.

> ❗ **Note:** Les formes d'encre représentent les entrées utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre programmaticalement, mais vous pouvez lire et modifier l'encre existante.

## **Accéder à l'encre**

Lire les balises de la première forme d'encre sur une diapositive.
```csharp
static void Access_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // Utilisez tagName selon les besoins
        }
    }
}
```


## **Supprimer l'encre**

Supprimer une forme d'encre de la diapositive si elle existe.
```csharp
static void Remove_Ink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```
