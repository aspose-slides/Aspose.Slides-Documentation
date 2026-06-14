---
title: 取得字型替代的警告回呼
type: docs
weight: 90
url: /zh-hant/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 字型替代
- 渲染過程
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "學習如何在 Aspose.Slides for Java 中取得字型替代的警告回呼，並正確顯示 PowerPoint 與 OpenDocument 簡報。"
---
## **簡介**

Aspose.Slides for Java 允許您在渲染期間當所需字型在機器上不可用時，接收字型替代的警告回呼。這些回呼有助於診斷缺少或無法存取的字型問題。

## **啟用警告回呼**

Aspose.Slides for Java 提供直接的 API，以在呈現投影片時接收警告回呼。請依照以下步驟設定警告回呼：

1. 建立實作 [IWarningCallback](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iwarningcallback/) 介面的自訂回呼類別，以處理警告。
1. 使用如 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/)、[PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/htmloptions/) 等選項類別設定警告回呼。
1. 載入使用目標機器上未安裝字型的簡報。
1. 產生投影片縮圖或匯出簡報，以觀察結果。

**自訂警告回呼類別：**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// 範例輸出:
//
// 字型將從 XYZ 替換為 {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**產生投影片縮圖：**

```java
// 設定警告回呼，以在投影片渲染期間處理與字型相關的警告。
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// 從指定的檔案路徑載入簡報。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 為簡報中的每張投影片產生縮圖影像。
    for (ISlide slide : presentation.getSlides()) {
        // 使用指定的渲染選項取得投影片縮圖影像。
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**匯出為 PDF 格式：**

```java
// 設定警告回呼，以在 PDF 匯出期間處理與字型相關的警告。
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// 從指定的檔案路徑載入簡報。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 將簡報匯出為 PDF。
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**匯出為 HTML 格式：**

```java
// 設定警告回呼，以在 HTML 匯出期間處理與字型相關的警告。
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// 從指定的檔案路徑載入簡報。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 將簡報匯出為 HTML 格式。
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```