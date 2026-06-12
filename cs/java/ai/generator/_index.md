---
title: "Vícejazyčný generátor snímků s podporou AI"
linktitle: "Generátor s podporou AI"
type: docs
weight: 40
url: /cs/java/ai/generator/
keywords:
- "vícejazyčná prezentace"
- "vícejazyčný snímek"
- "generátor AI prezentací"
- "generátor AI snímků"
- "funkce AI s podporou"
- "AI agent"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Java"
- "Aspose.Slides"
description: "Vytvořte vícejazyčné snímky z textu pomocí Aspose.Slides pro Java. Použijte svou šablonu a exportujte upravené sady do PowerPointu a OpenDocumentu. Další informace."
---
## **Úvod**

Aspose.Slides představuje novou funkci využívající umělou inteligenci, Presentation Generator, která umožňuje vývojářům automaticky vytvářet dobře strukturované prezentace PowerPointu z jednoduchých textových vstupů, jako jsou popisy témat, shrnutí, citace nebo odrážky.

Uživatelé mohou upravit úroveň podrobností obsahu a volitelně použít vlastní šablonu prezentace k definování vizuálního designu.

V současné době AI Presentation Generator strukturuje obsah pomocí textových bloků, seznamů s odrážkami a tabulek. Generování obrázků zatím není podporováno; obrázky lze však snadno přidat později pomocí nástrojů Aspose.Slides nebo ručně.

Výstupem je kompletní prezentace PowerPoint, kterou lze použít tak, jak je, nebo exportovat do libovolného formátu podporovaného API Aspose.Slides. Přestože generátor produkuje vysoce kvalitní výsledky, může být vyžadována menší následná úprava k splnění konkrétních požadavků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné modely AI; místo toho integruje s externími AI službami přes internet. Tuto integraci zajišťuje třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro komunikaci s AI modelem.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/), který se připojuje k API OpenAI, nebo poskytnout vlastní implementaci [IAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iaiwebclient/) pro práci s jiným poskytovatelem AI nebo jazykovým modelem. Aspose.Slides spravuje veškerou komunikaci s AI službou a zpracovává odpovědi AI pro generování snímků. Všimněte si, že API OpenAI je placená služba, takže při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) je nutný účet a API klíč.

## **Pojďme kódovat**

### **Příklad 1**

Tento příklad ukazuje, jak vygenerovat prezentaci na téma Aspose.Slides pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/).

```java
// Vytvořte instanci OpenAIWebClient, vestavěnou implementaci OpenAI webového klienta.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Vytvořte instanci SlidesAIAgent, která poskytuje přístup k funkcím s podporou AI.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definujte instrukci pro generování prezentace.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Vygenerujte prezentaci se středním množstvím obsahu na základě instrukce.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Uložte vygenerovanou prezentaci na lokální disk jako soubor PowerPoint (.pptx).
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Příklad 2**

Následující příklad demonstruje přetížení metody [generatePresentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-). V tomto případě je použita externě spravovaná instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) a `master presentation` uživatele.

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) vytvoří a spravuje vlastní interní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) a automaticky řídí její životní cyklus. Pokud však upřednostňujete spravovat [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) sami – například při používání [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) nebo [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/openaiwebclient/) poskytnout vlastní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html).

```java
// Předávejte HttpURLConnection do konstruktoru OpenAIWebClient.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Vytvořte instanci SlidesAIAgent.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definujte instrukci pro generování prezentace.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Načtěte hlavní prezentaci z lokálního disku k použití jako šablona designu.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Vygenerujte podrobnou prezentaci pomocí instrukce a hlavní šablony.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Uložte vygenerovanou prezentaci jako PDF.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Klíčové výhody**

Nový AI Presentation Generator v Aspose.Slides poskytuje rychlý a flexibilní způsob, jak vytvořit strukturované sady snímků z jednoduchých textových výzev. S podporou vlastních šablon a externě spravovaných instancí [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) lze snadno integrovat do široké škály aplikací.

Typické případy použití zahrnují vytváření marketingových prezentací, vzdělávacích materiálů, klientských zpráv a interních sad snímků. I když generování obrázků zatím není podporováno, nástroj již nabízí silný základ pro automatizaci tvorby prezentací a v budoucnu se očekávají další vylepšení.