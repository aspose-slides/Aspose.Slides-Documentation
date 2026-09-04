---
title: Python'da Modern API ile Görüntü İşlemeyi Geliştirin
linktitle: Modern API
type: docs
weight: 237
url: /tr/python-java/modern-api/
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
- Java
- Aspose.Slides
description: "Java aracılığıyla Python'da görüntü işlemeyi modernleştirin: slaytları ve şekilleri oluşturun, resimler ekleyin ve kullanımdan kaldırılmış görüntüleme çağrılarını Aspose.Slides Modern API'ye taşıyın."
---
## **Giriş**

Aspose.Slides for Python via Java, Java kitaplığına JPype aracılığıyla erişir. Eski görüntü işleme API'si `java.awt` üzerinden [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ve [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) kullanıyordu.

Java kitaplığı, versiyon 24.4 itibarıyla bu görüntüleme API'lerini kullanımdan kaldırdı. Modern API, görüntüleri yüklemek, oluşturmak ve kaydetmek için [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) kullanır. Yeni Python kodları için ve mevcut görüntü işleme iş akışlarını taşırken bunu kullanın.

{{% alert color="info" title="Note" %}}
Aşağıdaki eski yöntem adları geçiş referanslarıdır. Mevcut sürümlerde artık bulunmazlar. Çalıştırılabilir örnekler Modern API'yi kullanır.
{{% /alert %}}

## **Modern API**

Ana görüntü işleme türleri şunlardır:

