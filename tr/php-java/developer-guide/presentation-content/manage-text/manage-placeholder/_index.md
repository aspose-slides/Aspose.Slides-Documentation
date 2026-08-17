---
title: PHP'de Sunum Yer Tutucularını Yönetme
linktitle: Yer Tutucuları Yönet
type: docs
weight: 10
url: /tr/php-java/manage-placeholder/
keywords:
- yer tutucu
- metin yer tutucu
- görsel yer tutucu
- grafik yer tutucu
- içerik yer tutucu
- ipucu metni
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile metin, görsel, grafik ve içerik yer tutucularını incelemeyi ve düzenlemeyi öğrenin ve yer tutucu kalıtımını anlayın."
---
## **Genel Bakış**

Yer tutucu, bir sunum şablonunda belirli bir içerik türü için konum ayıran bir şekildir. Yaygın örnekler başlık, gövde, resim, grafik ve genel amaçlı içerik yer tutucularıdır. Normal bir şekilden farklı olarak, bir yer tutucu konumunu, boyutunu, biçimini ve diğer ayarlarını bir düzen slaytından ya da ana slayttan devralabilir.

Aspose.Slides, yer tutucu bilgilerini [Shape::getPlaceholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getplaceholder/) yöntemiyle açığa çıkarır. Yöntem, normal bir şekil için `null` ya da bir [Placeholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholder/) nesnesi döndürür. Yer tutucunun ne içerdiğini belirlemek için [Placeholder::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholder/gettype/) yöntemini kullanın.

Yer tutucu tipini öğrendikten sonra şekil sınıfı hâlâ önemlidir:

- Boş bir metin, resim, grafik veya içerik yer tutucu genellikle bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ile temsil edilir.
- Dolu bir resim yer tutucu bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ile temsil edilebilir.
- Dolu bir grafik yer tutucu bir [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/) ile temsil edilebilir.
- Bir içerik yer tutucu çeşitli içerik türleri içerebilir. Her yer tutucunun bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olduğunu varsaymak yerine hem [Placeholder::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholder/gettype/) hem de çalışma zamanı şekil sınıfını kontrol edin.

{{% alert color="warning" title="Uyarı" %}}
[Placeholder::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholder/gettype/) bir yer tutucunun rolünü tanımlar; şeklin çalışma zamanı sınıfını garanti etmez. Metin, resim, grafik, tablo veya medya-özel üyelerine erişmeden önce her zaman bir tip kontrolü yapın.
{{% /alert %}}

## **Yer Tutucu Kalıtımını Anlamak**

Yer tutucular bir hiyerarşi oluşturur:

1. Ana slayt, yeniden kullanılabilir stilleri ve bazı durumlarda ana seviyesindeki yer tutucuları tanımlar.
2. Düzen slaytı, bir veya daha fazla normal slayt tarafından kullanılan yerleşimi tanımlar ve ana slayttan devralabilir.
3. Normal bir slayt, o slayt için yer tutucuları içerir ve düzeninden devralabilir.

Bu hiyerarşide bir seviye yukarı çıkmak için [Shape::getBasePlaceholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getbaseplaceholder/) yöntemini çağırın. Bir slayt yer tutucu genellikle düzen yer tutucusunu döndürür; bir düzen yer tutucu ise ana yer tutucusunu döndürebilir. Şeklin temel yer tutucusu olmadığında yöntem `null` döndürür.

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

Normal bir slaytta bir yer tutucuyu düzenlemek, o slayt için yerel bir geçersiz kılma oluşturur veya değiştirir. İlgili düzeni veya ana slaytı düzenlemek, bu ayarı hâlâ devralan tüm slaytları etkileyebilir. Yerel bir normal şeklin temel yer tutucusu yoktur ve yalnızca aynı koordinatları doldurması, kalıtıma başlamasını sağlamaz.

## **Yer Tutucudaki Metni Değiştirme**

Başlık, ortalanmış başlık, alt başlık, gövde ve metin yer tutucuları normalde metni destekler. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) olup olmadığını kontrol ettikten sonra [getTextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/gettextframe/) yöntemini kullanın.

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

Bu desen, resim, grafik, tablo veya medya yer tutucularını [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) nesneleri olarak ele almayı önler. Ayrıca kırılgan bir şekil indeksine güvenmek yerine yer tutucuyu amacına göre tanımlar.

## **Düzen Üzerinde İpucu Metni Ayarlama**

İpucu metni, boş bir yer tutucuda tasarım zamanında gösterilen talimattır, örneğin *Başlık eklemek için tıklayın*. Normal bir slaytın şekil koleksiyonundan ulaşmaya çalışmak yerine düzen yer tutucusunda özel bir ipucu metni ayarlayın. Düzeni [Slide::getLayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getLayoutSlide) yöntemiyle alın ve [BaseSlide::getShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getShapes) tarafından döndürülen koleksiyonu döngüyle gezinin.

Aşağıdaki örnek, ilk slaytın kullandığı düzen üzerindeki başlık ve alt başlık ipuçlarını değiştirir:

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

