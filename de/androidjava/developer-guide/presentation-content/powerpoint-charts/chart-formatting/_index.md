---
title: Diagramme in Präsentationen auf Android formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/androidjava/chart-formatting/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Android via Java formatieren und verleihen Sie Ihrer PowerPoint-Präsentation ein professionelles, ansprechendes Design."
---

## **Diagramm‑Entitäten formatieren**
Aspose.Slides für Android via Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich Diagrammkategorie‑ und Wertachse.

Aspose.Slides für Android via Java bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Entitäten und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Folien‑Verweis über dessen Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Beispiel verwenden wir **ChartType.LineWithMarkers**).
1. Greifen Sie auf die Wertachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für die Hauptgitterlinien der Wertachse
   1. Festlegen des **Linienformats** für die Hilfsgitterlinien der Wertachse
   1. Festlegen des **Zahlenformats** für die Wertachse
   1. Festlegen von **Min‑, Max‑, Haupt‑ und Hilfseinheiten** für die Wertachse
   1. Festlegen von **Texteigenschaften** für die Daten der Wertachse
   1. Festlegen des **Titels** für die Wertachse
   1. Festlegen des **Linienformats** für die Wertachse
1. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für die Hauptgitterlinien der Kategorienachse
   1. Festlegen des **Linienformats** für die Hilfsgitterlinien der Kategorienachse
   1. Festlegen von **Texteigenschaften** für die Daten der Kategorienachse
   1. Festlegen des **Titels** für die Kategorienachse
   1. Festlegen der **Beschriftungspositionierung** für die Kategorienachse
   1. Festlegen des **Drehwinkels** für die Beschriftungen der Kategorienachse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Texteigenschaften** dafür
1. Diagrammlegenden anzeigen, ohne dass sie sich überschneiden
1. Greifen Sie auf die **sekundäre Wertachse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Wertachse**
   1. Festlegen des **Linienformats** für die sekundäre Wertachse
   1. Festlegen des **Zahlenformats** für die sekundäre Wertachse
   1. Festlegen von **Min‑, Max‑, Haupt‑ und Hilfseinheiten** für die sekundäre Wertachse
1. Zeichnen Sie nun die erste Diagrammreihe auf der sekundären Wertachse
1. Setzen Sie die Füllfarbe der hinteren Diagrammwand
1. Setzen Sie die Füllfarbe des Diagramm‑Plot‑Bereichs
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei
```java
// Eine Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Beispiel-Diagramm hinzufügen
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Diagrammtitel festlegen
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Hauptgitterlinienformat für Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Nebengitterlinienformat für Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Zahlenformat für Werteachse festlegen
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Maximal- und Minimalwerte des Diagramms festlegen
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Texteigenschaften der Werteachse festlegen
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Titel der Werteachse festlegen
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Hauptgitterlinienformat für Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Nebengitterlinienformat für Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Texteigenschaften der Kategorienachse festlegen
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Titel der Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Position der Kategorienachsenbeschriftungen festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Rotationswinkel der Kategorienachsenbeschriftungen festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Texteigenschaften der Legende festlegen
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Diagrammlegenden anzeigen, ohne das Diagramm zu überlappen
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Sekundäre Werteachse festlegen
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Zahlenformat der sekundären Werteachse festlegen
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Maximal- und Minimalwerte des Diagramms festlegen
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Hintergrundwandfarbe des Diagramms festlegen
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Plotbereichsfarbe festlegen
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Präsentation speichern
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftart‑Eigenschaften für ein Diagramm festlegen**
Aspose.Slides für Android via Java unterstützt das Festlegen von schriftbezogenen Eigenschaften für ein Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftart‑Eigenschaften für ein Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Objekt.
- Fügen Sie dem Folie ein Diagramm hinzu.
- Legen Sie die Schriftgröße fest.
- Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten angegeben.
```java
// Eine Instanz der Presentation-Klasse erstellen
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
Aspose.Slides für Android via Java bietet eine einfache API zur Verwaltung des Datenformats eines Diagramms:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich einen Folien‑Verweis über dessen Index.
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Beispiel wird **ChartType.ClusteredColumn** verwendet).
1. Setzen Sie das voreingestellte Zahlenformat aus den verfügbaren Vorgabewerten.
1. Durchlaufen Sie jede Datenzelle in jeder Diagrammreihe und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Setzen Sie ein benutzerdefiniertes Zahlenformat.
1. Durchlaufen Sie jede Datenzelle in jeder Diagrammreihe und setzen Sie ein unterschiedliches Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
```java
// Eine Instanz der Presentation-Klasse erstellen
Presentation pres = new Presentation();
try {
    // Auf die erste Präsentationsfolie zugreifen
    ISlide slide = pres.getSlides().get_Item(0);

    // Ein Standard-ClusteredColumn-Diagramm hinzufügen
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Zugriff auf die Diagramm-Seriensammlung
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Durch alle Diagrammserien iterieren
    for (IChartSeries ser : series) 
    {
        // Durch jede Datenzelle in der Serie iterieren
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Das Zahlenformat festlegen
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Präsentation speichern
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Die möglichen voreingestellten Zahlenformat‑Werte zusammen mit ihrem Index sind unten aufgeführt:

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0,00|
|**3**|#,##0|
|**4**|#,##0,00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rot$-#,##0|
|**7**|$#,##0,00;$-#,##0,00|
|**8**|$#,##0,00;Rot$-#,##0,00|
|**9**|0 %|
|**10**|0,00 %|
|**11**|0,00E+00|
|**12**|# ?/​?|
|**13**|# /|
|**14**|TT.MM.JJ|
|**15**|TT-MMM-JJ|
|**16**|TT-MMM|
|**17**|MMM-JJ|
|**18**|hh:mm AM/PM|
|**19**|hh:mm:ss AM/PM|
|**20**|hh:mm|
|**21**|hh:mm:ss|
|**22**|TT.MM.JJ hh:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rot-#,##0|
|**39**|#,##0,00;-#,##0,00|
|**40**|#,##0,00;Rot-#,##0,00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0,00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0,00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0,0E+00|
|**49**|@|

## **Abgerundete Diagrammbereichs‑Ränder festlegen**
Aspose.Slides für Android via Java unterstützt das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) wurden zum [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart)‑Interface und zur [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart)‑Klasse hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Objekt.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest.
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf **True**.
1. Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten angegeben.  
```java
// Eine Instanz der Presentation-Klasse erstellen
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

**Kann ich halbtransparente Füllungen für Spalten/Flächen setzen, während die Umrandung undurchsichtig bleibt?**

Ja. Transparenz der Füllung und der Umriss werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit des Gitters und der Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überlappen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht benötigte Beschriftungselemente (z. B. Kategorien), passen Sie den Versatz/die Position der Beschriftung an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie zum Format „Wert + Legende“.

**Kann ich Farbverlauf‑ oder Musterfüllungen auf Reihen anwenden?**

Ja. Sowohl einfarbige als auch Farbverlauf‑/Musterfüllungen sind in der Regel verfügbar. In der Praxis sollten Farbverläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Gitter und zum Text verringern.