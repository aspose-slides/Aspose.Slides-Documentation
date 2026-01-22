---
title: Diagramme in Präsentationen für Android formatieren
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
- Schrifteigenschaften
- abgerundete Kante
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Android via Java formatieren und heben Sie Ihre PowerPoint-Präsentation mit professionellem, auffälligem Design hervor."
---

## **Format Chart Entities**
Aspose.Slides für Android über Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich Diagramm‑Kategorie‑ und Werte‑Achse.

Aspose.Slides für Android über Java bietet eine einfache API zum Verwalten verschiedener Diagramm‑Entitäten und zum Formatieren mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse.
1. Ermitteln Sie die Referenz einer Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für Hauptgitternetzlinien der Werte‑Achse
   1. Festlegen des **Linienformats** für Nebengitternetzlinien der Werte‑Achse
   1. Festlegen des **Zahlenformats** für die Werte‑Achse
   1. Festlegen von **Min, Max, Haupt‑ und Nebeneinheiten** für die Werte‑Achse
   1. Festlegen der **Texteigenschaften** für Werte‑Achsendaten
   1. Festlegen des **Titels** für die Werte‑Achse
   1. Festlegen des **Linienformats** für die Werte‑Achse
1. Greifen Sie auf die Kategorie‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für Hauptgitternetzlinien der Kategorie‑Achse
   1. Festlegen des **Linienformats** für Nebengitternetzlinien der Kategorie‑Achse
   1. Festlegen der **Texteigenschaften** für Kategorie‑Achsendaten
   1. Festlegen des **Titels** für die Kategorie‑Achse
   1. Festlegen der **Beschriftungspositionierung** für die Kategorie‑Achse
   1. Festlegen des **Rotationswinkels** für Kategorie‑Achsenbeschriftungen
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Texteigenschaften** dafür
1. Legenden des Diagramms anzeigen, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **sekundäre Werte‑Achse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Werte‑Achse**
   1. Festlegen des **Linienformats** für die sekundäre Werte‑Achse
   1. Festlegen des **Zahlenformats** für die sekundäre Werte‑Achse
   1. Festlegen von **Min, Max, Haupt‑ und Nebeneinheiten** für die sekundäre Werte‑Achse
1. Plotten Sie nun die erste Diagrammserie auf der sekundären Werte‑Achse
1. Legen Sie die Füllfarbe der Rückwand des Diagramms fest
1. Legen Sie die Füllfarbe des Plot‑Bereichs des Diagramms fest
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen des Beispiel‑Diagramms
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

    // Festlegen des Formats der Hauptgitternetzlinien für die Wertachse
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Festlegen des Formats der Nebengitternetzlinien für die Wertachse
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Festlegen des Zahlenformats der Wertachse
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Festlegen von maximalen und minimalen Werten des Diagramms
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Festlegen der Texteigenschaften der Wertachse
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Festlegen des Titels der Wertachse
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen des Formats der Hauptgitternetzlinien für die Kategorie‑Achse
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Festlegen des Formats der Nebengitternetzlinien für die Kategorie‑Achse
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Festlegen der Texteigenschaften der Kategorie‑Achse
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Festlegen des Titels der Kategorie‑Achse
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen der Beschriftungsposition der Kategorie‑Achse
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Festlegen des Rotationswinkels der Achsenbeschriftung der Kategorie‑Achse
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Festlegen der Texteigenschaften der Legende
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
    // Festlegen der sekundären Wertachse
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Festlegen des Zahlenformats der sekundären Wertachse
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Festlegen von maximalen und minimalen Werten des Diagramms
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Festlegen der Farbe der Rückwand des Diagramms
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Festlegen der Farbe des Plot‑Bereichs
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Präsentation speichern
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Set Font Properties for a Chart**
Aspose.Slides für Android über Java unterstützt das Festlegen von schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den folgenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein Objekt der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
- Diagramm auf der Folie hinzufügen.
- Schriftgröße festlegen.
- Modifizierte Präsentation speichern.

```java
// Erstelle eine Instanz der Presentation-Klasse
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


## **Set the Numeric Format**
Aspose.Slides für Android über Java bietet eine einfache API zum Verwalten des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)‑Klasse.
1. Ermitteln Sie die Referenz einer Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Setzen Sie das vordefinierte Zahlenformat aus den möglichen Vorgabewerten.
1. Durchlaufen Sie die Diagrammdatenzelle jeder Diagrammserie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Setzen Sie das benutzerdefinierte Zahlenformat.
1. Durchlaufen Sie die Diagrammdatenzelle jeder Diagrammserie und setzen ein unterschiedliches Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Greife auf die erste Präsentationsfolie zu
    ISlide slide = pres.getSlides().get_Item(0);

    // Füge ein Standard-Clustered-Column-Diagramm hinzu
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Greife auf die Diagramm-Seriensammlung zu
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Durchlaufe jede Diagramm-Serie
    for (IChartSeries ser : series) 
    {
        // Durchlaufe jede Datenzelle in der Serie
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Setze das Zahlenformat
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Speichere die Präsentation
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


The possible preset number format values along with their preset index and that can be used are given below:

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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Set Chart Area Rounded Borders**
Aspose.Slides für Android über Java unterstützt das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) wurden dem Interface [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart) und der Klasse [Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Chart) hinzugefügt.

1. Instanziieren Sie ein Objekt der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
1. Diagramm auf der Folie hinzufügen.
1. Fülltyp und Füllfarbe des Diagramms festlegen
1. Runde‑Ecken‑Eigenschaft auf **True** setzen.
1. Modifizierte Präsentation speichern.

```java
// Erstelle eine Instanz der Presentation-Klasse
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

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

Ja. Fülltransparenz und Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitters und der Daten in dichten Visualisierungen zu verbessern.

**How can I deal with data labels when they overlap?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), stellen Sie den Beschriftungsversatz/-position ein, zeigen Sie bei Bedarf nur Beschriftungen für ausgewählte Punkte an oder wechseln Sie das Format zu „Wert + Legende“.

**Can I apply gradient or pattern fills to series?**

Ja. Sowohl einfarbige als auch Farbverlauf‑/Musterfüllungen stehen typischerweise zur Verfügung. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Gitter und Text verringern.