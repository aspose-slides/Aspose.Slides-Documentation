---
title: Získání výstražných zpětných volání pro nahrazování písma v .NET
type: docs
weight: 120
url: /cs/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- výstražné zpětné volání
- nahrazení písma
- proces vykreslování
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se získávat výstražná zpětná volání při nahrazování písma v Aspose.Slides pro .NET a přesně zobrazovat prezentace PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides pro .NET vám umožňuje přijímat výstražné zpětné volání při nahrazování písma, když požadované písmo není během renderování na počítači k dispozici. Tato zpětná volání pomáhají diagnostikovat problémy s chybějícími nebo nepřístupnými písmy.

## **Povolení výstražných zpětných volání**

Aspose.Slides pro .NET poskytuje jednoduché rozhraní API pro přijímání výstražných zpětných volání při vykreslování snímků prezentace. Postupujte podle těchto kroků pro nastavení výstražných zpětných volání:

1. Vytvořte vlastní třídu zpětného volání, která implementuje rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/net/aspose.slides.warnings/iwarningcallback/) pro zpracování výstrah.
2. Nastavte výstražné zpětné volání pomocí tříd možností, jako jsou [RenderingOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/htmloptions/) a další.
3. Načtěte prezentaci, která používá písmo, které není na cílovém počítači k dispozici.
4. Vytvořte miniaturu snímku nebo exportujte prezentaci, abyste pozorovali výsledek.

**Vlastní třída výstražného zpětného volání:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Příklad výstupu:
//
// Písmo bude nahrazeno z XYZ na {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Vytvořit miniaturu snímku:**

```c#
// Nastavte výstražné zpětné volání pro zpracování výstrah souvisejících s písmem během vykreslování snímku.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Načtěte prezentaci ze zadané cesty k souboru.
using var presentation = new Presentation("sample.pptx");

// Vytvořte miniaturu obrázku pro každý snímek v prezentaci.
foreach (var slide in presentation.Slides)
{
    // Získejte miniaturu snímku pomocí zadaných možností vykreslování.
    using var image = slide.GetImage(options);
    // ...
}
```

**Exportovat do formátu PDF:**

```c#
// Nastavte výstražné zpětné volání pro zpracování výstrah souvisejících s písmem během exportu do PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Načtěte prezentaci ze zadané cesty k souboru.
using var presentation = new Presentation("sample.pptx");

// Exportujte prezentaci jako PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Exportovat do formátu HTML:**

```c#
// Nastavte výstražné zpětné volání pro zpracování výstrah souvisejících s písmem během exportu do HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Načtěte prezentaci ze zadané cesty k souboru.
using var presentation = new Presentation("sample.pptx");

// Exportujte prezentaci ve formátu HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```