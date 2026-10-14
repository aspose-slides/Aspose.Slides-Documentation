---
title: Chuyển Đổi Các Slide PowerPoint Sang PNG Trong .NET
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/net/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bài thuyết trình sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint sang hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho .NET, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide bài thuyết trình sang hình ảnh PNG bằng Aspose.Slides cho .NET. Bạn có thể tải các bài thuyết trình ở các định dạng như PPT, PPTX và ODP, hiển thị mỗi slide và lưu nó dưới dạng hình ảnh PNG riêng biệt.

Các ví dụ dưới đây minh họa việc tạo hình thu nhỏ, thiết lập hệ số tỷ lệ, chỉ định kích thước đầu ra bằng pixel và chọn kiểu hiển thị gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bài thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và truy cập các slide của nó qua bộ sưu tập [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Ví dụ này hiển thị mỗi slide bằng [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) không có tham số để tạo hình thu nhỏ. Sau đó nó gọi [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) với [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) để lưu mỗi slide đã hiển thị dưới dạng hình ảnh PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Phương thức overload không tham số của [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) hiển thị ở tỉ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 điểm sẽ tạo ra hình thu nhỏ 144 × 108 pixel. Để kiểm soát kích thước đầu ra, sử dụng các overload với hệ số tỷ lệ hoặc kích thước ảnh cụ thể như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Chuyển các hệ số tỷ lệ ngang và dọc cho [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) để kiểm soát kích thước hiển thị. Trong ví dụ này, cả hai hệ số đều là 2, vì vậy một slide có kích thước 720 × 540 điểm sẽ tạo ra ảnh 1440 × 1080 pixel. Các hệ số tỷ lệ bằng nhau giữ tỉ lệ khung hình của slide. Mỗi ảnh được lưu ở định dạng PNG bằng [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước đầu ra bằng pixel, truyền một kích thước cho [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) thay vì các hệ số tỷ lệ. Ví dụ này hiển thị mỗi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Chọn kích thước phù hợp với tỉ lệ khung hình của slide để tránh làm giãn ảnh.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Chọn Kiểu Hiển Thị Gradient**

Giả sử một slide chứa các màu nền gradient, nhưng các chuyển đổi trong PNG xuất ra trông nhẹ hơn hoặc khác so với những gì bạn thấy trong PowerPoint. Bạn có thể sử dụng thuộc tính [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) của [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) để chọn cách các gradient được hiển thị.

Tải về [gradient-styles.pptx](gradient-styles.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa hai gradient tuyến tính: từ xanh lơ sang cam ở phía trên và từ xanh dương sang vàng ở phía dưới. Mỗi gradient có hai điểm dừng, tại 0% và 100%.

Ví dụ sau tải bài thuyết trình này và hiển thị slide đầu tiên trong cả hai chế độ bằng [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Các hình ảnh dưới đây hiển thị kết quả từ cùng một slide, với cả hai gradient trong mỗi hình ảnh:

| Default | PowerPointUI |
| --- | --- |
| ![Gradient từ xanh lơ sang cam và từ xanh dương sang vàng được hiển thị với Default](gradient-Default.png) | ![Các gradient tương tự được hiển thị với PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian nhẹ hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác biệt phụ thuộc vào các màu và điểm dừng trong gradient.

Chọn `Default` khi đầu ra chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai đầu ra với kết quả mong muốn; không chế độ nào là ưu tiên chung.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xuất một hình dạng cụ thể, chẳng hạn như biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo hình thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/net/create-shape-thumbnails/), cho phép bạn hiển thị một hình dạng dưới dạng hình ảnh PNG.

**Việc chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có. Sử dụng một thể hiện bài thuyết trình riêng cho mỗi luồng hoặc quy trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/net/multithreading/).

**Các hạn chế trong chế độ đánh giá khi xuất ra PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/net/licensing/) cho tới khi có giấy phép.