---
title: Grafieken in presentaties opmaken in JavaScript
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/nodejs-java/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiekonderdeel
- grafiekeigenschappen
- grafiekinstellingen
- grafiekopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer grafiekopmaak in Aspose.Slides voor Node.js met JavaScript en til uw PowerPoint-presentatie naar een professioneel, opvallend stijlniveau."
---
## **Overzicht**

Dit artikel legt uit hoe grafieken in PowerPoint‑presentaties kunnen worden opgemaakt met Aspose.Slides. Het laat zien hoe belangrijke grafiekelementen zoals assen, rasterlijnen, titels, legendes, het plotgebied en wandvullingen kunnen worden aangepast om het uiterlijk en de leesbaarheid van grafiekgegevens te verbeteren.

Het toont ook hoe u lettertype‑eigenschappen voor grafiekttekst kunt instellen, vooraf ingestelde en aangepaste numerieke opmaak op grafiekgegevens kunt toepassen, en afgeronde hoeken voor het grafiekgebied kunt inschakelen. Samen laten deze voorbeelden zien hoe u zowel de visuele stijl als de gegevenspresentatie van grafieken in een presentatie kunt beheersen.

## **Grafiek‑entiteiten opmaken**

Aspose.Slides for Node.js via Java laat ontwikkelaars aangepaste grafieken vanaf nul aan hun dia's toevoegen. Dit artikel legt uit hoe verschillende grafiek‑entiteiten, waaronder de categorie‑ en waardenas, kunnen worden opgemaakt.

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor het beheren van verschillende grafiek‑entiteiten en het formatteren ervan met aangepaste waarden:

