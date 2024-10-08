---
title: 替换演示文稿图像集合中的图像
type: docs
weight: 110
url: /python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for Python via .NET 使得替换幻灯片形状中添加的图像成为可能。本文解释了如何使用不同的方法替换演示文稿图像集合中添加的图像。

{{% /alert %}} 
## **替换演示文稿图像集合中的图像**
Aspose.Slides for Python via .NET 提供了简单的 API 方法，用于替换演示文稿图像集合中的图像。请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载包含图像的演示文稿文件。
1. 从文件加载一个字节数组中的图像。
1. 用字节数组中的新图像替换目标图像。
1. 在第二种方法中，将图像加载到 Image 对象中，并用加载的图像替换目标图像。
1. 在第三种方法中，用演示文稿图像集合中已添加的图像替换图像。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#实例化演示文稿
with slides.Presentation("pres.pptx") as presentation:

    #第一种方法
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #第二种方法
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #第三种方法
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #保存演示文稿
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```