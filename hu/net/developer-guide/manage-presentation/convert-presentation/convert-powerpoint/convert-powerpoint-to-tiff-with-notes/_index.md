---
title: PowerPoint prezentációk konvertálása TIFF-be jegyzetekkel .NET-ben
linktitle: PowerPoint TIFF-be jegyzetekkel
type: docs
weight: 100
url: /hu/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-be
- prezentáció TIFF-be
- dia TIFF-be
- PPT TIFF-be
- PPTX TIFF-be
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- PowerPoint jegyzetekkel
- prezentáció jegyzetekkel
- dia jegyzetekkel
- PPT jegyzetekkel
- PPTX jegyzetekkel
- TIFF jegyzetekkel
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat TIFF-be jegyzetekkel az Aspose.Slides for .NET használatával. Tanulja meg, hogyan exportálhatja hatékonyan a diákat előadói jegyzetekkel."
---
## **Bevezetés**

Az Aspose.Slides for .NET egyszerű megoldást kínál a PowerPoint és OpenDocument prezentációk (PPT, PPTX és ODP) jegyzetekkel együtt TIFF formátumba történő átalakításához. Ez a formátum széles körben használatos magas minőségű képtárolásra, nyomtatásra és dokumentumarchiválásra. Az Aspose.Slides segítségével nem csak az egész prezentációt exportálhatja előadói jegyzetekkel, hanem a dia bélyegképeket is előállíthatja a Jegyzetdia nézetben. Az átalakítás egyszerű és hatékony, a `Save` metódust használva a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályban, amely a teljes prezentációt TIFF képsorozattá alakítja, miközben megőrzi a jegyzeteket és az elrendezést.

## **Prezentáció átalakítása TIFF-be jegyzetekkel**

PowerPoint vagy OpenDocument prezentáció TIFF-be mentése jegyzetekkel az Aspose.Slides for .NET segítségével az alábbi lépéseket tartalmazza:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály egy példányát: Töltsön be egy PowerPoint vagy OpenDocument fájlt.  
1. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) osztályt a jegyzetek és megjegyzések megjelenítési módjának meghatározásához.  
1. Mentse a prezentációt TIFF-be: Adja át a beállított opciókat a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save/index) metódusnak.  

Tegyük fel, hogy van egy "speaker_notes.pptx" fájlunk a következő diával:

![A prezentáció dia előadói jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan konvertálhatjuk a prezentációt TIFF képpé a Jegyzetdia nézetben a [SlidesLayoutOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) tulajdonság használatával.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurálja a TIFF opciókat a jegyzetelrendezéssel.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // A jegyzetek megjelenítése a dia alatt.
        }
    };

    // Mentse a prezentációt TIFF-be a beszélőjegyzetekkel.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Az eredmény:

![A TIFF képfájl előadói jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tipp" color="info" %}}

Tekintse meg az Aspose ingyenes [PowerPoint poszter konvertert](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **GYIK**

### Vezérelhetem a jegyzetterület pozícióját a keletkezett TIFF-ben?

Igen. Használja a [jegyzet elrendezési beállításokat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), hogy a `None`, `BottomTruncated` vagy `BottomFull` opciók közül válasszon, amelyek rendre a jegyzetek elrejtését, egy oldalra való illesztését vagy több oldalra történő folytatását teszik lehetővé.

### Hogyan csökkenthetem a jegyzetes TIFF fájl méretét anélkül, hogy a minőség láthatóan romlana?

Válasszon [hatékony tömörítést](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/compressiontype/) (például `LZW` vagy `RLE`), állítson be megfelelő DPI-t, és ha elfogadható, használjon alacsonyabb [pixelformátumot](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/pixelformat/) (mint például 8 bpp vagy 1 bpp monokróm esetén). A [kép méretének](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/imagesize/) enyhe csökkentése is segíthet anélkül, hogy jelentősen rontaná az olvashatóságot.

### A jegyzetek betűtípusa befolyásolja az eredményt, ha az eredeti betűtípusok hiányoznak a rendszerből?

Igen. A hiányzó betűtípusok [helyettesítést](/slides/hu/net/font-selection-sequence/) váltanak ki, ami megváltoztathatja a szöveg méreteit és megjelenését. Ennek elkerülése érdekében [biztosítsa a szükséges betűtípusokat](/slides/hu/net/custom-font/) vagy állítson be alapértelmezett [tartalék betűtípust](/slides/hu/net/fallback-font/), hogy a kívánt tipográfia használható legyen.