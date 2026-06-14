---
title: 在 C++ 中將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/cpp/convert-powerpoint-to-animated-gif/
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
- 匯出 PPT 為 GIF
- 匯出 PPTX 為 GIF
- 預設 設定
- 自訂 設定
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆將 PowerPoint 簡報（PPT、PPTX）轉換為動畫 GIF。快速且高品質的結果。"
---
## **概述**

Aspose.Slides 讓您僅用幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣受支援的動畫格式分享簡報內容，並可嵌入網頁、即時通訊或文件時，這非常有用。本文說明如何使用預設設定將簡報匯出為 GIF，並說明如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/gifoptions/) 設定框架大小、投影片延遲與過渡幀率等選項，以自訂輸出。

## **使用預設設定將簡報轉換為動畫 GIF**

以下 C++ 範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

將使用預設參數建立動畫 GIF。 

{{%  alert  title="TIP"  color="primary"  %}} 
如果您想自訂 GIF 參數，可以使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.gif_options) 類別。請參考以下範例程式碼。 
{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

以下 C++ 範例程式碼示範如何使用自訂設定將簡報轉換為動畫 GIF：

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 產生的 GIF 大小
gifOptions->set_FrameSize(Size(960, 720));
// 每張投影片顯示的時間，直到切換到下一張
gifOptions->set_DefaultDelay(2000);
// 提升 FPS 以獲得更好的過渡動畫品質
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
您可能想試用由 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器。 
{{% /alert %}}

## **常見問題**

**如果簡報中使用的字型未安裝在系統上，該怎麼辦？**

請安裝缺少的字型或[設定備用字型](/slides/zh-hant/cpp/powerpoint-fonts/)。Aspose.Slides 會進行替代，但外觀可能會有所不同。若涉及品牌識別，請務必確保所需字型已正確安裝。

**我可以在 GIF 幀上疊加浮水印嗎？**

可以。請在匯出前將半透明物件/標誌[加入母片或各個投影片](/slides/zh-hant/cpp/watermark/) ，浮水印便會顯示於每一幀。