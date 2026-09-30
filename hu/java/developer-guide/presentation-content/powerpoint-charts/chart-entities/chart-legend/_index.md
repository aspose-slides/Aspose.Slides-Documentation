---
title: Diagram legendák testreszabása prezentációkban Java-val
linktitle: Diagram legenda
type: docs
url: /hu/java/chart-legend/
keywords:
- diagram legenda
- legenda pozíció
- betűméret
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Testreszabott diagram legendákat hozhat létre az Aspose.Slides for Java segítségével, hogy a PowerPoint prezentációkat a legendák egyedi formázásával optimalizálja."
---
## **Áttekintés**

Aspose.Slides for Java lehetőségeket biztosít a diagram legendák testreszabásához a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy legendát, beállítani a teljes legenda betűméretét, egyedi legendaelemet formázni, valamint elrejteni vagy visszaállítani a kiválasztott elemeket.

Az FAQ lefedi a kapcsolódó viselkedéseket, többek között a legenda számára hely lefoglalását, a több soros címkék megjelenítését és a formázás öröklését a prezentációtémából.

## **Legenda elhelyezése**

Használja a legenda [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-) és [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) metódusait a pozíció és méret megadásához a diagram méreteihez viszonyított törtként.

Ez a példa egy prezentációt hoz létre, és hozzáad egy csoportosított oszlopdiagramot alapértelmezett adatokkal az első diára. A kívánt legendaeltolások és méretek a diagram szélességével és magasságával osztva relatív értékekké alakulnak: a legenda 50 ponttal a diagram bal‑felső sarkától eltolt és 100 × 100 pont méretű.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Adja meg a legenda pozícióját és méretét a diagramhoz viszonyítva.
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

Használja a legenda [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) metódusát a szövegformázás eléréséhez, és a [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust a betűméret pontban történő beállításához.

Ez a példa egy diagramot hoz létre alapértelmezett adatokkal, és a legenda szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és -5‑tól 10‑ig terjedő tartományt állít be.

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

## **Egyedi legendaelem betűméretének beállítása**

Használja a legenda [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) metódusa által visszaadott gyűjteményt egy adott elem formázásának eléréséhez. Az elemek indexelése nullától indul, így az `1` index a második elemet jelöli.

Ez a példa egy csoportosított oszlopdiagramot hoz létre, amely alapértelmezett adatai legalább két sorozatot tartalmaznak. A második legendaelemet félkövér, dőlt és 20 pontos kék szöveggel formázza.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Egyedi legendaelemek elrejtése**

Egy segéd sorozat kizárásához a legendából, miközben az adatai láthatóak maradnak, hívja meg az [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) metódust `true` értékkel a [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) segítségével. Ez csak a kiválasztott legendaelemet rejti el; a sorozatot vagy adatpontjait nem távolítja el. Ezzel szemben az [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) `false` értékkel való hívása az egész legendát elrejti.

Az alábbi példa egy több sorozatot tartalmazó csoportosított oszlopdiagramot hoz létre alapértelmezett adatokkal. Elrejti a második sorozat legendaelemét (index `1`), és elmenti a prezentációt. Ezután a [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) `false` értékkel való meghívásával visszaállítja az elemet, és egy második példányt ment. Az oszlopok mindkét fájlban láthatóak maradnak.

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

    // Állítsa vissza ugyanazt az elemet a diagram adatai módosítása nélkül.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, ahol minden elem látható, illetve a második elem rejtve van. A második sorozat oszlopai változatlanok maradnak.

![Az összes legendaelem látható és a 2. sorozat a legendából rejtett diagram összehasonlítása; az összes oszlop látható marad.](hide-legend-entry.png)

Oszlop-, sáv- és vonaldiagramokban a legendaelemek a sorozatokat azonosítják. Pie diagramok esetén egyedi adatpontokat (szeleteket) jelölnek, ezért a kiválasztott szeletre a [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) metódust kell használni. Az API ezt az adatpont‑metódust a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusokra dokumentálja. Ne tételezzük fel, hogy ez a gyűrűs diagramokra is vonatkozik, mivel azok nincsenek a felsorolásban.

## **FAQ**

**A diagram a legendának helyet foglalhat el ahelyett, hogy átfedné?**

Igen. Hívja meg a [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) metódust `false` értékkel, hogy helyet foglaljon a legendának, ahelyett, hogy átfedné a rajzterületet.

**Készíthetek több soros legenda‑címkéket?**

Igen. A hosszú címkék a rendelkezésre álló szélesség hiánya esetén tördelődnek. Továbbá sorozatnevekben új sor karaktereket (`\n`) használhat a sortörés kéréséhez.

**Hogyan tudom, hogy a legenda a prezentáció témájának színsémáját kövesse?**

Hagyja a legenda színeit, kitöltéseit és betűtípusait beállítás nélkül, hogy örökölje a téma formázását. Az explicit formázás felülírja a megfelelő téma beállításokat.