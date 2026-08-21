---
title: Android'de PowerPoint Sunumlarını TIFF'e Dönüştürme
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak, Java kod örnekleriyle PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için TIFF'i seçer.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel doğruluğu korumasını sağlayabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

Presentation sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu kullanarak, bir PowerPoint sunumunun tamamını hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu kod, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfını örnekleyin; bu sınıf bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eder.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

TiffOptions sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) metodu, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) metodunun `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) bir dışa aktarma düzeyi ayarıdır ve tüm TIFF görüntüsü için bir piksel dönüştürme algoritması seçer. Tek tek bir şeklin siyah-beyaz görüntüleme modunda nasıl görüneceğini tanımlamak için [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metodunu kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.
{{% /alert %}}

Şöyle bir "sample.pptx" dosyamız olduğunu ve aşağıdaki slaytı içerdiğini varsayalım:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah-beyaz bir TIFF'e nasıl dönüştüreceğinizi gösterir:

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

## **Sunumu Özel Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) metodu, elde edilen görüntünün boyutunu tanımlamanızı sağlar.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma türünü ayarlayın.
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

## **Sunumu Özel Görüntü Piksel Formatıyla TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) metodunu kullanarak, elde edilen TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel formatlı bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfını örnekleyin; bu sınıf bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eder.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelerde belirtildiği gibi):
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

{{% alert title="Tip" color="info" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster Dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online)'nu inceleyin.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı konusunda bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı konusunda herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytları TIFF'e dönüştürürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle, animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.