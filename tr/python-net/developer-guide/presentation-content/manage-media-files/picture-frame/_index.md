---
title: Python ile Sunumlara Resim Çerçeveleri Ekleme
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
- raster görsel
- vektör görsel
- görsel kırp
- kırpılmış alan
- StretchOff özelliği
- resim çerçevesi biçimlendirme
- resim çerçevesi özellikleri
- göreceli ölçek
- görsel efekti
- en-boy oranı
- görsel şeffaflığı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarına resim çerçeveleri ekleyin. İş akışınızı kolaylaştırın ve slayt tasarımlarını geliştirin.
---
## **Giriş**

Aspose.Slides for Python içindeki resim çerçeveleri, raster ve vektör görüntüleri yerel slayt şekilleri olarak yerleştirmenizi ve yönetmenizi sağlar. Dosyalardan veya akışlardan resimler ekleyebilir, kesin koordinatlarla konumlandırıp yeniden boyutlandırabilir, döndürme uygulayabilir, şeffaflık ayarlayabilir ve diğer şekillerle birlikte z-sırasını kontrol edebilirsiniz. API ayrıca kırpma, en-boy oranını koruma, kenarlık ve efekt ayarlama ve düzeni yeniden oluşturmak zorunda kalmadan temel görüntüyü değiştirme desteği sunar. Resim çerçeveleri normal şekiller gibi davrandığı için animasyonlar, köprüler ve alt metin ekleyebilir, görsel açıdan zengin ve erişilebilir sunumlar oluşturmayı kolaylaştırır.

## **Resim Çerçeveleri Oluşturma**

Bu bölüm, Aspose.Slides for Python kullanarak bir slayta görüntü eklemek için bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) oluşturmayı gösterir. Görüntüyü nasıl yükleyeceğinizi, slaytta tam olarak nasıl konumlandıracağınızı ve boyutunu ve biçimlendirmesini nasıl kontrol edeceğinizi öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt alın.
3. Görüntüyü sunumun [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) öğesine ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) oluşturun. Bu görüntü şekli doldurmak için kullanılacaktır.
4. Çerçevenin genişliğini ve yüksekliğini belirtin.
5. [add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) yöntemini kullanarak o boyutta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) oluşturun.
6. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu bir resim çerçevesi oluşturmayı gösterir:

```py
import aspose.slides as slides

# PPTX dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Görüntüyü sunuma ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Görüntünün boyutunda bir resim çerçevesi ekleyin.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Sunumu PPTX olarak kaydedin.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Resim çerçeveleri, görüntülerden hızlı bir şekilde sunum slaytları oluşturmanıza olanak tanır. Resim çerçevelerini Aspose.Slides kaydetme seçenekleriyle birleştirerek, görüntüleri bir biçimden başka bir biçime dönüştürmek için I/O işlemlerini kontrol edebilirsiniz. Şu sayfalara da göz atmak isteyebilirsiniz: [image to JPG](https://products.aspose.com/slides/tr/python-net/conversion/image-to-jpg/) dönüştür; [JPG to image](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-image/) dönüştür; [JPG to PNG](https://products.aspose.com/slides/tr/python-net/conversion/jpg-to-png/) dönüştür; [PNG to JPG](https://products.aspose.com/slides/tr/python-net/conversion/png-to-jpg/) dönüştür; [PNG to SVG](https://products.aspose.com/slides/tr/python-net/conversion/png-to-svg/) dönüştür; [SVG to PNG](https://products.aspose.com/slides/tr/python-net/conversion/svg-to-png/) dönüştür.
{{% /alert %}}

## **Göreceli Ölçekle Resim Çerçeveleri Oluşturma**

Bu bölüm, bir görüntüyü sabit bir boyutta yerleştirip ardından genişlik ve yükseklik için yüzde bazlı ölçeklemeyi bağımsız olarak uygulamayı gösterir. Yüzdeler farklı olduğundan en-boy oranı değişebilir. Ölçekleme, görüntünün orijinal boyutlarına göre yapılır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt alın.
3. Görüntüyü sunumun [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) öğesine ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) oluşturun.
4. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ekleyin.
5. Resim çerçevesinin göreceli genişliğini ve yüksekliğini ayarlayın.
6. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu, göreceli ölçekleme ile bir resim çerçevesi oluşturmayı gösterir:

```py
import aspose.slides as slides

# PPTX dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Slayta bir resim çerçevesi ekleyin.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Göreceli ölçek genişliğini ve yüksekliğini ayarlayın.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Sunumu kaydedin.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Resim Çerçevelerinden Raster Görüntü Çıkarma**

[PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) nesnelerinden raster görüntüler çıkarabilir ve PNG, JPG ve diğer biçimlerde kaydedebilirsiniz. Aşağıdaki kod örneği, “sample.pptx” belgesinden bir görüntüyü çıkarıp PNG formatında kaydetmeyi gösterir.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Resim Çerçevelerinden SVG Görüntü Çıkarma**

