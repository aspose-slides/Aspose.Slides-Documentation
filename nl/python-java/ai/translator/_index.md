---
title: AI-aangedreven presentatietranslator
linktitle: AI-aangedreven vertaler
type: docs
weight: 20
url: /nl/python-java/ai/translator/
keywords:
- AI-presentatietranslator
- AI-slidevertaler
- meertalige presentatie
- presentatievertaling
- slidevertaling
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Vertaal presentaties met AI met behulp van Aspose.Slides voor Python via Java. Lokaliseer slide-tekst en sla de vertaalde presentatie op als PowerPoint of PDF."
---
## **Introductie**

Aspose.Slides for Python via Java biedt een AI‑presentatievertalings‑API voor het lokaliseren van slide‑inhoud. Vertaal een bestaande presentatie naar een opgegeven taal en sla de vertaalde versie vervolgens op in het formaat dat uw publiek nodig heeft.

## **Hoe het werkt**

[SlidesAIAgent](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesaiagent/) communiceert met een externe AI‑service via een AI‑client. De voorbeelden gebruiken de ingebouwde [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesaiagent/#translate) werkt de aan hem doorgegeven presentatie bij. Aspose.Slides verwerkt de AI‑reacties en vervangt de slide‑tekst terwijl de bestaande lay‑out en opmaak behouden blijven. Bekijk het resultaat: vertaalde tekst kan langer zijn dan het origineel en mogelijk lay‑out‑aanpassingen vereisen.

## **Voorvereisten**

Volg [Installation](/slides/nl/python-java/installation/) om de bibliotheek en de runtime te configureren. Stel de omgevingsvariabelen `OPENAI_API_KEY` en `OPENAI_MODEL` in voordat u de voorbeelden uitvoert. Kies een model dat wordt ondersteund door de ingebouwde client en beschikbaar is voor uw API‑account.

{{% alert color="info" title="Note" %}}
Vertaling vereist een internetverbinding en stuurt de presentatie‑tekst naar de geconfigureerde AI‑service. De API‑toegang en gebruikskosten zijn gescheiden van uw Aspose.Slides‑licentie.
{{% /alert %}}

De voorbeelden hergebruiken een actieve JVM of starten deze indien nodig. Zie [JVM lifecycle guidance](/slides/nl/python-java/limitations-and-api-differences/#import-the-library) voor notebook‑gebruik.

## **Vertaal een presentatie**

Plaats `sample.pptx` in de werkmap. Dit voorbeeld laadt het met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/), vertaalt de tekst naar Japans en slaat het resultaat op als een PDF. Het maakt de presentatie vrij en sluit de AI‑client, zelfs als een bewerking mislukt.

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

## **Configureer de HTTP‑verbinding**

Standaard beheert [OpenAIWebClient](https://reference.aspose.com/slides/nl/python-java/aspose.slides/openaiwebclient/) zijn HTTP‑verbinding intern. De vier‑argumenten‑constructor accepteert ook een extern beheerde Java‑[HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Gebruik deze overload wanneer u een proxy of verbindingstime‑outs moet configureren.

Het volgende voorbeeld maakt een Java‑HTTP‑proxy met [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) en opent een verbinding via [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Vervang `proxy.example.com` en de poort door uw proxy‑instellingen. De verbinding wordt rechtstreeks via JPype doorgegeven; een Python‑HTTPS‑sessie kan niet in de plaats hiervan worden gebruikt.

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

## **Belangrijkste voordelen**

Geautomatiseerde vertaling helpt bij het voorbereiden van meertalige trainingsmaterialen, productpresentaties en klant‑rapporten, terwijl het bestaande slide‑ontwerp wordt hergebruikt. Sla een bewerkbare presentatie op voor nadere controle of exporteer een PDF voor distributie.

## **FAQ**

**Maakt vertaling een apart presentatiewerkobject?**

Nee. [SlidesAIAgent.translate](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesaiagent/#translate) wijzigt de meegeleverde presentatie. Sla deze op onder een nieuwe bestandsnaam om het originele bestand ongewijzigd te laten.

**Hoe specificeer ik de doeltaal?**

Geef de taaltaal door, bijvoorbeeld `"Japanese"` of `"Spanish"`, als tweede argument. De vertaal‑kwaliteit en taal‑dekking hangen af van het gekozen model.

**Kan ik vertalen zonder een proxy te gebruiken?**

Ja. Gebruik de drie‑argumenten‑client‑constructor die in het eerste voorbeeld wordt getoond. Het voorbeeld met aangepaste verbinding is alleen nodig wanneer uw toepassing expliciete verbindingsinstellingen vereist.