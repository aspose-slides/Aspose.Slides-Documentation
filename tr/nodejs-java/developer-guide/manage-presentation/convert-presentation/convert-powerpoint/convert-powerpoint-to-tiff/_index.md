---
title: PowerPoint Sunumlarını JavaScript'te TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'e
- sunumdan TIFF'e
- slayttan TIFF'e
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

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kalite ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine sorunsuz bir şekilde dönüştürebilir, sunumlarınızın en yüksek görsel sadakati korumasını sağlayabilirsiniz.

## **Sunumu TIFF'ye Dönüştür**

[Kaydet](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanan [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı sayesinde bir PowerPoint sunumunu hızlıca TIFF'ye dönüştürebilirsiniz. Ortaya çıkan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu JavaScript kodu, bir PowerPoint sunumunu TIFF'ye nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını başlat.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydet.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'ye Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slaytı veya resmi siyah-beyaz TIFF'ye dönüştürürken kullanılacak algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) tam TIFF görüntüsü için piksel dönüştürme algoritması seçen bir dışa aktarma seviyesindeki ayardır. Bireysel bir şeklin siyah‑beyaz görüntü modunda nasıl görüneceğini tanımlamak için [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/slides/tr/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.
{{% /alert %}}

Şöyle bir "sample.pptx" dosyamız olduğunu varsayalım ve aşağıdaki slaytı içersin:

![Bir sunum slaytı](slide_black_and_white.png)

Bu JavaScript kodu, renkli slaytı siyah‑beyaz TIFF'ye nasıl dönüştüreceğinizi gösterir:

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

## **Sunumu Özel Boyutlu TIFF'ye Dönüştür**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, istediğiniz değerleri [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) içinde bulunan yöntemlerle ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setImageSize) yöntemi, ortaya çıkan görüntünün boyutunu tanımlamanıza olanak verir.

Bu JavaScript kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını başlat.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Sıkıştırma türünü ayarla.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Sıkıştırma türleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma yapılmadığını belirtir.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Renk derinliği piksel formatı tarafından kontrol edilir (aşağıdaki örneğe bakın); CCITT3 ve CCITT4 her zaman piksel başına 1 bit üretir.

    // Görüntü DPI'sını ayarla.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarla.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu belirtilen boyutta TIFF olarak kaydet.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Sunumu Özel Görüntü Piksel Biçimi ile TIFF'ye Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) yöntemiyle ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu JavaScript kodu, bir PowerPoint sunumunu özel piksel biçimli bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını başlat.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelerde belirtildiği gibi):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */

    /// Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydet.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="info" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) sayfasına göz atın.
{{% /alert %}}

## **SSS**

**PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'ye dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'ye dönüştürürken slayt sayısı konusunda herhangi bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Her boyutta sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'ye dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.