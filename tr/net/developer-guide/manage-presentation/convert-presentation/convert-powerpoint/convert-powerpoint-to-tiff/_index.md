---
title: PowerPoint Sunumlarını .NET'te TIFF'e Dönüştürme
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
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca dönüştürmeyi öğrenin. C# kod örnekleri."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları, görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için genellikle TIFF'i seçer.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine sorunsuz bir şekilde dönüştürebilir, sunumlarınızın en yüksek görsel doğruluğu korumasını sağlayabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

[Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı üzerinden kullanarak, bir PowerPoint sunumunu tamamen TIFF'e hızlıca dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna göre oluşturulur.

Bu C# kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfını örnekleyin; bu sınıf bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eder.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Sunumu TIFF olarak kaydedin.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) sınıfındaki [BwConversionMode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/bwconversionmode/) özelliği, renkli bir slayt veya resmi siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [CompressionType](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/compressiontype/) özelliği `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}

[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/bwconversionmode/) bir dışa aktarma düzeyi ayarıdır ve tüm TIFF görüntüsü için piksel dönüşüm algoritmasını seçer. Tek bir şeklin siyah-beyaz görüntü modunda nasıl görüneceğini tanımlamak için [IShape.BlackWhiteMode](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/blackwhitemode/) kullanın. Örnekler için [Şekiller İçin Siyah-Beyaz İşleme Kontrolü](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) bölümüne bakın.

{{% /alert %}}

Diyelim ki aşağıdaki slaytı içeren bir "sample.pptx" dosyamız var:

![Bir sunum slaytı](slide_black_and_white.png)

Bu C# kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

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

## **Sunumu Özelleştirilmiş Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/) sınıfındaki ilgili özellikleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [ImageSize](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/imagesize/) özelliği, oluşturulan görüntünün boyutunu tanımlamanıza olanak verir.

Bu C# kodu, bir PowerPoint sunumunu özelleştirilmiş boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation sınıfını örnekleyin; bu sınıf bir sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eder.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma türünü ayarlayın.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Sıkıştırma türleri:
        Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
        None - Sıkıştırma kullanılmadığını belirtir.
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

[TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions) sınıfındaki [PixelFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/pixelformat/) özelliğini kullanarak, elde edilen TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu C# kodu, bir PowerPoint sunumunu özelleştirilmiş piksel biçimli TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat, belgelerde belirtildiği gibi aşağıdaki değerleri içerir:
        Format1bppIndexed - 1 bit piksel başına, indeksli.
        Format4bppIndexed - 4 bit piksel başına, indeksli.
        Format8bppIndexed - 8 bit piksel başına, indeksli.
        Format24bppRgb    - 24 bit piksel başına, RGB.
        Format32bppArgb   - 32 bit piksel başına, ARGB.
    */

    // Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="İpucu" color="info" %}}

Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) sayfasına göz atın.

{{% /alert %}}

## **SSS**

**Bireysel bir slaytı, tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı üzerinde bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Sunumun boyutu ne olursa olsun TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytları TIFF'e dönüştürürken korunur mu?**

Hayır, TIFF sabit bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.