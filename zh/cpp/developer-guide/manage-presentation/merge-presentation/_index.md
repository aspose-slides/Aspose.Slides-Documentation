---
title: 合并演示文稿 - C++ PowerPoint API
linktitle: 合并演示文稿
type: docs
weight: 40
url: /cpp/merge-presentation/
keywords: "合并 PowerPoint, PPTX, PPT, 组合 PowerPoint, 合并演示文稿, 组合演示文稿, C++"
description: 本文解释了如何使用 C++ PowerPoint API 或库合并或组合 PowerPoint 演示文稿。
---

{{% alert title="提示" color="primary" %}} 

您可能想要查看 **Aspose 免费在线** [合并应用](https://products.aspose.app/slides/merger)。它允许用户以相同格式（PPT 到 PPT，PPTX 到 PPTX 等）合并 PowerPoint 演示文稿，并以不同格式（PPT 到 PPTX，PPTX 到 ODP 等）合并演示文稿。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个演示文稿时，您实际上是将它们的幻灯片组合到一个演示文稿中以获得一个文件。 

{{% alert title="信息" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺乏允许用户以这种方式组合演示文稿的功能。 

然而， [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) 允许您以不同的方式合并演示文稿。您可以合并演示文稿及其所有形状、样式、文本、格式、评论、动画等，而无需担心质量或数据的损失。 

**另见**

[克隆幻灯片](https://docs.aspose.com/slides/cpp/clone-slides/)。 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有来自演示文稿的幻灯片最终会出现在一个演示文稿中
* 特定幻灯片。选定的幻灯片最终会出现在一个演示文稿中
* 以一种格式（PPT 到 PPT，PPTX 到 PPTX 等）以及不同格式（PPT 到 PPTX，PPTX 到 ODP 等）相互合并。 

{{% alert title="注意" color="warning" %}} 

除了演示文稿，Aspose.Slides 还允许运合并其他文件：

* [图像](https://products.aspose.com/slides/cpp/merger/image-to-image/)，例如 [JPG 到 JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) 或 [PNG 到 PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* 文档，例如 [PDF 到 PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) 或 [HTML 到 HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* 以及不同的两个文件，例如 [图像到 PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) 或 [JPG 到 PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) 或 [TIFF 到 PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **合并选项**

您可以应用决定是否

* 输出演示文稿中的每个幻灯片保留独特的样式
* 所有输出演示文稿中的幻灯片使用特定样式。 

要合并演示文稿，Aspose.Slides 提供 [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection) 接口）。不同的 `AddClone` 方法实现定义了演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合，因此您可以从想要合并幻灯片的演示文稿调用 `AddClone` 方法。 

`AddClone` 方法返回一个 `ISlide` 对象，这是源幻灯片的克隆。输出演示文稿中的幻灯片只是源幻灯片的副本。因此，您可以更改生成的幻灯片（例如，应用样式或格式选项或布局），而无需担心源演示文稿受到影响。 

## **合并演示文稿** 

Aspose.Slides 提供 [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法，允许您在保持幻灯片布局和样式的同时合并幻灯片（默认参数）。 

以下 C++ 代码演示了如何合并演示文稿：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **合并带有幻灯片母版的演示文稿**

Aspose.Slides 提供 [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) 方法，允许您在应用幻灯片母版演示文稿模板的同时合并幻灯片。这样，如果需要，您可以更改输出演示文稿中的幻灯片样式。 

这段 C++ 代码演示了所描述的操作：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

幻灯片母版的幻灯片布局自动确定。当无法确定适当的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) 异常。 

{{% /alert %}}

如果您希望输出演示文稿中的幻灯片具有不同的幻灯片布局，请在合并时使用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) 方法。 

## **从演示文稿合并特定幻灯片**

以下 C++ 代码展示了如何选择并组合来自不同演示文稿的特定幻灯片以获取一个输出演示文稿：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **合并带有幻灯片布局的演示文稿**

以下 C++ 代码展示了如何在将您首选的幻灯片布局应用于演示文稿的同时组合演示文稿中的幻灯片以获取一个输出演示文稿：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **合并具有不同幻灯片大小的演示文稿**

{{% alert title="注意" color="warning" %}} 

您不能合并具有不同幻灯片大小的演示文稿。 

{{% /alert %}}

要合并具有不同幻灯片大小的两个演示文稿，您必须调整其中一个演示文稿的大小以使其大小与另一个演示文稿匹配。 

以下示例代码演示了所描述的操作：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **将幻灯片合并到演示文稿部分**

以下 C++ 代码展示了如何将特定幻灯片合并到演示文稿的部分：

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

幻灯片被添加到该部分的末尾。 

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。通过这个在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。 

{{% /alert %}}