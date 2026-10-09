---
title: 使用 PHP 管理演示文稿中的图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/php-java/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- 图表缓存
- 工作簿恢复
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文说明如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合以及为图表值指定数据源类型。

它还涵盖了使用外部工作簿作为图表数据源的操作。示例演示了如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/php-java/chart-series/)以了解空单元格与零的区别，以及可用显示模式的折线图比较。

## **包含隐藏行和列中的数据**

使用[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/)控制图表是否仅绘制隐藏工作表行和列中的可见单元格。将其设为 `true` 只绘制可见单元格，设为 `false` 则包含可见和隐藏单元格。此设置仅影响图表绘制，不会隐藏或取消隐藏工作表行或列。

[sample presentation](hidden-source-data.pptx)的第一张幻灯片的第一个形状是柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和 C 列被隐藏，但它们的单元格仍然包含值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隐藏行) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)访问源单元格，并读取[ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/)以检查其隐藏状态。此方法报告隐藏状态而不更改它。在本例中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `false`、`true` 和 `true`。

对于本示例，在更改绘图设置后刷新图表数据：使用[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)保留嵌入的工作簿，并使用[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)重新加载它。包含所有单元格时，还需使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

            // 从嵌入的工作簿刷新图表数据。
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 恢复完整的源范围，包括隐藏的类别。
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

示例保存了两个版本的演示文稿：一个仅包含可见的零售值（10 和 20），另一个包含全部六个值。下图展示了两种绘图模式。第 3 行和 C 列在两个嵌入的工作簿中仍然隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含值的隐藏单元格不同于空单元格。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)控制缺失值的显示方式；它不包含或排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/php-java/chart-series/#control-the-display-of-empty-cells)获取示例。

## **检索图表的数据范围**

在更新现有演示文稿中的工作簿数据之前，检查源范围以识别每个图表使用的工作表单元格。[ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/)方法返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 为工作表名称，`!` 将其与单元格范围分隔，`$A$1:$D$5` 标识包括 A1 到 D5 的单元格。美元符号表示绝对行列引用。

该方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，则会抛出异常。有关更多信息，请参阅[ChartData API 参考](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)。

此示例打开演示文稿并直接检查每张幻灯片上的形状是否为图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，则打印一条消息并继续下一个图表。

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

## **从工作簿读取和写入图表数据**

Aspose.Slides for PHP via Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)和[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)方法，允许读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意** 图表数据必须以相同方式组织或结构类似于源数据。

此示例使用第一张幻灯片第一形状的图表的演示文稿。它将嵌入的工作簿读取为字节数组，清除现有系列和类别，并将相同的工作簿写回。更改保留在内存中，示例未保存演示文稿。

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

### **在修改工作簿后验证图表布局**

当用修改后的工作簿替换嵌入的工作簿时，图表仍保留原始的系列和类别集合。这种不匹配可能导致[Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)因索引超出范围而失败。写回更新的工作簿之前，请先清除现有系列和类别。此示例使用第一张幻灯片第一形状的图表。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

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

        // 在此修改工作簿字节，例如，使用 Aspose.Cells。

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

清除集合可在写回工作簿之前移除陈旧的数据引用。为更新的工作簿在使用图表前重新构建任何必需的系列和类别映射。

## **将工作簿单元格设为图表数据标签**

可以使用工作簿单元格中的文本作为图表数据标签。

此示例在现有演示文稿的第一张幻灯片添加一个带默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

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

## **管理工作表**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/)方法提供对图表工作簿中工作表的访问。此示例创建一个带默认数据的饼图，并将每个工作表名称打印到控制台。

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

## **指定数据源类型**

此示例创建一个带默认数据的 3D 柱形图，并使用不同的数据源设置两个系列名称。第一个名称使用字符串文字；第二个使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/)枚举为每个名称选择来源。示例保存了带有更新系列名称的演示文稿。

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

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)上使用 `getEmbeddedWorkbookType` 方法并结合[WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。此示例检查现有演示文稿第一张幻灯片上的形状，跳过非图表形状，并为每个嵌入 .xlsb 工作簿的图表打印诊断信息。

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

        // 在此读取或修改受支持的图表工作簿数据。
    }
} finally {
    $presentation->dispose();
}
```

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **创建外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)和[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)将嵌入的图表工作簿导出为文件，并将图表链接到该外部工作簿。

此示例创建一个带默认数据的饼图并导出其工作簿。它在将外部工作簿分配为图表数据源之前完成文件写入，然后保存已链接的演示文稿。

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

### **设置外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)方法，您可以将外部工作簿分配给图表作为其数据源。该方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

此示例使用一个外部工作簿，其工作表 `Sheet1` 包含 B1 中的系列名称、A2:A4 中的类别名称以及 B2:B4 中的数值。示例创建饼图，链接工作簿，并使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)将 A1:B4 映射为一个系列和三个类别。它保存了带有链接图表的演示文稿。

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

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 与 `updateChartData` 设置为 `false` 进行分配。它保留饼图的默认数据并在不加载不可用工作簿的情况下保存演示文稿。

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

### **获取图表的外部数据源工作簿路径**

要识别链接到图表的工作簿，请检查图表是否使用外部数据源并检索其工作簿路径。

此示例检查演示文稿第一张幻灯片的第一个形状是否为链接到外部工作簿的图表。如果是，则将[getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)打印到控制台。随后保存演示文稿的副本。

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

### **编辑图表数据**

您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

此示例使用第一张幻灯片第一形状的图表，该图表链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格值设为 100 并保存更新后的演示文稿。编辑单元格值可以更新链接的外部 XLSX 文件，若需保留原始工作簿，请使用副本。

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

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)，调用[LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)，并在打开演示文稿前将[SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/)设为 `true`。

下面的 PHP 示例恢复了第一张幻灯片第一形状的图表的工作簿数据，该图表引用了不可用的外部工作簿。它通过[Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/)和[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)访问恢复的数据：

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

        // 在此读取或修改恢复的工作簿数据。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。仅在使用缓存图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿的后续更改。

## **常见问题解答**

**我能判断特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)和[external workbook path](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认正在使用外部文件。

**是否支持相对路径的外部工作簿，如何存储？**

支持。如果指定相对路径，它会自动转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，因此移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可以用作外部数据源。但 Aspose.Slides 不支持直接编辑远程工作簿——只能将其作为来源使用。

**保存演示文稿时 Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿存储了指向外部文件的[link](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如需保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备一个已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），然后链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都存储自己的链接。如果它们指向相同文件，更新该文件后在下次加载数据时所有图表都会反映更改。