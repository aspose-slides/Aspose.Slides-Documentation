---
title: 在演示文稿中创建 Excel 图表并将其作为 OLE 对象嵌入
type: docs
weight: 30
url: /zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Cells for Java 创建 Excel 图表，并将工作簿嵌入到使用 Aspose.Slides 的 PowerPoint 演示文稿中，包括图表预览。"
---
## **概述**

本文展示了如何使用 Aspose.Cells for Java 创建 Excel 柱形图，并将其工作簿嵌入到使用 Aspose.Slides for Java 的 PowerPoint 演示文稿中。嵌入的工作簿同时包含源数据和图表。单独的 PNG 预览在 OLE 对象激活之前显示幻灯片上的图表。

结果是嵌入的 Excel 对象，而非本机 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

将 Aspose.Cells for Java 和 Aspose.Slides for Java 添加到项目依赖中。在 Java 方法中运行示例。使用这些库生成演示文稿无需 Microsoft Office。

不需要任何输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入当前工作目录。在评估模式之外运行时，请为两个产品应用许可证。

## **嵌入工作原理**

1. 创建一个包含数据工作表和图表工作表的工作簿。
1. 将图表工作表设为活动工作表，以便工作簿打开时显示图表。
1. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。
1. 将工作簿以 XLSX 格式保存到内存中，并将这些字节嵌入到幻灯片中。
1. 将 PNG 设为 OLE 对象的预览，并将演示文稿保存为 PPTX。

工作簿显示范围和幻灯片框架具有不同的作用。[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 使用从零开始的起始/结束行列索引。相反，[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) 使用顶部行、左侧列、底部行和右侧列。示例使用行索引 55 和列索引 25 作为右下边界；这些值是布局选择，而不是数据行列的数量。

幻灯片框架使用点作为单位。示例将其放置在幻灯片内部并居中，同时保持 PNG 的宽高比，而不是将预览拉伸以填满幻灯片。

## **创建并嵌入图表**

下面的完整示例向 `DataSheet` 填充四行五列的值。每行对应一个图表序列。保存工作簿之前，将 `ChartSheet` 设为活动工作表。

工作簿明确保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 扩展名。PNG 直接从其字节加载，无需中间的位图转换。通过 [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 进行分配可替换默认的 OLE 占位符。

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // 渲染图表预览并分别序列化可编辑的工作簿。
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // 在幻灯片内适配预览图像，保持其宽高比不变。
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```
## **预期结果**

`OutputChart.pptx` 包含一张带有嵌入式 Excel 工作簿和图表预览的幻灯片。工作簿包括原始数据以及包含四个序列的柱形图。预览居中显示在幻灯片上，并保持其比例。

![Excel 柱形图作为嵌入工作簿的预览显示](excel-chart-ole-preview.png)

在兼容的桌面 PowerPoint 环境且已安装 Excel 时，双击对象即可激活并编辑嵌入的工作簿。激活和编辑取决于宿主应用程序的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和其幻灯片预览是分开的内容。提供图表图像，以便幻灯片显示图表而不是默认的“EMBEDDED OLE OBJECT”占位符。参见 [添加 OleObjectFrame 时的对象预览问题](/slides/zh/java/object-preview-issue-when-adding-oleobjectframe/)。

**在代码中更改工作簿时，预览会自动更新吗？**

将预览视为快照。当以编程方式更新工作簿数据时，需要重新生成图表图像并同时替换预览和嵌入的工作簿数据。

**可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式，并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际的工作簿格式匹配，仅更改扩展名并不会转换数据。

**激活后对象可能会改变大小的原因是什么？**

宿主应用在激活工作簿时可能会更新 OLE 对象的显示。工作簿的 OLE 显示范围和幻灯片框架尺寸均会影响。参见 [PPTX 中图表缩放的可行方案](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)。

## **相关章节**

- [PPTX 中图表缩放的可行方案](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/java/object-preview-issue-when-adding-oleobjectframe/)
- [使用 PowerPoint 加载项自动更新 OLE 对象](/slides/zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)