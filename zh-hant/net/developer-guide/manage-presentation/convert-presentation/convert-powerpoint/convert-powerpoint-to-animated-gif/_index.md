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
description: "使用 Aspose.Slides for .NET 輕鬆將 PowerPoint 簡報 (PPT, PPTX) 轉換為動畫 GIF。快速且高品質的結果。"
---
## **概觀**

Aspose.Slides 允許您只需幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣受支援的動畫格式分享投影片內容，且可嵌入網頁、即時通訊或文件中，這非常有用。本文說明如何使用預設設定將簡報匯出為 GIF，並透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/gifoptions/) 設定畫面大小、投影片延遲、過渡幀率等選項以自訂輸出。

## **使用預設設定將簡報轉換為動畫 GIF**

此 C# 範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

將會使用預設參數建立動畫 GIF。

{{%  alert  title="TIP"  color="info"  %}} 
如果您想自訂 GIF 的參數，可以使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/gifoptions) 類別。請參閱以下範例程式碼。 
{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

此範例程式碼示範如何在 C# 中使用自訂設定將簡報轉換為動畫 GIF：

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 產生的 GIF 大小  
        DefaultDelay = 2000, // 每張投影片顯示的時間，直至切換到下一張
        TransitionFps = 35 // 提高 FPS 以獲得更好的過渡動畫品質
    });
}
```

{{% alert title="Info" color="info" %}}
您可能想試試由 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器。 
{{% /alert %}}

## **常見問題**

### 如果簡報中使用的字型未安裝在系統上該怎麼辦？

安裝缺少的字型或[設定備用字型](/slides/zh-hant/net/powerpoint-fonts/)。Aspose.Slides 會進行替代，但外觀可能會有所不同。為了品牌形象，請務必確保所需字型已明確可用。

### 我可以在 GIF 幀上疊加浮水印嗎？

可以。[加入半透明物件/標誌](/slides/zh-hant/net/watermark/) 到母片或個別投影片，於匯出前設定——浮水印將會出現在每一個幀上。