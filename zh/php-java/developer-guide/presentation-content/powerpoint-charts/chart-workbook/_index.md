---
title: 使用 PHP 在演示文稿中管理图表工作簿
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
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 了解 Aspose.Slides for PHP：轻松管理 PowerPoint 和 OpenDocument 格式的图表工作簿，以简化演示文稿数据。"
---

## **读取和写入工作簿中的图表数据**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) 方法，允许您读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同的方式组织，或具有与源相似的结构。

下面的 PHP 代码演示了一个示例操作：
```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将工作簿单元格设置为图表数据标签**
1. 创建 [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个带有数据的气泡图。  
4. 访问图表系列。  
5. 将工作簿单元格设置为数据标签。  
6. 保存演示文稿。  

下面的 PHP 代码展示了如何将工作簿单元格设置为图表数据标签：
```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **管理工作表**
下面的 PHP 代码演示了使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) 方法访问工作表集合的操作：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **指定数据源类型**
下面的 PHP 代码展示了如何为数据源指定类型：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **外部工作簿**
{{% alert color="primary" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/) 中，我们实现了对外部工作簿作为图表数据源的支持。 
{{% /alert %}} 

### **创建外部工作簿**
使用 **`readWorkbookStream`** 和 **`setExternalWorkbook`** 方法，您可以从头创建外部工作簿，或将内部工作簿转换为外部工作簿。

下面的 PHP 代码演示了外部工作簿的创建过程：
```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **设置外部工作簿**
使用 **`setExternalWorkbook`** 方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可以用于更新外部工作簿的路径（如果后者已移动）。

虽然不能编辑存储在远程位置或资源中的工作簿数据，但仍可以将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

下面的 PHP 代码展示了如何设置外部工作簿：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


`ChartData` 参数（在 `setExternalWorkbook` 方法下）用于指定是否加载 Excel 工作簿。

* `ChartData` 值设为 `false` 时，仅更新工作簿路径——图表数据不会从目标工作簿加载或更新。当目标工作簿不存在或不可用时，可使用此设置。  
* `ChartData` 值设为 `true` 时，图表数据会从目标工作簿更新。  
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **获取图表的外部数据源工作簿路径**
1. 创建 [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 为图表形状创建对象。  
4. 为表示图表数据源的源 (`ChartDataSourceType`) 类型创建对象。  
5. 根据源类型与外部工作簿数据源类型相同，指定相应条件。  

下面的 PHP 代码演示了此操作：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # 保存演示文稿
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **编辑图表数据**
您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

下面的 PHP 代码实现了上述过程：
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**
**我如何确定特定图表是链接到外部工作簿还是嵌入的工作簿？**  
可以。图表具有[data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) 和[path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认使用了外部文件。

**是否支持外部工作簿的相对路径，它们如何存储？**  
是的。如果指定相对路径，它会自动转换为绝对路径。这对于项目可移植性很方便；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**我可以使用位于网络资源/共享上的工作簿吗？**  
可以，这类工作簿可以用作外部数据源。但不支持直接在 Aspose.Slides 中编辑远程工作簿—它们只能作为数据源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**  
不会。演示文稿会存储一个[link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) 并用于读取数据。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护，我该怎么办？**  
Aspose.Slides 在链接时不接受密码。常见做法是预先移除保护，或准备一个已解密的副本（例如使用[Aspose.Cells](/cells/php-java/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**  
可以。每个图表都有自己的链接。如果它们都指向同一个文件，更新该文件后，下次加载数据时每个图表都会反映出更改。