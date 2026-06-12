---
title: AI poháněný vícejazykový generátor snímků
linktitle: AI poháněný generátor
type: docs
weight: 40
url: /cs/python-net/ai/generator/
keywords:
- vícejazyková prezentace
- vícejazykový snímek
- AI generátor prezentací
- AI generátor snímků
- funkce poháněná AI
- AI agent
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vygenerujte vícejazykové snímky z textu pomocí Aspose.Slides pro Python. Použijte svou šablonu a exportujte vylepšené sady do PowerPoint a OpenDocument. Zjistěte více."
---
## **Úvod**

Aspose.Slides představuje novou funkci poháněnou AI, Generátor prezentací, která umožňuje vývojářům automaticky vytvářet dobře strukturované PowerPoint prezentace z jednoduchých textových vstupů, jako jsou popisy témat, souhrny, citace nebo odrážky.

Uživatelé mohou upravit úroveň podrobnosti obsahu a volitelně použít vlastní šablonu prezentace k definování vizuálního designu.

V současné době Generátor AI prezentací strukturuje obsah pomocí textových bloků, seznamů s odrážkami a tabulek. Generování obrázků zatím není podporováno; obrázky lze však snadno přidat později pomocí nástrojů Aspose.Slides nebo ručně.

Výstupem je kompletní PowerPoint prezentace, kterou lze použít tak, jak je, nebo exportovat do libovolného formátu podporovaného API Aspose.Slides. I když generátor poskytuje vysoce kvalitní výsledky, může být vyžadována drobná následná úprava k splnění konkrétních požadavků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné AI modely; místo toho integruje s externími AI službami přes internet. Tuto integraci zajišťuje třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/slidesaiagent/), která používá implementaci třídy [IAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/iaiwebclient/) k komunikaci s AI modelem.

Můžete použít vestavěnou třídu [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/), která se připojuje k API OpenAI, nebo poskytnout vlastní implementaci [IAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/iaiwebclient/) pro práci s jiným poskytovatelem AI nebo jazykovým modelem. Aspose.Slides spravuje veškerou komunikaci s AI službou a zpracovává odpovědi AI k vytvoření snímků. Všimněte si, že API OpenAI je placená služba, takže při používání vestavěné [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/) je vyžadován účet a API klíč.

## **Pojďme kódovat**

### **Příklad 1**

Tento příklad ukazuje, jak vygenerovat prezentaci na téma Aspose.Slides pomocí vestavěné [OpenAIWebClient](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/openaiwebclient/).

```py
# Vytvořte instanci OpenAIWebClient, vestavěnou implementaci OpenAI webového klienta.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # Vytvořte instanci SlidesAIAgent, která poskytuje přístup k funkcím poháněným AI.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definujte instrukci pro generování prezentace.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Vygenerujte prezentaci se středním množstvím obsahu na základě instrukce.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Uložte vygenerovanou prezentaci na lokální disk jako soubor PowerPoint (.pptx).
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Příklad 2**

Následující příklad demonstruje přetížení metody [generate_presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation). V tomto případě je použita `master presentation` uživatele.

```py
# Předá HttpClient konstruktoru OpenAIWebClient.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # Vytvoří instanci SlidesAIAgent.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Definuje instrukci pro generování prezentace.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Načte hlavní prezentaci z lokálního disku pro použití jako šablonu designu.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Vygeneruje podrobnou prezentaci pomocí instrukce a hlavní šablony.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Uloží vygenerovanou prezentaci jako PDF.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Klíčové výhody**

Nový Generátor AI prezentací v Aspose.Slides poskytuje rychlý a flexibilní způsob, jak vytvářet strukturované sady snímků z jednoduchých textových výzev. S podporou vlastních šablon jej lze snadno integrovat do široké škály aplikací.

Typické případy použití zahrnují tvorbu marketingových prezentací, vzdělávacích materiálů, zpráv pro klienty a interních sad snímků. Ačkoli generování obrázků zatím není podporováno, nástroj již poskytuje pevný základ pro automatizaci tvorby prezentací, přičemž v budoucnu lze očekávat další vylepšení.