---
title: 在 Python via Java 中指定預設簡報字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中設定預設字型，以確保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正確轉換為 PDF、XPS 以及影像。"
---
## **概覽**

Aspose.Slides 允許您指定在渲染簡報時使用的預設字型。這在產生投影片縮圖或將簡報匯出為 PDF、XPS 等格式時非常有用。預設字型可於載入簡報之前透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 進行設定。

[setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) 方法定義一般文字的預設字型，而 [setDefaultAsianFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) 定義亞洲文字的預設字型。設定這些選項後，即可使用指定的字型載入並渲染簡報。

## **使用預設字型來渲染簡報**

Aspose.Slides 讓您可以為渲染 PDF、XPS 或縮圖時設定預設字型。本節說明如何使用 Aspose.Slides for Python via Java 為一般文字與亞洲文字設定預設字型：

1. 建立一個 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/) 的實例。  
1. 使用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) 指定您想要的字型。以下範例使用 Wingdings。  
1. 使用 [setDefaultAsianFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) 指定您想要的字型。以下範例同樣使用 Wingdings。  
1. 使用帶有載入選項的 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 來載入簡報。  
1. 產生投影片縮圖、PDF 與 XPS 以驗證結果。

以下範例實作上述步驟：

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# 使用載入選項定義預設的一般字型與亞洲字型。
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# 載入簡報。
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # 產生投影片縮圖。
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 將影像儲存到磁碟。
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # 產生 PDF。
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # 產生 XPS 文件。
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **常見問題**

**預設的一般字型與亞洲字型究竟會影響什麼？僅限匯出，還是也會作用於縮圖、PDF、XPS、HTML 與 SVG？**

它們會參與所有支援輸出的渲染流程，包括投影片縮圖、[PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/)、[光柵影像](/slides/zh-hant/python-java/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**在僅僅讀取並儲存 PPTX 而不進行任何渲染時，會套用預設字型嗎？**

不會。預設字型僅在需要測量與繪製文字時才會生效。直接開啟‑儲存簡報不會改變儲存的字型資訊或檔案結構。預設字型會在執行需要渲染或重新排版文字的操作時才會發揮作用。

**如果我新增自己的字型資料夾或從記憶體提供字型，這些會在選擇預設字型時被考慮嗎？**

會。[自訂字型來源](/slides/zh-hant/python-java/custom-font/) 會擴充引擎可使用的字型家族與字形目錄。預設字型與任何 [備援規則](/slides/zh-hant/python-java/fallback-font/) 會首先對這些來源進行解析，從而在伺服器與容器環境中提供更可靠的覆蓋。

**預設字型會影響文字度量（字距、前進寬度），進而影響換行與折行嗎？**

會。更改字型會改變字形度量，可能在渲染時導致換行、折行以及分頁的變化。為了版面穩定，建議 [嵌入原始字型](/slides/zh-hant/python-java/embedded-font/) 或選擇度量兼容的預設與備援字型家族。

**如果簡報中的所有字型都已嵌入，設定預設字型還有意義嗎？**

通常不需要，因為 [嵌入字型](/slides/zh-hant/python-java/embedded-font/) 已確保外觀一致。然而，預設字型仍可作為安全網，處理嵌入子集未涵蓋的字元，或當檔案同時包含嵌入與未嵌入的文字時提供備援。