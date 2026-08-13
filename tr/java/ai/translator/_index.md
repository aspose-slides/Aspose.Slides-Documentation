---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
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
- AI destekli özellikler
- AI yetenekleri
- AI ajanı
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "AI kullanarak PowerPoint slaytlarını Aspose.Slides for Java ile çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çeviri API'si gibi yapay zeka destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle entegre olur. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) arabiriminin bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı veya dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) uygulamanızı geliştirebilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="info" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu, bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerektiğini unutmayın.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirli bir OpenAI [modeli](https://platform.openai.com/docs/models) ile yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```java
import com.aspose.slides.*;

// Çevirilecek bir sunumu yükle.
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisi ile SlidesAIAgent'ı başlat.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Sunumu Japoncaya çevir.
    aiAgent.translate(presentation, "japanese");

    // Çevrilen sunumu PDF olarak kaydet.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, bir vekil (proxy) gibi temel ayarları yapılandırmak, daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) veya farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak gibi nedenlerle [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nesnesini kendiniz yönetmek isterseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// HttpURLConnection örneğini kendiniz yapılandırın (özel zaman aşımı ayarları, proxy ayarları vb.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Ana Faydalar**

Aspose.Slides Sunum Çeviri API'si, çok dilli PowerPoint sunumları sunmak için yapay zeka destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirir, bu da manuel iş akışlarına göre zaman kazandırır ve hataları en aza indirir. İster bir geliştirici, eğitimci ya da iş profesyoneli olun, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanızı sağlar – ulaşımınızı genişletir ve iletişimi geliştirir.