---
title: Python’da Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/python-net/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil render etme
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via .NET, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytları, sunum dosyasını açarak Microsoft PowerPoint’te görüntüleyebilirsiniz. Ancak, geliştiriciler bazen şekillerin görüntülerini ayrı bir görüntüleyicide görmek isteyebilir. Böyle durumlarda, Aspose.Slides slayt şekilleri için küçük resim (thumbnail) görüntüleri oluşturabilir. Bu makale, bu özelliğin nasıl kullanılacağını açıklar.

## **Kaynak Slaytlardan Şekil Küçük Resimleri Oluşturma**

Tam bir slayt yerine belirli bir nesnenin önizlemesi gerektiğinde, tek bir şekil için küçük resim oluşturabilirsiniz. Aspose.Slides, herhangi bir şekli bir görüntüye dışa aktarmanıza olanak tanır; bu sayede hafif önizlemeler, simgeler veya sonraki işlem adımları için varlıklar oluşturmak kolaylaşır.

Herhangi bir şekilden küçük resim oluşturmak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its ID or index.
1. Get a reference to a shape on that slide.
1. Render the shape’s thumbnail image.
1. Save the thumbnail image in the desired format.

The example below generates a shape thumbnail.

```py
import aspose.slides as slides

# Sunum dosyasını açmak için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Varsayılan ölçekle bir görüntü oluşturun.
    with shape.get_image() as thumbnail:
        # Görüntüyü PNG formatında diske kaydedin.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Özel Ölçekleme Katsayısı ile Küçük Resimler Oluşturma**

Bu bölüm, Aspose.Slides içinde kullanıcı tanımlı bir ölçekleme katsayısı ile şekil küçük resimleri oluşturmayı gösterir. Ölçeği kontrol ederek, önizlemeler, dışa aktarımlar veya yüksek DPI ekranlar için küçük resim boyutunu hassas bir şekilde ayarlayabilirsiniz.

Bir slayttaki herhangi bir şekil için küçük resim oluşturmak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) class.
1. Get a slide by its ID or index.
1. Get the target shape on that slide.
1. Render the thumbnail image of the shape with the specified scale.
1. Save the thumbnail image in the desired format.

The example below generates a thumbnail with a user-defined scaling factor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Sunum dosyasını açmak için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Tanımlı ölçekle bir görüntü oluşturun.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Görüntüyü PNG formatında diske kaydedin.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Bir Şeklin Görünüm Sınırlarını Kullanarak Küçük Resimler Oluşturma**

Bu bölüm, bir şeklin görünüm sınırları içinde küçük resim oluşturmayı gösterir. Tüm şekil efektlerini hesaba katar. Oluşturulan küçük resim, slayt sınırları ile kısıtlanır.

Bir slayt şeklinin görünüm sınırları içinde herhangi bir küçük resmi oluşturmak için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) class.
1. Get a slide by its ID or index.
1. Get the target shape on that slide.
1. Render the thumbnail image of the shape with the specified bounds.
1. Save the thumbnail image in the desired image format.

The example below creates a thumbnail with user-defined bounds.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Sunum dosyasını açmak için Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Görünüm sınırlarıyla bir şekil görüntüsü oluşturun.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Görüntüyü PNG formatında diske kaydedin.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Almak**

Bir [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnesinin çerçeve özellikleri—`Shape.x`, `Shape.y`, `Shape.width` ve `Shape.height`—sunum modelinde depolanan dikdörtgeni tanımlar. Gerçekte render edilen içerik bu çerçevenin dışına çıkabilir veya farklı bir eksen hizalı dikdörtgeni kapsayabilir. Döndürmeler, konturlar, ok uçları, metin yerleşimi ve taşması, oluşturulan SmartArt geometrisi ve diğer render etkileri, işgal edilen alanı değiştirebilir.

Render edilmeden, bu işgal edilen alanı hesaplamak için [Shape.get_visual_bounds](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_visual_bounds/) kullanın. Metot, slayt koordinatlarında kayan noktalı bir dikdörtgen döndürür. Döndürülen dikdörtgen slayta kırpılmamıştır; içerik slayt orijini dışına taşarsa koordinatları negatif olabilir.

The following example gets and compares the frame and visual bounds:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Aynı dikdörtgen, yakın şekilleri `left`, `right`, `top` veya `bottom` kenarına hizalamak, oluşturulan bir yerleşimde yeterli alan ayırmak veya izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir; görsel sınırlar özellikle SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için faydalıdır; çünkü depolanan çerçeve, tam render sonucunu yansıtmayabilir.

Layout veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bir bitmap gerekmiyorsa [Shape.get_visual_bounds](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_visual_bounds/) kullanın. Şekli render etmeniz gerektiğinde ise [Shape.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) kullanın. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapethumbnailbounds/) ile `ShapeThumbnailBounds.SHAPE` görüntüyü şekil sınırlarından, kontur ayarları dahil, boyutlandırırken, `ShapeThumbnailBounds.APPEARANCE` şeklin görünümünden boyutlandırır ve sonucu slayt sınırlarıyla kısıtlar. Buna karşılık, `Shape.get_visual_bounds` yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca şeklin içeriği SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/).

**Küçük resim render ederken SHAPE ve APPEARANCE sınırları arasındaki fark nedir?**

`SHAPE`, şeklin geometrisini kullanır; `APPEARANCE` ise [görsel efektleri](/slides/tr/python-net/shape-effect/) (gölgeler, parlamalar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenmişse ne olur? Küçük resim olarak hâlâ render edilir mi?**

Gizli bir şekil modelin bir parçası olmaya devam eder ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün üretilmesini engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne (örneğin [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/)) küçük resim ya da SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin kaymalarını önlemek için gereken fontları [sağlamalısınız](/slides/tr/python-net/custom-font/) (veya [font ikamelerini yapılandırmalısınız](/slides/tr/python-net/font-substitution/)).