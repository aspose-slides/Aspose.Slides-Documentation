---
title: 在 Python 透過 Java 將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/python-java/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 將 PPT 轉換為 PDF
- PPTX 轉 PDF
- 將 PPTX 轉換為 PDF
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
description: "在 Python 透過 Java 使用 Aspose.Slides，將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概述**

將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 透過 Java 的 Python 轉換為 PDF 格式可提供多項優勢，包括在不同裝置之間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型取代、選擇特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="注意" %}}
Aspose.Slides for Python via Java 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，而 PDF Producer 欄位則會以「*Aspose.Slides v XX.XX*」的形式顯示。**注意**，您無法指示 Aspose.Slides 修改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報至 PDF
* 從簡報中挑選特定投影片至 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保最終的 PDF 與原始簡報高度相符。轉換過程中會正確呈現以下元素與屬性：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

預設轉換使用 PDF 匯出的預設設定。當您需要控制影像品質、頁面內容或 PDF 合規性時，請使用自訂選項。

在執行範例之前，先安裝 [Aspose.Slides for Python via Java](/slides/zh-hant/python-java/installation/) 並配置相容的 Java 執行環境。每個範例皆從當前工作目錄讀取 `presentation.pptx`；請將其替換為您的 PPT、PPTX 或 ODP 檔案。每個 Python 行程只需啟動一次 JVM。

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
Aspose 提供免費的線上 **PowerPoint 轉 PDF 轉換器** (https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)，可示範本文件所描述的轉換流程。您可利用此轉換器進行即時測試。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——屬於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別的屬性——讓您自訂輸出 PDF、設定 PDF 密碼，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

透過自訂轉換選項，您可以定義點陣圖的首選品質設定、指定中繼檔的處理方式、設定文字的壓縮等級、為影像配置 DPI 等等。

以下程式碼示範如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF：

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

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

如果簡報中包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，將隱藏投影片作為頁面匯入最終的 PDF。

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

以下程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

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

### **偵測字型取代**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別下提供 [setWarningCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setWarningCallback) 方法，讓您在簡報轉換為 PDF 的過程中偵測字型取代情形。

使用 JPype 代理接收來自 Java API 的警告回呼。將 Java 描述字串轉為 Python 字串後，再檢查其前綴：

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
欲取得有關渲染過程中字型取代警告回呼的更多資訊，請參閱 [取得字型取代的警告回呼](/slides/zh-hant/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

欲了解更多字型取代相關資訊，請參閱 [字型取代](/slides/zh-hant/python-java/font-substitution/) 文章。
{{% /alert %}}

## **將 PowerPoint 中的特定投影片轉換為 PDF**

傳遞給 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 的投影片編號採用 1 為基礎。以下範例在兩張投影片皆存在時，匯出第 1 張與第 3 張投影片：

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

此範例將第一張投影片匯出至大小為 612 × 792 點 (美國信紙) 的頁面，並將投影片複製到具有指定尺寸的新簡報中：

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

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下程式碼示範如何將 PowerPoint 簡報轉換為包含備註的 PDF：

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

## **PDF 的無障礙與合規標準**

在製作無障礙 PDF 時，請參考 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)。使用 [PdfOptions.setCompliance](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setCompliance) 可選擇輸出標準：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下程式碼示範一個會根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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

> **注意：** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表、公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標示為雜項；僅會為整個圖形提供替代文字。

## **常見問題 (FAQ)**

**我可以一次大量將多個 PowerPoint 檔案批次轉換為 PDF 嗎？**  
是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以在程式中迭代檔案並套用轉換程序。

**是否可以為轉換後的 PDF 設定密碼保護？**  
可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別設定密碼與存取權限，即可在轉換過程中為 PDF 加密。

**如何在 PDF 中包含隱藏投影片？**  
使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 方法，即可在最終 PDF 中包含隱藏投影片。

**Aspose.Slides 能否在 PDF 中維持高影像品質？**  
可以。透過 [PdfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/) 類別的 [setJpegQuality](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setJpegQuality) 與 [setSufficientResolution](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfoptions/#setSufficientResolution) 等方法，可在 PDF 中保留高品質影像。

**Aspose.Slides 是否支援 PDF/A 合規標準？**  
是的，Aspose.Slides 允許您匯出符合 [各種標準](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pdfcompliance/) 的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，適用於無障礙或歸檔需求。請選擇適當的標準並依需求檢查輸出結果。

## **其他資源**

- [Aspose.Slides for Python via Java 文件說明](/slides/zh-hant/python-java/)
- [Aspose.Slides for Python via Java API 參考]https://reference.aspose.com/slides/zh-hant/python-java/
- [Aspose 免費線上轉換器]https://products.aspose.app/slides/zh-hant/conversion