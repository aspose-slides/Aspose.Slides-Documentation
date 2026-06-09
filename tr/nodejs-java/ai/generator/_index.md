---
title: Yapay Zeka Destekli Çok Dilli Slayt Üreteci
linktitle: Yapay Zeka Destekli Üreteç
type: docs
weight: 40
url: /tr/nodejs-java/ai/generator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile metinden çok dilli slaytlar oluşturun. Şablonunuzu uygulayın ve düzenli desteleri PowerPoint ve OpenDocument formatına dışa aktarın. Daha fazla bilgi edinin."
---
## **Giriş**

Aspose.Slides, geliştiricilerin konu açıklamaları, özetler, alıntılar veya madde işaretli listeler gibi basit metin girdileriyle otomatik olarak iyi yapılandırılmış PowerPoint sunumları oluşturmasını sağlayan yeni bir yapay zeka destekli özellik, Presentation Generator'ı tanıtır.

Kullanıcılar, içerik detay seviyesini ayarlayabilir ve isteğe bağlı olarak görsel tasarımı tanımlamak için özel bir sunum şablonu uygulayabilir.

Şu anda AI Presentation Generator, içeriği metin blokları, madde işaretli listeler ve tablolar kullanarak yapılandırıyor. Görüntü oluşturma henüz desteklenmiyor; ancak, görüntüler Aspose.Slides araçlarıyla ya da manuel olarak sonradan kolayca eklenebilir.

Çıktı, olduğu gibi kullanılabilecek ya da Aspose.Slides API'sinin desteklediği herhangi bir formata dışa aktarılabilecek eksiksiz bir PowerPoint sunumudur. Oluşturucu yüksek kaliteli sonuçlar verse de, belirli gereksinimleri karşılamak için küçük bir son düzenleme gerekebilir.

## **Nasıl Çalışır**

Aspose.Slides yerleşik yapay zeka modelleri içermez; bunun yerine internet üzerinden harici AI hizmetleriyle bütünleşir. Bu bütünleşme, [SlidesAIAgent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesaiagent/) sınıfı tarafından yönetilir.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanabilirsiniz; bu, OpenAI API'sine bağlanır. Aspose.Slides, AI hizmetiyle tüm iletişimi yönetir ve AI yanıtlarını slayt oluşturmak için işler. OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanırken bir hesap ve API anahtarı gereklidir.

## **Kod Yazalım**

### **Örnek 1**

Bu örnek, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanarak Aspose.Slides konulu bir sunumun nasıl oluşturulacağını gösterir.

```js
// OpenAIWebClient örneğini oluşturun, OpenAI web istemcisinin yerleşik uygulaması.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // AI destekli özelliklere erişim sağlayan SlidesAIAgent örneğini oluşturun.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Sunumu oluşturmak için talimatı tanımlayın.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Talimata göre orta miktarda içerikle bir sunum oluşturun.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Oluşturulan sunumu yerel diske PowerPoint (.pptx) dosyası olarak kaydedin.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Örnek 2**

Aşağıdaki örnek, [generatePresentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) metodunun aşırı yüklemelerini gösterir. Bu durumda, harici olarak yönetilen bir [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneği ve kullanıcının `master presentation`ı kullanılır.

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)'ı kendiniz yönetmeyi tercih ederseniz—örneğin, kaynak yönetimini ve performansı artırmak için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) veya [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanıyorsanız—[OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) oluştururken kendi [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğinizi sağlayabilirsiniz.

```js
// HttpURLConnection nesnesini OpenAIWebClient yapıcıya geçirin.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // SlidesAIAgent örneğini oluşturun.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Sunumu oluşturmak için talimatı tanımlayın.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Tasarım şablonu olarak kullanmak için yerel diskten bir ana sunum yükleyin.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Talimatı ve ana şablonu kullanarak ayrıntılı bir sunum oluşturun.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Oluşturulan sunumu PDF olarak kaydedin.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Anahtar Faydalar**

Aspose.Slides'teki yeni AI Presentation Generator, basit metin istemlerinden yapılandırılmış slayt desteleri üretmek için hızlı ve esnek bir yol sunar. Özel şablonlar ve harici yönetilen [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örnekleri desteğiyle, çok çeşitli uygulamalara sorunsuz bir şekilde entegre edilebilir.

Tipik kullanım senaryoları arasında pazarlama sunumları, eğitim materyalları, müşteri raporları ve iç slayt desteleri oluşturmak yer alır. Görüntü oluşturma henüz desteklenmese de, araç zaten sunum oluşturmayı otomatikleştirmek için sağlam bir temel sunuyor ve gelecekte daha fazla iyileştirme bekleniyor.