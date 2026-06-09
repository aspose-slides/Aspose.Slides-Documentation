---
title: PHP kullanarak Sunumlarda SmartArt Grafiklerini Yönetin
linktitle: SmartArt Grafikler
type: docs
weight: 20
url: /tr/php-java/manage-smartart-shape/
keywords:
- SmartArt nesnesi
- SmartArt grafiği
- SmartArt stili
- SmartArt rengi
- SmartArt oluştur
- SmartArt ekle
- SmartArt düzenle
- SmartArt değiştir
- SmartArt eriş
- SmartArt düzen türü
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint SmartArt oluşturma, düzenleme ve stil verme işlemlerini otomatikleştirin; kısa kod örnekleri ve performansa odaklı rehberlik sunar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında SmartArt grafiklerini programlı olarak oluşturmanıza ve yönetmenize olanak tanır. Bu makale, bir slayta SmartArt şekli eklemeyi, mevcut SmartArt şekillerine erişmeyi, belirli bir düzen türüne göre SmartArt bulmayı ve SmartArt stilini veya renk stilini değiştirerek görsel görünümünü güncellemeyi açıklar.

Örnekler, sunum slaydının şekil koleksiyonu üzerinden SmartArt şekilleriyle nasıl çalışılacağını, bir şeklin SmartArt olup olmadığını kontrol etmeyi ve ardından özelliklerini değiştirmeyi veya incelemeyi gösterir.

## **SmartArt Şekli Oluştur**
Aspose.Slides for PHP via Java, SmartArt şekilleri oluşturmak için bir API sağlamaktadır. Bir slayda SmartArt şekli oluşturmak için lütfen aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini oluşturun.
1. Göstergecisini (Index) kullanarak bir slaytın başvurusunu alın.
1. [SmartArt şekli ekleyin](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addSmartArt) ve [LayoutType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArtLayoutType) ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

```php
  # Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı alın
    $slide = $pres->getSlides()->get_Item(0);
    # Smart Art şekli ekleyin
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Sunumu kaydedin
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Slayta eklenen SmartArt şekli**|

## **Bir Slayttaki SmartArt Şekline Erişim**
Aşağıdaki kod, sunum slaydına eklenen SmartArt şekillerine erişmek için kullanılacaktır. Örnek kodda, slayt içindeki her şekli dolaşacak ve şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) olup olmadığını kontrol edeceğiz. Şekil SmartArt tipindeyse, onu **SmartArt** (https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) örneğine tip dönüştüreceğiz.

```php
  # İstenen sunumu yükleyin
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # İlk slayt içindeki her şekli dolaşın
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Şeklin SmartArt tipinde olup olmadığını kontrol edin
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArtEx'e tip dönüştürün
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Belirli Bir Düzen Türüne Sahip SmartArt Şekline Erişim**
Aşağıdaki örnek kod, belirli bir LayoutType’a sahip [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) şekline erişmeye yardımcı olur. Lütfen unutmayın; LayoutType sadece okuma amaçlıdır ve yalnızca [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) şekli eklenirken ayarlanır, daha sonra değiştirilemez.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. Göstergecisini kullanarak ilk slaydın başvurusunu alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’a tip dönüştürün.
1. Belirli LayoutType’a sahip SmartArt şekli kontrol edin ve ardından yapılması gereken işlemleri gerçekleştirin.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # İlk slayt içindeki her şekli dolaşın
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Şeklin SmartArt tipinde olup olmadığını kontrol edin
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArtEx'e tip dönüştürün
        $smart = $shape;
        # SmartArt düzenini kontrol et
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt Şekli Stilini Değiştir**
Bu örnekte, herhangi bir SmartArt şeklinin hızlı stilini değiştirmeyi öğreneceğiz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. Göstergecisini kullanarak ilk slaydın başvurusunu alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’a tip dönüştürün.
1. Belirli bir Style’a sahip SmartArt şeklini bulun.
1. SmartArt şekli için yeni Style’ı ayarlayın.
1. Sunumu kaydedin.

```php
  # Presentation sınıfını örnekleyin
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # İlk slaytı alın
    $slide = $pres->getSlides()->get_Item(0);
    # İlk slayt içindeki her şekli dolaşın
    foreach($slide->getShapes() as $shape) {
      # Şeklin SmartArt tipinde olup olmadığını kontrol edin
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArtEx'e tip dönüştürün
        $smart = $shape;
        # SmartArt stilini kontrol edin
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt stilini değiştirin
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Sunumu kaydedin
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Şekil: Stili değiştirilen SmartArt şekli**|

## **SmartArt Şekli Renk Stilini Değiştir**
Bu örnekte, herhangi bir SmartArt şeklinin renk stilini değiştirmeyi öğreneceğiz. Aşağıdaki örnek kod, belirli bir renk stiline sahip SmartArt şekline erişecek ve stilini değiştirecektir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. Göstergecisini kullanarak ilk slaydın başvurusunu alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SmartArt) tipinde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt’a tip dönüştürün.
1. Belirli bir Color Style’a sahip SmartArt şeklini bulun.
1. SmartArt şekli için yeni Color Style’ı ayarlayın.
1. Sunumu kaydedin.

```php
  # Presentation sınıfını örnekleyin
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # İlk slaytı alın
    $slide = $pres->getSlides()->get_Item(0);
    # İlk slayt içindeki her şekli dolaşın
    foreach($slide->getShapes() as $shape) {
      # Şeklin SmartArt tipinde olup olmadığını kontrol edin
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Şekli SmartArtEx'e tip dönüştürün
        $smart = $shape;
        # SmartArt renk tipini kontrol edin
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # SmartArt renk tipini değiştirin
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Sunumu kaydedin
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Şekil: Renk Stili değiştirilen SmartArt şekli**|

## **SSS**

**SmartArt'ı tek bir nesne olarak canlandırabilir miyim?**

Evet. SmartArt bir şekildir, bu nedenle diğer şekillerde olduğu gibi [standard animasyonları](/slides/tr/php-java/powerpoint-animation/) (giriş, çıkış, vurgu, hareket yolları) animasyon API'si aracılığıyla uygulayabilirsiniz.

**Bir slayttaki belirli bir SmartArt’ı iç kimliğini bilmiyorsam nasıl bulabilirim?**

Alternatif Metni (AltText) ayarlayın ve şekli bu değerle arayın—bu, hedef şekli bulmanın önerilen yoludur.

**SmartArt'ı diğer şekillerle gruplayabilir miyim?**

Evet. SmartArt'ı diğer şekiller (resimler, tablolar vb.) ile gruplayabilir ve ardından [grubu manipüle edebilirsiniz](/slides/tr/php-java/group/).

**Belirli bir SmartArt’ın görüntüsünü (ör. önizleme veya rapor için) nasıl alabilirim?**

Şeklin bir küçük resim/görüntüsünü dışa aktarın; kütüphane, tek tek şekilleri raster dosyalara (PNG/JPG/TIFF) [render edebilir](/slides/tr/php-java/create-shape-thumbnails/).

**Tüm sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**

Evet. Rendering motoru, [PDF dışa aktarımı](/slides/tr/php-java/convert-powerpoint-to-pdf/) için yüksek doğruluk hedefler ve kalite ve uyumluluk seçenekleri sunar.