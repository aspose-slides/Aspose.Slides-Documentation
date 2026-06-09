---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
type: docs
weight: 20
url: /tr/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slayt oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle entegre olur. Bu işlevsellik, AI servisleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaiwebclient/) uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="primary" %}}
OpenAI API'nin ücretli bir hizmet olduğunu unutmayın; bu nedenle, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirtilen bir OpenAI [modeli](https://platform.openai.com/docs/models) kullanarak yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) ile bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```java
// Çevirilecek bir sunumu yükleyin.
Presentation presentation = new Presentation("sample.pptx");

// Modelinizi ve API anahtarınızı belirterek OpenAIWebClient ile bir AI istemcisi oluşturun.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisi ile SlidesAIAgent'ı başlatın.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Sunumu Japoncaya çevirin.
    aiAgent.translate(presentation, "japanese");

    // Çevrilmiş sunumu PDF olarak kaydedin.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, bir proxy gibi önemli ayarları yapılandırmak veya daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ya da farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak gibi sebeplerle [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)’ı kendiniz yönetmek isterseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```java
// Önceden yapılandırılmış bir HttpURLConnection örneğinizin olduğunu varsayın (örn., özel zaman aşımı, proxy ayarları vb.).
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Anahtar Faydalar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Çeviriyi otomatikleştirerek düzen ve tasarımı korur, böylece manuel iş akışlarına kıyasla zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, eğitmen ya da iş profesyoneli olun, bu API küresel izleyiciler için ilgi çekici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır - erişiminizi genişletir ve iletişimi iyileştirir.