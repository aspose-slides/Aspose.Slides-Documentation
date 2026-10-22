---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/php-java/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक कोशिका
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को सहजता से प्रबंधित करें जिससे आपकी प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे वर्कबुक स्ट्रिम्स के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रहों तक पहुंच प्राप्त की जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि कैसे एक बाहरी वर्कबुक बनाई और नियोजित की जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित किया जाए।

गुम डेटा वाले वर्कबुक सेल्स के लिए, अंतर के बारे में जानने हेतु देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/php-java/chart-series/) जहाँ खाली सेल और शून्य के बीच का अंतर और लाइन‑चार्ट मोड के तुलना प्रस्तुत किया गया है।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करना**

Use [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) to control whether a chart plots data from hidden worksheet rows and columns. Set it to `true` to plot only visible cells, or `false` to include both visible and hidden cells. This setting controls chart plotting; it does not hide or unhide worksheet rows or columns.

The [नमूना प्रस्तुति](hidden-source-data.pptx) contains a column chart as the first shape on its first slide. The embedded worksheet, `Sheet1`, contains the following source range, `A1:C4`. Row 3 and column C are hidden, but their cells still contain values.

| Worksheet row | A: Month | B: Retail | C: Wholesale (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

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

            // एम्बेडेड वर्कबुक से चार्ट डेटा रीफ़्रेश करें।
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

The example saves two versions of the presentation: one with only the visible Retail values (10 and 20), and another with all six values. The images below illustrate the two plotting modes. Row 3 and column C remain hidden in both embedded workbooks.

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए Retail मान 10 और 20.](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी, और मार्च के लिए Retail और Wholesale मान.](hidden_cells_False.png) |

