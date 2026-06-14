---
title: 在 JavaScript 中將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- 動畫 GIF
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 GIF
- 簡報 轉 GIF
- 投影片 轉 GIF
- PPT 轉 GIF
- PPTX 轉 GIF
- 將 PPT 儲存為 GIF
- 將 PPTX 儲存為 GIF
- 将 PPT 匯出為 GIF
- 将 PPTX 匯出為 GIF
- 預設 設定
- 自訂 設定
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "輕鬆在 JavaScript 中使用 Aspose.Slides for Node.js（透過 Java）將 PowerPoint 簡報（PPT、PPTX）轉換為動畫 GIF。快速且高品質的結果。"
---
## **概述**

Aspose.Slides 允許您僅透過幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量且廣受支援的動畫格式分享投影片內容，並將其嵌入網頁、即時通訊或文件中時，這項功能十分實用。本文說明如何使用預設設定將簡報匯出為 GIF，以及如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/gifoptions/) 設定框架大小、投影片延遲與轉場影格率等參數自訂輸出。

## **使用預設設定將簡報轉換為動畫 GIF**

以下 JavaScript 範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

動畫 GIF 會使用預設參數建立。

{{%  alert  title="TIP"  color="primary"  %}} 

如果您想自訂 GIF 的參數，可使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/GifOptions) 類別。請參考下方範例程式碼。

{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

以下範例程式碼示範如何在 JavaScript 中使用自訂設定將簡報轉換為動畫 GIF：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// 產生的 GIF 大小
    gifOptions.setDefaultDelay(2000);// 每張投影片顯示的時間，直到切換至下一張
    gifOptions.setTransitionFps(35);// 提高 FPS 以提升轉場動畫品質
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}

您也可以試用 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換工具。

{{% /alert %}}

## **常見問題**

**如果簡報使用的字型未安裝在系統上，該怎麼辦？**

安裝缺少的字型或[設定備援字型](/slides/zh-hant/nodejs-java/powerpoint-fonts/)。Aspose.Slides 會嘗試替換，但外觀可能會有所不同。為了維持品牌一致性，請務必確保所需字型已明確可用。

**我可以在 GIF 影格上疊加浮水印嗎？**

可以。請在匯出前於母片或各個投影片上[加入半透明物件/標誌](/slides/zh-hant/nodejs-java/watermark/)，浮水印會出現在每一個影格上。