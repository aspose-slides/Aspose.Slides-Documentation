---
title: Java ile PowerPoint Sunumlarını TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten TIFF'e
- sunumu TIFF'e
- slaytı TIFF'e
- PPT'yi TIFF'e
- PPTX'i TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e aktar
- PPTX'i TIFF'e aktar
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kalite ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncılar genellikle katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı tarafından sağlanan [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini kullanarak tüm bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Aşağıdaki kod bir PowerPoint sunumunu TIFF'e dönüştürmeyi göstermektedir:

```java
// Bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Sunumu Siyah‑Beyaz TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfındaki [setBwConversionMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) yöntemi, renkli bir slaytı veya görüntüyü siyah‑beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [setCompressionType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Aşağıdaki kod renkli slaytı siyah‑beyaz TIFF'e dönüştürmeyi göstermektedir:

```java
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

![Siyah‑beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştür**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfında mevcut yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) yöntemi, ortaya çıkan görüntünün boyutunu tanımlamanıza olanak tanır.

Aşağıdaki kod bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine dönüştürmeyi göstermektedir:

```java
// Bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma tipini ayarlayın.
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

    // Derinlik sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI değerini ayarlayın.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarlayın.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Sunumu belirtilen boyutla TIFF olarak kaydedin.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Sunumu Özel Piksel Biçimli TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) sınıfındaki [setPixelFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) yöntemiyle ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Aşağıdaki kod bir PowerPoint sunumunu özel piksel biçimli TIFF görüntüsüne dönüştürmeyi göstermektedir:

```java
// Bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
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
    
    // Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="primary" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) hizmetine göz atın.
{{% /alert %}}

## **SSS**

**Bireysel bir slaytı, tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarındaki bireysel slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı için bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. İstediğiniz boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytları TIFF'e dönüştürürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların sabit anlık görüntüleri dışa aktarılır.