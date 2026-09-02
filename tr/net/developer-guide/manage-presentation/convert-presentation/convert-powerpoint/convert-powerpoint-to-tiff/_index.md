---
title: PowerPoint Sunumlarını .NET'te TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/net/convert-powerpoint-to-tiff/
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
- PPT'yi TIFF'e aktar
- PPTX'i TIFF'e aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine nasıl kolayca dönüştüreceğinizi öğrenin. C# kod örnekleri."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yüksek kaliteli ve grafiklerin ayrıntılı korunmasıyla bilinen, yaygın olarak kullanılan kayıpsız bir raster görüntü formatıdır. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncılar genellikle görüntülerindeki katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine sorunsuz bir şekilde dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini koruyabilirsiniz. 

## **Sunumu TIFF'e Dönüştür**

[Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) metodunu, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı ile birlikte kullanarak tüm bir PowerPoint sunumunu hızlıca TIFF'e dönüştürebilirsiniz. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Aşağıdaki C# kodu bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Sunumu TIFF olarak kaydedin.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) sınıfındaki [BwConversionMode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/bwconversionmode/) özelliği, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [CompressionType](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/compressiontype/) özelliği `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}

[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/bwconversionmode/) tamamen TIFF görüntüsü için piksel dönüşüm algoritmasını seçen bir dışa aktarma seviyesindeki ayardır. Tek bir şeklin siyah-beyaz görüntü modunda nasıl görünmesi gerektiğini tanımlamak için [IShape.BlackWhiteMode](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/blackwhitemode/) kullanın. Örnekler için [/slides/tr/net/shape-formatting/#control-black-and-white-rendering-for-shapes](https://reference.aspose.com/slides/tr/net/shape-formatting/#control-black-and-white-rendering-for-shapes) adresindeki **Control Black-and-White Rendering for Shapes** bölümüne bakın.

{{% /alert %}}

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu C# kodu renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Sunumu Özel Boyutlu TIFF'e Dönüştür**

Belirli boyutlarda bir TIFF görüntüsü istiyorsanız, [TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) içinde bulunan özellikleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [ImageSize](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/imagesize/) özelliği oluşturulan görüntünün boyutunu tanımlamanıza olanak verir.

Aşağıdaki C# kodu PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfının bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden bir örneğini oluşturun.
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

    // Görüntü DPI'ını ayarlayın.
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

## **Sunumu Özel Piksel Formatlı TIFF'e Dönüştür**

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions) sınıfındaki [PixelFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/pixelformat/) özelliğini kullanarak ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Aşağıdaki C# kodu PowerPoint sunumunu özel piksel formatlı bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelendirmede belirtildiği gibi):
        Format1bppIndexed - Piksel başına 1 bit, indeksli.
        Format4bppIndexed - Piksel başına 4 bit, indeksli.
        Format8bppIndexed - Piksel başına 8 bit, indeksli.
        Format24bppRgb    - Piksel başına 24 bit, RGB.
        Format32bppArgb   - Piksel başına 32 bit, ARGB.
    */

    // Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="İpucu" color="info" %}}

Aspose'un [ÜCRETSİZ PowerPoint Poster Dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) hizmetine bir göz atın.

{{% /alert %}}

## **SSS**

**Bireysel bir slaytı tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısında bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Her boyuttaki sunumu TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.