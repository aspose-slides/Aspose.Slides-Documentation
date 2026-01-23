---
title: Präsentationsdiagramme in PHP formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/php-java/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagrammobjekt
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schriftarteigenschaften
- abgerundete Kante
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides for PHP via Java formatieren und Ihrer PowerPoint-Präsentation ein professionelles, auffälliges Design verleihen."
---

## **Diagrammobjekte formatieren**
Aspose.Slides for PHP via Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagrammobjekte formatiert werden, einschließlich Diagrammkategorie‑ und Werteachse.

Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung verschiedener Diagrammobjekte und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Rufen Sie die Referenz einer Folie anhand ihres Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Diagrammtyp hinzu (in diesem Beispiel verwenden wir ChartType::LineWithMarkers).
1. Greifen Sie auf die Wertachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Wertachse
   1. Festlegen des **Line format** für die Nebengitternetzlinien der Wertachse
   1. Festlegen des **Number Format** für die Wertachse
   1. Festlegen von **Min, Max, Major and Minor units** für die Wertachse
   1. Festlegen der **Text Properties** für die Daten der Wertachse
   1. Festlegen des **Title** für die Wertachse
   1. Festlegen des **Line Format** für die Wertachse
1. Greifen Sie auf die Category Axis des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Category Axis
   1. Festlegen des **Line format** für die Nebengitternetzlinien der Category Axis
   1. Festlegen der **Text Properties** für die Daten der Category Axis
   1. Festlegen des **Title** für die Category Axis
   1. Festlegen der **Label Positioning** für die Category Axis
   1. Festlegen des **Rotation Angle** für die Beschriftungen der Category Axis
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Legen Sie die Anzeige der Diagrammlegenden ohne Überlappung des Diagramms fest
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen des **Line Format** für die sekundäre Value Axis
   1. Festlegen des **Number Format** für die sekundäre Value Axis
   1. Festlegen von **Min, Max, Major and Minor units** für die sekundäre Value Axis
1. Plotten Sie nun die erste Diagrammserie auf der sekundären Value Axis
1. Legen Sie die Füllfarbe der Rückwand des Diagramms fest
1. Legen Sie die Füllfarbe des Plotbereichs des Diagramms fest
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei
```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
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
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Festlegen des Formats der Hauptgitternetzlinien für die Wertachse
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Festlegen des Formats der Hilfsgitternetzlinien für die Wertachse
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Festlegen des Zahlenformats der Wertachse
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
    # Festlegen der Texteigenschaften der Wertachse
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Festlegen des Titels der Wertachse
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Festlegen des Formats der Hauptgitternetzlinien für die Kategorienachse
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Festlegen des Formats der Hilfsgitternetzlinien für die Kategorienachse
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Festlegen der Texteigenschaften der Kategorienachse
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Festlegen des Titels der Kategorienachse
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Festlegen der Beschriftungsposition der Kategorienachse
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Festlegen des Rotationswinkels der Beschriftungen der Kategorienachse
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Festlegen der Texteigenschaften der Legende
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
    # Festlegen der sekundären Wertachse
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Festlegen des Zahlenformats der sekundären Wertachse
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
    # Festlegen der Hintergrundwandfarbe des Diagramms
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Festlegen der Farbe des Zeichenbereichs
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


## **Schriftart‑Eigenschaften für ein Diagramm festlegen**
Aspose.Slides for PHP via Java bietet Unterstützung für das Festlegen der schriftenbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den untenstehenden Schritten, um die Schriftarteigenschaften für ein Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klassenobjekt.
- Fügen Sie dem Folie ein Diagramm hinzu.
- Legen Sie die Schriftgröße fest.
- Speichern Sie die modifizierte Präsentation.

Im Folgenden wird ein Beispiel gegeben.
```php
  # Instanz der Presentation-Klasse erstellen
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
Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Rufen Sie die Referenz einer Folie anhand ihres Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType::ClusteredColumn**).
1. Legen Sie das vordefinierte Zahlenformat aus den möglichen vorgegebenen Werten fest.
1. Durchlaufen Sie die Diagrammdatenzelle jeder Diagrammserie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Diagrammdatenzelle jeder Diagrammserie und setzen Sie ein unterschiedliches Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Präsentationsfolie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen eines Standard-Clustered-Column-Diagramms
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Zugriff auf die Diagrammseriensammlung
    $series = $chart->getChartData()->getSeries();
    # Durchlaufen jeder Diagrammserie
    foreach($series as $ser) {
      # Durchlaufen jeder Datenzelle in der Serie
      foreach($ser->getDataPoints() as $cell) {
        # Festlegen des Zahlenformats
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


Die möglichen vorgegebenen Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:

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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Ränder des Diagrammbereichs festlegen**
Aspose.Slides for PHP via Java bietet Unterstützung für das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) und [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) wurden der [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart)-Klasse hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klassenobjekt.
1. Fügen Sie der Folie ein Diagramm hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest.
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf True.
1. Speichern Sie die modifizierte Präsentation.

Im Folgenden wird ein Beispiel gegeben. 
```php
  # Instanz der Presentation-Klasse erstellen
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

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen, während die Kontur undurchsichtig bleibt?**

Ja. Die Fülltransparenz und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie überlappen?**

Verringern Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Komponenten der Beschriftung (z. B. Kategorien), stellen Sie den Beschriftungsversatz/die Position ein, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Verlauf‑ oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Musterfüllungen sind in der Regel verfügbar. Verwenden Sie Verläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Raster und zum Text verringern.