---
title: PHP'de PowerPoint Şekillerini Biçimlendir
linktitle: Şekil Biçimlendirme
type: docs
weight: 20
url: /tr/php-java/shape-formatting/
keywords:
- şekil biçimlendir
- çizgi biçimlendir
- eskiz efekti
- şekil çizgisi eskiz
- birleşim stili biçimlendir
- degrade doldurma
- desen doldurma
- resim doldurma
- doku doldurma
- düz renk doldurma
- şekil saydamlığı
- siyah-beyaz şekil renderlaması
- gri tonlamalı şekil renderlaması
- şekil döndür
- 3B kabartma efekti
- 3B döndürme efekti
- biçimlendirmeyi sıfırla
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint şekillerini nasıl biçimlendireceğinizi öğrenin—PPT ve PPTX dosyaları için doldurma, çizgi ve efekt stillerini hassasiyetle ve tam kontrolle ayarlayın."
---
## **Giriş**

PowerPoint’te şekillerin kenarlıklarını, doldurmalarını ve efektlerini ayarlayarak biçimlendirin. Aspose.Slides for PHP via Java, şeffaflık, döndürme ve 3B biçimlendirme dahil olmak üzere bu ayarları programlı olarak kontrol etmenizi sağlar.

![PowerPoint’te şekil biçimlendirme seçenekleri](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java, şekilleri PowerPoint’te mevcut olan aynı seçenekleri kullanarak biçimlendirmenizi sağlayan sınıflar ve yöntemler sunar.

## **Çizgi Biçimlendirme**

Şeklin kenarlığını kontrol etmek için [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) kullanın. Bu örnek, mavi, kesikli kenarlığa sahip doldurulmamış bir dikdörtgen oluşturur. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) kalın‑ince bileşik bir çizgi seçer, [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) genişliği 7 puana ayarlar ve [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) kesik desenini seçer.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Sunumda biçimlendirilmiş çizgiler](formatted-lines.png)

### **Özel Çizgi Kesik Desenlerini Ayarlama**

Önceden tanımlı çizgi stilleri ihtiyaç duyduğunuz kesik ve boşluk uzunluklarını sağlamadığında, örneğin marka kenarlıkları veya teknik diyagramlar için, [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) kullanın. Bir desen atandığında çizgi kesik stili otomatik olarak [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) olarak değişir.

Dizi girişleri, bir kesikle başlayarak kesik ve boşluk uzunluklarını sırayla değiştirir. Her değer, çizgi genişliğinin bir katıdır: 3 puan genişlikte `[4, 2]` 12 puan kesik ve ardından 6 puan boşluk üretir. Tam kesik‑boşluk segmentleri tanımlamak için sonlu, negatif olmayan değer çiftleri kullanın. Örnek, her kesik ve boşluğun görünür kalması için pozitif değerler kullanır.

Bu örnek, aynı uzunlukta ve düz uçlu beş mavi çizgi oluşturur. İlk üç, 3 puan genişliğinde desenleri karşılaştırır. Dördüncüsü, ilk deseni iki kat genişlikte tekrarlayarak hem kesik hem boşluk uzunluklarını iki katına çıkarır. Beşincisi ise özel deseni katı bir çizgiye değiştirir.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Son satırdaki çizgiyi katı bir stile döndür.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bunun yerine önceden tanımlı kesik bir stile dönmek için, [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) i [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) metoduna geçirin. Seçilen stil, çizginin görünümünü kontrol eder.

PowerPoint’te sonuç, üstten alta: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; ve **Solid, 3 pt**.

![PowerPoint’te üç özel kesik desen, ilk deseni kullanan daha geniş bir çizgi ve katı bir çizgi](custom-dash-patterns.png)

### **Çizgi Uçlarını Ayarla**

[LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) bir açık çizginin uçlarını ayarlamak için. [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) sınıfı üç açık uç stilini sağlar:

- `Flat`: Çizgi uç noktasında durur.
- `Round`: Yarım dairesel uç, uç noktasının yarı çizgi genişliği kadar ötesine uzanır.
- `Square`: Kare uç, uç noktasının yarı çizgi genişliği kadar ötesine uzanır.

Sınıf ayrıca `NotDefined` stilini içerir; bu, açık bir uç stilinin atanmadığı anlamına gelir.

