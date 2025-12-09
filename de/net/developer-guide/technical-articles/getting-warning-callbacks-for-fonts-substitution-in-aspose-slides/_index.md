---
title: Warnrückrufe für Schriftart-Substitution in .NET erhalten
type: docs
weight: 120
url: /de/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- Warnrückruf
- Schriftart-Substitution
- Rendervorgang
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Warnrückrufe für Schriftart-Substitution in Aspose.Slides für .NET erhalten und PowerPoint- sowie OpenDocument-Präsentationen genau anzeigen."
---

## **Übersicht**

Aspose.Slides for .NET ermöglicht das Empfangen von Warnungsrückrufen für die Schriftartsubstitution, wenn eine erforderliche Schriftart während der Wiedergabe nicht auf dem System verfügbar ist. Diese Rückrufe helfen, Probleme mit fehlenden oder nicht zugänglichen Schriftarten zu diagnostizieren.

## **Warnungsrückrufe aktivieren**

Aspose.Slides for .NET bietet einfache APIs, um Warnungsrückrufe beim Rendern von Präsentationsfolien zu erhalten. Befolgen Sie diese Schritte, um Warnungsrückrufe zu konfigurieren:

1. Erstellen Sie eine benutzerdefinierte Callback‑Klasse, die das [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) Interface implementiert, um Warnungen zu behandeln.  
1. Setzen Sie den Warnungs‑Callback mithilfe von Optionsklassen wie [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) und anderen.  
1. Laden Sie eine Präsentation, die eine Schriftart verwendet, die auf dem Zielcomputer nicht verfügbar ist.  
1. Erzeugen Sie ein Folien‑Miniaturbild oder exportieren Sie die Präsentation, um die Wirkung zu beobachten.

**Benutzerdefinierte Warnungs‑Callback‑Klasse:**  
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

// Beispielausgabe:
//
// Schriftart wird von XYZ zu {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**Folien‑Miniaturbild erzeugen:**  
```c#
// Richten Sie einen Warnungs-Callback ein, um schriftenbezogene Warnungen beim Rendern von Folien zu behandeln.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Laden Sie die Präsentation vom angegebenen Dateipfad.
using var presentation = new Presentation("sample.pptx");

// Erzeugen Sie ein Miniaturbild für jede Folie in der Präsentation.
foreach (var slide in presentation.Slides)
{
    // Holen Sie das Folien-Miniaturbild mit den angegebenen Renderoptionen.
    using var image = slide.GetImage(options);
    // ...
}
```


**Exportieren in das PDF‑Format:**  
```c#
// Richten Sie einen Warnungs-Callback ein, um schriftenbezogene Warnungen beim PDF-Export zu behandeln.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Laden Sie die Präsentation vom angegebenen Dateipfad.
using var presentation = new Presentation("sample.pptx");

// Exportieren Sie die Präsentation als PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**Exportieren in das HTML‑Format:**  
```c#
// Richten Sie einen Warnungs-Callback ein, um schriftenbezogene Warnungen beim HTML-Export zu behandeln.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Laden Sie die Präsentation vom angegebenen Dateipfad.
using var presentation = new Presentation("sample.pptx");

// Exportieren Sie die Präsentation im HTML-Format.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
