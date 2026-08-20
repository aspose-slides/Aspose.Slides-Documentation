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
- şekil düzen formatları
- şekil SVG olarak
- şekli SVG'ye
- şekli hizalama
- şekli çevirme
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile sunum şekillerini tanımlamayı, kopyalamayı, kaldırmayı, gizlemeyi, yeniden sıralamayı, dışa aktarmayı, hizalamayı ve çevirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bir slayd üzerindeki şekilleri sıralı bir [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) olarak temsil eder. Koleksiyon, şekilleri bulup değiştirdiğiniz yer olmasının yanı sıra, yığılma sıralarının kaynağıdır: `0` indeksi en arka şekildir, son indeks ise en ön şekildir.

Bu makale bu modeli izler. İlk olarak bir şekli güvenilir bir şekilde nasıl tanımlayacağınızı açıklar, ardından şekilleri kopyalama, kaldırma, gizleme ve yeniden sıralama yöntemlerini gösterir. Son bölümler, düzen düzeyinde biçimlendirme, SVG dışa aktarımı, hizalama ve çevirme ayarlarını kapsar. Her örnek bağımsızdır, bu yüzden iş akışınızın gerektirdiği işlemleri yalnızca kullanabilirsiniz.

## **Şekilleri Tanımlama ve Bulma**

Koleksiyon indeksleri bilinen bir dosya işlenirken kullanışlıdır, ancak sabit tanımlayıcılar değildir. Bir şekil eklemek, kaldırmak veya yeniden sıralamak indeksini değiştirebilir. Tanımlayıcıyı, sunumun nasıl oluşturulduğuna ve sürdürüldüğüne göre seçin:

- [Name](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getname/) geliştirici kontrolündeki şablonlar için yararlıdır ve PowerPoint'in Seçim Bölmesinde incelemesi kolaydır. İsimler düzenlenebilir ve benzersiz olması garanti değildir, bu yüzden koda bağlıysa bir adlandırma kuralı oluşturun.
- [AlternativeText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getalternativetext/) erişilebilirlik açıklaması ya da yazar tarafından sağlanan bir etiket zaten şekli tanımladığında kullanışlıdır. Kullanıcılar tarafından görülür, yerelleştirilebilir ya da erişilebilirlik için yeniden yazılabilir ve benzersiz olması garanti değildir. Anlamlı erişilebilirlik metnini sessizce bir veritabanı anahtarı olarak yeniden kullanmayın.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getofficeinteropshapeid/) salt‑okunur bir tanımlayıcıdır ve bir slayt içinde benzersizdir, PowerPoint interop tarafından kullanılan şekil kimliğine karşılık gelir. PowerPoint ile bütünleştirirken ya da bir şeklin ömrü boyunca kesin bir referansa ihtiyaç duyduğunuzda kullanın. Kopyalanmış veya yeniden oluşturulmuş bir şekil farklı bir şekildir ve kendi kimliğini alır.

İlgili [Shape::getUniqueId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getuniqueid/) metodu, sunum kapsamındaki bir tanımlayıcı döndürür, ancak bu tanımlayıcı eklentiler için tasarlanmıştır ve yeniden atanabilir. Kalıcı bir dış anahtar olarak değerlendirilmemelidir. Uzun vadeli kimlik hayati öneme sahipse, eşlemeyi uygulama verilerinde tutun ve beklenen şeklin hâlâ mevcut olduğunu doğrulayın.

Aşağıdaki örnek, isme göre tam karşılaştırma yapar ve slayt kapsamlı interop kimliğini raporlar. Şablon beklenen şekli içermediğinde, kod hatalı nesneyle devam etmek yerine bu sonucu raporlar.

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

Bir işlem belirli bir şekil türüne özgü olduğunda, tür‑spesifik üyeleri kullanmadan önce çalışma zamanındaki sınıfı kontrol edin. Bu örnek, adlandırılmış nesne bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ise yalnızca metni ve alternatif metni günceller.

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

## **Şekil Koleksiyonunu Değiştirme**

Ekle, kopyala, kaldır ve yeniden sırala yöntemleri koleksiyon üzerinde anında çalışır. Bir işlem şekillerin sayısını veya sırasını değiştirirse, o işlemden önce alınan indekslere hâlâ güvenmeyin.