Uçlar, çizgi uçlarına simgeler ekleyen ok uçlarından ve çizgi segmentleri arasındaki köşeleri kontrol eden birleşimlerden farklıdır. Bu örnek, sadece uç şekillerini karşılaştırmak için [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) ve [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) ile ok uçlarını devre dışı bırakır.

İzleyen örnek, 20 puan genişliğinde, diğer yönleri aynı olan üç yatış çizgi oluşturur. Üstten alta düz, yuvarlak ve kare uçlar kullanılır. Uç noktaları aynı yatay koordinatlara sahiptir; yuvarlak ve kare uçlar her uç noktasının 10 puan ötesine uzanır.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint’te sonuç, üstten alta: **Flat**, **Round**, ve **Square**.

![PowerPoint’te aynı kalın çizgilerde düz, yuvarlak ve kare uçlar](line-caps.png)

## **Şekil Çizgilerine Eskiz Efektleri Uygulama**

Eskiz efekti, bir şekil çizgisinin el çizimi gibi görünmesini sağlar. Çizgi ayarlarına erişmek için [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat), eskiz ayarlarına erişmek için [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat), ve [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) ile [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) sınıfından bir değer seçin.

Aşağıdaki PHP kodu, bir [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) etkisi uygulamayı, açıkça atanmış değeri okumayı ve efekti [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) ile kaldırmayı gösterir:

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

[SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) tarafından döndürülen değer, şekle doğrudan atanmış ayarı temsil eder. Çizgi biçimlendirmesi bir temadan, ana slayttan veya düzen slaytından kalıtılabiliyorsa, [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective) kullanın, dönen nesnenin `getSketchFormat` metoduna erişin ve `getSketchType` değerini okuyun. Etkili değer, kalıtım çözüldükten sonra gerçekte uygulanan biçimlendirmeyi yansıtır. Bu örnek, ilk slaytında en az bir şekil bulunan mevcut bir sunum gerektirir ve her iki değeri de yazdırır:

