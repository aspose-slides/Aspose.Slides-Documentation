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
- AI odaklı özellikler
- AI yetenekleri
- AI ajanı
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint slaytlarını AI kullanarak Aspose.Slides for Node.js ile çevirin. PPT, PPTX ve ODP'yi düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için Sunum Çevirisi API'si gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides, yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [SlidesAIAgent](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanarak OpenAI API'sine bağlanabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevirilen içeriği akıllıca ekler.

{{% alert color="info" title="Note" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın, bu yüzden yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirtilen bir OpenAI [modeli](https://platform.openai.com/docs/models) ile yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Çevrilecek bir sunumu yükleyin.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Modelinizi ve API anahtarınızı belirterek OpenAIWebClient ile bir AI istemcisi oluşturun.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI istemcisi ile SlidesAIAgent'ı başlatın.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Sunumu Japoncaya çevirin.
    aiAgent.translate(presentation, "japanese");

    // Çevrilen sunumu PDF olarak kaydedin.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Varsayılan olarak, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) kendi dahili [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) örneğini oluşturur ve yönetir, yaşam döngüsünü otomatik olarak ele alır. Ancak, [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) yapılandırmasını kendiniz yönetmek isterseniz — özellikle bir proxy gibi temel ayarları yapılandırmak, [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) kullanmak veya daha iyi kaynak yönetimi ve performans için farklı bir [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) kullanmak — [OpenAIWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaiwebclient/) oluştururken kendi `HttpURLConnection` örneğinizi sağlayabilirsiniz.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Bir HttpURLConnection örneği oluşturun ve önceden yapılandırın (örneğin, özel zaman aşımı değerleri, proxy ayarları vb.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI Örneği**

Çevirmeni, [OpenAICompatibleWebClient](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/openaicompatiblewebclient/) ile Azure OpenAI dağıtımınızı kullanacak şekilde yapılandırabilirsiniz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Bu kod parçacığı, Azure OpenAI uç noktanızı kullanarak bir sunumu nasıl çevireceğinizi gösterir. Yer tutucu değerleri dağıtım adınız, API anahtarınız ve uç nokta URL'niz ile değiştirin.

## **Ana Faydalar**

Aspose.Slides Sunum Çevirisi API'si, çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirdiği için manuel iş akışlarına göre zaman kazandırır ve hataları en aza indirir. İster bir geliştirici, eğitimci veya iş profesyoneli olun, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanıza olanak tanır - erişiminizi genişletir ve iletişimi iyileştirir.