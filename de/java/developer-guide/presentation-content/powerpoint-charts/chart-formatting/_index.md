---
title: Diagrammformatierung
type: docs
weight: 60
url: /de/java/chart-formatting/
---

## **Diagramm-Elemente formatieren**
Aspose.Slides für Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erläutert, wie verschiedene Diagramm-Elemente, einschließlich der Kategorie- und Wert-Achse des Diagramms, formatiert werden.

Aspose.Slides für Java bietet eine einfache API zur Verwaltung verschiedener Diagramm-Elemente und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie einen beliebigen gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Wert-Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für die Haupt-Rasterlinien der Wert-Achse
   1. Festlegen des **Linienformats** für die Unter-Rasterlinien der Wert-Achse
   1. Festlegen des **Zahlenformats** für die Wert-Achse
   1. Festlegen der **Min-, Max-, Haupt- und Nebenwerteinheiten** für die Wert-Achse
   1. Festlegen der **Text-Eigenschaften** für die Wert-Achsen-Daten
   1. Festlegen des **Titels** für die Wert-Achse
   1. Festlegen des **Linienformats** für die Wert-Achse
1. Greifen Sie auf die Kategorie-Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für die Haupt-Rasterlinien der Kategorie-Achse
   1. Festlegen des **Linienformats** für die Unter-Rasterlinien der Kategorie-Achse
   1. Festlegen der **Text-Eigenschaften** für die Kategorie-Achsen-Daten
   1. Festlegen des **Titels** für die Kategorie-Achse
   1. Festlegen der **Beschriftungspositionierung** für die Kategorie-Achse
   1. Festlegen des **Drehwinkels** für die Beschriftungen der Kategorie-Achse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text-Eigenschaften** dafür
1. Legen Sie fest, dass die Legenden des Diagramms angezeigt werden, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **sekundäre Wert-Achse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Wert-Achse**
   1. Festlegen des **Linienformats** für die sekundäre Wert-Achse
   1. Festlegen des **Zahlenformats** für die sekundäre Wert-Achse
   1. Festlegen der **Min-, Max-, Haupt- und Nebenwerteinheiten** für die sekundäre Wert-Achse
1. Plotten Sie nun die erste Diagrammserie auf der sekundären Wert-Achse
1. Legen Sie die Füllfarbe der Hintergrundwand des Diagramms fest
1. Legen Sie die Füllfarbe des Diagramm-Plotbereichs fest
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei

```java
// Erstellen Sie eine Instanz der Präsentation-Klasse
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen des Beispiel-Diagramms
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Festlegen des Diagrammtitels
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Beispiel-Diagramm");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen des Formats der Haupt-Rasterlinien für die Wert-Achse
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Festlegen des Formats der Unter-Rasterlinien für die Wert-Achse
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Festlegen des Zahlenformats der Wert-Achse
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

    // Festlegen der Text-Eigenschaften der Wert-Achse
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Festlegen des Titels der Wert-Achse
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primäre Achse");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen des Formats der Haupt-Rasterlinien für die Kategorie-Achse
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Festlegen des Formats der Unter-Rasterlinien für die Kategorie-Achse
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Festlegen der Text-Eigenschaften der Kategorie-Achse
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Festlegen des Titels der Kategorie-Achse
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Beispiel-Kategorie");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Festlegen der Position der Beschriftungen der Kategorie-Achse
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Festlegen des Drehwinkels der Beschriftungen der Kategorie-Achse
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Festlegen der Text-Eigenschaften der Legenden
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Legenden-Diagramme ohne Überlappung des Diagramms anzeigen

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Festlegen der sekundären Wert-Achse
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Festlegen des Zahlenformats der sekundären Wert-Achse
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
    // Festlegen der Plotbereichsfarbe
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Präsentation speichern
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Schriftarten-Eigenschaften für das Diagramm festlegen**
Aspose.Slides für Java bietet Unterstützung für das Festlegen der schreibartbezogenen Eigenschaften für das Diagramm. Bitte befolgen Sie die folgenden Schritte, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klassenobjekt.
- Fügen Sie das Diagramm auf der Folie hinzu.
- Stellen Sie die Schriftgröße ein.
- Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten gegeben.

```java
// Erstellen Sie eine Instanz der Präsentation-Klasse
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

## **Format von Zahlen festlegen**
Aspose.Slides für Java bietet eine einfache API zur Verwaltung des Datenformats für Diagramme:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie einen beliebigen gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Stellen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten ein.
1. Durchlaufen Sie jede Datenzelle in jeder Diagrammserie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Stellen Sie das benutzerdefinierte Zahlenformat ein.
1. Durchlaufen Sie jede Datenzelle in jeder Diagrammserie und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.

```java
// Erstellen Sie eine Instanz der Präsentation-Klasse
Presentation pres = new Presentation();
try {
    // Zugriff auf die erste Präsentationsfolie
    ISlide slide = pres.getSlides().get_Item(0);

    // Hinzufügen eines standardmäßigen gruppierten Säulendiagramms
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Zugriff auf die Diagrammserie-Sammlung
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

    // Präsentation speichern
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem vordefinierten Index, die verwendet werden können, sind unten aufgeführt:

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

## **Rundungen der Diagrammflächen-Bordüren festlegen**
Aspose.Slides für Java bietet Unterstützung für das Festlegen der Diagrammfläche. Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) wurden zum [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/IChart) Interface und zur [Chart](https://reference.aspose.com/slides/java/com.aspose.slides/Chart) Klasse hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest.
1. Stellen Sie die Eigenschaft der runden Ecken auf Wahr ein.
1. Speichern Sie die modifizierte Präsentation.

Ein Beispiel wird unten gegeben.

```java
// Erstellen Sie eine Instanz der Präsentation-Klasse
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