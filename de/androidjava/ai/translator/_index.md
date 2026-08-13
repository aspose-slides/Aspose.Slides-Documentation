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
description: "Übersetzen Sie PowerPoint-Folien mit KI mithilfe von Aspose.Slides für Android über Java. Lokalisieren Sie PPT, PPTX und ODP, während das Layout erhalten bleibt - schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsstarke API zur programmgesteuerten Verwaltung von PowerPoint‑Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gestützte Funktionen – beispielsweise die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Funktionen, sondern integriert externe KI‑Modelle über das Internet. Diese Funktionalität wird über die [SlidesAIAgent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesaiagent/)‑Klasse bereitgestellt, die eine Implementierung des [IAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaiwebclient/)‑Interfaces verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) verwenden, um sich mit der API von OpenAI zu verbinden, oder Ihren eigenen [IAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaiwebclient/) implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="info" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mithilfe des integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) mit einem angegebenen OpenAI‑[model](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Lade eine Präsentation zum Übersetzen.
Presentation presentation = new Presentation("sample.pptx");

// Erstelle einen KI-Client mit OpenAIWebClient und gib dein Modell und deinen API-Schlüssel an.
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

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑Instanz und übernimmt deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – etwa um wesentliche Einstellungen wie einen Proxy zu konfigurieren oder einen [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und höhere Leistung zu verwenden – können Sie Ihre eigene `HttpURLConnection`‑Instanz beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) bereitstellen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Konfiguriere eine HttpURLConnection-Instanz selbst (z.B. mit benutzerdefinierten Zeitlimits, Proxy-Einstellungen usw.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Übergib die Verbindung dem OpenAIWebClient-Konstruktor.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Hauptvorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung für die Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die automatisierte Übersetzung bei gleichzeitiger Wahrung von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Workflows. Egal, ob Sie Entwickler, Dozent oder Geschäftsprofi sind – diese API ermöglicht es Ihnen, ansprechende, lokalisierte Präsentationen für ein globales Publikum zu erstellen, Ihre Reichweite zu erweitern und die Kommunikation zu verbessern.