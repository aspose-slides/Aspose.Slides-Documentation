---
title: PowerPoint Şekillerini Python ile Java Üzerinden Biçimlendir
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/python-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- şekil çizgi eskizi
- birleştirme stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil renderleme
- gri tonlamalı şekil renderleme
- şekil döndürme
- 3b kiriş efekti
- 3b döndürme efekti
- biçimlendirme sıfırlama
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Python üzerinden Java ile PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassas ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, konturlarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java, PowerPoint'te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve metodlar sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. İşlem adımları aşağıdaki gibidir:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [çizgi stili](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) ayarını belirleyin.
1. Çizgi genişliğini ayarlayın.
1. Çizginin [çizgi dash stili](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) ayarını belirleyin.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki kod, bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) biçimlendirmesini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Bir sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Rectangle şeklinin dolgu rengini ayarla.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Rectangle'ın çizgilerine biçimlendirme uygula.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Rectangle'ın çizgi rengini ayarla.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # PPTX dosyasını diske kaydet.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Sunumda biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisini elle çizilmiş gibi gösterir. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) metodunu, eskiz ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) metodunu ve [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) metodunu kullanarak [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/) enumarasyonundan bir değer seçin.

Aşağıdaki Python kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved) efektini nasıl uygulayacağını, açıkça atanmış değeri nasıl okuyacağını ve [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None) ile efekti nasıl kaldıracağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Şeklin çizgi formatına ve çizim formatına eriş.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Bir eskiz efekti uygula.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Şekle doğrudan atanmış eskiz efektini oku.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Eskiz efektini kaldır.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından kalıtılabiliyorsa, [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) metodunu kullanın, `LineFormatEffectiveData.getSketchFormat` öğesine erişin ve `SketchFormatEffectiveData.getSketchType` öğesini okuyun. Etkili değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Birleştirme Stillerini Biçimlendirme**

İşte üç birleştirme tipi seçeneği:

* Yuvarlak
* Köşe
* Eğim

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çizerken **Köşe** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

Aşağıdaki Python kodu, yukarıdaki görselde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round birleştirme tipi ayarlarıyla nasıl oluşturulduğunu gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde üç otomatik şekil ekle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Her dikdörtgen şeklinin dolgu rengini ayarla.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Çizgi kalınlığını ayarla.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Her dikdörtgenin çizgi rengini ayarla.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Birleştirme stilini ayarla.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Her dikdörtgene metin ekle.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # PPTX dosyasını diske kaydet.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gradyan Doldurma**

PowerPoint'te Gradyan Doldurma, bir şekle sürekli bir renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, bir renk yavaş yavaş diğerine karışacak şekilde iki veya daha fazla renk uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/) sınıfı tarafından sunulan gradyan durak koleksiyonunun [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) metodunu kullanarak tanımlı konumlarla iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir elipse gradyan doldurma etkisi uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Ellipse tipinde bir otomatik şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Elipseye gradyan biçimlendirmesi uygula.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Gradyanın yönünü ayarla.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # İki gradyan durak ekle.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # PPTX dosyasını diske kaydet.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Gradyan doldurmalı elips](gradient-fill.png)

Bir gradyan, dışa aktarılan bir görüntüde PowerPoint'tekinden farklı görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda depolanan gradyan doldurmayı değiştirmeden bir renderleme stili seçebilirsiniz.

## **Desen Doldurma**

PowerPoint'te Desen Doldurma, iki renkli bir tasarımı (nokta, şerit, çapraz çizgi veya dama) şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özel olarak seçebilirsiniz.

Aspose.Slides, sunumlarınıza görsel çekicilik katmak için 45'ten fazla önceden tanımlı desen stili sunar. Önceden tanımlı bir deseni seçtikten sonra bile, kullanılacak tam renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Arka Plan Rengi](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) ayarını yapın.
1. Desenin [Ön Plan Rengi](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) ayarını yapın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir dikdörtgene desen doldurma uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Dolgu tipini Pattern olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Desen stilini ayarla.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Desen arka plan ve ön plan renklerini ayarla.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # PPTX dosyasını diske kaydet.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Desenli doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'te Resim Doldurma, bir şeklin içine bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece görüntü şeklin arka planı gibi davranır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görüntüyü `SlidesPicture.setImage` metoduna geçirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Şu örnek dosyayı düşünelim: **lotus.png**.

![Lotus resmi](lotus.png)