```php
use aspose\slides\Presentation;

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

## **Birleşim Stillerini Biçimlendirme**

İşte üç birleşim türü seçeneği:

* Round
* Miter
* Bevel

Birleşim stili, iki kenar segmentinin bir köşede nasıl buluşacağını kontrol eder. Yuvarlatılmış köşeler için **Round**, keskin köşeler için **Miter**, ya da düzleştirilmiş köşeler için **Bevel** kullanın.

![Sunumdaki birleşim stili](join-style-powerpoint.png)

Bu örnek, 15 puan genişliğinde mavi kenarlıklı üç siyah dikdörtgen oluşturur. Köşelerin nasıl çizildiğini karşılaştırmak için [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) metodunu sırasıyla [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) sınıfının miter, bevel ve round değerlerine ayarlar.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Keskin Köşelerde Miter Birleşimlerini Sınırla**

[LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) i, [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) i [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) olarak ayarlayarak, keskin bir köşenin ne kadar uzayabileceğini sınırlamak için kullanın.

Sınırlama, birleşimin iç ve dış köşeleri arasındaki mesafenin çizgi genişliğine oranıdır. Örneğin, `8` değeri, miter uzunluğunu çizgi genişliğinin sekiz katına kadar izin verir; bu, puan cinsinden bir ölçüm değildir. Köşe sınırlamayı aşarsa, PowerPoint o köşede bir bevel birleşim kullanır. Daha büyük bir sınırlama, daha keskin noktalar sağlar. Bu ayar yalnızca miter birleşimlerini etkiler ve köşe iki limit içinde kaldığında değişiklik görünür bir etki yaratmaz.

Bu örnek, 20 puan genişliğinde kenarlıklı iki aynı, doldurulmamış üçgen oluşturur. Sol üçgen `2` sınırlaması, sağ üçgen ise `8` sınırını kullanır. Her üçgen 80 puan genişliğinde ve 160 puan yüksekliğinde olup, üst köşesinin miter‑uzunluk/çizgi‑genişlik oranı yaklaşık `4.12`'dir. Sonuç olarak, PowerPoint sol tepeyi biçimlendirir (bevel) ve sağ tepeyi korur.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint’te sonuç: solda **Miter limit 2**, sağda **miter limit 8**.

![PowerPoint’te miter limit 2 ile biçimlendirilmiş bir tepe ve miter limit 8 ile sivri bir tepe](miter-limits.png)

## **Degrade Doldurma**

Degrade doldurma, şekil boyunca renkleri karıştırır. Bu örnek, [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) kullanarak kırmızıdan mor renge 45 derece açıyla lineer bir degrade ile bir elips doldurur. [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) yöntemi, renk duraklarını 0 ve 1 konumlarına, yani degradenin başlangıç ve sonuna yerleştirir. Mevcut durakların temizlenmesi, yalnızca bu iki rengin kullanılmasını sağlar.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Degrade doldurulmuş elips](gradient-fill.png)

Eğer bir degrade, PowerPoint’teki görünümünden dışa aktarılan bir görüntüde farklı görünüyorsa, [Choose a Gradient Rendering Style](/slides/tr/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) bölümüne bakın. Sunumda saklanan degrade doldurmayı değiştirmeden bir render stilini seçebilirsiniz.

### **Lineer Degrade Açısını Ayarla**

[GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) kullanarak bir [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) doldurmanın yönünü kontrol edin. Açı derece cinsinden ölçülür ve saat yönünde artar: `0` soldan sağa, `90` üstten alta, `180` sağdan sola, `270` alttan üste gider. Kesirli açılar desteklenir. `[0, 360)` aralığının dışındaki sonlu açılar bir tam dönüşe normalize edilir; örneğin `-45` `315`, `360` ise `0` olur.

Bu örnek, `0`, `0.5` ve `1` konumlarında aynı kırmızı, yeşil ve mavi duraklara sahip altı dikdörtgen oluşturur. Ölçekleme devre dışı bırakılmıştır, böylece açı, dikdörtgenlerin oranlarından bağımsız olarak karşılaştırılabilir. Açılar soldan sağa sırasıyla ilk satırda `0`, `45` ve `90`, ikinci satırda ise `135`, `180` ve `270` olarak belirlenmiştir.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint’te sonuç:

![Üst satırda 0, 45 ve 90 derece, alt satırda 135, 180 ve 270 derece lineer degralar](linear-gradient-angles.png)

### **Şekil ile Lineer Degradeyi Ölçekle**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) bir [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) değeri alır. Şeklin oranları değiştiğinde geometrik degrade açısını korumak için açıkça `False`, degradeyi şeklin genişliği ve yüksekliğiyle ölçeklemek için `True` olarak ayarlayın. Ölçekleme etkinleştirildiğinde, kare olmayan bir şekilde görünür açı, atanmış açıdan farklı olabilir.

Aşağıdaki örnek, `45` derece açı ve açı karşılaştırmasında kullanılan aynı renk duraklarını kullanır. Sol sütun `False`, sağ sütun `True` kullanır. Her sütun, bir geniş dikdörtgenin üstünde yüksek bir dikdörtgen içerir. İkisi de aynı geniş boyutlarla başlar; ikinci dikdörtgenin genişlik ve yüksekliğini değiştirmek, degrade ayarlarını değiştirmeden doldurmanın yeniden boyutlandırmaya nasıl yanıt verdiğini gösterir.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPoint’te sonuç, solda ölçekleme devre dışı, sağda etkin:

![45 derecelik degradeye sahip geniş ve yüksek dikdörtgenler, solda LinearGradientScaled False, sağda True karşılaştırması](linear-gradient-scaling.png)

Ölçekleme devre dışı bırakıldığında, diagonal renk şeritleri her iki dikdörtgende aynı yönü korur. Ölçekleme etkinleştirildiğinde, şeritler şeklin oranlarıyla uzar. Bu, bir şablonun degreni farklı bir boyuta uyarlarken yeniden üretmeye yardımcı olur. Kare bir şekilde, ölçekleme etkinleştirmek bu `45` derece degrenin görünümünü değiştirmez.

Açı ve ölçekleme ayarları her ikisi de lineer degrader için geçerlidir. [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/) doldurmalarını kontrol etmezler.

### **Açıyı Degrade Yönüyle Birleştir**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/) sınıfından bir degrade stilini seçer; bu, sayısal bir açı yerine geçmez. Lineer bir degrade için köşe stilleri, renklerin dağıtıldığı alanı değiştirebilir ve [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) ile atanmış açıyı değiştirmez. Açılar veya ölçekleme karşılaştırılırken yönü aynı tutun.

Aşağıdaki örnek, aynı ayarları ters sırada uygular. İki dikdörtgen aynı görünüme sahiptir: yön atamasını açıdan önce veya sonra yapmak sonucu değiştirmez.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Desen Doldurma**

Desen doldurma, nokta, çizgi veya karo gibi iki renkli bir tasarım uygular. Bu örnek, [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) ile bir ızgara deseni seçer. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) açık gri arka planı, [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) ise sarı desen rengini sağlar.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Desen doldurmalı dikdörtgen](pattern-fill.png)

## **Resim Doldurma**

Resim doldurma, bir şekil içinde bir görüntü kullanır. Bu örnek yerel bir resim gerektirir ve [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) ile sunumun görüntü koleksiyonuna yükler. [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) i döşeme moduna ayarlamak, resmi dikdörtgen içinde tekrarlatır. Burada kullanılan kaynak resim aşağıda gösterilmiştir:

![Lotus resmi](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Resim doldurmalı şekil](picture-fill.png)

### **Resmi Doku Olarak Döşeme**

Bir resmi doku olarak döşemek ve döşeme davranışını özelleştirmek istiyorsanız, aşağıdaki [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) sınıfı yöntemlerini kullanabilirsiniz:

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Resim doldurma modunu ayarlar—`Tile` veya `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Döşemelerin şekil içinde hizalamasını belirler.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Döşemenin yatay, dikey veya her iki yönde çevrilip çevrilmeyeceğini kontrol eder.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Döşemenin şeklin orijinal noktasından (puan cinsinden) yatay kaymasını ayarlar.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Döşemenin şeklin orijinal noktasından (puan cinsinden) dikey kaymasını ayarlar.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Döşemenin yatay ölçeğini yüzde olarak tanımlar.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Döşemenin dikey ölçeğini yüzde olarak tanımlar.

