---
title: C++ ile PowerPoint Sunumlarını TIFF'e Dönüştür
titlelink: PowerPoint'ten TIFF'e
type: docs
weight: 90
url: /tr/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint'i dönüştür
- OpenDocument'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten TIFF'e
- sunumu TIFF'e
- slaytı TIFF'e
- PPT'yi TIFF'e
- PPTX'i TIFF'e
- PPT'yi TIFF olarak kaydet
- PPTX'i TIFF olarak kaydet
- PPT'yi TIFF'e dışa aktar
- PPTX'i TIFF'e dışa aktar
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint (PPT, PPTX) sunumlarını yüksek kaliteli TIFF görüntülerine kolayca nasıl dönüştüreceğinizi, kod örnekleriyle öğrenin."
---
## **Giriş**

TIFF (**Tagged Image File Format**) yaygın olarak kullanılan, kayıpsız raster görüntü formatıdır ve olağanüstü kalitesi ile grafiklerin detaylı korunmasıyla bilinir. Tasarımcılar, fotoğrafçılar ve masaüstü yayıncıları genellikle görüntülerinde katmanları, renk doğruluğunu ve orijinal ayarları korumak için TIFF'i tercih eder.

Aspose.Slides kullanarak, PowerPoint slaytlarınızı (PPT, PPTX) ve OpenDocument slaytlarınızı (ODP) doğrudan yüksek kaliteli TIFF görüntülerine zahmetsizce dönüştürebilir, sunumlarınızın maksimum görsel sadeliğini korumasını sağlayabilirsiniz.

## **Sunumu TIFF'e Dönüştür**

Sağlanan [Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemi, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı tarafından sunulur ve bir PowerPoint sunumunu hızlıca TIFF'e dönüştürmenizi sağlar. Oluşturulan TIFF görüntüleri varsayılan slayt boyutuna karşılık gelir.

Bu C++ kodu, bir PowerPoint sunumunu TIFF'e nasıl dönüştüreceğinizi gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Sunum dosyasını (PPT, PPTX, ODP, vb.) temsil eden Presentation sınıfını örnekleyin.
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Sunumu Siyah-Beyaz TIFF'e Dönüştür**

[set_BwConversionMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) yöntemi, [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) sınıfında renkli bir slaytı veya görüntüyü siyah-beyaz TIFF'e dönüştürürken kullanılacak algoritmayı belirtmenizi sağlar. Bu ayar yalnızca [set_CompressionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) yöntemi `CCITT4` veya `CCITT3` olarak ayarlandığında geçerlidir.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) tüm TIFF görüntüsü için piksel dönüştürme algoritmasını seçen bir dışa aktarma düzeyi ayarıdır. Siyah-beyaz görüntüleme modu etkin olduğunda bir şeklin nasıl görüneceğini belirlemek için [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_blackwhitemode/) yöntemini kullanın. Örnekler için [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) sayfasına bakın.
{{% /alert %}}

Örneğin, aşağıdaki slaytı içeren bir "sample.pptx" dosyamız olduğunu varsayalım:

![Bir sunum slaytı](slide_black_and_white.png)

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

![Siyah-Beyaz TIFF](TIFF_black_and_white.png)

## **Sunumu Özel Boyutlu TIFF'e Dönüştür**

Belirli boyutlarda bir TIFF görüntüsü gerektiğinde, istediğiniz değerleri [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) içinde bulunan yöntemlerle ayarlayabilirsiniz. Örneğin, [set_ImageSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_imagesize/) yöntemi, oluşturulan görüntünün boyutunu tanımlamanıza olanak verir.

Bu C++ kodu, bir PowerPoint sunumunu özel boyutlu TIFF görüntülerine nasıl dönüştüreceğinizi gösterir:

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

// Sıkıştırma türünü ayarlayın.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
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
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Görüntü boyutunu ayarlayın.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Sunumu belirtilen boyutta TIFF olarak kaydedin.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Özel Görüntü Piksel Formatı ile TIFF'e Sunumu Dönüştür**

[set_PixelFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) yöntemini, [TiffOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/tiffoptions/) sınıfından kullanarak, oluşturulan TIFF görüntüsü için tercih ettiğiniz piksel formatını belirtebilirsiniz.

Bu C++ kodu, bir PowerPoint sunumunu özel piksel formatına sahip bir TIFF görüntüsüne nasıl dönüştüreceğinizi gösterir:

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
ImagePixelFormat aşağıdaki değerleri içerir (belgede belirtildiği gibi):
    Format1bppIndexed - piksel başına 1 bit, indeksli.
    Format4bppIndexed - piksel başına 4 bit, indeksli.
    Format8bppIndexed - piksel başına 8 bit, indeksli.
    Format24bppRgb    - piksel başına 24 bit, RGB.
    Format32bppArgb   - piksel başına 32 bit, ARGB.
*/

// Sunumu belirtilen görüntü boyutuyla TIFF olarak kaydedin.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Aspose'un [Ücretsiz PowerPoint'ten Poster Dönüştürücü](https://products.aspose.app/slides/tr/conversion/convert-ppt-to-poster-online) göz atın.
{{% /alert %}}

## **SSS**

**Bir PowerPoint sunumunun tamamı yerine tek bir slaytı TIFF'e dönüştürebilir miyim?**

Evet. Aspose.Slides, PowerPoint ve OpenDocument sunumlarından tek tek slaytları ayrı ayrı TIFF görüntülerine dönüştürmenize olanak tanır.

**Sunumu TIFF'e dönüştürürken slayt sayısında bir sınırlama var mı?**

Hayır, Aspose.Slides slayt sayısı konusunda herhangi bir kısıtlama getirmez. Herhangi bir boyuttaki sunumları TIFF formatına dönüştürebilirsiniz.

**PowerPoint animasyonları ve geçiş efektleri, slaytlar TIFF'e dönüştürüldüğünde korunur mu?**

Hayır, TIFF statik bir görüntü formatıdır. Bu nedenle animasyonlar ve geçiş efektleri korunmaz; yalnızca slaytların statik anlık görüntüleri dışa aktarılır.