---
title: Přizpůsobení legend grafů v prezentacích pomocí PHP
linktitle: Legenda grafu
type: docs
url: /cs/php-java/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro PHP přes Java a optimalizujte prezentace PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides for PHP via Java poskytuje možnosti přizpůsobení legendy grafu v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivou položku legendy a skrýt nebo obnovit vybrané položky.

Často kladené otázky pokrývají související chování, včetně rezervace místa pro legendu, zobrazování víceliniových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Použijte metody legendy [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) a [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) k určení jejího umístění a velikosti jako zlomků rozměrů grafu.

Tento příklad vytvoří prezentaci a přidá na první snímek klastrový sloupcový graf s výchozími daty. Rozdělením požadovaných odsazení a rozměrů legendy šířkou a výškou grafu je převede na relativní hodnoty: legenda je posunuta o 50 bodů od levého horního rohu grafu a má velikost 100 × 100 bodů. Příklad používá java_values k převodu rozměrů grafu vrácených PHP/Java Bridge na čísla PHP před dělením.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Vyjádřete pozici a velikost legendy vzhledem k grafu.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení velikosti písma legendy**

Použijte [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) k získání formátování textu legendy a [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) k nastavení velikosti písma v bodech.

Tento příklad vytvoří graf s výchozími daty a nastaví text legendy na 20 bodů. Také zakáže automatické ohraničení pro svislou osu a nastaví její rozsah od -5 do 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení velikosti písma jednotlivé položky legendy**

Použijte kolekci vrácenou metodou [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) k získání formátování konkrétní položky. Indexy položek jsou nulové, takže index `1` odkazuje na druhou položku.

Tento příklad vytvoří klastrový sloupcový graf, jehož výchozí data obsahují alespoň dvě řady. Formátuje druhou položku legendy tučným, kurzívovým textem o velikosti 20 bodů a modrou barvou.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Skrytí jednotlivých položek legendy**

Chcete‑li vyloučit pomocnou řadu z legendy při zachování jejích dat, zavolejte [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) s hodnotou `true` přes [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Tím se skryje pouze vybraná položka legendy; řada ani její datové body nebudou odebrány. Naopak zavoláním [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) s hodnotou `false` skryjete celou legendu.

Níže uvedený příklad vytvoří klastrový sloupcový graf s několika řadami pomocí výchozích dat. Skryje legendu druhé řady (index `1`) a uloží prezentaci. Poté položku obnoví voláním [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) s hodnotou `false` a uloží druhou kopii. Sloupce zůstávají viditelné v obou souborech.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Obnovit stejnou položku bez změny dat grafu.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Níže uvedené srovnání ukazuje stejný graf se všemi položkami legendy viditelnými a s druhou položkou skrytou. Sloupce druhé řady zůstávají nezměněny.

![Porovnání grafu se všemi položkami legendy viditelnými a s řadou 2 skrytou v legendě; všechny sloupce jsou stále viditelné.](hide-legend-entry.png)

V sloupcových, pruhových a čárových grafech položky legendy identifikují řady. U koláčových grafů identifikují jednotlivé datové body (výseče), takže místo toho použijte [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) na vybrané výseči. API dokumentuje tuto metodu datového bodu pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepředpokládejte, že se vztahuje na prstencové grafy, které v tomto seznamu nejsou.

## **Často kladené otázky**

**Mohu nechat graf vyhradit místo pro legendu místo toho, aby ji překrýval?**

Ano. Zavolejte [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) s hodnotou `false`, aby legenda vyhradila místo místo toho, aby překrývala oblast grafu.

**Mohu vytvořit víceliniové popisky legendy?**

Ano. Dlouhé popisky se mohou zalomit, pokud dostupná šířka není dostatečná. Můžete také použít znak nového řádku ve jménech řad pro vložení zalomení.

**Jak zajistit, aby legenda následovala barevné schéma motivu prezentace?**

Ponechte barvy, výplně a písma legendy nenastavené, aby mohla dědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.