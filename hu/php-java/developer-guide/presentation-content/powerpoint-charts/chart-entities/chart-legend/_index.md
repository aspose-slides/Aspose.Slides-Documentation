---
title: Diagram jelmagyarázatok testreszabása prezentációkban PHP használatával
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/php-java/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat pozíció
- betűméret
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Testreszabhatja a diagram jelmagyarázatokat az Aspose.Slides for PHP via Java segítségével, hogy a PowerPoint prezentációkat a személyre szabott jelmagyarázati formázással optimalizálja."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java lehetőséget biztosít a diagram jelmagyarázatainak testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet pozicionálni és méretezni egy jelmagyarázatot, beállítani a teljes jelmagyarázat betűméretét, formázni egyetlen bejegyzést, valamint elrejteni vagy visszaállítani a kiválasztott bejegyzéseket.

A GyIK a kapcsolódó viselkedéseket is tárgyalja, beleértve a jelmagyarázat számára lefoglalt helyet, a többsoros címkék megjelenítését és a formázás öröklését a prezentáció témájából.

## **Jelmagyarázat pozicionálása**

Használja a jelmagyarázat [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), és [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) metódusait a pozíció és a méret megadásához a diagram méretének tört részeként.

Ez a példa egy prezentációt hoz létre, és egy alapértelmezett adatokkal rendelkező klaszteres oszlopdiagramot ad az első diára. A kívánt jelmagyarázat eltolásokat és méreteket a diagram szélességével és magasságával elosztva relatív értékekké alakítja: a jelmagyarázat 50 ponttal van eltolva a diagram bal‑felső sarkától, és 100 × 100 pont méretű. A példa a java_values funkciót használja, hogy a PHP/Java Bridge által visszaadott diagramméreteket PHP‑számokká konvertálja az osztás előtt.

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

    // Fejezze ki a jelmagyarázat pozícióját és méretét a diagramhoz viszonyítva.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **A jelmagyarázat betűméretének beállítása**

Használja a jelmagyarázat [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) metódusát a szövegformázás eléréséhez, és a [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) metódust a betűméret pontban történő beállításához.

Ez a példa egy alapértelmezett adatokkal rendelkező diagramot hoz létre, és a jelmagyarázat szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és a tartományt -5‑től 10‑ig állítja be.

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

## **Egyes jelmagyarázat bejegyzés betűméretének beállítása**

Használja a jelmagyarázat [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) metódusa által visszaadott gyűjteményt egy adott bejegyzés formázásához. A bejegyzés indexei nullával kezdődnek, ezért az `1` index a második bejegyzést jelöli.

Ez a példa egy klaszteres oszlopdiagramot hoz létre, amely alapértelmezett adatai legalább két sorozatot tartalmaznak. A második jelmagyarázat bejegyzést félkövér, dőlt és 20 pontos kék szöveggel formázza.

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

## **Egyes jelmagyarázat bejegyzések elrejtése**

Egy segédsorozat kizárásához a jelmagyarázatból, miközben az adatai láthatóak maradnak, hívja meg a [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) metódust `true` értékkel a [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) segítségével. Ez csak a kijelölt jelmagyarázat bejegyzést rejti el; a sorozat vagy annak adatpontjai nem kerülnek eltávolításra. Ezzel szemben a [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) `false` értékkel történő hívása az egész jelmagyarázatot elrejti.

Az alábbi példa több sorozattal rendelkező klaszteres oszlopdiagramot hoz létre alapértelmezett adatokkal. Elrejti a második sorozat jelmagyarázat bejegyzését (index `1`), menti a prezentációt, majd a [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) `false` értékkel történő hívással visszaállítja a bejegyzést, és második másolatot ment. A oszlopok mindkét fájlban láthatóak maradnak.

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

    // A bejegyzés visszaállítása a diagram adatait módosítása nélkül.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A lenti összehasonlítás ugyanazt a diagramot mutatja, egyszer az összes jelmagyarázat bejegyzés látható, egyszer pedig a második bejegyzés elrejtett. A második sorozat oszlopai változatlanok maradnak.

![Diagram összehasonlítása, amikor minden jelmagyarázat bejegyzés látható, és amikor a 2. sorozat el van rejtve a jelmagyarázatból; az összes oszlop látható marad.](hide-legend-entry.png)

Oszlop-, sáv- és vonaldiagramok esetén a jelmagyarázat bejegyzései a sorozatokat azonosítják. Kördiagramok esetén egyedi adatpontokat (szeleteket) jelölnek, ezért a kiválasztott szeletre a [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) metódust kell használni. Az API dokumentálja ezt a adatpont‑metódust a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusokhoz. Ne feltételezze, hogy ez a gyűrűdiagramokra is érvényes, mivel azok nincsenek a felsoroltak között.

## **GYIK**

**Megtudom-e úgy beállítani, hogy a diagram lefoglalja a helyet a jelmagyarázatnak a felülírás helyett?**  
Igen. Hívja meg a [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) metódust `false` értékkel, hogy a jelmagyarázat helyét lefoglalja, ahelyett, hogy átfedné a diagram területét.

**Készíthetek többsoros jelmagyarázat címkéket?**  
Igen. A hosszú címkék megtörnek, ha a rendelkezésre álló szélesség nem elegendő. Soronkénti sortöréseket is beilleszthet a sorozatnevekbe új sor karakterek használatával.

**Hogyan tehetem, hogy a jelmagyarázat a prezentáció téma színsémáját kövesse?**  
Hagyja a jelmagyarázat színeit, kitöltéseit és betűtípusait beállítatlanul, hogy örökölje a téma formázását. Az explicit formázás felülírja a megfelelő téma beállításokat.