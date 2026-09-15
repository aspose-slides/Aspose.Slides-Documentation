---
title: AI Destekli Sunum Çevirmeni
linktitle: AI Destekli Çevirmen
type: docs
weight: 20
url: /tr/python-net/ai/translator/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slayt oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için [Presentation Translation API](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/) gibi AI destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik AI yeteneklerine sahip değildir, ancak internet üzerinden harici AI modelleriyle bütünleşir. Bu işlevsellik, AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/iaiwebclient/) alt sınıflarını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/slidesaiagent/) sınıfı aracılığıyla sunulur.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/)’ı OpenAI API'sine bağlanmak için kullanabilir veya farklı bir AI sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/iaiwebclient/)’ınızı uygulayabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="info" %}}
OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/) kullanırken bir hesap oluşturmanız ve API anahtarınızı sağlamanız gerekir.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirli bir OpenAI [modeli](https://platform.openai.com/docs/models) ile yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/) kullanarak bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```py
import aspose.slides as slides

# Çevrilecek bir sunumu yükleyin.
with slides.Presentation("sample.pptx") as presentation:

    # Modelinizi ve API anahtarınızı belirterek OpenAIWebClient ile bir AI istemcisi oluşturun.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # AI istemcisiyle SlidesAIAgent'ı başlatın.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Sunumu Japoncaya çevirin.
        ai_agent.translate(presentation, "japanese")

        # Çevrilen sunumu PDF olarak kaydedin.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI Örneği**

**26.7.0** sürümünden beri, .NET üzerinden Python için Aspose.Slides, Azure OpenAI dahil OpenAI uyumlu sağlayıcıları destekler. Çevirmeni, [OpenAICompatibleWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaicompatiblewebclient/) ile kendi Azure dağıtımınızı kullanacak şekilde yapılandırabilirsiniz.

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

Bu kod parçacığı, Azure OpenAI uç noktanızı kullanarak bir sunumu nasıl çevireceğinizi gösterir. Yer tutucu değerleri dağıtım adınız, API anahtarınız ve uç nokta URL'niz ile değiştirin.

## **Anahtar Faydalar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/) çok dilli PowerPoint sunumları sunmak için AI destekli bir çözüm sunar. Düzeni ve tasarımı koruyarak çeviriyi otomatikleştirdiği için manuel süreçlere göre zaman tasarrufu sağlar ve hataları en aza indirir. Geliştirici, eğitimci ya da iş profesyoneli olsanız da, bu API küresel izleyiciler için etkileyici, yerelleştirilmiş sunumlar oluşturmanızı sağlar – erişiminizi genişletir ve iletişimi iyileştirir.