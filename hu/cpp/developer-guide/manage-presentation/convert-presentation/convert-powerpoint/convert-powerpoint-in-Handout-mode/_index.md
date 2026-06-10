---
title: PowerPoint bemutatók konvertálása kézikönyv módba C++ használatával
linktitle: Kézikönyv mód
type: docs
weight: 150
url: /hu/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- kézikönyv mód
- kézikönyv
- PPT
- PPTX
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Konvertálja a bemutatókat kézikönyvekké C++-ban. Állítsa be a diákat oldalanként, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Aspose.Slides lehetővé teszi a bemutatók különböző formátumokra történő konvertálását, beleértve a kézikönyvek nyomtatásra Handout módban való létrehozását. Ez a mód lehetővé teszi, hogy konfigurálja, hogyan jelennek meg több dia egyetlen oldalon, ami hasznos konferenciákon, szemináriumokon és egyéb eseményeken. Engedélyezheti ezt a módot a `set_SlidesLayoutOptions` metódus beállításával az [IPdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ihtmloptions/), és [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfészekben.

## **Handout módú export**

A Handout mód konfigurálásához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra és egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertáljon egy bemutatót PDF-re Handout módban.

```cpp
// Töltse be a bemutatót.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Állítsa be az exportálási beállításokat.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // dia számait nyomtatja
slidesLayoutOptions->set_PrintFrameSlide(true);                      // keretet nyomtat a diák köré
slidesLayoutOptions->set_PrintComments(false);                       // nincs megjegyzés

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Exportálja a bemutatót PDF-be a kiválasztott elrendezéssel.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Vegye figyelembe, hogy a `set_SlidesLayoutOptions` metódus csak bizonyos kimeneti formátumok esetén érhető el, mint például a PDF, HTML, TIFF, illetve képként történő renderelésnél.
{{% /alert %}} 

## **GYIK**

**Mi a maximális diakép szám oldalanként a Handout módban?**

Az Aspose.Slides támogatja a [presets](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) legfeljebb 9 diakép oldalanként, vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Létrehozhatok egy egyedi rácsot, például 5 vagy 8 diát oldalanként?**

Nem. A diaképek számát és elrendezését kizárólag a [HandoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) felsorolás szabályozza; tetszőleges elrendezések nem támogatottak.

**Belefoglalhatom a rejtett diákot a Handout kimenetbe?**

Igen. Használja a `set_ShowHiddenSlides` metódust a célformátum exportbeállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/), vagy a [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/).