### **Bir Şekli Kopyalama**

[ShapeCollection::addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addclone/) bağımsız bir kopya oluşturur ve hedef koleksiyona ekler. [ShapeCollection::insertClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/insertclone/) da bir kopya oluşturur ancak belirli bir z‑sırası indeksine yerleştirir. Koordinatları kabul eden aşırı yüklemeler, kopyayı boyutunu değiştirmeden taşır; genişlik ve yükseklik alan aşırı yüklemeler ise yeniden boyutlandırabilir.

Örnek, bir hedef slayt oluşturur, etiketli bir dikdörtgeni öne kopyalar ve ikinci bir kopyayı arka tarafa ekler. Her iki kopyada yapılan değişiklikler kaynak şekli etkilemez.

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

Kopyalama, şeklin içeriğini ve biçimlendirmesini, adı ve alternatif metni dahil olmak üzere kopyalar. Bu değerlerin benzersiz olması gerektiğinde kopyaya yeni mantıksal tanımlayıcılar atayın. Karmaşık şekillerin kullandığı kaynaklar sunum tarafından yönetilir, ancak bir kopya yeni bir koleksiyon öğesi ve yeni bir şekil kimliği olur.

### **Şekilleri Kaldırma**

[ShapeCollection::remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/remove/) koleksiyonundan belirli bir şekil nesnesini siler. İndeksli yineleme sırasında birden fazla eşleşme kaldırılırken, kalan indekslerin geçerli kalmasını sağlamak için sondan başlayarak dolaşın.

Bu örnek, belirli bir isme sahip tüm şekilleri kaldırır. Şekli sabit bir koleksiyon öğesi olarak değil, geçerli indekste okur ve şekli gereksiz yere dönüştürmez.

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

Kaldırma sonrası, şekil sayısı ve sonraki şekillerin indeksleri değişir. Etkilemeyen şekillere referanslar, kaydedilmiş indekslerden daha güvenilirdir. Ayrıca, kaldırılan nesneye referans verebilecek bağlayıcılar, animasyonlar ve diğer sunum özelliklerini göz önünde bulundurun; görünen bir şekli kaldırmak, slaydın görünümünden daha fazlasını değiştirebilir.

### **Bir Şekli Gizleme**

[Shape::setHidden](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/sethidden/) değerini `true` olarak ayarlamak, şekli koleksiyonda tutar ancak normal slayt gösterisinde görünmesini engeller. İndeksi, biçimlendirmesi ve içeriği koda hâlâ ulaşılabilir, bu yüzden gizleme, daha sonra geri getirilebilecek isteğe bağlı öğeler için uygundur.

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

Gizleme bir silme veya güvenlik değildir. Nesne hâlâ bir kullanıcı ya da kod tarafından bulunabilir ve gizlilikten çıkarılabilir ve sunum dosyasının bir parçası olarak kalır.

### **Z‑Sırasını Değiştirme**

Üst üste gelen şekiller, koleksiyon sırasına göre çizilir. [ShapeCollection::reorder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/reorder/) mevcut bir şekli kopyalamadan hedef indekse taşır. `0` indeksi arka, `size() - 1` indeksi ön demektir.

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

Dikdörtgen önce oluşturulur ve başlangıçta elipsin arkasında bulunur. Son indekse taşımak onu öne getirir. İlgili tüm şekiller eklenip kopyalandıktan sonra z‑sırasını sonlandırın, çünkü bu işlemler yeni koleksiyon öğeleri ekleyebilir veya ekleyebilir ve istenen yığını değiştirebilir.

## **Düzen Slaytlarındaki Şekilleri İnceleme**

Normal slaytlar, düzen slaytları ve ana slaytlar ayrı şekil koleksiyonlarına sahiptir. Bir düzen koleksiyonundaki şekil, normal bir slaytta benzer konumda bulunan şekil ile aynı nesne değildir. Bir düzenin sağladığı biçimlendirmeyi anlamak veya değiştirmek gerektiğinde düzen şekillerini inceleyin.

Aşağıdaki örnek, her bir düzen şeklinin [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getfillformat/) ve [LineFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getlineformat/) özelliklerini, tüm şekillerin `AutoShape` olduğu varsayımı olmadan okur.

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

