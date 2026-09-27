---
title: 在 Python 透過 Java 中建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/python-java/create-presentation/
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
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python（透過 Java）中建立簡報——產生 PPT、PPTX 與 ODP 檔案，受益於 OpenDocument 支援，並以程式方式儲存以確保可靠結果。"
---
## **概觀**

本篇文章說明如何使用 Aspose.Slides for Python via Java 建立簡報，將帶文字的圖形加入第一張投影片，並將結果儲存為 PPTX 檔案。常見問題解答涵蓋輸出格式、範本、投影片大小、記憶體使用、執行緒、授權、數位簽章以及 VBA 支援。

在開始之前，請安裝 Python、JDK、JPype 以及 Aspose.Slides for Python via Java。請參閱[安裝](/slides/zh-hant/python-java/installation/)了解 Windows、Linux 以及 macOS 的安裝步驟。

## **建立簡報**

在 Aspose.Slides for Python via Java 中從頭建立 PowerPoint 檔案，就像實例化 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別一樣簡單。建構函式會自動提供一個只有單一投影片的空白簡報，讓您立即擁有可放置圖形、文字、圖表或任何應用程式所需內容的畫布。當您修改該投影片──或新增投影片──後，即可將結果儲存為 PPTX、舊版 PPT，甚至 OpenDocument 格式。下面的簡短程式碼範例說明了透過在第一張投影片上加入簡單圖形的工作流程。

1. 建立 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別的實例。
1. 透過索引 0 取得第一張投影片。
1. 使用 [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) 新增類型為 [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) 的 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)。
1. 使用 [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText) 設定圖形的文字。
1. 使用 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 並指定 [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) 儲存簡報。

以下範例會在 Java 虛擬機器 (JVM) 尚未啟動時啟動它，將帶文字的雲形圖形加入第一張投影片，並儲存簡報。將檔案儲存為 *create_presentation.py*：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立一個含有單一空白投影片的簡報。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增雲形圖形並設定其文字。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在已安裝套件的環境中執行此腳本：

```sh
python create_presentation.py
```

雲形圖案的左上角距離投影片的左邊緣與上邊緣各 20 點，寬度為 200 點，高度為 80 點。腳本會將 *new_presentation.pptx* 儲存於目前工作目錄，該檔案包含一張投影片，內含雲形圖案及其文字。JVM 會持續執行直至 Python 程式結束；請參閱[限制與 API 差異](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library)。若未授權，Aspose.Slides 亦會在每張儲存的投影片上加入評估水印文字方塊；請參閱[授權](/slides/zh-hant/python-java/licensing/)。

結果：

![新的簡報](new_presentation.png)

## **常見問題**

**可以將新簡報儲存為哪些格式？**

您可以儲存為 [PPTX, PPT, and ODP](/slides/zh-hant/python-java/save-presentation/)，並匯出為 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)、[SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/) 和 [images](/slides/zh-hant/python-java/convert-powerpoint-to-png/)，以及其他格式。

**我可以從範本 (POTX/POTM) 開始，並儲存為一般的 PPTX 嗎？**

可以。載入範本後儲存為所需格式；POTX/POTM/PPTM 以及類似格式 [已支援](/slides/zh-hant/python-java/supported-file-formats/)。

**建立簡報時，如何控制投影片大小/長寬比？**

設定 [投影片大小](/slides/zh-hant/python-java/slide-size/)（包括 4:3、16:9 等預設或自訂尺寸），並選擇內容的縮放方式。

**尺寸與座標以什麼單位測量？**

以點為單位：1 英吋等於 72 點。

**如何處理包含大量媒體檔案的巨型簡報以降低記憶體使用？**

使用 [BLOB management strategies](/slides/zh-hant/python-java/manage-blob/) 來管理大型檔案，透過使用暫存檔限制記憶體內的儲存，並優先使用檔案為基礎的工作流程，而非純記憶體串流。

**我可以平行建立/儲存簡報嗎？**

不能在 [多執行緒](/slides/zh-hant/python-java/multithreading/) 中同時操作相同的 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 實例。請為每個執行緒或程序執行獨立的實例。

**如何移除試用水印與限制？**

[套用授權](/slides/zh-hant/python-java/licensing/) 每個程序僅需執行一次。授權 XML 必須保持未修改，若有多執行緒則需同步授權設定。

**我可以為建立的 PPTX 加上數位簽章嗎？**

可以。[數位簽章](/slides/zh-hant/python-java/digital-signature-in-powerpoint/)（新增與驗證）在簡報中受到支援。

**在建立的簡報中支援巨集 (VBA) 嗎？**

可以。您可以 [建立/編輯 VBA 專案](/slides/zh-hant/python-java/presentation-via-vba/) 並儲存含巨集的檔案，例如 PPTM/PPSM。