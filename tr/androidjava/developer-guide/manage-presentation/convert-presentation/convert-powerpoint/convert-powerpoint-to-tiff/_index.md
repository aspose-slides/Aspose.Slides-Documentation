---
title: Android'de PowerPoint Sunumlarını TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/androidjava/convert-powerpoint-to-tiff/
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
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak, PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, Java kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**), olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinen, yaygın olarak kullanılan kayıpsız raster görüntü formatıdır. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle TIFF'i katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştür**

[save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu sağlayan [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını kullanarak bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu kod, bir PowerPoint sunumunu TIFF'e dönüştürmeyi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenize olanak tanır. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) tüm TIFF görüntüsü için bir piksel dönüşüm algoritması seçen dışa aktarım düzeyi bir ayardır. Tek bir şeklin siyah‑beyaz görüntü modunda nasıl görüneceğini belirlemek için [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) yöntemini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/slides/tr/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) bölümüne bakın.
{{% /alert %}}

Diyelim ki aşağıdaki slaytı içeren bir **sample.pptx** dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli bir slaytı siyah‑beyaz TIFF'e dönüştürmeyi gösterir:

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

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) yöntemi, elde edilecek görüntünün boyutunu tanımlamanızı sağlar.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine dönüştürmeyi gösterir:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma tipini ayarlayın.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Sıkıştırma tipleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma olmadığını belirtir.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Derinlik, sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'sını ayarlayın.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarlayın.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu belirtilen boyutla TIFF olarak kaydedin.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Sunumu Özel Görüntü Piksel Formatı ile TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) yöntemini kullanarak elde edilecek TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel formatına sahip bir TIFF görüntüsüne dönüştürmeyi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelere göre):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */
    
    // Sunumu belirtilen piksel formatı ile TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="info" %}}
Aspose'un **ÜCRETSİZ PowerPoint'ten Poster Dönüştürücüsü**nü inceleyin: https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online
{{% /alert %}}

## **SSS**

**Bireysel bir slaytı tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısına bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı konusunda herhangi bir kısıtlama uygulamaz. Her boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürüldüğünde korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.