---
title: Generátor multijazykových snímků poháněný umělou inteligencí
linktitle: AI-poháněný generátor
type: docs
weight: 40
url: /cs/nodejs-java/ai/generator/
keywords:
- multijazyková prezentace
- multijazykový snímek
- AI generátor prezentací
- AI generátor snímků
- funkce poháněná AI
- AI agent
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte multijazykové snímky z textu pomocí Aspose.Slides pro Node.js. Použijte svou šablonu a exportujte vylepšené sady do PowerPointu a OpenDocumentu. Zjistěte více."
---
## **Úvod**

Aspose.Slides představuje novou funkci poháněnou AI, nazvanou Presentation Generator, která umožňuje vývojářům automaticky vytvářet dobře strukturované prezentace PowerPoint z jednoduchých textových vstupů, jako jsou popisy témat, souhrny, citace nebo odrážky.

Uživatelé mohou nastavit úroveň podrobností obsahu a volitelně použít vlastní šablonu prezentace k definování vizuálního designu.

V současné době AI Presentation Generator strukturuje obsah pomocí textových bloků, odrážkových seznamů a tabulek. Generování obrázků ještě není podporováno; obrázky lze však snadno přidat později pomocí nástrojů Aspose.Slides nebo ručně.

Výstupem je kompletní prezentace PowerPoint, kterou lze použít tak, jak je, nebo exportovat do libovolného formátu podporovaného API Aspose.Slides. I když generátor poskytuje vysoce kvalitní výsledky, může být nutná drobná následná úprava pro splnění konkrétních požadavků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné AI modely; místo toho integruje s externími AI službami přes internet. Tato integrace je zajištěna třídou [SlidesAIAgent](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesaiagent/).

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/), který se připojuje k API OpenAI. Aspose.Slides spravuje veškerou komunikaci s AI službou a zpracovává odpovědi AI pro generování snímků. Všimněte si, že API OpenAI je placená služba, takže při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) je vyžadován účet a API klíč.

## **Pojďme kódovat**

### **Příklad 1**

Tento příklad ukazuje, jak vygenerovat prezentaci na téma Aspose.Slides pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/).

```js
// Vytvořte instanci OpenAIWebClient, vestavěné implementace OpenAI webového klienta.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Vytvořte instanci SlidesAIAgent, která poskytuje přístup k funkcím poháněným AI.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definujte pokyn pro generování prezentace.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Vygenerujte prezentaci se středním množstvím obsahu na základě pokynu.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Uložte vygenerovanou prezentaci na lokální disk jako soubor PowerPoint (.pptx) file.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Příklad 2**

Následující příklad ukazuje přetížení metody [generatePresentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation). V tomto případě je použita externě spravovaná instance [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) a `master presentation` uživatele.

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) vytváří a spravuje vlastní vnitřní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html), kterou automaticky řídí během životního cyklu. Pokud však chcete [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) spravovat sami – například při použití [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) nebo [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) pro lepší správu zdrojů a výkon – můžete při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/openaiwebclient/) předat vlastní instanci [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html).

```js
// Předá HttpURLConnection konstruktoru OpenAIWebClient.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Vytvořte instanci SlidesAIAgent.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Definujte pokyn pro generování prezentace.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Načtěte hlavní prezentaci z lokálního disku pro použití jako šablonu designu.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Vygenerujte podrobnou prezentaci pomocí pokynu a hlavní šablony.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Uložte vygenerovanou prezentaci jako PDF.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Klíčové výhody**

Nový AI Presentation Generator v Aspose.Slides poskytuje rychlý a flexibilní způsob, jak vytvářet strukturované sady snímků z jednoduchých textových výzev. S podporou vlastních šablon a externě spravovaných instancí [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) lze snadno integrovat do široké škály aplikací.

Typické případy použití zahrnují tvorbu marketingových prezentací, vzdělávacích materiálů, zpráv pro klienty a interních sad snímků. I když generování obrázků zatím není podporováno, nástroj již nabízí solidní základ pro automatizaci tvorby prezentací a v budoucnu lze očekávat další vylepšení.