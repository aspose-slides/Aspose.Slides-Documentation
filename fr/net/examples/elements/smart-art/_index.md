---
title: SmartArt
type: docs
weight: 140
url: /fr/net/examples/elements/smart-art/
keywords:
- SmartArt
- ajouter SmartArt
- accéder à SmartArt
- supprimer SmartArt
- mise en page SmartArt
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec SmartArt dans Aspose.Slides for .NET : créez, modifiez, convertissez et stylisez des diagrammes avec C# pour les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions à l’aide de **Aspose.Slides for .NET**.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l’une des dispositions intégrées.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt d’une diapositive.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **Modifier la disposition SmartArt**

Mettez à jour le type de disposition d’un graphique SmartArt existant.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```