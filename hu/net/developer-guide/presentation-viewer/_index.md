---
title: Prezentáció megjelenítő létrehozása .NET-ben
linktitle: Prezentáció megjelenítő
type: docs
weight: 50
url: /hu/net/presentation-viewer/
keywords: 
- prezentáció megtekintése
- prezentáció megjelenítő
- prezentáció megjelenítő létrehozása
- PPT megtekintése
- PPTX megtekintése
- ODP megtekintése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Egy egyéni prezentáció megjelenítőt hoz létre .NET-ben az Aspose.Slides használatával. Egyszerűen megjelenítheti a PowerPoint és OpenDocument fájlokat a Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Aspose.Slides for .NET a diákat tartalmazó bemutatófájlok létrehozására szolgál. Ezek a diák megtekinthetők például a Microsoft PowerPoint megnyitásával. Előfordulhat azonban, hogy a fejlesztők a diák képeit szeretnék megtekinteni kedvenc képnézegetőjükkel, vagy egy egyéni bemutató megjelenítőben használják fel őket. Ilyen esetben az Aspose.Slides lehetővé teszi az egyes diák képként történő exportálását. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép létrehozása diáról**

Az Aspose.Slides használatával egy prezentáció diáiból SVG képet generálni az alábbi lépésekkel lehet:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát a diára az indexe alapján.
1. Nyisson meg egy fájlfolyamot.
1. Mentse el a diát SVG képként a fájlfolyamba.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **SVG generálása egyéni alakzat azonosítóval**

Aspose.Slides használható egy [SVG](https://docs.fileformat.com/page-description-language/svg/) generálására egyedi alakzat `ID`-val rendelkező diáról. Ennek eléréséhez használja az [ISvgShape](https://reference.aspose.com/slides/hu/net/aspose.slides.export/isvgshape) interfész Id tulajdonságát. A `CustomSvgShapeFormattingController` osztály használható az alakzat azonosítójának beállítására.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Dia miniatűr kép létrehozása**

Aspose.Slides segít miniatűr képeket generálni a diákhoz. Egy dia miniatűrjének létrehozásához az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát a diára az indexe alapján.
1. Készítsen miniatűr képet a hivatkozott diáról a kívánt méretarányban.
1. Mentse el a miniatűr képet a kívánt képformátumban.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Dia miniatűr létrehozása felhasználó által meghatározott méretekkel**

Felhasználó által meghatározott méretekkel ellátott dia miniatűr kép létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát a diára az indexe alapján.
1. Generáljon miniatűr képet a hivatkozott diáról a megadott méretekkel.
1. Mentse el a miniatűr képet a kívánt képformátumban.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Dia miniatűr létrehozása előadói jegyzetekkel**

Aspose.Slides használatával egy előadói jegyzetekkel rendelkező dia miniatűrjének generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/renderingoptions/) osztályból.
1. `RenderingOptions.SlidesLayoutOptions` tulajdonságot használja az előadói jegyzetek pozíciójának beállításához.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát a diára az indexe alapján.
1. Generáljon miniatűr képet a hivatkozott diáról a renderelési beállítások használatával.
1. Mentse el a miniatűr képet a kívánt képformátumban.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hu/viewer/) ingyenes alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API segítségével:

[![Online PowerPoint megjelenítő](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/hu/viewer/)

## **GYIK**

**Beágyazhatok bemutató megjelenítőt egy ASP.NET webalkalmazásba?**

Igen. Az Aspose.Slides szerveroldalon használható a diák képként vagy HTML-ként történő renderelésére, majd a böngészőben való megjelenítésére. A navigációs és nagyítási funkciók JavaScript segítségével megvalósíthatók az interaktív élmény érdekében.

**Mi a legjobb módja a diák megjelenítésének egy egyedi .NET megjelenítőben?**

Az ajánlott megközelítés, hogy minden diát képként (például PNG vagy SVG) renderelünk, vagy az Aspose.Slides segítségével HTML-re konvertálunk, majd a kimenetet egy képkeretben (asztali alkalmazás esetén) vagy HTML konténerben (web esetén) jelenítjük meg.

**Hogyan kezeljem a sok diát tartalmazó nagy prezentációkat?**

Nagy prezentációk esetén fontolja meg a diák lazy-loading vagy igény szerinti renderelését. Ez azt jelenti, hogy egy dia tartalmát csak akkor generálja, amikor a felhasználó rá navigál, így csökken a memória- és betöltési idő.