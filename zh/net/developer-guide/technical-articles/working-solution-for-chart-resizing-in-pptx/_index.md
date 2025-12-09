---
title: PPTX 中图表缩放的可行解决方案
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
description: "使用 Aspose.Slides for .NET 嵌入 Excel OLE 对象时，修复 PPTX 中意外的图表缩放问题。了解两种保持尺寸一致的代码方法。"
---

## **背景**

已观察到，通过 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后会被重新缩放到未指定的比例。此行为导致图表在激活前后呈现出明显的视觉差异。Aspose 团队对该问题进行了深入调查并找到了方案。本文描述了问题的原因以及相应的解决方法。

在[previous article](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用 Aspose.Cells for .NET 创建 Excel 图表并通过 Aspose.Slides for .NET 将其嵌入 PowerPoint 演示文稿。为了解决[object preview issue](/slides/zh/net/object-preview-issue-when-adding-oleobjectframe/) ，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，双击显示图表图像的 OLE 对象框会激活 Excel 图表。最终用户可以在底层 Excel 工作簿中进行任意修改，然后点击激活的工作簿之外的区域返回相应的幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，重新缩放的比例取决于 OLE 对象框和嵌入的 Excel 工作簿的原始大小。

## **缩放原因**

由于 Excel 工作簿拥有自己的窗口大小，它在首次激活时会尝试保留原始尺寸。而 OLE 对象框则有其自身的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸并在嵌入过程中保持正确的比例。根据 Excel 窗口尺寸与 OLE 对象框的尺寸或位置之间的差异，便会发生重新缩放。

## **可行方案**

使用 Aspose.Slides for .NET 创建 PowerPoint 演示文稿时有两种可能的场景。

**Scenario 1:** 基于现有模板创建演示文稿。

**Scenario 2:** 从头开始创建演示文稿。

我们在此提供的解决方案适用于这两种场景。所有解决方案的基本原则相同：**嵌入的 OLE 对象的窗口大小应与 PowerPoint 幻灯片中的 OLE 对象框匹配**。下面将讨论实现该目标的两种方法。

## **第一种方法**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿的窗口大小，使其匹配 PowerPoint 幻灯片中 OLE 对象框的尺寸。

**Scenario 1** 

假设我们已经定义了一个模板并希望基于该模板创建演示文稿。假设模板中索引为 2 的形状是我们想要放置包含嵌入式 Excel 工作簿的 OLE 框的位置。在此场景下，OLE 对象框的大小是预定义的——它与模板中索引 2 的形状大小相匹配。我们需要做的就是将工作簿的窗口大小设置为该形状的大小。下面的代码片段实现了此目的：
```cs
// 定义带窗口的图表大小。 
chart.SizeWithWindow = true;

// 设置工作簿窗口宽度（单位为英寸），除以 72 因为 PowerPoint 使用每英寸 72 像素。
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// 设置工作簿窗口高度（单位为英寸）。
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// 将工作簿保存到内存流中。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建一个包含嵌入式 Excel 数据的 OLE 对象框。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Scenario 2** 

假设我们想要从头创建演示文稿，并在其中包含任意大小的 OLE 对象框以及嵌入的 Excel 工作簿。以下代码片段在幻灯片上创建一个高 4 英寸、宽 9.5 英寸、左上角坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象框。随后将 Excel 工作簿窗口设置为相同的尺寸——高 4 英寸、宽 9.5 英寸。
```cs
// 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 72)

// 我们期望的宽度。
int desiredWidth = 684;//9.5 英寸 (9.5 * 72)

// 定义带窗口的图表大小。
chart.SizeWithWindow = true;

// 设置工作簿窗口宽度（单位为英寸）。
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// 设置工作簿窗口高度（单位为英寸）。
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// 将工作簿保存到内存流。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建包含嵌入式 Excel 数据的 OLE 对象框。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **第二种方法**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿中图表的大小，以匹配 PowerPoint 幻灯片中 OLE 对象框的尺寸。当图表大小预先已知且不会更改时，此方法非常有用。

**Scenario 1** 

假设我们已经定义了一个模板并希望基于该模板创建演示文稿。假设模板中索引为 2 的形状是我们打算放置包含嵌入式 Excel 工作簿的 OLE 框的位置。在此场景下，OLE 框的大小是预定义的——与模板中索引 2 的形状大小相匹配。我们只需将工作簿中图表的大小设置为该形状的大小。下面的代码片段实现了此目的：
```cs
// 定义不带窗口的图表大小。 
chart.SizeWithWindow = false;

// 以像素设置图表宽度（乘以 96，因为 Excel 使用每英寸 96 像素）。    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// 以像素设置图表高度。
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// 定义图表打印尺寸。
chart.PrintSize = PrintSizeType.Custom;

// 将工作簿保存到内存流。
MemoryStream workbookStream = workbook.SaveToStream();

// 创建包含嵌入式 Excel 数据的 OLE 对象框。
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**Scenario 2** 

假设我们从头创建演示文稿，并在其中包含任意大小的 OLE 对象框以及嵌入的 Excel 工作簿。以下代码片段在幻灯片上创建一个高 4 英寸、宽 9.5 英寸、左上角坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象框。同时将相应的图表大小设置为相同的尺寸：高 4 英寸、宽 9.5 英寸。
```cs
 // 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 576)

// 我们期望的宽度。
int desiredWidth = 684; // 9.5 英寸 (9.5 * 576)

// 定义不带窗口的图表大小。 
chart.SizeWithWindow = false;

// 以像素设置图表宽度。   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// 以像素设置图表高度。    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **结论**

解决图表重新缩放问题有两种方法。选择哪种方法取决于需求和使用场景。无论演示文稿是基于模板创建还是从头开始创建，两种方法的实现方式相同。此外，在本方案中对 OLE 对象框的尺寸没有任何限制。

## FAQ

**Q: 为什么我的嵌入式 Excel 图表在 PowerPoint 中激活后会改变大小？**  
这是因为 Excel 在首次激活时尝试恢复原始窗口尺寸，而 PowerPoint 中的 OLE 对象框有其自身的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，这可能导致重新缩放。

**Q: 是否可以完全避免此重新缩放问题？**  
可以。通过在嵌入之前使 Excel 工作簿的窗口尺寸或图表尺寸与 OLE 对象框的尺寸匹配，即可保持图表尺寸一致。

**Q: 我应该采用哪种方法，是设置工作簿窗口大小还是设置图表大小？**  
如果希望保持工作簿的纵横比并可能以后再调整大小，请使用 **Approach 1 (window size)**。  
如果图表尺寸固定且嵌入后不会改变，请使用 **Approach 2 (chart size)**。

**Q: 这些方法是否适用于基于模板的演示文稿和新建的演示文稿？**  
是的。两种方法在基于模板创建和从头创建的演示文稿中均可使用。

**Q: OLE 对象框的尺寸是否有限制？**  
没有限制。只要它能够适当地缩放到工作簿或图表的尺寸即可。

**Q: 我可以在其他电子表格程序创建的图表上使用这些方法吗？**  
示例针对使用 Aspose.Cells 创建的 Excel 图表，但只要其他 OLE 兼容的电子表格程序支持类似的尺寸设置，原理同样适用。

## **相关章节**

- [在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [使用 PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)