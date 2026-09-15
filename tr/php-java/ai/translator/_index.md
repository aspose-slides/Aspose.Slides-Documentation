---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
type: docs
weight: 20
url: /tr/php-java/ai/translator/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yetenekleri içermez, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [SlidesAIAgent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="info" title="Not" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın, bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.
{{% /alert %}}

## **Örnek**

Bu örnekte, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) ve belirtilen OpenAI [model](https://platform.openai.com/docs/models) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```php
// Çevrilecek bir sunumu yükleyin.
$presentation = new Presentation("sample.pptx");

// Modelinizi ve API anahtarınızı belirterek OpenAIWebClient ile bir AI istemcisi oluşturun.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisi ile SlidesAIAgent'i başlatın.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Sunumu Japoncaya çevirin.
    $aiAgent->translate($presentation, "japanese");

    // Çevrilen sunumu PDF olarak kaydedin.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kendi iç [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yaşam döngüsünü otomatik olarak yönetir. Ancak, bir proxy gibi temel ayarları yapılandırmak veya daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ya da farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak istiyorsanız, [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```php
// Kendi HttpURLConnection örneğinizi oluşturun ve önceden yapılandırın (özel zaman aşımı değerleri, proxy ayarları vb.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Bağlantıyı AI istemcisine geçirin.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI Örneği**

Çevirmeni, [OpenAICompatibleWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaicompatiblewebclient/) ile Azure OpenAI dağıtımınızı kullanacak şekilde yapılandırabilirsiniz.

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Bu kod parçacığı, Azure OpenAI uç noktanızı kullanarak bir sunumu nasıl çevireceğinizi gösterir. Yer tutucu değerleri dağıtım adınız, API anahtarınız ve uç nokta URL'niz ile değiştirin.

## **Temel Faydalar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirir, manuel iş akışlarına kıyasla zaman tasarrufu sağlar ve hataları en aza indirir. İster bir geliştirici, eğitimci ya da iş profesyoneli olun, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır; böylece erişiminizi genişletir ve iletişiminizi geliştirir.