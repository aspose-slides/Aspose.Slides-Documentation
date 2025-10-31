---
title: 在 Python 中从演示文稿形状提取图像
linktitle: 形状中的图像
type: docs
weight: 90
url: /zh/python-net/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- 幻灯片背景
- 形状背景
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 —— 快速、代码友好的解决方案。"
---

## **从形状中提取图像**

{{% alert color="primary" %}} 

图片通常会被添加到形状中，也常用作幻灯片的背景。图像对象是通过[IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)添加的，它是[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)对象的集合。 

本文说明了如何提取添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每张幻灯片，再遍历每个形状以定位图像。找到或识别出图像后，即可将其提取并另存为新文件。 XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #访问演示文稿
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #访问第一张幻灯片
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #获取背景图片  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #获取背景图片  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #设置所需的图片格式 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```

## **常见问题**

**我能提取原始图像而不进行任何裁剪、特效或形状转换吗？**

是的。当您访问形状的图像时，您从演示文稿的[image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)中获取图像对象，这意味着获取的是未裁剪或未应用样式特效的原始像素。工作流遍历演示文稿的图像集合和[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)对象，这些对象存储原始数据。

**一次保存大量图像时，是否有复制相同文件的风险？**

是的，如果不加区分地全部保存。演示文稿的[image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)可能包含相同的二进制数据，这些数据被不同的形状或幻灯片引用。为了避免重复，在写入之前比较哈希值、大小或提取数据的内容。

**我如何确定哪些形状与演示文稿集合中的特定图像关联？**

Aspose.Slides 不会存储从[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)到形状的反向链接。您需要在遍历过程中手动建立映射：每当发现对[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)的引用时，记录使用该图像的形状。

**我能提取嵌入在 OLE 对象中的图像，例如附件文档吗？**

不能直接提取，因为 OLE 对象是一个容器。您需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)工作；OLE 是另一种对象类型。