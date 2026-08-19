---
title: Python ile Sunumlarda Görüntü Yönetimini Optimize Etme
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/python-net/image/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarında raster ve SVG görüntülerini ekleme, yeniden kullanma, bağlama, değiştirme ve yönetme konusunda bilgi edinin."
---
## **Giriş**

Aspose.Slides for Python via .NET, görüntülerle çalışmanın çeşitli yollarını sunar ve her biri farklı bir amaca hizmet eder. Bir görüntüyü sunuya kaydedebilir, bir resim çerçevesinde görüntüleyebilir, slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale, görüntü kaynaklarına ve bunların bir sunu içinde nasıl kullanıldığına odaklanır. Bir resim çerçevesine uygulanan kırpma, şeffaflık, efektler, uzatma ve diğer biçimlendirmeler için [Picture Frame](/slides/tr/python-net/picture-frame/) bölümüne bakın.

## **Görüntü Modelini Anlamak**

- [sunum görüntü koleksiyonu](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/) sunumda kullanılan görüntü kaynaklarını saklar. Görüntü verisini eklemek ve bir [IPPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/) kaynağı elde etmek için [ImageCollection.add_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/add_image/) kullanın.
- [resim çerçevesi](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ipictureframe/) bir slayt, yerleşim veya ana taslak üzerine bir görüntüyü gösteren bir şekildir. Görüntü kaynağını bir slayta yerleştirmek için [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) kullanın.
- Bir slayt arka planı, görüntüyü bir şekil olarak değil, slayt dolgusunun bir parçası olarak kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [IPPImage.replace_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/replace_image/) bir görüntü kaynağını değiştirir. Birden fazla sunu öğesi aynı kaynağı kullanıyorsa, hepsi değiştirilmiş versiyonu kullanır.
- SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Bu nedenle tipik bir iş akışı şudur: görüntü verisini görüntü koleksiyonuna ekleyin, bir [IPPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/) alın ve ardından bu kaynağı bir veya daha fazla resim çerçevesinde veya dolgu içinde kullanın.

## **Gömülü Görüntü Ekleme**

Yerel bir görüntüyü eklemek için dosyayı okuyun, verisini görüntü koleksiyonuna ekleyin ve döndürülen `IPPImage`ı kullanan bir resim çerçevesi oluşturun.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Bu şekilde eklenen görüntü sunuya gömülür, böylece ortaya çıkan dosya orijinal görüntü dosyasının hâlâ mevcut olmasına bağlı kalmaz.

### **Web'den Görüntü Ekleme**

Bir görüntü HTTP veya HTTPS üzerinden erişilebiliyorsa, baytlarını indirin, bunları sunum görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel bir görüntü gibi kullanın.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

Uzun süren uygulamalarda, her istekte yeni bir bağlantı oluşturmaktansa uygun olduğunda bir HTTP istemcisi veya bağlantı havuzu yeniden kullanın. Kaynak güvenilir değilse uzaktaki URL'leri, yanıt boyutlarını ve içerik türlerini de doğrulayın.

## **Slaytlar Arasında Görüntüleri Yeniden Kullanma**

Aynı görüntü birden fazla kez gerekiyorsa, görüntüyü sunuya bir kez ekleyin ve ek resim çerçeveleri oluştururken döndürülen [IPPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/)ı yeniden kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve paylaşılan görüntü kaynağı ile kullanımları arasındaki ilişkiyi açık hâle getirir.

Birçok slaytta otomatik olarak görünmesi gereken grafikler (örneğin şirket logosu) için, her slayta eşdeğer bir şekil eklemek yerine resim çerçevesini bir [slide master](/slides/tr/python-net/slide-master/) veya yerleşim üzerine yerleştirmeyi düşünün.

## **Görüntüyü Slayt Arka Planı Olarak Kullanma**

Arka plan görüntüsü slayt dolgusuna atanır; bir resim çerçevesi şekli olarak eklenmez. Bu, resmin slayt arka planını kaplaması ve normal bir slayt nesnesi gibi manipüle edilmemesi gerektiğinde kullanışlıdır.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Ek arka plan seçenekleri, ana taslak ve yerleşim arka planları dahil, için [Presentation Background](/slides/tr/python-net/presentation-background/) bölümüne bakın.

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntülerin taşınabilirlik ve dosya boyutu açısından farklı ticaretleri vardır:

- **Gömülü görüntü:** görüntü verisi sununun içinde saklanır. Sunu tek başına çalışır, ancak dosya boyutu görüntü verisini içerir.
- **Bağlantılı görüntü:** sunu, harici bir görüntünün yolunu veya URL'sini saklar. Bu, sunu boyutunu küçültebilir, ancak dış kaynağın sunu açıldığında veya işlendiğinde erişilebilir olması gerekir.

Bir bağlantılı resim, görüntü verisini gömmek yerine [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/tr/python-net/aspose.slides/islidespicture/link_path_long/) aracılığıyla dış yol veya URL atayarak oluşturulabilir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Bağlantılı görüntüleri yalnızca dağıtım ortamı dış kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrimdışı çalışması veya sistemler arasında taşınması gereken sunular için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG bir vektör biçimidir; bu, ikonlar, diyagramlar ve raster görüntülerdeki detay kaybı olmadan ölçeklenmesi gereken diğer grafikler için faydalı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı olarak hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekleme**

Bir [SvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/svgimage/) oluşturun, görüntü koleksiyonuna ekleyin ve ortaya çıkan görüntü kaynağını bir resim çerçevesine yerleştirin.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **SVG'yi Düzenlenebilir Şekillere Dönüştürme**

