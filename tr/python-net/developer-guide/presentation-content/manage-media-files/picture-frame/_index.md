---
title: Presentasyonlarda Resim Çerçevelerini Python ile Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/python-net/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görüntü
- bağlantılı görüntü
- görüntüyü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreceli ölçek
- görsel efekt
- en/boy oranı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir görüntüyü gösteren bir slayt şeklidir. Aspose.Slides'te, resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) gömülü resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) aracılığıyla sahiplenir, bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ise resmin konumunu, boyutunu, çizgi biçimlendirmesini, döndürmeyi, kırpmayı, resim efektlerini ve diğer çerçeve‑düzeyindeki ayarları kontrol eder.

Aynı resim birden fazla kez gösterildiğinde bu ayrım yararlıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görselleri ve SVG gibi vektör görselleri içerebilir. Ayrıca resmi sunuma gömmek yerine bağlantılı görsellere de başvurabilirler. Bu seçim taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görselin nasıl saklanacağına karar vermek faydalıdır.

## **Gömülü Resim Ekleme ve Biçimlendirme**

Gömülü bir görsel için, görsel verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) kullanın. Görsel sunum paketinin bir parçası haline gelir, bu sayede sunum başka bir bilgisayara taşındığında kendi kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görseli ekler, görselin yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürme uygular:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Resim çerçevesi görüntülenen geometrini kontrol eder; çerçeve boyutunu değiştirmek, gömülü görsel kaynağında saklanan özgün piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görseli kırpma veya sıkıştırma yaparken önem kazanır.

## **Göreceli Ölçeği Kullanma**

[PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) çerçeve için [relative_scale_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/relative_scale_width/) ve [relative_scale_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/relative_scale_height/) özelliklerini sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreceli ölçek, bir iş akışının son boyutları elle hesaplamak yerine kaynak görsel boyutuyla olan ilişkiyi koruması gerektiğinde yararlıdır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görseli yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlantılı Görseller**

Gömülü bir resim, görsel verisini doğrudan sunuma kaydeder ve bu nedenle taşınabilirlik ve tahmin edilebilir render için en güvenli seçimdir. Bağlantılı bir resim, [Picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picture/) bağlantı yolu aracılığıyla dış bir konumu tutar; görsel verisi aynı şekilde gömülmez.

Bağlantılı görseller PPTX içinde saklanan görsel verisinin miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlantılı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir kalmalıdır. Yol değişirse, dosya taşınırsa veya kaynak bulunamazsa, bağlantılı görsel beklenildiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü görseller genellikle daha güvenilirdir.

### **Bağlantılı Görsel Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir görsel dosyasına yönlendirir. Bu örnek yalnızca görsel bağlantısını ele alır; video bağlantısı ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe dahil edilmemiştir.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Dış dosya yönetimi kasıtlıysa bağlantıları kullanın. Sıkıştırma yerine sadece bir yedek olarak kullanmayın: kırık görsel bağımlılıklarına sahip küçük bir PPTX, büyük ve kendi kendine yeterli bir sunuma göre genellikle daha az kullanışlıdır.

## **Resim Çerçevelerinden Görselleri Çıkarma**

Mevcut bir sunumdan görsel çıkarmadan önce, bir şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görsel içerip içermediğini kontrol edin. Bağlantılı resim çerçeveleri, aynı şekilde çıkarılabilecek görsel baytlarını içermeyebilir.

### **Raster Görsel Çıkarma**

Modern görsel API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

[IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) üzerinden kaydetmek, çıkarılan görseli istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytları (dönüştürülmüş raster dosyası yerine) elde etmeniz gerekiyorsa, [PPImage.binary_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/binary_data/) özelliğini kullanın.

### **SVG Görsel Çıkarma**

SVG bir resim için, [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) nesnesi sunar. Bu, resmi önce rasterlaştırmadan SVG verisini doğrudan almanızı sağlar.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar, bu vektör içeriğini piksellere dönüştürür. PDF veya SVG slayt dışa aktarma da bir render işlemidir; bu nedenle dışa aktarılan grafikler, orijinal gömülü SVG'nin bayt‑bayt kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.svg_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/svg_data/) kullanılmalıdır.

## **Görseli Kırpma**

Kırpma, bir görselin çerçeve içinde hangi kısmının görüneceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görselin boyutlarının yüzdesi olarak ifade edilir. Kırpma, gizli pikselleri gömülü görselden hemen silmez; yalnızca görünür bölgeyi değiştirir.

Aşağıdaki örnek bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Gizli görsel verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, sonraki bölümde açıklanan gibi kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görsel Verisini Kaldırma**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) geçerli kırpma dikdörtgeninin dışındaki görsel verisini kaldırır ve ortaya çıkan görsel kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir un‑crop işlemi için mevcut değildir.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Bu yöntem sunuma yeni bir görsel kaynağı ekleyebilir. Orijinal görsel diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlâ mevcut kaynağa ihtiyacı olur; bu nedenle kırpılmış alanların silinmesi mutlaka toplam görsel sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterlaştırır.

