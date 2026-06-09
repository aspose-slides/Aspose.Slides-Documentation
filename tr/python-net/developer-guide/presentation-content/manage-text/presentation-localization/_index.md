---
title: Python ile Sunum Yerelleştirmesini Otomatikleştirin
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/python-net/presentation-localization/
keywords:
- dili değiştir
- imla denetimi
- dil kimliği
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python'da Aspose.Slides kullanarak PowerPoint ve OpenDocument slayt yerelleştirmesini otomatikleştirin, pratik kod örnekleri ve daha hızlı global dağıtım için ipuçlarıyla."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metin için `language_id` değerinin nasıl ayarlanacağını açıklar. Bir sunumu nasıl açacağınızı, metin içeren bir şekil ekleyeceğinizi, bir metin bölümü için dil tanımlayıcısını atayacağınızı ve sonucu PPTX dosyası olarak kaydedeceğinizi gösterir.

## **Sunum ve Şeklin Metni İçin Dili Değiştir**
- Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını, indeksini kullanarak edinin.
- Slayta Dikdörtgen tipinde bir AutoShape ekleyin.
- TextFrame'e bir miktar metin ekleyin.
- `language_id` değerini metne ayarlayın.
- Sunumu PPTX dosyası olarak kaydedin.

Yukarıdaki adımların uygulaması aşağıdaki örnekte gösterilmiştir.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Dil kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides'teki [language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/) imla denetimi ve dil bilgisi kontrolü için dili saklar, ancak metin içeriğini çevirmez veya değiştirmez. Bu, PowerPoint'in denetim için anlayabileceği bir meta veridir.

**Dil kimliği oluşturma sırasında tireleme ve satır sonlarını etkiler mi?**

Aspose.Slides'de, [language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/) denetim içindir. Tireleme kalitesi ve satır kaydırma, öncelikle [uygun yazı tipleri](/slides/tr/python-net/powerpoint-fonts/) ve yazı sisteminin düzen/satır sonu ayarlarının bulunabilirliğine bağlıdır. Doğru oluşturmayı sağlamak için gereken yazı tiplerini erişilebilir kılın, [yazı tipi ikame kurallarını](/slides/tr/python-net/font-substitution/) yapılandırın ve/veya [yazı tiplerini göm](/slides/tr/python-net/embedded-font/) sunuma ekleyin.

**Tek bir paragrafta farklı diller ayarlayabilir miyim?**

Evet. [language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/) metin bölümü düzeyinde uygulanır, bu nedenle tek bir paragraf birden fazla dili, farklı denetim ayarlarıyla karıştırabilir.