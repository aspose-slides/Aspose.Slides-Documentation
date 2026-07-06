---
title: Python ile Sunumlara Resim Çerçeveleri Ekle
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/python-net/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- görsel ekle
- görsel oluştur
- görsel çıkar
- raster görüntü
- vektör görüntü
- görüntüyü kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreli ölçek
- görsel efekt
- en-boy oranı
- görsel şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin."
---
## **Giriş**

Aspose.Slides for Python'daki resim çerçeveleri, raster ve vektör görüntüleri yerel slayt şekilleri olarak yerleştirmenize ve yönetmenize olanak tanır. Dosyalardan veya akışlardan resimleri ekleyebilir, kesin koordinatlarla konumlandırıp yeniden boyutlandırabilir, döndürme uygulayabilir, şeffaflığı ayarlayabilir ve diğer şekillerle birlikte z‑sırasını kontrol edebilirsiniz. API ayrıca kırpma, en‑boy oranını koruma, kenarlık ve efekt ayarlama ve yerleşimi yeniden oluşturmayarak temel görüntüyü değiştirme özelliklerini destekler. Resim çerçeveleri normal şekiller gibi davrandığından animasyonlar, köprüler ve alt metin ekleyebilir, görsel olarak zengin, erişilebilir sunumlar oluşturmayı kolaylaştırır.

## **Resim Çerçeveleri Oluşturma**

Bu bölüm, Aspose.Slides for Python ile bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) oluşturarak bir kaydı slayta nasıl ekleyeceğinizi gösterir. Görüntüyü nasıl yükleyeceğinizi, slayta tam olarak nasıl yerleştireceğinizi ve boyut ve biçimlendirmesini nasıl kontrol edeceğinizi öğreneceksiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayt alın.  
3. Sunumun [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) öğesine görüntüyü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) oluşturun. Bu görüntü şekli doldurmak için kullanılacaktır.  
4. Çerçevenin genişliğini ve yüksekliğini belirtin.  
5. Bu boyutta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) oluşturmak için [add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) metodunu kullanın.  
6. Sunumu PPTX dosyası olarak kaydedin.

Bu sonraki Python kodu, bir resim çerçevesinin nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides

# PPTX dosyasını temsil edecek Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Görüntüyü sunuma ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Görüntü boyutunda bir resim çerçevesi ekleyin.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Sunumu PPTX olarak kaydedin.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Resim çerçeveleri, görüntülerden sunum slaytları oluşturmayı hızlı bir şekilde sağlar. Resim çerçevelerini Aspose.Slides kaydetme seçenekleriyle birleştirdiğinizde, görüntüleri bir biçimden başka bir biçime dönüştürmek için I/O operasyonlarını kontrol edebilirsiniz. Aşağıdaki sayfalara bakmak isteyebilirsiniz: [görüntüyü JPG'ye dönüştür](https://products.aspose.com/slides/tr/python-net/conversion/image-to-jpg/); [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-image/); [JPG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-png/); [PNG'yi JPG'ye dönüştür](https://products.aspose.com/slides/tr/python-net/conversion/png-to-jpg/); [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/python-net/conversion/png-to-svg/); [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Göreli Ölçekli Resim Çerçeveleri Oluşturma**

Bu bölüm, bir görüntünün sabit bir boyutta yerleştirilmesini ve ardından genişliği ile yüksekliğine bağımsız olarak yüzde bazlı ölçekleme uygulanmasını gösterir. Yüzdeler farklı olabileceği için en‑boy oranı değişebilir. Ölçekleme, görüntünün özgün boyutlarına göre yapılır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayt alın.  
3. Sunumun [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) öğesine görüntüyü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) oluşturun.  
4. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ekleyin.  
5. Resim çerçevesinin göreli genişliğini ve yüksekliğini ayarlayın.  
6. Sunumu PPTX dosyası olarak kaydedin.

Bu sonraki Python kodu, göreli ölçekleme ile bir resim çerçevesinin nasıl oluşturulacağını gösterir:

