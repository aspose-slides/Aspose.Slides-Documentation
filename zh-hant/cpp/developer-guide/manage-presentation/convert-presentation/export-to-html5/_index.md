---
title: 在 C++ 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/cpp/export-to-html5/
keywords:
- PowerPoint 轉換為 HTML5
- OpenDocument 轉換為 HTML5
- 簡報 轉換為 HTML5
- 投影片 轉換為 HTML5
- PPT 轉換為 HTML5
- PPTX 轉換為 HTML5
- ODP 轉換為 HTML5
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
## **概述**

本文說明如何使用 Aspose.Slides for C++ 將 PowerPoint 簡報轉換為 HTML5。它涵蓋了基本匯出、形狀動畫與投影片過渡的控制，以及註解版面配置。還比較了 HTML5 輸出與標準 HTML 匯出的 SVG 基礎輸出。

## **匯出 PowerPoint 為 HTML5**

以下示例從工作目錄載入簡報，並將其保存為 HTML5 格式。它使用預設的匯出設定；下一個示例說明如何明確控制動畫播放。請將輸入路徑替換為您的簡報路徑。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
除了 HTML 文件外，匯出還會寫入支援的 CSS 與 JavaScript 檔案，用於投影片樣式、動畫、效果與導覽。將這些檔案與 HTML 文件一起保存，以便在移動或發布輸出時使用。產生的頁面也會從公共 CDN 載入 jQuery 與 Anime.js；若未載入，投影片的導覽與動畫將無法運作。
{{% /alert %}}

要在匯出時不播放形狀動畫或投影片過渡，請在 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 中將 `false` 傳遞給 [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)。這些設定是獨立的，您可以啟用其中一項而停用另一項。此示例將兩種動畫均停用後匯出簡報。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **匯出 PowerPoint 為 HTML**

標準的 HTML 匯出使用不同的呈現方式：投影片內容以 SVG 形式嵌入 HTML 頁面。以下示例使用此呈現方式將簡報轉換為 HTML 文件。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

以下簡化的標記示範產生頁面的結構。SVG 元素包含已呈現的投影片內容；佔位文字僅代表該內容，並非實際匯出輸出。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
基於 SVG 的匯出不會將 PowerPoint 形狀呈現為個別的 HTML 元素。當您需要本文示範的形狀動畫與投影片過渡選項時，請使用 HTML5 匯出。
{{% /alert %}}

## **匯出 PowerPoint 為 HTML5 投影片檢視**

HTML5 匯出會產生可在瀏覽器中檢視與導覽簡報投影片的頁面。此示例將 `true` 傳遞給 [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 與 [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)，使匯出的投影片檢視能播放來源簡報的效果。請使用已包含形狀動畫與投影片過渡的簡報以觀察這些設定的效果。啟用它們不會為沒有任何效果的投影片新增動畫。匯出後，於瀏覽器開啟產生的 HTML5 文件，並確保其支援檔案可用。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **將簡報轉換為帶有註解的 HTML5 文件**

您可以在 HTML5 輸出中納入現有投影片註解，讓讀者能在投影片內容旁看到回饋。此節的示例假設來源簡報已包含註解，如下圖所示。它會匯出這些註解；不會建立新註解。

![投影片上的兩則註解](two_comments_pptx.png)

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 物件傳遞給 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 的 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) 方法。呼叫 [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/)，並使用來自 [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) 列舉的 `CommentsPositions::Right`，將註解置於每張投影片的右側。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

下圖顯示匯出的 HTML5 文件，註解顯示在投影片旁邊。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **匯出時排除 JavaScript 超連結**

假設 `hyperlinks.pptx` 包含指向 `javascript:alert('Hello')` 的文字連結，以及一般的 `https://example.com/` 連結。若要在匯出時排除 JavaScript 超連結，請以 `true` 呼叫 [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/)。預設為 `false`，因此除非啟用此選項，這類連結不會被過濾。

以下示例從工作目錄載入簡報，並以 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 匯出：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

匯出的檔案會省略 JavaScript 超連結，同時保留其文字與一般的 HTTPS 連結。來源簡報保持不變。

此選項僅過濾 JavaScript 超連結；它不會移除所有腳本或其他主動內容，也不保證符合 CSP。舉例而言，HTML5 輸出仍會包含用於投影片導覽與動畫的腳本。

## **常見問題**

**我能控制物件動畫與投影片過渡在 HTML5 中是否播放嗎？**

是的，HTML5 匯出提供單獨的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 與 [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

**是否支援註解，且可以將它們放置在投影片的何處？**

是的，現有的註解可以包含在 HTML5 輸出中，並可透過 [版面設定](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/)（例如放在投影片右側）來設定其位置。

**我能為安全或 CSP 考量而跳過呼叫 JavaScript 的連結嗎？**

是的，使用 [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 方法可在儲存時跳過含 JavaScript 呼叫的超連結。預設為 `false`。請參考 [匯出時排除 JavaScript 超連結](/slides/zh-hant/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) 以取得 HTML5 匯出範例與過濾範圍說明。此設定不會移除 HTML5 檢視器用於導覽與動畫的 JavaScript。