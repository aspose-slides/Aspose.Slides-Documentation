---
title: "Wie man Text aus PPT-, PPTX- und ODP-Dateien mit dem Open XML SDK in .NET extrahiert"
linktitle: Open XML SDK
type: docs
weight: 20
url: /de/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- Cloud-Plattformen
- Cloud-Integration
- Open XML SDK
- PPTX-Text-Extraktion
- .NET-Folienverarbeitung
- Präsentationstextextraktion
- Masterfolie
- Referenten-Notizen
- Text aus Folien extrahieren
- C#
description: "Erfahren Sie, wie Sie in .NET mit dem Open XML SDK Text aus PPT, PPTX und ODP extrahieren, mit XML-basiertem Zugriff, Leistungstipps und Konvertierungs‑Workarounds für Cloud‑Apps."
---

# Text aus PPT, PPTX, ODP mithilfe des Open XML SDK extrahieren

## Open XML SDK

Der **Open XML SDK** bietet eine stark strukturierte und effiziente Methode zum Extrahieren von Text aus Präsentationsdateien – insbesondere **PPTX**, das dem Open XML‑Standard entspricht. Durch den direkten Zugriff auf das zugrunde liegende XML ermöglicht dieses SDK eine schnellere und flexiblere Verarbeitung von Folieninhalten im Vergleich zu herkömmlichen Methoden.

## Direkter XML‑Zugriff

- **Text direkt analysieren**: Der Open XML SDK lässt Sie Text aus XML‑Teilen extrahieren, ohne die Folien zu rendern.
- **Strukturierte Elemente**: Da Text in klar definierten XML‑Tags gespeichert ist, ist das Abrufen und Verarbeiten einfacher.

### Beispiel: Text direkt aus dem XML‑Inhalt einer Folie extrahieren
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## Leistungsvorteile

- **Schnelleres Extrahieren**: Umgeht den Overhead beim Öffnen von PowerPoint oder anderen High‑Level‑APIs.
- **Geringerer Speicherverbrauch**: Es werden nur relevante XML‑Teile gelesen, wodurch der Ressourcenverbrauch reduziert wird.
- **Kein Microsoft PowerPoint nötig**: Befreit Sie von zusätzlichen Installationsanforderungen.

### Beispiel: Text effizient extrahieren, ohne die gesamte Präsentation zu laden
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## Identifizierung von Textelementen

### Details zum Extrahieren von Text aus Präsentationen

Beim Extrahieren von Text aus Präsentationen sollten Sie folgende Aspekte berücksichtigen:

- **Text kann in verschiedenen Bereichen liegen**: Normale Folien, Master‑Folien, Layouts oder Notizen.
- **Standard‑Platzhalter**: Master‑Folien und Layouts können Platzhalter enthalten (z. B. „Klicken Sie, um den Master‑Titelstil zu bearbeiten“), die keinen tatsächlichen Präsentationsinhalt darstellen.
- **Leeren oder ausgeblendeten Text filtern**: Einige Elemente können leer sein oder nicht zur Anzeige bestimmt sein.

### Tags, die Text enthalten

In einer **PPTX**‑Datei wird Text typischerweise gespeichert in:
- `<a:t>`‑Elementen innerhalb von `<a:p>` (Absätze)
- `<a:r>`‑Elementen (Textsegmente innerhalb von Absätzen)

### Beispiel: Alle Textelemente einer Folie extrahieren
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## ODP und PPT

### Unfähigkeit, Text direkt zu extrahieren

- Im Gegensatz zu **PPTX** werden **PPT** (binäres Format) und **ODP** (OpenDocument Presentation) vom Open XML SDK **nicht unterstützt**.
- **PPT** speichert Inhalte in einem geschlossenen Binärformat, was die Textextraktion erschwert.
- **ODP** basiert auf **OpenDocument XML**, das strukturell von PPTX abweicht.

### Vorgehensweise: Konvertierung zu PPTX

Um Text aus **PPT** oder **ODP** zu extrahieren, wird folgender Ansatz empfohlen:

1. **PPT → PPTX** mit PowerPoint oder einem Drittanbieter‑Tool konvertieren.  
2. **ODP → PPTX** über LibreOffice oder PowerPoint konvertieren.  
3. **Text** aus der neuen PPTX‑Datei mit dem Open XML SDK extrahieren.

### Beispiel: ODP über LibreOffice‑Kommandozeile zu PPTX konvertieren
```sh
soffice --headless --convert-to pptx presentation.odp
```


## Unterstützte Plattformen und Frameworks

- **Windows**: .NET Framework 4.6.1 und höher, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Cloud‑Umgebungen**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker‑Container.
- **Kompatibilität mit Office‑Anwendungen**: Keine Microsoft‑Office‑Installation erforderlich.
- **Unterstützte Programmiersprachen**: Der Open XML SDK kann mit **C#**, **VB.NET**, **F#** und anderen .NET‑unterstützten Sprachen verwendet werden.

## Fazit

Der Einsatz des **Open XML SDK** für die **PPTX‑Textextraktion** bietet sowohl Effizienz als auch Klarheit, während **PPT** und **ODP** einen vorbereitenden Konvertierungsschritt benötigen, um eine reibungslose Verarbeitung zu ermöglichen. Dieser Ansatz gewährleistet **hohe Leistung**, **Flexibilität** und **breite Kompatibilität** mit modernen .NET‑Anwendungen.