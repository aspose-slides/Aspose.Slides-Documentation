---
title: PHP ile Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/php-java/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil renderleme
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca yaratın ve dışa aktarın."
---
## **Giriş**

Aspose.Slides, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, Microsoft PowerPoint ile sunum dosyalarını açarak görüntülenebilir. Ancak bazen geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek istemeleri gerekebilir. Bu durumlarda Aspose.Slides, slayt şekillerinin küçük resim (thumbnail) görsellerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.

Bu makale, slayt küçük resimlerini farklı şekillerde oluşturmayı açıklar:

- Bir slayt içinde bir şeklin küçük resmini oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için küçük resim oluşturma.
- Bir şeklin görünüm sınırları içinde küçük resim oluşturma.

## **Bir Slayttan Şekil Küçük Resmi Oluşturma**
Aspose.Slides for PHP via Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID'si veya indeksi kullanarak herhangi bir slaydın referansını alın.
1. Referans alınan slaydın varsayılan ölçekteki [şekil küçük resmi görüntüsünü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) alın.
1. Küçük resim görüntüsünü istediğiniz görüntü formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi nasıl oluşturulacağını gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfını başlat
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tam ölçekli bir görüntü oluştur
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Görüntüyü PNG formatında diske kaydet
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kullanıcı Tanımlı Ölçek Faktörü ile Küçük Resim Oluşturma**
Aspose.Slides for PHP via Java kullanarak bir slaydın şekil küçük resmini oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID'si veya indeksi kullanarak herhangi bir slaydın referansını alın.
1. Kullanıcı tanımlı boyutlarla referans alınan slaydın [şekil küçük resmi görüntüsünü](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) alın.
1. Küçük resim görüntüsünü istediğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçek faktörüne göre şekil küçük resmi nasıl oluşturulacağını gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfını örnekle
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tam ölçekli bir görüntü oluştur
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Görüntüyü PNG formatında diske kaydet
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Sınır Tabanlı Şekil Görünümü Küçük Resmi Oluşturma**
Bu yöntem, geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim oluşturmasını sağlar. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla kısıtlanır. Bir slayt şeklinin görünüm sınırları içinde küçük resim oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID'si veya indeksi kullanarak herhangi bir slaydın referansını alın.
1. Referans alınan slaydın, şekil sınırları görünüm olarak kullanılarak küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz görüntü formatında kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanır:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfını örnekle
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tam ölçekli bir görüntü oluştur
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Görüntüyü PNG formatında diske kaydet
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Almak**

[Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) çerçeve özellikleri—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` ve `Shape::getHeight()`—sunum modelinde saklanan dikdörtgeni tanımlar. Gerçekten render edilen içerik bu çerçevenin ötesine uzanabilir ya da farklı bir eksen hizalı dikdörtgen kaplayabilir. Döndürme, kenarlıklar, ok uçları, metin düzeni ve taşma, oluşturulan SmartArt geometrisi ve diğer render efektleri, kaplanan alanı değiştirebilir.

[Shape::getVisualBounds](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getVisualBounds) yöntemini, görüntü oluşturmadan bu kaplanan alanı hesaplamak için kullanın. Metot, slayt koordinatlarında bir [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) döndürür. Döndürülen dikdörtgen slayta kırpılmadığından, içerik slayt başlangıcının ötesine uzandığında koordinatları negatif olabilir.

Aşağıdaki örnek, çerçeve ve görsel sınırları alır ve karşılaştırır:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Aynı [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html), yakın şekilleri sol, sağ, üst veya alt kenarına hizalamak; oluşturulan bir düzen içinde yeterli alan ayırmak; ya da izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir. Görsel sınırlar, saklanan çerçevenin tam render sonucunu temsil etmeyebileceği SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için özellikle faydalıdır.

Düzen veya doğrulama için koordinatlara ihtiyaç duyduğunuzda ve bitmap gerektirmediğinizde [Shape::getVisualBounds](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getVisualBounds) kullanın. Şekli render etmeniz gerektiğinde [Shape::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) kullanın. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapethumbnailbounds/) ile `ShapeThumbnailBounds::Shape`, kenarlık ayarları dahil olmak üzere şekil sınırlarından görüntünün boyutunu ayarlar; `ShapeThumbnailBounds::Appearance` ise görüntüyü şeklin görünümünden alır ve sonucu slayt sınırlarıyla kısıtlar. Bunun aksine, `Shape::getVisualBounds` yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca, şeklin içeriğini SVG olarak kaydederek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/).

**Küçük resim render edilirken Shape (Şekil) ve Appearance (Görünüm) sınırları arasındaki fark nedir?**

`Shape` şeklin geometrisini kullanır; `Appearance` ise [görsel efektleri](/slides/tr/php-java/shape-effect/) (gölge, parıltı vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenirse ne olur? Yine de küçük resim olarak render edilir mi?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne ( [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/) dahil) küçük resim veya SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar metin şekillerinin küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedeklemeler ve metin akışını önlemek için [gerekli fontları sağlamalısınız](/slides/tr/php-java/custom-font/) (veya [font ikamelerini yapılandırmalısınız](/slides/tr/php-java/font-substitution/)).