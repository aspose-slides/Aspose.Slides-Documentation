---
title: Waarschuwingen ontvangen voor lettertypevervanging in .NET
type: docs
weight: 120
url: /nl/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwing callback
- lettertypevervanging
- renderproces
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u waarschuwing callbacks kunt ontvangen voor lettertypevervanging in Aspose.Slides voor .NET en PowerPoint- en OpenDocument-presentaties nauwkeurig weergeeft."
---
## **Inleiding**

Aspose.Slides voor .NET maakt het mogelijk om waarschuwing‑callbacks te ontvangen voor lettertypevervanging wanneer een vereist lettertype niet beschikbaar is op de computer tijdens het renderen. Deze callbacks helpen bij het diagnosticeren van problemen met ontbrekende of ontoegankelijke lettertypen.

## **Waarschuwingen inschakelen**

Aspose.Slides voor .NET biedt eenvoudige API’s om waarschuwing‑callbacks te ontvangen bij het renderen van presentatiedia’s. Volg deze stappen om waarschuwing‑callbacks te configureren:

1. Maak een aangepaste callback‑klasse die de interface [IWarningCallback](https://reference.aspose.com/slides/nl/net/aspose.slides.warnings/iwarningcallback/) implementeert om waarschuwingen af te handelen.
1. Stel de waarschuwing‑callback in via optieklassen zoals [RenderingOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/htmloptions/), en anderen.
1. Laad een presentatie die een lettertype gebruikt dat niet beschikbaar is op de doelsysteem.
1. Genereer een miniatuur van een dia of exporteer de presentatie om het effect te zien.

**Aangepaste Waarschuwing Callback Klasse:**

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

// Voorbeeldoutput:
//
// Lettertype wordt vervangen van XYZ naar {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Miniatuur van een dia genereren:**

```c#
// Stel een waarschuwingscallback in om lettertypegerelateerde waarschuwingen af te handelen tijdens het renderen van dia's.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Laad de presentatie vanaf het opgegeven bestandspad.
using var presentation = new Presentation("sample.pptx");

// Genereer een miniatuurafbeelding voor elke dia in de presentatie.
foreach (var slide in presentation.Slides)
{
    // Haal de miniatuurafbeelding van de dia op met de opgegeven renderopties.
    using var image = slide.GetImage(options);
    // ...
}
```

**Exporteren naar PDF‑formaat:**

```c#
// Stel een waarschuwingscallback in om lettertypegerelateerde waarschuwingen af te handelen tijdens PDF-export.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Laad de presentatie vanaf het opgegeven bestandspad.
using var presentation = new Presentation("sample.pptx");

// Exporteer de presentatie als PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Exporteren naar HTML‑formaat:**

```c#
// Stel een waarschuwingscallback in om lettertypegerelateerde waarschuwingen af te handelen tijdens HTML-export.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Laad de presentatie vanaf het opgegeven bestandspad.
using var presentation = new Presentation("sample.pptx");

// Exporteer de presentatie in HTML-indeling.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```