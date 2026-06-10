---
title: "Diagram adat táblák testreszabása prezentációkban C++ használatával"
linktitle: "Adattábla"
type: docs
url: /hu/cpp/chart-data-table/
keywords:
- diagram adatok
- adat tábla
- betűtípus tulajdonságok
- PowerPoint
- prezentáció
- С++
- Aspose.Slides
description: "Testreszabja a diagram adat táblákat C++-ban PPT és PPTX esetén az Aspose.Slides segítségével, hogy növelje a hatékonyságot és a prezentációk vonzerejét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram adat táblákkal dolgozni az Aspose.Slides-ban. Megmutatja, hogyan jeleníthető meg egy diagram adat táblája, és hogyan testreszabható a szöveg formázása betűtípus‑tulajdonságok beállításával, például félkövér stílus és betűmagasság. A példában a bemutató betöltését, a diagram hozzáadását, a diagram adat táblájának engedélyezését, a betűtípus beállítások alkalmazását és a módosított bemutató mentését demonstrálja.

## **Betűtípus‑tulajdonságok beállítása diagram adat táblához**
Aspose.Slides for C++ lehetővé teszi a betűtípus‑tulajdonságok módosítását egy diagram adat táblájában.  

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztálypéldányt.  
1. Adjon egy diagramot a diára.  
1. Állítsa be a diagram tábláját.  
1. Állítsa be a betűmagasságot.  
1. Mentse el a módosított bemutatót.  

Az alábbi minta példa látható.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Megjeleníthetek kis jelmagyarázat‑kulcsokat a diagram adat táblájában lévő értékek mellett?**

Igen. Az adat tábla támogatja a [legend keys](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/datatable/set_showlegendkey/) funkciót, és be‑ vagy kikapcsolható.

**Megmarad az adat tábla, ha a bemutatót PDF‑re, HTML‑re vagy képekre exportáljuk?**

Igen. Az Aspose.Slides a diagramot a dia részeként rendereli, ezért az exportált [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/hu/cpp/convert-powerpoint-to-html/)/[image](/slides/hu/cpp/convert-powerpoint-to-png/) tartalmazza a diagramot a hozzá tartozó adat táblával.

**Támogatottak az adat táblák a sablonfájlból származó diagramok esetén?**

Igen. Bármely, meglévő bemutatóból vagy sablonból betöltött diagram esetén a diagram tulajdonságainak segítségével ellenőrizhető és módosítható, hogy az adat tábla [látható-e](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/set_hasdatatable/).

**Hogyan találhatom meg gyorsan, mely diagramokban van engedélyezve az adat tábla?**

Vizsgálja meg minden diagram azon tulajdonságát, amely jelzi, hogy az adat tábla [látható‑e](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/get_hasdatatable/), és iteráljon a diákon, hogy azonosítsa azokat a diagramokat, ahol engedélyezve van.