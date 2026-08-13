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
- Web-Client
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Übersetzen Sie PowerPoint‑Folien mit KI mittels Aspose.Slides für Java. Lokalisieren Sie PPT, PPTX und ODP und erhalten Sie das Layout dabei – schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsstarke API zur programmatischen Verwaltung von PowerPoint-Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI-gesteuerte Funktionen – beispielsweise die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI-Funktionen, integriert jedoch externe KI-Modelle über das Internet. Diese Funktionalität wird über die [SlidesAIAgent](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesaiagent/)‑Klasse bereitgestellt, die eine Implementierung des [IAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaiwebclient/)‑Interfaces verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/openaiwebclient/) verwenden, um eine Verbindung zur OpenAI‑API herzustellen, oder Ihren eigenen [IAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/iaiwebclient/) implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzte Inhalte intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung beibehalten werden.

{{% alert color="info" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint-Präsentation ins Japanische mithilfe des integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/openaiwebclient/) mit einem angegebenen OpenAI‑[Modell](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Lädt eine Präsentation zum Übersetzen.
Presentation presentation = new Presentation("sample.pptx");

// Erstellt einen KI-Client mit OpenAIWebClient und gibt Ihr Modell sowie Ihren API-Schlüssel an.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialisiert SlidesAIAgent mit dem KI-Client.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Übersetzt die Präsentation ins Japanische.
    aiAgent.translate(presentation, "japanese");

    // Speichert die übersetzte Präsentation als PDF.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanz und übernimmt deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – vor allem, um wesentliche Einstellungen wie einen Proxy zu konfigurieren oder um eine [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) oder einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und eine höhere Leistung zu nutzen – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/de/java/com.aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz bereitstellen.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// Konfigurieren Sie selbst eine HttpURLConnection-Instanz (benutzerdefinierte Zeitüberschreitungen, Proxy-Einstellungen usw.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Wesentliche Vorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung zum Erstellen mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und reduziert Fehler im Vergleich zu manuellen Arbeitsabläufen. Unabhängig davon, ob Sie Entwickler, Pädagoge oder Business‑Professional sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum – erweitert Ihre Reichweite und verbessert die Kommunikation.