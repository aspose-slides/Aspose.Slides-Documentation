---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "Übersetzen Sie PowerPoint-Folien mit KI unter Verwendung von Aspose.Slides für Android via Java. Lokalisieren Sie PPT, PPTX und ODP bei gleichzeitiger Beibehaltung des Layouts - schnell und entwicklerfreundlich. Probieren Sie es aus."
---

## **Aspose.Slides Präsentations‑Übersetzungs‑API: KI‑gestützte mehrsprachige Folien‑Übersetzung**

Aspose.Slides ist eine leistungsstarke API zur programmgesteuerten Verwaltung von PowerPoint‑Präsentationen. Neben dem Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gestützte Funktionen – wie die Präsentations‑Übersetzungs‑API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Funktionen, integriert aber externe KI‑Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) verwenden, um sich mit der OpenAI‑API zu verbinden, oder Ihr eigenes [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzte Inhalte intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="primary" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mit dem integrierten [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) und einem angegebenen OpenAI‑[model](https://platform.openai.com/docs/models).
```java
// Lade eine Präsentation zum Übersetzen.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialisiere SlidesAIAgent mit dem KI-Client.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Übersetze die Präsentation ins Japanische.
    aiAgent.translate(presentation, "japanese");

    // Speichere die übersetzte Präsentation als PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑Instanz und steuert deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – vor allem, um wesentliche Einstellungen wie einen Proxy zu konfigurieren oder um eine [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcen‑Management und eine höhere Leistungsfähigkeit zu verwenden – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz bereitstellen.
```java
// Angenommen, Sie haben eine vorkonfigurierte HttpURLConnection-Instanz (z.B. mit benutzerdefinierten Timeouts, Proxy-Einstellungen usw.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Wesentliche Vorteile**

Die Aspose.Slides Präsentations‑Übersetzungs‑API bietet eine KI‑gestützte Lösung zum Bereitstellen mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitigem Erhalt von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Workflows. Egal, ob Sie Entwickler, Lehrender oder Business‑Professional sind, ermöglicht Ihnen diese API, ansprechende, lokalisierte Präsentationen für ein globales Publikum zu erstellen – erweitern Sie Ihre Reichweite und verbessern Sie die Kommunikation.