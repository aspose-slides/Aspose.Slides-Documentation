---
title: Ábrázolási területek testreszabása prezentációs diagramokban C++-ban
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
description: "Ismerje meg, hogyan testreszabhatja a diagramok ábrázolási területeit PowerPoint prezentációkban az Aspose.Slides for C++ segítségével. Javítsa diái megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni egy diagram ábrázolási területével az Aspose.Slides-ben. Ismerteti, hogyan lehet a tényleges pozíciót és méretet lekérni az ábrázolási területből a diagram elrendezésének ellenőrzésével, majd az X, Y, szélesség és magasság értékek olvasásával.

Ez továbbá bemutatja, hogyan lehet beállítani az ábrázolási terület elrendezési módját, ha az elrendezést kézzel állítják be, a `LayoutTargetType` használatával meghatározva, hogy az ábrázolási területet a belső régiója vagy a külső régiója, a tengelyekkel és tengelycímkékkel együtt számítják-e.

## **A diagram ábrázolási területének szélességének és magasságának lekérése**
Az Aspose.Slides for C++ egyszerű API-t biztosít a . 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Nyissa meg az első diát.
3. Adjon hozzá diagramot alapértelmezett adatokkal.
4. Hívja meg az IChart::ValidateChartLayout() metódust a tényleges értékek lekérése előtt.
5. Lekéri a diagram elem tényleges X helyét (balra), a diagram bal felső sarkához képest.
6. Lekéri a diagram elem tényleges felső pozícióját a diagram bal felső sarkához képest.
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

// Diagramot tartalmazó prezentáció mentése
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **A diagram ábrázolási területének elrendezési módjának beállítása**
Az Aspose.Slides for C++ egyszerű API-t biztosít a diagram ábrázolási területének elrendezési módjának beállításához. A **LayoutTargetType** tulajdonság hozzá lett adva a **ChartPlotArea** és **IChartPlotArea** osztályokhoz. Ha az ábrázolási terület elrendezése kézzel van meghatározva, ez a tulajdonság megadja, hogy az ábrázolási területet a belső (a tengelyek és tengelycímkék nélkül) vagy a külső (a tengelyekkel és tengelycímkékkel együtt) rész alapján kell-e elrendezni. Két lehetséges érték van, amely a **LayoutTargetType** felsoroltban van definiálva.

- **LayoutTargetType.Inner** – meghatározza, hogy az ábrázolási terület mérete határozza meg a terület méretét, a jelölőjelek és tengelycímkék nélkül.
- **LayoutTargetType.Outer** – meghatározza, hogy az ábrázolási terület mérete határozza meg a terület méretét, a jelölőjelek és tengelycímkék is beleértve.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **GYIK**

**Milyen mértékegységben térnek vissza az ActualX, ActualY, ActualWidth és ActualHeight értékek?**

Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordináta egységek.

**Miben különbözik az ábrázolási terület a diagram területétől a tartalom tekintetében?**

Az ábrázolási terület az adatrajzolási régió (sorozatok, rácsvonalak, trendvonalak stb.); a diagram terület tartalmazza a környező elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén az ábrázolási terület magában foglalja a falakat/padlót és a tengelyeket is.

**Hogyan értelmezhetők az ábrázolási terület X, Y, szélesség és magasság értékei, ha az elrendezés kézi?**

Ezök a diagram teljes méretének tört részei (0–1); ebben a módban az automatikus pozicionálás le van tiltva, és a beállított tört értékek kerülnek felhasználásra.

**Miért változott meg az ábrázolási terület pozíciója a jelmagyarázat hozzáadása/mozgatása után?**

A jelmagyarázat a diagram területén kívül helyezkedik el az ábrázolási terület mellett, de befolyásolja az elrendezést és a rendelkezésre álló helyet, így az ábrázolási terület eltolódhat, ha az automatikus pozicionálás aktív. (Ez a PowerPoint diagramok szokásos viselkedése.)