A hidden cell containing a value is different from an empty cell. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controls how missing values are displayed; it does not include or exclude hidden source data. See [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/php-java/chart-series/#control-the-display-of-empty-cells) for an example.

## **चार्ट की डेटा रेंज प्राप्त करना**

Before updating workbook data in an existing presentation, inspect the source ranges to identify which worksheet cells each chart uses. The [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) method returns the current data range as a worksheet-qualified formula, such as `Sheet1!$A$1:$D$5`. Here, `Sheet1` is the worksheet name, `!` separates it from the cell range, and `$A$1:$D$5` identifies cells A1 through D5, inclusive. The dollar signs indicate absolute row and column references.

The method reads the current range without changing the chart or its workbook. If the chart does not use a workbook as its data source, it throws an exception. For more information, see the [ChartData API रेफ़रेंस](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

This example opens a presentation and checks the shapes directly on each slide for charts. It prints each chart's name and source range. If a chart does not use a workbook, it prints a message and continues to the next chart.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides for PHP via Java provides the [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) and [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **नोट** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This example uses a presentation with a chart as the first shape on its first slide. It reads the embedded workbook into a byte array, clears the existing series and categories, and writes the same workbook back. The changes remain in memory; the example does not save the presentation.

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को सत्यापित करना**

When you replace an embedded workbook with a modified one, the chart retains its original series and category collections. This mismatch can cause [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) to fail with an index-out-of-range error. Clear the existing series and categories before writing the updated workbook back to the chart. This example uses a chart that is the first shape on the first slide. The comment marks where workbook editing would occur; the runnable example writes the original workbook back and validates the layout in memory.

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

        // यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करना**

Use [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) to control how numeric values appear in a chart's embedded workbook. For example, a report may need a conversion rate displayed as a percentage with four decimal places and a coefficient displayed with five decimal places. Keep both values numeric so they remain available for calculations and chart plotting.

A number format changes the display, not the stored value. The format `0.0000%` displays `0.125` as `12.5000%`; it does not replace the stored number with `12.5`. Similarly, `0.00000` displays `0.1234567` as `0.12346` without rounding the stored value. If the custom format is an empty string (`""`), the format returned by [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) is used instead.

The following example creates a column chart and accesses its cells through [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). On worksheet 0, B2 contains the conversion rate and C2 contains the coefficient. Both cells supply chart values. The example also enables value labels linked to the source formats.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Workbook cell formats are separate from formats set directly on chart axes or data labels. In this example, each label displays its source cell's value because [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) is set to `true`, and follows the source number format because [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) is set to `true`. After saving and reopening the presentation, the labels display `12.5000%` and `0.12346`, as shown below. The vertical axis uses its own number format, assigned with [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) as `0.00`, with [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) set to `false`.

To format a data label independently, set its source-link flag to `false` and assign a format with [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). This does not change the workbook cell's format. For example, an independent label format of `0.00` displays the first value as `0.13`, while B2 still displays `12.5000%`. See [Chart Data Labels](/slides/hi/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) for direct label formatting.

![स्रोत‑लिंक्ड लेबल वाले कॉलम चार्ट जिसमें 12.5000% और 0.12346 दिखाए गए हैं तथा स्वतंत्र रूप से फ़ॉर्मेट किया गया संख्यात्मक अक्ष.](custom-cell-formats.png)

## **चार्ट डेटा लेबल के रूप में वर्कबुक सेल सेट करना**

You can use text from workbook cells as chart data labels.

This example adds a bubble chart with default data to the first slide of an existing presentation. It uses cells A10:A12 on worksheet 0 for the first three labels in the first series, enables labels from cells, and saves the updated presentation.

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

## **वर्कशीट्स को प्रबंधित करना**

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

Series point values can also be stored directly as numeric literals. See [Set Series Values Using Numeric Literals](/slides/hi/php-java/chart-series/#set-series-values-using-numeric-literals) for a complete example that saves and reads them. The source type of point values is separate from the chart's internal or external workbook configuration; using numeric literals does not, by itself, remove the embedded workbook.

This example creates a 3D column chart with default data and sets two series names using different data sources. The first name uses a string literal; the second uses cell C1 on worksheet 0. The [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) enumeration selects the source for each name. The example saves the presentation with the updated series names.

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाना**

Aspose.Slides does not support the Excel binary workbook (.xlsb) format that can be embedded in some charts. You can use the `getEmbeddedWorkbookType` method on [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) together with the [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) enumeration to detect unsupported formats and skip those charts. This example inspects the shapes on the first slide of an existing presentation, skips non-chart shapes, and prints a diagnostic message for each chart with an embedded .xlsb workbook.

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

        // यहाँ समर्थित चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    $presentation->dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides supports using external workbooks as a data source for charts.

### **बाहरी वर्कबुक बनाना**

Use [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) and [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) to export an embedded chart workbook to a file and link the chart to that external workbook.

This example creates a pie chart with default data and exports its workbook. It completes the file write before assigning the external workbook as the chart data source, then saves the linked presentation.

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

### **बाहरी वर्कबुक सेट करना**

Using the [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This example uses an external workbook whose worksheet named `Sheet1` contains a series name in B1, category names in A2:A4, and numeric values in B2:B4. The example creates a pie chart, links the workbook, and uses [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) to map A1:B4 to one series and three categories. It saves the presentation with the linked chart.

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

`updateChartData` पैरामीटर [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) मे यह नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` हो, केवल वर्कबुक पथ अपडेट किया जाता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकती है।
* जब `updateChartData` `true` हो, चार्ट डेटा लक्ष्य वर्कबुक से अपडेट किया जाता है।

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

### **एक चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करना**

To identify the workbook linked to a chart, check whether the chart uses an external data source and retrieve its workbook path.

This example inspects the first shape on the first slide of a presentation with a linked external workbook. If it is a chart linked to an external workbook, the example prints [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) to the console. It then saves a copy of the presentation.

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

### **चार्ट डेटा संपादित करना**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This example uses a chart that is the first shape on the first slide and is linked to an accessible external workbook. It sets the cell-backed value of the first data point in the first series to 100 and saves the updated presentation. Editing cell values can update the linked external XLSX file, so use a copy if you need to preserve the original workbook.

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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करना**

If a chart uses an external workbook that is missing or unavailable, Aspose.Slides can reconstruct the chart workbook from the data cached in the presentation. Create [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), call [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), and set [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) to `true` before opening the presentation.

The following PHP example recovers workbook data for a chart that is the first shape on the first slide and references an unavailable external workbook. It accesses the recovered data through [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) and [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

If the external workbook is unavailable and recovery is disabled, Aspose.Slides throws an exception. Enable recovery only when using the cached chart data is an acceptable fallback, because the cache may not contain changes made to the external workbook after the presentation was last updated.

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट का एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक पथ](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप एक सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः ही एक निरपेक्ष पथ में बदल दिया जाता है। प्रस्तुति निरपेक्ष पथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से दूरस्थ वर्कबुक को सीधे संपादित करना समर्थित नहीं है — उन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को अधिलेखित करता है?**

प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य समाधान यह है कि पहले सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में प्रतिबिंबित होगा।