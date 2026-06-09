---
title: Modern API ile Görüntü İşleme Yeteneğini Artırın
linktitle: Modern API
type: docs
weight: 280
url: /tr/python-net/modern-api/
keywords:
- modern API
- çizim
- slayt küçük resmi
- slayttan görüntüye
- şekil küçük resmi
- şekilden görüntüye
- sunum küçük resmi
- sunumdan görüntülere
- görüntü ekle
- resim ekle
- Python
- Aspose.Slides
description: "Eski görüntüleme API'lerini Python Modern API ile değiştirerek slayt görüntü işleme süreçlerini modernize edin ve PowerPoint ile OpenDocument otomasyonunu sorunsuz hale getirin."
---
## **Giriş**

Aspose.Slides for Python genel API'si şu anda aşağıdaki `aspose.pydrawing` türlerine bağımlıdır:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

24.4 sürümünden itibaren, bu genel API, Aspose.Slides for Python genel API'sindeki [değişiklikler](https://releases.aspose.com/slides/tr/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) nedeniyle **kullanımdan kaldırılmıştır**.

`aspose.pydrawing`'i genel API'den kaldırmak için **Modern API**'yi tanıttık. `aspose.pydrawing.Image` ve `aspose.pydrawing.Bitmap` kullanan yöntemler kullanımdan kaldırılmıştır ve Modern API eşdeğerleriyle değiştirilmelidir. `aspose.pydrawing.Graphics` kullanan yöntemler kullanımdan kaldırılmıştır ve doğrudan bir Modern API eşdeğeri yoktur.

Mevcut sürümlerde, `aspose.pydrawing`'e bağımlı genel API'yi eski/kullanımdan kaldırılmış olarak değerlendirin. Yeni kodlar için ve mevcut görüntü işleme iş akışlarını taşırken Modern API'yi kullanın.

## **Modern API**

Aşağıdaki sınıflar ve enum'lar genel API'ye eklenmiştir:

- [aspose.slides.IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imageformat/) - görüntü dosyası biçimini temsil eder.
- [aspose.slides.Images](https://reference.aspose.com/slides/tr/python-net/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) ile oluşturma ve çalışma yöntemlerini sağlar.

`get_image` ile tek bir slayt veya şekil oluşturun. `get_images` ile birden fazla sunum slaytı oluşturun. Görüntüleri yüklemek için [Images](https://reference.aspose.com/slides/tr/python-net/aspose.slides/images/) yöntemlerini, bir sunuma eklemek için `add_image` ile [IImage] ve mevcut bir sunum görüntüsünü güncellemek için `replace_image` ile [IImage] kullanın.

Yeni API için tipik bir kullanım senaryosu şu şekildedir:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Eski Kodu Modern API ile Değiştir**

Daha kolay bir geçiş için, yeni [IImage] sınıfı `aspose.pydrawing.Image` ve `aspose.pydrawing.Bitmap` sınıflarının ayrı API'lerini yansıtır. Çoğu durumda, `aspose.pydrawing` kullanan yöntem çağrılarını Modern API eşdeğerleriyle değiştirmeniz yeterlidir.

### **Bir Slayt Küçük Resmi Al**

**Kullanımdan Kaldırılmış API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Bir Şekil Küçük Resmi Al**

**Kullanımdan Kaldırılmış API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Bir Sunum Küçük Resmi Al**

**Kullanımdan Kaldırılmış API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Bir Sunuma Resim Ekleyin**

**Kullanımdan Kaldırılmış API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Kaldırılacak Yöntemler ve Özellikler ile Modern Değişiklikleri**

### **Presentation Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Slide Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Shape Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage Sınıfı**

|Yöntem/Özellik İmzası|Yerine Kullanılan Yöntem/Özellik İmzası|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output Sınıfı**

|Yöntem İmzası|Yerine Kullanılan Yöntem İmzası|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **aspose.pydrawing.Graphics için API Desteği**

`aspose.pydrawing.Graphics` kullanan yöntemler kullanımdan kaldırılmıştır ve doğrudan Modern API eşdeğeri yoktur.

`aspose.pydrawing.Graphics`'e render yapan API yerine Modern API görüntü renderleme yöntemlerini kullanın:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **SSS**

**`aspose.pydrawing.Graphics` neden kaldırıldı?**

`aspose.pydrawing.Graphics` desteği, render ve görüntülerle çalışma süreçlerini birleştirmek, platforma özgü bağımlılıkları ortadan kaldırmak ve [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) ile çapraz platform bir yaklaşıma geçmek için genel API'de kullanımdan kaldırıldı. `aspose.pydrawing.Graphics`'e render etmek yerine `get_image` veya `get_images` kullanın.

**[IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) kullanmanın `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`'a göre pratik faydası nedir?**

[IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) raster ve vektör görüntülerle çalışmayı birleştirir, [ImageFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imageformat/) aracılığıyla çeşitli biçimlere kaydetmeyi basitleştirir, pydrawing bağımlılığını azaltır ve kodun çevresel taşınabilirliğini artırır.

**Modern API, küçük resim oluşturma performansını etkiler mi?**

`get_thumbnail`'dan `get_image`'a geçiş senaryoları kötüleştirmez: yeni yöntemler aynı seçenekler ve boyutlarla görüntü üretme yeteneklerini sunar ve render seçeneklerini korur. Kazanç ya da kayıp belirli senaryoya bağlıdır, ancak işlevsel olarak değişimleri eşdeğerdir.