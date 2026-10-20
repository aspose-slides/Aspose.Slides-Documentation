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
description: "使用 Aspose.Slides 在 Python 中逐步將 PPT、PPTX 與 ODP 轉換為高品質、符合 WCAG 標準的 PDF——包括密碼保護、投影片選擇與影像品質控制。"
showReadingTime: true
---
## **概述**

在 Python 中將 PowerPoint 簡報 (PPT、PPTX、ODP) 轉換為 PDF 格式具備多項優勢，包括確保在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 文件設定密碼保護、偵測字體替換、選擇特定投影片進行轉換，以及將合規標準套用至輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要在 Python 中將簡報轉換為 PDF，只需將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別，然後使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python 會在輸出文件中插入其 API 資訊與版本號。例如，當它將簡報轉換為 PDF 時，Aspose.Slides for Python 會在 Application 欄位填入 '*Aspose.Slides*' 的值，並在 PDF Producer 欄位填入 '*Aspose.Slides v XX.XX*' 形式的值。**注意** 您無法指示 Aspose.Slides for Python 更變或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您進行以下轉換：

* 整個簡報轉換為 PDF
* 指定簡報中的投影片轉換為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 內容與原始簡報高度相符。轉換過程中會精確呈現各種元素與屬性，包括：

* 圖片
* 文本框與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。此情況下，Aspose.Slides 會使用最佳設定與最高品質等級嘗試將提供的簡報轉換為 PDF。

