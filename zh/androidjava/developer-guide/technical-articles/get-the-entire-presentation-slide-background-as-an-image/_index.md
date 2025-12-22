---
title: 从演示文稿中获取完整幻灯片背景并将其保存为图像
linktitle: 完整幻灯片背景
type: docs
weight: 95
url: /zh/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片背景
- 最终背景
- 提取背景
- 完整背景
- 背景转图像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 从 PowerPoint 和 OpenDocument 演示文稿中提取完整幻灯片背景为图像，简化视觉工作流。"
---

## **获取整个幻灯片背景**

在 PowerPoint 演示文稿中，幻灯片背景可能由许多元素组成。除了设置为[幻灯片背景](/slides/zh/androidjava/presentation-background/)的图像之外，最终背景还可能受到演示主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for Android via Java 并未提供直接提取整个演示文稿幻灯片背景为图像的方法，但您可以按以下步骤操作：
1. 使用[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)类加载演示文稿。
1. 从演示文稿获取幻灯片尺寸。
1. 选择一张幻灯片。
1. 创建临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片尺寸。
1. 将选定的幻灯片克隆到临时演示文稿中。
1. 删除克隆幻灯片上的形状。
1. 将克隆的幻灯片转换为图像。

下面的代码示例将整个演示文稿幻灯片背景提取为图像。
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


## **FAQ**

**从母版幻灯片的复杂渐变、纹理或图片填充在生成的背景图像中会被保留吗？**

是的。Aspose.Slides 会渲染在幻灯片、布局或母版上定义的渐变、图片和纹理填充。如果需要将外观与继承的母版隔离，请在导出前在当前幻灯片上[设置独立背景](/slides/zh/androidjava/presentation-background/)。

**在保存之前，我可以在生成的背景图像上添加水印吗？**

是的。您可以在工作[幻灯片副本](/slides/zh/androidjava/clone-slides/)上添加[水印](/slides/zh/androidjava/watermark/)形状或图像（放置在其他内容后面），然后导出。这使您能够生成带有嵌入水印的背景图像。

**我可以在不关联到现有幻灯片的情况下获取特定布局或母版的背景吗？**

是的。访问所需的母版或布局，将其应用于具有所需大小的[临时幻灯片](/slides/zh/androidjava/clone-slides/)，然后导出该幻灯片即可获取该布局或母版派生的背景。

**是否存在影响图像导出的许可限制？**

渲染功能在[有效许可证](/slides/zh/androidjava/licensing/)下完全可用。在评估模式下，输出可能包含水印等限制。请在每个进程首次运行批量导出前激活许可证。