```py
import aspose.slides as slides

# PPTX dosyasını temsil edecek Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Slayta bir resim çerçevesi ekleyin.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Göreli ölçek genişliğini ve yüksekliğini ayarlayın.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Sunumu kaydedin.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Resim Çerçevelerinden Raster Görüntüleri Çıkarma**

Raster görüntüleri, [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) nesnelerinden çıkarabilir ve PNG, JPG ve diğer biçimlerde kaydedebilirsiniz. Aşağıdaki kod örneği, "sample.pptx" belgesinden bir görüntüyü nasıl çıkarıp PNG biçiminde kaydedeceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Resim Çerçevelerinden SVG Görüntüleri Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) şekilleri içinde yer alan SVG grafikler içerdiğinde, Aspose.Slides for Python via .NET, orijinal vektör görüntüleri tam bütünlüğüyle almanızı sağlar. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame]'i tanımlayabilir, altında bulunan [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/)'in SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG biçiminde diske veya akışa kaydedebilirsiniz.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Görsel Şeffaflığını Almak**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanıza olanak tanır. Bu Python kodu işlemi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Tüm görüntülere uygulanan efektler [aspose.slides.effects](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/) içinde bulunabilir.
{{% /alert %}}

## **Bir Görüntünün Parlaklık ve Kontrastını Almak**

Aspose.Slides, bir görüntüye uygulanan parlaklık ve kontrast etkisini almanıza olanak tanır. [Luminance](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/luminance/) sınıfı bu görüntü dönüşüm etkisini temsil eder.

Bu Python kodu, bir resim çerçevesinden parlaklık ve kontrast ayarlarını nasıl alacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulayabileceğiniz çok sayıda biçimlendirme seçeneği sunar. Bu seçeneklerle bir resim çerçevesini belirli gereksinimlere göre ayarlayabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayt alın.  
3. Sunumun [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) öğesine görüntüyü ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) oluşturun. Bu görüntü şekli doldurmak için kullanılacaktır.  
4. Çerçevenin genişliğini ve yüksekliğini belirtin.  
5. Bu boyutta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) oluşturmak için slaytın [add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) metodunu kullanın.  
6. Resim çerçevesinin çizgi rengini ayarlayın.  
7. Resim çerçevesinin çizgi kalınlığını ayarlayın.  
8. Resim çerçevesini pozitif (saat yönünde) ya da negatif (saat yönünün tersinde) bir değer vererek döndürün.  
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, resim çerçevesi biçimlendirme sürecini gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyasını temsil edecek Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Görüntü boyutunda bir resim çerçevesi ekleyin.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Resim çerçevesine biçimlendirme uygulayın.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Sunumu PPTX olarak kaydedin.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose, ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirdi. JPG/JPEG veya PNG görüntülerini birleştirmeniz veya fotoğraf ızgaraları oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz.
{{% /alert %}}

## **Görselleri Bağlantı Olarak Ekle**

Sunum dosyalarını küçük tutmak için, dosyaları doğrudan gömmek yerine görselleri veya videoları bağlantı olarak ekleyebilirsiniz. Aşağıdaki Python kodu, bir yer tutucuya bir görsel ve bir video nasıl eklenir gösterir:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Görselleri Kırpma**

Bu bölümde, bir resim çerçevesindeki görüntünün görünür alanını kaynak dosyayı değiştirmeden nasıl kırpacağınızı öğreneceksiniz. Ayrıca, kırpma kenar boşluklarını uygulayarak slaytta temiz, odaklanmış bir kompozisyon oluşturmanın temel yöntemini de öğreneceksiniz.

Aşağıdaki Python kodu, bir slaytta bir görüntüyü nasıl kırpacağınızı gösterir:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Slayta bir resim çerçevesi ekleyin.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Görüntüyü kırp (yüzde değerleri).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Sonucu kaydedin.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Görsellerin Kırpılmış Alanlarını Silme**

Bir çerçevedeki bir görüntünün kırpılmış alanlarını silmek istiyorsanız, [delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) metodunu kullanın. Bu metod, kırpılmış görüntüyü ya da kırpma gerekmezse orijinal görüntüyü döndürür.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # İlk slayttan PictureFrame alın.
    picture_frame = slides.shape[0]

    # İlk slayttan PictureFrame alın.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Sonucu kaydedin.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) metodu, kırpılmış görüntüyü sunumun image collection'ına ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu sunum boyutunu azaltabilir; aksi takdirde, sonuçtaki sunumdaki görüntü sayısı artabilir.

Kırpma sırasında, bu metod WMF/EMF metafilelerini raster PNG görüntüsüne dönüştürür.
{{% /alert %}}

## **Görselleri Sıkıştırma**

Bir sunumda bir resmi, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/compress_image/) metodunu kullanarak sıkıştırabilirsiniz.  
Bu metod, görüntüyü şekil boyutu ve belirtilen çözünürlüğe göre boyutunu azaltarak sıkıştırır ve kırpılmış alanları silme seçeneği sunar.

Resmin boyut ve çözünürlüğünü, PowerPoint'teki **Picture Format -> Compress Pictures -> Resolution** özelliğine benzer şekilde ayarlar.

Aşağıdaki Python örnekleri, hedef bir çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Görüntüyü hedef çözünürlük 150 DPI (Web çözünürlüğü) ile sıkıştırın ve kırpılmış alanları kaldırın.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Sıkıştırmanın sonucunu kontrol edin.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Veya doğrudan özel bir DPI değeri kullanarak:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Görüntüyü 150 DPI'ye (web çözünürlüğü) sıkıştırın ve kırpılmış alanları kaldırın.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metod, görüntüyü şeklin boyutu ve verilen DPI'ye göre daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler dosya boyutunu optimize etmek için silinebilir.  
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca, JPEG kalitesi çözünürlüğe göre korunur veya hafifçe azaltılır; bu, PowerPoint'in yüksek çözünürlüklü JPEG'leri işlemesiyle benzer şekildedir.
{{% /alert %}}

## **En‑Boy Oranını Kilitle**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdikten sonra en‑boy oranını korumasını istiyorsanız, [aspect_ratio_locked](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) özelliğini `True` olarak ayarlayın.

Aşağıdaki Python kodu, bir şeklin en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Yeniden boyutlandırırken en-boy oranını kilitle.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en‑boy oranını korur, içindeki görüntünün en‑boy oranını değil.
{{% /alert %}}

## **Stretch Offset Özelliklerini Kullanma**

[PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) sınıfının `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` ve `stretch_offset_bottom` özelliklerini kullanarak bir doldurma dikdörtgeni tanımlayabilirsiniz.

Bir görüntü için stretching belirtildiğinde, kaynak dikdörtgen doldurma dikdörtgenine sığacak şekilde ölçeklenir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde olarak bir offset ile tanımlanır. Pozitif yüzde bir içeri çekme, negatif yüzde ise dışarı itme anlamına gelir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre bir slayta referans alın.  
3. Dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.  
4. Şeklin doldurma tipini ayarlayın.  
5. Şeklin resim doldurma modunu ayarlayın.  
6. Bir görüntü yükleyin.  
7. Görüntüyü şekli doldurmak için atayın.  
8. Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarlarından offsetlerini belirtin.  
9. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, Stretch Offset özelliklerini nasıl kullanacağınızı gösterir:

```py
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Bir dikdörtgen AutoShape ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Şeklin doldurma tipini ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Şeklin resim doldurma modunu ayarlayın.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Görüntüyü yükleyin ve sunuma ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Görüntüyü şekli doldurması için atayın.
    shape.fill_format.picture_fill_format.picture.image = image

    # Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarlarından offsetlerini belirtin.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX dosyasını diske kaydedin.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose, ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlayarak görüntülerden hızlı bir şekilde sunum oluşturmanıza imkan tanır.
{{% /alert %}}

