---
title: Převod snímků prezentace na obrázky pro Android
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Převod snímků z formátů PPT, PPTX a ODP na obrázky pomocí Aspose.Slides pro Android - rychlé, vysoce kvalitní vykreslování s přehlednými ukázkami kódu v jazyce Java."
---
## **Úvod**

Aspose.Slides pro Android přes Java vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Pro převod snímku na obrázek postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiffoptions/), nebo
    - Rozhraní [IRenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irenderingoptions/).
2. Vygenerujte obrázek snímku voláním metody [getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage--).

V Aspose.Slides pro Android přes Java je [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) rozhraní, které vám umožňuje pracovat s obrázky definovanými pomocí pixelových dat. Toto rozhraní můžete použít k uložení obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Můžete převést snímek na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete snímek převést na bitmapu a poté obrázek uložit ve formátu JPEG nebo v libovolném jiném preferovaném formátu.

Tento kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a poté uložit obrázek ve formátu PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Převést první snímek prezentace na bitmapu.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Uložit obrázek ve formátu PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků na obrázky s vlastními rozměry**

Možná budete potřebovat získat obrázek určité velikosti. Pomocí přetížení metody [getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška).

Tento ukázkový kód demonstruje, jak to provést:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Převést první snímek prezentace na bitmapu s určenou velikostí.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Uložit obrázek ve formátu JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě rozhraní—[ITiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiffoptions/) a [IRenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/irenderingoptions/)—která vám umožňují řídit vykreslování snímků prezentace do obrázků. Obě rozhraní obsahují metodu `setSlidesLayoutOptions`, která vám umožní konfigurovat vykreslení poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/) můžete určit preferovanou polohu poznámek a komentářů ve výsledném obrázku.

Tento kód ukazuje, jak převést snímek s poznámkami a komentáři:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Načíst soubor prezentace.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Nastavit polohu poznámek.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Nastavit polohu komentářů.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Nastavit šířku oblasti komentářů.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Nastavit barvu oblasti komentářů.

    // Vytvořit možnosti vykreslení.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Převést první snímek prezentace na obrázek.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Uložit obrázek ve formátu GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
V jakémkoli procesu převodu snímku na obrázek metoda [setNotesPosition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) nemůže použít `BottomFull` (pro specifikaci pozice poznámek), protože text poznámky může být příliš velký a není schopen se vejít do určené velikosti obrázku.
{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že vám umožňuje specifikovat parametry jako velikost, rozlišení, barevná paleta a další.

Tento kód demonstruje proces převodu, kde jsou použity TIFF možnosti k vytvoření černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```java 
// Načíst soubor prezentace.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Získat první snímek z prezentace.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Nastavit parametry výstupního TIFF obrázku.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Nastavit velikost obrázku.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Nastavit formát pixelů (černobílý).
    tiffOptions.setDpiX(300);                                        // Nastavit horizontální rozlišení.
    tiffOptions.setDpiY(300);                                        // Nastavit vertikální rozlišení.

    // Převést snímek na obrázek s určenými možnostmi.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Uložit obrázek ve formátu TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž efektivně převedete celou prezentaci na sérii obrázků.

Tento ukázkový kód ukazuje, jak v Javě převést všechny snímky v prezentaci na obrázky:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Vykreslit prezentaci do obrázků snímek po snímku.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Ovládání skrytých snímků (nevykreslovat skryté snímky).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Převést snímek na obrázek.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Uložit obrázek ve formátu JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
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

Ano, skryté snímky mohou být zpracovány stejně jako běžné. Stačí zajistit, aby byly zahrnuty do smyčky zpracování.

**Lze obrázky uložit se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázků.