---
title: 使用 C++ 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/cpp/image/
keywords:
- 添加图像
- 添加图片
- 替换图像
- 图像集合
- 图片框
- 链接图像
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 将 SVG 转换为形状
- 外部 SVG 资源
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中添加、复用、链接、替换和管理光栅图像及 SVG 图像。"
---
## **介绍**

Aspose.Slides for C++ 提供了多种处理图像的方法，每种方法都有不同的用途。您可以在演示文稿中存储图像，在图片框中显示图像，将其用作幻灯片背景，链接到外部图像，替换共享的图像资源，或将 SVG 内容转换为可编辑的形状。

本文重点介绍图像资源以及它们在整个演示文稿中的使用方式。有关对单个图片框进行裁剪、透明度、效果、拉伸以及其他格式设置，请参阅[图片框](/slides/zh/cpp/picture-frame/)。

## **了解图像模型**

以下 API 概念密切相关，但不可互换：

- [演示文稿图像集合](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/) 存储演示文稿使用的图像资源。使用[IImageCollection::AddImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/addimage/) 添加图像数据并获取一个[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)资源。
- [图片框](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/) 是一种在幻灯片、版面或母版上显示图像的形状。使用[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addpictureframe/)将图像资源放置在幻灯片上。
- 幻灯片背景将图像用作幻灯片填充的一部分，而不是形状。因此它的行为不同于图片框。
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/replaceimage/) 替换图像资源。如果多个演示文稿元素使用该资源，它们都会使用替换后的图像。
- 将 SVG 转换为形状会创建可编辑的幻灯片形状。转换后，内容不再作为单一图片资源进行管理。

因此，典型的工作流是：将图像数据添加到图像集合，获取一个[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)，然后在一个或多个图片框或填充中使用该资源。

## **添加嵌入式图像**

要插入本地图像，请读取文件，将其数据添加到图像集合，并创建使用返回的[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)资源的图片框。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

以这种方式添加的图像会嵌入到演示文稿中，因此生成的文件不依赖原始图像文件的可用性。

### **从网络添加图像**

当图像通过 HTTP 或 HTTPS 提供时，下载其字节，将其添加到演示文稿图像集合，并以与本地图像相同的方式使用返回的图像资源。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在源不可信时，请验证远程 URL、响应大小和内容类型。在已经使用其他 HTTP 客户端的应用程序中，您可以使用该客户端下载图像，然后将得到的字节或流传递给[IImageCollection::AddImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/addimage/)。

## **在幻灯片之间重复使用图像**

如果同一图像需要使用多次，请在演示文稿中仅添加一次，并在创建其他图片框时复用返回的[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)。这可以避免重复加载相同的源数据，并明确共享图像资源与其使用之间的关系。

对于应自动出现在多张幻灯片上的图形（例如公司徽标），请考虑将图片框放置在[幻灯片母版](/slides/zh/cpp/slide-master/)或版面上，而不是在每张幻灯片中添加相同的形状。

## **将图像用作幻灯片背景**

背景图像被分配到幻灯片填充中，而不是作为图片框形状添加。当图片需要覆盖整个幻灯片背景且不应像普通幻灯片对象那样被操作时，这非常有用。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

有关更多背景选项，包括母版和版面背景，请参阅[演示文稿背景](/slides/zh/cpp/presentation-background/)。

## **嵌入式图像和链接图像**

嵌入式图像和链接图像在可移植性和文件大小上存在不同的权衡：

- **嵌入式图像：** 图像数据存储在演示文稿内部。演示文稿是自包含的，但文件大小包括图像数据。
- **链接图像：** 演示文稿存储指向外部图像的路径或 URL。这可以减小演示文稿的大小，但在打开或渲染演示文稿时必须能够访问外部资源。

可以通过[ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidespicture/set_linkpathlong/) 分配外部路径或 URL 来创建链接图片，而不是嵌入图像数据。

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

仅在部署环境能够可靠访问外部资源时才使用链接图像。对于必须离线使用或在系统之间移动的演示文稿，嵌入式图像通常更安全。

## **处理 SVG 图像**

SVG 是一种矢量格式，适用于图标、图表以及其他需要在不失细节的情况下缩放的图形。Aspose.Slides 同时支持将 SVG 作为图像资源和可编辑幻灯片形状的源。

### **将 SVG 添加为图像**

创建一个[SvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/svgimage/)，将其添加到图像集合，并在图片框中放置生成的图像资源。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **带有外部资源的 SVG 文件**

