---
title: PowerPoint Slaytlarını Python’da PNG’ye Dönüştürme
linktitle: Slayt PNG’ye
type: docs
weight: 30
url: /tr/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint'i PNG’ye dönüştür
- Sunumu PNG’ye dönüştür
- Slaytı PNG’ye dönüştür
- PPT'yi PNG’ye dönüştür
- PPTX'i PNG’ye dönüştür
- ODP'yi PNG’ye dönüştür
- PowerPoint PNG’ye
- Sunum PNG’ye
- Slayt PNG’ye
- PPT PNG’ye
- PPTX PNG’ye
- ODP PNG’ye
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Aspose.Slides for Python via .NET ile hızlıca yüksek kaliteli PNG görüntülerine dönüştürün, kesin ve otomatik sonuçlar sağlayarak."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, PowerPoint sunumlarını PNG’ye dönüştürmeyi kolaylaştırır. Bir sunumu yüklersiniz, slaytlarını döngüyle gezersiniz, her birini raster görüntüye renderlersiniz ve sonucu PNG dosyaları olarak kaydedersiniz. Bu, slayt önizlemeleri oluşturmak, slaytları web sayfalarına gömmek veya sonraki işlem adımları için sabit varlıklar üretmek için idealdir.

## **Slaytları PNG’ye Dönüştürme**

Bu bölüm, Aspose.Slides for Python via .NET kullanarak bir PowerPoint sunumunu PNG görüntülerine dönüştürmenin mümkün olan en basit örneğini gösterir.

Şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfını örnekleyin.
1. `Presentation.slides` koleksiyonundan bir slayt alın (bkz. [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) sınıfı).
1. Slaytın küçük resmini oluşturmak için `Slide.get_image` metodunu kullanın.
1. Slayt küçük resmini PNG formatında kaydetmek için `Presentation.save` metodunu kullanın.

Bu Python kodu, bir PowerPoint sunumunu PNG’ye nasıl dönüştüreceğinizi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Özel Boyutlarda PNG’ye Slayt Dönüştürme**

Slaytları özel bir ölçekle PNG’ye aktarmak için `Slide.get_image` metodunu yatay ve dikey ölçek faktörleriyle çağırın. Bu çarpanlar, çıktıyı slaytın orijinal boyutlarına göre yeniden boyutlandırır—örneğin `2.0`, hem genişliği hem de yüksekliği iki katına çıkar. En boy oranını korumak için `scale_x` ve `scale_y` değerlerini eşit tutun.

Bu Python kodu, açıklanan işlemi gösterir:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Özel Boyutta PNG’ye Slayt Dönüştürme**

Belirli bir boyutta PNG dosyaları oluşturmak istiyorsanız, istediğiniz `width` ve `height` değerlerini geçin. Aşağıdaki kod, bir PowerPoint’i PNG’ye dönüştürürken görüntü boyutunu nasıl belirleyeceğinizi gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}

Aspose’un ücretsiz **PowerPoint‑to‑PNG dönüştürücülerini** deneyebilirsiniz—[PPTX to PNG](https://products.aspose.app/slides/tr/conversion/pptx-to-png) ve [PPT to PNG](https://products.aspose.app/slides/tr/conversion/ppt-to-png). Bu araçlar, bu sayfada açıklanan sürecin canlı bir uygulamasını sunar.

{{% /alert %}}

## **SSS**

**Yalnızca belirli bir şekli (ör. grafik veya resim) tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, [tek tek şekiller için küçük resim oluşturmayı](/slides/tr/python-net/create-shape-thumbnails/) destekler; bir şekli PNG görüntüsü olarak renderlayabilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet, ancak bir sunum örneğini iş parçacıkları arasında **paylaşmayın**(/slides/tr/python-net/multithreading/). Her iş parçacığı veya süreç için ayrı bir örnek kullanın.

**PNG’ye dışa aktarırken deneme sürümü kısıtlamaları nelerdir?**

Değerlendirme modu, çıkış görüntülerine bir filigran ekler ve bir lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/python-net/licensing/) uygular.