---
title: Grup Şekli
type: docs
weight: 170
url: /tr/net/examples/elements/group-shape/
keywords:
- grup
- grup şekli ekle
- grup şekline eriş
- grup şekli kaldır
- şekilleri gruptan çıkar
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te gruplanmış şekilleri yönetin: C# örnekleriyle PPT, PPTX ve ODP sunumlarında grup şekilleri oluşturun, iç içe yerleştirin, hizalayın, yeniden sıralayın ve stil verin."
---
**Aspose.Slides for .NET** kullanarak şekil grupları oluşturma, bu gruplara erişme, gruplamayı kaldırma ve silme örnekleri.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

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

## **Grup Şekline Eriş**

Bir slayttan ilk grup şekli alın.

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

## **Grup Şeklini Kaldır**

Slayttan bir grup şekli sil.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Şekilleri Gruplamadan Çıkar**

Şekilleri grup konteynerinden dışarı taşı.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Şekli gruptan dışarı taşı.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```