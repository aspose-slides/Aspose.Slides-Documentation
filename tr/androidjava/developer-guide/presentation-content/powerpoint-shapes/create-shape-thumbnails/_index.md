---
title: Android'de Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/androidjava/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil işleme
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Android via Java, her sayfanın bir slayta karşılık geldiği sunum dosyaları oluşturmak için kullanılabilir. Slaytlar, sunum dosyaları Microsoft PowerPoint ile açılarak görüntülenebilir. Ancak, geliştiriciler bazen şekillerin görüntülerini ayrı bir görüntüleyicide görüntülemek isteyebilir. Bu gibi durumlarda, Aspose.Slides for Android via Java, slayt şekillerinin küçük resimlerini oluşturmalarına yardımcı olur.

Bu konuda, farklı durumlarda slayt küçük resimlerini nasıl oluşturacağınızı göstereceğiz:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Şeklin görünümünün sınırları içinde şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for Android via Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kimliği veya indeksi kullanarak herhangi bir slaytın referansını alın.
1. [Şekil küçük resmi görüntüsünü al](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getImage--) referans alınan slaytın varsayılan ölçekteki görüntüsünü alın.
1. Küçük resim görüntüsünü tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi nasıl oluşturacağınızı gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tam ölçekli bir görüntü oluşturun
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Görüntüyü PNG formatında diske kaydedin
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kullanıcı Tanımlı Ölçeklendirme Faktörü Küçük Resmi Oluşturma**
Aspose.Slides for Android via Java kullanarak bir slaytın şekil küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kimliği veya indeksi kullanarak herhangi bir slaytın referansını alın.
1. [Şekil küçük resmi görüntüsünü al](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) referans alınan slaytın kullanıcı tanımlı boyutlarla görüntüsünü alın.
1. Küçük resim görüntüsünü tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçeklendirme faktörüne göre şekil küçük resmi nasıl oluşturacağınızı gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tam ölçekli bir görüntü oluşturun
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Görüntüyü PNG formatında diske kaydedin
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sınır Tabanlı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, geliştiricilerin şeklin görünümünün sınırları içinde bir küçük resim oluşturmasını sağlar. Tüm şekil efektleri dikkate alınır. Oluşturulan şekil küçük resmi, slayt sınırları ile sınırlıdır. Şeklin görünümünün sınırları içinde bir slayt şekli küçük resmi oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kimliği veya indeksi kullanarak herhangi bir slaytın referansını alın.
1. Şekil sınırlarını görünüm olarak kullanarak referans alınan slaytın küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanmaktadır:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Tam ölçekli bir görüntü oluşturun
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Görüntüyü PNG formatında diske kaydedin
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Alın**

[IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) sınıfının çerçeve özellikleri—`getX()`, `getY()`, `getWidth()`, ve `getHeight()` metodları—sunum modelinde depolanan dikdörtgeni tanımlar. Gerçekte render edilen içerik bu çerçevenin dışına çıkabilir veya farklı bir eksen hizalı dikdörtgeni kaplayabilir. Döndürme, konturlar, ok uçları, metin yerleşimi ve taşması, oluşturulan SmartArt geometrisi ve diğer render efektleri, kaplanan alanı değiştirebilir.

Bu kaplanan alanı bir görüntü oluşturmadan hesaplamak için [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getVisualBounds--) metodunu kullanın. Metot, slayt koordinatlarında bir [RectF](https://developer.android.com/reference/android/graphics/RectF) döndürür. Döndürülen dikdörtgen slayta kırpılmadığından, içerik slayt orijini dışına uzandığında koordinatları negatif olabilir.

[Shape.getVisualBounds](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getVisualBounds--) şu anda [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzü tarafından bildirilmemektedir. Bu nedenle, slayttaki şekil koleksiyonundan alınan şekli arayüz türünde tutun ve yalnızca bu metodu çağırırken tip dönüşümü yapın.

Aşağıdaki örnek, çerçeve ve görsel sınırları alıp karşılaştırır:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Aynı [RectF](https://developer.android.com/reference/android/graphics/RectF), yakındaki şekilleri sol, sağ, üst veya alt kenarına hizalamak, oluşturulan bir yerleşimde yeterli alan ayırmak ya da izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir; görsel sınırlar özellikle SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için faydalıdır; çünkü depolanan çerçeve tam render edilmiş sonucu temsil etmeyebilir.

Yerleşim veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bitmap gerekmiyorsa [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getVisualBounds--) kullanın. Şekli render etmeniz gerektiğinde ise [IShape.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getImage--) kullanın. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapethumbnailbounds/) ile `ShapeThumbnailBounds.Shape`, şekil sınırlarından ve kontur ayarlarından görüntüyü boyutlandırırken, `ShapeThumbnailBounds.Appearance` görüntüyü şeklin görünümünden boyutlandırır ve sonucu slayt sınırları ile kısıtlar. Buna karşıt olarak, [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getVisualBounds--) yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca içeriği SVG olarak kaydedilerek vektör SVG olarak da dışa aktarılabilir ([şekli SVG olarak dışa aktar](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)).

**Küçük resim render ederken Shape ve Appearance sınırları arasındaki fark nedir?**

`Shape` şeklin geometrisini kullanır; `Appearance` ise [görsel efektleri](/slides/tr/androidjava/shape-effect/) (gölge, parlaklık vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenmişse ne olur? Gizli olduğu halde küçük resmi oluşturulur mu?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün üretilmesini engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/) (dahil [GroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/smartart/)) olarak temsil edilen herhangi bir nesne, küçük resim ya da SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin akışını önlemek için gerekli fontları sağlamalısınız ([gerekli fontları sağla](/slides/tr/androidjava/custom-font/)) (veya [font ikamelerini yapılandır](/slides/tr/androidjava/font-substitution/)).