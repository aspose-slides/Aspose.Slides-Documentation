---
title: 在 Python 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/python-java/convert-pptx-to-ppt/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPTX
- PPTX 轉 PPT
- 將 PPTX 儲存為 PPT
- 匯出 PPTX 為 PPT
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python 中將 PPTX 轉換為舊版 PPT 格式。包含程式碼範例以及相容性與受保護檔案的說明。"
---
## **概述**

Aspose.Slides for Python via Java 讓您在未安裝 Microsoft PowerPoint 的情況下，將 PPTX 簡報轉換為 PowerPoint 97–2003 所使用的舊版 PPT 格式。載入 PPTX 檔案並以 PPT 輸出格式儲存，如下所示。

## **將 PPTX 轉換為 PPT**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)，傳入輸出路徑與 [SaveFormat.Ppt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Ppt)。

以下示例會在需要時啟動 Java 虛擬機，並使用預設選項將 `template.pptx` 轉換為 `output.ppt`。請將路徑替換為您自己的檔案名稱。即使儲存失敗，`finally` 區塊仍會釋放簡報資源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 載入 PPTX 簡報。
presentation = Presentation("template.pptx")
try:
    # 以 PPT 格式儲存簡報。
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

[SaveFormat.Ppt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Ppt) 參數用於選擇輸出格式；僅更改檔案副檔名並不會轉換簡報。請保留原始 PPTX 檔案，以便在較新功能在 PPT 中沒有對應時能回到原檔。

## **將 PPTX 轉換為其他格式**

Aspose.Slides 亦支援其他輸出格式。請參閱相應文章以了解特定格式的選項與範例：

- [在 Python 中將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)
- [在 Python 中將 PowerPoint 轉換為 XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/)
- [在 Python 中將 PowerPoint 轉換為 HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)
- [在 Python 中將簡報儲存為 ODP](/slides/zh-hant/python-java/save-presentation/)
- [在 Python 中將 PowerPoint 轉換為 PNG](/slides/zh-hant/python-java/convert-powerpoint-to-png/)

## **常見問題**

**所有 PPTX 效果與功能在轉換為 PPT 後都能保留嗎？**

未必。舊版 PPT 格式並不支援 PPTX 中的所有功能。某些效果、物件或行為可能會被簡化或以不同方式顯示。請在目標檢視器中檢查轉換後的簡報，特別是當簡報包含較新的 PowerPoint 功能時。

**我可以只將選取的投影片轉換為 PPT 嗎？**

儲存為 PPT 會寫入整個簡報。若要只轉換特定投影片，請建立新簡報，移除其預設的空白投影片，將所需的投影片複製到新簡報中，然後以 PPT 儲存。請參閱 [Clone Slides in Python](/slides/zh-hant/python-java/clone-slides/)。

**我可以轉換受密碼保護的 PPTX 檔案嗎？**

可以，只要在載入來源簡報時提供正確的密碼。您也可以為輸出檔案設定保護。請參閱 [Password-Protected Presentations](/slides/zh-hant/python-java/password-protected-presentation/)。