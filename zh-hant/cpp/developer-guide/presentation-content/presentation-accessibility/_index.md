---
title: 在 C++ 中管理簡報可及性
linktitle: 簡報可及性
type: docs
weight: 30
url: /zh-hant/cpp/presentation-accessibility/
keywords:
- 簡報可及性
- 替代文字
- 替代文字標題
- 替代文字說明
- 標記為裝飾性
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自動執行 PPT、PPTX 與 ODP 檔案的簡報可及性檢查——提升螢幕閱讀器體驗並增強合規性。"
---
## **簡介**

替代文字可協助使用輔助技術的使用者了解圖像、圖表和其他資訊形狀的意義。本文說明如何使用 Aspose.Slides for C++ 讀取和更新替代文字標題與說明、如何將可及性說明與程式碼中使用的形狀名稱區分，以及如何檢查形狀是否被標記為裝飾性。

這些功能支援投影片的可及性，但不保證完整可及。仍需檢查閱讀順序、顏色對比、文字可讀性等其他可及性需求。

## **管理替代文字標題與說明**

使用替代文字向無法觀看圖像的使用者說明圖像、圖表和其他資訊形狀的含義。以下屬性各有不同用途：

| Property or content | Purpose |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_alternativetexttitle/) | 替代說明的簡短標題。 |
| [AlternativeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_alternativetext/) | 形狀內容或目的在投影片情境中的具意義說明。 |
| [Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) | 形狀的名稱，程式碼可利用它在簡報中找出特定形狀。 |
| 可見文字 | 投影片上顯示的內容，例如形狀的文字或圖表的標題與標籤。更新替代文字不會改變此內容。 |

當簡報被重新作為範本使用時，程式碼可能會先依據其[Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 找到形狀，然後再更新。此名稱的用途與替代文字不同，後者說明視覺資訊對讀者的傳遞。透過名稱搜尋可讓作者在不影響程式碼尋找形狀的前提下，改進或翻譯說明。名稱可以被編輯，且不保證唯一，因此請確認名稱與目標形狀相符；請參閱[Identify and Find Shapes](/slides/zh-hant/cpp/shape-manipulations/#identify-and-find-shapes)。

以下範例需要 `input.pptx`，其中第一張投影片的第一個形狀是一張辦公室入口的圖片，且該圖片不應被標記為裝飾性。範例讀取並列印目前的替代文字標題與說明，更新這兩個值，並將簡報儲存為 `output.pptx`。請依實際圖片及其傳遞的資訊調整文字內容。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

僅添加替代文字並不能保證簡報的可及性或符合可及性標準。請檢查說明的正確性與相關性，同時審視閱讀順序、顏色對比、可讀文字等其他可及性需求。資訊性視覺不應被標記為裝飾性；下一節將說明如何讀取[IsDecorative](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_isdecorative/)。

## **標記為裝飾性**

標記為裝飾性用於純粹美觀的視覺元素，使螢幕閱讀器略過它們，減少噪音並將焦點放在有意義的內容上。這類標記適用於背景、裝飾圖案與間隔物—絕不要用在傳遞資訊的圖表、圖示或圖像上。Aspose.Slides 提供此旗標供偵測與驗證，協助自動化可及性檢查與清理。

![Mark as Decorative](mark_as_decorative.png)

以下程式碼示範如何判斷形狀是否被標記為裝飾性。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **FAQ**

**我應該在替代文字標題和說明中放什麼？**

使用簡短的標題來辨識主題，並以說明文字解釋視覺在投影片情境中傳遞的資訊。對於圖表，說明相關的趨勢或比較，而不是僅寫「圖表」。

**我可以使用替代文字在範本中定位形狀嗎？**

建議使用[Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 來尋找形狀，並確認它是預期的形狀。替代文字可能會被編輯或翻譯，會導致搜尋精確說明的程式碼失效；請參閱[Identify and Find Shapes](/slides/zh-hant/cpp/shape-manipulations/)。

**什麼時候應該將形狀標記為裝飾性？**

對於不提供資訊的視覺元素（例如裝飾性圖案）使用裝飾性旗標。傳遞意義的圖片與圖表則需提供適當的說明。

**加入替代文字就能讓簡報完全符合可及性嗎？**

不能。替代文字只解決可及性的部分問題。仍必須檢查閱讀順序、顏色對比、文字可讀性等其他相關需求；僅設定這些屬性並不足以確保合規。