İpucu metni normal bir slayt içeriği değildir. PowerPoint gibi düzenleme uygulamalarındaki boş yer tutucular için tasarlanmıştır. Bir kullanıcı ya da program gerçek içerik sağladığında ipucu artık gösterilmez. Bir ipucu değiştirmek, düzeni kullanan slaytlardaki mevcut metni de değiştirmez.

## **Resim Yer Tutucusunu Güncelleme**

Ele alınacak iki durum vardır:

- Resim yer tutucu zaten doldurulmuş ve bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe/) ile temsil ediliyorsa, görüntüyü [PictureFillFormat::getPicture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/picturefillformat/getpicture/) ve [SlidesPicture::setImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidespicture/setimage/) ile değiştirin.
- Eğer hâlâ boş bir yer tutucuysa, [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addpictureframe/) ile yer tutucunun koordinatlarında bir resim çerçevesi ekleyin ve boş yer tutucuyu kaldırın.

Aşağıdaki örnek her iki durumu da destekler ve sunumu kaydeder:

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

Boş bir yer tutucu için oluşturulan değiştirme, yeni bir yer tutucu değil, yerel bir resim çerçevesidir; çünkü [Shape::getPlaceholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getplaceholder/) bir ayarlayıcı sağlamaz. Ayırılan konumu korur ancak artık yer tutucuya özgü davranışı devralmaz. Yer tutucu ilişkisinin korunması önemliyse, önce PowerPoint'te yer tutucuyu hazırlayıp doldurun, ardından sonucu Aspose.Slides ile güncelleyin.

Görsel şeffaflığı, kırpma ve diğer resim-özel etkiler için [Manage Picture Frames](/slides/tr/php-java/picture-frame/) sayfasına bakın. Bu işlemler yer tutucu meta verilerine değil, resim çerçevesine veya resim doldurmaya aittir.

## **Grafik ve İçerik Yer Tutucularıyla Çalışma**

Dolu bir grafik yer tutucu bir [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/) ile temsil edilebilir. Bu örnek, yer tutucu tipine ve çalışma zamanı sınıfına göre böyle bir grafik bulur, başlığını değiştirir ve dosyayı kaydeder:

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

Genel bir içerik yer tutucu genellikle [PlaceholderType::Object](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholdertype/) tipindedir. PowerPoint'te grafik, tablo, diyagram, resim ve medya gibi çeşitli içerik türlerini başlatan bir öğe gibi davranır. Doldurulduktan sonra, ne içerdiğini öğrenmek için gerçek şekil sınıfını inceleyin. Özelleştirilmiş düzenler ayrıca [PlaceholderType::Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholdertype/) veya [PlaceholderType::Diagram](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholdertype/) tiplerini ortaya çıkarabilir.

Aspose.Slides, yalnızca [Placeholder::getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/placeholder/gettype/) değiştirerek boş bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) yer tutucuyu bir [Chart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/) haline dönüştürmez; tip sınıf üzerinden değiştirilemez. Boş bir grafik veya içerik alanını programatik olarak doldurmak için gerekli nesneyi yer tutucunun koordinatlarına ekleyin ve ardından boş yer tutucuyu kaldırın. Aşağıdaki örnek bir grafik için bunu yapar:

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

Eklenen grafik, sıradan bir yerel grafiktir. Yer tutucunun alanını kaplar ancak düzen yer tutucusundan devralmaz. Kategorilerini, serilerini veya çalışma kitabı verilerini değiştirmek gerektiğinde özel [chart management articles](/slides/tr/php-java/powerpoint-charts/) sayfalarını kullanın.

## **Tam Örnek: Metin veya Görsel İçeriği Güncelleme**

Aşağıdaki uçtan uca örnek bir şablon açar, ilk slaytta bir başlık veya resim yer tutucusunu arar, yer tutucu ve şekil tiplerini kontrol eder, uygun içeriği günceller ve çıktıyı kaydeder. Örnek, bilinçli olarak bir şekil indeksini varsaymaktan veya her yer tutucuyu aynı sınıf olarak ele almaktan kaçınır:

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

## **SSS**

**Temel yer tutucu nedir?**

Temel yer tutucu, başka bir yer tutucunun devraldığı düzen ya da ana üzerindeki karşılık gelen şekildir. Onu almak için [Shape::getBasePlaceholder](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getbaseplaceholder/) yöntemini kullanın. Normal bir yerel şekil, yer tutucu hiyerarşisinin bir parçası olmadığından `null` döndürür.

**Tüm slayt başlıklarını bir düzen yer tutucusunu düzenleyerek değiştirebilir miyim?**

Bir düzen üzerinden devralınan biçimlendirmeyi veya ipucu metnini değiştirebilirsiniz, ancak mevcut başlık içeriği normal slaytlarda depolanır. Sunum boyunca gerçek başlık metnini değiştirmek için slaytlar üzerinde döngü yapın ve her başlık yer tutucusunu güncelleyin.

**Tarih, slayt numarası, başlık ve altbilgi yer tutucularını nasıl yönetirim?**

Uygun slayt, düzen, ana, not veya el ilanı kapsamında üstbilgi ve altbilgi yöneticilerini kullanın. Tam örnekler için [Manage Presentation Header and Footer](/slides/tr/php-java/presentation-header-and-footer/) sayfasına bakın.