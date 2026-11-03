---
title: Quản lý Placeholder của Bài thuyết trình trong .NET
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/net/manage-placeholder/
keywords:
- placeholder
- placeholder văn bản
- placeholder hình ảnh
- placeholder biểu đồ
- placeholder nội dung
- văn bản nhắc
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, đồng thời hiểu về kế thừa placeholder với Aspose.Slides cho .NET."
---
## **Tổng quan**

Placeholder là một hình dạng dự trữ vị trí cho một loại nội dung cụ thể trong mẫu bản trình chiếu. Các ví dụ phổ biến là placeholder tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa năng. Không giống như một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ một slide bố cục hoặc slide chủ.

Aspose.Slides cung cấp thông tin placeholder thông qua thuộc tính [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). Thuộc tính trả về một đối tượng [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) hoặc `null` cho một hình dạng bình thường. Sử dụng [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) để xác định placeholder dự định chứa gì.

Giao diện hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder văn bản, hình ảnh, biểu đồ hoặc nội dung trống thường được biểu diễn bằng một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) và giao diện hình dạng thời gian chạy thay vì giả định rằng mọi placeholder đều là một [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) mô tả vai trò của placeholder; nó không đảm bảo loại thời gian chạy của hình dạng. Luôn luôn kiểm tra loại trước khi truy cập các thành viên đặc trưng cho văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về Kế thừa Placeholder**

Placeholder tạo thành một phân cấp:

1. Một slide chủ định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder cấp master.
2. Một slide bố cục định nghĩa bố trí được sử dụng cho một hoặc nhiều slide bình thường và có thể kế thừa từ master.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ bố cục của nó.

Gọi [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) để di chuyển lên một cấp trong phân cấp này. Một placeholder slide thường trả về placeholder bố cục của nó; một placeholder bố cục có thể trả về placeholder master. Phương thức trả về `null` khi hình dạng không có placeholder cơ sở.

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

Chỉnh sửa một placeholder trên slide bình thường tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Xóa Trạng thái Placeholder**

Khi tùy chỉnh một mẫu, sử dụng [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) để giữ đối tượng hiện có như một hình dạng thông thường. Thuộc tính [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) của nó trở thành `null`, nhưng hình dạng vẫn còn trong bộ sưu tập của slide. Ngược lại, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) xóa hình dạng khỏi bộ sưu tập đó.

Ví dụ sau yêu cầu `template.pptx` có ít nhất một slide và một placeholder văn bản không rỗng trên slide đầu tiên. Sử dụng một placeholder có định dạng được kế thừa từ layout hoặc master để thấy hiệu quả của việc xóa quan hệ đó. Ví dụ kiểm tra rằng cùng một hình dạng vẫn còn, gọi lại phương thức trên hình dạng giờ đã là hình thường, và lưu kết quả.

{{% alert color="warning" title="Warning" %}}
Xóa trạng thái placeholder không tự động giữ các thiết lập hiển thị đã kế thừa. Ví dụ dưới đây cố tình để các thiết lập đó không thay đổi, vì vậy đầu ra có thể trông khác. Một hình dạng mà vị trí và kích thước hoàn toàn được kế thừa có thể có tọa độ và kích thước bằng 0 sau lời gọi và trở nên vô hình ngay cả khi nó vẫn còn trong bộ sưu tập.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Gọi phương thức trên một hình dạng thông thường không có tác dụng.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Đối với một placeholder phù hợp, cả ba kiểm tra đều in ra `True`. Văn bản vẫn còn, nhưng vị trí, kích thước, góc quay, phông chữ, căn đoạn, lề khung văn bản, neo dọc, nền và các thiết lập đường viền có thể thay đổi khi quan hệ placeholder bị xóa. Ví dụ, định dạng tiêu đề đã kế thừa có thể quay lại định dạng văn bản thông thường. Xem [Slide Layout](/slides/vi/net/slide-layout/) để biết thêm về layout.

