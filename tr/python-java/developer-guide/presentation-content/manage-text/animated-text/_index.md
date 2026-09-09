---
title: Java üzerinden Python ile PowerPoint Metnini Canlandır
linktitle: Animasyonlu Metin
type: docs
weight: 60
url: /tr/python-java/animated-text/
keywords:
- animasyonlu metin
- metin animasyonu
- animasyonlu paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında dinamik animasyonlu metin oluşturun, kolay takip edilebilen, optimize edilmiş Python kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta animasyonlu metin ile çalışmayı, tek tek paragraflara animasyon efektleri uygulayarak ve bir metin çerçevesindeki paragraflara zaten atanmış efektleri alarak açıklar. Sunumda paragraf düzeyinde animasyon eklemek ve mevcut paragraf animasyon efektlerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

[Sequence](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/) sınıfının [addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) yöntemi, tek bir paragrafa animasyon efektleri eklemenizi sağlar. Bu örnek kod, tek bir paragrafa animasyon efekti eklemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Efekt eklenecek paragrafı seç.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Seçilen paragrafa Fly animasyon efekti ekle.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Paragrafların Animasyon Efektlerini Almak**

Bir paragrafa uygulanan animasyon efektlerini elde etmek isteyebilirsiniz—örneğin bu efektleri başka bir paragraf veya şekle uygulamak gibi.

Aspose.Slides for Python via Java, bir metin çerçevesi (şekil) içinde bulunan paragraflara uygulanan tüm animasyon efektlerini almanıza olanak tanır. Bu örnek kod, bir paragrafa uygulanan animasyon efektlerini nasıl alacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **SSS**

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilir mi?**

Metin animasyonları, bir slayttaki nesnenin zaman içinde davranışını kontrol ederken, [geçişler](/slides/tr/python-java/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bunlar bağımsızdır ve birlikte kullanılabilir; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarları tarafından yönetilir.

**Metin animasyonları PDF veya görüntülere dışa aktarılırken korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden hareket olmadan slaydın tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/python-java/convert-powerpoint-to-video/) veya [HTML](/slides/tr/python-java/export-to-html5/) dışa aktarmayı kullanın.

**Metin animasyonları düzenlerde ve slayt ana temasında çalışır mı?**

Layout/master nesnelerine uygulanan efektler slaytlara miras kalır, ancak bunların zamanlaması ve slayt düzeyindeki animasyonlarla etkileşimi, slaytta son dizilime bağlıdır.