---
title: Python'da Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/python-net/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil işleme
- şekil renderleme
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Python via .NET, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytları, sunum dosyasını açarak Microsoft PowerPoint ile görüntüleyebilirsiniz. Ancak, geliştiriciler bazen şekillerin görüntülerini ayrı bir görüntüleyicide görmek isteyebilir. Böyle durumlarda, Aspose.Slides slayt şekilleri için küçük resim görüntüleri oluşturabilir. Bu makale bu özelliğin nasıl kullanılacağını açıklar.

## **Slaytlardan Şekil Küçük Resimleri Oluşturma**

Tüm slaytı değil belirli bir nesnenin ön izlemesini istediğinizde, tek bir şekil için küçük resim oluşturabilirsiniz. Aspose.Slides, herhangi bir şekli bir görüntüye dışa aktarmanıza olanak tanır, böylece hafif ön izlemeler, simgeler veya sonraki işleme için varlıklar oluşturmak kolaylaşır.

Herhangi bir şekilden küçük resim oluşturmak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliği ya da indeksi ile bir slayta referans alın.
1. O slayttaki bir şekle referans alın.
1. Şeklin küçük resim görüntüsünü oluşturun.
1. Küçük resim görüntüsünü istenen formatta kaydedin.

Aşağıdaki örnek bir şekil küçük resmi üretir.

```py
import aspose.slides as slides

# Sunum dosyasını açmak için Presentation sınıfını örnekleyin.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Varsayılan ölçekle bir görüntü oluştur.
    with shape.get_image() as thumbnail:
        # Görüntüyü PNG formatında diske kaydet.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Özel Ölçeklendirme Faktörüyle Küçük Resimler Oluşturma**

Bu bölüm, Aspose.Slides içinde kullanıcı tanımlı bir ölçeklendirme faktörüyle şekil küçük resimleri nasıl oluşturacağınızı gösterir. Ölçeği kontrol ederek, küçük resim boyutunu ön izlemeler, dışa aktarmalar veya yüksek DPI ekranlar için ince ayar yapabilirsiniz.

Bir slayttaki herhangi bir şekil için küçük resim oluşturmak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliği ya da indeksi ile bir slayt alın.
1. O slayttaki hedef şekle ulaşın.
1. Belirtilen ölçekle şeklin küçük resim görüntüsünü oluşturun.
1. Küçük resim görüntüsünü istenen formatta kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı bir ölçeklendirme faktörüyle bir küçük resim oluşturur.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Sunum dosyasını açmak için Presentation sınıfını örnekleyin.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Tanımlı ölçekle bir görüntü oluştur.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Görüntüyü PNG formatında diske kaydet.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Bir Şeklin Görünüm Sınırlarını Kullanarak Küçük Resimler Oluşturma**

Bu bölüm, bir şeklin görünüm sınırları içinde küçük resim oluşturma yöntemini gösterir. Tüm şekil efektlerini hesaba katar. Oluşturulan küçük resim slayt sınırlarıyla sınırlıdır.

Bir slayt şeklinin görünüm sınırları içinde bir küçük resim oluşturmak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Kimliği ya da indeksi ile bir slayt alın.
1. O slayttaki hedef şekle ulaşın.
1. Belirtilen sınırlarla şeklin küçük resim görüntüsünü oluşturun.
1. Küçük resim görüntüsünü istenen görüntü formatında kaydedin.

Aşağıdaki örnek, kullanıcı tanımlı sınırlarla bir küçük resim oluşturur.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Sunum dosyasını açmak için Presentation sınıfını örnekleyin.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Görünüm sınırlarıyla şekil görüntüsü oluştur.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Görüntüyü PNG formatında diske kaydet.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca içeriği SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/write_as_svg/).

**Küçük resim oluştururken SHAPE ve APPEARANCE sınırları arasındaki fark nedir?**

`SHAPE`, şeklin geometrisini kullanır; `APPEARANCE` ise [görsel efektleri](/slides/tr/python-net/shape-effect/) (gölgeler, parıltılar vb.) hesaba katar.

**Bir şekil gizli olarak işaretlenmişse ne olur? Yine de küçük resim olarak oluşturulacak mı?**

Gizli bir şekil modelin bir parçası olarak kalır ve oluşturulabilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) (örneğin [GroupShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/)) olarak temsil edilen herhangi bir nesne, küçük resim ya da SVG olarak kaydedilebilir.

**Sisteme yüklü yazı tipleri metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin kaymalarını önlemek için [gerekli yazı tiplerini sağlamalısınız](/slides/tr/python-net/custom-font/) (veya [yazı tipi ikamelerini yapılandırmalısınız](/slides/tr/python-net/font-substitution/)).