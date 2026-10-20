---
title: Thay đổi kích thước hình dạng trên các slide của bản trình chiếu trong .NET
type: docs
weight: 130
url: /vi/net/resizing-shapes-on-slide/
aliases:
  - /vi/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument với Aspose.Slides cho .NET—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Khi bạn thay đổi kích thước slide của bản trình chiếu, bạn cũng có thể cần thay đổi kích thước và vị trí lại các hình dạng để vừa với các kích thước mới. Bài viết này chỉ ra cách thu phóng các hình dạng một cách thủ công và cách xử lý các bảng trên slide, master và layout.

## **Thay đổi kích thước hình dạng**

Để giữ nguyên vị trí và kích thước tương đối của mỗi hình dạng, nhân tọa độ ngang và chiều rộng của nó với tỉ lệ giữa chiều rộng slide mới và chiều rộng gốc. Áp dụng tỉ lệ chiều cao tương ứng cho tọa độ dọc và chiều cao của nó.

Ví dụ đầu tiên tải một bản trình chiếu mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) với [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) để vòng lặp tiếp theo kiểm soát việc thu phóng. Các tỉ lệ là không có đơn vị; vị trí và kích thước của hình dạng được đo bằng điểm. Các tỉ lệ chiều rộng và chiều cao khác nhau có thể biến dạng hình dạng, và việc thay đổi kích thước của hình dạng không thu phóng kích thước phông chữ.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Tính các hệ số thu phóng ngang và dọc độc lập.
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
Bảng yêu cầu xử lý riêng: thu phóng chiều rộng các cột và chiều cao các hàng thay vì gán chiều rộng và chiều cao tổng thể của bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô yêu cầu nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ các bảng và xử lý các hình dạng trên master và layout cũng như các slide riêng lẻ trước khi lưu bản trình chiếu đã thay đổi kích thước. Trợ giúp của nó xử lý mỗi [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) bằng cách thu phóng [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) và [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Sau đó nó thu phóng vị trí của bảng mà không thu phóng riêng các kích thước tổng thể của bảng.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Tính các hệ số thu phóng ngang và dọc độc lập.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như các slide riêng lẻ.
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
            //        Kích thước bảng được kiểm soát bởi chiều rộng các cột và chiều cao các hàng.
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

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ vị trí và kích thước gốc và có thể vượt ra ngoài slide. Thu phóng chiều rộng và chiều cao bằng các tỉ lệ khác nhau cũng có thể làm biến dạng các hình dạng.

**Mã được cung cấp có hoạt động cho tất cả các loại hình dạng không?**

Ví dụ đầu tiên thay đổi giới hạn của hình dạng trực tiếp và dành cho các slide không có bảng. Ví dụ thứ hai xử lý các bảng riêng biệt. Kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì các ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể hạn chế chiều cao hàng.

**Làm sao tôi có thể thay đổi kích thước bảng khi thay đổi kích thước slide?**

Thu phóng chiều rộng các cột bằng tỉ lệ chiều rộng và chiều cao tối thiểu của các hàng bằng tỉ lệ chiều cao, sau đó thu phóng vị trí của bảng, như trong ví dụ thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các slide master và layout không?**

Có. Ví dụ thứ hai lặp qua [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) và mỗi [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) của master và áp dụng cùng một logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Đặt [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) sau khi thay đổi kích thước slide và trước khi đọc kích thước mục tiêu, để các hệ số thu phóng phản ánh hướng cuối cùng.

**Có giới hạn nào cho kích thước slide tôi có thể đặt không?**

Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Các kích thước hỗ trợ cũng phụ thuộc vào định dạng bản trình chiếu và ứng dụng dùng để mở tệp.

**Làm sao tôi ngăn các hình dạng có tỉ lệ khung cố định bị biến dạng?**

Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa bố cục gốc trong kích thước slide mới, sử dụng tỉ lệ nhỏ hơn trong số tỉ lệ chiều rộng và chiều cao cho cả hai kích thước và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại không gian chưa sử dụng ở một cạnh.