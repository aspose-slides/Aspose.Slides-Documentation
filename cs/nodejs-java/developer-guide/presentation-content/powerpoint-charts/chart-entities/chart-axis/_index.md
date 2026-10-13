---
title: Přizpůsobení os grafu v prezentacích pomocí JavaScriptu
linktitle: Osa grafu
type: docs
url: /cs/nodejs-java/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte, jak pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java přizpůsobit osy grafu v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Node.js přes Java. Pokrývá vypočtené hodnoty os, přepínání řádků a sloupců v grafu, viditelnost os, intervaly popisků kategorií a značek, datumové kategorie a formátování, otáčení názvu, umístění osy, jednotky zobrazení a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose v grafech**

Vytvořte [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) před čtením vypočtených hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) a [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) pro limity osy a [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) a [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) a [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

## **Prohození dat mezi osami**

Použijte [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se mění způsob seskupení dat; neprohazuje to vodorovnou a svislou osu. Příklad používá [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku s hlavičkou a sloupce s kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Skrytí svislé osy u čárových grafů**

Zavolejte [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) s hodnotou `false` na svislé ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Skrytí vodorovné osy u čárových grafů**

Zavolejte [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) s hodnotou `false` na vodorovné ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna osy kategorie**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) k výběru datumové nebo textové osy kategorie. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první tvar na první snímku a buňky kategorie obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Voláním [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) s `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) s `TimeUnitType.Months` umístí hlavní značky v jednomměsíčních intervalech.

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

## **Řízení intervalů popisků osy kategorie**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) s hodnotou `false` a pak předejte požadovaný interval kategorie metodě [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Pro textové kategorie v jejich normálním pořadí se číslování začíná od první kategorie:

| Interval | Štítky zobrazené v příkladu |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interval `3` zobrazí každý třetí štítek a mezi zobrazenými štítky skryje dva štítky. Nepřidává to odpovídající sloupce. Automatické rozestupy volí interval na základě dostupného místa; nemusí nutně zobrazit každý štítek.

Značky mají samostatná nastavení. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) k nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorie, zatímco štítky se zobrazí jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) s viditelným stylem, aby byl výsledek patrný. Voláním kteréhokoli nastavení automatického rozestupu s `true` znovu umožníte grafu zvolit ten interval automaticky.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky v souboru `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovávají původní data grafu. Žádná vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje vnímat rozdíl v hustotě.

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

    // Snímek 2: zobrazit každý třetí štítek, ale ponechat značku pro každou kategorii.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Snímek 3: nechat graf znovu vybrat oba intervaly.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatické rozestupy (snímek 1):** V tomto zobrazení je každý druhý popisek kategorie zobrazen a zalamuje se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího nástroje.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Ruční rozestupy (snímek 2):** Každý třetí štítek je zobrazen na jednom řádku, zatímco značky zůstávají na každém intervalu kategorie. Všechny 24 sloupců, včetně těch bez štítků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled zobrazený výše.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Výběr správné osy a intervalu**

Použijte tento interval počtu kategorií pro textovou osu kategorie, např. osu kategorie sloupcového, čárového, plošného nebo pruhového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je osa kategorie svislá, takže použijte tato nastavení na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Rozestup značek se také vztahuje na osu řady v grafech, které ji mají.

Není vhodné používat rozestup popisků kategorie k nastavení číselné škály hodnotové osy. Na hodnotové ose metoda [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) udává rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 … když osa začíná nulou. Interval popisků kategorie `3` počítá pozice kategorií bez ohledu na jejich hodnoty. Rozptylové a bublinové grafy používají hodnotové osy místo textové osy kategorie. Pro datumovou osu použijte časové hlavní jednotky a měřítka, jak je popsáno v sekci [Změna osy kategorie](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty osy kategorie**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první listu (index `0`), počítaná jako počet dní od 30. prosince 1899. Výpočet v JavaScriptu používá UTC časové značky a dělí rozdíl 86 400 000 ms za den. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) s `CategoryAxisType.Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) s `false` a předejte `yyyy` metodě [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), aby se popisky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení názvu osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) s `true` na svislé ose, zadejte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) k otočení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s otočeným názvem hodnotové osy o 90 stupňů.

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

## **Nastavení polohy osy na ose kategorie nebo hodnoty**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) k řízení, zda hodnotová osa protíná osu kategorie mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro osy kategorie. Příklad nastaví hodnotu na `true` na vodorovné ose kategorie sloupcového grafu a výsledek uloží.

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

## **Nastavení jednotky zobrazení na hodnotové ose grafu**

Použijte [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) ke škálování štítků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku zobrazení milionů na jeho svislé ose.

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

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty těsně u nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejný poměr, ne stejný rozdíl.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) k výběru základu. Tím se změní způsob, jakým jsou existující hodnoty zobrazovány; nezmění to data ani nepřidá logaritmickou trendovou čáru. Trendová čára představuje přizpůsobený vztah v datech a je samostatnou funkcí.

### **Výběr hodnotové osy a základu**

U čárového nebo sloupcového grafu je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). U vodorovného pruhového grafu je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Rozptylové a bublinové grafy mají dvě hodnotové osy, takže pro X‑hodnoty použijte vodorovnou osu, pro Y‑hodnoty svislou nebo obě. Logaritmické škálování neaplikujte na osu kategorie.

Výchozí logaritmický základ je `10`. Pro PPTX grafy je povolen základ od `2` do `1000` včetně; podporovány jsou i zlomkové základy, např. `2.5`. Se základem `10` jsou po sobě jdoucí mocniny (10, 100, 1 000, 10 000) rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek zduplikuje a na druhém povolí logaritmickou hodnotovou osu s bází 10. Oba snímky zachovávají stejná data.

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

    // Udržte první snímek lineární a změňte pouze měřítko hodnotové osy kopie.
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

**Lineární stupnice (snímek 1):** Stejné svislé vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, takže menší hodnoty jsou těžko rozlišitelné.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmická stupnice (snímek 2):** Stejné svislé vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí čáru na bázi 10. Osy stále zobrazují původní počty požadavků.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmické škálování může zobrazovat jen přísně kladné hodnoty. Před jeho zapnutím data zkontrolujte. Pokud jsou nuly nebo záporné hodnoty významné, zachovejte lineární stupnici nebo je zobrazte odděleně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, uveďte důvod vynechání. Nekrémujte je tiše malými kladnými čísly, protože tím měníte význam dat. Jakékoli ručně nastavené minimum nebo maximum logaritmické osy musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průnik os)?**

Použijte [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) k výběru chování průniku. Pro určení číselné hodnoty průniku použijte [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Tímto nastavením můžete posunout průnik osy na vhodnou úroveň.

**Jak mohu umístit popisky značek relativně k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) s typem [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro nastavení samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) nebo [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); jsou oddělené od umístění popisků.