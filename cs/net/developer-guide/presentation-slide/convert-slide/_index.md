---
title: Převod snímků prezentace na obrázky v .NET
linktitle: Snímek na obrázek
type: docs
weight: 41
url: /cs/net/convert-slide/
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
- .NET
- C#
- Aspose.Slides
description: "Převod snímků z PPT, PPTX a ODP na obrázky v C# pomocí Aspose.Slides pro .NET—rychlé, vysoce kvalitní renderování s přehlednými ukázkami kódu."
---
## **Úvod**

Aspose.Slides pro .NET vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Pro převod snímku do obrázku postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat, pomocí:
    - Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/) , nebo
    - Rozhraní [IRenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/irenderingoptions/).
2. Vygenerujte obrázek snímku voláním metody [GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/).

V .NET je [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) objekt, který vám umožňuje pracovat s obrázky definovanými pomocí pixelových dat. Můžete použít instanci této třídy k uložení obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Můžete převést snímek na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete převést snímek na bitmapu a poté uložit obrázek ve formátu JPEG nebo v jiném preferovaném formátu.

Tento C# kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a poté uložit obrázek ve formátu PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Převést první snímek v prezentaci na bitmapu.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Uložit obrázek ve formátu PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Převod snímků na obrázky s vlastními rozměry**

Možná budete potřebovat získat obrázek určité velikosti. Pomocí přetížení metody [GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/), můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška).

Tento ukázkový kód ukazuje, jak to provést:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Převést první snímek v prezentaci na bitmapu se zadanou velikostí.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Uložit obrázek ve formátu JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě rozhraní — [ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/) a [IRenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/irenderingoptions/) — která vám umožňují řídit vykreslování snímků prezentace do obrázků. Obě rozhraní obsahují vlastnost `SlidesLayoutOptions`, která vám umožní konfigurovat vykreslování poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) můžete určit preferovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento C# kód ukazuje, jak převést snímek s poznámkami a komentáři:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Načíst soubor prezentace.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Vytvořit možnosti vykreslování.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Nastavit pozici poznámek.
            CommentsPosition = CommentsPositions.Right,      // Nastavit pozici komentářů.
            CommentsAreaWidth = 500,                         // Nastavit šířku oblasti komentářů.
            CommentsAreaColor = Color.AntiqueWhite           // Nastavit barvu oblasti komentářů.
        }
    };

    // Převést první snímek prezentace na obrázek.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Uložit obrázek ve formátu GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
V jakémkoli procesu převodu snímku na obrázek nelze vlastnost [NotesPosition](https://reference.aspose.com/slides/cs/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) nastavit na `BottomFull` (pro určení pozice poznámek), protože text poznámky může být příliš velký a nemusí se vejít do zadané velikosti obrázku.
{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Rozhraní [ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že vám umožňuje specifikovat parametry jako velikost, rozlišení, barevná paleta a další.

Tento C# kód ukazuje proces převodu, kde jsou použity TIFF možnosti k vytvoření černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```cs
// Načíst soubor prezentace.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Získat první snímek z prezentace.
    ISlide slide = presentation.Slides[0];

    // Nastavit nastavení výstupního TIFF obrázku.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Nastavit velikost obrázku.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Nastavit formát pixelů (černobílý).
        DpiX = 300,                                        // Nastavit horizontální rozlišení.
        DpiY = 300                                         // Nastavit vertikální rozlišení.
    };

    // Převést snímek na obrázek s určenými možnostmi.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Uložit obrázek ve formátu TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž efektivně převedete celou prezentaci na sérii obrázků.

Tento ukázkový kód ukazuje, jak v C# převést všechny snímky v prezentaci na obrázky:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Vykreslit prezentaci do obrázků snímek po snímku.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Ovládání skrytých snímků (nevykreslovat skryté snímky).
        if (presentation.Slides[i].Hidden)
            continue;

        // Převést snímek na obrázek.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Uložit obrázek ve formátu JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Často kladené otázky**

**1. Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda `GetImage` ukládá pouze statický obrázek snímku, bez animací.

**2. Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky lze zpracovat stejně jako běžné. Stačí zajistit, aby byly zahrnuty do smyčky zpracování.

**3. Lze obrázky uložit se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázky.