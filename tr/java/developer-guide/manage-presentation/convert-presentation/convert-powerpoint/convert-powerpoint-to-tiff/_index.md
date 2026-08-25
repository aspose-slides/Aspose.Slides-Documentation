---
title: PowerPoint Sunumlarını Java'da TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/java/convert-powerpoint-to-tiff/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kalite TIFF görüntülerine nasıl kolayca dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalite ile grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncılar, görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için sıkça TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın en yüksek görsel doğruluğu korumasını sağlayabilirsiniz.

## **Sunumu TIFF'e Dönüştür**

Sunum sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanarak tüm bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu kod, bir PowerPoint sunumunun TIFF'e nasıl dönüştürüleceğini göstermektedir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını oluşturur.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydeder.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) tam TIFF görüntüsü için bir piksel dönüşüm algoritması seçen bir dışa aktarma seviyesindeki ayardır. Siyah-beyaz görüntüleme modu etkin olduğunda tek bir şeklin nasıl görünmesi gerektiğini tanımlamak için [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) yöntemini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/slides/tr/java/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.

{{% /alert %}}

Şöyle bir "sample.pptx" dosyamız olduğunu ve aşağıdaki slaytı içerdiğini varsayalım:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi göstermektedir:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştür**

Belirli boyutlarda bir TIFF görüntüsü gerekliyse, istediğiniz değerleri [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfında bulunan yöntemlerle ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) yöntemi oluşan görüntünün boyutunu tanımlamanıza olanak verir.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi göstermektedir:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını oluşturur.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma türünü ayarlar.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
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

    // Görüntü DPI'sını ayarlar.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarlar.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu belirtilen boyutta TIFF olarak kaydeder.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) yöntemini kullanarak, oluşan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel biçimli bir TIFF görüntüsüne nasıl dönüştüreceğinizi göstermektedir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturur.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat şu değerleri içerir (belgelerde belirtildiği gibi):
        Format1bppIndexed - Piksel başına 1 bit, indeksli.
        Format4bppIndexed - Piksel başına 4 bit, indeksli.
        Format8bppIndexed - Piksel başına 8 bit, indeksli.
        Format24bppRgb    - Piksel başına 24 bit, RGB.
        Format32bppArgb   - Piksel başına 32 bit, ARGB.
    */
    
    // Sunumu belirtilen piksel biçimiyle TIFF olarak kaydeder.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="info" %}}

Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsünü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) inceleyin.

{{% /alert %}}

## **SSS**

**Bireysel bir slaytı, tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısında bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Her boyutta sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.