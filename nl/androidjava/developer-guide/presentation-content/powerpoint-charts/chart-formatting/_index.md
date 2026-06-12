---
title: Grafiekopmaak voor presentaties op Android
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/androidjava/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiekelement
- grafiekeigenschappen
- grafiekinstellingen
- grafiekopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer grafiekopmaak in Aspose.Slides voor Android via Java en til uw PowerPoint-presentatie naar een hoger niveau met een professionele, opvallende vormgeving."
---
## **Overzicht**

Dit artikel legt uit hoe grafieken in PowerPoint‑presentaties te formatteren met Aspose.Slides. Het laat zien hoe belangrijke elementen van een grafiek, zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandvullingen, aangepast kunnen worden om het uiterlijk en de leesbaarheid van grafiekgegevens te verbeteren.

Het laat bovendien zien hoe de tekeneigenschappen van grafiekttekst ingesteld worden, hoe voorgedefinieerde en aangepaste numerieke opmaken op grafiekgegevens toegepast kunnen worden en hoe afgeronde hoeken voor het grafiekgebied ingeschakeld worden. Samen tonen deze voorbeelden hoe zowel de visuele stijl als de gegevenspresentatie van grafieken in een presentatie gecontroleerd kan worden.

## **Grafiekelementen opmaken**
Aspose.Slides voor Android via Java stelt ontwikkelaars in staat om vanaf nul aangepaste grafieken aan hun dia’s toe te voegen. Dit artikel legt uit hoe verschillende grafiekelementen, waaronder de categorie‑ en waarde‑as, opgemaakt kunnen worden.

Aspose.Slides voor Android via Java biedt een eenvoudige API voor het beheren van verschillende grafiekelementen en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de [**Presentatie**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) class.
1. Haal een verwijzing naar een dia op via de index.
1. Voeg een grafiek toe met standaardgegevens en een gewenst type (in dit voorbeeld gebruiken we ChartType.LineWithMarkers).
1. Toegang tot de waarde‑as van de grafiek en stel de volgende eigenschappen in:
   1. Instellen van **Lijnformaat** voor de hoofd‑rasterlijnen van de waarde‑as
   1. Instellen van **Lijnformaat** voor de sub‑rasterlijnen van de waarde‑as
   1. Instellen van **Getalopmaak** voor de waarde‑as
   1. Instellen van **Min‑, Max‑, Hoofd‑ en Sub‑eenheden** voor de waarde‑as
   1. Instellen van **Teksteigenschappen** voor de waarde‑as‑gegevens
   1. Instellen van **Titel** voor de waarde‑as
   1. Instellen van **Lijnformaat** voor de waarde‑as
1. Toegang tot de categorie‑as van de grafiek en stel de volgende eigenschappen in:
   1. Instellen van **Lijnformaat** voor de hoofd‑rasterlijnen van de categorie‑as
   1. Instellen van **Lijnformaat** voor de sub‑rasterlijnen van de categorie‑as
   1. Instellen van **Teksteigenschappen** voor de categorie‑as‑gegevens
   1. Instellen van **Titel** voor de categorie‑as
   1. Instellen van **Labelpositionering** voor de categorie‑as
   1. Instellen van **Rotatiehoek** voor de labels van de categorie‑as
1. Toegang tot de legenda van de grafiek en stel de **Teksteigenschappen** ervan in
1. Zet de weergave van grafieklegenda's zonder overlap met de grafiek
1. Toegang tot de **Secundaire waarde‑as** van de grafiek en stel de volgende eigenschappen in:
   1. Schakel de secundaire **Waarde‑as** in
   1. Instellen van **Lijnformaat** voor de secundaire waarde‑as
   1. Instellen van **Getalopmaak** voor de secundaire waarde‑as
   1. Instellen van **Min‑, Max‑, Hoofd‑ en Sub‑eenheden** voor de secundaire waarde‑as
