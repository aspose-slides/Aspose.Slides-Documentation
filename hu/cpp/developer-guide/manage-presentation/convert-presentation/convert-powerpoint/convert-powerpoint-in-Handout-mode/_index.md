---
title: PowerPoint prezentációk konvertálása Handout módban C++ használatával
linktitle: Handout mód
type: docs
weight: 150
url: /hu/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- handout mód
- handout
- PPT
- PPTX
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Konvertálja a prezentációkat handout-okká C++-ban. Állítsa be az oldalon megjelenítendő diák számát, tartsa meg a jegyzeteket, exportáljon PDF-be vagy képekbe az Aspose.Slides segítségével, mintakóddal. Próbálja ki ingyen."
---
## **Bevezetés**

Aspose.Slides lehetővé teszi prezentációk különböző formátumokba történő konvertálását, beleértve a segédlet készítését nyomtatáshoz Handout módban. Ez a mód lehetővé teszi, hogy beállítsa, hogyan jelenjenek meg több dia egy oldalon, ami hasznos konferenciákon, szemináriumokon és egyéb eseményeken. A mód engedélyezhető a `set_SlidesLayoutOptions` metódus beállításával az [IPdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/ihtmloptions/) és [ITiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/itiffoptions/) interfészekben.

## **Handout mód exportálása**

A Handout mód beállításához használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handoutlayoutingoptions/) objektumot, amely meghatározza, hány dia kerül egy oldalra, valamint egyéb megjelenítési paramétereket.

Az alábbiakban egy kódrészlet látható, amely bemutatja, hogyan konvertáljon egy prezentációt PDF formátumba Handout módban.

```cpp
// Prezentáció betöltése.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Exportálási beállítások meghatározása.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 dia egy oldalon vízszintesen
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // dia számok nyomtatása
slidesLayoutOptions->set_PrintFrameSlide(true);                      // keret nyomtatása a diák köré
slidesLayoutOptions->set_PrintComments(false);                       // nincs megjegyzés

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Prezentáció exportálása PDF-be a kiválasztott elrendezéssel.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Ne feledje, hogy a `set_SlidesLayoutOptions` metódus csak bizonyos kimeneti formátumoknál érhető el, például PDF, HTML, TIFF, illetve képként történő renderelés esetén.
{{% /alert %}} 

## **GYIK**

**Mi a maximális dia bélyegkép száma oldalanként Handout módban?**

Az Aspose.Slides [előbeállításokat](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) támogat, amelyek legfeljebb 9 bélyegképet tesznek lehetővé oldalanként vízszintes vagy függőleges elrendezéssel: 1, 2, 3, 4 (vízszintes/függőleges), 6 (vízszintes/függőleges) és 9 (vízszintes/függőleges).

**Definiálhatok egy egyéni rácsot, például 5 vagy 8 dia oldalanként?**

Nem. A bélyegképek száma és elrendezése szigorúan a [HandoutType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) felsorolás által van szabályozva; tetszőleges elrendezések nem támogatottak.

**Tartalmazhatok rejtett diákat a Handout kimenetben?**

Igen. Használja a `set_ShowHiddenSlides` metódust a célformátum exportbeállításaiban, például a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/htmloptions/) vagy [TiffOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/tiffoptions/) esetén.