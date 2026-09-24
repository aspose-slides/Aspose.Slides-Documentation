---
title: Diagramm-Arbeitsmappe in Präsentationen mit PHP verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/php-java/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externe Arbeitsmappe
- Externe Daten
- Diagramm-Cache
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für PHP via Java: Verwalten Sie Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte festlegt.

Außerdem wird die Arbeit mit externen Arbeitsmappen als Datenquellen für Diagramme behandelt. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten darstellen, siehe [Steuern Sie die Anzeige leerer Zellen](/slides/de/php-java/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**
Aspose.Slides stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#writeWorkbookStream) bereit, mit denen Sie Diagramm‑Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Der folgende PHP‑Code demonstriert einen Beispielvorgang:

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

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine geänderte ersetzen, behält das Diagramm seine ursprünglichen Reihen‑ und Kategorien‑Sammlungen bei. Diese Diskrepanz kann dazu führen, dass [Chart::validateChartLayout](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/validatechartlayout/) mit einem „index out of range“-Fehler fehlschlägt. Löschen Sie die vorhandenen Reihen und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben.

```php
// Nach dem Ändern des Arbeitsmappen-Streams (z. B. mit Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Vorhandene Datenreferenzen löschen.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass `validateChartLayout` ohne Fehler abgeschlossen werden kann.

## **Eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/php-java/aspose.slides/presentation) Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Bubble‑Diagramm mit einigen Daten hinzu.  
1. Greifen Sie auf die Diagramm‑Reihen zu.  
1. Legen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung fest.  
1. Speichern Sie die Präsentation.

Der folgende PHP‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instanziert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
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

Dieser PHP‑Code demonstriert einen Vorgang, bei dem die Methode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#getWorksheets) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Datentyp der Datenquelle festlegen**

Dieser PHP‑Code zeigt, wie Sie einen Typ für eine Datenquelle festlegen:

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

## **Nicht unterstützte eingebettete Arbeitsmappen‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet werden kann. Mit der Methode `getEmbeddedWorkbookType` auf [ChartData](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/php-java/aspose.slides/workbooktype/) können Sie nicht unterstützte Formate erkennen und diese Diagramme überspringen.

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
      # Eingebettete Arbeitsmappe ist im .xlsb-Format, das nicht unterstützt wird.
      continue;
    }

    # Diagramm-Arbeitsmappendaten hier lesen oder ändern.
  }
} finally {
  $presentation->dispose();
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt externe Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Der folgende PHP‑Code demonstriert den Erstellungsprozess einer externen Arbeitsmappe:

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

Mit der Methode **`setExternalWorkbook`** können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zu einer externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an Remote‑Standorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle verwenden. Wird ein relativer Pfad zu einer externen Arbeitsmappe angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Der folgende PHP‑Code zeigt, wie Sie eine externe Arbeitsmappe festlegen:

```php
  # Erstellt eine Instanz der Presentation-Klasse
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

Der Parameter `ChartData` (unter der Methode `setExternalWorkbook`) gibt an, ob eine Excel‑Arbeitsmappe geladen werden soll oder nicht.

* Wenn der Wert von `ChartData` auf `false` gesetzt ist, wird nur der Pfad der Arbeitsmappe aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn der Wert von `ChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```php
  # Erstellt eine Instanz der Presentation-Klasse
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

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/php-java/aspose.slides/presentation) Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Erzeugen Sie ein Objekt für das Diagramm‑Shape.  
1. Erzeugen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms repräsentiert.  
1. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Arbeitsmappe entspricht.

Der folgende PHP‑Code demonstriert den Vorgang:

```php
  # Erstellt eine Instanz der Presentation-Klasse
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

Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Kann eine externe Arbeitsmappe nicht geladen werden, wird eine Ausnahme ausgelöst.

Der folgende PHP‑Code implementiert den beschriebenen Prozess:

```php
  # Erstellt eine Instanz der Presentation-Klasse
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

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm eine externe Arbeitsmappe, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/), konfigurieren Sie es mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/spreadsheetoptions/), und rufen Sie [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) mit `true` auf, bevor Sie die Präsentation öffnen.

Das folgende PHP‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [Chart::getChartData](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/#getChartData) sowie [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Wiederhergestellte Arbeitsmappendaten hier lesen oder ändern.
} finally {
    $presentation->dispose();
}
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten als akzeptabler Rückgriff in Ordnung ist, da der Cache möglicherweise nicht die nach der letzten Aktualisierung der Präsentation an der externen Arbeitsmappe vorgenommenen Änderungen enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm besitzt einen [data source type](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getdatasourcetype/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getexternalworkbookpath/); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen auf Netzwerk‑Ressourcen/Freigaben verwenden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von Remote‑Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getexternalworkbookpath/) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht geändert.

**Was ist zu tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verlinken. Ein gängiger Ansatz besteht darin, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/php-java/)) vorzubereiten und darauf zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird ein Update dieser Datei in jedem Diagramm beim nächsten Laden der Daten reflektiert.