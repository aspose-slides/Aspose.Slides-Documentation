---
title: Převod prezentací PowerPoint do TIFF s poznámkami v .NET
linktitle: PowerPoint do TIFF s poznámkami
type: docs
weight: 100
url: /cs/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
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
description: "Převod prezentací PowerPoint do TIFF s poznámkami pomocí Aspose.Slides pro .NET. Naučte se efektivně exportovat snímky s řečnickými poznámkami."
---
## **Úvod**

Aspose.Slides for .NET poskytuje jednoduché řešení pro převod prezentací PowerPoint a OpenDocument (PPT, PPTX a ODP) s poznámkami do formátu TIFF. Tento formát je široce používán pro ukládání vysoce kvalitních obrázků, tisk a archivaci dokumentů. S Aspose.Slides můžete nejen exportovat celé prezentace s řečnickými poznámkami, ale také generovat miniatury snímků v zobrazení Poznámkový snímek. Proces konverze je jednoduchý a efektivní, využívá metodu `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) k převodu celé prezentace na sérii TIFF obrázků při zachování poznámek a rozložení.

## **Převod prezentace do TIFF s poznámkami**

Uložení prezentace PowerPoint nebo OpenDocument do TIFF s poznámkami pomocí Aspose.Slides for .NET zahrnuje následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/): načtěte soubor PowerPoint nebo OpenDocument.  
2. Nakonfigurujte možnosti výstupního rozložení: použijte třídu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/notescommentslayoutingoptions/) k určení, jak mají být poznámky a komentáře zobrazeny.  
3. Uložte prezentaci do TIFF: předávejte nakonfigurované možnosti metodě [Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/save/index).

Předpokládejme, že máme soubor „speaker_notes.pptx“ s následujícím snímkem:

![Snímek prezentace s řečnickými poznámkami](slide_with_notes.png)

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Nastavte možnosti TIFF s rozvržením poznámek.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Zobrazí poznámky pod snímkem.
        }
    };

    // Uložte prezentaci do TIFF s řečnickými poznámkami.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Výsledek:

![TIFF obrázek s řečnickými poznámkami](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Vyzkoušejte Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Mohu ovládat pozici oblasti poznámek ve výsledném TIFF?**

Ano. Použijte [notes layout settings](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) a vyberte mezi možnostmi `None`, `BottomTruncated` nebo `BottomFull`, které respektive skryjí poznámky, vejdou je na jednu stránku nebo umožní jejich pokračování na dalších stránkách.

**Jak mohu snížit velikost TIFF souboru s poznámkami bez viditelné ztráty kvality?**

Zvolte [efektivní kompresi](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/compressiontype/) (např. `LZW` nebo `RLE`), nastavte rozumné DPI a – pokud to je přijatelné – použijte nižší [pixel format](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/pixelformat/) (např. 8 bpp nebo 1 bpp pro monochrom). Mírné zmenšení [rozměrů obrázku](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/imagesize/) také pomůže, aniž by to podstatně ovlivnilo čitelnost.

**Ovlivňuje písmo v poznámkách výsledek, pokud chybí původní písma v systému?**

Ano. Chybějící písma spouští [substituci](/slides/cs/net/font-selection-sequence/), což může změnit metriky a vzhled textu. Pro zabránění tomu [poskytněte požadovaná písma](/slides/cs/net/custom-font/) nebo nastavte výchozí [fallback font](/slides/cs/net/fallback-font/), aby byly použity zamýšlené typy písma.