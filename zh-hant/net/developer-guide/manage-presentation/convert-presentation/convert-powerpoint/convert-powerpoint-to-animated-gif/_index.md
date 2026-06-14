---
title: 在 .NET 中將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆將 PowerPoint 簡報（PPT、PPTX）轉換為動畫 GIF。快速且高品質的結果。"
---
## **概述**

Aspose.Slides 允許您僅透過幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣受支援的動畫格式分享投影片內容，並可嵌入網頁、即時通訊軟體或文件時，這相當有用。本文說明如何使用預設設定將簡報匯出為 GIF，以及如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/gifoptions/) 設定框格大小、投影片延遲、轉場影格率等選項，自訂輸出結果。

## **使用預設設定將簡報轉換為動畫 GIF**

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

將依預設參數建立動畫 GIF。 

{{%  alert  title="TIP"  color="primary"  %}} 
如果您想自訂 GIF 的參數，可使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/gifoptions) 類別。請參考以下範例程式碼。 
{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 產生的 GIF 大小
        DefaultDelay = 2000, // 每張投影片顯示的時間，直到切換到下一張
        TransitionFps = 35 // 提高 FPS 以改善轉場動畫品質
    });
}
```

{{% alert title="Info" color="info" %}}
您可能想了解 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器。 
{{% /alert %}}

## **常見問題**

**如果簡報中使用的字型未安裝在系統上，該怎麼辦？**

安裝遺失的字型或[設定備用字型](/slides/zh-hant/net/powerpoint-fonts/)。Aspose.Slides 會進行替代，但外觀可能會有所不同。若涉及品牌，請務必確保所需字型已明確可用。

**我可以在 GIF 影格上疊加浮水印嗎？**

可以。[加入半透明物件/標誌](/slides/zh-hant/net/watermark/)至母片或個別投影片後匯出 — 浮水印將會出現在每一個影格上。