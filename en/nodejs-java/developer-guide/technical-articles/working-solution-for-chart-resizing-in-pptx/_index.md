---
title: Working Solution for Chart Resizing in PPTX
type: docs
weight: 40
url: /nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- chart resizing
- Excel chart
- OLE object
- embed chart
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Fix unexpected chart resizing in PPTX when using embedded Excel OLE objects with Aspose.Slides for Node.js via Java. Set fixed chart dimensions to keep the chart and OLE frame sizes consistent."
---

## **Overview**

Excel charts embedded as OLE objects in PowerPoint presentations using Aspose components can change size after their first activation. This can cause a noticeable difference in the chart's appearance before and after activation. This article explains why resizing occurs and shows how to prevent it by matching fixed chart dimensions to the OLE frame.

In [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Node.js via Java and embed it in a PowerPoint presentation using Aspose.Slides for Node.js via Java. To address the [object preview issue](/slides/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Cause of Resizing**

The embedded Excel workbook has its own window dimensions, which Excel tries to retain when the object is first activated. The OLE frame on the slide has independently defined dimensions. When the Excel workbook is activated, Excel and PowerPoint negotiate the object's size to maintain its proportions as part of the embedding process. Differences between the workbook window and the OLE frame can therefore cause the object to resize.

## **Working Solution**

Match the chart size to the OLE frame on the slide and keep the chart dimensions independent of the workbook window. This solution works with a new presentation or an existing template.

The example requires Aspose.Cells for Node.js via Java and Aspose.Slides for Node.js via Java. Install the `aspose.cells`, `aspose.slides.via.java`, and `java` Node.js packages. Run the two CommonJS scripts below in separate Node.js processes, using the same working directory, because both Aspose packages initialize the Java bridge during loading. It creates a simple column chart on an active chart sheet and embeds the workbook in XLS format. No chart preview image is assigned; the chart becomes visible when the OLE object is activated in PowerPoint.

The example creates a new presentation with a 9.5 × 4-inch OLE frame positioned 0.5 inches from the left edge and 1 inch from the top. Slide coordinates and dimensions are in points (72 points per inch). For an existing presentation, see [Use a Template](#use-a-template).

## **Set a Fixed Chart Size**

Set [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) to false so that the chart dimensions are independent of the workbook window. Set the [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) dimensions through [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) and [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) to the CUSTOM value of `PrintSizeType`. The example embeds the workbook with [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) and saves a presentation with a 9.5 × 4-inch OLE frame.

Save this first script as `create-fixed-chart.js`. It creates `chart-fixed-size.xls` with a chart measuring 912 × 384 pixels, matching the 684 × 288-point frame used by the second script. No input workbook is required.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Match the OLE frame dimensions in points (72 points per inch).
    const width = 684; // 9.5 inches.
    const height = 288; // 4 inches.

    chart.setSizeWithWindow(false);
    // Convert points to chart pixels using 96 pixels per inch.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

Save the second script as `embed-fixed-chart.js` and run it after `create-fixed-chart.js`. It reads the generated XLS workbook and saves `chart-fixed-size.pptx`. The Java bridge requires an explicit Java byte array for the workbook data and Java float values for the frame coordinates and dimensions. The `xls` extension matches the workbook's saved format.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Slide coordinates and dimensions are in points (72 points per inch).
    const width = 684; // 9.5 inches.
    const height = 288; // 4 inches.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

## **Use a Template**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Load the template presentation instead of creating an empty presentation.
1. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.
1. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Use the same dimensions in the workbook-creation script, keeping the sizing calculations unchanged, and regenerate the XLS workbook before embedding it.
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

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
