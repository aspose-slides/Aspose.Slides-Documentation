---
title: PowerPoint Slaytlarını Python'da PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint'i PNG'ye dönüştür
- sunumu PNG'ye dönüştür
- slaytı PNG'ye dönüştür
- PPT'yi PNG'ye dönüştür
- PPTX'i PNG'ye dönüştür
- ODP'yi PNG'ye dönüştür
- PowerPoint'ten PNG'ye
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- ODP'yi PNG'ye
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Aspose.Slides for Python via .NET ile yüksek kaliteli PNG görüntülerine hızlıca dönüştürün, kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak sunum slaytlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP gibi formatlarda sunumları yükleyebilir, her slaytı işleyebilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekte işleme, ölçeği artırma, çıkış boyutlarını piksel olarak belirleme ve bir gradyan işleme stilini seçme konularını gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytlarına [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) koleksiyonu aracılığıyla erişin. Örnek, her slaytı parametresiz [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ile işleyerek bir küçük resim oluşturur. Ardından, [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) metodunu [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) ile çağırarak işlenen her slaytı PNG görüntüsü olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Parametresiz [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) aşırı yüklemesi 0.2 ölçekle işler. Örneğin, 720 × 540 puan ölçüsündeki bir slayt 144 × 108 piksel bir küçük resim üretir. Çıkış boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle veya açık bir görüntü boyutuyla aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i PNG'ye Özel Boyutlarla Dönüştür**

İşlenen boyutları kontrol etmek için yatay ve dikey ölçek faktörlerini [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) metoduna gönderin. Bu örnekte, her iki faktör de 2'dir, bu yüzden 720 × 540 puan ölçüsündeki bir slayt 1440 × 1080 piksel bir görüntü üretir. Eşit ölçek faktörleri slaytın en‑boy oranını korur. Her görüntü, [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ile PNG formatında kaydedilir.

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **PowerPoint'i PNG'ye Özel Boyutla Dönüştür**

Çıkış boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine bir boyut değerini [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) metoduna gönderin. Bu örnek, her slaytı 960 × 720 piksel olarak işler ve sonucu [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ile kaydeder. Görüntünün uzamasını önlemek için slaytın en‑boy oranına uygun boyutları seçin.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Bir Gradyan İşleme Stili Seçin**

Bir slaytta gradyan dolgu bulunduğunu ve dışa aktarılan PNG'deki geçişlerin PowerPoint'te gördüklerinizden daha açık ya da farklı göründüğünü varsayalım. Gradyanların nasıl işleneceğini seçmek için [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) sınıfının [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) özelliğini kullanabilirsiniz.

[gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, üstte cyan‑tan‑turuncuya ve altta mavi‑tan‑sarıya iki lineer gradyan içerir. Her gradyanın iki durak noktası vardır: %0 ve %100.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı her iki modda da [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ile işler.

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

| Varsayılan | PowerPointUI |
| --- | --- |
| ![Cyan'dan turuncuya ve mavi'dan sarıya gradyanlar Varsayılan ile render edildi](gradient-Default.png) | ![Aynı gradyanlar PowerPointUI ile render edildi](gradient-PowerPointUI.png) |

Bu örnekte, `DEFAULT` daha açık ara renkler üretirken, `POWER_POINT_UI` daha koyu ara renkler üretir. Fark, gradyandaki renkler ve durak noktalara bağlıdır.

İhtiyaçlarınıza uygun standart Aspose.Slides çıktısı gerektiğinde `DEFAULT` seçin. Önceliğiniz PowerPoint'teki görünümle eşleşmekse `POWER_POINT_UI` deneyin. Her iki çıktıyı da istediğiniz sonuçla karşılaştırın; hiçbir mod evrensel olarak tercih edilebilir değildir.

## **SSS**

**Bir grafik veya resim gibi belirli bir şekli, tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, [tekil şekiller için küçük resimler oluşturma](/slides/tr/python-net/create-shape-thumbnails/) özelliğini destekler; bu sayede bir şekli PNG görüntüsü olarak işleyebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet. Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [tek bir örneği iş parçacıkları arasında paylaşmayın](/slides/tr/python-net/multithreading/).

**PNG olarak dışa aktarırken değerlendirme sınırlamaları nelerdir?**

Değerlendirme modunda, çıktı görüntülerine bir filigran eklenir ve lisans uygulanana kadar [diğer kısıtlamalar](/slides/tr/python-net/licensing/) uygulanır.