---
title: AI Destekli Çok Dilli Slayt Üreteci
linktitle: AI Destekli Üreteç
type: docs
weight: 40
url: /tr/java/ai/generator/
keywords:
- çok dilli sunum
- çok dilli slayt
- AI sunum oluşturucu
- AI slayt oluşturucu
- AI destekli özellik
- AI ajanı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile metinden çok dilli slaytlar oluşturun. Şablonunuzu uygulayın ve düzenli desteleri PowerPoint ve OpenDocument formatına dışa aktarın. Daha fazla bilgi edinin."
---
## **Giriş**

Aspose.Slides, geliştiricilerin konu açıklamaları, özetler, alıntılar veya madde işaretleri gibi basit metin girdilerinden otomatik olarak iyi yapılandırılmış PowerPoint sunumları oluşturmasını sağlayan yeni bir yapay zeka destekli özellik olan Presentation Generator'ı tanıtıyor.

Kullanıcılar içerik ayrıntısı seviyesini ayarlayabilir ve isteğe bağlı olarak görsel tasarımı tanımlamak için özel bir sunum şablonu uygulayabilir.

Şu anda AI Presentation Generator, içeriği metin blokları, madde listeleri ve tablolar kullanarak yapılandırır. Görüntü oluşturma henüz desteklenmemektedir; ancak görüntüler, daha sonra Aspose.Slides araçlarıyla veya manuel olarak kolayca eklenebilir.

Çıktı, olduğu gibi kullanılabilecek veya Aspose.Slides API'sının desteklediği herhangi bir formata dışa aktarılabilecek tam bir PowerPoint sunumudur. Üreteç yüksek kaliteli sonuçlar verse de, belirli gereksinimleri karşılamak için küçük bir son düzenleme gerekebilir.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI modelleri içermez; bunun yerine internet üzerinden harici AI hizmetleriyle bütünleşir. Bu bütünleşme, AI modeliyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesaiagent/) sınıfı tarafından yönetilir.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanabilirsiniz; bu, OpenAI API'sine bağlanır, ya da başka bir AI sağlayıcısı veya dil modeliyle çalışmak için [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) arayüzünün özel bir uygulamasını sağlayabilirsiniz. Aspose.Slides, AI hizmetiyle tüm iletişimi yönetir ve slaytları oluşturmak için AI yanıtlarını işler. OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanırken bir hesap ve API anahtarı gereklidir.

## **Kod Yazalım**

### **Örnek 1**

Bu örnek, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanarak Aspose.Slides konulu bir sunum nasıl oluşturulacağını göstermektedir.

```java
// OpenAIWebClient örneğini oluşturun; bu, OpenAI web istemcisinin yerleşik uygulamasıdır.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // SlidesAIAgent örneğini oluşturun; bu, AI destekli özelliklere erişim sağlar.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Sunumu oluşturmak için talimatı tanımlayın.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Talimata dayanarak orta miktarda içerikle bir sunum oluşturun.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Oluşturulan sunumu yerel diske PowerPoint (.pptx) dosyası olarak kaydedin.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Örnek 2**

Aşağıdaki örnek, [generatePresentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) yönteminin aşırı yüklemelerini göstermektedir. Bu durumda, harici olarak yönetilen bir [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneği ve kullanıcının `master presentation`'ı kullanılır.

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, kaynak yönetimini ve performansı artırmak için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) veya [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanırken olduğu gibi [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) öğesini kendiniz yönetmeyi tercih ederseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) oluştururken kendi [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğinizi sağlayabilirsiniz.

```java
// HttpURLConnection'ı OpenAIWebClient yapıcısına geçirin.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // SlidesAIAgent örneğini oluşturun.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Sunumu oluşturmak için talimatı tanımlayın.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Tasarım şablonu olarak kullanılacak ana sunumu yerel diskten yükleyin.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Talimat ve ana şablonu kullanarak ayrıntılı bir sunum oluşturun.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Oluşturulan sunumu PDF olarak kaydedin.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Anahtar Avantajlar**

Aspose.Slides'taki yeni AI Presentation Generator, basit metin istemlerinden yapılandırılmış slayt desteleri üretmek için hızlı ve esnek bir yol sunar. Özel şablonlar ve harici olarak yönetilen [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örnekleri desteğiyle, geniş bir uygulama yelpazesine sorunsuz bir şekilde entegre edilebilir.

Tipik kullanım senaryoları arasında pazarlama sunumları, eğitim materyalları, müşteri raporları ve dahili slayt desteleri oluşturmak bulunur. Görüntü oluşturma henüz desteklenmese de, araç zaten sunum oluşturmayı otomatikleştirmek için güçlü bir temel sunar; gelecekte daha fazla iyileştirme beklenmektedir.