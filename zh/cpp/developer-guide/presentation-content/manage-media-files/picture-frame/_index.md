---
title: 使用 C++ 管理演示文稿中的图片框
linktitle: 图片框
type: docs
weight: 10
url: /zh/cpp/picture-frame/
keywords:
- 图片框
- 添加图片框
- 创建图片框
- 嵌入图像
- 链接图像
- 提取图像
- 光栅图像
- SVG 图像
- 裁剪图像
- 删除裁剪区域
- 压缩图像
- StretchOffset
- 图片框格式化
- 相对比例
- 图像效果
- 宽高比
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在演示文稿中创建、格式化、链接、裁剪、提取和压缩图片框。"
---
## **概述**

图片框是用于在幻灯片上显示图像的形状。在 Aspose.Slides 中，图像资源与显示它的形状是分开的对象：一个[演示文稿](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)通过其[图像集合](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_images/)拥有嵌入的图像资源，而一个[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)则控制图像的位置、大小、线条格式、旋转、裁剪、图片效果以及其他框级设置。

当同一图像需要显示多次时，这种分离非常有用。将图像一次性添加到演示文稿，保留返回的[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)，在创建图片框时使用该图像资源。

图片框可以包含 PNG、JPEG 等光栅图像以及 SVG 矢量图像。它们也可以引用链接图像，而不是将图像字节存储在演示文稿中。此选择会影响可移植性、文件大小、提取和导出行为，因此在应用格式或优化之前，决定图像应如何存储是有意义的。

## **添加和格式化嵌入图像**

对于嵌入图像，向演示文稿添加图像数据并使用[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shapecollection/addpictureframe/)创建图片框。图像会成为演示文稿包的一部分，因此当演示文稿移动到另一台电脑时仍保持自包含。

下面的示例添加 JPEG 图像，使用图像的原始尺寸创建框，并应用线条格式和旋转：

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

图片框控制显示的几何形状；更改框的大小并不会改变嵌入图像资源中存储的原始像素尺寸。此区别在以后进行裁剪或压缩时尤为重要。

## **使用相对比例**

[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)公开框的相对宽高比例。值为`1.0`对应原始图片尺寸的 100%。相对比例在需要保持与源图像大小关系而不是手动计算最终尺寸的工作流中很有用。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

相对比例仅更改框的比例设置；它不会对嵌入图像进行重新取样或压缩。

## **嵌入图像和链接图像**

嵌入图片将图像数据存储在演示文稿内部，是可移植性和渲染可预测性的最安全选择。链接图片则通过[ISlidesPicture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidespicture/)的链接路径引用外部位置，而不是以相同方式嵌入图像数据。

链接图像可以减少 PPTX 中存储的图像数据量，但会引入外部依赖。链接文件必须对打开或渲染演示文稿的应用保持可访问。如果路径更改、文件被移动或资源不可用，链接图片可能无法如预期显示。对于需要通过电子邮件发送、归档或在隔离环境中渲染的演示文稿，嵌入图像通常更可靠。

### **添加链接图像**

下面的示例创建图片框并指向本地图像文件。它仅处理图像链接；视频链接是单独的媒体工作流，故意未在此示例中混合。

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

当外部文件管理是有意为之时使用链接。不要仅仅把它们当作压缩的替代方案：一个带有破损图像依赖关系的小 PPTX 往往不如一个更大的自包含演示文稿有用。

## **从图片框提取图像**

在从现有演示文稿提取图像之前，检查形状是否实际为[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)且包含嵌入图像。链接图片框可能不包含可用来同样方式提取的图像字节。

### **提取光栅图像**

现代图像 API 直接使用[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)。下面的示例在幻灯片上找到第一个嵌入的光栅图片并将其保存为 PNG：

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

通过[IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)保存会将提取的图像转换为请求的输出格式。如果需要演示文稿中存储的编码字节而不是已转换的光栅文件，请使用图像资源的二进制数据。

### **提取 SVG 图像**

对于 SVG 图片，[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)公开一个[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/)对象。这使您能够直接检索 SVG 数据，而无需先将图片光栅化。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

保持 SVG 内容为 SVG 可在演示文稿内部保留矢量来源。PNG 或 JPEG 等光栅导出必然将该矢量内容渲染为像素。PDF 或 SVG 幻灯片导出同样是渲染操作，因此导出的图形不应被视为原始嵌入 SVG 的逐字节拷贝；在需要原始矢量资源时，请使用嵌入的[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/)数据。

## **裁剪图像**

裁剪改变框内可见的图像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/)上的裁剪值是源图像尺寸的百分比。裁剪不会立即从嵌入图像中删除隐藏的像素；它仅更改可见区域。

下面的示例安全地找到图片框并应用裁剪值：

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

因为隐藏的图像数据仍然存在，之后可以更改裁剪而不会丢失原始像素。如果文件大小比可逆性更重要，可以按下一节所述物理移除裁剪区域。

