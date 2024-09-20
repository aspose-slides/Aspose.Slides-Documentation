---
title: Рабочая тетрадь диаграмм
type: docs
weight: 70
url: /php-java/chart-workbook/
keywords: "Рабочая тетрадь диаграмм, данные диаграмм, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Рабочая тетрадь диаграмм в презентации PowerPoint"
---

## **Установка данных диаграммы из рабочей тетради**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-), которые позволяют читать и записывать рабочие тетрадки данных диаграмм (содержащие данные диаграмм, редактированные с помощью Aspose.Cells). **Примечание:** данные диаграммы должны быть организованы в том же формате или иметь структуру, аналогичную исходным данным.

Этот код PHP демонстрирует пример операции:

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

## **Установка ячейки рабочей тетрадки как метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте круговую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку рабочей тетрадки в качестве метки данных.
1. Сохраните презентацию.

Этот код PHP показывает, как установить ячейку рабочей тетрадки в качестве метки данных диаграммы:

```php
  $lbl0 = "Значение ячейки метки 0";
  $lbl1 = "Значение ячейки метки 1";
  $lbl2 = "Значение ячейки метки 2";
  # Создает экземпляр класса презентации, который представляет файл презентации
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

## **Управление листами**

Этот код PHP демонстрирует операцию, в которой используется метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) для доступа к коллекции листов:

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

## **Указать тип источника данных**

Этот код PHP показывает, как указать тип для источника данных:

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

## **Внешняя рабочая тетрадь**

{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/) мы внедрили поддержку внешних рабочих тетрадей как источников данных для диаграмм.
{{% /alert %}} 

### **Создание внешней рабочей тетради**

С помощью методов **`readWorkbookStream`** и **`setExternalWorkbook`** вы можете либо создать внешнюю рабочую тетрадь с нуля, либо сделать внутреннюю рабочую тетрадь внешней.

Этот код PHP демонстрирует процесс создания внешней рабочей тетради:

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

### **Установка внешней рабочей тетради**

С помощью метода **`setExternalWorkbook`** вы можете назначить внешнюю рабочую тетрадь диаграмме в качестве источника данных. Этот метод также может быть использован для обновления пути к внешней рабочей тетради (если последняя была перемещена).

Хотя вы не можете редактировать данные в рабочих тетрадях, хранящихся в удаленных местах или ресурсах, вы все равно можете использовать такие рабочие тетради в качестве внешнего источника данных. Если предоставлен относительный путь для внешней рабочей тетради, он автоматически преобразуется в полный путь.

Этот код PHP показывает, как установить внешнюю рабочую тетрадь:

```php
  # Создает экземпляр класса Presentation
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

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружена рабочая тетрадь Excel или нет. 

* Когда значение `ChartData` установлено в `false`, только путь к рабочей тетради обновляется — данные диаграммы не будут загружены или обновлены из целевой рабочей тетради. Это значение может быть полезным, когда целевая рабочая тетрадь не существует или недоступна. 
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей тетради.

```php
  # Создает экземпляр класса Presentation
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

### **Получение пути к рабочей тетради внешнего источника данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на слайд по его индексу.
3. Создайте объект для фигуры диаграммы.
4. Создайте объект для типа источника (`ChartDataSourceType`), который представляет источник данных диаграммы.
5. Укажите соответствующее условие на основе того, что тип источника соответствует типу источника данных внешней рабочей тетради.

Этот код PHP демонстрирует операцию:

```php
  # Создает экземпляр класса Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Сохраняет презентацию
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих тетрадях так же, как и в содержимом внутренних рабочих тетрадей. Когда внешняя рабочая тетрадь не может быть загружена, возникает исключение.

Этот код PHP является реализацией описанного процесса:

```php
  # Создает экземпляр класса Presentation
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