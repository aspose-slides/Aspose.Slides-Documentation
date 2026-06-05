---
title: 使用 Python 将演示文稿导出为带外部链接图像的 HTML
linktitle: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- 链接图像
- 外部链接图像
- 链接资源
- 外部资源
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，图像保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为一个自包含的 HTML 文件。图像和其他资源直接写入 HTML，通常采用 Base64 数据。这在需要单个可移植文件时很方便，但对于网站、CMS 或服务器端转换流水线来说并不总是最佳格式。

当您希望：

- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像；
- 在导出后检查、替换、压缩或后处理生成的图像；
- 保持输出结构更接近 Web 应用程序的期望。

有关通用 HTML 转换工作流，请参阅 [将PowerPoint演示文稿转换为HTML](/slides/zh/python-net/convert-powerpoint-to-html/)。本文重点介绍导出期间的图像链接部分。

## **链接图像导出工作原理**

.NET 和 Java 中，[ILinkEmbedController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/ilinkembedcontroller/) 表示导出器用于决定资源是嵌入还是链接的回调接口。在通过 .NET 使用 Python 时，Python 类目前无法直接实现此 .NET 回调接口，因此实际工作流如下：

1. 使用 [HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 将演示文稿导出为 HTML。
2. 使用 [SlideImageFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/slideimageformat/) 配合 [SVGOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/)，使幻灯片在 HTML 中以 SVG 形式呈现。
3. 将 HTML 中 `data:` URL 的 Base64 图像数据移动到单独的文件中。
4. 将原始的 `data:` URL 替换为相对链接，例如 `assets/resource-1.jpg`。

文件系统路径和浏览器 URL 是相互独立的。例如，下面的示例将图像文件写入磁盘上的 `html-output/assets`，而 HTML 中包含诸如 `assets/resource-1.jpg` 的相对 URL。浏览器会相对于包含链接的 HTML 文件解析这些 URL。

## **导出带链接图像的 HTML**

以下 Python 示例会创建输出目录，将 HTML 文件保存到该目录，将提取的图像存储在 `assets` 子目录中，并将 Base64 图像 URL 重写为相对链接。当 Aspose.Slides 提供安全的文件扩展名时，示例会提取常见的 Base64 图像格式。未识别的 Data URL 将保持嵌入。

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

导出后，输出文件夹可能具有以下结构：

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

具体文件取决于演示文稿内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。当选择更小或更合适的文件时，Aspose.Slides 可能会使用与源演示文稿不同的图像编解码器。带透明度的图像会导出为 PNG。

## **选择部署时的 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.jpg`。

当文件部署到其他位置时，使用不同的资源目录名称或重写生成的链接：

- 当资源目录与 HTML 文件相邻时使用 `assets/`。
- 当资源目录位于 HTML 文件上一级时使用 `../assets/`。
- 当文件上传到 CDN 或静态文件服务器时使用 `https://cdn.example.com/presentations/job-123/assets/`。

在服务器应用程序中，为每个转换作业使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时改为嵌入**

当输出必须是单个文件时（例如电子邮件附件、离线预览或在没有配套资产文件夹的情况下移动的文档），嵌入的 Base64 HTML 仍然有用。链接图像更适合 HTML 由 Web 应用程序提供、存储在 CMS 中、通过构建流水线优化或浏览器独立于 HTML 缓存的情况。

## **FAQ**

**我可以只外部化图像并保持其他资源嵌入吗？**

是的。示例仅提取 `EXTENSIONS_BY_CONTENT_TYPE` 中列出的 `image/*` Base64 数据 URL。其他数据 URL 将保持嵌入。

**导出的图像扩展名为何与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出期间重新编码光栅图像，以降低体积或提高浏览器兼容性。例如，源文件中的图像可能会根据渲染结果写入为 JPEG 或 PNG。

**我移动 HTML 文件后相对 URL 还能工作吗？**

相对 URL 仅在保持相同的相对文件夹结构时有效。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持在同一位置，除非您生成了不同的 URL 前缀。

**服务器应用程序应该重复使用相同的输出文件夹吗？**

不应。为每个转换作业使用唯一的输出目录或存储前缀。这可以避免文件名冲突，并防止一次导出覆盖其他导出生成的资源。