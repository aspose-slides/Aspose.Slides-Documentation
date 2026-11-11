---
title: Xuất các slide bản trình chiếu dưới dạng hình ảnh SVG trong .NET
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bản trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong .NET và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng được, hoạt động tốt cho việc xuất bản web, trình xem slide, quy trình tiếp cận, và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide ra một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các yếu tố SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) khi SVG được xuất cần gọn gàng, dự đoán được trên các trình duyệt, hoặc chuẩn bị cho việc sử dụng tương tác.

## **Xuất một slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), chọn một slide và ghi nó vào luồng. Ví dụ dưới đây xuất mọi slide trong một bản trình chiếu thành các tệp SVG riêng biệt.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Tên tệp sử dụng [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) bao gồm khung văn bản trong khu vực render, và [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) xác định liệu việc xoay khung có được áp dụng hay không. Đặt [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) thành `true` khi văn bản phải được render mà không có ligatures.

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

## **Kiểm soát cắt đầu cuối đường tại các đầu mũi tên**

SVG 1.1 không có cài đặt inset marker để chỉ định nơi một đường nên dừng lại dưới đầu mũi tên. Theo mặc định, Aspose.Slides rút ngắn đường đã xuất để nét không lấn ra ngoài marker. Đặt [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) thành `true` để vẽ nét tới cuối điểm kết thúc gốc của đường. Cài đặt này chỉ ảnh hưởng đến đầu ra SVG. Đường vẫn giữ vị trí và độ dài trên slide.

Ví dụ vẽ các đầu mũi tên hình tam giác và hình kim cương trên các đường có độ rộng 2 và 10 điểm. Nó xuất cùng một slide hai lần, chỉ thay đổi tùy chọn cắt.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Sự so sánh cho thấy đầu mũi tên tam giác trên đường 10 điểm. Khi bật cắt, đầu mũi nhọn. Khi tắt cắt, nét lấn ra phía bên trong các cạnh nghiêng của marker và để lại một đầu phẳng.

![Tam giác 10‑điểm được phóng to với đầu nhọn khi bật cắt và đầu phẳng khi tắt cắt](line-end-cropping.png)

Trong các đường khác của ví dụ, nét lấn ra ít thấy hơn trên tam giác 2 điểm. Kim cương đậm phủ kín đầu nét ở cả hai độ rộng.

## **Kiểm soát văn bản và phông chữ**

Khi xuất slide sang SVG, bạn có thể kiểm soát việc văn bản giữ dạng văn bản hay được chuyển thành đồ họa vector, và cách phông chữ ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng độ nhất quán hình ảnh, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG đã xuất.

### **Vector hoá toàn bộ văn bản**

Đặt [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả hình ảnh nhất quán hơn trên các trình duyệt, nhưng văn bản không còn có thể chọn hoặc tìm kiếm dưới dạng SVG text.

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

### **Chọn cách xử lý phông chữ ngoài**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) sử dụng một giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông chữ trong SVG, hoặc `Vectorize` để render chỉ những văn bản sử dụng phông chữ ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông.

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

## **Giảm kích thước hình ảnh nhúng**

Sử dụng [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) để giảm độ phân giải của hình ảnh nhúng, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) để bỏ qua các khu vực đã cắt của nguồn hình ảnh, và [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là giảm độ trung thực hình ảnh hoặc dữ liệu hình ảnh được giữ lại.

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

## **Kiểm soát độ phân giải raster hoá Metafile**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) thiết lập giới hạn độ phân giải tối thiểu cho việc raster hoá metafile khi xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một hình ảnh EMF hoặc WMF được raster hoá. Nó không định nghĩa DPI toàn cục cho SVG hoặc buộc mọi đối tượng trên slide trở thành hình raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), chứa một hình ảnh EMF với các đường chéo gần nhau. Ví dụ dưới đây xuất slide đầu tiên của tệp này ở ba độ phân giải raster hoá khác nhau thông qua [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Tất cả các cài đặt xuất khác giữ nguyên để có thể so sánh kết quả.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Trong đầu ra, EMF trở thành một PNG nhúng trong mỗi SVG. Các đo lường sau áp dụng cho bản trình chiếu đã cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hoá Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây cho thấy cùng một vùng raster nhúng ở cùng kích thước hiển thị được phóng to. Các đường chéo hiển thị nhiễu pixel ở 72 DPI và cạnh mịn hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng lên. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hay thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo được phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) kiểm soát việc giảm độ phân giải hình ảnh và có thể che dấu ảnh hưởng của việc thay đổi độ phân giải raster hoá metafile. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hoá metafile.

## **Gán ID ổn định cho hình dạng và văn bản**

Sử dụng [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) để đặt [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) cho mỗi hình dạng SVG. Để đặt giá trị [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) cho các phần tử `tspan` trong văn bản, triển khai [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Gán bất kỳ controller nào bằng [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Controller dưới đây sử dụng [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), ổn định trong suốt vòng đời của hình dạng, và một bộ đếm lặp lại cho các span văn bản của nó. Điều này làm cho các ID được tạo phù hợp cho việc xử lý hậu kỳ một bản trình chiếu không thay đổi.

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

## **Thêm trình xử lý sự kiện SVG**

Trong một [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), gọi [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) với một giá trị [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán controller bằng [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

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

Trang chủ có thể định nghĩa hàm JavaScript mà trình xử lý tham chiếu tới. Gán ID và trình xử lý sự kiện cho phép trình xem slide, cải thiện khả năng truy cập và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào nên dùng [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Dùng [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) khi tất cả văn bản phải độc lập với phông chữ. Dùng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xóa các khu vực hình ảnh đã cắt, và chọn liên kết tới các tệp phông chữ khi môi trường đích có thể phục vụ chúng. Kiểm tra kết quả vì giảm độ phân giải hình ảnh, giảm chất lượng JPEG và vector hoá văn bản mỗi yếu tố đều có sự cân bằng giữa chất lượng và kích thước.

**Tôi có thể sửa đổi các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một controller định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.