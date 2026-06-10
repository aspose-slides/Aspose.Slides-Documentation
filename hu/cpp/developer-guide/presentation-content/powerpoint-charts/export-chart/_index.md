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
description: "Ismerje meg, hogyan exportálhatja a prezentációs diagramokat az Aspose.Slides for C++ segítségével, PPT és PPTX formátumok támogatásával, és egyszerűsítse a jelentéstételt bármilyen munkafolyamatban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a prezentációból képként exportálja. Ez a cikk bemutatja, hogyan lehet egy diagramról képet kapni és elmenteni, ami hasznos, ha a diagram vizuális elemeit a PowerPoint prezentáción kívül szeretné újra felhasználni.

## **Diagramkép lekérése**
Az Aspose.Slides for C++ támogatja egy adott diagram képként történő kinyerését. Az alábbi példakód mutatja.

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

**Exportálhatok egy diagramot vektorként (SVG) a raszteres kép helyett?**

Igen. A diagram egy alakzat, és tartalma SVG-be menthető a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) használatával.

**Hogyan állíthatom be a exportált diagram pontos méretét pixelekben?**

Használja a képrenderelés túlterheléseit, amelyek lehetővé teszik a méret vagy a méretezés megadását – a könyvtár támogatja az objektumok adott mérettel/méretezéssel történő renderelését.

**Mit tegyek, ha a címkék és a jelmagyarázat betűtípusai hibásan jelennek meg export után?**

[Töltse be a szükséges betűtípusokat](/slides/hu/cpp/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Tiszteletben tartja-e az export a PowerPoint téma, stílusok és hatásokat?**

Igen. Az Aspose.Slides renderelője követi a prezentáció formázását (témák, stílusok, kitöltések, hatások), így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken kívüli elérhető renderelési/exportálási lehetőségek?**

Tekintse meg az export szekciót az [API](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/)/[dokumentációban](/slides/hu/cpp/convert-powerpoint/) a kimeneti célokhoz ([PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hu/cpp/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállításokat.