---
title: Python üzerinden Java ile Sunum Köprülerini Yönetme
linktitle: Köprüyü Yönet
type: docs
weight: 20
url: /tr/python-java/manage-hyperlinks/
keywords:
  - URL ekle
  - köprü ekle
  - köprü oluştur
  - köprüyü biçimlendir
  - köprüyü kaldır
  - köprüyü güncelle
  - metin köprüsü
  - slayt köprüsü
  - şekil köprüsü
  - görüntü köprüsü
  - video köprüsü
  - değiştirilebilir köprü
  - PowerPoint
  - OpenDocument
  - sunum
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarındaki köprüleri zahmetsizce yönetin—etkileşimi ve iş akışını dakikalar içinde artırın."
---
## **Giriş**

Köprü, bir nesneye, veriye veya konuma yapılan bir referanstır. PowerPoint sunularında yaygın köprüler şunlardır:

* Metin, şekil veya medyada bulunan web sitelerine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for Python via Java, sunularda köprülerle ilgili birçok görevi gerçekleştirmenize olanak tanır. 

{{% alert color="info" title="Not" %}} 
Aspose'un basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisini](https://products.aspose.app/slides/tr/editor) kontrol edebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

### **Metne URL Köprüsü Ekleme**

Bu Python kodu, bir web sitesi köprüsünü metne nasıl ekleyeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Şekillere veya Çerçevelere URL Köprüsü Ekleme**

Python via Java örnek kodu, bir şekle web sitesi köprüsü eklemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Medyaya URL Köprüsü Ekleme**

Aspose.Slides, görüntülere, ses ve video dosyalarına köprü eklemenize izin verir. 

Bu örnek kod, bir **görüntüye** köprü eklemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Sunuma resim ekler
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Daha önce eklenen resme dayanarak slayt 1'de resim çerçevesi oluşturur
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu örnek kod, bir **ses dosyasına** köprü eklemeyi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu örnek kod, bir **videoya** köprü eklemeyi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="İpucu" %}} 
Şu bölümü görmek isteyebilirsiniz *[OLE'yi Yönet](/slides/tr/python-java/manage-ole/)*.
{{% /alert %}}

## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Köprüler nesnelere veya yerlere referans eklemenizi sağladığından, içindekiler tablosu oluşturmak için kullanılabilir.

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Köprüleri Biçimlendirme**

### **Renk**

Hyperlink sınıfındaki [Hyperlink.setColorSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setColorSource) özelliğiyle, köprülerin rengini ayarlayabilir ve köprülerden renk bilgisi alabilirsiniz. Bu özellik ilk kez PowerPoint 2019'da tanıtıldı; bu yüzden özellikteki değişiklikler daha eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, aynı slayta farklı renklerde köprülerin eklenmesini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sunumlardan Köprüleri Kaldırma**

### **Metinden Köprüleri Kaldırma**

Bu Python kodu, bir sunum slaydındaki metinden köprüyü nasıl kaldıracağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Bu Python kodu, bir sunum slaydındaki şekilden köprüyü nasıl kaldıracağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Değiştirilebilir Köprü**

[Hyperlink](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/) sınıfı değiştirilebilir. Bu sınıfla aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [setTargetFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Kod parçacığı, bir slayta köprü eklemeyi ve daha sonra araç ipucunu düzenlemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Zaten eklenmiş köprünün araç ipucunu değiştirir
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HyperlinkQueries'de Desteklenen Özellikler**

Köprünün tanımlı olduğu bir sunum, slayt veya metinden [HyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/) erişebilirsiniz. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getHyperlinkQueries)

[HyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/) sınıfı aşağıdaki yöntem ve özellikleri destekler: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **SSS**

**Bir slayta değil, bir "bölüm"e ya da bir bölümün ilk slaytına dahili gezinme nasıl oluşturabilirim?**

PowerPoint'teki bölümler slayt gruplarıdır; gezinme teknik olarak belirli bir slaytı hedefler. Bir "bölüme" gezinmek için genellikle o bölümün ilk slaytına bağlanırsınız.

**Ana slayt öğelerine köprü ekleyebilir ve tüm slaytlarda çalışmasını sağlayabilir miyim?**

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu tür bağlantılar alt slaytlarda görünür ve slayt gösterisi sırasında tıklanabilir.

**PDF, HTML, görüntüler veya video olarak dışa aktarırken köprüler korunacak mı?**

[PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) formatlarında evet—bağlantılar genellikle korunur. [Görüntüler](/slides/tr/python-java/convert-powerpoint-to-png/) ve [video](/slides/tr/python-java/convert-powerpoint-to-video/) formatlarına dışa aktarırken, bu formatların doğası (raster kareler/video) nedeniyle tıklanabilirlik taşınmaz.