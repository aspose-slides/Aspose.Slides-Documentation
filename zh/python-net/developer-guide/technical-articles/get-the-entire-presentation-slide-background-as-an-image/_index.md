---
title: 获取整个演示文稿幻灯片背景作为图像
type: docs
weight: 95
url: /python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片
- 背景
- 幻灯片背景
- 背景转换为图像
- PowerPoint
- PPT
- PPTX
- PowerPoint 演示文稿
- Python
- Aspose.Slides for Python
---

在 PowerPoint 演示文稿中，幻灯片背景可以由许多元素组成。除了设置为 [幻灯片背景](/slides/python-net/presentation-background/) 的图像外，最终背景还可以受到演示文稿主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for Python 并没有提供一个简单的方法来将整个演示文稿的幻灯片背景提取为图像，但您可以按照以下步骤进行操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类加载演示文稿。
1. 获取演示文稿的幻灯片大小。
1. 选择一张幻灯片。
1. 创建一个临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片大小。
1. 将选择的幻灯片克隆到临时演示文稿中。
1. 删除克隆幻灯片中的形状。
1. 将克隆的幻灯片转换为图像。

以下代码示例提取整个演示文稿的幻灯片背景作为图像。
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```