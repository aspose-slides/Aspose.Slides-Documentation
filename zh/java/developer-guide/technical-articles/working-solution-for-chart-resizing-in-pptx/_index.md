---
title: PPTX 图表缩放的工作解决方案
type: docs
weight: 40
url: /zh/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表缩放
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 嵌入的 Excel OLE 对象时，解决 PPTX 中意外的图表缩放问题。了解两种代码方法以保持尺寸一致。"
---

## **背景**

已观察到通过 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后会以未指定的比例进行缩放。此行为导致图表在激活前后呈现出明显的视觉差异。Aspose 团队对该问题进行了详细调查并找到了方案。本文描述了问题的原因及相应的修复方法。

在[前一篇文章](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们讲解了如何使用 Aspose.Cells for Java 创建 Excel 图表并将其嵌入 PowerPoint 演示文稿（使用 Aspose.Slides for Java）。为了解决[对象预览问题](/slides/zh/java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象帧。在输出的演示文稿中，双击显示图表图像的 OLE 对象帧时，Excel 图表被激活。最终用户可以在底层 Excel 工作簿中进行任意更改，然后单击激活工作簿之外的区域返回相应的幻灯片。用户返回幻灯片时，OLE 对象帧的大小会发生变化，缩放因子取决于 OLE 对象帧和嵌入的 Excel 工作簿的原始尺寸。

## **缩放原因**

由于 Excel 工作簿本身具有窗口大小，它会在首次激活时尝试保留原始尺寸。而 OLE 对象帧也有自己的大小。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸并在嵌入过程中保持正确的比例。Excel 窗口大小与 OLE 对象帧的大小或位置之间的差异会导致缩放。

## **可行解决方案**

使用 Aspose.Slides for Java 创建 PowerPoint 演示文稿有两种可能的场景。

**场景 1：** 基于现有模板创建演示文稿。

**场景 2：** 从零创建演示文稿。

本文提供的解决方案适用于两种场景。所有解决方案的核心相同：**嵌入的 OLE 对象窗口大小应与 PowerPoint 幻灯片中的 OLE 对象帧大小匹配**。下面将讨论两种实现方式。

## **第一种方法**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿窗口大小，使其匹配 PowerPoint 幻灯片中 OLE 对象帧的大小。

**场景 1**

假设我们已经定义了一个模板，并希望基于该模板创建演示文稿。模板中索引为 2 的形状位置将放置包含嵌入式 Excel 工作簿的 OLE 帧。在此场景下，OLE 对象帧的大小是预定义的——它与模板中索引为 2 的形状大小相同。我们只需将工作簿的窗口大小设置为该形状的大小即可。下面的代码片段实现了此目的：
```java
// 将工作簿的窗口宽度设置为英寸（除以 576，因为 PowerPoint 使用每英寸 576 像素）。
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// 将工作簿的窗口高度设置为英寸。
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 使用嵌入的 Excel 数据创建 OLE 对象框架。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**场景 2**

假设我们要从零创建演示文稿，并在其中加入任意大小的 OLE 对象帧以及嵌入的 Excel 工作簿。以下代码片段在幻灯片上创建一个宽 9.5 英寸、高 4 英寸、左上角坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象帧。随后将 Excel 工作簿窗口大小设置为相同的尺寸——高 4 英寸、宽 9.5 英寸。
```java
// 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 72)
 
// 我们期望的宽度。
int desiredWidth = 684; // 9.5 英寸 (9.5 * 72)
 
// 使用窗口定义图表大小。
chart.setSizeWithWindow(true);
 
// 将工作簿的窗口宽度设置为英寸（除以 576，因为 PowerPoint 使用每英寸 576 像素）。
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// 将工作簿的窗口高度设置为英寸。
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 使用嵌入的 Excel 数据创建 OLE 对象框架。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **第二种方法**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿中图表的尺寸，使其匹配 PowerPoint 幻灯片中 OLE 对象帧的尺寸。该方法适用于事先已知图表尺寸且不再变化的情况。

**场景 1**

假设我们已经定义了一个模板，并希望基于该模板创建演示文稿。模板中索引为 2 的形状位置将放置包含嵌入式 Excel 工作簿的 OLE 帧。在此场景下，OLE 帧的大小是预定义的——与模板中索引为 2 的形状大小相同。我们只需将工作簿中图表的尺寸设为该形状的大小即可。下面的代码片段实现了此目的：
```java
// 定义不使用窗口的图表大小。
chart.setSizeWithWindow(false);
 
// 设置图表宽度（单位：像素），乘以 96 因为 Excel 每英寸使用 96 像素。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// 设置图表高度（单位：像素）。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// 定义图表打印大小。
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 使用嵌入的 Excel 数据创建 OLE 对象框架。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**场景 2**:

假设我们要从零创建演示文稿，并在其中加入任意大小的 OLE 对象帧以及嵌入的 Excel 工作簿。以下代码片段在幻灯片上创建一个宽 9.5 英寸、高 4 英寸、左上角坐标为 x = 0.5 英寸、y = 1 英寸的 OLE 对象帧，并将相应的图表尺寸设置为相同的尺寸：高 4 英寸、宽 9.5 英寸。
```java
// 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 72)
 
// 我们期望的宽度。
int desiredWidth = 684; // 9.5 英寸 (9.5 * 72)
 
// 定义不使用窗口的图表大小。
chart.setSizeWithWindow(false);
 
// 设置图表宽度（单位：像素），乘以 96 因为 Excel 每英寸使用 96 像素。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// 设置图表高度（单位：像素）。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 使用嵌入的 Excel 数据创建 OLE 对象框架。
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **结论**

修复图表缩放问题有两种方法。选择哪种方法取决于需求和使用场景。无论演示文稿是基于模板创建还是从零创建，两种方法的工作原理相同。此外，此方案对 OLE 对象帧的大小没有限制。

## **常见问答**

**为何我的嵌入 Excel 图表在 PowerPoint 中激活后会改变大小？**

这是因为 Excel 在首次激活时尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象帧具有自己的尺寸。PowerPoint 与 Excel 协商尺寸以保持宽高比，这会导致缩放。

**是否可以完全阻止此缩放问题？**

可以。通过在嵌入前将 Excel 工作簿窗口大小或图表大小匹配到 OLE 对象帧的尺寸，即可保持图表尺寸一致。

**应该使用哪种方法：设置工作簿窗口大小还是设置图表大小？**

如果希望保持工作簿的宽高比并可能在以后调整大小，请使用**方法 1（窗口大小）**。  
如果图表尺寸固定且嵌入后不再变化，请使用**方法 2（图表大小）**。

**这些方法在基于模板的演示文稿和新建演示文稿中都有效吗？**

是的。两种方法对基于模板创建和从零创建的演示文稿均适用。

**OLE 对象帧的尺寸有限制吗？**

没有。只要尺寸能够相应地映射到工作簿或图表的尺寸，就可以将 OLE 帧设置为任意大小。

**这些方法能用于其他电子表格程序创建的图表吗？**

示例代码针对使用 Aspose.Cells 创建的 Excel 图表，但原理同样适用于其他支持 OLE 的电子表格程序，只要它们提供类似的尺寸设置选项。

## **相关章节**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)