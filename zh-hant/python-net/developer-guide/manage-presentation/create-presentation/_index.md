---
title: 在 Python 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/python-net/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中建立 PowerPoint 簡報—產生 PPT、PPTX 與 ODP 檔案，受益於 OpenDocument 支援，並以程式方式儲存，以確保可靠的結果。"
---
## **概述**

Aspose.Slides for Python 讓您完全透過程式碼建立全新簡報檔案。本文展示核心工作流程——建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 物件、取得第一張投影片、插入簡單圖形，並將結果儲存——讓您了解在不使用 Microsoft Office 的情況下產生簡報只需極少的設定。由於相同的 API 可以寫入 PPT、PPTX 與 ODP 檔案，您只需一套程式碼即可同時支援傳統 PowerPoint 與 OpenDocument 格式。Aspose.Slides 適用於桌面、Web 或伺服器環境，為您的 Python 應用程式提供一個高效的起點，以便在建立初始投影片集後加入更豐富的內容，如文字、影像或圖表。

## **建立簡報**

在 Aspose.Slides for Python 中從頭建立 PowerPoint 檔案就像實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別一樣直接。建構函式會自動提供一個包含單一投影片的空白簡報，讓您立刻擁有可放置圖形、文字、圖表或任何應用程式所需內容的畫布。當您修改該投影片或新增其他投影片後，即可將結果儲存為 PPTX、舊版 PPT，甚至是 OpenDocument 格式。以下簡短程式碼範例說明了透過在第一張投影片上加入簡單圖形的工作流程。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片參考。  
3. 使用 `shapes` 集合所公開的 `add_auto_shape` 方法，新增一個 `CLOUD` 類型的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/) 物件。  
4. 為自動圖形加入文字。  
5. 將修改後的簡報另存為 PPTX 檔案。

在下方範例中，會在簡報的第一張投影片上新增雲狀圖形。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增一個類型為 CLOUD 的自動圖形。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：

![新的簡報](new_presentation.png)

## **常見問題**

**可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/python-net/save-presentation/)，並且可匯出為 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/python-net/convert-powerpoint-to-png/)、以及 [images](/slides/zh-hant/python-net/convert-powerpoint-to-png/)，等等。

**我可以從範本 (POTX/POTM) 開始，然後儲存為一般的 PPTX 嗎？**

可以。載入範本後儲存為所需的格式；POTX、POTM、PPTM 等類似格式 [受到支援](/slides/zh-hant/python-net/supported-file-formats/)。

**建立簡報時，如何控制投影片尺寸/長寬比？**

設定 [slide size](/slides/zh-hant/python-net/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸與座標的單位是什麼？**

使用點 (point)：1 英吋等於 72 點。

**如何處理包含大量媒體檔案的超大型簡報，以降低記憶體使用量？**

使用 [BLOB management strategies](/slides/zh-hant/python-net/manage-blob/)，透過暫存檔限制記憶體內部儲存，並傾向使用基於檔案的工作流程而非純記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法在同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 實例上從 [multiple threads](/slides/zh-hant/python-net/multithreading/) 進行操作。請為每個執行緒或行程執行獨立、隔離的實例。

**如何移除試用版水印與限制？**

在每個程式流程中 [Apply a license](/slides/zh-hant/python-net/licensing/)。授權 XML 必須保持未修改，且若有多執行緒，授權設定應同步執行。

**我可以為我建立的 PPTX 加上數位簽章嗎？**

可以。支援 [Digital signatures](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)（加入與驗證）於簡報。

**在建立的簡報中是否支援宏 (VBA)？**

可以。您可以 [create/edit VBA projects](/slides/zh-hant/python-net/presentation-via-vba/) 並儲存含宏的檔案，如 PPTM、PPSM。