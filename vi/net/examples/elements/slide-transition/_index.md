---
title: Chuyển tiếp Slide
type: docs
weight: 110
url: /vi/net/examples/elements/slide-transition/
keywords:
- chuyển tiếp slide
- thêm chuyển tiếp slide
- truy cập chuyển tiếp slide
- xóa chuyển tiếp slide
- thời lượng chuyển tiếp
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Thành thạo chuyển tiếp slide trong Aspose.Slides cho .NET: thêm, tùy chỉnh và sắp xếp các hiệu ứng và thời lượng với các ví dụ C# cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách áp dụng hiệu ứng chuyển tiếp slide và thời gian với **Aspose.Slides for .NET**.

## **Thêm chuyển tiếp slide**

Áp dụng hiệu ứng chuyển đổi mờ (fade) cho slide đầu tiên.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Áp dụng chuyển đổi mờ.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Truy cập chuyển tiếp slide**

Đọc kiểu chuyển tiếp hiện đang được gán cho một slide.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Truy cập kiểu chuyển tiếp.
    var type = slide.SlideShowTransition.Type;
}
```

## **Xóa chuyển tiếp slide**

Xóa bất kỳ hiệu ứng chuyển tiếp nào bằng cách đặt kiểu thành `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Xóa chuyển tiếp bằng cách đặt None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Đặt thời lượng chuyển tiếp**

Chỉ định thời gian slide được hiển thị trước khi tự động chuyển tiếp.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // tính bằng mili giây
}
```