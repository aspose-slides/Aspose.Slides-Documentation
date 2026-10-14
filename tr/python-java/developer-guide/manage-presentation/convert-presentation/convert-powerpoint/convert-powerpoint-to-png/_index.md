---
title: Python'da PowerPoint Slaytlarını PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten PNG'ye
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile PowerPoint slaytlarını PNG görüntülerine dönüştürün. PPT, PPTX ve ODP sunumlarını özel ölçeklerle ya da tam görüntü boyutlarıyla dışa aktarın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak sunum slaytlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP gibi formatlarda sunumları yükleyebilir, her slaytı renderlayabilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekte renderleme, ölçeği artırma, çıkış boyutlarını piksel olarak belirtme ve bir degrade renderleme stilini seçme işlemlerini göstermektedir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytlarına [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) koleksiyonu aracılığıyla erişin. Örnek, her slaytı parametresiz olarak [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) ile renderlayarak bir küçük resim oluşturur. Ardından, her renderlanan slaytı PNG görüntüsü olarak kaydetmek için [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ile [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) çağırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Parametresiz [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) aşırı yüklemesi 0,2 ölçeğinde renderlar. Örneğin, 720 × 540 puan ölçüsündeki bir slayt 144 × 108 piksel bir küçük resim üretir. Çıkış boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle veya açık bir görüntü boyutuyla aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i Özel Boyutlarla PNG'ye Dönüştür**

Renderlanan boyutları kontrol etmek için [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) yöntemine yatay ve dikey ölçek faktörlerini geçirin. Bu örnekte, her iki faktör de 2'dir, bu nedenle 720 × 540 puan ölçüsündeki bir slayt 1440 × 1080 piksel bir görüntü üretir. Eşit ölçek faktörleri slaytın en‑boy oranını korur. Her renderlanan görüntü PNG formatında kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **PowerPoint'i Özel Boyutla PNG'ye Dönüştür**

Çıkış boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine bir boyut [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) yöntemine geçirin. Bu örnek, her slaytı 960 × 720 pikselde renderlayıp sonucu PNG formatında kaydeder. Görüntünün uzamasını önlemek için slaytın en‑boy oranına uyan boyutları seçin.

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Bir Degrade Renderleme Stili Seçin**

Bir slaytın degrade doldurmaları olduğunu varsayalım, ancak dışa aktarılan PNG'deki geçişler PowerPoint'te gördüklerinizden daha açık veya farklı görünebilir. Degradelerin nasıl renderlanacağını seçmek için [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) tarafından miras alınan [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) yöntemini kullanabilirsiniz.

Uygulamanın çalışma dizinine [gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve yerleştirin. İlk slaytı iki lineer degrade içerir: üstte camgöbeğinden turuncuya ve altta maviden sarıya. Her degrade iki durak içerir, %0 ve %100'de.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı iki modda [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) ile renderlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Aşağıdaki görüntüler aynı slayttan çıkan sonuçları gösterir, her görüntüde her iki degrade de vardır:

| Default | PowerPointUI |
| --- | --- |
| ![Varsayılan ile renderlanan camgöbeğinden turuncuya ve maviden sarıya degradeler](gradient-Default.png) | ![Aynı degradeler PowerPointUI ile renderlanmıştır](gradient-PowerPointUI.png) |

Bu örnekte, `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, degrade içindeki renkler ve duraklara bağlıdır.

`Default` seçin, çünkü standart Aspose.Slides çıktısı ihtiyaçlarınıza uygunsa. Görünümün PowerPoint ile eşleşmesi önceliğinizse `PowerPointUI` deneyin. Her iki çıktıyı hedeflediğiniz sonuçla karşılaştırın; hiçbir mod evrensel olarak tercih edilebilir değildir.

## **SSS**

**Bir slaytın tamamı yerine belirli bir şekli, örneğin bir grafik veya resim, nasıl dışa aktarabilirim?**

Aspose.Slides, [generating thumbnails for individual shapes](/slides/tr/python-java/create-shape-thumbnails/) özelliğiyle, bir şekli PNG görüntüsü olarak renderlamanıza olanak tanır.

**Sunucuda paralel dönüştürme destekleniyor mu?**

Evet. Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [iş parçacıkları arasında tek bir örnek paylaşmayın](/slides/tr/python-java/multithreading/).

**PNG'ye dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamalar](/slides/tr/python-java/licensing/) uygular.