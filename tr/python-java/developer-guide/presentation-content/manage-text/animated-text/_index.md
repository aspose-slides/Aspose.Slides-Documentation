---
title: Python via Java ile PowerPoint Metnini Canlandırın
linktitle: Canlandırılmış Metin
type: docs
weight: 60
url: /tr/python-java/animated-text/
keywords:
- canlandırılmış metin
- metin animasyonu
- canlandırılmış paragraf
- paragraf animasyonu
- animasyon efekti
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında dinamik canlandırılmış metin oluşturun, takip etmesi kolay, optimize edilmiş Python kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde animasyonlu metinle çalışmayı, bireysel paragraflara animasyon efektleri uygulamayı ve bir metin çerçevesindeki paragraflara zaten atanmış efektleri almayı açıklar. Sunumda paragraf seviyesinde animasyon eklemek ve mevcut paragraf animasyon efektlerini incelemek için kullanılan API yöntemlerine odaklanır.

## **Paragraflara Animasyon Efektleri Ekleme**

[Sequence](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/) sınıfının [addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) yöntemi, tek bir paragrafa animasyon efekti eklemenizi sağlar. Bu örnek kod, tek bir paragrafa animasyon efekti nasıl eklenir gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Etki eklemek için paragrafı seçin.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Seçilen paragrafa bir Uçuş animasyon efekti ekleyin.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Paragrafların Animasyon Efektlerini Alma**

Bir paragrafın eklenmiş animasyon efektlerini öğrenmek isteyebilirsiniz—örneğin, bir senaryoda bir paragraftaki animasyon efektlerini alıp başka bir paragraf veya şekle uygulamayı planlıyorsunuzdur.

Aspose.Slides for Python via Java, bir metin çerçevesi (shape) içinde bulunan paragraflara uygulanmış tüm animasyon efektlerini almanıza olanak tanır. Bu örnek kod, bir paragraftaki animasyon efektlerini nasıl alacağınızı gösterir:

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

**Metin animasyonları slayt geçişlerinden nasıl farklıdır ve birleştirilebilirler mi?**

Metin animasyonları bir slayttaki nesnenin zaman içinde davranışını kontrol ederken, [transitions](/slides/tr/python-java/slide-transition/) slaytların nasıl değiştiğini kontrol eder. Bağımsızdırlar ve birlikte kullanılabilirler; oynatma sırası animasyon zaman çizelgesi ve geçiş ayarlarıyla belirlenir.

**Metin animasyonları PDF veya görüntülere dışa aktarılırken korunur mu?**

Hayır. PDF ve raster görüntüler statiktir, bu yüzden hareket olmadan slaytın tek bir durumunu görürsünüz. Hareketi korumak için [video](/slides/tr/python-java/convert-powerpoint-to-video/) veya [HTML](/slides/tr/python-java/export-to-html5/) dışa aktarmayı kullanın.

**Metin animasyonları yerleşimler ve slayt ana şablonunda çalışır mı?**

Yerleşim/ana şablon nesnelerine uygulanan efektler slaytlara aktarılır, ancak zamanlamaları ve slayt düzeyindeki animasyonlarla etkileşimleri slayttaki nihai sekansına bağlıdır.