---
title: 使用 JavaScript 自訂簡報中的圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/nodejs-java/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 來自訂圖表圖例，針對 PowerPoint 簡報進行量身訂做的圖例格式化，以提升簡報效果。"
---
## **概述**

Aspose.Slides 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文說明如何設定圖例的位置與大小、設定整個圖例的字型大小，以及對單一圖例項目套用格式。

同時在 FAQ 中也討論了相關行為，包括使用非覆蓋模式讓繪圖區為圖例留出空間、允許長圖例標籤自動換行或使用換行字元，以及在未設定明確文字與填充時讓圖例格式繼承簡報主題。

## **圖例定位**

為了設定圖例屬性，請依照下列步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
- 取得投影片的參考。
- 在投影片上加入圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

在下方示例中，我們已設定圖表圖例的位置與大小。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 取得投影片的參考
    var slide = pres.getSlides().get_Item(0);
    // 在投影片上新增叢集柱狀圖
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // 設定圖例屬性
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // 將簡報寫入磁碟
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定圖例字型大小**

The Aspose.Slides for Node.js via Java 讓開發人員能夠設定圖例的字型大小。請遵循以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定單一圖例項目的字型大小**

The Aspose.Slides for Node.js via Java 讓開發人員能夠設定單一圖例項目的字型大小。請遵循以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 存取圖例項目。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**我可以啟用圖例，使圖表自動為其分配空間而不是覆蓋在上面嗎？**

是。使用非覆蓋模式（[setOverlay(false)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/legend/setoverlay/)）；在此情況下，繪圖區會縮小以容納圖例。

**我可以建立多行的圖例標籤嗎？**

是。當空間不足時，長標籤會自動換行；也支援在系列名稱中使用換行字元強制換行。

**如何讓圖例遵循簡報主題的配色方案？**

不要為圖例或其文字設定明確的顏色、填充或字型。如此一來，它們會繼承自主題，且在設計變更時會正確更新。