---
title: Python'da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/python-net/shape-formatting/
keywords:
- şekil biçimlendirme
- satır biçimlendirme
- eskiz etkisi
- şekil çizgi eskizi
- bağlantı stili biçimlendirme
- gradyan doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil şeffaflığı
- siyah-beyaz şekil renderleme
- gri ölçek şekil renderleme
- şekli döndürme
- 3B keskinlik efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python’da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, satır ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, hatlarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, iç kısımların nasıl doldurulacağını kontrol eden ayarları belirterek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python, PowerPoint’te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve özellikler sunar.

## **Satırları Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir satır stili belirtebilirsiniz. İşlem adımları aşağıdaki gibidir:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [line style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linestyle/) özelliğini ayarlayın.  
1. Satır kalınlığını belirleyin.  
1. Şeklin [dash style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linedashstyle/) özelliğini ayarlayın.  
1. Şeklin satır rengini belirleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu bir dikdörtgen `AutoShape`’ın nasıl biçimlendirileceğini gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Dikdörtgen şeklinin dolgusunu kaldır, böylece yalnızca hatları görünür.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Dikdörtgenin hatlarına biçimlendirme uygula.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Dikdörtgenin hattının rengini ayarla.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX dosyasını diske kaydet.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The formatted lines in the presentation](formatted-lines.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape.line_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/line_format/) öğesini, eskiz ayarlarına erişmek için [LineFormat.sketch_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/lineformat/sketch_format/) öğesini ve [SketchFormat.sketch_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/sketchformat/sketch_type/) üzerinden [LineSketchType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linesketchtype/) değerlerinden birini seçebilirsiniz.

Aşağıdaki Python kodu, bir [LineSketchType.CURVED](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağınızı, doğrudan atanmış değeri nasıl okuyacağınızı ve [LineSketchType.NONE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linesketchtype/) ile efekti nasıl kaldıracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Şeklin satır formatına ve eskiz formatına eriş.
    sketch_format = shape.line_format.sketch_format

    # Bir eskiz efekti uygula.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Şekle doğrudan atanmış eskiz efektini oku.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Eskiz efektini kaldır.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` tarafından döndürülen değer, doğrudan şekle atanan ayarı temsil eder. Satır biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaytından devralınabiliyorsa, [LineFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/lineformat/get_effective/) yöntemini kullanın, dönen nesnenin `sketch_format` özelliğine erişin ve `sketch_type` özelliğini okuyun. Etkili değer, devralma çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Bağlantı Stillerini Biçimlendirme**

Üç bağlantı türü seçeneği vardır:

* Yuvarlak
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıyla (örneğin bir şeklin köşesinde) birleştirdiğinde **Yuvarlak** ayarını kullanır. Ancak, keskin açılı bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![The join style in the presentation](join-style-powerpoint.png)

Aşağıdaki Python kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Round bağlantı türü ayarlarıyla üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

	# İlk slaytı al.
	slide = presentation.slides[0]

	# Rectangle tipinde üç otomatik şekil ekle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Her dikdörtgen şeklinin dolgu rengini ayarla.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Satır kalınlığını ayarla.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Her dikdörtgenin hattının rengini ayarla.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Bağlantı stilini ayarla.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Her dikdörtgene metin ekle.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# PPTX dosyasını diske kaydet.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradyan Doldurma**

PowerPoint’te Gradyan Doldurma, bir şekle kesintisiz bir renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin yavaşça diğerine karıştığı bir şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `GRADIENT` olarak ayarlayın.  
1. [GradientFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/gradientformat/) sınıfının `gradient_stops` koleksiyonundaki `add` metodlarını kullanarak konumları tanımlı iki rengi ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu bir elips üzerinde gradyan doldurma etkisinin nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Ellipse tipinde bir otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Elipsa gradyan biçimlendirmesi uygula.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Gradyanın yönünü ayarla.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # İki gradyan durdurma noktası ekle.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTX dosyasını diske kaydet.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The ellipse with gradient fill](gradient-fill.png)

## **Desen Doldurma**

PowerPoint’te Desen Doldurma, iki renkli bir tasarımı (nokta, çizgi, çapraz çizgi veya kare gibi) bir şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini istediğiniz gibi seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra hâlâ kullanılacak kesin renkleri belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `PATTERN` olarak ayarlayın.  
1. Ön tanımlı seçeneklerden bir desen stili seçin.  
1. Desenin [back_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternformat/back_color/) özelliğini ayarlayın.  
1. Desenin [fore_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternformat/fore_color/) özelliğini ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu bir dikdörtgen üzerinde desen doldurmanın nasıl yapılacağını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Doldurma tipini Pattern olarak ayarla.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Desen stilini ayarla.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Desen arka plan ve ön plan renklerini ayarla.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX dosyasını diske kaydet.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The rectangle with pattern fill](pattern-fill.png)

