---
title: 将 PowerPoint 转换为 PNG
type: docs
weight: 30
url: /zh/python-net/convert-powerpoint-to-png/
keywords: PowerPoint 转 PNG, PPT 转 PNG, PPTX 转 PNG, Python, Aspose.Slides for Python via .NET
description: 将 PowerPoint 演示文稿转换为 PNG
---

## **关于 PowerPoint 到 PNG 的转换**

PNG（可移植网络图形）格式不如 JPEG（联合图像专家组）流行，但仍然非常受欢迎。

**用例：** 当您有复杂的图像且大小不是问题时，PNG 是比 JPEG 更好的图像格式。

{{% alert title="提示" color="primary" %}} 您可能想查看 Aspose 免费的 **PowerPoint 到 PNG 转换器**： [PPTX 转 PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT 转 PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。 这两者是该页面描述的过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 集合中获取 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 接口的幻灯片对象。
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 方法获取每个幻灯片的缩略图。
4. 使用 [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) 方法将幻灯片缩略图保存为 PNG 格式。

以下 Python 代码演示了如何将 PowerPoint 演示文稿转换为 PNG：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果您想获得大约某一特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这将决定生成缩略图的尺寸。

以下 Python 代码演示了所描述的操作：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **使用自定义大小将 PowerPoint 转换为 PNG**

如果您想获得大约某一特定大小的 PNG 文件，可以传递您偏好的 `width` 和 `height` 参数给 `ImageSize`。

以下代码演示了如何在指定图像大小的情况下将 PowerPoint 转换为 PNG：

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```