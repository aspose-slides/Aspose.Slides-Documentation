---
title: Traduttore di presentazioni alimentato da IA
linktitle: Traduttore alimentato da IA
type: docs
weight: 20
url: /it/python-java/ai/translator/
keywords:
- Traduttore di presentazioni IA
- Traduttore di diapositive IA
- Presentazione multilingue
- Traduzione di presentazioni
- Traduzione di diapositive
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Traduci le presentazioni con l'IA usando Aspose.Slides per Python via Java. Localizza il testo delle diapositive e salva la presentazione tradotta come PowerPoint o PDF."
---
## **Introduzione**

Aspose.Slides per Python via Java offre un'API di traduzione AI per presentazioni per la localizzazione del contenuto delle diapositive. Traduci una presentazione esistente in una lingua specificata, quindi salva la versione tradotta nel formato di cui ha bisogno il tuo pubblico.

## **Come funziona**

[SlidesAIAgent](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesaiagent/) comunica con un servizio AI esterno tramite un client AI. Gli esempi utilizzano il client integrato [OpenAIWebClient](https://reference.aspose.com/slides/it/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesaiagent/#translate) aggiorna la presentazione passata. Aspose.Slides elabora le risposte AI e sostituisce il testo delle diapositive mantenendo il layout e la formattazione esistenti. Controlla il risultato: il testo tradotto può essere più lungo dell'originale e richiedere aggiustamenti del layout.

## **Prerequisiti**

Segui [Installation](/slides/it/python-java/installation/) per configurare la libreria e il suo runtime. Imposta le variabili d'ambiente `OPENAI_API_KEY` e `OPENAI_MODEL` prima di eseguire gli esempi. Scegli un modello supportato dal client integrato e disponibile per il tuo account API.

{{% alert color="info" title="Note" %}}
La traduzione richiede una connessione a Internet e invia il testo della presentazione al servizio AI configurato. L'accesso all'API e le tariffe di utilizzo sono separate dalla licenza di Aspose.Slides.
{{% /alert %}}

Gli esempi riutilizzano una JVM attiva o la avviano se necessario. Consulta [JVM lifecycle guidance](/slides/it/python-java/limitations-and-api-differences/#import-the-library) per l'uso nei notebook.

## **Traduci una presentazione**

Posiziona `sample.pptx` nella directory di lavoro. Questo esempio lo carica con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), traduce il suo testo in Japanese e salva il risultato come PDF. Rilascia la presentazione e chiude il client AI anche se un'operazione fallisce.

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

## **Configura la connessione HTTP**

Per impostazione predefinita, [OpenAIWebClient](https://reference.aspose.com/slides/it/python-java/aspose.slides/openaiwebclient/) gestisce internamente la sua connessione HTTP. Il costruttore a quattro argomenti accetta anche un Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) gestito esternamente. Usa questo overload quando devi configurare un proxy o i timeout della connessione.

L'esempio seguente crea un proxy HTTP Java con [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) e apre una connessione tramite [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Sostituisci `proxy.example.com` e la porta con le impostazioni del tuo proxy. La connessione viene passata direttamente tramite JPype; non è possibile utilizzare una sessione HTTP Python al suo posto.

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

## **Vantaggi principali**

La traduzione automatica aiuta a preparare materiali di formazione multilingue, presentazioni di prodotto e report per i clienti, riutilizzando il design della diapositiva esistente. Salva una presentazione modificabile per ulteriori revisioni o esporta un PDF per la distribuzione.

## **FAQ**

**La traduzione crea un oggetto presentazione separato?**

No. [SlidesAIAgent.translate](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesaiagent/#translate) modifica la presentazione fornita. Salvala con un nuovo nome file per mantenere invariato il file originale.

**Come specifico la lingua di destinazione?**

Passa il nome della lingua, come `"Japanese"` o `"Spanish"`, come secondo argomento. La qualità della traduzione e la copertura linguistica dipendono dal modello selezionato.

**Posso tradurre senza usare un proxy?**

Sì. Usa il costruttore del client a tre argomenti mostrato nel primo esempio. L'esempio di connessione personalizzata è necessario solo quando la tua applicazione richiede impostazioni di connessione esplicite.