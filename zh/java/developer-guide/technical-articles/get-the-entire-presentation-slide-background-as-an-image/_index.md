---
title: 获取整个演示文稿幻灯片背景作为图像
type: docs
weight: 95
url: /java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片
- 背景
- 幻灯片背景
- 背景到图像
- PowerPoint
- PPT
- PPTX
- PowerPoint 演示文稿
- Java
- Aspose.Slides for Java
---

在 PowerPoint 演示文稿中，幻灯片背景可以由许多元素组成。除了设置为[幻灯片背景](/slides/java/presentation-background/)的图像外，最终背景还可以受到演示主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for Java 没有提供提取整个演示文稿幻灯片背景作为图像的简单方法，但您可以按照以下步骤来完成此操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类加载演示文稿。
1. 获取演示文稿的幻灯片大小。
1. 选择一张幻灯片。
1. 创建一个临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片大小。
1. 将选定的幻灯片克隆到临时演示文稿中。
1. 从克隆的幻灯片中删除形状。
1. 将克隆的幻灯片转换为图像。

以下代码示例提取整个演示文稿幻灯片背景作为图像。
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```