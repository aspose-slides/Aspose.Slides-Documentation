---
title: Python ile Sunumlarda Resim Çerçevelerini Yönetme
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
- görüntü çıkar
- raster görüntü
- SVG görüntü
- görüntüyü kırp
- kırpılmış alanları sil
- görüntüyü sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirme
- göreceli ölçek
- görüntü efekti
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile sunumlardaki resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi gösteren slayt şeklidir. Aspose.Slides'da, resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) yerleşik resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) resmin konumunu, boyutunu, çizgi biçimlendirmesini, döndürülmesini, kırpılmasını, resim efektlerini ve diğer çerçeve düzeyindeki ayarları kontrol eder.

Bu ayrım, aynı resmin birden fazla kez gösterilmesi gerektiğinde faydalıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntüleri ve SVG gibi vektör görüntüleri içerebilir. Ayrıca görüntü baytlarını sunuma depolamak yerine bağlı (linked) görüntülere de başvurabilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl depolanacağına karar vermek faydalıdır.

## **Gömülü Bir Görüntü Ekleme ve Biçimlendirme**

Gömülü bir görüntü için, görüntü verilerini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) kullanın. Görüntü, sunum paketinin bir parçası haline gelir, böylece sunum başka bir bilgisayara taşındığında kendi kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile döndürmeyi uygular:

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

Resim çerçevesi, görüntülenen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir görüntüyü kırpma veya sıkıştırma yaparken önemli hale gelir.

## **Göreceli Ölçeği Kullanma**

[PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) çerçeve için [relative_scale_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/relative_scale_width/) ve [relative_scale_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/relative_scale_height/) özelliklerini sunar. `1.0` değeri, orijinal resim boyutunun %100'üne karşılık gelir. Göreceli ölçek, bir iş akışının nihai boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuna olan ilişkiyi koruması gerektiğinde faydalıdır.

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

Göreceli ölçek, çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlı Görüntüler**

Gömülü bir resim, görüntü verilerini sunum içinde depolar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlı bir resim, görüntü verilerini aynı şekilde gömmek yerine [Picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picture/) bağlantı yolu aracılığıyla harici bir konumda saklar.

Bağlı görüntüler, PPTX içinde depolanan görüntü verisi miktarını azaltabilir, ancak dış bağımlılık getirir. Bağlı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak kullanılamaz olursa, bağlı resim beklenildiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlı Bir Görüntü Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve yerel bir görüntü dosyasına işaret eder. Bu örnek yalnızca görüntü bağlamayı ele alır; video bağlama ayrı bir medya iş akışıdır ve kasıtlı olarak bu örneğe karıştırılmamıştır.

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

Harici dosya yönetimi kasıtlıysa bağlantılar kullanılmalıdır. Sıkıştırma yerine yalnızca bir yedek olarak kullanılmamalıdır: bozuk görüntü bağımlılıkları olan küçük bir PPTX, genellikle daha büyük, kendi kendine yeterli bir sunumdan daha az kullanışlıdır.

## **Resim Çerçevelerinden Görüntüleri Çıkarma**

Mevcut bir sunumdan görüntü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) olup olmadığını ve içinde gömülü bir görüntü barındırıp barındırmadığını kontrol edin. Bağlı resim çerçeveleri, aynı şekilde çıkarılabilecek görüntü baytlarını içermeyebilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API'si doğrudan [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) kullanır. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

[IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) üzerinden kaydetmek, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunumda depolanan kodlanmış baytlara, dönüştürülmüş raster dosya yerine ihtiyacınız varsa, bunun yerine [PPImage.binary_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/binary_data/) özelliğini kullanın.

### **SVG Görüntüsü Çıkarma**

SVG bir resim için, [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) nesnesi sunar. Bu sayede resmi önce rasterlaştırmadan doğrudan SVG verisini alabilirsiniz.

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

SVG içeriğini SVG olarak tutmak, sunum içinde vektör kaynağını korur. PNG veya JPEG gibi raster dışa aktarmalar, bu vektör içeriğini piksellere dönüştürmek zorundadır. PDF veya SVG slayt dışa aktarma da bir render işlemi olduğundan, dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.svg_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/svg_data/) kullanılmalıdır.

## **Bir Görüntüyü Kırpma**

Kırpma, çerçeve içinde görüntünün hangi kısmının görüleceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutları üzerinden yüzde olarak verilir. Kırpma, gömülü görüntüdeki gizli pikselleri başlangıçta silmez; yalnızca görünen bölgeyi değiştirir.

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

Gizli görüntü verileri hâlâ mevcut olduğu için kırpma, daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu, geri dönüşümden daha önemliyse, sonraki bölümde açıklandığı gibi kırpılmış bölgeler fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için artık mevcut değildir.

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

Bu yöntem sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçeveler hâlâ mevcut kaynaklarını ihtiyaç duyar; bu yüzden kırpılmış alanların silinmesi mutlaka toplam görüntü sayısını azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterlaştırır.

