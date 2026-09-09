---
title: 在 Python 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/python-java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將舊版 PPT 檔案轉換為 PPTX。包括單檔與批次轉換的 Python 範例、錯誤處理與保真度說明。"
---
## **概述**

PPT 是舊版的二進位 PowerPoint 格式，而 PPTX 是較新的 Open XML 格式。Aspose.Slides for Python via Java 能在不安裝 Microsoft PowerPoint 的情況下載入 PPT 檔並將其儲存為 PPTX。本文件說明如何轉換單一檔案或整個目錄，並闡述轉換後需檢查的項目。

每個範例在需要時會啟動 Java 虛擬機，使用完畢後會釋放簡報資源。請將範例路徑替換為您自己的檔案或目錄路徑。

## **將 PPT 檔轉換為 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入來源檔案，然後以 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Pptx) 為參數呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)。`finally` 區塊會處置簡報並釋放其資源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 載入舊版 PPT 簡報。
presentation = Presentation("presentation.ppt")
try:
    # 將簡報儲存為 PPTX 格式。
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

副檔名本身不會決定輸出格式；必須使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Pptx) 參數來指定。若需保留原始 PPT 檔，請確保輸入與輸出路徑不同。

## **批次轉換多個 PPT 檔案**

以下範例會將指定目錄中的所有 `.ppt` 檔案進行轉換。每個檔案皆獨立處理，單一轉換失敗不會中斷整批作業。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

在正式環境中，請記錄完整例外資訊，判斷是否允許覆寫已存在的輸出檔，並將失敗的檔名寫入重試或審查佇列。損毀的檔案、未提供正確密碼的受保護檔案、無法存取的路徑以及不支援的內容，都可能導致轉換失敗。請參閱 [Password-Protected Presentations](/slides/zh-hant/python-java/password-protected-presentation/) 了解載入加密檔案的方式。

## **保真度與舊版功能**

轉換通常會保留投影片、投影片母片、版面配置、文字、圖形、影像、表格與圖表。惟 PPT 與 PPTX 並非以完全相同的方式呈現所有功能。若某個舊版功能在 PPTX 中沒有對應項目，或未被函式庫支援，可能會被正規化、略過，或以不同方式顯示。

若轉換後的檔案包含動畫、轉場、內嵌或連結的 OLE 物件、ActiveX 控制項、內嵌媒體、罕見字型或 VBA 巨集，請特別檢查。純 PPTX 檔案並非支援巨集的格式，若需保留 VBA，請使用相應的巨集啟用工作流程。此外，亦需確認在開啟或渲染轉換後簡報的環境中，已安裝必要的字型與外部資源。

針對重要文件，建議以程式方式重新開啟產生的 PPTX，檢查投影片數量與關鍵內容，並在目標檢視器中比對其外觀與投影片放映行為。不要將一次成功的 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 呼叫視為所有舊版功能皆獲得完全 PPTX 對應的證明。

## **何時使用 PPTX**

當簡報需要在最新版 PowerPoint 中編輯、與支援 Open XML 套件的系統交換，或需以較易檢查與復原的格式保存時，請使用 PPTX。保留原始 PPT 作為歸檔或回滾備份，直至轉換後的簡報通過您的保真度檢驗。

若需 PDF、HTML、影像、XPS 或其他輸出類型，請參考 [Convert Presentations to Multiple Formats](/slides/zh-hant/python-java/convert-presentation/) 中針對各格式的說明，而非假設所有目標皆保留可編輯的 PowerPoint 功能。

## **線上轉換器**

如需偶爾轉換單一檔案或快速比較，可使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)。若需可重複執行的轉換、批次處理或應用層級的錯誤處理，請使用 Python via Java API。

## **相關文章**

- [PPT 與 PPTX 比較](/slides/zh-hant/python-java/ppt-vs-pptx/)
- [在 Python 中儲存簡報](/slides/zh-hant/python-java/save-presentation/)
- [支援的檔案格式](/slides/zh-hant/python-java/supported-file-formats/)
- [在 Python 中開啟簡報](/slides/zh-hant/python-java/open-presentation/)

## **常見問題**

**我可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX 嗎？**

可以。Aspose.Slides for Python via Java 能在不需要 Microsoft PowerPoint 的情況下載入與儲存簡報檔案。

**PPT 轉 PPTX 會完整保留所有內容嗎？**

它會保留一般的簡報內容，但無法保證每個舊版或不支援的功能皆能完整呈現。若產生的檔案包含巨集、OLE 或 ActiveX 物件、媒體、特殊動畫或罕見字型，請特別檢查。

**我可以轉換受密碼保護的 PPT 檔案嗎？**

可以，只要在載入檔案時提供正確的密碼。缺少或錯誤的密碼會導致載入失敗。

**轉換完成後我應該刪除 PPT 檔案嗎？**

請保留原始檔案，直到您在重要的檢視器與工作流程中驗證過 PPTX 為止。若有舊版功能轉換結果不同，這樣即可作為回滾備份。