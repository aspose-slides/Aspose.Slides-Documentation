---
title: PHP'de Sunum Şekillerini Yönetme
linktitle: Şekil Manipülasyonu
type: docs
weight: 40
url: /tr/php-java/shape-manipulations/
keywords:
- PowerPoint şekli
- sunum şekli
- slayttaki şekil
- şekil bulma
- şekil kopyalama
- şekil kaldırma
- şekil gizleme
- şekil sırasını değiştirme
- interop şekil kimliğini al
- şekil alternatif metni
- şekil ayar noktası
- önceden tanımlı şekil ayarı
- şekil geometrisi
- şekil düzen formatları
- Şekil SVG olarak
- Şekli SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunum şekillerini tanımlamayı, ayarlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bir slayttaki şekilleri sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) olarak temsil eder. Bu koleksiyon, şekilleri bulup değiştirdiğiniz yer olduğu gibi, yığma sırasının kaynağıdır: indeks `0` en arka şekildir, son indeks ise en ön şekildir.

Bu makale aynı modeli izler. Öncelikle bir şeklin güvenilir şekilde nasıl tanımlanacağını ve önceden ayarlanmış şekil ayar noktalarının nasıl değiştirileceğini açıklar, ardından şekilleri kopyalama, silme, gizleme ve yeniden sıralama gösterilir. Son bölümler, düzen seviyesindeki biçimlendirme, SVG dışa aktarma, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, böylece iş akışınızın gerektirdiği işlemleri tek başına kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indisleri, bilinen bir dosya işlenirken kullanışlıdır, ancak stabil tanımlayıcılar değildir. Bir şeklin eklenmesi, kaldırılması veya yeniden sıralanması indeksini değiştirebilir. Sunumun nasıl oluşturulup sürdürüldüğüne göre bir tanımlayıcı seçin:

- [Name](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getname/) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesi'nde incelemesi kolaydır. İsimler düzenlenebilir ve benzersiz olması garanti değildir; kod bu isimlere bağlıysa bir adlandırma kuralları belirleyin.
- [AlternativeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getalternativetext/) erişilebilirlik açıklaması ya da yazarın eklediği bir etiket zaten şekli tanımlıyorsa kullanışlıdır. Kullanıcılara görünür, yerelleştirilebilir ya da erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti değildir. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getofficeinteropshapeid/) bir slayt içinde benzersiz, salt okunur bir tanımlayıcıdır ve PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleşirken ya da bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanan ya da yeniden oluşturulan bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [Shape::getUniqueId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getuniqueid/) yöntemi sunum kapsamlı bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak ele alınmamalıdır. Uzun vadeli kimlik önem taşıyorsa, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, kesin bir karşılaştırma ile isimle arama yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod yanlış nesneyle devam etmek yerine bu sonucu raporlar.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Bir işlem bir şekil tipine özgü olduğunda, tip‑spesifik üyeleri kullanmadan önce çalışma zaman sınıfını kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ise yalnızca metin ve alternatif metni günceller.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Önceden Tanımlı Şekil Ayarlarını Tanımlama ve Değiştirme**

