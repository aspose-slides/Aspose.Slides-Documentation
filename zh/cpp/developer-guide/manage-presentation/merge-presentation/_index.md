---
title: 高效合并 C++ 演示文稿
linktitle: 合并演示文稿
type: docs
weight: 40
url: /zh/cpp/merge-presentation/
keywords:
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- 合并 PowerPoint
- 合并 演示文稿
- 合并 幻灯片
- 合并 PPT
- 合并 PPTX
- 合并 ODP
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松合并 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）演示文稿，简化工作流程。"
---
## **概述**

Aspose.Slides 允许您通过克隆幻灯片的方式将一个演示文稿的幻灯片合并到另一个演示文稿中。本文介绍了如何合并整个演示文稿或选定的幻灯片、在合并过程中使用母版或特定布局、处理不同幻灯片尺寸的演示文稿，以及将合并的幻灯片添加到演示文稿的章节中。还涵盖了与合并内容相关的实用说明，包括演讲者备注、批注、受密码保护的源文件以及线程使用等。

{{% alert title="Info" color="info" %}}
大多数演示文稿程序（PowerPoint 或 OpenOffice）都没有允许用户以这种方式合并演示文稿的功能。
[**Aspose.Slides for C++**](https://products.aspose.com/slides/zh/cpp/) , however, allows you merge to presentations in different ways. You get to merge presentations with all their shapes, styles, texts, formatting, comments, animations, etc. without having to worry about loss of quality or data.
**See also**
[Clone Slides](https://docs.aspose.com/slides/zh/cpp/clone-slides/)*.*
{{% /alert %}}

### **可以合并的内容**

使用 Aspose.Slides，您可以合并 

* 整个演示文稿。所有演示文稿中的幻灯片都会汇总到一个演示文稿中
* 指定的幻灯片。选定的幻灯片会汇总到一个演示文稿中
* 同一格式的演示文稿（PPT 到 PPT、PPTX 到 PPTX 等）以及不同格式的演示文稿（PPT 到 PPTX、PPTX 到 ODP 等）相互合并。

{{% alert title="Note" color="warning" %}} 
除了演示文稿，Aspose.Slides 还允许您合并其他文件：

* [Images](https://products.aspose.com/slides/zh/cpp/merger/image-to-image/)，例如 [JPG to JPG](https://products.aspose.com/slides/zh/cpp/merger/jpg-to-jpg/) 或 [PNG to PNG](https://products.aspose.com/slides/zh/cpp/merger/png-to-png/)
* 文档，例如 [PDF to PDF](https://products.aspose.com/slides/zh/cpp/merger/pdf-to-pdf/) 或 [HTML to HTML](https://products.aspose.com/slides/zh/cpp/merger/html-to-html/)
* 以及两种不同的文件，例如 [image to PDF](https://products.aspose.com/slides/zh/cpp/merger/image-to-pdf/) 或 [JPG to PDF](https://products.aspose.com/slides/zh/cpp/merger/jpg-to-pdf/) 或 [TIFF to PDF](https://products.aspose.com/slides/zh/cpp/merger/tiff-to-pdf/)。
{{% /alert %}}

### **合并选项**

您可以应用以下选项来决定是否

* 输出演示文稿中的每一张幻灯片保留唯一的样式
* 为输出演示文稿中的所有幻灯片使用相同的样式。

要合并演示文稿，Aspose.Slides 提供了 [AddClone](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法（来自 [ISlideCollection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_slide_collection) 接口）。`AddClone` 方法有多种实现方式，用于定义演示文稿合并过程的参数。每个 Presentation 对象都有一个 [Slides](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 集合，因此您可以从要合并幻灯片的目标演示文稿中调用 `AddClone` 方法。

`AddClone` 方法返回一个 `ISlide` 对象，它是源幻灯片的克隆。输出演示文稿中的幻灯片仅是源幻灯片的副本。因此，您可以对生成的幻灯片进行更改（例如应用样式、格式选项或布局），而无需担心影响源演示文稿。

## **合并演示文稿**

Aspose.Slides 提供了 [**AddClone (ISlide)**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 方法，允许您在保持幻灯片布局和样式的前提下合并幻灯片（默认参数）。

以下 C++ 代码演示了如何合并演示文稿：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **使用幻灯片母版合并演示文稿**

Aspose.Slides 提供了 [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) 方法，允许您在合并幻灯片时应用幻灯片母版模板。这样，如果需要，您可以更改输出演示文稿中幻灯片的样式。

以下 C++ 代码演示了上述操作：

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
幻灯片母版的布局会自动确定。如果无法确定合适的布局，并且将 `AddClone` 方法的 `allowCloneMissingLayout` 布尔参数设置为 true，则使用源幻灯片的布局。否则，将抛出 [PptxEditException](https://reference.aspose.com/slides/zh/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)。
{{% /alert %}}

如果希望输出演示文稿中的幻灯片使用不同的幻灯片布局，请在合并时改用 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) 方法。

## **从演示文稿中合并特定幻灯片**

从多个演示文稿中合并特定幻灯片对于创建自定义幻灯片套件非常有用。Aspose.Slides C++ 允许您仅选择并导入所需的幻灯片。API 能够保留原始幻灯片的格式、布局和设计。

下面的 C++ 代码创建了一个新演示文稿，从另外两个演示文稿中添加标题幻灯片，并将结果保存为文件：

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 在上面的代码中声明。
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

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

以下 C++ 代码展示了如何在合并演示文稿时为幻灯片应用您偏好的布局，以生成一个输出演示文稿：

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **合并不同幻灯片尺寸的演示文稿**

{{% alert title="Note" color="warning" %}} 
无法合并尺寸不同的演示文稿。 
{{% /alert %}}

要合并尺寸不同的两个演示文稿，必须先将其中一个演示文稿的尺寸调整为与另一演示文稿相匹配。

以下示例代码演示了上述操作：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

以下 C++ 代码展示了如何将特定幻灯片合并到演示文稿的某个章节：

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

该幻灯片会添加到章节的末尾。

{{% alert title="Tip" color="info" %}}
Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/zh/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/zh/collage/jpg) 或 PNG 到 PNG 的图像，创建 [photo grids](https://products.aspose.app/slides/zh/collage/photo-grid) 等。
{{% /alert %}}

## **常见问题解答**

### 在合并过程中是否保留演讲者备注？

是的。克隆幻灯片时，Aspose.Slides 会将所有幻灯片元素（包括备注、格式和动画）一起复制。

### 批注及其作者会被转移吗？

批注作为幻灯片内容的一部分，会随幻灯片一起复制。批注作者标签会作为批注对象保留在生成的演示文稿中。

### 如果源演示文稿受密码保护怎么办？

必须通过 [打开带密码的演示文稿](/slides/zh/cpp/password-protected-presentation/) 并使用 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/) 加载；加载后，这些幻灯片可以安全地克隆到未受保护的目标文件（或同样受保护的文件）中。

### 合并操作的线程安全性如何？

请勿在 [多个线程](/slides/zh/cpp/multithreading/) 中使用同一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例。推荐的原则是“一个文档—一个线程”；不同的文件可以在各自的线程中并行处理。