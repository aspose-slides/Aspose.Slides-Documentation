---
title: 在 C++ 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/cpp/export-to-html5/
keywords:
- PowerPoint 轉 HTML5
- OpenDocument 轉 HTML5
- 簡報 轉 HTML5
- 投影片 轉 HTML5
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
description: "使用 Aspose.Slides for C++ 將 PowerPoint 與 OpenDocument 簡報匯出為相容行動裝置的 HTML5。保留格式、動畫和互動性。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。它涵蓋了不含 Web 擴充功能或其他相依性的基本 HTML5 匯出，以及控制形狀動畫和投影片過渡的選項。本文亦展示標準的 PowerPoint 轉 HTML 匯出流程，說明如何在投影片檢視模式下產生 HTML5 輸出，並演示如何透過設定版面配置將註解納入匯出的文件中。

## **將 PowerPoint 匯出為 HTML5**

這段 C++ 程式碼示範如何將簡報匯出為 HTML5。

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
在此情況下，您會得到乾淨的 HTML。 
{{% /alert %}}

您可能想要以此方式指定形狀動畫和投影片過渡的設定：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **將 PowerPoint 匯出為 HTML**

這段 C++ 程式碼示範標準的 PowerPoint 轉 HTML 流程：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

在此情況下，簡報內容透過 SVG 以如下形式呈現：

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
當您使用此方法將 PowerPoint 匯出為 HTML 時，由於採用 SVG 轉換，將無法套用樣式或對特定元素進行動畫。 
{{% /alert %}}

## **將 PowerPoint 匯出為 HTML5 投影片檢視**

**Aspose.Slides** 允許您將 PowerPoint 簡報轉換為 HTML5 文件，並以投影片檢視模式呈現投影片。在此情況下，當您在瀏覽器中開啟產生的 HTML5 檔案時，會在網頁上以投影片檢視模式顯示簡報。

這段 C++ 程式碼示範 PowerPoint 轉 HTML5 投影片檢視的匯出流程：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **將簡報轉換為含註解的 HTML5 文件**

PowerPoint 中的註解是一種工具，允許使用者在簡報投影片上留下備註或回饋。它們在協作專案中特別有用，因為多位使用者可以對特定投影片元素添加建議或意見，而不會更改主要內容。每則註解皆顯示作者名稱，方便追蹤誰留下了該評論。

假設我們有一個名為 "sample.pptx" 的 PowerPoint 簡報檔案如下所示。

![簡報投影片上的兩則註解](two_comments_pptx.png)

當您將 PowerPoint 簡報轉換為 HTML5 文件時，您可以輕鬆指定是否在輸出文件中包含簡報的註解。為此，您需要在 [Html5Options](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/) 類別的 `get_NotesCommentsLayouting` 方法中設定註解的顯示參數。

以下程式碼範例將簡報轉換為 HTML5 文件，並將註解顯示於投影片右側。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

圖片下方顯示了 "output.html" 文件的內容。

![輸出 HTML5 文件中的註解](two_comments_html5.png)

## **常見問題**

**我可以控制物件動畫與投影片過渡在 HTML5 中是否播放嗎？**

是的，HTML5 提供了分別的選項，可啟用或停用 [shape animations](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animateshapes/) 與 [slide transitions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

**是否支援輸出註解？它們可以相對於投影片放置在哪裡？**

是的，註解可在 HTML5 中加入，並透過註記與註解的版面設定將其定位（例如放在投影片右側）。

**我可以為了安全性或 CSP 而跳過呼叫 JavaScript 的連結嗎？**

是的，有一個 [setting](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 可在儲存時跳過包含 JavaScript 呼叫的超連結。這有助於遵守嚴格的安全政策。