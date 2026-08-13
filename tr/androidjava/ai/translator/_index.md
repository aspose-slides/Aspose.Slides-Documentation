---
title: Yapay Zeka Destekli Sunum Çevirmeni
linktitle: Yapay Zeka Destekli Çevirmen
type: docs
weight: 20
url: /tr/androidjava/ai/translator/
keywords:
- Yapay zeka sunum çevirmeni
- Yapay zeka slayt çevirmeni
- Yapay zeka destekli özellik
- çok dilli sunum
- çok dilli slayt
- sunum çevirisi
- slayt çevirisi
- yapay zeka odaklı özellikler
- yapay zeka yetenekleri
- yapay zeka ajanı
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PowerPoint slaytlarını yapay zeka ile çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Presentation Translation API gibi yapay zeka odaklı özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik yapay zeka yeteneklerine sahip değildir, ancak internet üzerinden harici yapay zeka modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) ile OpenAI API'sine bağlanabilir veya farklı bir yapay zeka sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient] uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzenini ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="info" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu yüzden yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirli bir OpenAI [model](https://platform.openai.com/docs/models) kullanarak yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) ile bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```java
import com.aspose.slides.*;

// Çevrilecek bir sunumu yükle.
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluştur, modelinizi ve API anahtarınızı belirterek.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisiyle SlidesAIAgent'ı başlat.
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

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, bir proxy gibi temel ayarları yapılandırmak veya daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ya da farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak amacıyla [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) üzerini kendiniz yönetmek isterseniz, [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // HttpURLConnection örneğini kendiniz yapılandırın (ör. özel zaman aşımı, proxy ayarları vb.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // Bağlantıyı OpenAIWebClient yapıcıya aktar.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Anahtar Faydalar**

Aspose.Slides Presentation Translation API, çok dilli PowerPoint sunumları sunmak için yapay zeka destekli bir çözüm sunar. Çeviriyi otomatikleştirirken düzeni ve tasarımı koruması, manuel iş akışlarına göre zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, eğitmen ya da iş profesyoneli olun, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır – erişiminizi genişletir ve iletişimi iyileştirir.