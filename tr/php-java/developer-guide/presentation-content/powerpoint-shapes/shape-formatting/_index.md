---
title: PHP'de PowerPoint Şekillerini Biçimlendirme
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/php-java/shape-formatting/
keywords:
- şekil biçimlendirme
- çizgi biçimlendirme
- birleştirme stili biçimlendirme
- gradyan dolgu
- desen dolgu
- resim dolgu
- doku dolgu
- katı renk dolgu
- şekil şeffaflığı
- şekil döndürme
- 3B köşe efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT, PPTX ve ODP dosyaları için dolgu, çizgi ve efekt stillerini hassas ve tam kontrol ile ayarlayın."
---
## **Giriş**

PowerPoint’te slaytlara şekil ekleyebilirsiniz. Şekiller çizgilerden oluştuğu için kenar çizgilerini değiştirerek veya etkilere uygulayarak biçimlendirebilirsiniz. Ayrıca şekillerin içlerinin nasıl doldurulacağını kontrol eden ayarları belirleyerek şekilleri biçimlendirebilirsiniz.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java, PowerPoint’te mevcut olan aynı seçenekleri kullanarak şekilleri biçimlendirmenizi sağlayan sınıflar ve metodlar sunar.

## **Çizgi Biçimlendirme**

Aspose.Slides kullanarak bir şekil için özel bir çizgi stili belirleyebilirsiniz. Aşağıdaki adımlar prosedürü özetler:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [line style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linestyle/) özelliğini ayarlayın.
1. Çizgi kalınlığını ayarlayın.
1. Çizginin [dash style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linedashstyle/) özelliğini ayarlayın.
1. Şeklin çizgi rengini ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu bir dikdörtgen `AutoShape` nasıl biçimlendirileceğini gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Dikdörtgen şeklinin dolgu rengini ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Dikdörtgenin çizgilerine biçimlendirme uygulayın.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Dikdörtgenin çizgi rengini ayarlayın.
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

## **Birleştirme Stilleri Biçimlendirme**

İşte üç birleştirme türü seçeneği:

* Yuvarlak
* Köşe
* Eğimli

Varsayılan olarak, PowerPoint iki çizgiyi bir açıda (örneğin bir şeklin köşesinde) birleştirirken **Yuvarlak** ayarını kullanır. Ancak keskin açıları olan bir şekil çizerseniz **Köşe** seçeneğini tercih edebilirsiniz.

![Sunumdaki birleştirme stili](join-style-powerpoint.png)

Aşağıdaki PHP kodu, yukarıdaki görselde gösterildiği gibi Miter, Bevel ve Round birleştirme tip ayarlarıyla üç dikdörtgenin nasıl oluşturulduğunu gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle türünde üç otomatik şekil ekleyin.
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

    // Çizgi genişliğini ayarlayın.
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

    // Birleştirme stilini ayarlayın.
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

PowerPoint’te Gradyan Dolgu, bir şekle sürekli bir renk geçişi uygulamanıza olanak tanıyan bir biçimlendirme seçeneğidir. Örneğin, bir rengin diğerine yavaşça karıştığı iki ya da daha fazla renk uygulayabilirsiniz.

Aspose.Slides kullanarak bir şekle gradyan dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Gradient` olarak ayarlayın.
1. [GradientFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/gradientformat/) sınıfı tarafından sunulan gradient durak koleksiyonunun `add` metodlarıyla konumları tanımlanmış iki tercih ettiğiniz rengi ekleyin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu bir elipse gradyan dolgu etkisi nasıl uygulanır gösterir:

```php
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Ellipse türünde bir otomatik şekil ekleyin.
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

![Gradyan dolgulu elips](gradient-fill.png)

## **Desen Dolgu**

PowerPoint’te Desen Dolgu, bir şekle iki renkli bir tasarım (nokta, çizgi, çapraz gölgelendirme veya kare gibi) uygulamanıza olanak tanıyan bir biçimlendirme seçeneğidir. Desenin ön ve arka plan renklerini özelleştirebilirsiniz.

Aspose.Slides, sunumlarınızın görsel çekiciliğini artırmak için şekillere uygulayabileceğiniz 45’ten fazla önceden tanımlanmış desen stilleri sunar. Önceden tanımlanmış bir deseni seçtikten sonra, kullanılacak tam renkleri hâlâ belirtebilirsiniz.

Aspose.Slides kullanarak bir şekle desen dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Pattern` olarak ayarlayın.
1. Önceden tanımlanmış seçeneklerden bir desen stili seçin.
1. Desenin [Background Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternformat/#getBackColor) (arka plan rengi) ayarlayın.
1. Desenin [Foreground Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternformat/#getForeColor) (ön plan rengi) ayarlayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu bir dikdörtgene desen dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
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

![Desen dolgulu dikdörtgen](pattern-fill.png)

## **Resim Dolgu**

PowerPoint’te Resim Dolgu, bir şeklin içine bir resim eklemenize ve resmi şeklin arka planı olarak kullanmanıza olanak tanıyan bir biçimlendirme seçeneğidir.

Aspose.Slides kullanarak bir şekle resim dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Picture` olarak ayarlayın.
1. Resim dolgu modunu `Tile` (veya tercih ettiğiniz başka bir mod) olarak ayarlayın.
1. Kullanmak istediğiniz resimden bir [PPImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ppimage/) nesnesi oluşturun.
1. Resmi `SlidesPicture.setImage` metoduna iletin.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

![Lotus resmi](lotus.png)

Aşağıdaki PHP kodu bir şekli resimle doldurmanın nasıl yapıldığını gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Dolgu tipini Picture olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Resim dolgu modunu ayarlayın.
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

![Resim dolgulu şekil](picture-fill.png)

### **Karo Resmi Doku Olarak Kullanma**

Karo bir resmi doku olarak ayarlamak ve karolama davranışını özelleştirmek istiyorsanız, aşağıdaki [PictureFillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/) sınıfı metodlarını kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim dolgu modunu ayarlar—`Tile` veya `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileAlignment): Şekil içinde karoların hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileFlip): Karoların yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Karoların yatay ofsetini (puan cinsinden) şeklin kökenine göre ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Karoların dikey ofsetini (puan cinsinden) şeklin kökenine göre ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileScaleX): Karoların yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/#setTileScaleY): Karoların dikey ölçeğini yüzde olarak tanımlar.

Aşağıdaki kod örneği bir dikdörtgen şekle karo resim dolgu ekleyip karo seçeneklerini nasıl yapılandıracağınızı gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Rectangle otomatik şekli ekleyin.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Şeklin dolgu tipini Picture olarak ayarlayın.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Görüntüyü yükleyin ve sunum kaynaklarına ekleyin.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Görüntüyü şekle atayın.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Resim dolgu modunu ve karo özelliklerini yapılandırın.
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

![Karo seçenekleri](tile-options.png)

## **Katı Renk Dolgu**

PowerPoint’te Katı Renk Dolgu, bir şekli tek, tek renkli bir arka planla dolduran bir biçimlendirme seçeneğidir. Bu sade arka plan rengi hiçbir gradyan, doku veya desen olmadan uygulanır.

Aspose.Slides kullanarak bir şekle katı renk dolgu uygulama adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. Şekle tercih ettiğiniz dolgu rengini atayın.
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki PHP kodu bir PowerPoint slaydındaki dikdörtgene katı renk dolgu nasıl uygulanır gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
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

![Katı renk dolgulu şekil](solid-color-fill.png)

## **Şeffaflık Ayarla**

PowerPoint’te bir şekle katı renk, gradyan, resim veya doku dolgusu uyguladığınızda, dolgunun opaklığını kontrol etmek için bir şeffaflık seviyesi de ayarlayabilirsiniz. Daha yüksek şeffaflık değeri, şeklin daha çok gözden kaçmasını sağlar ve arka planın ya da alt nesnelerin kısmen görünmesine izin verir.

Aspose.Slides, dolgu için kullanılan rengin alfa değerini ayarlayarak şeffaflık seviyesini belirlemenize olanak tanır. İşte nasıl yapılacağı:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. [FillType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filltype/) özelliğini `Solid` olarak ayarlayın.
1. `Color` sınıfını kullanarak şeffaflığı (alfa bileşeni şeffaflığı kontrol eder) içeren bir renk tanımlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu bir dikdörtgene şeffaf dolgu rengi nasıl uygulanır gösterir:

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

![Şeffaf şekil](shape-transparency.png)

## **Şekilleri Döndürme**

Aspose.Slides, PowerPoint sunumlarındaki şekilleri döndürmenize izin verir. Bu, görsel öğeleri belirli hizalama veya tasarım ihtiyaçlarıyla konumlandırırken kullanışlı olabilir.

Bir slayt üzerindeki bir şekli döndürmek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin döndürme özelliğini istediğiniz açıya ayarlayın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu bir şekli 5 derece nasıl döndüreceğinizi gösterir:

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // İlk slaytı alın.
    $slide = $presentation->getSlides()->get_Item(0);

    // Rectangle türünde bir otomatik şekil ekleyin.
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

## **3B Köşe Efektleri Ekle**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B köşe efektleri uygulamanıza izin verir.

Bir şekle 3B köşe efekti eklemek için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. Şeklin [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliğini köşe ayarlarını tanımlayacak şekilde yapılandırın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu bir şekle 3B köşe efektleri nasıl uygulanır gösterir:

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

![3B köşe etkisi](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekle**

Aspose.Slides, şekillere [ThreeDFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/threedformat/) özelliklerini yapılandırarak 3B döndürme efektleri uygulamanıza izin verir.

Bir şekle 3B döndürme uygulamak için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizinine göre bir slayta referans alın.
1. Slayta bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
1. 3B döndürmeyi tanımlamak için [setCameraType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/camera/#setCameraType) ve [setLightType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/lightrig/#setLightType) metodlarını kullanın.
1. Sunumu kaydedin.

Aşağıdaki PHP kodu bir şekle 3B döndürme efektleri nasıl uygulanır gösterir:

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

![3B döndürme etkisi](3D-rotation-effect.png)

## **Biçimlendirmeyi Sıfırla**

Aşağıdaki Java kodu, bir slaydın biçimlendirmesini nasıl sıfırlayacağınızı ve [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) üzerindeki yer tutuculara sahip tüm şekillerin konum, boyut ve biçimlendirmesini varsayılan ayarlarına nasıl geri döndüreceğinizi gösterir:

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

Yalnızca çok az etkiler. Gömülü görüntüler ve medya dosyaları dosya alanının çoğunu kaplarken, renkler, efektler ve gradyanlar gibi şekil parametreleri meta veri olarak saklanır ve neredeyse hiçbir ek boyut eklemez.

**Bir slayttaki aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplandırabilirim?**

Her şeklin temel biçimlendirme özelliklerini (dolgu, çizgi ve efekt ayarları) karşılaştırın. Tüm ilgili değerler aynıysa stillerini aynı olarak kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir setini diğer sunumlarda yeniden kullanmak üzere ayrı bir dosyaya kaydedebilir miyim?**

Evet. İstenen stillere sahip örnek şekilleri bir şablon slayt destesi ya da .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilize şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.