Bu örnek, yerel bir resim gerektirir ve [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) i orijinal boyutunun %50'si kadar tekrarlamak için yapılandırır. −32 puanlık ofsetler, döşemeleri yatay ve dikey olarak kaydırır; alt‑sağ hizalama ve her iki yönde çevirme, tekrarlanan dokunun nasıl düzenleneceğini belirler.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Döşeme seçenekleri](tile-options.png)

## **Düz Renk Doldurma**

Düz doldurma, bir şekle tek ve tekdüze bir renk verir. Bu örnek, [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) i düz doldurma moduna ayarlar ve [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) ile sarı renk atar, ardından dikdörtgeni bir sunumda kaydeder.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Düz renk doldurmalı şekil](solid-color-fill.png)

### **Tema Referanslarını Koruyarak Renkleri Kopyala**

[ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) kullanarak bir renk tanımını, renk tipini, tema referansını ve dönüşümleriyle birlikte kopyalayabilirsiniz. Bu, doldurma renginin sunum temasını takip etmeye devam etmesi gereken şekiller arasında aktarılması gerektiğinde kullanışlıdır. Yöntem sadece rengi kopyalar; doldurma tipi, kenarlık veya diğer şekil biçimlendirmesini kopyalamaz. Hedefin doldurma tipini açıkça [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) ile ayarlayın.

Bu örnek, soldan sağa üç dikdörtgen oluşturur: kaynak, tema duyarlı bir kopya ve sabit RGB kopyası. Kaynak, ilk vurgu rengini referanslamak için [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) kullanır ve [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add) ile bir ton ekler. RGB kopyası, kaynağın etkili doldurma rengini kullanır, böylece üçü başlangıçta aynı görünür. [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) çağrısı sabit bir RGB değeri atar ve mevcut renk dönüşümlerini temizler.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Tema referansları yeni vurgu rengini izler; sabit RGB değeri bunu yapmaz.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tema değişikliğinden önce, üç doldurma eşleşir:

![Kaynak, copyFrom hedefi ve sabit RGB hedefi, aynı mavi doldurmalarla](color-copy-before.png)

Tema değişikliğinden sonra, kaynak ve tema duyarlı kopya yeni vurgu rengini izler ve tonlarını korur. Sabit RGB kopyası ise mavi kalır:

