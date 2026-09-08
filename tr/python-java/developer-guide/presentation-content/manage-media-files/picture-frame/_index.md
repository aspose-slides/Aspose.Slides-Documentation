---
title: Python ile Sunumlarda Resim Çerçevelerini Yönetin
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/python-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü görüntü
- bağlı görüntü
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunumlarda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi görüntüleyen bir slayt şeklidir. Aspose.Slides'ta, resim kaynağı ve onu görüntüleyen şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) gömülü resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) resmin konumunu, boyutunu, çizgi biçimini, dönüşümünü, kırpılmasını, resim efektlerini ve diğer çerçeve‑düzeyi ayarları kontrol eder.

Bu ayrım, aynı resim birden fazla kez gösterildiğinde faydalıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster görüntülerin yanı sıra SVG gibi vektör görüntüleri de içerebilir. Ayrıca görüntüyü sunuma gömmek yerine bağlı (linked) görüntülere de başvurabilirler. Bu seçim, taşınabilirlik, dosya boyutu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce görüntünün nasıl saklanacağına karar vermek yararlıdır.

## **Gömülü Bir Görüntüyü Ekle ve Biçimlendir**

Gömülü bir görüntü için, görüntü verisini sunuma ekleyin ve [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addPictureFrame) ile bir resim çerçevesi oluşturun. Görüntü sunum paketinin bir parçası haline gelir, bu yüzden sunum başka bir bilgisayara taşındığında kendi kendine yeterli kalır.

Aşağıdaki örnek bir JPEG görüntüsü ekler, görüntünün yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimini ve dönüşümünü uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resim çerçevesi, görüntülenen geometriyi kontrol eder; çerçeve boyutunu değiştirmek, gömülü görüntü kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir resmi kırpma veya sıkıştırma yaptığınızda önem kazanır.

## **Göreceli Ölçeği Kullan**

[PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) çerçeve için göreceli genişlik ve yükseklik ölçeklendirmesini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) aracılığıyla sunar. `1.0` değeri, orijinal resim boyutunun %100’üne karşılık gelir. Göreceli ölçek, bir iş akışının kaynak resim boyutuna olan ilişkiyi koruması gerektiğinde, son boyutları manuel olarak hesaplamak yerine kullanışlıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Göreceli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü görüntüyü yeniden örneklemez veya sıkıştırmaz.

## **Gömülü ve Bağlı Görüntüler**

