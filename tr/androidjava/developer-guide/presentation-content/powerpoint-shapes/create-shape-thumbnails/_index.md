---
title: Android'de Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/androidjava/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil renderleme
- şekil render
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Android via Java, her sayfanın bir slayta karşılık geldiği sunum dosyaları oluşturmak için kullanılabilir. Slaytlar, Microsoft PowerPoint ile sunum dosyalarını açarak görüntülenebilir. Ancak, geliştiriciler bazen şekillerin görüntülerini ayrı bir görüntüleyicide görmek isteyebilir. Böyle durumlarda, Aspose.Slides for Android via Java, slayt şekillerinin küçük resimlerini oluşturmalarına yardımcı olur.

Bu konuda, farklı durumlarda slayt küçük resimlerinin nasıl oluşturulacağını göstereceğiz:

- Bir slayt içinde bir şeklin küçük resmini oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şeklinin küçük resmini oluşturma.
- Bir şeklin görünümünün sınırları içinde küçük resim oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for Android via Java kullanarak herhangi bir slayttan bir şekil küçük resmi oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID veya indeks kullanarak herhangi bir slaydın referansını alın.
1. [Şekil küçük resim görüntüsünü al](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getImage--) referans alınan slayt için varsayılan ölçekle.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi oluşturmayı gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfı oluşturun
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

## **Kullanıcı Tanımlı Ölçekleme Faktörü ile Küçük Resim Oluşturma**
Aspose.Slides for Android via Java kullanarak bir slaydın şekil küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID veya indeks kullanarak herhangi bir slaydın referansını alın.
1. [Şekil küçük resim görüntüsünü al](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) referans alınan slayt için kullanıcı tanımlı boyutlarla.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçekleme faktörüne göre şekil küçük resmi oluşturmayı gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfı oluşturun
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
Bu yöntem, geliştiricilerin şeklin görünümünün sınırları içinde bir küçük resim oluşturmalarını sağlar. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla sınırlıdır. Şeklin görünümünün sınırları içinde bir slayt şeklinin küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID veya indeks kullanarak herhangi bir slaydın referansını alın.
1. Görünüm olarak şekil sınırlarıyla referans alınan slaydın küçük resim görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanmaktadır:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfı oluşturun
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

## **SSS**

**Bir şekil küçükresi kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) şeklinde SVG olarak kaydedilerek dışa aktarılabilir.

**Küçük resim oluştururken Şekil ve Görünüm sınırları arasındaki fark nedir?**

`Shape` şeklin geometrisini kullanır; `Appearance` [görsel efektleri](/slides/tr/androidjava/shape-effect/) (gölgeler, parlamalar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenmişse ne olur? Küçük resim olarak hala oluşturulacak mı?**

Gizli bir şekil modelin bir parçası olmaya devam eder ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/) (örneğin [GroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/smartart/)) olarak temsil edilen herhangi bir nesne küçük resim veya SVG olarak kaydedilebilir.

**Sistemde yüklü olan yazı tipleri metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedekleme ve metin kaymalarını önlemek için gerekli yazı tiplerini [sağlamalısınız](/slides/tr/androidjava/custom-font/) (veya [yazı tipi ikamelerini yapılandırmalısınız](/slides/tr/androidjava/font-substitution/)).