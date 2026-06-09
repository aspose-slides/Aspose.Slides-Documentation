---
title: Yapay Zeka Destekli Çok Dilli Slayt Oluşturucu
linktitle: Yapay Zeka Destekli Oluşturucu
type: docs
weight: 40
url: /tr/net/ai/generator/
keywords:
- çok dilli sunum
- çok dilli slayt
- Yapay Zeka sunum oluşturucu
- Yapay Zeka slayt oluşturucu
- Yapay Zeka destekli özellik
- Yapay Zeka ajanı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile metinden çok dilli slaytlar oluşturun. Şablonunuzu uygulayın ve düzenli desteleri PowerPoint ve OpenDocument formatına dışa aktarın. Daha fazla bilgi edinin."
---
## **Giriş**

Aspose.Slides, geliştiricilerin konu açıklamaları, özetler, alıntılar veya madde işaretleri gibi basit metin girdilerinden otomatik olarak iyi yapılandırılmış PowerPoint sunumları oluşturmasını sağlayan yeni bir yapay zeka destekli özellik olan Sunum Oluşturucu'yu tanıtır.

Kullanıcılar, içerik ayrıntı seviyesini ayarlayabilir ve isteğe bağlı olarak görsel tasarımı belirlemek için özel bir sunum şablonu uygulayabilir.

Şu anda AI Sunum Oluşturucu, içeriği metin blokları, madde listeleri ve tablolar kullanarak yapılandırır. Görsel oluşturma henüz desteklenmemektedir; ancak, görseller daha sonra Aspose.Slides araçlarıyla veya manuel olarak kolayca eklenebilir.

Çıktı, olduğu gibi kullanılabilecek veya Aspose.Slides API'sının desteklediği herhangi bir formata aktarılabilecek tam bir PowerPoint sunumudur. Oluşturucu yüksek kaliteli sonuçlar üretse de, belirli gereksinimleri karşılamak için küçük bir son düzenleme gerekebilir.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI modelleri içermez; bunun yerine internet üzerinden harici AI hizmetleriyle entegre olur. Bu entegrasyon, AI modeliyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent/) sınıfı tarafından yönetilir.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanabilirsiniz; bu, OpenAI API'sına bağlanır, ya da başka bir AI sağlayıcısı veya dil modeliyle çalışmak için [IAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/iaiwebclient/) arayüzünün özelleştirilmiş bir uygulamasını sağlayabilirsiniz. Aspose.Slides, AI hizmetiyle tüm iletişimi yönetir ve AI yanıtlarını işleyerek slaytlar üretir. OpenAI API'sının ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanıldığında bir hesap ve API anahtarı gereklidir.

## **Kod Yazalım**

### **Örnek 1**

Bu örnek, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kullanarak Aspose.Slides konulu bir sunumun nasıl oluşturulacağını gösterir.

```csharp
// OpenAIWebClient örneğini oluşturun, OpenAI web istemcisinin yerleşik uygulaması.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// SlidesAIAgent örneğini oluşturun, bu AI destekli özelliklere erişim sağlar.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Sunumu oluşturmak için talimatı tanımlayın.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Talimata dayanarak orta miktarda içerikli bir sunum oluşturun.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Oluşturulan sunumu yerel diske PowerPoint (.pptx) dosyası olarak kaydedin.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **Örnek 2**

Aşağıdaki örnek, [GeneratePresentation](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent/generatepresentation/) metodunun fazla yüklemelerini gösterir. Bu durumda, harici olarak yönetilen bir [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneği ve kullanıcının `master presentation`ı kullanılır.

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) kendi dahili [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneğini oluşturur ve yönetir, yaşam döngüsü ve imhasını otomatik olarak ele alır. Ancak, kaynak yönetimini ve performansı artırmak için bir [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) kullanıyorsanız gibi, [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) öğesini kendiniz yönetmek isterseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/openaiwebclient/) oluştururken kendi [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örneğinizi sağlayabilirsiniz.

```csharp
// Harici olarak yönetilen bir HttpClient örneği oluşturun.
using var httpClient = new HttpClient();

// HttpClient'ı OpenAIWebClient yapıcısına iletin.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// SlidesAIAgent örneği oluşturun.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Sunumu oluşturmak için talimatı tanımlayın.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Tasarım şablonu olarak kullanılmak üzere yerel diskten bir ana sunum yükleyin.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Talimatı ve ana şablonu kullanarak ayrıntılı bir sunum oluşturun.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Oluşturulan sunumu PDF olarak kaydedin.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

Birçok müşterinin Aspose.Slides'ı senkron bağlamlarda kullandığını belirtmek gerekir. Bunu desteklemek için, [SlidesAIAgent](https://reference.aspose.com/slides/tr/net/aspose.slides.ai/slidesaiagent/) sınıfı hem senkron hem de asenkron yöntemler sunar ve uygulamanızın iş akışına en uygun yaklaşımı seçmenizi sağlar.

## **Anahtar Avantajlar**

Aspose.Slides'taki yeni AI Sunum Oluşturucu, basit metin istemlerinden yapılandırılmış slayt desteleri üretmek için hızlı ve esnek bir yol sağlar. Özel şablon desteği, harici yönetilen [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) örnekleri ve hem senkron hem de asenkron iş akışlarıyla, geniş bir uygulama yelpazesine sorunsuz bir şekilde entegre edilebilir.

Tipik kullanım senaryoları arasında pazarlama sunumları, eğitim materyalleri, müşteri raporları ve iç slayt desteleri oluşturmak yer alır. Görsel oluşturma henüz desteklenmemekle birlikte, araç zaten sunum oluşturmayı otomatikleştirmek için güçlü bir temel sunar ve gelecekte daha fazla iyileştirme beklenmektedir.