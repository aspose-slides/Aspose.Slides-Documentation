---
title: 在 JavaScript 中指定預設簡報字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/nodejs-java/default-font/
keywords:
- 預設字型
- 標準字型
- 一般字型
- 亞洲字型
- PDF 匯出
- XPS 匯出
- 圖片匯出
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js（透過 Java）中設定預設字型，以確保 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）正確轉換為 PDF、XPS 與圖片。"
---
## **概述**

Aspose.Slides 允許您指定在投影片呈現時使用的預設字型。這在產生投影片縮圖或將投影片匯出為 PDF、XPS 等格式時非常有用。預設字型須在載入投影片之前透過 `LoadOptions` 進行設定。

`setDefaultRegularFont` 方法定義一般文字的預設字型，而 `setDefaultAsianFont` 定義亞洲文字的預設字型。設定這些選項後，即可載入投影片並使用指定的字型進行呈現。

## **使用預設字型呈現投影片**

Aspose.Slides 讓您設定用於將投影片渲染為 PDF、XPS 或縮圖的預設字型。以下說明如何定義 DefaultRegularFont 與 DefaultAsianFont 作為預設字型。請依照下列步驟，使用 Aspose.Slides for Node.js via Java API 從外部目錄載入字型：

1. 建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LoadOptions) 的實例。  
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 設為您想要的字型。以下範例中，我使用了 Wingdings。  
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 設為您想要的字型。以下範例中，我使用了 Wingdings。  
4. 使用 Presentation 並設定載入選項來載入投影片。  
5. 現在，產生投影片縮圖、PDF 與 XPS 以驗證結果。

```javascript
// 使用載入選項來定義預設的常規字型與亞洲字型
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// 載入簡報
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // 產生投影片縮圖
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // 將影像儲存於磁碟上。
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // 產生 PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // 產生 XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**DefaultRegularFont 和 DefaultAsianFont 具體會影響什麼——僅匯出，還是也會影響縮圖、PDF、XPS、HTML 和 SVG？**  
它們會參與所有支援輸出的渲染流程。這包括投影片縮圖、[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)、[raster images](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)，以及 [SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**在僅讀取並儲存 PPTX 而不進行任何渲染時，會套用預設字型嗎？**  
不會。只有在必須測量與繪製文字時，預設字型才會發揮作用。直接開啟後再儲存投影片不會變更已儲存的字型序列或檔案結構。預設字型會在需要渲染或重新排版文字的操作中使用。

**如果我新增自己的字型資料夾或從記憶體提供字型，選擇預設字型時會考慮它們嗎？**  
會。[Custom font sources](/slides/zh-hant/nodejs-java/custom-font/) 會擴充引擎可使用的字型家族與字形目錄。預設字型以及任何 [fallback rules](/slides/zh-hant/nodejs-java/fallback-font/) 會首先參考這些來源，以在伺服器與容器中提供更可靠的字型覆蓋。

**預設字型會影響文字度量（字距、前進寬度），從而影響換行與自動換列嗎？**  
會。變更字型會改變字形度量，從而影響行斷、換行與分頁。若要版面穩定，請 [embed the original fonts](/slides/zh-hant/nodejs-java/embedded-font/) 或選擇度量相容的預設與備援字型家族。

**如果投影片中使用的所有字型皆已嵌入，設定預設字型還有意義嗎？**  
通常不需要，因為 [embedded fonts](/slides/zh-hant/nodejs-java/embedded-font/) 已確保外觀一致。即便如此，預設字型仍可在嵌入子集未涵蓋的字元或檔案同時混合使用嵌入與未嵌入文字時，作為安全網。