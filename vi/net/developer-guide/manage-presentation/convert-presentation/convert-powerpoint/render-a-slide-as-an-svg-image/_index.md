---
title: Xuất slide trình chiếu thành hình ảnh SVG trong .NET
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xuất slide PowerPoint thành hình ảnh SVG trong .NET và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, phù hợp cho xuất bản web, trình xem slide, quy trình hỗ trợ truy cập và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách viết văn bản, phông chữ, hình ảnh và các phần tử SVG.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/) khi SVG được xuất cần gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc tương tác.

## **Xuất một slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), chọn một slide, và ghi nó vào một luồng. Ví dụ sau xuất mỗi slide trong một bản trình chiếu thành một tệp SVG riêng.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Tên tệp sử dụng [ISlide.SlideNumber](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/slidenumber/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape.WriteAsSvg](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/writeassvg/) khi một trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/useframesize/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/useframerotation/) xác định việc áp dụng xoay khung. Đặt [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/disablefontligatures/) thành `true` khi văn bản phải được render mà không có ligature.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Kiểm soát Văn bản và Phông chữ**

### **Biểu diễn Văn bản Dưới dạng Vector**

Đặt [SVGOptions.VectorizeText](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/vectorizetext/) thành `true` để ghi tất cả văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm kết quả hiển thị đồng nhất hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hoặc tìm kiếm dưới dạng văn bản SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Chọn Cách Xử lý Phông chữ Ngoại vi**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/externalfontshandling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgexternalfontshandling/) cho các phông chữ được tải ngoại vi. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để đưa dữ liệu phông chữ vào SVG, hoặc `Vectorize` để chỉ render văn bản sử dụng phông chữ ngoại vi dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông chữ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Giảm Kích thước Hình ảnh Được Nhúng**

Sử dụng [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/picturescompression/) để giảm độ phân giải của hình ảnh nhúng, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) để bỏ qua các khu vực ảnh đã cắt, và [SVGOptions.JpegQuality](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/jpegquality/) để kiểm soát chất lượng mã hoá JPEG. Các thiết lập này giảm kích thước tệp với chi phí là giảm độ trung thực hình ảnh hoặc dữ liệu ảnh được giữ lại.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Gán ID Ổn định cho Hình dạng và Văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgshapeformattingcontroller/) để đặt [ISvgShape.Id](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgshape/id/) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan.Id](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgtspan/id/) trên các phần tử `tspan` của văn bản, triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Gán một trong hai controller bằng [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Controller dưới đây sử dụng [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/officeinteropshapeid/), vốn ổn định trong suốt vòng đời của hình dạng, và một bộ đếm lặp lại cho các đoạn văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình chiếu không thay đổi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Thêm Trình xử lý Sự kiện SVG**

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgshapeformattingcontroller/), gọi [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isvgshape/seteventhandler/) với một giá trị [SvgEvent](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán controller bằng [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Trang chủ có thể định nghĩa hàm JavaScript được tham chiếu bởi trình xử lý. Gán ID và trình xử lý sự kiện cho phép trình xem slide, cải tiến khả năng truy cập và các quy trình SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.VectorizeText](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/vectorizetext/) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.VectorizeText](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/vectorizetext/) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ ngoại vi cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho SVG nhỏ hơn là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xóa các khu vực ảnh đã cắt, và chọn các tệp phông chữ liên kết khi môi trường đích có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG thấp hơn, và văn bản được vector hóa đều có các thỏa hiệp về chất lượng và kích thước khác nhau.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một controller định dạng, sau đó chọn các phần tử SVG phù hợp trong công cụ xử lý hậu kỳ hoặc tập lệnh trình duyệt của bạn.