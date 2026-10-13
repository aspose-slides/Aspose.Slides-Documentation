---
title: Anpassa diagramaxlar i presentationer med JavaScript
linktitle: Diagramaxel
type: docs
url: /sv/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du använder JavaScript med Aspose.Slides för Node.js via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur man anpassar diagramaxlar med Aspose.Slides för Node.js via Java. Den täcker beräknade axelvärden, byte av diagramrader och -kolumner, axelns synlighet, intervall för kategorietiketter och stapelflaggor, datumkategorier och formatering, titelrotation, axelpositionering, visningsenheter och logaritmisk skalning.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) och lägg till ett ytdiagram med standarddata. Anropa [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) innan du läser beräknade axelvärden så att diagramlayouten är uppdaterad.

Läs [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) och [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) för axelgränserna, samt [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) och [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) för stapelflaggintervall. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) och [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) ger tidsenhetsskalor, vilket är relevant för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Byt data mellan axlar**

Använd [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) för att byta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte horisontella och vertikala axlar. Exemplet använder [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori‑kolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Inaktivera den vertikala axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) med `false` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Inaktivera den horisontella axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) med `false` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ändra en kategoriaxel**

Använd [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) för att välja en datum‑ eller textkategoriaxel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategori‑celler som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Anropa [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) med `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) med `1` och [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) med `TimeUnitType.Months` för att placera huvudstaplar med en‑månaders intervall.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Styr intervaller för kategoriaxelns etiketter**

När ett diagram har många kategorier, minska antalet synliga axel‑etiketter utan att ta bort kategorier eller datapunkter. Anropa [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) med `false`, och skicka sedan det önskade kategori‑intervallet till [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). För textkategorier i deras normala ordning börjar räknandet på den första kategorin:

| Interval | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Ett intervall på `3` visar var tredje etikett, med två etiketter dolda mellan de visade. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; det visar inte nödvändigtvis varje etikett.

Stapelflaggor har separata kontroller. Anropa [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) med `false` och använd [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) för att ange deras intervall. Till exempel behåller `1` en stapelflagga vid varje kategoriintervall medan etiketter bara visas var tredje kategori. Använd [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) med en synlig stil så att du kan se resultatet. Att anropa någon av de automatiska spacing‑inställarna med `true` igen låter diagrammet välja det intervallet på nytt.

Följande självständiga exempel skapar 24 kategorier och en serie, sparar sedan tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikett‑spacing med oberoende stapelflaggor och återställd automatisk spacing. De två kopiorna behåller den ursprungliga diagramdatan. Ingen indatanpresentation krävs. Horisontell etikett‑text gör skillnaden i densitet lätt att se.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Bild 2: visa var tredje etikett, men behåll en stapelflagga för varje kategori.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Bild 3: låt diagrammet välja båda intervallerna igen.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatisk spacing (bild 1):** I denna rendering visas varannan kategori‑etikett och radbryts på två rader. Det automatiska resultatet kan variera med diagramstorlek, teckensnitt och renderare.

![Automatisk kategori‑etikettspacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell spacing (bild 2):** Var tredje etikett visas på en rad, medan stapelflaggor förblir vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utseendet som visas ovan.

![Manuell kategori‑etikettintervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj korrekt axel och intervall**

Använd detta kategori‑antal‑intervall för en textkategoriaxel, till exempel kategori­axeln i ett stapel‑, linje‑, yt‑ eller stapeldiagram. I ett stapeldiagram är det den horisontella axeln. I ett horisontellt stapeldiagram är kategori­axeln vertikal, så tillämpa dessa inställningar på axeln som returneras av [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Stapelflaggs‑spacing gäller också för en serieaxel i diagram som har en sådan.

Använd inte kategori‑etikett‑spacing för att ställa in den numeriska skalan för en värdeaxel. På en värdeaxel specificerar [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) ett värdeskillnad: till exempel ger en huvud‑enhet på `10` staplar vid 0, 10, 20 osv när axeln startar vid noll. Ett kategori‑etikett‑intervall på `3` räknar kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubbeldiagram använder värdeaxlar snarare än en text‑kategori­axel. För en datumaxel, använd tidsbaserade huvud‑enheter och skalor som beskrivs i [Ändra en kategoriaxel](#change-a-category-axis).

## **Ställ in datumformatet för kategori­axelns värden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE‑Automation‑serienummer i det första kalkylbladet (index `0`), beräknat som antalet dagar sedan 30 december 1899 för dessa datum. JavaScript‑beräkningen använder UTC‑tidsstämplar och delar skillnaden med 86 400 000 millisekunder per dag. Använd [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) med `CategoryAxisType.Date`, anropa [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) med `false` och skicka `yyyy` till [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in en rotationsvinkel för en diagramaxeltitel**

Anropa [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) med `true` på den vertikala axeln, ange titeltext och använd [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) för att rotera titeln. Vinkeln mäts i grader; detta exempel sparar ett stapeldiagram med dess värde‑axeltitel roterad 90 grader.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in axelposition på en kategori‑ eller värdeaxel**

Använd [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) för att styra om värdeaxeln korsar kategori­axeln mellan kategorier eller vid kategori‑stapelflaggor. Denna inställning gäller kategori­axlar. Exemplet sätter den till `true` på den horisontella kategori­axeln i ett stapeldiagram och sparar resultatet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in visningsenhet på en diagramvärdeaxel**

Använd [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) för att skala etiketter på en värdeaxel utan att ändra underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett stapeldiagram och applicerar miljon‑visningsenheten på dess vertikala axel.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Konfigurera en logaritmisk värdeaxel**

En logaritmisk värdeaxel är användbar när positiva värden spänner över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar under fem perioder. På en linjär skala framträder de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd motsvarar lika förhållanden snarare än lika skillnader.

Anropa [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) med `true` på värdeaxeln och använd [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) för att välja basen. Detta förändrar hur befintliga värden visas; det ändrar inte data eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i data och är en separat funktion.

### **Välj värdeaxel och bas**

För ett linje‑ eller stapeldiagram returneras värdeaxeln av [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). För ett horisontellt stapeldiagram returneras den av [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Spridnings‑ och bubbeldiagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden, eller båda. Applicera inte logaritmisk skalning på en kategori­axel.

Standardbasen för logaritmisk skala är `10`. För PPTX‑diagram kan du använda en bas mellan `2` och `1000`, inklusive; bråktalsbaser som `2.5` stöds också. Med bas `10` är på varandra följande potenser såsom 10, 100, 1 000 och 10 000 jämt avstånd.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med de fem förfrågningsantalena på den första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värdeaxel på den andra. Båda bilderna behåller samma data.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Behåll den första bilden linjär och ändra endast kopians värdeaxelskala.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Linjär skala (bild 1):** Lika vertikala avstånd motsvarar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att urskilja.

![Linje‑diagram i PowerPoint som visar fem förfrågningsantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd motsvarar lika förhållanden. Varje period har tio gånger så många förfrågningar som den föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem förfrågningsantal i PowerPoint på en bas‑10 logaritmisk värdeaxel](value-axis-logarithmic.png)

### **Hantera noll och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att utesluta dessa värden för analysen, förklara uteslutandet. Ersätt dem inte tyst med små positiva tal, eftersom det förändrar datans innebörd. Eventuellt manuellt konfigurerat minimum eller maximum för en logaritmisk axel måste också vara positivt.

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) för att välja korsningsbeteende. För att specificera ett numeriskt korsningsvärde, använd [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Dessa inställningar låter dig flytta axelkorsningen till en lämplig baslinje.

**Hur kan jag placera stapel‑etiketter i förhållande till axeln?**

Anropa [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) med [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att styra stapelflaggorna själva, använd [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) eller [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); dessa är separata från etikettplaceringen.