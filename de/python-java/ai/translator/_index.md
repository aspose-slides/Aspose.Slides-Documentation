---
title: KI-gestützter Präsentationsübersetzer
linktitle: KI-gestützter Übersetzer
type: docs
weight: 20
url: /de/python-java/ai/translator/
keywords:
- KI-Präsentationsübersetzer
- KI-Folienübersetzer
- mehrsprachige Präsentation
- Präsentationsübersetzung
- Folienübersetzung
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Präsentationen mit KI mithilfe von Aspose.Slides für Python via Java übersetzen. Folientext lokalisieren und die übersetzte Präsentation als PowerPoint oder PDF speichern."
---
## **Einleitung**

Aspose.Slides for Python via Java bietet eine KI‑Präsentations‑Übersetzungs‑API zum Lokalisieren von Folieninhalten. Übersetzen Sie eine vorhandene Präsentation in eine angegebene Sprache und speichern Sie die übersetzte Version im gewünschten Format für Ihr Publikum.

## **Funktionsweise**

[SlidesAIAgent](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesaiagent/) kommuniziert über einen KI‑Client mit einem externen KI‑Dienst. Die Beispiele verwenden den integrierten [OpenAIWebClient](https://reference.aspose.com/slides/de/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesaiagent/#translate) aktualisiert die übergebene Präsentation. Aspose.Slides verarbeitet die KI‑Antworten und ersetzt den Folientext, wobei das vorhandene Layout und die Formatierung beibehalten werden. Prüfen Sie das Ergebnis: Übersetzter Text kann länger sein als der Originaltext und Layoutanpassungen erfordern.

## **Voraussetzungen**

Folgen Sie der [Installation](/slides/de/python-java/installation/), um die Bibliothek und deren Laufzeit zu konfigurieren. Setzen Sie die Umgebungsvariablen `OPENAI_API_KEY` und `OPENAI_MODEL`, bevor Sie die Beispiele ausführen. Wählen Sie ein Modell, das vom integrierten Client unterstützt wird und für Ihr API‑Konto verfügbar ist.

{{% alert color="info" title="Hinweis" %}}
Die Übersetzung erfordert eine Internetverbindung und sendet den Präsentationstext an den konfigurierten KI‑Dienst. Der API‑Zugriff und die Nutzungsgebühren sind separat von Ihrer Aspose.Slides‑Lizenz.
{{% /alert %}}

Die Beispiele verwenden eine bereits aktive JVM oder starten sie bei Bedarf. Siehe die [JVM‑Lebenszyklus‑Hinweise](/slides/de/python-java/limitations-and-api-differences/#import-the-library) für die Verwendung in Notebooks.

## **Präsentation übersetzen**

Platzieren Sie `sample.pptx` im Arbeitsverzeichnis. Dieses Beispiel lädt sie mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), übersetzt den Text ins Japanische und speichert das Ergebnis als PDF. Es gibt die Präsentation frei und schließt den KI‑Client, selbst wenn ein Vorgang fehlschlägt.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **HTTP‑Verbindung konfigurieren**

Standardmäßig verwaltet [OpenAIWebClient](https://reference.aspose.com/slides/de/python-java/aspose.slides/openaiwebclient/) seine HTTP‑Verbindung intern. Der Konstruktor mit vier Argumenten akzeptiert außerdem ein extern verwaltetes Java‑[HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Verwenden Sie diese Überladung, wenn Sie einen Proxy oder Verbindungs‑Timeouts konfigurieren müssen.

Das folgende Beispiel erstellt einen Java‑HTTP‑Proxy mit [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) und öffnet eine Verbindung über [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Ersetzen Sie `proxy.example.com` und den Port durch Ihre Proxy‑Einstellungen. Die Verbindung wird direkt über JPype übergeben; eine Python‑HTTP‑Session kann hier nicht verwendet werden.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Wesentliche Vorteile**

Automatisierte Übersetzung hilft beim Erstellen mehrsprachiger Schulungsunterlagen, Produktpräsentationen und Kundenberichte, während das vorhandene Foliendesign wiederverwendet wird. Speichern Sie eine bearbeitbare Präsentation für weitere Überprüfungen oder exportieren Sie ein PDF zur Verteilung.

## **FAQ**

**Erstellt die Übersetzung ein separates Präsentations‑Objekt?**

Nein. [SlidesAIAgent.translate](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesaiagent/#translate) ändert die bereitgestellte Präsentation. Speichern Sie sie unter einem neuen Dateinamen, um die Originaldatei unverändert zu lassen.

**Wie gebe ich die Zielsprache an?**

Übergeben Sie den Sprachnamen, z. B. `"Japanese"` oder `"Spanish"`, als zweites Argument. Die Übersetzungsqualität und der Sprachumfang hängen vom gewählten Modell ab.

**Kann ich ohne Proxy übersetzen?**

Ja. Verwenden Sie den dreistelligen Client‑Konstruktor aus dem ersten Beispiel. Das benutzerdefinierte Verbindungsbeispiel ist nur notwendig, wenn Ihre Anwendung explizite Verbindungseinstellungen erfordert.