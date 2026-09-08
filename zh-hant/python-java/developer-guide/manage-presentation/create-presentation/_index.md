---
title: 在 Python via Java 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/python-java/create-presentation/
keywords:
- 建立簡報
- 新增簡報
- 建立 PPT
- 新 PPT
- 建立 PPTX
- 新 PPTX
- 建立 ODP
- 新 ODP
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 於 Python via Java 建立簡報——產生 PPT、PPTX 與 ODP 檔案，支援 OpenDocument，並以程式方式儲存以確保可靠的結果。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via Java 建立簡報、在第一張投影片上加入帶文字的形狀，並將結果儲存為 PPTX 檔案。FAQ 包括輸出格式、範本、投影片大小、記憶體使用、執行緒、授權、數位簽章以及 VBA 支援。

## **建立簡報**

在 Aspose.Slides for Python via Java 中從頭開始建立 PowerPoint 檔案，就像實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別一樣直接。建構子會自動提供一個只有單一投影片的空白簡報，讓您立即擁有形狀、文字、圖表或任何應用程式需要的內容畫布。當您修改該投影片或新增投影片時，就可以將結果儲存為 PPTX、舊版 PPT，甚至 OpenDocument 格式。以下簡短的程式碼範例說明了這個工作流程，透過在第一張投影片上加入簡單的形狀來示範。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得第一張投影片。  
1. 使用 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addAutoShape) 新增類型為 [ShapeType.Cloud](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#Cloud) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。  
1. 使用 [TextFrame.setText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/#setText) 設定形狀的文字。  
1. 使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 搭配 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Pptx) 儲存簡報。

以下範例需要 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。它會在 JVM 尚未啟動時啟動它，將雲狀形狀新增至第一張投影片，並儲存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立一個只有空白投影片的簡報。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 加入雲狀形狀並設定其文字。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![新的簡報](new_presentation.png)

## **常見問題**

**我可以將新的簡報儲存為哪些格式？**

您可以儲存為 [PPTX、PPT 和 ODP](/slides/zh-hant/python-java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/python-java/render-slide-as-svg/) 以及 [images](/slides/zh-hant/python-java/convert-powerpoint-to-png/)，等等。

**我可以從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？**

可以。載入範本後儲存為所需格式；POTX、POTM、PPTM 以及類似格式 [已支援](/slides/zh-hant/python-java/supported-file-formats/)。

**建立簡報時，如何控制投影片尺寸/長寬比？**

設定 [slide size](/slides/zh-hant/python-java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸與座標的單位是什麼？**

以點 (point) 為單位：1 英吋等於 72 點。

**如何處理包含大量媒體檔案的巨大簡報以降低記憶體使用量？**

使用 [BLOB management strategies](/slides/zh-hant/python-java/manage-blob/)，透過暫存檔限制記憶體內的儲存，並優先採用基於檔案的工作流程，而非純粹的記憶體串流。

**我可以平行建立/儲存簡報嗎？**

您無法在 [multiple threads](/slides/zh-hant/python-java/multithreading/) 中同時操作同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例。請於每個執行緒或行程中執行獨立的實例。

**我如何移除試用版浮水印與限制？**

[Apply a license](/slides/zh-hant/python-java/licensing/) 每個行程執行一次。授權 XML 必須保持未被修改，且若有多個執行緒，授權設定應同步執行。

**我可以為所建立的 PPTX 加上數位簽章嗎？**

可以。[Digital signatures](/slides/zh-hant/python-java/digital-signature-in-powerpoint/)（新增與驗證）在簡報中受到支援。

**在建立的簡報中是否支援巨集 (VBA)？**

可以。您可以 [create/edit VBA projects](/slides/zh-hant/python-java/presentation-via-vba/) 並儲存含巨集的檔案，例如 PPTM/PPSM。