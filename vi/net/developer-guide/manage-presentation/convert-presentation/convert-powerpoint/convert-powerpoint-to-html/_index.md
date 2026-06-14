---
title: Chuyển đổi bản thuyết trình PowerPoint sang HTML trong .NET
linktitle: PowerPoint sang HTML
type: docs
weight: 30
url: /vi/net/convert-powerpoint-to-html/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang HTML
- bản thuyết trình sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- lưu PowerPoint dưới dạng HTML
- lưu bản thuyết trình dưới dạng HTML
- lưu slide dưới dạng HTML
- lưu PPT dưới dạng HTML
- lưu PPTX dưới dạng HTML
- xuất PPT sang HTML
- xuất PPTX sang HTML
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi bản thuyết trình PowerPoint sang HTML trong .NET. Sử dụng Aspose.Slides để xuất các tệp PPT và PPTX, các slide đã chọn, ghi chú, phông chữ, hình ảnh, SVG và media."
---
## **Tổng quan**

Aspose.Slides for .NET có thể lưu các bản thuyết trình PowerPoint dưới dạng HTML mà không cần Microsoft PowerPoint. Việc chuyển đổi cơ bản chỉ bao gồm một lần tải [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và một lời gọi [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) với [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/). Sử dụng [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/) khi bạn cần kiểm soát bố cục xuất, phông chữ, hình ảnh, ghi chú, chú thích, đầu ra SVG, hoặc các tài nguyên liên kết.

Hướng dẫn này tập trung vào các kịch bản xuất HTML thực tế:

- Xuất toàn bộ bản thuyết trình hoặc các slide đã chọn.
- Tạo HTML với bố cục cố định, đáp ứng, hoặc dựa trên SVG.
- Bao gồm ghi chú người thuyết trình và chú thích.
- Kiểm soát chất lượng hình ảnh và dữ liệu ảnh đã cắt.
- Nhúng phông chữ hoặc lưu các tệp phông chữ riêng biệt.
- Chọn cách các tài nguyên bên ngoài và tệp media được ghi và tham chiếu.

Mặc định, xuất HTML tạo ra một tài liệu HTML tự chứa, trong đó hầu hết các tài nguyên được nhúng. Điều này thuận tiện cho việc chia sẻ một tệp duy nhất, nhưng có thể làm tăng kích thước đầu ra. Đối với việc xuất bản web, hãy cân nhắc sử dụng tài nguyên bên ngoài, giảm DPI hình ảnh, và chỉ nhúng các phông chữ không có sẵn đáng tin cậy trong môi trường đích.

## **Chuyển đổi bản thuyết trình sang HTML**

Để xuất một bản thuyết trình sang HTML, tải nó bằng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và lưu bằng [SaveFormat.Html](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Ví dụ này ghi một tệp HTML. Đối tượng presentation được giải phóng bởi câu lệnh `using`, giúp giải phóng các tay cầm tệp và tài nguyên render sau khi xuất.

## **Sử dụng HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/) là lớp cấu hình chính cho việc xuất HTML. Các thiết lập thường gặp bao gồm:

- `SlidesLayoutOptions`: thêm ghi chú, chú thích, tài liệu phát tay, hoặc các thông tin bố cục khác.
- `HtmlFormatter`: thay đổi cấu trúc tài liệu HTML hoặc ủy thác việc định dạng cho một controller.
- `SlideImageFormat`: thay đổi cách biểu diễn các slide, ví dụ dưới dạng SVG.
- `PicturesCompression`: kiểm soát DPI hình ảnh và kích thước đầu ra.
- `DeletePicturesCroppedAreas`: giữ hoặc loại bỏ dữ liệu ảnh đã cắt.
- `SvgResponsiveLayout`: làm cho nội dung SVG được xuất thích ứng với container của nó.
- `ShowHiddenSlides`: bao gồm các slide ẩn khi cần.

Các phần sau đây trình bày các tùy chọn phổ biến nhất một cách riêng biệt để bạn có thể chỉ kết hợp những tùy chọn cần thiết cho quy trình làm việc của mình.

## **Chuyển đổi các slide đã chọn sang HTML**

Phương thức quá tải [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) cho phép chỉ định số slide sử dụng vị trí slide bắt đầu từ 1. Vòng lặp dưới đây lưu mỗi slide vào một tệp HTML riêng.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Sử dụng mẫu này khi một trang web hoặc ứng dụng cần một trang HTML cho mỗi slide. Nếu mỗi slide đều có cùng bố cục, tạo một thể hiện [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/) và truyền nó vào mỗi lời gọi `Save`.

## **Tạo HTML đáp ứng**

[ResponsiveHtmlController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/responsivehtmlcontroller/) cung cấp đầu ra HTML đáp ứng thông qua [HtmlFormatter](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmlformatter/). Sử dụng nó khi trang được xuất cần thích nghi tốt hơn với chiều rộng trình duyệt.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Đối với bố cục đáp ứng dựa trên SVG, đặt `SvgResponsiveLayout` trên [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/). Điều này hữu ích khi nội dung slide được xuất dưới dạng markup SVG có khả năng mở rộng.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Bao gồm ghi chú người thuyết trình và chú thích**

Sử dụng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/) thông qua `HtmlOptions.SlidesLayoutOptions` để bao gồm ghi chú người thuyết trình hoặc chú thích. Ghi chú và chú thích mặc định bị ẩn trừ khi bạn chỉ định vị trí của chúng.

Giả sử bản thuyết trình nguồn chứa ghi chú người thuyết trình:

![Slide có ghi chú người thuyết trình trong PowerPoint](slide_with_notes.png)

Mã dưới đây xuất nội dung slide cùng ghi chú người thuyết trình phía dưới slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

Kết quả HTML với slide và ghi chú người thuyết trình:

![Kết quả HTML với slide và ghi chú người thuyết trình](HTML_with_notes.png)

Để xuất chú thích, đặt `CommentsPosition`, ví dụ `CommentsPositions.Right` hoặc `CommentsPositions.Bottom`. Nếu chỉ cần chú thích, bỏ qua `NotesPosition`. Nếu cần cả ghi chú và chú thích, đặt cả hai thuộc tính.

## **Kiểm soát chất lượng hình ảnh và vùng đã cắt**

Xuất HTML có thể nén hình ảnh slide để giảm kích thước đầu ra. Đặt `PicturesCompression` thành giá trị từ [PicturesCompression](https://reference.aspose.com/slides/vi/net/aspose.slides.export/picturescompression/) khi bạn cần chất lượng hình ảnh cao hơn.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Mặc định, các vùng đã cắt của hình ảnh có thể bị loại bỏ khỏi đầu ra được xuất. Giữ dữ liệu đã cắt chỉ khi người dùng cần khôi phục hoặc kiểm tra những phần ảnh ẩn đó. Việc giữ lại có thể làm tăng kích thước HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Thêm CSS**

Đối với kiểu dáng đơn giản, truyền một chuỗi CSS vào [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Điều này thay đổi tài liệu HTML bao quanh trong khi Aspose.Slides vẫn tiếp tục render nội dung slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Đối với tiêu đề tài liệu tùy chỉnh, tệp CSS liên kết, hoặc markup tùy chỉnh xung quanh slide và shape, triển khai [IHtmlFormattingController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ihtmlformattingcontroller/) và truyền nó vào [HtmlFormatter](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmlformatter/) với `CreateCustomFormatter`.

## **Nhúng phông chữ**

Nếu môi trường đích có thể không cài đặt các phông chữ của bản thuyết trình, hãy nhúng phông chữ vào HTML bằng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/embedallfontshtmlcontroller/). Việc nhúng cải thiện độ trung thực hình ảnh nhưng làm tăng kích thước đầu ra.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Loại bỏ phông chữ chỉ khi bạn chắc chắn rằng các trình duyệt hoặc hệ thống đích đã cung cấp chúng. Đối với phông chữ thương hiệu hoặc phông chữ ít phổ biến, việc nhúng thường an toàn hơn.

## **Liên kết tệp phông chữ thay vì nhúng chúng**

Để giảm kích thước tệp HTML, bạn có thể ghi dữ liệu phông chữ vào các tệp WOFF riêng và thêm quy tắc `@font-face` vào HTML. Trợ giúp dưới đây mở rộng [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/embedallfontshtmlcontroller/) và ghi đè `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Trong ví dụ này, các tệp phông chữ được lưu vào `html-output/fonts`, và HTML tham chiếu chúng bằng URL như `fonts/BrandFont-normal-400.woff`. Nếu tệp HTML và phông chữ được triển khai ở vị trí khác, chọn `fontUrlPrefix` sao cho khớp với đường dẫn URL đã triển khai.

## **Lưu tài nguyên ra bên ngoài**

HTML tự chứa dễ di chuyển, nhưng các tài nguyên Base64 được nhúng có thể làm tệp lớn. Nếu ứng dụng của bạn cần các tệp hình ảnh bên ngoài, triển khai [ILinkEmbedController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/) và truyền nó vào hàm tạo [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/htmloptions/).

Khi bạn tách tài nguyên ra bên ngoài, hãy chọn hai đường dẫn một cách có ý thức:

- Đường dẫn xuất trên hệ thống tệp, nơi ứng dụng ghi các hình ảnh, phông chữ, âm thanh hoặc video đã tạo.
- Đường dẫn URL, là đường dẫn mà trình duyệt sử dụng từ tài liệu HTML để tải các tệp đó.

Đối với triển khai đầy đủ việc liên kết hình ảnh, xem [Export Presentations to HTML with Externally Linked Images](/slides/vi/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Xuất tệp media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/videoplayerhtmlcontroller/) xuất các tệp video và âm thanh và ghi HTML có thể phát chúng trong trình duyệt. Hàm tạo của nó nhận:

- `path`: thư mục nơi các tệp media được tạo sẽ được ghi.
- `fileName`: tên tệp HTML đang được tạo.
- `baseUri`: tiền tố URI tuyệt đối được dùng trong các liên kết HTML tới các tệp media.

Nếu tệp HTML là `html-output/presentation.html` và các tệp media được lưu trong `html-output/media`, `path` nên chỉ tới thư mục media trên đĩa, trong khi `baseUri` nên chỉ tới cùng thư mục từ góc nhìn của trình duyệt. Đối với bản xem trước cục bộ, bạn có thể xây dựng URI `file:///` từ thư mục media. Đối với ứng dụng đã triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Sử dụng các thư mục xuất duy nhất cho mỗi công việc xuất, đặc biệt trong các ứng dụng server. Các đường dẫn xuất chung có thể khiến các tệp từ các chuyển đổi khác nhau ghi đè lên nhau.

## **Hiệu năng và quản lý tài nguyên**

Chuyển đổi HTML là một thao tác render, vì vậy thời gian xử lý và mức sử dụng bộ nhớ phụ thuộc vào số slide, độ phân giải hình ảnh, phông chữ, hiệu ứng, biểu đồ và media được nhúng. Giá trị DPI `PicturesCompression` cao hơn, phông chữ nhúng, đầu ra SVG và việc giữ lại các vùng ảnh đã cắt có thể cải thiện độ trung thực nhưng thường làm tăng kích thước đầu ra.

Đối với chuyển đổi hàng loạt:

- Giải phóng ngay mọi instance của [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sau khi sử dụng.
- Sử dụng các thư mục xuất riêng biệt cho các công việc khác nhau.
- Tránh nhúng các phông chữ phổ biến trừ khi cần độ chính xác cao.
- Giảm DPI hình ảnh khi HTML chỉ dùng để xem trước hoặc làm thumbnail.
- Giữ bản thuyết trình gốc, HTML đã tạo và các tài nguyên bên ngoài cùng nhau cho đến khi đường dẫn triển khai cuối cùng.

## **FAQ**

**Liệu các siêu liên kết có được giữ lại trong đầu ra HTML không?**

Có. Các siêu liên kết trong bản thuyết trình được xuất sang HTML và vẫn có thể nhấp được khi URL mục tiêu hợp lệ.

**Tôi có thể chuyển đổi các bản thuyết trình sang HTML đồng thời không?**

Có, nhưng không chia sẻ một instance của [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) giữa các luồng. Xử lý các tệp khác nhau với các instance presentation riêng biệt, các stream riêng và các thư mục xuất riêng. Xem hướng dẫn [multithreading guidance](/slides/vi/net/multithreading/) để biết chi tiết.

**Đối tượng Presentation có an toàn với đa luồng không?**

Không. Một instance duy nhất của [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) nên được tải, sửa đổi, lưu và giải phóng trên cùng một luồng. Đối với công việc song song, tạo một instance độc lập cho mỗi luồng hoặc mỗi tiến trình.

**Tại sao tệp HTML được tạo ra lại lớn?**

Xuất mặc định có thể nhúng các tài nguyên trực tiếp vào HTML. Các phông chữ nhúng, hình ảnh DPI cao, media, nội dung SVG và việc giữ lại các vùng ảnh đã cắt cũng làm tăng kích thước. Sử dụng tài nguyên bên ngoài, loại bỏ các phông chữ phổ biến khỏi việc nhúng và giảm `PicturesCompression` khi kích thước nhỏ hơn quan trọng hơn độ trung thực tối đa.

**Tại sao kích thước phông chữ PowerPoint như 24 pt xuất hiện là 17.999819 pt trong HTML?**

Điều này có thể xảy ra vì PowerPoint và HTML sử dụng các mô hình DPI khác nhau. PowerPoint lưu kích thước văn bản bằng điểm typographic dựa trên 72 DPI, trong khi bố cục HTML dựa trên pixel CSS trong mô hình 96 DPI. Khi Aspose.Slides xuất bản thuyết trình sang HTML, kích thước phông chữ được chuyển đổi giữa hai hệ thống, và quá trình chuyển đổi có thể gây ra sự chênh lệch làm tròn nhỏ.

Các giá trị này không cho thấy sự thay đổi thực tế về kích thước phông chữ. Chúng chỉ là hệ quả toán học của việc chuyển đổi các chỉ số văn bản giữa PowerPoint và HTML.

**Làm sao để chọn baseUri cho việc xuất media?**

Chọn `baseUri` dựa trên góc nhìn của trình duyệt và truyền nó dưới dạng URI tuyệt đối. Đối với bản xem trước cục bộ, bạn có thể tạo nó từ thư mục xuất bằng `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Đối với triển khai, sử dụng URL tuyệt đối của thư mục media đã công bố. `path` trên hệ thống tệp và `baseUri` trong trình duyệt không cần phải là cùng một chuỗi, nhưng chúng phải mô tả cùng một vị trí tài nguyên.

**Tôi có thể bao gồm các slide ẩn không?**

Có. Đặt `ShowHiddenSlides = true` trên [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/) khi cần xuất các slide ẩn.