---
title: 在 Python 中將 PPT 與 PPTX 轉換為 PDF | 進階選項
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- 轉換 PowerPoint
- 簡報
- PowerPoint 轉 PDF
- PPT 轉 PDF
- PPTX 轉 PDF
- 將 PowerPoint 儲存為 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "逐步指南，說明如何使用 Aspose.Slides 在 Python 中將 PPT、PPTX 與 ODP 轉換為高品質、符合 WCAG 標準的 PDF——包括密碼保護、投影片選擇與影像品質控制。"
showReadingTime: true
---
## **概觀**

在 Python 中將 PowerPoint 簡報 (PPT、PPTX、ODP) 轉換為 PDF 格式具有多項優勢，包括確保在不同裝置上的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 文件設定密碼保護、偵測字型替代、選取特定投影片進行轉換，以及對輸出文件套用符合性標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中將簡報轉換為 PDF，只需將檔案名稱作為參數傳遞給 [簡報](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別，然後使用 [儲存](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[簡報](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別提供的 [儲存](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python 會將其 API 資訊與版本號插入輸出文件。例如，當它將簡報轉換為 PDF 時，Aspose.Slides for Python 會在 Application 欄位填入「*Aspose.Slides*」值，並在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意**，您無法指示 Aspose.Slides for Python 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報為 PDF
* 簡報中的特定投影片為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 內容與原始簡報高度相符。轉換過程中會精確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 清單符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試以最佳設定、最高品質層級將提供的簡報轉換為 PDF。

以下範例載入簡報並使用預設匯出設定將所有可見投影片儲存為 PDF。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)，可示範簡報轉 PDF 的過程。若想實際體驗此處描述的流程，可使用該轉換器進行測試。

{{% /alert %}}

## **將 PowerPoint 轉 PDF（含選項）**

Aspose.Slides 提供自訂選項—屬於 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 類別的屬性—讓您自訂 PDF（轉換過程的結果）、以密碼鎖定 PDF，或指定轉換流程的其他行為。

### **使用自訂選項將 PowerPoint 轉 PDF**

使用自訂轉換選項，您可以設定光柵影像的首選品質、指定圖形檔的處理方式、設定文字的壓縮層級、設定影像的 DPI 等。

以下範例將簡報匯出為 PDF 1.5，設定 JPEG 品質為 90、影像解析度為 300 DPI、圖形檔儲存為 PNG，並使用 Flate 文字壓縮。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **將嵌入的 OLE 檔案保留為 PDF 附件**

若簡報中包含嵌入的 Excel 活頁簿，您可能希望 PDF 接收者同時存取活頁簿資料與檢視投影片。將 [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) 設為 `True` 即可在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `False`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會作為附件包含。將此選項設為 `True` 會額外包含檔案資料。預覽仍為視覺表示；附件則允許接收者另行開啟或儲存嵌入的檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為帶有活頁簿附件的 PDF。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

檢查結果：

1. 使用支援檔案附件的檢視器（例如 Adobe Acrobat Reader）開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板並找到嵌入的活頁簿。
3. 儲存附件並在 Excel 中開啟以檢視其資料，或直接在檢視器允許的情況下開啟。PDF 頁面的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}

PDF/A 標準對附件有所限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 則允許其他檔案類型（包括 Excel 活頁簿）。這些是標準的要求，並非 Aspose.Slides 的限制。本範例使用預設的 PDF 符合性設定，未示範 PDF/A 匯出。

{{% /alert %}}

### **將 PowerPoint 轉 PDF（含隱藏投影片）**

如果簡報包含隱藏投影片，您可以使用自訂選項—[show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 屬性（屬於 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 類別）—指示 Aspose.Slides 在產生的 PDF 中將隱藏投影片也視為頁面加入。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **將 PowerPoint 轉為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **處理沒有專屬粗體字型的字型**

即使字型本身沒有專屬的粗體字型，簡報仍可對文字套用粗體格式。此時會透過合成粗體（synthetic bold）使常規字形變粗。若此文字在 PDF 中看起來過於沉重或與預期外觀不符，可嘗試將 [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) 設為 `True`。此選項在 PDF 匯出時將受影響的文字以點陣圖方式呈現，對某些字型可改善其外觀。預設值為 `False`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個為同一字型且套用粗體格式但未提供專屬粗體字型。以下範例載入簡報、啟用不支援字型樣式的光柵化，並將其匯出為 PDF：

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

以下預覽分別顯示關閉與開啟選項的輸出結果。此範例中，關閉選項時粗體文字的筆劃較重；開啟選項時筆劃較輕，普通文字保持不變。請比較結果後再為您的簡報選擇設定。

| 關閉選項 (`False`，預設) | 開啟選項 (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用選項只會將粗體文字轉為點陣圖：此文字無法被選取、複製，或在未使用 OCR 的情況下搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍保持可搜尋。若關閉選項，兩段文字皆保持文字形式。

此選項會對字型沒有專屬粗體字型的粗體文字進行光柵化。[字型替代](/slides/zh-hant/python-net/font-substitution/) 則會在原始字型無法使用時選擇其他字型。

## **將 PowerPoint 中選取的投影片轉為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號為 1 起始，且輸入簡報必須至少包含三張投影片。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **將 PowerPoint 轉為自訂投影片大小的 PDF**

以下範例將簡報的第一張投影片複製到新簡報，並將投影片大小設定為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應並將單一投影片匯出為 PDF。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 移除新建立的簡報所產生的空白投影片。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **將 PowerPoint 轉為備註投影片檢視的 PDF**

以下範例將簡報匯出為 PDF，並將每張投影片的演講者備註置於投影片下方。請使用包含演講者備註的簡報以查看結果。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF 的可存取性與符合性標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下符合性標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 Python 程式碼示範一個 PowerPoint 轉 PDF 的操作，取得基於不同符合性標準的多個 PDF：

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

{{% alert color="info" title="Note" %}}

Aspose.Slides 支援的 PDF 轉換操作讓您可以將 PDF 轉換為最常見的檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 轉換。其他針對專業格式的 PDF 轉換操作——[PDF 轉 SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)——亦受支援。

{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**Aspose.Slides for Python 能否移除 PDF 中的應用程式資訊？**

不能，Aspose.Slides for Python 會自動在輸出 PDF 中包含 API 資訊與版本號，且此資訊無法修改或移除。

**如何在 PDF 轉換中只包含特定投影片？**

您可以在呼叫 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法時，傳入投影片位置的陣列，以指定要轉換的投影片索引。

**轉換時可以為 PDF 設定密碼保護嗎？**

可以，您可以在保存簡報為 PDF 之前，使用 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 類別設定密碼並定義存取權限。

**Aspose.Slides 是否支援將 PDF 轉換為其他格式？**

是的，Aspose.Slides 支援將 PDF 轉換為 HTML、影像格式（JPG、PNG）、SVG、TIFF 以及 XML 等格式。

**如何確保我的 PDF 符合可存取性標準？**

在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中將 [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) 屬性設定為 `PDF_A1A`、`PDF_A1B` 或 `PDF_UA`，即可確保符合可存取性指南。

**我可以在 PDF 輸出中包含隱藏投影片嗎？**

可以，將 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 屬性於 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中設為 `True`，即可將隱藏投影片納入 PDF。

**如何在轉換過程中調整影像品質與解析度？**

使用 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 與 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 屬性於 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中，分別控制影像品質與解析度。

**Aspose.Slides 會自動處理字型替代嗎？**

Aspose.Slides 會在轉換過程中偵測字型替代，您可以使用 `warning_callback` 屬性於 `SaveOptions` 中自行處理（目前功能有限）。

## **其他資源**

- [Aspose.Slides for Python via .NET 文件](/slides/zh-hant/python-net/)
- [Aspose.Slides API 參考](https://reference.aspose.com/slides/python-net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)