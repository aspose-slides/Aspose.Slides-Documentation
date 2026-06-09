---
title: Python'da PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/python-net/shape-formatting/
keywords:
  - şekil biçimlendirme
  - çizgi biçimlendirme
  - bağlantı stili biçimlendirme
  - degrade doldurma
  - desen doldurma
  - resim doldurma
  - doku doldurma
  - düz renk doldurma
  - şekil şeffaflığı
  - şekil döndürme
  - 3B kavis efekti
  - 3B döndürme efekti
  - biçimlendirmeyi sıfırla
  - PowerPoint
  - sunum
  - Python
  - Aspose.Slides
description: "Aspose.Slides kullanarak Python'da PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için doldurma, çizgi ve efekt stillerini hassas ve tam kontrol ile ayarlayın."
---
## **Giriş**

PowerPoint'ta slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerini değiştirerek veya etkilere uygulayarak biçimlendirebilirsiniz. Ayrıca, iç kısımların nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![PowerPoint'ta şekil biçimlendirme](format-shape-powerpoint.png)

Aspose.Slides for Python, PowerPoint'ta mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve özellikler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. Aşağıdaki adımlar prosedürü özetlemektedir:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi genişliğini ayarlayın.
1. Şeklin [dash style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, bir dikdörtgen `AutoShape` nasıl biçimlendirileceğini gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Dikdörtgen tipinde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Dikdörtgen şeklin doldurma rengini ayarlayın.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Dikdörtgenin çizgi rengini ayarlayın.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # PPTX dosyasını diske kaydedin.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Bağlantı Stilini Biçimlendirme**

İşte üç adet bağlantı tipi seçeneği:

* Yuvarlak
* Miter
* Köşe

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirdiğinde **Round** ayarını kullanır. Ancak, keskin açıları olan bir şekil çizerken **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlantı stili](join-style-powerpoint.png)

Aşağıdaki Python kodu, yukarıdaki resimde gösterildiği gibi üç dikdörtgenin Miter, Bevel ve Round bağlantı tipi ayarları kullanılarak nasıl oluşturulduğunu gösterir:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

	# İlk slaytı alın.
	slide = presentation.slides[0]

	# Dikdörtgen tipinde üç otomatik şekil ekleyin.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Her bir dikdörtgen şeklin doldurma rengini ayarlayın.
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

	# Her bir dikdörtgenin çizgi rengini ayarlayın.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Bağlantı stilini ayarlayın.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Her bir dikdörtgene metin ekleyin.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# PPTX dosyasını diske kaydedin.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Degrade Doldurma**

PowerPoint'ta Degrade Doldurma, bir şekle sürekli bir renk karışımı uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi, birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulamanın yolu:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `GRADIENT` olarak ayarlayın.
1. İki tercih ettiğiniz rengi tanımlı konumlarla, [GradientFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/gradientformat/) sınıfının `gradient_stops` koleksiyonundaki `add` metodlarını kullanarak ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Elips tipinde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Elipseye degrade biçimlendirme uygulayın.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Degradeyin yönünü ayarlayın.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # İki adet degrade durak noktası ekleyin.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # PPTX dosyasını diske kaydedin.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Degrade doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint'ta Desen Doldurma, iki renkli bir tasarımı—nokta, çizgi, çapraz çizgi veya kare gibi—şekle uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla önceden tanımlı desen stiline sahiptir. Önceden tanımlı bir deseni seçtikten sonra bile kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulamanın yolu:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `PATTERN` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [back_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternformat/back_color/) özelliğini ayarlayın.
1. Desenin [fore_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternformat/fore_color/) özelliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Dikdörtgen tipinde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Doldurma tipini Pattern olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Desen stilini ayarlayın.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Desenin arka plan ve ön plan renklerini ayarlayın.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # PPTX dosyasını diske kaydedin.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint'ta Resim Doldurma, bir şeklin içine bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece görüntü şeklin arka planı olarak kullanılır.

