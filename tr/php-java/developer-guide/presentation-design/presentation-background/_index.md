---
title: PHP'de Sunum Arka Planlarını Yönetin
linktitle: Slayt Arka Planı
type: docs
weight: 20
url: /tr/php-java/presentation-background/
keywords:
- sunum arka planı
- slayt arka planı
- katı renk
- degrade rengi
- görüntü arka planı
- arka plan şeffaflığı
- arka plan özellikleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument dosyalarında dinamik arka planlar ayarlamayı, sunumlarınızı geliştirecek kod ipuçlarıyla öğrenin."
---
## **Giriş**

Katı renkler, degradeler ve görüntüler slayt arka planları için yaygın olarak kullanılır. Arka planı **normal bir slayt** (tek bir slayt) veya **master slayt** (birden fazla slayta aynı anda uygulanır) için ayarlayabilirsiniz.

![PowerPoint arka planı](powerpoint-background.png)

## **Normal Bir Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumda belirli bir slayt için katı bir rengi arka plan olarak ayarlamanıza olanak tanır—sunum bir master slayt kullansa bile. Değişiklik yalnızca seçilen slayta uygulanır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirtmek için [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) üzerindeki [getSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/#getSolidFillColor) metodunu kullanın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki PHP örneği, normal bir slayt için mavi katı rengi arka plan olarak ayarlamayı göstermektedir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Slaytın arka plan rengini maviye ayarla.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Sunumu diske kaydet.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Master Slayt İçin Katı Renk Arka Planı Ayarlama**

Aspose.Slides, bir sunumda master slayt için katı bir rengi arka plan olarak ayarlamanıza izin verir. Master slayt, tüm slaytların biçimlendirmesini kontrol eden bir şablon görevi gördüğünden, master slaytın arka planına katı bir renk seçtiğinizde bu, her slayta uygulanır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Master slaytın [BackgroundType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/backgroundtype/) (`getMasters` aracılığıyla) değerini `OwnBackground` olarak ayarlayın.
3. Master slayt arka planının [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) değerini `Solid` olarak ayarlayın.
4. Katı arka plan rengini belirtmek için [getSolidFillColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/#getSolidFillColor) metodunu kullanın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki PHP örneği, master slayt için katı bir renk (yeşil) arka planını ayarlamayı göstermektedir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Master slaytının arka plan rengini Orman Yeşili olarak ayarla.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Sunumu diske kaydet.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Slayt İçin Degrade Arka Planı Ayarlama**

Degrade, rengin kademeli bir değişimiyle oluşturulan bir görsel etkidir. Slayt arka planı olarak kullanıldığında degrade, sunumların daha sanatsal ve profesyonel görünmesini sağlar. Aspose.Slides, slaytların arka planı olarak bir degrade rengi ayarlamanıza izin verir.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) değerini `Gradient` olarak ayarlayın.
4. Tercih ettiğiniz degrade ayarlarını yapılandırmak için [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) üzerindeki [getGradientFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/#getGradientFormat) metodunu kullanın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki PHP örneği, bir slayt için degrade rengi arka plan olarak ayarlamayı göstermektedir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Arka plana bir degrade efekti uygula.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Sunumu diske kaydet.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Slaytı Görüntü ile Arka Plan Olarak Ayarlama**

Katı ve degrade dolguların yanı sıra Aspose.Slides, slayt arka planı olarak görüntüler kullanmanıza da izin verir.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın [BackgroundType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/backgroundtype/) değerini `OwnBackground` olarak ayarlayın.
3. Slayt arka planının [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) değerini `Picture` olarak ayarlayın.
4. Slayt arka planı olarak kullanmak istediğiniz görüntüyü yükleyin.
5. Görüntüyü sunumun görüntü koleksiyonuna ekleyin.
6. Görüntüyü arka plan olarak atamak için [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) üzerindeki [getPictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/#getPictureFillFormat) metodunu kullanın.
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki PHP örneği, bir slayt için arka plan olarak bir görüntüyü ayarlamayı göstermektedir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Arka plan görüntüsü özelliklerini ayarla.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Görüntüyü yükle.
    $image = Images::fromFile("Tulips.jpg");
    // Görüntüyü sunumun görüntü koleksiyonuna ekle.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Sunumu diske kaydet.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki kod örneği, arka plan dolgu tipini döşeli bir resim olarak ayarlamayı ve döşeme özelliklerini değiştirmeyi göstermektedir:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Arka plan doldurması için kullanılan görüntüyü ayarla.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Resim doldurma modunu Döşeme olarak ayarla ve döşeme özelliklerini ayarla.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}

Daha fazla bilgi için: [**Döşeli Resmi Doku Olarak Kullanma**](/slides/tr/php-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Arka Plan Görüntüsü Şeffaflığını Değiştirme**

Bir slaytın arka plan görüntüsünün şeffaflığını ayarlayarak slayt içeriğinin öne çıkmasını isteyebilirsiniz. Aşağıdaki PHP kodu, bir slayt arka plan görüntüsünün şeffaflığını nasıl değiştireceğinizi göstermektedir:

```php
$transparencyValue = 30; // Örneğin.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Slayt Arka Plan Değerini Almak**

Aspose.Slides, bir slaytın etkili arka plan değerlerini almak için `BackgroundEffectiveData` sınıfını sağlar. Bu sınıf, etkili [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) ve [EffectFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effectformat/) öğelerini ortaya çıkarır.

[BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/) sınıfının `getBackground` metodunu kullanarak bir slaytın etkili arka planını elde edebilirsiniz.

Aşağıdaki PHP örneği, bir slaytın etkili arka plan değerini almayı göstermektedir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Master, layout ve temayı göz önünde bulundurarak etkili arka planı al.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Özel bir arka planı sıfırlayıp tema/layout arka planını geri yükleyebilir miyim?**

Evet. Slaytın özel dolgusunu kaldırın; arka plan, ilgili [layout](/slides/tr/php-java/slide-layout/)/[master](/slides/tr/php-java/slide-master/) slaytından (yani [tema arka planı](/slides/tr/php-java/presentation-theme/)) tekrar devralınacaktır.

**Sunumun temasını daha sonra değiştirirsem arka plan ne olur?**

Bir slaytın kendi dolgusunu içeriyorsa, arka plan değişmeden kalır. Arka plan [layout](/slides/tr/php-java/slide-layout/)/[master](/slides/tr/php-java/slide-master/) üzerinden devralındıysa, yeni temaya uyacak şekilde güncellenir.