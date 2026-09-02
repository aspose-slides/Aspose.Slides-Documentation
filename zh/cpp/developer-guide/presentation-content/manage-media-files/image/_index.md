---
title: 使用 C++ 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/cpp/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 外部 SVG 资源
- SVG 解析器
- 链接的 SVG 图像
- SVG 字体
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并自动化工作流。"
---
## **简介**

图像使演示文稿更具吸引力和视觉冲击力。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源将图片插入到幻灯片中。类似地，Aspose.Slides 也提供多种方式向演示文稿幻灯片添加图像。

{{% alert title="Tip" color="primary" %}} 
Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可让您快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想将图像添加为图片框——特别是当您计划调整大小、应用效果或使用其他标准格式选项时——请参阅[图片框](/slides/zh/cpp/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以将图像从一种格式转换为另一种格式。请参阅以下页面：将[图像转 JPG](https://products.aspose.com/slides/zh/cpp/conversion/image-to-jpg/) 、[JPG 转图像](https://products.aspose.com/slides/zh/cpp/conversion/jpg-to-image/)、[JPG 转 PNG](https://products.aspose.com/slides/zh/cpp/conversion/jpg-to-png/)、[PNG 转 JPG](https://products.aspose.com/slides/zh/cpp/conversion/png-to-jpg/)、[PNG 转 SVG](https://products.aspose.com/slides/zh/cpp/conversion/png-to-svg/) 和 [SVG 转 PNG](https://products.aspose.com/slides/zh/cpp/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides 支持 JPEG、PNG、BMP、GIF 等常用格式的图像。

## **将本地存储的图像添加到幻灯片**

您可以将计算机上存储的一个或多个图像添加到演示文稿幻灯片中。下面的 C++ 示例代码演示了如何向幻灯片添加图像：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **从网页添加图像到幻灯片**

如果您想添加到幻灯片的图像未存储在电脑上，您可以直接从网络添加。

下面的 C++ 示例代码演示了如何从网络将图像添加到幻灯片：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **向幻灯片母版添加图像**

幻灯片母版存储并控制使用该母版的幻灯片的主题和布局等信息。当您向幻灯片母版添加图像时，图像会出现在基于该母版的每张幻灯片上。

下面的 C++ 示例代码演示了如何向幻灯片母版添加图像：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **将图像设为幻灯片背景**

您可以将图片用作一个或多个幻灯片的背景。详细信息，请参阅 *[将图像设置为幻灯片背景](/slides/zh/cpp/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG**

SVG 内容可以使用 [SvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/svgimage/) 类添加到演示文稿中。生成的 [ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/) 对象随后可加入演示文稿的图像集合并用于创建图片框。

下面的 C++ 示例导入了一个自包含的 SVG 字符串。此 SVG 使用的所有图像、样式和其他资源均直接嵌入在 SVG 内容中。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **导入带外部资源的 SVG 内容**

从设计工具、图表编辑器、图标系统和网络流水线导出的 SVG 文件可能会引用存储在 SVG 文档之外的资源。例如，SVG 可以包含类似 `images/photo.png` 的图像链接、CSS `url(...)` 值或字体 URL。

要导入此类 SVG 内容，请实现一个 [IExternalResourceResolver](https://reference.aspose.com/slides/zh/cpp/aspose.slides.import/iexternalresourceresolver/) 并将其与基 URI 一起传递给相应的 `SvgImage` 构造函数。基 URI 标识 SVG 文档的位置，用于解析相对链接。

[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/) 接口提供对导入 SVG 信息的访问：

- `get_SvgContent()` 返回 SVG 标记的字符串形式。
- `get_SvgData()` 返回 SVG 内容的字节数组。
- `get_BaseUri()` 返回用于相对链接的基 URI。
- `get_ExternalResourceResolver()` 返回分配给 SVG 图像的解析器。

### **实现外部资源解析器**

解析器有两个方法：

- [ResolveUri](https://reference.aspose.com/slides/zh/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) 将基 URI 与相对资源链接合并并返回绝对 URI。当链接无法解析或不被允许时返回空字符串。
- [GetEntity](https://reference.aspose.com/slides/zh/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) 为绝对资源 URI 返回可读取的流。当资源缺失、被阻止或不可用时返回 `nullptr`。在适当情况下也可以返回回退流。

下面的解析器仅从允许的本地目录加载链接资源。网络资源和超出允许目录的路径将被阻止。对于未解析的图像链接，可返回可选的回退图片。

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // 此解析器有意仅允许本地文件。
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // 仅在图像资源时使用回退。返回图像流
        // 对于缺失的字体或样式表则无效。
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **在 SVG 导入期间解析链接资源**

假设 `assets/diagram.svg` 包含如下相对引用：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

下面的 C++ 示例将 SVG 文件 URI 作为基 URI 并提供自定义解析器。解析器将相对图像链接转换为绝对 URI，并在 Aspose.Slides 处理 SVG 时返回包含链接资源的流。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// 基本 URI 表示 SVG 文档的位置。
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage 提供源内容、二进制数据、基本 URI 和解析器。
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`SvgImage` 类还提供接受 SVG 数据字节数组或流的重载，并可同时指定外部资源解析器和基 URI。

{{% alert title="Important" color="warning" %}}
资源解析器在 Aspose.Slides 处理并渲染 SVG 时使外部资源可用。它不会修改原始 SVG 标记，也不会自动将已解析的资源嵌入其中。

当 `ISvgImage` 被添加到演示文稿的图像集合时，PPTX 文件可以同时包含原始 SVG 表示和栅格回退图像。链接资源可能会出现在生成的回退图像中，而像 `images/photo.png` 这样的相对链接在存储的 SVG 中保持不变。渲染原生 SVG 表示的应用程序因此在原始外部资源不可用时可能会省略链接内容。
{{% /alert %}}

### **创建可移植的 SVG 图片**

要创建不依赖外部文件的 SVG 图片，请在创建 `SvgImage` 之前使 SVG 自包含。例如，将链接的图像 URL 替换为包含图像数据的 `data:` URI：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必需资源嵌入到 SVG 内容后，创建 `SvgImage`，将其添加到演示文稿图像集合，并如前例所示插入到图片框中。

### **处理缺失或被阻止的资源**

当资源 URI 无效、被禁止或无法解析时，`ResolveUri` 应返回空字符串。当资源无法读取时，`GetEntity` 应返回 `nullptr`。Aspose.Slides 会在可能的情况下继续处理 SVG 而不使用该资源。

可以为缺失资源返回回退流，但其内容必须与请求的资源类型兼容。例如，仅在缺失图像时返回图像流，而不是返回字体或样式表流。

{{% alert title="Security" color="warning" %}}
不要从不可信的 SVG 文件解析任意文件路径或不受限制的网络 URL。应限制允许的方案、目录和主机。对于网络资源，还需设置连接超时、响应大小限制以及内容验证。
{{% /alert %}}

## **将 SVG 转换为形状集合**
Aspose.Slides 可以将 SVG 转换为形状集合，类似于 PowerPoint 中的相应功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [AddGroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/) 方法的重载提供，该方法属于 [IShapeCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/) 接口，接受一个 [ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/) 对象作为第一个参数。

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// 源 SVG 文件名
auto svgFileName = System::String(u"sample.svg");

// 输出演示文稿文件名
auto outPptxPath = System::String(u"presentation.pptx");

// 创建新的演示文稿
auto presentation = System::MakeObject<Presentation>();

// 读取 SVG 文件内容
auto svgContent = File::ReadAllText(svgFileName);

// 创建 SvgImage 对象
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// 获取幻灯片大小
auto slideSize = presentation->get_SlideSize()->get_Size();

// 将 SVG 图像转换为形状组并按幻灯片大小进行缩放
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// 以 PPTX 格式保存演示文稿
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **将图像以 EMF 形式添加到幻灯片**
Aspose.Slides for C++ 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图像并将其添加到演示文稿幻灯片。

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 在使用任何 Aspose.Cells 类型之前，必须先启动 Aspose.Cells for C++。
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// 将工作表渲染为 EMF。
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells 将渲染的页面返回为缓冲区，Aspose.Slides 将其添加为图像。
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **替换图像集合中的图像**

Aspose.Slides 让您可以替换存储在演示文稿图像集合中的图像，包括幻灯片形状使用的图像。本节描述了更新集合中图像的几种方法。您可以使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 实例或集合中已存在的其他图像来替换图像。

按照以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。
2. 将新图像从文件加载到字节数组中。
3. 使用字节数组将目标图像替换为新图像。
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 对象并使用该对象替换目标图像。
5. 在第三种方法中，用演示文稿图像集合中已存在的图像替换目标图像。
6. 将修改后的演示文稿写为 PPTX 文件。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 实例化代表演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 第一种方式。
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 第二种方式。
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 第三种方式。
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// 将演示文稿保存到文件。
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文本添加动画并创建 GIF。
{{% /alert %}}

## **FAQ**

**插入后原始图像分辨率是否保持不变？**

是的。源像素会被保留，但最终显示效果取决于[图片](/slides/zh/cpp/picture-frame/)在幻灯片上的缩放方式以及保存时的压缩情况。

**一次性在数十张幻灯片中替换相同标志的最佳方法是什么？**

将标志放在母版幻灯片或布局上，并在演示文稿的图像集合中进行替换——更新会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，随后各个部件可使用标准形状属性进行编辑。

**如何一次性将图片设置为多张幻灯片的背景？**

在母版幻灯片或相应布局上[将图像设为背景](/slides/zh/cpp/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止由于大量图片导致演示文稿体积过大？**

重复使用单一图像资源而非复制，选择合适的分辨率，保存时进行压缩，并在合适的情况下将重复图形放在母版上。