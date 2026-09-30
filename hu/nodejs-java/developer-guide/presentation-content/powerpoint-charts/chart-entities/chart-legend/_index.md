---
title: Diagram jelmagyarázatok testreszabása prezentációkban JavaScript használatával
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/nodejs-java/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat pozíció
- betűméret
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabja a diagram jelmagyarázatokat az Aspose.Slides for Node.js via Java segítségével, hogy optimalizálja a PowerPoint prezentációkat a testreszabott jelmagyarázati formázással."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java lehetőséget biztosít a diagram jelmagyarázatok testreszabására a PowerPoint-prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy jelmagyarázatot, beállítani a teljes jelmagyarázat betűméretét, formázni egy adott jelmagyarázati bejegyzést, valamint elrejteni vagy visszaállítani a kiválasztott bejegyzéseket.

A GyIK a kapcsolódó viselkedéseket is lefedi, többek között a jelmagyarázat helyének lefoglalását, a több soros címkék megjelenítését, valamint a formázás öröklését a prezentáció témájából.

## **Jelmagyarázat elhelyezése**

Használja a jelmagyarázat [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), és [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) metódusait a pozíciója és mérete meghatározásához a diagram méretének tört részeként.

Ez a példa létrehoz egy prezentációt, és az első diára egy csoportosított oszlopdiagramot ad hozzá az alapértelmezett adatokkal. A kívánt jelmagyarázat eltolásokat és méreteket a diagram szélességével és magasságával elosztva relatív értékekké alakítja: a jelmagyarázat 50 ponttal van eltolva a diagram bal felső sarkától, és 100 pont szélességű és 100 pont magasságú.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // A jelmagyarázat pozícióját és méretét a diagramhoz viszonyítva adja meg.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A jelmagyarázat betűméretének beállítása**

Használja a jelmagyarázat [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) metódusát a szövegformázás eléréséhez, és a [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) metódust a betűméret pontban történő beállításához.

Ez a példa létrehoz egy diagramot az alapértelmezett adatokkal, és a jelmagyarázat szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és a tartományt -5 és 10 között állítja be.

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

## **Egy adott jelmagyarázati bejegyzés betűméretének beállítása**

Használja a jelmagyarázat [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) metódusa által visszaadott gyűjteményt egy adott bejegyzés formázásának eléréséhez. A bejegyzések indexelése nullától indul, így az `1` index a második bejegyzést jelöli.

Ez a példa létrehoz egy csoportosított oszlopdiagramot, amelynek alapértelmezett adatai legalább két sorozatot tartalmaznak. Formázza a második jelmagyarázati bejegyzést félkövér, dőlt és 20 pontos kék szöveggel.

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

## **Egyedi jelmagyarázati bejegyzések elrejtése**

Egy segédsorozat kizárásához a jelmagyarázatból, miközben az adat látható marad, hívja meg a [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) metódust `true` értékkel a [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) segítségével. Ez csak a kiválasztott jelmagyarázati bejegyzést rejti el; a sorozatot vagy adatpontjait nem távolítja el. Ezzel szemben a [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) `false` értékkel történő meghívása az egész jelmagyarázatot eltünteti.

Az alábbi példa létrehoz egy csoportosított oszlopdiagramot több sorozattal az alapértelmezett adatok használatával. Elrejti a második sorozat jelmagyarázati bejegyzését (index `1`), majd elmenti a prezentációt. Ezután a [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) `false` értékkel történő meghívásával visszaállítja a bejegyzést, és egy második másolatot ment. Az oszlopok mindkét fájlban láthatók maradnak.

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

    // Állítsa vissza ugyanazt a bejegyzést a diagram adatait megváltoztatás nélkül.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, az összes bejegyzés látható állapotban és a második bejegyzés rejtett állapotban. A második sorozat oszlopai változatlanok maradnak.

![Diagram összehasonlítása, ahol az összes jelmagyarázati bejegyzés látható, illetve a 2. sorozat el van rejtve a jelmagyarázatból; az összes oszlop látható marad.](hide-legend-entry.png)

Oszlop-, oszlopdiagramoknál és vonaldiagramoknál a jelmagyarázati bejegyzések a sorozatokat azonosítják. Kördiagramoknál egyenkénti adatpontokat (szeleteket) jelölnek, ezért a kiválasztott szelet esetén használja a [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) metódust. Az API ezt az adatpont‑metódust a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusokra dokumentálja. Ne feltételezze, hogy ez a gyűrűdiagramokra is érvényes, mivel azok nincsenek a felsorolásban.

## **GYIK**

**Kérhetem, hogy a diagram helyet foglaljon a jelmagyarázatnak ahelyett, hogy átfedje azt?**

Igen. Hívja meg a [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) metódust `false` értékkel, hogy helyet foglaljon a jelmagyarázatnak, ahelyett, hogy átfedné a diagramterületet.

**Létrehozhatok több soros jelmagyarázati címkéket?**

Igen. A hosszú címkék megtörhetnek, ha a rendelkezésre álló szélesség nem elegendő. A sorozatnevekben új sor karaktereket is használhat a sortörés kérése érdekében.

**Hogyan tudom, hogy a jelmagyarázat kövesse a prezentáció téma színpalettáját?**

Hagyja a jelmagyarázat színeit, kitöltéseit és betűtípusait beállítatlanul, hogy örökölje a téma formázását. Az explicit formázás felülírja a megfelelő téma beállításait.