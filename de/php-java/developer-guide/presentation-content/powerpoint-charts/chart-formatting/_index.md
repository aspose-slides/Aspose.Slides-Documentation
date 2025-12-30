---
title: Diagramme in PHP formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/php-java/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- abgerundete Rahmen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme mit Aspose.Slides für PHP via Java formatieren und verleihen Sie Ihrer PowerPoint-Präsentation ein professionelles, ansprechendes Design."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides for PHP via Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm-Entitäten formatiert werden, einschließlich Diagramm‑Kategorien‑ und Werte‑Achse.

Aspose.Slides for PHP via Java bietet eine einfache API zum Verwalten verschiedener Diagramm‑Entitäten und zum Formatieren mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Folien‑Referenz anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType::LineWithMarkers).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. **Linienformat** für Hauptgitternetzlinien der Werte‑Achse festlegen
   1. **Linienformat** für Neben­gitternetzlinien der Werte‑Achse festlegen
   1. **Zahlenformat** für die Werte‑Achse festlegen
   1. **Min‑, Max‑, Haupt‑ und Neben‑Einheiten** für die Werte‑Achse festlegen
   1. **Texteigenschaften** für Werte‑Achsen‑Daten festlegen
   1. **Titel** für die Werte‑Achse festlegen
   1. **Linienformat** für die Werte‑Achse festlegen
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. **Linienformat** für Hauptgitternetzlinien der Kategorien‑Achse festlegen
   1. **Linienformat** für Neben­gitternetzlinien der Kategorien‑Achse festlegen
   1. **Texteigenschaften** für Kategorien‑Achsen‑Daten festlegen
   1. **Titel** für die Kategorien‑Achse festlegen
   1. **Beschriftungsposition** für die Kategorien‑Achse festlegen
   1. **Drehwinkel** für Kategorien‑Achsen‑Beschriftungen festlegen
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Texteigenschaften** dafür
1. Legende so anzeigen, dass sie das Diagramm nicht überlappt
1. Greifen Sie auf die **sekundäre Werte‑Achse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Die sekundäre **Werte‑Achse** aktivieren
   1. **Linienformat** für die sekundäre Werte‑Achse festlegen
   1. **Zahlenformat** für die sekundäre Werte‑Achse festlegen
   1. **Min‑, Max‑, Haupt‑ und Neben‑Einheiten** für die sekundäre Werte‑Achse festlegen
1. Plotten Sie nun die erste Diagramm‑Serie auf der sekundären Werte‑Achse
1. Hintergrundfarbe der Rückwand des Diagramms festlegen
1. Füllfarbe des Plot‑Bereichs des Diagramms festlegen
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Beispiel-Diagramm hinzufügen
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Diagrammtitel festlegen
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Format der Hauptgitternetzlinien für die Werte-Achse festlegen
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Format der Nebengitternetzlinien für die Werte-Achse festlegen
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Zahlenformat der Werte-Achse festlegen
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Maximal- und Minimalwerte des Diagramms festlegen
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Text-Eigenschaften der Werte-Achse festlegen
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Titel der Werte-Achse festlegen
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Format der Hauptgitternetzlinien für die Kategorien-Achse festlegen
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Format der Nebengitternetzlinien für die Kategorien-Achse festlegen
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Text-Eigenschaften der Kategorien-Achse festlegen
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Titel der Kategorien-Achse festlegen
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Position der Kategorien-Achsen-Beschriftung festlegen
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Rotationswinkel der Kategorien-Achsen-Beschriftung festlegen
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Text-Eigenschaften der Legenden festlegen
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Legenden anzeigen, ohne das Diagramm zu überlappen
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Sekundäre Werte-Achse festlegen
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Zahlenformat der sekundären Werte-Achse festlegen
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Maximal- und Minimalwerte des Diagramms festlegen
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Farbe der Hintergrundwand des Diagramms festlegen
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Farbe des Diagramm-Plot-Bereichs festlegen
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Präsentation speichern
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Schrifteigenschaften für ein Diagramm festlegen**
Aspose.Slides for PHP via Java unterstützt das Festlegen von schriftspezifischen Eigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schrifteigenschaften für ein Diagramm zu setzen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klassenobjekt.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Schriftgröße festlegen.
- Modifizierte Präsentation speichern.

Nachfolgend ein Beispiel.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numerisches Format festlegen**
Aspose.Slides for PHP via Java bietet eine einfache API zum Verwalten des Diagramm‑Datenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Folien‑Referenz anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType::ClusteredColumn**).
1. Setzen Sie das voreingestellte Zahlenformat aus den möglichen Vorgabewerten.
1. Durchlaufen Sie jede Datenzelle jeder Diagramm‑Serie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Präsentation speichern.
1. Benutzerdefiniertes Zahlenformat festlegen.
1. Durchlaufen Sie die Datenzellen jeder Diagramm‑Serie und setzen Sie unterschiedliche Zahlenformate.
1. Präsentation speichern.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Greife auf die erste Präsentationsfolie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Ein Standard-Clustered-Column-Diagramm hinzufügen
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Greife auf die Diagramm-Serien-Sammlung zu
    $series = $chart->getChartData()->getSeries();
    # Durchlaufe jede Diagrammserie
    foreach($series as $ser) {
      # Durchlaufe jede Datenzelle in der Serie
      foreach($ser->getDataPoints() as $cell) {
        # Nummernformat festlegen
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Präsentation speichern
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Die möglichen voreingestellten Zahlenformat‑Werte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Rahmen für Diagrammbereich festlegen**
Aspose.Slides for PHP via Java bietet Unterstützung für das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) wurden dem Interface [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) und der Klasse [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart) hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Fülltyp und Füllfarbe des Diagramms festlegen
1. Eigenschaft für abgerundete Ecken auf **True** setzen.
1. Modifizierte Präsentation speichern.

Nachfolgend ein Beispiel.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Flächen setzen und dabei den Rand undurchsichtig lassen?**

Ja. Transparenz der Füllung und Umriss werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überlappen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), passen Sie den Beschriftungs‑Offset/‑Position an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie das Format zu „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Muster‑Füllungen stehen in der Regel zur Verfügung. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Raster und Text reduzieren.