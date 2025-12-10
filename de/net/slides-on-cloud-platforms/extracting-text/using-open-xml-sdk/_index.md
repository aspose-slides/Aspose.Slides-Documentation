---
title: "Wie man Text aus PPT, PPTX und ODP Dateien mit Open XML SDK in .NET extrahiert"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /de/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- "Cloud-Plattformen"
- "Cloud-Integration"
- "Open XML SDK"
- "PPTX-Text-Extraktion"
- ".NET Folienverarbeitung"
- "Präsentationstextextraktion"
- "Masterfolie"
- "Sprechernotizen"
- "Text aus Folien extrahieren"
- "C#"
description: "Erfahren Sie, wie Sie Text aus PPT, PPTX und ODP in .NET mit Open XML SDK extrahieren, mit XML-basiertem Zugriff, Leistungstipps und Konvertierungs‑Workarounds für Cloud‑Apps."
---

## **Open XML SDK**

Das **Open XML SDK** bietet eine hochstrukturierte und effiziente Methode zum Extrahieren von Text aus Präsentationsdateien – insbesondere **PPTX**, das dem Open XML-Standard entspricht. Durch den direkten Zugriff auf das zugrunde liegende XML ermöglicht dieses SDK eine schnellere und flexiblere Handhabung von Folieninhalten im Vergleich zu herkömmlichen Methoden.

## **Direct XML Access**

- **Text direkt analysieren**: Das Open XML SDK ermöglicht das Extrahieren von Text aus XML-Teilen, ohne Folien zu rendern.
- **Strukturierte Elemente**: Da Text in klar definierten XML-Tags gespeichert ist, ist das Abrufen und Verarbeiten einfacher.

### **Example: Extracting Text Directly from Slide XML Content**
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


## **Performance Advantages**

- **Schnellere Extraktion**: Umgeht den Overhead des Öffnens von PowerPoint oder anderer High-Level-APIs.
- **Geringerer Speicherverbrauch**: Es werden nur relevante XML-Teile abgerufen, wodurch der Ressourcenverbrauch reduziert wird.
- **Kein Microsoft PowerPoint erforderlich**: Befreit Sie von zusätzlichen Installationsanforderungen.

### **Example: Efficiently Extracting Text Without Loading the Entire Presentation**
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


## **Identifying Text Elements**

### **Specifics of Extracting Text from Presentations**

Beim Extrahieren von Text aus Präsentationen sollten Sie diese Faktoren berücksichtigen:

- **Text kann in verschiedenen Abschnitten vorkommen**: Reguläre Folien, Masterfolien, Layouts oder Notizen.
- **Standard-Platzhalter**: Masterfolien und Layouts können Platzhalter enthalten (z. B. „Klicken Sie, um den Master‑Titelsstil zu bearbeiten“), die kein tatsächlicher Präsentationsinhalt sind.
- **Leeren oder ausgeblendeten Text filtern**: Einige Elemente könnten leer sein oder nicht zur Anzeige bestimmt.

### **Tags Containing Text**

In einer **PPTX**‑Datei wird Text im Allgemeinen gespeichert in:

- `<a:t>`-Elemente innerhalb von `<a:p>` (Absätze)
- `<a:r>`-Elemente (Textsegmente innerhalb von Absätzen)

### **Example: Extracting All Text Elements from a Slide**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP and PPT**

### **Inability to Extract Text Directly**

- Im Gegensatz zu **PPTX** werden **PPT** (binäres Format) und **ODP** (OpenDocument Presentation) **nicht vom Open XML SDK unterstützt**.
- **PPT** speichert Inhalte in einem geschlossenen Binärformat, was die Textextraktion erschwert.
- **ODP** basiert auf **OpenDocument XML**, das strukturell von PPTX abweicht.

### **Workaround: Converting to PPTX**

Um Text aus **PPT** oder **ODP** zu extrahieren, wird folgender Ansatz empfohlen:

1. **PPT → PPTX konvertieren** mit PowerPoint oder einem Drittanbieter-Tool.  
2. **ODP → PPTX konvertieren** über LibreOffice oder PowerPoint.  
3. **Text extrahieren** aus der neuen PPTX mit dem Open XML SDK.

### **Example: Converting ODP to PPTX via LibreOffice Command Line**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Supported Platforms and Frameworks**

- **Windows**: .NET Framework 4.6.1 und höher, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Cloud‑Umgebungen**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker‑Container.
- **Kompatibilität mit Office‑Anwendungen**: Keine Microsoft‑Office-Installation erforderlich.
- **Unterstützte Programmiersprachen**: Das Open XML SDK kann mit **C#**, **VB.NET**, **F#** und anderen .NET‑unterstützten Sprachen verwendet werden.

## **Conclusion**

Die Verwendung des **Open XML SDK** für die **PPTX‑Textextraktion** bietet sowohl Effizienz als auch Übersichtlichkeit, während **PPT und ODP** einen anfänglichen Konvertierungsschritt für eine reibungslose Verarbeitung erfordern. Die Anwendung dieses Ansatzes gewährleistet **hohe Leistung**, **Flexibilität** und **breite Kompatibilität** mit modernen .NET‑Anwendungen.