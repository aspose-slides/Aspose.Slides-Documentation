---
title: SmartArt
type: docs
weight: 140
url: /fr/net/examples/elements/smartart/
keywords:
- Exemple SmartArt
- ajouter SmartArt
- accéder SmartArt
- supprimer SmartArt
- disposition SmartArt
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créez et modifiez des SmartArt en C# avec Aspose.Slides : ajoutez des nœuds, changez les dispositions et les styles, convertissez en formes avec précision, puis exportez vers PPT, PPTX et ODP."
---

Montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions en utilisant **Aspose.Slides for .NET**.

## Ajouter SmartArt

Insérez un graphique SmartArt en utilisant l’une des dispositions intégrées.
```csharp
static void Add_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```


## Accéder au SmartArt

Récupérez le premier objet SmartArt d’une diapositive.
```csharp
static void Access_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```


## Supprimer SmartArt

Supprimez une forme SmartArt de la diapositive.
```csharp
static void Remove_SmartArt()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smart);
}
```


## Modifier la disposition du SmartArt

Mettez à jour le type de disposition d’un graphique SmartArt existant.
```csharp
static void Change_SmartArt_Layout()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smart.Layout = SmartArtLayoutType.VerticalPictureList;
}
```
