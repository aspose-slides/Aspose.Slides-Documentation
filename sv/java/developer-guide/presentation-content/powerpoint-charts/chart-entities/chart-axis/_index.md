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
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar med Aspose.Slides för Java. Den täcker beräknade axiellvärden, byte av diagramrader och -kolumner, axiell synlighet, intervall för kategorietiketter och streckmarkeringar, datumkategorier och formatering, titelrotation, axiell placering, displayenheter och logaritmisk skalning.

## **Hämta maximivärdena på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och lägg till ett area‑diagram med standarddata. Anropa [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) innan du läser beräknade axiellvärden så att diagramlayouten är uppdaterad.

Läs [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) och [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) för axiellimitterna, och [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) och [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) för intervallen mellan strecken. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) och [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) tillhandahåller tidsenhetsskalan, vilket är relevant för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

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

Använd [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) för att byta rollerna mellan serier och kategorier i diagramdata. Varje tidigare kategori blir en serie och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte ut de horisontella och vertikala axlarna. Exemplet använder [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori­kolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

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

## **Ändra en kategori­axel**

Använd [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) för att välja en datum‑ eller textkategoriexel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategori­celler som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Genom att anropa [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) med `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) med `1` och [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) med `TimeUnitType.Months` placeras huvudstrecken med ett‑månadsintervall.

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

## **Styr intervallen för kategoriexeltiketter**

När ett diagram har många kategorier kan du minska antalet synliga axiellabeler utan att ta bort kategorier eller datapunkter. Anropa [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) med `false`, och skicka sedan önskat kategoriintervall till [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). För textkategorier i normal ordning börjar räknandet på den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Ett intervall på `3` visar var tredje etikett, med två etiketter dolda mellan de som visas. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på det tillgängliga utrymmet; det visar inte nödvändigtvis varje etikett.

Streckmarkeringar har separata kontroller. Anropa [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) med `false` och använd [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) för att ange deras intervall. Till exempel behåller `1` ett streck på varje kategoriintervall medan etiketter bara visas var tredje kategori. Använd [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) med en synlig stil så att du kan se resultatet. Att återigen sätta någon av de automatiska intervall‑inställningarna till `true` låter diagrammet välja intervallet på nytt.

Följande självständiga exempel skapar 24 kategorier och en serie, och sparar sedan tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikett‑spacing med oberoende streckmarkeringar och återställd automatisk spacing. De två kopiorna behåller den ursprungliga diagramdatan. Ingen inmatningspresentation krävs. Horisontell etikett‑text gör skillnaden i densitet lätt att se.

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

    // Bild 2: visa var tredje etikett, men behåll ett streck för varje kategori.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Bild 3: låt diagrammet välja båda intervallen igen.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatisk spacing (bild 1):** I den här renderingen visas varannan kategorietikett och radbryts till två rader. Det automatiska resultatet kan variera med diagramstorlek, typsnitt och renderaren.

![Automatisk kategorietikettspacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell spacing (bild 2):** Var tredje etikett visas på en rad, medan streckmarkeringarna förblir på varje kategoriintervall. Alla 24 kolumner, även de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utformning som visas ovan.

![Manuell kategorietikettintervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑räkningsintervall för en textkategoriexel, såsom kategori­axeln i ett stapeldiagram, linjediagram, area‑diagram eller stapeldiagram. I ett stapeldiagram är det den horisontella axeln. I ett horisontellt stapeldiagram är kategori­axeln vertikal, så tillämpa dessa inställningar på axeln som returneras av [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Intervall för streckmarkeringar gäller också för en serieaxel i diagram som har en.

Använd inte kategori­etikett‑spacing för att ställa in den numeriska skalan på en värdeaxel. På en värdeaxel anger [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) ett värdesskillnad: t.ex. ger en huvudenhet på `10` streck vid 0, 10, 20 osv. när axeln börjar på noll. Ett kategori­etikettintervall på `3` räknar istället kategori­positioner, oberoende av deras datavärden. Spridnings‑ och bubbeldiagram använder värdeaxlar snarare än en textkategoriexel. För en datumaxel, använd tidsbaserade huvud‑enheter och skalor som beskrivs i [Ändra en kategori­axel](#ändra-en‑kategori­axel).

## **Ställ in datumformatet för kategori­axiellvärden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE‑Automation‑serienummer i det första kalkylbladet (index `0`), beräknat som antalet dagar sedan 30 december 1899 för dessa datum. Använd [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) med `CategoryAxisType.Date`, anropa [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) med `false` och skicka `yyyy` till [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) så att kategori­etiketterna visar fyrsiffriga år oberoende av cellformateringen.

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

## **Ställ in rotationsvinkel för en diagramaxelrubrik**

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

## **Ställ in axelpositionen på en kategori‑ eller värdeaxel**

Använd [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) för att styra om värdeaxeln korsar kategori­axeln mellan kategorier eller vid kategori­streck. Denna inställning gäller för kategori­axlar. Exemplet sätter den på `true` på den horisontella kategori­axeln i ett stapeldiagram och sparar resultatet.

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

## **Ställ in displayenheten på en diagramvärdeaxel**

Använd [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) för att skala etiketter på en värdeaxel utan att ändra underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett stapeldiagram och tillämpar miljon‑displayenheten på dess vertikala axel.

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

En logaritmisk värdeaxel är användbar när positiva värden sträcker sig över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar över fem perioder. På en linjär skala ser de mindre värdena nära varandra nära noll ut. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd motsvarar lika förhållanden snarare än lika differenser.

Anropa [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) med `true` på värdeaxeln och använd [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) för att välja bas. Detta ändrar hur befintliga värden visas; det ändrar inte datan eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i datan och är en separat funktion.

### **Välj värdeaxeln och basen**

För ett linje‑ eller stapeldiagram returneras värdeaxeln av [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). För ett horisontellt stapeldiagram returneras den av [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Spridnings‑ och bubbeldiagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden eller båda. Applicera inte logaritmisk skalning på en kategori­axel.

Standardbasen för logaritmer är `10`. För PPTX‑diagram kan du använda en bas från `2` till `1000`, inklusive; bråkiga baser som `2.5` stöds också. Med bas `10` är successiva potenser som 10, 100, 1 000 och 10 000 jämnt fördelade.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med de fem begärantalena på den första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värdeaxel på den andra. Båda bilderna behåller samma data.

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

**Linjär skala (bild 1):** Lika vertikala avstånd motsvarar lika skillnader i begärantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att urskilja.

![Linjediagram i PowerPoint som visar fem begärantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd motsvarar lika förhållanden. Varje period har tio gånger så många förfrågningar som föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga begärantalena.

![Samma fem begärantal i PowerPoint på en bas‑10 logaritmisk värdeaxel](value-axis-logarithmic.png)

### **Hantera noll‑ och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera datan innan du aktiverar den. Om noll‑ eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att utesluta dessa värden för analysen, förklara borttagandet. Ersätt dem inte tyst med små positiva tal, eftersom det ändrar datans betydelse. Alla manuellt konfigurerade min‑ eller maxvärden för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) för att välja korsningsbeteende. För att ange ett numeriskt korsningsvärde, använd [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). Dessa inställningar låter dig flytta axelkorsningen till en lämplig nollnivå.

**Hur kan jag placera tick‑etiketter i förhållande till axeln?**

Anropa [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) med [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att kontrollera själva streckmarkeringarna, använd [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) eller [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); dessa är separata från etikettplaceringen.