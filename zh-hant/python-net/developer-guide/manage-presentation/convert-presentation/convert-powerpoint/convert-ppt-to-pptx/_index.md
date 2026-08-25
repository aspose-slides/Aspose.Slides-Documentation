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
description: "使用 Aspose.Slides 在 Python 中將舊版 PPT 檔案轉換為 PPTX。提供單檔與批次轉換範例、錯誤處理以及忠實度說明。"
---
## **概觀**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Python via .NET 能在不使用 Microsoft PowerPoint 的情況下載入 PPT 檔案並將其另存為 PPTX。本文章說明如何轉換單一檔案或整個目錄的檔案，並解釋轉換完成後需要檢查的項目。

## **將 PPT 檔案轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/)，並傳入 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/)。`with` 陳述式會在區塊結束時釋放 Presentation 並釋放其資源。

```python
import aspose.slides as slides

# 載入舊版 PPT 簡報。
with slides.Presentation("presentation.ppt") as presentation:
    # 將簡報儲存為 PPTX 格式。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

副檔名本身不會決定輸出格式；必須使用 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/saveformat/) 參數來指定。如果需要保留原始 PPT 檔案，請確保輸入與輸出路徑不同。

## **轉換多個 PPT 檔案**

以下範例會轉換目錄中所有 `.ppt` 檔案。每個檔案獨立處理，單一轉換失敗不會中斷其餘批次。

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

在正式環境中，請記錄完整的例外資訊，決定是否允許覆寫已存在的輸出檔案，並將失敗的檔名寫入重試或審查佇列。損壞的檔案、未提供正確密碼就開啟的受保護檔案、無法存取的路徑以及不支援的內容，都可能導致轉換失敗。請參閱 [受密碼保護的簡報](/slides/zh-hant/python-net/password-protected-presentation/) 以了解載入加密檔案的方法。

## **忠實度與舊版功能**

轉換通常會保留投影片、母片、版面配置、文字、圖形、影像、表格與圖表。然而，PPT 與 PPTX 並未以完全相同的方式呈現所有功能。若某個舊版功能在 PPTX 中沒有對應項目，或未受函式庫支援，可能會被標準化、略過，或以不同方式顯示。

若轉換後的檔案包含動畫、轉場、內嵌或鏈結的 OLE 物件、ActiveX 控制項、內嵌媒體、罕見字型或 VBA 巨集，請特別檢查。純 PPTX 檔案並非支援巨集的格式，若必須保留 VBA，請使用相應的支援巨集工作流程。同時確認必要的字型與外部資源在要開啟或呈現轉換後簡報的環境中皆已存在。

對於重要文件，請以程式方式重新開啟產生的 PPTX，檢查關鍵的投影片數量與內容，並在預期的檢視程式中比較其外觀與投影片放映行為。不要將成功的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 呼叫視為每個舊版功能皆有完全相同 PPTX 表示的證明。

## **何時使用 PPTX**

當簡報需要在新版 PowerPoint 中編輯、與支援 Open XML 套件的系統交換，或存放於較易檢查與復原的格式時，請使用 PPTX。請將原始 PPT 保留為歸檔或回滾備份，直到轉換後的簡報通過您的忠實度檢查。

若需要 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [將簡報轉換為多種格式](/slides/zh-hant/python-net/convert-presentation/) 的格式說明，而不要假設所有目標皆保留可編輯的 PowerPoint 功能。

## **線上轉換器**

若僅需要偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複的轉換、批次處理或應用層面的錯誤處理，請使用 Python API。

## **相關文章**

- [PPT 與 PPTX 比較](/slides/zh-hant/python-net/ppt-vs-pptx/)
- [在 Python 中儲存簡報](/slides/zh-hant/python-net/save-presentation/)
- [支援的檔案格式](/slides/zh-hant/python-net/supported-file-formats/)
- [在 Python 中開啟簡報](/slides/zh-hant/python-net/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Python via .NET 能在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉 PPTX 轉換會完全保留所有內容嗎？**

它能保留一般的簡報內容，但無法保證每項舊版或不受支援的功能都能完全忠實呈現。若生成的檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或罕見字型，請務必檢查。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。若密碼缺失或不正確，載入操作將失敗。

**轉換完成後我應該刪除原始 PPT 檔案嗎？**

請保留原始檔案，直到您在相關的檢視程式與工作流程中驗證 PPTX 為止。這樣若有舊版功能轉換後有差異，仍可作為回滾備份。