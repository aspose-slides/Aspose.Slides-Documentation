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
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для PHP через Java: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---

## **Чтение и запись данных диаграммы из рабочей книги**
Aspose.Slides предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) и [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) , которые позволяют читать и записывать рабочие книги данных диаграмм (содержащие данные диаграммы, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь схожую структуру с исходными.

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


## **Установить ячейку рабочей книги в качестве метки данных диаграммы**
1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. Получите ссылку на слайд по его индексу.
1. Добавьте пузырчатую диаграмму с некоторыми данными.
1. Получите доступ к сериям диаграммы.
1. Установите ячейку рабочей книги в качестве метки данных.
1. Сохраните презентацию.

Этот PHP‑код показывает, как установить ячейку рабочей книги в качестве метки данных диаграммы:
```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Создаёт экземпляр класса презентации, представляющего файл презентации
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
Этот PHP‑код демонстрирует операцию, в которой метод [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) используется для доступа к коллекции листов:
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
Этот PHP‑код показывает, как указать тип для источника данных:
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


## **Внешняя рабочая книга**
{{% alert color="primary" %}} 
В [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/), мы реализовали поддержку внешних рабочих книг в качестве источника данных для диаграмм.
{{% /alert %}} 

### **Создать внешнюю рабочую книгу**
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


### **Установить внешнюю рабочую книгу**
С помощью метода **`setExternalWorkbook`** вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, их всё равно можно использовать как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

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


Параметр `ChartData` (в методе `setExternalWorkbook`) используется для указания, будет ли загружена Excel‑рабочая книга.

* Когда значение `ChartData` установлено в `false`, обновляется только путь к рабочей книге — данные диаграммы не загружаются и не обновляются из целевой рабочей книги. Этот параметр может быть полезен, когда целевая рабочая книга отсутствует или недоступна. 
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


### **Получить путь к внешней рабочей книге-источнику данных диаграммы**
1. Создайте экземпляр класса [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. Получите ссылку на слайд по его индексу.
1. Создайте объект для формы диаграммы.
1. Создайте объект типа источника (`ChartDataSourceType`), представляющий источник данных диаграммы.
1. Укажите соответствующее условие, основываясь на том, что тип источника совпадает с типом внешней рабочей книги.

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


### **Редактировать данные диаграммы**
Вы можете редактировать данные во внешних рабочих книгах так же, как вносите изменения в содержимое внутренних рабочих книг. Если внешнюю рабочую книгу загрузить не удалось, будет выброшено исключение.

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


## **Часто задаваемые вопросы**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [тип источника данных](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) и [путь к внешней рабочей книге](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если указать относительный путь, он автоматически преобразуется в абсолютный. Это удобно для переносимости проекта; однако имейте в виду, что презентация сохраняет абсолютный путь в файле PPTX.

**Могу ли я использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых рабочих книг через Aspose.Slides не поддерживается — их можно использовать только в качестве источника.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Нет. Презентация сохраняет [ссылку на внешний файл](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) которую использует для чтения данных. Сам внешний файл не изменяется при сохранении презентации.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при установке ссылки. Обычный подход — заранее снять защиту или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](/cells/php-java/)) и ссылаться на эту копию.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.