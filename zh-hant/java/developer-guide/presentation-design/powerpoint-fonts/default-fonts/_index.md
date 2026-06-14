---
title: 在 Java 中指定預設簡報字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/java/default-font/
keywords:
- 預設字型
- 常規字型
- 一般字型
- 亞洲字型
- PDF 匯出
- XPS 匯出
- 影像匯出
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中設定預設字型，以確保 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 正確轉換為 PDF、XPS 與影像。"
---
## **概觀**

Aspose.Slides 允許您指定在呈現簡報時使用的預設字型。這在產生投影片縮圖或將簡報匯出為 PDF 與 XPS 等格式時非常有用。預設字型須在載入簡報之前，透過 `LoadOptions` 進行設定。

`setDefaultRegularFont` 方法定義一般文字的預設字型，而 `setDefaultAsianFont` 方法定義亞洲文字的預設字型。設定這些選項之後，即可載入簡報並使用指定的字型進行呈現。

## **使用預設字型來呈現簡報**

Aspose.Slides 允許您設定將簡報呈現為 PDF、XPS 或縮圖時的預設字型。本文說明如何定義 DefaultRegularFont 與 DefaultAsianFont 以作為預設字型。請依照以下步驟，使用 Aspose.Slides for Java API 從外部目錄載入字型：

1. 建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LoadOptions)的實例。
2. [設定 DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-)為您想要的字型。以下範例中，我使用了 Wingdings。
3. [設定 DefaultAsianFont](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-)為您想要的字型。以下範例中，我使用了 Wingdings。
4. 使用 Presentation 並設定載入選項來載入簡報。
5. 現在，產生投影片縮圖、PDF 與 XPS 以驗證結果。

上述實作示例如下。

```java
// 使用載入選項定義預設的常規字型與亞洲字型
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// 載入簡報
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

## **常見問題**

**DefaultRegularFont 和 DefaultAsianFont 完全會影響什麼——僅匯出，還是也包括縮圖、PDF、XPS、HTML 與 SVG？**

它們會參與所有支援輸出的渲染流程。這包括投影片縮圖、[PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/)、[點陣圖](/slides/zh-hant/java/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)、以及[SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**僅讀取並儲存 PPTX 而未進行任何渲染時，會套用預設字型嗎？**

不會。預設字型僅在必須測量與繪製文字時才會起作用。直接開啟後儲存簡報不會更改儲存的字型資料或檔案結構。預設字型會在需要渲染或重新排版文字的操作中發揮作用。

**如果我加入自己的字型資料夾或從記憶體提供字型，選擇預設字型時會考慮它們嗎？**

會。[自訂字型來源](/slides/zh-hant/java/custom-font/) 會擴充引擎可使用的字型族與字形目錄。預設字型以及任何[備援規則](/slides/zh-hant/java/fallback-font/) 會首先對這些來源進行解析，從而在伺服器與容器中提供更可靠的覆蓋率。

**預設字型會影響文字度量（字距、前進寬度），進而影響換行與自動換行嗎？**

會。更換字型會改變字形度量，從而在渲染過程中影響換行、 自動換行與分頁。為了版面穩定，請[嵌入原始字型](/slides/zh-hant/java/embedded-font/) 或選擇度量相容的預設與備援字型族。

**如果簡報中使用的所有字型都已嵌入，設定預設字型還有意義嗎？**

通常不需要，因為[嵌入字型](/slides/zh-hant/java/embedded-font/) 已能確保外觀一致。預設字型仍可作為備援，防止嵌入子集未涵蓋的字元，或在檔案同時包含嵌入與未嵌入文字時提供保險。