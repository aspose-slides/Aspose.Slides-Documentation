---
title: Python Kullanarak Sunularda Resim Çerçevelerini Yönetme
linktitle: Resim Çerçevesi
type: docs
weight: 10
url: /tr/python-java/picture-frame/
keywords:
- resim çerçevesi
- resim çerçevesi ekle
- resim çerçevesi oluştur
- gömülü resim
- bağlantılı resim
- resim çıkar
- raster resim
- SVG resmi
- resmi kırp
- kırpılmış alanları sil
- resmi sıkıştır
- StretchOffset
- resim çerçevesi biçimlendirmesi
- göreli ölçek
- resim etkisi
- en-boy oranı
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunularda resim çerçevelerini oluşturun, biçimlendirin, bağlayın, kırpın, çıkarın ve sıkıştırın."
---
## **Genel Bakış**

Bir resim çerçevesi, bir resmi gösteren slayt şeklidir. Aspose.Slides'ta, resim kaynağı ve onu gösteren şekil ayrı nesnelerdir: bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) yerleşik resim kaynaklarını [ImageCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/) aracılığıyla sahiplenirken, bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) resmin konumunu, boyutunu, çizgi biçimlendirmesini, dönüşünü, kırpmasını, resim efektlerini ve diğer çerçeve‑seviyesi ayarları kontrol eder.

Bu ayrım, aynı resim birden fazla kez gösterildiğinde yararlıdır. Resmi sunuma bir kez ekleyin, döndürülen [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) nesnesini saklayın ve resim çerçeveleri oluştururken bu resim kaynağını kullanın.

Resim çerçeveleri PNG veya JPEG gibi raster resimleri ve SVG gibi vektör resimleri içerebilir. Ayrıca görüntü baytlarını sunuma yerleştirmek yerine bağlı (linked) resimlere de başvurabilirler. Bu seçim, taşınabilirliği, dosya boyutunu, çıkarma ve dışa aktarma davranışını etkiler; bu nedenle biçimlendirme veya optimizasyon uygulamadan önce resmin nasıl saklanacağına karar vermek yararlıdır.

## **Gömülü Bir Resim Ekleme ve Biçimlendirme**

Gömülü bir resim için, görüntü verisini sunuma ekleyin ve bir resim çerçevesi oluşturmak için [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addPictureFrame) yöntemini kullanın. Resim, sunum paketinin bir parçası haline gelir; bu sayede sunum başka bir bilgisayara taşındığında bile kendi içinde bütün kalır.

Aşağıdaki örnek bir JPEG resmi ekler, resmin yerel boyutlarında bir çerçeve oluşturur ve çizgi biçimlendirmesi ile dönüş uygular:

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

Resim çerçevesi görüntülenen geometrisini kontrol eder; çerçeve boyutunu değiştirmek, gömülü resim kaynağında saklanan orijinal piksel boyutlarını değiştirmez. Bu ayrım, daha sonra bir resmi kırpma veya sıkıştırma işlemi yapıldığında önem kazanır.

## **Göreli Ölçek Kullanımı**

[PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) çerçeve için göreli genişlik ve yükseklik ölçeğini [setRelativeScaleWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) ve [setRelativeScaleHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) ile açığa çıkar. `1.0` değeri, orijinal resim boyutunun %100'üne eşittir. Göreli ölçek, bir iş akışının son boyutları manuel olarak hesaplamak yerine kaynak görüntü boyutuyla ilişkili kalması gerektiğinde kullanışlıdır.

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

Göreli ölçek çerçevenin ölçek ayarlarını değiştirir; gömülü resmi yeniden örneklemiyor veya sıkıştırmıyor.

## **Gömülü ve Bağlı Resimler**

