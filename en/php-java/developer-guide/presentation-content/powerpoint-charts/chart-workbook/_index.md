---
title: Manage Chart Workbooks in Presentations Using PHP
linktitle: Chart Workbook
type: docs
weight: 70
url: /php-java/chart-workbook/
keywords:
- chart workbook
- chart data
- workbook cell
- data label
- worksheet
- data source
- external workbook
- external data
- chart cache
- workbook recovery
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Discover Aspose.Slides for PHP via Java: effortlessly manage chart workbooks in PowerPoint and OpenDocument formats to streamline your presentation data."
---

## **Overview**

This article explains how to work with chart workbooks in Aspose.Slides. It shows how to read and write chart data through workbook streams, use workbook cells as chart data labels, access worksheet collections, and specify the data source type for chart values.

It also covers working with external workbooks as chart data sources. The examples demonstrate how to create and assign an external workbook, retrieve the path of an external workbook linked to a chart, and edit chart data when the workbook is available.

For workbook cells that represent missing data, see [Control the Display of Empty Cells](/slides/php-java/chart-series/) for the difference between an empty cell and zero, and a line-chart comparison of the available display modes.

## **Include Data from Hidden Rows and Columns**

Use [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) to control whether a chart plots data from hidden worksheet rows and columns. Set it to `true` to plot only visible cells, or `false` to include both visible and hidden cells. This setting controls chart plotting; it does not hide or unhide worksheet rows or columns.

Download [hidden-source-data.pptx](hidden-source-data.pptx) and place it in the working directory. Its first slide contains a column chart as the first shape. The embedded worksheet, `Sheet1`, contains the following source range, `A1:C4`. Row 3 and column C are hidden, but their cells still contain values.

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Access source cells through [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) and read [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) to inspect their hidden status. This method reports the hidden status without changing it. In this file, B2 is visible, B3 belongs to the hidden row, and C2 belongs to the hidden column; the example prints `false`, `true`, and `true`, respectively.

For this example, refresh the chart data after changing the plotting setting: retain the embedded workbook with [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) and reload it with [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). When including all cells, also use [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) to restore the complete range, including the hidden February category. Simply changing the flag is insufficient to refresh this sample's cached chart data and category labels.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Refresh the chart data from the embedded workbook.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Restore the complete source range, including hidden categories.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

The example saves `hidden_cells_true.pptx` with only the visible Retail values (10 and 20), and `hidden_cells_false.pptx` with all six values. The images below illustrate the two plotting modes. Row 3 and column C remain hidden in both embedded workbooks.

