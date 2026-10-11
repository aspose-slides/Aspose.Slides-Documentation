---
title: PowerPoint bemutatók konvertálása Kézikönyv módban Androidon
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Konvertálja a bemutatókat kézikönyvekké Java-ban. Állítsa be az oldalankénti diák számát, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Androidra készült Aspose.Slides segítségével, mintaprogrammal. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a bemutatók különféle formátumokra történő konvertálását, beleértve a kézikönyvek létrehozását nyomtatáshoz Kézikönyv módban. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelenjenek meg több dia egyetlen oldalon, ami hasznos konferenciákon, szemináriumokon és egyéb eseményeken. Engedélyezheti ezt a módot a `setSlidesLayoutOptions` metódus beállításával az [IPdfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfészekben.

A kézikönyv oldal méretének és tájolásának beállításához az exportálás előtt, tekintse meg a [Jegyzetoldal mérete](/slides/hu/androidjava/notes-size/) oldalt.

## **Kézikönyv módú exportálás**

A Kézikönyv mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egyetlen oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbiakban egy kódpélda látható, amely bemutatja, hogyan konvertálhat egy bemutatót PDF-be Kézikönyv módban.

```java
import com.aspose.slides.*;

// Töltse be a bemutatót.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Állítsa be az exportálási beállításokat.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // dia számok nyomtatása
	slidesLayoutOptions.setPrintFrameSlide(true);                     // keret nyomtatása a diák körül
	slidesLayoutOptions.setPrintComments(false);                      // nincs megjegyzés

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportálja a bemutatót PDF-be a kiválasztott elrendezéssel.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Vegye figyelembe, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, valamint képként történő megjelenítéskor.
{{% /alert %}} 

## **GYIK**

**Mennyi a maximális dia‑bélyegkép száma oldalanként Kézikönyv módban?**

Az Aspose.Slides támogatja a [presets](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) legfeljebb 9 bélyegkép oldalanként, vízszintes vagy függőleges rendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A bélyegképek száma és rendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) osztály által van meghatározva; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diát a Kézikönyv kimenetben?**

Igen. A rejtett diák engedélyezhetők a `setShowHiddenSlides` metódus használatával az exportbeállításokban a célformátumhoz, például a [PdfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) esetén.