---
title: Přidání čar trendu do grafů v prezentacích v Javě
linktitle: Čára trendu
type: docs
url: /cs/java/trend-line/
keywords:
- graf
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- trendová čára klouzavého průměru
- polynomická čára trendu
- mocninná čára trendu
- vlastní čára trendu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Rychle přidejte a upravte čáry trendu v grafech PowerPointu pomocí Aspose.Slides pro Java – praktický průvodce, jak zaujmout publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci čáry trendu. Ukazuje, jak vytvořit graf, přidat čáry trendu k sériím grafu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné. Také popisuje, jak do grafu přidat vlastní čáru vložením tvaru čáry, a obsahuje stručné FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání čáry trendu**

Použijte [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) k přidání čáry trendu do série grafu a vyberte její typ pomocí [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). Příklad vytvoří seskupený sloupcový graf s výchozími daty a přidá dvě čáry trendu ke každé ze třech sérií.

Exponenciální čára trendu skryje svou rovnici a hodnotu R‑kvadrát pomocí [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) a [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), zatímco lineární čára trendu je červená. Logaritmická čára trendu používá [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) pro vlastní popisek. Klouzavý průměr používá [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) s třemi datovými body a vlastní [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Polynomická čára trendu má [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) nastavený na tři a rozšiřuje o jednu kategorii dopředu pomocí [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). Mocninná čára trendu rozšiřuje o jednu kategorii dozadu pomocí [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení průsečíku čáry trendu**

Použijte [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) k pevné hodnotě Y čáry trendu při X = 0. Toto nastavení je podporováno pro lineární, exponenciální a polynomické čáry trendu.

Například model výrobních nákladů může vyžadovat zahájení s známými fixními náklady 100, i když měření při nenulových objemech výroby naznačují jinou základní úroveň. Pro lineární čáru trendu pevné nastavení průsečíku omezuje rovnici `y = ax + b` na `b = 100`; sklon je přizpůsoben datům pod tímto omezením. Nejedná se jen o posunutí již vytvořené čáry. Nastavení průsečíku os řídí, kde se osy grafu setkají, nikoli koeficienty přizpůsobené čáry trendu.

Následující příklad vytvoří XY‑rozptylový graf s objemy výroby od 1 do 4 a náklady 170, 200, 230 a 260. Uloží graf s výchozím automatickým průsečíkem, nastaví průsečík na 100 a uloží druhý PPTX. Tyto dva soubory se liší pouze nastavením průsečíku. Čára trendu zobrazuje svou rovnici a rozšiřuje se zpět na X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Při automatickém výpočtu tato data produkují `y = 30x + 140`. Nastavení průsečíku na 100 místo toho přibližně dává `y = 43.33x + 100`: hodnota při nule odpovídá známé základní úrovni, zatímco čára již neprochází všemi datovými body.

| Automatický průsečík | Pevný průsečík 100 |
| --- | --- |
| ![Lineární čára trendu s automaticky vypočteným průsečíkem 140](intercept-automatic.png) | ![Lineární čára trendu s pevným průsečíkem 100](intercept-fixed.png) |

Oba obrázky používají stejná data a měřítka os. Čáry trendu jsou rozšířeny zpět na X = 0, aby ukázaly své průsečíky.

Ve výchozím nastavení [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) vrací `Double.NaN`, což představuje nespecifikovaný průsečík místo nuly. Průsečík je pak automaticky vypočítán z dat.

## **Přidání vlastní čáry**

Vlastní čára je tvar nakreslený nad grafem, nikoli čára trendu vypočtená ze sériových dat. Tento příklad používá [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) k přidání vodorovné čáry na snímek nad graf. Pozice čáry je zadána v souřadnicích snímku, měřených v bodech, takže začíná na levém okraji grafu a leží v polovině výšky grafu. Její šířka odpovídá šířce grafu. [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) dává čáře plnou červenou barvu.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Co znamená 'forward' a 'backward' u čáry trendu?**

Jedná se o délky čáry trendu projektované dopředu/dozadu: pro rozptylové (XY) grafy — v jednotkách os; pro jiné grafy — v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/java/convert-powerpoint-to-pdf/) nebo [SVG](/slides/cs/java/render-a-slide-as-an-svg-image/) a vykresluje grafy do obrázků; čáry trendu jako součást grafu jsou během těchto operací zachovány. K dispozici je také metoda pro [export obrázku grafu](/slides/cs/java/create-shape-thumbnails/).