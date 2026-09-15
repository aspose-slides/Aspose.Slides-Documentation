---
title: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- 演示文稿 转 HTML
- 幻灯片 转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- 链接图像
- 外部链接图像
- 链接资源
- 外部资源
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，图像和其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为一个独立的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单个便携文件时很方便，但并不总是适合网站、CMS 或服务器端转换流水线的最佳格式。

当您希望：

- 减少 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 使输出结构更接近 Web 应用程序的预期。

时，请使用外部链接资源。

有关通用的 HTML 转换工作流，请参阅[将 PowerPoint 演示文稿转换为 HTML](/slides/zh/python-java/convert-powerpoint-to-html/)。本文重点讨论导出过程中的资源链接部分。

## **链接资源导出工作原理**

`ILinkEmbedController` 允许您的应用程序逐个资源决定导出器是将数据嵌入 HTML，还是外部保存并写入链接。

该接口有三个方法：

- `ILinkEmbedController.getObjectStoringLocation` 决定资源是应链接还是嵌入。
- `ILinkEmbedController.getUrl` 返回将写入生成的 HTML 或其他链接资源的 URL。
- `ILinkEmbedController.saveExternal` 将链接资源的数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是独立的考量。例如，下面的示例将资源文件写入磁盘上的 `html-output/assets`，而 HTML 中包含相对 URL 如 `assets/resource-1.svg`。浏览器会相对于包含链接的文件解析这些 URL。因此，从 `presentation.html` 到 SVG 文件的链接使用 `assets/resource-1.svg`，而该 SVG 文件中指向同一 `assets` 文件夹内的图像时使用 `resource-4.jpg`。

## **导出带链接资源的 HTML**

以下 Python 示例创建输出目录，将 HTML 文件保存到该目录，并将链接资源存储在 `assets` 子目录中。当 Aspose.Slides 提供或能够推断安全的文件扩展名时，控制器会链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源仍保持嵌入。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
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

确切的文件取决于演示文稿内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。Aspose.Slides 可能会选择与源演示文稿不同的图像编解码器，以产生更小或更合适的文件。具有透明度的图像会导出为 PNG。

## **选择部署 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在 `ILinkEmbedController.getUrl` 中使用 `referrer` 参数，仅返回文件名。例如，如果 `resource-1.svg` 和 `resource-4.jpg` 都位于 `assets` 文件夹中，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

当文件部署在其他位置时，请使用不同的 URL 前缀：

- 当资源目录与 HTML 文件位于同一目录时，使用 `assets/`。
- 当资源目录位于 HTML 文件上一级时，使用 `../assets/`。
- 当文件上传至 CDN 或静态文件服务器时，使用 `https://cdn.example.com/presentations/job-123/assets/`。

`ILinkEmbedController.getUrl` 返回的 URL 必须与 `ILinkEmbedController.saveExternal` 写入的文件的最终部署位置相匹配。在服务器应用程序中，请为每个转换作业使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时改为嵌入**

当输出必须是单个文件时，嵌入的 Base64 HTML 仍然有用，例如电子邮件附件、离线预览或需要在没有支持资产文件夹的情况下移动的文档。HTML 将由 Web 应用程序提供、存储在 CMS 中、经过构建流水线优化或由浏览器独立缓存时，链接资源更为合适。

## **常见问题**

**我可以只外部化图像而保持其他资源嵌入吗？**

是的。在 `ILinkEmbedController.getObjectStoringLocation` 中，仅对您希望保存为单独文件的内容类型返回 [LinkEmbedDecision.Link](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linkembeddecision/#Link)，对其他全部返回 [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/linkembeddecision/#Embed)。

**为什么导出的图像扩展名与源演示文稿不同？**

Aspose.Slides 可能会在 HTML 导出期间重新编码光栅图像，以提升体积或浏览器兼容性。例如，源文件中的图像可能会根据渲染结果被写入为 JPEG 或 PNG。

**移动 HTML 文件后相对 URL 还能工作吗？**

相对 URL 仅在保持相同的相对文件夹结构时有效。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持相邻，除非您生成了不同的 URL 前缀。

**服务器应用程序应该重复使用相同的输出文件夹吗？**

不应该。为每个转换作业使用唯一的输出目录或存储前缀。这可以避免文件名冲突，并防止一次导出覆盖另一项导出生成的资源。