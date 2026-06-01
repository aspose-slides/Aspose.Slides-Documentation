---
title: 在 C++ 中从演示文稿进行高级文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/cpp/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们的简明分步指南，节省时间。"
---
## **概览**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问并检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for C++ 高效提取 PPT、PPTX 和 ODP 等各种演示文稿格式文本的完整指南。您将学习如何系统地遍历演示文稿元素，以准确获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for C++ 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/) 类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/getalltextboxes/) 方法。该方法接受一个类型为 [IBaseSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/) 的对象作为参数。执行时，方法会扫描整张幻灯片中的文本，并返回类型为 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 的对象数组，保留所有文本格式。

以下代码片段提取演示文稿第一张幻灯片的全部文本：

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/) 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/getalltextframes/) 静态方法。它接受两个参数：

1. 首先，一个表示 PowerPoint 或 OpenDocument 演示文稿的 [IPresentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/) 对象，文本将从该对象中提取。
2. 其次，一个 `Boolean` 值，指示在扫描演示文稿文本时是否应包括母版幻灯片。

该方法返回类型为 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 的对象数组，包含文本格式信息。下面的代码从演示文稿（包括母版幻灯片）中扫描文本和格式细节。

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **分类快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentationfactory/) 类同样提供了从演示文稿中提取所有文本的方法：

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textextractionarrangingmode/) 枚举参数指示组织文本提取结果的模式，可设置为以下值：
- `Unarranged` - 原始文本，不考虑其在幻灯片上的位置。
- `Arranged` - 文本按幻灯片上的顺序排列。

当速度至关重要时，可使用未排列模式；它比已排列模式更快。

[IPresentationText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationtext/) 表示从演示文稿中提取的原始文本。其 `get_SlidesText()` 方法返回类型为 [ISlideText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidetext/) 的对象数组。每个对象表示对应幻灯片上的文本。类型为 [ISlideText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidetext/) 的对象具有以下方法：

- `get_Text()` - 幻灯片形状中的文本。
- `get_MasterText()` - 与该幻灯片关联的母版幻灯片形状中的文本。
- `get_LayoutText()` - 与该幻灯片关联的版式幻灯片形状中的文本。
- `get_NotesText()` - 幻灯片备注形状中的文本。
- `get_CommentsText()` - 与该幻灯片关联的批注中的文本。

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Aspose.Slides 在进行文本提取时处理大型演示文稿的速度如何？**

Aspose.Slides 经过高性能优化，即使是[大型演示文稿](/slides/zh/cpp/open-presentation/)也能快速处理，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

可以。Aspose.Slides 能从包括表格和图表相关对象在内的多种幻灯片元素中提取文本，从而让您访问并分析常见演示结构中的文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 授权？**

您可以使用 Aspose