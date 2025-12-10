---
title: 在 PPTX 中图表缩放的可行方案
type: docs
weight: 60
url: /zh/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表缩放
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表缩放。了解两种代码方法以保持尺寸一致。"
---

## **背景**

已观察到通过 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在第一次激活后会被调整为未指定的比例。此行为导致图表在激活前后的视觉呈现出现明显差异。Aspose 团队已详细调查此问题并找到了解决方案。本文说明问题的原因以及相应的修复方法。

在[上一篇文章](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用 Aspose.Cells for .NET 创建 Excel 图表并使用 Aspose.Slides for .NET 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框架。在输出的演示文稿中，双击显示图表图像的 OLE 对象框架即可激活 Excel 图表。最终用户可以在底层 Excel 工作簿中进行任意更改，然后点击激活工作簿之外的区域返回相应幻灯片。用户返回幻灯片时 OLE 对象框架的大小会发生变化，且缩放因子取决于 OLE 对象框架和嵌入的 Excel 工作簿的原始尺寸。

## **缩放原因**

因为 Excel 工作簿有自己的窗口大小，它会尝试在第一次激活时保留原始尺寸。而 OLE 对象框架也有自己的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 和 PowerPoint 会协商尺寸并在嵌入过程中保持正确的比例。Excel 窗口尺寸与 OLE 对象框架的尺寸或位置之间的差异会导致缩放。

## **可行方案**

使用 Aspose.Slides for .NET 创建 PowerPoint 演示文稿有两种可能的情景。

**情景 1：** 基于现有模板创建演示文稿。

**情景 2：** 从头开始创建演示文稿。

我们在此提供的解决方案适用于两种情景。所有方案的核心相同：**嵌入的 OLE 对象窗口尺寸应与 PowerPoint 幻灯片中的 OLE 对象框架匹配**。下面将讨论两种实现方式。

## **第一种方法**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿窗口尺寸，使其与 PowerPoint 幻灯片中 OLE 对象框架的尺寸一致。

**情景 1**

假设我们已定义模板并希望基于该模板创建演示文稿。模板中索引为 2 的形状将放置包含嵌入 Excel 工作簿的 OLE 框。在此情景下，OLE 对象框架的尺寸是预定义的——与模板中索引为 2 的形状尺寸相同。我们只需将工作簿窗口尺寸设为该形状的尺寸。以下代码片段实现此目的：
```cs
// 使用窗口定义图表尺寸。 
chart.SizeWithWindow = true;

// 将工作簿的窗口宽度设置为英寸（除以 72，因为 PowerPoint 每英寸使用 72 像素）。
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// 将工作簿的窗口高度设置为英寸。
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// 将工作簿保存到内存流。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建包含嵌入式 Excel 数据的 OLE 对象框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**情景 2**

假设我们想从头创建演示文稿，并在其中加入任意尺寸的 OLE 对象框架以及嵌入的 Excel 工作簿。在以下代码片段中，我们在幻灯片上以 x = 0.5 英寸、y = 1 英寸的位置创建一个高 4 英寸、宽 9.5 英寸的 OLE 对象框架。随后将 Excel 工作簿窗口设为相同尺寸——高 4 英寸、宽 9.5 英寸。
```cs
// 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 72)

// 我们期望的宽度。
int desiredWidth = 684;//9.5 英寸 (9.5 * 72)

// 使用窗口定义图表大小。
chart.SizeWithWindow = true;

// 设置工作簿窗口宽度（单位：英寸）。
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// 设置工作簿窗口高度（单位：英寸）。
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// 将工作簿保存到内存流。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建包含嵌入 Excel 数据的 OLE 对象框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **第二种方法**

在此方法中，我们将学习如何将嵌入 Excel 工作簿中图表的尺寸设置为与 PowerPoint 幻灯片中 OLE 对象框架的尺寸相匹配。该方法适用于预先已知图表尺寸且不会变化的情况。

**情景 1**

假设我们已定义模板并希望基于该模板创建演示文稿。模板中索引为 2 的形状将放置包含嵌入 Excel 工作簿的 OLE 框。在此情景下，OLE 框的尺寸是预定义的——与模板中索引为 2 的形状尺寸相同。我们只需将工作簿中图表的尺寸设为该形状的尺寸。以下代码片段实现此目的：
```cs
// 定义不带窗口的图表尺寸。 
chart.SizeWithWindow = false;

// 在像素中设置图表宽度（乘以 96，因为 Excel 每英寸使用 96 像素）。    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// 设置图表高度（像素）。
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// 定义图表的打印尺寸。
chart.PrintSize = PrintSizeType.Custom;

// 将工作簿保存到内存流。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建包含嵌入的 Excel 数据的 OLE 对象框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**情景 2**

假设我们想从头创建演示文稿，并在其中加入任意尺寸的 OLE 对象框架以及嵌入的 Excel 工作簿。在以下代码片段中，我们在幻灯片上以 x = 0.5 英寸、y = 1 英寸的位置创建一个高 4 英寸、宽 9.5 英寸的 OLE 对象框架。同时将对应的图表尺寸设为相同：高 4 英寸、宽 9.5 英寸。
```cs
 // 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 576)

// 我们期望的宽度。
int desiredWidth = 684; // 9.5 英寸 (9.5 * 576)

// 定义不带窗口的图表尺寸。 
chart.SizeWithWindow = false;

// 设置图表宽度（像素）。   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// 设置图表高度（像素）。    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// 将工作簿保存到内存流。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建包含嵌入 Excel 数据的 OLE 对象框架。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **结论**

解决图表缩放问题有两种方法。选择哪种方法取决于需求和使用场景。无论是基于模板还是从头创建，这两种方法的工作方式相同。此外，此解决方案对 OLE 对象框架的尺寸没有限制。

## **常见问答**

**为什么我的嵌入 Excel 图表在 PowerPoint 中激活后会改变尺寸？**  
这是因为 Excel 在首次激活时尝试恢复原始窗口尺寸，而 PowerPoint 中的 OLE 对象框架有其自身的尺寸。PowerPoint 与 Excel 会协商尺寸以保持宽高比，这可能导致缩放。

**是否可以完全防止此缩放问题？**  
可以。通过在嵌入前将 Excel 工作簿窗口尺寸或图表尺寸匹配到 OLE 对象框架尺寸，就能保持图表尺寸一致。

**应选择设置工作簿窗口尺寸还是设置图表尺寸？**  
如果希望保持工作簿的宽高比并可能以后进行缩放，请使用**方法 1（窗口尺寸）**。  
如果图表尺寸固定且嵌入后不会改变，请使用**方法 2（图表尺寸）**。

**这些方法在基于模板的演示文稿和全新演示文稿中都有效吗？**  
是的。两种方法在基于模板创建的演示文稿和从头创建的演示文稿中表现相同。

**OLE 对象框架的尺寸是否有限制？**  
没有。只要与工作簿或图表的尺寸相匹配，OLE 框可以设为任意大小。

**能否将这些方法用于其他电子表格程序创建的图表？**  
示例针对使用 Aspose.Cells 创建的 Excel 图表，但只要其他 OLE 兼容的电子表格程序支持类似的尺寸选项，原则同样适用。

## **相关章节**

- [在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [使用 PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)