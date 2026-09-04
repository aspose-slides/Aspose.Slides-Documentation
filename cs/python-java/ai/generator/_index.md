---
title: AI-poháněný vícejazyčný generátor snímků
linktitle: AI-poháněný generátor
type: docs
weight: 40
url: /cs/python-java/ai/generator/
keywords:
- vícejazyčná prezentace
- vícejazyčný snímek
- AI generátor prezentací
- AI generátor snímků
- šablona prezentace
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Vytvořte vícejazyčné prezentace z textu pomocí Aspose.Slides pro Python přes Java. Vyberte úroveň detailu obsahu, použijte šablonu a exportujte do PowerPointu nebo PDF."
---
## **Úvod**

Generátor AI prezentací v Aspose.Slides pro Python přes Java vytváří prezentace na základě popisu tématu, souhrnů, citací nebo odrážek. Zadejte požadovaný jazyk ve svém promptu, vyberte množství obsahu a volitelně poskytněte šablonu prezentace, která určuje rozvržení a design.  
Generátor strukturuje obsah pomocí textových bloků, seznamů odrážek a tabulek. Nevytváří obrázky; můžete je po vytvoření prezentace přidat. Zkontrolujte vygenerovaný obsah a rozvržení před sdílením prezentace.

## **Jak to funguje**

[SlidesAIAgent](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesaiagent/) používá AI klienta k komunikaci s externím modelem. Níže uvedené příklady používají vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-java/aspose.slides/openaiwebclient/). Aspose.Slides zpracovává odpovědi modelu a sestavuje prezentaci, kterou můžete upravit nebo exportovat.  

Použijte [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidesaiagent/#generatePresentation) s textovým popisem a hodnotou [PresentationContentAmountType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationcontentamounttype/). Přetížení s třetím argumentem přijímá prezentaci, kterou lze použít jako návrhovou šablonu.

## **Požadavky**

Následujte [Installation](/slides/cs/python-java/installation/) pro nastavení Pythonu, Javy, JPype a Aspose.Slides. Před spuštěním příkladů nastavte proměnné prostředí `OPENAI_API_KEY` a `OPENAI_MODEL`. Vyberte model podporovaný vestavěným klientem a dostupný ve vašem API účtu.

{{% alert color="info" title="Note" %}}
Služba AI vyžaduje připojení k internetu a samostatný přístup k API. Prompt se odesílá do nakonfigurované služby a poplatky za její používání se uplatňují nezávisle na vaší licenci Aspose.Slides.
{{% /alert %}}

Každý příklad spustí JVM pouze tehdy, pokud již neběží, a ponechá jej k dispozici pro další operace. Viz [JVM lifecycle guidance](/slides/cs/python-java/limitations-and-api-differences/#import-the-library) při úpravě kódu pro notebooky.

## **Vytvořit prezentaci z textu**

Tento příklad vytvoří anglickou prezentaci s [Medium](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationcontentamounttype/#Medium) množstvím obsahu a uloží ji jako soubor PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Vytvořit prezentaci pomocí šablony**

Umístěte `masterPresentation.pptx` do pracovního adresáře. Tento příklad ho načte pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), vytvoří španělskou prezentaci s [Detailed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationcontentamounttype/#Detailed) obsahem a exportuje ji do PDF. Šablona i vygenerovaná prezentace jsou uvolněny, i když generování nebo ukládání selže.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Pokud potřebujete nastavit proxy nebo časové limity připojení, viz [Configure the HTTP Connection](/slides/cs/python-java/ai/translator/#configure-the-http-connection). Výsledného klienta můžete také předat generátoru.

## **Klíčové výhody**

Generování může snížit počáteční tvorbu materiálů pro školení, přehledy produktů, klientské zprávy a interní prezentace. Prompt určuje téma a jazyk, zatímco šablona vám umožní znovu použít existující design prezentace.

## **Často kladené otázky**

**Jak mohu kontrolovat délku vygenerované prezentace?**

Vyberte [Brief](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationcontentamounttype/#Medium) nebo [Detailed](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Tato nastavení ovlivňují jak počet snímků, tak úroveň detailu na každém snímku; neurčují přesný počet snímků.

**Mohu generovat snímky v jiném jazyce?**

Ano. Uveďte požadovaný jazyk v textovém popisu. Výsledek závisí na jazykových schopnostech zvoleného modelu.

**Mohu zachovat editovatelnou verzi při exportu do PDF?**

Ano. Před uvolněním vygenerované prezentace ji také uložte jako PPTX pomocí postupu v prvním příkladu.