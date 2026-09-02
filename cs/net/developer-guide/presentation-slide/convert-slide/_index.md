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
description: "Převod snímků z PPT, PPTX a ODP na obrázky v C# pomocí Aspose.Slides pro .NET – rychlé, vysoce kvalitní vykreslování s jasnými ukázkami kódu."
---
## **Úvod**

Aspose.Slides pro .NET vám umožňuje snadno převádět snímky prezentací PowerPoint a OpenDocument do různých formátů obrázků, včetně BMP, PNG, JPG (JPEG), GIF a dalších.

Chcete-li převést snímek na obrázek, postupujte podle těchto kroků:

1. Definujte požadovaná nastavení převodu a vyberte snímky, které chcete exportovat pomocí:
    - Rozhraní[ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/), nebo
    - Rozhraní[IRenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/irenderingoptions/).
2. Vygenerujte obrázek snímku voláním metody[GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/).

V .NET je[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) objekt, který vám umožňuje pracovat s obrázky definovanými pomocí pixelových dat. Můžete použít instanci této třídy k uložení obrázků v široké škále formátů (BMP, JPG, PNG atd.).

## **Převod snímků na bitmapy a uložení obrázků ve formátu PNG**

Snímek můžete převést na objekt bitmapy a použít jej přímo ve své aplikaci. Případně můžete snímek převést na bitmapu a poté uložit obrázek ve formátu JPEG nebo jakémkoli jiném preferovaném formátu.

Tento C# kód ukazuje, jak převést první snímek prezentace na objekt bitmapy a následně uložit obrázek ve formátu PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Převede první snímek v prezentaci na bitmapu.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Uloží obrázek ve formátu PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Převod snímků na obrázky s vlastním rozměrem**

Možná budete potřebovat obrázek určité velikosti. Pomocí přetížení metody[GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/) můžete převést snímek na obrázek s konkrétními rozměry (šířka a výška).

Tento ukázkový kód demonstruje, jak to provést:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Převádí první snímek v prezentaci na bitmapu s určenou velikostí.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Uloží obrázek ve formátu JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Převod snímků s poznámkami a komentáři na obrázky**

Některé snímky mohou obsahovat poznámky a komentáře.

Aspose.Slides poskytuje dvě rozhraní—[ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/) a [IRenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/irenderingoptions/)—která vám umožňují kontrolovat vykreslování snímků prezentace do obrázků. Obě rozhraní zahrnují vlastnost`SlidesLayoutOptions`, která vám umožňuje nakonfigurovat vykreslování poznámek a komentářů na snímku při jeho převodu na obrázek.

S třídou[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) můžete specifikovat preferovanou pozici poznámek a komentářů ve výsledném obrázku.

Tento C# kód ukazuje, jak převést snímek s poznámkami a komentáři:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Načte soubor prezentace.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Vytvoří možnosti vykreslování.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Nastaví pozici poznámek.
            CommentsPosition = CommentsPositions.Right,      // Nastaví pozici komentářů.
            CommentsAreaWidth = 500,                         // Nastaví šířku oblasti komentářů.
            CommentsAreaColor = Color.AntiqueWhite           // Nastaví barvu oblasti komentářů.
        }
    };

    // Převádí první snímek prezentace na obrázek.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Uloží obrázek ve formátu GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

V jakémkoli procesu převodu snímku na obrázek nelze vlastnost[NotesPosition](https://reference.aspose.com/slides/cs/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) nastavit na `BottomFull` (pro určení pozice poznámek), protože text poznámky může být příliš velký a nevejde se do zadané velikosti obrázku.

{{% /alert %}} 

## **Převod snímků na obrázky pomocí TIFF možností**

Rozhraní[ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/) poskytuje větší kontrolu nad výsledným TIFF obrázkem tím, že umožňuje specifikovat parametry jako velikost, rozlišení, barevnou paletu a další.

Tento C# kód ukazuje proces převodu, kde jsou TIFF možnosti použity k výstupu černobílého obrázku s rozlišením 300 DPI a velikostí 2160 × 2800:

```cs
// Načte soubor prezentace.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Získá první snímek z prezentace.
    ISlide slide = presentation.Slides[0];

    // Nastaví parametry výstupního TIFF obrázku.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Nastaví velikost obrázku.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Nastaví formát pixelů (černobílý).
        DpiX = 300,                                        // Nastaví horizontální rozlišení.
        DpiY = 300                                         // Nastaví vertikální rozlišení.
    };

    // Převádí snímek na obrázek s danými možnostmi.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Uloží obrázek do formátu TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Převod všech snímků na obrázky**

Aspose.Slides vám umožňuje převést všechny snímky v prezentaci na obrázky, čímž prakticky převedete celou prezentaci na sérii obrázků.

Tento ukázkový kód demonstruje, jak v C# převést všechny snímky v prezentaci na obrázky:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Vykreslí prezentaci na obrázky snímek po snímku.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Ovládá skryté snímky (nerenderuje skryté snímky).
        if (presentation.Slides[i].Hidden)
            continue;

        // Převádí snímek na obrázek.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Uloží obrázek ve formátu JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Vykreslení barevných emoji**

{{% alert title="Note" color="warning" %}} 
Pro správné vykreslení barevných emoji při převodu snímků prezentace na obrázky musí být písma emoji použité v prezentaci nainstalována a dostupná na systému, na kterém se provádí převod. Například pokud prezentace používá **Segoe UI Emoji** a toto písmo chybí, mohou se emoji v výstupních obrázcích zobrazovat monochromaticky.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides vykreslování snímků s animacemi?**

Ne, metoda`GetImage` ukládá pouze statický obrázek snímku, bez animací.

**Lze skryté snímky exportovat jako obrázky?**

Ano, skryté snímky mohou být zpracovány stejně jako běžné. Jen se ujistěte, že jsou zahrnuty ve smyčce zpracování.

**Lze obrázky uložit se stíny a efekty?**

Ano, Aspose.Slides podporuje vykreslování stínů, průhlednosti a dalších grafických efektů při ukládání snímků jako obrázků.