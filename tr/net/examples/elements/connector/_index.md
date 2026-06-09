---
title: Bağlayıcı
type: docs
weight: 190
url: /tr/net/examples/elements/connector/
keywords:
- bağlayıcı
- bağlayıcı ekle
- bağlayıcıya eriş
- bağlayıcıyı kaldır
- şekilleri yeniden bağla
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak şekiller arasındaki bağlayıcıları ekleme, yönlendirme ve biçimlendirme konularını, PPT, PPTX ve ODP sunumları için C# örnekleriyle öğrenin."
---
Bu makale, şekilleri bağlayıcılarla nasıl bağlayacağınızı ve **Aspose.Slides for .NET** kullanarak hedeflerini nasıl değiştireceğinizi gösterir.

## **Bağlayıcı Ekle**

Slayttaki iki nokta arasına bir bağlayıcı şekli ekleyin.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Bağlayıcıya Erişim**

Bir slayta eklenen ilk bağlayıcı şekli alın.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Bağlayıcıyı Kaldır**

Slayttan bir bağlayıcıyı silin.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Şekilleri Yeniden Bağla**

Başlangıç ve bitiş hedeflerini atayarak bir bağlayıcıyı iki şekle bağlayın.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```