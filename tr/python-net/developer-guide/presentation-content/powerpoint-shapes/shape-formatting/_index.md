---
title: Python'da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/python-net/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- skeç efekti
- skeç şekil çizgisi
- eklem stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- katı renk dolgu
- şekil şeffaflığı
- siyah-beyaz şekil renderlaması
- gri tonlamalı şekil renderlaması
- şekil döndürme
- 3d köşe efekti
- 3d döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassas ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için dış hatlarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, şekillerin iç kısımlarının nasıl doldurulacağını kontrol eden ayarları belirterek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python, PowerPoint'ta mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve özellikler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [çizgi stili](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Şeklin [çizgi dash stili](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle (dikdörtgen) türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Dikdörtgen şeklinin dolgusunu kaldırın, böylece yalnızca çizgileri görünür.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Dikdörtgenin çizgi rengine ayarlayın.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX dosyasını diske kaydedin.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Sketch Efektlerini Uygulama**

Sketch efekti, bir şekil çizgisinin elle çizilmiş gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) , sketch ayarlarına erişmek için [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) , ve [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) enumarasyonundan bir değer seçmek için [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) kullanın.

Aşağıdaki Python kodu, bir [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) etkisini nasıl uygulayacağını, açıkça atanmış değeri nasıl okuyacağını ve [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) ile etkiyi nasıl kaldıracağını gösterir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Şeklin çizgi biçimine ve skeç biçimine erişin.
    sketch_format = shape.line_format.sketch_format

    # Bir skeç efekti uygulayın.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Şekle doğrudan atanmış skeç efektini okuyun.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Skeç efektini kaldırın.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

`SketchFormat.sketch_type` tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından kalıtılamıyorsa, [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) kullanın, dönen nesnenin `sketch_format` özelliğine erişin ve `sketch_type` özelliğini okuyun. Etkin değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Eklem Stilleri Biçimlendirme**

Üç eklem tipi seçeneği şunlardır:

* Yuvarlak
* Miter
* Bevel

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Yuvarlak** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki eklem stili](join-style-powerpoint.png)

Aşağıdaki Python kodu, yukarıdaki görüntüde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round eklem tipi ayarları kullanılarak nasıl oluşturulduğunu gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

	# İlk slaytı al.
	slide = presentation.slides[0]

	# Rectangle (dikdörtgen) türünde üç otomatik şekil ekleyin.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Her dikdörtgen şeklinin dolgu rengini ayarlayın.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Çizgi genişliğini ayarlayın.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Her dikdörtgenin çizgi rengini ayarlayın.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Eklem stilini ayarlayın.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Her dikdörtgene metin ekleyin.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# PPTX dosyasını diske kaydedin.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradyan Dolgu**

PowerPoint'ta Gradyan Dolgu, bir şekle sürekli renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, bir rengin yavaşça diğerine geçeceği şekilde iki veya daha fazla renk uygulayabilirsiniz.

Aşağıda Aspose.Slides kullanarak bir şekle gradyan dolgu uygulama adımları verilmiştir:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) özelliğini `GRADIENT` olarak ayarlayın.
1. İki tercih ettiğiniz rengi, tanımlı konumlarla birlikte, [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/) sınıfı tarafından sağlanan `gradient_stops` koleksiyonunun `add` metotlarını kullanarak ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Ellipse (elips) türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Elips'e gradyan biçimlendirmesi uygulayın.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Gradyanın yönünü ayarlayın.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # İki gradyan durağı ekleyin.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Gradyan dolgulu elips](gradient-fill.png)

Eğer bir gradyan, PowerPoint'takinden farklı bir dışa aktarılmış görüntüde görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda depolanan gradyan dolgu değişmeden bir render stili seçebilirsiniz.

## **Desen Dolgu**

PowerPoint'ta Pattern Fill, bir şekle iki renkli desen (nokta, çizgi, çapraz tarama veya kare gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir desen seçtikten sonra bile kullanılacak kesin renkleri belirleyebilirsiniz.

Aşağıda Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları verilmiştir:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) özelliğini `PATTERN` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stilini seçin.
1. Desenin [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) özelliğini ayarlayın.
1. Desenin [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) özelliğini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle (dikdörtgen) türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Dolgu tipini Pattern olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Desen stilini ayarlayın.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Desenin arka plan ve ön plan renklerini ayarlayın.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX dosyasını diske kaydedin.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Desenli dolgu içeren dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint'ta Picture Fill, bir şeklin içine bir resim eklemenizi sağlayan bir biçimlendirme seçeneğidir; bu sayede resmi şeklin arka planı olarak kullanabilirsiniz.

Aşağıda Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları verilmiştir:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) özelliğini `PICTURE` olarak ayarlayın.
1. Resim dolgu modunu `TILE` (veya tercih edilen başka bir mod) olarak ayarlayın.
1. [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) nesnesini kullanmak istediğiniz resimden oluşturun.
1. Bu resmi şeklin `picture_fill_format` özelliğindeki `picture.image` alanına atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Diyelim ki aşağıdaki resimle bir "lotus.png" dosyamız var:

![Lotus resmi](lotus.png)

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle (dikdörtgen) türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Dolgu tipini Picture olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Resim dolgu modunu ayarlayın.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Resmi ayarlayın.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX dosyasını diske kaydedin.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Resim dolgulu şekil](picture-fill.png)

