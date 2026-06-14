---
title: 在 PHP 中將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/php-java/convert-powerpoint-to-animated-gif/
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
- PHP
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for PHP 透過 Java 將 PowerPoint 簡報 (PPT、PPTX) 轉換為動畫 GIF。快速且高品質的結果。"
---
## **概述**

Aspose.Slides 允許您只透過幾行程式碼，即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣泛支援的動畫格式分享投影片內容，且可嵌入網頁、訊息軟體或文件中時，此功能非常有用。本文說明如何使用預設設定將簡報匯出為 GIF，以及如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/gifoptions/) 設定框架大小、投影片延遲、過渡幀率等選項，以自訂輸出。

## **使用預設設定將簡報轉換為動畫 GIF**

此範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

動畫 GIF 將以預設參數建立。

{{%  alert  title="TIP"  color="primary"  %}} 
如果您想自訂 GIF 的參數，可以使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/GifOptions) 類別。請參閱以下範例程式碼。 
{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**
此範例程式碼示範如何使用自訂設定將簡報轉換為動畫 GIF：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// 產生的 GIF 大小
    $gifOptions->setDefaultDelay(2000);// 每張投影片顯示的時間，直到切換到下一張
    $gifOptions->setTransitionFps(35);// 提高 FPS 以提升過渡動畫品質
    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
您可能想要看看 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換工具。 
{{% /alert %}}

## **常見問題**

**如果簡報中使用的字型未安裝在系統上，該怎麼辦？**

請安裝缺少的字型或[設定備用字型](/slides/zh-hant/php-java/powerpoint-fonts/)。Aspose.Slides 會進行替代，但外觀可能會有所不同。為了維持品牌形象，務必確保所需字型已明確提供。

**我可以在 GIF 幀上覆蓋水印嗎？**

可以。請在匯出前於母片或各個投影片上[加入半透明物件/標誌](/slides/zh-hant/php-java/watermark/)，水印將會出現在每一幀上。