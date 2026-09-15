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
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle entegre olur. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaiwebclient/) uygulamanızı oluşturabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevirilen içeriği akıllıca ekler.

{{% alert color="info" title="Not" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın, bu yüzden yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmalı ve API anahtarınızı sağlamalısınız.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirtilen bir OpenAI [modeli](https://platform.openai.com/docs/models) kullanarak yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) ile bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```java
import com.aspose.slides.*;

// Çevirilecek bir sunumu yükle.
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluştur, model ve API anahtarını belirterek.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisiyle SlidesAIAgent'ı başlat.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Sunumu Japoncaya çevir.
    aiAgent.translate(presentation, "japanese");

    // Çevirilen sunumu PDF olarak kaydet.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nesnesini kendiniz yönetmeyi tercih ederseniz — özellikle bir proxy gibi temel ayarları yapılandırmak, veya daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ya da farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak — [OpenAIWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

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

    // Bağlantıyı OpenAIWebClient yapıcısına aktarın.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI Örneği**

Çeviriyi, [OpenAICompatibleWebClient](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/openaicompatiblewebclient/) kullanarak Azure OpenAI dağıtımınızı kullanacak şekilde yapılandırabilirsiniz.

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Bu kod parçacığı, Azure OpenAI uç noktanızı kullanarak bir sunumu nasıl çevireceğinizi gösterir. Yer tutucu değerleri dağıtım adınız, API anahtarınız ve uç nokta URL'niz ile değiştirin.

## **Temel Avantajlar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirir, manuel iş akışlarına göre zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, eğitmen ya da iş profesyoneli olun, bu API küresel izleyiciler için ilgi çekici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır – erişiminizi genişletir ve iletişimi iyileştirir.