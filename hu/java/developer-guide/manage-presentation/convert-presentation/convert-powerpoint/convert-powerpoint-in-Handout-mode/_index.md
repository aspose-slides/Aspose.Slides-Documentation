---
title: PowerPoint prezentációk konvertálása handout módban Java használatával
linktitle: Handout mód
type: docs
weight: 150
url: /hu/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- handout mód
- handout
- PPT
- PPTX
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Prezentációk konvertálása handout formátumba Java-ban. Állítsa be az oldalankénti diák számát, tartsa a jegyzeteket, exportáljon PDF-re vagy képekre az Aspose.Slides segítségével, minta Java kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a prezentációkat olyan kimeneti formátumokra konvertálja, amelyek támogatják a Handout módot. Ebben a módban több dia egyetlen oldalon van elrendezve, ami hasznos a prezentációs anyagok nyomtatásához konferenciák, szemináriumok és hasonló események esetén.

A Handout mód a `setSlidesLayoutOptions` metódussal konfigurálható, amely elérhető az [IPdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiffoptions/) esetén. A handout elrendezés meghatározásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) objektumot.

## **Handout mód exportálás**

A prezentáció Handout módban történő exportálásához állítsa be a `setSlidesLayoutOptions` metódust a cél exportálási beállításoknál, és adjon meg egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) példányt, amely meghatározza az oldalankénti diák számát és a kapcsolódó megjelenítési paramétereket.

Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy prezentációt PDF-re Handout módban.

```java
// Prezentáció betöltése.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportálási beállítások megadása.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // diaszámok nyomtatása
    slidesLayoutOptions.setPrintFrameSlide(true);                     // keret nyomtatása a diák köré
    slidesLayoutOptions.setPrintComments(false);                      // nincsenek megjegyzések

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Prezentáció exportálása PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Vegye figyelembe, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, és képek renderelésekor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diakép szám oldalanként a Handout módban?**

Az Aspose.Slides [előre definiált beállításokat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) támogat, amelyek legfeljebb 9 bélyegképet tesznek lehetővé oldalanként, vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diákat oldalanként?**

Nem. A bélyegképek számát és sorrendjét kizárólag a [HandoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) osztály határozza meg; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diákot a Handout kimenetben?**

Igen. A rejtett diák engedélyezhetők a `setShowHiddenSlides` metódus használatával az export beállításokban a cél formátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/).