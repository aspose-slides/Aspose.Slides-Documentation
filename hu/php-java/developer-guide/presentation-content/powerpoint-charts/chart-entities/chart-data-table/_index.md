---
title: Diagram adat-táblák testreszabása prezentációkban PHP használatával
linktitle: Adat tábla
type: docs
url: /hu/php-java/chart-data-table/
keywords:
- diagram adat
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Testreszabja a diagram adat-tábla betűtípusait, szegélyeit és jelmagyarázat kulcsait PowerPoint prezentációkban az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetővé teszi egy diagram adat-táblázatának megjelenítését, valamint a szövegformázás, a szegélyek és a jelmagyarázat kulcsok testreszabását. Ez a cikk bemutatja, hogyan engedélyezzük a táblát, formázzuk a szöveget, szabályozzuk a szegélyek típusait, és hogyan jeleníthetjük meg vagy rejthetjük el a jelmagyarázat kulcsait. A példák a beállított diagramokat PPTX fájlokba mentik.

## **Betűtípus tulajdonságainak beállítása**

Az adat-tábla megjelenítéséhez adja át a `true` értéket a [setDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setdatatable/) metódusnak. Használja a [getChartDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/getchartdatatable/) metódust a tábla eléréséhez és a szövegformázás beállításához.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály segítségével.  
1. Adjon egy csoportos oszlopdiagramot az első diára.  
1. Engedélyezze a diagram adat-tábláját.  
1. Engedélyezze a félkövér szöveget a [setFontBold](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontBold) metódussal, és adja át a `20` értéket a [setFontHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/#setFontHeight) metódusnak a 20 pontos szöveghez.  
1. Mentse el a módosított prezentációt.

Az alábbi példa a munkakönyvtárban lévő `test.pptx` fájlt igényli, amely legalább egy diát tartalmaz. A példa egy alapértelmezett adatokkal rendelkező diagramot ad hozzá a (50, 50) pozícióba, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` tartalmazza a diagramot az engedélyezett adat-táblával és a megadott betűtípus-beállításokkal.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Az adat-tábla szegélyeinek testreszabása**

A táblát a [Chart::setDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setdatatable/) metódussal engedélyezheti, és a [Chart::getChartDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/getchartdatatable/) metódussal érheti el. Három szegélytípust szabályozhat függetlenül:

- A [setBorderHorizontal](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setborderhorizontal/) a vízszintes cella-szegélyeket kezeli.  
- A [setBorderVertical](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setbordervertical/) a függőleges cella-szegélyeket kezeli.  
- A [setBorderOutline](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setborderoutline/) a táblázat külső szegélyét kezeli.

Adja át a `true` értéket minden módszernek a szegélyek megjelenítéséhez, vagy a `false` értéket azok elrejtéséhez. Az alábbi példa egy alapértelmezett adatokkal rendelkező csoportos oszlopdiagramot hoz létre, megjeleníti a vízszintes és a külső szegélyt, és elrejti a függőleges szegélyt. Bemeneti fájlt nem igényel. A diagram pozíciója és mérete pontokban van megadva.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az alábbi összehasonlítás ugyanazt a diagramadatot és jelmagyarázat kulcs beállítást használja mind a négy esetben. Kiindulva a minden szegély engedélyezett állapotból, minden további változat egyetlen szegély beállítást kapcsol ki. A bal alsó változat megfelel a példában szereplő szegélybeállításoknak.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők a sorok nevei mellett az adat-táblában. Segítik az olvasókat a sorok és a diagram sorozatai közötti összerendelésben. Adja át a `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setshowlegendkey/) metódusnak a jelölők megjelenítéséhez, vagy a `false` értéket azok elrejtéséhez.

A diagram különálló jelmagyarázatát a [Chart::setLegend](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setlegend/) metódus vezérli. Ezek a beállítások egymástól függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblázatban lévő kulcsokat, és a táblázati kulcsok elrejtése nem rejti el a különálló jelmagyarázatot.

Az alábbi példa egy alapértelmezett adatokkal rendelkező diagramot hoz létre, engedélyezi annak adat-tábláját, és a táblán belül megjeleníti a jelmagyarázat kulcsokat, miközben elrejti a különálló jelmagyarázatot. Az összes tábla szegély explicit módon engedélyezett. Bemeneti prezentációra nincs szükség. A táblázat kulcsainak csak elrejtéséhez adja át a `false` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setshowlegendkey/) metódusnak.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az alábbi összehasonlítás ugyanazt a táblát mutatja, a jelmagyarázat kulcsok engedélyezett és letiltott állapotban. Az összes szegély továbbra is engedélyezett, és a különálló diagram jelmagyarázat mindkét esetben rejtett.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetek jelmagyarázat kulcsokat egy diagram adat-táblájában?**

Igen. Adja át a `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datatable/setshowlegendkey/) metódusnak a kulcsok megjelenítéséhez, vagy a `false` értéket azok elrejtéséhez.

**Megmarad-e az adat-tábla a prezentáció PDF, HTML vagy képek formátumba történő exportálásakor?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat-táblát a dia részévé rendereli, amikor a [PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/php-java/convert-powerpoint-to-html/) vagy [images](/slides/hu/php-java/convert-powerpoint-to-png/) formátumba exportál.

**Dolgozhatok adat-táblákkal olyan diagramokban, amelyeket sablonból töltöttem be?**

Igen. Egy meglévő prezentációból vagy sablonból betöltött diagram esetén használja a [hasDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/hasdatatable/) és a [setDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setdatatable/) metódusokat a táblázat megjelenítésének ellenőrzéséhez vagy módosításához.

**Hogyan találhatom meg azokat a diagramokat, amelyeknél az adat-tábla engedélyezve van?**

Iteráljon a diákon lévő alakzatokon, azonosítsa a diagramokat, és hívja meg a [hasDataTable](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/hasdatatable/) metódusukat. A `true` érték azt jelzi, hogy az adat-tábla engedélyezve van.