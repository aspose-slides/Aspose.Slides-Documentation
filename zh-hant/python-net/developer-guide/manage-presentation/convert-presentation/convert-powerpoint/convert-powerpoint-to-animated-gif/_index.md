---
title: 在 Python 中將簡報轉換為動畫 GIF
linktitle: 簡報轉 GIF
type: docs
weight: 65
url: /zh-hant/python-net/convert-powerpoint-to-animated-gif/
keywords:
- 動畫 GIF
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- 轉換 ODP
- PowerPoint 轉 GIF
- OpenDocument 轉 GIF
- 簡報轉 GIF
- 投影片轉 GIF
- PPT 轉 GIF
- PPTX 轉 GIF
- ODP 轉 GIF
- 預設設定
- 自訂設定
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python，輕鬆將 PowerPoint 簡報（PPT、PPTX）和 OpenDocument 檔案（ODP）轉換為動畫 GIF。快速且高品質的結果。"
---
## **概述**

Aspose.Slides 讓您只需幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。當您需要以輕量、廣受支援的動畫格式分享投影片內容，並可嵌入網頁、即時通訊或文件中時，這非常實用。本文說明如何使用預設設定將簡報匯出為 GIF，以及如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/gifoptions/) 來設定框架大小、投影片延遲與轉場影格率等選項，以自訂輸出內容。

## **使用預設設定將簡報轉換為動畫 GIF**

以下 Python 範例程式碼示範如何使用標準設定將簡報轉換為動畫 GIF：

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

動畫 GIF 會使用預設參數建立。

{{%  alert  title="TIP"  color="primary"  %}} 

如果您想自訂 GIF 的參數，可使用 [GifOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/gifoptions/) 類別。請參考以下範例程式碼。

{{% /alert %}} 

## **使用自訂設定將簡報轉換為動畫 GIF**

以下範例程式碼示範如何在 Python 中使用自訂設定將簡報轉換為動畫 GIF：

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 產生的 GIF 大小  
options.default_delay = 2000 # 每張投影片顯示的時間，直到切換至下一張
options.transition_fps = 35  # 提升 FPS 以改善過渡動畫品質

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

您可能想查看 Aspose 開發的免費 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器。

{{% /alert %}}

## **常見問題**

**如果簡報中使用的字型未安裝在系統上該怎麼辦？**

請安裝缺少的字型或 [配置備用字體](/slides/zh-hant/python-net/powerpoint-fonts/)。Aspose.Slides 會自動替代，但外觀可能會有差異。若涉及品牌識別，請務必確保所需字型已明確可用。

**我可以在 GIF 影格上覆蓋浮水印嗎？**

可以。請在匯出前於母片或個別投影片加入半透明物件/標誌 ([Add a semi-transparent object/logo](/slides/zh-hant/python-net/watermark/)) — 浮水印會出現在每個影格上。