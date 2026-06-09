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
- AI yönlendirmeli özellikler
- AI yetenekleri
- AI ajan
- Web istemcisi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python kullanarak AI ile PowerPoint slaytlarını çevirin. PPT, PPTX ve ODP dosyalarını düzeni koruyarak yerelleştirin—hızlı ve geliştirici dostu. Deneyin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarını programlı olarak yönetmek için güçlü bir API'dir. Slaytları oluşturma, düzenleme ve dönüştürmenin yanı sıra, çok dilli slayt içeriği için [Presentation Translation API](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/) gibi yapay zeka destekli özellikler sunar.

## **Nasıl Çalışır**

Aspose.Slides yerleşik yapay zeka yeteneklerine sahip değildir, ancak internet üzerinden dış yapay zeka modelleriyle bütünleşir. Bu işlevsellik, [SlidesAIAgent](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/slidesaiagent/) sınıfı aracılığıyla sunulur ve AI hizmetleriyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/iaiwebclient/) alt sınıflarını kullanır.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/)&#39;ı kullanarak OpenAI&#39;nin API&#39;sine bağlanabilir veya farklı bir AI sağlayıcısı ya da dil modeli kullanmak için kendi [IAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/iaiwebclient/)&#39;ınızı uygulayabilirsiniz.

Aspose.Slides iletişimi yönetir, AI yanıtlarını ayrıştırır ve orijinal slayt düzeni ve biçimlendirmesini koruyarak çevrilmiş içeriği akıllıca ekler.

{{% alert color="primary" %}}
OpenAI API&#39;nin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/)&#39;ı kullanırken bir hesap oluşturmalı ve API anahtarınızı sağlamalısınız.
{{% /alert %}}

## **Örnek**

Bu örnekte, belirli bir OpenAI [model](https://platform.openai.com/docs/models) kullanarak yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/) ile bir PowerPoint sunumunu Japoncaya çeviriyoruz.

```py
# Çevrilecek bir sunumu yükle.
with slides.Presentation("sample.pptx") as presentation:

    # Modelinizi ve API anahtarınızı belirterek OpenAIWebClient ile bir AI istemcisi oluştur.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # AI istemcisiyle SlidesAIAgent'ı başlat.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # Sunumu Japoncaya çevir.
        ai_agent.translate(presentation, "japanese")

        # Çevrilen sunumu PDF olarak kaydet.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **Temel Faydalar**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/), çok dilli PowerPoint sunumları sunmak için yapay zeka destekli bir çözüm sunar. Çeviriyi otomatikleştirerek düzen ve tasarımı korur, bu da zaman tasarrufu sağlar ve manuel iş akışlarına göre hataları en aza indirir. İster bir geliştirici, ister eğitimci, ister iş profesyoneli olun, bu API küresel izleyiciler için ilgi çekici, yerelleştirilmiş sunumlar oluşturmanızı sağlar – erişiminizi genişletir ve iletişimi iyileştirir.