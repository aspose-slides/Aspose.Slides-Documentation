---
title: Převod prezentací PowerPoint do režimu letáků v .NET
linktitle: Režim letáků
type: docs
weight: 150
url: /cs/net/convert-powerpoint-in-handout-mode/
keywords:
- převést PowerPoint
- převést prezentaci
- režim letáků
- leták
- PowerPoint
- prezentace
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Převádějte prezentace na letáky v .NET. Nastavte počet snímků na stránku, zachovejte poznámky, exportujte do PDF nebo obrázků pomocí Aspose.Slides, s ukázkovým kódem v C#. Vyzkoušejte zdarma."
---
## **Úvod**

Aspose.Slides umožňuje převádět prezentace do výstupních formátů, které podporují režim letáků. V tomto režimu jsou na jedné stránce uspořádány více snímků, což je užitečné pro tisk materiálů prezentace na konference, semináře a podobné akce.

Režim letáků se konfigurují pomocí vlastnosti `SlidesLayoutOptions`, která je dostupná v [IPdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/ihtmloptions/) a [ITiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/itiffoptions/). Pro definování rozložení letáku použijte objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handoutlayoutingoptions/) .

## **Export v režimu letáků**

Pro export prezentace v režimu letáků nastavte vlastnost `SlidesLayoutOptions` u cílových možností exportu a přiřaďte instanci [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handoutlayoutingoptions/) , která určuje počet snímků na stránku a související parametry zobrazení.

Níže je příklad kódu, který ukazuje, jak převést prezentaci do PDF v režimu letáků.

```c#
// Načíst prezentaci.
using var presentation = new Presentation("sample.pptx");

// Nastavit možnosti exportu.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 snímky na jedné stránce horizontálně
        PrintSlideNumbers = true,                   // vytisknout čísla snímků
        PrintFrameSlide = true,                     // vytisknout rám kolem snímků
        PrintComments = false                       // žádné komentáře
    }
};

// Exportovat prezentaci do PDF s vybraným rozložením.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Mějte na paměti, že vlastnost `SlidesLayoutOptions` je k dispozici pouze pro některé výstupní formáty, jako jsou PDF, HTML, TIFF, a při vykreslování jako obrázky.
{{% /alert %}} 

## **Často kladené otázky**

**Jaký je maximální počet miniatur snímků na stránku v režimu letáků?**

Aspose.Slides podporuje [předvolby](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handouttype/) až 9 miniatur na stránku s horizontálním nebo vertikálním uspořádáním: 1, 2, 3, 4 (horizontální/vertikální), 6 (horizontální/vertikální) a 9 (horizontální/vertikální).

**Mohu definovat vlastní mřížku, například 5 nebo 8 snímků na stránku?**

Ne. Počet a uspořádání miniatur je přísně řízen výčtem [HandoutType](https://reference.aspose.com/slides/cs/net/aspose.slides.export/handouttype/) ; libovolná rozvržení nejsou podporována.

**Mohu zahrnout skryté snímky do výstupu letáku?**

Ano. Povolit možnost `ShowHiddenSlides` v nastavení exportu pro cílový formát, například [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) nebo [TiffOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/tiffoptions/).