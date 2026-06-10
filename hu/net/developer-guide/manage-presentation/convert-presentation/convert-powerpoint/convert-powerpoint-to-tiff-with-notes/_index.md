---
title: PowerPoint bemutatók konvertálása TIFF-be jegyzetekkel .NET-ben
linktitle: PowerPoint TIFF-be jegyzetekkel
type: docs
weight: 100
url: /hu/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint TIFF-be
- bemutató TIFF-be
- dia TIFF-be
- PPT TIFF-be
- PPTX TIFF-be
- PPT mentése TIFF-ként
- PPTX mentése TIFF-ként
- PPT exportálása TIFF-be
- PPTX exportálása TIFF-be
- PowerPoint jegyzetekkel
- bemutató jegyzetekkel
- dia jegyzetekkel
- PPT jegyzetekkel
- PPTX jegyzetekkel
- TIFF jegyzetekkel
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint bemutatókat TIFF-be jegyzetekkel az Aspose.Slides for .NET használatával. Ismerje meg, hogyan exportálhatja a diákat előadói jegyzetekkel hatékonyan."
---
## **Bevezetés**

Aspose.Slides for .NET egyszerű megoldást kínál a PowerPoint és OpenDocument bemutatók (PPT, PPTX és ODP) jegyzetekkel együtt TIFF formátumba konvertálására. Ez a formátum széles körben használatos magas minőségű képtárolásra, nyomtatásra és dokumentumarchiválásra. Az Aspose.Slides segítségével nem csak a teljes bemutatót exportálhatja előadói jegyzetekkel, hanem diakép bélyegképeket is generálhat a Jegyzet Dia nézetben. A konverziós folyamat egyszerű és hatékony, az [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály `Save` metódusát használva alakítja a teljes bemutatót TIFF képsorozattá, miközben megőrzi a jegyzeteket és az elrendezést.

## **Bemutató konvertálása TIFF-be jegyzetekkel**

PowerPoint vagy OpenDocument bemutató TIFF-be mentése jegyzetekkel az Aspose.Slides for .NET használatával a következő lépéseket tartalmazza:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályt: Töltse be a PowerPoint vagy OpenDocument fájlt.
2. Állítsa be a kimeneti elrendezési beállításokat: Használja a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/notescommentslayoutingoptions/) osztályt annak meghatározásához, hogyan jelenjenek meg a jegyzetek és megjegyzések.
3. Mentse a bemutatót TIFF-be: Adja át a beállított opciókat a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save/index) metódusnak.

Tegyük fel, hogy van egy „speaker_notes.pptx” fájlunk a következő diával:

![A bemutató dia előadói jegyzetekkel](slide_with_notes.png)

Az alábbi kódrészlet bemutatja, hogyan konvertálja a bemutatót TIFF-képpé a Jegyzet Dia nézetben a [SlidesLayoutOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) tulajdonság használatával.

```c#
// Példányosítja a Presentation osztályt, amely egy bemutató fájlt reprezentál.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurálja a TIFF beállításokat a Jegyzetek elrendezésével.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // A jegyzeteket a dia alá jeleníti meg.
        }
    };

    // Elmenti a bemutatót TIFF-be a előadói jegyzetekkel.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Az eredmény:

![A TIFF kép előadói jegyzetekkel](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Tekintse meg az Aspose [Ingyenes PowerPoint poszter konvertert](https://products.aspose.app/slides/hu/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **GYIK**

**Kontrolálhatom a jegyzet terület pozícióját a létrejövő TIFF-ben?**

Igen. Használja a [notes layout settings](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) beállításait, hogy a `None`, `BottomTruncated` vagy `BottomFull` opciók közül válasszon, amelyek rendre a jegyzetek elrejtését, egyetlen oldalra való illesztését vagy további oldalakra való áramoltatását teszik lehetővé.

**Hogyan csökkenthetem a jegyzetekkel ellátott TIFF-fájl méretét anélkül, hogy látható minőségromlás lépne fel?**

Válasszon egy [efficient compression](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/compressiontype/) (pl. `LZW` vagy `RLE`), állítson be egy ésszerű DPI értéket, és ha elfogadható, használjon alacsonyabb [pixel format](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/pixelformat/) (például 8 bpp vagy 1 bpp monokrómhoz). Az [image dimensions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/imagesize/) enyhe csökkentése is segíthet anélkül, hogy jelentősen rontaná az olvashatóságot.

**A jegyzetekben használt betűtípus befolyásolja az eredményt, ha az eredeti betűtípusok hiányoznak a rendszeren?**

Igen. A hiányzó betűtípusok [substitution](/slides/hu/net/font-selection-sequence/) műveletet váltanak ki, ami megváltoztathatja a szöveg méreteit és megjelenését. Ennek elkerülése érdekében [adja meg a szükséges betűtípusokat](/slides/hu/net/custom-font/) vagy állítson be egy alapértelmezett [fallback font](/slides/hu/net/fallback-font/) betűtípust, hogy a kívánt típusok legyenek használva.