### **Döşeme Resmi Olarak Doku**

Eğer döşenmiş bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) sınıfının aşağıdaki özelliklerini kullanabilirsiniz:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Resim dolgu modunu ayarlar—`TILE` veya `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Şekil içinde döşemelerin hizalamasını belirler.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Döşemenin şeklin orijininin (nokta cinsinden) yatay kaymasını ayarlar.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Döşemenin şeklin orijininin (nokta cinsinden) dikey kaymasını ayarlar.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    first_slide = presentation.slides[0]

    # Bir dikdörtgen otomatik şekil ekleyin.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Şeklin dolgu tipini Picture olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Görüntüyü şekle atayın.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Resim dolgu modunu ve döşeme özelliklerini yapılandırın.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # PPTX dosyasını diske kaydedin.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Dolgu**

PowerPoint'ta Solid Color Fill, bir şekli tek, tekdüze renkle dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aşağıdaki adımları izleyerek Aspose.Slides kullanarak bir şekle katı renk dolgu uygulayabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) özelliğini `SOLID` olarak ayarlayın.
1. Şekle tercih ettiğiniz dolgu rengini atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle (dikdörtgen) türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Dolgu tipini Solid olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Dolgu rengini ayarlayın.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX dosyasını diske kaydedin.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Katı renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflık Ayarlama**

PowerPoint'ta bir şekle katı renk, gradyan, resim veya doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol eden bir şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha fazla şeffaf olmasını sağlar ve arka planın veya altındaki nesnelerin kısmen görünür olmasına izin verir.

Aspose.Slides, dolgu için kullanılan renkteki alfa değerini ayarlayarak şeffaflık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Dolgu tipini `SOLID` olarak ayarlayın.
1. `Color.from_argb` kullanarak şeffaflık (alfa bileşeni) içeren bir renk tanımlayın.
1. Sunumu kaydedin.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]
    
    # Katı bir dikdörtgen otomatik şekil ekleyin.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayttaki şekli döndürmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin `rotation` özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı al.
    slide = presentation.slides[0]

    # Rectangle (dikdörtgen) türünde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Şekli 5 derece döndürün.
    shape.rotation = 5

    # PPTX dosyasını diske kaydedin.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Şekil döndürme](shape-rotation.png)

## **3D Köşe Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D köşe efektleri uygulamanızı sağlar.

Bir şekle 3D köşe efekti eklemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) özelliğini köşe ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Slayta bir şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Şeklin ThreeDFormat özelliklerini ayarlayın.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Sunumu PPTX dosyası olarak kaydedin.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![3D köşe efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri uygulamanızı sağlar.

Bir şekle 3D döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) ve [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) ayarlarını 3D döndürmeyi tanımlayacak şekilde ayarlayın.
1. Sunumu kaydedin.

```python
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Sunumu PPTX dosyası olarak kaydedin.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![3D döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz Renderlamayı Kontrol Etme**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) özelliği, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl renderlanacağını belirtir. Bu özellik tek başına siyah-beyaz görüntüyü etkinleştirmez ve normal renk modunda şeklin dolgu, çizgi veya diğer biçimlendirmelerini değiştirmez.

[BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) enumarasyonundan bir değer kullanarak istenen davranışı seçin. Örneğin, `AUTOMATIC` render uygulamasının dönüşümü seçmesine izin verir, `GRAY` ve `LIGHT_GRAY` gri renkleme kullanır, `BLACK_WHITE` sadece siyah ve beyaz kullanır, `BLACK` ve `WHITE` tek bir rengi zorlar, `COLOR` normal renklemeyi korur ve `HIDDEN` şekli siyah-beyaz modunda gizler. `NOT_DEFINED` ise şekil seviyesinde bir mod atanmamış anlamına gelir.

Aşağıdaki Python kodu, renkli bir şekil oluşturur ve siyah-beyaz görüntüleme modunda gri görünmesini sağlar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Renkli modda turuncu dolguyu koruyun, ancak şekli siyah-beyaz modda gri renkle renderlayın.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Normal renk modunda, dikdörtgen turuncu dolgusunu korur. Siyah-beyaz görüntüleme akışında, modu `GRAY` olarak ayarlandığı için gri renkte gösterilir. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah-beyaz görüntü ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanıza olanak sağlar.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Python kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) üzerindeki yer tutuculara sahip tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına geri döndürmeyi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Slayttaki düzen üzerinde yer tutucuya sahip her şekli sıfırla.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Şekil biçimlendirmesi son sunum dosya boyutunu etkiler mi?**

Yalnızca çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur, şekil parametreleri (renkler, efektler, gradyanlar) meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Bir slayttaki aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplandırabilirim?**

Eşleşen doldurma, çizgi ve efekt ayarları gibi temel biçimlendirme özelliklerini her şekil için karşılaştırın. Tüm karşılık gelen değerler eşleşiyorsa, stilleri aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir kümesini ayrı bir dosyada kaydedip diğer sunumlarda yeniden kullanabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilleri içeren şekilleri kopyalayın ve gerektiği yerde biçimlendirmeyi tekrar uygulayın.