Gömülü bir resim, görüntü verisini doğrudan sunuma yerleştirir ve bu nedenle taşınabilirlik ve öngörülebilir render için en güvenli seçenektir. Bağlı bir resim, görüntü verisini aynı şekilde yerleştirmek yerine [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#setLinkPathLong) yöntemiyle dış bir konuma işaret eder.

Bağlı resimler PPTX içindeki veri miktarını azaltabilir, ancak dış bir bağımlılık getirir. Bağlı dosya, sunumu açan veya renderlayan uygulama tarafından erişilebilir olmalıdır. Yol değişirse, dosya taşınırsa veya kaynak mevcut olmazsa, bağlı resim beklenildiği gibi görüntülenmeyebilir. E‑posta ile gönderilmesi, arşivlenmesi veya izole ortamlarda render edilmesi gereken sunumlar için gömülü resimler genellikle daha güvenilirdir.

### **Bağlı Bir Resim Ekleme**

Aşağıdaki örnek bir resim çerçevesi oluşturur ve onu yerel bir resim dosyasına işaret eder. Sadece resim bağlamayı gösterir; video bağlama ayrı bir medya iş akışıdır ve bilerek bu örneğe karıştırılmamıştır.

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

Harici dosya yönetimi amaçlıysa bağlantıları kullanın. Sıkıştırmanın yerine sadece bir yedekleme olarak kullanmayın: kırık bağımlılıkları olan küçük bir PPTX, genellikle daha büyük, kendi içinde bütün bir sunumdan daha az yararlıdır.

## **Resimleri Resim Çerçevelerinden Çıkarma**

Mevcut bir sunumdan bir resmi çıkarmadan önce, şeklin gerçekten bir [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) olup olmadığını ve gömülü bir resim içerip içermediğini kontrol edin. Bağlı resim çerçeveleri, aynı şekilde çıkarılamayan görüntü baytları içermeyebilir.

### **Raster Resim Çıkarma**

Modern resim API'si raster resimlerle doğrudan çalışır ve eski Java resim sarmalayıcısına ihtiyaç duymaz. Aşağıdaki örnek bir slaytta ilk gömülü raster resmi bulur ve PNG olarak kaydeder:

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

Raster resmi kaydetmek, çıkarılan resmi istenen çıktı formatına dönüştürür. Sunum içinde saklanan kodlanmış baytlara ihtiyaç duyuyorsanız, dönüştürülmüş raster dosya yerine resim kaynağının ikili verisini kullanın.

### **SVG Resim Çıkarma**

Bir SVG resmi için, [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) bir [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) nesnesi sunar. Bu, resmi önce rasterleştirmeden doğrudan SVG verisini almanıza olanak tanır.

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

SVG içeriğini SVG olarak tutmak, vektör kaynağını sunum içinde korur. PNG veya JPEG gibi raster dışa aktarımlar, bu vektör içeriği piksellere dönüştürür. PDF veya SVG slayt dışa aktarması da bir render işlemi olduğundan, dışa aktarılan grafikler orijinal gömülü SVG'nin bayt‑bayt kopyası olarak ele alınmamalıdır; orijinal vektör kaynağı gerektiğinde gömülü [SvgImage.getSvgData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/#getSvgData) verisi kullanılmalıdır.

## **Bir Resmi Kırpma**

Kırpma, çerçeve içinde hangi resim kısmının görünür olduğunu değiştirir. [PictureFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/) üzerindeki kırpma değerleri, kaynak görüntünün boyutlarının yüzdesidir. Kırpma, gömülü resimdeki gizli pikselleri başlangıçta silmez; yalnızca görünür bölgeyi değiştirir.

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

Gizli görüntü verisi hâlâ mevcut olduğu için kırpma daha sonra orijinal pikselleri kaybetmeden değiştirilebilir. Dosya boyutu daha önemliyse ve geri döndürülebilirlik gerekmezse, kırpılmış bölgeler bir sonraki bölümde fiziksel olarak kaldırılabilir.

## **Kırpılmış Resim Verisini Kaldırma**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) mevcut kırpma dikdörtgeninin dışındaki görüntü verisini kaldırır ve sonuçta oluşan resim kaynağını döndürür. Bu, dosya boyutunu azaltabilir, ancak yıkıcı bir optimizasyondur: sunum kaydedildikten sonra kaldırılan pikseller daha sonra bir “uncrop” işlemiyle geri getirilemez.

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

Bu yöntem sunuma yeni bir resim kaynağı ekleyebilir. Orijinal resim diğer resim çerçeveleri tarafından da kullanılıyorsa, bu çerçevelerin hâlâ mevcut kaynağa ihtiyacı vardır; bu nedenle kırpılmış alanların silinmesi mutlaka toplam resim sayısını düşürmez. WMF veya EMF içeriğini bu yöntemle kırpmak, kırpılmış sonucu PNG’ye rasterleştirir.

## **Raster Resimleri Sıkıştırma**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#compressImage) raster resim çözünürlüğünü, resmin gösterildiği boyuta göre azaltır. Aynı işlemde kırpılmış bölgeler de kaldırılabilir. Yöntem, resim yeniden boyutlandırıldıysa veya kırpıldıysa `True`, hiçbir değişiklik gerekmediyse `False` döndürür.

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

Sıkıştırma raster resimler için tasarlanmıştır. SVG ve metafile içeriği bu raster sıkıştırma iş akışıyla azaltılmaz. Ayrıca, daha düşük çözünürlük ve kaldırılan kırpılmış bölgeler optimize edilmiş sunumdan geri getirilemez. Hedef çözünürlüğü, resmin gerçek olarak görüntülenecek veya dışa aktarılacak en büyük boyutuna göre seçin; en düşük DPI’yı küresel olarak uygulamayın.

## **Resim Dönüşüm Efektlerini Yönetme**

Parlaklık, kontrast, renk dönüşümleri, bulanıklaştırma, alfa efektleri, sıralı zincirler, denetim, kaldırma ve çift yönlü doğrulama gibi tam bir iş akışı için [Image Transform Effects](/slides/tr/python-java/image-transform-effects/) bölümüne bakın.

## **Resim Çerçevesi Geometrisini Kilitleme**

[PictureFrameLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframelock/) ayarları, bir resim çerçevesi için hangi düzenleme işlemlerinin devre dışı bırakılacağını kontrol eder. Örneğin, [setAspectRatioLocked](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) yeniden boyutlandırılırken şeklin oranlarını korur.

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

Resim doldurma modu “stretch” olduğunda, [PictureFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/) üzerindeki stretch‑offset değerleri, doldurma dikdörtgenini resim çerçevesinin sınırlayıcı kutusuna göre tanımlar. Pozitif yüzde değerleri bir kenardan içeriye doğru bir boşluk oluştururken, negatif yüzde değerleri dışa doğru bir genişleme oluşturur.

Bu, kırpmadan farklıdır. Kırpma değerleri, kaynağın hangi kısmının görünür olduğunu seçerken; stretch‑offset değerleri görünür dolgu resminin uzatılacağı dikdörtgeni değiştirir.

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

Doldurma konumlandırması için stretch‑offset kullanın. Kaynak görüntünün kenarlarını gizlemek istiyorsanız kırpma özelliklerini kullanın.

## **Depolama, Dosya Boyutu ve Dışa Aktarım Hususları**

Resim depolama ve resim‑çerçeve biçimlendirmesi ayrı ayrı ele alındığında temel ödünleşmeler daha kolay yönetilir:

- **Gömülü resimler** sunumu kendi içinde bütün tutar ve paylaşım ve sunucu tarafı render için en güvenilirdir; ancak büyük raster resimler PPTX boyutunu ve bellek kullanımını artırır.
- **Bağlı resimler** paketi daha küçük tutabilir, fakat sunum dış dosyaların belirtilen yollarda veya konumlarda erişilebilir olmasına bağımlıdır.
- **Kırpma** başlangıçta yok edici değildir. Gizli pikseller, kırpılmış alanlar açıkça silinene kadar gömülüdür.
- **Sıkıştırma**, aşırı büyük raster resimlerin dosya boyutunu önemli ölçüde azaltabilir, ancak kaynak çözünürlüğü feda eder. Kaynağın slayt üzerindeki hedef boyutu bilindikten sonra uygulanmalıdır.
- **SVG resimler**, vektör korumanın önemli olduğu durumlarda SVG olarak tutulmalıdır. Vektör kaynağı gerektiğinde gömülü SVG doğrudan çıkarılabilir. Raster slayt dışa aktarmaları her zaman render edilen slaytı piksele dönüştürür.
- **Tekrarlanan resimler**, mümkün olduğunca mevcut bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) kaynağını yeniden kullanmalı, aynı dosyayı tekrar‑tekrar sunuma yüklemekten kaçınmalıdır.

Büyük sunumlarda resim optimizasyonu genellikle seçici olarak yapıldığında daha etkilidir: logoları ve diyagramları vektör içerik olarak tutun, fotoğrafları gerçek gösterim boyutlarına göre sıkıştırın, kırpılmış pikselleri yalnızca daha sonra düzenleme gerekmediğinde kaldırın ve dış bağlantıları yalnızca bağımlılık yönetimi dağıtım tasarımının bir parçasıysa kullanın.

## **SSS**

**Resim çerçevesi ile resim kaynağı arasındaki fark nedir?**

[PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) sunuma ilişkili bir resim kaynağını temsil eder. [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) bir slayt üzerindeki, görüntüyü gösteren ve boyut, dönüş, kırpma değerleri, efektler ve kilitler gibi çerçeve‑seviyesi geometrik ve biçimlendirme bilgilerini depolayan bir şekildir.

**Resimleri gömmeli miyim yoksa bağlamalı mı?**

Sunumun taşınabilir, arşivlenebilir veya dış kaynaklara erişim olmadan render edilmesi gerekiyorsa resimleri gömün. Resimleri dışarıda tutmak ve dış konumların güvenilir bir şekilde yönetilebileceği durumlarda sadece bağlayın.

**Kırpma PPTX dosya boyutunu azaltır mı?**

Kendiliğinden değildir. Normal kırpma ayarları kaynağın bir kısmını gizler ancak altında yatan pikselleri tutar. Kırpılmış pikselleri kalıcı olarak kaldırmak için [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) veya kırpılmış‑alan kaldırmalı sıkıştırma kullanın.

**Sıkıştırmadan sonra resim kalitesini geri getirebilir miyim?**

Hayır. Sıkıştırma depolanan raster çözünürlüğü azaltır ve kırpılmış bölgelerin kaldırılması görüntü verisini siler. Daha sonraki yüksek çözünürlüklü düzenlemeler gerekebileceği durumlarda orijinal kaynağı sunum dışında tutun.

**SVG resimler nasıl ele alınmalı?**

Vektör bütünlüğünün önemli olduğu durumlarda SVG içeriğini SVG olarak tutun. Gömülü [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) doğrudan çıkarılabilir. PNG veya JPEG gibi raster formatına slide renderlandığında SVG piksellere rasterleşir.

**Varolan slaytları okurken güvenli olmayan dönüştürmelerden nasıl kaçınırım?**

Resim‑çerçevesi‑özel üyeleri kullanmadan önce şekil tipini kontrol edin. [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) karşısında bir `isinstance` kontrolü, geçersiz dönüşümleri önler ve resim çerçevesi içermeyen slaytların kodla ele alınmasını sağlar.