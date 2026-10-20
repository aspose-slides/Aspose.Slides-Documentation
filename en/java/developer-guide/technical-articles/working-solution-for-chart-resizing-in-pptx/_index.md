---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 40
url: /java/working-solution-for-chart-resizing-in-pptx/
keywords:
- chart resizing
- Excel chart
- OLE object
- embed chart
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Fix unexpected chart resizing in PPTX when using embedded Excel OLE objects with Aspose.Slides for Java. Set fixed chart dimensions to keep the chart and OLE frame sizes consistent."
---

## **Background**

Excel charts embedded as OLE objects in PowerPoint presentations using Aspose components can change size after their first activation. This can cause a noticeable difference in the chart's appearance before and after activation. This article explains why resizing occurs and shows how to prevent it by matching fixed chart dimensions to the OLE frame.

In [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Java and embed it in a PowerPoint presentation using Aspose.Slides for Java. To address the [object preview issue](/slides/java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Cause of Resizing**

The embedded Excel workbook has its own window dimensions, which Excel tries to retain when the object is first activated. The OLE frame on the slide has independently defined dimensions. When the Excel workbook is activated, Excel and PowerPoint negotiate the object's size to maintain its proportions as part of the embedding process. Differences between the workbook window and the OLE frame can therefore cause the object to resize.

## **Working Solution**

Match the chart size to the OLE frame on the slide and keep the chart dimensions independent of the workbook window. This solution works with a new presentation or an existing template.

The example requires Aspose.Cells for Java and Aspose.Slides for Java. It creates a simple column chart on an active chart sheet and embeds the workbook in XLS format. No chart preview image is assigned; the chart becomes visible when the OLE object is activated in PowerPoint.

The example creates a new presentation with a 9.5 × 4-inch OLE frame positioned 0.5 inches from the left edge and 1 inch from the top. Slide coordinates and dimensions are in points (72 points per inch). For an existing presentation, see [Use a Template](#use-a-template).

## **Set a Fixed Chart Size**

Set [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) to false so that the chart dimensions are independent of the workbook window. Set the [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) dimensions through [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) and [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). The example embeds the workbook with [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) and saves a presentation with a 9.5 × 4-inch OLE frame.

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

        // Slide coordinates and dimensions are in points (72 points per inch).
        float width = 684f; // 9.5 inches.
        float height = 288f; // 4 inches.

        chart.setSizeWithWindow(false);
        // Convert points to chart pixels using 96 pixels per inch.
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

## **Use a Template**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Load the template presentation instead of creating an empty presentation.
1. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.
1. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Keep the sizing calculations unchanged.
1. Add the OLE frame at the placeholder's position instead of the fixed coordinates 36 and 72.
1. Remove the placeholder before saving the presentation.

## **FAQ**

**Why does my embedded Excel chart change size after activating it in PowerPoint?**

This happens because Excel tries to restore the original window size when first activated, whereas the OLE object frame in PowerPoint has its own dimensions. PowerPoint and Excel negotiate the size to maintain the aspect ratio, which can cause the resizing.

**How can I keep the chart and OLE frame sizes consistent?**

Set fixed chart dimensions that match the OLE frame and use a custom chart print size before embedding the workbook. The example above shows the required settings and unit conversions.

**Is matching the workbook window size sufficient?**

Matching the workbook window size alone does not reliably prevent the OLE frame from changing size after activation. Use fixed chart dimensions as shown in the example.

**Does this solution work with both template-based presentations and new presentations?**

Yes. For a template, use the placeholder's dimensions and position. For a new presentation, specify the frame dimensions and position directly.

**Can I use this example with charts created in other spreadsheet programs?**

The example uses an Excel workbook created with Aspose.Cells. It does not demonstrate activation behavior for other spreadsheet programs.

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
