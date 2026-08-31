---
title: Управление рабочими книгами диаграмм в презентациях с использованием PHP
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/php-java/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Ознакомьтесь с Aspose.Slides для PHP через Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Показано, как читать и записывать данные диаграмм через потоки рабочих книг, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграммы. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

## **Чтение и запись данных диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [readWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#readWorkbookStream) и [writeWorkbookStream](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#writeWorkbookStream), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Важно**: данные диаграммы должны быть организованы одинаково или иметь структуру, схожую с исходной.

Этот PHP‑код демонстрирует пример операции:

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

### **Проверка макета диаграммы после изменения рабочей книги**

При замене вложенной рабочей книги на изменённую диаграмма сохраняет оригинальные коллекции рядов и категорий. Такое несоответствие может вызвать ошибку в [Chart::validateChartLayout](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/validatechartlayout/) с сообщением «index out of range». Очистите существующие ряды и категории перед записью обновлённой рабочей книги обратно в диаграмму.

```php
// После изменения потока рабочей книги (например, используя Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Очистить существующие ссылки на данные.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Очистка коллекций гарантирует согласованность структуры данных диаграммы с новой рабочей книгой, позволяя `validateChartLayout` завершиться без ошибок.

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырчатую диаграмму с некоторыми данными.
1. Получите доступ к рядам диаграммы.
1. Установите ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

Этот PHP‑код показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Создаёт объект класса презентации, представляющий файл презентации
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

Этот PHP‑код демонстрирует операцию, в которой используется метод [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdataworkbook/#getWorksheets) для доступа к коллекции листов:

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

## **Указание типа источника данных**

Этот PHP‑код показывает, как указать тип источника данных:

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

## **Обнаружение неподдерживаемых форматов вложенных рабочих книг**

Aspose.Slides не поддерживает формат бинарных рабочих книг Excel (.xlsb), которые могут быть встроены в некоторые диаграммы. Вы можете использовать метод `getEmbeddedWorkbookType` у [ChartData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # Встроенная рабочая книга в формате .xlsb, который не поддерживается.
      continue;
    }

    # Здесь чтение или изменение данных рабочей книги диаграммы.
  }
} finally {
  $presentation->dispose();
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает внешние рабочие книги в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

С помощью методов **`readWorkbookStream`** и **`setExternalWorkbook`** вы можете либо создать внешнюю рабочую книгу с нуля, либо сделать внутреннюю рабочую книгу внешней.

Этот PHP‑код демонстрирует процесс создания внешней рабочей книги:

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

### **Установка внешней рабочей книги**

Метод **`setExternalWorkbook`** позволяет назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот же метод можно использовать для обновления пути к внешней рабочей книге (если файл был перемещён).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот PHP‑код показывает, как установить внешнюю рабочую книгу:

```php
  # Создаёт экземпляр класса Presentation
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

Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружаться Excel‑рабочая книга.

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой книги. Такой вариант полезен, если целевая рабочая книга отсутствует или недоступна.
* Когда значение `ChartData` установлено в `true`, данные диаграммы обновляются из целевой рабочей книги.

```php
  # Создаёт экземпляр класса Presentation
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

### **Получение пути к внешнему источнику данных рабочей книги диаграммы**

1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект для типа источника (`ChartDataSourceType`), представляющего источник данных диаграммы.
1. Укажите соответствующее условие в зависимости от того, совпадает ли тип источника с типом внешней рабочей книги.

Этот PHP‑код демонстрирует операцию:

```php
  # Создаёт экземпляр класса Presentation
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

Вы можете редактировать данные во внешних рабочих книгах так же, как изменяете содержимое внутренних книг. Если внешняя рабочая книга не может быть загружена, будет выброшено исключение.

Этот PHP‑код реализует описанный процесс:

```php
  # Создаёт экземпляр класса Presentation
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

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из данных, закешированных в презентации. Создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/), настройте его с помощью [SpreadsheetOptions](https://reference.aspose.com/slides/ru/php-java/aspose.slides/spreadsheetoptions/), и вызовите [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) со значением `true` перед открытием презентации.

Следующий пример на PHP открывает презентацию, в которой диаграмма ссылается на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [Chart::getChartData](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/#getChartData) и [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Чтение или изменение восстановленных данных рабочей книги здесь.
} finally {
    $presentation->dispose();
}
```

Если внешняя рабочая книга недоступна, а восстановление отключено, Aspose.Slides генерирует исключение. Включайте восстановление только тогда, когда использование закешированных данных диаграммы приемлемо, так как кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getdatasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя рабочая книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они сохраняются?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако в файле PPTX сохраняется абсолютный путь.

**Можно ли использовать рабочие книги, находящиеся на сетевых ресурсах/общих папках?**

Да, такие книги могут быть использованы как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — они могут лишь служить источником.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chartdata/getexternalworkbookpath/) и использует её только для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно сначала снимают защиту или подготавливают расшифрованную копию (например, с помощью [Aspose.Cells](/cells/php-java/)) и ссылаются на неё.

**Могут ли несколько диаграмм сослаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один файл, изменение этого файла будет отражено в каждой диаграмме при следующей загрузке данных.