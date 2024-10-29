---
title: 获取整个演示文稿幻灯片背景作为图像
type: docs
weight: 95
url: /zh/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 幻灯片
- 背景
- 幻灯片背景
- 背景转为图像
- PowerPoint
- PPT
- PPTX
- PowerPoint 演示文稿
- C++
- Aspose.Slides for C++
---

在 PowerPoint 演示文稿中，幻灯片背景可以由许多元素组成。除了设置为 [幻灯片背景](/slides/zh/cpp/presentation-background/) 的图像外，最终的背景还受到演示主题、配色方案以及放置在母版幻灯片和布局幻灯片上的形状的影响。

Aspose.Slides for C++ 不提供将整个演示文稿幻灯片背景提取为图像的简单方法，但您可以按照以下步骤进行操作：
1. 使用 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类加载演示文稿。
1. 从演示文稿中获取幻灯片大小。
1. 选择一张幻灯片。
1. 创建一个临时演示文稿。
1. 在临时演示文稿中设置相同的幻灯片大小。
1. 将选定的幻灯片克隆到临时演示文稿中。
1. 从克隆的幻灯片中删除形状。
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