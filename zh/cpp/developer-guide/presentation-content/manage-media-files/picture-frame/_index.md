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
- 添加图像
- 创建图像
- 提取图像
- 光栅图像
- 矢量图像
- 裁剪图像
- 裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 宽高比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿中。简化工作流程并提升幻灯片设计。"
---

图片框是包含图像的形状——它就像装在相框中的图片。

您可以通过图片框向幻灯片添加图像。通过格式化图片框即可对图像进行格式化。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费的转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——帮助用户快速将图像创建为演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建一个 [Presentation 类](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，以用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片的形状对象公开的 `AddPictureFrame` 方法，基于图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame)。  
6. 将包含图片的图片框添加到幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示了如何创建图片框：
```c++
// 文档目录的路径。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 加载将在演示文稿图像集合中添加的图像
// 获取图片
auto image = Images::FromFile(filePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 向幻灯片添加图片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对比例的宽度和高度
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// 对 PictureFrame 应用一些格式设置
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="warning" %}} 
图片框可帮助您快速基于图像创建演示文稿幻灯片。将图片框与 Aspose.Slides 的保存选项结合使用，可对输入/输出操作进行操作，以实现图像格式之间的转换。您可能需要查看以下页面：转换 [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)；转换 [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)；转换 [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)；转换 [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。 
{{% /alert %}}

## **创建带相对比例的图片框**

通过更改图像的相对缩放，可以创建更复杂的图片框。

1. 创建一个 [Presentation 类](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 向演示文稿的图像集合中添加图像。  
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，以用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示了如何创建带相对比例的图片框：
```c++
// 文档目录的路径。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 加载将在演示文稿图像集合中添加的图像
// 获取图片
auto image = Images::FromFile(filePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 向幻灯片添加图片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对比例的宽度和高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **从图片框提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) 对象中提取光栅图像，并以 PNG、JPG 等格式保存。下面的代码示例演示了如何从文档 “sample.pptx” 中提取图像并保存为 PNG 格式。
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```


## **从图片框提取 SVG 图像**

当演示文稿中包含放置在 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 形状内的 SVG 图形时，Aspose.Slides for C++ 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，可识别每个 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/)，检查底层的 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 是否包含 SVG 内容，然后将该图像以原生 SVG 格式保存到磁盘或流中。

下面的代码示例演示了如何从图片框中提取 SVG 图像：
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```


## **获取图像的透明度**

Aspose.Slides 允许您获取应用于图像的透明度效果。以下 C++ 代码演示了该操作：
```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```


{{% alert color="primary" %}} 
所有适用于图像的效果均可在 [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/) 中找到。 
{{% /alert %}}

## **图片框格式化**

Aspose.Slides 提供了许多可应用于图片框的格式化选项。使用这些选项，您可以调整图片框以满足特定需求。

1. 创建一个 [Presentation 类](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 中添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，以用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过 [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 对象公开的 [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法，基于图像的宽度和高度创建一个 `PictureFrame`。  
6. 将包含图片的图片框添加到幻灯片。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过正值或负值旋转图片框。  
   * 正值顺时针旋转图像。  
   * 负值逆时针旋转图像。  
10. 将图片框（包含图片）再次添加到幻灯片。  
11. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示了图片框格式化过程：
```c++
// 文档目录的路径。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 加载将添加到演示文稿图像集合中的图像
// 获取图片
auto image = Images::FromFile(filePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 向幻灯片添加图片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对比例的宽度和高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert title="Tip" color="primary" %}}
Aspose 最近推出了一个 [免费拼图制作工具](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，可以使用此服务。 
{{% /alert %}}

## **将图像作为链接添加**

为避免演示文稿体积过大，您可以通过链接而非直接嵌入文件的方式添加图像（或视频）。以下 C++ 代码演示了如何向占位符中添加图像和视频：
```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **裁剪图像**

以下 C++ 代码演示了如何裁剪幻灯片上的现有图像：
```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 创建新的图像对象
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// 向幻灯片添加图片框
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 裁剪图像（百分比值）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 保存结果
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **删除图片框的裁剪区域**

如果您想删除框中图像的裁剪区域，可使用 [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。若不需要裁剪，该方法返回原始图像。

以下 C++ 代码演示了此操作：
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 从第一张幻灯片获取 PictureFrame
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// 保存结果
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```


{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅用于已处理的 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/)，此设置可以减小演示文稿大小；否则，生成的演示文稿中的图像数量会增加。

该方法在裁剪操作中会将 WMF/EMF 元文件转换为光栅 PNG 图像。 
{{% /alert %}}

## **锁定宽高比**

若希望包含图像的形状在更改图像尺寸后仍保持宽高比，可使用 [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 方法设置 *锁定宽高比*。

以下 C++ 代码演示了如何锁定形状的宽高比：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```


{{% alert title="NOTE" color="warning" %}} 
此 *锁定宽高比* 设置仅保留形状本身的宽高比，而不影响其包含的图像。 
{{% /alert %}}

## **使用 StretchOff 属性**

通过使用 [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) 类中的 [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) 属性，您可以指定填充矩形。

当指定图像拉伸时，源矩形会按比例缩放以适应指定的填充矩形。填充矩形的每条边由相对于形状边界框对应边缘的百分比偏移定义。正百分比表示向内收缩，负百分比表示向外延伸。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加用于填充形状的设置图像。  
8. 指定图像相对于形状边界框相应边缘的偏移。  
9. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示了使用 StretchOff 属性的过程：
``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```


## **FAQ**

**如何查看 PictureFrame 支持的图像格式？**  
Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 的图像对象支持光栅图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的功能相重叠。

**大量大图像会如何影响 PPTX 大小和性能？**  
嵌入大图像会增加文件大小和内存占用；使用链接图像可降低演示文稿大小，但需确保外部文件始终可访问。Aspose.Slides 提供通过链接添加图像的功能以减小文件体积。

**如何防止图像对象被意外移动/缩放？**  
对 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/get_pictureframelock/)（例如禁用移动或缩放）。锁定机制在单独的 [保护文章](/slides/zh/cpp/applying-protection-to-presentation/) 中介绍，适用于包括 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得以保留？**  
Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 中提取 SVG 作为原始矢量图。当 [导出为 PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/) 或 [光栅格式](/slides/zh/cpp/convert-powerpoint-to-png/) 时，结果可能会根据导出设置被光栅化；提取行为验证了原始 SVG 仍以矢量形式存储。