以下範例載入一個簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的線上 [**PowerPoint to PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 以示範簡報轉 PDF 的流程。若要實作本說明中的程序，可透過該轉換器進行測試。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項—位於 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 類別下的屬性—讓您自訂 PDF（轉換過程的產出）、以密碼鎖定 PDF，或指定轉換流程的行為。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以設定點陣圖的首選品質、指定中繪圖檔的處理方式、設定文字的壓縮等級、設定影像的 DPI 等。

以下範例將簡報匯出為 PDF 1.5，設定 JPEG 品質為 90、影像解析度為 300 DPI、中繪圖檔儲存為 PNG，並使用 Flate 文字壓縮。

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

### **自動選擇影像壓縮**

當簡報包含大量照片或螢幕擷取圖時，縮小匯出 PDF 的檔案大小可讓寄送或下載更為便利。將 [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) 設為 `True`，即可在 PDF 匯出時自動為每張影像選擇最適合的壓縮演算法。

以下範例載入現有簡報，啟用自動影像壓縮選擇，並將其儲存為 PDF 文件。其他 PDF 匯出設定保持預設值。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

此選項會為每張影像選擇壓縮演算法。降低 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 會降低 JPEG 影像品質；降低 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 允許影像降採樣至較低解析度，可能減少細節。啟用自動壓縮選擇本身不會降低上述任一設定。

選擇影像壓縮演算法會需額外的處理時間與記憶體。縮小幅度取決於簡報中的影像與匯出設定；無法保證每個簡報皆有固定的縮小比例。

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報內嵌了 Excel 工作簿，您可能希望 PDF 接收者同時能取得該工作簿的資料與檢視投影片。將 [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) 設為 `True`，即可在產生的 PDF 中將嵌入的 OLE 檔案保留為附件。

預設值為 `False`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會作為附件包含。將此選項設為 `True` 會額外加入檔案資料。預覽仍為視覺呈現；附件則允許接收者另行開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入式 Excel 工作簿的簡報，並將其匯出為附帶該工作簿的 PDF。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

檢查結果方法：

1. 在支援檔案附件的檢視器（如 Adobe Acrobat Reader）中開啟匯出的 PDF。  
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的工作簿。  
3. 儲存附件並在 Excel 中開啟以檢查其資料，或在檢視器允許時直接開啟。PDF 頁面的預覽與附件是分離的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 允許其他檔案類型，包括 Excel 工作簿。這些是標準的要求，並非 Aspose.Slides 的特定限制。本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將隱藏投影片包含在 PDF 中**

如果簡報包含隱藏投影片，您可以使用自訂選項—[PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 類別中的 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 屬性，指示 Aspose.Slides 將隱藏投影片作為頁面包含於產生的 PDF 中。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **處理沒有專用粗體字型的字體**

即使字型沒有專用的粗體字型，簡報仍可對文字套用粗體格式，系統會透過合成粗體（synthetic bolding）方式人工加粗常規字形。當此類文字在 PDF 中看起來過於粗重或與預期外觀不符時，可嘗試將 [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) 設為 `True`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，對某些字型可改善其外觀。預設值為 `False`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字型（沒有專用粗體）套用粗體格式。以下範例載入簡報，啟用對不支援字型樣式的點陣化，並將其匯出為 PDF：

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

下列預覽分別顯示未啟用與已啟用的輸出結果。在此範例中，未啟用時粗體文字的筆畫較粗；啟用後筆畫較細，普通文字則保持不變。請比較結果後再為您的簡報決定設定。

| 選項停用 (`False`，預設) | 選項啟用 (`True`) |
|---|---|
| ![PDF（未啟用不支援字體樣式點陣化）](unsupported-bold-disabled.png) | ![PDF（已啟用不支援字體樣式點陣化）](unsupported-bold-enabled.png) |

在此範例中，啟用該選項會將僅粗體文字轉為點陣圖：此文字無法被選取、複製或在未使用 OCR 的情況下搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍保持可搜尋狀態。若停用此選項，兩段文字皆保持文字形式。

此選項會在字型沒有專用粗體時將粗體文字點陣化。[字體替換](/slides/zh-hant/python-net/font-substitution/) 則會在原始字型不可用時選擇其他字型。

## **將選取的 PowerPoint 投影片轉換為 PDF**

以下範例將簡報中的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起點，且輸入的簡報必須至少包含三張投影片。

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **使用自訂投影片尺寸將 PowerPoint 轉換為 PDF**

以下範例將簡報的第一張投影片複製到一個新簡報，並設定投影片尺寸為 612 × 792 點（8.5 × 11 吋）。此範例會縮放投影片內容以適應尺寸，並將單一投影片匯出為 PDF。

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # 移除新簡報建立時預設的空白投影片。
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **在備註投影片檢視中將 PowerPoint 轉換為 PDF**

以下範例將簡報匯出為 PDF，並將每張投影片的講者備註置於投影片下方。請使用包含講者備註的簡報以觀察結果。

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **PDF 的可存取性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 和 **PDF/UA**。

此 Python 程式碼示範了根據不同合規標準取得多個 PDF 的 PowerPoint 轉 PDF 轉換操作：

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
Aspose.Slides 支援的 PDF 轉換功能允許您將 PDF 轉換為最常見的檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) 轉換。其他轉換至專業格式的 PDF 操作—[PDF 轉 SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—亦受到支援。
{{% /alert %}}

> **注意:** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會被保留為獨立內容，可能會被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**Aspose.Slides for Python 能從 PDF 中移除應用程式資訊嗎？**  
不會，Aspose.Slides for Python 會自動在輸出 PDF 中加入 API 資訊與版本號。此資訊無法修改或移除。

**如何在 PDF 轉換中僅包含特定投影片？**  
您可以透過將投影片位置的陣列傳遞給 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法，來指定要轉換的投影片索引。

**在轉換過程中是否可以為 PDF 加密保護？**  
可以，您可以在將簡報儲存為 PDF 前，使用 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 類別設定密碼並定義存取權限。

**Aspose.Slides 是否支援將 PDF 轉換為其他格式？**  
是，Aspose.Slides 支援將 PDF 轉換為 HTML、影像格式（JPG、PNG）、SVG、TIFF 以及 XML 等格式。

**如何確保我的 PDF 符合可存取性標準？**  
在 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中設定 [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) 屬性為 `PDF_A1A`、`PDF_A1B` 或 `PDF_UA` 等標準，即可確保符合可存取性指南。

**我可以在 PDF 輸出中包含隱藏投影片嗎？**  
可以，將 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中的 [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) 屬性設為 `True`，即可在 PDF 中包含隱藏投影片。

**在轉換過程中如何調整影像品質與解析度？**  
使用 [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) 中的 [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) 與 [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) 屬性，以控制產生 PDF 時的影像品質與解析度。

**Aspose.Slides 會自動處理字體替換嗎？**  
Aspose.Slides 會在轉換過程中偵測字體替換，您可使用 `SaveOptions` 中的 `warning_callback` 屬性來處理（目前功能有限）。

## **其他資源**

- [Aspose.Slides for Python via .NET 文件](/slides/zh-hant/python-net/)
- [Aspose.Slides API 參考](https://reference.aspose.com/slides/python-net/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/conversion)