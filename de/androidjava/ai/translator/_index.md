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
- Webclient
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Übersetzen Sie PowerPoint‑Folien mit KI mithilfe von Aspose.Slides für Android über Java. Lokalisieren Sie PPT, PPTX und ODP und erhalten Sie das Layout – schnell und entwicklerfreundlich. Probieren Sie es aus."
---

## **Aspose.Slides Präsentationsübersetzungs-API: KI-gestützte mehrsprachige Folienübersetzung**

Aspose.Slides enthält keine integrierten KI-Funktionen, integriert jedoch externe KI-Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) verwendet, um mit KI-Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) verwenden, um eine Verbindung zur OpenAI‑API herzustellen, oder Ihr eigenes [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="primary" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Service ist, daher müssen Sie ein Konto erstellen und Ihren API‑Schlüssel angeben, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mit dem integrierten [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/), wobei ein bestimmtes OpenAI‑[Modell](https://platform.openai.com/docs/models) verwendet wird.
```java
// Laden Sie eine Präsentation zum Übersetzen.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialisieren Sie SlidesAIAgent mit dem KI-Client.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Übersetzen Sie die Präsentation ins Japanische.
    aiAgent.translate(presentation, "japanese");

    // Speichern Sie die übersetzte Präsentation als PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanz und steuert deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – hauptsächlich, um wesentliche Einstellungen wie einen Proxy zu konfigurieren oder einen [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und eine höhere Leistung zu nutzen – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz übergeben.
```java
// Angenommen, Sie haben eine vorauskonfigurierte HttpURLConnection-Instanz (z.B. mit benutzerdefinierten Zeitüberschreitungen, Proxy-Einstellungen usw.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Wesentliche Vorteile**

Die Aspose.Slides Präsentationsübersetzungs‑API bietet eine KI‑gestützte Lösung zur Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Pädagoge oder Geschäftsexperte sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum – erweitert Ihre Reichweite und verbessert die Kommunikation.