Bir sunum, [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) şekilleri içinde SVG grafikler içerdiğinde, Aspose.Slides for Python via .NET, orijinal vektör görüntülerini tam sadakatle almanıza olanak tanır. Slaytın şekil koleksiyonunu dolaşarak her bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) öğesini tanımlayabilir, temel [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesinin SVG içeriği taşıyıp taşımadığını kontrol edebilir ve ardından bu görüntüyü yerel SVG biçiminde diske veya akışa kaydedebilirsiniz.

Aşağıdaki kod örneği, bir resim çerçevesinden SVG görüntüsü çıkarmayı gösterir:

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

## **Görüntü Şeffaflığını Alma**

Aspose.Slides, bir görüntüye uygulanan şeffaflık etkisini almanızı sağlar. Bu Python kodu işlemi gösterir:

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
Görüntülere uygulanan tüm efektler [aspose.slides.effects](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/) içinde bulunabilir.
{{% /alert %}}

## **Resim Çerçevesi Biçimlendirme**

Aspose.Slides, bir resim çerçevesine uygulayabileceğiniz birçok biçimlendirme seçeneği sunar. Bu seçeneklerle bir resim çerçevesini belirli gereksinimlere göre ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt alın.
3. Görüntüyü sunumun [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) öğesine ekleyerek bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) oluşturun. Bu görüntü şekli doldurmak için kullanılacaktır.
4. Çerçevenin genişliğini ve yüksekliğini belirtin.
5. Slaytın [add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) yöntemini kullanarak o boyutta bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) oluşturun.
6. Resim çerçevesinin kenar rengini ayarlayın.
7. Resim çerçevesinin kenar genişliğini ayarlayın.
8. Pozitif (saat yönünde) veya negatif (saat yönünün tersinde) bir değer sağlayarak resim çerçevesini döndürün.
9. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu resim çerçevesi biçimlendirme sürecini gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyasını temsil etmek için Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Görüntünün boyutunda bir resim çerçevesi ekleyin.
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
Aspose, ücretsiz bir [Collage Maker](https://products.aspose.app/slides/tr/collage) geliştirmiştir. JPG/JPEG veya PNG görüntüleri birleştirmeniz, fotoğraf ızgaraları oluşturmanız gerektiğinde bu hizmeti kullanabilirsiniz.
{{% /alert %}}

## **Resimleri Bağlantı Olarak Ekleme**

Sunum dosyalarının boyutunu düşük tutmak için, dosyaları doğrudan sunuma gömmek yerine, resimleri veya videoları bağlantılar aracılığıyla ekleyebilirsiniz. Aşağıdaki Python kodu, bir yer tutucuya bir resim ve bir video nasıl eklenir gösterir:

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

## **Görüntüleri Kırpma**

Bu bölümde, bir resim çerçevesindeki görüntünün görünür alanını, kaynak dosyayı değiştirmeden nasıl kırpacağınızı öğreneceksiniz. Ayrıca, kaydırma kenar boşlukları uygulayarak slaytta temiz ve odaklanmış bir kompozisyon oluşturmanın temel yöntemini öğreneceksiniz.

Aşağıdaki Python kodu bir slayttaki görüntüyü kırpmayı gösterir:

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

## **Kırpılmış Görüntü Alanlarını Silme**

Bir çerçevedeki görüntünün kırpılmış alanlarını silmek istiyorsanız, [delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) yöntemini kullanın. Bu yöntem, kırpılmış görüntüyü döndürür; kırpma gerekmezse orijinal görüntüyü döndürür.

Aşağıdaki Python kodu işlemi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # İlk slayttan PictureFrame'i alın.
    picture_frame = slides.shape[0]

    # İlk slayttan PictureFrame'i alın.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Sonucu kaydedin.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
[delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) yöntemi, kırpılmış görüntüyü sunumun görüntü koleksiyonuna ekler. Görüntü yalnızca işlenen [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) içinde kullanılıyorsa, bu sunum boyutunu azaltabilir; aksi takdirde sonuç sunumdaki görüntü sayısı artabilir.

Kırpma sırasında bu yöntem, WMF/EMF metafile'lerini raster PNG görüntüsüne dönüştürür.
{{% /alert %}}

## **Görüntüleri Sıkıştırma**

Bir sunumdaki resmi, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/compress_image/) yöntemiyle sıkıştırabilirsiniz.
Bu yöntem, şekil boyutu ve belirtilen çözünürlüğe göre görüntüyü küçülterek sıkıştırır; kırpılmış alanları silme seçeneği de vardır.

PowerPoint'in **Picture Format -> Compress Pictures -> Resolution** özelliğine benzer şekilde resmin boyut ve çözünürlüğünü ayarlar.

Aşağıdaki Python örnekleri, hedef çözünürlük belirleyerek ve isteğe bağlı olarak kırpılmış alanları kaldırarak bir sunumdaki görüntüyü nasıl sıkıştıracağınızı gösterir:

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

    # Görüntüyü 150 DPI'ye (web çözünürlüğü) sıkıştırın, kırpılmış alanları kaldırarak.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Yöntem, şeklin boyutu ve sağlanan DPI temelinde görüntüyü daha düşük bir çözünürlüğe dönüştürür. Kırpılmış bölgeler, dosya boyutunu optimize etmek için silinebilir.
