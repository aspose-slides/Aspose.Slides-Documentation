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
description: "Übersetzen Sie PowerPoint-Folien mit KI mithilfe von Aspose.Slides für .NET. Lokalisieren Sie PPT, PPTX und ODP, während das Layout erhalten bleibt - schnell und entwicklerfreundlich. Probieren Sie es aus."
---

## **Aspose.Slides Präsentations‑Übersetzungs‑API: KI‑gestützte mehrsprachige Folienübersetzung**

Aspose.Slides ist eine leistungsstarke API zum programmatischen Verwalten von PowerPoint‑Präsentationen. Neben dem Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gesteuerte Funktionen – wie die [Präsentations‑Übersetzungs‑API](https://reference.aspose.com/slides/net/aspose.slides.ai/) für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Funktionen, sondern integriert externe KI‑Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) nutzt, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) verwenden, um sich mit der OpenAI‑API zu verbinden, oder Ihr eigenes [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="primary" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mithilfe des integrierten [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) mit einem angegebenen OpenAI-[Modell](https://platform.openai.com/docs/models).

```csharp
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

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) seine eigene interne [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)-Instanz und übernimmt deren Lebenszyklus und die automatische Entsorgung. Wenn Sie jedoch lieber den [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) selbst verwalten – beispielsweise beim Einsatz eines [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) für ein besseres Ressourcenmanagement und höhere Leistung – können Sie beim Erstellen des [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) Ihre eigene `HttpClient`-Instanz angeben.

```csharp
// Gehen Sie davon aus, dass Sie eine IHttpClientFactory-Instanz haben (z. B. über Dependency Injection injiziert).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides wird häufig in synchronen Umgebungen eingesetzt. Um dies zu unterstützen, stellt die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) sowohl synchrone als auch asynchrone Methoden bereit – sodass Sie den Ansatz wählen können, der am besten zum Arbeitsablauf Ihrer Anwendung passt.

## **Wesentliche Vorteile**

Die Aspose.Slides Präsentations‑Übersetzungs‑API bietet eine KI‑gestützte Lösung für die Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die automatische Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und reduziert Fehler im Vergleich zu manuellen Abläufen. Egal, ob Sie Entwickler, Lehrender oder Business‑Professional sind, ermöglicht Ihnen diese API, ansprechende, lokalisierte Präsentationen für ein globales Publikum zu erstellen – Ihre Reichweite zu erweitern und die Kommunikation zu verbessern.