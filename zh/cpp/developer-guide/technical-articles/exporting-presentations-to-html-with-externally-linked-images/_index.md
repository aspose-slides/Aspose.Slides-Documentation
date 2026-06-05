---
title: 使用外部链接图像将演示文稿导出为 HTML
type: docs
weight: 50
url: /zh/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 导出幻灯片
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint 转 HTML
- OpenDocument 转 HTML
- 演示文稿转 HTML
- 幻灯片转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- 已链接图像
- 外部链接图像
- 已链接资源
- 外部资源
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，图像和其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为自包含的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单个可移植文件时很方便，但对网站、CMS 或服务器端转换流水线而言并不总是最佳格式。

当您希望：

- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 保持输出结构更接近 Web 应用程序的预期。

有关通用的 HTML 转换工作流，请参阅 [Convert PowerPoint Presentations to HTML](/slides/zh/cpp/convert-powerpoint-to-html/)。本文聚焦于导出的资源链接部分。

## **链接资源导出工作原理**

[ILinkEmbedController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/) 允许您的应用程序逐个资源决定是将数据嵌入 HTML，还是外部保存并写入链接。

该接口具有三个方法：

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 决定是否应链接或嵌入资源。
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 返回将写入生成的 HTML 或其他链接资源的 URL。
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) 将链接资源数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是不同的关注点。例如，下面的示例将资源文件写入磁盘上的 `html-output/assets`，而 HTML 中包含相对 URL，如 `assets/resource-1.svg`。浏览器会根据包含链接的文件相对解析这些 URL。因此，从 `presentation.html` 链接到 SVG 文件使用 `assets/resource-1.svg`，而该 SVG 文件链接到同一 `assets` 文件夹中保存的图像时使用 `resource-4.jpg`。

## **导出带链接资源的 HTML**

以下 C++ 示例会创建输出目录，将 HTML 文件保存到该目录，并将链接资源存储在 `assets` 子目录中。当 Aspose.Slides 提供或能够推断出安全的文件扩展名时，控制器会链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源仍保持嵌入。

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

导出后，输出文件夹的结构如下：

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

具体文件取决于演示文稿的内容和导出选项。例如，栅格图像通常导出为 JPEG 或 PNG。当这样能够生成更小或更适合的文件时，Aspose.Slides 可能会选择不同于源演示文稿的图像编码。带透明度的图像会导出为 PNG。

## **选择部署用的 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在 [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 中使用 `referrer` 参数，仅返回文件名。例如，如果 `resource-1.svg` 和 `resource-4.jpg` 均位于 `assets` 文件夹中，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

当文件部署在其他位置时，请使用不同的 URL 前缀：

- 当资源目录与 HTML 文件相邻时使用 `assets/`。
- 当资源目录位于 HTML 文件上一级时使用 `../assets/`。
- 当文件上传到 CDN 或静态文件服务器时使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 返回的 URL 必须与 [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) 写入的文件的最终部署位置相匹配。在服务器应用程序中，为每个转换作业使用唯一的输出目录或对象存储前缀，以避免覆盖来自其他导出的文件。

## **何时改为嵌入**

当输出必须是单个文件时，例如电子邮件附件、离线预览或将在没有支持资产文件夹的情况下移动的文档，嵌入的 Base64 HTML 仍然有用。HTML 将由 Web 应用程序提供、存储在 CMS 中、经由构建流水线优化或由浏览器独立缓存时，链接资源更为合适。

## **常见问题**

**我可以仅对图像进行外部化，而保持其他资源嵌入吗？**

是的。在 [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 中，仅对希望保存为独立文件的内容类型返回 `LinkEmbedDecision::Link`，其余全部返回 `LinkEmbedDecision::Embed`。

**为什么导出的图像扩展名与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出期间重新编码栅格图像，以改善体积或浏览器兼容性。例如，源文件中的图像可能会根据渲染结果被写入为 JPEG 或 PNG。

**在移动 HTML 文件后，相对 URL 仍然有效吗？**

相对 URL 仅在保持相同的相对文件夹结构时有效。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持相邻，除非您生成了不同的 URL 前缀。

**服务器应用程序应该复用相同的输出文件夹吗？**

不。为每个转换作业使用唯一的输出目录或存储前缀。这可以避免文件名冲突，并防止一次导出覆盖另一导出生成的资源。