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
- AI odaklı özellikler
- AI yetenekleri
- AI ajanı
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı bir şekilde yönetmek için güçlü bir API'dir. Slayt oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) arayüzünün bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilir veya farklı bir AI sağlayıcısı veya dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaiwebclient/) uygulamanızı geliştirebilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini korurken çevrilmiş içeriği akıllıca ekler.

{{% alert color="info" title="Not" %}}

OpenAI API'nin ücretli bir servis olduğunu unutmayın, bu yüzden yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.

{{% /alert %}}

## **Örnek**

Bu örnekte, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) ve belirtilen bir OpenAI [modeli](https://platform.openai.com/docs/models) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```java
import com.aspose.slides.*;

// Çevrilecek bir sunumu yükleyin.
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluşturun, modelinizi ve API anahtarınızı belirterek.
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

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak işler. Ancak, [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)'ı kendiniz yönetmek isterseniz — özellikle bir proxy gibi temel ayarları yapılandırmak, ya da daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) veya farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak amacıyla — [OpenAIWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// HttpURLConnection örneğini kendiniz yapılandırın (özel zaman aşımı ayarları, proxy ayarları, vb.).
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI Örneği**

Çevirmeni, [OpenAICompatibleWebClient](https://reference.aspose.com/slides/tr/java/com.aspose.slides/openaicompatiblewebclient/) kullanarak Azure OpenAI dağıtımınızı kullanacak şekilde yapılandırabilirsiniz.

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

## **Anahtar Faydalar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirir, manuel iş akışlarına göre zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, eğitmen ya da iş profesyoneli olun, bu API global izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır - erişiminizi genişletir ve iletişimi geliştirir.