---
title: "Diagram adat táblák testreszabása prezentációkban Java használatával"
linktitle: "Adattábla"
type: docs
url: /hu/java/chart-data-table/
keywords:
- "diagram adatok"
- "adat tábla"
- "betűtípus beállítások"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Testreszabja a diagram adat tábla betűtípusaikat, szegélyeit és legendajelölőit PowerPoint prezentációkban az Aspose.Slides for Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és testreszabja a szövegformázását, a szegélyeket és a legendajelölőket. Ez a cikk elmagyarázza, hogyan engedélyezheti a táblát, formázhatja a szöveget, vezérelheti a különböző szegélytípusokat, illetve hogyan jelenítheti meg vagy rejtheti el a legendajelölőket. A példák a beállított diagramokat PPTX fájlokban mentik.

## **Betűtípus beállítások**

A diagram adat táblájának megjelenítéséhez adja át a `true` értéket a [setDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#setDataTable-boolean-). Használja a [getChartDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#getChartDataTable--) metódust a tábla eléréséhez és szövegformázásának beállításához.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály segítségével.  
1. Adjon hozzá egy csoportosított oszlopdiagramot az első diára.  
1. Engedélyezze a diagram adat tábláját.  
1. Állítsa be a félkövér szöveget a [setFontBold](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) metódussal, és adja át a `20` értéket a [setFontHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódusnak a 20 pontos szöveghez.  
1. Mentse el a módosított prezentációt.

A következő példa a munkakönyvtárban található `test.pptx` fájlt igényli, amelynek tartalmaznia kell legalább egy diát. Egy alapértelmezett adatokkal ellátott diagramot ad a (50, 50) pozícióba, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` a diagramot tartalmazza, adat táblájával engedélyezve és a megadott betűtípus-beállításokkal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adat tábla szegélyeinek testreszabása**

Engedélyezze a táblát a [IChart.setDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDataTable-boolean-) metódussal, és érje el azt a [IChart.getChartDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#getChartDataTable--) segítségével. Három típusú szegélyt vezérelhet függetlenül:

- A [setBorderHorizontal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) a vízszintes cellaszegélyeket vezérli.  
- A [setBorderVertical](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) a függőleges cellaszegélyeket vezérli.  
- A [setBorderOutline](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) a tábla külső szegélyét vezérli.

Adjon át `true` értéket minden metódusnak a szegélyek megjelenítéséhez, vagy `false`-t a rejtéshez. A következő példa egy alapértelmezett adatokkal ellátott csoportosított oszlopdiagramot hoz létre, megjeleníti a vízszintes és a külső szegélyeket, és elrejti a függőleges szegélyeket. Nem igényel bemeneti fájlt. A diagram pozíciója és mérete pontokban van megadva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a diagram adatot és legendajelző beállítást használja mind a négy esetben. Kiindulva az összes szegély engedélyezett állapotból, minden további változat egyetlen szegélybeállítást kapcsol ki. A bal alsó változat egyezik a példában szereplő szegélybeállításokkal.

![Diagram adat táblák minden szegéllyel, vízszintes szegély nélkül, függőleges szegély nélkül és külső szegély nélkül](data-table-borders.png)

## **Legendajelölők megjelenítése vagy elrejtése**

A legendajelölők kis színes jelölők a sorok nevei mellett az adat táblában. Segítenek a felhasználónak a táblasorok és a diagram sorozatok közti összerendelésben. Adja át a `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) metódusnak a jelölők megjelenítéséhez, vagy `false`-t azok elrejtéséhez.

A diagram különálló legendáját a [IChart.setLegend](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setLegend-boolean-) metódus vezérli. Ezek a beállítások függetlenek: a különálló legenda elrejtése nem rejti el a táblán belüli jelölőket, és a táblajelölők elrejtése nem befolyásolja a különálló legendát.

A következő példa egy alapértelmezett adatokkal ellátott diagramot hoz létre, engedélyezi annak adat tábláját, és megjeleníti a legendajelölőket a táblában, miközben elrejti a különálló legendát. Az összes táblaszegély kifejezetten engedélyezett. Nem szükséges bemeneti prezentáció. A táblajelölők csak elrejtéséhez adja át a `false` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) metódusnak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi összehasonlítás ugyanazt a táblát mutatja legendajelölőkkel bekapcsolva és kikapcsolva. Az összes szegély továbbra is engedélyezett, és a különálló diagram legendája mindkét esetben rejtett.

![Diagram adat táblák legendajelölőkkel megjelenítve bal oldalon és elrejtve jobb oldalon](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetek legendajelölőket egy diagram adat táblájában?**

Igen. Adja át a `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) metódusnak a legendajelölők megjelenítéséhez, vagy `false`-t azok elrejtéséhez.

**Megmarad az adat tábla a prezentáció PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblát a diára rendereli, amikor a [PDF](/slides/hu/java/convert-powerpoint-to-pdf/), [HTML](/slides/hu/java/convert-powerpoint-to-html/) vagy [képek](/slides/hu/java/convert-powerpoint-to-png/) formátumba exportálja.

**Munkálhatok adat táblákkal olyan diagramokban, amelyek sablonból vagy meglévő prezentációból származnak?**

Igen. Egy meglévő prezentációból vagy sablonból betöltött diagram esetén használja a [hasDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#hasDataTable--) és a [setDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#setDataTable-boolean-) metódusokat a adat tábla megjelenítésének ellenőrzésére vagy módosítására.

**Hogyan találhatok olyan diagramokat, amelyeknél az adat tábla engedélyezve van?**

Iteráljon végig minden dia alakzatain, azonosítsa a diagramokat, és hívja meg a [hasDataTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/#hasDataTable--) metódust. A `true` érték azt jelzi, hogy az adat tábla engedélyezve van.