## **FAQ**

**PictureFrame için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**

Aspose.Slides, bir [PictureFrame]'e atanan görüntü nesnesi aracılığıyla raster görüntüleri (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüleri (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüşüm motorunun yetenekleriyle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX boyutunu ve performansını nasıl etkiler?**

Büyük görüntülerin gömülmesi dosya boyutunu ve bellek kullanımını artırır; görüntüleri bağlamak sunum boyutunu düşük tutmaya yardımcı olur ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme imkanı sunar.

**Bir görüntü nesnesinin yanlışlıkla taşınmasını/yeniden boyutlandırılmasını nasıl kilitleyebilirim?**

[shape locks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/picture_frame_lock/) özelliğini bir [PictureFrame] için kullanın (örneğin, taşıma veya yeniden boyutlandırmayı devre dışı bırakın). Kilitleme mekanizması, şekiller için ayrı bir [koruma makalesinde](/slides/tr/python-net/applying-protection-to-presentation/) açıklanmıştır ve [PictureFrame] dahil çeşitli şekil türleri için desteklenir.

**Bir sunumu PDF/görüntülere dışa aktarırken SVG vektör doğruluğu korunur mu?**

Aspose.Slides, bir [PictureFrame]'den orijinal vektör olarak SVG çıkartılmasına izin verir. PDF'e ya da raster formatlara dışa aktarırken, ayarlara bağlı olarak sonuç rasterleştirilebilir; orijinal SVG'nin bir vektör olarak saklandığı, çıkarma davranışıyla doğrulanır.