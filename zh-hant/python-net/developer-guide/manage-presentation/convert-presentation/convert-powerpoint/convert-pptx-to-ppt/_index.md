---
title: 在 Python 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/python-net/convert-pptx-to-ppt/
keywords:
- PPTX 轉 PPT
- 將 PPTX 轉換為 PPT
- 轉換 PowerPoint
- 轉換簡報
- Python
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Python 透過 .NET 將 PPTX 轉換為 PPT——確保與 PowerPoint 格式的無縫相容，同時保留簡報的版面配置與品質。"
---
## **概觀**

Aspose.Slides for Python 允許您在程式碼中將現代 PPTX 簡報轉換為舊版 PPT 格式。開啟 PPTX 並將其匯出為 PPT，同時保留簡報的內容與版面配置，使結果相容於較舊版本的 PowerPoint。同一工作流程也能產生其他輸出，例如 PDF、XPS、ODP、HTML 或影像，讓它能順利整合至腳本、CI 流程與批次處理。

## **將 PPTX 轉換為 PPT**

要將 PPTX 轉換為 PPT，只需將檔案名稱和儲存格式傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/)類別的[save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/)方法。以下的 Python 範例使用預設選項將簡報從 PPTX 轉換為 PPT。

```py
import aspose.slides as slides

# 實例化代表 PPTX 檔案的 Presentation 類別。
presentation = slides.Presentation("presentation.pptx")

# 將簡報儲存為 PPT 檔案。
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **常見問題**

**將 PPTX 的所有效果與功能在儲存為舊版 PPT（97–2003）格式時是否都能保留？**

未必。PPT 格式缺少某些較新的功能（例如特定的效果、物件與行為），因此在轉換過程中可能會將功能簡化或以點陣圖方式呈現。

**我可以僅將選取的投影片轉換為 PPT，而不是整個簡報嗎？**

直接儲存會針對整個簡報。若要轉換特定投影片，請建立僅包含這些投影片的新簡報並將其儲存為 PPT；或者使用支援逐投影片轉換參數的服務/API。

**是否支援受密碼保護的簡報？**

是的。您可以偵測檔案是否受保護，以密碼開啟，並且還能為儲存的 PPT[設定保護/加密設定](/slides/zh-hant/python-net/password-protected-presentation/)。

另請參閱：
- [在 Python 中將 PPT 與 PPTX 轉換為 PDF | 高級選項](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)
- [在 Python 中將 PowerPoint 簡報轉換為 XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/)
- [在 Python 中將 PowerPoint 簡報轉換為 HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)
- [在 Python 中將 PowerPoint 投影片轉換為 PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/)