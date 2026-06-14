---
title: Nhóm Hình
type: docs
weight: 170
url: /vi/net/examples/elements/group-shape/
keywords:
- nhóm
- thêm nhóm hình
- truy cập nhóm hình
- xóa nhóm hình
- tách nhóm hình
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Quản lý các hình dạng được nhóm trong Aspose.Slides cho .NET: tạo, lồng, căn chỉnh, sắp xếp lại và tạo kiểu cho các nhóm hình bằng các ví dụ C# trong các bản trình bày PPT, PPTX và ODP."
---
Ví dụ về việc tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bằng **Aspose.Slides for .NET**.

## **Thêm Nhóm Hình**

Tạo một nhóm chứa hai hình dạng cơ bản.

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

## **Truy Cập Nhóm Hình**

Lấy nhóm hình đầu tiên từ một slide.

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

## **Xóa Nhóm Hình**

Xóa một nhóm hình khỏi slide.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Tách Nhóm Hình**

Di chuyển các hình ra khỏi container nhóm.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Di chuyển hình ra khỏi nhóm.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```