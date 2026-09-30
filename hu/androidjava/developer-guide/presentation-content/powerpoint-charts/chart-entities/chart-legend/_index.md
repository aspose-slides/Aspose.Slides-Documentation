---
title: Diagram legendák testreszabása Androidos prezentációkban
linktitle: Diagram legenda
type: docs
url: /hu/androidjava/chart-legend/
keywords:
- diagram legenda
- legend helyzete
- betűméret
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Testreszabja a diagram legendákat az Aspose.Slides for Android via Java segítségével, hogy a PowerPoint prezentációkat a legendák egyedi formázásával optimalizálja."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetőséget biztosít a diagramlegendák testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy legendát, beállítani a teljes legenda betűméretét, formázni egy egyedi legendabejegyzést, illetve elrejteni vagy visszaállítani a kiválasztott bejegyzéseket.

Az GYIK a kapcsolódó viselkedéseket tárgyalja, beleértve a legenda számára hely lefoglalását, a több soros címkék megjelenítését, valamint a formázás öröklését a prezentáció témájától.

## **Legenda elhelyezése**

Használja a legenda [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), és [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) metódusait a pozíció és méret meghatározásához a diagram méretének tört részeként.

Ez a példa egy prezentációt hoz létre, és egy klaszterezett oszlopdiagramot ad hozzá alapértelmezett adatokkal az első diára. A kívánt legenda eltolás és méret a diagram szélességével és magasságával elosztva relatív értékekké alakul: a legenda 50 ponttal van eltolva a diagram bal‑felső sarkától, és 100 × 100 pont méretű.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // A legend pozíciójának és méretének kifejezése a diagramhoz viszonyítva.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A legenda betűméretének beállítása**

Használja a legenda [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) hogy hozzáférjen a szövegformázáshoz, és a [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust a betűméret pontban történő beállításához.

Ez a példa egy diagramot hoz létre alapértelmezett adatokkal, és a legenda szövegét 20 pontra állítja. Emellett letiltja az automatikus határokat a függőleges tengelyen, és -5‑től 10‑ig állítja be a tartományt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyedi legendabejegyzés betűméretének beállítása**

Használja a legendától a [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) metódus visszaadta gyűjteményt egy adott bejegyzés formázásához. A bejegyzés indexei nullától indulnak, így a `1` index a második bejegyzésre vonatkozik.

Ez a példa egy klaszterezett oszlopdiagramot hoz létre, amely alapértelmezett adatai legalább két sorozatot tartalmaznak. Formázza a második legendabejegyzést félkövér, dőlt és 20 pontos kék szöveggel.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyedi legendabejegyzések elrejtése**

Egy segédsorozat kizárásához a legendából, miközben az adatai láthatóak maradnak, hívja meg az [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) metódust `true` értékkel a [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) segítségével. Ez csak a kiválasztott legendabejegyzést rejti el; nem távolítja el a sorozatot vagy adatpontjait. Ezzel szemben az [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) `false` értékével való meghívás az egész legendát elrejti.

Az alábbi példa egy több sorozatos klaszterezett oszlopdiagramot hoz létre alapértelmezett adatokkal. Elrejti a második sorozat legendabejegyzését (index `1`), és elmenti a prezentációt. Ezután a [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) `false` értékkel történő meghívásával visszaállítja a bejegyzést, és egy második másolatot ment el. Az oszlopok mindkét fájlban láthatóak maradnak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    //    A bejegyzést a diagram adatainak módosítása nélkül állítja vissza.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, minden bejegyzés látható állapotban és a második bejegyzés rejtett állapotban. A második sorozat oszlopai változatlanok maradnak.

![Diagram összehasonlítása, ahol minden legendabejegyzés látható, illetve a 2. sorozat rejtve van a legendában; az összes oszlop látható marad.](hide-legend-entry.png)

Az oszlop-, oszlop– és vonaldiagramokban a legendabejegyzések a sorozatokat azonosítják. Pie-diagramok esetén egyedi adatpontokat (szeleteket) jelölnek, ezért a kiválasztott szeletre alkalmazza az [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) metódust. Az API ezt a adatpont‑metódust a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusoknál dokumentálja. Ne feltételezze, hogy ez a módszer a gyűrűdiagramokra is vonatkozik, mivel azok nincsenek a felsoroltak között.

## **GYIK**

**A diagram lefoglalhat helyet a legendának az átfedés helyett?**

Igen. Hívja meg a [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) metódust `false` értékkel, hogy a legendának helyet foglaljon, ahelyett, hogy átfedné a diagram területét.

**Készíthetek több soros legendacímkéket?**

Igen. Hosszú címkék megtörhetnek, ha a rendelkezésre álló szélesség nem elegendő. Új sor karaktereket is használhat a sorozatneveknél a sortörés kéréséhez.

**Hogyan tudom, hogy a legenda kövesse a prezentáció téma színsémáját?**

Hagyja a legenda színeit, kitöltéseit és betűtípusait beállítás nélkül, hogy örökölje a téma formázását. A kifejezett formázás felülírja a megfelelő téma beállításokat.