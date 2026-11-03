---
title: PHP'de Sunum Yer Tutucularını Yönet
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/php-java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- resim yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- istem metni
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile metin, resim, grafik ve içerik yer tutucularını nasıl inceleyeceğinizi ve düzenleyeceğinizi ve yer tutucu kalıtımını anlayacağınızı öğrenin."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için bir konumu ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, yer tutucu konumunu, boyutunu, biçimlendirmesini ve diğer ayarlarını bir yerleşim slaytından veya ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) yöntemiyle sunar. Bu yöntem, normal bir şekil için `null` dönen bir [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne amaçladığını belirlemek için [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) kullanın.

Şekil sınıfı, yer tutucu tipini öğrendikten sonra da önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucusu genellikle bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucusu bir [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) ile temsil edilebilir.
- Bir içerik yer tutucusu birçok içerik türü içerebilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) hem de çalışma zamanındaki şekil sınıfını kontrol edin.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanındaki sınıfını garanti etmez. Metin, resim, grafik, tablo veya medya‑özel üyelerine erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlayın**

Yer tutucular bir hiyerarşi oluşturur:

1. Bir ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana‑seviye yer tutucuları tanımlar.
2. Bir yerleşim slaytı, bir veya daha fazla normal slayt tarafından kullanılan düzeni tanımlar ve ana slayttan kalıtım alabilir.
3. Bir normal slayt, o slayt için yer tutucuları içerir ve yerleşiminden kalıtım alabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) çağırın. Bir slayt yer tutucusu genellikle yerleşim yer tutucusunu döndürür; bir yerleşim yer tutucusu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu yoksa yöntem `null` döndürür.

Aşağıdaki örnek, ilk slayttaki yer tutucuları listeler ve temel yer tutucularını rapor eder:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili yerleşim ya da ana slaytı düzenlemek, hâlâ bu ayarı devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve yalnızca aynı koordinatları kapladığı için kalıtım başlamaz.

## **Yer Tutucu Durumunu Kaldır**

Bir şablonu uyarlarken, mevcut bir nesneyi normal bir şekil olarak tutmak için [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) kullanın. Bunun [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) yöntemi `null` döner, ancak şekil slayt koleksiyonunda kalır. Buna karşılık, [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) şekli o koleksiyondan siler.

Aşağıdaki örnek, en az bir slaytı ve ilk slaytta boş olmayan bir metin yer tutucusu bulunan bir `template.pptx` gerektirir. Etkiyi görmek için, yerleşim ya da ana slayttan kalıtım alan bir yer tutucu kullanın. Örnek, aynı şeklin kalıp kaldığını kontrol eder, ardından şimdi normal bir şekil üzerine aynı yöntemi tekrar çağırır ve sonucu kaydeder.

{{% alert color="warning" title="Warning" %}}
Yer tutucu durumunu kaldırmak, kalıtılan görünüm ayarlarını otomatik olarak korumaz. Aşağıdaki örnek bu ayarları bilinçli olarak değiştirmeden bırakır, bu yüzden çıktı farklı görünebilir. Tamamen kalıtılan bir konum ve boyuta sahip bir şekil, çağrı sonrası sıfır koordinat ve boyuta sahip olabilir ve görünmez hâle gelse de koleksiyonda kalır.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Normal bir şekil üzerinde yöntemi çağırmak hiçbir etki yapmaz.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Eşleşen bir yer tutucu için üç kontrol de `true` yazdırır. Metin kalır, ancak kalıtılan konum, boyut, dönüş, yazı tipi, paragraf hizalaması, metin‑çerçeve kenar boşlukları, dikey yerleşim, dolgu ve çizgi ayarları, yer tutucu ilişkisi kaldırıldığında değişebilir. Örneğin, kalıtılan başlık biçimlendirmesi normal metin biçimlendirmesine geri dönebilir. Daha fazla yerleşim bilgisi için [Slayt Düzeni](/slides/tr/php-java/slide-layout/) sayfasına bakın.

İstenen görünümü korumak için, çağrıdan önce çözülmüş konum, boyut ve dönüşü yakalayın ve gerekli etkili biçimlendirme değerlerini ayrı değişkenlere kopyalayın. Bu değerleri [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), ve [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) aracılığıyla alın. Yalnızca etkili‑format nesnelerine güvenmeyin; metin‑biçimlendirme değerleri ilişki kaldırıldıktan sonra değişebilir. Yakalanan değerleri, yazı tipi ailesi, boyutu, stili, rengi, paragraf ayarları, metin‑çerçeve ayarları, dolgu ve çizgi gibi normal şekle açıkça uygulayın.

Kalıtılan şekil geometrisi de [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) ile açıkça atanabilir. Dikdörtgen bir metin yer tutucusu için bu, [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) atamayı gerektirir; yalnızca dolgu ve çizgiyi geri yüklemek görünür dikdörtgeni sağlamaz. Ek efektleri veya daha karmaşık biçimlendirmeleri olan şablonlarda bu ayarlar da ele alınmalıdır.

