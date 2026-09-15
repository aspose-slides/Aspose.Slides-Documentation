---
title: Python via Java ile Sunum Görüntüleyicisi Oluşturma
linktitle: Sunum Görüntüleyicisi
type: docs
weight: 50
url: /tr/python-java/presentation-viewer/
keywords:
- sunumu görüntüle
- sunum görüntüleyici
- sunum görüntüleyici oluştur
- PPT görüntüle
- PPTX görüntüle
- ODP görüntüle
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Python via Java ile özel bir sunum görüntüleyicisi oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for Python via Java, slayt içeren sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint'te sunumları açarak görüntülenebilir. Ancak, bazen geliştiricilerin slaytları tercih ettikleri bir görüntüleyicide görsel olarak görüntülemeleri veya kendi sunum görüntüleyicilerini oluşturmaları gerekebilir. Bu gibi durumlarda, Aspose.Slides tek bir slaytı görsel olarak dışa aktarmanıza olanak tanır. Bu makale bunu nasıl yapacağınızı açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slayt referansını indeksine göre alın.  
1. Bir bayt akışı açın.  
1. Slaytı SVG görüntüsü olarak akışa kaydedin ve bir dosyaya yazın.  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Özel Şekil Kimliği ile SVG Oluşturma**

Aspose.Slides, özel bir şekil kimliğiyle bir slayttan [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu yapmak için, [SvgShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgshape/) sınıfından [SvgShape.setId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgshape/#setId) yöntemini kullanın. Şekil kimliğini ayarlamak için `CustomSvgShapeFormattingController` kullanılabilir.  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slayt referansını indeksine göre alın.  
1. Referans alınan slaytın tanımlı ölçekle küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi görüntüsü oluşturmak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slayt referansını indeksine göre alın.  
1. Referans alınan slaytın tanımlı boyutlarla küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/) sınıfının bir örneğini oluşturun.  
1. Konuşmacı notlarının konumunu ayarlamak için [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) yöntemini kullanın.  
1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slayt referansını indeksine göre alın.  
1. Render seçenekleriyle referans alınan slaytın küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Canlı Örnek**

Aspose.Slides API ile neler uygulayabileceğinizi görmek için ücretsiz [**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) uygulamasını deneyebilirsiniz:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Bir web uygulamasına sunum görüntüleyicisi yerleştirebilir miyim?**

Evet. Sunumları görüntülemek için Aspose.Slides'i sunucu tarafında görüntüleri veya HTML olarak render edebilir ve tarayıcıda gösterebilirsiniz. Gezinti ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir görüntüleyicide slaytları görüntülemenin en iyi yolu nedir?**

Önerilen yöntem, her bir slaytı bir görüntü (ör. PNG veya SVG) olarak render etmek veya Aspose.Slides kullanarak HTML'e dönüştürmek, ardından çıktıyı bir resim kutusunda (masaüstü için) veya bir HTML konteynerinde (web için) görüntülemektir.

**Çok sayıda slaytı olan büyük bir sunumu nasıl yönetebilirim?**

Büyük sunumlar için slaytların tembel yükleme (lazy-loading) veya talep üzerine render edilmesini düşünün. Bu, bir slaytın içeriğinin yalnızca kullanıcı ona gittiğinde üretilmesi anlamına gelir; böylece bellek ve yükleme süresi azalır.