- [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) — raster veya vektör görüntüyü temsil eder.
- [ImageFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/) — görüntü dosyası formatı sabitlerini sağlar.
- [Images](https://reference.aspose.com/slides/tr/python-java/aspose.slides/images/) — görüntüler oluşturur, örneğin [Images.fromFile](https://reference.aspose.com/slides/tr/python-java/aspose.slides/images/#fromFile) ile.

Bir slaytı veya şekli oluşturmak için [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) veya [Shape.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) kullanın. Birden fazla slaytı oluşturmak için oluşturma seçenekleriyle [Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) kullanın. Argüman almayan aşırı yükleme, sunumun görüntü koleksiyonunu döndürür.

Bir görüntüyü [Images.fromFile](https://reference.aspose.com/slides/tr/python-java/aspose.slides/images/#fromFile) ile yükleyin, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) ile ekleyin veya mevcut bir sunum görüntüsünü [PPImage.replaceImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#replaceImage) ile güncelleyin. Her iki görüntü‑koleksiyonu işlemi de [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) kabul eder.

Yüklediğiniz veya oluşturduğunuz her görüntüyü, bir `finally` bloğunda `dispose` metodunu çağırarak serbest bırakın. Sunumu da [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) ile serbest bırakın.

### **Python Ortamını Hazırlama**

[Installation](/slides/tr/python-java/installation/) bölümünde açıklandığı gibi paketleri kurun. Her örnek, JVM'yi başlatmadan önce `asposeslides` modülünü içe aktarır, ardından JVM çalıştıktan sonra API'yi içe aktarır. Örnekler, JVM'yi yeniden kullanılabilir olması için çalışır durumda bırakır. Notebook ve JVM yaşam döngüsü rehberi için [Limitations and API Differences](/slides/tr/python-java/limitations-and-api-differences/#import-the-library) bölümüne bakın.

`pres.pptx` dosyasını açan örneklerin çalıştığı dizinde bir sunum dosyası gerekir. `image.png` dosyasını yükleyen örneklerin mevcut bir resim dosyası gerekir.

### **Bir Resim Yükleyip Bir Slaytı Oluşturma**

Bu örnek, ilk slayta bir resim ekler ve slaytı JPEG görüntüsü olarak kaydeder. [IImage.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/#save) oluşturulan görüntüyü belirtilen formatta yazar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Eski Kodu Modern API ile Değiştirme**

Eski küçük resim çağrılarını, [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) döndüren yöntemlerle değiştirin, ardından sonucu [IImage.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/#save) ile kaydedin. Bu, oluşturulan görüntüleri [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) yöntemine iletme ihtiyacını ortadan kaldırır.

### **Belirli Bir Boyutta Slaytı Oluşturma**

Eski `slide.getThumbnail(image_size)` çağrısını, aynı görüntü boyutunu kullanan [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) ile değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Slayt Küçük Resmi Alma**

Eski `slide.getThumbnail()` çağrısını, argümansız [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) ile değiştirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Şekil Küçük Resmi Alma**

Eski `shape.getThumbnail()` çağrısını, [Shape.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) ile değiştirin. Şekle erişmeden önce slaytın bir şekil içerdiğini kontrol edin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Sunum Küçük Resmi Alma**

Eski `presentation.getThumbnails(options, image_size)` çağrısını, [Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) ile değiştirin. Oluşturmayı yapılandırmak için [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/) kullanın.

Döndürülen dizi üzerinde doğrudan Python'un `enumerate` ile yineleyin. Bir kaydetme hatası kalan görüntülerin serbest bırakılmamasına yol açmasın diye, döndürülen her görüntüyü bir `finally` bloğunda serbest bırakın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Bir Resmi Sunuma Ekleme**

[ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) yerine [Images.fromFile](https://reference.aspose.com/slides/tr/python-java/aspose.slides/images/#fromFile) kullanın, ardından elde edilen görüntüyü [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) ile ekleyin. Resmi slayta ekleyin ve sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kullanımdan Kaldırılan Yöntemler ve Modern API'deki Yerine Geçenler**

Tablolar Python çağrı gösterimini kullanır. Eski sütundaki adlar kaldırılan API'leri gösterir; bağlanan yerine geçen yöntemleri kullanın. Modern görüntü‑oluşturma yöntemleri Java tampon görüntüler yerine [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) nesneleri döndürür.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages), oluşturma seçenekleriyle çağrıldığında oluşturulmuş görüntülerin bir dizisini döndürür.

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

Burada, `slides` bir‑bazlı slayt numaralarını içeren Java `int[]` tipidir; 1 ve 3 numaralı slaytları seçmek için `jpype.JArray(jpype.JInt)([1, 3])` ile oluşturun. `image_size` bir [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) nesnesidir.

### **Shape**

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Slayt**

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | Doğrudan bir karşılığı yok; bunun yerine bir görüntüye render edin |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Doğrudan bir karşılığı yok; bunun yerine bir görüntüye render edin |
| `slide.renderToGraphics(options, graphics, image_size)` | Doğrudan bir karşılığı yok; bunun yerine bir görüntüye render edin |

Burada, `options` bir [RenderingOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/renderingoptions/) ve `tiff_options` bir [TiffOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tiffoptions/) nesnesidir.

### **Çıktı**

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/tr/python-java/aspose.slides/output/#add) with `path, image`, where `image` is [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) |

### **PPImage**

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#getImage) |

Mevcut bir sunum görüntüsünün içeriğini değiştirmek için bir [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) ile [PPImage.replaceImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/#replaceImage) kullanın.

### **PatternFormat**

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/tr/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/tr/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

Renk argümanları Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) nesneleri olarak kalır.

### **PatternFormatEffectiveData**

Java API'si JPype üzerinden geri dönen etkili desen verileri için, yerine geçen yöntem adı `getTileIImage` olarak korunur.

| Eski çağrı | Modern yerine geçiş |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, returning [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) |

## **Graphics2D için API Desteği**

Eski `renderToGraphics` aşırı yüklemeleri, çağıran tarafından sağlanan bir [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) bağlamına çizim yapıyordu. Modern API, bu bağlama doğrudan çizen bir karşılık sunmaz.

Bir slaytı oluşturmak için [Slide.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/#getImage), birkaç slaytı oluşturmak için [Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages) kullanın, ardından döndürülen görüntüleri [IImage.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/#save) ile kaydedin. Slayt oluşturmayı özel Java çizimiyle birleştiren uygulamaların birleşim adımını uyarlamaları gerekir.

## **SSS**

**Eski Java görüntüleme API'si neden değiştirildi?**

Modern API, görüntü yükleme, oluşturma ve kaydetmeyi [IImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/iimage/) üzerine taşır. Bu, iş akışlarını Java tampon görüntülerini veya bir Java grafik bağlamını ortaya çıkarmadan ortak bir görüntü soyutlamasıyla çalıştırır.

**Java ve JPype hâlâ gerekli mi?**

Evet. Aspose.Slides for Python via Java hâlâ JVM üzerinde çalışır. Modern API yalnızca görüntü işleme çağrılarını değiştirir, çalışma zamanı gereksinimlerini etkilemez. Ayrıntılar için [System Requirements](/slides/tr/python-java/system-requirements/) bölümüne bakın.

**Python'da görüntüleri nasıl serbest bırakırım?**

Yüklediğiniz veya oluşturduğunuz her görüntüyü bir `finally` bloğunda `dispose` metodunu çağırarak serbest bırakın. Birden fazla slaytı oluşturursanız, döndürülen dizi içindeki her görüntüyü serbest bırakın. Sunumu ayrıca [Presentation.dispose](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#dispose) ile serbest bırakın.

**Modern API'ye geçmek daha hızlı küçük resim oluşturmayı garantiler mi?**

Hiçbir performans iyileştirmesi garantilenmez. Yerine geçen yöntemler oluşturma seçenekleri, ölçekleme ve görüntü boyutlarını destekler; performansı kendi sunumlarınız ve çıktı ayarlarınızla ölçmeniz gerekir.

**Görüntü getiren bazen neden bir koleksiyon döndürür?**

Argümansız [Presentation.getImages](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getImages), gömülü sunum görüntülerini döndürür. Oluşturma seçenekleriyle aşırı yüklemeleri, oluşturulmuş slayt görüntülerini döndürür.