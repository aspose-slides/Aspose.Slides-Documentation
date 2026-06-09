---
title: Python'da PowerPoint Metnini Canlandırma
linktitle: Canlandırılmış Metin
type: docs
weight: 60
url: /tr/python-net/animated-text/
keywords:
- canlandırılmış metin
- metin animasyonu
- canlandırılmış paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında dinamik canlandırılmış metin oluşturun, kolay takip edilebilir, optimize edilmiş kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python kullanarak PowerPoint sunumlarında metni nasıl canlandıracağınızı gösterir. Bireysel paragraflara efekt eklemeyi, tetikleyicileri ayarlamayı ve mevcut animasyon dizilerini geri okumayı öğreneceksiniz. Sonunda, yeniden kullanılabilir metin animasyonu iş akışları oluşturabilecek ve bunları standart PPTX olarak dışa aktararak PowerPoint'te doğru şekilde oynatabileceksiniz.

## **Paragraf Animasyon Efektleri Ekle**

Sequence sınıfının [add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) metodu, tek bir paragrafta animasyon efekti uygulamanızı sağlar. Aşağıdaki örnek kod bunu nasıl yapacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Etkiyi eklemek için paragrafı seçin.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Seçilen paragrafa bir Uçuş animasyon efekti ekleyin.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Paragraf Animasyon Efektlerini Al**

Bir paragraf üzerinde hangi animasyon efektlerinin uygulandığını belirlemek isteyebilirsiniz—örneğin, bu efektleri başka bir paragraf ya da şekle kopyalamayı planlıyorsanız.

Aspose.Slides for Python, bir metin çerçevesindeki (şekil) paragraflara uygulanan tüm animasyon efektlerini almanızı sağlar. Aşağıdaki örnek kod bir paragrafın animasyon efektlerini nasıl alacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **SSS**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilirler mi?**

Metin animasyonları bir slayt üzerindeki nesnenin zaman içindeki davranışını kontrol ederken, [transitions](/slides/tr/python-net/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bunlar bağımsızdır ve birlikte kullanılabilir; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarları tarafından belirlenir.

**Metin animasyonları PDF ya da görüntülere dışa aktarıldığında korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden hareket olmadan slaydın tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/python-net/convert-powerpoint-to-video/) ya da [HTML](/slides/tr/python-net/export-to-html5/) dışa aktarmayı kullanın.

**Metin animasyonları düzenlerde ve slayt ana düzeninde çalışır mı?**

Düzen/ana düzen nesnelerine uygulanan efektler slaytlara aktarılır, ancak bunların zamanlaması ve slayt düzeyindeki animasyonlarla etkileşimi slayttaki nihai sıralamaya bağlıdır.