Görüntü bir metafile (WMF/EMF) veya SVG ise sıkıştırma uygulanmaz. Ayrıca JPEG kalitesi, çözünürlüğe bağlı olarak aynı PowerPoint davranışıyla hafifçe azaltılabilir.
{{% /alert %}}

## **En-Boy Oranını Kilitleme**

Bir şeklin içinde bulunan görüntünün boyutlarını değiştirdiğinizde en-boy oranının korunmasını istiyorsanız, [aspect_ratio_locked](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) özelliğini `True` olarak ayarlayın.

Aşağıdaki Python kodu, bir şeklin en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Yeniden boyutlandırırken en‑boy oranını kilitle.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Bu *Lock Aspect Ratio* ayarı yalnızca şeklin en‑boy oranını korur; içinde bulunan görüntünün oranını korumaz.
{{% /alert %}}

## **Stretch Offset Özelliklerini Kullanma**

[PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) sınıfının `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` ve `stretch_offset_bottom` özelliklerini kullanarak bir doldurma dikdörtgeni tanımlayabilirsiniz.

Bir görüntü için stretching belirtildiğinde, kaynak dikdörtgen doldurma dikdörtgenine sığacak şekilde ölçeklenir. Doldurma dikdörtgeninin her kenarı, şeklin sınırlayıcı kutusunun ilgili kenarından yüzde offset ile tanımlanır. Pozitif yüzde bir içeri çekme, negatif yüzde bir dışarı çıkarma belirtir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayta referans alın.
3. Dikdörtgen bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) ekleyin.
4. Şeklin doldurma türünü ayarlayın.
5. Şeklin resim doldurma kipini ayarlayın.
6. Bir görüntü yükleyin.
7. Görüntüyü şekli doldurmak için atayın.
8. Görüntü offset'lerini şeklin sınırlayıcı kutusunun ilgili kenarlarından belirtin.
9. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki Python kodu Stretch Offset özelliklerini nasıl kullanacağınızı gösterir:

```py
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation() as presentation:
    # İlk slaytı alın.
    slide = presentation.slides[0]

    # Bir dikdörtgen AutoShape ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Şeklin doldurma türünü ayarlayın.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Şeklin resim doldurma kipini ayarlayın.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Görüntüyü yükleyin ve sunuma ekleyin.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Görüntüyü şekli doldurmak için atayın.
    shape.fill_format.picture_fill_format.picture.image = image

    # Görüntünün, şeklin sınırlayıcı kutusunun ilgili kenarlarından olan offsetlerini belirtin.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # PPTX dosyasını diske kaydedin.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose, ücretsiz dönüştürücüler sunar—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—bu sayede görüntülerden hızlıca sunumlar oluşturabilirsiniz.
{{% /alert %}}

## **SSS**

**PictureFrame için hangi görüntü formatlarının desteklendiğini nasıl öğrenebilirim?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) öğesine atanan görüntü nesnesi üzerinden raster görüntüler (PNG, JPEG, BMP, GIF vb.) ve vektör görüntüler (örneğin SVG) destekler. Desteklenen formatların listesi genellikle slayt ve görüntü dönüştürme motorunun yetenekleriyle örtüşür.

**Yüzlerce büyük görüntü eklemek PPTX boyutu ve performansını nasıl etkiler?**

Büyük görüntüleri gömmek dosya boyutunu ve bellek kullanımını artırır; görüntülere bağlamak sunum boyutunu düşük tutar ancak dış dosyaların erişilebilir olmasını gerektirir. Aspose.Slides, dosya boyutunu azaltmak için görüntüleri bağlantı olarak ekleme olanağı sağlar.

**Bir görüntü nesnesinin yanlışlıkla taşınmasını/yeniden boyutlandırılmasını nasıl kilitlebilirim?**

Bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) için [shape locks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/picture_frame_lock/) (örneğin taşıma veya yeniden boyutlandırmayı devre dışı bırakma) kullanın. Kilitleme mekanizması, ayrı bir [protection article](/slides/tr/python-net/applying-protection-to-presentation/) içinde açıklanmıştır ve [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) dahil çeşitli şekil tipleri için desteklenir.

**SVG vektör doğruluğu, sunumu PDF/görüntülere dışa aktarırken korunur mu?**

Aspose.Slides, bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) içinden SVG'yi orijinal vektör olarak çıkarabilir. PDF'ye [/slides/tr/python-net/convert-powerpoint-to-pdf/] veya raster formatlara [/slides/tr/python-net/convert-powerpoint-to-png/] dışa aktarırken, sonuç ihracat ayarlarına bağlı olarak rasterleştirilebilir; ancak orijinal SVG'nin vektör olarak saklandığı, çıkarma davranışıyla doğrulanır.