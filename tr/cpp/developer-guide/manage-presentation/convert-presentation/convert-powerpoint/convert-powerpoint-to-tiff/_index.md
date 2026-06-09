---
title: C++'ta PowerPoint Sunumlarını TIFF'e Dönüştürme
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/cpp/convert-powerpoint-to-tiff/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafiklerin ayrıntılı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel doğruluğunu korumasını sağlayabilirsiniz.

## **Sunumu TIFF'e Dönüştürme**

Sağlanan [Save] metodunu [Presentation] sınıfı içinde kullanarak, bir PowerPoint sunumunu hızlı bir şekilde TIFF'e dönüştürebilirsiniz. Oluşan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu C++ kodu, bir PowerPoint sunumunun TIFF'e nasıl dönüştürüleceğini gösterir:

```cpp
// Sunumu (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Sunumu TIFF olarak kaydedin.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

Bu sınıftaki [set_BwConversionMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) yöntemi, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirtmenizi sağlar. Bu ayarın yalnızca [set_CompressionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![Sunum slaytı](slide_black_and_white.png)

Bu C++ kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Sonuç:

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsüne ihtiyacınız varsa, [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) içinde bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [set_ImageSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_imagesize/) yöntemi, oluşan görüntünün boyutunu tanımlamanıza olanak verir.

Bu C++ kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

```cpp
// Sunumu (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Sıkıştırma türünü ayarlayın.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Sıkıştırma türleri:
    Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
    None - Sıkıştırma yapılmadığını belirtir.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Derinlik sıkıştırma türüne bağlıdır ve manuel olarak ayarlanamaz.

// Görüntü DPI'sını ayarlayın.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Görüntü boyutunu ayarlayın.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Belirtilen boyutla sunumu TIFF olarak kaydedin.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Sunumu Özel Görüntü Piksel Biçimiyle TIFF'e Dönüştürme**

[TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) sınıfındaki [set_PixelFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) yöntemini kullanarak, oluşan TIFF görüntüsü için tercih ettiğiniz piksel biçimini belirtebilirsiniz.

Bu C++ kodu, bir PowerPoint sunumunu özel piksel biçimli bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

```cpp
// Sunumu (PPT, PPTX, ODP vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat aşağıdaki değerleri içerir (belgelerde belirtildiği gibi):
    Format1bppIndexed - Piksel başına 1 bit, indeksli.
    Format4bppIndexed - Piksel başına 4 bit, indeksli.
    Format8bppIndexed - Piksel başına 8 bit, indeksli.
    Format24bppRgb    - Piksel başına 24 bit, RGB.
    Format32bppArgb   - Piksel başına 32 bit, ARGB.
*/

// Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="primary" %}}
Check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **SSS**

**PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlardan tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı için bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytların TIFF'e dönüştürülmesinde korunuyor mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların statik anlık görüntüleri dışa aktarılır.