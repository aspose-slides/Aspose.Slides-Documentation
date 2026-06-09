---
title: Android'de PowerPoint Sunumlarını TIFF'e Dönüştürme
titlelink: PowerPoint'tan TIFF'e
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
  - PowerPoint'tan TIFF'e
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
description: "Aspose.Slides for Android kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine nasıl kolayca dönüştüreceğinizi, Java kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalite ile grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle TIFF'i katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel doğruluğunu korumasını sağlayabilirsiniz. 

## **Bir Sunumu TIFF'e Dönüştürme**

[save] yöntemini sağlayan [Presentation] sınıfını kullanarak bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu kod, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```java
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Sunumu TIFF olarak kaydedin.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Bir Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions] sınıfındaki [setBwConversionMode] yöntemi, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [setCompressionType] yönteminin `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu kod, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

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

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Bir Sunumu Özel Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions] içinde bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [setImageSize] yöntemi, ortaya çıkan görüntünün boyutunu tanımlamanızı sağlar.

Bu kod, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```java
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturun.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma tipini ayarlayın.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Sıkıştırma tipleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma uygulanmadığını belirtir.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Derinlik sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'sını ayarlayın.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Görüntü boyutunu ayarlayın.
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Belirtilen boyutla sunumu TIFF olarak kaydedin.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Bir Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştürme**

[TiffOptions] sınıfındaki [setPixelFormat] yöntemini kullanarak ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirleyebilirsiniz.

Bu kod, bir PowerPoint sunumunu özel piksel biçimli bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```java
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını oluşturun.
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
    
    // Belirtilen görüntü boyutuyla sunumu TIFF olarak kaydedin.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="İpucu" color="primary" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) 'na göz atın.
{{% /alert %}}

## **SSS**

**PowerPoint sunumunun tümü yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısında bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş etkileri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.