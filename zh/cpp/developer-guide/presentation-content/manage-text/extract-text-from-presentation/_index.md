---
title: C++ 中的高级演示文稿文本提取
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
description: "使用 Aspose.Slides for C++ 快速从 PowerPoint 和 OpenDocument 演示文稿中提取文本。按照我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是处理幻灯片内容的开发人员常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），获取和检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了使用 Aspose.Slides for C++ 高效提取 PPT、PPTX 和 ODP 等多种演示文稿格式文本的完整指南。您将学习如何系统地遍历演示文稿元素，从而准确获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for C++ 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/) 命名空间，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/) 类。该类提供了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/getalltextboxes/) 方法。此方法接受一个类型为 [IBaseSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/) 的对象作为参数。执行时，该方法会扫描整张幻灯片的文本，并返回类型为 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 的对象数组，保留所有文本格式。

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

要扫描整个演示文稿的文本，可使用由 [SlideUtil](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/) 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/getalltextframes/)