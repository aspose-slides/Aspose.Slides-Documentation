---
title: Formatera diagram i presentationer på Android
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/androidjava/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensegenskaper
- rundade kanter
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Android via Java och förbättra din PowerPoint-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Den här artikeln förklarar hur du formaterar diagram i PowerPoint-presentationer med hjälp av Aspose.Slides. Den visar hur du anpassar viktiga diagramkomponenter såsom axlar, rutnätslinjer, titlar, förklaringar, plot‑område och väggfyllningar för att förbättra diagrammets utseende och läsbarhet.

Den demonstrerar också hur du ställer in teckensegenskaper för diagramtext, applicerar förinställda och anpassade numeriska format på diagramdata samt aktiverar rundade hörn för diagramområdet. Tillsammans visar exemplen hur du styr både den visuella stilen och datapresentationen av diagram i en presentation.

## **Formatera diagramobjekt**
Aspose.Slides for Android via Java låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Den här artikeln förklarar hur du formaterar olika diagramobjekt inklusive diagrammets kategori‑ och värdeaxel.

Aspose.Slides for Android via Java erbjuder ett enkelt API för att hantera olika diagramobjekt och formatera dem med egna värden:

1. Skapa en instans av klassen [**Presentation**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) .
2. Hämta en referens till en bild med dess index.
3. Lägg till ett diagram med standarddata samt någon av de önskade typerna (i detta exempel använder vi ChartType.LineWithMarkers).
4. Få åtkomst till diagrammets **Värdeaxel** och ställ in följande egenskaper:
   1. Ställ in **Linjeformat** för värdeaxelns huvudrutnätslinjer
   1. Ställ in **Linjeformat** för värdeaxelns underrutnätslinjer
   1. Ställ in **Talformat** för värdeaxeln
   1. Ställ in **Min, Max, Huvud‑ och underenheter** för värdeaxeln
   1. Ställ in **Textegenskaper** för värdeaxelns data
   1. Ställ in **Titel** för värdeaxeln
   1. Ställ in **Linjeformat** för värdeaxeln
5. Få åtkomst till diagrammets **Kategori‑axel** och ställ in följande egenskaper:
   1. Ställ in **Linjeformat** för kategoriaxelns huvudrutnätslinjer
   1. Ställ in **Linjeformat** för kategoriaxelns underrutnätslinjer
   1. Ställ in **Textegenskaper** för kategoriaxelns data
   1. Ställ in **Titel** för kategoriaxeln
   1. Ställ in **Etikettpositionering** för kategoriaxeln
   1. Ställ in **Rotationsvinkel** för kategoriaxonsetiketter
6. Få åtkomst till diagrammets förklaring och ställ in **Textegenskaper** för den
7. Visa diagramförklaringar utan att de överlappar diagrammet
8. Få åtkomst till diagrammets **sekundära Värdeaxel** och ställ in följande egenskaper:
   1. Aktivera den sekundära **Värdeaxeln**
   1. Ställ in **Linjeformat** för den sekundära värdeaxeln
   1. Ställ in **Talformat** för den sekundära värdeaxeln
   1. Ställ in **Min, Max, Huvud‑ och underenheter** för den sekundära värdeaxeln
9. Plotta nu den första diagramserien på den sekundära värdeaxeln
10. Ställ in färg för diagrammets bakre väggfyllning
11. Ställ in färg för diagrammets plot‑områdefyllning
12. Skriv den modifierade presentationen till en PPTX‑fil

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Åtkomst till den första bilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till exempeldiagrammet
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Ställer in diagramtitel
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ställer in format för huvudrutnätslinjer för värdeaxeln
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Ställer in format för underrutnätslinjer för värdeaxeln
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Ställer in talformat för värdeaxeln
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Ställer in diagrammets max- och minvärden
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Ställer in textegenskaper för värdeaxeln
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Ställer in titel för värdeaxeln
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ställer in format för huvudrutnätslinjer för kategoriaxeln
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Ställer in format för underrutnätslinjer för kategoriaxeln
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Ställer in textegenskaper för kategoriaxeln
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Ställer in kategoriens titel
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ställer in position för kategoriaxelns etiketter
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Ställer in rotationsvinkel för kategoriaxelns etiketter
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Ställer in textegenskaper för förklaringar
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Ställ in att visa diagramförklaringar utan överlappning

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Ställer in sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Ställer in talformat för sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Ställer in diagrammets max- och minvärden
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Ställer in färg för diagrammets bakre vägg
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Ställer in färg för plot‑området
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Spara presentationen
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in teckensegenskaper för ett diagram**
Aspose.Slides for Android via Java erbjuder stöd för att ställa in teckensegenskaper för diagram. Följ stegen nedan för att ange teckensegenskaperna för diagrammet.

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) klassobjekt.
- Lägg till diagram på bilden.
- Ställ in teckenhöjd.
- Spara den modifierade presentationen.

Nedan följer ett exempel.

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

## **Ställ in numeriskt format**
Aspose.Slides for Android via Java erbjuder ett enkelt API för att hantera diagramdatans format:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) .
2. Hämta en referens till en bild med dess index.
3. Lägg till ett diagram med standarddata samt någon av de önskade typerna (detta exempel använder **ChartType.ClusteredColumn**).
4. Ställ in det förinställda talformatet från de möjliga förinställda värdena.
5. Gå igenom varje diagramserie och varje datacell och sätt diagramdatans talformat.
6. Spara presentationen.
7. Ställ in ett anpassat talformat.
8. Gå igenom varje diagramserie och varje datacell och ange ett annat talformat för diagramdata.
9. Spara presentationen.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Åtkomst till den första presentationsbilden
    ISlide slide = pres.getSlides().get_Item(0);

    // Lägger till ett standarddiagram av typen ClusteredColumn
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Hämtar diagramseriens samling
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Iterera genom varje diagramserie
    for (IChartSeries ser : series) 
    {
        // Iterera genom varje datapunkt i serien
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Ställer in talformatet
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Sparar presentationen
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

De möjliga förinställda talformatvärdena tillsammans med deras index som kan användas listas nedan:

|**0**|Allmän|
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

## **Ställ in rundade kanter för diagramområde**
Aspose.Slides for Android via Java erbjuder stöd för att ange diagramområde. Metoderna [**hasRoundedCorners**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) och [**setRoundedCorners**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) har lagts till i gränssnittet [IChart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart) och klassen [Chart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Chart) .

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassobjekt.
2. Lägg till diagram på bilden.
3. Ställ in fyllningstyp och fyllningsfärg för diagrammet
4. Ställ in egenskapen för rundade hörn till True.
5. Spara den modifierade presentationen.

Nedan följer ett exempel.  

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

## **Vanliga frågor**

**Kan jag ange semitransparenta fyllningar för kolumner/områden samtidigt som kanten förblir ogenomskinlig?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera dataetiketter när de överlappar?**

Minska teckenstorleken, inaktivera icke‑nödvändiga etikettkomponenter (t.ex. kategorier), justera etikettens förskjutning/position, visa etiketter endast för utvalda punkter om det behövs, eller byt format till ”värde + förklaring”.

**Kan jag applicera gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör du använda gradienter sparsamt och undvika kombinationer som minskar kontrasten mot rutnätet och texten.