---
title: Diagrammformatierung
type: docs
weight: 60
url: /de/nodejs-java/chart-formatting/
---

## **Diagramm‑Entitäten formatieren**

Aspose.Slides for Node.js via Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm‑Entitäten formatiert werden, einschließlich Kategorie‑ und Werte‑Achse des Diagramms.

Aspose.Slides for Node.js via Java bietet eine einfache API zum Verwalten verschiedener Diagramm‑Entitäten und zum Formatieren mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Value Axis des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Value Axis
   1. Festlegen des **Line format** für die Hilfsgitternetzlinien der Value Axis
   1. Festlegen des **Number Format** für die Value Axis
   1. Festlegen von **Min, Max, Major und Minor units** für die Value Axis
   1. Festlegen von **Text Properties** für die Daten der Value Axis
   1. Festlegen des **Title** für die Value Axis
   1. Festlegen des **Line Format** für die Value Axis
1. Greifen Sie auf die Category Axis des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Category Axis
   1. Festlegen des **Line format** für die Hilfsgitternetzlinien der Category Axis
   1. Festlegen von **Text Properties** für die Daten der Category Axis
   1. Festlegen des **Title** für die Category Axis
   1. Festlegen der **Label Positioning** für die Category Axis
   1. Festlegen des **Rotation Angle** für die Beschriftungen der Category Axis
1. Greifen Sie auf die Legend des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Legen Sie fest, dass Diagramm‑Legenden angezeigt werden, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen des **Line Format** für die Secondary Value Axis
   1. Festlegen des **Number Format** für die Secondary Value Axis
   1. Festlegen von **Min, Max, Major und Minor units** für die Secondary Value Axis
1. Plotten Sie nun die erste Diagramm‑Serie auf der Secondary Value Axis
1. Setzen Sie die Füllfarbe der Rückwand des Diagramms
1. Setzen Sie die Füllfarbe des Plot‑Bereichs des Diagramms
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei
```javascript
// Instanz der Presentation-Klasse erstellen
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Beispieldiagramm hinzufügen
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Diagrammtitel festlegen
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Format der Hauptgitternetzlinien für die Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Format der Hilfsgitternetzlinien für die Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Zahlenformat der Werteachse festlegen
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Maximal- und Minimalwerte des Diagramms festlegen
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Text-Eigenschaften der Werteachse festlegen
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Titel der Werteachse festlegen
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Format der Hauptgitternetzlinien für die Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Format der Hilfsgitternetzlinien für die Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Text-Eigenschaften der Kategorienachse festlegen
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Titel der Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Position der Beschriftungen der Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Drehwinkel der Beschriftungen der Kategorienachse festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Text-Eigenschaften der Legenden festlegen
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Legenden anzeigen, ohne das Diagramm zu überlappen
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Sekundäre Werteachse festlegen
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Zahlenformat der sekundären Werteachse festlegen
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Maximal- und Minimalwerte des Diagramms festlegen
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Farbe der Diagrammhintergrundwand festlegen
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Farbe des Plotbereichs festlegen
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Präsentation speichern
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriftart‑Eigenschaften für Diagramm festlegen**

Aspose.Slides for Node.js via Java bietet Unterstützung zum Festlegen von Schriftarteigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klassenobjekt.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Setzen Sie die Schriftgröße.
- Speichern Sie die geänderte Präsentation.

Nachstehendes Beispiel wird gegeben.
```javascript
// Instanz der Presentation-Klasse erstellen
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Format von Numerischen Werten festlegen**

Aspose.Slides for Node.js via Java bietet eine einfache API zum Verwalten des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten sowie dem gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Setzen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten.
1. Durchlaufen Sie jede Zelle der Diagrammdaten in jeder Diagramm‑Serie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Setzen Sie das benutzerdefinierte Zahlenformat.
1. Durchlaufen Sie die Diagrammdatenzellen in jeder Diagramm‑Serie und setzen Sie ein anderes Zahlenformat.
1. Speichern Sie die Präsentation.
```javascript
// Instanz der Presentation-Klasse erstellen
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Präsentationsfolie
    var slide = pres.getSlides().get_Item(0);
    // Ein Standard-ClusteredColumn-Diagramm hinzufügen
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Zugriff auf die Diagramm-Seriensammlung
    var series = chart.getChartData().getSeries();
    // Durch alle Diagrammserien iterieren
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Durch jede Datenzelle in der Serie iterieren
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Zahlenformat festlegen
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Präsentation speichern
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind nachfolgend angegeben:

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

Aspose.Slides for Node.js via Java bietet Unterstützung zum Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) wurden zur Klasse [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart) hinzugefügt.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Setzen Sie den Fülltyp und die Füllfarbe des Diagramms.
1. Setzen Sie die Eigenschaft round corner auf True.
1. Speichern Sie die geänderte Präsentation.

Nachstehendes Beispiel wird gegeben. 
```javascript
// Instanz der Presentation-Klasse erstellen
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Flächen festlegen, während die Randlinie undurchsichtig bleibt?**

Ja. Fülltransparenz und Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), stellen Sie den Beschriftungs‑Offset/-Position ein, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls notwendig, oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Farbverläufe oder Musterfüllungen auf Reihen anwenden?**

Ja. Sowohl einfarbige als auch Farbverlauf‑/Musterfüllungen sind in der Regel verfügbar. Verwenden Sie Farbverläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Raster und zum Text verringern.