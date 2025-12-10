---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/net/examples/elements/master-slide/
keywords:
- 母版幻灯片示例
- 添加母版幻灯片
- 访问母版幻灯片
- 删除母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 和 Aspose.Slides 管理母版幻灯片：创建、编辑、克隆并格式化主题、背景和占位符，以统一 PowerPoint 和 OpenDocument 中的幻灯片。"
---

母版幻灯片构成 PowerPoint 幻灯片继承层次结构的顶层。**母版幻灯片** 定义背景、标志和文本格式等通用设计元素。**布局幻灯片** 继承自母版幻灯片，而 **普通幻灯片** 则继承自布局幻灯片。

本文演示如何使用 Aspose.Slides for .NET 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

此示例展示如何通过克隆默认母版来创建新的母版幻灯片。随后通过布局继承向所有幻灯片添加公司名称横幅。

```csharp
static void Add_Master_Slide()
{
    using var pres = new Presentation();

    // Clone the default master slide
    var defaultMasterSlide = pres.Masters[0];
    var newMaster = pres.Masters.AddClone(defaultMasterSlide);

    // Add a banner with company name to the top of the master slide
    var textBox = newMaster.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Assign the new master slide to a layout slide
    var layoutSlide = pres.LayoutSlides[0];
    layoutSlide.MasterSlide = newMaster;

    // Assign the layout slide to the first slide in the presentation
    pres.Slides[0].LayoutSlide = layoutSlide;
}
````

> 💡 **提示 1:** 母版幻灯片提供了一种在所有幻灯片上应用统一品牌或共享设计元素的方式。对母版所做的任何更改都会自动反映在依赖的布局幻灯片和普通幻灯片上。

> 💡 **提示 2:** 添加到母版幻灯片的任何形状或格式都会被布局幻灯片继承，进而被使用这些布局的所有普通幻灯片继承。

> 下图展示了在母版幻灯片上添加的文本框如何自动呈现在最终幻灯片上。

![Master Inheritance Example](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用 `Presentation.Masters` 集合访问母版幻灯片。以下示例展示如何检索并使用它们：

```csharp
static void Access_Master_Slide()
{
    using var pres = new Presentation();

    // Access the first master slide
    var firstMasterSlide = pres.Masters[0];

    // Change the background type
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **删除母版幻灯片**

可以通过索引或引用来删除母版幻灯片。

```csharp
static void Remove_Master_Slide()
{
    using var pres = new Presentation();

    // Remove by index
    pres.Masters.RemoveAt(0);

    // Or remove by reference
    var firstMasterSlide = pres.Masters[0];
    pres.Masters.Remove(firstMasterSlide);
}
```

## **删除未使用的母版幻灯片**

有些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```csharp
static void RemoveUnused_Master_Slide()
{
    using var pres = new Presentation();

    // Remove all unused master slides (even those marked as Preserve)
    pres.Masters.RemoveUnused(ignorePreserveField: true);
}
```

> ⚙️ **提示:** 使用 `RemoveUnused(true)` 可清理未使用的母版幻灯片并最小化演示文稿大小。