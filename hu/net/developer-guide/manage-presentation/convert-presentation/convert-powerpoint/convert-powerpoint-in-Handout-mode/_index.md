---
title: PowerPoint bemutatók konvertálása szórólap módra .NET-ben
linktitle: Szórólap mód
type: docs
weight: 150
url: /hu/net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- szórólap mód
- szórólap
- PowerPoint
- prezentáció
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a prezentációkat szórólapokká .NET-ben. Állítsa be az oldalankénti diák számát, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides segítségével, minta C# kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a bemutatókat olyan kimeneti formátumokra konvertálja, amelyek támogatják a Szórólap módot. Ebben a módban több dia kerül egyetlen oldalra, ami hasznos a bemutató anyagok nyomtatásához konferenciákon, szemináriumokon és hasonló eseményeken.

A Szórólap mód a `SlidesLayoutOptions` tulajdonsággal konfigurálható, amely a [IPdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/itiffoptions/) esetén elérhető. A szórólap elrendezésének meghatározásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handoutlayoutingoptions/) objektumot.

A szórólap oldal méretének és tájolásának export előtt történő beállításához lásd a [Notes Page Size](/slides/hu/net/notes-size/) oldalt.

## **Szórólap módú export**

A bemutató Szórólap módban történő exportálásához állítsa be a `SlidesLayoutOptions` tulajdonságot a cél exportálási beállításoknál, és adjon meg egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handoutlayoutingoptions/) példányt, amely meghatározza az oldalon lévő diák számát és a kapcsolódó megjelenítési paramétereket.

Az alábbi kódpélda mutatja, hogyan konvertálható egy bemutató PDF formátumba Szórólap módban.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Betölti a bemutatót.
using var presentation = new Presentation("sample.pptx");

// Beállítja az exportálási beállításokat.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 dia egy oldalon vízszintesen
        PrintSlideNumbers = true,                   // dia számok nyomtatása
        PrintFrameSlide = true,                     // keret nyomtatása a diák köré
        PrintComments = false                       // nincsenek megjegyzések
    }
};

// Exportálja a bemutatót PDF-be a kiválasztott elrendezéssel.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `SlidesLayoutOptions` tulajdonság csak bizonyos kimeneti formátumok esetén érhető el, például PDF, HTML, TIFF, illetve képként történő rendereléskor.
{{% /alert %}} 

## **GYIK**

### Mi a maximális diakép minikép száma oldalanként a Szórólap módban?

Az Aspose.Slides [előbeállításokat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handouttype/) támogat, amelyek legfeljebb 9 miniképet tesznek lehetővé oldalanként vízszintes vagy függőleges elrendezésben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

### Definiálhatok egyéni rácsot, például 5 vagy 8 diát oldalanként?

Nem. A miniképek száma és elrendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/net/aspose.slides.export/handouttype/) felsorolás által vezérelve; tetszőleges elrendezések nem támogatottak.

### Belefoglalhatók a rejtett diák a Szórólap kimenetbe?

Igen. Engedélyezze a `ShowHiddenSlides` opciót az exportálási beállításoknál a cél formátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/tiffoptions/) esetén.