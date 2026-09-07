---
title: 使用 Python 將 PowerPoint 簡報轉換為 XPS
linktitle: PowerPoint 轉 XPS
type: docs
weight: 70
url: /zh-hant/python-java/convert-powerpoint-to-xps/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 XPS
- 簡報 轉 XPS
- PPT 轉 XPS
- PPTX 轉 XPS
- 將 PPT 儲存為 XPS
- 將 PPTX 儲存為 XPS
- 將 PPT 匯出為 XPS
- 將 PPTX 匯出為 XPS
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python 中將 PowerPoint PPT 和 PPTX 簡報轉換為 XPS，可選擇預設或自訂匯出設定。"
---
## **概觀**

Aspose.Slides for Python via Java 允許您透過將 PPT 或 PPTX 檔案儲存為 XPS 格式，將 PowerPoint 簡報轉換為 XPS。本篇說明 XPS 何時有用，並展示如何使用預設設定或自訂 [XpsOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xpsoptions/) 設定匯出簡報。

## **關於 XPS**

XPS（XML Paper Specification）是 Microsoft 開發的基於 XML 的文件格式。它描述了固定頁面，保留文字與圖形的版面配置，以便在相容軟體中檢視與列印。

## **何時使用 Microsoft XPS 格式**

在文件工作流程需要固定版面檔案來共享或透過相容工具列印時，使用 XPS。接受者需要支援 XPS 的軟體。如果您的工作流程需要 PDF，請參閱 [Convert PowerPoint to PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}
若要嘗試將 PPT 或 PPTX 簡報轉換為 XPS，請使用 [free online converter](https://products.aspose.app/slides/zh-hant/conversion)。
{{% /alert %}}

| 輸入 PowerPoint 簡報 | 輸出 XPS 文件 |
| --- | --- |
| ![原始 PowerPoint 簡報](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![已轉換為 XPS 的簡報](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **使用 Aspose.Slides 轉換 XPS**

使用 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法搭配 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的 [SaveFormat.Xps](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Xps) 來匯出簡報。您可以使用預設匯出設定，或提供 [XpsOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xpsoptions/) 以自訂輸出。

以下範例會在需要時啟動 Java 虛擬機，並在使用後釋放簡報。請將輸入檔名取代為您的 PPT 或 PPTX 檔案路徑。

### **使用預設設定將簡報轉換為 XPS**

以下 Python 程式碼使用預設設定將簡報轉換為 XPS：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # 將簡報儲存為 XPS 文件。
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **使用自訂設定將簡報轉換為 XPS**

以下範例使用 [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) 將圖形檔案儲存為 PNG 圖片，以產生 XPS 文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # 使用自訂 XPS 設定儲存簡報。
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以將 XPS 儲存到串流而不是檔案嗎？**

可以。[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法有接受 Java 輸出串流的重載。使用 Python via Java 時，可透過 JPype 使用相容的 Java 串流（例如 Java 位元組陣列輸出串流），將匯出資料保留在記憶體中。

**隱藏的投影片會包含在 XPS 輸出中嗎？**

預設會排除隱藏投影片。若要包含，請在儲存前將 [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) 設為 `True`。

**XPS 會保留動畫和投影片轉場效果嗎？**

不會。XPS 為固定頁面，匯出的投影片不會播放動畫或轉場效果。