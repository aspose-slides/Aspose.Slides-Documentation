---
title: Převod prezentací PowerPoint do TIFF s poznámkami v C++
linktitle: PowerPoint do TIFF s poznámkami
type: docs
weight: 100
url: /cs/cpp/convert-powerpoint-to-tiff-with-notes/
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
- export PPT do TIFF
- export PPTX do TIFF
- PowerPoint s poznámkami
- prezentace s poznámkami
- snímek s poznámkami
- PPT s poznámkami
- PPTX s poznámkami
- TIFF s poznámkami
- C++
- Aspose.Slides
description: "Převádějte prezentace PowerPoint do TIFF s poznámkami pomocí Aspose.Slides pro C++. Naučte se efektivně exportovat snímky s poznámkami přednášejícího."
---
## **Úvod**

Aspose.Slides for C++ poskytuje jednoduché řešení pro převod prezentací PowerPoint a OpenDocument (PPT, PPTX a ODP) s poznámkami do formátu TIFF. Tento formát se široce používá pro ukládání vysoce kvalitních obrázků, tisk a archivaci dokumentů. S Aspose.Slides můžete nejen exportovat celé prezentace s poznámkami přednášejícího, ale také generovat miniatury snímků v zobrazení poznámek ke snímku. Proces převodu je jednoduchý a efektivní, využívá metodu `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) k transformaci celé prezentace na sérii TIFF obrázků při zachování poznámek a rozvržení.

## **Převod prezentace do TIFF s poznámkami**

Ukládání prezentace PowerPoint nebo OpenDocument do TIFF s poznámkami pomocí Aspose.Slides for C++ zahrnuje následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/): načtěte soubor PowerPoint nebo OpenDocument.
2. Nastavte možnosti výstupního rozvržení: Použijte třídu [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) k určení, jak mají být poznámky a komentáře zobrazeny.
3. Uložte prezentaci do TIFF: Předávejte nastavené možnosti metodě [Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/).

Předpokládejme, že máme soubor "speaker_notes.pptx" s následujícím snímkem:

![Snímek prezentace s poznámkami přednášejícího](slide_with_notes.png)

Níže uvedený úryvek kódu ukazuje, jak převést prezentaci na TIFF obrázek v zobrazení poznámek ke snímku pomocí metody [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Zobrazí poznámky pod snímkem.

// Nakonfigurujte TIFF možnosti s rozvržením poznámek.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Uložte prezentaci do TIFF s poznámkami přednášejícího.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Výsledek:

![TIFF obrázek s poznámkami přednášejícího](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Vyzkoušejte Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/cs/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Často kladené otázky**

### Mohu ovládat polohu oblasti poznámek ve výsledném TIFF?

Ano. Použijte [notes layout settings](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) k výběru mezi možnostmi jako `None`, `BottomTruncated` nebo `BottomFull`, které respektive skryjí poznámky, vejdou je na jednu stránku nebo umožní jejich pokračování na dalších stránkách.

### Jak mohu snížit velikost TIFF souboru s poznámkami bez patrné ztráty kvality?

Vyberte [efficient compression](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (např. `LZW` nebo `RLE`), nastavte rozumné DPI a pokud je to přijatelné, použijte nižší [pixel format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (např. 8 bpp nebo 1 bpp pro monochromní). Mírné zmenšení [image dimensions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/tiffoptions/set_imagesize/) může také pomoci, aniž by výrazně snížilo čitelnost.

### Ovlivní font v poznámkách výsledek, pokud původní fonty chybí v systému?

Ano. Chybějící fonty spustí [substitution](/slides/cs/cpp/font-selection-sequence/), což může změnit metriky textu a vzhled. Abyste tomu předešli, [supply the required fonts](/slides/cs/cpp/custom-font/) nebo nastavte výchozí [fallback font](/slides/cs/cpp/fallback-font/), aby byly použity zamýšlené typy písma.