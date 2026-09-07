---
title: 在 Python 中轉換 OpenDocument 簡報
linktitle: 轉換 OpenDocument
type: docs
weight: 10
url: /zh-hant/python-java/convert-openoffice-odp/
keywords:
- 轉換 ODP
- ODP 轉 PDF
- ODP 轉 HTML
- ODP 轉 TIFF
- ODP 轉 PPT
- ODP 轉 PPTX
- ODP 轉 XPS
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 OpenDocument (ODP) 簡報轉換為 PDF、HTML 及其他格式，無需安裝 OpenOffice 或 LibreOffice。"
---
## **簡介**

Aspose.Slides for Python via Java 允許您將 OpenDocument (ODP) 簡報轉換為 PDF、HTML、TIFF、XPS、PPT 和 PPTX 等格式。ODP 轉換使用與 PowerPoint 轉換相同的 API：使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入來源檔案，並使用 [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 選擇輸出格式。

## **將 ODP 轉換為 PDF**

在執行範例之前，請先參考[安裝說明](/slides/zh-hant/python-java/installation/)。將名為 `pres.odp` 的 ODP 簡報放置於工作目錄中。以下程式碼會在必要時啟動 JVM，載入簡報，並將其儲存為 `pres.pdf`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **不同應用程式中的 OpenDocument 簡報**

由於 PowerPoint 與 LibreOffice/OpenOffice Impress 支援的簡報功能和呈現行為不同，同一 ODP 簡報在這兩個應用程式中的顯示可能會有所差異。當版面配置取決於複雜格式時，請檢查轉換後的簡報。

相容性差異可能會影響：

- 表格，包括相對於其他形狀的堆疊順序以及對圖片填充的支援。
- 文字旋轉與對齊。
- 文字的圖片、漸層與圖案填充。
- 編號與項目清單。

以下圖片顯示在 LibreOffice Impress 中建立的清單：

![LibreOffice Impress 中的 ODP 清單範例](odp-list-example.png)

Aspose.Slides 會保存 ODP 清單，以確保與 LibreOffice/OpenOffice Impress 的相容性。

欲取得功能相容性細節，請參閱[Microsoft 關於 OpenDocument 簡報格式的指南](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)。

## **常見問題**

**如果 ODP 檔案的格式在轉換後發生變化，該怎麼辦？**

ODP 與 PowerPoint 採用不同的簡報模型。表格、字型與填充樣式可能會呈現不同。請確認所需字型已安裝，檢查輸出結果，並在必要時調整版面或格式。

**轉換 ODP 檔案是否需要安裝 OpenOffice 或 LibreOffice？**

不需要。Aspose.Slides for Python via Java 會在不依賴任何這類應用程式的情況下處理簡報。僅需相容的 Java 執行環境與 Python 套件。

**在將 ODP 簡報轉換為 PDF 時，我可以自訂 PDF 輸出嗎？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 設定 PDF 匯出選項，例如影像品質與壓縮。

**我可以在伺服器或容器中轉換 ODP 簡報嗎？**

可以。於目標環境中安裝 Python 套件、相容的 Java 執行環境，以及簡報所需的字型。無需任何辦公室應用程式。