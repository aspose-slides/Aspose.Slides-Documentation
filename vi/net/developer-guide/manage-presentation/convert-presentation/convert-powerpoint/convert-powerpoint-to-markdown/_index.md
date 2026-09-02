---
title: Chuyển đổi bản trình bày PowerPoint sang Markdown trong .NET
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/net/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản trình bày sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản trình bày dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- xuất ảnh Markdown
- liên kết ảnh CDN
- PowerPoint
- bản trình bày
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PPT và PPTX sang Markdown trong .NET và kiểm soát vị trí lưu và cách tham chiếu các hình ảnh bitmap, metafile và SVG đã xuất."
---
## **Tổng quan**

Aspose.Slides for .NET có thể chuyển đổi các bản trình bày PPT và PPTX sang Markdown để tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn một kiểu Markdown, kiểm soát cách nội dung slide được hiển thị, và quyết định nơi lưu trữ hình ảnh đã xuất và cách Markdown tạo ra tham chiếu đến chúng.

Mặc định, xuất Markdown chỉ sử dụng đầu ra dạng văn bản. Để xuất nội dung hình ảnh, đặt thuộc tính [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/exporttype/) thành giá trị `Sequential` hoặc `Visual` từ enum [MarkdownExportType](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownexporttype/). `Sequential` hiển thị các mục slide riêng rẽ và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo toàn mối quan hệ trực quan. Giá trị `TextOnly` không phát ra tài nguyên hình ảnh, vì vậy các sự kiện lưu hình ảnh sẽ không được gọi trong chế độ này.

## **Chuyển đổi bản trình bày sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), sau đó gọi phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) với giá trị `Md` từ enum [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Chọn Kiểu Markdown**

Thuộc tính [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/flavor/) kiểm soát tiêu chuẩn Markdown được sử dụng cho đầu ra. Enum [Flavor](https://reference.aspose.com/slides/vi/net/aspose.slides.export/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể được hỗ trợ khác.

Ví dụ sau xuất một bản trình bày dưới dạng CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Xuất Hình ảnh bằng Hành vi Lưu Trữ Cục bộ Mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/) cung cấp hai thuộc tính cho hình ảnh được lưu cục bộ:

- [BasePath](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/basepath/) chỉ định thư mục cơ sở cho tài liệu Markdown và các tài nguyên của nó.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) chỉ định thư mục con cho hình ảnh. Giá trị mặc định của nó là `Images`.

Ví dụ sau hiển thị nội dung hình ảnh, ghi hình ảnh vào `output/assets`, và tạo các tham chiếu ảnh tương đối trong tài liệu Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Hành vi này cũng đóng vai trò dự phòng khi một bộ xử lý lưu ảnh tùy chỉnh trả về `false`.

## **Tùy chỉnh việc Lưu Hình ảnh và Liên kết Markdown**

Sử dụng sự kiện [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/imagesaving/) cho các tài nguyên bitmap và metafile không phải SVG được phát ra trong quá trình xuất Markdown. Delegate [MarkdownImageSavingHandler](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) của nó nhận đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/), đối tượng [ImageFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/), và liên kết Markdown được tạo dưới dạng tham số `ref string`. Lưu hoặc tải lên hình ảnh với định dạng được cung cấp, và thay thế `link` bằng tham chiếu phải xuất hiện trong đầu ra Markdown.

Các tài nguyên phát ra dưới định dạng SVG được xử lý riêng. Đăng ký sự kiện [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), delegate [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) của nó nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) và tham số `ref string link`. Một SVG không có đối số `ImageFormat`; ghi hoặc tải lên dữ liệu XML của nó từ thuộc tính [ISvgImage.SvgData](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/svgdata/) thay thế. Tùy thuộc vào chế độ xuất và cách nhóm trực quan, một SVG trong bản trình bày nguồn có thể được raster hoá hoặc kết hợp với nội dung khác; tài nguyên không phải SVG kết quả sẽ được chuyển tới `ImageSaving`. Đăng ký cả hai sự kiện khi mọi tài nguyên hình ảnh xuất cần xử lý tùy chỉnh.

Giá trị trả về của bộ xử lý quyết định ai sẽ xử lý hình ảnh:

