---
title: 在 PHP 中指定預設簡報字型
linktitle: 預設字型
type: docs
weight: 30
url: /zh-hant/php-java/default-font/
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中設定預設字型，以確保 PowerPoint (PPT, PPTX) 與 OpenDocument (ODP) 正確轉換為 PDF、XPS 與影像。"
---
## **概述**

Aspose.Slides 允許您指定在呈現簡報時使用的預設字型。這在產生投影片縮圖或將簡報匯出為 PDF、XPS 等格式時非常有用。預設字型在載入簡報之前透過 `LoadOptions` 進行設定。

`setDefaultRegularFont` 方法定義一般文字的預設字型，而 `setDefaultAsianFont` 定義亞洲文字的預設字型。設定好這些選項後，即可載入簡報並使用指定的字型進行渲染。

## **使用預設字型呈現簡報**
Aspose.Slides 讓您在將簡報渲染為 PDF、XPS 或縮圖時設定預設字型。本文說明如何為 DefaultRegularFont 與 DefaultAsianFont 設定預設字型。請依照以下步驟，使用 Aspose.Slides for PHP via Java API 從外部目錄載入字型：

1. 建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LoadOptions) 的實例。
2. [設定 DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 為您想要的字型。以下範例使用 Wingdings。
3. [設定 DefaultAsianFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 為您想要的字型。以下示例同樣使用 Wingdings。
4. 使用 Presentation 並套用載入選項來載入簡報。
5. 現在產生投影片縮圖、PDF 與 XPS 以驗證結果。

上述實作範例如下。

```php
  # 使用載入選項定義預設的常規字型與亞洲字型
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # 載入簡報
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # 產生投影片縮圖
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # 在磁碟上儲存影像。
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 產生 PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # 產生 XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**DefaultRegularFont 與 DefaultAsianFont 具體會影響什麼？僅限匯出，還是也會影響縮圖、PDF、XPS、HTML 與 SVG？**

它們會參與所有支援輸出的渲染流程。包括投影片縮圖、[PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)、[點陣圖](/slides/zh-hant/php-java/convert-powerpoint-to-png/)、[HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)、以及 [SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/)，因為 Aspose.Slides 在這些目標上使用相同的版面配置與字形解析邏輯。

**僅讀取並儲存 PPTX 而不進行任何渲染時，會套用預設字型嗎？**

不會。預設字型僅在需要測量與繪製文字時才會生效。直接開啟再儲存簡報不會改變已儲存的字型資訊或檔案結構。預設字型會在執行渲染或重新排版文字的操作時才會發揮作用。

**如果我新增自己的字型資料夾或從記憶體提供字型，挑選預設字型時會考慮這些來源嗎？**

會。 [自訂字型來源](/slides/zh-hant/php-java/custom-font/) 可擴充引擎可使用的字型家族與字形。預設字型與任何 [備援規則](/slides/zh-hant/php-java/fallback-font/) 會首先對這些來源進行解析，在伺服器或容器環境中提供更可靠的覆蓋。

**預設字型會影響文字度量（字距、前進寬度），進而影響換行與折行嗎？**

會。字型變更會改變字形度量，從而在渲染時影響換行、折行與分頁。若需版面穩定，請 [嵌入原始字型](/slides/zh-hant/php-java/embedded-font/) 或選擇在度量上相容的預設與備援字型家族。

**如果簡報中使用的所有字型都已嵌入，設定預設字型還有意義嗎？**

通常沒有必要，因為 [嵌入字型](/slides/zh-hant/php-java/embedded-font/) 已確保外觀一致。預設字型仍可作為安全網，針對嵌入子集未涵蓋的字元或檔案同時包含嵌入與未嵌入文字的情況提供保障。