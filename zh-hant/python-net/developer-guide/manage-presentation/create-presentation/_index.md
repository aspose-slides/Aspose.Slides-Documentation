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
description: "在 Python 中使用 Aspose.Slides 建立 PowerPoint 簡報——產生 PPT、PPTX 與 ODP 檔案，支援 OpenDocument，並以程式方式儲存以確保可靠的結果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via .NET 來建立簡報、在第一張投影片上加入帶文字的圖形，並將結果儲存為 PPTX 檔案。同一套 API 也可將簡報儲存為 PPT 與 ODP，所以您可以使用同一套程式碼同時支援 PowerPoint 與 OpenDocument 格式，而不需要 Microsoft Office。最後的簡短 FAQ 針對格式、範本、投影片尺寸、單位、記憶體使用、執行緒、授權、數位簽章與 VBA 支援等常見問題提供說明。

開始之前，請使用 `pip install aspose.slides` 從 PyPI 安裝套件。請參閱[安裝](/slides/zh-hant/python-net/installation/)以取得 Linux 與 macOS 所需的函式庫，以及 Debian 與 Ubuntu 系統 Python 所需的虛擬環境資訊。

## **建立簡報**

若要建立簡報並在第一張投影片上放置帶文字的圖形，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別的實例。新簡報會自動包含一張空白投影片。  
2. 由 [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) 集合依索引 0 取得該投影片。  
3. 使用投影片的 [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 集合的 [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) 方法，新增一個雲狀的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)，並設定其 [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/)。  
4. 以 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法將簡報儲存為 PPTX 檔案。

```py
import aspose.slides as slides

# 實例化代表簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增類型為 CLOUD 的自動形狀。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

雲形物件的左上角距離投影片左邊緣與上邊緣各 20 點，寬度為 200 點、高度為 80 點。`with` 陳述式會在程式區塊結束時釋放簡報的資源。此腳本會在目前資料夾中保存 *new_presentation.pptx*，其中只有一張投影片，內含雲形與文字。若未套用授權，Aspose.Slides 會在每張投影片上加入評估浮水印；詳情請參閱[授權](/slides/zh-hant/python-net/licensing/)。

結果：

![新簡報](new_presentation.png)

## **常見問題**

### 可以儲存簡報為哪些格式？

您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/python-net/save-presentation/)，並可匯出為 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/)、以及[圖片](/slides/zh-hant/python-net/convert-powerpoint-to-png/)等格式。

### 可以從範本 (POTX/POTM) 開始，然後儲存為一般 PPTX 嗎？

可以。載入範本後儲存為所需格式；POTX/POTM/PPTM 等類似格式[受支援](/slides/zh-hant/python-net/supported-file-formats/)。

### 建立簡報時如何控制投影片尺寸/長寬比？

設定[投影片大小](/slides/zh-hant/python-net/slide-size/)（包含 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

### 尺寸與座標使用什麼單位？

使用點（points）：1 吋等於 72 點。

### 如何處理含大量媒體檔案的超大型簡報以減少記憶體使用？

使用[BLOB 管理策略](/slides/zh-hant/python-net/manage-blob/)，透過暫存檔限制記憶體儲存，並優先採用基於檔案的工作流程而非純記憶體串流。

### 可以平行建立/儲存簡報嗎？

無法在[多執行緒](/slides/zh-hant/python-net/multithreading/)中同時操作同一個 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 實例。請為每個執行緒或行程使用獨立的實例。

### 如何移除評估浮水印與限制？

在每個行程中[套用授權](/slides/zh-hant/python-net/licensing/)。授權 XML 必須保持未修改，若有多執行緒則需同步授權設定。

### 可以為我建立的 PPTX 加上數位簽章嗎？

可以。[數位簽章](/slides/zh-hant/python-net/digital-signature-in-powerpoint/)（加入與驗證）皆受到支援。

### 在建立的簡報中是否支援 VBA 巨集？

支援。您可以[建立/編輯 VBA 專案](/slides/zh-hant/python-net/presentation-via-vba/)並儲存含巨集的檔案，例如 PPTM/PPSM。