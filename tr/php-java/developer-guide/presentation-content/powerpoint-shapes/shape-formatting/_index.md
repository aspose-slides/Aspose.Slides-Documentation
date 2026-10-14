---
title: PowerPoint Şekillerini PHP'de Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/php-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- çizim efekti
- şekil çizgi taslağı
- bağlama stilini biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil şeffaflığı
- siyah-beyaz şekil işleme
- gri tonlamalı şekil işleme
- şekil döndürme
- 3B eğim efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassas bir şekilde ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekiller ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlıklarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca, iç kısımların nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java, PowerPoint’te bulunan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. İşlem aşağıdaki adımlarla açıklanmıştır:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini belirleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgen `AutoShape` nasıl biçimlendirilir gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklin doldurma rengini ayarla.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Dikdörtgenin çizgilerine biçimlendirme uygula.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Dikdörtgenin çizgi rengini ayarla.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // PPTX dosyasını diske kaydet.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The formatted lines in the presentation](formatted-lines.png)

## **Şekil Çizgilerine Çizim Efekti Uygulama**

Çizim efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), çizim ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), ve çizim tipini seçmek için [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) kullanın; değerler [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) enumından alınır.

Aşağıdaki PHP kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) efekti nasıl uygulanır, açıkça atanmış değer nasıl okunur ve [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) ile efekt nasıl kaldırılır gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi biçimine ve onun taslak biçimine eriş.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Bir taslak efekti uygula.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Şekle doğrudan atanmış taslak efektini oku.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Taslak efektini kaldır.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya yerleşim slaytından devralınabiliyorsa, [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) kullanın, dönen nesnenin `getSketchFormat` yöntemine erişin ve `getSketchType` değerini okuyun. Etkin değer, devralmanın çözüldükten sonra aslında uygulanan biçimlendirmeyi yansıtır:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Bağlama Stilleri Biçimlendirme**

Üç bağlama tipi seçeneği şunlardır:

* Yuvarlak
* Köşe
* Eğik

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çiziyorsanız **Köşe** seçeneğini tercih edebilirsiniz.

![The join style in the presentation](join-style-powerpoint.png)

Aşağıdaki PHP kodu, yukarıdaki görüntüde gösterildiği gibi Miter, Bevel ve Round bağlama tipi ayarları kullanılarak üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Her bir dikdörtgen şeklin doldurma rengini ayarla.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Çizgi kalınlığını ayarla.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Her bir dikdörtgenin çizgi rengini ayarla.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Bağlama stilini ayarla.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Her bir dikdörtgene metin ekle.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // PPTX dosyasını diske kaydet.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradyan Dolgu**

PowerPoint’te Gradyan Dolgu, bir şekle sürekli renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi, birinin yavaş yavaş diğerine karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/) sınıfının sağladığı gradyan durak koleksiyonunun `add` metodlarını kullanarak konumları belirlenmiş iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir elips üzerinde gradyan dolgu etkisinin nasıl uygulanacağını gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirmesi uygula.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Gradyanın yönünü ayarla.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // İki gradyan durak ekle.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX dosyasını diske kaydet.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The ellipse with gradient fill](gradient-fill.png)

Bir gradyan, dışa aktarılan görüntüde PowerPoint’teki görünümünden farklı ise, [Choose a Gradient Rendering Style](/slides/tr/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda depolanan gradyan dolgu değiştirilmeden bir işleme stili seçebilirsiniz.

## **Desen Dolgu**

PowerPoint’te Desen Dolgu, bir şekle iki renkli bir tasarım (nokta, çizgi, çapraz çizgi veya kare gibi) uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulanabilecek 45’ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra bile kullanılacak tam renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Önceden tanımlı seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) özelliğini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgene desen dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Pattern olarak ayarla.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Desen stilini ayarla.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Desenin arka plan ve ön plan renklerini ayarla.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX dosyasını diske kaydet.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The rectangle with pattern fill](pattern-fill.png)

## **Resim Dolgu**

PowerPoint’te Resim Dolgu, bir şeklin içine bir görüntü yerleştirmenizi sağlayan bir biçimlendirme seçeneğidir; böylece görüntü şeklin arka planı olarak kullanılır.

Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görüntüyü `SlidesPicture.setImage` yöntemine aktarın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

“lotus.png” adlı dosyamızın aşağıdaki resmi olduğunu varsayalım:

![The lotus picture](lotus.png)

