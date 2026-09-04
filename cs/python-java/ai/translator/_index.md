---
title: Prezentace překládána pomocí AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/python-java/ai/translator/
keywords:
  - AI překladač prezentací
  - AI překladač snímků
  - vícejazyková prezentace
  - překlad prezentace
  - překlad snímků
  - PowerPoint
  - OpenDocument
  - Python
  - Aspose.Slides
description: "Překládejte prezentace pomocí AI s Aspose.Slides pro Python přes Java. Lokalizujte text snímků a uložte přeloženou prezentaci jako PowerPoint nebo PDF."
---
## **Úvod**

Aspose.Slides for Python via Java poskytuje AI rozhraní pro překlad prezentací pro lokalizaci obsahu snímků. Přeložte existující prezentaci do určeného jazyka a poté uložte přeloženou verzi ve formátu, který vaše publikum potřebuje.

## **Jak to funguje**

[SlidesAIAgent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesaiagent/) komunikuje s externí AI službou prostřednictvím AI klienta. Příklady používají vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesaiagent/#translate) aktualizuje předanou prezentaci. Aspose.Slides zpracuje AI odpovědi a nahradí text ve snímcích při zachování stávajícího rozvržení a formátování. Zkontrolujte výsledek: přeložený text může být delší než originál a může vyžadovat úpravy rozvržení.

## **Požadavky**

Postupujte podle [Installation](/slides/cs/python-java/installation/) pro konfiguraci knihovny a jejího runtime. Nastavte proměnné prostředí `OPENAI_API_KEY` a `OPENAI_MODEL` před spuštěním ukázek. Vyberte model podporovaný vestavěným klientem a dostupný pro váš API účet.

{{% alert color="info" title="Poznámka" %}}
Překlad vyžaduje internetové připojení a odesílá text prezentace do nakonfigurované AI služby. Přístup k její API a poplatky za použití jsou oddělené od vaší licence Aspose.Slides.
{{% /alert %}}

Ukázky znovu používají aktivní JVM nebo jej spustí podle potřeby. Viz [JVM lifecycle guidance](/slides/cs/python-java/limitations-and-api-differences/#import-the-library) pro použití v notebooku.

## **Přeložit prezentaci**

Umístěte `sample.pptx` do pracovního adresáře. Tento příklad načte soubor pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), přeloží jeho text do japonštiny a uloží výsledek jako PDF. Uvolní prezentaci a zavře AI klienta i v případě, že operace selže.

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

## **Konfigurace HTTP připojení**

Ve výchozím nastavení [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-java/aspose.slides/openaiwebclient/) spravuje své HTTP připojení interně. Jeho konstruktor se čtyřmi argumenty také přijímá externě spravované Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Použijte toto přetížení, když potřebujete nakonfigurovat proxy nebo časové limity připojení.

Následující příklad vytvoří Java HTTP proxy pomocí [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) a otevře spojení přes [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Nahraďte `proxy.example.com` a port vašimi nastaveními proxy. Připojení je předáno přímo přes JPype; Python HTTP relaci nelze použít místo něj.

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

## **Klíčové výhody**

Automatizovaný překlad pomáhá připravovat vícejazykové školící materiály, produktové prezentace a zprávy pro klienty při zachování stávajícího designu snímků. Uložte editovatelnou prezentaci pro další revizi nebo exportujte PDF pro distribuci.

## **Často kladené otázky**

**Vytváří překlad samostatný objekt prezentace?**

Ne. [SlidesAIAgent.translate](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesaiagent/#translate) upravuje dodanou prezentaci. Uložte ji pod novým názvem souboru, abyste zachovali původní soubor nezměněný.

**Jak specifikuji cílový jazyk?**

Předávejte název jazyka, například `"Japanese"` nebo `"Spanish"`, jako druhý argument. Kvalita překladu a pokrytí jazyků závisí na vybraném modelu.

**Mohu překládat bez použití proxy?**

Ano. Použijte tříargumentový konstruktor klienta zobrazený v prvním příkladu. Příklad s vlastním připojením je potřeba jen tehdy, když vaše aplikace vyžaduje explicitní nastavení připojení.