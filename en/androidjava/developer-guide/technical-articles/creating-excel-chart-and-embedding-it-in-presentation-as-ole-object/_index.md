---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 30
url: /androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Create an Excel chart with Aspose.Cells for Android via Java and embed the workbook in a PowerPoint presentation with Aspose.Slides for Android via Java, including a chart preview."
---

## **Overview**

This article shows how to create an Excel column chart with Aspose.Cells for Android via Java and embed its workbook in a PowerPoint presentation with Aspose.Slides for Android via Java. The embedded workbook contains both the source data and the chart. A separate PNG preview displays the chart on the slide before the OLE object is activated.

The result is an embedded Excel object, not a native PowerPoint chart. Editing the workbook through OLE requires a desktop application that supports OLE activation and a compatible Excel installation.

## **Prerequisites**

Add Aspose.Cells for Android via Java and Aspose.Slides for Android via Java to your project dependencies. Call `ExcelChartEmbedding.createPresentation(getFilesDir())` from an Android activity. Microsoft Office is not required to generate the presentation with these libraries.

No input files are required: the example creates the data and chart in memory, then writes `OutputChart.pptx` to the application's internal files directory. Apply licenses for both products when running outside evaluation mode.

## **How the Embedding Works**

1. Create a workbook with a data worksheet and a chart sheet.
1. Make the chart sheet active so that the workbook opens on the chart.
1. Set the workbook's OLE display range and render the chart to PNG.
1. Save the workbook as XLSX in memory and embed those bytes in a slide.
1. Assign the PNG as the OLE object's preview and save the presentation as PPTX.

The workbook display range and the frame on the slide have different roles. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) takes zero-based start/end row and column indices. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) instead takes the top row, left column, bottom row, and right column. The example uses row index 55 and column index 25 as the lower-right boundaries; these values are layout choices, not the number of data rows or columns.

The slide frame uses points. The example fits it within the slide and centers it while preserving the PNG's aspect ratio, rather than stretching the preview to fill the slide.

## **Create and Embed the Chart**

The following complete example populates `DataSheet` with four rows and five columns of values. Each row becomes a chart series. `ChartSheet` is selected as the active sheet before the workbook is saved.

The workbook is explicitly saved as XLSX, matching the `xlsx` extension passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). The PNG is loaded directly from its bytes without an intermediate bitmap conversion. Assigning it through [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) replaces the default OLE placeholder.

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

                // Render the chart preview and serialize the editable workbook separately.
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

                        // Fit the preview within the slide without changing its aspect ratio.
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

## **Expected Result**

`OutputChart.pptx` contains one slide with an embedded Excel workbook and a chart preview. The workbook contains the original data and a column chart with four series. The preview is centered on the slide and retains its proportions.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In a compatible desktop PowerPoint environment with Excel available, double-click the object to activate and edit the embedded workbook. Activation and editing depend on the host application's OLE support and security settings.

## **FAQ**

**Why is a preview image needed?**

The embedded workbook and its slide preview are separate content. Supply a chart image so the slide shows the chart instead of the default "EMBEDDED OLE OBJECT" placeholder. See [Object Preview Issue when Adding OleObjectFrame](/slides/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Does the preview update automatically when I change the workbook in code?**

Treat the preview as a snapshot. When updating workbook data programmatically, regenerate the chart image and replace the preview as well as the embedded workbook data.

**Can I use XLS instead of XLSX?**

Yes. Save the workbook in XLS format and use `xls` as the embedded data extension. The extension must match the actual workbook format; changing the extension alone does not convert the data.

**Why might the object change size after activation?**

The host application can update the OLE object's presentation when it activates the workbook. The workbook's OLE display range and the slide frame dimensions both matter. See [Working Solution for Worksheet Resizing](/slides/androidjava/working-solution-for-worksheet-resizing/).

## **Related Sections**

- [Working Solution for Worksheet Resizing](/slides/androidjava/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE](/slides/androidjava/manage-ole/)
