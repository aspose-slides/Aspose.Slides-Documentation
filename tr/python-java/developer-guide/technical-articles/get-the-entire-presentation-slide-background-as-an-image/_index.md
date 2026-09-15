---
title: Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Al
linktitle: Tüm Slayt Arka Planı
type: docs
weight: 95
url: /tr/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt arka planı
- tam arka plan
- arka planı çıkar
- tam arka plan
- arkaplanı görüntüye
- PPT arka planı
- PPTX arka planı
- ODP arka planı
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görüntü olarak çıkarın, görsel iş akışlarını sadeleştirir."
---
## **Genel Bakış**

PowerPoint sunumlarında bir slayt arka planı, slayt arka planı resmi, sunum teması, renk şeması ve ana slayt ya da yerleşim slaydına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides for Python via Java kullanarak tüm slayt arka planını bir resim olarak nasıl çıkarılacağını gösterir. Bu görev için tek bir yöntem olmadığından, yaklaşım seçilen slaytı geçici bir sunuma kopyalamayı, slayt şekillerini kaldırmayı ve ardından ortaya çıkan slayt arka planını bir resme dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Al**

Aspose.Slides for Python via Java, tüm sunum slayt arka planını bir resim olarak çıkarmak için basit bir yöntem sunmaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma kopyalayın.
1. Kopyalanan slayttaki şekilleri silin.
1. Kopyalanan slaytı bir resme dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir resim olarak çıkarır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **SSS**

**Bir ana slayttan gelen karmaşık degrade, doku veya resim doldurmaları, sonuçta elde edilen arka plan görüntüsünde korunur mu?**

Evet. Aspose.Slides, slayt, düzen veya ana slaytta tanımlanan degrade, resim ve doku doldurmalarını işler. Kalıtılan ana slaytlardan görünümü izole etmeniz gerekiyorsa, dışa aktarmadan önce mevcut slaytta [özel bir arka plan ayarlayın](/slides/tr/python-java/presentation-background/).

**Kaydetmeden önce sonuç arka plan resmine bir filigran ekleyebilir miyim?**

Evet. Çalışma [slayt kopyası](/slides/tr/python-java/clone-slides/) üzerine bir [filigran ekleyin](/slides/tr/python-java/watermark/) şekli veya resmi (diğer içeriğin arkasına yerleştirerek) ekleyebilir ve ardından dışa aktarabilirsiniz. Bu sayede filigranın dahil edildiği bir arka plan resmi üretebilirsiniz.

**Mevcut bir slayta bağlamadan belirli bir yerleşim veya ana slayt için arka plan alabilir miyim?**

Evet. İstenen ana slaytı veya yerleşimi erişin, gerekli boyutta bir [geçici slayt](/slides/tr/python-java/clone-slides/) üzerine uygulayın ve o slaytı dışa aktararak yerleşim veya ana slayttan türetilen arka planı elde edin.

**Görüntü dışa aktarımını etkileyen lisans sınırlamaları var mı?**

Render özellikleri, [geçerli bir lisans](/slides/tr/python-java/licensing/) ile tamamen kullanılabilir durumdadır. Değerlendirme modunda çıktı, filigran gibi sınırlamalar içerebilir. Toplu dışa aktarımları çalıştırmadan önce süreç başına bir kez lisansı etkinleştirin.