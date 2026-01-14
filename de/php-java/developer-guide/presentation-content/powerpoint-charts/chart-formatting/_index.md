---
title: Diagramme für Präsentationen in PHP formatieren
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
- Schriftarteigenschaften
- abgerundete Rahmen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für PHP via Java formatieren und heben Sie Ihre PowerPoint-Präsentation mit professionellem, auffälligem Design hervor."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides for PHP via Java ermöglicht Entwicklern das Hinzufügen benutzerdefinierter Diagramme zu ihren Folien von Grund auf. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich Diagramm‑Kategorien‑ und Werte‑Achse.

Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Entitäten und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.
1. Holen Sie sich die Referenz einer Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen gewünschten Typ auswählen (in diesem Beispiel verwenden wir ChartType::LineWithMarkers).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für Hauptgitterlinien der Werte‑Achse
   1. Festlegen des **Line format** für Neben­gitterlinien der Werte‑Achse
   1. Festlegen des **Number Format** für die Werte‑Achse
   1. Festlegen von **Min, Max, Major and Minor units** für die Werte‑Achse
   1. Festlegen der **Text Properties** für die Werte‑Achsendaten
   1. Festlegen des **Title** für die Werte‑Achse
   1. Festlegen des **Line Format** für die Werte‑Achse
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für Hauptgitterlinien der Kategorien‑Achse
   1. Festlegen des **Line format** für Neben­gitterlinien der Kategorien‑Achse
   1. Festlegen der **Text Properties** für die Kategorien‑Achsendaten
   1. Festlegen des **Title** für die Kategorien‑Achse
   1. Festlegen der **Label Positioning** für die Kategorien‑Achse
   1. Festlegen des **Rotation Angle** für die Kategorien‑Achsenbeschriftungen
1. Greifen Sie auf die Diagramm‑Legende zu und setzen Sie die **Text Properties** dafür
1. Legenden anzeigen, ohne dass sie das Diagramm überlappen
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen des **Line Format** für die sekundäre Werte‑Achse
   1. Festlegen des **Number Format** für die sekundäre Werte‑Achse
   1. Festlegen von **Min, Max, Major and Minor units** für die sekundäre Werte‑Achse
1. Plotten Sie die erste Diagramm‑Serie auf der sekundären Werte‑Achse
1. Setzen Sie die Füllfarbe der Hintergrundwand des Diagramms
1. Setzen Sie die Füllfarbe des Diagramm‑Plot‑Bereichs
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen des Beispiel-Diagramms
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
    # Format der Hauptgitterlinien für die Werteachse festlegen
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Format der Nebengitterlinien für die Werteachse festlegen
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Zahlenformat der Werteachse festlegen
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
    # Texteigenschaften der Werteachse festlegen
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Titel der Werteachse festlegen
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Format der Hauptgitterlinien für die Kategorienachse festlegen
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Format der Nebengitterlinien für die Kategorienachse festlegen
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Texteigenschaften der Kategorienachse festlegen
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Titel der Kategorienachse festlegen
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Position der Beschriftungen der Kategorienachse festlegen
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Drehwinkel der Beschriftungen der Kategorienachse festlegen
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Texteigenschaften der Legenden festlegen
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
    # Sekundäre Werteachse festlegen
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Zahlenformat der sekundären Werteachse festlegen
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
    # Hintergrundwandfarbe des Diagramms festlegen
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Farbe des Diagrammbereichs festlegen
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
Aspose.Slides for PHP via Java bietet Unterstützung für das Festlegen von Schriftart‑bezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftart‑Eigenschaften für ein Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klassenobjekt.
- Fügen Sie dem Folie ein Diagramm hinzu.
- Setzen Sie die Schriftgröße.
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
Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung des Diagramm‑Datenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich die Referenz einer Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und wählen Sie einen gewünschten Typ (dieses Beispiel verwendet **ChartType::ClusteredColumn**).
1. Legen Sie das voreingestellte Zahlenformat aus den möglichen Vorgabewerten fest.
1. Durchlaufen Sie die Diagrammdatenzellen jeder Diagrammserie und setzen Sie das Zahlenformat.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Diagrammdatenzellen jeder Diagrammserie und setzen Sie ein unterschiedliches Zahlenformat.
1. Speichern Sie die Präsentation.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen eines Standard-Clustered-Column-Diagramms
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Zugriff auf die Diagramm-Seriensammlung
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


Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:

|**0**|General|
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

## **Abgerundete Ränder des Diagrammbereichs festlegen**
Aspose.Slides for PHP via Java bietet Unterstützung für das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) und [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) wurden zur [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart)‑Klasse hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)‑Klassenobjekt.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Setzen Sie den Fülltyp und die Füllfarbe des Diagramms
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

**Kann ich halbtransparente Füllungen für Säulen/Bereiche festlegen, während die Umrandung undurchsichtig bleibt?**

Ja. Die Fülltransparenz und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitternetzes und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), setzen Sie den Beschriftungs‑Offset/‑Position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie das Format zu „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Farbverlaufs‑/Musterfüllungen sind in der Regel verfügbar. Verwenden Sie Farbverläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitternetz und zum Text verringern.