Önceden tanımlı geometri şekilleri, köşe boyutu, ok oranları veya yay açıları gibi özellikleri kontrol eden ayarlama noktaları sunabilir. Bu noktalara salt okunur [GeometryShape::getAdjustments](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/#getAdjustments) koleksiyonu üzerinden erişin. Koleksiyon şekil tarafından sağlanır, ancak her [AdjustValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/) değiştirilebilir bir değer içerir.

Sadece sabit bir koleksiyon indeksine güvenmeyin. Ayarlamaları yineleyin ve salt okunur [AdjustValue::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/#getType) yöntemini inceleyin; bu yöntemin döndürdüğü [ShapeAdjustmentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeadjustmenttype/) değeri ayarlamanın neyi kontrol ettiğini tanımlar. Salt okunur [AdjustValue::getName](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/getname/) yöntemi ek tanımlama bilgisi sağlar ve aynı anlamsal tipe sahip birden fazla ayarlama içeren önceden tanımlı şekillerde özellikle kullanışlıdır.

Ayarlamanın anlamına uyan değer yöntemini kullanın:

| Ayarlama tipi | Amaç | Değiştirilecek değer |
|---|---|---|
| `CornerSize` | Yuvarlatılmış köşelerin boyutu | [setRawValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Ok kuyruğunun kalınlığı | `setRawValue` |
| `ArrowheadLength` | Ok başının uzunluğu | `setRawValue` |
| `ArrowheadWidth` | Ok başının genişliği | `setRawValue` |
| `StartAngle` | Dilimin ya da yayının başlangıç açısı | [setAngleValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Dilimin ya da yayının bitiş açısı | `setAngleValue` |

`getType` ve `getName` sadece salt okunur bilgi döndürür. `getRawValue` ve `setRawValue` önceden tanımlı şeklin yerel geometri biriminde bir tamsayıyla çalışır, `getAngleValue` ve `setAngleValue` ise derece cinsinden açıyla çalışır. Ayarlamaların sayısı, sırası, anlamı ve geçerli aralığı, önceden tanımlı [GeometryShape::getShapeType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/geometryshape/#getShapeType) değerine bağlıdır. Bir önceden tanımlı için geçerli bir değer, başka bir tanım için geçersiz ya da farklı bir etkiye sahip olabilir.

`getType` `ShapeAdjustmentType::Custom` döndürdüğünde API standart bir anlamsal anlamı tanımaz. `getName`, önceden tanımlı tip ve mevcut değeri inceleyin; beklenen anlam ve aralık bilinmedikçe ayarlamayı değiştirmeyin. Tanınan tipler için bile aynı tip birden fazla kez ortaya çıkıyorsa, değer seçmeden önce bunu kontrol edin. Bağlayıcı bükülme ayarlamalarıyla ilgili örnek [Connector](/slides/tr/php-java/connector/) makalesinde gösterilmiştir.

Aşağıdaki tam örnek, üç önceden tanımlı şeklin varsayılan ve değiştirilmiş sürümlerini oluşturur. Her ayarlamayı yineleyerek adını ve tipini raporlar, `setRawValue` ile boyutla ilgili değerleri, `setAngleValue` ile açıları değiştirir ve sonucu kaydeder. Sol sütun varsayılan geometrileri tutar; sağ sütun ise ayarlanmış yuvarlatılmış dikdörtgen, dört yönlü ok ve dilimi gösterir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Varsayılan ve ayarlanmış şekil sütunları için başlık ekleyin.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Değiştirmeden önce anlamsal tipi kontrol etmek, kodun niyetini açıkça belirtir ve belirli bir koleksiyon indeksinin farklı önceden tanımlı şekillerde aynı anlama sahip olduğunu varsaymayı önler.

## **Şekil Koleksiyonunu Değiştirme**

Ekleme, kopyalama, silme ve yeniden sıralama yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekil sayısını ya da sırasını değiştiriyorsa, o işlemden önce yakalanan indekslere güvenerek ilerlemeyin.

### **Bir Şekli Kopyalama**

[ShapeCollection::addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [ShapeCollection::insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/insertclone/) da bir kopya oluşturur ancak belirli bir z‑order indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler kopyayı boyutunu değiştirmeden taşırken, genişlik ve yükseklik alanları yeniden boyutlandırabilir.

Örnek bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka plana ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adını ve alternatif metnini de dahil ederek kopyalar. Bu değerlerin benzersiz olması gerekiyorsa kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak kopya yeni bir koleksiyon öğesi olarak yeni bir şekil kimliği alır.

### **Şekilleri Kaldırma**

[ShapeCollection::remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/remove/) belirli bir şekil nesnesini koleksiyonundan siler. İndeksli bir döngüde birden fazla eşleşmeyi kaldırırken, her kalan indeksin geçerli kalması için sondan başlayarak geçin.

Bu örnek, belirli bir isimle işaretlenmiş her şekli kaldırır. Sabit bir koleksiyon öğesi yerine mevcut indeksteki şekli okur ve şekli gereksiz yere cast etmez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaldırma işleminden sonra şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilenmemiş şekillere yapılan referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca kaldırılan nesneye referans veren bağlayıcılar, animasyonlar ve diğer sunum özelliklerini de göz önünde bulundurun; görünür bir şekli kaldırmak sadece slayt görünümünü değil, ilişkili diğer öğeleri de etkileyebilir.

### **Bir Şekli Gizleme**

[Shape::setHidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/sethidden/) değerini `true` yaparak şekil koleksiyonda kalır ancak normal slayt gösterisinde görünmez. İndeksi, biçimlendirmesi ve içeriği kod için hâlâ kullanılabilir, bu yüzden gizleme, daha sonra geri getirilebilecek opsiyonel öğeler için uygundur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gizleme silme ya da güvenlik değildir. Nesne hâlâ keşfedilebilir ve bir kullanıcı ya da kod tarafından tekrar görünür hâle getirilebilir; ayrıca sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller koleksiyon sırasına göre boyanır. [ShapeCollection::reorder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/reorder/) mevcut bir şekli yeni bir kopya oluşturmadan hedef indeksine taşır. İndeks `0` arka, `size() - 1` ön olarak kabul edilir.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dikdörtgen ilk oluşturulduğunda elipsin arkasında yer alır. Onu son indekse taşıdığınızda ön tarafta görünür. Tüm ilgili şekiller eklenip kopyalandıktan sonra z‑sırasını sonlandırın; çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slaytta aynı konumda bulunan şekil ile aynı nesne değildir. Düzen tarafından sağlanan biçimlendirmeyi anlamak ya da değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getfillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getlineformat/) özelliklerini, her şeklin bir `AutoShape` olup olmadığını varsaymadan okur.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Bir düzenin düzenlenmesi, onu kullanan birden çok slaytı etkileyebilir. Bir düzen şekli değiştirmeden önce, normal bir slayt nesneyi devralıyor mu yoksa yerel bir geçersiz kılma içeriyor mu belirleyin ve o düzeni kullanan her slaytı test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[Shape::writeAsSvg](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) bir şeklin render edilmiş içeriğini bir akışa yazar. Sonuç, şekli içerir; tüm slayt arka planını ya da komşu şekilleri içermez.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Render ederken sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve fontlar, görseller gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, bireysel bir şekil yerine slaytı dışa aktarın. Akışı çağıran tarafın sorumluluğudur ve kapatılması gerekir.

## **Şekilleri Hizalama**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/alignshapes/) aşırı yüklemeleri, ya tüm şekilleri ya da seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapesalignmenttype/) kenar, merkez çizgi ya da dağıtım kipini belirtir. `alignToSlide` değerini `true` yaparak slayt kenarlarını, `false` yaparak seçili şekilleri birbirlerine göre hizalayabilirsiniz.

Bu örnek üç şekli slaytın üst kenarına hizalar. Döndürülen şekil referansları, hizalamadan hemen önce geçerli indekslerine dönüştürülür.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hizalama konumları değiştirir, z‑sırayı etkilemez. Göreceli hizalama genellikle en az iki şekil gerektirirken, yatay ya da dikey dağıtım yeterli sayıda şekil olmadan boşluk tanımlayamaz. Metodu çağırmadan önce koleksiyonu değiştirdiyseniz indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ile döndürmeyi depolar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/php-java/aspose.slides/nullablebool/) kullanır: `True` çevirme etkin, `False` devre dışı, `NotDefined` belirtilmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu bir çevirilmemiş şekil içerir.

![The shape before flipping](shape_to_be_flipped.png)

Örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu önemlidir çünkü yeni bir [Frame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setframe/) atamak çerçevenin tamamını değiştirir.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaydedilen şekil, konumu, boyutu ve döndürmesi korunarak yatay ve dikey olarak ayna yansıtılır.

![The shape after flipping](flipped_shape.png)

## **SSS**

**Bir koleksiyon indeksi şekil tanımlayıcısı olarak kullanılmalı mı?**

Sadece koleksiyon işlem sırasında değişmeyecek kısa vadeli işlemler için kullanılabilir. Oluşturulmuş şablonlar için doğrulanmış bir `Name` ya da `AlternativeText` konvansiyonu, slayt kapsamlı interop işleri için `OfficeInteropShapeId` tercih edilmelidir.

**Bir şekli gizlemek, onu z‑sırasından çıkartır mı?**

Hayır. Gizli bir şekil aynı indeksde koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir ya da tekrar görünür hâle getirilebilir.

**Kopyalanan bir şekil başka bir şeklin önünde neden göründü?**

`addClone` kopyayı koleksiyonun sonuna ekler; bu z‑sırasının ön kısmıdır. İlk indeksi seçmek için `insertClone` kullanın ya da tüm şekiller eklendikten sonra `reorder` ile konumlandırın.

**Önceden tanımlı bir şekil ayarını tanımlamak için sabit bir indeks kullanabilir miyim?**

Yalnızca kesin önceden tanımlı ve koleksiyon düzeni doğrulandıktan sonra. `GeometryShape::getAdjustments` içinde yineleyerek `AdjustValue::getType` kontrol etmeyi tercih edin; aynı anlamsal tip birden çok kez ortaya çıkıyorsa ek bilgi için `AdjustValue::getName` kullanın.