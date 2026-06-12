---
title: Převod snímků prezentace na obrázky v JavaScriptu
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převádějte snímky z PPT, PPTX a ODP na obrázky v JavaScriptu pomocí Aspose.Slides pro Node.js přes Java — rychlé, vysoce kvalitní vykreslování s přehlednými příklady kódu."
---
## **Úvod**

Aspose.Slides pro Node.js přes Java vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Pro převod snímku na obrázek postupujte podle následujících kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - Třídy [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) nebo
    - Třídy [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/) .
2. Vygenerujte obrázek snímku voláním metody [getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) .

V Aspose.Slides pro Node.js přes Java je [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) třída, která vám umožňuje pracovat s obrázky definovanými pomocí pixelových dat. Touto třídou můžete ukládat obrázky v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapu a uložení obrázků v PNG**

Můžete převést snímek na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete převést snímek na bitmapu a následně uložit obrázek ve formátu JPEG nebo jakémkoli jiném preferovaném formátu.

Tento JavaScriptový kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a poté uložit obrázek ve formátu PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Převést první snímek v prezentaci na bitmapu.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Uložit obrázek ve formátu PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků na obrázky s vlastními rozměry**

Možná budete potřebovat získat obrázek určité velikosti. Pomocí přetížení metody [getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška).

Tento ukázkový kód demonstruje, jak to provést:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Převést první snímek v prezentaci na bitmapu s určenou velikostí.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Uložit obrázek ve formátu JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě třídy - [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) a [RenderingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/renderingoptions/) - které vám umožňují kontrolovat vykreslování snímků prezentace do obrázků. Obě třídy obsahují metodu `setSlidesLayoutOptions`, která vám umožňuje nastavit vykreslování poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) můžete specifikovat požadovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento JavaScriptový kód ukazuje, jak převést snímek s poznámkami a komentáři:

```js
const scaleX = 2;
const scaleY = scaleX;

// Načíst soubor prezentace.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Nastavit polohu poznámek.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Nastavit polohu komentářů.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Nastavit šířku oblasti komentářů.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Nastavit barvu oblasti komentářů.

    // Vytvořit nastavení vykreslování.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Převést první snímek prezentace na obrázek.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Uložit obrázek ve formátu GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
V jakémkoli procesu převodu snímku na obrázek metoda [setNotesPosition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) nemůže použít `BottomFull` (pro určení pozice poznámek), protože text poznámky může být příliš velký a nepřesahuje určenou velikost obrázku.
{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Třída [TiffOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že umožňuje specifikovat parametry jako velikost, rozlišení, barevnou paletu a další.

Tento JavaScriptový kód ukazuje proces konverze, kde jsou použity TIFF možnosti k vytvoření černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```js
// Načíst soubor prezentace.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Získat první snímek z prezentace.
    let slide = presentation.getSlides().get_Item(0);

    // Nastavit konfiguraci výstupního TIFF obrazu.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Nastavit velikost obrázku.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Nastavit formát pixelů (černobílý).
    tiffOptions.setDpiX(300);                                                          // Nastavit horizontální rozlišení.
    tiffOptions.setDpiY(300);                                                          // Nastavit vertikální rozlišení.

    // Převést snímek na obrázek s určenými možnostmi.
    let image = slide.getImage(tiffOptions);
    try {
        // Uložit obrázek ve formátu TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Podpora TIFF není zaručena ve verzích starších než JDK 9.
{{% /alert %}} 

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž efektivně převádí celou prezentaci na sérii obrázků.

Tento ukázkový kód demonstruje, jak převést všechny snímky v prezentaci na obrázky v JavaScriptu:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vykreslit prezentaci na obrázky snímek po snímku.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Ovládání skrytých snímků (nevykreslovat skryté snímky).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Převést snímek na obrázek.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Uložit obrázek ve formátu JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda `getImage` ukládá pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky lze zpracovat stejně jako běžné. Jen se ujistěte, že jsou zahrnuty ve smyčce zpracování.

**Lze obrázky ukládat se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázky.