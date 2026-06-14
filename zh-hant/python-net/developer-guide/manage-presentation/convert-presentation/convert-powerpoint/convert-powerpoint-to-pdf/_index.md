---
title: 在 Python 中將 PPT 與 PPTX 轉換為 PDF | 高級選項
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/python-net/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 簡報
- PowerPoint 轉 PDF
- PPT 轉 PDF
- PPTX 轉 PDF
- 將 PowerPoint 儲存為 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "逐步指南，說明如何使用 Aspose.Slides 在 Python 中將 PPT、PPTX 與 ODP 轉換為高品質、符合 WCAG 標準的 PDF——包含密碼保護、投影片選擇與影像品質控制。"
showReadingTime: true
---
## **概述**

將 PowerPoint 簡報（PPT、PPTX、ODP）轉換為 PDF 格式的 Python 程式具備多項優勢，包括確保在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、以密碼保護 PDF 文件、偵測字型替換、選取特定投影片進行轉換，以及套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中將簡報轉換為 PDF，只需將檔名作為參數傳入 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別，然後使用 [Save](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/#methods) 方法將簡報儲存為 PDF。[Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [Save](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/#methods) 方法。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python 會直接在輸出文件中寫入 API 資訊與版本號。例如，當它將簡報轉換為 PDF 時，Aspose.Slides for Python 會在 Application 欄位填入 '*Aspose.Slides*'，在 PDF Producer 欄位填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意**，您無法指示 Aspose.Slides for Python 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報至 PDF
* 簡報中指定的投影片至 PDF

Aspose.Slides 匯出簡報為 PDF，確保產生的 PDF 內容與原始簡報高度相符。轉換過程中會正確呈現以下元素與屬性：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint PDF 轉換作業使用預設選項執行。在此情況下，Aspose.Slides 會嘗試以最佳設定、最高品質等級將提供的簡報轉換為 PDF。以下 Python 程式碼示範如何將 PowerPoint 轉換為 PDF：

_Steps: PowerPoint to PDF Conversions in Python_

以下範例程式碼說明如何使用 .NET 透過 Python 進行這些轉換  
- <a name="python-net-powerpoint-to-pdf"><strong>步驟：使用 Python 透過 .NET 将 PowerPoint 轉換為 PDF</strong></a>  
- <a name="python-net-ppt-to-pdf"><strong>步驟：使用 Python 透過 .NET 将 PPT 轉換為 PDF</strong></a>  
- <a name="python-net-pptx-to-pdf"><strong>步驟：使用 Python 透過 .NET 将 PPTX 轉換為 PDF</strong></a>  
- <a name="python-net-odp-to-pdf"><strong>步驟：使用 Python 透過 .NET 将 ODP 轉換為 PDF</strong></a>  
- <a name="python-net-odp-to-pdf"><strong>步驟：使用 Python 透過 .NET 将 PPS 轉換為 PDF</strong></a>

**程式碼步驟：**

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例，並提供 PowerPoint 檔案。  
  * _.ppt_ 副檔名用於在 _Presentation_ 類別中載入 **PPT** 檔案。  
  * _.pptx_ 副檔名用於在 _Presentation_ 類別中載入 **PPTX** 檔案。  
  * _.odp_ 副檔名用於在 _Presentation_ 類別中載入 **ODP** 檔案。  
  * _.pps_ 副檔名用於在 _Presentation_ 類別中載入 **PPS** 檔案。  
- 呼叫 **Save** 方法，使用 **SaveFormat.PDF** 列舉，將 _Presentation_ 儲存為 **PDF** 格式。

```python
import aspose.slides as slides

# 建立一個代表 PowerPoint 檔案的 Presentation 類別實例
presentation = slides.Presentation("PowerPoint.ppt")

# 將簡報儲存為 PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf) 示範簡報至 PDF 的轉換流程。若想實作本文件所述程序，可使用此轉換器進行測試。

{{% /alert %}}

## **將 PowerPoint 轉換為 PDF 並使用選項**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides.export/pdfoptions/) 類別下的屬性——讓您自訂轉換後的 PDF、以密碼鎖定 PDF，甚至指定轉換流程的行為。

### **將 PowerPoint 轉換為 PDF 並使用自訂選項**

透過自訂轉換選項，您可以設定光柵影像的首選品質、指定如何處理中繼檔、設定文字壓縮層級、設定影像 DPI 等。

以下程式碼示範將 PowerPoint 簡報以多項自訂選項轉換為 PDF：

```python
import aspose.slides as slides

# 建立 PdfOptions 類別的實例
pdf_options = slides.export.PdfOptions()

# 設定 JPG 圖片的品質
pdf_options.jpeg_quality = 90

# 設定影像的 DPI
pdf_options.sufficient_resolution = 300

# 設定中繼檔的處理方式
pdf_options.save_metafiles_as_png = True

# 設定文字內容的壓縮等級
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# 定義 PDF 合規模式
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# 建立代表 PowerPoint 文件的 Presentation 類別實例
with slides.Presentation("PowerPoint.pptx") as presentation:
    # 將簡報儲存為 PDF 文件
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **將 PowerPoint 轉換為 PDF（包含隱藏投影片）**

如果簡報包含隱藏投影片，您可以使用自訂選項——[PdfOptions](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides.export/pdfoptions/) 類別的 `show_hidden_slides` 屬性——指示 Aspose.Slides 將隱藏投影片作為頁面包含在產生的 PDF 中。

以下 Python 程式碼示範如何在轉換為 PDF 時包含隱藏投影片：

```python
import aspose.slides as slides

# 建立一個代表 PowerPoint 檔案的 Presentation 類別實例
presentation = slides.Presentation("PowerPoint.pptx")

# 建立 PdfOptions 類別的實例
pdfOptions = slides.export.PdfOptions()

# 加入隱藏投影片
pdfOptions.show_hidden_slides = True

# 將簡報儲存為 PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下 Python 程式碼示範如何使用 [PdfOptions](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides.export/pdfoptions/) 類別的保護參數，將 PowerPoint 轉換為受密碼保護的 PDF：

```python
import aspose.slides as slides

# 建立一個代表 PowerPoint 檔案的 Presentation 物件
presentation = slides.Presentation("PowerPoint.pptx")

# 建立 PdfOptions 類別的實例
pdfOptions = slides.export.PdfOptions()

# 設定 PDF 密碼與存取權限
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# 將簡報儲存為 PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下 Python 程式碼示範如何將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```python
import aspose.slides as slides

# 建立一個代表 PowerPoint 檔案的 Presentation 物件
presentation = slides.Presentation("PowerPoint.pptx")

# 設定投影片位置的陣列
slides_array = [ 1, 3 ]

# 將簡報儲存為 PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **將 PowerPoint 轉換為自訂投影片大小的 PDF**

以下 Python 程式碼示範如何在指定投影片大小的情況下，將 PowerPoint 轉換為 PDF：

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # 建立具有調整後投影片大小的新簡報。
    with slides.Presentation() as resized_presentation:

        # 設定自訂投影片大小。
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # 從原始簡報複製第一張投影片。
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 將調整尺寸的簡報儲存為含註解的 PDF。
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **將 PowerPoint 轉換為 PDF（註解投影片檢視）**

以下 Python 程式碼示範如何將 PowerPoint 轉換為 PDF 註解：

```python
import aspose.slides as slides

# 建立一個代表 PowerPoint 檔案的 Presentation 類別實例
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 將簡報儲存為 PDF 註解
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF 的可及性與合規標準**

Aspose.Slides 允許您使用符合 [Web 內容可及性指引 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 Python 程式碼示範一次取得多種符合不同合規標準的 PDF：

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides 對 PDF 轉換作業的支援延伸至允許您將 PDF 轉換為最熱門的檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-png/) 轉換。其他針對特殊格式的 PDF 轉換亦受支援，包括 [PDF 轉 SVG](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/zh-hant/python-net/conversion/pdf-to-xml/)。

{{% /alert %}}

> **Note:** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題集**

**Aspose.Slides for Python 能否從 PDF 中移除應用程式資訊？**

不能，Aspose.Slides for Python 會自動在輸出 PDF 中加入 API 資訊與版本號，無法修改或移除。

**如何僅在 PDF 轉換中包含特定投影片？**

您可以在呼叫 `save` 方法時傳入投影片索引陣列，以指定要轉換的投影片。

**是否能在轉換過程中為 PDF 設定密碼保護？**

可以，於將簡報儲存為 PDF 前，使用 `PdfOptions` 類別設定密碼及存取權限。

**Aspose.Slides 是否支援將 PDF 轉換為其他格式？**

支援，Aspose.Slides 可將 PDF 轉換為 HTML、影像格式（JPG、PNG）、SVG、TIFF 以及 XML 等。

**如何確保我的 PDF 符合可及性標準？**

在 `PdfOptions` 中設定 `compliance` 屬性為 `PDF_A1A`、`PDF_A1B` 或 `PDF_UA` 即可符合相關可及性指南。

**我可以在 PDF 輸出中包含隱藏投影片嗎？**

可以，將 `PdfOptions` 的 `show_hidden_slides` 屬性設為 `True` 後，隱藏投影片將被納入 PDF。

**如何在轉換時調整影像品質與解析度？**

使用 `PdfOptions` 的 `jpeg_quality` 與 `sufficient_resolution` 屬性即可控制產生 PDF 的影像品質與解析度。

**Aspose.Slides 會自動處理字型替換嗎？**

會，Aspose.Slides 於轉換過程中會偵測字型替換，您亦可透過 `SaveOptions` 的 `warning_callback` 屬性（目前功能有限）自行處理。

## **其他資源**

- [Aspose.Slides for .NET 文件](https://docs.aspose.com/slides/zh-hant/python-net/)
- [Aspose.Slides API 參考文件](https://reference.aspose.com/slides/zh-hant/python-net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/zh-hant/conversion)