## **Yer Tutucudaki Metni Değiştir**

Başlık, ortalanmış‑başlık, alt‑başlık, gövde ve metin yer tutucuları normalde metin destekler. [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) yöntemini kullanın.

Bu örnek, ilk slayttaki ilk başlık yer tutucusunu günceller ve sonucu kaydeder:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) nesnesi olarak ele almayı önler. Ayrıca, kırılgan bir şekil indeksine güvenmek yerine yer tutucuyu amacına göre tanımlamayı sağlar.

## **Düzeni Üzerinde İpucu Metni Ayarla**

İpucu metni, boş bir yer tutucuda görüntülenen tasarım‑zamanı yönergesidir; örneğin *Başlık eklemek için tıklayın*. Bu metni normal bir slayttaki şekil koleksiyonundan almaya çalışmak yerine, yerleşim yer tutucusu üzerinde özelleştirin. Yerleşime, [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) aracılığıyla erişin ve [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) tarafından döndürülen koleksiyonu döngüye alın.

Aşağıdaki örnek, ilk slaytın kullandığı yerleşimde başlık ve alt‑başlık ipuçlarını değiştirir:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarında boş yer tutucular için tasarlanmıştır. Kullanıcı ya da program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucu değiştirmek, yerleşimi kullanan slaytlardaki mevcut metni değiştirmez.

## **Resim Yer Tutucusunu Güncelle**

İki durum ele alınmalıdır:

- Resim yer tutucusu zaten doldurulmuş ve bir [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) ile temsil ediliyorsa, resmi [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) ve [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) üzerinden değiştirin.
- Hâlâ boş bir yer tutucuysa, [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Bu iki durumu da destekleyen ve sunumu kaydeden örnek:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) bir ayarlayıcı sağlamaz. Rezerv edilmiş konumu korur ancak artık yer tutucu‑özel davranışı devralmaz. Yer tutucu ilişkisinin sürdürülmesi kritikse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından Aspose.Slides ile elde edilen [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) güncelleyin.

Resim şeffaflığı, kırpma ve diğer resim‑özel efektler için [Resim Çerçevelerini Yönet](/slides/tr/php-java/picture-frame/) bölümüne bakın. Bu işlemler resim çerçevesi veya resim doldurmasıyla ilgilidir, yer tutucu meta verileriyle değil.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucusu bir [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) ile temsil edilebilir. Bu örnek, hem yer tutucu tipine hem de çalışma zamanındaki sınıfa göre bir grafik bulur, başlığını değiştirir ve dosyayı kaydeder:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Genel bir içerik yer tutucusu genellikle [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) tipindedir. PowerPoint'te, grafik, tablo, diyagram, resim ve medya gibi çeşitli içerik türlerinin başlatıcısı olarak davranır. Doldurulduktan sonra, gerçekte ne içerdiğini öğrenmek için şekil sınıfını inceleyin. Özelleştirilmiş yerleşimler, ayrıca [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) veya [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) tiplerini ortaya koyabilir.

Aspose.Slides, bir boş [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) yer tutucusunu sadece [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) değiştirerek bir [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) haline dönüştürmez; tip sınıf üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programlı olarak doldurmak için, gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Eklenen grafik, yerel bir normal grafiktir. Yer tutucunun alanını kaplar ancak yerleşim yer tutucusundan kalıtım almaz. Kategorileri, serileri veya çalışma kitabı verilerini değiştirmek gerektiğinde ilgili [grafik yönetimi makalelerine](/slides/tr/php-java/powerpoint-charts/) başvurun.

## **Tam Örnek: Metin veya Görüntü İçeriğini Güncelle**

Aşağıdaki uçtan‑uca örnek bir şablonu açar, ilk slaytta bir başlık ya da resim yer tutucusu arar, yer tutucu ve şekil tiplerini kontrol eder, ilgili içeriği günceller ve çıktıyı kaydeder. Örnek, şekil indeksine güvenmeyi ve her yer tutucuyu aynı sınıf olarak ele almayı kasıtlı olarak önler.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Temel yer tutucu nedir?**

Temel yer tutucu, başka bir yer tutucunun kalıtım yaptığı yerleşim ya da ana slayttaki karşılık gelen şekildir. Onu elde etmek için [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) kullanın. Normal bir yerel şekil `null` döndürür çünkü yer tutucu hiyerarşisinin bir parçası değildir.

**Tüm slayt başlıklarını bir yerleşim yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir yerleşim üzerinden kalıtılan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum genelinde gerçek başlık metnini değiştirmek için slaytları döngüye alıp her başlık yer tutucusunu güncellemeniz gerekir.

**Tarih, slayt‑numarası, başlık ve alt‑bilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, yerleşim, ana, not veya dağıtım kapsamındaki başlık ve alt‑bilgi yöneticilerini kullanın. Ayrıntılı örnekler için [Sunum Başlık ve Alt Bilgi Yönetimi](/slides/tr/php-java/presentation-header-and-footer/) sayfasına bakın.