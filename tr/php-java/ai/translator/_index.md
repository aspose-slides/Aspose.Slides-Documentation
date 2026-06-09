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

Aspose.Slides, programatik olarak PowerPoint sunumlarını yönetmek için güçlü bir API'dir. Kaydırıları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [SlidesAIAgent](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="primary" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmalı ve API anahtarınızı sağlamalısınız.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirtilen bir OpenAI [model](https://platform.openai.com/docs/models) ile yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```php
// Çevrilecek bir sunumu yükleyin.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisiyle SlidesAIAgent'ı başlat.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Sunumu Japoncaya çevir.
    $aiAgent->translate($presentation, "japanese");

    // Çevrilen sunumu PDF olarak kaydet.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) kendi iç [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yaşam döngüsünü otomatik olarak yönetir. Ancak, bir proxy gibi temel ayarları yapılandırmak veya daha iyi kaynak yönetimi ve performans için bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) ya da farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak istediğinizde, [OpenAIWebClient](https://reference.aspose.com/slides/tr/php-java/aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```php
// Önceden yapılandırılmış bir HttpURLConnection örneğiniz olduğunu varsayın (örneğin, özel zaman aşımı ayarları, proxy ayarları vb.)
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

## **Temel Avantajlar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sağlar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirir, zaman tasarrufu sağlar ve manuel iş akışlarına kıyasla hataları en aza indirir. İster geliştirici, ister eğitimci, ister iş profesyoneli olun, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır; böylece erişiminizi genişletir ve iletişimi iyileştirir.