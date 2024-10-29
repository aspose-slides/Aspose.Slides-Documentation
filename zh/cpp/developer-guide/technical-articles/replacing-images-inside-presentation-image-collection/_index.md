---
title: 替换演示文稿图像集合中的图像
type: docs
weight: 90
url: /zh/cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for C++ 允许您替换幻灯片形状中添加的图像。在本文中，您将学习如何通过不同的方法替换演示文稿图像集合中的图像。

{{% /alert %}} 
## **在演示文稿图像集合中替换图像**
Aspose.Slides for C++ 提供了一种简单的 API 方法，可以通过以下方式替换演示文稿图像集合中的图像：

1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类加载包含图像的演示文稿文件。
1. 从文件加载图像到字节数组中。
1. 使用以下方法之一：
   - 第一个方法：用字节数组中的新图像替换目标图像。
   - 第二个方法：将图像加载到 [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) 对象中，并用加载的图像替换目标图像。
   - 第三个方法：用演示文稿图像集合中已添加的图像替换图像。
1. 将修改后的演示文稿写入 PPTX 文件。

以下示例代码演示了如何替换演示文稿图像集合中的图像：

``` cpp
// 实例化演示文稿
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// 第一个方法
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// 第二个方法
SharedPtr<IImage> newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 第三个方法
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// 保存演示文稿
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```