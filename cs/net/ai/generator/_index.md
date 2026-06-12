---
title: AI-poháněný vícejazykový generátor snímků
linktitle: AI-poháněný generátor
type: docs
weight: 40
url: /cs/net/ai/generator/
keywords:
- vícejazyková prezentace
- vícejazykový snímek
- AI generátor prezentací
- AI generátor snímků
- AI-poháněná funkce
- AI agent
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte vícejazykové snímky z textu pomocí Aspose.Slides pro .NET. Použijte svou šablonu a exportujte elegantní sady do PowerPointu a OpenDocumentu. Další informace."
---
## **Úvod**

Aspose.Slides představuje novou funkci poháněnou umělou inteligencí – Generátor prezentací, která umožňuje vývojářům automaticky vytvářet dobře strukturované PowerPoint prezentace ze jednoduchých textových vstupů, jako jsou popisy témat, souhrny, citace nebo odrážky.

Uživatelé mohou upravit úroveň podrobnosti obsahu a volitelně použít vlastní šablonu prezentace k definování vizuálního designu.

V současné době Generátor AI prezentací strukturuje obsah pomocí textových bloků, odrážkových seznamů a tabulek. Generování obrázků zatím není podporováno; obrázky lze však snadno přidat později pomocí nástrojů Aspose.Slides nebo ručně.

Výstupem je kompletní PowerPoint prezentace, kterou lze použít tak, jak je, nebo exportovat do libovolného formátu podporovaného API Aspose.Slides. Přestože generátor poskytuje vysoce kvalitní výsledky, může být nutná menší následná úprava k splnění konkrétních požadavků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné modely AI; místo toho integruje s externími AI službami přes internet. Tuto integraci zajišťuje třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent/), která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) pro komunikaci s AI modelem.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/), který se připojuje k API OpenAI, nebo poskytnout vlastní implementaci [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) pro práci s jiným poskytovatelem AI nebo jazykovým modelem. Aspose.Slides spravuje veškerou komunikaci s AI službou a zpracovává odpovědi AI k vytvoření snímků. Všimněte si, že OpenAI API je placená služba, takže při použití vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) je vyžadován účet a API klíč.

## **Pojďme kódit**

### **Příklad 1**

Tento příklad ukazuje, jak vygenerovat prezentaci na téma Aspose.Slides pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/).

```csharp
// Vytvořte instanci OpenAIWebClient, vestavěné implementace OpenAI webového klienta.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Vytvořte instanci SlidesAIAgent, která poskytuje přístup k funkcím poháněným AI.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definujte instrukci pro generování prezentace.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generujte prezentaci se středním množstvím obsahu na základě instrukce.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Uložte vygenerovanou prezentaci na lokální disk jako soubor PowerPoint (.pptx).
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Příklad 2**

Následující příklad demonstruje přetížení metody [GeneratePresentation](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent/generatepresentation/). V tomto případě je použita externě spravovaná instance [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) a `master presentation` uživatele.

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), přičemž automaticky zpracovává její životní cyklus a uvolnění. Pokud však preferujete spravovat [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) sami – například při použití [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pro lepší správu zdrojů a výkon – můžete při konstrukci [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) dodat vlastní instanci [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient).

```csharp
// Vytvořte externě spravovanou instanci HttpClient.
using var httpClient = new HttpClient();

// Předejte HttpClient do konstruktoru OpenAIWebClient.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Vytvořte instanci SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Definujte instrukci pro generování prezentace.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Načtěte hlavní (master) prezentaci z lokálního disku pro použití jako šablonu designu.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Vygenerujte podrobnou prezentaci pomocí instrukce a hlavní šablony.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Uložte vygenerovanou prezentaci jako PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Stojí za zmínku, že mnoho zákazníků používá Aspose.Slides v synchronních kontextech. Aby to bylo možné, třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent/) poskytuje jak synchronní, tak asynchronní metody, což vám umožní vybrat si přístup, který nejlépe vyhovuje workflow vaší aplikace.

## **Klíčové výhody**

Nový AI Generátor prezentací v Aspose.Slides nabízí rychlý a flexibilní způsob vytváření strukturovaných sad snímků z jednoduchých textových podnětů. S podporou vlastních šablon, externě spravovaných instancí [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) a jak synchronních, tak asynchronních pracovních toků jej lze bez problémů začlenit do široké škály aplikací.

Typické scénáře zahrnují tvorbu marketingových prezentací, vzdělávacích materiálů, klientských reportů a interních sad snímků. Přestože generování obrázků zatím není podporováno, nástroj již poskytuje solidní základ pro automatizaci tvorby prezentací, s dalšími vylepšeními očekávanými v budoucnu.