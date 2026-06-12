---
title: Forma di gruppo
type: docs
weight: 170
url: /it/net/examples/elements/group-shape/
keywords:
- gruppo
- aggiungi forma di gruppo
- accedi forma di gruppo
- rimuovi forma di gruppo
- separa forme
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Gestisci le forme raggruppate in Aspose.Slides per .NET: crea, annida, allinea, riordina e formatta le forme di gruppo con esempi C# in presentazioni PPT, PPTX e ODP."
---
Esempi per la creazione di gruppi di forme, l'accesso a essi, la separazione e la rimozione utilizzando **Aspose.Slides for .NET**.

## **Aggiungi un Gruppo di Forme**

Crea un gruppo contenente due forme di base.

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

## **Accedi a un Gruppo di Forme**

Recupera il primo gruppo di forme da una diapositiva.

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

## **Rimuovi un Gruppo di Forme**

Elimina un gruppo di forme dalla diapositiva.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Dividi le Forme**

Sposta le forme fuori da un contenitore di gruppo.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Sposta la forma fuori dal gruppo.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```