- Trả về `true` sau khi bộ xử lý đã lưu, tải lên, chuyển đổi, hoặc xử lý hình ảnh và đã gán một giá trị hợp lệ cho `link`. Aspose.Slides sẽ ghi giá trị này vào tài liệu Markdown và không thực hiện lưu cục bộ mặc định.
- Trả về `false` để cho phép Aspose.Slides lưu hình ảnh cục bộ và tạo liên kết theo [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/basepath/) và [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Một bộ xử lý trả về `true` chịu trách nhiệm về hình ảnh. Nếu nó trả về `true` mà không gán một liên kết hợp lệ, không rỗng, quá trình xuất sẽ thất bại với một `InvalidOperationException`.
{{% /alert %}}

### **Lưu Hình ảnh vào Thư mục Gốc CDN và Sử dụng URL Bên ngoài**

Ví dụ sau xem `cdn-origin/presentations/quarterly-report` như một thư mục gốc CDN đã được gắn hoặc đồng bộ. Mỗi bộ xử lý trích xuất tên tệp được tạo, lưu hình ảnh vào thư mục tùy chỉnh đó, và thay thế tham chiếu cục bộ đã tạo bằng một URL công cộng của CDN. Mẫu này không thực hiện tải lên mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm gốc CDN hoặc các tệp của nó được công bố lên CDN. Đối với lưu trữ đối tượng, thay thế thao tác ghi hệ thống tệp bằng thao tác tải lên của SDK lưu trữ và gán `link` chỉ sau khi tải lên thành công.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Bộ xử lý bitmap cố ý trả về `false` cho các hình ảnh nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu những hình ảnh này vào `output/fallback-images` theo hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như tài nguyên SVG, được xử lý bởi mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ được tạo như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các bộ xử lý chỉ sử dụng các đường dẫn hệ điều hành khi ghi tệp; các liên kết được ghi vào Markdown sử dụng dấu gạch chéo xuôi và tên tệp đã được mã hoá URL. Áp dụng quy tắc tương tự khi xây dựng liên kết tương đối: dùng `/`, không dùng dấu phân tách thư mục riêng của nền tảng.

## **FAQ**

**Một bộ xử lý có thể xử lý cả ảnh raster và ảnh SVG không?**

Không. Sử dụng [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/imagesaving/) cho các tài nguyên bitmap và metafile được phát ra và [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) cho các tài nguyên được phát ra dưới dạng SVG. Bộ đầu tiên cung cấp một đối tượng [IImage](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/) và một [ImageFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/); bộ thứ hai cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/) mà dữ liệu SVG có thể đọc từ [ISvgImage.SvgData](https://reference.aspose.com/slides/vi/net/aspose.slides/isvgimage/svgdata/). Một SVG nguồn bị raster hoá trong quá trình xuất sẽ được xử lý bởi `ImageSaving` thay vì `SvgImageSaving`.

**Điều gì xảy ra khi bộ xử lý lưu ảnh trả về `false`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí hình ảnh và tham chiếu được tạo sẽ được kiểm soát bởi [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/basepath/) và [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/vi/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Bộ xử lý có thể cung cấp URL mà không lưu ảnh cục bộ không?**

Có. Bộ xử lý có thể tải lên hình ảnh lên lưu trữ đối tượng hoặc chuyển cho dịch vụ khác, gán URL kết quả cho `link`, và trả về `true`. Bộ xử lý phải hoàn thành việc xử lý tự mình; trả về `true` sẽ ngăn hành vi lưu cục bộ mặc định.

**Tại sao việc xuất Markdown ném ra `InvalidOperationException` từ một bộ xử lý?**

Ngoại lệ này xảy ra khi bộ xử lý trả về `true` nhưng không cung cấp một liên kết hợp lệ. Gán đường dẫn tương đối hoặc URL bên ngoài mà nên được ghi vào Markdown trước khi trả về `true`.

**Dấu phân tách đường dẫn nào nên được sử dụng cho liên kết ảnh?**

Sử dụng dấu gạch chéo xuôi trong các liên kết Markdown và URL. Chỉ dùng `Path.Combine` cho các đường dẫn hệ thống, sau đó tạo hoặc chuẩn hoá tham chiếu Markdown riêng biệt.

**Liên kết siêu văn bản có được giữ nguyên khi xuất Markdown không?**

Có. Các [hyperlinks](/slides/vi/net/manage-hyperlinks/) văn bản được giữ dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/net/slide-transition/) và [animations](/slides/vi/net/powerpoint-animation/) của slide không được chuyển đổi.

**Có thể chuyển đổi nhiều bản trình bày sang Markdown đồng thời không?**

Bạn có thể xử lý các tệp bản trình bày khác nhau song song, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) giữa các luồng. Tuân theo [multithreading guidelines](/slides/vi/net/multithreading/) và sử dụng một thể hiện riêng cho mỗi tệp.