---
title: 在 Android 上指定預設投影片字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "透過 Java 為 Android 上的 Aspose.Slides 設定預設字型，以確保 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 正確轉換為 PDF、XPS 及圖像。"
---
## **概述**

Aspose.Slides 允許您指定在投影片呈現時使用的預設字型。這在產生投影片縮圖或將投影片匯出為 PDF、XPS 等格式時非常有用。預設字型須透過 `LoadOptions` 在載入投影片之前進行設定。

`setDefaultRegularFont` 方法定義一般文字的預設字型，而 `setDefaultAsianFont` 定義亞洲文字的預設字型。設定這些選項之後，即可載入投影片並使用指定的字型進行呈現。

## **使用預設字型呈現投影片**

Aspose.Slides 允許您設定在將投影片呈現為 PDF、XPS 或縮圖時使用的預設字型。本文說明如何定義 DefaultRegularFont 與 DefaultAsianFont 以作為預設字型。請依照以下步驟，使用 Aspose.Slides for Android 透過 Java API 從外部目錄載入字型：

1. 建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LoadOptions) 的實例。
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 設為您想要的字型。在以下範例中，我使用了 Wingdings。
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 設為您想要的字型。我在以下示例中使用了 Wingdings。
1. 使用 Presentation 並設定載入選項載入投影片。
1. 現在，產生投影片縮圖、PDF 與 XPS 以驗證結果。

以下示範上述實作方式。

```java
// 使用載入選項來定義預設的正文字型與亞洲字型
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // 產生投影片縮圖
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // 將影像儲存至磁碟。
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // 產生 PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // 產生 XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**DefaultRegularFont 與 DefaultAsianFont 具體會影響什麼——僅匯出，或同時影響縮圖、PDF、XPS、HTML 與 SVG？**  
它們會參與所有支援輸出的呈現管線。這包括投影片縮圖、[PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/)、[點陣圖](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**在僅讀取並儲存 PPTX 而不進行任何呈現時，會套用預設字型嗎？**  
不會。當必須測量並繪製文字時，預設字型才會發揮作用。直接開啟後再儲存投影片不會改變儲存的字型資訊或檔案結構。預設字型僅在需要呈現或重新排版文字的操作中使用。

**如果我新增自己的字型資料夾或從記憶體提供字型，系統在選取預設字型時會考慮它們嗎？**  
會。[自訂字型來源](/slides/zh-hant/androidjava/custom-font/) 會擴充引擎可使用的字族與字形目錄。預設字型與任何 [備援規則](/slides/zh-hant/androidjava/fallback-font/) 會先對這些來源進行解析，從而在伺服器與容器環境中提供更可靠的字型覆蓋。

**預設字型會影響文字度量（字距、前進寬度），進而影響斷行與換行嗎？**  
會。變更字型會改變字形度量，從而在呈現時影響斷行、換行與分頁。為確保版面穩定，請 [嵌入原始字型](/slides/zh-hant/androidjava/embedded-font/) 或選擇在度量上相容的預設與備援字族。

**如果投影片中使用的所有字型皆已嵌入，設定預設字型還有意義嗎？**  
通常沒有必要，因為 [嵌入字型](/slides/zh-hant/androidjava/embedded-font/) 已能確保外觀一致。但預設字型仍可作為備援，針對嵌入子集未涵蓋的字元，或檔案同時混合了嵌入與未嵌入的文字時提供保險。