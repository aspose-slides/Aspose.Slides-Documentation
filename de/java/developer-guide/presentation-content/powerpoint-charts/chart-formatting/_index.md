---
title: Diagramme in Java formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/java/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagrammobjekt
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- abgerundete Kante
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Java formatieren und verleihen Sie Ihrer PowerPoint-Präsentation mit professionellem, auffälligem Design einen höheren Anspruch."
---

## **Diagrammobjekte formatieren**
Aspose.Slides for Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagrammobjekte einschließlich Diagrammkategorie‑ und Werteachse formatiert werden.

Aspose.Slides for Java stellt eine einfache API zum Verwalten verschiedener Diagrammobjekte und deren Formatierung mit benutzerdefinierten Werten bereit:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen beliebigen gewünschten Typ auswählen (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für Hauptgitternetzlinien der Werteachse
   1. Festlegen des **Line format** für Nebengitternetzlinien der Werteachse
   1. Festlegen des **Number Format** für die Werteachse
   1. Festlegen von **Min, Max, Major and Minor units** für die Werteachse
   1. Festlegen von **Text Properties** für die Daten der Werteachse
   1. Festlegen des **Title** für die Werteachse
   1. Festlegen des **Line Format** für die Werteachse
1. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für Hauptgitternetzlinien der Kategorienachse
   1. Festlegen des **Line format** für Nebengitternetzlinien der Kategorienachse
   1. Festlegen von **Text Properties** für die Daten der Kategorienachse
   1. Festlegen des **Title** für die Kategorienachse
   1. Festlegen von **Label Positioning** für die Kategorienachse
   1. Festlegen von **Rotation Angle** für die Beschriftungen der Kategorienachse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Legenden des Diagramms anzeigen, ohne dass sie das Diagramm überlappen
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen des **Line Format** für die sekundäre Value Axis
   1. Festlegen des **Number Format** für die sekundäre Value Axis
   1. Festlegen von **Min, Max, Major and Minor units** für die sekundäre Value Axis
1. Plotten Sie nun die erste Diagrammreihe auf der sekundären Value Axis
1. Legen Sie die Füllfarbe der Hintergrundwand des Diagramms fest
1. Legen Sie die Füllfarbe des Diagrammbereichs fest
1. Speichern Sie die geänderte Präsentation in einer PPTX-Datei
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen des Beispieldiagramms
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Festlegen des Diagrammtitels
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen des Formats der Hauptgitternetzlinien für die Werteachse
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Festlegen des Formats der Nebengitternetzlinien für die Werteachse
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Festlegen des Zahlenformats der Werteachse
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Festlegen der maximalen und minimalen Werte des Diagramms
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Festlegen der Text-Eigenschaften der Werteachse
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Festlegen des Titels der Werteachse
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen des Formats der Hauptgitternetzlinien für die Kategorienachse
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Festlegen des Formats der Nebengitternetzlinien für die Kategorienachse
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Festlegen der Text-Eigenschaften der Kategorienachse
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Festlegen des Titels der Kategorienachse
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen der Beschriftungsposition der Kategorienachse
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Festlegen des Rotationswinkels der Beschriftungen der Kategorienachse
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Festlegen der Text-Eigenschaften der Legenden
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Legenden anzeigen, ohne das Diagramm zu überlappen

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Festlegen der sekundären Werteachse
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Festlegen des Zahlenformats der sekundären Werteachse
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Festlegen der maximalen und minimalen Werte des Diagramms
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Festlegen der Hintergrundwandfarbe des Diagramms
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Festlegen der Farbe des Diagrammbereichs
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Präsentation speichern
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftarteigenschaften für ein Diagramm festlegen**
Aspose.Slides for Java bietet Unterstützung zum Festlegen von schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den untenstehenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klassenobjekt.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Stellen Sie die Schriftgröße ein.
- Speichern Sie die geänderte Präsentation.

Ein Beispiel unten ist angegeben.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numerisches Format festlegen**
Aspose.Slides for Java stellt eine einfache API zum Verwalten des Datenformats von Diagrammen bereit:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und wählen Sie einen beliebigen gewünschten Typ (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Legen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten fest.
1. Durchlaufen Sie die Datenzellen jedes Diagrammserien und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Datenzellen innerhalb jeder Diagrammreihe und setzen ein unterschiedliches Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie der Präsentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen eines standardmäßigen gruppierten Säulendiagramms
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Zugriff auf die Sammlung der Diagrammserien
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Durchlaufen jeder Diagrammserie
    for (IChartSeries ser : series) 
    {
        // Durchlaufen jeder Datenzelle in der Serie
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Festlegen des Zahlenformats
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Speichern der Präsentation
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten angegeben:

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

## **Abgerundete Ränder des Diagrammbereichs festlegen**
Aspose.Slides for Java bietet Unterstützung zum Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) wurden zum [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) Interface und zur [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) Klasse hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf True.
1. Speichern Sie die geänderte Präsentation.

Ein Beispiel unten ist angegeben. 
```java
// Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen, während die Kontur undurchsichtig bleibt?**

Ja. Die Fülltransparenz und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitters und der Daten in dicht gepackten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie überlappen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), setzen Sie den Beschriftungsversatz/-position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Farbverläufe oder Musterfüllungen auf Reihen anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Musterfüllungen sind in der Regel verfügbar. Verwenden Sie Verläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitter und zum Text verringern.