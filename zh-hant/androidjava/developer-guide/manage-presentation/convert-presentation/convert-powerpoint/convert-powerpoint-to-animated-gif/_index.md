---
title: 在 Android 上將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/androidjava/convert-powerpoint-to-animated-gif/
keywords:
- 動畫 GIF
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 GIF
- 簡報轉 GIF
- 投影片轉 GIF
- PPT 轉 GIF
- PPTX 轉 GIF
- 將 PPT 儲存為 GIF
- 將 PPTX 儲存為 GIF
- 匯出 PPT 為 GIF
- 匯出 PPTX 為 GIF
- 預設設定
- 自訂設定
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Android 於 Java 環境將 PowerPoint 簡報（PPT、PPTX）轉換為動畫 GIF。快速且高品質的結果。"
---
## **概觀**

Aspose.Slides 允許您只需幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣受支援的動畫格式分享投影片內容，並可嵌入網頁、即時通訊或文件中時，這非常實用。本文說明如何使用預設設定將簡報匯出為 GIF，並透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/gifoptions/) 設定框架大小、投影片延遲與過渡幀率等選項，以自訂輸出內容。

## **使用預設設定將簡報轉換為動畫 GIF**

以下 Java 範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

將會使用預設參數建立動畫 GIF。

{{%  alert  title="TIP"  color="primary"  %}} 

如果您想自訂 GIF 的參數，可使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GifOptions) 類別。請參考下方範例程式碼。

{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

以下範例程式碼示範如何在 Java 中使用自訂設定將簡報轉換為動畫 GIF：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // 產生的 GIF 大小  
	gifOptions.setDefaultDelay(2000); // 每張投影片顯示的時間，直到切換至下一張
	gifOptions.setTransitionFps(35); // 提高 FPS 以獲得更好的過渡動畫品質
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}} 

您可以試用 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換工具。

{{% /alert %}}

## **常見問題**

**如果簡報中使用的字型未安裝在系統上，該怎麼辦？**

安裝缺少的字型或 [設定備用字型](/slides/zh-hant/androidjava/powerpoint-fonts/)。Aspose.Slides 會進行替代，但外觀可能有所不同。為了品牌一致性，請務必確保所需字型已明確可用。

**我可以在 GIF 幀上覆蓋浮水印嗎？**

可以。於母片或個別投影片加入半透明物件/標誌 (請參閱 [/slides/zh-hant/androidjava/watermark/] )，在匯出前添加——浮水印將出現在每一個幀上。