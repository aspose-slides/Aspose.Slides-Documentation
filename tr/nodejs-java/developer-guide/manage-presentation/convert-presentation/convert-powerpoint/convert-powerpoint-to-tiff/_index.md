---
title: JavaScript ile PowerPoint Sunumlarını TIFF'e Dönüştür
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
- sunumdan TIFF'e
- slayttan TIFF'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, JavaScript kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncılar genellikle görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın en yüksek görsel sadeliği korumasını sağlayabilirsiniz.

## **Sunumu TIFF'e Dönüştür**

Presentation sınıfının sağladığı [save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) metodunu kullanarak, bir PowerPoint sunumunun tamamını hızlı bir şekilde TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu JavaScript kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```js
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştür**

[setBwConversionMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) metodu, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) metodu `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu JavaScript kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```js
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

## **Sunumu Özel Boyutlu TIFF'e Dönüştür**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setImageSize) metodu, oluşan görüntünün boyutunu belirlemenize olanak tanır.

Bu JavaScript kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```js
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

    // Derinlik sıkıştırma türüne bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'sını ayarlayın.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarlayın.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu belirtilen boyutla TIFF olarak kaydedin.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfının [setPixelFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) metodunu kullanarak, oluşan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu JavaScript kodu, bir PowerPoint sunumunu özel piksel biçimli TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```js
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgede belirtildiği gibi):
        Format1bppIndexed - Piksel başına 1 bit, indeksli.
        Format4bppIndexed - Piksel başına 4 bit, indeksli.
        Format8bppIndexed - Piksel başına 8 bit, indeksli.
        Format24bppRgb    - Piksel başına 24 bit, RGB.
        Format32bppArgb   - Piksel başına 32 bit, ARGB.
    */

    /// Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsüne](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) göz atın.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenizi sağlar.

**Bir sunumu TIFF'e dönüştürürken slayt sayısına herhangi bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.