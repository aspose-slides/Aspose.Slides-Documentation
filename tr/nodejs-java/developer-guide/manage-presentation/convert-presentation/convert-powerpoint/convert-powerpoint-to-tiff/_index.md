---
title: PowerPoint Sunumlarını JavaScript ile TIFF'e Dönüştürme
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, JavaScript kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinen, yaygın kullanılan kayıpsız raster görüntü formatıdır. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncılar genellikle katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine sorunsuz bir şekilde dönüştürebilir, sunumlarınızın görsel sadakatini en üst seviyede tutabilirsiniz.

## **Sunumu TIFF'e Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanarak bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu JavaScript kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slaytı veya resmi siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirlemenizi sağlar. Bu ayar yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerlidir.

{{% alert color="info" title="Not" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) tüm TIFF görüntüsü için piksel dönüşüm algoritmasını seçen bir dışa aktarma seviyesindeki ayardır. Tek bir şeklin siyah-beyaz görüntü modunda nasıl görüneceğini tanımlamak için [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) yöntemini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.
{{% /alert %}}

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![Bir sunum slaydı](slide_black_and_white.png)

Bu JavaScript kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü ihtiyacınız varsa, [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) içinde bulunan yöntemlerle istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setImageSize) yöntemi, oluşturulan görüntünün boyutunu tanımlamanıza olanak tanır.

Bu JavaScript kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Sıkıştırma türünü ayarlayın.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Sıkıştırma türleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma olmadığını belirtir.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Renk derinliği, piksel formatı tarafından kontrol edilir (aşağıdaki örneğe bakın); CCITT3 ve CCITT4 her zaman piksel başına 1 bitten üretir.

    // Görüntü DPI'sını ayarlayın.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarlayın.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Belirtilen boyutla sunumu TIFF olarak kaydedin.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Sunumu Özel Görüntü Piksel Formatlı TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) yöntemi ile oluşturulan TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Bu JavaScript kodu, bir PowerPoint sunumunu özel piksel formatına sahip bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelere göre):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */

    /// Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="info" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsüne](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) göz atın.
{{% /alert %}}

## **SSS**

**Bireysel bir slaytı, tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı TIFF görüntüleri olarak dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı konusunda bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürüldüğünde korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.