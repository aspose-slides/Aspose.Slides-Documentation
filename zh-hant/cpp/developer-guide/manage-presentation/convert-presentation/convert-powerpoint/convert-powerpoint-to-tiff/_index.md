---
title: 在 C++ 中將 PowerPoint 簡報轉換為 TIFF
titlelink: PowerPoint 轉 TIFF
type: docs
weight: 90
url: /zh-hant/cpp/convert-powerpoint-to-tiff/
keywords:
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 TIFF
- 簡報 轉 TIFF
- 投影片 轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- 將 PPT 儲存為 TIFF
- 將 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++，輕鬆將 PowerPoint（PPT、PPTX）簡報轉換為高品質的 TIFF 圖像，並提供程式碼範例。"
---
## **簡介**

TIFF（**Tagged Image File Format**）是一種廣泛使用的無損點陣圖像格式，以其卓越的品質和對圖形細節的完整保留而聞名。設計師、攝影師以及桌面出版人員常選擇 TIFF 來保持圖像的圖層、顏色準確度與原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 投影片（PPT、PPTX）與 OpenDocument 投影片（ODP）直接轉換為高品質的 TIFF 圖像，確保您的簡報保留最佳的視覺忠實度。

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別提供的 [Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 圖像符合預設投影片尺寸。

以下 C++ 程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// 將簡報儲存為 TIFF。
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **將簡報轉換為黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/) 類別中的 [set_BwConversionMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) 方法允許您指定將彩色投影片或圖像轉換為黑白 TIFF 時使用的演算法。請注意，此設定僅在 [set_CompressionType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) 方法設為 `CCITT4` 或 `CCITT3` 時套用。

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) 是一個匯出層級的設定，用於為完整的 TIFF 圖像選擇像素轉換演算法。若要定義在黑白顯示模式下個別圖形的呈現方式，請使用 [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_blackwhitemode/)。有關範例，請參閱 [Control Black-and-White Rendering for Shapes](/slides/zh-hant/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes)。
{{% /alert %}}

假設我們有一個名為「sample.pptx」的檔案，其包含以下投影片：

![投影片示例](slide_black_and_white.png)

以下 C++ 程式碼示範如何將彩色投影片轉換為黑白 TIFF：

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

結果：

![黑白 TIFF](TIFF_black_and_white.png)

## **將簡報轉換為具有自訂大小的 TIFF**

如果您需要具有特定尺寸的 TIFF 圖像，您可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/) 中提供的方法設定所需的數值。例如，[set_ImageSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 方法允許您定義產生圖像的大小。

以下 C++ 程式碼示範如何將 PowerPoint 簡報轉換為具自訂大小的 TIFF 圖像：

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

// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// 設定壓縮類型。
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
壓縮類型：
    Default - 指定預設的壓縮方案 (LZW)。
    None - 指定不使用壓縮。
    CCITT3
    CCITT4
    LZW
    RLE
*/

// 深度取決於壓縮類型，無法手動設定。

// 設定影像 DPI。
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// 設定影像大小。
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 以指定的尺寸將簡報儲存為 TIFF。
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **將簡報轉換為具有自訂圖像像素格式的 TIFF**

透過 [TiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/) 類別中的 [set_PixelFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) 方法，您可以為產生的 TIFF 圖像指定首選的像素格式。

以下 C++ 程式碼示範如何將 PowerPoint 簡報轉換為具自訂像素格式的 TIFF 圖像：

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat 包含以下值（如文件所述）：
    Format1bppIndexed - 每像素 1 位，索引式。
    Format4bppIndexed - 每像素 4 位，索引式。
    Format8bppIndexed - 每像素 8 位，索引式。
    Format24bppRgb    - 每像素 24 位，RGB。
    Format32bppArgb   - 每像素 32 位，ARGB。
*/

 // 以指定的影像大小將簡報儲存為 TIFF。
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
查看 Aspose 的 [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以將單一投影片而非整個 PowerPoint 簡報轉換為 TIFF 嗎？**

可以。Aspose.Slides 允許您將 PowerPoint 與 OpenDocument 簡報中的單一投影片分別轉換為 TIFF 圖像。

**在將簡報轉換為 TIFF 時，投影片數量有任何限制嗎？**

沒有，Aspose.Slides 不會對投影片數量施加任何限制。您可以將任何規模的簡報轉換為 TIFF 格式。

**將投影片轉換為 TIFF 時，會保留 PowerPoint 動畫和過場效果嗎？**

不會，TIFF 是靜態圖像格式。因此，動畫和過場效果不會被保留；僅匯出投影片的靜態快照。