Gömülü bir resim, görüntü verisini doğrudan sunuma depolar ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlı bir resim, görüntü verisini aynı şekilde gömmek yerine [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#setLinkPathLong) yöntemiyle harici bir konuma işaret eder.

Bağlı görüntüler PPTX içinde depolanan görüntü verisinin miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlı dosya, sunumu açan veya render eden uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak mevcut olmazsa, bağlı resim beklenildiği gibi görüntülenmeyebilir. E-posta ile gönderilmesi, arşivlenmesi veya izole ortamda render edilmesi gereken sunumlar için gömülü görüntüler genellikle daha güvenilirdir.

### **Bağlı Bir Görüntü Ekle**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve yerel bir görüntü dosyasına işaret eder. Sadece görüntü bağlamayı gösterir; video bağlama ayrı bir medya iş akışıdır ve bu örneğe kasıtlı olarak karıştırılmamıştır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Harici dosya yönetimi kasıtlıysa bağlantılar kullanın. Sıkıştırma yerine sadece bir yedekleme yöntemi olarak kullanmayın: kırık görüntü bağımlılıkları olan küçük bir PPTX, genellikle daha büyük, kendi içinde bütün bir sunumdan daha az kullanışlıdır.

## **Resim Çerçevelerinden Görüntü Çıkarma**

Mevcut bir sunumdan bir görüntüyü çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir görüntü içerdiğini kontrol edin. Bağlı resim çerçeveleri, aynı şekilde çıkarılamayan görüntü baytları barındırmayabilir.

### **Raster Görüntü Çıkarma**

Modern görüntü API’si raster görüntülerle doğrudan çalışır ve eski Java görüntü sarmalayıcısına ihtiyaç duymaz. Aşağıdaki örnek bir slayttaki ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Raster görüntünün kaydedilmesi, çıkarılan görüntüyü istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara (dönüştürülmüş raster dosya yerine) ihtiyacınız varsa, görüntü kaynağının ikili verisini kullanın.

### **SVG Görüntü Çıkarma**

Bir SVG resmi için, [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanızı sağlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımları, bu vektör içeriğini piksellere dönüştürür. PDF ya da SVG slayt dışa aktarımı da bir render işlemidir; dışa aktarılan grafikler orijinal gömülü SVG’nin bayt‑bayt kopyası olarak değerlendirilmemelidir; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.getSvgData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/#getSvgData) verisi kullanılmalıdır.

## **Bir Görüntüyü Kırpma**

Kırpma, bir görüntünün çerçeve içinde hangi kısmının görüneceğini değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzde değerleridir. Kırpma, gömülü görüntüdeki gizli pikselleri başlangıçta silmez; sadece görünür bölgeyi değiştirir.

Aşağıdaki örnek bir resim çerçevesini güvenli bir şekilde bulur ve kırpma değerlerini uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gizli görüntü verisi hâlâ mevcut olduğundan, kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu geri dönüşümden daha önemliyse, kırpılmış bölgeler bir sonraki bölümde fiziksel olarak kaldırılabilir.

## **Kırpılmış Görüntü Verisini Kaldırma**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve ortaya çıkan görüntü kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonraki bir kırpma geri alma işlemi için mevcut olmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yöntem, sunuma yeni bir görüntü kaynağı ekleyebilir. Orijinal görüntü başka resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlâ mevcut kaynaklarına ihtiyacı olur; bu yüzden kırpılmış alanların silinmesi toplam görüntü sayısını mutlaka azaltmaz. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Görüntüleri Sıkıştırma**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#compressImage) raster görüntünün çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, görüntü yeniden boyutlandırıldıysa veya kırpıldıysa `True`, hiçbir değişiklik gerekmediyse `False` döndürür.

Standart bir hedef çözünürlük yeterli olduğunda önceden tanımlı bir [PicturesCompression](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturescompression/) değeri kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Belirli bir hedef gerektiğinde önceden tanımlı bir değer yerine pozitif bir DPI değeri de geçirilebilir.

Sıkıştırma raster görüntüler içindir. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, daha düşük çözünürlük ve silinmiş kırpılmış bölgeler optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, görüntünün gerçekte görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; global olarak en düşük DPI’yı uygulamaktan kaçının.

## **Görüntü Dönüştürme Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklık, alfa efektleri, sıralı zincirler, denetleme, kaldırma ve çift‑yönlü doğrulama gibi kapsamlı bir iş akışı için [Image Transform Effects](/slides/tr/python-java/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) şeklin yeniden boyutlandırılırken oranlarını korur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kilitleme, resim çerçevesi şekline uygulanır. Kaynak görüntünün aynı en‑boy oranına yeniden örneklenmesini veya kalıcı olarak değiştirilmesini zorlamaz.

## **StretchOffset Değerlerini Ayarlama**

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerler kenardan içe doğru bir boşluk oluştururken, negatif yüzde değerler dışa doğru bir taşma oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynağın hangi kısmının görüneceğini seçerken; stretch offsetleri, görünen resim doldurmasının hangi dikdörtgene gerileceğini değiştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Stretch offsetleri doldurma konumlandırması için kullanın. Kırpma özelliklerini ise kaynak görüntünün kenarlarını gizlemek istediğinizde kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarma Hususları**

Görsel depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ödünleşimler daha net yönetilir:

- **Gömülü görüntüler** sunumu kendi içinde tutar ve paylaşım ile sunucu‑tarafı render için en güvenilir olandır; ancak büyük raster görüntüler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlı görüntüler** paketi daha küçük tutabilir, fakat sunum dış dosyaların belirtilen yollarda mevcut olmasına bağlıdır.
- **Kırpma** başlangıçta yıkıcı değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene veya sıkıştırma sırasında kaldırılana kadar gömülü kalır.
- **Sıkıştırma** aşırı büyük raster görüntüler için dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Önceden kaydedilecek slayt boyutu bilindiğinde uygulanmalıdır.
- **SVG görüntüler** vektör korumasının önemli olduğu durumlarda SVG olarak kalmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarımları her zaman slaytı piksele dönüştürür.
- **Tekrarlanan görüntüler** mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalı, aynı dosyayı sürekli olarak sunuma yüklemekten kaçınmalıdır.

Büyük sunumlarda, görüntü optimizasyonu genellikle seçici olarak yapıldığında en etkili olur: logolar ve diyagramlar vektör içerik olarak tutulur, fotoğraflar gerçek gösterim boyutuna göre sıkıştırılır, kırpılmış pikseller yalnızca daha sonra düzenleme gerekmiyorsa kaldırılır ve dış bağlantılar, bağımlılık yönetimi dağıtım tasarımının bir parçası olmadıkça kullanılmaz.

## **SSS**

**Resim çerçevesi ile görüntü kaynağı arasındaki fark nedir?**

Bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) sunuma ait bir görüntü kaynağını temsil eder. Bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) ise bir slayttaki resmi gösteren bir şekildir ve boyut, dönüşüm, kırpma değerleri, efektler ve kilitlemeler gibi çerçeve‑düzeyi geometri ve biçimlendirme bilgilerini depolar.

**Görüntüleri gömmeli mi yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya harici kaynaklara erişim olmadan render edilmesi gerekiyorsa görüntüleri gömün. Görüntü dosyalarını PPTX dışına tutmak kasıtlı ve dış konumlar güvenilir bir şekilde yönetilebilecekse yalnızca bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden olmaz. Normal kırpma ayarları kaynağın bir kısmını gizler ancak alttaki pikselleri tutar. Bu pikselleri kalıcı olarak atmak için [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) veya kırpılmış alanların kaldırıldığı bir sıkıştırma uygulayın.

**Sıkıştırmadan sonra görüntü kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma saklanan raster çözünürlüğü azaltabilir ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonra yüksek çözünürlüklü düzenleme gerekebileceği durumlarda orijinal kaynak görüntüyü sunum dışında tutun.

**SVG görüntüler nasıl işlenmeli?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriği SVG olarak kalmalıdır. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. Slaytı PNG veya JPEG gibi raster bir formata render etmek, SVG’yi slayt görüntüsü içinde piksellere dönüştürür.

**Mevcut slaytları okurken güvensiz dönüşümler nasıl önlenir?**

Resim‑çerçevesi‑özel üyeleri kullanmadan önce şeklin tipini kontrol edin. Bir `isinstance` kontrolüyle [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) olup olmadığını doğrulamak, geçersiz dönüşümleri önler ve resim‑çerçevesi içermeyen slaytların düzgün işlenmesini sağlar.