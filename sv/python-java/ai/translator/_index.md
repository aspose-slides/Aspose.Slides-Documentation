---
title: AI-driven presentationsöversättare
linktitle: AI-driven översättare
type: docs
weight: 20
url: /sv/python-java/ai/translator/
keywords:
- AI-presentationöversättare
- AI-bildöversättare
- flerspråkig presentation
- presentationöversättning
- bildöversättning
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Översätt presentationer med AI med hjälp av Aspose.Slides för Python via Java. Lokalisera bildtext och spara den översatta presentationen som PowerPoint eller PDF."
---
## **Introduktion**

Aspose.Slides för Python via Java tillhandahåller ett AI Presentation Translation API för lokalisering av bildspelsinnehåll. Översätt en befintlig presentation till ett specificerat språk och spara sedan den översatta versionen i det format som din publik behöver.

## **Hur det fungerar**

[SlidesAIAgent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesaiagent/) kommunicerar med en extern AI-tjänst via en AI-klient. Exemplen använder den inbyggda [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesaiagent/#translate) uppdaterar den presentation som skickas till den. Aspose.Slides behandlar AI-svaren och ersätter bildtexten samtidigt som den befintliga layouten och formateringen behålls. Granska resultatet: översatt text kan vara längre än originalet och kan kräva layoutjusteringar.

## **Förutsättningar**

Följ [Installation](/slides/sv/python-java/installation/) för att konfigurera biblioteket och dess runtime. Ställ in miljövariablerna `OPENAI_API_KEY` och `OPENAI_MODEL` innan du kör exemplen. Välj en modell som stöds av den inbyggda klienten och som är tillgänglig för ditt API‑konto.

{{% alert color="info" title="Note" %}}
Översättning kräver en internetanslutning och skickar presentationstext till den konfigurerade AI‑tjänsten. Dess API‑åtkomst och användningsavgifter är separata från din Aspose.Slides‑licens.
{{% /alert %}}

Exemplen återanvänder en aktiv JVM eller startar den om nödvändigt. Se [JVM lifecycle guidance](/slides/sv/python-java/limitations-and-api-differences/#import-the-library) för användning i notebook.

## **Översätt en presentation**

Placera `sample.pptx` i arbetskatalogen. Detta exempel laddar den med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), översätter dess text till japanska och sparar resultatet som en PDF. Det frigör presentationen och stänger AI‑klienten även om en operation misslyckas.

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

## **Konfigurera HTTP‑anslutningen**

Som standard hanterar [OpenAIWebClient](https://reference.aspose.com/slides/sv/python-java/aspose.slides/openaiwebclient/) sin HTTP‑anslutning internt. Dess fyr‑argument‑konstruktor accepterar också en externt hanterad Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Använd denna överlagring när du behöver konfigurera en proxy eller anslutningstimeouts.

Följande exempel skapar en Java HTTP‑proxy med [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) och öppnar en anslutning via [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Ersätt `proxy.example.com` och porten med dina proxy‑inställningar. Anslutningen skickas direkt genom JPype; en Python‑HTTP‑session kan inte användas i dess ställe.

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

## **Viktiga fördelar**

Automatiserad översättning hjälper till att förbereda flerspråkiga träningsmaterial, produktpresentationer och kundrapporter samtidigt som den befintliga bilddesignen återanvänds. Spara en redigerbar presentation för vidare granskning eller exportera en PDF för distribution.

## **Vanliga frågor**

**Skapar översättning ett separat presentationsobjekt?**

Nej. [SlidesAIAgent.translate](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidesaiagent/#translate) modifierar den levererade presentationen. Spara den under ett nytt filnamn för att behålla den ursprungliga filen oförändrad.

**Hur anger jag målspråket?**

Skicka språkets namn, till exempel `"Japanese"` eller `"Spanish"`, som det andra argumentet. Översättningskvalitet och språktäckning beror på den valda modellen.

**Kan jag översätta utan att använda en proxy?**

Ja. Använd den tre‑argument‑klientkonstruktor som visas i det första exemplet. Exemplet med anpassad anslutning behövs bara när din applikation kräver explicita anslutningsinställningar.