---
title: Groupe de formes
type: docs
weight: 170
url: /fr/net/examples/elements/group-shape/
keywords:
- groupe
- ajouter forme de groupe
- accéder forme de groupe
- supprimer forme de groupe
- désassembler formes
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les formes groupées dans Aspose.Slides pour .NET : créez, imbriquez, alignez, réordonnez et stylisez les groupes de formes avec des exemples C# dans les présentations PPT, PPTX et ODP."
---
Exemples de création de groupes de formes, d'accès, de désassemblage et de suppression à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un groupe de formes**

Créez un groupe contenant deux formes de base.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Accéder à un groupe de formes**

Récupérez la première forme groupée d'une diapositive.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Supprimer un groupe de formes**

Supprimez un groupe de formes de la diapositive.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Dégrouper les formes**

Déplacez les formes hors d'un conteneur de groupe.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Déplacer la forme hors du groupe.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```