---
title: 在 C++ 中高效合并演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/cpp/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并演示文稿
- 合并幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 组合 PowerPoint
- 组合演示文稿
- 组合幻灯片
- 组合 PPT
- 组合 PPTX
- 组合 ODP
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，简化工作流程。"
---

{{% alert  title="Tip" color="primary" %}} 

您可能想查看 **Aspose free online** [Merger app](https://products.aspose.app/slides/merger)。它允许用户在相同格式（PPT 转 PPT、PPTX 转 PPTX 等）下合并 PowerPoint 演示文稿，也可以在不同格式（PPT 转 PPTX、PPTX 转 ODP 等）之间合并演示文稿。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **演示文稿合并**

当您将一个演示文稿合并到另一个时，实际上是将它们的幻灯片合并到单个演示文稿中，以获得一个文件。 

{{% alert title="Info" color="info" %}}

大多数演示文稿程序（PowerPoint 或 OpenOffice）缺少允许用户以这种方式合并演示文稿的功能。 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/)，然而，允许您以不同方式合并演示文稿。您可以合并演示文稿的所有形状、样式、文本、格式、注释、动画等，而无需担心质量或数据的丢失。 

**另请参阅**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有演示文稿中的幻灯片会合并到一个演示文稿中  
* 特定幻灯片。选定的幻灯片会合并到一个演示文稿中  
* 同一格式的演示文稿（PPT 转 PPT、PPTX 转 PPTX 等）以及不同格式的演示文稿（PPT 转 PPTX、PPTX 转 ODP 等）相互合并。 

{{% alert title="Note" color="warning" %}} 

除了演示文稿，Aspose.Slides 还支持合并其它文件：

* [Images](https://products.aspose.com/slides/cpp/merger/image-to-image/)，例如 [JPG to JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) 或 [PNG to PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)  
* 文档，例如 [PDF to PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) 或 [HTML to HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)  
* 以及两种不同类型的文件，例如 [image to PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) 或 [JPG to PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) 或 [TIFF to PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/)。 

{{% /alert %}}

### **合并选项**

您可以应用以下选项，以决定：

* 输出演示文稿中的每一张幻灯片是否保留唯一的样式  
* 是否对输出演示文稿中的所有幻灯片使用相同的样式  

要合并演示文稿，Aspose.Slides 提供了来自 [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection) 接口的 [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法。`AddClone` 方法有多种实现，定义了演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合，因此您可以从目标演示文稿调用 `AddClone` 方法以合并幻灯片。 

`AddClone` 方法返回一个 `ISlide` 对象，即源幻灯片的克隆。输出演示文稿中的幻灯片仅是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或布局），而无需担心源演示文稿受到影响。 

## **合并演示文稿** 

Aspose.Slides 提供了 [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法，允许在保留原始布局和样式（默认参数）的情况下合并幻灯片。 

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


## **使用幻灯片母版合并演示文稿** 

Aspose.Slides 提供了 [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) 方法，允许在应用幻灯片母版模板的情况下合并幻灯片。这样，必要时您可以更改输出演示文稿中幻灯片的样式。 

以下 C++ 代码演示了上述操作：
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

幻灯片母版的布局会自动确定。当无法确定合适的布局时，如果 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)。 

{{% /alert %}}

如果希望输出演示文稿中的幻灯片使用不同的布局，请在合并时改用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) 方法。 

## **从演示文稿中合并特定幻灯片** 

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片集非常有用。Aspose.Slides C++ 允许您只选择并导入所需的幻灯片。API 会保留原始幻灯片的格式、布局和设计。 

下面的 C++ 代码创建一个新演示文稿，从两个其他演示文稿中添加标题幻灯片，并将结果保存为文件：
```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```

```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```


## **使用幻灯片布局合并演示文稿** 

此 C++ 代码展示了如何在合并幻灯片时应用您首选的幻灯片布局，以生成一个输出演示文稿：
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **合并不同尺寸幻灯片的演示文稿** 

{{% alert title="Note" color="warning" %}} 

无法合并尺寸不同的演示文稿。 

{{% /alert %}} 

若要合并尺寸不同的两个演示文稿，必须将其中一个演示文稿的尺寸调整为与另一个相同。 

以下示例代码演示了此操作：
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


## **将幻灯片合并到演示文稿章节** 

此 C++ 代码展示了如何将特定幻灯片合并到演示文稿的某个章节：
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


该幻灯片会被添加到章节的末尾。 

{{% alert title="Tip" color="primary" %}}

Aspose 提供了免费的 [Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图片，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid)，等等。 

{{% /alert %}}

## **FAQ**

**合并时是否保留演讲者备注？**

是的。克隆幻灯片时，Aspose.Slides 会保留所有幻灯片元素，包括备注、格式和动画。

**评论及其作者会被转移吗？**

评论作为幻灯片内容的一部分，会随幻灯片一起复制。评论作者标签会以评论对象的形式保留在生成的演示文稿中。

**如果源演示文稿受密码保护怎么办？**

必须使用密码通过 [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) 打开（参见 [/slides/cpp/password-protected-presentation/]），加载后，这些幻灯片可以安全地克隆到未受保护的目标文件（或同样受保护的文件）中。

**合并操作的线程安全性如何？**

请勿在 **多个线程** 中使用同一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 实例。推荐的规则是 “一个文档 — 一个线程”；不同的文件可以在独立线程中并行处理。