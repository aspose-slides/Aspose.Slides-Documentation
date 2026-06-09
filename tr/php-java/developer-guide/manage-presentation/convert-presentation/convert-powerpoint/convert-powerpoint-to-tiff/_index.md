---
title: PHP'de PowerPoint Sunumlarını TIFF'e Dönüştürme
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'e
- sunumu TIFF'e
- slaytı TIFF'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e aktar
- PPTX'i TIFF'e aktar
- PHP
- Aspose.Slides
description: "PHP için Java aracılığıyla Aspose.Slides kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kaliteyi ve grafiklerin ayrıntılı korunmasını sağlar. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle TIFF'i katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Bir Sunumu TIFF'e Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemini kullanarak bir PowerPoint sunumunun tamamını hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu kod, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Bir Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#setBwConversionMode) yöntemi, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getCompressionType) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında uygulanacağını unutmayın.

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Özel Boyutlu TIFF'e Sunumu Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsüne ihtiyacınız varsa, [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) içinde bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getImageSize) yöntemi, ortaya çıkan görüntünün boyutunu tanımlamanıza olanak verir.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Sıkıştırma tipini ayarlayın.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Sıkıştırma tipleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma uygulanmadığını belirtir.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Derinlik sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'sını ayarlayın.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Görüntü boyutunu ayarlayın.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Belirtilen boyutla sunumu TIFF olarak kaydedin.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Özel Görüntü Piksel Formatlı TIFF'e Sunumu Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getPixelFormat) yöntemini kullanarak, ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel formatlı bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelerde belirtildiği gibi):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */

    // Belirtilen görüntü boyutuyla sunumu TIFF olarak kaydedin.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose'in [ÜCRETSİZ PowerPoint'ten Afiş dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online)'na göz atın.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısında bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF sabit bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.