## **Raster Görselleri Sıkıştırma**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/compress_image/) raster görsel çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Görsel yeniden boyutlandırıldıysa veya kırpıldıysa yöntem `True`, değişiklik gerekmediyse `False` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/picturescompression/) değeri kullanın:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Belirli bir hedef gerektiğinde bir enum değeri yerine özel pozitif DPI değeri de geçilebilir.

Sıkıştırma raster görseller için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca düşük çözünürlük ve silinen kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görselin gerçekten görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; küresel olarak en düşük DPI’yı uygulamaktan kaçının.

## **Görsel Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, inceleme, kaldırma ve iki‑yönlü doğrulama konularını içeren tam iş akışı için [Görsel Dönüşüm Efektleri](/slides/tr/python-net/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakıldığını kontrol eder. Örneğin, [aspect_ratio_locked](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) özelliği, şekil yeniden boyutlandırılırken en/boy oranının korunmasını sağlar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Kilitleme, yalnızca resim çerçevesi şekline uygulanır; kaynak görseli aynı en/boy oranına yeniden örneklemek veya kalıcı olarak değiştirmek zorunda bırakmaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeriye doğru bir boşluk oluştururken, negatif yüzde değerleri dışa doğru bir genişleme yaratır.

Bu, kırpmaktan farklıdır. Kırpma değerleri, kaynak görselin hangi kısmının görüneceğini seçerken; stretch offsetleri, görünen resim doldurmasının gerildiği dikdörtgeni değiştirir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Doldurma yerleşimi için stretch offsetlerini kullanın. Kaynak görsel kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarım Hususları**

Görsel depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel denge noktaları daha kolay yönetilir:

- **Gömülü görseller** sunumu kendi içinde tutar ve paylaşım ve sunucu‑tarafı render açısından en güvenilirdir; ancak büyük raster görseller PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlantılı görseller** paketi daha küçük tutabilir, fakat sunum dış dosyaların belirtilen yollar veya konumlarda mevcut olmasına bağımlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılıncaya kadar gömülü kalır.
- **Sıkıştırma** büyük raster görsellerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Görselin slayt üzerindeki hedef boyutu bilindikten sonra uygulanmalıdır.
- **SVG görseller** vektör bütünlüğünün önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarımları her zaman slaytı piksellere dönüştürür.
- **Tekrarlanan görseller** mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) kaynağını yeniden kullanmalıdır; aynı dosyanın sunuma tekrar tekrar yüklenmesinden kaçının.

Büyük sunumlar için görsel optimizasyonu genellikle seçici olarak yapıldığında daha etkilidir: logolar ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca sonradan düzenleme gerekmiyorsa kaldırın ve dış bağlantıları yalnızca bağımlılık yönetimi dağıtım tasarımının bir parçasıysa kullanın.

## **SSS**

**Resim çerçevesi ile görsel kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) bir sunuma bağlı görsel kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ise bir slayt üzerindeki bir şekildir; bir görseli gösterir ve boyut, döndürme, kırpma değerleri, efektler ve kilitler gibi çerçeve‑düzeyinde geometri ve biçimlendirme bilgilerini saklar.

**Görselleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görselleri gömün. Görselleri yalnızca dış dosya yönetimi kasıtlı ve dış konumlar güvenilir bir şekilde sürdürülebilir ise bağlayın; sadece sıkıştırma yerine bir yedek olarak kullanmayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kırpma tek başına dosya boyutunu azaltmaz. Normal kırpma ayarları, kaynak görselin bölümlerini gizler ancak altındaki pikselleri tutar. Bu pikselleri kalıcı olarak kaldırmak için [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) veya kırpılmış‑alan kaldırmalı bir görsel sıkıştırma kullanın.

**Sıkıştırma sonrası görsel kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma saklanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görsel verisini siler. Daha sonraki yüksek çözünürlüklü düzenleme ihtimali varsa, orijinal kaynak görseli sunum dışında tutun.

**SVG görseller nasıl ele alınmalı?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriğini SVG olarak tutun. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) doğrudan çıkarılabilir. Slaytı PNG veya JPEG gibi raster bir formata render etmek, SVG’yi slayt görüntüsünün bir parçası olarak piksellere dönüştürür.

**Mevcut slaytları okurken güvenli olmayan tip dönüşümlerinden nasıl kaçınırım?**

Şeklin tipini, resim‑çerçevesi‑özel üyeler kullanılmadan önce kontrol edin. `isinstance(shape, slides.PictureFrame)` kullanmak, geçersiz tip dönüşümlerinden kaçınır ve resim çerçeveleri içermeyen slaytların kod tarafından düzgün şekilde işlenmesini sağlar.