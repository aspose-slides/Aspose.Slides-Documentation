---
title: 在 C++ 中將簡報轉換為 HTML5
linktitle: 簡報轉 HTML5
type: docs
weight: 40
url: /zh-hant/cpp/export-to-html5/
keywords:
- PowerPoint 轉 HTML5
- OpenDocument 轉 HTML5
- 簡報轉 HTML5
- 投影片轉 HTML5
- PPT 轉 HTML5
- PPTX 轉 HTML5
- ODP 轉 HTML5
- 將 PPT 儲存為 HTML5
- 將 PPTX 儲存為 HTML5
- 將 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋了不含網路擴充或額外相依性的基本 HTML5 匯出，以及控制形狀動畫和投影片轉場的選項。本文還展示了標準的 PowerPoint 轉 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並示範如何透過設定其版面配置將評論包含在匯出文件中。

## **匯出 PowerPoint 為 HTML5**

此 C++ 程式碼示範如何將簡報匯出為 HTML5。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
在此情況下，您會取得乾淨的 HTML。 
{{% /alert %}}

您可能想以此方式指定形狀動畫和投影片轉場的設定：

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **匯出 PowerPoint 為 HTML**

此 C++ 示例說明標準的 PowerPoint 轉 HTML 流程：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

在此情況下，簡報內容會透過 SVG 以如下形式呈現：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
當您使用此方法將 PowerPoint 匯出為 HTML 時，因為使用 SVG 渲染，將無法套用樣式或對特定元素進行動畫。 
{{% /alert %}}

## **匯出 PowerPoint 為 HTML5 投影片檢視**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式呈現簡報。此時，當您在瀏覽器中開啟產生的 HTML5 檔案時，會在網頁上以投影片檢視模式看到簡報。

此 C++ 程式碼示範 PowerPoint 轉 HTML5 投影片檢視的匯出流程：

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **將簡報轉換為含評論的 HTML5 文件**

PowerPoint 中的評論是一種工具，允許使用者在簡報投影片上留下備註或回饋。它在協同專案中特別有用，因為多位使用者可以對特定投影片元素添加建議或意見，而不會改變主要內容。每則評論都會顯示作者名稱，便於追蹤誰留下了該備註。

假設我們有以下儲存在「sample.pptx」檔案中的 PowerPoint 簡報。

![簡報投影片上的兩則評論](two_comments_pptx.png)

將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的評論。為此，需在 [Html5Options](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/) 類別的 `get_NotesCommentsLayouting` 方法中指定評論的顯示參數。

以下程式碼示例將簡報轉換為 HTML5 文件，並將評論顯示在投影片的右側。
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

下圖顯示了「output.html」文件。

![輸出 HTML5 文件中的評論](two_comments_html5.png)

## **常見問題**

### 我能控制物件動畫和投影片轉場在 HTML5 中是否播放嗎？

是的，HTML5 提供獨立的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

### HTML5 支援輸出評論嗎？它們相對於投影片可以放置在哪裡？

是的，HTML5 可以加入評論，並可透過備註與評論的版面配置設定將其定位（例如放在投影片右側）。

### 我能因為安全性或 CSP 原因而跳過呼叫 JavaScript 的連結嗎？

是的，有一個 [設定](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 可在儲存時跳過包含 JavaScript 呼叫的超連結。此功能有助於符合嚴格的安全政策。