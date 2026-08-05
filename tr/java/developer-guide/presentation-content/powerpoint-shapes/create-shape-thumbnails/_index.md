---
title: Java'da Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/java/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil renderleme
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Java, her sayfanın bir slayta karşılık geldiği sunum dosyaları oluşturmak için kullanılabilir. Slaytlar, Microsoft PowerPoint ile sunum dosyalarını açarak görüntülenebilir. Ancak, geliştiriciler bazen şekillerin görsellerini ayrı bir görüntüleyicide görmek isteyebilir. Bu gibi durumlarda, Aspose.Slides for Java slayt şekillerinin küçük resimlerini (thumbnail) oluşturmalarına yardımcı olur.

Bu makale, slayt küçük resimlerini farklı şekillerde oluşturmayı açıklar:

- Bir slayt içinde bir şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Şeklin görünüm sınırları içinde bir şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı kimliği veya indeksiyle alın.
1. Referans alınan slaydın varsayılan ölçeğindeki [şekil küçük resmi görüntüsünü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getImage--) alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi nasıl oluşturulacağını gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfı örnekleyin
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

## **Kullanıcı Tanımlı Ölçek Faktörü ile Küçük Resim Oluşturma**
Aspose.Slides for Java kullanarak bir slaytın şekil küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı kimliği veya indeksiyle alın.
1. Referans alınan slaydın [şekil küçük resmi görüntüsünü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getImage-int-float-float-) kullanıcı tanımlı boyutlarla alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçek faktörüne dayalı şekil küçük resmi nasıl oluşturulacağını gösterir:

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

## **Sınır Tabanlı Görünüm Küçük Resmi Oluşturma**
Bu yöntem, geliştiricilerin bir şeklin görünüm sınırları içinde küçük resim oluşturmasını sağlar. Tüm şekil efektleri dikkate alınır. Oluşturulan şekil küçük resmi, slayt sınırlarıyla kısıtlanır. Bir şeklin görünüm sınırları içinde bir slayt şeklinin küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı kimliği veya indeksiyle alın.
1. Görünüm sınırları olarak şekil sınırlarını kullanan referans alınan slaydın küçük resim görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

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

## **Bir Şeklin Gerçek Görsel Sınırlarını Almak**

[IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzünün çerçeve özellikleri—`getX()`, `getY()`, `getWidth()` ve `getHeight()` metodları—sunum modelinde saklanan dikdörtgeni tanımlar. Gerçekte render edilen içerik bu çerçevenin dışına uzanabilir veya farklı bir eksen‑align dikdörtgende yer alabilir. Döndürme, kenarlıklar, ok uçları, metin yerleşimi ve taşması, oluşturulan SmartArt geometrisi ve diğer render efektleri, kullanılan alanı değiştirebilir.

[Görsel alanı](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getVisualBounds--) hesaplamak için `Shape.getVisualBounds` metodunu kullanın; bu, bir resim oluşturmadan işgal edilen alanı verir. Metod, slayt koordinatlarında bir [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) döndürür. Döndürülen dikdörtgen slayta kırpılmamıştır, bu yüzden içerik slayt orijininin dışına uzandığında koordinatları negatif olabilir.

`Shape.getVisualBounds` şu anda [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzü tarafından bildirilmiyor. Bu nedenle, slaydın şekil koleksiyonundan alınan şekli bir arayüz değeri olarak tutun ve metodu çağırırken yalnızca dönüştürün.

Aşağıdaki örnek, çerçeve ve görsel sınırları alıp karşılaştırır:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Aynı [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html), yakındaki şekilleri sol, sağ, üst veya alt kenarına hizalamak; oluşturulan bir yerleşimde yeterli alan ayırmak; ya da izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir. Görsel sınırlar, saklanan çerçevenin tam render sonucunu yansıtmayabileceği SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için özellikle yararlıdır.

Yerleşim veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bitmap gerekmiyorsa `Shape.getVisualBounds` kullanın. Şekli render etmeniz gerektiğinde `IShape.getImage` kullanın. `ShapeThumbnailBounds` ile, `ShapeThumbnailBounds.Shape` şekil sınırlarından, kenar ayarları dahil, resmi boyutlandırırken; `ShapeThumbnailBounds.Appearance` şeklin görünümünden boyutlandırır ve sonucu slayt sınırlarıyla kısıtlar. Buna karşılık, `Shape.getVisualBounds` yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimlerini kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca, şeklin içeriği SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Küçük resim oluşturulurken Şekil (Shape) ve Görünüm (Appearance) sınırları arasındaki fark nedir?**

`Shape` şeklin geometrisini kullanır; `Appearance` ise [visual effects](/slides/tr/java/shape-effect/) (gölgeler, ışıldamalar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenmişse ne olur? Küçük resim olarak hâlâ render edilir mi?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/) olarak temsil edilen herhangi bir nesne (örneğin [GroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/) ve [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/smartart/)) küçük resim veya SVG olarak kaydedilebilir.

**Sistem tarafından yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen font geri dönüşlerini ve metin kaymalarını önlemek için [gerekli fontları sağlayın](/slides/tr/java/custom-font/) (veya [font ikameleri yapılandırın](/slides/tr/java/font-substitution/)).