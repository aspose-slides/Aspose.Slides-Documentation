---
title: 创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿
type: docs
weight: 30
url: /zh/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 图表
- 嵌入图表
- OLE 对象
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Cells for Android via Java 创建 Excel 图表，并使用 Aspose.Slides for Android via Java 将工作簿嵌入 PowerPoint 演示文稿中，包括图表预览。"
---
## **概述**

本文展示了如何使用 Aspose.Cells for Android via Java 创建 Excel 列状图并将其工作簿嵌入到使用 Aspose.Slides for Android via Java 的 PowerPoint 演示文稿中。嵌入的工作簿同时包含源数据和图表。一个单独的 PNG 预览在 OLE 对象激活之前显示幻灯片上的图表。

结果是一个嵌入的 Excel 对象，而不是本机 PowerPoint 图表。通过 OLE 编辑工作簿需要支持 OLE 激活的桌面应用程序以及兼容的 Excel 安装。

## **先决条件**

将 Aspose.Cells for Android via Java 和 Aspose.Slides for Android via Java 添加到项目依赖中。在 Android Activity 中调用 `ExcelChartEmbedding.createPresentation(getFilesDir())`。生成演示文稿时不需要 Microsoft Office。

不需要输入文件：示例在内存中创建数据和图表，然后将 `OutputChart.pptx` 写入应用的内部文件目录。运行时若不在评估模式，请为两个产品应用许可证。

## **嵌入工作原理**

1. 创建包含数据工作表和图表工作表的工作簿。  
2. 将图表工作表设为活动工作表，使工作簿在打开时显示图表。  
3. 设置工作簿的 OLE 显示范围并将图表渲染为 PNG。  
4. 将工作簿以 XLSX 形式保存在内存中，并将其字节嵌入到幻灯片中。  
5. 将 PNG 设为 OLE 对象的预览并将演示文稿保存为 PPTX。

工作簿显示范围和幻灯片框架的作用不同。[setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 使用零基的起始/结束行列索引。[ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) 则使用顶部行、左侧列、底部行和右侧列。示例使用行索引 55 和列索引 25 作为右下边界，这些值是布局选择，而非数据行列的数量。

幻灯片框架使用点（points）。示例将其放置在幻灯片内部并居中显示，同时保持 PNG 的宽高比，而不是拉伸预览以填满幻灯片。

## **创建并嵌入图表**

以下完整示例向 `DataSheet` 填充四行五列的值。每行成为一个图表系列。保存工作簿之前，将 `ChartSheet` 设为活动工作表。

工作簿显式保存为 XLSX，匹配传递给 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 扩展名。PNG 直接从字节加载，无需中间位图转换。通过 [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 赋值可替换默认的 OLE 占位符。

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // 渲染图表预览并单独序列化可编辑的工作簿。
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

                        // 在幻灯片内适配预览而不改变其宽高比。
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **预期结果**

`OutputChart.pptx` 包含一张幻灯片，内嵌 Excel 工作簿并带有图表预览。工作簿包含原始数据和一个四系列的列状图。预览居中显示并保持比例。

![Excel 列状图作为嵌入工作簿的预览显示](excel-chart-ole-preview.png)

在具备 Excel 的兼容桌面 PowerPoint 环境中，双击对象即可激活并编辑嵌入的工作簿。激活和编辑取决于宿主应用的 OLE 支持和安全设置。

## **常见问题**

**为什么需要预览图像？**

嵌入的工作簿和幻灯片预览是分离的内容。提供图表图像可让幻灯片显示图表，而不是默认的 “EMBEDDED OLE OBJECT” 占位符。参见 [添加 OleObjectFrame 时的对象预览问题](/slides/zh/androidjava/object-preview-issue-when-adding-oleobjectframe/)。

**预览在代码中更改工作簿时会自动更新吗？**

将预览视为快照。程序化更新工作簿数据后，需要重新生成图表图像并替换预览以及嵌入的工作簿数据。

**我可以使用 XLS 而不是 XLSX 吗？**

可以。将工作簿保存为 XLS 格式并使用 `xls` 作为嵌入数据的扩展名。扩展名必须与实际工作簿格式匹配，仅更改扩展名并不会转换数据。

**为什么对象在激活后可能会改变大小？**

宿主应用在激活工作簿时可能更新 OLE 对象的呈现。工作簿的 OLE 显示范围和幻灯片框架尺寸都会影响结果。参见 [工作表调整大小的解决方案](/slides/zh/androidjava/working-solution-for-worksheet-resizing/)。

## **相关章节**

- [工作表调整大小的解决方案](/slides/zh/androidjava/working-solution-for-worksheet-resizing/)
- [添加 OleObjectFrame 时的对象预览问题](/slides/zh/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [管理 OLE](/slides/zh/androidjava/manage-ole/)