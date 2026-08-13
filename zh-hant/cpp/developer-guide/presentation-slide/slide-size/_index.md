---
title: 在 C++ 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/cpp/slide-size/
keywords:
- 投影片大小
- 長寬比
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
description: "了解如何使用 C++ 與 Aspose.Slides 快速調整 PPT、PPTX 和 ODP 檔案中的投影片大小，並在不失真的情況下優化簡報以適應任何螢幕。"
---
## **簡介**

Aspose.Slides 提供全面的工具來調整 PowerPoint 簡報的投影片大小與長寬比，這對於列印和螢幕顯示皆相當重要。

常見的投影片大小與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕和裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機和顯示器。

確保簡報全過程的一致性，因為單一的投影片大小與長寬比會套用至所有投影片。為獲得最佳效果，請在簡報建立之初設定投影片尺寸，以避免日後的問題。

{{% alert color="info" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報的投影片大小**

以下範例程式碼示範如何使用 Aspose.Slides 在 C++ 中變更簡報的投影片大小：

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

如果您發現常見的投影片大小（4:3 與 16:9）不適合您的工作，您可以決定使用特定或唯一的投影片大小。例如，若您計畫在自訂的頁面佈局上列印全尺寸投影片，或是希望在特定類型的螢幕上呈現簡報，使用自訂大小設定將對您有所幫助。

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

變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，以決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`  
  若您 **不想** 讓投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`  
  若您希望縮小投影片尺寸且需要 Aspose.Slides 將投影片物件縮小以確保全部內容都能放入投影片（避免遺失內容），請使用此設定。

- `Maximize`  
  若您希望放大投影片尺寸且需要 Aspose.Slides 將投影片物件放大以使其與新的投影片尺寸成比例，請使用此設定。

以下範例程式碼示範在變更簡報投影片大小時如何使用 `Maximize` 設定：

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### 我可以使用英寸以外的單位（例如點或毫米）設定自訂投影片大小嗎？

是的。Aspose.Slides 在內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

### 非常大的自訂投影片大小會影響渲染時的效能與記憶體使用量嗎？

是的。較大的投影片尺寸（以點計）結合較高的渲染比例會導致記憶體消耗增加與處理時間變長。請以實際需求為導向設定投影片大小，僅在需要達到特定輸出品質時調整渲染比例。

### 我可以定義一個非標準的投影片大小，然後合併來自不同大小簡報的投影片嗎？

您無法在投影片大小不同的情況下[合併簡報](/slides/zh-hant/cpp/merge-presentation/)。必須先將其中一個簡報的尺寸調整至與另一個相同。變更投影片大小時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesizescaletype/) 選項決定現有內容的處理方式。尺寸對齊後，即可在保留格式的前提下合併投影片。

### 我能產生單一圖形或投影片特定區域的縮圖，且它們會遵循新的投影片大小嗎？

是的。Aspose.Slides 可以為[完整投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/getimage/)以及為[選取的圖形](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)產生縮圖。產生的圖像會反映目前的投影片大小與長寬比，確保框架與幾何形狀的一致性。