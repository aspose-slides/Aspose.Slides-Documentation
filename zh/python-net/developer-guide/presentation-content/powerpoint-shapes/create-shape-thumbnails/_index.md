---
title: 创建形状缩略图
type: docs
weight: 70
url: /python-net/create-shape-thumbnails/
keywords: "形状缩略图。PowerPoint演示文稿，Python，Aspose.Slides for Python via .NET"
description: "Python中的PowerPoint演示文稿中的形状缩略图"
---

Aspose.Slides for Python via .NET用于创建演示文稿文件，其中每一页都是一张幻灯片。这些幻灯片可以通过使用Microsoft PowerPoint打开演示文稿文件进行查看。但有时，开发人员可能需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for Python via .NET帮助您生成幻灯片形状的缩略图。如何使用此功能在本文中进行了说明。
本文解释了如何以不同方式生成幻灯片缩略图：

- 在幻灯片中生成形状缩略图。
- 为用户定义尺寸的幻灯片形状生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。
- 生成SmartArt子节点的缩略图。
## **从幻灯片生成形状缩略图**
要使用Aspose.Slides for Python via .NET从任何幻灯片生成形状缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用其ID或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的默认缩放比例的形状缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

下面的示例生成形状缩略图。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation类
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # 创建全比例图像
    with presentation.slides[0].shapes[0].get_image() as bitmap:
        # 将图像以PNG格式保存到磁盘
        bitmap.save("Shape_thumbnail_out.png", slides.ImageFormat.PNG)
```


## **生成用户定义缩放因子的缩略图**
要使用Aspose.Slides for Python via .NET生成任何幻灯片形状的形状缩略图：

1. 创建一个 `Presentation` 类的实例。
1. 使用其ID或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的具有形状边界的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

下面的示例生成了一个具有用户定义缩放因子的缩略图。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation类
with slides.Presentation(path + "HelloWorld.pptx") as p:
    # 创建全比例图像
    with p.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.SHAPE, 1, 1) as bitmap:
        # 将图像以PNG格式保存到磁盘
        bitmap.save("Scaling Factor Thumbnail_out.png", slides.ImageFormat.PNG)
```


## **创建形状外观边界缩略图**
此方法用于创建形状的缩略图，允许开发人员在形状外观的边界内生成缩略图。它考虑到所有形状效果。生成的形状缩略图受到幻灯片边界的限制。要在其外观的边界内生成任何幻灯片形状的缩略图，请使用以下示例代码：

1. 创建一个 `Presentation` 类的实例。
1. 使用其ID或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的具有形状边界作为外观的缩略图图像。
1. 将缩略图图像保存为任何所需的图像格式。

下面的示例生成了一个具有用户定义缩放因子的缩略图。

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的Presentation类
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # 创建外观边界形状图像
    with presentation.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.APPEARANCE, 1, 1) as bitmap:
        # 将图像以PNG格式保存到磁盘
        bitmap.save("Shape_thumbnail_Bound_Shape_out.png", slides.ImageFormat.PNG)
```