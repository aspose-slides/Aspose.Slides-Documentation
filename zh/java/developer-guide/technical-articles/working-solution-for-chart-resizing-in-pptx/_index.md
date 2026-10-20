---
title: PPTX 中图表大小调整的可行方案
type: docs
weight: 40
url: /zh/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 图表大小调整
- Excel 图表
- OLE 对象
- 嵌入图表
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 嵌入的 Excel OLE 对象时，修复 PPTX 中意外的图表大小调整。设置固定图表尺寸，以保持图表和 OLE 框尺寸一致。"
---
## **背景**

使用 Aspose 组件将 Excel 图表作为 OLE 对象嵌入到 PowerPoint 演示文稿中后，首次激活时可能会改变大小。这会导致图表在激活前后的外观出现明显差异。本文解释了产生尺寸变化的原因，并展示通过将固定图表尺寸与 OLE 框匹配来防止此问题的方法。

在[创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用 Aspose.Cells for Java 创建 Excel 图表并使用 Aspose.Slides for Java 将其嵌入到 PowerPoint 演示文稿。为了解决[对象预览问题](/slides/zh/java/object-preview-issue-when-adding-oleobjectframe/)，我们将图表图像分配给图表的 OLE 对象框。在输出的演示文稿中，当双击显示图表图像的 OLE 对象框时，Excel 图表会被激活。用户可以编辑嵌入的 Excel 工作簿，然后通过点击已激活工作簿之外的区域返回到幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化，且调整比例因原始 OLE 对象框和嵌入的 Excel 工作簿的尺寸而异。

## **尺寸调整原因**

嵌入的 Excel 工作簿有其自己的窗口尺寸，Excel 会尝试在对象首次激活时保留该尺寸。幻灯片上的 OLE 框则拥有独立定义的尺寸。当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商对象的大小，以在嵌入过程中保持其比例。因此，工作簿窗口与 OLE 框之间的差异可能导致对象重新调整大小。

## **可行方案**

将图表尺寸与幻灯片上的 OLE 框匹配，并使图表尺寸独立于工作簿窗口。此方案可用于新建演示文稿或现有模板。

示例需要 Aspose.Cells for Java 和 Aspose.Slides for Java。它在活动图表工作表上创建一个简单的柱形图，并以 XLS 格式嵌入工作簿。未分配图表预览图像；图表将在 PowerPoint 中激活 OLE 对象时可见。

示例创建了一个带有 9.5 × 4 英寸 OLE 框的新演示文稿，框左侧距左边缘 0.5 英寸，顶部距上边缘 1 英寸。幻灯片坐标和尺寸使用点（每英寸 72 点）。有关现有演示文稿的用法，请参阅[使用模板](#use-a-template)。

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 幻灯片坐标和尺寸使用点（每英寸 72 点）表示。
        float width = 684f; // 9.5 英寸。
        float height = 288f; // 4 英寸。

        chart.setSizeWithWindow(false);
        // 使用每英寸 96 像素将点转换为图表像素。
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **设置固定图表尺寸**

将[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-)设为 false，以使图表尺寸独立于工作簿窗口。通过[setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-)和[setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-)设置[getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--)的尺寸，使用 96 像素/英寸将点转换为像素：一个 684 × 288 点的框对应 912 × 384 像素的图表。将[setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-)设为[PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/)的 CUSTOM 值。示例使用[addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-)嵌入工作簿，并保存一个带有 9.5 × 4 英寸 OLE 框的演示文稿。

## **使用模板**

现有演示文稿的尺寸逻辑相同。要适配示例：

1. 加载模板演示文稿，而不是创建空白演示文稿。  
2. 检查第一张幻灯片至少包含三个形状，然后使用索引为 2 的形状作为占位符。  
3. 从该形状获取框宽度和高度，而不是使用固定值 684 和 288。保持计算方式不变。  
4. 在占位符的位置添加 OLE 框，而不是使用固定坐标 36 和 72。  
5. 保存演示文稿前删除占位符。

## **常见问题**

**为什么我的嵌入 Excel 图表在 PowerPoint 中激活后会改变大小？**  
因为 Excel 在首次激活时尝试恢复原始窗口尺寸，而 PowerPoint 中的 OLE 对象框有自己的尺寸。PowerPoint 与 Excel 协商尺寸以保持长宽比，从而导致尺寸调整。

**如何保持图表和 OLE 框尺寸一致？**  
设置与 OLE 框匹配的固定图表尺寸，并在嵌入工作簿前使用自定义图表打印尺寸。上面的示例展示了所需的设置和单位换算。

**仅匹配工作簿窗口尺寸是否足够？**  
仅匹配工作簿窗口尺寸并不能可靠地防止 OLE 框在激活后改变大小。请使用示例中展示的固定图表尺寸。

**此方案是否同时适用于基于模板的演示文稿和新建演示文稿？**  
是的。对于模板，使用占位符的尺寸和位置；对于新建演示文稿，直接指定框的尺寸和位置。

**我可以将此示例用于其他电子表格程序创建的图表吗？**  
示例使用 Aspose.Cells 创建的 Excel 工作簿。它未演示其他电子表格程序的激活行为。

## **相关章节**

- [创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)