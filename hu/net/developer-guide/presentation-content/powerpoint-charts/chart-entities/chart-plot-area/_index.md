---
title: Prezentációs diagramok ábrázolási területeinek testreszabása .NET-ben
linktitle: Ábrázolási terület
type: docs
url: /hu/net/chart-plot-area/
keywords:
- diagram
- ábrázolási terület
- ábrázolási terület szélessége
- ábrázolási terület magassága
- ábrázolási terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diagramok ábrázolási területeit a PowerPoint prezentációkban az Aspose.Slides for .NET segítségével. Javítsa a diák megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni egy diagram ábrázolási területével az Aspose.Slides-ben. Ismerteti, hogyan lehet a tényleges pozíciót és méretet meghatározni az ábrázolási területen a diagram elrendezésének érvényesítésével, majd az X, Y, szélesség és magasság értékek kiolvasásával.

Ez továbbá bemutatja, hogyan lehet beállítani az ábrázolási terület elrendezési módját, ha az elrendezés manuálisan van meghatározva, a `LayoutTargetType` használatával megadva, hogy az ábrázolási területet a belső régiója vagy a külső régiója, beleértve a tengelyeket és tengelycímkéket, alapján számítják-e.

## **A diagram ábrázolási területének szélességének és magasságának lekérdezése**
Az Aspose.Slides for .NET egyszerű API-t biztosít a .

1. Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.
2. Érje el az első diát.
3. Adjon hozzá egy diagramot az alapértelmezett adatokkal.
4. Hívja meg az IChart.ValidateChartLayout() metódust, mielőtt a tényleges értékeket lekéri.
5. A diagram elem tényleges X helyzetét (bal) adja vissza a diagram bal felső sarkához viszonyítva.
6. A diagram elem tényleges felső pozícióját adja vissza a diagram bal felső sarkához viszonyítva.
7. A diagram elem tényleges szélességét adja vissza.
8. A diagram elem tényleges magasságát adja vissza.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Mentse a prezentációt a diagrammal
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **A diagram ábrázolási területének elrendezési módjának beállítása**
Az Aspose.Slides for .NET egyszerű API-t biztosít a diagram ábrázolási területének elrendezési módjának beállításához. A **LayoutTargetType** tulajdonságot hozzáadták a **ChartPlotArea** és **IChartPlotArea** osztályokhoz. Ha az ábrázolási terület elrendezése manuálisan van meghatározva, ez a tulajdonság azt adja meg, hogy az ábrázolási területet a belső (a tengelyeket és tengelycímkéket kizárva) vagy a külső (a tengelyeket és tengelycímkéket beleértve) része alapján kell elrendezni. Két lehetséges érték van, amely a **LayoutTargetType** felsoroltban van definiálva.

- **LayoutTargetType.Inner** – meghatározza, hogy az ábrázolási terület mérete határozza meg a terület méretét, a jelölőket és tengelycímkéket kizárva.
- **LayoutTargetType.Outer** – meghatározza, hogy az ábrázolási terület mérete határozza meg a terület méretét, a jelölőket és a tengelycímkéket is.

Az alábbiakban példa kód található.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Milyen mértékegységben térnek vissza az ActualX, ActualY, ActualWidth és ActualHeight értékek?**

Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordinátaegységek.

**Mi a különbség a Plot Area és a Chart Area tartalma között?**

A Plot Area a diagram adatok megjelenítési területe (sorozatok, rácsvonalak, trendvonalak stb.); a Chart Area magában foglalja a környező elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén a Plot Area magában foglalja a falakat/aját és a tengelyeket is.

**Hogyan értelmeződnek a Plot Area X, Y, Width és Height értékei, ha az elrendezés manuális?**

Ezek a diagram teljes méretének tört részei (0–1); ebben a módban az automatikus pozicionálás ki van kapcsolva, és a beállított törtek kerülnek felhasználásra.

**Miért változott meg a Plot Area pozíciója a jelmagyarázat hozzáadása/mozgatása után?**

A jelmagyarázat a Chart Area-ban, a Plot Area-n kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért a Plot Area eltolódhat, ha az automatikus pozicionálás aktív. (Ez a PowerPoint diagramok szokásos viselkedése.)