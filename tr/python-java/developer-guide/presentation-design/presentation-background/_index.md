---
title: Python üzerinden Java ile Sunum Arka Planlarını Yönetme
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/python-java/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- düz renk
- degrade renk
- görsel arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planları nasıl ayarlayacağınızı öğrenin, sunumlarınızı güçlendirecek kod ipuçlarıyla."
---
## **Giriş**

Düz renkler, degradeler ve görüntüler genellikle slayt arka planları için kullanılır. **normal bir slayt** (tek bir slayt) ya da **ana slayt** (birden çok slayta aynı anda uygulanır) için arka planı ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Slayt İçin Düz Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki belirli bir slayt için—sunum bir ana slayt kullansa bile—düz bir rengi arka plan olarak ayarlamanıza olanak tanır. Değişiklik yalnızca seçili slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#getsolidfillcolor) metodunu kullanarak düz arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, normal bir slayt için mavi düz renk arka planının nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Slaydın arka plan rengini maviye ayarla.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Sunumu diske kaydet.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ana Slayt İçin Düz Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumdaki ana slayt için düz bir rengi arka plan olarak ayarlamanıza olanak tanır. Ana slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi görür; bu nedenle ana slaytın arka planı için düz bir renk seçtiğinizde, bu renk her slayta uygulanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Ana slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/backgroundtype/) ( [getMasters](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getmasters) aracılığıyla ) değerini `OwnBackground` olarak ayarlayın.
3. Ana slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. [getSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#getsolidfillcolor) metodunu kullanarak düz arka plan rengini belirleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, ana slayt için yeşil bir düz renk arka planının nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Ana slaytın arka plan rengini yeşile ayarla.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Sunumu diske kaydet.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slayt İçin Degrade Arka Planı Ayarlama**

Degrade, rengin yavaş yavaş değişmesiyle oluşturulan bir grafik etkisidir. Slayt arka planı olarak kullanıldığında, degradeler sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytlar için arka plan olarak bir degrade renk ayarlamanıza izin verir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) değerini `Gradient` olarak ayarlayın.
4. [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#getgradientformat) metodunu kullanarak tercih ettiğiniz degrade ayarlarını yapılandırın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir slayt için degrade renk arka planının nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Arka plana bir degrade etkisi uygula.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Degrade renklerini ekle. Degrade durakları olmadığında, arka plan varsayılan siyah-beyaz geçişine geri döner.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Sunumu diske kaydet.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Slaytın Arka Planı Olarak Görüntü Ayarlama**

Düz ve degrade dolguların yanı sıra, Aspose.Slides slayt arka planı olarak görüntü kullanmanıza da izin verir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) değerini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. [FillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#getpicturefillformat) metodunu kullanarak görüntüyü arka plan olarak atayın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki Python örneği, bir slayt için arka plan olarak bir görüntünün nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Arka plan görüntüsü özelliklerini ayarla.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Görüntüyü yükle.
    image = Images.fromFile("Tulips.jpg")
    # Görüntüyü sunumun görüntü koleksiyonuna ekle.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Sunumu diske kaydet.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki kod örneği, arka plan doldurma türünü döşenmiş bir resme ayarlamayı ve döşeme özelliklerini değiştirmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Arka plan doldurması için kullanılan görüntüyü ayarla.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Resim doldurma modunu Döşeme (Tile) olarak ayarla ve döşeme özelliklerini düzenle.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Not" %}}
Daha fazla bilgi: [Desen Olarak Döşeme Resmi](/slides/tr/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Slaytın arka plan görüntüsünün şeffaflığını ayarlamak isteyebilirsiniz; bu sayede slayt içeriği daha çok öne çıkar. Aşağıdaki Python kodu, bir slayt arka plan görüntüsünün şeffaflığını nasıl değiştirileceğini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Örneğin.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Resim dönüşüm işlemleri koleksiyonunu al.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Mevcut sabit yüzde şeffaflık etkisini bul.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Yeni şeffaflık değerini ayarla.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slayt Arka Plan Değerini Alma**

Aspose.Slides, bir slaytın etkili arka plan değerlerini [Background](https://reference.aspose.com/slides/tr/python-java/aspose.slides/background/) üzerindeki [getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/background/#geteffective) metodu ile almanıza olanak tanır. Dönen veri, etkili dolgu ve efekt biçimlerini içerir.

[BaseSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/) sınıfının [getBackground](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getbackground) metodunu kullanarak bir slaytın arka planını elde edebilirsiniz.

Aşağıdaki Python örneği, bir slaytın etkili arka plan değerinin nasıl alınacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Ana slayt, düzen ve temayı dikkate alarak etkili arka planı al.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Özel bir arka planı sıfırlayıp tema/layout arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel dolgusunu kaldırın; arka plan tekrar ilgili [layout](/slides/tr/python-java/slide-layout/)/[master](/slides/tr/python-java/slide-master/) slaytından (yani [tema arka planı](/slides/tr/python-java/presentation-theme/)) devralınır.

**Sunum temasını daha sonra değiştirirsem arka plan ne olur?**

Slaytın kendi dolgu değeri varsa değişmez. Arka plan [layout](/slides/tr/python-java/slide-layout/)/[master](/slides/tr/python-java/slide-master/) üzerinden devralındıysa, yeni tema ile eşleşecek şekilde güncellenir.