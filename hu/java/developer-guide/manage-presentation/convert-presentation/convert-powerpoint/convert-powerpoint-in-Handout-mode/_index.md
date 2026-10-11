---
title: PowerPoint bemutatók konvertálása kézbesítő módba Java-val
linktitle: Kézbesítő mód
type: docs
weight: 150
url: /hu/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- kézbesítő mód
- kézbesítő
- PPT
- PPTX
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Konvertálja a bemutatókat kézbesítő formátumba Java-ban. Állítsa be az oldalon lévő diák számát, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides használatával, minta Java kóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a bemutatókat olyan kimeneti formátumokra konvertálja, amelyek támogatják a kézbesítő módot. Ebben a módban több diát rendeznek el egyetlen oldalon, ami hasznos a konferenciák, szemináriumok és hasonló események számára szánt bemutató anyagok nyomtatásához.

A kézbesítő mód a `setSlidesLayoutOptions` metódussal konfigurálható, amely a [IPdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itiffoptions/) esetén érhető el. A kézbesítő elrendezés meghatározásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) objektumot.

A kézbesítő oldal méretének és tájolásának exportálás előtti beállításához lásd a [Megjegyzés oldal mérete](/slides/hu/java/notes-size/).

## **Kézbesítő módú exportálás**

A bemutató kézbesítő módban történő exportálásához állítsa be a `setSlidesLayoutOptions` metódust a cél exportálási beállításoknál, és adjon meg egy [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handoutlayoutingoptions/) példányt, amely meghatározza az oldalankénti diák számát és a kapcsolódó megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy bemutatót PDF-be kézbesítő módban.

```java
import com.aspose.slides.*;

// Töltsön be egy bemutatót.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Állítsa be az exportálási beállításokat.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // nyomtassa ki a diák számát
    slidesLayoutOptions.setPrintFrameSlide(true);                     // nyomtassa ki a keretet a diák körül
    slidesLayoutOptions.setPrintComments(false);                      // nincs megjegyzés

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exportálja a bemutatót PDF-be a kiválasztott elrendezéssel.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Figyelmeztetés" %}}

Vigyázat, a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, vagy képként történő renderelés esetén.

{{% /alert %}} 

## **GYIK**

**Mi a maximális diakép miniatűrök száma oldalanként a kézbesítő módban?**

Az Aspose.Slides a [presets](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) segítségével legfeljebb 9 miniatűrt támogat oldalanként, vízszintes vagy függőleges elrendezésben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A miniatűrök száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/handouttype/) osztály által van szabályozva; tetszőleges elrendezések nem támogatottak.

**Tudok-e rejtett diákat is belefoglalni a kézbesítő kimenetbe?**

Igen. A rejtett diákat az `setShowHiddenSlides` metódus engedélyezésével vehetjük fel az exportálási beállításoknál a cél formátumnál, például a [PdfOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/tiffoptions/) esetén.