![Kaynak ve copyFrom hedefi turuncu doldurmayla, sabit RGB hedefi mavi kalır](color-copy-after.png)

Kopyalanan tanım, kaynağın bağımsızdır. Daha sonra kaynağın tema referansını değiştirmek, başka bir renk atamak ya da dönüşümlerini eklemek/çıkarmak hedefi etkilemez. Bir tema değişikliği hâlâ her iki şekli etkiler çünkü her biri bağımsız olarak aynı tema rengini referans alır.

PPTX'i kaydedip yeniden açmak, [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType) tarafından döndürülen kopyalanan renk tipini, tema referansını ve [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform) tarafından döndürülen dönüşüm koleksiyonunu korur; tanımı RGB'ye düzleştirmez.

Farklı tema bağlamları arasında, örneğin farklı vurgu paletlerine sahip sunumlar arasında kopyalama yaparken, kopyalanan referans hedefin temasına göre çözülür. Aynı referans ve dönüşümler, bu yüzden farklı bir görünür renk üretebilir. Tema renklerini yapılandırma hakkında daha fazla bilgi için [Presentation Theme](/slides/tr/php-java/presentation-theme/) bölümüne bakın.

## **Slayt Arka Planını Şekil Doldurması Olarak Kullan**

Bir şeklin slayt arka planıyla eşleşmesi gerektiğinde, örneğin bir şablonda, [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) kullanın. Herhangi bir açık doldurmayı kaldırmak için önce doldurma tipini [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) ile [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) olarak ayarlayın. Bu kombinasyonla şekil, stil doldurması yerine slayt arka planını kullanır. Bayrağın yalnızca etkinleştirilmesi mevcut bir açık doldurmayı kaldırmaz.

Bu, [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) farklıdır: arka plan doldurması, şeklin arkasındaki nesneleri slayt arka planının ilgili alanıyla kapatırken, no fill bu nesnelerin görünür kalmasını sağlar. Bir degrade, her şeklin içinde yeniden başlamaz, slaytla hizalı kalır.

Aşağıdaki örnek, slayt tarafından kalıtılan bir ana arka plan oluşturur ve üç dikdörtgenin arkasına magenta bir şerit yerleştirir. Sol dikdörtgen arka planı kullanır, orta dikdörtgen doldurması yoktur ve sağ dikdörtgen arka plan doldurmasından açık turuncu doldurmaya geçer.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Gradyanı ana slayttan devral.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Bu nesneyi önce ekleyin, böylece dikdörtgenlerin arkasında görünür.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Açık bir doldurma uygulamadan önce arka plan doldurmayı devre dışı bırak.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç, soldan sağa: **background fill**, **no fill**, ve **explicit fill**. Magenta şerit sol ve sağ dikdörtgenler tarafından gizlenir ancak orta dikdörtgen üzerinden görünür kalır.

![Magenta şeridin üzerinde arka plan doldurma, doldurma yok ve açık turuncu doldurma](background-fill.png)

Aynı davranış, doğrudan slaytta tanımlanan veya bir yerleşimden kalıtılan arka plan için de geçerlidir. Şekil, slaytın çözümlenmiş arka planını kullanır; örnek, slayt ve yerleşim arka planlarını tanımsız bırakır, böylece ana (master) sağlar.

## **Saydamlık Ayarla**

Düz bir doldurma için, rengin alfa bileşeni opaklığı kontrol eder: 0 tamamen şeffaf, 255 tamamen opaktır. Bu örnek, sarı bir dikdörtgen için alfa değerini 128 olarak kullanır; bu yaklaşık %50 şeffaflık verir ve altındaki dikdörtgenin görünür kalmasını sağlar. Renk, [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) aracılığıyla atanır.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Saydam şekil](shape-transparency.png)

## **Şekilleri Döndür**

[Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) kullanarak bir şekli slayt düzleminde döndürün. Açı derece cinsinden ölçülür; bu örnek, bir dikdörtgeni 5 derece saat yönünde döndürür ve sunumu kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Şekil döndürmesi](shape-rotation.png)

## **3B Kabartma Efektleri Ekle**

[Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) kullanarak bir şekle derinlik ve kabartılmış kenarlar verin. Bu örnek, turuncu kenarlıklı yeşil bir elips oluşturur, [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) i 4 puana ayarlar ve [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) aracılığıyla 6 puan genişlik ve yüksekliğe sahip dairesel bir üst kabartma uygular. Ön yüze bakış ortografik kamera ve üç noktalı aydınlatma, kabartmayı görünür kılar.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![3B kabartma efekti](3D-bevel-effect.png)

## **3B Döndürme Efektleri Ekle**

Bir şeklin 3B görünümü, kamera ayarlarıyla kontrol edilir. Bu örnek, [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) i enlem, boylam ve devrim açıları 40, 35 ve 20 derece olarak ayarlar. [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) ile izometrik bir kamera ve [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) ile dengeli bir aydınlatma seçer, ardından biçimlendirilmiş dikdörtgeni kaydeder.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![3B döndürme efekti](3D-rotation-effect.png)

## **Şekiller İçin Siyah-Beyaz Renderlamayı Kontrol Et**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) yöntemi, bir sunum siyah-beyaz modunda görüntülendiğinde veya işlendiğinde bireysel bir şeklin nasıl renderlanacağını belirtir. Tek başına siyah-beyaz görüntülemeyi etkinleştirmez ve normal renk modunda şeklin doldurmasını, çizgisini veya diğer biçimlendirmelerini değiştirmez.

[BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) sınıfından bir değer kullanarak istenen davranışı seçin. Örneğin, `Automatic` render uygulamasının dönüşümü seçmesine izin verir, `Gray` ve `LightGray` gri renk kullanır, `BlackWhite` sadece siyah ve beyazı, `Black` ve `White` tek bir rengi zorlar, `Color` normal renklendirmeyi korur ve `Hidden` şekli siyah-beyaz modunda görmezden gelir. `NotDefined` ise şekil düzeyinde bir mod atanmadığını ifade eder.

Bu örnek, turuncu bir dikdörtgen oluşturur ve [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) i gri olarak ayarlar. Kaydedilen şekil, normal renk gösteriminde turuncu doldurmasını korur ve siyah-beyaz görüntü ayarlarını dikkate alan uygulamalardan gri renklendirme talep eder:

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
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Normal renk modunda, dikdörtgen turuncu doldurmasını korur. Siyah-beyaz gösterim iş akışında, modu `Gray` olduğu için gri renklendirme kullanır. Bu, tam renkli bir slaytı korurken, baskı, ön izleme veya sunumun siyah-beyaz gösterim ayarlarını dikkate alan diğer iş akışları için farklı bir görünüm tanımlamanıza olanak sağlar.

## **Biçimlendirmeyi Sıfırla**

[Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) i kullanarak slayt yer tutucularının konum, boyut ve biçimlendirmesini, karşılık gelen düzen yer tutucularından geri yükleyin. Bu örnek, düzenle bağlantılı yer tutuculara sahip mevcut bir sunum gerektirir ve kaydetmeden önce her slaytı sıfırlar. Karşılık gelen düzen yer tutucusu olmayan şekiller sıfırlanmaz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Şekil biçimlendirmesi, nihai sunum dosya boyutunu etkiler mi?**

Renkler, çizgi stilleri ve efekt ayarları, gömülü görüntüler ve medya ile karşılaştırıldığında genellikle az veri ekler. Resim doldurmalar, görüntüler sunumda depolandığı için dosya boyutunu artırabilir.

**Bir slaytta aynı biçimlendirmeyi paylaşan şekilleri nasıl tespit edip gruplayabilirim?**

Her şeklin temel biçimlendirme özelliklerini—doldurma, çizgi ve efekt ayarlarını—karşılaştırın. Tüm karşılık gelen değerler eşleşiyorsa, stillerini aynı kabul edin ve bu şekilleri mantıksal olarak gruplayın; bu, sonraki stil yönetimini basitleştirir.

**Özel şekil stillerinin bir kümesini başka sunumlarda yeniden kullanmak için ayrı bir dosyada kaydedebilir miyim?**

Evet. İstenen stillere sahip örnek şekilleri bir şablon slayt paketi veya .POTX şablon dosyasında saklayın. Yeni bir sunum oluştururken şablonu açın, ihtiyacınız olan stilli şekilleri klonlayın ve gerektiği yerde biçimlendirmelerini yeniden uygulayın.