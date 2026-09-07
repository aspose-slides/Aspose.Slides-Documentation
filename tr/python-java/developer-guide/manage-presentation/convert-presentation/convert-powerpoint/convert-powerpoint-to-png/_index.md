---
title: "PowerPoint Slaytlarını Python'da PNG'ye Dönüştür"
linktitle: "PowerPoint'ten PNG'ye"
type: docs
weight: 30
url: /tr/python-java/convert-powerpoint-to-png/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten PNG'ye"
- "sunumu PNG'ye"
- "slaytı PNG'ye"
- "PPT'den PNG'ye"
- "PPTX'ten PNG'ye"
- "PPT'yi PNG olarak kaydet"
- "PPTX'i PNG olarak kaydet"
- "PPT'yi PNG'ye aktar"
- "PPTX'i PNG'ye aktar"
- Python
- Java
- Aspose.Slides
description: "PowerPoint slaytlarını Python üzerinden Java ile PNG görüntülerine dönüştürün. PPT, PPTX ve ODP sunumlarını özel ölçeklerle veya kesin görüntü boyutlarıyla dışa aktarın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP dosyalarını yükleyebilir, her slaytı renderleyebilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Örnekler ayrıca ölçek faktörleriyle veya kesin genişlik ve yükseklikle çıktının boyutlarını nasıl kontrol edileceğini gösterir. Her örnek gerektiğinde Java sanal makinesini başlatır ve kullanım sonrası sunum ve görüntü kaynaklarını serbest bırakır.

## **PowerPoint'i PNG'ye Dönüştür**

1. Giriş dosyasını [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Slaytları [Presentation.getSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getSlides) kullanarak alın.
3. Her slaytı [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) ile renderleyin.
4. [ImageFormat.Png](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/#Png) kullanarak her renderlenen görüntüyü kaydedin, ardından kaynaklarını serbest bırakın.

Aşağıdaki Python örneği tüm slaytları varsayılan boyutlarında dışa aktarır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint'i Özel Ölçekle PNG'ye Dönüştür**

Çıktı boyutlarını artırmak veya azaltmak için [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) metoduna yatay ve dikey ölçek faktörleri gönderin. Örneğin, 720 × 540 puanlık bir slayt, her iki eksende 2 ölçek faktörüyle renderlendiğinde 1440 × 1080 piksel bir görüntü üretir.

Aynı ölçek faktörlerini kullanarak slaytın en/boy oranını koruyun. Farklı faktörler slaytı yatay ya da dikey olarak uzatır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint'i Özel Boyutla PNG'ye Dönüştür**

Kesin piksel boyutlarını belirtmek için istediğiniz genişlik ve yükseklik değerleriyle bir Java `Dimension` nesnesi oluşturup [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) metoduna geçirin. Kaynağın slaytıyla aynı en/boy oranını seçin, aksi takdirde bozulma olur.

Aşağıdaki örnek her slaytı 960 × 720 piksel PNG görüntüsü olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **SSS**

**Bir grafik veya resim gibi tek bir şekli, tüm slayt yerine dışa aktarabilir miyim?**

Evet. Aspose.Slides, tek tek şekiller için [küçük resim oluşturmayı](/slides/tr/python-java/create-shape-thumbnails/) destekler; bunları PNG görüntüsü olarak kaydedebilirsiniz.

**Sunucuda sunumları paralel olarak dönüştürebilir miyim?**

Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın ve dosyaların üzerine yazılmasını önlemek için benzersiz çıktı yolları belirleyin. İş parçacıkları arasında bir sunum örneğini paylaşmayın. Bkz. [Multithreading](/slides/tr/python-java/multithreading/).

**PNG olarak dışa aktarırken deneme sürümü sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve [diğer kısıtlamaları](/slides/tr/python-java/licensing/) uygular. Bu sınırlamaları kaldırmak için bir lisans uygulayın.