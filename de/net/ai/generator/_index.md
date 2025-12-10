---
title: KI-gestützter mehrsprachiger Foliengenerator
linktitle: KI-gestützter Generator
type: docs
weight: 40
url: /de/net/ai/generator/
keywords:
- mehrsprachige Präsentation
- mehrsprachige Folie
- KI-Präsentationsgenerator
- KI-Foliengenerator
- KI-gestützte Funktion
- KI-Agent
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erzeugen Sie mehrsprachige Folien aus Text mit Aspose.Slides für .NET. Wenden Sie Ihre Vorlage an und exportieren Sie professionell gestaltete Decks nach PowerPoint und OpenDocument. Erfahren Sie mehr."
---

## **Aspose.Slides Presentation KI API: KI-gestützter Folien-Generator**

Aspose.Slides führt ein neues KI-gestütztes Feature, den Presentation Generator, ein, das Entwicklern ermöglicht, automatisch gut strukturierte PowerPoint‑Präsentationen aus einfachen Texteingaben wie Themenbeschreibungen, Zusammenfassungen, Zitaten oder Aufzählungspunkten zu erstellen.

Benutzer können den Detailgrad des Inhalts anpassen und optional eine benutzerdefinierte Präsentationsvorlage anwenden, um das visuelle Design festzulegen.

Derzeit strukturiert der KI‑Presentation‑Generator Inhalte mittels Textblöcken, Aufzählungslisten und Tabellen. Die Bilderzeugung wird noch nicht unterstützt; Bilder können jedoch anschließend leicht mit den Aspose.Slides‑Werkzeugen oder manuell hinzugefügt werden.

Die Ausgabe ist eine vollständige PowerPoint‑Präsentation, die direkt verwendet oder in jedes von der Aspose.Slides‑API unterstützte Format exportiert werden kann. Obwohl der Generator hochwertige Ergebnisse liefert, kann eine leichte Nachbearbeitung erforderlich sein, um spezifische Anforderungen zu erfüllen.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Modelle; stattdessen integriert es externe KI‑Dienste über das Internet. Diese Integration wird von der Klasse [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) übernommen, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) nutzt, um mit dem KI‑Modell zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) verwenden, der sich mit der OpenAI‑API verbindet, oder eine eigene Implementierung von [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) bereitstellen, um mit einem anderen KI‑Anbieter oder Sprachmodell zu arbeiten. Aspose.Slides verwaltet die gesamte Kommunikation mit dem KI‑Dienst und verarbeitet die Antworten der KI, um Folien zu erzeugen. Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass ein Konto und ein API‑Schlüssel erforderlich sind, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) nutzen.

## **Lass uns programmieren**

### **Beispiel 1**

Dieses Beispiel zeigt, wie man eine Präsentation zum Thema Aspose.Slides mit dem integrierten [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) erzeugt.

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Beispiel 2**

Das folgende Beispiel demonstriert die Überladungen der Methode [GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/). In diesem Fall werden eine extern verwaltete [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-Instanz und die `master presentation` des Benutzers verwendet.

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) seine eigene interne [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-Instanz und kümmert sich automatisch um deren Lebenszyklus und Entsorgung. Wenn Sie jedoch den [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) selbst verwalten möchten – zum Beispiel beim Einsatz einer [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) für ein verbessertes Ressourcenmanagement und höhere Performance – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) Ihre eigene [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-Instanz übergeben.

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Es sei darauf hingewiesen, dass viele Kunden Aspose.Slides in synchronen Kontexten einsetzen. Um dies zu unterstützen, stellt die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) sowohl synchrone als auch asynchrone Methoden bereit, sodass Sie den Ansatz wählen können, der am besten zum Workflow Ihrer Anwendung passt.

## **Wesentliche Vorteile**

Der neue KI‑Presentation‑Generator in Aspose.Slides bietet eine schnelle und flexible Methode, strukturierte Folienpräsentationen aus einfachen Texteingaben zu erzeugen. Mit Unterstützung für benutzerdefinierte Vorlagen, extern verwaltete [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-Instanzen sowie sowohl synchrone als auch asynchrone Workflows lässt er sich nahtlos in eine Vielzahl von Anwendungen integrieren.

Typische Anwendungsfälle umfassen die Erstellung von Marketing‑Präsentationen, Lehrmaterialien, Kundenberichten und internen Foliensets. Obwohl die Bilderzeugung noch nicht unterstützt wird, bietet das Tool bereits eine solide Basis zur Automatisierung der Präsentationserstellung, wobei in Zukunft weitere Verbesserungen erwartet werden.