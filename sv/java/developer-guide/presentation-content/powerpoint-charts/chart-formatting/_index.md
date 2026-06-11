---
title: Formatera presentationsdiagram i Java
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/java/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramattribut
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- avrundad kant
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Java och förbättra din PowerPoint-presentation med professionell, iögonfallande styling."
---
## **Översikt**

Denna artikel förklarar hur man formaterar diagram i PowerPoint-presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagramdelar såsom axlar, rutnätlinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra diagrammets utseende och läsbarhet.

Den demonstrerar också hur man anger teckensnittsegenskaper för diagramtext, tillämpar förinställda och anpassade numeriska format på diagramdata samt aktiverar avrundade hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och datavisningen för diagram i en presentation.

## **Formatera diagramobjekt**
Aspose.Slides for Java låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Denna artikel förklarar hur man formaterar olika diagramobjekt inklusive diagrammets kategori‑ och värdeaxel.

Aspose.Slides for Java tillhandahåller ett enkelt API för att hantera olika diagramobjekt och formatera dem med egna värden:

1. Skapa en instans av [**Presentation**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassen.
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata tillsammans med någon av de önskade typerna (i detta exempel använder vi ChartType.LineWithMarkers).
1. Åtkomst till diagrammets värdeaxel och ange följande egenskaper:
   1. Ange **Line format** för värdeaxelns huvudrutnätlinjer
   1. Ange **Line format** för värdeaxelns sekundära rutnätlinjer
   1. Ange **Number Format** för värdeaxeln
   1. Ange **Min, Max, Major and Minor units** för värdeaxeln
   1. Ange **Text Properties** för värdeaxelns data
   1. Ange **Title** för värdeaxeln
   1. Ange **Line Format** för värdeaxeln
1. Åtkomst till diagrammets kategori‑axel och ange följande egenskaper:
   1. Ange **Line format** för kategori‑axelns huvudrutnätlinjer
   1. Ange **Line format** för kategori‑axelns sekundära rutnätlinjer
   1. Ange **Text Properties** för kategori‑axelns data
   1. Ange **Title** för kategori‑axeln
   1. Ange **Label Positioning** för kategori‑axeln
   1. Ange **Rotation Angle** för kategori‑axelns etiketter
1. Åtkomst till diagrammets förklaring och ange **Text Properties** för den
1. Visa diagramförklaringar utan att de överlappar diagrammet
1. Åtkomst till diagrammets **Secondary Value Axis** och ange följande egenskaper:
   1. Aktivera den sekundära **Value Axis**
   1. Ange **Line Format** för sekundär värdeaxel
   1. Ange **Number Format** för sekundär värdeaxel
   1. Ange **Min, Max, Major and Minor units** för sekundär värdeaxel
1. Plotta nu den första diagramserien på den sekundära värdeaxeln
1. Ange bakväggens fyllningsfärg för diagrammet
1. Ange plotområdets fyllningsfärg för diagrammet
1. Skriv den modifierade presentationen till en PPTX‑fil

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Åtkomst till den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till exempeldiagrammet
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Anger diagramtitel
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Anger format för huvudrutnätlinjer för värdeaxel
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Anger format för sekundära rutnätlinjer för värdeaxel
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Anger nummerformat för värdeaxeln
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Anger diagrammets maximala och minsta värden
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Anger textegenskaper för värdeaxeln
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Anger titel för värdeaxeln
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Anger format för huvudrutnätlinjer för kategori-axeln
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Anger format för sekundära rutnätlinjer för kategori-axeln
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Anger textegenskaper för kategori-axeln
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Anger kategori-titel
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Anger position för kategori-axelns etiketter
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Anger rotationsvinkel för kategori-axelns etiketter
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Anger textegenskaper för förklaringar
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Ställ in att visa diagramförklaringar utan överlappning med diagrammet

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Anger sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Anger nummerformat för sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Anger diagrammets maximala och minsta värden
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Anger färg på diagrammets bakvägg
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Anger färg på plotområdet
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Spara presentation
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange teckensnittsegenskaper för ett diagram**
Aspose.Slides for Java erbjuder stöd för att ange teckensnittsegenskaper för diagrammet. Följ stegen nedan för att ange teckensnittsegenskaper för diagrammet.

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑klassobjektet.
- Lägg till ett diagram på bilden.
- Ange teckensnittshöjd.
- Spara den modifierade presentationen.

Nedan ges ett exempel.

```java
// Skapa en instans av Presentation-klassen
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

## **Ange numeriskt format**
Aspose.Slides for Java tillhandahåller ett enkelt API för att hantera diagramdatas format:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassen.
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata tillsammans med någon av de önskade typerna (detta exempel använder **ChartType.ClusteredColumn**).
1. Ange det förinställda nummerformatet från de möjliga förinställda värdena.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange diagramdatans nummerformat.
1. Spara presentationen.
1. Ange ett anpassat nummerformat.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange ett annat nummerformat för diagramdata.
1. Spara presentationen.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Åtkomst till den första presentationsbilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till ett standardklustrat kolumndiagram
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Åtkomst till diagramseriekollektionen
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Gå igenom varje diagramserie
    for (IChartSeries ser : series) 
    {
        // Gå igenom varje datacell i serien
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Anger nummerformatet
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Sparar presentationen
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

De möjliga förinställda nummerformatvärdena tillsammans med deras index som kan användas visas nedan:

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

## **Ange avrundade kanter för diagramområdet**
Aspose.Slides for Java erbjuder stöd för att ställa in diagramområdet. Metoderna [**hasRoundedCorners**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChart#hasRoundedCorners--) och [**setRoundedCorners**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) har lagts till i gränssnittet [IChart](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChart) och klassen [Chart](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Chart).

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassobjektet.
1. Lägg till ett diagram på bilden.
1. Ange fyllningstyp och fyllningsfärg för diagrammet
1. Ställ in egenskapen för runda hörn till True.
1. Spara den modifierade presentationen.

Nedan ges ett exempel.

```java
// Skapa en instans av Presentation-klassen
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

**Kan jag ange halvtransparenta fyllningar för kolumner/områden samtidigt som kanterna förblir ogenomskinliga?**

Ja. Fyllningens transparens och konturen konfigureras separat. Detta är användbart för att öka läsbarheten av rutnätet och data i täta visualiseringar.

**Hur hanterar jag dataetiketter när de överlappar?**

Minska teckensnittsstorleken, inaktivera icke‑viktiga etikettkomponenter (t.ex. kategorier), justera etikettens förskjutning/position, visa etiketter endast för utvalda punkter om nödvändigt, eller byt formatet till ”värde + förklaring”.

**Kan jag använda gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnätet och text undvikas.