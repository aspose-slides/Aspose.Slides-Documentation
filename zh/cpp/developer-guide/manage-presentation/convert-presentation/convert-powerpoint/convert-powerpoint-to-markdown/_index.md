---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/cpp/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将 演示文稿 保存为 Markdown
- 将 幻灯片 保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 将 PPT 导出为 MD
- 将 PPTX 导出为 MD
- Markdown 图像导出
- CDN 图像链接
- PowerPoint
- 演示文稿
- Markdown
- C++
- Aspose.Slides
description: "在 C++ 中将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出的位图、元文件和 SVG 图像的保存位置和引用方式。"
---
## **概述**

Aspose.Slides for C++ 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，以用于文档编写、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 的风格，控制幻灯片内容的渲染方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出使用仅文本输出。若要导出可视内容，请将[MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) 方法设置为来自[MarkdownExportType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownexporttype/) 枚举的 `Sequential` 或 `Visual` 值。`Sequential` 会分别且按顺序渲染幻灯片项，而 `Visual` 则将分组项保留在一起，以保持它们的视觉关系。`TextOnly` 值不会生成图像资源，因此在该模式下不会触发图像保存事件。

## **将演示文稿转换为 Markdown**

使用[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载源文件，然后调用[Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 方法，并传入来自[SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 枚举的 `Md` 值。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **选择 Markdown 风格**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) 方法控制输出使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

以下示例将演示文稿导出为 CommonMark：

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **使用默认本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/) 类提供了两种配置本地保存图像的方法：

- [set_BasePath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) 指定 Markdown 文档及其资源的基目录。
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) 指定图像子目录。默认值为 `Images`。

以下示例渲染可视内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

当自定义图像保存处理程序返回 `false` 时，此行为也作为回退。

## **自定义图像保存和 Markdown 链接**

在 Markdown 导出期间，对非 SVG 位图和元文件资源使用 `MarkdownSaveOptions::ImageSaving` 事件。其[MarkdownImageSavingHandler](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) 委托接收[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 对象、其[ImageFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/)，以及生成的 Markdown 链接，后者作为 `System::String&` 参数。使用提供的格式保存或上传图像，并将 `link` 替换为必须出现在 Markdown 输出中的引用。

以 SVG 格式生成的资源单独处理。订阅 `MarkdownSaveOptions::SvgImageSaving` 事件，其[MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) 委托接收[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/) 对象和 `System::String& link` 参数。SVG 不包含 `ImageFormat` 参数；请改为从[ISvgImage::get_SvgData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/get_svgdata/) 方法读取其 XML 数据并写入或上传。根据导出模式和视觉分组，源演示文稿中的 SVG 可能会在导出时被栅格化或与其他内容合并；此时生成的非 SVG 资源会交给 `ImageSaving` 处理。若每个导出的视觉资源都需要自定义处理，请同时订阅这两个事件。

处理程序的返回值决定由谁处理图像：

- 在处理程序已保存、上传、转换或以其他方式处理图像并为 `link` 分配了有效值后返回 `true`。Aspose.Slides 将该值写入 Markdown 文档，并且不执行默认的本地保存。
- 返回 `false` 让 Aspose.Slides 本地保存图像，并根据[MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/)和[MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) 生成链接。

{{% alert color="warning" title="Important" %}}
返回 `true` 的处理程序需要对图像负责。如果它返回 `true` 但未为 `link` 分配有效且非空的链接，导出将因 `InvalidOperationException` 而失败。
{{% /alert %}}

### **将图像保存到 CDN 源目录并使用外部 URL**

以下示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或已同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并用公共 CDN URL 替换生成的本地引用。示例本身不执行网络上传：只有在目录被挂载为 CDN 源或其文件已发布到 CDN 后，URL 才有效。若使用对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并在上传成功后才为 `link` 赋值。

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

位图处理程序有意对小于 128 × 128 像素的图像返回 `false`，因此 Aspose.Slides 使用默认行为将这些图像保存到 `output/fallback-images`。较大的位图、元文件以及 SVG 资源由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 将变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写入文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠并对文件名进行 URL 转义。构建相对链接时同样使用 `/`，而非平台特定的目录分隔符。

## **常见问题**

**一个处理程序能同时处理光栅图像和 SVG 图像吗？**

不可以。对生成的位图和元文件资源使用 `MarkdownSaveOptions::ImageSaving`，对以 SVG 形式生成的资源使用 `MarkdownSaveOptions::SvgImageSaving`。前者提供[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 对象和[ImageFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/)，后者提供[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/) 对象，可通过[ISvgImage::get_SvgData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/get_svgdata/) 读取 SVG 数据。源 SVG 在导出时被栅格化的情况由 `ImageSaving` 处理。

**当图像保存处理程序返回 `false` 时会发生什么？**

Aspose.Slides 使用其默认的本地保存行为。图像的保存位置和生成的引用受[MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/)和[MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) 控制。

**处理程序能在不本地保存图像的情况下提供 URL 吗？**

可以。处理程序可以将图像上传到对象存储或交给其他服务，随后将得到的 URL 赋给 `link` 并返回 `true`。返回 `true` 表示处理程序已自行完成所有工作，默认的本地保存将被跳过。

**为什么 Markdown 导出会因处理程序抛出 `InvalidOperationException`？**

当处理程序返回 `true` 但未提供有效的链接时会抛出该异常。在返回 `true` 之前，请确保已为 `link` 赋予应写入 Markdown 的相对路径或外部 URL。

**图像链接应使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠`/`。仅在文件系统路径上使用 `Path::Combine` 或平台特定的分隔符，然后单独构造或规范化 Markdown 引用。

**Markdown 导出期间是否保留超链接？**

会。文本[超链接](/slides/zh/cpp/manage-hyperlinks/)会保留为标准的 Markdown 链接。幻灯片[切换效果](/slides/zh/cpp/slide-transition/)和[动画](/slides/zh/cpp/powerpoint-animation/)则不会被转换。

**演示文稿可以并行转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例。请遵循[多线程指南](/slides/zh/cpp/multithreading/) 为每个文件使用独立的实例。