SVG 可以引用外部图像、样式表或字体。对于这些情况，[SvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/svgimage/) 提供接受[IExternalResourceResolver](https://reference.aspose.com/slides/zh/cpp/aspose.slides.import/iexternalresourceresolver/)和基准 URI 的构造函数。解析器可以将相对 URI 映射到允许的绝对 URI，并返回所请求资源的流。

解析器在 Aspose.Slides 处理 SVG 时提供外部资源，但不会将 SVG 重写为自包含文档。如果 SVG 必须保持可移植，请在 SVG 本身中嵌入所需资源，例如使用 `data:` URI 链接图像。

当 SVG 文件来自不可信来源时，限制解析器可以访问的方案、文件位置和主机。网络解析器还应应用超时、响应大小限制和内容验证。

### **将 SVG 转换为可编辑形状**

Aspose.Slides 可以将 SVG 转换为一组可编辑的幻灯片形状，类似于 PowerPoint 相应的命令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/)的[IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addgroupshape/) 重载来执行转换。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

当需要将单个矢量元素编辑为 PowerPoint 形状时，请使用 SVG 到形状的转换。如果仅需显示 SVG，将其保留为图像更简单，且避免创建大量独立形状。

## **替换现有图像资源**

当需要替换现有图像资源时，请使用[IPPImage::ReplaceImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/replaceimage/)。这在共享图形（如徽标）时尤其有用。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

如果多个图片框、背景、母版或版面使用相同的图像资源，替换该资源会更新所有这些使用。如果只需更改一个图片框，请为该框分配不同的图像，而不是替换共享资源。

[IPPImage::ReplaceImage] 还提供接受[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)或另一个[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)的重载。

## **实用图像管理指南**

### **控制演示文稿大小**

大型光栅图像会导致演示文稿体积不必要地增大。请使用尺寸适合预期显示大小的源图像，尽可能复用共享图像资源，并避免嵌入同一全分辨率图形的重复副本。

对于已经放置在图片框中的光栅图片，可使用[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/compressimage/)根据所选分辨率和裁剪设置压缩图像数据。这属于图片框处理，而不是图像集合管理，请参阅[图片框](/slides/zh/cpp/picture-frame/)了解相关格式化操作。

### **在嵌入和链接内容之间进行选择**

嵌入使演示文稿具有可移植性，因为所有必需的图像数据随文件一起携带。链接可以减小文件大小，但会引入外部依赖。仅在该依赖可接受且稳定时才使用链接。

### **复用共享品牌元素**

对于重复使用的徽标、水印或装饰图形，请使用单一图像资源并复用它。如果该图形属于演示文稿设计而非幻灯片内容，请将其放置在母版或版面上，以便相应幻灯片继承。

### **保持 SVG 资源可移植**

自包含的 SVG 比依赖外部文件或网络资源的 SVG 更易于移动和一致渲染。尽可能在导入 SVG 前嵌入所需资源。仅在需要编辑单个矢量元素时才将 SVG 转换为形状。

### **使用 Aspose.Slides 图像 API**

对于 C++ 图像工作流，需要图像对象时请使用 Aspose.Slides 的[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)和[Images](https://reference.aspose.com/slides/zh/cpp/aspose.slides/images/) API；需要将图像数据注册为演示文稿资源时使用[IImageCollection::AddImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/addimage/)。集合的重载还支持字节数组和流，这在图像数据来自文件、网络客户端、数据库或其他库时非常有用。

从电子表格或其他产品生成 EMF 内容是独立的集成工作流，超出本文范围。如果仅需将现有 WMF 或 EMF 文件插入演示文稿，请将其数据传递给合适的[IImageCollection::AddImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/addimage/)重载，而无需在图像管理工作流中添加第二个产品依赖。

## **常见问题**

**图像集合和图片框之间有什么区别？**

图像集合存储可重复使用的图像资源。图片框是一种幻灯片形状，用于显示这些资源之一，并提供如裁剪和效果等图片特定的格式设置。

**在所有位置替换相同徽标的最佳方法是什么？**

如果徽标已经作为单一图像资源共享，请使用[IPPImage::ReplaceImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/replaceimage/)替换该资源。对于全演示文稿的品牌标识，也可以将徽标放置在母版或版面上，以减少重复的幻灯片内容。

**为什么在另一台电脑上链接图像会消失？**

链接图片依赖其外部文件或 URL。如果在另一台电脑上无法访问该资源，链接图像可能不可用。演示文稿必须自包含时，请嵌入图像。

**插入的 SVG 能否编辑为 PowerPoint 形状？**

可以。使用[IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addgroupshape/)转换 SVG；生成的组包含可编辑的幻灯片形状，而不是单个 SVG 图片。

**如何让包含大量图像的演示文稿保持更小？**

复用共享图像资源，避免使用不必要的大尺寸光栅源，适时压缩合适的光栅图片，将重复的品牌元素放在母版或版面上，并仅在外部依赖可接受时使用链接图像。