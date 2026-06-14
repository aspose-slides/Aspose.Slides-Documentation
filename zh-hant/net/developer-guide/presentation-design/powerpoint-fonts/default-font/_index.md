---
title: 在 .NET 中指定預設簡報字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/net/default-font/
keywords:
- 預設字型
- 常規字型
- 普通字型
- 亞洲字型
- PDF 匯出
- XPS 匯出
- 影像匯出
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中設定預設字型，以確保 PowerPoint (PPT、PPTX) 和 OpenDocument (ODP) 正確轉換為 PDF、XPS 以及影像。"
---
## **概述**

Aspose.Slides 允許您指定在呈現簡報時使用的預設字型。這在產生投影片縮圖或將簡報匯出為 PDF、XPS 等格式時非常有用。預設字型需在載入簡報前透過 `LoadOptions` 進行設定。

`DefaultRegularFont` 屬性定義一般文字的預設字型，而 `DefaultAsianFont` 定義亞洲文字的預設字型。設定這些選項後，即可載入簡報並使用指定的字型進行渲染。

## **在渲染簡報時使用預設字型**
Aspose.Slides 讓您設定在將簡報渲染為 PDF、XPS 或縮圖時的預設字型。本文說明如何定義 DefaultRegularFont 與 DefaultAsianFont 作為預設字型。請依照以下步驟，使用 Aspose.Slides for .NET API 從外部目錄載入字型：

1. 建立 LoadOptions 的實例。  
1. 將 DefaultRegularFont 設為您想要的字型。在以下示例中，我使用了 Wingdings。  
1. 将 DefaultAsianFont 設為您想要的字型。以下範例中我使用了 Wingdings。  
1. 使用 Presentation 並設定載入選項來載入簡報。  
1. 現在，產生投影片縮圖、PDF 與 XPS，以驗證結果。

上述實作如下所示。

```c#
// 使用載入選項來指定預設的常規字型和亞洲字型
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **常見問題**

**DefaultRegularFont 與 DefaultAsianFont 具體會影響什麼——僅匯出，還是包括縮圖、PDF、XPS、HTML 與 SVG？**

他們會參與所有支援輸出的渲染管線，包括投影片縮圖、[PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)、[點陣圖](/slides/zh-hant/net/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字型解析邏輯。

**在僅讀取並保存 PPTX 而不執行任何渲染時，會套用預設字型嗎？**

否。只有在需要測量與繪製文字時，預設字型才會生效。單純的開啟後立即保存簡報不會更改儲存的字型區段或檔案結構。預設字型會在執行渲染或重新排版文字的操作時介入。

**如果我新增自訂字型資料夾或從記憶體提供字型，系統在選擇預設字型時會考慮它們嗎？**

會。[自訂字型來源](/slides/zh-hant/net/custom-font/) 會擴充引擎可使用的字型族與字形目錄。預設字型和任何 [備援規則](/slides/zh-hant/net/fallback-font/) 會優先對這些來源進行解析，從而在伺服器與容器中提供更可靠的字型覆蓋。

**預設字型會影響文字度量（字距、前進值），進而影響換行與自動換行嗎？**

會。變更字型會改變字形度量，進而在渲染時改變換行、換行方式與分頁。為了版面穩定，請[嵌入原始字型](/slides/zh-hant/net/embedded-font/)或選擇度量相容的預設與備援字型族。

**如果簡報中使用的所有字型皆已嵌入，設定預設字型還有意義嗎？**

通常沒有必要，因為[嵌入字型](/slides/zh-hant/net/embedded-font/)已能確保外觀一致。預設字型仍可作為備援，針對嵌入子集未涵蓋的字元或檔案同時混用嵌入與未嵌入文字的情況。