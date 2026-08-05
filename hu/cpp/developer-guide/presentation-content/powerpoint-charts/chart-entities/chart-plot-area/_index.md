---
title: A prezentációs diagramok ábrázolási területeinek testreszabása C++-ban
linktitle: Ábrázolási terület
type: docs
url: /hu/cpp/chart-plot-area/
keywords:
- diagram
- ábrázolási terület
- ábrázolási terület szélessége
- ábrázolási terület magassága
- ábrázolási terület mérete
- elrendezési mód
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan testreszabhatja a diagramok ábrázolási területeit PowerPoint-prezentációkban az Aspose.Slides for C++ segítségével. Javítsa diái megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk a diagram ábrázolási területével az Aspose.Slides-ban. Kitér arra, hogyan lehet a tényleges pozíciót és méretet lekérni az ábrázolási területhez a diagram elrendezésének validálásával, majd az X, Y, szélesség és magasság értékek elolvasásával.

Az írás bemutatja továbbá, hogyan konfigurálható az ábrázolási terület elrendezési módja, amikor az elrendezés manuálisan van beállítva, a `LayoutTargetType` használatával meghatározva, hogy az ábrázolási területet a belső régió vagy a külső régió (tengelyekkel és tengelycímkékkel együtt) alapján számolják.

## **A diagram ábrázolási területének szélességének és magasságának lekérése**
Az Aspose.Slides for C++ egyszerű API-t biztosít.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze meg az első diát.
3. Adjon hozzá diagramot alapértelmezett adatokkal.
4. Hívja meg az IChart::ValidateChartLayout() metódust a tényleges értékek lekérése előtt.
5. Lekéri a diagram elem tényleges X helyzetét (bal), a diagram bal felső sarkához viszonyítva.
6. Lekéri a diagram elem tényleges felső pozícióját a diagram bal felső sarkához viszonyítva.
7. Lekéri a diagram elem tényleges szélességét.
8. Lekéri a diagram elem tényleges magasságát.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Prezentáció mentése diagrammal
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **A diagram ábrázolási területének elrendezési módjának beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a diagram ábrázolási területének elrendezési módjának beállításához. A **LayoutTargetType** tulajdonság hozzá lett adva a **ChartPlotArea** és **IChartPlotArea** osztályokhoz. Ha az ábrázolási terület elrendezése manuálisan van megadva, ez a tulajdonság meghatározza, hogy az ábrázolási területet a belső (a tengelyek és tengelycímkék nélkül) vagy a külső (a tengelyekkel és tengelycímkékkel együtt) része alapján helyezzék el. Két lehetséges érték van, amelyek a **LayoutTargetType** felsorolja.

- **LayoutTargetType.Inner** – meghatározza, hogy az ábrázolási terület mérete a terület méretét határozza meg, a jelölőket és tengelycímkéket nem figyelembe véve.
- **LayoutTargetType.Outer** – meghatározza, hogy az ábrázolási terület mérete a terület méretét, a jelölőket és a tengelycímkéket is magában foglalja.

Az alábbiakban példakód található.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **GYIK**

**Milyen mértékegységben térnek vissza az ActualX, ActualY, ActualWidth és ActualHeight értékek?**

Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordinátarendszer egységei.

**Miben különbözik az ábrázolási terület a diagram területétől a tartalom tekintetében?**

Az ábrázolási terület a adatrajzolási régió (sorozatok, rácsvonalak, trendvonalak stb.); a diagram terület tartalmazza a környező elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén az ábrázolási terület magába foglalja a falakat/alsót és a tengelyeket is.

**Hogyan értelmezendő az ábrázolási terület X, Y, szélessége és magassága, ha az elrendezés manuális?**

Ez az érték a diagram teljes méretének törtértékét (0–1) jelenti; ebben a módban az automatikus pozicionálás ki van kapcsolva, és a megadott törtek lesznek alkalmazva.

**Miért változott meg az ábrázolási terület pozíciója a jelmagyarázat hozzáadása/mozgatása után?**

A jelmagyarázat a diagram területében, az ábrázolási területetől kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért az ábrázolási terület eltolódhat, ha az automatikus pozicionálás aktív. (Ez a PowerPoint diagramok szokásos viselkedése.)