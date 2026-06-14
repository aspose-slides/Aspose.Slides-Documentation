---
title: 在 C++ 中指定預設簡報字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/cpp/default-font/
keywords:
- 預設字型
- 一般字型
- 正常字型
- 亞洲字型
- PDF 匯出
- XPS 匯出
- 影像匯出
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中設定預設字型，以確保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正確轉換為 PDF、XPS 和影像。"
---
## **概觀**

Aspose.Slides 允許您指定在呈現簡報時使用的預設字型。這在產生投影片縮圖或將簡報匯出為 PDF、XPS 等格式時非常有用。預設字型可透過 `LoadOptions` 在載入簡報之前進行設定。

`set_DefaultRegularFont` 方法定義一般文字的預設字型，而 `set_DefaultAsianFont` 定義亞洲文字的預設字型。設定這些選項後，即可使用指定的字型載入並呈現簡報。

## **使用預設字型來呈現簡報**
Aspose.Slides 讓您可以設定在將簡報轉換成 PDF、XPS 或縮圖時使用的預設字型。本文說明如何為 DefaultRegularFont 與 DefaultAsianFont 設定預設字型。請依照以下步驟，使用 Aspose.Slides for C++ API 從外部目錄載入字型：

1. 建立 `LoadOptions` 的實例。  
1. 將 `DefaultRegularFont` 設為您想要的字型。以下範例使用 Wingdings。  
1. 將 `DefaultAsianFont` 設為您想要的字型。以下範例同樣使用 Wingdings。  
1. 使用 `Presentation` 並設定載入選項來載入簡報。  
1. 產生投影片縮圖、PDF 與 XPS，以驗證結果。

上述實作範例如下。

```cpp
// 使用載入選項來指定預設一般與亞洲字型
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

**DefaultRegularFont 與 DefaultAsianFont 影響的範圍是什麼——僅限匯出，還是也包括縮圖、PDF、XPS、HTML 與 SVG？**

它們會參與所有支援輸出的渲染管線。這包括投影片縮圖、[PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)、[點陣圖](/slides/zh-hant/cpp/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**僅讀取並儲存 PPTX 而不進行任何渲染時，會套用預設字型嗎？**

不會。只有在需要測量與繪製文字時，預設字型才會生效。單純的開啟‑儲存不會更改已儲存的字型串或檔案結構。預設字型僅在執行渲染或重新排版文字的操作時發揮作用。

**如果我新增自己的字型資料夾或從記憶體提供字型，系統在選擇預設字型時會考慮這些來源嗎？**

會。[自訂字型來源](/slides/zh-hant/cpp/custom-font/) 會擴充可用字型系列與字形的目錄。預設字型與任何 [備援規則](/slides/zh-hant/cpp/fallback-font/) 會先對這些來源進行解析，從而在伺服器與容器環境中提供更可靠的覆蓋。

**預設字型會影響文字度量（字距、前進寬度），進而改變換行與自動換列嗎？**

會。變更字型會改變字形度量，從而在渲染過程中影響換行、換列與分頁。為了版面穩定性，請 [嵌入原始字型](/slides/zh-hant/cpp/embedded-font/) 或選擇度量相容的預設與備援字型系列。

**如果簡報中所有字型皆已嵌入，設定預設字型還有意義嗎？**

通常不需要，因為 [嵌入字型](/slides/zh-hant/cpp/embedded-font/) 已確保外觀一致。預設字型仍可作為保險措施，處理嵌入子集未涵蓋的字元，或在檔案同時混用嵌入與未嵌入文字時提供支援。