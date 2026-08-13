---
title: PowerPoint Sunumlarını .NET'te TIFF'e Dönüştürme
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kalitede TIFF görüntülerine kolayca dönüştürmeyi öğrenin. C# kod örnekleri."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i seçer.

Aspose.Slides'ı kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel doğruluğunu korumasını sağlayabilirsiniz. 

## **Sunumu TIFF'e Dönüştürme**

Sunum sınıfı tarafından sağlanan [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemini kullanarak, bir PowerPoint sunumunu tamamen hızlı bir şekilde TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu C# kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Sunumu TIFF olarak kaydedin.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[BwConversionMode](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/bwconversionmode/) özelliği, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirlemenizi sağlar. Bu ayarın yalnızca [CompressionType](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/compressiontype/) özelliği `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

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

## **Sunumu Özel Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions] içinde mevcut olan özellikleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [ImageSize] özelliği ortaya çıkan görüntünün boyutunu tanımlamanızı sağlar.

Bu C# kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfının bir örneğini oluşturun.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Sıkıştırma tipini ayarla.
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

    // Derinlik, sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

    // Görüntü DPI'sını ayarla.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Görüntü boyutunu ayarla.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Sunumu belirtilen boyutla TIFF olarak kaydet.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştürme**

[TiffOptions] sınıfındaki [PixelFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/pixelformat/) özelliğini kullanarak, ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirleyebilirsiniz.

Bu C# kodu, bir PowerPoint sunumunu özel piksel biçimli TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfının bir örneğini oluştur.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat aşağıdaki değerleri içerir (belgelerde belirtildiği gibi):
        Format1bppIndexed - piksel başına 1 bit, indeksli.
        Format4bppIndexed - piksel başına 4 bit, indeksli.
        Format8bppIndexed - piksel başına 8 bit, indeksli.
        Format24bppRgb    - piksel başına 24 bit, RGB.
        Format32bppArgb   - piksel başına 32 bit, ARGB.
    */

    // Belirtilen görüntü boyutuyla sunumu TIFF olarak kaydet.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Aspose'un [ÜCRETSİZ PowerPoint'ten Poster dönüştürücüsü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) sitesine göz atın.
{{% /alert %}}

## **SSS**

### Tek bir slaytı, tüm PowerPoint sunumu yerine TIFF'e dönüştürebilir miyim?

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

### Sunumu TIFF'e dönüştürürken slayt sayısı konusunda bir sınırlama var mı?

Hayır, Aspose.Slides slayt sayısı konusunda herhangi bir kısıtlama getirmez. Herhangi bir boyutta sunumu TIFF formatına dönüştürebilirsiniz.

### PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürüldüğünde korunur mu?

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.