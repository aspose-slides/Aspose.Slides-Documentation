---
title: 在 C++ 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/cpp/slide-size/
keywords:
- 投影片大小
- 寬高比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片大小
- 變更投影片大小
- 自訂投影片大小
- 特殊投影片大小
- 獨特投影片大小
- 全尺寸投影片
- 螢幕類型
- 不縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 C++ 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具來調整 PowerPoint 簡報的投影片大小和寬高比，對於列印和螢幕顯示皆相當重要。  

常見投影片尺寸與比例：

- **Standard (4:3 寬高比)**: 適用於較舊的螢幕和裝置。  
- **Widescreen (16:9 寬高比)**: 推薦用於現代投影機與顯示器。  

確保整個簡報的一致性，因為單一的投影片大小與寬高比會套用至所有投影片。為取得最佳效果，請在建立簡報初期即設定投影片尺寸，以免後續產生問題。  

{{% alert color="info" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 寬高比。
{{% /alert %}}

備註與講義頁面的尺寸與普通投影片不同。請參閱[Notes Page Size](/slides/zh-hant/cpp/notes-size/)以變更其尺寸與方向。

## **更改簡報中的投影片大小**

以下範例程式碼示範如何使用 Aspose.Slides 於 C++ 中變更簡報的投影片大小：

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **在簡報中指定自訂投影片大小**

如果您發現常見的投影片尺寸（4:3 與 16:9）不適合您的工作，您可以選擇使用特定或獨特的投影片大小。例如，若您計畫在自訂頁面版面上列印完整尺寸的投影片，或是要在特定類型的螢幕上顯示簡報，使用自訂尺寸設定將能帶來效益。  

以下範例程式碼示範如何使用 Aspose.Slides for C++ 在 C++ 中為簡報指定自訂投影片大小：

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 紙張大小
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **調整大小後處理投影片內容**

在變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，以決定 Aspose.Slides 如何處理投影片上的內容。  

依據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`

  若您不希望投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  若您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片的物件縮小以確保全部適合投影片（如此可避免遺失內容），請使用此設定。  

- `Maximize`

  若您想放大投影片尺寸，且需要 Aspose.Slides 將投影片的物件放大，使其與新投影片尺寸成比例，請使用此設定。  

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **常見問題**

### 我可以使用英吋以外的單位（例如點或公釐）設定自訂投影片大小嗎？

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任意單位（例如公釐或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

### 非常大的自訂投影片大小會影響渲染時的效能與記憶體使用量嗎？

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體消耗增加與處理時間延長。請以實際需求的投影片大小為目標，僅在需要時調整渲染比例，以取得所需的輸出品質。

### 我可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片嗎？

在投影片尺寸不同的情況下，您無法[合併簡報](/slides/zh-hant/cpp/merge-presentation/)。必須先將其中一個簡報的尺寸調整至相同。變更投影片大小時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesizescaletype/) 選項選擇如何處理現有內容。尺寸對齊後，即可合併投影片且保留格式。

### 我可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？

可以。Aspose.Slides 可以為[整張投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/getimage/)生成縮圖，也能為[選取的圖形](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)生成縮圖。產生的圖片會反映當前的投影片大小與寬高比，確保框架與幾何形狀的一致性。