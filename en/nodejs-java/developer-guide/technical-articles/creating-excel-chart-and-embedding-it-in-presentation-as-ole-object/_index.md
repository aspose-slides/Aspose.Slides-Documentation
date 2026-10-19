---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 30
url: /nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Create an Excel chart with Aspose.Cells for Node.js via Java and embed the workbook in a PowerPoint presentation with Aspose.Slides, including a chart preview."
---

## **Overview**

This article shows how to create an Excel column chart with Aspose.Cells for Node.js via Java and embed its workbook in a PowerPoint presentation with Aspose.Slides for Node.js via Java. The embedded workbook contains both the source data and the chart. A separate PNG preview displays the chart on the slide before the OLE object is activated.

The result is an embedded Excel object, not a native PowerPoint chart. Editing the workbook through OLE requires a desktop application that supports OLE activation and a compatible Excel installation.

## **Prerequisites**

Install the `aspose.cells`, `aspose.slides.via.java`, and `java` Node.js packages. Run the examples as two CommonJS scripts in separate Node.js processes: first `create-chart.js`, then `embed-chart.js`, using the same working directory. Both Aspose packages initialize the Java bridge during loading, so these examples keep them in separate processes. Microsoft Office is not required to generate the presentation with these libraries.

No existing workbook or image is required. The first script creates `ChartWorkbook.xlsx` and `ChartPreview.png`; the second reads those files and writes `OutputChart.pptx` to the current working directory. Apply licenses for both products when running outside evaluation mode.

## **How the Embedding Works**

1. Create a workbook with a data worksheet and a chart sheet.
1. Make the chart sheet active so that the workbook opens on the chart.
1. Set the workbook's OLE display range and render the chart to PNG.
1. Save the workbook as XLSX and embed its bytes in a slide in a separate Node.js process.
1. Assign the PNG as the OLE object's preview and save the presentation as PPTX.

The workbook display range and the frame on the slide have different roles. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) takes zero-based start/end row and column indices. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) instead takes the top row, left column, bottom row, and right column. The example uses row index 55 and column index 25 as the lower-right boundaries; these values are layout choices, not the number of data rows or columns.

The slide frame uses points. The example fits it within the slide and centers it while preserving the PNG's aspect ratio, rather than stretching the preview to fill the slide.

## **Create and Embed the Chart**

Save the first example as `create-chart.js`. It populates `DataSheet` with four rows and five columns of values. Each row becomes a chart series. `ChartSheet` is selected as the active sheet before the workbook is saved.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Render the chart preview and serialize the editable workbook separately.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

Save the following example as `embed-chart.js`. Run it after `create-chart.js` has created both input files. It centers the OLE frame and preserves the preview image's aspect ratio.

The second script embeds the saved workbook and uses the PNG as its preview. The workbook is explicitly saved as XLSX, matching the `xlsx` extension passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). The PNG is loaded directly from its bytes without an intermediate bitmap conversion. The Java bridge requires explicit Java byte arrays for the image and workbook data, and Java float values for the slide frame coordinates. Assigning it through [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) replaces the default OLE placeholder.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Fit the preview within the slide without changing its aspect ratio.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// All synchronous work is complete; stop the Java bridge process.
process.exit(0);
```

## **Expected Result**

`OutputChart.pptx` contains one slide with an embedded Excel workbook and a chart preview. The workbook contains the original data and a column chart with four series. The preview is centered on the slide and retains its proportions.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In a compatible desktop PowerPoint environment with Excel available, double-click the object to activate and edit the embedded workbook. Activation and editing depend on the host application's OLE support and security settings.

## **FAQ**

**Why is a preview image needed?**

The embedded workbook and its slide preview are separate content. Supply a chart image so the slide shows the chart instead of the default "EMBEDDED OLE OBJECT" placeholder. See [Object Preview Issue when Adding OleObjectFrame](/slides/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Does the preview update automatically when I change the workbook in code?**

Treat the preview as a snapshot. When updating workbook data programmatically, regenerate the chart image and replace the preview as well as the embedded workbook data.

**Can I use XLS instead of XLSX?**

Yes. Save the workbook in XLS format and use `xls` as the embedded data extension. The extension must match the actual workbook format; changing the extension alone does not convert the data.

**Why might the object change size after activation?**

The host application can update the OLE object's presentation when it activates the workbook. The workbook's OLE display range and the slide frame dimensions both matter. See [Working Solution for Chart Resizing in PPTX](/slides/java/working-solution-for-chart-resizing-in-pptx/).

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)