## **Resim Doldurma**

PowerPoint’te Resim Doldurma, bir şeklin içine bir görüntü yerleştirmenizi ve resmi şeklin arka planı gibi kullanmanızı sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `PICTURE` olarak ayarlayın.  
1. Resim doldurma modunu `TILE` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.  
1. Kullanmak istediğiniz görselden bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.  
1. Bu görseli şeklin `picture_fill_format`’undaki `picture.image` özelliğine atayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki görsel “lotus.png” dosyasını göstermektedir:

![The lotus picture](lotus.png)

Aşağıdaki Python kodu bir şekle resim doldurmanın nasıl yapılacağını gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Doldurma tipini Picture olarak ayarla.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Resim doldurma modunu ayarla.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Bir görüntü yükle ve sunum kaynaklarına ekle.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Resmi ayarla.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX dosyasını diske kaydet.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The shape with picture fill](picture-fill.png)

### **Resmi Doku Olarak Döşeme**

Döşeme şeklinde bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) sınıfının aşağıdaki özelliklerini kullanabilirsiniz:

- [picture_fill_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Resim doldurma modunu `TILE` ya da `STRETCH` olarak ayarlar.  
- [tile_alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_alignment/): Döşemelerin şekil içinde nasıl hizalanacağını belirler.  
- [tile_flip](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_flip/): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.  
- [tile_offset_x](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_offset_x/): Döşemenin şeklin orijinalinden yatay ofsetini (puan cinsinden) ayarlar.  
- [tile_offset_y](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_offset_y/): Döşemenin şeklin orijinalinden dikey ofsetini (puan cinsinden) ayarlar.  
- [tile_scale_x](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_scale_x/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.  
- [tile_scale_y](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_scale_y/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekli ekleyip döşeme resim doldurması ve döşeme seçeneklerini yapılandırmanın nasıl yapıldığını gösterir:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    first_slide = presentation.slides[0]

    # Rectangle otomatik şekli ekle.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Şeklin doldurma tipini Picture olarak ayarla.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Görüntüyü yükle ve sunum kaynaklarına ekle.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Görüntüyü şekle ata.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Resim doldurma modunu ve döşeme özelliklerini yapılandır.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # PPTX dosyasını diske kaydet.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The tile options](tile-options.png)

## **Düz Renk Doldurma**

PowerPoint’te Düz Renk Doldurma, bir şekli tek bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `SOLID` olarak ayarlayın.  
1. İstediğiniz dolgu rengini şekle atayın.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu bir PowerPoint slaydında bir dikdörtgene düz renk doldurma nasıl uygulanır gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Doldurma tipini Solid olarak ayarla.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Doldurma rengini ayarla.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX dosyasını diske kaydet.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The shape with solid color fill](solid-color-fill.png)

## **Saydamlık Ayarlama**

PowerPoint’te bir şekle düz renk, gradyan, resim ya da doku doldurması uyguladığınızda, doldurmanın saydamlık seviyesini de ayarlayarak opaklığını kontrol edebilirsiniz. Yüksek saydamlık değeri, şeklin daha şeffaf olmasını sağlar ve arka plan ya da alt nesnelerin bir kısmının görünmesine izin verir.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak saydamlık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Dolgu tipini `SOLID` olarak ayarlayın.  
1. `Color.from_argb` kullanarak saydamlığı olan bir renk tanımlayın (`alpha` bileşeni saydamlığı kontrol eder).  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bir dikdörtgene saydam dolgu rengi nasıl uygulanır gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]
    
    # Katı bir dikdörtgen otomatik şekil ekle.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The transparent shape](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalamalar veya tasarım gereksinimleri doğrultusunda konumlandırırken yararlı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin `rotation` özelliğini istediğiniz açıya (derece) ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bir şekli 5 derece döndürmenin nasıl yapılacağını gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını oluştur.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle tipinde bir otomatik şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Şekli 5 derece döndür.
    shape.rotation = 5

    # PPTX dosyasını diske kaydet.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The shape rotation](shape-rotation.png)

## **3B Keskinlik Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B keskinlik (bevel) efektleri uygulamanıza olanak tanır.

Bir şekle 3B keskinlik efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) özelliğini yapılandırarak keskinlik ayarlarını tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bir şekle 3B keskinlik efektinin nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Slayta bir şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Şeklin ThreeDFormat özelliklerini ayarla.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Sunumu PPTX dosyası olarak kaydet.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The 3D bevel effect](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza olanak tanır.

Bir şekle 3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta referans alın.  
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
1. Şeklin [camera_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/camera/camera_type/) ve [light_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/lightrig/light_type/) özelliklerini ayarlayarak 3B döndürmeyi tanımlayın.  
1. Sunumu kaydedin.

Aşağıdaki Python kodu bir şekle 3B döndürme efektinin nasıl uygulanacağını gösterir:

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Sunumu PPTX dosyası olarak kaydet.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![The 3D rotation effect](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz Renderlama Kontrolü**

[Shape.black_white_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/black_white_mode/) özelliği, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl renderlanacağını belirler. Bu özellik tek başına siyah-beyaz gösterimi etkinleştirmez ve normal renk modunda şeklin dolgu, satır veya diğer biçimlendirmesini değiştirmez.

[BlackWhiteMode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/blackwhitemode/) enum’undan bir değer alarak istenen davranışı seçebilirsiniz. Örneğin, `AUTOMATIC` renderlayıcıya dönüşümü seçtirir, `GRAY` ve `LIGHT_GRAY` gri renkleme kullanır, `BLACK_WHITE` yalnızca siyah ve beyazı, `BLACK` ve `WHITE` tek bir rengi zorlar, `COLOR` normal renklemeyi korur ve `HIDDEN` şekli siyah-beyaz modunda gizler. `NOT_DEFINED` ise şekil düzeyinde bir mod atanmadığını gösterir.

Aşağıdaki Python kodu renkli bir şekil oluşturur ve siyah‑beyaz gösterim modunda gri görünmesini sağlar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Turuncu dolguyu renk modunda tut, ancak şekli siyah-beyaz modunda gri renkle render et.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Normal renk modunda dikdörtgen turuncu dolgu ile kalır. Siyah‑beyaz gösterim iş akışında ise modu `GRAY` olduğu için gri renkte gösterilir. Bu, tam renkli bir slaytı korurken baskı, ön izleme gibi siyah‑beyaz ayarlarını saygı gösteren iş akışları için ayrı bir görünüm tanımlamanıza olanak tanır.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Python kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) üzerindeki tüm placeholder’ların konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürmeyi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Yer tutucuya sahip olan slayttaki her şekli sıfırla.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya boyutunun büyük kısmını oluşturur, şekil parametreleri (renkler, efektler, gradyanlar vb.) ise meta veri olarak saklanır ve neredeyse hiç ekstra yer kaplamaz.

**Aynı biçimlendirmeye sahip şekilleri slaytta nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, satır ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı kabul edip mantıksal olarak gruplandırın; bu, sonraki stil yönetimini kolaylaştırır.

**Özel şekil stillerini başka sunumlarda kullanmak üzere ayrı bir dosyada saklayabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt paketinde veya .POTX şablon dosyasında tutabilirsiniz. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.