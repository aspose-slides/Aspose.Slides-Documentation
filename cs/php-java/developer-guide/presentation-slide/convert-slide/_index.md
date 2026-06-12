---
title: Převod snímků prezentace na obrázky v PHP
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/php-java/convert-slide/
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
- PHP
- Aspose.Slides
description: "Převod snímků z formátů PPT, PPTX a ODP na obrázky pomocí Aspose.Slides for PHP via Java — rychlé, vysoce kvalitní vykreslování s přehlednými ukázkami kódu."
---
## **Úvod**

Aspose.Slides for PHP via Java vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Chcete-li převést snímek na obrázek, postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - Třídy [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) nebo
    - Třídy [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/).
2. Vytvořte obrázek snímku voláním metody [getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage).

V Aspose.Slides for PHP via Java je [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) třída, která umožňuje pracovat s obrázky definovanými pixelovými daty. Tuto třídu můžete použít k ukládání obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Můžete převést snímek na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete snímek převést na bitmapu a poté uložit obrázek ve formátu JPEG nebo jakémkoli jiném preferovaném formátu.

Tento kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a následně uložit obrázek ve formátu PNG:

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

## **Převod snímků na obrázky s vlastními rozměry**

Možná budete potřebovat obrázek o určité velikosti. Pomocí přetížené verze metody [getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) můžete převést snímek na obrázek se specifickými rozměry (šířka a výška).

Tento ukázkový kód ukazuje, jak to provést:

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

Aspose.Slides poskytuje dvě třídy [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) a [RenderingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/renderingoptions/), které umožňují řídit vykreslování snímků prezentace do obrázků. Obě třídy obsahují metodu `setSlidesLayoutOptions`, která vám umožní nakonfigurovat vykreslování poznámek a komentářů na snímku při jeho převodu na obrázek.

Pomocí třídy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) můžete určit požadovanou pozici poznámek a komentářů ve výsledném obrázku.

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
V jakémkoli procesu převodu snímku na obrázek metoda [setNotesPosition](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) nemůže použít `BottomFull` (pro určení pozice poznámek), protože text poznámky může být příliš dlouhý a nevejde se do určené velikosti obrázku.
{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že umožňuje specifikovat parametry jako velikost, rozlišení, barevná paleta a další.

Tento kód ukazuje proces převodu, kde jsou použity TIFF možnosti k vytvoření černobílého obrázku s rozlišením 300 DPI a velikostí 2160 x 2800:

```php
// Načíst soubor prezentace.
$presentation = new Presentation("sample.pptx");
try {
    // Získat první snímek z prezentace.
    $slide = $presentation->getSlides()->get_Item(0);

    // Nastavit konfiguraci výstupního TIFF obrázku.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Nastavit velikost obrázku.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Nastavit formát pixelů (černobílý).
    $options->setDpiX(300);                                              // Nastavit horizontální rozlišení.
    $options->setDpiY(300);                                              // Nastavit vertikální rozlišení.
    
    // Převést snímek na obrázek s určenými možnostmi.
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
Podpora TIFF není zaručena ve verzích starších než JDK 9.
{{% /alert %}} 

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž prakticky převede celou prezentaci na sérii obrázků.

Tento ukázkový kód ukazuje, jak v PHP převést všechny snímky v prezentaci na obrázky:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Vykreslit prezentaci do obrázků snímek po snímku.
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

## **FAQ**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**  
Ne, metoda `getImage` uloží pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**  
Ano, skryté snímky lze zpracovat stejně jako běžné. Jen se ujistěte, že jsou zahrnuty ve smyčce zpracování.

**Lze obrázky uložit se stíny a efekty?**  
Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázků.