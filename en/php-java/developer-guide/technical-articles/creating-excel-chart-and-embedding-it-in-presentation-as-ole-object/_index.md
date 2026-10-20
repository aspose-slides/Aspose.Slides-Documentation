---
title: Create Excel Charts and Embed Them in Presentations as OLE Objects
type: docs
weight: 30
url: /php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel chart
- embed chart
- OLE object
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Create an Excel chart with Aspose.Cells for PHP via Java and embed the workbook in a PowerPoint presentation with Aspose.Slides for PHP via Java, including a chart preview."
---

## **Overview**

This article shows how to create an Excel column chart with Aspose.Cells for PHP via Java and embed its workbook in a PowerPoint presentation with Aspose.Slides for PHP via Java. The embedded workbook contains both the source data and the chart. A separate PNG preview displays the chart on the slide before the OLE object is activated.

The result is an embedded Excel object, not a native PowerPoint chart. Editing the workbook through OLE requires a desktop application that supports OLE activation and a compatible Excel installation.

## **Prerequisites**

Configure Aspose.Cells for PHP via Java and Aspose.Slides for PHP via Java with the same PHP/Java Bridge instance. Load both PHP wrappers and make both products' Java libraries available to the bridge. Microsoft Office is not required to generate the presentation with these libraries.

No input files are required: the example creates the data and chart in memory, then writes `OutputChart.pptx` to the current working directory. Apply licenses for both products when running outside evaluation mode.

## **How the Embedding Works**

1. Create a workbook with a data worksheet and a chart sheet.
1. Make the chart sheet active so that the workbook opens on the chart.
1. Set the workbook's OLE display range and render the chart to PNG.
1. Save the workbook as XLSX in memory and embed those bytes in a slide.
1. Assign the PNG as the OLE object's preview and save the presentation as PPTX.

The workbook display range and the frame on the slide have different roles. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) takes zero-based start/end row and column indices. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) instead takes the top row, left column, bottom row, and right column. The example uses row index 55 and column index 25 as the lower-right boundaries; these values are layout choices, not the number of data rows or columns.

The slide frame uses points. The example fits it within the slide and centers it while preserving the PNG's aspect ratio, rather than stretching the preview to fill the slide.

## **Create and Embed the Chart**

The following complete example populates `DataSheet` with four rows and five columns of values. Each row becomes a chart series. `ChartSheet` is selected as the active sheet before the workbook is saved.

The workbook is explicitly saved as XLSX, matching the `xlsx` extension passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Java numeric results are converted with `java_values` before PHP performs arithmetic, while binary data remains in Java byte arrays. The PNG is loaded directly from its bytes without an intermediate bitmap conversion. Assigning it through [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) replaces the default OLE placeholder.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Keep the PNG and XLSX as Java byte arrays when passing them to Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Fit and center the preview while preserving its aspect ratio.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Expected Result**

`OutputChart.pptx` contains one slide with an embedded Excel workbook and a chart preview. The workbook contains the original data and a column chart with four series. The preview is centered on the slide and retains its proportions.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In a compatible desktop PowerPoint environment with Excel available, double-click the object to activate and edit the embedded workbook. Activation and editing depend on the host application's OLE support and security settings.

## **FAQ**

**Why is a preview image needed?**

The embedded workbook and its slide preview are separate content. Supply a chart image so the slide shows the chart instead of the default "EMBEDDED OLE OBJECT" placeholder. See [Object Preview Issue when Adding OleObjectFrame](/slides/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Does the preview update automatically when I change the workbook in code?**

Treat the preview as a snapshot. When updating workbook data programmatically, regenerate the chart image and replace the preview as well as the embedded workbook data.

**Can I use XLS instead of XLSX?**

Yes. Save the workbook in XLS format and use `xls` as the embedded data extension. The extension must match the actual workbook format; changing the extension alone does not convert the data.

**Why might the object change size after activation?**

The host application can update the OLE object's presentation when it activates the workbook. The workbook's OLE display range and the slide frame dimensions both matter. See [Working Solution for Chart Resizing in PPTX](/slides/java/working-solution-for-chart-resizing-in-pptx/).

## **Related Sections**

- [Working Solution for Chart Resizing in PPTX](/slides/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/php-java/manage-ole/)
