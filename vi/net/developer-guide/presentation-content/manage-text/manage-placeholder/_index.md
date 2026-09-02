---
title: Quản lý Trình giữ chỗ trong .NET
linktitle: Quản lý Trình giữ chỗ
type: docs
weight: 10
url: /vi/net/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- trình giữ chỗ nội dung
- văn bản nhắc
- PowerPoint
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các trình giữ chỗ văn bản, hình ảnh, biểu đồ và nội dung, đồng thời hiểu về kế thừa trình giữ chỗ với Aspose.Slides cho .NET."
---
## **Tổng quan**

Placeholder là một hình dạng giữ chỗ cho một loại nội dung cụ thể trong mẫu thuyết trình. Các ví dụ phổ biến gồm tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa năng. Khác với hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ slide bố cục hoặc slide mẫu.

Aspose.Slides cung cấp thông tin placeholder qua thuộc tính [IShape.Placeholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/placeholder/). Thuộc tính này trả về một đối tượng [IPlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/iplaceholder/) hoặc `null` đối với hình dạng bình thường. Sử dụng [IPlaceholder.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/iplaceholder/type/) để xác định placeholder dự định chứa gì.

Giao diện hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder trống cho văn bản, hình ảnh, biểu đồ hoặc nội dung thường được biểu diễn bằng một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/).
- Placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/iplaceholder/type/) và giao diện hình dạng thời gian chạy thay vì giả định mọi placeholder đều là một [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Cảnh báo" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/iplaceholder/type/) mô tả vai trò của placeholder; nó không đảm bảo kiểu thời gian chạy của hình dạng. Luôn kiểm tra kiểu trước khi truy cập các thành viên specific cho văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholder tạo thành một cây phân cấp:

1. Slide mẫu định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức mẫu.
2. Slide bố cục định nghĩa cách sắp xếp được sử dụng bởi một hoặc nhiều slide bình thường và có thể kế thừa từ slide mẫu.
3. Slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getbaseplaceholder/) để di chuyển lên một cấp trong cây phân cấp này. Một placeholder trên slide thường trả về placeholder trên bố cục; một placeholder trên bố cục có thể trả về placeholder trên mẫu. Phương thức trả về `null` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Chỉnh sửa một placeholder trên slide bình thường sẽ tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa bố cục hoặc mẫu liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa cài đặt đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Thay đổi văn bản trong Placeholder**

Tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và các placeholder văn bản thường hỗ trợ văn bản. Kiểm tra [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) trước khi sử dụng thuộc tính [TextFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/textframe/) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu tiên và lưu kết quả:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Mẫu này tránh việc ép kiểu các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện sang [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/). Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào chỉ mục hình dạng dễ bị phá vỡ.

## **Đặt văn bản nhắc trên Layout**

Văn bản nhắc là hướng dẫn thời gian thiết kế hiển thị trong một placeholder trống, ví dụ *Nhấp để thêm tiêu đề*. Đặt văn bản nhắc tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập nó thông qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout qua [ISlide.LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/layoutslide/) và lặp qua [ILayoutSlide.Shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide/shapes/).

Ví dụ sau thay đổi nhắc tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Văn bản nhắc không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, nhắc sẽ không còn hiển thị. Thay đổi nhắc cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Placeholder hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/), thay thế hình ảnh qua [IPictureFillFormat.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/ipicturefillformat/picture/) và [ISlidesPicture.Image](https://reference.aspose.com/slides/vi/net/aspose.slides/islidespicture/image/).
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addpictureframe/) và xóa placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản thuyết trình:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [IShape.Placeholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/placeholder/) chỉ đọc. Nó giữ vị trí đã dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc duy trì quan hệ placeholder là quan trọng, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/vi/net/aspose.slides/ipictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt hình ảnh, cắt và các hiệu ứng đặc thù của picture, xem [Manage Picture Frames](/slides/vi/net/picture-frame/). Các thao tác này thuộc picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Placeholder biểu đồ và nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/). Ví dụ này tìm biểu đồ đó bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề và lưu tệp:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/vi/net/aspose.slides/placeholdertype/). Trong PowerPoint nó hoạt động như một bộ khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các layout chuyên dụng cũng có thể hiển thị [PlaceholderType.Chart](https://reference.aspose.com/slides/vi/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/vi/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/vi/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/vi/net/aspose.slides/placeholdertype/), hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/vi/net/aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/iautoshape/) trống thành một [IChart](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichart/) chỉ bằng cách thay đổi [IPlaceholder.Type](https://reference.aspose.com/slides/vi/net/aspose.slides/iplaceholder/type/); loại này chỉ đọc. Để lấp đầy một biểu đồ hoặc vùng nội dung trống bằng chương trình, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xóa placeholder trống. Ví dụ sau thực hiện điều này cho một biểu đồ:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm khu vực của placeholder nhưng không kế thừa từ placeholder trên layout. Sử dụng các bài viết quản lý biểu đồ chuyên biệt [chart management articles](/slides/vi/net/powerpoint-charts/) khi bạn cần thay thế danh mục, series hoặc dữ liệu workbook của nó.

## **Ví dụ hoàn chỉnh: Cập nhật nội dung Văn bản hoặc Hình ảnh**

Ví dụ end-to-end phía dưới mở một mẫu, tìm kiếm slide đầu tiên để xác định placeholder tiêu đề hoặc hình ảnh, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ này cố ý tránh việc giả định chỉ mục hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc mẫu mà một placeholder khác kế thừa. Sử dụng [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/getbaseplaceholder/) để lấy nó. Một hình dạng cục bộ thông thường trả về `null` vì nó không thuộc cây phân cấp placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder trên layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản nhắc thông qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế thực tế văn bản tiêu đề trên toàn bộ bản thuyết trình, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý tiêu đề và chân trang ở phạm vi slide, layout, mẫu, ghi chú hoặc bản phát tay tương ứng. Xem [Manage Presentation Header and Footer](/slides/vi/net/presentation-header-and-footer/) để biết các ví dụ đầy đủ.