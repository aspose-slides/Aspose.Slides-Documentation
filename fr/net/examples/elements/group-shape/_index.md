---
title: GroupeForme
type: docs
weight: 170
url: /fr/net/examples/elements/group-shape/
keywords:
- exemple de groupe
- ajouter une forme de groupe
- accéder à une forme de groupe
- supprimer une forme de groupe
- dissocier les formes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec les formes de groupe en C# avec Aspose.Slides : créer et dissocier, réorganiser les formes enfants, définir les transformations et les limites dans PowerPoint et OpenDocument."
---

Exemples de création de groupes de formes, d'accès à ceux-ci, de dissociation et de suppression à l'aide de **Aspose.Slides pour .NET**.

## Ajouter un groupe de formes

Créer un groupe contenant deux formes de base.
```csharp
static void Add_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```


## Accéder à un groupe de formes

Récupérer le premier groupe de formes d'une diapositive.
```csharp
static void Access_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```


## Supprimer un groupe de formes

Supprimer un groupe de formes de la diapositive.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## Dissocier les formes

Déplacer les formes hors d'un conteneur de groupe.
```csharp
static void Ungroup_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Déplacer la forme hors du groupe
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```
