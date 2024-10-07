---
title: Diagrammformatierung
type: docs
weight: 60
url: /php-java/chart-formatting/
---

## **Formatieren von Diagrammobjekten**
Aspose.Slides für PHP über Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf in ihre Folien einzufügen. Dieser Artikel erklärt, wie man verschiedene Diagrammobjekte, einschließlich der Kategorie- und Werteachse, formatiert.

Aspose.Slides für PHP über Java bietet eine einfache API zur Verwaltung verschiedener Diagrammobjekte und deren Formatierung mit benutzerdefinierten Werten:

1. Erstelle eine Instanz der [**Präsentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalte eine Referenz zur Folie durch ihren Index.
1. Füge ein Diagramm mit Standarddaten sowie einem beliebigen gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType::LineWithMarkers).
1. Greife auf die Werteachse des Diagramms zu und setze folgende Eigenschaften:
   1. Festlegen des **Linienformats** für die Hauptrasterlinien der Werteachse
   1. Festlegen des **Linienformats** für die Nebengitterlinien der Werteachse
   1. Festlegen des **Zahlenformats** für die Werteachse
   1. Festlegen von **Min-, Max-, Haupt- und Nebeneinheiten** für die Werteachse
   1. Festlegen der **Textformatierung** für die Daten der Werteachse
   1. Festlegen des **Titels** für die Werteachse
   1. Festlegen des **Linienformats** für die Werteachse
1. Greife auf die Kategoriewerteachse zu und setze folgende Eigenschaften:
   1. Festlegen des **Linienformats** für die Hauptgitterlinien der Kategoriewerteachse
   1. Festlegen des **Linienformats** für die Nebengitterlinien der Kategoriewerteachse
   1. Festlegen der **Textformatierung** für die Daten der Kategoriewerteachse
   1. Festlegen des **Titels** für die Kategoriewerteachse
   1. Festlegen der **Beschriftungsposition** für die Kategoriewerteachse
   1. Festlegen des **Drehwinkels** für die Beschriftungen der Kategoriewerteachse
1. Greife auf die Legende des Diagramms zu und setze die **Textformatierung** für sie
1. Stelle sicher, dass Diagrammlegenden ohne Überlappung angezeigt werden
1. Greife auf die **sekundäre Werteachse** des Diagramms zu und setze folgende Eigenschaften:
   1. Aktiviere die sekundäre **Werteachse**
   1. Festlegen des **Linienformats** für die sekundäre Werteachse
   1. Festlegen des **Zahlenformats** für die sekundäre Werteachse
   1. Festlegen von **Min-, Max-, Haupt- und Nebeneinheiten** für die sekundäre Werteachse
1. Plotte jetzt die erste Diagrammreihe auf der sekundären Werteachse
1. Setze die Füllfarbe der hinteren Wand des Diagramms
1. Setze die Füllfarbe des Plotbereichs des Diagramms
1. Schreibe die modifizierte Präsentation in eine PPTX-Datei

```php
  # Erstelle eine Instanz der Präsentation-Klasse
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen des Beispiel-Diagramms
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Festlegen des Diagrammtitels
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Beispiel-Diagramm");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Festlegen des Formats für die Hauptgitterlinien der Werteachse
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Festlegen des Formats für die Nebengitterlinien der Werteachse
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Festlegen des Zahlenformats der Werteachse
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Festlegen der maximalen und minimalen Werte des Diagramms
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Festlegen der Textformatierung für die Werteachse
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Festlegen des Titels der Werteachse
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primärachse");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Festlegen des Formats für die Hauptgitterlinien der Kategoriewerteachse
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Festlegen des Formats für die Nebengitterlinien der Kategoriewerteachse
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Festlegen der Textformatierung für die Kategoriewerteachse
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Festlegen des Titels der Kategorie
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Beispielkategorie");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Festlegen der Beschriftungsposition der Kategoriewerteachse
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Festlegen des Drehwinkels der Beschriftungen der Kategoriewerteachse
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Festlegen der Textformatierung für die Legenden
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Stelle sicher, dass die Diagrammlegenden ohne Überlappung angezeigt werden
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Festlegen der sekundären Werteachse
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Festlegen des Zahlenformats der sekundären Werteachse
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Festlegen der maximalen und minimalen Werte des Diagramms
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Festlegen der Füllfarbe der hinteren Wand des Diagramms
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Festlegen der Plotbereichsfarbe
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Speichern der Präsentation
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Schriftart Eigenschaften für Diagramm festlegen**
Aspose.Slides für PHP über Java bietet Unterstützung für die Festlegung der Schriftartbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den untenstehenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziiere das [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klassenobjekt.
- Füge ein Diagramm auf der Folie hinzu.
- Setze die Schriftartgröße.
- Speichere die modifizierte Präsentation.

Ein untenstehendes Beispiel wird gegeben.

```php
  # Erstelle eine Instanz der Präsentation-Klasse
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

## **Zahlenformat festlegen**
Aspose.Slides für PHP über Java bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstelle eine Instanz der [Präsentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalte eine Referenz zur Folie durch ihren Index.
1. Füge ein Diagramm mit Standarddaten sowie einem beliebigen gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType::ClusteredColumn**).
1. Setze das voreingestellte Zahlenformat aus den möglichen voreingestellten Werten.
1. Durchlaufe jede Diagrammdatenzelle in jeder Diagrammreihe und setze das Zahlenformat der Diagrammdaten.
1. Speichere die Präsentation.
1. Setze das benutzerdefinierte Zahlenformat.
1. Durchlaufe die Diagrammdatenzelle innerhalb jeder Diagrammreihe und setze ein anderes Diagrammdatenzahlenformat.
1. Speichere die Präsentation.

```php
  # Erstelle eine Instanz der Präsentation-Klasse
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen eines Standard-Clustered-Column-Diagramms
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Zugriff auf die Diagrammreihensammlung
    $series = $chart->getChartData()->getSeries();
    # Durchlaufe jede Diagrammreihe
    foreach($series as $ser) {
      # Durchlaufe jede Datenzelle in der Reihe
      foreach($ser->getDataPoints() as $cell) {
        # Festlegen des Zahlenformats
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Speichern der Präsentation
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem voreingestellten Index, die verwendet werden können, sind unten aufgeführt:

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rot$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rot$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/jj|
|**15**|d-mmm-jj|
|**16**|d-mmm|
|**17**|mmm-jj|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/jj h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rot-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rot-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Runde Ecken für den Diagrammbereich festlegen**
Aspose.Slides für PHP über Java bietet Unterstützung für die Festlegung des Diagrammbereichs. Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) wurden zur [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) Schnittstelle und zur [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart) Klasse hinzugefügt.

1. Instanziiere das [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klassenobjekt.
1. Füge ein Diagramm auf der Folie hinzu.
1. Setze den Fülltyp und die Füllfarbe des Diagramms
1. Setze die runde Ecken-Eigenschaft auf Wahr.
1. Speichere die modifizierte Präsentation.

Ein untenstehendes Beispiel wird gegeben.

```php
  # Erstelle eine Instanz der Präsentation-Klasse
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