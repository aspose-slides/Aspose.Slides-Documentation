---
title: ".NET'te PowerPoint Sunumlarını TIFF'e Dönüştürme"
titlelink: "PowerPoint'ten TIFF'e"
type: docs
weight: 90
url: /tr/net/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint'i dönüştür"
- "OpenDocument'i dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT'yi dönüştür"
- "PPTX'i dönüştür"
- "PowerPoint'ten TIFF'e"
- "sunumdan TIFF'e"
- "slayttan TIFF'e"
- "PPT'den TIFF'e"
- "PPTX'den TIFF'e"
- "PPT'yi TIFF olarak kaydet"
- "PPTX'i TIFF olarak kaydet"
- "PPT'yi TIFF'e dışa aktar"
- "PPTX'i TIFF'e dışa aktar"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi öğrenin. C# kod örnekleri."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kaliteyi, grafikleri ayrıntılı olarak korumasını sağlar. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları, katmanları, renk doğruluğunu ve orijinal ayarları korumak için genellikle TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın en yüksek görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

[Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı tarafından sağlanan [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini kullanarak bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu C# kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```cs
// Bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Sunumu TIFF olarak kaydedin.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) sınıfındaki [BwConversionMode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/bwconversionmode/) özelliği, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [CompressionType](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/compressiontype/) özelliği `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![Bir sunum slaytı](slide_black_and_white.png)

Bu C# kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```cs
TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özelleştirilmiş Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü gerektiriyorsanız, [TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) içinde bulunan özellikleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [ImageSize](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/imagesize/) özelliği, elde edilecek görüntünün boyutunu tanımlamanıza olanak sağlar.

Bu C# kodu, bir PowerPoint sunumunu özelleştirilmiş boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```cs
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma türünü ayarlayın.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
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
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Görüntü boyutunu ayarlayın.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Sunumu belirtilen boyutla TIFF olarak kaydedin.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Sunumu Özelleştirilmiş Görüntü Piksel Biçimiyle TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions) sınıfındaki [PixelFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/pixelformat/) özelliğini kullanarak, elde edilecek TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu C# kodu, bir PowerPoint sunumunu özelleştirilmiş piksel biçimli TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```cs
// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelendirmede belirtildiği gibi):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */

    // Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Aspose'un [ÜCRETSİZ PowerPoint'den Poster Dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) inceleyin.
{{% /alert %}}

## **SSS**

**PowerPoint sunumunun tümünü değil tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısında bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde hiçbir kısıtlama getirmez. Herhangi bir boyutta sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF sabit bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.