---
title: Převod prezentací do režimu Handout pomocí Pythonu
linktitle: Režim Handout
type: docs
weight: 150
url: /cs/python-net/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim handout
- podklad
- PowerPoint
- prezentace
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Převádějte prezentace do podkladů v Pythonu. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides poskytuje možnost převádět prezentace do různých formátů, včetně vytváření podkladů pro tisk v režimu Handout. Tento režim vám umožňuje nastavit, jak se na jedné stránce zobrazí více snímků, což je užitečné pro konference, semináře a další akce. Tento režim můžete povolit nastavením vlastnosti `slides_layout_options` ve třídách [PdfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) a [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/).

## **Export v režimu Handout**

Pro konfiguraci režimu Handout použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handoutlayoutingoptions/), který určuje, kolik snímků se umístí na jednu stránku a další parametry zobrazení.

Níže je ukázkový kód, který ukazuje, jak převést prezentaci do PDF v režimu Handout.

```py
# Načtení prezentace.
with slides.Presentation("sample.pptx") as presentation:

    # Nastavení exportních možností.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 snímky na jedné stránce horizontálně
    slides_layout_options.print_slide_numbers = True                                 # tisk čísel snímků
    slides_layout_options.print_frame_slide = True                                   # tisk rámce okolo snímků
    slides_layout_options.print_comments = False                                     # žádné komentáře

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Export prezentace do PDF s vybraným rozložením.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Mějte na paměti, že vlastnost `slides_layout_options` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet náhledových snímků na stránku v režimu Handout?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handouttype/) až 9 náhledových snímků na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání náhledových snímků je přísně řízen výčtem [HandoutType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/handouttype/); libovolná rozložení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu Handout?**

Ano. V nastavení exportu pro cílový formát povolte možnost `show_hidden_slides`, například u [PdfOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/tiffoptions/).