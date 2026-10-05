---
title: 在 Python 透過 Java 將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/python-java/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報轉 PDF
- PPT 轉 PDF
- 將 PPT 轉換為 PDF
- PPTX 轉 PDF
- 將 PPTX 轉換為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "在 Python 透過 Java 使用 Aspose.Slides 將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，並提供快速程式範例與進階轉換選項。"
---
## **概觀**

在 Python 透過 Java 轉換 PowerPoint 簡報（PPT、PPTX、ODP 等）為 PDF 格式具有多種優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔設置密碼保護、偵測字型取代、選取特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔案名稱作為參數傳遞給 [簡報](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別，然後使用 [保存](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 方法將簡報儲存為 PDF。[簡報](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [保存](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 **Application** 欄位填入 "*Aspose.Slides*"，在 **PDF Producer** 欄位填入形如 "*Aspose.Slides v XX.XX*" 的值。**注意**，您無法指示 Aspose.Slides 從輸出文件中變更或移除此資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報為 PDF
* 簡報中特定投影片為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會精確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準轉換使用預設的 PDF 匯出設定。當您需要控制影像品質、頁面內容或 PDF 合規性時，請使用自訂選項。

在執行範例之前，請安裝 [Aspose.Slides for Python via Java](/slides/zh-hant/python-java/installation/) 並確保已安裝相容的 Java 執行環境。每個範例皆會從目前工作目錄讀取 `presentation.pptx`；請將其替換為您的 PPT、PPTX 或 ODP 檔案。每個 Python 程序只需啟動一次 JVM。

以下範例載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，示範簡報轉 PDF 的流程。您可以使用此轉換器執行測試，以即時體驗本文所述的實作流程。
{{% /alert %}}

## **將 PowerPoint 轉換為 PDF（含選項）**

Aspose.Slides 提供自訂選項——[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、為 PDF 設置密碼，或指定轉換過程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

透過自訂轉換選項，您可以定義光柵影像的首選品質、指定如何處理中繼檔、設定文字的壓縮等級、配置影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，將中繼檔另存為 PNG，並使用 Flate 文字壓縮。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中包含嵌入的 Excel 活頁簿，您可能希望 PDF 接收者同時取得活頁簿資料並檢視投影片。請對 `True` 呼叫 [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) 以在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `False`：OLE 物件的預覽影像或圖示會呈現在 PDF 頁面上，但其嵌入檔案不會作為附件包含。將選項設為 `True` 則會額外加入檔案資料。預覽仍為視覺表示；附件允許接收者另行開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為附帶活頁簿的 PDF。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

檢查結果的步驟：

1. 在支援檔案附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的活頁簿。
3. 儲存附件並在 Excel 中開啟以檢視資料，或在檢視器允許的情況下直接開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有嚴格限制：PDF/A‑1 禁止嵌入檔案，PDF/A‑2 只允許 PDF/A 附件，PDF/A‑3 則允許其他檔案類型（包括 Excel 活頁簿）。這些限制屬於標準本身，而非 Aspose.Slides 的限制。此範例使用預設的 PDF 合規性設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將 PowerPoint 轉換為包含隱藏投影片的 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，將隱藏投影片納入產生的 PDF 頁面。

以下範例匯出簡報為 PDF，並包含所有隱藏投影片。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **將 PowerPoint 轉換為具密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **偵測字型取代**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) 方法，讓您在簡報轉 PDF 的過程中偵測字型取代情形。

以下範例將簡報匯出為 PDF，並將字型取代警告列印到主控台。僅當匯出時使用了不可用的字型且被取代時，才會印出警告。使用 JPype 代理來接收來自 Java API 的警告回呼。將 Java 描述字串轉換為 Python 字串後，再檢查其前綴：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
欲取得更多關於字型取代的資訊，請參閱 [字型取代](/slides/zh-hant/python-java/font-substitution/) 文章。
{{% /alert %}}

## **將選取的投影片從 PowerPoint 轉換為 PDF**

傳遞給 [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) 的投影片編號以 1 為起點。本範例在兩張投影片皆存在時，匯出第 1 張和第 3 張投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **將 PowerPoint 轉換為具自訂投影片尺寸的 PDF**

本範例將第一張投影片匯出至尺寸為 612 x 792 點（美國信紙）的頁面上。它會將投影片複製到一個新簡報，並依指定尺寸縮放投影片內容以符合頁面。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # 移除新簡報建立時所產生的空白投影片。
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **將 PowerPoint 轉換為備註投影片檢視的 PDF**

以下範例將簡報匯出為 PDF，將每張投影片的演講者備註置於投影片下方。請使用包含演講者備註的簡報以觀察結果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF 的無障礙與合規標準**

在製作無障礙 PDF 時，請參考 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)。使用 [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) 可選擇輸出標準：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範依不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**我可以一次大量將多個 PowerPoint 檔案批次轉換為 PDF 嗎？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以在程式中遍歷檔案並套用轉換流程。

**是否可以為轉換後的 PDF 設置密碼保護？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 類別中將 [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 設為 `True`，即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中維持高影像品質？**

可以，您可以使用 [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) 與 [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) 等方法，在 [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) 類別中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 允許您匯出符合[各種標準](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 以及 PDF/UA，適用於無障礙或存檔需求。請選擇適當的標準並依需求檢查輸出結果。

## **其他資源**

- [Aspose.Slides for Python via Java 文件](/slides/zh-hant/python-java/)
- [Aspose.Slides for Python via Java API 參考文件](https://reference.aspose.com/slides/python-java/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)