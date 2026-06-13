---
title: اتصال‌دهنده
type: docs
weight: 190
url: /fa/net/examples/elements/connector/
keywords:
- اتصال‌دهنده
- افزودن اتصال‌دهنده
- دسترسی به اتصال‌دهنده
- حذف اتصال‌دهنده
- اتصال مجدد اشکال
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای .NET، اتصال‌دهنده‌ها را بین اشکال اضافه، مسیردهی و استایل کنید، با مثال‌های C# برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه اشکال را با اتصال‌دهنده‌ها متصل کرده و هدف‌های آن‌ها را با استفاده از **Aspose.Slides for .NET** تغییر دهیم.

## **افزودن اتصال‌دهنده**

یک شکل اتصال‌دهنده بین دو نقطه در اسلاید وارد کنید.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **دسترسی به اتصال‌دهنده**

شکل اولین اتصال‌دهنده اضافه شده به اسلاید را بازیابی کنید.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **حذف اتصال‌دهنده**

یک اتصال‌دهنده را از اسلید حذف کنید.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **اتصال مجدد اشکال**

یک اتصال‌دهنده را به دو شکل متصل کنید با اختصاص اهداف شروع و پایان.

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