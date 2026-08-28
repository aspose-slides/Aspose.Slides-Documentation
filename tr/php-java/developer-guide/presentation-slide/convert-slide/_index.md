---
title: "PHP'de Sunum Slaytlarını Görüntülere Dönüştürme"
linktitle: "Slayttan Görüntüye"
type: docs
weight: 35
url: /tr/php-java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slaytı görüntüye
- slaytı görüntü olarak kaydet
- slaytı EMF'ye
- slaytı PNG'ye
- slaytı JPEG'e
- slaytı bitmap'e
- slaytı TIFF'e
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PPT, PPTX ve ODP sunumlarından slaytları PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına PHP ile Aspose.Slides kullanarak dönüştürün."
---
## **Giriş**

Aspose.Slides for PHP via Java, PowerPoint ve OpenDocument sunumlarından tek tek slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatlarında oluşturabilir.

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. Sunumu [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı ile yükleyin.
2. Render (oluştur) etmek istediğiniz slaytı seçin.
3. Gerekirse render ayarlarını [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfı ile yapılandırın.
4. [Slide::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metodunu çağırın. Bu metod bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) nesnesi döndürür.
5. [IImage::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/#save) metodunu çağırın ve çıktı formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/) değeri ile belirtin.

## **Bir Slaytı PNG Görüntüsü Olarak Dönüştürün**

En basit dönüşüm, varsayılan render ayarlarını kullanır. Oluşan [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) nesnesi bellekte işlenebilir veya bir dosyaya kaydedilebilir.

Aşağıdaki PHP örneği ilk slaytı render eder ve PNG görüntüsü olarak kaydeder:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Özel Boyutlarla Slaytları Görüntülere Dönüştürün**

[Slide::getImage] aşırı yüklemesini kullanın; bu, tam piksel boyutlarıyla bir slaytı render etmek için bir [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) değerini kabul eder.

Aşağıdaki örnek 1820 × 1040 JPEG görüntüsü oluşturur:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Notlar ve Yorumlarla Slaytları Görüntülere Dönüştürün**

Varsayılan olarak, slayt görüntüleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metoduna geçirin.

Aşağıdaki örnek, kesilmiş notları slaytın altında ve yorumları sağında konumlandırır:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Uyarı" color="warning" %}}
Slayt-görüntü dönüşümü için, [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metoduna [BottomFull](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notespositions/) geçirmeyin. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notespositions/) kullanın.
{{% /alert %}}

## **TIFF Seçenekleri Kullanarak Slaytları Görüntülere Dönüştürün**

[TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfı, render edilen TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek, ilk slaytı 2160 × 2880 TIFF görüntüsü olarak 300 DPI'da render eder:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Uyarı" color="warning" %}}
TIFF desteği, JDK 9'dan önceki Java sürümlerinde garanti edilmez.
{{% /alert %}}

## **Tüm Slaytları Görüntülere Dönüştürün**

Tüm sunumu bir dizi görüntüye dönüştürmek için slayt koleksiyonunda döngü yapın. Gizli slaytlar, açıkça atlamadığınız sürece dahil edilir.

Aşağıdaki örnek, her slaytı yatay ve dikey ölçek faktörleri 2 olan bir JPEG görüntüsü olarak render eder:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gelişmiş Metafile Çıktısı Oluşturun**

Enhanced Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafilleri destekleyen diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde kullanışlıdır. Piksel tabanlı bir görüntünün aksine, EMF keskinlik kaybı olmadan ölçeklenebilen vektör çizim işlemlerini koruyabilir. Ancak EMF, öncelikle Windows metafili desteği olan uygulamalar için bir uyumluluk biçimidir, evrensel bir değişim biçimi değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içeriği, vektör metafili kapsayıcısı içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Bir Slaytı EMF Olarak Dışa Aktarın**

[Slide::writeAsEmf](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#writeAsEmf) metodu, bir slaytı EMF formatında hedef bir akıma yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve bir EMF dosya akışına yazar:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Çağıran, [Slide::writeAsEmf](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#writeAsEmf)’e geçirilen akımın sahibidir ve yukarıda gösterildiği gibi onu kapatmakla sorumludur.

### **Bir SVG Görüntüsünü EMF'ye Dönüştürün ve Sunuma Ekleyin**

SVG içeriğini EMF'ye dönüştürmek için [SvgImage::writeAsEmf](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/#writeAsEmf) kullanın. Ortaya çıkan baytlar, [ImageCollection::addImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imagecollection/#addImage) ile sunuma eklenebilir ve bir slayta [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addPictureFrame) ile yerleştirilebilir.

Aşağıdaki örnek, SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/) oluşturur, bunu bellek içi bir EMF'ye dönüştürür, metafili ilk slayta ekler ve sunumu kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgimage/#writeAsEmf), hedef akımın sahipliğini almaz. Bir [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html), tüm oluşturulan verileri bellekte saklar, bu nedenle `toByteArray` çağrılmadan önce konum sıfırlamaya gerek yoktur. Döndürülen bayt dizisi, akım kapatıldıktan sonra da geçerli kalır.

EMF üretimi, seçilen Aspose.Slides for PHP via Java ve JDK yapılandırması tarafından desteklenen işletim sistemlerinde mevcuttur, ancak yazı tipleri veya grafik bağımlılıkları mevcut değilse platformlar arasında render farkları olabilir. Kaynak içerikte kullanılan yazı tiplerini yükleyin veya uygun değişiklikleri yapılandırın, Aspose.Slides for PHP via Java için [platform gereksinimlerini](/slides/tr/php-java/system-requirements/) izleyin ve sonucu hedef EMF tüketen uygulamada doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafillerinin görüntülenmesi ve düzenlenmesi konusunda sınırlı veya tutarsız destek sunar.

## **Renkli Emoji Render'ı**

{{% alert title="Not" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru şekilde render etmek için, sunumda kullanılan emoji yazı tiplerinin dönüşümü yapan sistemde yüklü ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıkış görüntülerinde tek renkli (monokrom) görünür.
{{% /alert %}}

## **SSS**

**Aspose.Slides animasyonlu slaytların render edilmesini destekliyor mu?**

Hayır. [Slide::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metodu slaytın statik bir görüntüsünü render eder ve animasyonları dışa aktarmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar normal slaytlar gibi render edilebilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Gölge ve diğer efektler slayt görüntülerinde korunur mu?**

Evet. Aspose.Slides, slayt görüntülerinde gölgeler, şeffaflık ve diğer desteklenen grafik efektlerini render eder.