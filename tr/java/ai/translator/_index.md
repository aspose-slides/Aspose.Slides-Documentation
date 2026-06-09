---
title: AI destekli Sunum Çevirmeni
linktitle: AI destekli Çevirmen
type: docs
weight: 20
url: /tr/java/ai/translator/
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
- AI ajan
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP'yi düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürme yanı sıra çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden dış AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/)’i kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="primary" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın, bu yüzden yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmalı ve API anahtarınızı sağlamalısınız.
{{% /alert %}}

## **Örnek**

Bu örnekte, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz; OpenAI [model](https://platform.openai.com/docs/models)i belirtilerek.

```java
// Çevrilecek bir sunumu yükleyin.
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluşturun, modelinizi ve API anahtarınızı belirtin.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisi ile SlidesAIAgent'ı başlatın.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Sunumu Japoncaya çevirin.
    aiAgent.translate(presentation, "japanese");

    // Çevrilen sunumu PDF olarak kaydedin.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kendi iç [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)yi kendiniz yönetmeyi tercih ederseniz — özellikle bir proxy gibi temel ayarları yapılandırmak, daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) veya farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak amacıyla — [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```java
// Önceden yapılandırılmış bir HttpURLConnection örneğiniz olduğunu varsayın (örneğin, özel zaman aşımları, proxy ayarları vb.)
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Temel Faydalar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirdiği için manuel iş akışlarına göre zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, ister eğitimci, ister işletme profesyoneli olun, bu API küresel izleyiciler için ilgi çekici, yerelleştirilmiş sunumlar oluşturmanızı sağlayarak kapsamınızı genişletir ve iletişimi iyileştirir.