| Only visible cells (`true`) | All cells (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

A hidden cell containing a value is different from an empty cell. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controls how missing values are displayed; it does not include or exclude hidden source data. See [Control the Display of Empty Cells](/slides/php-java/chart-series/#control-the-display-of-empty-cells) for an example.

## **Read and Write Chart Data from a Workbook**

Aspose.Slides for PHP via Java provides the [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) and [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This example opens `chart.pptx`, which must contain a chart as the first shape on its first slide. It reads the embedded workbook into a byte array, clears the existing series and categories, and writes the same workbook back. The changes remain in memory; the example does not save the presentation.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Validate Chart Layout After Workbook Modification**

When you replace an embedded workbook with a modified one, the chart retains its original series and category collections. This mismatch can cause [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) to fail with an index-out-of-range error. Clear the existing series and categories before writing the updated workbook back to the chart. This example requires `chart.pptx` with a chart as the first shape on its first slide. The comment marks where workbook editing would occur; the runnable example writes the original workbook back and validates the layout in memory.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Modify the workbook bytes here, for example, using Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Clearing the collections removes stale data references before the workbook is written back. Rebuild any required series and category mappings for the updated workbook before using the chart.

## **Set a Workbook Cell as a Chart Data Label**

You can use text from workbook cells as chart data labels. The following steps show how to link the labels in a bubble chart to cells in its data workbook.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Access the first slide by its zero-based index.
1. Add a bubble chart with default data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This example opens `chart2.pptx`, which must contain at least one slide, and adds a bubble chart with default data. It uses cells A10:A12 on worksheet 0 for the first three labels in the first series, enables labels from cells, and saves the result to `resultchart.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Manage Worksheets**

The [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) method provides access to the worksheets in a chart workbook. This example creates a pie chart with default data and prints each worksheet name to the console.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Specify the Data Source Type**

This example creates a 3D column chart with default data and sets two series names using different data sources. The first name uses a string literal; the second uses cell C1 on worksheet 0. The [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) enumeration selects the source for each name. The result is saved to `pres.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides does not support the Excel binary workbook (.xlsb) format that can be embedded in some charts. You can use the `getEmbeddedWorkbookType` method on [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) together with the [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) enumeration to detect unsupported formats and skip those charts. This example inspects the shapes on the first slide of `sample.pptx`, skips non-chart shapes, and prints a diagnostic message for each chart with an embedded .xlsb workbook.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Read or modify supported chart workbook data here.
    }
} finally {
    $presentation->dispose();
}
```

## **External Workbook**

Aspose.Slides supports using external workbooks as a data source for charts.

### **Create an External Workbook**

Use [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) and [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) to export an embedded chart workbook to a file and link the chart to that external workbook.

This example creates a pie chart with default data, writes its workbook to `externalWorkbook1.xlsx`, and completes the file write before assigning the file as the chart data source. It saves the linked presentation to `externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```


### **Set an External Workbook**

Using the [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This example requires `externalWorkbook.xlsx` in the working directory. Its worksheet named `Sheet1` must contain a series name in B1, category names in A2:A4, and numeric values in B2:B4. The example creates a pie chart, links the workbook, and uses [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) to map A1:B4 to one series and three categories. It saves the result to `Presentation_with_externalWorkbook.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The `updateChartData` parameter of [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) controls whether the workbook is loaded.

* When `updateChartData` is `false`, only the workbook path is updated. The chart data is not loaded or updated from the target workbook, so the workbook can be unavailable.
* When `updateChartData` is `true`, the chart data is updated from the target workbook.

The following example assigns a placeholder URL with `updateChartData` set to `false`. It retains the pie chart's default data and saves the presentation without loading the unavailable workbook.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Get the External Data Source Workbook Path of a Chart**

To identify the workbook linked to a chart, first check whether the chart uses an external data source. If it does, you can retrieve the workbook path by following these steps.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class.
1. Access the first slide by its zero-based index.
1. Check that the first shape is a chart.
1. Read the chart data source type.
1. If the source is an external workbook, read its path.

This example opens `externalWorkbook.pptx`, created in the earlier example, and inspects the first shape on the first slide. If it is a chart linked to an external workbook, the example prints [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) to the console. It then saves a copy of the presentation to `Result.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This example requires `presentation.pptx` with a chart as the first shape on the first slide and an accessible external workbook. It sets the cell-backed value of the first data point in the first series to 100 and saves the presentation to `presentation_out.pptx`. Editing cell values can update the linked external XLSX file, so use a copy if you need to preserve the original workbook.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Recover a Workbook from the Chart Cache**

If a chart uses an external workbook that is missing or unavailable, Aspose.Slides can reconstruct the chart workbook from the data cached in the presentation. Create [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), call [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), and set [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) to `true` before opening the presentation.

The following PHP example opens `presentation.pptx`, whose first shape on the first slide must be a chart referencing an unavailable external workbook, and accesses the recovered data through [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) and [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Read or modify the recovered workbook data here.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

If the external workbook is unavailable and recovery is disabled, Aspose.Slides throws an exception. Enable recovery only when using the cached chart data is an acceptable fallback, because the cache may not contain changes made to the external workbook after the presentation was last updated.

## **FAQ**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) and a [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Are relative paths to external workbooks supported, and how are they stored?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. The presentation stores the absolute path in the PPTX file, so moving the workbook may require updating the link.

**Can I use workbooks located on network resources/shares?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

The presentation stores a [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Editing cell-backed chart data can also update the linked local XLSX file. Use a copy of the workbook if the original must remain unchanged.

**What should I do if the external file is password-protected?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](https://reference.aspose.com/cells/java/)) and link to that copy.

**Can multiple charts reference the same external workbook?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.
