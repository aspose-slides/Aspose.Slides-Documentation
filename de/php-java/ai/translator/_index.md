---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/php-java/ai/translator/
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
- PHP
- Aspose.Slides
description: "Übersetzen Sie PowerPoint-Folien mit KI mithilfe von Aspose.Slides für PHP. Lokalisieren Sie PPT, PPTX und ODP, wobei das Layout erhalten bleibt - schnell und entwicklerfreundlich. Probieren Sie es aus."
---
## **Einleitung**

Aspose.Slides ist eine leistungsstarke API zur programmgesteuerten Verwaltung von PowerPoint‑Präsentationen. Zusätzlich zum Erstellen, Bearbeiten und Konvertieren von Folien bietet sie KI‑gestützte Funktionen – beispielsweise die Presentation Translation API für mehrsprachige Folieninhalte.

## **Wie es funktioniert**

Aspose.Slides enthält keine integrierten KI‑Funktionen, sondern integriert externe KI‑Modelle über das Internet. Diese Funktionalität wird über die Klasse [SlidesAIAgent](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesaiagent/) bereitgestellt, um mit KI‑Diensten zu kommunizieren.

Sie können den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/php-java/aspose.slides/openaiwebclient/) verwenden, um sich mit der OpenAI‑API zu verbinden.

Aspose.Slides übernimmt die Kommunikation, analysiert die KI‑Antworten und fügt übersetzte Inhalte intelligent ein, wobei das ursprüngliche Folienlayout und die Formatierung beibehalten werden.

{{% alert color="info" title="Hinweis" %}}
Beachten Sie, dass die OpenAI‑API ein kostenpflichtiger Dienst ist, sodass Sie ein Konto erstellen und Ihren API‑Schlüssel angeben müssen, wenn Sie den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/php-java/aspose.slides/openaiwebclient/) verwenden.
{{% /alert %}}

## **Beispiel**

In diesem Beispiel übersetzen wir eine PowerPoint‑Präsentation ins Japanische, indem wir den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/php-java/aspose.slides/openaiwebclient/) mit einem angegebenen OpenAI-[Modell](https://platform.openai.com/docs/models) verwenden.

```php
// Lade eine Präsentation zum Übersetzen.
$presentation = new Presentation("sample.pptx");

// Erstelle einen KI-Client mit OpenAIWebClient und gib dein Modell sowie den API-Schlüssel an.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Initialisiere SlidesAIAgent mit dem KI-Client.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Übersetze die Präsentation ins Japanische.
    $aiAgent->translate($presentation, "japanese");

    // Speichere die übersetzte Präsentation als PDF.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Standardmäßig erstellt und verwaltet der integrierte [OpenAIWebClient](https://reference.aspose.com/slides/de/php-java/aspose.slides/openaiwebclient/) seine eigene interne [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-Instanz und kümmert sich automatisch um deren Lebenszyklus. Wenn Sie jedoch die [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) selbst verwalten möchten – hauptsächlich, um wesentliche Einstellungen wie einen Proxy zu konfigurieren oder um eine [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) bzw. einen anderen [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) für ein besseres Ressourcenmanagement und höhere Leistung zu verwenden – können Sie beim Erzeugen des [OpenAIWebClient](https://reference.aspose.com/slides/de/php-java/aspose.slides/openaiwebclient/) Ihre eigene `HttpURLConnection`‑Instanz bereitstellen.

```php
// Erstelle und vorkonfiguriere deine eigene HttpURLConnection-Instanz (benutzerdefinierte Timeouts, Proxy-Einstellungen usw.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Übergib die Verbindung an den KI-Client.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI Beispiel**

Sie können den Übersetzer so konfigurieren, dass er Ihre Azure OpenAI‑Bereitstellung mit dem [OpenAICompatibleWebClient](https://reference.aspose.com/slides/de/php-java/aspose.slides/openaicompatiblewebclient/) verwendet.

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Dieses Snippet demonstriert das Übersetzen einer Präsentation mit Ihrem Azure OpenAI‑Endpunkt. Ersetzen Sie die Platzhalterwerte durch Ihren Bereitstellungsnamen, API‑Schlüssel und Endpunkt‑URL.

## **Wesentliche Vorteile**

Die Aspose.Slides Presentation Translation API bietet eine KI‑gestützte Lösung zum Bereitstellen mehrsprachiger PowerPoint‑Präsentationen. Durch die Automatisierung der Übersetzung bei gleichzeitiger Beibehaltung von Layout und Design spart sie Zeit und minimiert Fehler im Vergleich zu manuellen Arbeitsabläufen. Egal, ob Sie Entwickler, Pädagoge oder Geschäftsprofi sind, ermöglicht diese API das Erstellen ansprechender, lokalisierter Präsentationen für ein globales Publikum – erweitert Ihre Reichweite und verbessert die Kommunikation.