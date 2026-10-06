---
title: Převod prezentací PowerPoint do režimu letáku pomocí Pythonu
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
description: "Převod prezentací PowerPoint na letáky v Pythonu prostřednictvím Javy. Uspořádejte více snímků na stránku a exportujte do PDF pomocí Aspose.Slides."
---
## **Úvod**

Aspose.Slides pro Python pomocí Java vám umožňuje exportovat prezentace v režimu letáku, uspořádat více snímků na jedné stránce. To je užitečné pro tisk materiálů prezentací na konference, semináře a podobné akce.

Rozvržení můžete nastavit pomocí metody [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Rozvržení letáků jsou podporována v [PdfOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/htmloptions/), a [TiffOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/tiffoptions/). Použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handoutlayoutingoptions/) k určení rozvržení a nastavení zobrazení.

Pro nastavení rozměrů a orientace stránky letáku před exportem viz [Velikost stránky poznámek](/slides/cs/python-java/notes-size/).

## **Export v režimu letáku**

Pro export prezentace v režimu letáku vytvořte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handoutlayoutingoptions/), a přiřaďte ji k cílovým možnostem exportu pomocí [setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Následující příklad načte `sample.pptx` a exportuje jej do PDF se čtyřmi snímky na stránku v horizontálním pořadí. Zahrnuje čísla snímků a rámečky kolem snímků a vylučuje komentáře.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Načtěte prezentaci.
presentation = Presentation("sample.pptx")
try:
    # Nastavte rozvržení letáku.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Exportujte prezentaci do PDF s vybraným rozvržením.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Nastavení rozvržení letáku se vztahují na podporované výstupní formáty, jako jsou PDF, HTML, TIFF a vykreslené obrázky. Nepřetočí snímky ve zdrojové prezentaci.
{{% /alert %}}

## **FAQ**

**Jaký je maximální počet miniatur snímků na stránce v režimu letáku?**

Aspose.Slides podporuje až devět miniatur na stránku. Předvolby [HandoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handouttype/) poskytují jeden, dva, tři, čtyři, šest nebo devět snímků na stránku. Předvolby se čtyřmi, šesti a devíti snímky nabízejí horizontální i vertikální uspořádání.

**Mohu definovat vlastní mřížku, například pět nebo osm snímků na stránku?**

Ne. Počet a pořadí miniatur jsou řízeny předdefinovanými hodnotami [HandoutType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/handouttype/). Libovolné mřížky nejsou těmito nastaveními rozvržení letáku podporovány.

**Mohu do výstupu letáku zahrnout skryté snímky?**

Ano. Aktivujte skryté snímky v nastavení exportu pro cílový formát. Pro PDF zavolejte [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) s hodnotou `True` před uložením prezentace.