---
title: Erstellen oder Aktualisieren von PowerPoint-Diagrammen in PHP
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/php-java/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Scatter-Diagramm
- Kreisdiagramm
- Liniendiagramm
- Baumkarten-Diagramm
- Börsendiagramm
- Box‑und‑Whisker‑Diagramm
- Trichterdiagramm
- Sunburst-Diagramm
- Histogramm-Diagramm
- Radar‑Diagramm
- Mehrkategorien‑Diagramm
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Codebeispielen."
---
## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung zum Erstellen und Anpassen von Diagrammen mit Aspose.Slides. Sie lernen, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, vom Initialisieren der Präsentation und des Diagrammobjekts bis hin zur Konfiguration von Reihen, Achsen und Legenden. Durch Befolgung dieser Anleitung erhalten Sie ein fundiertes Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und den Prozess der Erstellung datengetriebener Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen, Daten schnell zu visualisieren und Einsichten zu gewinnen, die aus einer Tabelle oder einem Spreadsheet nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzelnen Folie einer Präsentation aggregieren, verdichten oder zusammenfassen
* Muster und Trends in Daten aufzeigen
* die Richtung und Dynamik von Daten über die Zeit oder bezogen auf eine bestimmte Einheit ableiten
* Ausreißer, Anomalien, Abweichungen, Fehler, unsinnige Daten usw. erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Note" %}}

Um Diagramme zu erstellen, verwenden Sie die [ChartType](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/)‑Klasse. Die Felder in dieser Klasse entsprechen verschiedenen Diagrammtypen.

{{% /alert %}}

### **Gruppierte Säulendiagramme erstellen**

