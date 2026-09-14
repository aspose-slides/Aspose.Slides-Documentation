---
title: Sunum Slaytlarını Python'da Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/python-java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan EMF
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PPT, PPTX ve ODP sunumlarından slaytları PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına Python ve Aspose.Slides ile dönüştürün."
---
## **Giriş**

Aspose.Slides for Python via Java, PowerPoint ve OpenDocument sunumlarından bireysel slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatları olarak oluşturabilir.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Oluşturmak istediğiniz slaytı seçin.
3. Gerekirse, renderlemeyi [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) sınıfı ile yapılandırın.
4. [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) metodunu çağırın. Bir görüntü nesnesi döndürür.
5. Görüntüyü kaydedin ve çıktı formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/) değeri ile belirtin.

## **Bir Slaytı PNG Görüntüsüne Dönüştürme**

En basit dönüşüm, varsayılan renderleme ayarlarını kullanır. Oluşan görüntü nesnesi bellek içinde işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki Python örneği ilk slaytı oluşturur ve PNG görüntüsü olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştürme**

Tam piksel boyutlarıyla bir slaytı oluşturmak için bir [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) değeri kabul eden [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) aşırı yüklemesini kullanın.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Notlar ve Yorumlarla Slaytları Görüntülere Dönüştürme**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metoduna geçirin.

Aşağıdaki örnek kesilmiş notları slaytın altına ve yorumları sağına yerleştirir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Slaytı-görüntü dönüşümünde, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metoduna [BottomFull](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomFull) geçirmeyin. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/python-java/aspose.slides/notespositions/#BottomTruncated) kullanın.
{{% /alert %}}

## **TIFF Seçenekleri Kullanarak Slaytları Görüntülere Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) sınıfı, oluşturulan TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek ilk slaytı 300 DPI'de 2160 × 2880 TIFF görüntüsü olarak oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
TIFF desteği JDK 9'dan önceki Java sürümlerinde garantilenmez.
{{% /alert %}}

## **Tüm Slaytları Görüntülere Dönüştürme**

Tüm sunumu bir dizi görüntüye dönüştürmek için slayt koleksiyonunu yineleyin. Gizli slaytlar, açıkça atlamadığınız sürece dahil edilir.

Aşağıdaki örnek her slaytı yatay ve dikey ölçek faktörleri 2 olan bir JPEG görüntüsü olarak oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Gelişmiş Metafile Çıktısı Oluşturma**

Gelişmiş Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafile desteği olan diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde kullanışlıdır. Piksel tabanlı bir görüntünün aksine, EMF vektör çizim işlemlerini koruyabilir ve ölçeklendirildiğinde aynı keskinlik kaybını yaşamaz. Ancak EMF, öncelikle Windows metafile desteği olan uygulamalar için bir uyumluluk formatıdır, evrensel bir takas formatı değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içerikleri, vektör metafile konteyneri içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Bir Slaytı EMF Olarak Dışa Aktarma**

[Slide.writeAsEmf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) metodu, bir [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) nesnesini EMF formatında bir hedef akışa yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve bir EMF dosya akışına yazar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Çağıran, [Slide.writeAsEmf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) metoduna geçirilen akışın sahibidir ve yukarıda gösterildiği gibi akışı kapatmakla sorumludur.

### **Bir SVG Görüntüsünü EMF'ye Dönüştürme ve Sunuma Ekleme**

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) metodunu kullanarak SVG içeriğini EMF'ye dönüştürün. Oluşan baytlar, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) aracılığıyla sunuma eklenebilir ve bir slayta [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addPictureFrame) ile yerleştirilebilir.

Aşağıdaki örnek bir [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) oluşturur, SVG işaretlemesinden bir EMF'ye dönüştürür, metafile'i ilk slayta ekler ve sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) hedef akışın sahipliğini devralmaz. Bir [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) tüm oluşturulan verileri bellekte saklar, bu nedenle [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--) çağrılmadan önce konum sıfırlamaya gerek yoktur. Döndürülen bayt dizisi akış kapatıldıktan sonra da geçerliliğini korur.

EMF oluşturma, seçilen Aspose.Slides for Python via Java ve JDK yapılandırması tarafından desteklenen işletim sistemlerinde mevcuttur, ancak yazı tipleri veya grafik bağımlılıkları bulunmadığında platformlar arasında renderleme farklılık gösterebilir. Kaynak içerikte kullanılan yazı tiplerini kurun veya uygun ikameler yapılandırın, Aspose.Slides for Python via Java için [platform gereksinimlerini](/slides/tr/python-java/system-requirements/) izleyin ve hedef EMF tüketen uygulamada sonucu doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafile'lerini görüntüleme ve düzenlemede sınırlı veya tutarsız destek sunar.

## **Renkli Emoji Renderleme**

{{% alert title="Note" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru bir şekilde renderlemek için sunumda kullanılan emoji yazı tiplerinin dönüşümü yapan sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların renderlenmesini destekliyor mu?**

Hayır. [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) metodu slaytın statik bir görüntüsünü oluşturur ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar normal slaytlar gibi renderlenebilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Gölge ve diğer efektler slayt görüntülerinde korunuyor mu?**

Evet. Aspose.Slides, slayt görüntülerinde gölgeleri, şeffaflığı ve diğer desteklenen grafik efektlerini renderler.