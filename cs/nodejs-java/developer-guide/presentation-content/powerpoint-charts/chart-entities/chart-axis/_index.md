---
title: Přizpůsobení os grafu v prezentacích pomocí JavaScriptu
linktitle: Osa grafu
type: docs
url: /cs/nodejs-java/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
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
description: "Objevte, jak pomocí JavaScriptu s Aspose.Slides pro Node.js přes Javu přizpůsobit osy grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Node.js prostřednictvím Javy. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek dělení, datumové kategorie a formátování, otáčení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získat maximální hodnoty na svislé ose v grafech**

Vytvořte [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Před načtením vypočítaných hodnot os zavolejte [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) , aby byl rozvržení grafu aktuální.

Načtěte [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) a [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) pro limity os a [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) a [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) a [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

Použijte [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupení dat; neprohodí se vodorovná a svislá osa. Příklad používá [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku s hlavičkou a sloupce s kategoriemi, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Obrátit pořadí vykreslování osy**

Použijte [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) k obrácení kategoriové nebo hodnotové osy. Například vodorovný sloupcový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neradí ani nepřeskupuje data sešitu. Na srovnání, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) vyměňuje role řad a kategorií.

Následující příklad vytvoří vodorovný sloupcový graf se třemi fázemi a jednou řadou. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejný datový soubor a na každé kopii je obrácena jen jedna osa.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Snímek 2: zobrazit první kategorii nahoře.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Ponechat vodorovnou hodnotovou osu dole.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Snímek 3: obrátit pouze vodorovné číselné měřítko.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obrácení osy může také přesunout kolmá osu na opačnou stranu grafu. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) určuje, kde druhá osa protíná konfigurovanou osu. Ve snímku 2, zavolání s `aspose.slides.CrossesType.Maximum` na obrácené kategoriové ose ponechává vodorovnou hodnotovou osu dole. Pro specifický průsečík použijte [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Zkontrolujte nastavení průsečíků při změně směru, zejména pokud má graf již vlastní průsečík. Zavolejte `setPlotOrderReversed` s `false` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový graf s normálním pořadím kategorií a hodnotové osy](axis-order-normal.png) | ![Vodorovný sloupcový graf s kategoriemi zobrazenými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží odspodu nahoru; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají nezměněny. | Kategorie zachovávají svůj normální pořádek; hodnoty rostou zprava doleva. Kategorieová osa protíná v nule vpravo. |

## **Zakázat svislou osu pro liniové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) s `false` na svislé ose, aby byla skryta. Příklad vytvoří liniový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázat vodorovnou osu pro liniové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) s `false` na vodorovné ose, aby byla skryta. Příklad vytvoří liniový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna kategoriové osy**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) pro výběr datumové nebo textové kategoriové osy. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první tvar na prvním snímku a buňky kategorie obsahují číselné hodnoty Excelových dat. Změní vodorovnou osu na datumovou osu. Zavolání [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) s `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) s `TimeUnitType.Months` umístí hlavní značky v intervalech jednoho měsíce.

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

## **Ovládání intervalů popisků kategoriové osy**

Když má graf mnoho kategorií, můžete snížit počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) s `false` a poté předejte požadovaný interval kategorií metodě [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Pro textové kategorie v jejich normálním pořadí se číslování začíná u první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Interval `3` zobrazuje každý třetí popisek, přičemž mezi zobrazenými popisky jsou dva skryté. Nepřidává to odpovídající sloupce. Automatické rozestupy volí interval na základě dostupného prostoru; nemusí nutně zobrazovat každý popisek.

Značky dělení mají samostatné ovládání. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) pro nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorie, zatímco popisky se zobrazí jen každé třetí kategorie. Použijte [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) s viditelným stylem, abyste viděli výsledek. Opětovné nastavení automatického rozestupu voláním příslušného nastavitelského metody s `true` umožní grafu znovu zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami dělení a obnovené automatické rozestupy. Obě kopie zachovávají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisku usnadňuje vnímat rozdíl v hustotě.

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

    // Snímek 2: zobrazit každý třetí popisek, ale zachovat značku dělení pro každou kategorii.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Snímek 3: nechat graf znovu zvolit oba intervaly.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatické rozestupy (snímek 1):** V tomto vykreslení je zobrazen každý druhý popisek kategorie a ten se zalamuje na dva řádky. Automatický výsledek se může lišit podle velikosti grafu, fontů a rendereru.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční rozestupy (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky dělení zůstávají na každém intervalu kategorie. Všechny 24 sloupce, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Ruční interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou kategoriovou osu, například kategoriovou osu sloupcového, liniového, plošného nebo sloupcového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném sloupcovém grafu je kategoriová osa svislá, takže tato nastavení aplikujte na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Rozestupy značek dělení platí také pro osu řady v grafech, které ji mají.

Ne používejte rozestup popisků kategorií k nastavení číselné stupnice hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) určuje rozdíl hodnot: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich datové hodnoty. Grafy rozptylu a bublin používají hodnotové osy místo textové kategoriové osy. Pro datumovou osu použijte časově založené hlavní jednotky a stupnice, jak je popsáno v [Změna kategoriové osy](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty kategoriové osy**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první listu (index `0`), vypočítaná jako počet dní od 30. prosince 1899. Výpočet v JavaScriptu používá UTC časové značky a dělí rozdíl 86 400 000 milisekundami za den. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) s `CategoryAxisType.Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) s `false` a předáte `yyyy` metodě [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), aby se popisky kategorií zobrazovaly čtyřciferně jako roky nezávisle na formátování buněk.

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

## **Nastavení úhlu otáčení názvu osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) s `true` na svislé ose, zadejte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) k otočení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení pozice osy na kategoriové nebo hodnotové ose**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) k určení, zda hodnotová osa protíná kategoriovou osu mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro kategoriové osy. Příklad nastaví hodnotu na `true` na vodorovné kategoriové ose sloupcového grafu a uloží výsledek.

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

Použijte [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) ke škálování popisků na hodnotové ose, aniž by se změnila podkladová data. S [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku zobrazení milionů na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, když kladné hodnoty sahají přes několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineárním měřítku se menší hodnoty zobrazují těsně u nuly. Logaritmické měřítko usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) k volbě základu. Tím se změní způsob, jakým jsou existující hodnoty zobrazeny; data ani žádná logaritmická trendová čára se nezmění. Trendová čára představuje modelovaný vztah v datech a je samostatnou funkcí.

### **Vyberte hodnotovou osu a základ**

Pro liniový nebo sloupcový graf je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Pro vodorovný sloupcový graf je to metoda [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Grafy rozptylu a bublin mají dvě hodnotové osy, takže pro hodnoty X vyberte vodorovnou osu, pro hodnoty Y svislou osu nebo obě. Logaritmické škálování neaplikujte na kategoriovou osu.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ v rozmezí `2` až `1000` včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny jako 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří liniový graf s pěti počty požadavků na prvním snímku, poté klonuje tento snímek a povolí logaritmickou hodnotovou osu s bází 10 na druhém. Oba snímky zachovávají stejná data.

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

    // Zachovat první snímek lineární a změnit pouze měřítko hodnotové osy kopie.
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

**Lineární škála (snímek 1):** Stejné svislé vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozeznání menších hodnot.

![Liniový graf v PowerPointu ukazující pět požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné svislé vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí čáru na logaritmickém měřítku se základem 10. Osa stále zobrazuje původní počty požadavků.

![Stejné pět požadavků v PowerPointu na logaritmické hodnotové ose se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmické měřítko může zobrazovat jen striktně kladné hodnoty. Před jeho povolením data zkontrolujte. Pokud jsou nula nebo záporné hodnoty významné, zachovejte lineární měřítko nebo je zobrazte samostatně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nekomentujte je tichým nahrazením malými kladnými čísly, protože to mění význam dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladný.

## **Často kladené otázky**

**Jak nastavit hodnotu, na které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Tato nastavení vám umožní posunout průsečík osy na vhodnou základnu.

**Jak mohu umístit popisky značek relativně k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) s typem [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro ovládání samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) nebo [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); jsou oddělené od umístění popisků.