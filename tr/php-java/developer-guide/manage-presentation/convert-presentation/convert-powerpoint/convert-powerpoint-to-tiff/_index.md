---
title: PowerPoint Sunumlarını PHP'de TIFF'e Dönüştürme
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
- sunumdan TIFF'e
- slayttan TIFF'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle birlikte öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncılar genellikle katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel sadakatini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

[Sunum](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı tarafından sağlanan [kaydet](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemini kullanarak, bir bütün PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

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

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

Renkli bir slaytı veya resmi siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenizi sağlayan [setBwConversionMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#setBwConversionMode) yöntemi, [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfındadır. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getCompressionType) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}

[TiffOptions::setBwConversionMode] dışa aktarma düzeyinde bir ayardır ve tam TIFF görüntüsü için bir piksel dönüşüm algoritması seçer. Siyah-beyaz görüntüleme modu etkin olduğunda bir şeklin nasıl görüneceğini tanımlamak için [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#setBlackWhiteMode) yöntemini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/slides/tr/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.

{{% /alert %}}

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

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

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getImageSize) yöntemi oluşan görüntünün boyutunu tanımlamanıza izin verir.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Sıkıştırma türünü ayarlayın.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Sıkıştırma türleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma olmadığını belirtir.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Derinlik, sıkıştırma türüne bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'ını ayarlayın.
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

## **Özel Piksel Biçimiyle TIFF'e Sunumu Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/tiffoptions/#getPixelFormat) yöntemini kullanarak, oluşan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel biçimli bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```php
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgede belirtildiği gibi):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */

    // Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="İpucu" color="info" %}}

Aspose'un [ÜCRETSİZ PowerPoint'den Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) adresine göz atın.

{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tümünü değil, tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Bir sunumu TIFF'e dönüştürürken slayt sayısında herhangi bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.