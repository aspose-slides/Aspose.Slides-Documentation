---
title: Sunum Slaytlarını PHP'de Görsellere Dönüştür
linktitle: Slayttan Görsele
type: docs
weight: 35
url: /tr/php-java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görsele
- slaytı görsel olarak kaydet
- slaytı PNG'ye
- slaytı JPEG'e
- slaytı bitmap'e
- slaytı TIFF'e
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları görsellere dönüştürün — hızlı, yüksek kaliteli renderleme ve net kod örnekleri."
---
## **Giriş**

Aspose.Slides for PHP via Java, PowerPoint ve OpenDocument sunum slaytlarını BMP, PNG, JPG (JPEG), GIF ve diğer çeşitli görüntü formatlarına kolayca dönüştürmenizi sağlar.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. Dönüştürme ayarlarını belirleyin ve dışa aktarmak istediğiniz slaytları aşağıdakileri kullanarak seçin:
    - [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfını, ya da
    - [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) sınıfını.
2. [getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metodunu çağırarak slayt görüntüsünü oluşturun.

Aspose.Slides for PHP via Java'da, bir [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) piksel verileriyle tanımlanan görsellerle çalışmanıza olanak tanıyan bir sınıftır. Bu sınıfı, görselleri geniş bir format yelpazesinde (BMP, JPG, PNG vb.) kaydetmek için kullanabilirsiniz.

## **Slaytları Bitmape Dönüştür ve Görüntüleri PNG Olarak Kaydet**

Bir slaytı bitmap nesnesine dönüştürüp uygulamanızda doğrudan kullanabilirsiniz. Alternatif olarak, slaytı bir bitmap'e dönüştürüp ardından görüntüyü JPEG ya da başka bir tercih edilen formatta kaydedebilirsiniz.

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

## **Özel Boyutlu Görsellerle Slaytları Dönüştür**

Belirli bir boyutta bir görüntü elde etmeniz gerekebilir. [getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) metodunun bir aşırı yüklemesini kullanarak, bir slaytı belirli boyutlarda (genişlik ve yükseklik) bir görüntüye dönüştürebilirsiniz.

Bu örnek kod, bunu nasıl yapacağınızı gösterir:

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

## **Notlar ve Yorumlar İçeren Slaytları Görsellere Dönüştür**

Bazı slaytlar not ve yorumlar içerebilir.

Aspose.Slides, sunum slaytlarını görüntülere dönüştürmeyi kontrol etmenizi sağlayan iki sınıf olan [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) ve [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) sunar. Her iki sınıf da `setSlidesLayoutOptions` metodunu içerir; bu yöntem, bir slaytı görüntüye dönüştürürken notların ve yorumların nasıl oluşturulacağını yapılandırmanıza olanak tanır.

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) sınıfıyla, sonuç görüntüde not ve yorumlar için tercih ettiğiniz konumu belirtebilirsiniz.

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

    // Renderleme seçeneklerini oluştur.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Sunumdaki ilk slaytı görüntüye dönüştür.
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

{{% alert title="Note" color="warning" %}} 
Herhangi bir slayt‑görüntü dönüşüm sürecinde, [setNotesPosition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metodu `BottomFull` uygulayamaz (notların konumunu belirlemek için) çünkü not metni çok büyük olabilir ve belirtilen görüntü boyutuna sığmayabilir.
{{% /alert %}} 

## **TIFF Seçeneklerini Kullanarak Slaytları Görsellere Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfı, boyut, çözünürlük, renk paleti ve daha fazlası gibi parametreleri belirlemenize izin vererek oluşan TIFF görüntüsü üzerinde daha fazla kontrol sağlar.

Bu kod, TIFF seçeneklerinin 300 DPI çözünürlükte ve 2160 × 2800 boyutunda siyah‑beyaz bir görüntü üretmek için kullanıldığı bir dönüştürme sürecini gösterir:

```php
// Bir sunum dosyası yükle.
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

{{% alert title="Note" color="warning" %}} 
Tiff desteği JDK 9 öncesi sürümlerde garanti edilmez.
{{% /alert %}} 

## **Tüm Slaytları Görsellere Dönüştür**

Aspose.Slides, bir sunumdaki tüm slaytları görüntülere dönüştürmenize olanak tanır; böylece tüm sunum bir dizi görüntüye çevrilir.

Bu örnek kod, bir sunumdaki tüm slaytları PHP'de görüntülere dönüştürmeyi gösterir:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Sunumu slayt slayt görüntülere dönüştür.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Gizli slaytları kontrol et (gizli slaytları renderlama).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Slaytı görüntüye dönüştür.
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

## **Renkli Emoji İşleme**

{{% alert title="Note" color="warning" %}} 
Sunum slaytlarını görüntülere dönüştürürken renkli emojileri doğru şekilde işlemek için, sunumda kullanılan emoji yazı tiplerinin dönüşümü gerçekleştiren sistemde yüklü ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emojiler çıktı görüntülerinde tek renkli görünebilir.
{{% /alert %}} 

## **SSS**

**Aspose.Slides slaytları animasyonlarla renderlamayı destekliyor mu?**

Hayır, `getImage` metodu slaytı yalnızca statik bir görüntü olarak kaydeder, animasyonları içermez.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet, gizli slaytlar da normal slaytlar gibi işlenebilir. İşlem döngüsünde dahil olduklarından emin olun.

**Görseller gölgeler ve efektler ile kaydedilebilir mi?**

Evet, Aspose.Slides slaytları görüntü olarak kaydederken gölgeler, saydamlık ve diğer grafik efektlerini renderlamayı destekler.