---
title: Převod prezentací PowerPoint do TIFF s poznámkami v C++
linktitle: PowerPoint do TIFF s poznámkami
type: docs
weight: 100
url: /cs/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Převod prezentací PowerPoint do TIFF s poznámkami pomocí Aspose.Slides pro C++. Naučte se efektivně exportovat snímky s poznámkami řečníka."
---
## **Úvod**

Aspose.Slides for C++ poskytuje jednoduché řešení pro převod prezentací PowerPoint a OpenDocument (PPT, PPTX a ODP) s poznámkami do formátu TIFF. Tento formát se široce používá pro vysoce kvalitní ukládání obrázků, tisk a archivaci dokumentů. S Aspose.Slides můžete nejen exportovat celé prezentace s poznámkami řečníka, ale také generovat miniatury snímků v zobrazení Poznámky snímku. Proces konverze je jednoduchý a efektivní, využívá metodu `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) k převodu celé prezentace na sérii TIFF obrázků při zachování poznámek a rozvržení.

## **Převod prezentace do TIFF s poznámkami**

Uložení prezentace PowerPoint nebo OpenDocument do TIFF s poznámkami pomocí Aspose.Slides for C++ zahrnuje následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/): načtěte soubor PowerPoint nebo OpenDocument.  
1. Nakonfigurujte možnosti výstupního rozvržení: použijte třídu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) k určení, jak mají být poznámky a komentáře zobrazeny.  
1. Uložte prezentaci do TIFF: předaďte nakonfigurované možnosti metodě [Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/).

Předpokládejme, že máme soubor "speaker_notes.pptx" s následujícím snímkem:

![The presentation slide with speaker notes](slide_with_notes.png)

Ukázka kódu níže ukazuje, jak převést prezentaci na TIFF obrázek v zobrazení Poznámky snímku pomocí metody [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Zobrazí poznámky pod snímkem.

// Nakonfigurujte možnosti TIFF s rozvržením poznámek.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci do TIFF s poznámkami řečníka.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Výsledek:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Vyzkoušejte Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Často kladené otázky**

**Mohu řídit polohu oblasti poznámek v výsledném TIFF?**

Ano. Použijte [nastavení rozvržení poznámek](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) a vyberte mezi možnostmi jako `None`, `BottomTruncated` nebo `BottomFull`, které respektive skryjí poznámky, vejdou je na jednu stránku nebo jim umožní přetéct na další stránky.

**Jak mohu snížit velikost souboru TIFF s poznámkami bez viditelné ztráty kvality?**

Zvolte [efektivní kompresi](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (např. `LZW` nebo `RLE`), nastavte rozumnou DPI a pokud je to přijatelné, použijte nižší [formát pixelů](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (např. 8 bpp nebo 1 bpp pro monochromní). Mírné zmenšení [rozměrů obrázku](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_imagesize/) může také pomoci, aniž by výrazně snížilo čitelnost.

**Ovlivňuje písmo v poznámkách výsledek, pokud chybí původní písma v systému?**

Ano. Chybějící písma spouštějí [substituci](/slides/cs/cpp/font-selection-sequence/), což může změnit metriky textu a vzhled. Pro zamezení toho [poskytněte požadovaná písma](/slides/cs/cpp/custom-font/) nebo nastavte výchozí [náhradní písmo](/slides/cs/cpp/fallback-font/), aby byla použita zamýšlená písma.