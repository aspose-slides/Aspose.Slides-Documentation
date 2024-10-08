---
title: 将PowerPoint PPT转换为JPG
type: docs
weight: 60
url: /zh/cpp/convert-powerpoint-to-jpg/
keywords:
- 转换PowerPoint演示文稿
- JPG
- JPEG
- PowerPoint到JPG
- PowerPoint到JPEG
- PPT到JPG
- PPTX到JPG
- PPT到JPEG
- PPTX到JPEG
- C++
- Aspose.Slides
description: "将PowerPoint转换为JPG：PPT到JPG，PPTX到JPG在C++中"
---

## **将演示文稿转换为一组图像**

在某些情况下，有必要将整个演示文稿转换为一组图像，就像PowerPoint允许的那样。以下C++代码显示了如何将演示文稿转换为JPG图像：

```c++
auto imageScale = 1.0f;

auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : pres->get_Slides())
{
    // 创建全尺寸图像
    System::SharedPtr<IImage> image = slide->GetImage(imageScale, imageScale);

    // 将图像以JPEG格式保存到磁盘
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert color="primary" %}} 

要查看Aspose.Slides如何将PowerPoint转换为JPG图像，您可以尝试这些免费的在线转换器：PowerPoint [PPTX到JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg)和[PPT到JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

## **将PowerPoint PPT/PPTX转换为具有自定义尺寸的JPG**

要更改生成的缩略图和JPG图像的尺寸，您可以通过将其传递给`float scaleX, float Y`的[**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method)方法来设置*ScaleX*和*ScaleY*值：

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// 定义尺寸
int32_t desiredX = 1200, desiredY = 800;

// 获取X和Y的缩放值
float scaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float scaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& slide : pres->get_Slides())
{
    // 创建全尺寸图像
    System::SharedPtr<IImage> image = slide->GetImage(scaleX, scaleY);

    // 将图像以JPEG格式保存到磁盘
    auto imageFileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(imageFileName, ImageFormat::Jpeg);

    image->Dispose();
}

pres->Dispose();
```

{{% alert title="提示" color="primary" %}}

Aspose提供了一个[免费的拼贴网页应用](https://products.aspose.app/slides/collage)。通过这个在线服务，您可以合并[JPG到JPG](https://products.aspose.app/slides/collage/jpg)或PNG到PNG图像，创建[照片网格](https://products.aspose.app/slides/collage/photo-grid)等等。 

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请参阅这些页面：转换[图像到JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/)；转换[JPG到图像](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/)；转换[JPG到PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/)，转换[PNG到JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/)；转换[PNG到SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/)，转换[SVG到PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **另见**

查看其他将PPT/PPTX转换为图像的选项，例如：

- [PPT/PPTX到SVG转换](/slides/zh/cpp/render-a-slide-as-an-svg-image/)