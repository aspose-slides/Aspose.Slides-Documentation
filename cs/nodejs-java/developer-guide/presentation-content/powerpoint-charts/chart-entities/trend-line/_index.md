---
title: Přidání trendových čar do grafů v prezentaci v JavaScriptu
linktitle: Trendová čára
type: docs
url: /cs/nodejs-java/trend-line/
keywords:
- graf
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- trendová čára s klouzavým průměrem
- polynomiální trendová čára
- mocninová trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Rychle přidejte a upravte trendové čáry v grafech PowerPointu pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java — praktický návod, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci trendové čáry. Ukazuje, jak vytvořit graf, přidat trendové čáry k sériím grafu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomiální a mocninové.

Také popisuje, jak přidat vlastní čáru do grafu vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce trendové čáry dopředu a dozadu a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidat trendovou čáru**

Použijte [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) k přidání trendové čáry do série grafu a vyberte její typ pomocí [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Příklad vytváří seskupený sloupcový graf s výchozími daty a přidává dvě trendové čáry ke každé ze svých tří sérií.

Exponenciální trendová čára skrývá svůj rovnice a hodnotu R‑squared pomocí [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) a [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), zatímco lineární trendová čára je červená. Logaritmická trendová čára používá [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) pro vlastní popisek. Klouzavý průměr používá [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) se třemi datovými body a vlastní [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName).

Polynomiální trendová čára má [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) tři a prodlužuje o jednu kategorii dopředu pomocí [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Mocninová trendová čára prodlužuje o jednu kategorii dozadu pomocí [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit průsečík trendové čáry**

Použijte [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) k upevnění hodnoty Y trendové čáry při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomiální trendové čáry.

Například model nákladů na výrobu může vyžadovat zahájení známými pevnými náklady ve výši 100, i když měření při nenulových objemech výroby naznačují jiný výchozí bod. Pro lineární trendovou čáru pevné nastavení průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejedná se o pouhé posunutí již natrénované čáry. Nastavení průsečíků os určuje, kde se osy grafu setkají, nikoli koeficienty natrénované trendové čáry.

Následující příklad vytváří bodový (XY) graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečíkem, nastaví průsečík na 100 a uloží druhý soubor PPTX. Oba soubory se liší pouze v nastavení průsečíku. Trendová čára zobrazuje svou rovnici a prodlužuje se zpět až k X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Při automatickém výpočtu tato data dávají `y = 30x + 140`. Nastavení průsečíku na 100 místo toho dává přibližně `y = 43.33x + 100`: hodnota při nule odpovídá známému výchozímu bodu, zatímco čára již neprochází všemi datovými body.

| Automatický průsečík | Pevný průsečík 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Obě obrázky používají stejná data a měřítka os. Trendové čáry jsou prodlouženy zpět k X = 0, aby zobrazily své průsečíky.

Ve výchozím nastavení [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) vrací `NaN`, což představuje neurčený průsečík, nikoli nulu. Průsečík je pak spočítán automaticky z dat.

## **Přidat vlastní čáru**

Vlastní čára je tvar nakreslený nad grafem, nikoli trendová čára vypočítaná ze sériových dat. Tento příklad používá [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) k přidání vodorovné čáry na snímek nad graf. Pozice čáry je specifikována v souřadnicích snímku, měřených v bodech, takže začíná u levého okraje grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) dává čáře plnou červenou barvu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Co znamenají „forward“ a „backward“ u trendové čáry?**

Jedná se o délky trendové čáry promítnuté dopředu či dozadu: pro bodové (XY) grafy – v jednotkách os; pro jiné grafy – v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane trendová čára zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku do obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/) a vykresluje grafy do obrázků; trendové čáry jako součást grafu jsou během těchto operací zachovány. K dispozici je také metoda k [exportovat obrázek grafu](/slides/cs/nodejs-java/create-shape-thumbnails/).