---
title: KI‑gestützter Präsentationsübersetzer
linktitle: KI‑gestützter Übersetzer
type: docs
weight: 20
url: /de/net/ai/translator/
keywords:
- KI-Präsentationsübersetzer
- KI-Folienübersetzer
- KI‑gestützte Funktion
- mehrsprachige Präsentation
- mehrsprachige Folie
- Präsentationsübersetzung
- Folienübersetzung
- KI‑gesteuerte Funktionen
- KI‑Fähigkeiten
- KI‑Agent
- Web‑Client
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Übersetzen Sie PowerPoint‑Folien mit KI mithilfe von Aspose.Slides für .NET. Lokalisieren Sie PPT, PPTX und ODP und erhalten Sie das Layout – schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einführung**

Aspose.Slides ist eine leistungsstarke API zum programmgesteuerten Verwalten von PowerPoint‑Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gesteuerte Funktionen – zum Beispiel die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Funktionen, integriert jedoch externe KI‑Modelle über das Internet. Diese Funktionalität wird über die SlidesAIAgent‑Klasse bereitgestellt, die eine Implementation des IAIWebClient‑Interfaces verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten OpenAIWebClient verwenden, um sich mit der API von OpenAI zu verbinden, oder Ihren eigenen IAIWebClient implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="info" title="Note" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten OpenAIWebClient verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mithilfe des integrierten OpenAIWebClient und eines angegebenen OpenAI‑Modells.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Laden Sie eine Präsentation zum Übersetzen.
using var presentation = new Presentation("sample.pptx");

// Erstellen Sie einen KI-Client mit OpenAIWebClient und geben Sie Ihr Modell und Ihren API-Schlüssel an.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialisieren Sie SlidesAIAgent mit dem KI-Client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Übersetzen Sie die Präsentation ins Japanische.
await aiAgent.TranslateAsync(presentation, "japanese");

// Speichern Sie die übersetzte Präsentation als PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Standardmäßig erstellt und verwaltet der integrierte OpenAIWebClient seine eigene interne HttpClient‑Instanz und übernimmt deren Lebenszyklus und Entsorgung automatisch. Wenn Sie jedoch den HttpClient selbst verwalten möchten – zum Beispiel beim Einsatz eines IHttpClientFactory für ein besseres Ressourcenmanagement und eine höhere Leistung – können Sie beim Erzeugen des OpenAIWebClient Ihre eigene `HttpClient`‑Instanz übergeben.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Verwenden Sie einen HttpClient, den Sie selbst verwalten – zum Beispiel einen, der von einem IHttpClientFactory erstellt wird
// über Dependency Injection injiziert.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides wird häufig in synchronen Umgebungen eingesetzt. Um dies zu unterstützen, bietet die SlidesAIAgent‑Klasse sowohl synchrone als auch asynchrone Methoden – sodass Sie den Ansatz wählen können, der am besten zum Workflow Ihrer Anwendung passt.

### **Azure OpenAI Beispiel**

Aspose.Slides für .NET unterstützt OpenAI‑kompatible Anbieter, einschließlich Azure OpenAI. Sie können den Übersetzer so konfigurieren, dass er Ihre interne Azure‑Bereitstellung mit dem OpenAICompatibleWebClient verwendet.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Dieses Snippet demonstriert das Übersetzen einer Präsentation mit Ihrem Azure‑OpenAI‑Endpunkt. Ersetzen Sie die Platzhalterwerte durch Ihren Bereitstellungsnamen, Ihren API‑Schlüssel und die Endpunkt‑URL.

## **Wesentliche Vorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung für die Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und reduziert Fehler im Vergleich zu manuellen Workflows. Egal, ob Sie Entwickler, Pädagoge oder Business‑Professional sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum – wodurch Ihre Reichweite erweitert und die Kommunikation verbessert wird.