---
title: PHP'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/php-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- taslak efekti
- taslak şekil çizgisi
- bağlantı stili biçimlendirme
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- katı renk doldurma
- şekil saydamlığı
- siyah‑beyaz şekil renderleme
- gri tonlamalı şekil renderleme
- şekil döndürme
- 3D kırma etkisi
- 3D döndürme etkisi
- biçimlendirmeyi sıfırlama
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenar çizgilerine etkiler uygulayarak veya değiştirerek biçimlendirebilirsiniz. Ayrıca şeklin içinin nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format‑shape‑powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java, PowerPoint’te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. İşlem aşağıdaki adımlarla açıklanmıştır:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini belirleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgen `AutoShape` nasıl biçimlendirilir gösterir:

```php
    // Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
    $presentation = new Presentation();
    try {
        // İlk slaytı alın.
        $slide = $presentation->getSlides()->get_Item(0);

        // Rectangle tipinde bir otomatik şekil ekleyin.
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

        // Dikdörtgen şeklinin dolgu rengini ayarlayın.
        $shape->getFillFormat()->setFillType(FillType::NoFill);

        // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
        $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
        $shape->getLineFormat()->setWidth(7);
        $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

        // Dikdörtgenin çizgisinin rengini ayarlayın.
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

        // PPTX dosyasını diske kaydedin.
        $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

Sonuç:

![Sunumdaki biçimlendirilmiş çizgiler](formatted-lines.png)

## **Şekil Çizgilerine Çizim Efekti Uygulama**

Bir çizim efekti, şekil çizgisini elle çizilmiş gibi gösterir. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) yöntemini, çizim ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lineformat/) yöntemini ve [SketchFormat.setSketchType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sketchformat/) yöntemiyle [LineSketchType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linesketchtype/) enum’undan bir değer seçebilirsiniz.

Aşağıdaki PHP kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linesketchtype/) efekti nasıl uygulanır, atanmış değer nasıl okunur ve [LineSketchType.None](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linesketchtype/) ile efekt nasıl kaldırılır gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi formatına ve taslak formatına erişin.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Bir taslak efekti uygulayın.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Şekle doğrudan atanmış taslak efektini okuyun.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Taslak efektini kaldırın.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sketchformat/) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından devralınabiliyorsa, [LineFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lineformat/) kullanın, dönen nesnenin `getSketchFormat` metoduna erişin ve `getSketchType` değerini okuyun. Etkili değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Bağlantı Stilini Biçimlendirme**

Üç bağlantı türü seçeneği şunlardır:

* Round
* Miter
* Bevel

PowerPoint varsayılan olarak iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Round** ayarını kullanır. Ancak keskin açıları olan bir şekil çizerseniz **Miter** seçeneğini tercih edebilirsiniz.

![Sunumdaki bağlantı stili](join-style-powerpoint.png)

Aşağıdaki PHP kodu, yukarıdaki görseldeki üç dikdörtgenin Miter, Bevel ve Round bağlantı stil ayarlarıyla nasıl oluşturulduğunu gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde üç otomatik şekil ekleyin.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Her dikdörtgen şeklinin dolgu rengini ayarlayın.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Çizgi kalınlığını ayarlayın.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Her dikdörtgenin çizgisinin rengini ayarlayın.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Bağlantı stilini ayarlayın.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Her dikdörtgene metin ekleyin.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // PPTX dosyasını diske kaydedin.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Degrade Doldurma**

PowerPoint’te Degrade Doldurma, bir şekle sürekli bir renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin iki veya daha fazla renk, birinin diğerine yavaşça karıştığı şekilde uygulanabilir.

Aspose.Slides kullanarak bir şekle degrade doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/gradientformat/) sınıfının sunduğu degrade durakları koleksiyonunun `add` metodlarıyla iki tercih ettiğiniz rengi tanımlı konumlarla ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir elipse nasıl degrade doldurma efekti uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Elipseye degrade biçimlendirmesi uygulayın.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Degradenin yönünü ayarlayın.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // İki degrade durak ekleyin.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Degrade doldurulmuş elips](gradient-fill.png)

## **Desen Doldurma**

PowerPoint’te Desen Doldurma, iki renkli bir tasarım—nokta, şerit, çapraz çizgi veya kare—şekle uygulanmasını sağlayan bir biçimlendirme seçeneğidir. Desenin ön plan ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulanabilen 45’ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir desen seçtikten sonra bile kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçenekler arasından bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternformat/#getBackColor) özelliğini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternformat/#getForeColor) özelliğini ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgene nasıl desen doldurma uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dolgu türünü Pattern olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Desen stilini ayarlayın.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Desenin arka plan ve ön plan renklerini ayarlayın.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Desen doldurulmuş dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

PowerPoint’te Resim Doldurma, bir şeklin içine bir görüntü ekleyerek resmi şeklin arka planı olarak kullanmanızı sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim doldurma modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görselden bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görseli `SlidesPicture.setImage` metoduna aktarın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıda “lotus.png” adlı dosyanın görseli gösterilmiştir:

![Lotus resmi](lotus.png)

Aşağıdaki PHP kodu, bir şekli resimle nasıl doldurur gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Dolgu türünü Picture olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Resim doldurma modunu ayarlayın.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Resmi ayarlayın.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Resim doldurulmuş şekil](picture-fill.png)

### **Doku Olarak Döşeme Resmi**

Döşeme şeklinde bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) sınıfının aşağıdaki yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim doldurma modunu `Tile` ya da `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içinde hizalanmasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin şeklin orijiniyle olan yatay ofsetini (puan cinsinden) ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin şeklin orijiniyle olan dikey ofsetini (puan cinsinden) ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yüzde olarak yatay ölçeğini tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin yüzde olarak dikey ölçeğini tanımlar.