1. Plot nu de eerste grafiekreeks op de secundaire waarde‑as
1. Stel de vulkleur van de achterwand van de grafiek in
1. Stel de vulkleur van het plotgebied van de grafiek in
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg de voorbeeldgrafiek toe
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Instellen van de grafiektitel
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Instellen van het formaat van de hoofd‑rasterlijnen voor de waarde‑as
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Instellen van het formaat van de sub‑rasterlijnen voor de waarde‑as
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Instellen van het getalformaat voor de waarde‑as
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Instellen van maximale en minimale waarden voor de grafiek
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Instellen van tekst‑eigenschappen voor de waarde‑as
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Instellen van de titel van de waarde‑as
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Instellen van het formaat van de hoofd‑rasterlijnen voor de categorie‑as
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Instellen van het formaat van de sub‑rasterlijnen voor de categorie‑as
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Instellen van tekst‑eigenschappen voor de categorie‑as
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Instellen van de categorie‑titel
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Instellen van labelpositie voor de categorie‑as
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Instellen van de rotatiehoek van labels voor de categorie‑as
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Instellen van tekst‑eigenschappen voor de legenda’s
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Instellen van weergave van legenda’s zonder overlap met de grafiek

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Instellen van de secundaire waarde‑as
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Instellen van het getalformaat voor de secundaire waarde‑as
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Instellen van maximale en minimale waarden voor de grafiek
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Instellen van de kleur van de achterwand van de grafiek
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Instellen van de kleur van het plotgebied
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Sla de presentatie op
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lettertype‑eigenschappen voor een grafiek instellen**
Aspose.Slides voor Android via Java biedt ondersteuning voor het instellen van lettertypegerelateerde eigenschappen voor de grafiek. Volg de onderstaande stappen om de lettertype‑eigenschappen van de grafiek in te stellen.

- Instantieer een [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse‑object.
- Voeg een grafiek toe aan de dia.
- Stel de lettergrootte in.
- Sla de gewijzigde presentatie op.

Het onderstaande voorbeeld wordt gegeven.

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

## **Nummeropmaak instellen**
Aspose.Slides voor Android via Java biedt een eenvoudige API voor het beheren van de opmaak van grafiekgegevens:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) class.
1. Verkrijg een verwijzing naar een dia via de index.
1. Voeg een grafiek toe met standaardgegevens en een gewenst type (dit voorbeeld gebruikt **ChartType.ClusteredColumn**).
1. Stel de vooraf ingestelde nummeropmaak in vanuit de mogelijke vooraf ingestelde waarden.
1. Loop door de gegevenscel van elke grafiekreeks en stel de nummeropmaak van de grafiekgegevens in.
1. Sla de presentatie op.
1. Stel de aangepaste nummeropmaak in.
1. Loop door de gegevenscel in elke grafiekreeks en stel een andere nummeropmaak voor de grafiekgegevens in.
1. Sla de presentatie op.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste presentatiedia
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een standaard gegroepeerde kolomgrafiek toe
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Toegang tot de verzameling van grafiekreeksen
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Doorloop elke grafiekreeks
    for (IChartSeries ser : series) 
    {
        // Doorloop elke gegevenscel in de reeks
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Instellen van het getalformaat
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Presentatie opslaan
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

De mogelijke vooraf ingestelde nummeropmaakwaarden met hun bijbehorende index die gebruikt kunnen worden, worden hieronder getoond:

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

## **Afgeronde randen van grafiekgebied instellen**
Aspose.Slides voor Android via Java biedt ondersteuning voor het instellen van het grafiekgebied. De methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) en [**setRoundedCorners**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) zijn toegevoegd aan de [IChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChart)‑interface en de [Chart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Chart)‑klasse.

1. Instantieer een [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) class object.
1. Voeg een grafiek toe aan de dia.
1. Stel het vultype en de vulkleur van de grafiek in
1. Stel de eigenschap voor afgeronde hoeken in op True.
1. Sla de gewijzigde presentatie op.

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

**Kan ik half-transparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. De transparantie van de vulling en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe ga ik om met gegevenslabels wanneer ze overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de label‑offset/‑positie in, toon labels alleen voor geselecteerde punten indien nodig, of wijzig het formaat naar "waarde + legenda".

**Kan ik verlopen of patroonvullingen op reeksen toepassen?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.