---
title: 在 C++ 中指定預設投影片字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/cpp/default-font/
keywords:
- 預設字型
- 常規字型
- 正常字型
- 亞洲字型
- PDF 匯出
- XPS 匯出
- 圖像匯出
- PowerPoint
- OpenDocument
- 投影片
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中設定預設字型，以確保 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 正確轉換為 PDF、XPS 以及圖像。"
---
## **概述**

Aspose.Slides 允許您指定在呈現投影片時使用的預設字型。這在產生投影片縮圖或將投影片匯出為 PDF 與 XPS 等格式時非常有用。預設字型是在載入投影片之前透過 `LoadOptions` 進行設定的。

`set_DefaultRegularFont` 方法定義一般文字的預設字型，而 `set_DefaultAsianFont` 方法定義亞洲文字的預設字型。設定這些選項後，即可載入投影片並使用指定的字型進行呈現。

## **使用預設字型呈現投影片**
Aspose.Slides 讓您能設定在將投影片呈現為 PDF、XPS 或縮圖時使用的預設字型。本文說明如何定義 DefaultRegularFont 與 DefaultAsianFont 作為預設字型。請依照以下步驟，使用 Aspose.Slides for C++ API 從外部目錄載入字型：

1. 建立 `LoadOptions` 的實例。
1. 將 `DefaultRegularFont` 設為您想要的字型。以下範例使用 Wingdings。
1. 將 `DefaultAsianFont` 設為您想要的字型。以下範例同樣使用 Wingdings。
1. 使用 `Presentation` 並設定載入選項來載入投影片。
1. 產生投影片縮圖、PDF 與 XPS 以驗證結果。

上述實作範例見下方。

```cpp
// 使用載入選項指定預設的常規字型與亞洲字型
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **常見問題**

**預設的 DefaultRegularFont 與 DefaultAsianFont 具體會影響什麼──僅匯出，還是也會影響縮圖、PDF、XPS、HTML 與 SVG？**

它們參與所有受支援輸出之呈現管線。這包括投影片縮圖、[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)、[光柵影像](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**僅讀取並儲存 PPTX 而未進行任何呈現時，會套用預設字型嗎？**

不會。當需要測量與繪製文字時，預設字型才會發揮作用。直接開啟後儲存投影片不會改變已儲存的字型串或檔案結構。預設字型僅在執行呈現或重新排版文字的操作時才會介入。

**如果我加入自訂字型資料夾或從記憶體提供字型，系統在選擇預設字型時會考慮它們嗎？**

會。[自訂字型來源](/slides/zh-hant/cpp/custom-font/) 會擴充引擎可使用的字型家族與字形目錄。預設字型與任何 [fallback 規則](/slides/zh-hant/cpp/fallback-font/) 會先對這些來源進行解析，從而在伺服器與容器環境中提供更可靠的覆蓋。

**預設字型會影響文字度量（字距、前進寬度），進而影響換行與自動換列嗎？**

會。更換字型會改變字形度量，可能在呈現時導致換行、折行與分頁的變化。若需版面穩定，請 [內嵌原始字型](/slides/zh-hant/cpp/embedded-font/) 或選擇在度量上相容的預設與備援字型家族。

**如果投影片中使用的所有字型皆已內嵌，設定預設字型仍有意義嗎？**

通常不需要，因為 [內嵌字型](/slides/zh-hant/cpp/embedded-font/) 已能確保外觀一致。預設字型仍可作為安全網，防止未被內嵌子集覆蓋的字元，或在檔案同時包含內嵌與未內嵌文字時發揮作用。