Aşağıdaki kod örneği, bir dikdörtgen şekline döşemeli resim doldurma ekleyip döşeme seçeneklerini nasıl yapılandırır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Bir dikdörtgen otomatik şekil ekleyin.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu türünü Picture olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Görüntüyü şekle atayın.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Resim doldurma modunu ve döşeme özelliklerini yapılandırın.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Katı Renk Doldurma**

PowerPoint’te Katı Renk Doldurma, bir şekli tek, tekdüze bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu düz arka plan rengi, degrade, doku ya da desen içermeden uygulanır.

Aspose.Slides kullanarak bir şekle katı renk doldurma uygulama adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz doldurma rengini atayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir PowerPoint slaydındaki dikdörtgene katı renk doldurma nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dolgu türünü Solid olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Dolgu rengini ayarlayın.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Katı renk doldurulmuş şekil](solid-color-fill.png)

## **Saydamlık Ayarlama**

PowerPoint’te bir şekle katı renk, degrade, resim ya da doku doldurma uyguladığınızda, doldurmanın saydamlık seviyesini de belirleyerek opaklığını kontrol edebilirsiniz. Yüksek saydamlık değeri, şeklin daha çok görünür olmasını sağlar ve arka plan ya da alttaki nesneler bir kısmı görünür hâle gelir.

Aspose.Slides, doldurma için kullanılan rengin alfa değerini ayarlayarak saydamlık seviyesini belirlemenizi sağlar. İşte yöntemi:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` sınıfını kullanarak saydamlığı (alfa bileşeni) içeren bir renk tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgene nasıl saydam bir doldurma rengi uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Katı bir dikdörtgen otomatik şekil ekleyin.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Katı şeklin üzerine şeffaf bir dikdörtgen otomatik şekil ekleyin.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // PPTX dosyasını diske kaydedin.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Saydam şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayt üzerindeki bir şekli döndürmek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekli 5 derece nasıl döndürür gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Şekli 5 derece döndürün.
    $shape->setRotation(5);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3D Kırma Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D kırma (bevel) efektleri uygular.

Bir şekle 3D kırma efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini başlatın.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliğini ayarlayarak kırma ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekle 3D kırma efektleri nasıl uygulanır gösterir:

```php
// Presentation sınıfının bir örneğini oluşturun.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Slayta bir şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Şeklin ThreeDFormat özelliklerini ayarlayın.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Sunumu bir PPTX dosyası olarak kaydedin.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![3D kırma efekti](3D-bevel-effect.png)

## **3D Döndürme Efektleri Ekleme**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3D döndürme efektleri uygular.

Bir şekle 3D döndürme uygulamak için:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. [setCameraType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lightrig/#setLightType) metodlarını kullanarak 3D döndürmeyi tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekle 3D döndürme efektleri nasıl uygulanır gösterir:

```php
// Presentation sınıfının bir örneğini oluşturun.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Sunumu bir PPTX dosyası olarak kaydedin.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![3D döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah‑Beyaz Renderlemeyi Kontrol Etme**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#setBlackWhiteMode) yöntemi, bir sunum siyah‑beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl renderlanacağını belirtir. Bu yöntem tek başına siyah‑beyaz görüntülemeyi etkinleştirmez ve normal renk modundaki şeklin doldurma, çizgi ya da diğer biçimlendirmelerini değiştirmez.

İstenen davranışı seçmek için [BlackWhiteMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/blackwhitemode/) sınıfından bir değer kullanın. Örneğin `Automatic` dönüşümü uygulama programına bırakır, `Gray` ve `LightGray` gri tonlamayı, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek bir rengi, `Color` normal renkleri korur, `Hidden` şekli siyah‑beyaz modunda gizler. `NotDefined` ise şekil düzeyinde bir mod atanmadığını gösterir.

Aşağıdaki PHP kodu, renkli bir şekil oluşturur ve siyah‑beyaz görüntüleme modunda gri görünmesini sağlar:

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

    // Renk modunda turuncu dolguyu koruyun, ancak siyah-beyaz modunda şekli gri renkle renderlayın.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Normal renk modunda dikdörtgen turuncu dolgu ile kalır. Siyah‑beyaz görüntüleme akışında ise modu `Gray` olduğundan gri renkte gösterilir. Bu, tam renkli bir slaytı korurken, yazdırma, ön izleme ya da sunumun siyah‑beyaz görüntüleme ayarlarını dikkate alan diğer akışlar için ayrı bir görünüm tanımlamanıza olanak verir.

## **Biçimlendirmeyi Sıfırlama**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini sıfırlamak ve [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) üzerindeki yer tutuculara sahip tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlara döndürmek için kullanılabilir:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Yerleşimde yer tutucu bulunan slayttaki her şekli sıfırla.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosya boyutunu etkiler mi?**

Özellikle çok az. Gömülü görüntüler ve medya dosyaları dosya alanının çoğunu kaplarken, renkler, efektler ve degradeler gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut oluşturmaz.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta tespit edip gruplamak nasıl yapılır?**

Her şeklin ana biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa stilleri aynı kabul edip o şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini sadeleştirir.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak için ayrı bir dosyada saklayabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında tutun. Yeni bir sunum oluştururken şablonu açın, ihtiyaç duyduğunuz stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.