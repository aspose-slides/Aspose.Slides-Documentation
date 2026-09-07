---
title: Převod PowerPoint prezentací do režimu letáku pomocí Pythonu
linktitle: Režim letáku
type: docs
weight: 150
url: /cs/python-java/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim letáku
- leták
- PPT
- PPTX
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Převést PowerPoint prezentace do letáků v Pythonu přes Java. Uspořádat více snímků na stránku a exportovat do PDF s Aspose.Slides."
---
## **Úvod**

Aspose.Slides for Python via Java vám umožňuje exportovat prezentace v režimu letáku, uspořádat více snímků na jedné stránce. To je užitečné pro tisk materiálů prezentací na konference, semináře a podobné akce.

Rozložení můžete nakonfigurovat prostřednictvím metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Rozložení letáku jsou podporována třídami [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/). Použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handoutlayoutingoptions/) k určení rozložení a nastavení zobrazení.

## **Export v režimu letáku**

Pro export prezentace v režimu letáku vytvořte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handoutlayoutingoptions/) a přiřaďte ji k cílovým možnostem exportu pomocí [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Následující příklad načte `sample.pptx` a exportuje jej do PDF se čtyřmi snímky na stránku v horizontálním pořadí. Obsahuje čísla snímků a rámečky kolem snímků a vylučuje komentáře.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Načíst prezentaci.
presentation = Presentation("sample.pptx")
try:
    # Nakonfigurujte rozložení letáku.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportovat prezentaci do PDF s vybraným rozložením.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Nastavení rozložení letáku se vztahuje na podporované výstupní formáty, jako jsou PDF, HTML, TIFF a vykreslené obrázky. Nepřeskupuje snímky ve zdrojové prezentaci.
{{% /alert %}}

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu letáku?**

Aspose.Slides podporuje až devět miniatur na stránku. Předvolby [HandoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handouttype/) poskytují jeden, dva, tři, čtyři, šest nebo devět snímků na stránku. Předvolby se čtyřmi, šesti a devíti snímky nabízejí horizontální i vertikální uspořádání.

**Mohu definovat vlastní mřížku, například pět nebo osm snímků na stránku?**

Ne. Počet a pořadí miniatur jsou řízeny předdefinovanými hodnotami [HandoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handouttype/). Libovolné mřížky nejsou těmito nastaveními rozložení letáku podporovány.

**Mohu zahrnout skryté snímky do výstupu letáku?**

Ano. Povolit skryté snímky v nastaveních exportu pro cílový formát. Pro PDF zavolejte [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) s hodnotou `True` před uložením prezentace.