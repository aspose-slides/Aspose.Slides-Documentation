---
title: 使用 C++ 在演示文稿中管理图片框
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
- 栅格图像
- 矢量图像
- 裁剪图像
- 裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 纵横比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 向 PowerPoint 和 OpenDocument 演示文稿添加图片框。简化工作流程并提升幻灯片设计。"
---
## **介绍**

图片框是一种包含图像的形状——它就像框中的图片。

您可以通过图片框向幻灯片添加图像。通过格式化图片框来格式化图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可帮助用户快速从图像创建演示文稿。 
{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation 类](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_image_collection) 添加图像来创建 [IPPImage](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用幻灯片关联的形状对象公开的 `AddPictureFrame` 方法，基于图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_frame)。  
6. 将包含图片的图片框添加到幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示如何创建图片框：

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
// 对图片框应用一些格式设置
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
图片框可以帮助您快速基于图像创建演示文稿幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，可以操作输入/输出以将图像从一种格式转换为另一种格式。您可能想查看以下页面：转换 [图像转 JPG](https://products.aspose.com/slides/zh/cpp/conversion/image-to-jpg/)；转换 [JPG 转 图像](https://products.aspose.com/slides/zh/cpp/conversion/jpg-to-image/)；转换 [JPG 转 PNG](https://products.aspose.com/slides/zh/cpp/conversion/jpg-to-png/)，转换 [PNG 转 JPG](https://products.aspose.com/slides/zh/cpp/conversion/png-to-jpg/)；转换 [PNG 转 SVG](https://products.aspose.com/slides/zh/cpp/conversion/png-to-svg/)，转换 [SVG 转 PNG](https://products.aspose.com/slides/zh/cpp/conversion/svg-to-png/)。 
{{% /alert %}} 

## **创建具有相对比例的图片框**

通过改变图像的相对缩放，您可以创建更复杂的图片框。

1. 创建 [Presentation 类](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将图像添加到演示文稿的图像集合中。  
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_image_collection) 添加图像来创建 [IPPImage](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示如何创建具有相对比例的图片框：

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

//将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **从图片框中提取栅格图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_frame) 对象提取栅格图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示如何从文档 “sample.pptx” 中提取图像并以 PNG 格式保存。

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

## **从图片框中提取 SVG 图像**

当演示文稿包含放置在 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 形状中的 SVG 图形时，Aspose.Slides for C++ 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/)，检查底层的 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 是否包含 SVG 内容，然后将该图像以其原生 SVG 格式保存到磁盘或流中。

以下代码示例演示如何从图片框中提取 SVG 图像：

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

Aspose.Slides 允许您获取应用于图像的透明度效果。下面的 C++ 代码演示此操作：

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
所有应用于图像的效果均可在 [Aspose::Slides::Effects](https://reference.aspose.com/slides/zh/cpp/aspose.slides.effects/) 中找到。 
{{% /alert %}}

## **获取图像的亮度和对比度**

Aspose.Slides 允许您获取应用于图像的亮度和对比度效果。[ILuminance](https://reference.aspose.com/slides/zh/cpp/aspose.slides.effects/iluminance/) 接口表示此图像变换效果。

下面的 C++ 代码演示如何从图片框获取亮度和对比度设置：

```c++
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **图片框格式化**

Aspose.Slides 提供许多可应用于图片框的格式化选项。使用这些选项，您可以修改图片框以满足特定需求。

1. 创建 [Presentation 类](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_image_collection) 添加图像来创建 [IPPImage](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过 [IShapes](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_shape_collection) 对象公开的 [AddPictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法，基于图像的宽度和高度创建 `PictureFrame`。  
6. 将包含图片的图片框添加到幻灯片。  
7. 设置图片框的线条颜色。  
8. 设置图片框的线条宽度。  
9. 通过给出正值或负值来旋转图片框。  
   * 正值使图像顺时针旋转。  
   * 负值使图像逆时针旋转。  
10. 将图片框（包含图片）添加到幻灯片。  
11. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示图片框格式化过程：

```c++
// 文档目录的路径。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

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

//将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose 最近开发了一个[免费拼贴制作器](https://products.aspose.app/slides/zh/collage)。如果您需要[合并 JPG/JPEG](https://products.aspose.app/slides/zh/collage/jpg)或 PNG 图像，或[从照片创建网格](https://products.aspose.app/slides/zh/collage/photo-grid)，可以使用此服务。 

{{% /alert %}}

## **将图像添加为链接**

为避免演示文稿体积过大，您可以通过链接方式添加图像（或视频），而不是将文件直接嵌入演示文稿。下面的 C++ 代码演示如何将图像和视频添加到占位符中：

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

下面的 C++ 代码演示如何裁剪幻灯片上的现有图像：

``` CPP
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

如果您想删除框中图像的裁剪区域，可以使用 [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。该方法在不需要裁剪时返回原始图像。

下面的 C++ 代码演示此操作：

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
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法会将裁剪后的图像添加到演示文稿的图像集合中。如果该图像仅在处理过的 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 中使用，此设置可以减小演示文稿体积。否则，生成的演示文稿中的图像数量会增加。

该方法在裁剪操作中会将 WMF/EMF 元文件转换为栅格 PNG 图像。 
{{% /alert %}}

## **压缩图像**

您可以使用 [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/compressimage/) 方法压缩演示文稿中的图片。该方法通过根据形状大小和指定分辨率减小图像尺寸来实现压缩，并可选择删除裁剪区域。

它的工作方式类似于 PowerPoint 的 **图片格式 -> 压缩图片 -> 分辨率** 功能。

以下 C++ 示例演示如何通过指定目标分辨率并可选删除裁剪区域来压缩演示文稿中的图像：

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 使用目标分辨率 150 DPI（网页分辨率）压缩图像并删除裁剪区域。
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// 检查压缩结果。
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

或直接使用自定义 DPI 值：

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 将图像压缩到 150 DPI（网页分辨率），并删除裁剪区域。
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 

该方法根据形状大小和提供的 DPI 将图像转换为较低分辨率。也可以删除裁剪区域以优化文件大小。若图像为元文件（WMF/EMF）或 SVG，则不会执行压缩。JPEG 的质量会根据分辨率保留或略有降低，类似于 PowerPoint 处理高分辨率 JPEG 的方式。 
{{% /alert %}}

## **锁定纵横比**

如果希望包含图像的形状在更改图像尺寸后仍保持其纵横比，可使用 [set_AspectRatioLocked()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 方法设置 *锁定纵横比*。

下面的 C++ 代码演示如何锁定形状的纵横比：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// 设置形状在调整大小时保持纵横比
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

此 *锁定纵横比* 设置仅保留形状的纵横比，而不影响其包含的图像。 
{{% /alert %}}

## **使用 StretchOff 属性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) 属性（来自 [IPictureFillFormat](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_picture_fill_format) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_fill_format) 类），可以指定填充矩形。

当指定图像的拉伸时，源矩形会按比例缩放以适应指定的填充矩形。填充矩形的每条边由相对于形状边界框相应边缘的百分比偏移定义。正百分比表示内缩，负百分比表示外伸。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个矩形 `AutoShape`。  
4. 创建图像。  
5. 设置形状的填充类型。  
6. 设置形状的图片填充模式。  
7. 添加已设置的图像以填充形状。  
8. 指定图像相对于形状边界框对应边缘的偏移量。  
9. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码演示使用 StretchOff 属性的过程：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 设置形状主体中图像在各侧的拉伸
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **常见问题**

**如何了解 PictureFrame 支持的图像格式？**  
Aspose.Slides 通过分配给 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 的图像对象，支持栅格图像（PNG、JPEG、BMP、GIF 等）和矢量图像（例如 SVG）。支持的格式列表通常与幻灯片和图像转换引擎的能力重叠。

**添加大量大图像会对 PPTX 大小和性能产生哪些影响？**  
嵌入大图像会增加文件大小和内存使用；通过链接方式添加图像可保持演示文稿体积较小，但需要外部文件保持可访问。Aspose.Slides 提供通过链接添加图像的功能，以减小文件大小。

**如何防止图像对象被意外移动/缩放？**  
对 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 使用 [形状锁定](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/get_pictureframelock/)（例如禁用移动或缩放）。锁定机制在单独的[保护文章](/slides/zh/cpp/applying-protection-to-presentation/)中进行描述，支持包括 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 在内的多种形状类型。

**导出演示文稿为 PDF/图像时，SVG 矢量保真度是否得到保留？**  
Aspose.Slides 允许从 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 中提取原始 SVG 矢量。当[导出为 PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)或[栅格格式](/slides/zh/cpp/convert-powerpoint-to-png/)时，结果可能会根据导出设置被栅格化；提取行为确认了原始 SVG 仍以矢量形式存储。