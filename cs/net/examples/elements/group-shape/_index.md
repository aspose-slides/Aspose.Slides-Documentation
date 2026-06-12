---
title: Skupinový tvar
type: docs
weight: 170
url: /cs/net/examples/elements/group-shape/
keywords:
- skupina
- přidat skupinový tvar
- přístup ke skupinovému tvaru
- odstranit skupinový tvar
- rozebrat tvary
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte seskupené tvary v Aspose.Slides pro .NET: vytvářejte, vnořujte, zarovnávejte, přeskupujte a stylizujte skupinové tvary pomocí příkladů v C# v prezentacích PPT, PPTX a ODP."
---
Příklady vytváření skupin tvarů, přístupu k nim, rozdělení skupiny a odstraňování pomocí **Aspose.Slides for .NET**.

## **Přidat skupinový tvar**

Vytvořte skupinu obsahující dva základní tvary.

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

## **Přístup ke skupinovému tvaru**

Načtěte první skupinový tvar ze snímku.

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

## **Odstranit skupinový tvar**

Odstraňte skupinový tvar ze snímku.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Rozdělit tvary**

Přesuňte tvary mimo kontejner skupiny.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Přesunout tvar mimo skupinu.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```