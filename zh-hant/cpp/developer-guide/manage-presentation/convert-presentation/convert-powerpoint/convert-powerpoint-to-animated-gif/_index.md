---
title: 在 C++ 中將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for C++ 將 PowerPoint 簡報 (PPT、PPTX) 轉換為動畫 GIF。快速且高品質的結果。"
---
## **概述**

Aspose.Slides 讓您僅用幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣受支援的動畫格式分享投影片內容，且可嵌入網頁、即時通訊或文件中時，這非常方便。本文說明如何使用預設設定將簡報匯出為 GIF，以及如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/gifoptions/) 設定框架大小、投影片延遲與轉場幀率等選項自訂輸出。

## **使用預設設定將簡報轉換為動畫 GIF**

以下 C++ 範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

動畫 GIF 將以預設參數建立。

{{%  alert  title="TIP"  color="info"  %}} 
如果您想自訂 GIF 的參數，可以使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.gif_options) 類別。請參考下方範例程式碼。 
{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

以下範例程式碼示範如何在 C++ 中使用自訂設定將簡報轉換為動畫 GIF：

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// 產生的 GIF 大小
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// 每張投影片顯示的時間，直到切換到下一張為止
gifOptions->set_DefaultDelay(2000);
// 提升 FPS 以獲得更好的轉場動畫品質
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
您可以試用 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換工具。 
{{% /alert %}}

## **常見問題**

### 若簡報中使用的字型未安裝在系統上，該怎麼辦？

安裝缺少的字型或 [設定備用字型](/slides/zh-hant/cpp/powerpoint-fonts/)。Aspose.Slides 會嘗試替代，但外觀可能會有所不同。若涉及品牌形象，務必確保所需字型已明確提供。

### 我可以在 GIF 幀上覆蓋浮水印嗎？

可以。於匯出前將半透明物件/標誌 [新增至母片或各個投影片](/slides/zh-hant/cpp/watermark/)，浮水印便會出現在每一幀上。