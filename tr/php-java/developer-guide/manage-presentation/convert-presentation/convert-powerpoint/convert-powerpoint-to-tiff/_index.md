---
title: PowerPoint Sunumlarını PHP'de TIFF'e Dönüştürün
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
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin detaylı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları, görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için genellikle TIFF'i tercih eder.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

Using the [save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) method provided by the [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

Bu kod, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturun.
$presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

The method [setBwConversionMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#setBwConversionMode) in the [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [setCompressionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getCompressionType) method is set to `CCITT4` or `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode] bir dışa aktarma düzeyi ayarıdır ve tüm TIFF görüntüsü için bir piksel dönüşüm algoritması seçer. Siyah‑beyaz görüntüleme modu aktif olduğunda tek bir şeklin nasıl görüneceğini belirlemek için [Shape::setBlackWhiteMode] kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) bölümüne bakın.
{{% /alert %}}

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah‑beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

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

![Siyah‑beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştürme**

If you require a TIFF image with specific dimensions, you can set your desired values using methods available in [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/). For instance, the [setImageSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getImageSize) method allows you to define the size of the resulting image.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturun.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Sıkıştırma tipini ayarla.
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

    // Derinlik, sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'sını ayarla.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Görüntü boyutunu ayarla.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Sunumu belirtilen boyutta TIFF olarak kaydet.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştürme**

Using the [setPixelFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getPixelFormat) method from the [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

Bu kod, bir PowerPoint sunumunu özel piksel biçimli TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturun.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelendirmede belirtildiği gibi):
        Format1bppIndexed - Piksel başına 1 bit, indeksli.
        Format4bppIndexed - Piksel başına 4 bit, indeksli.
        Format8bppIndexed - Piksel başına 8 bit, indeksli.
        Format24bppRgb    - Piksel başına 24 bit, RGB.
        Format32bppArgb   - Piksel başına 32 bit, ARGB.
    */

    // Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose'un [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) adresindeki ücretsiz PowerPoint'ten Poster dönüştürücüsüne göz atın.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunu tamamen değil, tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı için bir limit var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde hiçbir kısıtlama getirmez. Herhangi bir boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle, animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.