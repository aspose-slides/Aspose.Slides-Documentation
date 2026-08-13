---
title: Převod prezentací PowerPoint do TIFF s poznámkami v .NET
linktitle: PowerPoint do TIFF s poznámkami
type: docs
weight: 100
url: /cs/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do TIFF
- prezentace do TIFF
- snímek do TIFF
- PPT do TIFF
- PPTX do TIFF
- uložit PPT jako TIFF
- uložit PPTX jako TIFF
- exportovat PPT do TIFF
- exportovat PPTX do TIFF
- PowerPoint s poznámkami
- prezentace s poznámkami
- snímek s poznámkami
- PPT s poznámkami
- PPTX s poznámkami
- TIFF s poznámkami
- .NET
- C#
- Aspose.Slides
description: "Převod prezentací PowerPoint do TIFF s poznámkami pomocí Aspose.Slides pro .NET. Naučte se efektivně exportovat snímky s poznámkami přednášejícího."
---
## **Úvod**

Aspose.Slides for .NET poskytuje jednoduché řešení pro převod prezentací PowerPoint a OpenDocument (PPT, PPTX a ODP) s poznámkami do formátu TIFF. Tento formát je široce používán pro ukládání vysoce kvalitních obrázků, tisk a archivaci dokumentů. S Aspose.Slides můžete nejen exportovat celé prezentace s poznámkami přednášejícího, ale také generovat miniatury snímků v zobrazení Poznámkový snímek. Proces konverze je jednoduchý a efektivní, využívá metodu `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) k transformaci celé prezentace na sérii TIFF obrázků při zachování poznámek a rozložení.

## **Převod prezentace do TIFF s poznámkami**

Uložení prezentace PowerPoint nebo OpenDocument do TIFF s poznámkami pomocí Aspose.Slides for .NET zahrnuje následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/): načtěte soubor PowerPoint nebo OpenDocument.  
2. Nastavte možnosti výstupního rozložení: použijte třídu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) k určení, jak mají být poznámky a komentáře zobrazeny.  
3. Uložte prezentaci do TIFF: předávejte nakonfigurované možnosti metodě [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save/index).

Řekněme, že máme soubor "speaker_notes.pptx" s následujícím snímkem:

![Snímek prezentace s poznámkami přednášejícího](slide_with_notes.png)

Ukázkový kód níže ukazuje, jak převést prezentaci na TIFF obrázek v zobrazení Poznámkový snímek pomocí vlastnosti [SlidesLayoutOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Nakonfigurujte možnosti TIFF s rozvržením poznámek.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Zobrazit poznámky pod snímkem.
        }
    };

    // Uložte prezentaci do TIFF s poznámkami přednášejícího.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Výsledek:

![TIFF obrázek s poznámkami přednášejícího](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Podívejte se na Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

### Můžu ovládat polohu oblasti poznámek ve výsledném TIFF?

Ano. Použijte [notes layout settings](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) a vyberte z možností jako `None`, `BottomTruncated` nebo `BottomFull`, které respektive schovávají poznámky, umisťují je na jednu stránku nebo umožňují jejich pokračování na dalších stránkách.

### Jak mohu snížit velikost souboru TIFF s poznámkami bez viditelné ztráty kvality?

Vyberte [efficient compression](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/compressiontype/) (např. `LZW` nebo `RLE`), nastavte rozumné DPI a pokud je to přijatelné, použijte nižší [pixel format](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/pixelformat/) (např. 8 bpp nebo 1 bpp pro černobílý). Mírné snížení [image dimensions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/imagesize/) může také pomoci, aniž by významně zhoršilo čitelnost.

### Ovlivňuje písmo v poznámkách výsledek, pokud původní písma chybí v systému?

Ano. Chybějící fonty spustí [náhradu](/slides/cs/net/font-selection-sequence/), což může změnit metriky textu a vzhled. Aby se tomu předešlo, [poskytněte požadované fonty](/slides/cs/net/custom-font/) nebo nastavte výchozí [náhradní font](/slides/cs/net/fallback-font/), aby byly použity požadované typy písma.