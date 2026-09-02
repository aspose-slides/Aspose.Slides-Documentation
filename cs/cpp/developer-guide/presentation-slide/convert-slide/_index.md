---
title: Převod snímků prezentace na obrázky v C++
linktitle: Snímek na obrázek
type: docs
weight: 41
url: /cs/cpp/convert-slide/
keywords:
- převést snímek
- exportovat snímek
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Převod snímků z PPT, PPTX a ODP na obrázky v C++ pomocí Aspose.Slides — rychlé, vysoce kvalitní vykreslování s jasnými ukázkami kódu."
---
## **Úvod**

Aspose.Slides for C++ vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Pro převod snímku na obrázek postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/itiffoptions/), nebo
    - Rozhraní [IRenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/irenderingoptions/).
2. Vygenerujte obrázek snímku voláním metody [GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/).

Třída [Bitmap](https://reference.aspose.com/slides/cs/cpp/system.drawing/bitmap/) je objekt, který vám umožňuje pracovat s obrázky definovanými pomocí pixelových dat. Můžete použít instanci této třídy k ukládání obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Můžete převést snímek na bitmapový objekt a použít jej přímo ve své aplikaci. Případně můžete převést snímek na bitmapu a následně uložit obrázek ve formátu JPEG nebo jakémkoli jiném preferovaném formátu.

Tento C++ kód ukazuje, jak převést první snímek prezentace na bitmapový objekt a poté uložit obrázek ve formátu PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Převést první snímek v prezentaci na bitmapu.
auto image = presentation->get_Slide(0)->GetImage();

// Uložit obrázek ve formátu PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Převod snímků na obrázky s vlastními rozměry**

Možná budete potřebovat obrázek určité velikosti. Pomocí přetížení metody [GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/getimage/) můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška).

Tento ukázkový kód demonstruje, jak to provést:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Převést první snímek v prezentaci na bitmapu se zadanou velikostí.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Uložit obrázek ve formátu JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě rozhraní — [ITiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/itiffoptions/) a [IRenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/irenderingoptions/) — která vám umožňují řídit vykreslování snímků prezentace do obrázků. Obě rozhraní obsahují metodu `set_SlidesLayoutOptions`, která umožňuje nastavit vykreslování poznámek a komentářů na snímku při jeho převodu na obrázek.

Pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) můžete určit preferovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento C++ kód demonstruje, jak převést snímek s poznámkami a komentáři:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Načíst soubor prezentace.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Nastavit pozici poznámek.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Nastavit pozici komentářů.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Nastavit šířku oblasti komentářů.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Nastavit barvu oblasti komentářů.

// Vytvořit možnosti vykreslování.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Převést první snímek prezentace na obrázek.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Uložit obrázek ve formátu GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

V jakémkoli procesu převodu snímku na obrázek metoda [set_NotesPosition](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) nemůže použít hodnotu BottomFull (pro určení pozice poznámek), protože text poznámky může být příliš velký a nevejde se do zadané velikosti obrázku.

{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/itiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že vám umožňuje zadat parametry, jako je velikost, rozlišení, barevná paleta a další.

Tento C++ kód demonstruje proces převodu, kde jsou použity TIFF možnosti k vytvoření černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```cpp 
// Načíst soubor prezentace.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Získat první snímek z prezentace.
auto slide = presentation->get_Slide(0);

// Nastavit parametry výstupního TIFF obrázku.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Nastavit velikost obrázku.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Nastavit formát pixelů (černá a bílá).
tiffOptions->set_DpiX(300);                                         // Nastavit horizontální rozlišení.
tiffOptions->set_DpiY(300);                                         // Nastavit vertikální rozlišení.

// Převést snímek na obrázek s uvedenými možnostmi.
auto image = slide->GetImage(tiffOptions);

// Uložit obrázek ve formátu TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž efektivně převádí celou prezentaci na sérii obrázků.

Tento ukázkový kód demonstruje, jak převést všechny snímky v prezentaci na obrázky v C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Vykreslit prezentaci na obrázky snímek po snímku.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Ovládání skrytých snímků (nevykreslovat skryté snímky).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Převést snímek na obrázek.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Uložit obrázek ve formátu JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Vykreslování barevných emoji**

{{% alert title="Note" color="warning" %}} 
Aby se barevné emoji při převodu snímků prezentace na obrázky vykreslovaly správně, muset být písmo emoji použité v prezentaci nainstalováno a dostupné na systému provádějícím převod. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji ve výstupních obrázcích objevit v černobílém provedení.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda `GetImage` ukládá pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky lze zpracovat stejně jako běžné. Jen se ujistěte, že jsou zahrnuty ve smyčce zpracování.

**Lze obrázky uložit se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázky.