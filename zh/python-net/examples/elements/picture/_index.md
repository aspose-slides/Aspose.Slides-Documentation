---
title: 图片
type: docs
weight: 50
url: /zh/python-net/examples/elements/picture/
keywords:
- 图片
- 图片框
- 添加图片
- 访问图片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中处理图片：插入、替换、裁剪、压缩、调整透明度和效果、填充形状，并导出为 PPT、PPTX 和 ODP。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 从内存图像中插入和访问图片。下面的示例在内存中创建图像，将其放置在幻灯片上，然后检索它。

## **添加图片**

此代码从文件加载图像，并将其作为图片框插入到第一张幻灯片中。

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 从文件加载图像。
        with open("image.png", "rb") as image_stream:
            # 将图像添加到演示文稿资源。
            image = presentation.images.add_image(image_stream)

        # 在第一页幻灯片上插入显示图像的图片框。
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **访问图片**

此示例确保幻灯片包含图片框，然后访问它找到的第一个图片框。

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # 访问幻灯片上的第一个图片框。
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```