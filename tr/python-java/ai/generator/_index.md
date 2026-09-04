---
title: AI Destekli Çok Dilli Slayt Oluşturucu
linktitle: AI Destekli Oluşturucu
type: docs
weight: 40
url: /tr/python-java/ai/generator/
keywords:
- çok dilli sunum
- çok dilli slayt
- AI sunum oluşturucu
- AI slayt oluşturucu
- sunum şablonu
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Metinden çok dilli sunumlar oluşturun, Aspose.Slides for Python via Java ile. İçerik detayını seçin, bir şablon uygulayın ve PowerPoint veya PDF olarak dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via Java içindeki AI Sunum Oluşturucu, konu açıklamalarından, özetlerden, alıntılardan veya madde işaretlerinden sunumlar oluşturur. İstediğiniz dili komutunuzda belirtin, içerik miktarını seçin ve isteğe bağlı olarak düzen ve tasarımı tanımlamak için bir sunum şablonu sağlayın.

Oluşturucu, içeriği metin blokları, madde işaretli listeler ve tablolar kullanarak yapılandırır. Görüntü oluşturmaz; oluşturulan sunuma daha sonra ekleyebilirsiniz. Sunumu paylaşmadan önce oluşturulan içeriği ve düzeni gözden geçirin.

## **Nasıl Çalışır**

[SlidesAIAgent](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesaiagent/) bir AI istemcisi kullanarak harici bir modelle iletişim kurar. Aşağıdaki örnekler yerleşik [OpenAIWebClient](https://reference.aspose.com/slides/tr/python-java/aspose.slides/openaiwebclient/) kullanır. Aspose.Slides, modelin yanıtlarını işleyerek düzenleyebileceğiniz veya dışa aktarabileceğiniz bir sunum oluşturur.

[SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slidesaiagent/#generatePresentation) metodunu bir metin açıklaması ve bir [PresentationContentAmountType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationcontentamounttype/) değeri ile kullanın. Üçüncü bir argüman alan aşırı yükleme, tasarım şablonu olarak kullanılacak bir sunumu kabul eder.

## **Önkoşullar**

[Installation](/slides/tr/python-java/installation/) kılavuzunu izleyerek Python, Java, JPype ve Aspose.Slides'i yapılandırın. Örnekleri çalıştırmadan önce `OPENAI_API_KEY` ve `OPENAI_MODEL` ortam değişkenlerini ayarlayın. Yerleşik istemci tarafından desteklenen ve API hesabınızda kullanılabilir bir model seçin.

{{% alert color="info" title="Note" %}}
AI hizmeti bir internet bağlantısı ve ayrı bir API erişimi gerektirir. Komutlar yapılandırılmış hizmete gönderilir ve kullanım ücretleri Aspose.Slides lisansınızdan bağımsız olarak uygulanır.
{{% /alert %}}

Her örnek, JVM hâlihazırda çalışmıyorsa başlatır ve sonraki işlemler için kullanılabilir durumda bırakır. Not defterleri için kodu uyarlarken [JVM lifecycle guidance](/slides/tr/python-java/limitations-and-api-differences/#import-the-library) bölümüne bakın.

## **Metinden Sunum Oluşturma**

Bu örnek, [Medium](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationcontentamounttype/#Medium) miktarda içeriğe sahip bir İngilizce sunum oluşturur ve PowerPoint dosyası olarak kaydeder.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Şablon Kullanarak Sunum Oluşturma**

`masterPresentation.pptx` dosyasını çalışma dizinine koyun. Bu örnek, dosyayı [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) ile yükler, [Detailed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationcontentamounttype/#Detailed) içeriğe sahip bir İspanyolca sunum oluşturur ve PDF olarak dışa aktarır. Oluşturma ya da kaydetme başarısız olsa bile şablon ve oluşturulan sunum serbest bırakılır.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Bir proxy veya bağlantı zaman aşımı yapılandırmanız gerekiyorsa, [Configure the HTTP Connection](/slides/tr/python-java/ai/translator/#configure-the-http-connection) bölümüne bakın. Oluşan istemciyi de oluşturucuya aktarabilirsiniz.

## **Temel Avantajlar**

Oluşturma, eğitim materyalleri, ürün özetleri, müşteri raporları ve iç sunumların ilk taslak çalışmalarını azaltabilir. Komutlar konu ve dili kontrol ederken, bir şablon mevcut bir sunum tasarımını yeniden kullanmanıza olanak tanır.

## **SSS**

**Oluşturulan sunumun uzunluğunu nasıl kontrol ederim?**

[Brief](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationcontentamounttype/#Medium) veya [Detailed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentationcontentamounttype/#Detailed) seçeneklerinden birini seçin. Bu ayarlar, slayt sayısını ve her slayttaki ayrıntıyı etkiler; kesin bir slayt sayısı belirtmez.

**Başka bir dilde slayt oluşturabilir miyim?**

Evet. İstenen dili metin açıklamasına ekleyin. Sonuç, seçilen modelin dil yeteneklerine bağlıdır.

**PDF olarak dışa aktarırken düzenlenebilir bir sürüm tutabilir miyim?**

Evet. Oluşturulan sunumu yok etmeden önce, ilk örnekteki yöntemi kullanarak PPTX olarak da kaydedin.