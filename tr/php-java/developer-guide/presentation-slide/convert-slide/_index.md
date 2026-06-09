---
title: Sunum Slaytlarını PHP'de Görüntülere Dönüştürme
linktitle: Slayttan Görüntüye
type: docs
weight: 35
url: /tr/php-java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan PNG
- slayttan JPEG
- slayttan bitmap
- slayttan TIFF
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PPT, PPTX ve ODP slaytlarını görüntülere dönüştürün — hızlı, yüksek kaliteli işleme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for PHP via Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğerleri dahil olmak üzere çeşitli görüntü biçimlerine kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. Dönüştürme ayarlarını belirleyin ve dışa aktarmak istediğiniz slaytları şu sınıfları kullanarak seçin:
    - The [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) class, or
    - The [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) class.
2. Slayt görüntüsünü, [getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) yöntemini çağırarak oluşturun.

Aspose.Slides for PHP via Java'da, [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) piksel verileriyle tanımlanan görüntülerle çalışmanıza olanak tanıyan bir sınıftır. Bu sınıfı, görüntüleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştürme ve Görüntüleri PNG Olarak Kaydetme**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bitmap'e dönüştürüp ardından görüntüyü JPEG veya tercih ettiğiniz başka bir formatta kaydedebilirsiniz.

Bu kod, bir sunumun ilk slaytını bitmap nesnesine dönüştürüp ardından PNG formatında kaydetmeyi gösterir:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı bitmap'e dönüştür.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Görüntüyü PNG formatında kaydet.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Özel Boyutlarda Slayt Görüntüleri Dönüştürme**

Belirli bir boyutta bir görüntü elde etmeniz gerekebilir. [getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) yönteminin bir aşırı yüklemesini kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) görüntüye dönüştürebilirsiniz.

Bu örnek kod, bu işlemi nasıl yapacağınızı gösterir:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Sunumdaki ilk slaytı belirtilen boyutta bitmap'e dönüştür.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Görüntüyü JPEG formatında kaydet.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Notlar ve Yorumlar İçeren Slaytları Görüntülere Dönüştürme**

Bazı slaytlar not ve yorum içerebilir.

Aspose.Slides, sunum slaytlarının görüntülere dönüştürülmesini kontrol etmenizi sağlayan iki sınıf olan [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) sunar. Her iki sınıf da `setSlidesLayoutOptions` metodunu içerir; bu metod, bir slaytı görüntüye dönüştürürken notların ve yorumların işlenmesini yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) sınıfı ile, ortaya çıkan görüntüde not ve yorumların istediğiniz konumunu belirtebilirsiniz.

Bu kod, not ve yorum içeren bir slaytı nasıl dönüştüreceğinizi gösterir:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Notların konumunu ayarla.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Yorumların konumunu ayarla.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Yorum alanının genişliğini ayarla.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Yorum alanının rengini ayarla.

    // Render seçeneklerini oluştur.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Sunumun ilk slaytını görüntüye dönüştür.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Görüntüyü GIF formatında kaydet.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Not" color="warning" %}} 

Herhangi bir slayt‑görüntü dönüştürme sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) yöntemi, bir notun metni çok büyük olabileceği ve belirtilen görüntü boyutuna sığmayabileceği için `BottomFull` (notların konumunu belirtmek amacıyla) uygulanamaz.

{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görüntülere Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfı, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenizi sağlayarak ortaya çıkan TIFF görüntüsü üzerinde daha fazla kontrol sunar.

Bu kod, TIFF seçeneklerinin 300 DPI çözünürlük ve 2160 × 2800 boyutunda bir siyah‑beyaz görüntü oluşturmak için kullanıldığı bir dönüştürme sürecini gösterir:

```php
// Bir sunum dosyasını yükle.
$presentation = new Presentation("sample.pptx");
try {
    // Sunumdan ilk slaytı al.
    $slide = $presentation->getSlides()->get_Item(0);

    // Çıktı TIFF görüntüsünün ayarlarını yapılandır.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Görüntü boyutunu ayarla.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Piksel formatını ayarla (siyah beyaz).
    $options->setDpiX(300);                                              // Yatay çözünürlüğü ayarla.
    $options->setDpiY(300);                                              // Dikey çözünürlüğü ayarla.
    
    // Slaytı belirtilen seçeneklerle görüntüye dönüştür.
    $image = $slide->getImage($options);
    try {
        // Görüntüyü TIFF formatında kaydet.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Not" color="warning" %}} 

Tiff desteği JDK 9'dan önceki sürümlerde garanti edilmez.

{{% /alert %}} 

## **Tüm Slaytları Görüntülere Dönüştürme**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; bu sayede bütün sunum bir dizi görüntüye çevrilir.

Bu örnek kod, bir sunumdaki tüm slaytları PHP'de görüntülere nasıl dönüştüreceğinizi gösterir:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere işle.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Gizli slaytları kontrol et (gizli slaytları renderleme).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Slaytı bir görüntüye dönüştür.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Görüntüyü JPEG formatında kaydet.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Aspose.Slides animasyonlu slaytların işlenmesini destekliyor mu?**

Hayır, `getImage` yöntemi slaytı yalnızca statik bir görüntü olarak kaydeder, animasyon içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar normal slaytlar gibi işlenebilir. İşlem döngüsünde yer aldıklarından emin olun.

**Görüntüler gölgeler ve efektler ile kaydedilebilir mi?**

Evet, Aspose.Slides, slaytları görüntü olarak kaydederken gölgeler, saydamlık ve diğer grafik efektlerinin işlenmesini destekler.