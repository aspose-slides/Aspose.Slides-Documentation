---
title: 将整个演示文稿幻灯片背景提取为图像
type: docs
weight: 95
url: /zh/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片
- 背景
- 幻灯片背景
- 背景为图像
- PowerPoint
- PPT
- PPTX
- PowerPoint演示文稿
- Java
- Aspose.Slides for Android via Java
---

在PowerPoint演示文稿中，幻灯片背景可以由多个元素组成。除了设置为[幻灯片背景](/slides/zh/androidjava/presentation-background/)的图像外，最终背景还可能受到演示文稿主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for Android via Java并没有提供一个简单的方法来将整个演示文稿幻灯片背景提取为图像，但您可以按照以下步骤操作：
1. 使用[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)类加载演示文稿。
1. 从演示文稿中获取幻灯片大小。
1. 选择一张幻灯片。
1. 创建一个临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片大小。
1. 将选定的幻灯片克隆到临时演示文稿中。
1. 从克隆的幻灯片中删除形状。
1. 将克隆的幻灯片转换为图像。

以下代码示例将整个演示文稿幻灯片背景提取为图像。
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```