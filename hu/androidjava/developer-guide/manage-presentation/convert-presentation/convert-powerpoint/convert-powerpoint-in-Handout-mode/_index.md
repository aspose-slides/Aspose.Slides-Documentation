---
title: PowerPoint prezentációk konvertálása kézikönyv módban Androidon
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/androidjava/convert-powerpoint-in-handout-mode/
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
description: "Prezentációkat konvertál kézikönyvekké Java-ban. Állítsd be az oldalankénti diák számát, tartsd meg a jegyzeteket, exportálj PDF-be vagy képekbe az Aspose.Slides for Android-al, mintakóddal. Próbáld ki ingyen."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a prezentációk különféle formátumokra történő konvertálását, beleértve a kézikönyvek (Handout) nyomtatásra való előállítását. Ez a mód lehetővé teszi, hogy beállítsa, hány diát jelenjen meg egyetlen oldalon, ami konferenciák, szemináriumok és egyéb események számára hasznos. A mód engedélyezhető a `setSlidesLayoutOptions` metódus beállításával a [IPdfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itiffoptions/) interfészekben.

## **Kézikönyv módú exportálás**

A Kézikönyv mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra, valamint a megjelenítés egyéb paramétereit.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertálhat egy prezentációt PDF‑be Kézikönyv módban.

```java
// Prezentáció betöltése.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Exportálási beállítások megadása.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // dia számok nyomtatása
	slidesLayoutOptions.setPrintFrameSlide(true);                     // keret nyomtatása a diáknál
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
Ne feledje, hogy a `setSlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, illetve képként történő rendereléskor.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diaképek számú előnézet egy oldalon a Kézikönyv módban?**

Az Aspose.Slides [előre beállított](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) elrendezéseket támogat, amelyek legfeljebb 9 előnézeti diát biztosítanak oldalanként, vízszintes vagy függőleges sorrendben: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A bélyegképek száma és sorrendje szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/handouttype/) osztály által van vezérelve; tetszőleges elrendezések nem támogatottak.

**Tüntetett diákat is belefoglalhatok a kézikönyv kimenetbe?**

Igen. Engedélyezze a rejtett diákat a `setShowHiddenSlides` metódussal az adott kimeneti formátum export beállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/tiffoptions/) esetén.