1. Maak een instantie van de [**Presentation**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Voeg een grafiek toe met standaardgegevens en een van de gewenste typen (in dit voorbeeld gebruiken we ChartType.LineWithMarkers).
1. Toegang tot de Value Axis van de grafiek en stel de volgende eigenschappen in:
   1. Instellen **Line format** voor Value Axis Major Grid lines
   1. Instellen **Line format** voor Value Axis Minor Grid lines
   1. Instellen **Number Format** voor Value Axis
   1. Instellen **Min, Max, Major and Minor units** voor Value Axis
   1. Instellen **Text Properties** voor Value Axis data
   1. Instellen **Title** voor Value Axis
   1. Instellen **Line Format** voor Value Axis
1. Toegang tot de Category Axis van de grafiek en stel de volgende eigenschappen in:
   1. Instellen **Line format** voor Category Axis Major Grid lines
   1. Instellen **Line format** voor Category Axis Minor Grid lines
   1. Instellen **Text Properties** voor Category Axis data
   1. Instellen **Title** voor Category Axis
   1. Instellen **Label Positioning** voor Category Axis
   1. Instellen **Rotation Angle** voor Category Axis labels
1. Toegang tot de Legend van de grafiek en stel de **Text Properties** in.
1. Zorg ervoor dat de Legend van de grafiek wordt getoond zonder de grafiek te overlappen.
1. Toegang tot de **Secondary Value Axis** van de grafiek en stel de volgende eigenschappen in:
   1. Schakel de Secondary **Value Axis** in
   1. Instellen **Line Format** voor Secondary Value Axis
   1. Instellen **Number Format** voor Secondary Value Axis
   1. Instellen **Min, Max, Major and Minor units** voor Secondary Value Axis
1. Plot nu de eerste grafiekserie op de Secondary Value Axis
1. Stel de opvulkleur van de achtergrondwand van de grafiek in
1. Stel de opvulkleur van het plotgebied van de grafiek in
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand

```javascript
// Maak een instantie van de Presentation‑klasse
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Voeg de voorbeeldgrafiek toe
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Titel van de grafiek instellen
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Formaat van de grote rasterlijnen voor de waardenas instellen
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Formaat van de kleine rasterlijnen voor de waardenas instellen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Getalopmaak van de waardenas instellen
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Maximale en minimale waarden van de grafiek instellen
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Teksteigenschappen van de waardenas instellen
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Titel van de waardenas instellen
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Formaat van de grote rasterlijnen voor de categoriasas instellen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Formaat van de kleine rasterlijnen voor de categoriasas instellen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Teksteigenschappen van de categoriasas instellen
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Titel van de categoriasas instellen
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Positie van de as‑labels instellen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Rotatie‑hoek van de as‑labels instellen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Teksteigenschappen van de legenden instellen
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Legenden van de grafiek weergeven zonder de grafiek te overlappen
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Secundaire waardenas instellen
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Getalopmaak van de secundaire waardenas instellen
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Maximale en minimale waarden van de grafiek instellen
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Kleur van de achterkant van de grafiek instellen
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Kleur van het plot‑gebied instellen
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Presentatie opslaan
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lettertype‑eigenschappen voor grafiek instellen**

Aspose.Slides for Node.js via Java biedt ondersteuning voor het instellen van lettertype‑gerelateerde eigenschappen voor de grafiek. Volg de onderstaande stappen om de lettertype‑eigenschappen voor de grafiek in te stellen.

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
- Voeg een grafiek toe aan de dia.
- Stel de lettergrootte in.
- Sla de gewijzigde presentatie op.

Onderstaand voorbeeld is gegeven.

```javascript
// Maak een instantie van de Presentation‑klasse
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

## **Getalopmaak instellen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor het beheren van de opmaak van grafiekgegevens:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Voeg een grafiek toe met standaardgegevens en een van de gewenste types (dit voorbeeld gebruikt **ChartType.ClusteredColumn**).
1. Stel het vooraf ingestelde getalformaat in op basis van de mogelijke vooraf ingestelde waarden.
1. Loop door elke cel met grafiekgegevens in elke grafiekserie en stel het getalformaat van de grafiekgegevens in.
1. Sla de presentatie op.
1. Stel het aangepaste getalformaat in.
1. Loop door elke cel met grafiekgegevens in elke grafiekserie en stel een ander getalformaat voor de grafiekgegevens in.
1. Sla de presentatie op.

```javascript
// Maak een instantie van de Presentation‑klasse
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste presentatiedia
    var slide = pres.getSlides().get_Item(0);
    // Voeg een standaard gegroepeerde kolomgrafiek toe
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Toegang tot de seriesverzameling van de grafiek
    var series = chart.getChartData().getSeries();
    // Doorloop elke grafiekserie
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Doorloop elke gegevenscel in de serie
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Getalopmaak instellen
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Presentatie opslaan
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De mogelijke vooraf ingestelde getalopmaakwaarden, inclusief hun index, die gebruikt kunnen worden, staan hieronder:

|**0**|Algemeen|
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

## **Afgeronde randen voor grafiekgebied instellen**

Aspose.Slides for Node.js via Java biedt ondersteuning voor het instellen van het grafiekgebied. Methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) en [**setRoundedCorners**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) zijn toegevoegd aan de [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Chart)‑klasse.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
1. Voeg een grafiek toe aan de dia.
1. Stel het vultype en de vulkleur van de grafiek in.
1. Stel de eigenschap voor afgeronde hoeken in op True.
1. Sla de gewijzigde presentatie op.

Onderstaand voorbeeld is gegeven.  

```javascript
// Maak een instantie van de Presentation‑klasse
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

**Kan ik halfdoorzichtige vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. De transparantie van de vulling en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met gegevenslabels wanneer ze overlappen?**

Verklein de lettergrootte, schakel niet‑essentiële labelcomponenten uit (bijvoorbeeld categorieën), stel de offset/positie van het label in, toon labels alleen voor geselecteerde punten indien nodig, of wijzig het formaat naar "waarde + legenda".

**Kan ik verloop‑ of patroonvullingen toepassen op series?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.