Aşağıdaki Python kodu, bir şekle resim doldurma uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Dolgu tipini Picture olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Resim doldurma modunu ayarla.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Bir görüntü yükle ve sunum kaynaklarına ekle.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Resmi ayarla.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # PPTX dosyasını diske kaydet.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) sınıfının aşağıdaki metodlarını kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim doldurma modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içinde hizalanmasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin yatay ofsetini (point cinsinden) şeklin başlangıç noktasından ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin dikey ofsetini (point cinsinden) şeklin başlangıç noktasından ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki örnek kod, bir dikdörtgen şekline döşeme resimli doldurma eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    first_slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Şeklin dolgu tipini Picture olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Görüntüyü yükle ve sunum kaynaklarına ekle.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Görüntüyü şekle ata.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Resim doldurma modunu ve döşeme özelliklerini yapılandır.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # PPTX dosyasını diske kaydet.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

PowerPoint'te Katı Renk Doldurma, bir şekli tek bir düz renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurma uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şeklin doldurma rengini istediğiniz renge atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir PowerPoint slaytındaki dikdörtgene katı renk doldurma uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Dolgu tipini Solid olarak ayarla.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Dolgu rengini ayarla.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # PPTX dosyasını diske kaydet.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflığı Ayarlama**

PowerPoint'te bir şekle katı renk, gradyan, resim veya doku doldurması uyguladığınızda, doldurmanın opaklığını kontrol etmek için bir şeffaflık seviyesi de belirleyebilirsiniz. Daha yüksek bir şeffaflık değeri, şeklin daha çok görünebilir olmasını sağlar; arka plan veya alt nesneler kısmen görünür hale gelir.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şeffaflık (alfa bileşeni) içeren bir renk tanımlamak için [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) sınıfını kullanın.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, bir dikdörtgene şeffaf bir doldurma rengi uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Katı bir dikdörtgen otomatik şekil ekle.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # PPTX dosyasını diske kaydet.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimlerine göre konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, bir şekli 5 derece döndürmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # İlk slaytı al.
    slide = presentation.getSlides().get_Item(0)

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Şekli 5 derece döndür.
    shape.setRotation(5)

    # PPTX dosyasını diske kaydet.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3B Kiriş Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kiriş efektleri eklemenizi sağlar.

Bir şekle 3B kiriş etkisi eklemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) özelliklerini yapılandırarak kiriş ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, bir şekle 3B kiriş etkisi uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Slayta bir şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Şeklin ThreeDFormat özelliklerini ayarla.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![3B kiriş etkisi](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri eklemenizi sağlar.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) metodlarını kullanın.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, bir şekle 3B döndürme etkisi uygulamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![3B döndürme etkisi](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz Renderlemeyi Kontrol Etme**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) metodu, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl renderleneceğini belirtir. Bu metod tek başına siyah-beyaz görüntüyü etkinleştirmez ve normal renk modundaki şeklin dolgu, çizgi veya diğer biçimlendirmelerini değiştirmez.

İstenilen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) sınıfından bir değer kullanın. Örneğin, `Automatic` renderleme uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renklendirme kullanır, `BlackWhite` yalnızca siyah ve beyaz kullanır, `Black` ve `White` tek bir renk zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah-beyaz modunda gizler. `NotDefined` ise şekil seviyesinde bir mod atanmadığını gösterir.

Aşağıdaki Python kodu, renkli bir şekil oluşturur ve siyah-beyaz görüntüleme modunda gri görünmesini sağlar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Renkli modda turuncu dolgu korunur, ancak siyah-beyaz modunda şekil gri renkle renderlenir.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Normal renk modunda, dikdörtgen turuncu dolgu rengini korur. Siyah-beyaz görüntüleme iş akışında, modu `Gray` olarak ayarlandığı için gri renklendirme kullanılır. Böylece tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah-beyaz görüntüleme ayarlarını dikkate alan diğer iş akışları için ayrı bir görünüm tanımlayabilirsiniz.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Python kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) üzerindeki tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Yerleşimdeki bir yer tutucuya sahip olan slayttaki her şekli sıfırla.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Sadece çok az etkiler. Gömülü görüntüler ve medya dosyaları dosyanın çoğunu oluşturur; renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiç ek boyut oluşturmaz.

**Bir slayttaki aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stilleri aynı kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini kolaylaştırır.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine veya .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilleri klonlayın ve gerektiği yerde biçimlendirmeyi tekrar uygulayın.