Để giữ nguyên diện mạo mong muốn, hãy ghi lại vị trí, kích thước và góc quay đã được giải quyết trước lời gọi, và sao chép các giá trị định dạng hiệu quả cần thiết vào các biến riêng. Lấy các giá trị này thông qua [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), và [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Đừng chỉ dựa vào các đối tượng định dạng hiệu quả, vì các giá trị định dạng văn bản của chúng có thể thay đổi sau khi quan hệ bị xóa. Áp dụng rõ ràng các giá trị đã ghi lại cho hình dạng thông thường sau đó, bao gồm họ phông chữ, kích thước, kiểu, màu sắc, thiết lập đoạn văn, thiết lập khung văn bản, nền và đường viền được mẫu của bạn sử dụng.

Định dạng hình học đã kế thừa cũng có thể cần được gán rõ ràng qua [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Đối với một placeholder văn bản hình chữ nhật, điều này có nghĩa là gán [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); chỉ khôi phục nền và đường viền có thể không khôi phục lại hình chữ nhật hiển thị. Các mẫu có hiệu ứng bổ sung hoặc định dạng phức tạp hơn cũng cần xử lý các thiết lập đó.

## **Thay đổi Văn bản trong Placeholder**

Tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và placeholder văn bản thường hỗ trợ văn bản. Kiểm tra [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) trước khi sử dụng thuộc tính [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) của nó.

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

Mẫu này tránh việc ép kiểu các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện sang [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Nó cũng xác định placeholder dựa trên mục đích thay vì dựa vào chỉ số hình dạng dễ hỏng.

## **Đặt Văn bản Nhắc trên Layout**

Văn bản nhắc là hướng dẫn thời gian thiết kế được hiển thị trong một placeholder trống, như *Click to add title*. Đặt văn bản nhắc tùy chỉnh trên placeholder layout thay vì cố gắng truy cập nó qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout qua [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) và lặp qua [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

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

Văn bản nhắc không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, nhắc sẽ không còn hiển thị. Thay đổi nhắc cũng không thay thế văn bản hiện có trên các slide dùng layout đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), thay thế hình ảnh qua [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) và [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Nếu nó vẫn là một placeholder trống, thêm một khung hình ảnh tại tọa độ của placeholder bằng [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) và xóa placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

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

Việc thay thế được tạo cho một placeholder trống là một khung hình ảnh cục bộ, không phải một placeholder mới, vì [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) chỉ đọc. Nó giữ vị trí đã dự trữ nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ quan hệ placeholder là thiết yếu, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt hình ảnh, cắt và các hiệu ứng đặc thù của hình ảnh, xem [Manage Picture Frames](/slides/vi/net/picture-frame/). Các thao tác đó thuộc về khung hình ảnh hoặc nền hình, không phải siêu dữ liệu của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và giao diện thời gian chạy, thay đổi tiêu đề của nó và lưu file:

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

Một placeholder nội dung chung thường có [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). Trong PowerPoint nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra giao diện hình dạng thực tế để biết nó chứa gì. Các layout chuyên biệt cũng có thể biểu hiện [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), hoặc [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) trống thành một [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) chỉ bằng cách thay đổi [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); loại này chỉ đọc. Để điền một biểu đồ hoặc vùng nội dung trống một cách lập trình, thêm đối tượng cần thiết tại tọa độ của placeholder rồi xóa placeholder trống. Ví dụ sau thực hiện điều này cho một biểu đồ:

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

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm diện tích của placeholder nhưng không kế thừa từ placeholder layout. Sử dụng các [chart management articles](/slides/vi/net/powerpoint-charts/) khi bạn cần thay thế các danh mục, chuỗi hoặc dữ liệu workbook của nó.

## **Ví dụ hoàn chỉnh: Cập nhật Nội dung Văn bản hoặc Hình ảnh**

Ví dụ end-to-end sau mở một mẫu, tìm kiếm slide đầu tiên cho một placeholder tiêu đề hoặc hình ảnh, kiểm tra loại placeholder và hình dạng, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ cố tình tránh giả định chỉ mục hình dạng hoặc ép kiểu mọi placeholder sang cùng một giao diện.

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

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà một placeholder khác kế thừa. Sử dụng [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) để lấy nó. Một hình dạng cục bộ thông thường trả về `null` vì nó không thuộc phần của cây placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa placeholder trên layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản nhắc qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý placeholder ngày, số slide, header và footer?**

Sử dụng các trình quản lý header và footer ở phạm vi slide, layout, master, notes hoặc handout tương ứng. Xem [Manage Presentation Header and Footer](/slides/vi/net/presentation-header-and-footer/) để biết các ví dụ hoàn chỉnh.