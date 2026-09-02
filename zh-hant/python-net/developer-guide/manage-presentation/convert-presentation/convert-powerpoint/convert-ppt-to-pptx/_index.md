---
title: 在 Python 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/python-net/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將舊版 PPT 檔案轉換為 PPTX。包含單一檔案與批次轉換、錯誤處理以及相容性說明的範例。"
---
## **概觀**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Python via .NET 可以在不安裝 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其另存為 PPTX。本文說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換後需檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 並指定 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)。`with` 陳述式會在區塊結束時釋放 Presentation 並釋放其資源。

```python
import aspose.slides as slides

# 載入舊版 PPT 簡報。
with slides.Presentation("presentation.ppt") as presentation:
    # 將簡報儲存為 PPTX 格式。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

檔案副檔名本身不會決定輸出格式；必須使用 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/) 參數。若需保留原始 PPT 檔案，請將輸入與輸出路徑設為不同位置。

## **批次轉換多個 PPT 檔案**

以下範例會將一個目錄中的每個 `.ppt` 檔案轉換。每個檔案獨立處理，單一轉換失敗不會中斷其餘批次。

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

在正式環境中，請記錄完整例外資訊，決定是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。損毀的檔案、未提供正確密碼而開啟的受保護檔案、無法存取的路徑，以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/python-net/password-protected-presentation/) 以了解載入加密檔案的方法。

## **相容性與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並未以完全相同的方式表示所有功能。若舊版功能在 PPTX 中沒有對應項目，或未被程式庫支援，可能會被正規化、略過，或以不同方式顯示。

當轉換檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、嵌入式媒體、不常見字型或 VBA 宏時，請檢查轉換結果。普通的 PPTX 檔案並非支援宏的格式；如需保留 VBA，請使用支援宏的工作流程。同時確認所需字型與外部資源已在開啟或渲染轉換後投影片的環境中存在。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵的投影片數量與內容，然後在目標檢視器中比較其外觀與投影片放映行為。不要把成功的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 呼叫當作每個舊版功能都有完全對應的 PPTX 表示的證明。

## **何時使用 PPTX**

當投影片需在最新的 PowerPoint 版本中編輯、與支援 Open XML 套件的系統交換，或以較易檢查與還原的格式儲存時，請使用 PPTX。請保留原始 PPT 作為存檔或回溯的備份，直到轉換後的投影片通過您的相容性檢查為止。

若需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) 中針對特定格式的指南，而不要假設所有目標皆保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅需偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複執行的轉換、批次處理或應用程式層級的錯誤處理，請使用 Python API。

## **相關文章**

- [PPT 與 PPTX 比較](/python-net/ppt-vs-pptx/)
- [在 Python 中儲存投影片](/python-net/save-presentation/)
- [支援的檔案格式](/python-net/supported-file-formats/)
- [在 Python 中開啟投影片](/python-net/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Python via .NET 能在不需要 Microsoft PowerPoint 的情況下載入並儲存投影片檔案。

**PPT 轉換為 PPTX 會完整保留所有內容嗎？**

它會保留常見的投影片內容，但對於每個舊版或未支援的功能，無法保證完全相同的相容性。當產生的檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或不常見字型時，請仔細檢查。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。若密碼遺失或不正確，載入操作會失敗。

**轉換完成後，我應該刪除 PPT 檔案嗎？**

請保留原始檔案，直到您在相關的檢視器與工作流程中驗證 PPTX 為止。若舊版功能轉換後有所差異，原始檔可作為回溯備份。