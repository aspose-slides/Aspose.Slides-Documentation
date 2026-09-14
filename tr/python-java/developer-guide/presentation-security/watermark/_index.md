---
title: Python'da Sunumlara Filigran Ekleme
linktitle: Filigran
type: docs
weight: 40
url: /tr/python-java/watermark/
keywords:
- filigran
- metin filigranı
- resim filigranı
- filigran ekle
- filigranı değiştir
- filigranı kaldır
- filigranı sil
- PPT'ye filigran ekle
- PPTX'e filigran ekle
- ODP'ye filigran ekle
- PPT'den filigranı kaldır
- PPTX'den filigranı kaldır
- ODP'den filigranı kaldır
- PPT'den filigranı sil
- PPTX'den filigranı sil
- ODP'den filigranı sil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python'da PowerPoint ve OpenDocument sunumlarında metin ve resim filigranlarını yöneterek taslak, gizli bilgi, telif hakkı ve daha fazlasını belirtin."
---
## **Giriş**

**Bir filigran**, bir sunumda bir slaytta ya da tüm sunum slaytlarında kullanılan metin veya resim damgasıdır. Genellikle bir filigran, sunumun taslak olduğunu göstermek (ör. “Taslak” filigranı), gizli bilgi içerdiğini belirtmek (ör. “Gizli” filigranı), hangi şirkete ait olduğunu belirtmek (ör. “Şirket Adı” filigranı), sunum yazarını tanımlamak vb. amaçlarla kullanılır. Filigran, sunumun kopyalanmaması gerektiğini belirterek telif hakkı ihlallerini önlemeye yardımcı olur. Filigranlar hem PowerPoint hem de OpenOffice sunum formatlarında kullanılır. Aspose.Slides içinde PowerPoint PPT, PPTX ve OpenOffice ODP dosya formatlarına filigran ekleyebilirsiniz.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/python-java/) içinde, PowerPoint veya OpenOffice belgelerinde filigran oluşturmanın ve tasarımını ve davranışını değiştirmenin çeşitli yolları vardır. Ortak nokta, metin filigranları eklemek için [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) sınıfını, resim filigranları eklemek için ise [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) sınıfını veya bir filigran şekline resmi doldurmanız gerektiğidir. [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) sınıfı, [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından türetilir ve şekil nesnesinin tüm esnek ayarlarını kullanmanıza olanak tanır. [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) bir şekil olmadığından ve ayarları sınırlı olduğundan, bir [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) nesnesi içinde sarılır.

Filigranın uygulanma yolu iki şekilde olabilir: tek bir slayta ya da tüm sunum slaytlarına. Slide Master, filigranı tüm sunum slaytlarına uygulamak için kullanılır — filigran Slide Master’a eklenir, orada tam olarak tasarlanır ve ayrı ayrı slaytlarda filigranı düzenleme iznini etkilemeden tüm slaytlara uygulanır.

Filigran genellikle diğer kullanıcılar tarafından düzenlenemez olarak kabul edilir. Filigranın (daha doğrusu filigranın ebeveyn şeklinin) düzenlenmesini önlemek için Aspose.Slides şekil kilitleme işlevi sağlar. Belirli bir şekil normal bir slaytta ya da bir Slide Master’da kilitlenebilir. Filigran şekli Slide Master’da kilitlenirse, tüm sunum slaytlarında da kilitli olur.

Filigrana bir isim verebilir, böylece ileride silmek istediğinizde slaytın şekillerinde ismiyle bulabilirsiniz.

Filigranı istediğiniz şekilde tasarlayabilirsiniz; ancak genellikle ortak özellikler, ortalanmış hizalama, döndürme, ön pozisyon gibi özellikler bulunur. Aşağıdaki örneklerde bunların nasıl kullanılacağını inceleyeceğiz.

## **Metin Filigranı**

### **Bir Slayta Metin Filigranı Ekleme**

PPT, PPTX veya ODP’de bir metin filigranı eklemek için önce slayta bir şekil ekleyebilir, ardından bu şekle bir metin çerçevesi ekleyebilirsiniz. Metin çerçevesi, [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) sınıfı ile temsil edilir. Bu tür, konumlandırma için geniş özellik yelpazesine sahip olan [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından türemediği için, [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) nesnesi bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) nesnesi içinde sarılır. Şekle filigran metni eklemek için aşağıdaki gibi [addTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#addTextFrame) metodunu kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [TextFrame Sınıfının Nasıl Kullanılacağı](/slides/tr/python-java/text-formatting/)
{{% /alert %}}

### **Bir Sunuma Metin Filigranı Ekleme**

Bir text filigranını tüm sunuma (yani tüm slaytlara aynı anda) eklemek istiyorsanız, [MasterSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/masterslide/) üzerine ekleyin. Tek bir slayda filigran eklerken kullanılan mantık aynı kalır — bir [AutoShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/) nesnesi oluşturun ve ardından [addTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#addTextFrame) metodunu kullanarak filigranı ekleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Slide Master'ı Nasıl Kullanılır](/slides/tr/python-java/slide-master/)
{{% /alert %}}

### **Filigran Şeklinin Şeffaflığını Ayarlama**

Varsayılan olarak, dikdörtgen şekil dolgu ve kenar rengiyle stilize edilmiştir. Aşağıdaki kod satırları şekli şeffaf hale getirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Metin Filigranı için Yazı Tipini Ayarlama**

Aşağıdaki gibi metin filigranının yazı tipini değiştirebilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Filigran Metin Rengini Ayarlama**

Filigran metninin rengini ayarlamak için aşağıdaki kodu kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Metin Filigranını Ortalamak**

Filigranı bir slaytta ortalamak mümkündür; bunun için aşağıdaki işlemleri yapabilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Aşağıdaki resim son sonucu göstermektedir.

![Metin filigranı](text_watermark.png)

## **Resim Filigranı**

### **Bir Sunuma Resim Filigranı Ekleme**

Bir sunum slaytına resim filigranı eklemek için aşağıdaki adımları izleyebilirsiniz:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Filigranı Düzenlemeden Koruma**

Filigranın düzenlenmesini önlemek gerekiyorsa, şekil üzerinde [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshape/#getAutoShapeLock) metodunu kullanın. Bu özellik sayesinde şeklin seçilmesi, yeniden boyutlandırılması, konumunun değiştirilmesi, diğer öğelerle gruplanması, metninin düzenlenmesinin kilitlenmesi ve daha fazlası korunabilir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Filigran şeklinin değiştirilmesini kilitle.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Filigranı Ön Plana Getirme**

Aspose.Slides içinde şekillerin Z‑order’ı [ShapeCollection.reorder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#reorder) metodu ile ayarlanabilir. Bunu yapmak için slaytın şekil koleksiyonundan bu metodu çağırıp şekil referansını ve sıra numarasını parametre olarak geçmeniz gerekir. Bu sayede bir şekli slaytın önüne getirebilir ya da arkasına gönderebilirsiniz. Bu özellik, filigranı sunumun önüne yerleştirmeniz gerektiğinde özellikle faydalıdır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Filigran Dönüşünü Ayarlama**

Filigranı slayt boyunca çapraz konumlandırmak için dönüşünü ayarlayan bir kod örneği aşağıdadır:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Filigrana Bir İsim Verme**

Aspose.Slides bir şeklin ismini belirlemenize izin verir. Şekil ismini kullanarak gelecekte ona erişebilir, değiştirebilir ya da silebilirsiniz. Filigran şeklinin ismini ayarlamak için [Shape.setName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#setName) metoduna isim değerini gönderin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Filigranı Kaldırma**

Filigran şeklini kaldırmak için önce [Shape.getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getName) metoduyla slayt şekilleri arasında bulup, ardından [ShapeCollection.remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#remove) metoduna geçirin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **SSS**

**Filigran nedir ve neden kullanmalıyım?**

Filigran, slaytlara uygulanan bir metin veya resim üst katmanıdır; fikri mülkiyeti korumaya, marka bilinirliğini artırmaya veya sunumların yetkisiz kullanılmasını önlemeye yardımcı olur.

**Tüm slaytlara filigran ekleyebilir miyim?**

Evet, Aspose.Slides programatik olarak bir sunumdaki her slayta filigran eklemenize olanak tanır. Tüm slaytları döngüyle gezerek filigran ayarlarını ayrı ayrı uygulayabilirsiniz.

**Filigranın şeffaflığını nasıl ayarlayabilirim?**

Şeffaflık, şeklin doldurma ayarları ([getFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getFillFormat)) üzerinden değiştirilerek ayarlanabilir. Böylece filigran sade bir görünüm kazanır ve slayt içeriğini boğmaz.

**Filigran için hangi resim biçimleri destekleniyor?**

Aspose.Slides PNG, JPEG, GIF, BMP, SVG ve daha fazlası gibi çeşitli resim formatlarını destekler.

**Metin filigranının yazı tipi ve stilini özelleştirebilir miyim?**

Evet, sunumunuzun tasarımı ve marka tutarlılığına uygun herhangi bir yazı tipi, boyut ve stil seçebilirsiniz.

**Filigranın konumunu veya yönünü nasıl değiştirebilirim?**

Şeklin koordinatlarını, boyutunu ve dönüş özelliklerini programatik olarak değiştirerek filigranın konumunu ve yönünü istediğiniz gibi ayarlayabilirsiniz.