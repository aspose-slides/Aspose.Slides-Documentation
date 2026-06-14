---
title: Slide Bố Cục
type: docs
weight: 20
url: /vi/net/examples/elements/layout-slide/
keywords:
- slide bố cục
- thêm slide bố cục
- truy cập slide bố cục
- xóa slide bố cục
- slide bố cục không sử dụng
- sao chép slide bố cục
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Quản lý slide bố cục trong Aspose.Slides cho .NET: chọn, áp dụng và tuỳ chỉnh bố cục slide, các placeholder và master với các ví dụ C# cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với **Layout Slides** trong Aspose.Slides cho .NET. Một layout slide xác định thiết kế và định dạng được kế thừa bởi các slide thông thường. Bạn có thể thêm, truy cập, sao chép và xóa layout slides, cũng như dọn dẹp các layout không dùng để giảm kích thước bản trình chiếu.

## **Thêm Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để định nghĩa định dạng có thể tái sử dụng. Ví dụ, bạn có thể thêm một hộp văn bản xuất hiện trên tất cả các slide sử dụng layout này.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Tạo một layout slide với loại bố cục trống và tên tùy chỉnh.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Thêm một hộp văn bản vào layout slide.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Thêm hai slide sử dụng layout này; cả hai sẽ kế thừa văn bản từ layout.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Layout slides hoạt động như mẫu cho các slide riêng lẻ. Bạn có thể định nghĩa các yếu tố chung một lần và tái sử dụng chúng trên nhiều slide.
> 💡 **Note 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung này.
> Ảnh chụp màn hình bên dưới hiển thị hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Slide Kế Thừa Nội Dung Layout](layout-slide-result.png)

## **Truy Cập Layout Slide**

Layout slides có thể được truy cập theo chỉ mục hoặc theo loại layout (ví dụ, `Blank`, `Title`, `SectionHeader`, v.v.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Truy cập một layout slide theo chỉ mục.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Truy cập một layout slide theo loại.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Xóa Layout Slide**

Bạn có thể xóa một layout slide cụ thể nếu nó không còn cần thiết.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Lấy một layout slide theo loại và xóa nó.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Xóa Các Layout Slide Không Sử Dụng**

Để giảm kích thước bản trình chiếu, bạn có thể muốn xóa các layout slide không được bất kỳ slide thông thường nào sử dụng.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Tự động xóa tất cả các layout slide không được bất kỳ slide nào tham chiếu.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Sao Chép Layout Slide**

Bạn có thể nhân đôi một layout slide bằng cách sử dụng phương thức `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Lấy một layout slide hiện có theo loại.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Nhân bản layout slide vào cuối bộ sưu tập layout slide.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Tóm Tắt:** Layout slides là công cụ mạnh mẽ để quản lý định dạng nhất quán trên các slide. Aspose.Slides cho phép kiểm soát đầy đủ việc tạo, quản lý và tối ưu hoá layout slides.