---
title: PHP'de Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/php-java/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil oluşturma
- şekil renderleme
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Introduction**

Aspose.Slides, her sayfası bir slayt olan sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, Microsoft PowerPoint kullanarak sunum dosyalarını açarak görüntülenebilir. Ancak bazen geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek isteyebilir. Böyle durumlarda Aspose.Slides, slayt şekillerinin küçük resimlerini (thumbnail) oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.

Bu makale, slayt küçük resimlerini farklı şekillerde oluşturmayı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Şeklin görünümünün sınırları içinde şekil küçük resmi oluşturma.

## **Generate a Shape Thumbnail from a Slide**
Aspose.Slides for PHP via Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID'si veya indeksiyle herhangi bir slaytın referansını alın.
1. Referans alınan slaydın varsayılan ölçekle [shape thumbnail image](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi nasıl oluşturulacağını gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tam ölçekli bir görüntü oluşturun
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Görüntüyü PNG formatında diske kaydedin
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

## **Generate a User-Defined Scaling Factor Thumbnail**
Aspose.Slides for PHP via Java kullanarak bir slaydın şekil küçük resmini oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID'si veya indeksiyle herhangi bir slaytın referansını alın.
1. Referans alınan slaydın kullanıcı tanımlı boyutlarla [shape thumbnail image](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçek faktörüne göre şekil küçük resmi nasıl oluşturulacağını gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tam ölçekli bir görüntü oluşturun
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Görüntüyü PNG formatında diske kaydedin
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

## **Create a Bounds-Based Shape Appearance Thumbnail**
Bu yöntem, geliştiricilerin bir şeklin görünümünün sınırları içinde küçük resim oluşturmasına olanak tanır. Tüm şekil efektlerini hesaba katar. Oluşturulan şekil küçük resmi slayt sınırlarıyla kısıtlanır. Bir slayt şeklinin görünüm sınırları içinde küçük resim oluşturmak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. ID'si veya indeksiyle herhangi bir slaytın referansını alın.
1. Görünüm olarak şekil sınırlarını kullanarak referans alınan slaydın küçük resim görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, yukarıdaki adımlara dayanır:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tam ölçekli bir görüntü oluşturun
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Görüntüyü PNG formatında diske kaydedin
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

## **FAQ**

**What image formats can be used when saving shape thumbnails?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) çünkü şeklin içeriği SVG olarak kaydedilebilir.

**What is the difference between Shape and Appearance bounds when rendering a thumbnail?**

`Shape` şeklin geometrisini; `Appearance` görsel efektleri (gölgeler, parıltılar vb.) dikkate alır.

**What happens if a shape is marked as hidden? Will it still render as a thumbnail?**

Gizli bir şekil modelin bir parçası olarak kalır ve oluşturulabilir; gizli bayrağı slayt gösterisi görüntülenmesini etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Are group shapes, charts, SmartArt, and other complex objects supported?**

Evet. [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne (örneğin [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/smartart/)) küçük resim veya SVG olarak kaydedilebilir.

**Do system-installed fonts affect the quality of thumbnails for text shapes?**

Evet. İstenmeyen yedeklemeler ve metin yeniden akışını önlemek için [gereken yazı tiplerini sağlayın](/slides/tr/php-java/custom-font/) (veya [yazı tipi ikamelerini yapılandırın](/slides/tr/php-java/font-substitution/)).