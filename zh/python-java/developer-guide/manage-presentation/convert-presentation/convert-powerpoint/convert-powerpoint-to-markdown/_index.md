---
title: 在 Python 通过 Java 将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/python-java/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿转 MD
- 幻灯片转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- Markdown 图像导出
- CDN 图像链接
- PowerPoint
- 演示文稿
- Markdown
- Python
- Java
- Aspose.Slides
description: "在 Python 通过 Java 将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出位图、元文件和 SVG 图像的保存位置及引用方式。"
---
## **概览**

Aspose.Slides for Python via Java 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，以用于文档、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 方言，控制幻灯片内容的渲染方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出仅使用文本输出。若要导出可视内容，请使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setExportType) 方法将导出类型设置为来自 [MarkdownExportType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownexporttype/) 枚举的 `Sequential` 或 `Visual` 值。`Sequential` 会分别且按顺序渲染幻灯片项目，而 `Visual` 则保持分组项目在一起，以保留它们的视觉关系。`TextOnly` 值不会生成图像资源，因此在该模式下不会调用图像保存回调。

## **将演示文稿转换为 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载源文件，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法并传入来自 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 枚举的 `Md` 值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

每个示例都从当前工作目录读取 `presentation.pptx`。在运行示例之前，请先安装 Aspose.Slides for Python via Java 以及兼容的 Java 运行时。每个 Python 进程只需启动一次 JVM。

## **选择 Markdown 方言**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setFlavor) 方法控制输出使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

下面的示例将演示文稿导出为 CommonMark：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **使用默认本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/) 类提供两种方法来配置本地保存的图像：

- [setBasePath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setBasePath) 指定 Markdown 文档及其资源的基目录。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) 指定图像子目录。默认值为 `Images`。

下面的示例渲染可视内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

当自定义图像保存处理程序返回 `False` 时，此行为也会作为回退使用。

## **自定义图像保存和 Markdown 链接**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/) 方法注册回调，以处理在 Markdown 导出期间产生的非 SVG 位图和元文件资源。其 `MarkdownImageSavingHandler` 回调接收图像对象、其 [ImageFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/) 值以及作为单元素 `String[]` 参数的生成的 Markdown 链接。使用提供的格式保存或上传图像，并将 `link[0]` 替换为必须出现在 Markdown 输出中的引用。

以 SVG 格式产生的资源单独处理。使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/) 方法注册回调。其 `MarkdownSvgImageSavingHandler` 回调接收一个 [SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/) 对象和单元素 `String[] link` 参数。SVG 没有 `ImageFormat` 参数；请改为使用 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/#getSvgData) 方法获取并写入或上传其 XML 数据。根据导出模式和视觉分组，源演示文稿中的 SVG 可能会被光栅化或与其他内容合并；生成的非 SVG 资源随后会传递给图像保存回调。若每个导出的视觉资源都需要自定义处理，请同时注册这两个回调。

处理程序的返回值决定由谁处理图像：

- 返回 `True` 表示处理程序已保存、上传、转换或以其他方式处理图像，并已为 `link[0]` 赋予有效值。Aspose.Slides 将该值写入 Markdown 文档，并且不会执行默认的本地保存。
- 返回 `False` 则让 Aspose.Slides 按照由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setBasePath) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) 设置的值本地保存图像并生成链接。

{{% alert color="danger" title="Important" %}}
返回 `True` 的处理程序需要对图像负责。如果它返回 `True` 但未分配有效且非空的链接，导出将因 `InvalidOperationException` 而失败。
{{% /alert %}}

在 Python 中，可使用 `jpype.JProxy` 注册这些回调，通过实现 Java 回调接口的 `invoke` 方法。`link` 参数是可变的 Java 字符串数组：在处理之前先将 `link[0]` 转换为 Python 字符串，然后将替换后的 URL 赋回 `link[0]`。

### **将图像保存到 CDN 源目录并使用外部 URL**

下面的示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并用公共 CDN URL 替换生成的本地引用。示例本身不执行网络上传：只有在目录被挂载为 CDN 源或其文件已发布到 CDN 后，URL 才会生效。若使用对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并仅在上传成功后为 `link[0]` 赋值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

位图处理程序有意对小于 128 × 128 像素的图像返回 `False`，因此 Aspose.Slides 会使用默认行为将这些图像保存到 `output/fallback-images`。更大的位图、元文件资源以及 SVG 资源则由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 将变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写入文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠并对文件名进行 URL 编码。构建相对链接时同样使用 `/`，而不是平台特定的目录分隔符。

## **常见问题**

**一个处理程序可以同时处理光栅图像和 SVG 图像吗？**

不可以。请使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/) 处理位图和元文件资源，使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/) 处理以 SVG 形式产生的资源。前者提供图像对象和 [ImageFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/) 值；后者提供可通过 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/#getSvgData) 读取 SVG 数据的 [SvgImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/svgimage/) 对象。导出期间被光栅化的源 SVG 将通过图像保存回调进行处理。

**当图像保存处理程序返回 `False` 时会发生什么？**

Aspose.Slides 将使用默认的本地保存行为。图像的位置和生成的引用由使用 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setBasePath) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) 设置的值控制。

**处理程序可以在不本地保存图像的情况下提供 URL 吗？**

可以。处理程序可以将图像上传到对象存储或传递给其他服务，为 `link[0]` 赋予生成的 URL，并返回 `True`。处理程序必须自行完成所有处理；返回 `True` 会阻止默认的本地保存。

**为什么 Markdown 导出会因处理程序抛出 `InvalidOperationException`？**

当处理程序返回 `True` 但未提供有效链接时会出现此异常。请在返回 `True` 之前为 `link[0]` 赋予应写入 Markdown 的相对路径或外部 URL。

**图像链接应使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠 `/`。仅在文件系统路径中使用 `pathlib.Path`，然后单独构建或规范化 Markdown 引用。

**Markdown 导出时会保留超链接吗？**

会。文本 [hyperlinks](/slides/zh/python-java/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/python-java/slide-transition/) 和 [animations](/slides/zh/python-java/powerpoint-animation/) 则不会被转换。

**可以并行将演示文稿转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例。请遵循 [multithreading guidelines](/slides/zh/python-java/multithreading/) 并为每个文件使用独立的实例。