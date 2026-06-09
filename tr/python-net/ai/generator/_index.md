---
title: Yapay Zeka Destekli Çok Dilli Slayt Oluşturucu
linktitle: Yapay Zeka Destekli Oluşturucu
type: docs
weight: 40
url: /tr/python-net/ai/generator/
keywords:
- çok dilli sunum
- çok dilli slayt
- Yapay Zeka sunum oluşturucu
- Yapay Zeka slayt oluşturucu
- Yapay Zeka destekli özellik
- Yapay Zeka ajanı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile metinden çok dilli slaytlar oluşturun. Şablonunuzu uygulayın ve şık desteleri PowerPoint ve OpenDocument formatına dışa aktarın. Daha fazla bilgi edinin."
---
## **Giriş**

Aspose.Slides, geliştiricilerin konu açıklamaları, özetler, alıntılar veya madde işaretleri gibi basit metin girdilerinden otomatik olarak iyi yapılandırılmış PowerPoint sunumları oluşturmalarını sağlayan yeni bir yapay zeka destekli özellik olan Sunum Oluşturucu'yu tanıtıyor.

Kullanıcılar, içeriğin ayrıntı seviyesini ayarlayabilir ve isteğe bağlı olarak görsel tasarımı belirlemek için özel bir sunum şablonu uygulayabilir.

Şu anda AI Sunum Oluşturucu, içeriği metin blokları, madde listeleri ve tablolar kullanarak yapılandırır. Görsel oluşturma henüz desteklenmemektedir; ancak, görseller daha sonra Aspose.Slides araçlarıyla veya manuel olarak kolayca eklenebilir.

Çıktı, olduğu gibi kullanılabilecek veya Aspose.Slides API'sinin desteklediği herhangi bir formata dışa aktarılabilecek tam bir PowerPoint sunumudur. Oluşturucu yüksek kaliteli sonuçlar verse de, belirli gereksinimleri karşılamak için küçük bir son düzenleme gerekebilir.

## **Nasıl Çalışır**

Aspose.Slides yerleşik yapay zeka modelleri içermez; bunun yerine internet üzerinden harici yapay zeka hizmetleriyle bütünleşir. Bu bütünleşme, AI modeliyle iletişim kurmak için [IAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/iaiwebclient/) sınıfının bir uygulamasını kullanan [SlidesAIAgent](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/slidesaiagent/) sınıfı tarafından yönetilir.

Yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/) sınıfını kullanabilirsiniz; bu sınıf OpenAI API'sine bağlanır, ya da başka bir AI sağlayıcısı veya dil modeliyle çalışmak için [IAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/iaiwebclient/) sınıfının özel bir uygulamasını sağlayabilirsiniz. Aspose.Slides, AI hizmetiyle tüm iletişimi yönetir ve slaytları oluşturmak için AI yanıtlarını işler. OpenAI API'sinin ücretli bir hizmet olduğunu unutmayın; bu nedenle yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/) kullanıldığında bir hesap ve API anahtarı gereklidir.

## **Kodlamaya Başlayalım**

### **Örnek 1**

Bu örnek, yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/openaiwebclient/) kullanarak Aspose.Slides konulu bir sunumun nasıl oluşturulacağını gösterir.

```py
# OpenAIWebClient örneğini oluşturun, OpenAI web istemcisinin yerleşik uygulaması.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # SlidesAIAgent örneğini oluşturun, bu AI destekli özelliklere erişim sağlar.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Sunumu oluşturmak için talimatı tanımlayın.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Talimata dayalı olarak orta miktarda içerikle bir sunum oluşturun.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # Oluşturulan sunumu yerel diske PowerPoint (.pptx) dosyası olarak kaydedin.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Örnek 2**

Aşağıdaki örnek, [generate_presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) metodunun aşırı yüklemelerini gösterir. Bu durumda, kullanıcının `master presentation`'ı kullanılır.

```py
# HttpClient'ı OpenAIWebClient yapıcısına geçirin.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # SlidesAIAgent örneğini oluşturun.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # Sunumu oluşturmak için talimatı tanımlayın.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # Tasarım şablonu olarak kullanılmak üzere yerel diskten bir ana sunum yükleyin.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # Talimat ve ana şablonu kullanarak ayrıntılı bir sunum oluşturun.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # Oluşturulan sunumu PDF olarak kaydedin.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Temel Faydalar**

Aspose.Slides'teki yeni AI Sunum Oluşturucu, basit metin komutlarından yapılandırılmış slayt desteleri üretmek için hızlı ve esnek bir yol sunar. Özel şablon desteğiyle, geniş bir uygulama yelpazesine sorunsuz bir şekilde entegre edilebilir.

Tipik kullanım senaryoları arasında pazarlama sunumları, eğitim materyalleri, müşteri raporları ve iç slayt desteleri oluşturmak yer alır. Görsel oluşturma henüz desteklenmemesine rağmen, araç zaten sunum oluşturmayı otomatikleştirmek için sağlam bir temel sunar ve gelecekte daha fazla geliştirme beklenmektedir.