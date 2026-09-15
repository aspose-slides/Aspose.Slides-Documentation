---
title: KI‑gestützter Präsentations‑Übersetzer
linktitle: KI‑gestützter Übersetzer
type: docs
weight: 20
url: /de/nodejs-java/ai/translator/
keywords:
- KI‑Präsentations‑Übersetzer
- KI‑Folien‑Übersetzer
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Übersetzen Sie PowerPoint‑Folien mit KI mittels Aspose.Slides für Node.js. Lokalisieren Sie PPT, PPTX und ODP und erhalten Sie das Layout—schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsstarke API zur programmgesteuerten Verwaltung von PowerPoint‑Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gestützte Funktionen – wie die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine eingebauten KI‑Funktionen, integriert jedoch externe KI‑Modelle über das Internet. Diese Funktionalität wird über die [SlidesAIAgent](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesaiagent/)‑Klasse bereitgestellt, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/openaiwebclient/) verwenden, um eine Verbindung zur OpenAI‑API herzustellen.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzten Inhalt intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung erhalten bleiben.

{{% alert color="info" title="Note" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische mithilfe des integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/openaiwebclient/) mit einem angegebenen OpenAI-[Modell](https://platform.openai.com/docs/models).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Lade eine zu übersetzende Präsentation.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialisiere SlidesAIAgent mit dem KI-Client.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Übersetze die Präsentation ins Japanische.
    aiAgent.translate(presentation, "japanese");

    // Speichere die übersetzte Präsentation als PDF.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑Instanz und behandelt deren Lebenszyklus automatisch. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – hauptsächlich um wesentliche Einstellungen wie einen Proxy zu konfigurieren oder einen [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und eine höhere Leistung zu verwenden – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz übergeben.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Erstelle und vorkonfiguriere eine HttpURLConnection-Instanz (z.B. mit benutzerdefinierten Zeitlimits, Proxy-Einstellungen usw.).
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI Beispiel**

Sie können den Übersetzer so konfigurieren, dass er Ihre Azure OpenAI‑Bereitstellung mit dem [OpenAICompatibleWebClient](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/openaicompatiblewebclient/) verwendet.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Dieses Snippet demonstriert die Übersetzung einer Präsentation mithilfe Ihres Azure OpenAI‑Endpunkts. Ersetzen Sie die Platzhalterwerte durch Ihren Bereitstellungsnamen, API‑Schlüssel und Endpunkt‑URL.

## **Wesentliche Vorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung zur Bereitstellung mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Erhaltung von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Pädagoge oder Business‑Professional sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum – erweitert Ihre Reichweite und verbessert die Kommunikation.