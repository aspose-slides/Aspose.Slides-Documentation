---
title: Diagramme in Präsentationen in JavaScript formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/nodejs-java/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- Abgerundete Ränder
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme mit Aspose.Slides für Node.js in JavaScript formatieren und verleihen Sie Ihrer PowerPoint-Präsentation ein professionelles, auffälliges Design."
---

## **Diagramm-Entitäten formatieren**

Aspose.Slides for Node.js via Java ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm-Entitäten formatiert werden, einschließlich Diagrammkategorie- und Werteachse.

Aspose.Slides for Node.js via Java bietet eine einfache API zur Verwaltung verschiedener Diagramm-Entitäten und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse.
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen beliebigen gewünschten Typ wählen (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für Hauptgitternetzlinien der Werteachse
   1. Festlegen des **Linienformats** für Nebengitternetzlinien der Werteachse
   1. Festlegen des **Zahlenformats** für die Werteachse
   1. Festlegen von **Min-, Max-, Haupt- und Neben-Einheiten** für die Werteachse
   1. Festlegen der **Texteigenschaften** für die Daten der Werteachse
   1. Festlegen des **Titels** für die Werteachse
   1. Festlegen des **Linienformats** für die Werteachse
1. Greifen Sie auf die Kategorieachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für Hauptgitternetzlinien der Kategorieachse
   1. Festlegen des **Linienformats** für Nebengitternetzlinien der Kategorieachse
   1. Festlegen der **Texteigenschaften** für die Daten der Kategorieachse
   1. Festlegen des **Titels** für die Kategorieachse
   1. Festlegen der **Beschriftungspositionierung** für die Kategorieachse
   1. Festlegen des **Drehwinkels** für die Beschriftungen der Kategorieachse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Texteigenschaften** dafür
1. Stellen Sie sicher, dass die Diagrammlegenden angezeigt werden, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **sekundäre Werteachse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Werteachse**
   1. Festlegen des **Linienformats** für die sekundäre Werteachse
   1. Festlegen des **Zahlenformats** für die sekundäre Werteachse
   1. Festlegen von **Min-, Max-, Haupt- und Neben-Einheiten** für die sekundäre Werteachse
1. Plotten Sie nun die erste Diagrammserie auf der sekundären Werteachse
1. Legen Sie die Füllfarbe der Rückwand des Diagramms fest
1. Legen Sie die Füllfarbe des Diagrammbereichs fest
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Zugriff auf die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen des Beispieldiagramms
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
    // Format der Nebengitternetzlinien für die Werteachse festlegen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Zahlenformat der Werteachse festlegen
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Maximale und minimale Werte des Diagramms festlegen
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Texteigenschaften der Werteachse festlegen
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
    // Format der Hauptgitternetzlinien für die Kategorieachse festlegen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Format der Nebengitternetzlinien für die Kategorieachse festlegen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Texteigenschaften der Kategorieachse festlegen
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Titel der Kategorieachse festlegen
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Position der Kategorieachsenbeschriftungen festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Rotationswinkel der Kategorieachsenbeschriftungen festlegen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Texteigenschaften der Legenden festlegen
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Diagrammlegenden anzeigen, ohne das Diagramm zu überlappen
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
    // Maximale und minimale Werte des Diagramms festlegen
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Farbe der Rückwand des Diagramms festlegen
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Farbe des Diagrammbereichs festlegen
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


## **Schrifteigenschaften für Diagramm festlegen**

Aspose.Slides for Node.js via Java unterstützt das Festlegen von schriftenbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den untenstehenden Schritten, um die Schrifteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein Objekt der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klassen.
- Fügen Sie dem Folie ein Diagramm hinzu.
- Setzen Sie die Schriftgröße.
- Speichern Sie die modifizierte Präsentation.

Nachstehendes Beispiel wird angegeben.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
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


## **Format von Zahlen festlegen**

Aspose.Slides for Node.js via Java bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
1. Rufen Sie die Referenz einer Folie über deren Index ab.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen gewünschten Typ wählen (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Legen Sie das voreingestellte Zahlenformat aus den möglichen voreingestellten Werten fest.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammserie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammserie und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Greife auf die erste Folie der Präsentation zu
    var slide = pres.getSlides().get_Item(0);
    // Hinzufügen eines Standard-ClusteredColumn-Diagramms
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 4­00);
    // Zugriff auf die Diagrammseriensammlung
    var series = chart.getChartData().getSeries();
    // Durchlaufen jeder Diagrammserie
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Durchlaufen jeder Datenzelle in der Serie
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Festlegen des Zahlenformats
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


Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:

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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Rahmen für Diagrammbereich festlegen**

Aspose.Slides for Node.js via Java unterstützt das Festlegen des Diagrammbereichs. Die Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) und [**setRoundedCorners**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) wurden zur Klasse [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart) hinzugefügt.

1. Instanziieren Sie ein Objekt der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf True.
1. Speichern Sie die modifizierte Präsentation.

Nachstehendes Beispiel wird angegeben. 
```javascript
// Erstelle eine Instanz der Presentation-Klasse
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

**Kann ich halbtransparente Füllungen für Säulen/Flächen festlegen und dabei die Kontur undurchsichtig lassen?**

Ja. Fülltransparenz und Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichtgestalteten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht erforderliche Beschriftungskomponenten (z. B. Kategorien), setzen Sie den Beschriftungsversatz/-position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf-/Musterfüllungen sind in der Regel verfügbar. Verwenden Sie Verläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Raster und Text verringern.