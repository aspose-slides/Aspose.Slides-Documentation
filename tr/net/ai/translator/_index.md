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
- AI ajan
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint slaytlarını AI ile çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için [Presentation Translation API](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/) gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını parses eder ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevirilen içeriği akıllıca ekler.

{{% alert color="info" title="Note" %}}

OpenAI API'sinin ücretli bir hizmet olduğunu, bu yüzden yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerektiğini unutmayın.

{{% /alert %}}

## **Örnek**

Bu örnekte, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz ve belirli bir OpenAI [model](https://platform.openai.com/docs/models) seçiyoruz.

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// Çevrilecek bir sunumu yükleyin.
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluşturun, modelinizi ve API anahtarınızı belirterek.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI istemcisi ile SlidesAIAgent'ı başlatın.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Sunumu Japoncaya çevirin.
await aiAgent.TranslateAsync(presentation, "japanese");

// Çevrilen sunumu PDF olarak kaydedin.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kendi dahili [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneğini oluşturur ve yönetir, yaşam döngüsü ve imhasını otomatik olarak ele alır. Ancak, [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)ʼı kendiniz yönetmek isterseniz—örneğin daha iyi kaynak yönetimi ve performans için bir [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) kullanırken—[OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) oluştururken kendi `HttpClient` örneğinizi sağlayabilirsiniz.

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// Kendiniz yönettiğiniz bir HttpClient kullanın - örneğin, bir IHttpClientFactory tarafından oluşturulan
// bağımlılık enjeksiyonu yoluyla enjekte edilen.
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides sıkça senkron ortamlarında kullanılır. Bunu desteklemek için, [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent/) sınıfı hem senkron hem de asenkron metodlar sunar—bu da uygulamanızın iş akışına en uygun yaklaşımı seçmenize olanak tanır.

### **Azure OpenAI Örneği**

Aspose.Slides for .NET, Azure OpenAI dahil olmak üzere OpenAI uyumlu sağlayıcıları destekler. Çevirmeni, [OpenAICompatibleWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaicompatiblewebclient/) ile kendi kurum içi Azure dağıtımınızı kullanacak şekilde yapılandırabilirsiniz.

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

Bu kod parçacığı, Azure OpenAI uç noktanızı kullanarak bir sunumu nasıl çevireceğinizi gösterir. Yer tutucu değerleri dağıtım adınız, API anahtarınız ve uç nokta URL'niz ile değiştirin.

## **Temel Faydalar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/), çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirir, manuel iş akışlarına kıyasla zaman tasarrufu sağlar ve hataları en aza indirir. İster geliştirici, eğitmen ya da iş profesyoneli olun, bu API küresel izleyiciler için ilgi çekici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır—erişiminizi genişletir ve iletişimi iyileştirir.