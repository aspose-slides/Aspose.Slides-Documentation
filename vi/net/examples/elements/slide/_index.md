---
title: Slide
type: docs
weight: 10
url: /vi/net/examples/elements/slide/
keywords:
- slide
- thêm slide
- truy cập slide
- chỉ mục slide
- sao chép slide
- sắp xếp lại slide
- xóa slide
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Kiểm soát các slide trong Aspose.Slides for .NET: tạo, sao chép, sắp xếp lại, thay đổi kích thước, đặt nền và áp dụng chuyển tiếp bằng C# cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với các slide bằng **Aspose.Slides for .NET**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp xếp lại và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ bên dưới bao gồm một mô tả ngắn gọn và một đoạn mã mẫu bằng C#.

## **Thêm một Slide**

Để thêm một slide mới, trước tiên bạn cần chọn một bố cục. Trong ví dụ này, chúng tôi sử dụng bố cục `Blank` và thêm một slide trống vào bản trình chiếu.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Mỗi slide dựa trên một bố cục, mà bản thân nó lại dựa trên một slide chính.
    // Sử dụng bố cục Blank để tạo một slide mới.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Thêm một slide trống mới bằng cách sử dụng bố cục đã chọn.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Lưu ý:** Mỗi bố cục slide được tạo ra từ một slide chính, slide chính xác định thiết kế tổng thể và cấu trúc placeholder. Hình dưới đây minh họa cách các slide chính và các bố cục liên quan của chúng được tổ chức trong PowerPoint.

![Mối quan hệ giữa Master và Layout](master-layout-slide.png)

## **Truy cập Slide theo Chỉ mục**

Bạn có thể truy cập slide bằng chỉ mục của chúng, hoặc tìm chỉ mục của một slide dựa trên một tham chiếu. Điều này hữu ích khi lặp qua hoặc chỉnh sửa các slide cụ thể.

```csharp
static void AccessSlide()
{
    // Mặc định, một bản trình chiếu được tạo với một slide trống.
    using var presentation = new Presentation();

    // Thêm một slide trống khác.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Truy cập các slide theo chỉ mục.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Lấy chỉ mục của slide từ một tham chiếu, sau đó truy cập nó bằng chỉ mục.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Sao chép Slide**

Ví dụ này minh họa cách sao chép một slide hiện có. Slide được sao chép sẽ tự động được thêm vào cuối bộ sưu tập các slide.

```csharp
static void CloneSlide()
{
    // Mặc định, bản trình chiếu chứa một slide trống.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Sao chép slide đầu tiên; nó sẽ được thêm vào cuối bản trình chiếu.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Chỉ mục của slide đã sao chép là 1 (slide thứ hai trong bản trình chiếu).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Sắp xếp lại Slides**

Bạn có thể thay đổi thứ tự của các slide bằng cách di chuyển một slide tới một chỉ mục mới. Trong trường hợp này, chúng tôi di chuyển slide đã sao chép tới vị trí đầu tiên.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Thêm một bản sao của slide đầu tiên (được tạo mặc định).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Di chuyển slide đã sao chép tới vị trí đầu tiên (các slide khác dịch xuống).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Xóa một Slide**

Để xóa một slide, chỉ cần tham chiếu tới nó và gọi `Remove`. Ví dụ này thêm một slide thứ hai và sau đó xóa slide gốc, chỉ để lại slide mới.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Thêm một slide trống mới ngoài slide đầu tiên mặc định.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Xóa slide đầu tiên; chỉ slide mới được thêm vào sẽ còn lại.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```