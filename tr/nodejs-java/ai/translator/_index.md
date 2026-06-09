---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
type: docs
weight: 20
url: /tr/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP'yi düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [SlidesAIAgent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilen içeriği akıllı bir şekilde ekler.

{{% alert color="primary" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmalı ve API anahtarınızı sağlamalısınız.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirli bir OpenAI [modeli](https://platform.openai.com/docs/models) kullanarak yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) ile bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```js
// Bir sunumu çevirmek için yükle.
let presentation = new aspose.slides.Presentation("sample.pptx");

// OpenAIWebClient ile bir AI istemcisi oluşturun, modelinizi ve API anahtarınızı belirterek.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // SlidesAIAgent'ı AI istemcisiyle başlat.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Sunumu Japoncaya çevir.
    aiAgent.translate(presentation, "japanese");

    // Çevrilen sunumu PDF olarak kaydet.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) nesnesini kendiniz yönetmek isterseniz — özellikle bir proxy gibi temel ayarları yapılandırmak, bir [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) veya daha iyi kaynak yönetimi ve performans için farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak — [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```js
// Önceden yapılandırılmış bir HttpURLConnection örneğiniz olduğunu varsayın (ör. özel zaman aşımı ayarları, proxy ayarları vb.)
let urlConnection = yourPreconfiguredConnection;
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **Temel Yararlar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Çeviriyi otomatikleştirerek ve düzen ile tasarımı koruyarak, manuel çalışma akışlarına kıyasla zaman tasarrufu sağlar ve hataları en aza indirir. Geliştirici, eğitimci veya iş profesyoneli olsanız da, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır - ulaşımınızı genişletir ve iletişimi geliştirir.