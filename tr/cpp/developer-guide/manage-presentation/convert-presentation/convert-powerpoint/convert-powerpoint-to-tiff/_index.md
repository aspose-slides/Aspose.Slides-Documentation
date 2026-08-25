---
title: PowerPoint Sunumlarını C++ ile TIFF'e Dönüştürme
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
- sunumdan TIFF'e
- slayttan TIFF'e
- PPT'den TIFF'e
- PPTX'ten TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca dönüştürmeyi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız bir raster görüntü formatıdır ve olağanüstü kalitesi ve grafikleri ayrıntılı olarak koruması ile bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle TIFF'i katmanları, renk doğruluğunu ve görüntülerindeki orijinal ayarları korumak için seçer.

Aspose.Slides kullanarak PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarını (ODP) doğrudan yüksek kaliteli TIFF görüntülerine sorunsuz bir şekilde dönüştürebilir, sunumlarınızın maksimum görsel doğruluğunu korumasını sağlayabilirsiniz.

## **Sunumu TIFF'e Dönüştürme**

Using the [Kaydet](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) method provided by the [Sunum](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Sunumu TIFF olarak kaydedin.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştürme**

[TiffOptions] sınıfındaki [set_BwConversionMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) yöntemi, renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılan algoritmayı belirtmenize olanak tanır. Bu ayarın yalnızca [set_CompressionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerli olduğunu unutmayın.

{{% alert color="info" title="Not" %}}
[TiffOptions::set_BwConversionMode] bir dışa aktarma düzeyi ayarıdır ve tam TIFF görüntüsü için piksel‑dönüştürme algoritmasını seçer. Bireysel bir şeklin siyah‑beyaz görüntüleme modunda nasıl görüneceğini tanımlamak için [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_blackwhitemode/). Örnekler için [Control Black-and-White Rendering for Shapes](/slides/tr/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) bölümüne bakın.
{{% /alert %}}

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![A presentation slide](slide_black_and_white.png)

Bu C++ kodu, renkli slaytı siyah-beyaz TIFF'e nasıl dönüştüreceğinizi gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Sonuç:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştürme**

Belirli boyutlarda bir TIFF görüntüsü gerekiyorsa, [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) sınıfında bulunan yöntemleri kullanarak istediğiniz değerleri ayarlayabilirsiniz. Örneğin, [set_ImageSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_imagesize/) yöntemi ortaya çıkan görüntünün boyutunu tanımlamanızı sağlar.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Sıkıştırma tipini ayarlayın.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Sıkıştırma tipleri:
    Default - Varsayılan sıkıştırma şemasını (LZW) belirtir.
    None - Sıkıştırma yapılmadığını belirtir.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Derinlik, sıkıştırma tipine bağlıdır ve manuel olarak ayarlanamaz.

// Görüntü DPI değerini ayarlayın.
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

## **Sunumu Özel Görüntü Piksel Formatı ile TIFF'e Dönüştürme**

[TiffOptions] sınıfındaki [set_PixelFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) yöntemini kullanarak, ortaya çıkan TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat aşağıdaki değerleri içerir (belgelendirmede belirtildiği gibi):
    Format1bppIndexed - piksel başına 1 bit, indeksli.
    Format4bppIndexed - piksel başına 4 bit, indeksli.
    Format8bppIndexed - piksel başına 8 bit, indeksli.
    Format24bppRgb    - piksel başına 24 bit, RGB.
    Format32bppArgb   - piksel başına 32 bit, ARGB.
*/

// Belirtilen görüntü boyutuyla sunumu TIFF olarak kaydedin.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="İpucu" color="info" %}}
Aspose'un [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) adlı ücretsiz PowerPoint'ten Poster dönüştürücüsüne göz atın.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tümü yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlardan tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısı için bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı üzerinde herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri slaytlar TIFF'e dönüştürülürken korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; sadece slaytların sabit anlık görüntüleri dışa aktarılır.