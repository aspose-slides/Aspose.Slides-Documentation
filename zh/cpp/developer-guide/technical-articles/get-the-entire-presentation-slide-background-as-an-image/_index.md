---
title: 从演示文稿中获取整个幻灯片背景并保存为图像
linktitle: 整个幻灯片背景
type: docs
weight: 95
url: /zh/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片背景
- 最终背景
- 提取背景
- 完整背景
- 背景转为图像
- PPT背景
- PPTX背景
- ODP背景
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 从 PowerPoint 和 OpenDocument 演示文稿中提取完整幻灯片背景为图像，简化可视化工作流。"
---

## **获取整个幻灯片背景**

在 PowerPoint 演示文稿中，幻灯片背景可能由多个元素组成。除了设置为[幻灯片背景](/slides/zh/cpp/presentation-background/)的图像之外，最终背景还可能受到演示主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for C++ 未提供直接将整个演示文稿幻灯片背景提取为图像的简便方法，但您可以按照以下步骤操作：
1. 使用[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类加载演示文稿。
1. 从演示文稿中获取幻灯片尺寸。
1. 选择一张幻灯片。
1. 创建一个临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片尺寸。
1. 将选定的幻灯片克隆到临时演示文稿中。
1. 删除克隆幻灯片上的形状。
1. 将克隆的幻灯片转换为图像。

以下代码示例将整个演示文稿幻灯片背景提取为图像。
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```


## **常见问题**

**复杂的渐变、纹理或母版幻灯片中的图片填充会在生成的背景图像中保留吗？**

是的。Aspose.Slides 渲染在幻灯片、布局或母版上定义的渐变、图片和纹理填充。如果您需要将外观与继承的母版分离，请在导出前在当前幻灯片上[设置自己的背景](/slides/zh/cpp/presentation-background/)。

**在保存之前，我可以在生成的背景图像上添加水印吗？**

是的。您可以在工作中的[幻灯片副本](/slides/zh/cpp/clone-slides/)上添加[水印](/slides/zh/cpp/watermark/)形状或图像（放置在其他内容后面），然后导出。这样即可生成已嵌入水印的背景图像。

**我能在不绑定到现有幻灯片的情况下获取特定布局或母版的背景吗？**

是的。访问所需的母版或布局，将其应用于具有所需尺寸的[临时幻灯片](/slides/zh/cpp/clone-slides/)，然后导出该幻灯片即可获取源自该布局或母版的背景。

**是否存在影响图像导出的许可限制？**

渲染功能在拥有[有效许可证](/slides/zh/cpp/licensing/)时可完整使用。在评估模式下，输出可能会包含水印等限制。请在运行批量导出之前为每个进程激活一次许可证。