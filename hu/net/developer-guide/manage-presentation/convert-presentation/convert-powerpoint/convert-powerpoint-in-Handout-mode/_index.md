---
title: PowerPoint bemutatók konvertálása kézibeszúrási módban .NET-ben
linktitle: Kézibeszúrási mód
type: docs
weight: 150
url: /hu/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- kézibeszúrási mód
- kézibeszúrás
- PowerPoint
- bemutató
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: ".NET-ben konvertálja a bemutatókat kézibeszúrásra. Állítsa be az oldalonkénti diák számát, tartsa meg a jegyzeteket, exportáljon PDF-re vagy képekre az Aspose.Slides segítségével, mintakóddal C#-ban. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a bemutatókat olyan kimeneti formátumokra konvertálja, amelyek támogatják a kézibeszúrási módot. Ebben a módban több dia egyetlen oldalon kerül elrendezésre, ami hasznos a bemutatóanyagok nyomtatásához konferenciákon, szemináriumokon és hasonló eseményeken.

A kézibeszúrási mód a `SlidesLayoutOptions` tulajdonságon keresztül konfigurálható, amely a [IPdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipdfoptions/), a [IRenderingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/irenderingoptions/), a [IHtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ihtmloptions/), és a [ITiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/itiffoptions/) esetén érhető el. A kézibeszúrás elrendezésének meghatározásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handoutlayoutingoptions/) objektumot.

## **Kézibeszúrási mód exportálása**

A prezentáció kézibeszúrási módban történő exportálásához állítsa be a `SlidesLayoutOptions` tulajdonságot a cél exportálási beállításoknál, és adjon meg egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handoutlayoutingoptions/) példányt, amely meghatározza a diák oldalankénti számát és a kapcsolódó megjelenítési paramétereket.

Az alábbi kódpélda bemutatja, hogyan konvertálhat egy prezentációt PDF‑re kézibeszúrási módban.

```c#
// Töltsön be egy bemutatót.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 dia egy oldalon vízszintesen
        PrintSlideNumbers = true,                   // nyomtassa ki a dia számát
        PrintFrameSlide = true,                     // nyomtassa ki a diák köré a keretet
        PrintComments = false                       // nincs megjegyzés
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `SlidesLayoutOptions` tulajdonság csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, illetve képként történő renderelés esetén.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diakép-miniatúrák száma oldalanként a kézibeszúrási módban?**

Az Aspose.Slides támogatja a [előbeállításokat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handouttype/) legfeljebb 9 miniaturát oldalanként vízszintes vagy függőleges elrendezésben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A miniaturák száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handouttype/) felsorolás által van szabályozva; egyedi elrendezések nem támogatottak.

**Tudok rejtett diákat is belefoglalni a kézibeszúrási kimenetbe?**

Igen. Engedélyezze a `ShowHiddenSlides` beállítást az exportálási beállításokban a célformátumnál, például a [PdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/), a [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/), vagy a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) használatával.