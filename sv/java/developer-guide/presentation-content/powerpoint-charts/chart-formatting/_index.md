---
title: Formatera diagram i presentationer i Java
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/java/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- rundade kanter
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Java och förbättra din PowerPoint-presentation med anpassade axlar, teckensnitt, nummerformat och rundade diagramkanter."
---
## **Översikt**

Denna artikel förklarar hur man formaterar diagram i PowerPoint-presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagramelement såsom axlar, rutnätlinjer, titlar, förklaringar, plotområdet och väggfyllningar för att förbättra utseendet och läsbarheten för diagramdata.

Den demonstrerar också hur man ställer in teckensnittsegenskaper för diagramtext, tillämpar fördefinierade numeriska format på diagramdata och aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och datavisningen för diagram i en presentation.

För separata fyllningar och konturer på stigande och fallande intervall, se [exempel på aktiediagram](/slides/sv/java/create-chart/#create-stock-charts).

## **Formatera diagramobjekt**

Använd [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) för att formatera diagramtitlar, axlar, rutnätlinjer, förklaringar och plotområdet. Detta exempel skapar ett linjediagram med markörer och standarddata, och tillämpar sedan separata text- och linjestilar på dess värde- och kategoriaxlar. Teckensnittsstorlekar och linjebreddar anges i punkter; kategorietiketter roteras 45 grader.

Värdeaxeln använder [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) oberoende av källcellerna. Dess skala sträcker sig från -2 till 15, med huvudintervall på 2 och delintervall på 0,5. Exemplet kombinerar även procentformatering med [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) satt till tusental, så anpassa dessa inställningar efter meningen och storleken på dina data. Förklaringen ligger utanför plotområdet eftersom [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) anropas med `false`. Bakväggs- och golvfyllningar konfigureras via [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) och [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), men dessa ytor är endast synliga i 3D-diagram.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange teckensnittsegenskaper för ett diagram**

Ange standardteckensnittsstorlek för diagramtext via [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Exemplet skapar ett grupperat stapeldiagram med ett 20-punkts teckensnitt och aktiverar värdeetiketter för den första serien via [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Textelement med egna uttryckliga teckensnittinställningar kan åsidosätta diagrammets standard.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Återanvänd textramformatering för en diagramförklaring**

För att matcha en förklaring med en bildspelsrubrik, ange rubrikens teckensnitt via [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) på det första stycket. Anropa [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) på formatet som returneras av förklaringens [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--). Det kopierar textraminställningarna, det första styckets formatering och styckets standardteckensnittsegenskaper. Formatering som tillämpas direkt på enskilda delar eller på senare stycken förblir lokala för källan.

Exemplet använder en fet, 26-punkts Calibri‑rubrik i marinblå som mall. Efter att ha formaterat förklaringen anropar det [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) för att tillämpa samma formatering på en separat bildtext.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I den sparade presentationen matchar förklaringen och bildtexten rubriken i storlek, vikt och färg. Förklaringen visar fortfarande serienamnen, och bildtexten behåller sin egen text. Om en del i bildtexten redan har en uttryckt teckensnittsstorlek, får den storleken företräde framför det kopierade stycket som standard.

| Innan kopiering | Efter kopiering |
| --- | --- |
| ![Kvartalsförsäljningsdiagram med vanliga svarta förklaringsetiketter och en svart bildtext](legend-formatting-before.png) | ![Samma diagram med större, fetta marinblå förklaringsetiketter och en matchande bildtext](legend-formatting.png) |

## **Ange numeriskt format**

Använd [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) för att tillämpa ett inbyggt nummerformat på diagrammets arbetsboks-celler. Detta exempel skapar ett grupperat stapeldiagram med standard, cellbaserad data och tillämpar formatindex 10 (`0.00%`) på varje series värdecell. Detta ändrar hur värdena visas i arbetsboken utan att ändra de underliggande siffrorna; till exempel visas 0,25 som 25,00 %. Axel- och dataetikettformat kan konfigureras separat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Följande tabell listar inbyggda nummerformatindex med representativa Excel-format för den engelska (USA) lokalen. De exakta formatsträngarna och deras visning kan variera mellan program och lokaler, särskilt för valuta och datum. Vissa Excel-format avviker också från standardvärdena i OOXML‑standarden, som beskrivs i [Microsofts anteckningar om implementering av nummerformat](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ange rundade kanter för diagramområde**

Anropa [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) med `true` för att runda hörnen på diagramområdet. Exemplet skapar ett grupperat stapeldiagram och använder [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) för att ge dess kontur en solid grå färg och en enkel linjestil innan presentationen sparas.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Redigera befintliga diagramanteckningar**

Ett diagram kan innehålla anpassade former, såsom en textanteckning som förklarar statusen för en rapport. Åtkomst till dessa former sker via [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), även listade under [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) i Diagram‑API‑referensen. Samlingen som returneras av [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) innehåller diagramägda former.

En vanlig textruta placerad över ett diagram tillhör bilden, även om den ser ut som en del av diagrammet. Iterering genom [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) hittar diagrammet och vanliga bildformer, men räknar inte upp de enskilda formerna inne i diagrammet. Diagramtitlar och dataetiketter är separata diagramelement, inte anpassade anteckningar i denna samling.

Ladda ner [chart-annotations.pptx](chart-annotations.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller ett diagram med en ogrupperad anteckning som lyder "Preliminära resultat", en diagramägd linje och en vanlig bildtextruta som lyder "Bildöverlappning". Exemplet hittar det första diagrammet på den bilden och ändrar anteckningen till "Slutresultat" när rapporten är klar för publicering. Det kontrollerar om samlingen är tom och redigerar endast en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) med en icke‑null textram som returneras av [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) och den förväntade texten.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Linjen och bildtextrutan förblir oförändrade. Följande bilder visar indata och det sparade, återöppnade resultatet:

| Innan redigering | Efter redigering |
| --- | --- |
| ![Diagramanteckning som visar Preliminära resultat](chart-annotations-before.png) | ![Diagramanteckning som visar Slutresultat](chart-annotations-after.png) |

{{% alert color="info" title="Obs" %}}
Exemplet granskar endast diagramägd former på toppnivå. Om en anteckning ligger i en [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), inspektera även den gruppens [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--)‑samling. Upprepa detta rekursivt för nästlade grupper och tillämpa samma textkontroller på deras underliggande former. En grupp i sig är en behållare; behandla den inte som en textruta.
{{% /alert %}}

## **FAQ**

**Kan jag sätta halvt genomskinliga fyllningar för kolumner/områden samtidigt som kanterna förblir ogenomskinliga?**

Ja. Fyllnadens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera dataetiketter när de överlappar?**

Minska teckensnittsstorleken, inaktivera icke‑nödvändiga etikettkomponenter (t.ex. kategorier), justera etikettpositionen, visa etiketter endast för valda punkter om nödvändigt, eller byt formatet till "värde + förklaring".

**Kan jag tillämpa gradient‑ eller mönsterfyllningar på serier?**

Ja. Serier stöder solida, gradient‑ och mönsterfyllningar. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnätet och texten undvikas.