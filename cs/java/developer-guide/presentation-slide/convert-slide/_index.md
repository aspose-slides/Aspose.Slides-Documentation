---
title: Převod snímků prezentace na obrázky v Javě
linktitle: Snímek na obrázek
type: docs
weight: 35
url: /cs/java/convert-slide/
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
- Java
- Aspose.Slides
description: "Převod snímků z PPT, PPTX a ODP na obrázky v Javě pomocí Aspose.Slides — rychlé, vysoce kvalitní vykreslování s přehlednými příklady kódu."
---
## **Úvod**

Aspose.Slides pro Java vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Chcete-li převést snímek na obrázek, postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiffoptions/) nebo
    - rozhraní [IRenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irenderingoptions/) .
2. Vygenerujte obrázek snímku zavoláním metody [getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-).

V Aspose.Slides pro Java je [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) rozhraní, které vám umožňuje pracovat s obrázky definovanými pixelovými daty. Toto rozhraní můžete použít k uložení obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Můžete převést snímek na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete převést snímek na bitmapu a následně uložit obrázek ve formátu JPEG nebo jakémkoli jiném preferovaném formátu.

Tento kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a následně uložit obrázek ve formátu PNG:

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

## **Převod snímků na obrázky s vlastní velikostí**

Možná budete potřebovat obrázek určité velikosti. Pomocí přetížení metody [getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), můžete převést snímek na obrázek se specifickými rozměry (šířka a výška).

Ukázkový kód demonstruje, jak to provést:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Převést první snímek prezentace na bitmapu se zadanou velikostí.
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

Aspose.Slides poskytuje dvě rozhraní — [ITiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiffoptions/) a [IRenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/irenderingoptions/) — která vám umožňují řídit vykreslování snímků prezentace do obrázků. Obě rozhraní zahrnují metodu `setSlidesLayoutOptions`, která vám umožňuje nastavit vykreslení poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/) můžete určit preferovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento kód ukazuje, jak převést snímek s poznámkami a komentáři:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Načíst soubor prezentace.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Nastavit pozici poznámek.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Nastavit pozici komentářů.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Nastavit šířku oblasti komentářů.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Nastavit barvu oblasti komentářů.

    // Vytvořit možnosti vykreslování.
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
V jakémkoli procesu převodu snímku na obrázek metoda [setNotesPosition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) nemůže použít `BottomFull` (pro určení pozice poznámek), protože text poznámky může být příliš dlouhý a nepamete se do zadané velikosti obrázku.
{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že vám umožňuje specifikovat parametry jako velikost, rozlišení, barevnou paletu a další.

Tento kód ukazuje proces převodu, kde jsou použity TIFF možnosti k vytvoření černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```java 
// Načíst soubor prezentace.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Získat první snímek z prezentace.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Nastavit konfiguraci výstupního TIFF obrázku.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Nastavit velikost obrázku.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Nastavit formát pixelů (černobílé).
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

{{% alert title="Note" color="warning" %}} 
Podpora TIFF není zaručena ve verzích starších než JDK 9.
{{% /alert %}} 

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž efektivně převede celou prezentaci na sérii obrázků.

Ukázkový kód demonstruje, jak v Javě převést všechny snímky v prezentaci na obrázky:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Vykreslit prezentaci na obrázky snímek po snímku.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Ovládat skryté snímky (nevykreslovat skryté snímky).
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

## **Barevné vykreslování emoji**

{{% alert title="Note" color="warning" %}} 
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky musí být písmo emoji použité v prezentaci nainstalováno a dostupné na systému, který provádí převod. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji v výstupních obrázcích zobrazovat v černobílé.
{{% /alert %}}

## **Časté dotazy**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda `getImage` ukládá pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky lze zpracovat stejně jako běžné. Jen se ujistěte, že jsou zahrnuty ve smyčce zpracování.

**Lze obrázky uložit se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázků.