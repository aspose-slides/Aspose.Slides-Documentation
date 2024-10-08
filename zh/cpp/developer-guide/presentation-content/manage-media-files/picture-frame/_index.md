---
title: 图片框
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "添加图片框，创建图片框，添加图像，创建图像，提取图像，StretchOff 属性，图片框格式，图片框属性，PowerPoint 演示文稿，C++，CPP，Aspose.Slides for C++"
description: "在 C++ 中为 PowerPoint 演示文稿添加图片框"
---

图片框是一种包含图像的形状——它就像框中的一幅画。

您可以通过图片框将图像添加到幻灯片中。通过这种方式，您可以通过格式化图片框来格式化图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——使人们能够快速从图像创建演示文稿。

{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 的实例。
2. 通过索引获取幻灯片的引用。
3. 通过将图像添加到与演示文稿对象相关联的 [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 中，创建 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充形状。
4. 指定图像的宽度和高度。
5. 通过与引用幻灯片相关的形状对象暴露的 `AddPictureFrame` 方法，基于图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame)。
6. 将包含图片的图片框添加到幻灯片。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了如何创建图片框：

```c++
// 文件夹路径。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 加载将添加到演示文稿图像集中的图像
// 获取图片
auto image = Images::FromFile(filePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 将图片框添加到幻灯片
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对缩放宽度和高度
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// 对 PictureFrame 应用一些格式
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

图片框使您能够快速基于图像创建演示幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操控输入/输出操作以将图像从一种格式转换为另一种格式。您可能希望查看这些页面：转换 [图像为 JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)；转换 [JPG 为图像](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)；转换 [JPG 为 PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)，转换 [PNG 为 JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)；转换 [PNG 为 SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)，转换 [SVG 为 PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **使用相对缩放创建图片框**

通过更改图像的相对缩放，您可以创建更复杂的图片框。

1. 创建 [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 的实例。
2. 通过索引获取幻灯片的引用。
3. 向演示文稿图像集合中添加图像。
4. 通过将图像添加到与演示文稿对象相关联的 [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 中，创建 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象。
5. 在图片框中指定图像的相对宽度和高度。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了如何以相对缩放创建图片框：

```c++
// 文件夹路径。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 加载将添加到演示文稿图像集中的图像
// 获取图片
auto image = Images::FromFile(filePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 将图片框添加到幻灯片
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对缩放宽度和高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **从图片框中提取图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) 对象中提取图像，并将其保存为 PNG、JPG 和其他格式。以下代码示例演示了如何从文档 "sample.pptx" 中提取图像并将其保存为 PNG 格式。

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

## **获取图像透明度**

Aspose.Slides 允许您获取图像的透明度。以下 C++ 代码演示了该操作：

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"图片透明度: ") + transparencyValue);
    }
}
```

## **图片框格式**

Aspose.Slides 提供了多种格式选项，可以应用于图片框。使用这些选项，您可以更改图片框以满足特定要求。

1. 创建 [Presentation class](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 的实例。
2. 通过索引获取幻灯片的引用。
3. 通过将图像添加到与演示文稿对象相关联的 [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 中，创建 [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) 对象。
4. 指定图像的宽度和高度。
5. 通过 [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) 对象关联的与引用幻灯片相关的 [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法创建一个 `PictureFrame`，基于图像的宽度和高度。
6. 将包含图片的图片框添加到幻灯片。
7. 设置图片框的线条颜色。
8. 设置图片框的线条宽度。
9. 通过给出正值或负值来旋转图片框。
   * 正值将图像顺时针旋转。
   * 负值将图像逆时针旋转。
10. 将包含图片的图片框添加到幻灯片。
11. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了图片框格式化过程：

```c++
// 文件夹路径。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 加载所需的演示文稿
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 加载将添加到演示文稿图像集中的图像
// 获取图片
auto image = Images::FromFile(filePath);

// 将图像添加到演示文稿的图像集合中
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 将图片框添加到幻灯片
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对缩放宽度和高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// 将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="提示" color="primary" %}}

Aspose 最近开发了一个 [免费拼贴制作器](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，您可以使用此服务。 

{{% /alert %}}

## **将图像作为链接添加**

为了避免演示文稿文件过大，您可以通过链接添加图像（或视频），而不是将文件直接嵌入到演示文稿中。以下 C++ 代码演示了如何将图像和视频添加到占位符：

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

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 创建新的图像对象
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// 向幻灯片添加一个PictureFrame
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 裁剪图像（百分比值）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 保存结果
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **删除图片的裁剪区域**

如果您想删除框中图像的裁剪区域，可以使用 [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。该方法返回裁剪后的图像或原始图像（如果不需要裁剪）。

以下 C++ 代码演示了该操作： 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 获取第一个幻灯片的 PictureFrame
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// 保存结果
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法将裁剪后的图像添加到演示文稿图像集合中。如果该图像仅在处理过的 [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) 中使用，则此设置可以减少演示文稿的大小。否则，结果演示文稿中的图像数量将增加。

该方法在裁剪操作中将 WMF/EMF 元文件转换为光栅 PNG 图像。 

{{% /alert %}}

## **锁定纵横比**

如果您希望包含图像的形状在更改图像尺寸时保持其纵横比，可以使用 [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 方法设置 *锁定纵横比* 设置。 

以下 C++ 代码演示了如何锁定形状的纵横比：

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

{{% alert title="注意" color="warning" %}} 

此 *锁定纵横比* 设置仅保留形状的纵横比，而不保留其包含的图像。

{{% /alert %}}

## **使用 StretchOff 属性**

使用 [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) 和 [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) 属性，从 [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format) 类，您可以指定填充矩形。 

在指定图像的拉伸时，源矩形会缩放以适应指定的填充矩形。填充矩形的每个边都由从形状的边界框的相应边的百分比偏移量定义。正百分比指定内缩。负百分比指定外缩。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个矩形 `AutoShape`。 
4. 创建一个图像。
5. 设置形状的填充类型。
6. 设置形状的图片填充模式。
7. 添加一个设置图像以填充形状。
8. 指定图像相对于形状边界框的相应边的偏移量。
9. 将修改后的演示文稿写入 PPTX 文件。

以下 C++ 代码演示了使用 StretchOff 属性的过程：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 设置图像从形状体的每一侧拉伸
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```