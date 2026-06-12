---
title: Převod prezentací PowerPoint do TIFF s poznámkami v JavaScriptu
linktitle: PowerPoint do TIFF s poznámkami
type: docs
weight: 100
url: /cs/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Převod prezentací PowerPoint do TIFF s poznámkami v JavaScriptu pomocí Aspose.Slides pro Node.js. Naučte se efektivně exportovat snímky s poznámkami přednášejícího."
---
## **Úvod**

Aspose.Slides for Node.js via Java poskytuje jednoduché řešení pro převod prezentací PowerPoint a OpenDocument (PPT, PPTX a ODP) s poznámkami do formátu TIFF. Tento formát je široce používán pro kvalitní ukládání obrázků, tisk a archivaci dokumentů. S Aspose.Slides můžete nejen exportovat celé prezentace s poznámkami přednášejícího, ale také generovat miniatury snímků v zobrazení poznámek k snímkům. Proces převodu je jednoduchý a efektivní, využívá metodu `save` třídy [Prezentace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) k transformaci celé prezentace na sérii TIFF obrázků při zachování poznámek a rozvržení.

## **Převést prezentaci na TIFF s poznámkami**

Uložení prezentace PowerPoint nebo OpenDocument do TIFF s poznámkami pomocí Aspose.Slides for Node.js via Java zahrnuje následující kroky:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/): načtěte soubor PowerPoint nebo OpenDocument.  
1. Nakonfigurujte možnosti výstupního rozvržení: použijte třídu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notescommentslayoutingoptions/) k určení, jak mají být zobrazeny poznámky a komentáře.  
1. Uložte prezentaci do TIFF: předávejte nakonfigurované možnosti metodě [save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#save).

Předpokládejme, že máme soubor "speaker_notes.pptx" s následujícím snímkem:

![Prezentace snímek s poznámkami přednášejícího](slide_with_notes.png)

Níže uvedený útržek kódu ukazuje, jak převést prezentaci na TIFF obrázek v zobrazení poznámek k snímkům pomocí metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Zobrazí poznámky pod snímkem.

    // Nakonfigurujte možnosti TIFF s rozvržením poznámek.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Uložte prezentaci do TIFF s poznámkami přednášejícího.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Výsledek:

![TIFF obrázek s poznámkami přednášejícího](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Prohlédněte si Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Často kladené otázky**

**Mohu ovládat umístění oblasti poznámek v výsledném TIFF?**

Ano. Použijte [nastavení rozvržení poznámek](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) a vyberte mezi možnostmi jako `None`, `BottomTruncated` nebo `BottomFull`, které respektive skryjí poznámky, vejdou je na jednu stránku nebo umožní jejich rozložení na další stránky.

**Jak mohu snížit velikost souboru TIFF s poznámkami bez viditelné ztráty kvality?**

Vyberte [efektivní kompresi](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (např. `LZW` nebo `RLE`), nastavte rozumné DPI a pokud je to přijatelné, použijte nižší [formát pixelu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (například 8 bpp nebo 1 bpp pro monochromatické). Mírné snížení [rozměrů obrázku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tiffoptions/setimagesize/) také pomůže, aniž by to výrazně ovlivnilo čitelnost.

**Ovlivní písmo v poznámkách výsledek, pokud v systému chybí původní písma?**

Ano. Chybějící písma spustí [nahrazení](/slides/cs/nodejs-java/font-selection-sequence/), což může změnit metriky textu a vzhled. Abyste tomu předešli, [poskytněte požadovaná písma](/slides/cs/nodejs-java/custom-font/) nebo nastavte výchozí [náhradní písmo](/slides/cs/nodejs-java/fallback-font/), aby byla použita zamýšlená písma.