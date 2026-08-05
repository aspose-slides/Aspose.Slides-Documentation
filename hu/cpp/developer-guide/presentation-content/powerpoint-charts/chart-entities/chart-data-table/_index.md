---
title: Diagram adat táblák testreszabása prezentációkban C++ használatával
linktitle: Adattábla
type: docs
url: /hu/cpp/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Testreszabja a diagram adat táblákat C++-ban PPT és PPTX esetén az Aspose.Slides segítségével, hogy növelje a hatékonyságot és a vonzerőt a prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram adat táblákkal az Aspose.Slides-ban. Megmutatja, hogyan jeleníthet meg egy adat táblát egy diagramhoz, és hogyan testreszabhatja a szöveg formázását a betűtípus tulajdonságok, például a félkövér stílus és a betűmagasság beállításával. A példa bemutatja egy bemutató betöltését, egy diagram hozzáadását, a diagram adat táblájának engedélyezését, a betűtípus beállítások alkalmazását, és a frissített bemutató mentését.

## **Betűtípus tulajdonságok beállítása diagram adat táblához**
Az Aspose.Slides for C++ lehetővé teszi a diagram adat táblájának betűtípus tulajdonságainak módosítását.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály objektumát.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram táblát.
1. Állítsa be a betűmagasságot.
1. Mentse el a módosított bemutatót.

Az alábbi példa példát mutatja.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Megjeleníthetek kis jelmagyarázat kulcsokat a diagram adat táblájában lévő értékek mellett?**

Igen. Az adat tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/datatable/set_showlegendkey/) funkciót, és be- vagy kikapcsolható.

**Megmarad az adat tábla a bemutató PDF, HTML vagy képek formátumba exportálásakor?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, így a exportált [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/cpp/convert-powerpoint-to-html/)/[image](/slides/hu/cpp/convert-powerpoint-to-png/) tartalmazza a diagramot a hozzá tartozó adat táblával.

**Támogatottak az adat táblák olyan diagramoknál, amelyek sablonfájlból származnak?**

Igen. Bármely, meglévő bemutatóból vagy sablonból betöltött diagram esetén ellenőrizhető és módosítható, hogy az adat tábla [látható-e](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/set_hasdatatable/) a diagram tulajdonságainak használatával.

**Hogyan találhatom meg gyorsan, mely diagramokban van engedélyezve az adat tábla egy fájlban?**

Vizsgálja meg minden diagram olyan tulajdonságát, amely jelzi, hogy az adat tábla [látható-e](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/get_hasdatatable/), és járja végig a diákat, hogy azonosítsa azokat a diagramokat, ahol engedélyezve van.