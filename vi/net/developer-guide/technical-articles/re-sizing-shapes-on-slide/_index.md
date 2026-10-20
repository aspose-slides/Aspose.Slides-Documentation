---
title: Thu phóng hình dạng trên các slide của bài thuyết trình trong .NET
type: docs
weight: 130
url: /vi/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /vi/net/re-sizing-shapes-on-slide/
keywords:
- thu phóng hình dạng
- thay đổi kích thước hình dạng
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng thu phóng hình dạng trên các slide PowerPoint và OpenDocument với Aspose.Slides cho .NET—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Overview**

Khi bạn thay đổi kích thước slide của một bài thuyết trình, bạn cũng có thể cần thay đổi kích thước và vị trí của các hình dạng để phù hợp với kích thước mới. Bài viết này cho thấy cách thu phóng hình dạng theo cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Resize Shapes**

Để giữ nguyên vị trí và kích thước tương đối của mỗi hình dạng, nhân tọa độ ngang và chiều rộng của nó với tỷ lệ giữa độ rộng slide mới và độ rộng gốc. Áp dụng tỷ lệ chiều cao tương ứng cho các tọa độ dọc và chiều cao.

Ví dụ đầu tiên tải một bài thuyết trình mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) với [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) để vòng lặp tiếp theo kiểm soát việc thu phóng. Các tỷ lệ không có đơn vị; vị trí và kích thước của hình dạng được đo bằng điểm. Các tỷ lệ chiều rộng và chiều cao khác nhau có thể làm biến dạng hình dạng, và việc thay đổi kích thước của hình dạng không làm thu phóng kích cỡ phông chữ.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Tính toán các hệ số thu phóng ngang và dọc độc lập.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Bảng yêu cầu xử lý riêng: thu phóng chiều rộng cột và chiều cao hàng thay vì gán chiều rộng và chiều cao tổng thể cho bảng. Chiều cao hàng có thể vẫn lớn hơn mức yêu cầu nếu nội dung ô yêu cầu nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như các slide riêng lẻ trước khi lưu bài thuyết trình đã thay đổi kích thước. Trợ giúp của nó xử lý mỗi [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) bằng cách thu phóng [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) và [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Sau đó nó thu phóng vị trí của bảng mà không thu phóng riêng biệt các kích thước tổng thể của bảng.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Tính toán các hệ số thu phóng ngang và dọc độc lập.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Thu phóng các hình dạng được định nghĩa trên master và layout cũng như các slide cá nhân.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Kích thước bảng được kiểm soát bởi chiều rộng cột và chiều cao hàng.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ nguyên vị trí và kích thước ban đầu và có thể vượt ra ngoài slide. Việc thu phóng chiều rộng và chiều cao bằng các tỷ lệ khác nhau cũng có thể làm biến dạng hình dạng.

**Does the provided code work for all shape types?**

Ví dụ đầu tiên thay đổi trực tiếp giới hạn của hình dạng và được dành cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Hãy kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì những ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể hạn chế chiều cao hàng.

**How do I resize tables when resizing a slide?**

Thu phóng chiều rộng các cột bằng tỷ lệ chiều rộng và chiều cao tối thiểu của các hàng bằng tỷ lệ chiều cao, sau đó thu phóng vị trí của bảng, như trong ví dụ thứ hai.

**Will this resizing work for master slides and layout slides?**

Có. Ví dụ thứ hai duyệt qua [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) và [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) của mỗi master và áp dụng cùng một logic thay đổi kích thước cho các hình dạng của chúng.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Có. Đặt [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số thu phóng phản ánh định hướng cuối cùng.

**Is there a limit to the slide size I can set?**

Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Các kích thước được hỗ trợ cũng phụ thuộc vào định dạng bài thuyết trình và ứng dụng được dùng để mở tệp.

**How can I prevent shapes with a fixed aspect ratio from becoming distorted?**

Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa vào bố cục gốc trong kích thước slide mới, hãy dùng tỷ lệ nhỏ hơn giữa tỷ lệ chiều rộng và chiều cao cho cả hai kích thước và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại không gian trống ở một cạnh.