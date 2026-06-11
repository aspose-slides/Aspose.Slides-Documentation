---
title: Få varningsåteruppringningar för teckensnittssubstitution i .NET
type: docs
weight: 120
url: /sv/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteruppringning
- teckensnittssubstitution
- renderingsprocess
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du får varningsåteruppringningar för teckensnittssubstitution i Aspose.Slides för .NET och visar PowerPoint- och OpenDocument-presentationer exakt."
---
## **Introduktion**

Aspose.Slides för .NET låter dig ta emot varningsåteruppringningar för teckensnittssubstitution när ett erforderligt teckensnitt inte är tillgängligt på datorn under rendering. Dessa återuppringningar hjälper till att diagnostisera problem med saknade eller otillgängliga teckensnitt.

## **Aktivera varningsåteruppringningar**

Aspose.Slides för .NET tillhandahåller enkla API:er för att ta emot varningsåteruppringningar vid rendering av presentationsbilder. Följ dessa steg för att konfigurera varningsåteruppringningar:

1. Skapa en anpassad callback-klass som implementerar gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/net/aspose.slides.warnings/iwarningcallback/) för att hantera varningar.
1. Ställ in varningsåteruppringningen med hjälp av alternativklasser såsom [RenderingOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/htmloptions/) och andra.
1. Läs in en presentation som använder ett teckensnitt som inte är tillgängligt på målmaskinen.
1. Generera en bild-miniatyr eller exportera presentationen för att observera effekten.

**Anpassad varningscallback-klass:**

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

// Exempelutmatning:
//
// Typsnittet kommer att ersättas från XYZ till {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Generera en bild-miniatyr:**

```c#
// Ställ in en varningsåteruppringning för att hantera teckensnittrelaterade varningar under bildrendering.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Läs in presentationen från den angivna filvägen.
using var presentation = new Presentation("sample.pptx");

// Generera en miniatyrbild för varje bild i presentationen.
foreach (var slide in presentation.Slides)
{
    // Hämta bildens miniatyrbild med de angivna renderingsalternativen.
    using var image = slide.GetImage(options);
    // ...
}
```

**Exportera till PDF-format:**

```c#
// Ställ in en varningsåteruppringning för att hantera teckensnittrelaterade varningar under PDF-export.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Läs in presentationen från den angivna filvägen.
using var presentation = new Presentation("sample.pptx");

// Exportera presentationen som PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Exportera till HTML-format:**

```c#
// Ställ in en varningsåteruppringning för att hantera teckensnittrelaterade varningar under HTML-export.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Läs in presentationen från den angivna filvägen.
using var presentation = new Presentation("sample.pptx");

// Exportera presentationen i HTML-format.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```