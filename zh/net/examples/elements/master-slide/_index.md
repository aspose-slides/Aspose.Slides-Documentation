---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/net/examples/elements/master-slide/
keywords:
- 母版幻灯片
- 添加母版幻灯片
- 访问母版幻灯片
- 删除母版幻灯片
- 未使用的母版幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET 的母版幻灯片示例：在 PPT、PPTX 和 ODP 中创建、编辑和设置母版、占位符和主题，提供清晰的 C# 代码。"
---
母版幻灯片位于 PowerPoint 幻灯片继承层次结构的顶层。**母版幻灯片** 定义公共设计元素，如背景、徽标和文本格式。**布局幻灯片** 继承自母版幻灯片，**普通幻灯片** 继承自布局幻灯片。

本文演示如何使用 Aspose.Slides for .NET 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

此示例展示了如何通过克隆默认母版来创建新的母版幻灯片。随后通过布局继承向所有幻灯片添加公司名称横幅。

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // 克隆默认母版幻灯片。
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // 向母版幻灯片顶部添加公司名称横幅。
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // 将新母版幻灯片分配给布局幻灯片。
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // 将布局幻灯片分配给演示文稿中的第一张幻灯片。
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **注意 1:** 母版幻灯片提供了一种在所有幻灯片上应用一致品牌或共享设计元素的方式。对母版所做的任何更改都会自动反映在依赖的布局幻灯片和普通幻灯片上。

> 💡 **注意 2:** 添加到母版幻灯片的任何形状或格式都会被布局幻灯片继承，进而被所有使用该布局的普通幻灯片继承。下图展示了在母版幻灯片上添加的文本框如何自动呈现在最终幻灯片上。

![母版继承示例](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用 `Presentation.Masters` 集合访问母版幻灯片。以下示例展示了如何检索和使用它们：

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // 访问第一个母版幻灯片。
    var firstMasterSlide = presentation.Masters[0];

    // 更改背景类型。
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **删除母版幻灯片**

母版幻灯片可以通过索引或引用的方式删除。

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // 通过索引删除母版幻灯片。
    presentation.Masters.RemoveAt(0);

    // 通过引用删除母版幻灯片。
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **删除未使用的母版幻灯片**

某些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // 删除所有未使用的母版幻灯片（即使标记为 Preserve）。
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```