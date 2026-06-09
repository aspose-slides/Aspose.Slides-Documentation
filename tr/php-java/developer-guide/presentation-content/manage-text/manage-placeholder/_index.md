---
title: PHP'de Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/php-java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- istem metni
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile yer tutucuları zahmetsizce yönetin: metni değiştirin, istemleri özelleştirin ve PowerPoint ve OpenDocument'ta görsel şeffaflığını ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum yer tutucularını programlı olarak yönetmenizi sağlar. Bu makale, slaytlardaki yer tutucuları nasıl bulup metinlerini değiştireceğinizi, yer tutucu düzenleri için özel istem metni nasıl ayarlayacağınızı ve yer tutucu arka planı olarak kullanılan bir resmin şeffaflığını nasıl ayarlayacağınızı açıklar. Ayrıca, temel yer tutucular ile yerel şekiller arasındaki farkı açıklayan, yer tutucu değişikliklerinin düzenler veya ustalar aracılığıyla nasıl uygulanabileceğini gösteren ve başlık ile alt bilgi yer tutucularının yönetimine yönlendiren kısa bir SSS içerir.

## **Bir Yer Tutucunun Metnini Değiştir**
[Aspose.Slides for PHP via Java](/slides/tr/php-java/), sunumlardaki slaytlarda yer tutucuları bulup değiştirebilmenizi sağlar. Aspose.Slides, bir yer tutucunun metninde değişiklik yapmanıza olanak tanır.

**Önkoşul**: Yer tutucu içeren bir sunuma ihtiyacınız var. Böyle bir sunumu standart Microsoft PowerPoint uygulamasında oluşturabilirsiniz.

Aspose.Slides kullanarak bu sunumdaki yer tutucunun metnini nasıl değiştireceğiniz aşağıda gösterilmektedir:

1. [`Presentation`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve sunumu argüman olarak geçin.
2. Slayt referansını indeksine göre alın.
3. Şekilleri döngüye alarak yer tutucuyu bulun.
4. Yer tutucu şekli bir [`AutoShape`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/AutoShape) tipine dönüştürün ve ilgili [`AutoShape`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/AutoShape) ile ilişkili olan [`TextFrame`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/TextFrame) kullanarak metni değiştirin.
5. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu, bir yer tutucunun metninin nasıl değiştirileceğini gösterir:

```php
  # Bir Presentation sınıfı örnekler
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # İlk slayta erişir
    $sld = $pres->getSlides()->get_Item(0);
    # Şekilleri döngüye alarak yer tutucuyu bulur
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Her yer tutucunun metnini değiştirir
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Sunumu diske kaydeder
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Yer Tutucuda İstem Metni Ayarla**
Standart ve önceden oluşturulmuş düzenler, ***Click to add a title*** veya ***Click to add a subtitle*** gibi yer tutucu istem metinleri içerir. Aspose.Slides ile tercih ettiğiniz istem metinlerini yer tutucu düzenlerine ekleyebilirsiniz.

Bu PHP kodu, bir yer tutucuda istem metninin nasıl ayarlanacağını gösterir:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Slaytı dolaşır
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint "Başlık eklemek için tıklayın" görüntüler
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Altyazı ekler
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Yer Tutucu Resim Şeffaflığını Ayarla**

Aspose.Slides, bir metin yer tutucusundaki arka plan resminin şeffaflığını ayarlamanıza izin verir. Bu çerçevedeki resmin şeffaflığını ayarlayarak, metnin veya resmin öne çıkmasını sağlayabilirsiniz (metnin ve resmin renklerine bağlı olarak).

Bu PHP kodu, bir şekil içindeki resim arka planının şeffaflığının nasıl ayarlanacağını gösterir:

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir temel yer tutucu nedir ve bir slayttaki yerel şekilden nasıl farklıdır?**

Temel yer tutucu, slaydın şeklinin devraldığı düzen veya ustadaki orijinal şekildir—tipi, konumu ve bazı biçimlendirmeler ondan gelir. Yerel şekil bağımsızdır; temel bir yer tutucu yoksa devralma uygulanmaz.

**Bir sunumdaki tüm başlıkları veya alt yazıları her slaytı tek tek dolaşmadan nasıl güncelleyebilirim?**

İlgili yer tutucuyu düzen veya ustada değiştirin. Bu düzen/ustaya dayalı slaytlar değişikliği otomatik olarak devralacaktır.

**Standart başlık/alt bilgi yer tutucularını—tarih & saat, slayt numarası ve alt bilgi metni—nasıl kontrol ederim?**

Uygun kapsamda (normal slaytlar, düzenler, ustalar, notlar/ele dağıtımları) HeaderFooter yöneticilerini kullanarak bu yer tutucuları açıp kapatabilir ve içeriklerini ayarlayabilirsiniz.