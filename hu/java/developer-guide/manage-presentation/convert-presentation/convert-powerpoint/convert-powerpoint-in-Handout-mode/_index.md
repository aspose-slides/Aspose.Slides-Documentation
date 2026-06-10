---
title: PowerPoint bemutatók konvertálása kézikönyvi módban Java használatával
linktitle: Kézikönyvi mód
type: docs
weight: 150
url: /hu/java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- kézikönyvi mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Konvertálja a bemutatókat kézikönyvekbe Java-ban. Állítson be oldalankénti diák számát, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides segítségével, minta Java kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a bemutatókat olyan kimeneti formátumokra konvertálja, amelyek támogatják a kézikönyvi módot. Ebben a módban több dia kerül egyetlen oldalra, ami hasznos a prezentációs anyagok nyomtatásához konferenciákon, szemináriumokon és hasonló eseményeken.

A kézikönyvi mód a `setSlidesLayoutOptions` metódussal konfigurálható, amely elérhető az [IPdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipdfoptions/), az [IRenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irenderingoptions/), az [IHtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihtmloptions/) és az [ITiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiffoptions/) felületeken. A kézikönyv elrendezésének meghatározásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) objektumot.

## **Kézikönyvi módú exportálás**

A bemutató kézikönyvi módban történő exportálásához állítsa be a cél exportálási beállításoknál a `setSlidesLayoutOptions` metódust, és adjon meg egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) példányt, amely meghatározza az oldalonkénti diák számát és a kapcsolódó megjelenítési paramétereket.

Alább egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy bemutatót PDF‑re kézikönyvi módban.

```java
// Töltsön be egy prezentációt.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Állítsa be az exportálási beállításokat.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // nyomtassa a dia számokat
    slidesLayoutOptions.setPrintFrameSlide(true);                     // rajzoljon keretet a diák köré
    slidesLayoutOptions.setPrintComments(false);                      // nincs megjegyzés

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exportálja a prezentációt PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Vegye figyelembe, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF esetén, valamint képek renderelésekor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diakép miniatűrök száma oldalanként a kézikönyvi módban?**

Az Aspose.Slides [preseteket](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) támogat, amelyek legfeljebb 9 miniatűrt tesznek lehetővé oldalanként, vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyedi rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A miniatűrök száma és elrendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) osztály által van meghatározva; egyedi elrendezések nem támogatottak.

**Belefoglalhatom a rejtett diákot a kézikönyvi kimenetbe?**

Igen. Engedélyezze a rejtett diák megjelenítését a `setShowHiddenSlides` metódussal az exportálási beállításoknál a célformátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/), a [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/) esetén.