Aspose.Slides, bir SVG'yi düzenlenebilir slayt şekilleri grubuna, ilgili PowerPoint komutuna benzer şekilde dönüştürebilir.

![PowerPoint Popup Menu](img_01_01.png)

Dönüştürmeyi gerçekleştirmek için bir [ISvgImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/isvgimage/) kabul eden [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_group_shape/) aşırı yüklemesini kullanın.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Bireysel vektör öğelerinin PowerPoint şekilleri olarak düzenlenmesi gerektiğinde SVG‑den‑şekil dönüşümünü kullanın. SVG yalnızca görüntülenmesi gerekiyorsa, onu bir resim olarak tutmak daha basittir ve birçok ayrı şekil oluşturmayı önler.

## **Mevcut Bir Görüntü Kaynağını Değiştirme**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [IPPImage.replace_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/replace_image/) kullanın. Bu, özellikle logolar gibi paylaşılan grafikler için yararlıdır.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Birden fazla resim çerçevesi, arka plan, ana taslak veya yerleşim aynı görüntü kaynağını kullanıyorsa, kaynağı değiştirmek tüm bu kullanımları günceller. Sadece bir resim çerçevesi değişecekse, paylaşılan kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

`replace_image` ayrıca bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) veya başka bir [IPPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/) kabul eden aşırı yüklemeler sunar.

## **Pratik Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Etme**

Büyük raster görüntüler sunuyu gereksiz yere şişirebilir. Hedeflenen gösterim boyutuna uygun boyutlarda kaynak görüntüler kullanın, mümkün olduğunca paylaşılan görüntü kaynaklarını yeniden kullanın ve aynı yüksek çözünürlüklü grafiğin tekrar tekrar gömülmesinden kaçının.

Resim çerçevelerine zaten yerleştirilmiş raster resimler için [PictureFillFormat.compress_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picturefillformat/compress_image/) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini küçültebilir. Bu, resim çerçevesi işleme olup görüntü koleksiyonu yönetimi değildir; ilgili biçimlendirme işlemleri için [Picture Frame](/slides/tr/python-net/picture-frame/) bölümüne bakın.

### **Gömülü ve Bağlantılı İçerik Arasında Seçim Yapma**

Gömme, tüm gerekli görüntü verileri dosyayla birlikte taşındığı için sununun taşınabilirliğini artırır. Bağlantı dosya boyutunu azaltabilir, ancak dış bir bağımlılık oluşturur. Bağlantıyı yalnızca bu bağımlılığın kabul edilebilir ve istikrarlı olduğu durumlarda kullanın.

### **Paylaşılan Markayı Yeniden Kullanma**

Tekrarlanan logolar, filigranlar veya dekoratif grafikler için tek bir görüntü kaynağı oluşturun ve yeniden kullanın. Grafik, slayt içeriğinden ziyade sunu tasarımına aitse, uygun slaytlar tarafından kalıtılacak şekilde bir ana taslak veya yerleşime yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tutma**

Kendine ait bir SVG, dış dosyalara veya ağ kaynaklarına bağımlı bir SVG'den daha kolay taşınır ve tutarlı şekilde işlenir. Mümkün olduğunda SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi yalnızca bireysel vektör öğelerinin düzenlenmesi gerektiğinde şekillere dönüştürün.

### **Modern Çapraz Platform Görüntü API'sini Kullanma**

Yeni Python via .NET kodu için, eski `aspose.pydrawing.Image` veya `aspose.pydrawing.Bitmap` API'leri yerine Aspose.Slides [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) ve [Images](https://reference.aspose.com/slides/tr/python-net/aspose.slides/images/) API'lerini kullanın. Geçiş rehberi için [Modern API](/slides/tr/python-net/modern-api/) bölümüne bakın.

WMF ve EMF özel bir dikkate ihtiyaç duyar. Bu formatlar bir [IImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iimage/) aracılığıyla geçirildiğinde, [ImageCollection.add_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/add_image/) metafili PNG raster temsiline dönüştürür. Metafili verisini korumak önemliyse, akış tabanlı [ImageCollection.add_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imagecollection/add_image/) aşırı yüklemesini kullanın. Elektronik tablolar veya diğer ürünlerden EMF içeriği oluşturmak ayrı bir bütünleştirme iş akışıdır ve bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu yeniden kullanılabilir görüntü kaynaklarını saklar. Resim çerçevesi ise bu kaynaklardan birini gösteren ve kırpma, efekt gibi resme özgü biçimlendirmeler sağlayan bir slayt şeklidir.

**Her yerde aynı logoyu değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, o kaynağı [IPPImage.replace_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ippimage/replace_image/) ile değiştirin. Sunu genelinde markalaşma için logoyu bir ana taslak veya yerleşime yerleştirmek de tekrarlanan slayt içeriğini azaltır.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı resim, dış dosya veya URL'ye bağımlıdır. Bu kaynak diğer bilgisayardan erişilemezse, bağlantılı görüntü kullanılamaz hale gelir. Sununun kendine ait olması gerekiyorsa görüntüyü gömün.

**Eklentilen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_group_shape/) ile dönüştürün; ortaya çıkan grup tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunuları nasıl daha küçük tutabilirim?**

Paylaşılan görüntü kaynaklarını yeniden kullanın, gereksiz büyük raster kaynaklardan kaçının, uygun olduğunda uygun raster resimleri sıkıştırın, tekrarlanan markaları ana taslak veya yerleşimlerde tutun ve dış bağımlılık kabul edilebilir olduğunda sadece bağlantılı görüntüler kullanın.