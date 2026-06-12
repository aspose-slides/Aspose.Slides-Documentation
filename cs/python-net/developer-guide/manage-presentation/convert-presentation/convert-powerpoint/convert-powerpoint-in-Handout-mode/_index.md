---
title: Převod prezentací do režimu Handout v Pythonu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- převést PowerPoint
- převod prezentace
- režim handout
- handout
- PowerPoint
- prezentace
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Převod prezentací do handoutů v Pythonu. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, včetně ukázkového kódu. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se více snímků zobrazí na jedné stránce, což je užitečné pro konference, semináře a další akce. Tento režim můžete aktivovat nastavením vlastnosti `slides_layout_options` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/).

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handoutlayoutingoptions/), který určuje, kolik snímků bude umístěno na jedné stránce a další parametry zobrazení.

Níže je ukázka kódu, která ukazuje, jak převést prezentaci do PDF v režimu Handout.

```py
# Načíst prezentaci.
with slides.Presentation("sample.pptx") as presentation:

    # Nastavit možnosti exportu.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 snímky na jedné stránce vodorovně
    slides_layout_options.print_slide_numbers = True                                 # tisknout čísla snímků
    slides_layout_options.print_frame_slide = True                                   # tisknout rám okolo snímků
    slides_layout_options.print_comments = False                                     # žádné komentáře

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exportovat prezentaci do PDF s vybraným rozvržením.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Mějte na paměti, že vlastnost `slides_layout_options` je k dispozici jen pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handouttype/) až 9 miniatur na stránku s vodorovným nebo svislým uspořádáním: 1, 2, 3, 4 (vodorovně/svisle), 6 (vodorovně/svisle) a 9 (vodorovně/svisle).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur jsou přísně řízeny výčtem [HandoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handouttype/); libovolná rozvržení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. Povolte volbu `show_hidden_slides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/).