## **删除裁剪图像数据**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)会删除当前裁剪矩形之外的图像数据并返回结果图像资源。这可以减小文件大小，但属于破坏性优化：演示文稿保存后，被移除的像素将不再可用于后续取消裁剪操作。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

该方法可能会向演示文稿添加新的图像资源。如果原始图像还被其他图片框使用，这些框仍需其现有资源，因此删除裁剪区域不一定会降低图像总数。使用此方法裁剪 WMF 或 EMF 内容会将裁剪结果光栅化为 PNG。

## **压缩光栅图像**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/compressimage/)根据图片显示尺寸相对降低光栅图像分辨率。它还可以在同一次操作中移除裁剪区域。当图像被重新尺寸化或裁剪时返回 `true`，若未进行任何更改则返回 `false`。

当标准目标分辨率足够时，可使用预定义的[PicturesCompression](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/picturescompression/)值：

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

需要特定目标时，也可以传入自定义正 DPI 值，而不是枚举值。

压缩旨在用于光栅图像。SVG 和元文件内容不会通过此光栅压缩工作流被缩减。还要记住，降低的分辨率和已删除的裁剪区域无法从优化后的演示文稿中恢复。应根据图像实际查看或导出的最大尺寸选择目标分辨率，而不是全局使用最低 DPI。

## **管理图像变换效果**

有关完整的亮度、对比度、颜色变换、模糊、Alpha 效果、有序链、检查、移除以及往返验证工作流，请参阅[图像变换效果](/slides/zh/cpp/image-transform-effects/)。

## **锁定图片框几何**

[IPictureFrameLock](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframelock/)设置控制对图片框禁用哪些编辑操作。例如，[长宽比锁定](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/)在调整大小时保持形状比例。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

锁定作用于图片框形状本身。它不会强制对源图像进行重新取样或永久更改为相同的长宽比。

## **调整 StretchOffset 值**

当图片填充模式为 stretch 时，[IPictureFillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/)上的 stretch‑offset 值相对于图片框的边界框定义填充矩形。正百分比会从边缘向内收缩，负百分比会向外扩展。

这不同于裁剪。裁剪值选择源图像的可见部分；stretch‑offset 改变可见图片填充被拉伸的矩形。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

使用 stretch‑offset 进行填充定位。要隐藏源图像边缘，请使用裁剪属性。

## **存储、文件大小和导出考虑因素**

当图像存储和图片框格式分开处理时，主要权衡更易管理：

- **嵌入图像**使演示文稿自包含，是共享和服务器端渲染最可靠的选择，但大型光栅图像会增加 PPTX 大小和内存使用。
- **链接图像**可以保持包体更小，但演示文稿依赖外部文件在存储路径或位置上保持可用。
- **裁剪**最初是非破坏性的。隐藏的像素仍保留在嵌入图像中，直到显式删除裁剪区域或在压缩时移除。
- **压缩**可以显著减小超大光栅图像的文件大小，但会牺牲源分辨率。应在确定幻灯片上实际显示尺寸后再应用。
- **SVG 图像**在需要保留矢量时应保持为 SVG。需要矢量资源本身时直接提取嵌入的 SVG。光栅幻灯片导出始终将渲染的幻灯片转换为像素。
- **重复图像**应尽可能复用已有的[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)资源，而不是在工作流中多次加载同一文件。

对于大型演示文稿，图像优化通常在有针对性地执行时最有效：将徽标和图表保留为矢量内容，根据实际显示尺寸压缩照片，仅在后续编辑不再需要时移除裁剪像素，并且除非部署设计中已考虑依赖管理，否则避免使用外部链接。

## **常见问题**

**图片框和图像资源有什么区别？**

[IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/)表示与演示文稿关联的图像资源。[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)是幻灯片上的形状，用于显示图像并存储框级几何和格式信息，如大小、旋转、裁剪值、效果和锁定。

**应该嵌入还是链接图像？**

当演示文稿必须可移植、归档或在没有外部资源的情况下渲染时，请嵌入图像。仅当有意将图像文件保留在 PPTX 之外且外部位置能够可靠维护时才使用链接图像。

**裁剪会减小 PPTX 文件大小吗？**

单独裁剪不会。普通裁剪设置隐藏源图像的部分，但仍保留底层像素。若要永久丢弃这些像素，请使用[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)或在压缩时移除裁剪区域。

**压缩后还能恢复图像质量吗？**

不能。压缩会降低存储的光栅分辨率，删除裁剪区域会丢弃图像数据。如需后续高分辨率编辑，请在演示文稿外保留原始源图像。

**应如何处理 SVG 图像？**

在矢量保真度重要时保持 SVG 内容为 SVG。嵌入的[ISvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/)可以直接提取。将幻灯片渲染为 PNG 或 JPEG 等光栅格式会将 SVG 光栅化。

**读取现有幻灯片时如何避免不安全的转换？**

在使用图片框特定成员之前检查形状类型。使用[IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)进行类型测试后再进行运行时转换，并将转换结果赋给局部变量后再访问图片框特定成员。