---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/net/examples/elements/animation/
keywords:
- hoạt ảnh
- thêm hoạt ảnh
- truy cập hoạt ảnh
- xóa hoạt ảnh
- trình tự hoạt ảnh
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá các ví dụ về hoạt ảnh của Aspose.Slides cho .NET: thêm, sắp xếp và tùy chỉnh các hiệu ứng và chuyển đổi bằng C# cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách tạo các hoạt ảnh đơn giản và quản lý trình tự của chúng bằng **Aspose.Slides for .NET**.

## **Thêm một hoạt ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng mờ dần được kích hoạt khi nhấp chuột.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Hiệu ứng mờ dần.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Truy cập một hoạt ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Truy cập hiệu ứng hoạt ảnh đầu tiên.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Xóa một hoạt ảnh**

Xóa một hiệu ứng hoạt ảnh khỏi trình tự.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Xóa hiệu ứng.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Sắp xếp các hoạt ảnh**

Thêm nhiều hiệu ứng và minh họa thứ tự xuất hiện của các hoạt ảnh.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```