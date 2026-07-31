---
title: Prezentációs diagramok exportálása C++-ban
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/cpp/export-chart/
keywords:
- diagram
- diagram képbe
- diagram képként
- diagramkép kinyerése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhatja a prezentációs diagramokat az Aspose.Slides for C++ segítségével, támogatva a PPT és PPTX formátumokat, és egyszerűsítse a jelentéskészítést bármely munkafolyamatban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot egy prezentációból képként exportálja. Ez a cikk bemutatja, hogyan lehet egy diagramból képet létrehozni és menteni, ami hasznos, ha a diagram vizuális elemeit a PowerPoint-prezentáción kívül kell újra felhasználni.

## **Diagramkép lekérése**
Az Aspose.Slides for C++ támogatja egy adott diagram képének kinyerését. Az alábbi példa bemutatásra kerül.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **GYIK**

**Exportálhatok egy diagramot vektor (SVG) formátumban a raszteres kép helyett?**

Igen. A diagram egy alakzat, és tartalmát SVG-be menthetjük a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) használatával.

**Hogyan állíthatom be a exportált diagram pontos méretét pixelben?**

Használja a képrenderelés túlterheléseit, amelyek lehetővé teszik a méret vagy méretezés megadását - a könyvtár támogatja az objektumok megadott dimenziók/arányok szerinti renderelését.

**Mit tegyek, ha a címkékben és a jelmagyarázatban lévő betűtípusok helytelennek tűnnek az exportálás után?**

[Töltsön be a szükséges betűtípusokat](/slides/hu/cpp/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg kinézetét.

**Tiszteletben tartja az exportálás a PowerPoint téma, stílusok és effektusok beállításait?**

Igen. Az Aspose.Slides renderelője a prezentáció formázását (témák, stílusok, kitöltések, hatások) követi, így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken túl elérhető renderelési/exportálási lehetőségek?**

Lásd az exportálási szakaszt az [API](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/)/[dokumentáció](/slides/hu/cpp/convert-powerpoint/) oldalon a kimeneti célokhoz ([PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállítások.