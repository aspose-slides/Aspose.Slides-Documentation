---
title: Python Kullanarak Sunumlarda Görüntü Yönetimini Optimize Etme
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/python-java/image/
keywords:
- görüntü ekle
- resim ekle
- görüntüyü değiştir
- görüntü koleksiyonu
- resim çerçevesi
- bağlantılı görüntü
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- SVG'den şekillere
- harici SVG kaynakları
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Python via Java için Aspose.Slides kullanarak PowerPoint ve OpenDocument sunumlarında raster ve SVG görüntülerini ekleme, yeniden kullanma, bağlama, değiştirme ve yönetme konusunda bilgi edinin."
---
## **Giriş**

Aspose.Slides for Python via Java, görüntülerle çalışmak için birkaç yöntem sunar ve her biri farklı bir amaç hizmet eder. Bir görüntüyü bir sunumda depolayabilir, bir resim çerçevesinde görüntüleyebilir, slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale, görüntü kaynaklarına ve bunların bir sunum boyunca nasıl kullanıldığına odaklanır. Bir bireysel resim çerçevesine uygulanan kırpma, şeffaflık, efektler, esnetme ve diğer biçimlendirmeler için lütfen [Resim Çerçevesi](/slides/tr/python-java/picture-frame/) bölümüne bakın.

## **Görüntü Modelini Anlama**

Aşağıdaki API kavramları yakından ilişkilidir ancak birbirinin yerine kullanılmaz:

- [Sunum görüntü koleksiyonu](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/) sunumda kullanılan görüntü kaynaklarını depolar. Görüntü verisini eklemek ve bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) kaynağı elde etmek için [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) kullanın.
- [Resim çerçevesi](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) bir slayt, düzen veya ana sayfada görüntüyü gösteren bir şekildir. Bir görüntü kaynağını slayta yerleştirmek için [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addPictureFrame) kullanın.
- Bir slayt arka planı, görüntüyü bir şekil olarak değil, slayt doldurmasının bir parçası olarak kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [PPImage.replaceImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#replaceImage) bir görüntü kaynağını değiştirir. Birkaç sunum öğesi bu kaynağı kullanıyorsa, hepsi yeni kaynağı kullanır.
- Bir SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Bu nedenle tipik bir iş akışı şöyledir: görüntü verisini görüntü koleksiyonuna ekleyin, bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) alın ve ardından o kaynağı bir veya daha fazla resim çerçevesi veya dolgu içinde kullanın.

## **Gömülü Görüntü Ekleme**

Yerel bir görüntüyü eklemek için dosyayı yükleyin, görüntü koleksiyonuna ekleyin ve döndürülen [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/)’i kullanan bir resim çerçevesi oluşturun.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu şekilde eklenen görüntü sunum içinde gömülüdür, bu yüzden ortaya çıkan dosya, orijinal görüntü dosyasının hâlâ mevcut olmasına bağlı değildir.

### **Web'den Görüntü Ekleme**

Bir görüntü HTTP veya HTTPS üzerinden mevcut olduğunda, baytlarını indirin, sunum görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel bir görüntü gibi aynı şekilde kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Uzun süre çalışan uygulamalarda, gereksiz ağ altyapısı oluşturmak yerine uygulamaya uygun bir HTTP istemcisi veya bağlantı yönetim stratejisini yeniden kullanın. Ayrıca kaynak güvenilir değilse uzak URL'leri, yanıt boyutlarını ve içerik türlerini doğrulayın.

## **Slaytlar Arasında Görüntüleri Yeniden Kullanma**

Aynı görüntü birden fazla kez gerekiyorsa, onu sunuma bir kez ekleyin ve ek resim çerçeveleri oluştururken döndürülen [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/)’i yeniden kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanım arasındaki ilişkiyi açık hâle getirir.

Şirket logosu gibi birçok slaytta otomatik olarak görünmesi gereken grafikler için, her slayta aynı şekli eklemek yerine bir [slayt ana sayfası](/slides/tr/python-java/slide-master/) veya düzen üzerine resim çerçevesi yerleştirmeyi düşünün.

## **Görüntüyü Slayt Arka Planı Olarak Kullanma**

Bir arka plan görüntüsü slayt dolgusuna atanır; bir resim çerçevesi şekli olarak eklenmez. Bu, resmin slayt arka planını kaplaması ve normal bir slayt nesnesi gibi işlenmemesi gerektiğinde kullanışlıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ana sayfa ve düzen arka planları dahil olmak üzere ek arka plan seçenekleri için [Sunum Arka Planı](/slides/tr/python-java/presentation-background/) bölümüne bakın.

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin farklı taşınabilirlik ve dosya boyutu dengeleri vardır:

- **Gömülü görüntü:** görüntü verisi sunum içinde depolanır. Sunum kendine yeterlidir, ancak dosya boyutu görüntü verisini içerir.
- **Bağlantılı görüntü:** sunum harici bir görüntüye bir yol veya URL depolar. Bu, sunum boyutunu azaltabilir, ancak harici kaynağın sunum açıldığında veya işlendiğinde erişilebilir olması gerekir.

Bir bağlantılı resim, görüntü verisini gömmek yerine dış yolu veya URL'yi [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#setLinkPathLong) aracılığıyla atayarak oluşturulabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bağlantılı görüntüleri yalnızca dağıtım ortamı harici kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrim dışı çalışması veya sistemler arasında taşınması gereken sunumlar için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG bir vektör formatıdır, bu yüzden ikonlar, diyagramlar ve raster görüntülerdeki detay kaybı olmadan ölçeklenmesi gereken diğer grafikler için faydalı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekleme**

Bir [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) oluşturun, görüntü koleksiyonuna ekleyin ve elde edilen görüntü kaynağını bir resim çerçevesine yerleştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dış Kaynaklı SVG Dosyaları**

Bir SVG, harici görüntüler, stil sayfaları veya yazı tiplerine referans verebilir. Bu durumlar için, [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) bir [ExternalResourceResolver](https://reference.aspose.com/slides/tr/python-java/aspose.slides/externalresourceresolver/) ve bir temel URI kabul eden kurucular sağlar. Çözücü, göreli bir URI'yi izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynak için bir akış döndürebilir.

Çözücü, Aspose.Slides SVG'yi işlerken harici kaynakları kullanılabilir kılar, ancak SVG'yi kendine yeter bir belgeye yeniden yazmaz. SVG'nin taşınabilir kalması gerekiyorsa, gerekli kaynakları doğrudan SVG içinde gömün; örneğin bağlantılı görüntüler için `data:` URI'leri kullanın.

SVG dosyaları güvenilmeyen kaynaklardan geldiğinde, çözücünün erişebileceği şemaları, dosya konumlarını ve hostları kısıtlayın. Ağ çözücüler ayrıca zaman aşımı, yanıt boyutu limitleri ve içerik doğrulaması uygulamalıdır.

### **SVG'yi Düzenlenebilir Şekillere Dönüştürme**

Aspose.Slides, bir SVG'yi ilgili PowerPoint komutu benzeri olarak düzenlenebilir slayt şekilleri grubuna dönüştürebilir.

![PowerPoint Açılır Menü](img_01_01.png)

Dönüştürmeyi gerçekleştirmek için bir [SvgImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/svgimage/) kabul eden [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addGroupShape) aşırı yüklemesini kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bireysel vektör öğelerinin PowerPoint şekilleri olarak düzenlenmesi gerektiğinde SVG'den şekillere dönüştürmeyi kullanın. SVG yalnızca görüntülenmesi gerekiyorsa, onu bir görüntü olarak tutmak daha basittir ve birçok ayrı şekil oluşturulmasını önler.

## **Mevcut Bir Görüntü Kaynağını Değiştirme**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [PPImage.replaceImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#replaceImage) kullanın. Bu, logolar gibi paylaşılan grafikler için özellikle faydalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Birden fazla resim çerçevesi, arka plan, ana sayfa veya düzen aynı görüntü kaynağını kullanıyorsa, o kaynağı değiştirmek tüm bu kullanımları günceller. Sadece bir resim çerçevesinin değişmesi gerekiyorsa, paylaşılan kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

[PPImage.replaceImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#replaceImage) ayrıca bir bayt dizisi veya başka bir [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) kabul eden aşırı yüklemeler sunar.

## **Uygulamalı Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Etme**

Büyük raster görüntüler bir sunumu gereksiz yere büyük yapabilir. Kaynak görüntüleri, hedef gösterim boyutlarına uygun boyutlarda kullanın, mümkün olduğunca paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı tam çözünürlüklü grafiğin tekrar tekrar gömülmesinden kaçının.

Raster resimler zaten resim çerçevelerine yerleştirilmişse, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picturefillformat/#compressImage) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, görüntü koleksiyonu yönetimi değil, resim çerçevesi işlemidir; ilgili biçimlendirme işlemleri için [Resim Çerçevesi](/slides/tr/python-java/picture-frame/) bölümüne bakın.

### **Gömülü ve Bağlantılı İçerik Arasından Seçim**

Gömme, tüm gerekli görüntü verileri dosyayla birlikte taşındığı için sunumu taşınabilir kılar. Bağlantı dosya boyutunu azaltabilir, ancak dış bir bağımlılık getirir. Bağlantıları yalnızca bu bağımlılık kabul edilebilir ve istikrarlı olduğunda kullanın.

### **Paylaşılan Marka Unsurlarını Yeniden Kullanma**

Tekrarlanan logolar, filigranlar veya dekoratif grafikler için bir görüntü kaynağı kullanın ve yeniden kullanın. Grafik, slayt içeriğinden ziyade sunum tasarımına aitse, uygun slaytlar tarafından miras alınması için bir ana sayfa veya düzen üzerine yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tutma**

Kendine yeter bir SVG, harici dosyalara veya ağ kaynaklarına bağımlı bir SVG'ye göre taşımak ve tutarlı bir şekilde işlemek daha kolaydır. Mümkün olduğunda, SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi sadece bireysel vektör öğelerinin düzenlenmesi gerektiğinde şekillere dönüştürün.

### **Modern Çok Platformlu Görüntü API'sini Kullanma**

Yeni Python via Java kodu için, eski `java.awt.image.BufferedImage` tabanlı genel API yerine Aspose.Slides çok platformlu görüntü nesnelerini ve [Images](https://reference.aspose.com/slides/tr/python-java/aspose.slides/images/) API'lerini kullanın. Geçiş rehberi için [Modern API](/slides/tr/python-java/modern-api/) bölümüne bakın.

WMF ve EMF özel bir dikkate ihtiyaç duyar. Bu formatlar çok platformlu bir görüntü nesnesi aracılığıyla iletildiğinde, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) metafili eklemeden önce raster PNG temsiline dönüştürür. Metafili verisini korumak önemliyse, akış tabanlı bir [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) aşırı yüklemesini kullanın. Elektronik tablo veya diğer ürünlerden EMF içeriği oluşturmak ayrı bir entegrasyon iş akışıdır ve bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu yeniden kullanılabilir görüntü kaynaklarını depolar. Resim çerçevesi, bu kaynaklardan birini gösteren bir slayt şeklidir ve kırpma ve efektler gibi resme özgü biçimlendirme sağlar.

**Her yerde aynı logoyu değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, bu kaynağı [PPImage.replaceImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#replaceImage) ile değiştirin. Sunum genelinde marka tutturmak için logoyu bir ana sayfaya veya düzene yerleştirmek, yinelenen slayt içeriğini de azaltabilir.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı bir resim, dış dosya veya URL'ye bağlıdır. Bu kaynak diğer bilgisayardan erişilemezse, bağlantılı görüntü kullanılamaz hâle gelebilir. Sunumun kendine yeterli olması gerektiğinde görüntüyü gömün.

**Eklenen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addGroupShape) ile dönüştürün; ortaya çıkan grup, tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunumları nasıl daha küçük tutabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz büyük raster kaynaklardan kaçının, uygun olduğunda raster resimleri sıkıştırın, yinelenen marka unsurlarını ana sayfalarda veya düzenlerde tutun ve dış bir bağımlılık kabul edilebilir olduğunda yalnızca bağlantılı görüntüler kullanın.