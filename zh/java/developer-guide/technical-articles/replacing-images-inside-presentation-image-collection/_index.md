---
title: 替换演示文稿图像集合中的图像
type: docs
weight: 80
url: /zh/java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java 使得在幻灯片形状中替换图像成为可能。本文解释了如何使用不同的方法替换添加到演示文稿图像集合中的图像。

{{% /alert %}} 
## **替换演示文稿图像集合中的图像**
Aspose.Slides for Java 提供了简单的 API 方法，用于替换演示文稿图像集合中的图像。请按照以下步骤操作：

1. 使用 Presentation 类加载包含图像的演示文稿文件。
1. 从文件中以字节数组加载图像。
1. 用新的字节数组中的图像替换目标图像。
1. 在第二种方法中加载图像到 Image 对象，并用加载的图像替换目标图像。
1. 在第三种方法中，用已经添加到演示文稿图像集合中的图像替换图像。
1. 将修改后的演示文稿写入 PPTX 文件。

```java
//实例化演示文稿
Presentation presentation = new Presentation("presentation.pptx");

//第一种方法
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

//第二种方法
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

//第三种方法
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

//保存演示文稿
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```