---
title: Java'da PowerPoint Sunumlarını TIFF'e Dönüştürme
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
- sunum TIFF'e
- slayt TIFF'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine nasıl kolayca dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kalite ve grafikleri ayrıntılı korumasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine kolayca dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

[save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı üzerinden kullanarak tüm PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu kod, bir PowerPoint sunumunu TIFF'e dönüştürmeyi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slayt veya resmi siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) tüm TIFF görüntüsü için piksel dönüşüm algoritmasını seçen bir dışa aktarım seviyesindeki ayardır. Tek bir şeklin siyah-beyaz görüntü modunda nasıl görüneceğini tanımlamak için [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metodunu kullanın. Örnekler için [Şekiller İçin Siyah-Beyaz İşleme Kontrolü](/java/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.
{{% /alert %}}

Örneğin aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah-beyaz TIFF'e dönüştürmeyi gösterir:

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

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) yöntemi, oluşturulan görüntünün boyutunu tanımlamanıza olanak verir.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine dönüştürmeyi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

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
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu belirtilen boyutta TIFF olarak kaydedin.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) metodunu kullanarak ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel biçimli bir TIFF görüntüsüne dönüştürmeyi gösterir:

```java
import com.aspose.slides.*;

// Presentation sınıfını örnekleyin; bu sınıf bir sunum dosyasını (PPT, PPTX, ODP vb.) temsil eder.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (dokümantasyonda belirtildiği gibi):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */
    
    // Sunumu belirtilen piksel biçimiyle TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="info" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster Dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) sayfasına göz atın.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tüm slaytları yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı için bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytları TIFF'e dönüştürürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.