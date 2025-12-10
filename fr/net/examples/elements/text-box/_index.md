---
title: Boîte de texte
type: docs
weight: 40
url: /fr/net/examples/elements/text-box/
keywords:
- exemple de boîte de texte
- ajouter une boîte de texte
- accéder à la boîte de texte
- supprimer la boîte de texte
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez et formatez des boîtes de texte en C# avec Aspose.Slides : définissez les polices, l’alignement, le retour à la ligne, l’ajustement automatique et les liens pour peaufiner les diapositives PowerPoint et OpenDocument."
---

Dans Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Pratiquement n'importe quelle forme peut contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programme.

## **Ajouter une zone de texte**

Une zone de texte est simplement un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
````

> 💡 **Remarque:** Tout `AutoShape` contenant un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder aux zones de texte par contenu**

Pour trouver toutes les zones de texte contenant un mot‑clé spécifique (par ex. «Slide»), parcourez les formes et vérifiez leur texte :

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## **Supprimer les zones de texte par contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot‑clé spécifique:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **Astuce:** Créez toujours une copie de la collection de formes avant de la modifier pendant l'itération afin d'éviter les erreurs de modification de collection.