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
- AI odaklı özellikler
- AI yetenekleri
- AI ajanı
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint slaytlarını AI ile çevirin. Düzeni koruyarak PPT, PPTX ve ODP dosyalarını yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için [Presentation Translation API](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/) gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle entegre olur. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) arabiriminin bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı veya dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak tercüme edilen içeriği akıllıca ekler.

{{% alert color="primary" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın, bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanırken bir hesap oluşturmalı ve API anahtarınızı sağlamalısınız.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirli bir OpenAI [model](https://platform.openai.com/docs/models) ile yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```csharp
// Çevrilecek bir sunumu yükleyin.
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluşturun, modelinizi ve API anahtarınızı belirtin.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI istemcisi ile SlidesAIAgent'i başlatın.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Sunumu Japoncaya çevirin.
await aiAgent.TranslateAsync(presentation, "japanese");

// Çevrilen sunumu PDF olarak kaydedin.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kendi iç [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneğini oluşturur ve yönetir; yaşam döngüsünü ve imhasını otomatik olarak ele alır. Ancak, daha iyi kaynak yönetimi ve performans için bir [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) kullanmak gibi [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) öğesini kendiniz yönetmek isterseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) oluştururken kendi `HttpClient` örneğinizi sağlayabilirsiniz.

```csharp
// Bir IHttpClientFactory örneğiniz olduğunu varsayın (ör. bağımlılık enjeksiyonu yoluyla eklenmiş).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides genellikle senkron ortamlarında kullanılır. Bunu desteklemek için, [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent/) sınıfı hem senkron hem de asenkron yöntemler sunar; bu sayede uygulamanızın iş akışına en uygun yaklaşımı seçebilirsiniz.

## **Temel Avantajlar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/) çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sağlar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirdiği için, manuel iş akışlarına göre zaman tasarrufu sağlar ve hataları en aza indirir. Geliştirici, eğitimci ya da iş profesyoneli olsanız da, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır; erişiminizi genişletir ve iletişimi iyileştirir.