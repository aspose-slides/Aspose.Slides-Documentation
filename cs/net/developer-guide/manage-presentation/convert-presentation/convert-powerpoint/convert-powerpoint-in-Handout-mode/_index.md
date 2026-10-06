---
title: Převod prezentací PowerPoint do režimu Rozdělení v .NET
linktitle: Režim Rozdělení
type: docs
weight: 150
url: /cs/net/convert-powerpoint-in-handout-mode/
keywords:
- převod PowerPoint
- převod prezentace
- režim rozdělení
- rozdělení
- PowerPoint
- prezentace
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Převod prezentací na rozdělení v .NET. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem C#. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides vám umožňuje převádět prezentace do výstupních formátů, které podporují režim Rozdělení. V tomto režimu jsou na jedné stránce uspořádány více snímků, což je užitečné pro tisk materiálů prezentací na konferencích, seminářích a podobných akcích.

Režim Rozdělení se nastavuje pomocí vlastnosti `SlidesLayoutOptions`, která je k dispozici v [IPdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/). Pro definování rozložení rozdělení použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handoutlayoutingoptions/).

Chcete-li nastavit rozměry a orientaci stránky rozdělení před exportem, podívejte se na [Velikost stránky poznámek](/slides/cs/net/notes-size/).

## **Export v režimu Rozdělení**

Pro export prezentace v režimu Rozdělení nastavte vlastnost `SlidesLayoutOptions` pro cílové exportní možnosti a přiřaďte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handoutlayoutingoptions/), která určuje počet snímků na stránce a související zobrazovací parametry.

Níže je ukázka kódu, která ukazuje, jak převést prezentaci na PDF v režimu Rozdělení.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Načíst prezentaci.
using var presentation = new Presentation("sample.pptx");

// Nastavit možnosti exportu.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 snímky na jedné stránce vodorovně
        PrintSlideNumbers = true,                   // vytisknout čísla snímků
        PrintFrameSlide = true,                     // vytisknout rám kolem snímků
        PrintComments = false                       // bez komentářů
    }
};

// Exportovat prezentaci do PDF s vybraným rozložením.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Mějte na paměti, že vlastnost `SlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při renderování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

### Jaký je maximální počet miniatur snímků na stránce v režimu Rozdělení?

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handouttype/) až 9 miniatur na stránku s vodorovným nebo svislým uspořádáním: 1, 2, 3, 4 (vodorovně/svisle), 6 (vodorovně/svisle) a 9 (vodorovně/svisle).

### Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?

Ne. Počet a uspořádání miniatur jsou přísně řízeny výčtovým typem [HandoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handouttype/); vlastní rozvržení není podporováno.

### Mohu zahrnout skryté snímky do výstupu Rozdělení?

Ano. Povolením možnosti `ShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/).