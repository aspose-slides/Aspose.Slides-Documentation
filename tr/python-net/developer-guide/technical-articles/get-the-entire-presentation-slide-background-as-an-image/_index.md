---
title: Sunumdan Tüm Slayt Arka Planını Görüntü Olarak Alın
linktitle: Tüm Slayt Arka Planı
type: docs
weight: 95
url: /tr/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- slayt
- arka plan
- slayt arka planı
- nihai arka plan
- arka planı görüntüye
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarından tam slayt arka planlarını görüntü olarak çıkarın, görsel iş akışlarını kolaylaştırın."
---
## **Genel Bakış**

PowerPoint sunumlarında, bir slayt arka planı slayt arka plan resmi, sunum teması, renk şeması ve ana slayt ya da düzen slaytına yerleştirilen nesneler gibi birden çok öğeden oluşabilir.

Bu makale, Aspose.Slides kullanarak tüm slayt arka planını bir görüntü olarak nasıl çıkarılacağını gösterir. Bu görev için tek bir yöntem olmadığından, yaklaşım seçilen slaytı geçici bir sunuma kopyalamayı, slayt şekillerini kaldırmayı ve ardından ortaya çıkan slayt arka planını bir görüntüye dönüştürmeyi içerir.

## **Tüm Slayt Arka Planını Alın**

Aspose.Slides for Python, tüm sunum slayt arka planını bir görüntü olarak çıkarmak için basit bir yöntem sağlamaz, ancak aşağıdaki adımları izleyerek bunu yapabilirsiniz:
1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Sunumdan slayt boyutunu alın.
1. Bir slayt seçin.
1. Geçici bir sunum oluşturun.
1. Geçici sunumda aynı slayt boyutunu ayarlayın.
1. Seçilen slaytı geçici sunuma kopyalayın.
1. Kopyalanan slayttaki şekilleri silin.
1. Kopyalanan slaytı bir görüntüye dönüştürün.

Aşağıdaki kod örneği, tüm sunum slayt arka planını bir görüntü olarak çıkarır.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **SSS**

**Ana slayttan gelen karmaşık degrade, doku veya resim doldurmaları, elde edilen arka plan görüntüsünde korunacak mı?**

Evet. Aspose.Slides, slayt, düzen veya ana üzerinde tanımlanan degrade, resim ve doku doldurmalarını işler. Kalıtılan masterlardan görünümü izole etmeniz gerekiyorsa, dışa aktarmadan önce mevcut slaytta [kendi arka planınızı ayarlayın](/slides/tr/python-net/presentation-background/).

**Kaydetmeden önce elde edilen arka plan görüntüsüne bir filigran ekleyebilir miyim?**

Evet. Çalışma [slayt kopyası](/slides/tr/python-net/clone-slides/) üzerine [filigran ekleyebilir](/slides/tr/python-net/watermark/) (diğer içeriğin arkasına yerleştirerek) ve ardından dışa aktarabilirsiniz. Bu, filigranın yerleşik olduğu bir arka plan görüntüsü oluşturmanızı sağlar.

**Belirli bir düzen veya master için arka planı, mevcut bir slayta bağlamadan alabilir miyim?**

Evet. İstenen master veya düzeni erişin, gerekli boyutta bir [geçici slayta](/slides/tr/python-net/clone-slides/) uygulayın ve o slaytı dışa aktararak ilgili düzen veya masterdan türetilen arka planı elde edin.

**Görüntü dışa aktarımını etkileyen lisans kısıtlamaları var mı?**

Render özellikleri, bir [geçerli lisans](/slides/tr/python-net/licensing/) ile tam olarak kullanılabilir. Değerlendirme modunda, çıktı bir filigran gibi sınırlamalar içerebilir. Toplu dışa aktarımları çalıştırmadan önce lisansı süreç başına bir kez etkinleştirin.