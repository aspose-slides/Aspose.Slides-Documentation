---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
type: docs
weight: 20
url: /tr/net/ai/translator/
keywords:
- AI sunum çevirmeni
- AI slayt çevirmeni
- AI destekli özellik
- çok dilli sunum
- çok dilli slayt
- sunum çevirisi
- slayt çevirisi
- AI destekli özellikler
- AI yetenekleri
- AI ajanı
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra çok dilli slayt içeriği için [Presentation Translation API](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/) gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yetenekleri içermez, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcı veya dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve özgün slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="info" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirtilen bir OpenAI [modeli](https://platform.openai.com/docs/models) kullanarak yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) ile bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Çevrilecek bir sunumu yükleyin.
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluşturun, modelinizi ve API anahtarınızı belirterek.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI istemcisiyle SlidesAIAgent'i başlatın.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Sunumu Japoncaya çevirin.
await aiAgent.TranslateAsync(presentation, "japanese");

// Çevrilen sunumu PDF olarak kaydedin.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kendi iç [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneğini oluşturur ve yönetir, yaşam döngüsü ve imhasını otomatik olarak ele alır. Ancak, daha iyi kaynak yönetimi ve performans için bir [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) kullanmak gibi nedenlerle [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneğini kendiniz yönetmek isterseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) oluştururken kendi `HttpClient` örneğinizi sağlayabilirsiniz.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Kendi yönettiğiniz bir HttpClient kullanın - örneğin, bir IHttpClientFactory tarafından oluşturulan bir HttpClient.
// bağımlılık enjeksiyonu aracılığıyla enjekte edildi.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides genellikle senkron ortamlarında kullanılır. Bunu desteklemek için, [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent/) sınıfı hem senkron hem de asenkron yöntemler sunar - bu sayede uygulamanızın iş akışına en uygun yaklaşımı seçebilirsiniz.

## **Temel Avantajlar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/) çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sağlar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirdiği için manuel iş akışlarına kıyasla zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, eğitmen ya da işletme profesyoneli olun, bu API küresel izleyiciler için ilgi çekici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır - erişiminizi genişletir ve iletişimi iyileştirir.