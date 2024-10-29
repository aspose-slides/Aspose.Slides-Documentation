---
title: 替换演示文稿图像集合中的图像
type: docs
weight: 110
url: /zh/net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NET 使得可以替换添加到幻灯片形状中的图像。本文解释了如何使用不同的方法替换演示文稿图像集合中添加的图像。

{{% /alert %}} 
## **在演示文稿图像集合中替换图像**
Aspose.Slides for .NET 提供了简单的 API 方法，用于替换演示文稿图像集合中的图像。请按照以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类加载包含图像的演示文稿文件。
1. 从文件中加载图像为字节数组。
1. 使用新的字节数组替换目标图像。
1. 在第二种方法中，将图像加载到 Image 对象中，并用加载的图像替换目标图像。
1. 在第三种方法中，用演示文稿图像集合中已添加的图像替换图像。
1. 将修改后的演示文稿保存为 PPTX 文件。

```c#
//实例化演示文稿
using Presentation presentation = new Presentation("presentation.pptx");

//第一种方法
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//第二种方法
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//第三种方法
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//保存演示文稿
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```