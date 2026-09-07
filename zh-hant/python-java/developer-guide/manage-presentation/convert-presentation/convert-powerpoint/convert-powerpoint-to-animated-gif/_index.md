---
title: 在 Python 中將 PowerPoint 簡報轉換為動畫 GIF
linktitle: PowerPoint 轉 GIF
type: docs
weight: 65
url: /zh-hant/python-java/convert-powerpoint-to-animated-gif/
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
- 将 PPTX 儲存為 GIF
- 匯出 PPT 為 GIF
- 匯出 PPTX 為 GIF
- 預設設定
- 自訂設定
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，輕鬆將 PowerPoint 簡報（PPT、PPTX）轉換為動畫 GIF。快速且高品質的結果。"
---
## **概覽**

Aspose.Slides for Python via Java 讓您只需幾行程式碼即可將 PowerPoint 簡報轉換為動畫 GIF 檔案。這對於在網頁、即時通訊或文件中分享投影片內容非常有用。本文說明如何使用預設設定匯出簡報，以及如何透過 [GifOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gifoptions/) 自訂影格大小、投影片延遲和轉場影格速率。

## **使用預設設定將簡報轉換為動畫 GIF**

下列 Python 範例載入 `pres.pptx`，並以標準設定儲存為動畫 GIF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="提示" %}}
若要自訂 GIF 輸出，請在儲存時傳入 [GifOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gifoptions/) 物件，如下所示。
{{% /alert %}}

## **使用自訂設定將簡報轉換為動畫 GIF**

使用 [setFrameSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gifoptions/#setFrameSize) 指定輸出尺寸（像素），[setDefaultDelay](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gifoptions/#setDefaultDelay) 設定預設投影片延遲（毫秒），以及 [setTransitionFps](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/gifoptions/#setTransitionFps) 控制轉場影格速率。

以下範例匯出 960 × 720 的 GIF，預設投影片延遲為兩秒，轉場每秒 35 影格。當投影片未設定自動前進時間時，會套用此預設延遲。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}}
您也可以試試 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換工具。
{{% /alert %}}

## **常見問題**

**如果簡報使用的字型未安裝於系統，該怎麼辦？**

安裝缺少的字型或[設定備援字型](/slides/zh-hant/python-java/powerpoint-fonts/)。字型替換可能會改變匯出 GIF 的外觀。確保原始字型可用以匹配簡報設計至關重要。

**我可以在 GIF 影格上覆蓋浮水印嗎？**

可以。請在匯出前於相關母片或單一投影片[新增半透明物件或標誌](/slides/zh-hant/python-java/watermark/)。浮水印會成為渲染投影片內容的一部份。