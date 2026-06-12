---
title: Diagrammen in presentaties opmaken in Java
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/java/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramonderdeel
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor Java en til uw PowerPoint-presentatie naar een professioneel, opvallend uiterlijk."
---
## **Overzicht**

Dit artikel legt uit hoe diagrammen in PowerPoint‑presentaties kunnen worden opgemaakt met Aspose.Slides. Het laat zien hoe belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en de wandvullingen kunnen worden aangepast om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het laat bovendien zien hoe lettertype‑eigenschappen voor diagramtekst kunnen worden ingesteld, vooraf ingestelde en aangepaste numerieke opmaak op diagramgegevens kan worden toegepast, en afgeronde hoeken voor het diagramgebied kunnen worden ingeschakeld. Samen tonen deze voorbeelden hoe zowel de visuele stijl als de data‑presentatie van diagrammen in een presentatie kan worden beheerst.

## **Diagramonderdelen opmaken**
Aspose.Slides for Java stelt ontwikkelaars in staat om vanaf nul aangepaste diagrammen aan hun dia’s toe te voegen. Dit artikel legt uit hoe verschillende diagramonderdelen kunnen worden opgemaakt, inclusief de categorische en waardenas van een diagram.

Aspose.Slides for Java biedt een eenvoudige API voor het beheren van verschillende diagramonderdelen en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de [**Presentation**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld gebruiken we ChartType.LineWithMarkers).
1. Open de Value Axis van het diagram en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor Value Axis Major Grid‑lijnen
   1. Instellen van **Line format** voor Value Axis Minor Grid‑lijnen
   1. Instellen van **Number Format** voor Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor Value Axis
   1. Instellen van **Text Properties** voor Value Axis‑gegevens
   1. Instellen van **Title** voor Value Axis
   1. Instellen van **Line Format** voor Value Axis
1. Open de Category Axis van het diagram en stel de volgende eigenschappen in:
   1. Instellen van **Line format** voor Category Axis Major Grid‑lijnen
   1. Instellen van **Line format** voor Category Axis Minor Grid‑lijnen
   1. Instellen van **Text Properties** voor Category Axis‑gegevens
   1. Instellen van **Title** voor Category Axis
   1. Instellen van **Label Positioning** voor Category Axis
   1. Instellen van **Rotation Angle** voor Category Axis‑labels
1. Open de Legend van het diagram en stel de **Text Properties** in.
1. Zorg ervoor dat de Legend van het diagram wordt getoond zonder het diagram te overlappen.
1. Open de **Secondary Value Axis** van het diagram en stel de volgende eigenschappen in:
   1. Schakel de Secondary **Value Axis** in
   1. Instellen van **Line Format** voor Secondary Value Axis
   1. Instellen van **Number Format** voor Secondary Value Axis
   1. Instellen van **Min, Max, Major and Minor units** voor Secondary Value Axis
1. Plot nu de eerste diagramreeks op de Secondary Value Axis
1. Stel de vulkleur van de achterwand van het diagram in
1. Stel de vulkleur van het plotgebied van het diagram in
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand

```java
// Maak een instantie van de Presentation‑klasse
Presentation pres = new Presentation();
try {
    // De eerste dia openen
    ISlide slide = pres.getSlides().get_Item(0);

    // Voorbeeld‑diagram toevoegen
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Diagramtitel instellen
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Opmaak van de belangrijke rasterlijnen voor de waardenas instellen
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Opmaak van de minder belangrijke rasterlijnen voor de waardenas instellen
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Getalopmaak voor de waardenas instellen
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Maximum‑ en minimumwaarden van het diagram instellen
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Teksteigenschappen voor de waardenas instellen
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Titel van de waardenas instellen
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Opmaak van de belangrijke rasterlijnen voor de categorie‑as instellen
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Opmaak van de minder belangrijke rasterlijnen voor de categorie‑as instellen
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Teksteigenschappen voor de categorie‑as instellen
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Titel van de categorie‑as instellen
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Label‑positie van de categorie‑as instellen
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Rotatie‑hoek van de categorie‑as‑labels instellen
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Teksteigenschappen voor legenda’s instellen
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Legenda’s van het diagram tonen zonder het diagram te overlappen

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Secundaire waardenas instellen
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Getalopmaak van de secundaire waardenas instellen
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Maximum‑ en minimumwaarden van het diagram instellen
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Achterwandkleur van het diagram instellen
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Kleur van het plotgebied instellen
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Presentatie opslaan
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertype‑eigenschappen voor een diagram instellen**
Aspose.Slides for Java biedt ondersteuning voor het instellen van lettertype‑gerelateerde eigenschappen voor een diagram. Volg de onderstaande stappen om de lettertype‑eigenschappen van een diagram in te stellen.

- Instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse maken.
- Diagram toevoegen aan de dia.
- Lettertype‑hoogte instellen.
- Aangepaste presentatie opslaan.

Hieronder staat een voorbeeld.

```java
// Maak een instantie van de Presentation‑klasse
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

## **Numeriek formaat instellen**
Aspose.Slides for Java biedt een eenvoudige API voor het beheren van diagramdatumnotatie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (dit voorbeeld gebruikt **ChartType.ClusteredColumn**).
1. Stel het vooraf ingestelde nummerformaat in op basis van de mogelijke presets.
1. Doorloop de datacellen van het diagram in elke reeks en stel het nummerformaat van de diagramgegevens in.
1. Sla de presentatie op.
1. Stel het aangepaste nummerformaat in.
1. Doorloop de datacellen van het diagram in elke reeks en stel een ander nummerformaat in voor de diagramgegevens.
1. Sla de presentatie opnieuw op.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Open de eerste dia van de presentatie
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een standaard clustered column-diagram toe
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // De collectie van diagramreeksen ophalen
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Doorloop elke diagramreeks
    for (IChartSeries ser : series) 
    {
        // Doorloop elke datacel in de reeks
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Het getalformaat instellen
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Presentatie opslaan
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

De mogelijke vooraf ingestelde nummerformaatwaarden, samen met hun index, die kunnen worden gebruikt, staan hieronder:

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

## **Afgeronde randen van diagramgebied instellen**
Aspose.Slides for Java biedt ondersteuning voor het instellen van het diagramgebied. De methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChart#hasRoundedCorners--) en [**setRoundedCorners**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) zijn toegevoegd aan de interface [IChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChart) en de klasse [Chart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Chart).

1. Instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse maken.
1. Diagram aan de dia toevoegen.
1. Vultype en vulkleur van het diagram instellen
1. Eigenschap round corner op True instellen.
1. Aangepaste presentatie opslaan.

Hieronder staat een voorbeeld.

```java
// Maak een instantie van de Presentation-klasse
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

**Kan ik halfdoorzichtige vulvormen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. De transparantie van de vulling en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dicht opeengepakte visualisaties te verbeteren.

**Hoe kan ik omgaan met gegevenslabels wanneer ze overlappen?**

Verklein de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de offset/positie van het label in, toon labels alleen voor geselecteerde punten indien nodig, of schakel over naar het formaat "waarde + legende".

**Kan ik verloop‑ of patroonvullingen op reeksen toepassen?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verloopspiegels spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.