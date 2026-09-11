---
title: Python via Java ile Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/python-java/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil renderleme
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via Java, her sayfanın bir slayta karşılık geldiği sunum dosyaları oluşturmak için kullanılabilir. Slaytlar, Microsoft PowerPoint kullanarak sunum dosyalarını açarak görüntülenebilir. Ancak, geliştiriciler bazen şekillerin görüntülerini ayrı bir resim görüntüleyicide görmek isterler. Bu gibi durumlarda, Aspose.Slides for Python via Java, slayt şekillerinin küçük resim görüntülerini oluşturmalarına yardımcı olur.

Bu makale, şekil küçük resimlerini farklı yollarla nasıl oluşturacağınızı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tarafından tanımlanan boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Şeklin görünüm sınırları içinde şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Bir slayttan herhangi bir şekil küçük resmi oluşturmak için Aspose.Slides for Python via Java kullanarak şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliğini veya dizinini kullanarak bir slayta referans alın.
1. Referans alınan slayttaki bir şeklin varsayılan ölçekteki [Şekil küçük resim görüntüsünü al](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) alın.
1. Küçük resim görüntüsünü tercih ettiğiniz resim formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi nasıl oluşturulacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Sunum dosyasını temsil eden bir Presentation sınıfının örneğini oluştur.
presentation = Presentation("Thumbnail.pptx")
try:
    # Tam ölçekli bir görüntü oluştur.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Görüntüyü PNG formatında diske kaydet.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Kullanıcı Tanımlı Ölçekleme Faktörü ile Küçük Resim Oluşturma**
Bir slaytın şekil küçük resmini Aspose.Slides for Python via Java kullanarak oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliğini veya dizinini kullanarak bir slayta referans alın.
1. Referans alınan slayttaki bir şeklin kullanıcı tanımlı boyutlarla [Şekil küçük resim görüntüsünü al](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) alın.
1. Küçük resim görüntüsünü tercih ettiğiniz resim formatında kaydedin.

Bu örnek kod, tanımlı bir ölçekleme faktörüne dayalı olarak şekil küçük resmi nasıl oluşturulacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Sunum dosyasını temsil eden bir Presentation sınıfının örneğini oluştur.
presentation = Presentation("Thumbnail.pptx")
try:
    # Her iki yönde 2 kat ölçeklenmiş bir görüntü oluştur.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Görüntüyü PNG formatında diske kaydet.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Sınır Tabanlı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim oluşturmasına olanak tanır. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla sınırlıdır. Görünüm sınırları içinde bir slayt şeklinin küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliğini veya dizinini kullanarak bir slayta referans alın.
1. Referans alınan slayttaki bir şeklin görüntü sınırlarını kullanarak küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü tercih ettiğiniz resim formatında kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanmaktadır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Sunum dosyasını temsil eden bir Presentation sınıfının örneğini oluştur.
presentation = Presentation("Thumbnail.pptx")
try:
    # Tam ölçekli bir görüntü oluştur.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Görüntüyü PNG formatında diske kaydet.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Al**

[Şekil](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) çerçeve özellikleri—its [getX](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getWidth) ve [getHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getHeight) yöntemleri—sunum modelinde saklanan dikdörtgeni tanımlar. Gerçekten render edilen içerik bu çerçevenin dışına çıkabilir veya farklı bir eksen hizalı dikdörtgen kaplayabilir. Döndürme, konturlar, ok uçları, metin yerleşimi ve taşma, oluşturulan SmartArt geometrisi ve diğer render etkileri kaplanan alanı değiştirebilir.

Bu kaplanan alanı bir görüntü oluşturmadan hesaplamak için [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getVisualBounds) yöntemini kullanın. Yöntem, slayt koordinatlarında bir [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) döndürür. Döndürülen dikdörtgen slayta kırpılmamıştır, bu nedenle içerik slayt orijininin dışına taşarsa koordinatları negatif olabilir.

Aşağıdaki örnek çerçeve ve görsel sınırları alır ve karşılaştırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Aynı [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) yakınlardaki şekilleri sol, sağ, üst veya alt kenarına hizalamak, oluşturulan bir yerleşimde yeterli alan ayırmak veya izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir; görsel sınırlar özellikle SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için faydalıdır; çünkü saklanan çerçeve tam render sonucunu temsil etmeyebilir.

Yerleşim veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bir bitmap gerekmiyorsa [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getVisualBounds) kullanılmalıdır. Şekli render etmeniz gerektiğinde ise [Shape.getImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) kullanılmalıdır. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapethumbnailbounds/) ile [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapethumbnailbounds/#Shape) görüntüyü şekil sınırlarından, kontur ayarları dahil, boyutlandırırken; [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapethumbnailbounds/#Appearance) ise görüntüyü şeklin görünümünden boyutlandırır ve sonucu slayt sınırlarıyla kısıtlar. Buna karşılık, [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getVisualBounds) yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimleri kaydederken hangi resim formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imageformat/), ve diğerleri. Şekiller, şeklin içeriğini SVG olarak kaydederek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Küçük resim oluşturulurken Shape ve Appearance sınırları arasındaki fark nedir?**

`Shape`, şeklin geometrisini kullanır; `Appearance`, [görsel efektleri](/slides/tr/python-java/shape-effect/) (gölgeler, parıltılar vb.) göz önünde bulundurur.

**Bir şekil gizli olarak işaretlenmişse ne olur? Yine de küçük resim olarak render edilir mi?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Şekil](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne (örneğin [GroupShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/smartart/)) küçük resim veya SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin yeniden akışını önlemek için [gerekli fontları sağlayın](/slides/tr/python-java/custom-font/) (veya [font ikamelerini yapılandırın](/slides/tr/python-java/font-substitution/)).