---
title: Přizpůsobení legend grafů v prezentacích pomocí JavaScriptu
linktitle: Legenda grafu
type: docs
url: /cs/nodejs-java/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Node.js přes Java a optimalizujte prezentace PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides for Node.js via Java poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma celé legendy, formátovat jednotlivou položku legendy a skrýt nebo obnovit vybrané položky.

Často kladené otázky (FAQ) pokrývají související chování, včetně rezervace místa pro legendu, zobrazení víceřádkových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Pro určení polohy a velikosti legendy jako zlomků rozměrů grafu použijte metody legendy [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) a [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/).

Tento příklad vytvoří prezentaci a přidá na první snímek shlukový sloupcový graf s výchozími daty. Rozdělením požadovaných posunů a rozměrů legendy šířkou a výškou grafu na relativní hodnoty získáme: legenda je posunuta o 50 bodů od levého horního rohu grafu a má velikost 100 × 100 bodů.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Vyjádřete polohu a velikost legendy relativně k grafu.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení velikosti písma legendy**

Pro přístup k formátování textu legendy použijte [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) a k nastavení velikosti písma v bodech použijte [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight).

Tento příklad vytvoří graf s výchozími daty a nastaví text legendy na 20 bodů. Také zakáže automatické hranice pro svislou osu a nastaví její rozsah od –5 do 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení velikosti písma jednotlivé položky legendy**

Pro přístup k formátování konkrétní položky použijte kolekci vrácenou metodou legendy [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/). Indexy položek jsou nulové, takže index `1` odkazuje na druhou položku.

Tento příklad vytvoří shlukový sloupcový graf, jehož výchozí data obsahují alespoň dva řady. Formátuje druhou položku legendy tučně, kurzívou a modrým textem o velikosti 20 bodů.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Skrytí jednotlivých položek legendy**

Chcete‑li vyloučit pomocnou řadu z legendy a přitom zachovat její data viditelná, zavolejte [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) s hodnotou `true` přes [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Tím se skryje pouze vybraná položka legendy; řada ani její datové body nejsou odstraněny. Naopak volání [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) s hodnotou `false` skryje celou legendu.

Níže uvedený příklad vytvoří shlukový sloupcový graf s více řadami pomocí výchozích dat. Skryje legendu druhé řady (index `1`) a prezentaci uloží. Poté položku obnoví voláním [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) s hodnotou `false` a uloží druhou kopii. Sloupce zůstávají viditelné v obou souborech.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Obnovit stejnou položku bez změny dat grafu.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Porovnání níže ukazuje stejný graf se všemi položkami legendy viditelnými a s druhou položkou skrytou. Sloupce druhé řady zůstávají nezměněny.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

U sloupcových, pruhových a čárových grafů položky legendy identifikují řady. U koláčových grafů identifikují jednotlivé datové body (kousky), takže místo toho použijte [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) na vybraný výsek. API tuto metodu popisuje pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepředpokládejte, že platí i pro prstencové grafy, které v tomto seznamu nejsou zahrnuty.

## **FAQ**

**Mohu nastavit, aby graf vyhradil místo pro legendu místo jejího překrývání?**

Ano. Zavolejte [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) s hodnotou `false`, aby se pro legendu rezervovalo místo místo toho, aby překrývala oblast grafu.

**Mohu vytvořit víceřádkové popisky legendy?**

Ano. Dlouhé popisky se při nedostatečné šířce automaticky zalomí. Můžete také použít znaky nového řádku v názvech řad k vytvoření zlomů řádků.

**Jak zajistím, aby legenda následovala schéma barev motivu prezentace?**

Nechte barvy, výplně a písma legendy nedefinované, aby mohla zdědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.