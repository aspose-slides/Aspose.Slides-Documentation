---
title: Převod snímků prezentace na obrázky v PHP
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/php-java/convert-slide/
keywords:
- převod snímku
- export snímku
- snímek na obrázek
- uložit snímek jako obrázek
- snímek na PNG
- snímek na JPEG
- snímek na bitmapu
- snímek na TIFF
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Převod snímků z formátů PPT, PPTX a ODP na obrázky pomocí Aspose.Slides pro PHP přes Java — rychlé, vysoce kvalitní vykreslování s přehlednými ukázkami kódu."
---
## **Úvod**

Aspose.Slides pro PHP přes Java vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých obrazových formátů, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Pro převod snímku na obrázek postupujte následovně:

1. Definujte požadované nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - Třídy [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/), nebo
    - Třídy [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/).
2. Vygenerujte obrázek snímku voláním metody [getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage).

V Aspose.Slides pro PHP přes Java je [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) třída, která vám umožňuje pracovat s obrázky definovanými pixelovými daty. Tuto třídu můžete použít k ukládání obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Můžete převést snímek na bitmapový objekt a použít jej přímo ve své aplikaci. Alternativně můžete snímek převést na bitmapu a poté obrázek uložit ve formátu JPEG nebo jiném preferovaném formátu.

Tento kód ukazuje, jak převést první snímek prezentace na bitmapový objekt a následně uložit obrázek ve formátu PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Převést první snímek v prezentaci na bitmapu.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Uložit obrázek ve formátu PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Převod snímků na obrázky s vlastní velikostí**

Možná budete potřebovat získat obrázek určité velikosti. Pomocí přetížení metody [getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška).

Tento ukázkový kód demonstruje, jak to provést:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Převést první snímek v prezentaci na bitmapu s určenou velikostí.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Uložit obrázek ve formátu JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě třídy[TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) a [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/)—které vám umožňují řídit vykreslování snímků prezentace do obrázků. Obě třídy obsahují metodu `setSlidesLayoutOptions`, která vám umožní konfigurovat vykreslení poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) můžete určit preferovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento kód ukazuje, jak převést snímek s poznámkami a komentáři:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Nastavit pozici poznámek.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Nastavit pozici komentářů.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Nastavit šířku oblasti komentářů.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Nastavit barvu oblasti komentářů.

    // Vytvořit možnosti vykreslování.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Převést první snímek prezentace na obrázek.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Uložit obrázek ve formátu GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
V jakémkoli procesu převodu snímku na obrázek metoda [setNotesPosition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) nemůže použít `BottomFull` (pro určení pozice poznámek), protože text poznámky může být příliš velký a nepřesahuje určenou velikost obrázku.
{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že umožňuje zadat parametry jako velikost, rozlišení, barevnou paletu a další.

Tento kód ukazuje proces převodu, kde jsou použity TIFF možnosti k vyprodukování černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```php
// Načíst soubor prezentace.
$presentation = new Presentation("sample.pptx");
try {
    // Získat první snímek z prezentace.
    $slide = $presentation->getSlides()->get_Item(0);

    // Nastavit konfiguraci výstupního TIFF obrázku.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Nastavit velikost obrázku.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Nastavit pixelový formát (černobílý).
    $options->setDpiX(300);                                              // Nastavit horizontální rozlišení.
    $options->setDpiY(300);                                              // Nastavit vertikální rozlišení.
    
    // Převést snímek na obrázek s uvedenými možnostmi.
    $image = $slide->getImage($options);
    try {
        // Uložit obrázek ve formátu TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Podpora formátu Tiff není zaručena ve verzích starších než JDK 9.
{{% /alert %}} 

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž efektivně převede celou prezentaci na sérii obrázků.

Tento ukázkový kód ukazuje, jak převést všechny snímky v prezentaci na obrázky v PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Vykreslit prezentaci na obrázky snímek po snímku.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Ovládání skrytých snímků (nevykreslovat skryté snímky).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Převést snímek na obrázek.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Uložit obrázek ve formátu JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Vykreslování barevných emoji**

{{% alert title="Note" color="warning" %}} 
Aby byly při převodu snímků prezentace na obrázky správně vykresleny barevné emoji, musí být písma emoji použité v prezentaci nainstalována a dostupná na systému provádějícím převod. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji ve výstupních obrázcích zobrazit v černobílém provedení.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda `getImage` ukládá pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky lze zpracovat stejně jako běžné. Jen se ujistěte, že jsou zahrnuty ve smyčce zpracování.

**Lze obrázky ukládat se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázků.