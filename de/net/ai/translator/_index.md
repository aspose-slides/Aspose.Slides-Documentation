---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/net/ai/translator/
keywords:
- KI-Präsentationsübersetzer
- KI-Folienübersetzer
- KI-gestützte Funktion
- mehrsprachige Präsentation
- mehrsprachige Folie
- Präsentationsübersetzung
- Folienübersetzung
- KI-gesteuerte Funktionen
- KI-Fähigkeiten
- KI-Agent
- Web-Client
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Übersetzen Sie PowerPoint-Folien mit KI mithilfe von Aspose.Slides für .NET. Lokalisiere PPT, PPTX und ODP und erhalte das Layout - schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsstarke API zum programmgesteuerten Verwalten von PowerPoint-Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI-gestützte Funktionen - beispielsweise die [Presentation Translation API](https://reference.aspose.com/slides/de/net/aspose.slides.ai/) für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI-Funktionen, sondern integriert externe KI-Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/de/net/aspose.slides.ai/slidesaiagent) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/iaiwebclient/) verwendet, um mit KI-Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/openaiwebclient/) verwenden, um sich mit der OpenAI-API zu verbinden, oder Ihr eigenes [IAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/iaiwebclient/) implementieren, um einen anderen KI-Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI-Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="info" %}}

Beachten Sie, dass die OpenAI-API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API-Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/openaiwebclient/) verwenden.

{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint-Präsentation ins Japanische, indem wir den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/openaiwebclient/) mit einem angegebenen OpenAI-[Modell](https://platform.openai.com/docs/models) verwenden.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Lade eine Präsentation zum Übersetzen.
using var presentation = new Presentation("sample.pptx");

// Erstelle einen KI-Client mit OpenAIWebClient, indem du dein Modell und deinen API‑Schlüssel angibst.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialisiere SlidesAIAgent mit dem KI-Client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Übersetze die Präsentation ins Japanische.
await aiAgent.TranslateAsync(presentation, "japanese");

// Speichere die übersetzte Präsentation als PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/openaiwebclient/) seine eigene interne [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-Instanz und kümmert sich automatisch um deren Lebenszyklus und Entsorgung. Wenn Sie jedoch den [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) selbst verwalten möchten - etwa beim Einsatz einer [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) für ein besseres Ressourcenmanagement und höhere Leistung - können Sie beim Erstellen des [OpenAIWebClient](https://reference.aspose.com/slides/de/net/aspose.slides.ai/openaiwebclient/) Ihre eigene `HttpClient`-Instanz übergeben.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Verwenden Sie einen HttpClient, den Sie selbst verwalten - zum Beispiel einen, der von einer IHttpClientFactory erstellt wurde
// über die Dependency Injection injiziert.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides wird häufig in synchronen Umgebungen eingesetzt. Um dies zu unterstützen, bietet die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/de/net/aspose.slides.ai/slidesaiagent/) sowohl synchrone als auch asynchrone Methoden - sodass Sie den Ansatz wählen können, der am besten zum Workflow Ihrer Anwendung passt.

## **Wesentliche Vorteile**

Die Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/de/net/aspose.slides.ai/) bietet eine KI-gestützte Lösung für die Bereitstellung mehrsprachiger PowerPoint-Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitigem Erhalt von Layout und Design spart sie Zeit und reduziert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Pädagoge oder Business-Professional sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum - erweitert Ihre Reichweite und verbessert die Kommunikation.