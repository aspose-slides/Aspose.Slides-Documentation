---
title: Anpassa diagramaxlar i presentationer med Java
linktitle: Diagramaxel
type: docs
url: /sv/java/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelns egenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axelrubrik
- axelposition
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar med Aspose.Slides for Java. Den täcker beräknade axiella värden, byte av diagramrader och -kolumner, axelns synlighet, intervall för kategorietiketter och stapelmärken, datumkategorier och formatering, titelförskjutning, axelposition, visningsenheter och logaritmisk skalning.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och lägg till ett ytdiagram med standarddata. Anropa [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) innan du läser beräknade axiella värden så att diagramlayouten är uppdaterad.

Läs [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) och [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) för axelgränserna, samt [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) och [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) för stapelmärkens intervall. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) och [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) ger tidsskalor, vilket är relevant för datumaxlar. Exemplet sparar dessa värden i lokala variabler och sparar diagrammet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Byt data mellan axlarna**

Använd [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) för att utbyta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie, och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte horisontella och vertikala axlar. Exemplet använder [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategorikolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vänd om plottningsordningen för en axel**

Använd [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) för att vända en kategori- eller värdeaxel. Till exempel kan ett horisontellt stapeldiagram visa projektsteg från topp till botten i samma ordning som kalkylbladet: Planering, Utveckling, Testning. Att vända en axel ändrar plottningsriktningen; den sorterar eller omordnar inte arbetsbokens data. Till jämförelse byter [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) rollerna för serier och kategorier.

Följande exempel skapar ett horisontellt stapeldiagram med tre steg och en serie. Det sparar en presentation med tre bilder: normal ordning, omvända kategorier och omvända värden. Varje kopia använder samma dataset, och endast en axel är omvänd i varje kopia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Bild 2: visa den första kategorin högst upp.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Behåll den horisontella värdeaxeln längst ner.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Bild 3: vänd endast den horisontella numeriska skalan.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att vända en axel kan också flytta den tvärgående axeln till motsatt sida av diagrammet. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) styr var den andra axeln korsar den axel som konfigureras. I bild 2 anropas den med `CrossesType.Maximum` på den omvända kategoriaxeln så att den horisontella värdeaxeln förblir längst ner. För en specifik korsningspunkt, använd [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Kontrollera korsningsinställningarna när du ändrar riktning, särskilt om diagrammet redan har en anpassad korsningspunkt. Anropa `setPlotOrderReversed` med `false` för att återställa normal plottningsriktning; korsningsinställningarna är separata.

| Normal ordning (bild 1) | Omvända kategorier (bild 2) | Omvända värden (bild 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| Kategorierna går från botten till toppen; värdena ökar från vänster till höger. | Planering, Utveckling och Testning visas från topp till botten. Värden och arbetsbladsradordning är oförändrade. | Kategorierna behåller sin normala ordning; värdena ökar från höger till vänster. Kategoriaxeln korsar vid noll på höger sida. |

## **Inaktivera den vertikala axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) med `false` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Inaktivera den horisontella axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) med `false` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ändra en kategoriaxel**

Använd [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) för att välja en datum- eller textkategoriaxel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategoriceller som innehåller numeriska Excel-datumvärden. Det ändrar den horisontella axeln till en datumaxel. Anropa [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) med `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) med `1` och [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) med `TimeUnitType.Months` för att placera huvudstaplar i ett‑månadsintervall.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Styr intervall för kategoriaxelns etiketter**

När ett diagram har många kategorier, minska antalet synliga axelrubriker utan att ta bort kategorier eller datapunkter. Anropa [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) med `false`, och skicka sedan önskat kategoriintervall till [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). För textkategorier i deras normala ordning börjar numreringen på den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

Ett intervall på `3` visar var tredje etikett och döljer två etiketter mellan de visas. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; den visar inte nödvändigtvis varje etikett.

Stapelmärken har egna kontroller. Anropa [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) med `false` och använd [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) för att sätta deras intervall. Till exempel behåller `1` ett stapelmärke vid varje kategoriintervall medan etiketter bara visas var tredje kategori. Använd [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) med en synlig stil så att du kan se resultatet. Att återigen ange någon av de automatiska inställningarna till `true` låter diagrammet välja intervallet på nytt.

Följande självständiga exempel skapar 24 kategorier och en serie, och sparar tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikettspacing med separata stapelmärken, och återställd automatisk spacing. De två kopiorna behåller originaldiagrammets data. Ingen ingångspresentation krävs. Horisontell etiketttext gör skillnaden i densitet lätt att se.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Bild 2: visa var tredje etikett, men behåll ett stapelmärke för varje kategori.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Bild 3: låt diagrammet välja båda intervallerna igen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatisk spacing (bild 1):** I denna rendering visas varannan kategorietikett och radbryts på två rader. Det automatiska resultatet kan variera med diagramstorlek, teckensnitt och renderaren.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manuell spacing (bild 2):** Var tredje etikett visas på en rad, medan stapelmärkena förblir vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utformningen som visas ovan.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑räknintervall för en textkategoriaxel, till exempel kategoriaxeln i ett stapel‑, linje‑, area‑ eller stapeldiagram. I ett stapeldiagram är den den horisontella axeln. I ett horisontellt stapeldiagram är kategoriaxeln vertikal, så tillämpa dessa inställningar på den axel som returneras av [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Stapelmärkintersvall gäller också för en serieaxel i diagram som har en sådan.

Använd inte kategorietikett‑spacing för att sätta den numeriska skalan på en värdeaxel. På en värdeaxel specificerar [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) ett värdesskillnad: t.ex. ger en huvudenhet på `10` staplar vid 0, 10, 20 osv. när axeln börjar vid noll. Ett kategori‑etikett‑intervall på `3` räknar däremot kategori­positioner oavsett deras värden. Sprid‑ och bubbeldiagram använder värdeaxlar snarare än en textkategoriaxel. För en datumaxel, använd tidsbaserade huvudenheter och skalor enligt avsnittet [Ändra en kategoriaxel](#ändra-en-kategoriaxel).

## **Ställ in datumformat för kategoriaxelvärden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE‑Automation‑serienummer i det första kalkylbladet (index `0`), beräknade som antalet dagar sedan 30 december 1899 för dessa datum. Använd [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) med `CategoryAxisType.Date`, anropa [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) med `false`, och skicka `yyyy` till [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in en rotationsvinkel för ett diagramaxelrubrik**

Anropa [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) med `true` på den vertikala axeln, ange rubriktext och använd [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) för att rotera rubriken. Vinkeln mäts i grader; detta exempel sparar ett stapeldiagram med sin värdeaxelrubrik roterad 90 grader.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in axelposition på en kategori‑ eller värdeaxel**

Använd [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) för att styra om värdeaxeln korsar kategoriaxeln mellan kategorier eller vid kategori‑stapelmärken. Denna inställning gäller kategoriaxlar. Exemplet sätter den till `true` på den horisontella kategoriaxeln i ett stapeldiagram och sparar resultatet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in visningsenhet på en diagramvärdeaxel**

Använd [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) för att skala etiketter på en värdeaxel utan att ändra de underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) satt till `Millions` visas värdet 60 000 000 som 60. Exemplet skapar ett stapeldiagram och använder miljon‑visningsenheten på den vertikala axeln.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Konfigurera en logaritmisk värdeaxel**

En logaritmisk värdeaxel är användbar när positiva värden sträcker sig över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar över fem perioder. På en linjär skala hamnar de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt lättare att jämföra: lika avstånd representerar lika förhållanden snarare än lika skillnader.

Anropa [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) med `true` på värdeaxeln och använd [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) för att välja bas. Detta ändrar hur befintliga värden visas; det ändrar inte data eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i datan och är en separat funktion.

### **Välj värdeaxel och bas**

För ett linje‑ eller stapeldiagram returneras värdeaxeln av [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). För ett horisontellt stapeldiagram returneras den av [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Sprid‑ och bubbeldiagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden eller båda. Använd inte logaritmisk skalning på en kategoriaxel.

Standardbasen för logaritm är `10`. För PPTX‑diagram kan du använda en bas mellan `2` och `1000`, inklusive; bråkbaser som `2.5` stöds också. Med bas `10` är på varandra följande potenser som 10, 100, 1 000 och 10 000 lika avstånd ifrån varandra.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med fem begäranstal på den första bilden, klonar sedan den bilden och aktiverar en logaritmisk värdeaxel med bas 10 på den andra. Båda bilderna behåller samma data.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Behåll den första bilden linjär och ändra endast kopians värdeaxelskala.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Linjär skala (bild 1):** Lika vertikala avstånd representerar lika skillnader i begäranstal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att urskilja.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd representerar lika förhållanden. Varje period har tio gånger så många förfrågningar som föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga begäranstalen.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Hantera noll och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att exkludera dessa värden, förklara undantaget. Ersätt dem inte tyst med små positiva tal, eftersom detta ändrar data­meningen. Alla manuellt konfigurerade minimum eller maximum för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur anger jag det värde där en axel korsar den andra (axelkorsning)?**

Använd [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) för att välja korsningsbeteende. För att specificera ett numeriskt korsningsvärde, använd [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Dessa inställningar låter dig flytta axelkorsningen till en lämplig baslinje.

**Hur kan jag positionera stapel‑etiketter relativt axeln?**

Anropa [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) med någon av [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att kontrollera själva stapelmärkena, använd [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) eller [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); dessa är separata från etikettpositionering.