## **Raster Görüntüleri Sıkıştırma**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/compress_image/) görüntünün gösterildiği boyuta göre raster çözünürlüğünü düşürür. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `True`, hiçbir değişiklik gerekmediyse `False` döndürür.

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

Belirli bir hedef gerektiğinde bir enum değeri yerine pozitif bir DPI değeri özel olarak geçirilebilir.

Sıkıştırma raster görüntüler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca daha düşük çözünürlük ve silinmiş kırpılmış bölgeler, optimize edilmiş sunumdan geri getirilemez. En düşük DPI’yı küresel olarak uygulamaktan ziyade, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre bir hedef çözünürlük seçin.

## **Görüntü Efektlerini İnceleme**

Resim efektleri, çerçeve tarafından kullanılan resimde depolanır. Görüntü dönüşüm koleksiyonu, şeffaflık için sabit alfa modülasyonu ve parlaklık/kontrast için parlaklık gibi efektler içerebilir. Aşağıdaki örnek, bir slayttaki ilk resim çerçevesinden her iki tür efekti güvenli bir şekilde okur:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/alphamodulatefixed/) ve [Luminance](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/luminance/) görüntünün çerçeve içinde nasıl render edildiğini değiştirir; orijinal gömülü görüntü baytlarını yeniden yazarlar.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [aspect_ratio_locked](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) özelliği, şekil yeniden boyutlandırılırken oranının korunmasını sağlar.

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

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en-boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri kenardan içe doğru bir boşluk oluştururken, negatif yüzde değerleri dışa doğru bir çıkıntı oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynak görüntünün hangi kısmının görüleceğini belirler; stretch‑offsetler ise görünen resim doldurmasının hangi dikdörtgene uzatılacağını değiştirir.

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

Doldurma konumlandırması için stretch‑offsetler kullanın. Kaynak görüntünün kenarlarını gizlemek amaçlıysa kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görsel depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel denge noktaları daha kolay yönetilir:

- **Gömülü görüntüler** sunumu kendi kendine yeterli kılar ve paylaşım ile sunucu‑tarafı render için en güvenilir olanlardır; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlı görüntüler** paketi daha küçük tutabilir, ancak sunum, dış dosyaların depolandığı yollar veya konumlar üzerinden erişilebilir olmasına bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene kadar gömülü kalır.
- **Sıkıştırma** aşırı büyük raster görüntüler için dosya boyutunu önemli ölçüde düşürebilir, ancak kaynak çözünürlüğünden vazgeçer. Görüntünün slayt üzerindeki hedef boyutu bilindiğinde uygulanmalıdır.
- **SVG görüntüler** vektör korumasının önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağının kendisine ihtiyaç duyduğunuzda gömülü SVG’yi doğrudan çıkarın. Raster slayt dışa aktarmaları her zaman render edilen slaytı piksele dönüştürür.
- **Tekrarlanan görüntüler** mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) kaynağını yeniden kullanmalı, aynı dosyanın sunuma birden fazla kez yüklenmesinden kaçınmalıdır.

Büyük sunumlarda, görüntü optimizasyonu seçici olarak yapıldığında genellikle en etkili olur: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca ileride düzenleme gerekmiyorsa kaldırın ve dış bağlantılardan kaçının; dış bağımlılık yönetimi dağıtım tasarımının bir parçası değilse.

## **SSS**

**Bir resim çerçevesi ile bir görüntü kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) bir sunumla ilişkili görüntü kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ise bir slaytta görüntüyü gösteren, boyut, döndürme, kırpma değerleri, efektler ve kilitler gibi çerçeve‑düzeyinde geometri ve biçimlendirme depolayan bir şekildir.

**Görüntüleri gömmeli miyim yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutma ve dış konumların güvenilir bir şekilde sürdürülebilir olacağı durumlarda bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Tek başına azaltmaz. Normal kırpma ayarları, kaynak görüntünün bir kısmını gizler ancak alttaki pikselleri tutar. Bu pikselleri kalıcı olarak atmak için [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) kullanılmalı veya kırpma bölgelerinin kaldırıldığı görüntü sıkıştırması uygulanmalıdır.

**Sıkıştırma sonrasında görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü düşürebilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl işlenmeli?**

Vektör doğruluğunun önemli olduğu durumlarda SVG içeriği SVG olarak tutulmalıdır. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) doğrudan çıkarılabilir. Bir slaytı PNG veya JPEG gibi raster formata render etmek, SVG’yi slayt görüntüsünün bir parçası olarak rasterlaştırır.

**Mevcut slaytları okurken güvenli olmayan dönüşümlerden nasıl kaçınılır?**

Bir şeklin tipini kontrol ederek [PictureFrame]‑özel üyelerini kullanmadan önce `isinstance(shape, slides.PictureFrame)` gibi bir kontrol yapın. Bu, geçersiz dönüşümleri önler ve resim çerçevesi içermeyen slaytların güvenli bir şekilde işlenmesini sağlar.