Dieser Abschnitt erklärt, wie Sie gruppierte Säulendiagramme mit Aspose.Slides erstellen. Sie lernen, eine Präsentation zu initialisieren, ein Diagramm hinzuzufügen und dessen Elemente wie Titel, Daten, Reihen, Kategorien und Stil anzupassen. Folgen Sie den untenstehenden Schritten, um zu sehen, wie ein Standard‑Gruppiertes‑Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType::ClusteredColumn` an.
1. Fügen Sie dem Diagramm einen Titel hinzu.
1. Greifen Sie auf das Daten‑Arbeitsblatt des Diagramms zu.
1. Löschen Sie alle Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Wenden Sie eine Füllfarbe auf die Diagramm‑Reihen an.
1. Fügen Sie Beschriftungen zu den Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C#‑Code demonstriert, wie ein gruppiertes Säulendiagramm erstellt wird:

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt ein Diagramm mit den Standarddaten hinzu
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Setzt den Diagrammtitel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Setzt die erste Serie, um Werte anzuzeigen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Setzt den Index für das Diagrammdatenblatt
    $defaultWorksheetIndex = 0;
    # Holt das Diagrammdaten-Arbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Löscht die standardmäßig erzeugten Serien und Kategorien
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Fügt neue Serien hinzu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Fügt neue Kategorien hinzu
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Nimmt die erste Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Füllt jetzt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Setzt die Füllfarbe für die Serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Nimmt die zweite Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Füllt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Setzt die Füllfarbe für die Serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Erstellt benutzerdefinierte Beschriftungen für jede Kategorie für die neue Serie
    # Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Zeigt den Wert für die dritte Beschriftung
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Speichert die Präsentation mit dem Diagramm
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Scatter‑Diagramme erstellen**

Scatter‑Diagramme (auch Streudiagramme oder x‑y‑Grafiken genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu zeigen.

Verwenden Sie ein Scatter‑Diagramm, wenn:

* Sie gepaarte numerische Daten haben
* Sie zwei Variablen haben, die gut zusammenpassen
* Sie bestimmen möchten, ob zwei Variablen miteinander verknüpft sind
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable besitzt

1. Folgen Sie den Schritten unter [Create Clustered Column Charts](#create-clustered-column-charts).
2. Für den dritten Schritt fügen Sie ein Diagramm mit einigen Daten hinzu und geben Ihren Diagrammtyp als einen der folgenden an:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Stellt ein Scatter‑Diagramm dar._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stellt ein Scatter‑Diagramm dar, das mit Kurven verbunden ist und Daten‑Marker enthält._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Stellt ein Scatter‑Diagramm dar, das mit Kurven verbunden ist, ohne Daten‑Marker._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stellt ein Scatter‑Diagramm dar, das mit Geraden verbunden ist und Daten‑Marker enthält._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Stellt ein Scatter‑Diagramm dar, das mit Geraden verbunden ist, ohne Daten‑Marker._

Dieser PHP‑Code zeigt, wie ein Scatter‑Diagramm mit unterschiedlichen Markern für jede Reihe erstellt wird:

```php
  # Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Erstellt das Standarddiagramm
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Holt den Standard‑Diagrammdaten‑Arbeitsblatt‑Index
    $defaultWorksheetIndex = 0;
    # Holt das Diagrammdaten‑Arbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Löscht die Demo‑Serien
    $chart->getChartData()->getSeries()->clear();
    # Fügt neue Serien hinzu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Nimmt die erste Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Fügt der Serie einen neuen Punkt (1:3) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Fügt einen neuen Punkt (2:10) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Ändert den Seriotyp
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Ändert den Diagrammserien‑Marker
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Nimmt die zweite Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Fügt dort einen neuen Punkt (5:2) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Fügt einen neuen Punkt (3:1) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Fügt einen neuen Punkt (2:2) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Fügt einen neuen Punkt (5:1) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Ändert den Diagrammserien‑Marker
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Enthält Ihr Datensatz jedoch viele Teile oder Beschriftungen, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::Pie](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Pie) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Fügen Sie neue Punkte für das Diagramm hinzu und wenden Sie benutzerdefinierte Farben auf die Segmente des Kreisdiagramms an.
9. Setzen Sie Beschriftungen für die Reihen.
10. Aktivieren Sie Führungs‑Linien für die Reihen‑Beschriftungen.
11. Legen Sie den Rotationswinkel für die Segmente des Kreisdiagramms fest.
12. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Kreisdiagramm erstellt wird:

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $slides = $pres->getSlides()->get_Item(0);
    # Fügt ein Diagramm mit Standarddaten hinzu
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Setzt den Diagrammtitel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Setzt die erste Serie, um Werte anzuzeigen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Setzt den Index für das Diagrammdatenblatt
    $defaultWorksheetIndex = 0;
    # Holt das Diagrammdaten‑Arbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Löscht die standardmäßig erzeugten Serien und Kategorien
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Fügt neue Kategorien hinzu
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Fügt neue Serien hinzu
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Füllt die Seriendaten
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Funktioniert in neuer Version nicht
    # Adding new points and setting sector color
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Setzt den Sektor‑Rand
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Setzt den Sektor‑Rand
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Setzt den Sektor‑Rand
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Zeigt Führungs­linien für das Diagramm an
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Speichert die Präsentation mit einem Diagramm
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich am besten, wenn Sie Änderungen von Werten über die Zeit darstellen möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Änderungen und Trends über die Zeit verfolgen, Anomalien in Datenreihen hervorheben und mehr.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::Line](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Line) an.
1. Greifen Sie auf das Diagramm‑Daten‑Workbook ([ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Liniendiagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Standardmäßig werden die Punkte in einem Liniendiagramm durch gerade kontinuierliche Linien verbunden. Wenn Sie stattdessen gestrichelte Linien wünschen, können Sie Ihren bevorzugten Strichtyp wie folgt angeben:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Baumkarten‑Diagramme erstellen**

Baumkarten‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und schnell auf Elemente aufmerksam machen möchten, die große Beiträge innerhalb jeder Kategorie leisten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::Treemap](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Treemap) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Baumkarten‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # Zweig 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # Zweig 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Börsendiagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#OpenHighLowClose) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Geben Sie das Format für die Hoch‑Niedrig‑Linien an.
9. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Börsendiagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Box‑und‑Whisker‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#BoxAndWhisker) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Box‑und‑Whisker‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Trichter‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::Funnel](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Funnel) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Trichter‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Sunburst‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::Sunburst](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Sunburst) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Sunburst‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # Zweig 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # Zweig 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Histogramm‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::Histogram](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Histogram) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Histogramm‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Radar‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp ([ChartType::Radar](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#Radar) in diesem Fall) an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Radar‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Mehrkategorien‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ [ChartType::ClusteredColumn](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/#ClusteredColumn) an.
4. Greifen Sie auf das Diagramm‑Daten‑Workbook [ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/) zu.
5. Löschen Sie die Standard‑Reihen und -Kategorien.
6. Fügen Sie neue Reihen und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
8. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Mehrkategorien‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Serien hinzufügen
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Präsentation mit Diagramm speichern
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Karten‑Diagramme erstellen**

Karten‑Diagramme visualisieren geografische Daten und helfen, Werte über Regionen hinweg zu vergleichen.

Dieser PHP‑Code zeigt, wie ein Karten‑Diagramm erstellt wird:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen mehreren Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und Beziehungen zwischen ihnen zu erkennen.

![Das Kombinationsdiagramm](combination_chart.png)

Der folgende PHP‑Code zeigt, wie das oben gezeigte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellt wird:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Setze den Diagrammtitel.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Setze die Diagrammlegende.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Lösche die standardmäßig erzeugten Serien und Kategorien.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Neue Kategorien hinzufügen.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Erste Serie hinzufügen.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Setze die horizontale Achse.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Setze die vertikale Achse.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Setze die Farbe der vertikalen Hauptgitterlinien.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Setze die sekundäre horizontale Achse.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Setze die sekundäre vertikale Achse.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Diagramme aktualisieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse, die die Präsentation mit dem zu aktualisierenden Diagramm darstellt.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Daten‑Arbeitsblatt des Diagramms zu.
5. Ändern Sie die Diagrammdaten‑Reihen, indem Sie die Reihenwerte anpassen.
6. Fügen Sie eine neue Reihe hinzu und füllen Sie deren Daten.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Diagramm aktualisiert wird:

```php
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Diagramm mit Standarddaten holen
    $chart = $sld->getShapes()->get_Item(0);
    # Index des Diagrammdatenblatts festlegen
    $defaultWorksheetIndex = 0;
    # Diagrammdaten-Arbeitsblatt abrufen
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Ändern des Diagramm‑Kategorienamens
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Erste Diagrammserie nehmen
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Jetzt werden die Seriendaten aktualisiert
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Seriennamen ändern

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Zweite Diagrammserie nehmen
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Jetzt werden die Seriendaten aktualisiert
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Seriennamen ändern

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Jetzt eine neue Serie hinzufügen
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Dritte Diagrammserie nehmen
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Jetzt werden die Seriendaten befüllt
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Präsentation mit Diagramm speichern
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Datenbereich für ein Diagramm festlegen**

Um den Datenbereich für ein Diagramm festzulegen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse, die die Präsentation mit dem Diagramm darstellt.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie der Datenbereich für ein Diagramm festgelegt wird:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Reihe automatisch ein unterschiedliches Markersymbol.

Dieser PHP‑Code zeigt, wie ein Diagramm‑Reihen‑Marker automatisch gesetzt wird:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Zweite Diagrammserie nehmen
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Jetzt werden die Seriendaten befüllt
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt eine breite Palette von [chart types](https://reference.aspose.com/slides/de/php-java/aspose.slides/charttype/), darunter Balken, Linien, Kreis, Flächen, Scatter, Histogramm, Radar und viele mehr. Diese Flexibilität erlaubt es Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung auszuwählen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zuerst eine Instanz der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Klasse, holen Sie die gewünschte Folie über deren Index und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf das zugehörige Daten‑Workbook ([ChartDataWorkbook](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdataworkbook/)) zugreifen, alle Standard‑Reihen und -Kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. Dadurch können Sie das Diagramm mit den neuesten Daten aktualisieren.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere [formatting elements](/slides/de/php-java/chart-entities/) ändern, um das Erscheinungsbild des Diagramms an Ihre spezifischen Designanforderungen anzupassen.