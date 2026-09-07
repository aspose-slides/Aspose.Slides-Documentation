---
title: 在 Python 中將 ODP 轉換為 PPTX
linktitle: ODP 轉 PPTX
type: docs
weight: 10
url: /zh-hant/python-java/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 ODP
- OpenDocument 轉 PPTX
- ODP 轉 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 為 PPTX
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 ODP 簡報轉換為 PPTX。提供完整的 Python 範例，無需安裝 PowerPoint 或 LibreOffice。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Python via Java 將 OpenDocument (ODP) 簡報轉換為 PowerPoint (PPTX) 格式。

## **將 ODP 轉換為 PPTX**

[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別可以直接載入 ODP 檔案。使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 將載入的簡報儲存為 PPTX 格式。

在執行範例之前，請先遵循[installation instructions](/slides/zh-hant/python-java/installation/)。將名為 `AccessOpenDoc.odp` 的 ODP 簡報放在工作目錄中。以下程式碼會在必要時啟動 JVM，開啟 ODP 檔案，並將其儲存為 `AccessOpenDoc_out.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # 將 ODP 簡報儲存為 PPTX 格式。
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **即時範例**

嘗試使用 [Aspose.Slides Conversion](https://products.aspose.app/slides/zh-hant/conversion/) 網路應用程式，觀察由 Aspose.Slides 支援的 ODP 轉 PPTX 轉換效果。

## **常見問題**

**我是否需要安裝 Microsoft PowerPoint 或 LibreOffice 來將 ODP 轉換為 PPTX？**

不需要。Aspose.Slides for Python via Java 能在未安裝上述任何應用程式的情況下讀寫簡報檔案。您只需要 Python 套件以及相容的 Java 執行環境。

**在轉換過程中，母片投影片、版面配置和佈景主題會被保留嗎？**

Aspose.Slides 會將來源簡報的結構與格式對映至 PPTX。然而，ODP 與 PPTX 支援的功能不同，部分元素在轉換後可能會有所差異。請確保所需字型可用，並檢查具有複雜格式的簡報。相關相容性考量請參閱[OpenDocument conversion](/slides/zh-hant/python-java/convert-openoffice-odp/)。

**我能轉換受密碼保護的 ODP 檔案嗎？**

可以，只要在開啟檔案時提供正確的密碼。詳細說明請參閱[password-protected presentations](/slides/zh-hant/python-java/password-protected-presentation/)，了解在以其他格式儲存之前如何載入受保護的檔案。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

適合。您可以在後端使用 Aspose.Slides for Python via Java，並搭配所需的 Java 執行環境。若需 REST API，請參考 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)。