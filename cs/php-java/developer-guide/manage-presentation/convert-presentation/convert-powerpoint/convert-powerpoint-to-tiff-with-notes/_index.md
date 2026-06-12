---
title: Převod prezentací PowerPoint do TIFF s poznámkami v PHP
linktitle: PowerPoint do TIFF s poznámkami
type: docs
weight: 100
url: /cs/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "Převod prezentací PowerPoint do TIFF s poznámkami pomocí Aspose.Slides for PHP via Java. Naučte se efektivně exportovat snímky s poznámkami přednášejícího."
---
## **Úvod**

Aspose.Slides for PHP via Java poskytuje jednoduché řešení pro převod prezentací PowerPoint a OpenDocument (PPT, PPTX a ODP) s poznámkami do formátu TIFF. Tento formát se široce používá pro ukládání vysoce kvalitních obrázků, tisk a archivaci dokumentů. S Aspose.Slides můžete nejen exportovat celé prezentace s poznámkami přednášejícího, ale také generovat miniatury snímků v zobrazení Notes Slide. Proces konverze je jednoduchý a efektivní, využívá metodu `save` třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) k transformaci celé prezentace na sérii TIFF obrázků při zachování poznámek a rozvržení.

## **Převod prezentace do TIFF s poznámkami**

Ukládání prezentace PowerPoint nebo OpenDocument do TIFF s poznámkami pomocí Aspose.Slides for PHP via Java zahrnuje následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/): Načtěte soubor PowerPoint nebo OpenDocument.
1. Nakonfigurujte možnosti výstupního rozvržení: Použijte třídu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/notescommentslayoutingoptions/) k určení, jak mají být poznámky a komentáře zobrazeny.
1. Uložte prezentaci do TIFF: Předávejte nakonfigurované možnosti metodě [save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save).

Řekněme, že máme soubor "speaker_notes.pptx" s následujícím snímkem:

![Snímek prezentace s poznámkami přednášejícího](slide_with_notes.png)

Níže uvedený úryvek kódu ukazuje, jak převést prezentaci na TIFF obrázek v zobrazení Notes Slide pomocí metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Zobrazí poznámky pod snímkem.

    // Nakonfigurujte možnosti TIFF s rozvržením poznámek.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Uložte prezentaci do TIFF s poznámkami přednášejícího.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![TIFF obrázek s poznámkami přednášejícího](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Vyzkoušejte Aspose [Bezplatný převodník PowerPoint na plakát](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

**Mohu řídit polohu oblasti poznámek ve výsledném TIFF?**

Ano. Použijte [nastavení rozvržení poznámek](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) a vyberte mezi možnostmi jako `None`, `BottomTruncated` nebo `BottomFull`, které respektive skryjí poznámky, umístí je na jednu stránku, nebo umožní jejich rozložení na další stránky.

**Jak mohu snížit velikost souboru TIFF s poznámkami bez viditelné ztráty kvality?**

Zvolte [efektivní kompresi](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/setcompressiontype/) (např. `LZW` nebo `RLE`), nastavte rozumné DPI a pokud je to přijatelné, použijte nižší [formát pixelů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/setpixelformat/) (například 8 bpp nebo 1 bpp pro monochromatické). Mírné zmenšení [rozměrů obrázku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tiffoptions/setimagesize/) může také pomoci, aniž by to výrazně snížilo čitelnost.

**Ovlivňuje písmo v poznámkách výsledek, pokud chybí původní písma v systému?**

Ano. Chybějící písma spustí [substituci](/slides/cs/php-java/font-selection-sequence/), což může změnit metriky textu a vzhled. Aby se tomu předešlo, [poskytněte požadovaná písma](/slides/cs/php-java/custom-font/) nebo nastavte výchozí [náhradní písmo](/slides/cs/php-java/fallback-font/), aby byla použita zamýšlená písma.