Aşağıdaki PHP kodu, bir şekli resimle nasıl dolduracağınızı gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Dolgu tipini Picture olarak ayarla.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Resim dolgu modunu ayarla.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Bir görüntü yükle ve sunum kaynaklarına ekle.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Resmi ayarla.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // PPTX dosyasını diske kaydet.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The shape with picture fill](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşeme bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek isterseniz, aşağıdaki [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) sınıfı yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim dolgu modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içinde hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin şekle göre yatay ofsetini (puan cinsinden) ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin şekle göre dikey ofsetini (puan cinsinden) ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekle döşemeli resim dolgu ekleyip döşeme seçeneklerini yapılandırmayı gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Bir dikdörtgen otomatik şekil ekle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarla.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Görüntüyü yükle ve sunum kaynaklarına ekle.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Görüntüyü şekle ata.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Resim dolgu modunu ve döşeme özelliklerini yapılandır.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // PPTX dosyasını diske kaydet.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The tile options](tile-options.png)

## **Düz Renk Dolgu**

PowerPoint’te Düz Renk Dolgu, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulamak için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz doldurma rengini atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir PowerPoint slaydındaki dikdörtgene düz renk dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Solid olarak ayarla.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Dolgu rengini ayarla.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX dosyasını diske kaydet.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The shape with solid color fill](solid-color-fill.png)

## **Saydamlık Ayarlama**

PowerPoint’te bir şekle düz renk, gradyan, resim veya doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol etmek için bir saydamlık seviyesi de belirleyebilirsiniz. Daha yüksek bir saydamlık değeri şekli daha geçirgen hâle getirir; arka plan veya alt nesneler kısmen görünür olur.

Aspose.Slides, dolgu rengi içindeki alfa değerini ayarlayarak saydamlık seviyesini belirlemenizi sağlar. İşte nasıl yapılacağı:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` sınıfını kullanarak saydamlığı olan bir renk tanımlayın (`alpha` bileşeni saydamlığı kontrol eder).
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgene saydam dolgu rengi nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekle.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekle.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // PPTX dosyasını diske kaydet.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The transparent shape](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarına göre konumlandırırken yararlı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekli 5 derece nasıl döndürür gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndür.
    $shape->setRotation(5);

    // PPTX dosyasını diske kaydet.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The shape rotation](shape-rotation.png)

## **3B Eğim Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B eğim efektleri uygulamanıza olanak tanır.

Bir şekle 3B eğim efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak eğim ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekle 3B eğim efektleri nasıl uygulanır gösterir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Slayta bir şekil ekle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Şeklin ThreeDFormat özelliklerini ayarla.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Sunumu PPTX dosyası olarak kaydet.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The 3D bevel effect](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza izin verir.

3B döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ekleyin.
1. [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) yöntemlerini kullanarak 3B döndürmeyi tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekle 3B döndürme efektleri nasıl uygulanır gösterir:

```php
// Presentation sınıfının bir örneğini oluştur.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Sunumu PPTX dosyası olarak kaydet.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The 3D rotation effect](3D-rotation-effect.png)

## **Şekiller için Siyah-Beyaz İşleme Kontrolü**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl işleneceğini belirtir. Bu yöntem tek başına siyah-beyaz görüntüyü etkinleştirmez ve normal renk modundaki şeklin dolgu, çizgi veya diğer biçimlendirmesini değiştirmez.

İstenilen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) sınıfından bir değer kullanın. Örneğin, `Automatic` dönüşümü uygulama programının seçmesine izin verir, `Gray` ve `LightGray` gri renk kullanır, `BlackWhite` sadece siyah ve beyaz, `Black` ve `White` tek bir renk zorlar, `Color` normal renkleme korunur ve `Hidden` şekli siyah-beyaz modunda gizler. `NotDefined` şekil seviyesinde bir mod atanmadığını gösterir.

Aşağıdaki PHP kodu, renkli bir şekil oluşturur ve siyah-beyaz görüntü modunda gri görünmesini sağlar:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Turuncu dolguyu renk modunda tut, ancak şekli siyah-beyaz modunda gri renkle renderla.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Normal renk modunda dikdörtgen turuncu dolgu ile kalır. Siyah-beyaz görüntü iş akışında, modu `Gray` olarak ayarlandığı için gri renkleme kullanır. Bu, tam renkli bir slaytı korurken baskı, önizleme veya siyah-beyaz görüntü ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanıza olanak tanır.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlamayı ve [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) üzerindeki tüm yer tutucu şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara geri döndürmeyi gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Düzende yer tutucuya sahip slayttaki her şekli sıfırla.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi sonuç sunum dosya boyutunu etkiler mi?**

Sadece çok az. Gömülü görüntüler ve medya dosyaları dosya alanının büyük kısmını oluşturur, şekil parametreleri (renkler, efektler, gradyanlar) meta veri olarak saklanır ve neredeyse ek bir boyut eklemez.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplandırın; bu, ileride stil yönetimini basitleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesine veya bir .POTX şablon dosyasına kaydedin. Yeni bir sunum oluştururken şablonu açın, ihtiyaç duyduğunuz stilize şekilleri klonlayın ve gerekli yerlerde biçimlendirmeyi yeniden uygulayın.