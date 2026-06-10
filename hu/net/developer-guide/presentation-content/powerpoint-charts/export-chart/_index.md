---
title: Prezentációs diagramok exportálása .NET-ben
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/net/export-chart/
keywords:
- diagram
- diagram képpé
- diagram képként
- diagramkép kinyerése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhatja a prezentációs diagramokat az Aspose.Slides for .NET segítségével, PPT és PPTX formátumok támogatásával, és egyszerűsítse a jelentéskészítést bármilyen munkafolyamatban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot egy bemutatóból képként exportálja. Ez a cikk bemutatja, hogyan lehet képet lekérni egy diagramról, és menteni azt, ami akkor hasznos, ha a diagram vizuális elemeit a PowerPoint bemutatón kívül kell újra felhasználni.

Az alapvető képexport munkafolyamat mellett a cikk a gyakori exporttal kapcsolatos kérdésekre is kitér, többek között a diagram tartalmának SVG formátumba mentésére, a kimeneti méret szabályozására renderelési beállításokkal, betűtípusok betöltésére a címkék és a jelmagyarázat megjelenésének megőrzése érdekében, valamint az eredeti bemutató formázásának, például témák, stílusok, kitöltések és effektusok megtartására a renderelés során.

## **Diagramkép lekérése**
Az Aspose.Slides for .NET támogatja egy adott diagram képként történő kinyerését. Az alábbi minta példa bemutatásra kerül.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **GYIK**

**Exportálhatok egy diagramot vektorként (SVG) a raszteres kép helyett?**

Igen. A diagram egy alakzat, és tartalma SVG‑ként menthető a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/writeassvg/) segítségével.

**Hogyan állíthatom be az exportált diagram pontos méretét pixelben?**

Használja a képrenderelés túlterheléseit, amelyek lehetővé teszik a méret vagy skála megadását – a könyvtár támogatja az objektumok adott mérettel/skálával történő renderelését.

**Mit tegyek, ha a címkékben és a jelmagyarázatban lévő betűtípusok helytelenül jelennek meg export után?**

[Töltse be a szükséges betűtípusokat](/slides/hu/net/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikan és a szöveg megjelenését.

**Figyelembe veszi az export a PowerPoint téma, stílusok és effektusok beállításait?**

Igen. Az Aspose.Slides renderelője követi a bemutató formázását (témák, stílusok, kitöltések, effektusok), így a diagram megjelenése megmarad.

**Hol találom a diagramképeken kívüli elérhető renderelési/exportálási képességeket?**

Tekintse meg az export szekciót az [API](https://reference.aspose.com/slides/hu/net/aspose.slides.export/)/[dokumentációban](/slides/hu/net/convert-powerpoint/) a kimeneti célpontokhoz ([PDF](/slides/hu/net/convert-powerpoint-to-pdf/), [SVG](/slides/hu/net/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/net/convert-powerpoint-to-xps/), [HTML](/slides/hu/net/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállítások.