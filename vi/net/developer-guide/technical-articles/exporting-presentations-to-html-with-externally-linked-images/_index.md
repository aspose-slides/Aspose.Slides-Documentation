---
title: Xuất bài thuyết trình sang HTML với hình ảnh được liên kết bên ngoài
type: docs
weight: 100
url: /vi/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bài thuyết trình
- xuất slide
- xuất PPT
- xuất PPTX
- xuất ODP
- PowerPoint sang HTML
- OpenDocument sang HTML
- bài thuyết trình sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- hình ảnh liên kết
- hình ảnh được liên kết bên ngoài
- tài nguyên liên kết
- tài nguyên bên ngoài
- .NET
- C#
- Aspose.Slides
description: "Xuất các bài thuyết trình PowerPoint và OpenDocument sang HTML trong .NET bằng Aspose.Slides, với hình ảnh và các tài nguyên khác được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bài thuyết trình thành một tệp HTML tự chứa. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp di động duy nhất, nhưng không phải luôn là định dạng tốt nhất cho một trang web, một CMS, hoặc một pipeline chuyển đổi phía máy chủ.

Sử dụng các tài nguyên được liên kết bên ngoài khi bạn muốn:

- giảm kích thước của tài liệu HTML;
- lưu trữ bộ nhớ đệm cho hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý hậu kỳ các tài nguyên đã tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Chuyển đổi bài thuyết trình PowerPoint sang HTML](/slides/vi/net/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động của xuất tài nguyên có liên kết**

[ILinkEmbedController](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/) cho phép ứng dụng của bạn quyết định, từng tài nguyên một, liệu trình xuất có nhúng dữ liệu vào HTML hay lưu chúng bên ngoài và ghi một liên kết.

Giao diện có ba phương thức:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) quyết định liệu một tài nguyên nên được liên kết hay nhúng.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/geturl/) trả về URL sẽ được ghi vào HTML đã tạo hoặc vào tài nguyên liên kết khác.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) ghi dữ liệu tài nguyên liên kết ra đĩa hoặc tới mục tiêu lưu trữ khác.

Đường dẫn hệ thống tập tin và URL của trình duyệt là hai vấn đề riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt giải quyết các URL này tương đối với tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` tới tệp SVG sử dụng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó tới hình ảnh được lưu trong cùng thư mục `assets` sử dụng `resource-4.jpg`.

## **Xuất HTML với các tài nguyên có liên kết**

Ví dụ C# sau tạo một thư mục đầu ra, lưu tệp HTML ở đó, và lưu các tài nguyên liên kết trong một thư mục con `assets`. Bộ điều khiển liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS phổ biến khi Aspose.Slides cung cấp hoặc có thể suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận dạng sẽ vẫn được nhúng.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

Sau khi xuất, thư mục đầu ra có cấu trúc sau:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Các tệp chính xác phụ thuộc vào nội dung bài thuyết trình và các tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn một codec ảnh khác với codec được dùng trong bài thuyết trình nguồn khi điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Hình ảnh có độ trong suốt sẽ được xuất dưới dạng PNG.

## **Chọn URL cho triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên liên kết tham chiếu tới tài nguyên liên kết khác, mẫu sử dụng tham số `referrer` trong [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/geturl/) và chỉ trả về tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu tới `resource-4.jpg`, chứ không phải `assets/resource-4.jpg`.

Sử dụng một tiền tố URL khác khi các tệp được triển khai ở nơi khác:

- Dùng `assets/` khi thư mục tài sản nằm cạnh tệp HTML.
- Dùng `../assets/` khi thư mục tài sản một cấp trên tệp HTML.
- Dùng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

URL được trả về bởi [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/geturl/) phải khớp với vị trí cuối cùng của tệp được ghi bởi [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). Trong các ứng dụng máy chủ, sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh ghi đè các tệp từ một lần xuất khác.

## **Khi nào nên nhúng thay vì**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước ngoại tuyến, hoặc tài liệu sẽ được di chuyển mà không có thư mục tài sản hỗ trợ. Các tài nguyên liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, tối ưu hoá bằng pipeline xây dựng, hoặc được bộ nhớ đệm bởi trình duyệt một cách độc lập với HTML.

## **Câu hỏi thường gặp**

**Tôi có thể chỉ tách riêng hình ảnh ra ngoài và giữ các tài nguyên khác được nhúng không?**

Có. Trong [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), trả về `LinkEmbedDecision.Link` chỉ cho các kiểu nội dung bạn muốn lưu dưới dạng tệp riêng, và trả về `LinkEmbedDecision.Embed` cho tất cả các loại còn lại.

**Tại sao phần mở rộng ảnh xuất ra lại khác với bài thuyết trình nguồn?**

Aspose.Slides có thể mã hoá lại hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc khả năng tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy thuộc vào kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

Các URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối vẫn được giữ nguyên. Nếu HTML tham chiếu tới `assets/resource-1.png`, thư mục `assets` phải nằm cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Hãy sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ cho mỗi công việc chuyển đổi. Điều này tránh xung đột tên tệp và ngăn một lần xuất ghi đè tài nguyên được tạo bởi lần xuất khác.