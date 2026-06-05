---
title: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 50
url: /zh/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 导出演示页
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint to HTML
- OpenDocument to HTML
- 演示文稿 to HTML
- 演示页 to HTML
- PPT to HTML
- PPTX to HTML
- ODP to HTML
- 链接图像
- 外部链接图像
- 链接资源
- 外部资源
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，并将图像和其他资源保存为外部链接文件。"
---
## **概览**

默认情况下，Aspose.Slides 将演示文稿导出为一个独立的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单个可移植文件时很方便，但并不总是适合网站、CMS 或服务器端转换流水线的最佳格式。

当您希望：

- 减少 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 使输出结构更接近 Web 应用程序的预期

时，请使用外部链接资源。

有关通用 HTML 转换工作流，请参阅[Convert PowerPoint Presentations to HTML](/slides/zh/cpp/convert-powerpoint-to-html/)。本文重点介绍导出过程中的资源链接部分。

## **链接资源导出工作原理**

[ILinkEmbedController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/) 让您的应用程序能够逐资源决定是将数据嵌入 HTML，还是外部保存并写入链接。

该接口包含三个方法：

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 决定资源是链接还是嵌入。
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 返回将写入生成的 HTML 或其他链接资源的 URL。
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) 将链接资源数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是分离的概念。例如，下面的示例将资源文件写入磁盘的 `html-output/assets`，而 HTML 中包含相对 URL 如 `assets/resource-1.svg`。浏览器会相对于包含链接的文件解析这些 URL。因此，从 `presentation.html` 链接到 SVG 文件使用 `assets/resource-1.svg`，而该 SVG 文件再链接到同一 `assets` 文件夹中的图像时使用 `resource-4.jpg`。

## **使用链接资源导出 HTML**

以下 C++ 示例创建输出目录，将 HTML 文件保存到该目录，并在 `assets` 子目录中存储链接资源。当 Aspose.Slides 提供或可以推断安全的文件扩展名时，控制器会链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源保持嵌入。

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

具体文件取决于演示文稿的内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。Aspose.Slides 可能会选择不同于源演示文稿的图像编解码器，以生成更小或更合适的文件。带有透明度的图像会导出为 PNG。

## **为部署选择 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 中使用 `referrer` 参数，并仅返回文件名。例如，如果 `resource-1.svg` 和 `resource-4.jpg` 都位于 `assets` 文件夹，则 SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

当文件部署在其他位置时，请使用不同的 URL 前缀：

- 当资产目录与 HTML 文件相邻时，使用 `assets/`。
- 当资产目录位于 HTML 文件上一级时，使用 `../assets/`。
- 当文件上传到 CDN 或静态文件服务器时，使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 返回的 URL 必须与 [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) 写入的文件最终部署位置相匹配。在服务器应用程序中，为每个转换任务使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出生成的文件。

## **何时使用嵌入而不是链接**

当输出必须是单个文件时（例如电子邮件附件、离线预览或将在没有支持资产文件夹的情况下移动的文档），嵌入的 Base64 HTML 仍然有用。链接资源更适合在 Web 应用程序提供 HTML、存储在 CMS、通过构建流水线优化或由浏览器独立缓存的场景。

## **常见问题**

**我可以仅外部化图像而保持其他资源嵌入吗？
