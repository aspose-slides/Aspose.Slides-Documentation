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
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides for Java, her sayfanın bir slayta karşılık geldiği sunum dosyaları oluşturmak için kullanılabilir. Slaytlar, Microsoft PowerPoint kullanılarak açılabilir. Ancak geliştiriciler bazen şekillerin görüntülerini ayrı bir resim görüntüleyicide görmek isteyebilir. Bu gibi durumlarda Aspose.Slides for Java, slayt şekillerinin küçük resimlerini oluşturmalarına yardımcı olur.

Bu makale, farklı şekillerde slayt küçük resimleri oluşturmayı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Şeklin görünüm sınırları içinde şekil küçük resmi oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kimliği veya diziniyle herhangi bir slaytın referansını alın.
1. [Şekil küçük resmi görüntüsünü al](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getImage--) referans alınan slaytın varsayılan ölçeğindeki şekil resmi.
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

## **Kullanıcı Tanımlı Ölçek Faktörlü Küçük Resim Oluşturma**
Aspose.Slides for Java kullanarak bir slaydın şekil küçük resmini oluşturmak için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kimliği veya diziniyle herhangi bir slaytın referansını alın.
1. [Şekil küçük resmi görüntüsünü al](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getImage-int-float-float-) referans alınan slaytın kullanıcı tanımlı boyutlarla şekil resmi.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçek faktörüne göre şekil küçük resmi nasıl oluşturulacağını gösterir:

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
Bu yöntem, geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim oluşturmalarına olanak tanır. Tüm şekil efektlerini hesaba katar. Oluşturulan şekil küçük resmi slayt sınırları tarafından kısıtlanır. Şeklin görünüm sınırları içinde bir slayt şekli için küçük resim oluşturmak için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Kimliği veya diziniyle herhangi bir slaytın referansını alın.
1. Şekil sınırlarını görünüm olarak kullanarak referans alınan slaytın küçük resim görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanır:

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

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca içerikleri SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Küçük resim oluşturulurken Shape ve Appearance sınırları arasındaki fark nedir?**  
`Shape` şeklin geometrisini kullanır; `Appearance` [görsel efektleri](/slides/tr/java/shape-effect/) (gölge, ışıltı vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenirse ne olur? Küçük resim olarak hala oluşturulur mu?**  
Gizli bir şekil modelin bir parçası olarak kalır ve görüntülenebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin resmini üretmeyi engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**  
Evet. [Shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/) (içinde [GroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/) ve [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/smartart/) gibi) olarak temsil edilen her nesne küçük resim veya SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**  
Evet. İstenmeyen yedekleme ve metin kayması yaşamamak için [gerekli fontları sağlayın](/slides/tr/java/custom-font/) (veya [font ikamelerini yapılandırın](/slides/tr/java/font-substitution/)).