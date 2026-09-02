---
title: "PHP'de PowerPoint Şekillerini Biçimlendirme"
linktitle: "Şekil Biçimlendirme"
type: docs
weight: 20
url: /tr/php-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- eskiz efekti
- eskiz şekil çizgisi
- birleştirme stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- düz renk dolgu
- şekil şeffaflığı
- şekli döndürme
- 3B köz efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyalarında dolgu, çizgi ve efekt stillerini kesinlik ve tam kontrol ile ayarlayın."
---
## **Giriş**

PowerPoint'te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için, kenarlıklarını değiştirerek veya efektler uygulayarak biçimlendirebilirsiniz. Ayrıca şekillerin iç kısımlarını dolduran ayarları belirleyerek biçimlendirme yapabilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java, PowerPoint'te mevcut aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirtebilirsiniz. İşlem aşağıdaki adımlarla açıklanmıştır:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını belirleyin.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini belirleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgen `AutoShape`'i nasıl biçimlendireceğinizi gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipi bir otomatik şekil ekleyin.
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

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Bir eskiz efekti, şekil çizgisini elle çizilmiş gibi gösterir. Çizgi ayarlarına erişmek için [Shape.getLineFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/), eskiz ayarlarına erişmek için [LineFormat.getSketchFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lineformat/), ve [SketchFormat.setSketchType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sketchformat/) ile [LineSketchType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linesketchtype/) öneklerinden bir değeri seçebilirsiniz.

Aşağıdaki PHP kodu, bir [LineSketchType.Curved](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linesketchtype/) efekti nasıl uygulanır, atanmış değer nasıl okunur ve [LineSketchType.None](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linesketchtype/) ile efekt nasıl kaldırılır gösterir:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Şeklin çizgi formatına ve eskiz formatına eriş.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Bir eskiz efekti uygula.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Şekle doğrudan atanmış eskiz efektini oku.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Eskiz efektini kaldır.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sketchformat/) tarafından döndürülen değer, doğrudan şekle atanan ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından kalıtılamışsa, [LineFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lineformat/) kullanın, dönen nesnenin `getSketchFormat` metoduna erişin ve `getSketchType` değerini okuyun. Etkin değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır:

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

## **Birleştirme Stilleri Biçimlendirme**

İşte üç birleştirme türü seçeneği:

* Yuvarlak
* Köşe
* Eğimli

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak, keskin açılara sahip bir şekil çizerken **Köşe** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

Aşağıdaki PHP kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Round (Yuvarlak) birleştirme türü ayarlarıyla üç dikdörtgenin nasıl oluşturulduğunu gösterir:

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

    // Her dikdörtgenin çizgi rengini ayarlayın.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Bağlama stilini ayarlayın.
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

## **Gradyan Dolgu**

PowerPoint'te Gradyan Dolgu, bir şekle sürekli bir renk geçişi uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Örneğin, iki veya daha fazla rengi birinin diğerine yavaşça karıştığı şekilde uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/gradientformat/) sınıfı tarafından sunulan gradyan durak koleksiyonunun `add` metotlarıyla konumları tanımlanmış iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir elips üzerine gradyan dolgu etkisi nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Elipseye gradyan biçimlendirmesi uygulayın.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Gradyanın yönünü ayarlayın.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // İki gradyan durak ekleyin.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Gradyan dolgu uygulanmış elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint'te Desen Dolgu, bir şekle iki renkli bir tasarım—nokta, çizgi, çapraz tarama veya kare gibi—uygulamanızı sağlayan bir biçimlendirme seçeneğidir. Desenin ön planı ve arka planı için özel renkler seçebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45'ten fazla ön tanımlı desen stili sunar. Ön tanımlı bir deseni seçtikten sonra, hâlâ kullanılacak kesin renkleri belirleyebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Ön tanımlı seçenekler arasından bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternformat/#getBackColor) değerini ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternformat/#getForeColor) değerini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgene desen dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Pattern olarak ayarlayın.
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

