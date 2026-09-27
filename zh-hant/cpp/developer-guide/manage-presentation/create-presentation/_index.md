---
title: 使用 C++ 建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/cpp/create-presentation/
keywords:
- 建立簡報
- 新增簡報
- 建立 PPT
- 新增 PPT
- 建立 PPTX
- 新增 PPTX
- 建立 ODP
- 新增 ODP
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中建立簡報——產生 PPT、PPTX 與 ODP 檔案，支援 OpenDocument，並以程式方式儲存以確保可靠的結果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中建立簡報、在第一張投影片上加入文字方塊，並將結果儲存為檔案。文末的簡短 FAQ 會涵蓋有關格式、範本、投影片尺寸、單位、記憶體使用、執行緒、授權、數位簽章與 VBA 支援的常見問題。

開始之前，請將 Aspose.Slides 加入您的專案：在 Windows 上的 Visual Studio 專案中透過 NuGet，或在 Linux 上使用 CMake 從 ZIP 套件安裝。請參閱[安裝](/slides/zh-hant/cpp/installation/)。

## **建立 PowerPoint 簡報**

若要建立簡報並在第一張投影片上放置文字方塊，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別的實例。新簡報已預設包含一張空白投影片。
1. 使用 [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 方法取得該投影片，索引值為 0。
1. 使用 [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) 方法新增矩形，並以 [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) 方法設定其文字。
1. 使用 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法將簡報儲存為 PPTX 檔案。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

此矩形左上角距投影片左邊緣 50 點、上邊緣 50 點，寬度為 400 點、高度為 100 點。程式會在工作目錄中儲存 *hello.pptx*，其中包含一張包含該矩形及其文字的投影片。若未授權，Aspose.Slides 亦會在每張儲存的投影片上加上評估水印；請參閱[授權](/slides/zh-hant/cpp/licensing/)。

## **常見問題**

### 我可以將新簡報儲存為哪些格式？

您可以儲存為 [PPTX、PPT 和 ODP](/slides/zh-hant/cpp/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/) 以及 [images](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 等格式。

### 我可以從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？

可以。載入範本後儲存為所需格式；POTX/POTM/PPTM 以及其他類似格式[已支援](/slides/zh-hant/cpp/supported-file-formats/)。

### 建立簡報時如何控制投影片尺寸/長寬比？

設定[投影片尺寸](/slides/zh-hant/cpp/slide-size/)（包含 4:3、16:9 等預設或自訂尺寸），並決定內容的縮放方式。

### 尺寸與座標的單位是什麼？

以點為單位：1 吋等於 72 點。

### 如何處理包含大量媒體檔案的非常大型簡報以減少記憶體使用？

使用[BLOB 管理策略](/slides/zh-hant/cpp/manage-blob/)，藉由使用暫存檔限制記憶體中的儲存，並優先採用基於檔案的工作流程而非純記憶體串流。

### 我可以平行建立/儲存簡報嗎？

您無法在[多執行緒](/slides/zh-hant/cpp/multithreading/)中同時操作同一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 實例。請在每個執行緒或行程中使用獨立的實例。

### 如何移除試用版水印與限制？

[套用授權](/slides/zh-hant/cpp/licensing/)一次即可於整個行程。授權 XML 必須保持未被修改，且若有多執行緒，授權設定應同步化。

### 我可以對所建立的 PPTX 進行數位簽章嗎？

可以。[數位簽章](/slides/zh-hant/cpp/digital-signature-in-powerpoint/)（加入與驗證）在簡報中受支援。

### 在建立的簡報中是否支援巨集 (VBA)？

可以。您可以[建立/編輯 VBA 專案](/slides/zh-hant/cpp/presentation-via-vba/)，並儲存支援巨集的檔案，例如 PPTM/PPSM。