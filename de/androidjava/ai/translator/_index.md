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
description: "Übersetzen Sie PowerPoint-Folien mit KI unter Verwendung von Aspose.Slides für Android via Java. Lokalisieren Sie PPT, PPTX und ODP und erhalten Sie das Layout - schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsfähige API zum programmgesteuerten Verwalten von PowerPoint-Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI-gesteuerte Funktionen – wie die Presentation Translation API für mehrsprachige Folieninhalte.

## **So funktioniert es**

Aspose.Slides enthält keine integrierten KI-Funktionen, sondern integriert externe KI-Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesaiagent/) bereitgestellt, die eine Implementierung des Interfaces [IAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaiwebclient/) verwendet, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) verwenden, um eine Verbindung zur OpenAI‑API herzustellen, oder Ihr eigenes [IAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaiwebclient/) implementieren, um einen anderen KI‑Anbieter oder ein anderes Sprachmodell zu nutzen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt den übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="info" title="Hinweis" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mit dem integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) unter Verwendung eines angegebenen OpenAI‑[Modells](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Laden Sie eine Präsentation zum Übersetzen.
Presentation presentation = new Presentation("sample.pptx");

// Erstellen Sie einen KI-Client mit OpenAIWebClient und geben Sie Ihr Modell und Ihren API‑Schlüssel an.
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

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanz und steuert deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – vor allem, um wichtige Einstellungen wie einen Proxy zu konfigurieren oder um eine [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) oder einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und eine höhere Leistung zu nutzen – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz bereitstellen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // Konfigurieren Sie eine HttpURLConnection-Instanz selbst (z. B. mit benutzerdefinierten Zeitüberschreitungen, Proxy-Einstellungen usw.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Übergeben Sie die Verbindung an den OpenAIWebClient-Konstruktor.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI Beispiel**

Sie können den Übersetzer so konfigurieren, dass er Ihre Azure OpenAI‑Bereitstellung mit dem [OpenAICompatibleWebClient](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/openaicompatiblewebclient/) verwendet.

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Dieses Snippet demonstriert das Übersetzen einer Präsentation mithilfe Ihres Azure OpenAI‑Endpunkts. Ersetzen Sie die Platzhalterwerte durch Ihren Bereitstellungsnamen, Ihren API‑Schlüssel und die Endpunkt‑URL.

## **Hauptvorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung zum Bereitstellen mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Pädagoge oder Business‑Profi sind, ermöglicht diese API Ihnen, ansprechende, lokalisierte Präsentationen für ein globales Publikum zu erstellen – Ihre Reichweite zu erweitern und die Kommunikation zu verbessern.