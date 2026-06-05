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
- 已裁剪区域
- StretchOff 属性
- 图片框格式化
- 图片框属性
- 相对比例
- 图像效果
- 长宽比
- 图像透明度
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将图片框添加到 PowerPoint 和 OpenDocument 演示文稿。简化工作流程并提升幻灯片设计。"
---
## **介绍**

图片框是一种包含图像的形状——它就像装在框里的图片。

您可以通过图片框将图像添加到幻灯片。这样，您就可以通过格式化图片框来对图像进行格式化。

{{% alert  title="Tip" color="primary" %}} 

Aspose 提供免费转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——帮助用户快速从图像创建演示文稿。 

{{% /alert %}} 

## **创建图片框**

1. 创建一个 [Presentation 类](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_image_collection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充形状。  
4. 指定图像的宽度和高度。  
5. 通过引用的幻灯片关联的形状对象公开的 `AddPictureFrame` 方法，基于图像的宽度和高度创建一个 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_frame)。  
6. 将包含图片的图片框添加到幻灯片。  
7. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码展示了如何创建图片框：

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

// 向演示文稿的图像集合中添加图像
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 向幻灯片添加图片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对缩放的宽度和高度
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

图片框可帮助您快速基于图像创建演示幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，可以操作输入/输出以将图像从一种格式转换为另一种格式。您可能想查看以下页面：将 [图像转换为 JPG](https://products.aspose.com/slides/zh/cpp/conversion/image-to-jpg/)；将 [JPG 转换为图像](https://products.aspose.com/slides/zh/cpp/conversion/jpg-to-image/)；将 [JPG 转换为 PNG](https://products.aspose.com/slides/zh/cpp/conversion/jpg-to-png/)，将 [PNG 转换为 JPG](https://products.aspose.com/slides/zh/cpp/conversion/png-to-jpg/)；将 [PNG 转换为 SVG](https://products.aspose.com/slides/zh/cpp/conversion/png-to-svg/)，将 [SVG 转换为 PNG](https://products.aspose.com/slides/zh/cpp/conversion/svg-to-png/)。 

{{% /alert %}}

## **使用相对比例创建图片框**

通过改变图像的相对缩放，您可以创建更复杂的图片框。

1. 创建一个 [Presentation 类](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation) 的实例。  
2. 通过索引获取幻灯片的引用。  
3. 将图像添加到演示文稿的图像集合中。  
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_image_collection) 添加图像，创建一个 [IPPImage](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_p_p_image) 对象，用于填充形状。  
5. 在图片框中指定图像的相对宽度和高度。  
6. 将修改后的演示文稿写入为 PPTX 文件。  

下面的 C++ 代码展示了如何使用相对比例创建图片框：

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

// 向演示文稿的图像集合中添加图像
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 向幻灯片添加图片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 设置相对缩放的宽度和高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//将 PPTX 文件写入磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **从图片框中提取光栅图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.picture_frame) 对象中提取光栅图像，并将其保存为 PNG、JPG 等格式。下面的代码示例演示了如何从文档 “sample.pptx” 中提取图像并以 PNG 格式保存。

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

当演示文稿在 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/) 形状中包含 SVG 图形时，Aspose.Slides for C++ 允许您以完整保真度检索原始矢量图像。通过遍历幻灯片的形状集合，您可以识别每个 [PictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pictureframe/)，检查其底层的 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 是否包含 SVG 内容，然后将该图像以原生 SVG 格式保存到磁盘或流中。

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

Aspose.Slides 允许您获取应用于图像的透明度效果。下面的 C++ 代码演示了该操作：

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

## **图片框格式化**

Aspose.Slides 提供多种格式化选项，可应用于图片框。使用这些选项，您可以调整图片框以满足特定需求。

1. 创建一个 [Presentation 类](https://reference.aspose.com/sl