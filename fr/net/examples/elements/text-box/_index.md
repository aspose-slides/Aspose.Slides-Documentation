---
title: Boîte de texte
type: docs
weight: 40
url: /fr/net/examples/elements/text-box/
keywords:
- boîte de texte
- ajouter une boîte de texte
- accéder à une boîte de texte
- supprimer une boîte de texte
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec les boîtes de texte dans Aspose.Slides pour .NET : ajoutez, formatez, alignez, enroulez, adaptez automatiquement et stylisez le texte en C# pour les présentations PPT, PPTX et ODP."
---
Dans Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Pratiquement n'importe quelle forme peut contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programmation.

## **Ajouter une zone de texte**

Une zone de texte est simplement un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Créez une forme rectangle (remplie par défaut avec bordure et sans texte).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Supprimez le remplissage et la bordure pour qu'elle ressemble à une boîte de texte typique.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Définissez le format du texte.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assignez le contenu réel du texte.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Remarque:** Tout `AutoShape` qui contient un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder aux zones de texte par contenu**

Pour trouver toutes les zones de texte contenant un mot‑clé spécifique (p. ex. "Slide"), parcourez les formes et vérifiez leur texte :

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Seules les AutoShapes peuvent contenir du texte éditable.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Faites quelque chose avec la zone de texte correspondante.
            }
        }
    }
}
```

## **Supprimer les zones de texte par contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot‑clé spécifique :

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Conseil:** Créez toujours une copie de la collection de formes avant de la modifier pendant l'itération afin d'éviter les erreurs de modification de collection.