---
title: 在 Python via Java 中將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/python-java/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 轉換 PPT 為 PDF
- PPTX 轉 PDF
- 轉換 PPTX 為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中使用 Aspose.Slides 將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概述**

在 Python 透過 Java 將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同裝置之間的相容性以及保留簡報的版面配置與格式。本指南說明如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔設定密碼、偵測字型替換、選取特定投影片進行轉換，並將合規性標準套用至輸出文件。

## **PowerPoint 轉 PDF 的轉換類型**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類，然後使用 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類提供的 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="注意" %}}
Aspose.Slides for Python via Java 會將其 API 資訊和版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您進行以下轉換：

* 整個簡報轉為 PDF
* 從簡報中挑選特定投影片轉為 PDF

Aspose.Slides 匯出簡報為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會準確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁腳
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準轉換使用預設的 PDF 匯出設定。當您需要控制影像品質、頁面內容或 PDF 合規性時，請使用自訂選項。

在執行範例之前，請先安裝 [Aspose.Slides for Python via Java](/slides/zh-hant/python-java/installation/) 並配置相容的 Java 執行環境。每個範例皆會從當前工作目錄讀取 `presentation.pptx`；請自行替換為您的 PPT、PPTX 或 ODP 檔案。每個 Python 程序只需啟動一次 JVM。

以下程式碼將簡報轉換為 PDF：

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

{{% alert color="info" title="注意" %}}
Aspose 提供免費的線上 **PowerPoint 轉 PDF 轉換器**（https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf），可示範簡報轉 PDF 的流程。您可使用此轉換器測試本文件中描述的實作步驟。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類下的屬性——讓您自行調整產生的 PDF、為 PDF 設定密碼，或指定轉換流程的行為。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

透過自訂轉換選項，您可以為光柵影像設定偏好的品質、指定如何處理中繪圖檔、設定文字的壓縮等級、配置影像的 DPI，等等。

以下程式碼示範如何使用多項自訂選項將 PowerPoint 簡報轉為 PDF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **將隱藏投影片包含於 PDF 轉換中**

如果簡報中有隱藏投影片，可使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，將隱藏投影片作為頁面納入最終的 PDF。

以下程式碼示範如何在 PDF 中包含隱藏投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類提供的 [setWarningCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setWarningCallback) 方法，可讓您在簡報轉 PDF 的過程中偵測字型替換。

使用 JPype 代理接收來自 Java API 的警告回呼，並在檢查字串前先將 Java 描述字串轉為 Python 字串：

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}}
欲取得在渲染過程中字型替換的回呼資訊，請參閱 [Getting Warning Callbacks for Fonts Substitution](/slides/zh-hant/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

更多關於字型替換的說明，請參閱 [Font Substitution](/slides/zh-hant/python-java/font-substitution/) 文章。
{{% /alert %}}

## **將選取的投影片轉換為 PDF**

傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 的投影片編號採用 1 為基礎。以下範例在投影片 1 與 3 同時存在時匯出這兩張投影片：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **使用自訂投影片尺寸將 PowerPoint 轉換為 PDF**

此範例將第一張投影片匯出至尺寸為 612 × 792 點（美國信紙）的頁面，並以指定尺寸將投影片複製至新簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **在備註投影片檢視模式下將 PowerPoint 轉換為 PDF**

以下程式碼示範如何將包含備註的 PowerPoint 簡報轉換為 PDF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF 的無障礙性與合規標準**

在製作無障礙 PDF 時，請參考 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)。使用 [PdfOptions.setCompliance](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setCompliance) 可選擇輸出標準：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

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

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形處理。個別路徑元素不會保留為分離的內容，且可能被標記為雜項；只有整體圖形會提供替代文字。

## **常見問題**

**我可以一次批次將多個 PowerPoint 檔轉換為 PDF 嗎？**

可以，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF，您可以在程式中遍歷檔案並套用轉換流程。

**轉換後的 PDF 能設定密碼保護嗎？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類設定密碼與存取權限，即可在轉換過程中為 PDF 加密。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類中使用 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，即可將隱藏投影片納入最終 PDF。

**Aspose.Slides 能在 PDF 中維持高影像品質嗎？**

可以。透過 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類的 [setJpegQuality](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setJpegQuality) 與 [setSufficientResolution](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setSufficientResolution) 方法，可確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

支援。Aspose.Slides 可匯出符合 [各種標準](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，適用於無障礙或存檔需求。請依需求選擇適當標準並檢查輸出結果。

## **其它資源**

- [Aspose.Slides for Python via Java 文件](/slides/zh-hant/python-java/)
- [Aspose.Slides for Python via Java API 參考]https://reference.aspose.com/slides/zh-hant/python-java/
- [Aspose 免費線上轉換工具]https://products.aspose.app/slides/zh-hant/conversion