![Desen dolgu uygulanmış dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint'te Resim Dolgu, bir şeklin içine bir resim eklemenizi—resmi şeklin arka planı gibi kullanmanızı—sağlayan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz görüntüden bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Görüntüyü `SlidesPicture.setImage` metoduna aktarın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki resim, "lotus.png" adlı dosyanın içeriğini göstermektedir:

![Lotus resmi](lotus.png)

Aşağıdaki PHP kodu, bir şekle resim dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Dolgu tipini Picture olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Resim dolgu modunu ayarlayın.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Bir görüntü yükleyin ve sunum kaynaklarına ekleyin.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Resimi ayarlayın.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // PPTX dosyasını diske kaydedin.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Resim dolgu uygulanmış şekil](picture-fill.png)

### **Resmi Doku Olarak Döşe**

Köşeli bir resmi doku olarak ayarlamak ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) sınıfı yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim dolgu modunu `Tile` veya `Stretch` olarak ayarlar.
- [setTileAlignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içinde nasıl hizalanacağını belirtir.
- [setTileFlip](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey ya da her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin yatay ofsetini (puan cinsinden) şeklin orijinalinden ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin dikey ofsetini (puan cinsinden) şeklin orijinalinden ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği, döşenmiş bir resim dolgu ile bir dikdörtgen şekli ekleyip döşeme seçeneklerini nasıl yapılandıracağınızı gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Resmi şekle atayın.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Resim dolgu modunu ve döşeme özelliklerini yapılandırın.
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

## **Düz Renk Dolgu**

PowerPoint'te Düz Renk Dolgu, bir şekli tek ve tekdüz bir renk ile dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi, hiçbir gradyan, doku ya da desen içermeden uygulanır.

Aspose.Slides kullanarak bir şekle düz renk dolgu uygulamak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. İstediğiniz dolgu rengini şekle atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu, bir PowerPoint slaytındaki bir dikdörtgene düz renk dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle tipinde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Dolgu tipini Solid olarak ayarlayın.
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

![Düz renk dolgu uygulanmış şekil](solid-color-fill.png)

## **Şeffaflığı Ayarlama**

PowerPoint'te bir şekle düz renk, gradyan, resim ya da doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol etmek için şeffaflık düzeyi de ayarlayabilirsiniz. Daha yüksek bir şeffaflık değeri, şeklin daha fazla görünür olmasını sağlar ve arka plan ya da alt nesneler kısmen görünür hale gelir.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` kullanarak alfa bileşeniyle şeffaflığı kontrol eden bir renk tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir dikdörtgene şeffaf bir dolgu rengi nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Düz bir dikdörtgen otomatik şekil ekleyin.
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

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarında şekilleri döndürmenizi sağlar. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken faydalı olabilir.

Bir slayttaki bir şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin dönüş özelliğini istediğiniz açıya ayarlayın.
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

## **3B Köz Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B köz efektleri eklemenizi sağlar.

Bir şekle 3B köz efekti eklemek için şu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliğini yapılandırarak köz ayarlarını tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekle 3B köz efektleri nasıl uygulanır gösterir:

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

    // Sunumu PPTX dosyası olarak kaydedin.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![3B köz efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekle**

Aspose.Slides, şekillerin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri eklemenizi sağlar.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lightrig/#setLightType) yöntemlerini kullanın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir şekle 3B döndürme efektleri nasıl uygulanır gösterir:

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

    // Sunumu PPTX dosyası olarak kaydedin.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini nasıl sıfırlayacağınızı ve [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) üzerindeki yer tutucularla birlikte tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına nasıl geri döndüreceğinizi gösterir:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Düzen üzerindeki yer tutucuya sahip slayttaki her şeklin biçimlendirmesini sıfırla.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi nihai sunum dosyasının boyutunu etkiler mi?**

Sadece çok az etkiler. Gömülü görüntüler ve medya dosyaları dosyanın büyük kısmını oluştururken, renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse ek bir boyut katmaz.

**Aynı biçimlendirmeye sahip şekilleri bir slaytta nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini—dolgu, çizgi ve efekt ayarlarını—karşılaştırın. Tüm ilgili değerler eşleşiyorsa, stillerini aynı olarak kabul edip bu şekilleri mantıksal olarak gruplayabilirsiniz; bu, sonraki stil yönetimini kolaylaştırır.

**Özel şekil stillerini başka sunumlarda yeniden kullanmak üzere ayrı bir dosyada saklayabilir miyim?**

Evet. İstediğiniz stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında tutun. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri kopyalayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.