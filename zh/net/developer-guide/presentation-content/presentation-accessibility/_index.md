---
title: 管理 .NET 中的演示文稿可访问性
linktitle: 演示文稿可访问性
type: docs
weight: 30
url: /zh/net/presentation-accessibility/
keywords:
- 演示文稿可访问性
- 替代文本
- 替代文本标题
- 替代文本描述
- 标记为装饰性
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自动检查 PPT、PPTX 和 ODP 文件的可访问性——提升屏幕阅读器体验并增强合规性。"
---
## **介绍**

替代文本帮助使用辅助技术的人员理解图像、图表和其他信息形状的含义。本文介绍如何使用 Aspose.Slides for .NET 读取和更新替代文本标题和描述，区分代码中使用的形状名称与可访问性描述，并检查形状是否标记为装饰性。

这些功能支持演示文稿的可访问性，但并不能保证完全可访问。还需检查阅读顺序、颜色对比、文本可读性以及其他可访问性要求。

## **管理替代文本标题和描述**

使用替代文本向看不到图像的人解释图像、图表和其他信息形状的含义。以下属性各有不同用途：

| 属性或内容 | 用途 |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/alternativetexttitle/) | 用于替代描述的简短标题。 |
| [AlternativeText](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/alternativetext/) | 对形状内容或在幻灯片上下文中的目的进行有意义的描述。 |
| [Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/name/) | 形状的名称，代码可以使用它在演示文稿中查找特定形状。 |
| 可见文本 | 幻灯片上显示的内容，例如形状的文本或图表的标题和标签。更新替代文本不会更改此内容。 |

当演示文稿被重新用作模板时，代码可能会在更新之前通过其[Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/name/)查找形状。该名称的用途与替代文本不同，后者说明视觉内容向读者传达了什么。按名称搜索允许作者在不影响代码查找形状的前提下改进或翻译描述。名称可以编辑且不保证唯一，请确保名称与目标形状匹配；参见[识别并查找形状](/slides/zh/net/shape-manipulations/#identify-and-find-shapes)。

以下示例需要 `input.pptx`，其中第一张幻灯片的第一个形状是一张办公入口的图片，该图片不应标记为装饰性。示例读取并打印其当前的替代文本标题和描述，更新两个值，并将演示文稿保存为 `output.pptx`。请根据实际图片及其传达的信息调整文字。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

仅添加替代文本并不能保证演示文稿的可访问性或符合可访问性标准。请审查描述的准确性和相关性，同时检查阅读顺序、颜色对比、可读文本以及其他可访问性要求。信息性视觉不应标记为装饰性；下一节展示如何读取[IsDecorative](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/isdecorative/)。

## **标记为装饰性**

标记为装饰性用于纯粹装饰性的视觉元素，使屏幕阅读器跳过它们，减少噪音并将注意力集中在有意义的内容上。应将其应用于背景、装饰图案和间距占位——绝不用于传递信息的图表、图标或图片。Aspose.Slides 为检测和验证此标志提供了接口，支持自动化的可访问性检查和清理。

![标记为装饰性](mark_as_decorative.png)

以下代码示例展示如何判断形状是否标记为装饰性。

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **常见问题**

**应该在替代文本标题和描述中写些什么？**

使用简短的标题来标识主题，并使用描述来解释视觉在幻灯片上下文中传达的信息。对于图表，应描述相关的趋势或比较，而不是仅仅写“图表”。

**应该使用替代文本来定位模板中的形状吗？**

推荐通过其[Name](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/name/)查找形状，并确认它是预期的形状。替代文本可能被编辑或翻译，这会导致搜索精确描述的代码失效；参见[识别并查找形状](/slides/zh/net/shape-manipulations/)。

**何时应将形状标记为装饰性？**

对不提供任何信息的视觉元素使用装饰性标志，例如装饰性图案。传递意义的图片和图表需要相应的描述，而不是标记为装饰性。

**添加替代文本会使演示文稿完全可访问吗？**

不会。替代文本仅解决可访问性的一部分。还需审查阅读顺序、颜色对比、文本可读性以及其他相关要求，仅设置这些属性并不能确保合规。