---
title: Diagramm Arbeitsmappe
type: docs
weight: 70
url: /de/php-java/chart-workbook/
keywords: "Diagramm Arbeitsmappe, Diagrammdaten, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Diagramm Arbeitsmappe in PowerPoint-Präsentation "
---

## **Diagrammdaten aus Arbeitsmappe festlegen**
Aspose.Slides bietet die [ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--) und [WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-) Methoden, die es Ihnen ermöglichen, Diagrammdaten Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) zu lesen und zu schreiben. **Hinweis**: Die Diagrammdaten müssen auf die gleiche Weise organisiert oder eine ähnliche Struktur wie die Quelle haben.

Dieser PHP-Code demonstriert eine Beispieloperation:

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

## **Arbeitsmappe Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.
1. Greifen Sie auf die Diagrammserie zu.
1. Stellen Sie die Arbeitsmappe Zelle als Datenbeschriftung ein.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Arbeitsmappe Zelle als Diagrammdatenbeschriftung festlegen:

```php
  $lbl0 = "Beschriftung 0 Zellwert";
  $lbl1 = "Beschriftung 1 Zellwert";
  $lbl2 = "Beschriftung 2 Zellwert";
  # Erstellt eine Präsentationsklasse, die eine Präsentationsdatei repräsentiert
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

## **Arbeitsblätter verwalten**

Dieser PHP-Code demonstriert eine Operation, bei der die [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--) Methode verwendet wird, um auf eine Arbeitsblattsammlung zuzugreifen:

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

## **Datensatztyp festlegen**

Dieser PHP-Code zeigt Ihnen, wie Sie einen Typ für eine Datenquelle festlegen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NeueZelle"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Externe Arbeitsmappe**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/), haben wir die Unterstützung externer Arbeitsmappen als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Externe Arbeitsmappe erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieser PHP-Code demonstriert den Prozess der Erstellung einer externen Arbeitsmappe:

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

### **Externe Arbeitsmappe festlegen**

Mit der Methode **`setExternalWorkbook`** können Sie einer Diagramm eine externe Arbeitsmappe als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zur externen Arbeitsmappe zu aktualisieren (wenn Letztere verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entfernten Standorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen weiterhin als externe Datenquelle verwenden. Wenn der relative Pfad für eine externe Arbeitsmappe angegeben wird, wird dieser automatisch in einen vollständigen Pfad umgewandelt.

Dieser PHP-Code zeigt Ihnen, wie Sie eine externe Arbeitsmappe festlegen:

```php
  # Erstellt eine Instanz der Präsentationsklasse
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

Der `ChartData` Parameter (unter der Methode `setExternalWorkbook`) wird verwendet, um anzugeben, ob eine Excel-Arbeitsmappe geladen werden soll oder nicht. 

* Wenn der `ChartData` Wert auf `false` gesetzt ist, wird nur der Arbeitsmappenpfad aktualisiert—die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Sie möchten diese Einstellung möglicherweise verwenden, wenn die Zielarbeitsmappe nicht vorhanden oder nicht verfügbar ist. 
* Wenn der `ChartData` Wert auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```php
  # Erstellt eine Instanz der Präsentationsklasse
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

### **Pfad zur externen Datenquelle Arbeitsmappe abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Erstellen Sie ein Objekt für die Diagrammform.
1. Erstellen Sie ein Objekt für den Quelle (`ChartDataSourceType`) Typ, das die Datenquelle des Diagramms repräsentiert.
1. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp der gleiche ist wie der externe Arbeitsmappe-Datenquelle Typ.

Dieser PHP-Code demonstriert die Operation:

```php
  # Erstellt eine Instanz der Präsentationsklasse
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Speichert die Präsentation
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen auf die gleiche Weise bearbeiten, wie Sie Änderungen am Inhalt interner Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser PHP-Code ist eine Implementierung des beschriebenen Prozesses:

```php
  # Erstellt eine Instanz der Präsentationsklasse
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