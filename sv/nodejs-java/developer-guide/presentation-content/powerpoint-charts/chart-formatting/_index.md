---
title: Formatera presentationsdiagram i JavaScript
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/nodejs-java/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramelement
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckengenskaper
- avrundade kanter
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Node.js i JavaScript och förbättra din PowerPoint-presentation med professionell, iögonfallande styling."
---
## **Översikt**

Denna artikel förklarar hur man formaterar diagram i PowerPoint-presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagramkomponenter såsom axlar, rutnätslinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra diagrammens utseende och läsbarhet.

Den demonstrerar också hur man anger typegenskaper för diagramtext, använder förinställda och anpassade numeriska format för diagramdata samt aktiverar avrundade hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och datapresentationen för diagram i en presentation.

## **Formatera diagramobjekt**

Aspose.Slides for Node.js via Java låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Denna artikel förklarar hur man formaterar olika diagramobjekt inklusive diagrammets kategori- och värdeaxel.

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hantera olika diagramobjekt och formatera dem med anpassade värden:

1. Skapa en instans av [**Presentation**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)klassen.
1. Hämta en bilds referens genom dess index.
1. Lägg till ett diagram med standarddata samt någon av de önskade typerna (i detta exempel använder vi ChartType.LineWithMarkers).
1. Åtkomst till diagrammets Värdeaxel och ange följande egenskaper:
   1. Ange **Line format** för Värdeaxelns stora rutnätslinjer
   1. Ange **Line format** för Värdeaxelns små rutnätslinjer
   1. Ange **Number Format** för Värdeaxel
   1. Ange **Min, Max, Major and Minor units** för Värdeaxel
   1. Ange **Text Properties** för Värdeaxelns data
   1. Ange **Title** för Värdeaxel
   1. Ange **Line Format** för Värdeaxel
1. Åtkomst till diagrammets KategoriAxel och ange följande egenskaper:
   1. Ange **Line format** för KategoriAxelns stora rutnätslinjer
   1. Ange **Line format** för KategoriAxelns små rutnätslinjer
   1. Ange **Text Properties** för KategoriAxelns data
   1. Ange **Title** för KategoriAxel
   1. Ange **Label Positioning** för KategoriAxel
   1. Ange **Rotation Angle** för KategoriAxelns etiketter
1. Åtkomst till diagrammets Legend och ange **Text Properties** för dem
1. Ställ in att visa diagramlegender utan att de överlappar diagrammet
1. Åtkomst till diagrammets **Secondary Value Axis** och ange följande egenskaper:
   1. Aktivera den sekundära **Value Axis**
   1. Ange **Line Format** för sekundär Value Axis
   1. Ange **Number Format** för sekundär Value Axis
   1. Ange **Min, Max, Major and Minor units** för sekundär Value Axis
1. Plotta nu den första diagramekserien på sekundär Value Axis
1. Ange bakväggens fyllningsfärg för diagrammet
1. Ange fyllningsfärgen för diagrammets plotområde
1. Skriv den modifierade presentationen till en PPTX‑fil

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till den första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägger till exempeldiagrammet
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Ställer in diagramtitel
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ställer in format för stora rutnätslinjer för värdeaxeln
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Ställer in format för små rutnätslinjer för värdeaxeln
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Ställer in talformat för värdeaxeln
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Ställer in diagrammets max- och minvärden
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Ställer in textegenskaper för värdeaxeln
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Ställer in titel för värdeaxeln
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ställer in format för stora rutnätslinjer för kategoriaxeln
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Ställer in format för små rutnätslinjer för kategoriaxeln
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Ställer in textegenskaper för kategoriaxeln
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Ställer in titel för kategoriaxeln
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ställer in etikettposition för kategoriaxeln
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Ställer in rotationsvinkel för kategoriaxelns etiketter
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Ställer in textegenskaper för förklaringar
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Ställ in att visa förklaringar utan att överlappa diagrammet
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Ställer in sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Ställer in talformat för sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Ställer in diagrammets max- och minvärden
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Ställer in bakväggens färg för diagrammet
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ställer in färg för plotområdet
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Spara presentationen
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange typegenskaper för diagram**

Aspose.Slides for Node.js via Java stöder att ange typegenskaper för diagrammet. Följ stegen nedan för att ange typegenskaper för diagrammet.

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)klassens objekt.
- Lägg till ett diagram på bilden.
- Ange teckenhöjd.
- Spara den modifierade presentationen.

Nedan ges ett exempel.

```javascript
// Skapa en instans av Presentation-klassen
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

## **Ange format för numeriska värden**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hantera diagramdatans format:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)klassen.
1. Hämta en bilds referens genom dess index.
1. Lägg till ett diagram med standarddata samt någon av de önskade typerna (detta exempel använder **ChartType.ClusteredColumn**).
1. Ange det förinställda talformatet från de möjliga förinställda värdena.
1. Gå igenom diagramdatacellen i varje diagramekserie och ange diagramdatans talformat.
1. Spara presentationen.
1. Ange ett anpassat talformat.
1. Gå igenom diagramdatacellen i varje diagramekserie och ange ett annat talformat.
1. Spara presentationen.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till den första presentationsbilden
    var slide = pres.getSlides().get_Item(0);
    // Lägger till ett standardklustrat stapeldiagram
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Åtkomst till diagrammets seriekollektion
    var series = chart.getChartData().getSeries();
    // Gå igenom varje diagramserie
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Gå igenom varje datapunkt i serien
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Ställer in talformatet
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Sparar presentationen
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De möjliga förinställda talformatvärdena tillsammans med deras förinställda index som kan användas listas nedan:

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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ange avrundade kanter för diagramområde**

Aspose.Slides for Node.js via Java stöder att ange diagramområde. Metoderna [**hasRoundedCorners**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) och [**setRoundedCorners**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) har lagts till i [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart)‑klassen.

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)klassens objekt.
1. Lägg till ett diagram på bilden.
1. Ange fyllningstyp och fyllningsfärg för diagrammet
1. Sätt egenskapen för rundade hörn till True.
1. Spara den modifierade presentationen.

Nedan ges ett exempel.

```javascript
// Skapa en instans av Presentation-klassen
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

**Kan jag ange halvtransparent fyllning för staplar/områden samtidigt som kanten förblir ogenomskinlig?**

Ja. Fylla transparens och kontur konfigureras separat. Detta är användbart för att förbättra läsbarheten av rutnätet och data i täta visualiseringar.

**Hur hanterar jag datamärkningar när de överlappar?**

Minska teckenstorleken, inaktivera icke‑nödvändiga märkningskomponenter (t.ex. kategorier), ange märkningens offset/position, visa märken endast för utvalda punkter om nödvändigt, eller byt format till "värde + förklaring".

**Kan jag använda gradient‑ eller mönsterfyllningar för serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör gradienter användas sparsamt och undvika kombinationer som minskar kontrasten mot rutnätet och texten.