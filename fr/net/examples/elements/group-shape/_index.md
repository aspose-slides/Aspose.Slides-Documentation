---
title: GroupeForme
type: docs
weight: 170
url: /fr/net/examples/elements/group-shape/
keywords:
- exemple de groupe
- ajouter une forme groupe
- accéder à la forme groupe
- supprimer la forme groupe
- dissocier les formes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec les formes groupées en C# à l'aide d'Aspose.Slides : créez et dissociez, réordonnez les formes enfants, définissez les transformations et les limites dans PowerPoint et OpenDocument."
---

Exemples de création de groupes de formes, d'accès, de dissociation et de suppression à l'aide d'**Aspose.Slides for .NET**.

## **Ajouter une forme groupe**

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


## **Accéder à une forme groupe**

Récupérer la première forme groupe d'une diapositive.
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


## **Supprimer une forme groupe**

Supprimer une forme groupe de la diapositive.
```csharp
static void Remove_Group_Shape()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```


## **Dissocier les formes**

Déplacer les formes hors d'un conteneur groupe.
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
