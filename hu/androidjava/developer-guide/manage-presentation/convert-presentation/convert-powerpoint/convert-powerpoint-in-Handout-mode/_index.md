---
title: PowerPoint prezentációk konvertálása kézikönyv módban Androidon
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Prezentációk konvertálása kézikönyvekké Java-ban. Állítsa be az oldalankénti diák számát, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekre az Aspose.Slides for Android segítségével, mintakód példával. Próbálja ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különböző formátumokra való konvertálását, beleértve a kézikönyvek létrehozását nyomtatáshoz Kézikönyv módban. Ez a mód lehetővé teszi, hogy konfigurálja, hogyan jelennek meg több dia egyetlen oldalon, ami hasznos konferenciák, szemináriumok és egyéb események számára. A mód engedélyezhető a `setSlidesLayoutOptions` metódus beállításával a [IPdfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihtmloptions/), és [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfészekben.

## **Kézikönyv mód exportálása**

A kézikönyv mód beállításához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hogy hány dia kerül egyetlen oldalra, valamint egyéb megjelenítési paramétereket.

```java
// Prezentáció betöltése.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Exportálási beállítások megadása.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // dia számok nyomtatása
	slidesLayoutOptions.setPrintFrameSlide(true);                     // keret nyomtatása a diák köré
	slidesLayoutOptions.setPrintComments(false);                      // nincsenek megjegyzések

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportálja a prezentációt PDF-be a kiválasztott elrendezéssel.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumokhoz érhető el, például PDF, HTML, TIFF, és képként történő renderelés esetén.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diaképlet száma oldalanként a Kézikönyv módban?**

Az Aspose.Slides [előre beállított](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) lehetőségeket támogat, amelyek legfeljebb 9 bélyegképet tesznek lehetővé oldalanként vízszintes vagy függőleges sorrendben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Létrehozhatok egy egyedi rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A bélyegképek száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) osztály által van vezérelve; tetszőleges elrendezések nem támogatottak.

**Tudok rejtett diákat is belefoglalni a Kézikönyv kimenetbe?**

Igen. A rejtett diák engedélyezhetők a `setShowHiddenSlides` metódus használatával a célformátum export beállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/), vagy a [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) esetén.