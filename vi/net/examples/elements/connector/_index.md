---
title: Kết nối
type: docs
weight: 190
url: /vi/net/examples/elements/connector/
keywords:
- kết nối
- thêm kết nối
- truy cập kết nối
- xóa kết nối
- kết nối lại các hình dạng
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Học cách thêm, định tuyến và định dạng các kết nối giữa các hình dạng bằng Aspose.Slides cho .NET, với các ví dụ C# cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách kết nối các hình dạng bằng kết nối và thay đổi mục tiêu của chúng bằng cách sử dụng **Aspose.Slides cho .NET**.

## **Thêm kết nối**

Chèn một hình dạng kết nối giữa hai điểm trên slide.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Truy cập một kết nối**

Lấy hình dạng kết nối đầu tiên được thêm vào slide.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Xóa một kết nối**

Xóa một kết nối khỏi slide.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Kết nối lại các hình dạng**

Gắn một kết nối vào hai hình dạng bằng cách chỉ định mục tiêu bắt đầu và kết thúc.

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