---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in PHP
linktitle: Diagramm erstellen
type: docs
weight: 10
url: /de/php-java/create-chart/
keywords: "Diagramm erstellen, Streudiagramm, Kreisdiagramm, Baumkarten-Diagramm, Aktien-Diagramm, Box und Whisker Diagramm, Histogramm-Diagramm, Trichterdiagramm, Sonnenstrahl-Diagramm, Mehrkategorien-Diagramm, PowerPoint-Präsentation, Java, Aspose.Slides für PHP via Java"
description: "Diagramm in PowerPoint-Präsentation erstellen"
---

## Überblick

Dieser Artikel beschreibt, wie man **PowerPoint-Präsentationsdiagramme in Java** erstellt. Sie können die Diagramme auch **aktualisieren**. Folgende Themen werden behandelt.

_Diagramm_: **Normal**
- [Java PowerPoint-Diagramm erstellen](#java-create-powerpoint-chart)
- [Java Präsentationsdiagramm erstellen](#java-create-presentation-chart)
- [Java PowerPoint-Präsentationsdiagramm erstellen](#java-create-powerpoint-presentation-chart)

_Diagramm_: **Gestreut**
- [Java Gestreutes Diagramm erstellen](#java-create-scattered-chart)
- [Java PowerPoint-Gestreutes Diagramm erstellen](#java-create-powerpoint-scattered-chart)
- [Java PowerPoint-Präsentationsgestreutes Diagramm erstellen](#java-create-powerpoint-presentation-scattered-chart)

_Diagramm_: **Kreis**
- [Java Kreisdiagramm erstellen](#java-create-pie-chart)
- [Java PowerPoint-Kreisdiagramm erstellen](#java-create-powerpoint-pie-chart)
- [Java PowerPoint-Präsentationskreisdiagramm erstellen](#java-create-powerpoint-presentation-pie-chart)

_Diagramm_: **Baumkarte**
- [Java Baumkartendiagramm erstellen](#java-create-tree-map-chart)
- [Java PowerPoint-Baumkartendiagramm erstellen](#java-create-powerpoint-tree-map-chart)
- [Java PowerPoint-Präsentationsbaumkartendiagramm erstellen](#java-create-powerpoint-presentation-tree-map-chart)

_Diagramm_: **Aktie**
- [Java Aktiendiagramm erstellen](#java-create-stock-chart)
- [Java PowerPoint-Aktiendiagramm erstellen](#java-create-powerpoint-stock-chart)
- [Java PowerPoint-Präsentationsaktiendiagramm erstellen](#java-create-powerpoint-presentation-stock-chart)

_Diagramm_: **Box‑ und Whisker**
- [Java Box‑ und Whisker‑Diagramm erstellen](#java-create-box-and-whisker-chart)
- [Java PowerPoint‑Box‑ und Whisker‑Diagramm erstellen](#java-create-powerpoint-box-and-whisker-chart)
- [Java PowerPoint‑Präsentations‑Box‑ und Whisker‑Diagramm erstellen](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Diagramm_: **Trichter**
- [Java Trichter‑Diagramm erstellen](#java-create-funnel-chart)
- [Java PowerPoint‑Trichter‑Diagramm erstellen](#java-create-powerpoint-funnel-chart)
- [Java PowerPoint‑Präsentations‑Trichter‑Diagramm erstellen](#java-create-powerpoint-presentation-funnel-chart)

_Diagramm_: **Sonnenstrahl**
- [Java Sonnenstrahl‑Diagramm erstellen](#java-create-sunburst-chart)
- [Java PowerPoint‑Sonnenstrahl‑Diagramm erstellen](#java-create-powerpoint-sunburst-chart)
- [Java PowerPoint‑Präsentations‑Sonnenstrahl‑Diagramm erstellen](#java-create-powerpoint-presentation-sunburst-chart)

_Diagramm_: **Histogramm**
- [Java Histogramm‑Diagramm erstellen](#java-create-histogram-chart)
- [Java PowerPoint‑Histogramm‑Diagramm erstellen](#java-create-powerpoint-histogram-chart)
- [Java PowerPoint‑Präsentations‑Histogramm‑Diagramm erstellen](#java-create-powerpoint-presentation-histogram-chart)

_Diagramm_: **Radar**
- [Java Radar‑Diagramm erstellen](#java-create-radar-chart)
- [Java PowerPoint‑Radar‑Diagramm erstellen](#java-create-powerpoint-radar-chart)
- [Java PowerPoint‑Präsentations‑Radar‑Diagramm erstellen](#java-create-powerpoint-presentation-radar-chart)

_Diagramm_: **Mehrere Kategorien**
- [Java Mehrkategorien‑Diagramm erstellen](#java-create-multi-category-chart)
- [Java PowerPoint‑Mehrkategorien‑Diagramm erstellen](#java-create-powerpoint-multi-category-chart)
- [Java PowerPoint‑Präsentations‑Mehrkategorien‑Diagramm erstellen](#java-create-powerpoint-presentation-multi-category-chart)

_Diagramm_: **Karte**
- [Java Kartendiagramm erstellen](#java-create-map-chart)
- [Java PowerPoint‑Kartendiagramm erstellen](#java-create-powerpoint-map-chart)
- [Java PowerPoint‑Präsentations‑Kartendiagramm erstellen](#java-create-powerpoint-presentation-map-chart)

_Aktion_: **Diagramm aktualisieren**
- [Java PowerPoint‑Diagramm aktualisieren](#java-update-powerpoint-chart)
- [Java Präsentations‑Diagramm aktualisieren](#java-update-presentation-chart)
- [Java PowerPoint‑Präsentations‑Diagramm aktualisieren](#java-update-powerpoint-presentation-chart)


## **Diagramm erstellen**
Diagramme helfen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet nicht sofort ersichtlich sind. 


**Warum Diagramme erstellen?**

Mit Diagrammen können Sie

* große Datenmengen auf einer einzigen Folie zusammenfassen, kondensieren oder aggregieren
* Muster und Trends in den Daten sichtbar machen
* die Richtung und das Momentum der Daten über die Zeit oder bezogen auf eine bestimmte Maßeinheit ableiten
* Ausreißer, Anomalien, Abweichungen, Fehler oder unsinnige Daten erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Einfügefunktion erstellen, die Vorlagen für zahlreiche Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf gängigen Diagrammtypen) sowie benutzerdefinierte Diagramme erzeugen. 

{{% alert color="primary" %}} 

Damit Sie Diagramme erstellen können, stellt Aspose.Slides die [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType)-Klasse bereit. Die Felder dieser Klasse entsprechen den verschiedenen Diagrammtypen.

{{% /alert %}} 

### **Normale Diagramme erstellen**

_Schritte: Diagramm erstellen_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint‑Diagramm erstellen</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Schritte:</em> Präsentations‑Diagramm erstellen</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Diagramm erstellen</strong></a>

_Code‑Schritte:_

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie den gewünschten Diagrammtyp an. 
4. Ergänzen Sie dem Diagramm einen Titel. 
5. Greifen Sie auf das Arbeitsblatt für Diagrammdaten zu.
6. Löschen Sie alle voreingestellten Serien und Kategorien.
7. Fügen Sie neue Serien und Kategorien hinzu.
8. Ergänzen Sie neue Daten für die Diagrammserien. 
9. Legen Sie eine Füllfarbe für die Serien fest. 
10. Fügen Sie Beschriftungen für die Serien hinzu. 
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines normalen Diagramms:
```php
  # Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt ein Diagramm mit Standarddaten hinzu
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Setzt den Diagrammtitel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Setzt die erste Serie, um Werte anzuzeigen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Legt den Index für das Diagrammdatenblatt fest
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
    # Befüllt jetzt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Setzt die Füllfarbe für die Serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Nimmt die zweite Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Befüllt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Setzt die Füllfarbe für die Serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Erstellt benutzerdefinierte Beschriftungen für jede Kategorie der neuen Serie
    # Setzt die erste Beschriftung, um den Kategorienamen anzuzeigen
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Zeigt den Wert für die dritte Beschriftung an
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Speichert die Präsentation mit Diagramm
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Gestreute Diagramme erstellen**
Gestreute Diagramme (auch Scatter‑Plots oder X‑Y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu verdeutlichen. 

Ein gestreutes Diagramm ist sinnvoll, wenn

* Sie gepaarte numerische Daten besitzen
* Sie zwei gut zusammenpassende Variablen haben
* Sie feststellen möchten, ob zwei Variablen miteinander zusammenhängen
* Sie eine unabhängige Variable mit mehreren Werten für eine abhängige Variable besitzen

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Schritte:</em> Gestreutes Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Schritte:</em> PowerPoint‑Gestreutes Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Gestreutes Diagramm erstellen</strong></a>

1. Bitte folgen Sie den bereits beschriebenen Schritten unter [Normale Diagramme erstellen](#creating-normal-charts)
2. Für den dritten Schritt wählen Sie einen der folgenden Diagrammtypen:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) – _Streudiagramm mit Markierungen._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) – _Streudiagramm, das durch Kurven verbunden ist, mit Markierungen._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) – _Streudiagramm, das durch Kurven verbunden ist, ohne Markierungen._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) – _Streudiagramm, das durch gerade Linien verbunden ist, mit Markierungen._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) – _Streudiagramm, das durch gerade Linien verbunden ist, ohne Markierungen._

Dieser PHP‑Code demonstriert das Erstellen gestreuter Diagramme mit unterschiedlichen Markierungssätzen:
```php
  # Instanziert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Erstellt das Standarddiagramm
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Ermittelt den Index des Standard-Diagrammdaten-Arbeitsblatts
    $defaultWorksheetIndex = 0;
    # Ermittelt das Diagrammdaten-Arbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Löscht die Demo-Serien
    $chart->getChartData()->getSeries()->clear();
    # Fügt neue Serien hinzu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Nimmt die erste Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Fügt einen neuen Punkt (1:3) zur Serie hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Fügt einen neuen Punkt (2:10) hinzu
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Ändert den Serientyp
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Ändert das Diagrammserien-Marker
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
    # Ändert das Diagrammserien-Marker
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

Kreisdiagramme eignen sich besonders, um die Verhältnis­beziehung von Teilen zum Ganzen darzustellen, vor allem wenn die Daten kategoriale Bezeichnungen mit numerischen Werten enthalten. Enthält Ihre Daten jedoch sehr viele Teile oder Beschriftungen, sollten Sie lieber ein Balkendiagramm verwenden.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Schritte:</em> Kreisdiagramm erstellen</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Schritte:</em> PowerPoint‑Kreisdiagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Kreisdiagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier: [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie) hinzu.
4. Greifen Sie auf das Diagrammdaten‑[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Fügen Sie neue Punkte hinzu und definieren Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms.
9. Setzen Sie Beschriftungen für die Serien.
10. Definieren Sie Führungslinien für die Serienbeschriftungen.
11. Legen Sie den Rotationswinkel für das Kreisdiagramm fest.
12. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Kreisdiagramms:
```php
  # Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
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
    # Holt das Diagrammdaten-Arbeitsblatt
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
    # Befüllt die Seriendaten
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Funktioniert in neuer Version nicht
    # Hinzufügen neuer Punkte und Festlegen der Sektorfarbe
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Setzt die Sektorlinie
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Setzt die Sektorlinie
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Setzt die Sektorlinie
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
    # Zeigt Führungslinien für das Diagramm
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Setzt den Rotationswinkel für die Kuchen-Chart-Sektoren
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

Liniendiagramme (auch Liniendiagramme genannt) eignen sich besonders, um Änderungen von Werten über die Zeit hinweg zu visualisieren. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Trends über die Zeit verfolgen, Anomalien in Datenreihen hervorheben usw.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (`ChartType::Line`) hinzu.
4. Greifen Sie auf das Diagrammdaten‑IChartDataWorkbook zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Liniendiagramms:
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


Standardmäßig werden die Punkte eines Liniendiagramms durch gerade, durchgehende Linien verbunden. Möchten Sie stattdessen gestrichelte Linien, können Sie den gewünschten Strichtyp wie folgt festlegen:
```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```


### **Baumkartendiagramme erstellen**

Baumkartendiagramme eignen sich besonders für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien darstellen und gleichzeitig schnell die Elemente hervorheben möchten, die maßgeblich zu jeder Kategorie beitragen.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Schritte:</em> Baumkartendiagramm erstellen</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Schritte:</em> PowerPoint‑Baumkartendiagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Baumkartendiagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier: [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap) hinzu.
4. Greifen Sie auf das Diagrammdaten‑[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Baumkartendiagramms:
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


### **Aktiendiagramme erstellen**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Schritte:</em> Aktiendiagramm erstellen</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Schritte:</em> PowerPoint‑Aktiendiagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Aktiendiagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose) hinzu.
4. Greifen Sie auf das Diagrammdaten‑[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Definieren Sie das Format für HiLowLines.
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Beispiel‑PHP‑Code zum Erstellen eines Aktiendiagramms:
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
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Box‑ und Whisker‑Diagramme erstellen**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Schritte:</em> Box‑ und Whisker‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint‑Box‑ und Whisker‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Box‑ und Whisker‑Diagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker) hinzu.
4. Greifen Sie auf das Diagrammdaten‑[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Box‑ und Whisker‑Diagramms:
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

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Schritte:</em> Trichter‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Schritte:</em> PowerPoint‑Trichter‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Trichter‑Diagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel) hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Der PHP‑Code zeigt, wie ein Trichter‑Diagramm erstellt wird:
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


### **Sonnenstrahl‑Diagramme erstellen**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Schritte:</em> Sonnenstrahl‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Schritte:</em> PowerPoint‑Sonnenstrahl‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Sonnenstrahl‑Diagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ (hier: [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst) hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Sonnenstrahl‑Diagramms:
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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Schritte:</em> Histogramm‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Schritte:</em> PowerPoint‑Histogramm‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Histogramm‑Diagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie.
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram) hinzu.
4. Greifen Sie auf das Diagrammdaten‑[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Histogramm‑Diagramms:
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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Schritte:</em> Radar‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Schritte:</em> PowerPoint‑Radar‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Radar‑Diagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie. 
3. Fügen Sie ein Diagramm mit Daten und dem gewünschten Typ (`ChartType::Radar`) hinzu.
4. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Radar‑Diagramms:
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

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Schritte:</em> Mehrkategorien‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Schritte:</em> PowerPoint‑Mehrkategorien‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Mehrkategorien‑Diagramm erstellen</strong></a>

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie sich über den Index die Referenz einer Folie. 
3. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn) hinzu.
4. Greifen Sie auf das Diagrammdaten‑[IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) zu.
5. Löschen Sie die voreingestellten Serien und Kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Ergänzen Sie neue Diagrammdaten für die Serien.
8. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code demonstriert das Erstellen eines Mehrkategorien‑Diagramms:
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

Ein Karten‑Diagramm visualisiert ein Gebiet, das Daten enthält. Karten‑Diagramme eignen sich besonders zum Vergleich von Daten oder Werten über geografische Regionen hinweg.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Schritte:</em> Karten‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Schritte:</em> PowerPoint‑Karten‑Diagramm erstellen</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Karten‑Diagramm erstellen</strong></a>

Dieser PHP‑Code demonstriert das Erstellen eines Karten‑Diagramms:
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

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es, Unterschiede zwischen Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen, um Beziehungen zu erkennen.

![Das Kombinations‑Diagramm](combination_chart.png)

Der folgende PHP‑Code zeigt, wie das oben abgebildete Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellt wird:
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

    // Diagrammtitel festlegen.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Diagrammlegende festlegen.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Standardmäßig erzeugte Serien und Kategorien löschen.
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
    // Horizontale Achse festlegen.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Vertikale Achse festlegen.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Farbe der vertikalen Hauptgitternetzlinien festlegen.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Sekundäre horizontale Achse festlegen.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Sekundäre vertikale Achse festlegen.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Schritte:</em> PowerPoint‑Diagramm aktualisieren</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Schritte:</em> Präsentations‑Diagramm aktualisieren</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Schritte:</em> PowerPoint‑Präsentations‑Diagramm aktualisieren</strong></a>

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Präsentation mit dem zu aktualisierenden Diagramm darstellt.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Diagrammdaten‑Arbeitsblatt zu.
5. Ändern Sie die Daten der Diagramm‑Serien, indem Sie die Serienwerte anpassen.
6. Fügen Sie eine neue Serie hinzu und füllen Sie die Daten.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie ein Diagramm aktualisiert wird:
```php
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Holt das Diagramm mit Standarddaten
    $chart = $sld->getShapes()->get_Item(0);
    # Setzt den Index des Diagramm-Datenblatts
    $defaultWorksheetIndex = 0;
    # Holt das Diagramm-Daten-Arbeitsblatt
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Ändert den Diagramm-Kategorienamen
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Nimmt die erste Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Aktualisiert jetzt die Seriendaten
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Seriennamen ändern

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Nimmt die zweite Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Aktualisiert jetzt die Seriendaten
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Seriennamen ändern

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Fügt jetzt eine neue Serie hinzu
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Nimmt die dritte Diagrammserie
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Populiert jetzt die Seriendaten
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Speichert die Präsentation mit Diagramm
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Datenbereich für Diagramme festlegen**

Um den Datenbereich für ein Diagramm festzulegen, gehen Sie wie folgt vor:

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Präsentation mit dem Diagramm enthält.
2. Holen Sie sich die Referenz einer Folie über deren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
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
Wenn Sie einen Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Serie automatisch ein unterschiedliches Standard‑Markersymbol.

Dieser PHP‑Code zeigt, wie ein Diagramm‑Series‑Marker automatisch gesetzt wird:
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
