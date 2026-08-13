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
- PPTX'den TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e aktar
- PPTX'i TIFF'e aktar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, Java kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kaliteyi ve grafiklerin ayrıntılı korunmasını sağlar. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları, görüntülerindeki katmanları, renk doğruluğunu ve orijinal ayarları korumak için genellikle TIFF'i tercih eder.

Aspose.Slides ile PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kalite TIFF görüntülerine sorunsuz bir şekilde dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu kullanarak tüm bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Aşağıdaki kod, bir PowerPoint sunumunu TIFF'e dönüştürmeyi göstermektedir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah‑Beyaz TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slayt veya görüntüyü siyah‑beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenize olanak tanır. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![A presentation slide](slide_black_and_white.png)

Aşağıdaki kod, renkli slaytı siyah‑beyaz TIFF'e dönüştürmeyi göstermektedir:

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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Özel Boyutlu TIFF'e Sunumu Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü istiyorsanız, [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) yöntemi, oluşturulan görüntünün boyutunu tanımlamanıza imkan verir.

Aşağıdaki kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine dönüştürmeyi göstermektedir:

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

    // Görüntünün DPI değerini ayarlayın.
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

## **Özel Piksel Formatlı TIFF'e Sunumu Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) metodunu kullanarak, elde edilen TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Aşağıdaki kod, bir PowerPoint sunumunu özel piksel formatlı bir TIFF görüntüsüne dönüştürmeyi göstermektedir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelere göre):
        Format1bppIndexed - Piksel başına 1 bit, indeksli.
        Format4bppIndexed - Piksel başına 4 bit, indeksli.
        Format8bppIndexed - Piksel başına 8 bit, indeksli.
        Format24bppRgb    - Piksel başına 24 bit, RGB.
        Format32bppArgb   - Piksel başına 32 bit, ARGB.
    */
    
    // Sunumu belirtilen piksel formatıyla TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose'un [ÜCRETSİZ PowerPoint‑den Poster dönüştürücüsünü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) inceleyin.
{{% /alert %}}

## **SSS**

### Tek bir slaytı tüm PowerPoint sunumu yerine TIFF olarak dönüştürebilir miyim?

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

### Sunumu TIFF'e dönüştürürken slayt sayısıyla ilgili bir sınırlama var mı?

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama uygulamaz. Herhangi bir boyutta sunumu TIFF formatına dönüştürebilirsiniz.

### PowerPoint animasyonları ve geçiş efektleri TIFF'e dönüştürülürken korunur mu?

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.