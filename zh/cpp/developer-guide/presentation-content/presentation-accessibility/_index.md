---
title: 在 C++ 中管理演示文稿可访问性
linktitle: 演示文稿可访问性
type: docs
weight: 30
url: /zh/cpp/presentation-accessibility/
keywords:
- 演示文稿可访问性
- 替代文本
- 替代文本标题
- 替代文本描述
- 标记为装饰性
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自动化检查 PPT、PPTX 和 ODP 文件的演示文稿可访问性——提升屏幕阅读器体验并增强合规性。"
---
## **简介**

替代文本帮助使用辅助技术的人理解图像、图表和其他信息形状的含义。本文阐述了如何使用 Aspose.Slides for C++ 读取和更新替代文本标题和描述，区分代码中使用的形状名称与可访问性描述，并检查形状是否标记为装饰性。

这些功能有助于演示文稿的可访问性，但并不能保证完全可访问。还需审查阅读顺序、颜色对比度、文本可读性及其他可访问性要求。

## **管理替代文本标题和描述**

使用替代文本向看不到图像的人解释图像、图表和其他信息形状的含义。以下属性用于不同的目的：

| 属性或内容 | 目的 |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_alternativetexttitle/) | 替代描述的简短标题。 |
| [AlternativeText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_alternativetext/) | 在幻灯片上下文中，对形状内容或目的的有意义描述。 |
| [Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_name/) | 形状的名称，代码可使用它在演示文稿中查找特定形状。 |
| 可见文本 | 幻灯片上显示的内容，例如形状的文本或图表的标题和标签。更新替代文本不会更改此内容。 |

当演示文稿被用作模板时，代码可能在更新之前通过其 [Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_name/) 找到形状。该名称的用途与替代文本不同，后者解释视觉对象向读者传达了什么。通过名称搜索可让作者改进或翻译描述，而不影响代码查找形状的方式。名称可以被编辑且不一定唯一，因此请检查名称是否匹配目标形状；参见 [Identify and Find Shapes](/slides/zh/cpp/shape-manipulations/#identify-and-find-shapes)。

以下示例需要位于第一张幻灯片第一形状的办公室入口图片的 `input.pptx`。该图像不应标记为装饰性。示例读取并打印其当前的替代文本标题和描述，更新这两个值，并将演示文稿保存为 `output.pptx`。请根据实际图像及其传递的信息调整措辞。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

仅添加替代文本并不能保证演示文稿的可访问性或符合可访问性标准。请审查描述的准确性和相关性，并同时检查阅读顺序、颜色对比度、可读文本及其他可访问性要求。信息性视觉对象不应标记为装饰性；下一节展示如何读取 [IsDecorative](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_isdecorative/)。

## **标记为装饰性**

“标记为装饰性”用于纯粹的装饰性视觉对象，使屏幕阅读器跳过它们，减少噪音并将关注点保持在有意义的内容上。将其应用于背景、装饰图案和间隔元素——绝不要用于传递信息的图表、图标或图像。Aspose.Slides 将此标志公开用于检测和验证，从而实现自动化的可访问性检查和清理。

![Mark as Decorative](mark_as_decorative.png)

以下代码示例展示了如何确定形状是否标记为装饰性。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **常见问题**

**在替代文本标题和描述中应该写什么？**

使用简短的标题来标识主题，并使用描述来阐明视觉对象在幻灯片上下文中传达的信息。对于图表，应描述相关的趋势或比较，而不是仅仅写“图表”。

**在模板中应该使用替代文本来定位形状吗？**

建议通过其 [Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_name/) 查找形状并确认它是预期的形状。替代文本可能会被编辑或翻译，这可能导致搜索精确描述的代码失效；参见 [Identify and Find Shapes](/slides/zh/cpp/shape-manipulations/)。

**何时应将形状标记为装饰性？**

对不提供信息的视觉对象使用装饰性标志，例如装饰性图案。传递意义的图像和图表则需要相应的描述。

**添加替代文本会使演示文稿完全可访问吗？**

不会。替代文本仅解决可访问性的一部分。还需审查阅读顺序、颜色对比度、文本可读性及其他相关要求，仅设置这些属性并不能确保符合标准。