---
title: PowerPoint Sunumlarını Python'da Hareketli GIF'lere Dönüştürme
linktitle: PowerPoint'ten GIF'e
type: docs
weight: 65
url: /tr/python-java/convert-powerpoint-to-animated-gif/
keywords:
- hareketli GIF
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten GIF'e
- sunumdan GIF'e
- slayttan GIF'e
- PPT'den GIF'e
- PPTX'den GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarını (PPT, PPTX) kolayca hareketli GIF'lere dönüştürün. Hızlı, yüksek kaliteli sonuçlar."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, sadece birkaç satır kodla PowerPoint sunumlarını hareketli GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini web sayfalarında, mesajlaşma uygulamalarında veya dokümantasyonda paylaşmak için faydalıdır. Bu makale, bir sunumu varsayılan ayarlarla nasıl dışa aktaracağınızı ve çerçeve boyutunu, slayt gecikmesini ve geçiş çerçeve hızını **GifOptions** üzerinden nasıl özelleştireceğinizi açıklar.

## **Varsayılan Ayarlarla Sunumları Hareketli GIF'e Dönüştürme**

Aşağıdaki Python örneği `pres.pptx` dosyasını yükler ve standart ayarları kullanarak hareketli GIF olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="İpucu" %}}
GIF çıktısını özelleştirmek için, kaydederken bir [GifOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/gifoptions/) nesnesi geçirin; aşağıda gösterildiği gibi.
{{% /alert %}}

## **Özel Ayarlarla Sunumları Hareketli GIF'e Dönüştürme**

Çıktı boyutlarını piksel olarak belirtmek için [setFrameSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/gifoptions/#setFrameSize), varsayılan slayt gecikmesini milisaniye cinsinden ayarlamak için [setDefaultDelay](https://reference.aspose.com/slides/tr/python-java/aspose.slides/gifoptions/#setDefaultDelay) ve geçiş çerçeve hızını kontrol etmek için [setTransitionFps](https://reference.aspose.com/slides/tr/python-java/aspose.slides/gifoptions/#setTransitionFps) yöntemlerini kullanın.

Aşağıdaki örnek, 960 × 720 çözünürlükte bir GIF'i, iki saniyelik varsayılan slayt gecikmesi ve geçişler için saniyede 35 kare ile dışa aktarır. Varsayılan gecikme, slaydın ilerleme zamanının ayarlanmadığı durumlarda uygulanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Ayrıca Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsünü deneyebilirsiniz.
{{% /alert %}}

## **SSS**

**Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne yapmalıyım?**

Eksik yazı tiplerini yükleyin veya [yedek yazı tiplerini yapılandırın](/slides/tr/python-java/powerpoint-fonts/). Yazı tipi ikamesi dışa aktarılan GIF'in görünümünü değiştirebilir. Sunumun tasarımıyla eşleşmesi için özgün yazı tiplerinin kullanılabilir olması önemlidir.

**GIF çerçevelerinin üzerine bir filigran ekleyebilir miyim?**

Evet. İlgili ana slaytlara veya tek tek slaytlara dışa aktarmadan önce [yarı saydam bir nesne veya logo ekleyin](/slides/tr/python-java/watermark/). Filigran, işlenen slayt içeriğinin bir parçası haline gelir.