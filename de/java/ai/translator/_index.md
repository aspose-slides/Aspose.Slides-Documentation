---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/java/ai/translator/
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
- Java
- Aspose.Slides
description: "PowerPoint-Folien mit KI über Aspose.Slides für Java übersetzen. PPT, PPTX und ODP lokalisieren und dabei das Layout beibehalten - schnell und entwicklerfreundlich. Probieren Sie es aus."
---

## **Aspose.Slides Presentation Translation API: KI‑gestützte mehrsprachige Folienübersetzung**

Aspose.Slides ist ein leistungsstarkes API zur programmatischen Verwaltung von PowerPoint‑Präsentationen. Neben dem Erstellen, Bearbeiten und Konvertieren von Folien bietet es KI‑gesteuerte Funktionen – zum Beispiel die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Fähigkeiten, sondern integriert externe KI‑Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) verwenden, um sich mit der OpenAI‑API zu verbinden, oder Ihre eigene Implementierung des [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) bereitstellen, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="primary" %}}
Hinweis: Die OpenAI‑API ist ein kostenpflichtiger Dienst, daher müssen Sie ein Konto erstellen und Ihren API‑Schlüssel angeben, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mithilfe des integrierten [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) und eines angegebenen OpenAI‑[Modells](https://platform.openai.com/docs/models).
```java
// Lade eine Präsentation zum Übersetzen.
Presentation presentation = new Presentation("sample.pptx");

// Erstelle einen KI-Client mit OpenAIWebClient, wobei du dein Modell und den API-Schlüssel angibst.
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


Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) seine eigene interne Instanz von [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) und übernimmt deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – insbesondere, um wichtige Einstellungen wie einen Proxy zu konfigurieren oder einen [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und eine höhere Leistung zu nutzen – können Sie beim Erstellen des [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz übergeben.
```java
// Angenommen, Sie haben eine vordefinierte HttpURLConnection-Instanz (z.B. mit benutzerdefinierten Timeouts, Proxy-Einstellungen usw.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **Wesentliche Vorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung für die Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Dozent oder Geschäftsprofi sind – diese API ermöglicht es Ihnen, ansprechende, lokalisierte Präsentationen für ein globales Publikum zu erstellen, Ihre Reichweite zu erweitern und die Kommunikation zu verbessern.