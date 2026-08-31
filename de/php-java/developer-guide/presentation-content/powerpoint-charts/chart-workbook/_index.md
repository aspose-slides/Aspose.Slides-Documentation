---
title: Diagramm‑Workbooks in Präsentationen mit PHP verwalten
linktitle: Diagramm‑Workbook
type: docs
weight: 70
url: /de/php-java/chart-workbook/
keywords:
- Diagramm‑Workbook
- Diagrammdaten
- Workbook‑Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externes Workbook
- Externe Daten
- Diagramm‑Cache
- Workbook‑Wiederherstellung
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für PHP über Java: Verwalten Sie Diagramm‑Workbooks in PowerPoint‑ und OpenDocument‑Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Diagrammdatenquellen. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines mit einem Diagramm verknüpften externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

## **Diagrammdaten aus einem Workbook lesen und schreiben**
Aspose.Slides stellt die [readWorkbookStream](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#writeWorkbookStream) Methoden zur Verfügung, mit denen Sie Diagrammdaten‑Workbooks lesen und schreiben können (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis**: Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine dem Quell‑Workbook ähnliche Struktur aufweisen.

Dieser PHP‑Code demonstriert einen Beispielvorgang:

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

### **Diagrammlayout nach Workbook‑Änderung validieren**

Wenn Sie ein eingebettetes Workbook durch ein geändertes ersetzen, behält das Diagramm seine ursprünglichen Reihen‑ und Kategorien‑Sammlungen bei. Diese Diskrepanz kann dazu führen, dass [Chart::validateChartLayout](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/validatechartlayout/) mit einem „index-out-of-range“-Fehler fehlschlägt. Löschen Sie die vorhandenen Reihen und Kategorien, bevor Sie das aktualisierte Workbook zurück in das Diagramm schreiben.

```php
// Nach dem Ändern des Workbook-Streams (z. B. mit Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Vorhandene Datenreferenzen löschen.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit dem neuen Workbook übereinstimmt, sodass `validateChartLayout` ohne Fehler abgeschlossen werden kann.

## **Eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/php-java/aspose.slides/presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein Bubble‑Diagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagramm‑Reihen zu.  
5. Setzen Sie die Workbook‑Zelle als Datenbeschriftung.  
6. Speichern Sie die Präsentation.

Dieser PHP‑Code zeigt, wie Sie eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen:

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

Dieser PHP‑Code demonstriert einen Vorgang, bei dem die [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/#getWorksheets) Methode verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Nicht unterstützte eingebettete Workbook‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode `getEmbeddedWorkbookType` auf [ChartData](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/php-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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
      # Eingebettetes Workbook ist im .xlsb-Format, das nicht unterstützt wird.
      continue;
    }

    # Hier das Diagramm-Workbook lesen oder ändern.
  }
} finally {
  $presentation->dispose();
}
```

## **Externes Workbook**

Aspose.Slides unterstützt externe Workbooks als Datenquelle für Diagramme.

### **Ein externes Workbook erstellen**

Mit den Methoden **`readWorkbookStream`** und **`setExternalWorkbook`** können Sie entweder ein externes Workbook von Grund auf neu erstellen oder ein internes Workbook extern machen.

Dieser PHP‑Code demonstriert den Erstellungsprozess für ein externes Workbook:

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

### **Externes Workbook zuweisen**

Mit der Methode **`setExternalWorkbook`** können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (falls dieses verschoben wurde).

Während Sie die Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Workbooks dennoch als externe Datenquelle verwenden. Wird ein relativer Pfad für ein externes Workbook angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieser PHP‑Code zeigt, wie Sie ein externes Workbook zuweisen:

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

Der `ChartData`‑Parameter (unter der `setExternalWorkbook`‑Methode) gibt an, ob ein Excel‑Workbook geladen wird oder nicht.

* Wenn der `ChartData`‑Wert auf `false` gesetzt ist, wird nur der Workbook‑Pfad aktualisiert — die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn das Ziel‑Workbook nicht existiert oder nicht verfügbar ist.  
* Wenn der `ChartData`‑Wert auf `true` gesetzt ist, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

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

### **Pfad des externen Datenquellen‑Workbooks eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/de/php-java/aspose.slides/presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Erstellen Sie ein Objekt für die Diagramm‑Form (ChartShape).  
4. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), der die Datenquelle des Diagramms repräsentiert.  
5. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp dem externen Workbook‑Datenquellentyp entspricht.

Dieser PHP‑Code demonstriert den Vorgang:

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

Sie können die Daten in externen Workbooks auf die gleiche Weise bearbeiten, wie Sie den Inhalt interner Workbooks ändern. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

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

### **Ein Workbook aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm ein externes Workbook verwendet, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/), konfigurieren Sie sie mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/spreadsheetoptions/), und rufen Sie [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) mit `true` auf, bevor Sie die Präsentation öffnen.

Das folgende PHP‑Beispiel öffnet eine Präsentation, deren Diagramm ein nicht verfügbares externes Workbook referenziert, und greift über [Chart::getChartData](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/#getChartData) und [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Wiederhergestellte Workbook-Daten hier lesen oder bearbeiten.
} finally {
    $presentation->dispose();
}
```

Ist das externe Workbook nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der im Cache gespeicherten Diagrammdaten ein akzeptabler Rückfall ist, da der Cache möglicherweise Änderungen am externen Workbook nach der letzten Aktualisierung der Präsentation nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getdatasourcetype/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getexternalworkbookpath/); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Workbooks über Aspose.Slides wird jedoch nicht unterstützt — sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdata/getexternalworkbookpath/) und verwendet diesen zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mithilfe von [Aspose.Cells](/cells/php-java/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei bei jedem Laden der Diagrammdaten in allen Diagrammen wirksam.