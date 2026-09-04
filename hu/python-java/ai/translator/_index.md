---
title: AI-alapú prezentációfordító
linktitle: AI-alapú fordító
type: docs
weight: 20
url: /hu/python-java/ai/translator/
keywords:
- AI prezentációfordító
- AI diafordító
- többnyelvű prezentáció
- prezentációfordítás
- diafordítás
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Prezentációkat AI segítségével fordít az Aspose.Slides for Python via Java használatával. A dia szövegét lokalizálja, és a lefordított prezentációt PowerPoint vagy PDF formátumban menti."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java AI prezentációfordítási API-t biztosít a diák tartalmának lokalizálásához. Fordíts le egy meglévő prezentációt egy megadott nyelvre, majd mentse a lefordított verziót a közönségnek szükséges formátumban.

## **Hogyan működik**

[SlidesAIAgent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesaiagent/) kommunikál egy külső AI szolgáltatással egy AI kliensen keresztül. A példák a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/python-java/aspose.slides/openaiwebclient/) használják.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesaiagent/#translate) frissíti a neki átadott prezentációt. Az Aspose.Slides feldolgozza az AI válaszokat, és lecseréli a dia szövegét, miközben megtartja a meglévő elrendezést és formázást. Nézd át az eredményt: a lefordított szöveg hosszabb lehet az eredetinél, és elrendezési módosításokra lehet szükség.

## **Előfeltételek**

Kövesd a [Installation](/slides/hu/python-java/installation/) útmutatót a könyvtár és a futási környezet beállításához. Állítsd be az `OPENAI_API_KEY` és `OPENAI_MODEL` környezeti változókat a példák futtatása előtt. Válassz egy a beépített kliens által támogatott és az API‑fiókodban elérhető modellt.

{{% alert color="info" title="Note" %}}
A fordításhoz internetkapcsolat szükséges, és a prezentáció szövegét a konfigurált AI szolgáltatáshoz továbbítja. Az API‑hozzáférés és a használati díjak különállóak az Aspose.Slides licencedtől.
{{% /alert %}}

A példák egy aktív JVM‑et újrahasználják, vagy szükség esetén elindítják azt. Lásd a [JVM lifecycle guidance](/slides/hu/python-java/limitations-and-api-differences/#import-the-library) szakaszt a notebook használatáról.

## **Prezentáció lefordítása**

Helyezd a `sample.pptx` fájlt a munkakönyvtárba. Ez a példa a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztállyal tölti be, japán nyelvre fordítja a szöveget, majd PDF‑ként menti az eredményt. A prezentációt felszabadítja, és az AI klienst is bezárja, még akkor is, ha egy művelet hibával jár.

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

## **HTTP kapcsolat konfigurálása**

Alapértelmezés szerint a [OpenAIWebClient](https://reference.aspose.com/slides/hu/python-java/aspose.slides/openaiwebclient/) belsőleg kezeli a HTTP kapcsolatot. A négyargumentumos konstruktor elfogad egy külsőleg kezelt Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) objektumot is. Használd ezt a túlterhelést, ha proxy‑t vagy kapcsolat‑időkorlátokat kell beállítanod.

Az alábbi példa Java HTTP proxy‑t hoz létre a [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) osztállyal, és a [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) segítségével nyit kapcsolatot. Cseréld le a `proxy.example.com` nevet és a portot a saját proxy beállításaidra. A kapcsolatot közvetlenül a JPype‑on keresztül adjuk át; Python HTTP munkamenet nem használható helyette.

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

## **Fő előnyök**

Az automatizált fordítás segít többnyelvű képzési anyagok, termékprezentációk és ügyfélriportok előkészítésében, miközben újrahasználja a meglévő dia‑designt. Menthetsz szerkeszthető prezentációt további felülvizsgálatra, vagy exportálhatsz PDF‑et terjesztéshez.

## **GYIK**

**Létrehoz a fordítás egy külön prezentáció objektumot?**

Nem. A [SlidesAIAgent.translate](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesaiagent/#translate) módosítja a megadott prezentációt. Mentsd el egy új fájlnéven, hogy az eredeti fájl változatlan maradjon.

**Hogyan adom meg a célnyelvet?**

Add meg a nyelv nevét, például `"Japanese"` vagy `"Spanish"` a második argumentumként. A fordítás minősége és a nyelvi lefedettség a kiválasztott modellen múlik.

**Fordíthatok proxy használata nélkül?**

Igen. Használd a háromargumentumos kliens‑konstruktort, amely az első példában látható. Az egyéni kapcsolati példa csak akkor szükséges, ha az alkalmazásod kifejezett kapcsolat‑beállításokat igényel.