Aspose.Slides kullanarak bir şekle resim doldurma uygulamanın yolu:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `PICTURE` olarak ayarlayın.
1. Resim doldurma modunu `TILE` (veya başka bir tercih edilen mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesi oluşturun.
1. Bu görüntüyü şeklin `picture_fill_format` içindeki `picture.image` özelliğine atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Diyelim ki aşağıdaki resme sahip bir "lotus.png" dosyamız var:

![Lotus resmi](lotus.png)

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Dikdörtgen tipinde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Doldurma tipini Picture olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Resim doldurma modunu ayarlayın.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Bir görüntü yükleyip sunum kaynaklarına ekleyin.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Resmi ayarlayın.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # PPTX dosyasını diske kaydedin.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Desen Olarak Döşeme Resmi**

Bir döşeme resmi olarak dokuyu ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) sınıfı özelliklerini kullanabilirsiniz:

- [picture_fill_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Resim doldurma modunu ayarlar—`TILE` veya `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_alignment/): Şekil içinde döşemelerin hizalamasını belirtir.
- [tile_flip](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_flip/): Döşemenin yatay, dikey ya da her ikisi yönünde çevrilip çevrilmeyeceğini kontrol eder.
- [tile_offset_x](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_offset_x/): Döşemenin (puan cinsinden) şeklin orijininin yatay ofsetini ayarlar.
- [tile_offset_y](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_offset_y/): Döşemenin (puan cinsinden) şeklin orijininin dikey ofsetini ayarlar.
- [tile_scale_x](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_scale_x/): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [tile_scale_y](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/tile_scale_y/): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşeme resmi doldurmalı bir dikdörtgen şekli eklemeyi ve döşeme seçeneklerini yapılandırmayı gösterir:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    first_slide = presentation.slides[0]

    # Bir dikdörtgen otomatik şekil ekleyin.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Şeklin doldurma tipini Picture olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Görüntüyü yükleyip sunum kaynaklarına ekleyin.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Görüntüyü şekle atayın.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Resim doldurma modunu ve döşeme özelliklerini yapılandırın.
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

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Doldurma**

PowerPoint'ta Düz Renk Doldurma, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, hiçbir degrade, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk doldurma uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) özelliğini `SOLID` olarak ayarlayın.
1. Şekle tercih ettiğiniz doldurma rengini atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Dikdörtgen tipinde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Doldurma tipini Solid olarak ayarlayın.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Doldurma rengini ayarlayın.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # PPTX dosyasını diske kaydedin.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Düz renk doldurulmuş şekil](solid-color-fill.png)

## **Şeffaflık Ayarla**

PowerPoint'ta bir şekle düz renk, degrade, resim veya doku doldurma uyguladığınızda, doldurmanın opaklığını kontrol etmek için bir şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha geçirgen olmasını sağlar ve arka planın ya da alttaki nesnelerin kısmen görünmesini mümkün kılar.

Aspose.Slides, doldurma için kullanılan renkteki alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Doldurma tipini `SOLID` olarak ayarlayın.
1. `Color.from_argb` kullanarak şeffaflık (alfa bileşeni) içeren bir renk tanımlayın.
1. Sunumu kaydedin.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]
    
    # Katı bir dikdörtgen otomatik şekil ekleyin.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım gereksinimlerine göre konumlandırırken yararlı olabilir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin `rotation` özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:

    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Dikdörtgen tipinde bir otomatik şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Şekli 5 derece döndürün.
    shape.rotation = 5

    # PPTX dosyasını diske kaydedin.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şekil döndürme](shape-rotation.png)

## **3B Kavis Efektleri Ekle**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B kavis efektleri uygulamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) ayarlarını yapılandırarak kavis ayarlarını tanımlayın.
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

Sonuç:

![3B kavis efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekle**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
1. Şeklin [camera_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/camera/camera_type/) ve [light_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/lightrig/light_type/) ayarlarını 3B döndürmeyi tanımlayacak şekilde yapın.
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

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Python kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Yerleşimde yer tutucu bulunan slayttaki her şekli sıfırla.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya alanının çoğunu kaplarken, renkler, efektler ve degradeler gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiç ek boyut eklemez.

**Bir slaytta aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm karşılık gelen değerler eşleşiyorsa, stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak için ayrı bir dosyada saklayabilir miyim?**

Evet. İstenilen stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilli şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.