Bir düzeni düzenlemek, onu kullanan birden fazla slaytı etkileyebilir. Bir düzen şekline değişiklik yapmadan önce, normal bir slaytın nesneyi devralıp devralmadığını veya yerel bir geçersiz kılma içerip içermediğini belirleyin ve o düzeni kullanan tüm slaytları test edin.

## **Bir Şekli SVG Olarak Dışa Aktarma**

[Shape::writeAsSvg](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/writeassvg/) bir şeklin render edilmiş içeriğini bir akıma yazar. Sonuç, şekli içerir, tüm slayt arka planını veya komşu şekilleri içermez.

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

Render işlemi sırasında sunumu açık tutun. Çıktı, şeklin biçimlendirmesine ve yazı tipleri, görüntüler gibi kaynaklara bağlıdır. Tüm kompozisyona ihtiyacınız varsa, tek bir şekil yerine slaytı dışa aktarın. Akımı çağıran sahiplenir ve kapatmalıdır.

## **Şekilleri Hizalama**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/alignshapes/) aşırı yüklemeleri, tüm şekilleri veya seçili koleksiyon indekslerini hizalar. [ShapesAlignmentType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapesalignmenttype/) kenarı, merkez hattı veya dağıtım modunu belirtir. `alignToSlide` değerini `true` yaparsanız slayt kenarlarını kullanır; `false` yaparsanız seçili şekilleri birbirine göre hizalar.

Bu örnek, üç şekli slaydın üst kenarına hizalar. Döndürülen şekil referansları, hizalama öncesinde hemen mevcut indekslerine dönüştürülür.

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

Hizalama, pozisyonları değiştirir, z‑sırasını değiştirmez. Göreceli hizalama genellikle en az iki şekil gerektirir, yatay veya dikey dağıtım ise aralığı tanımlamak için yeterli şekle ihtiyaç duyar. Metodu çağırmadan önce koleksiyonu değiştirirseniz, indeksleri yeniden hesaplayın.

## **Bir Şekli Çevirme**

[ShapeFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapeframe/) sınıfı konum, boyut, yatay ve dikey çevirme ayarları ve rotasyonu depolar. `getFlipH` ve `getFlipV` değerleri [NullableBool](https://reference.aspose.com/slides/tr/php-java/aspose.slides/nullablebool/) kullanır: `True` çevirme etkinleştirir, `False` devre dışı bırakır ve `NotDefined` belirlenmemiş/varsayılan durumu korur.

Aşağıdaki giriş sunumu, çevrilmemiş bir şekil içerir.

![Çevirme öncesi şekil](shape_to_be_flipped.png)

Bu örnek, diğer tüm çerçeve değerlerini korur ve yalnızca iki çevirme ayarını değiştirir. Bu, yeni bir [Frame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/setframe/) atamanın tüm çerçeveyi değiştirmesi nedeniyle önemlidir.

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

Kaydedilen şekil, konum, boyut ve rotasyonu korurken yatay ve dikey olarak yansıtılmıştır.

![Çevirme sonrası şekil](flipped_shape.png)

## **SSS**

**Koleksiyon indeksini bir şekil tanımlayıcısı olarak kullanmalı mıyım?**

Yalnızca koleksiyon, indeks kullanılmadan önce değişmeyecek kısa vadeli işlemler için. Oluşturulan şablonlar için doğrulanmış bir `Name` veya `AlternativeText` kuralını, slayt kapsamlı interop çalışmaları için ise `OfficeInteropShapeId` kullanmayı tercih edin.

**Bir şekli gizlemek, onu z‑sırasından kaldırır mı?**

Hayır. Gizli bir şekil aynı indekste koleksiyonda kalır. Bulunabilir, yeniden sıralanabilir, düzenlenebilir veya tekrar görünür hâle getirilebilir.

**Neden kopyalanmış bir şekil başka bir şeklin önünde göründü?**

`addClone`, kopyayı koleksiyonun sonuna ekler; bu, z‑sırasının önüdür. İlk indeksi seçmek için `insertClone` kullanın ya da tüm şekiller eklendikten sonra `reorder` yapın.