---
title: PPTX 中图表缩放的可行解决方案
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
description: "使用 Aspose.Slides for Java 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表缩放。学习两种保持尺寸一致的方法并附带代码示例。"
---
## **背景**

已观察到，通过 Aspose 组件将 Excel 图表作为 OLE 对象嵌入 PowerPoint 演示文稿后，首次激活后会被重新缩放到未指定的比例。此行为导致图表在激活前后的视觉效果出现明显差异。Aspose 团队对该问题进行了深入调查并找到了解决方案。本文介绍了问题产生的原因以及相应的修复方法。

在[上一篇文章](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们说明了如何使用 Aspose.Cells for Java 创建 Excel 图表并通过 Aspose.Slides for Java 将其嵌入 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，双击显示图表图像的 OLE 对象框会激活 Excel 图表。最终用户可以在底层 Excel 工作簿中进行任意修改，然后点击激活工作簿之外的区域返回对应幻灯片。用户返回幻灯片时 OLE 对象框的大小会发生变化，缩放比例取决于 OLE 对象框和嵌入的 Excel 工作簿原始大小的不同。

## **缩放原因**

由于 Excel 工作簿有自己的窗口大小，它会在首次激活时尝试保留原始大小。而 OLE 对象框也有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸并在嵌入过程中保持正确比例。Excel 窗口大小与 OLE 对象框的大小或位置存在差异时，就会发生缩放。

## **可行方案**

使用 Aspose.Slides for Java 创建 PowerPoint 演示文稿有两种可能的场景。

**场景 1：** 基于现有模板创建演示文稿。

**场景 2：** 从头创建演示文稿。

本文提供的解决方案适用于两种场景。所有方案的核心相同：**嵌入的 OLE 对象窗口大小应与 PowerPoint 幻灯片中的 OLE 对象框大小匹配**。下面将讨论两种实现方式。

## **方法一**

本方法演示如何设置嵌入的 Excel 工作簿窗口大小，使其与 PowerPoint 幻灯片中 OLE 对象框的大小保持一致。

**场景 1**

假设我们已定义模板并希望基于该模板创建演示文稿。模板中索引为 2 的形状用于放置包含嵌入式 Excel 工作簿的 OLE 框。在此场景下，OLE 对象框的大小是预定义的——与模板中索引为 2 的形状大小相同。我们只需将工作簿的窗口大小设置为该形状的大小。以下代码片段实现此功能：

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 将工作簿的窗口宽度设置为英寸（除以 72，因为 PowerPoint 每英寸使用 72 点）。
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// 将工作簿的窗口高度设置为英寸。
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 创建包含嵌入式 Excel 数据的 OLE 对象框。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**场景 2**

假设我们要从头创建演示文稿，并在其中包含任意大小的 OLE 对象框和嵌入的 Excel 工作簿。在下面的代码片段中，我们在幻灯片上创建一个高 4 英寸、宽 9.5 英寸、左上角坐标为 x=0.5 英寸、y=1 英寸的 OLE 对象框，然后将 Excel 工作簿窗口大小设置为相同的尺寸——高 4 英寸、宽 9.5 英寸。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 72)
 
// 我们期望的宽度。
int desiredWidth = 684; // 9.5 英寸 (9.5 * 72)
 
// 使用窗口定义图表大小。
chart.setSizeWithWindow(true);
 
// 设置工作簿窗口宽度（单位为英寸），除以 72 因为 PowerPoint 每英寸使用 72 点。
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// 设置工作簿窗口高度（单位为英寸）。
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 创建包含嵌入式 Excel 数据的 OLE 对象框。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 英寸 (0.5 * 72)
    72,  // y = 1 英寸 (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **方法二**

本方法演示如何设置嵌入的 Excel 工作簿中图表的大小，使其与 PowerPoint 幻灯片中 OLE 对象框的大小相匹配。在图表尺寸已知且不会变化的情况下，此方法非常实用。

**场景 1**

假设我们已定义模板并希望基于该模板创建演示文稿。模板中索引为 2 的形状用于放置包含嵌入式 Excel 工作簿的 OLE 框。在此场景下，OLE 框的大小是预定义的——与模板中索引为 2 的形状大小相同。我们只需将工作簿中图表的大小设置为该形状的大小。以下代码片段实现此功能：

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 在没有窗口的情况下定义图表大小。
chart.setSizeWithWindow(false);
 
// 以像素设置图表宽度（乘以 96，因为 Excel 使用每英寸 96 像素）。
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// 以像素设置图表高度。
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// 定义图表打印尺寸。
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 创建包含嵌入式 Excel 数据的 OLE 对象框。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**场景 2**:

假设我们要从头创建演示文稿，并在其中包含任意大小的 OLE 对象框和嵌入的 Excel 工作簿。在下面的代码片段中，我们在幻灯片上创建一个高 4 英寸、宽 9.5 英寸、左上角坐标为 x=0.5 英寸、y=1 英寸的 OLE 对象框，并将相应的图表大小同样设置为高 4 英寸、宽 9.5 英寸。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// 我们期望的高度。
int desiredHeight = 288; // 4 英寸 (4 * 72)
 
// 我们期望的宽度。
int desiredWidth = 684; // 9.5 英寸 (9.5 * 72)
 
// 在没有窗口的情况下定义图表大小。
chart.setSizeWithWindow(false);
 
// 以像素设置图表宽度（除以 72 得到英寸，乘以 96 因为 Excel 使用每英寸 96 像素）。
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// 以像素设置图表高度。
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// 将工作簿保存到内存流。
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// 创建包含嵌入式 Excel 数据的 OLE 对象框。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 英寸 (0.5 * 72)
    72,  // y = 1 英寸 (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **结论**

解决图表缩放问题有两种方法。选择哪种方法取决于具体需求和使用场景。无论是基于模板创建还是从头创建演示文稿，两种方法的效果相同。此外，该解决方案对 OLE 对象框的大小没有限制。

## **常见问题**

### 为什么嵌入的 Excel 图表在 PowerPoint 中激活后会改变大小？

因为 Excel 在首次激活时尝试恢复原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持宽高比，这可能导致缩放。

### 能否彻底避免此缩放问题？

可以。通过在嵌入前将 Excel 工作簿窗口大小或图表大小设置为与 OLE 对象框大小匹配，可保持图表尺寸一致。

### 应该使用设置工作簿窗口大小还是设置图表大小的方法？

如果希望保持工作簿的宽高比并可能以后进行缩放，请使用**方法一（窗口大小）**。如果图表尺寸固定且嵌入后不会改变，请使用**方法二（图表大小）**。

### 这些方法是否适用于基于模板的演示文稿和新建演示文稿？

是的。两种方法在基于模板创建和从头创建的演示文稿中表现相同。

### OLE 对象框的大小是否有限制？

没有限制。只要 OLE 框的尺寸能够恰当地映射到工作簿或图表大小，即可任意设置。

### 能否将这些方法用于其他电子表格程序创建的图表？

示例针对使用 Aspose.Cells 创建的 Excel 图表，但原理同样适用于其他支持类似尺寸选项的 OLE 兼容电子表格程序。

## **相关章节**

- [在演示文稿中创建 Excel 图表并将其作为 OLE 对象嵌入](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)