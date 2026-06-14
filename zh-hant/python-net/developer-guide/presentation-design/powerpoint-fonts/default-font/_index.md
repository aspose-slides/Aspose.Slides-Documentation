---
title: 使用 Python 自訂簡報的預設字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/python-net/default-font/
keywords:
- 預設字型
- 普通字型
- 正常字型
- 亞洲字型
- PDF 匯出
- XPS 匯出
- 影像匯出
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python 中設定預設字型，以確保 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 正確轉換為 PDF、XPS 與影像。"
---
## **概覽**

Aspose.Slides 允許您指定在呈現簡報時使用的預設字型。這在產生投影片縮圖或將簡報匯出為 PDF、XPS 等格式時非常有用。預設字型必須在載入簡報之前透過 `LoadOptions` 進行設定。

`default_regular_font` 屬性定義了普通文字的預設字型，而 `default_asian_font` 定義了亞洲文字的預設字型。設定這些選項後，即可載入簡報並使用指定的字型進行渲染。

## **使用預設字型來渲染簡報**
Aspose.Slides 讓您可以設定在將簡報渲染為 PDF、XPS 或縮圖時使用的預設字型。本文說明如何定義 DefaultRegularFont 與 DefaultAsianFont 作為預設字型。請依照下列步驟，使用 Aspose.Slides for Python via .NET API 從外部目錄載入字型：

1. 建立 `LoadOptions` 的實例。  
1. 將 `DefaultRegularFont` 設為您想要的字型。例如以下示例使用 Wingdings。  
1. 將 `DefaultAsianFont` 設為您想要的字型。以下範例亦使用 Wingdings。  
1. 使用 `Presentation` 並設定載入選項來載入簡報。  
1. 產生投影片縮圖、PDF 與 XPS，以驗證結果。  

上述實作範例顯示如下。

```py
import aspose.slides as slides

# 使用載入選項定義預設的常規字型和亞洲字型# 使用載入選項定義預設的常規字型和亞洲字型
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# 載入簡報
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # 產生投影片縮圖
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # 產生 PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # 產生 XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **常見問題**

**default_regular_font 與 default_asian_font 究竟會影響什麼——僅匯出，還是同時影響縮圖、PDF、XPS、HTML 與 SVG？**  
它們會參與所有支援輸出的渲染流程。這包括投影片縮圖、[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/)、[光柵影像](/slides/zh-hant/python-net/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)、以及[SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**在僅讀取並儲存 PPTX 而不進行任何渲染時，會套用預設字型嗎？**  
不會。預設字型僅在需要測量與繪製文字時才會生效。直接開啟後再儲存簡報不會更改儲存的字型資訊或檔案結構。預設字型會在執行渲染或重新排版文字的操作時介入。

**如果我加入自訂字型資料夾或從記憶體提供字型，系統在選擇預設字型時會考慮它們嗎？**  
會。 [自訂字型來源](/slides/zh-hant/python-net/custom-font/) 會擴充引擎可使用的字型家族與字形目錄。預設字型以及任何 [備援規則](/slides/zh-hant/python-net/fallback-font/) 會首先對這些來源進行解析，從而在伺服器與容器環境中提供更可靠的字型覆蓋。

**預設字型會影響文字度量（字距、前進寬度）從而影響斷行與換行嗎？**  
會。更換字型會改變字形度量，可能在渲染過程中改變斷行、換行與分頁。為了版面穩定，請 [嵌入原始字型](/slides/zh-hant/python-net/embedded-font/) 或選擇在度量上相容的預設與備援字型族。

**如果簡報中使用的所有字型皆已嵌入，設定預設字型還有意義嗎？**  
通常沒有必要，因為 [嵌入字型](/slides/zh-hant/python-net/embedded-font/) 已能確保外觀一致。預設字型仍可作為保險措施，針對嵌入子集未涵蓋的字元或檔案同時包含嵌入與未嵌入文字的情況。