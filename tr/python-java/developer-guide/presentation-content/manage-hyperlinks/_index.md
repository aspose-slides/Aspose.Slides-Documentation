---
title: Python üzerinden Java ile Sunum Köprülerini Yönet
linktitle: Köprüyü Yönet
type: docs
weight: 20
url: /tr/python-java/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprüyü biçimlendir
- köprü kaldır
- köprüyü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- görsel köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint ve OpenDocument sunumlarındaki köprüleri zahmetsizce yönetin—interaktiviteyi ve iş akışını dakikalar içinde artırın."
---
## **Giriş**

Bir köprü, bir nesneye, veriye veya bir konuma referanstır. PowerPoint Sunumlarında yaygın köprüler şunlardır:

* Metin, şekil veya multimedya içinde web sitelerine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for Python via Java, sunumlardaki köprülerle ilgili birçok görevi gerçekleştirmenizi sağlar. 

{{% alert color="info" title="Note" %}} 

Aspose’un basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisini]https://products.aspose.app/slides/tr/editor inceleyebilirsiniz.

{{% /alert %}} 

## **URL Köprüleri Ekle**

### **Metne URL Köprüleri Ekle**

Bu Python kodu, bir metne web sitesi köprüsü eklemenizi gösterir:

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

### **Şekillere veya Çerçevelere URL Köprüleri Ekle**

Bu Python via Java örnek kodu, bir şekle web sitesi köprüsü eklemenizi gösterir:

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

### **Multimedyaya URL Köprüleri Ekle**

Aspose.Slides, görsellere, ses ve video dosyalarına köprü eklemenizi sağlar. 

Bu örnek kod, bir **görsele** köprü eklemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Sunuma görsel ekler
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Daha önce eklenen görsele dayanarak slayt 1'de resim çerçevesi oluşturur
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

Bu örnek kod, bir **video** dosyasına köprü eklemeyi gösterir:

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

{{% alert color="success" title="Tip" %}} 

*[OLE'yi Yönet](/slides/tr/python-java/manage-ole/)*'ı görebilirsiniz.

{{% /alert %}}

## **İçindekiler Tablosu Oluşturmak İçin Köprüleri Kullanma**

Köprüler, nesnelere veya konumlara referans eklemenizi sağladığından, bir içindekiler tablosu oluşturmak için kullanılabilir. 

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmanızı gösterir:

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

[Hyperlink.setColorSource](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/#setColorSource) özelliğiyle, [Hyperlink](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlink/) sınıfındaki köprülerin rengini ayarlayabilir ve renk bilgisini alabilirsiniz. Bu özellik PowerPoint 2019’da ilk kez tanıtıldı; bu nedenle özellik ile ilgili değişiklikler eski PowerPoint sürümlerinde uygulanmaz.

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

Bu Python kodu, bir sunum slaydındaki metinden köprüyü kaldırmanızı gösterir:

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

Bu Python kodu, bir sunum slaydındaki bir şekilden köprüyü kaldırmanızı gösterir: 

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

Kod snippet'i, bir slayta köprü ekleyip sonradan araç ipucunu düzenlemenizi gösterir:

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

## **HyperlinkQueries İçin Desteklenen Özellikler**

Bir sunum, slayt veya köprünün tanımlandığı metin üzerinden [HyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/) erişilebilir. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/#getHyperlinkQueries)

[HyperlinkQueries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/) sınıfı şu yöntem ve özellikleri destekler: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **SSS**

**Bir slayta değil, bir "bölüm"e veya bir bölümün ilk slaytına iç navigasyon nasıl oluşturabilirim?**

PowerPoint’te bölümler, slayt gruplarıdır; navigasyon teknik olarak belirli bir slaytı hedef alır. “Bir bölüme gitmek” için genellikle o bölümün ilk slaytına bağlantı verilir.

**Ana slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu bağlantılar alt slaytlarda da görünür ve sunum sırasında tıklanabilir olur.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**

[PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) dışa aktarmalarında evet—bağlantılar genellikle korunur. [Görüntüler](/slides/tr/python-java/convert-powerpoint-to-png/) ve [video](/slides/tr/python-java/convert-powerpoint-to-video/) dışa aktarmalarında ise, raster çerçeveler/video formatları köprüleri desteklemediği için tıklanabilirlik taşınmaz.