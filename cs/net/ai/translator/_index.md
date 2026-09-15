---
title: Překladač prezentací poháněný AI
linktitle: Překladač poháněný AI
type: docs
weight: 20
url: /cs/net/ai/translator/
keywords:
- Překladač prezentací AI
- Překladač snímků AI
- Funkce poháněná AI
- Vícejazyčná prezentace
- Vícejazyčný snímek
- Překlad prezentace
- Překlad snímku
- Funkce řízené AI
- Schopnosti AI
- AI agent
- Webový klient
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Překládejte snímky PowerPoint pomocí AI s Aspose.Slides pro .NET. Lokalizujte PPT, PPTX a ODP při zachování rozvržení—rychle a přívětivě pro vývojáře. Vyzkoušejte to."
---
## **Úvod**

Aspose.Slides je výkonné API pro programové řízení prezentací PowerPoint. Kromě vytváření, úprav a převodu snímků nabízí funkce řízené AI – například [Presentation Translation API](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/) pro vícejazyčný obsah snímků.

## **Jak to funguje**

Aspose.Slides neobsahuje vestavěné AI funkce, ale integruje se s externími AI modely přes internet. Tato funkce je zpřístupněna pomocí třídy [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent) , která používá implementaci rozhraní [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) , aby komunikovala se službami AI.

Můžete použít vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) k připojení k API OpenAI nebo implementovat vlastní [IAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/iaiwebclient/) , abyste použili jiného poskytovatele AI nebo jazykový model.

Aspose.Slides zajišťuje komunikaci, parsuje odpovědi AI a inteligentně vkládá přeložený obsah při zachování původního rozvržení a formátování snímků.

{{% alert color="info" title="Poznámka" %}}
Upozorňujeme, že API OpenAI je placená služba, takže budete muset vytvořit účet a zadat svůj API klíč při používání vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/).
{{% /alert %}}

## **Příklad**

V tomto příkladu překládáme prezentaci PowerPoint do japonštiny pomocí vestavěného [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) s určeným OpenAI [modelem](https://platform.openai.com/docs/models).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Načtěte prezentaci k překladu.
using var presentation = new Presentation("sample.pptx");

// Vytvořte AI klienta pomocí OpenAIWebClient, specifikujte svůj model a API klíč.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Inicializujte SlidesAIAgent s AI klientem.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Přeložte prezentaci do japonštiny.
await aiAgent.TranslateAsync(presentation, "japanese");

// Uložte přeloženou prezentaci jako PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Ve výchozím nastavení vestavěný [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/) vytváří a spravuje vlastní interní instanci [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) , přičemž automaticky spravuje její životní cyklus a uvolnění. Pokud však chcete [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) spravovat sami – například při použití [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) pro lepší správu zdrojů a výkon – můžete poskytnout vlastní instanci `HttpClient` při vytváření [OpenAIWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaiwebclient/).

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Použijte HttpClient, který spravujete sami - například vytvořený pomocí IHttpClientFactory
// injektovaný pomocí dependency injection.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides se často používá v synchronních prostředích. Pro podporu toho třída [SlidesAIAgent](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/slidesaiagent/) nabízí jak synchronní, tak asynchronní metody – což vám umožní vybrat přístup, který nejlépe vyhovuje workflow vaší aplikace.

### **Příklad Azure OpenAI**

Aspose.Slides pro .NET podporuje poskytovatele kompatibilní s OpenAI, včetně Azure OpenAI. Můžete nakonfigurovat překladač tak, aby používal vaše interní nasazení Azure prostřednictvím [OpenAICompatibleWebClient](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/openaicompatiblewebclient/).

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

Tento úryvek ukazuje, jak přeložit prezentaci pomocí vašeho koncového bodu Azure OpenAI. Nahraďte placeholder hodnoty názvem nasazení, API klíčem a URL koncového bodu.

## **Klíčové výhody**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/cs/net/aspose.slides.ai/) poskytuje řešení poháněné AI pro doručování vícejazyčných prezentací PowerPoint. Automatizací překladu při zachování rozvržení a designu šetří čas a snižuje chyby ve srovnání s ručními postupy. Ať už jste vývojář, pedagog nebo obchodní profesionál, toto API vám umožní vytvářet poutavé, lokalizované prezentace pro globální publikum – rozšiřujete tak svůj dosah a zlepšujete komunikaci.