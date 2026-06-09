---
title: Python'da Sunum Görüntüleyici Oluşturma
linktitle: Sunum Görüntüleyici
type: docs
weight: 50
url: /tr/python-net/presentation-viewer/
keywords:
- sunumu görüntüle
- sunum görüntüleyici
- sunum görüntüleyici oluştur
- PPT görüntüle
- PPTX görüntüle
- ODP görüntüle
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da özel bir sunum görüntüleyici oluşturmayı öğrenin. Microsoft PowerPoint veya başka bir ofis yazılımına ihtiyaç duymadan PowerPoint (PPTX, PPT) ve OpenDocument (ODP) dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for Python, slaytlarla sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint'te sunumları açarak görüntülenebilir. Ancak, geliştiriciler bazen slaytları tercih ettikleri bir resim görüntüleyicide görüntülemek veya özel bir sunum görüntüleyicide kullanmak isteyebilir. Bu gibi durumlarda, Aspose.Slides tek tek slaytları resim olarak dışa aktarmanıza izin verir. Bu makale bunun nasıl yapılacağını açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

Aspose.Slides ile bir sunum slaytından SVG görüntüsü oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta, indeksine göre bir referans alın.
1. Bir dosya akışı açın.
1. Slaytı, dosya akışına SVG görüntüsü olarak kaydedin.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta, indeksine göre bir referans alın.
1. Referans alınan slayttan istenen ölçekte bir küçük resim oluşturun.
1. Küçük resim görüntüsünü tercih ettiğiniz resim formatında kaydedin.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi görüntüsü oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta, indeksine göre bir referans alın.
1. Belirtilen boyutlarla referans alınan slayttan bir küçük resim oluşturun.
1. Küçük resim görüntüsünü tercih ettiğiniz resim formatında kaydedin.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides'in [RenderingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/renderingoptions/) sınıfının bir örneğini oluşturun.
1. Konuşmacı notlarının konumunu ayarlamak için `RenderingOptions.slides_layout_options` özelliğini kullanın.
1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta, indeksine göre bir referans alın.
1. Oluşturduğunuz renderleme seçeneklerini kullanarak referans alınan slayttan bir küçük resim oluşturun.
1. Küçük resim görüntüsünü tercih ettiğiniz resim formatında kaydedin.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Canlı Örnek**

Aspose.Slides API ile neler uygulayabileceğinizi görmek için [**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) ücretsiz uygulamasını deneyin:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/tr/viewer/)

## **SSS**

**Bir ASP.NET web uygulamasına sunum görüntüleyicisi yerleştirebilir miyim?**

Evet. Sunum slaytlarını sunucu tarafında [images](/slides/tr/python-net/convert-powerpoint-to-png/) veya [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) olarak işleyebilir ve tarayıcıda görüntüleyebilirsiniz. Navigasyon ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir .NET görüntüleyicide slaytları görüntülemenin en iyi yolu nedir?**

Önerilen yaklaşım, her slaytı bir [image](/slides/tr/python-net/convert-powerpoint-to-png/) (ör. PNG veya SVG) olarak işlemek veya Aspose.Slides kullanarak [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) biçimine dönüştürmek, ardından çıktıyı bir resim kutusu içinde (masaüstü için) veya HTML konteyneri içinde (web için) göstermektir.

**Çok sayıda slaytı olan büyük sunumları nasıl yönetebilirim?**

Büyük sunumlar için, slaytların tembel yükleme (lazy-loading) veya talep üzerine işlenmesini düşünün. Bu, bir slaytın içeriğinin yalnızca kullanıcı ona geçtiğinde üretilmesi anlamına gelir ve bellek ile yükleme süresini azaltır.