---
title: Androidon lévő bemutatók diagram adat tábláinak testreszabása
linktitle: Adattábla
type: docs
url: /hu/androidjava/chart-data-table/
keywords:
- diagramadat
- adat tábla
- betűtulajdonságok
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Diagram adat táblák betűtípusainak, szegélyeinek és jelmagyarázat kulcsainak testreszabása PowerPoint bemutatókban az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy megjelenítse egy diagram adat tábláját, és testreszabja annak szövegformázását, szegélyeit és a jelmagyarázat kulcsait. Ez a cikk bemutatja, hogyan engedélyezheti a táblát, formázhatja a szöveget, vezérelheti az egyes szegélytípusokat, valamint hogyan jelenítheti meg vagy rejtheti el a jelmagyarázat kulcsait. A példák a beállított diagramokat PPTX fájlokba mentik.

## **Betűtulajdonságok beállítása**

A diagram adat táblájának megjelenítéséhez adja át a `true` értéket a [setDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). A táblához való hozzáféréshez és a szövegformázás beállításához használja a [getChartDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#getChartDataTable--) metódust.

1. Töltse be a bemutatót a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály segítségével.
2. Adjon hozzá egy csoportos oszlopdiagramot az első diára.
3. Engedélyezze a diagram adat tábláját.
4. Kapcsolja be a félkövér szöveget a [setFontBold](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) használatával, és adja át a `20`‑at a [setFontHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódusnak a 20 pontos szöveghez.
5. Mentse el a módosított bemutatót.

Az alábbi példa a munkakönyvtárban lévő `test.pptx` fájlt igényli, amelynek legalább egy diát kell tartalmaznia. Egy alapértelmezett adatokkal ellátott diagramot ad hozzá a (50, 50) pozícióba, 600 pont szélességgel és 400 pont magassággal. A mentett `output.pptx` fájl tartalmazza a diagramot engedélyezett adat táblával és az alkalmazott betűtípus beállításokkal.

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

## **Adattábla szegélyek testreszabása**

Engedélyezze a táblát az [IChart.setDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) használatával, és férjen hozzá az [IChart.getChartDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#getChartDataTable--) segítségével. Három típusú szegélyt vezérelhet önállóan:

- [setBorderHorizontal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) vezérli a vízszintes cellaszegélyeket.
- [setBorderVertical](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) vezérli a függőleges cellaszegélyeket.
- [setBorderOutline](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) vezérli a tábla külső szegélyét.

Adja át a `true` értéket minden metódusnak a szegélyek megjelenítéséhez, vagy a `false` értéket azok elrejtéséhez. Az alábbi példa egy alapértelmezett adatokkal ellátott csoportos oszlopdiagramot hoz létre, megjeleníti a vízszintes és a külső szegélyeket, és elrejti a függőleges szegélyeket. Nem igényel bemeneti fájlt. A diagram pozíciója és mérete pontban van megadva.

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

A lenti összehasonlítás ugyanazt a diagram adatot és jelmagyarázat kulcs beállítást használja mind a négy esetben. Az összes szegély engedélyezésével indul, majd minden további változat csak egy szegélyt kapcsol ki. Az alsó‑bal variáns megegyezik a példában szereplő szegélybeállításokkal.

![Diagram adat táblák minden szegéllyel, vízszintes szegély nélkül, függőleges szegély nélkül, és külső szegély nélkül](data-table-borders.png)

## **Jelmagyarázat kulcsok megjelenítése vagy elrejtése**

A jelmagyarázat kulcsok kis színes jelölők a sorok nevei mellett az adattáblában. Segítik az olvasót, hogy minden táblasorhoz a diagram sorozatot párosítsa. Adja át a `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) metódusnak a jelölők megjelenítéséhez, vagy a `false` értéket azok elrejtéséhez.

A diagram különálló jelmagyarázata az [IChart.setLegend](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) segítségével szabályozható. Ezek a beállítások függetlenek: a különálló jelmagyarázat elrejtése nem rejti el a táblán belüli kulcsokat, és a táblán lévő kulcsok elrejtése nem rejti el a különálló jelmagyarázatot.

Az alábbi példa egy alapértelmezett adatokkal ellátott diagramot hoz létre, engedélyezi az adat táblát, és megjeleníti a jelmagyarázat kulcsokat benne, miközben elrejti a különálló jelmagyarázatot. Az összes táblaszegély kifejezetten engedélyezett. Bemutató bemeneti fájlra nincs szükség. A táblán lévő kulcsok csak elrejtéséhez adja át a `false` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) metódusnak.

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

A lenti összehasonlítás ugyanazt a táblát mutatja, a jelmagyarázat kulcsok be és ki vannak kapcsolva. Minden szegély továbbra is engedélyezett, és a különálló diagram jelmagyarázat mindkét esetben rejtve van.

![Diagram adat táblák jelmagyarázat kulcsokkal bal oldalon megjelenítve, jobb oldalon elrejtve](data-table-legend-keys.png)

## **GYIK**

**Megjeleníthetem-e a jelmagyarázat kulcsokat egy diagram adat táblájában?**

Igen. Adja át a `true` értéket a [setShowLegendKey](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) metódusnak a jelmagyarázat kulcsok megjelenítéséhez, vagy a `false` értéket azok elrejtéséhez.

**Megmarad-e az adat tábla a bemutató PDF-re, HTML-re vagy képekre exportálásakor?**

Igen. Az Aspose.Slides a diagramot és a megjelenített adat táblát a dia részévé rendereli, amikor a [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/) vagy a [képek](/slides/hu/androidjava/convert-powerpoint-to-png/) formátumba exportál.

**Munkálhatok-e adat táblákkal olyan diagramokban, amelyek sablonból lettek betöltve?**

Igen. Egy meglévő bemutatóból vagy sablonból betöltött diagram esetén használja a [hasDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#hasDataTable--) és a [setDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) metódusokat annak ellenőrzésére vagy módosítására, hogy megjelenik-e az adat tábla.

**Hogyan találhatok olyan diagramokat, amelyekhez engedélyezve van az adat tábla?**

Iteráljon végig minden dia alakzatain, azonosítsa a diagramokat, és hívja meg azok [hasDataTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/#hasDataTable--) metódusát. A `true` érték azt jelzi, hogy az adat tábla engedélyezve van.