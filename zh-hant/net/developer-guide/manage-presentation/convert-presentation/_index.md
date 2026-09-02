---
title: 在 .NET 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/net/convert-presentation/
keywords:
- 轉換簡報
- 匯出簡報
- PPT 轉 PPTX
- PPTX 轉 PPT
- ODP 轉 PPTX
- PPT 轉 PDF
- PPTX 轉 PDF
- ODP 轉 PDF
- PPT 轉 HTML
- PPTX 轉 HTML
- ODP 轉 HTML
- PPT 轉 PNG
- PPTX 轉 PNG
- ODP 轉 PNG
- PPTX 轉 JPG
- ODP 轉 JPG
- PPT 轉 XPS
- PPTX 轉 XPS
- ODP 轉 XPS
- PPT 轉 TIFF
- PPTX 轉 TIFF
- ODP 轉 TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、圖像、XPS、TIFF 等多種格式。"
---
## **概觀**

Aspose.Slides for .NET 能夠載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將它們儲存或轉換為其他多種格式。您可以將舊版 PPT 檔案轉換為現代 PPTX、將簡報匯出為 PDF、XPS 等固定版面文件、將投影片發佈為 HTML，或將投影片渲染成圖像檔案以供預覽、縮圖與封存使用。

大多數文件轉換遵循相同的基本流程：載入來源檔案、選擇所需的輸出格式，必要時套用特定格式的選項。對於圖像格式，每一張投影片會分別渲染，然後儲存為點陣或向量圖像。以下連結的專屬文章提供了每種情況的實作細節。

## **選擇轉換情境**

使用下列文章取得完整的 C# 範例與格式特定選項。

| 情境 | 使用時機 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 現代化舊版 PPT 檔案、正規化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [Convert PPT to PPTX](/slides/zh-hant/net/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/zh-hant/net/convert-odp-to-pptx/), [Save Presentations](/slides/zh-hant/net/save-presentation/) |
| PPTX to PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以相容舊有工作流程。 | [Convert PPTX to PPT](/slides/zh-hant/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 建立可攜、可搜尋、固定版面的文件，以供分享、列印或封存。 | [Convert PowerPoint to PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 匯出投影片內容與講者備註。 | [Convert PowerPoint to PDF with Notes](/slides/zh-hant/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 將簡報發佈為 HTML 頁面，並控制圖像、字型、備註與回應式版面配置選項。 | [Convert PowerPoint to HTML](/slides/zh-hant/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 匯出投影片為 HTML5，以在瀏覽器中保留格式與互動性。 | [Convert Presentations to HTML5](/slides/zh-hant/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 將每張投影片渲染為 PNG 圖像，以供預覽、縮圖或 Web 輸出。 | [Convert PowerPoint to PNG](/slides/zh-hant/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [Convert PowerPoint to JPG](/slides/zh-hant/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | 匯出單一投影片為可縮放向量圖形。 | [Render Slide as SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 產生固定版面的 XPS 文件。 | [Convert PowerPoint to XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或封存工作流程使用。 | [Convert PowerPoint to TIFF](/slides/zh-hant/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 將投影片與講者備註一併儲存為 TIFF。 | [Convert PowerPoint to TIFF with Notes](/slides/zh-hant/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 需要文件式輸出時，將投影片轉換為 Word 文件。 | [Convert PowerPoint to Word](/slides/zh-hant/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | 將簡報內容抽取為 Markdown，以供文件編寫與文字工作流程使用。 | [Convert PowerPoint to Markdown](/slides/zh-hant/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | 建立文字型 PowerPoint XML Presentation，以供檢視、比較、診斷或基於 XML 的工作流程使用。 | [Convert PowerPoint to XML](/slides/zh-hant/net/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | 從投影片建立動畫 GIF。 | [Convert PowerPoint to Animated GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 建立從簡報投影片導出的影片工作流程。 | [Convert PowerPoint to Video](/slides/zh-hant/net/convert-powerpoint-to-video/) |
| Presentation to XAML | 將投影片匯出為 XAML，以用於 .NET UI 情境。 | [Export Presentations to XAML](/slides/zh-hant/net/export-to-xaml/) |

如需更完整的輸入與輸出格式列表，請參閱 [Supported File Formats](/slides/zh-hant/net/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for .NET 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 與 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需將輸入檔案改成 ODP 即可套用。

轉換 ODP 檔案時，請記住 PowerPoint 與 OpenDocument 應用程式並不會以完全相同的方式支援每一種版面配置與格式設定。如果 ODP 檔案是以 LibreOffice 或 OpenOffice Impress 建立，請檢查輸出結果，並在需要格式特定指引時使用 [Convert OpenDocument Presentations](/slides/zh-hant/net/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 是舊版二進位 PowerPoint 格式，而 PPTX 是現代的 Office Open XML 格式。Aspose.Slides for .NET 支援高度忠實的 PPT 轉 PPTX 轉換，保留複雜的簡報結構，如母片、佈局、投影片、圖表、群組圖形、占位符、文字框、紋理與圖片填充等。

詳情請參閱 [Convert PPT to PPTX](/slides/zh-hant/net/convert-ppt-to-pptx/) 與 [PPT vs PPTX](/slides/zh-hant/net/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在需要跨裝置外觀一致且不作為簡報編輯的情況下非常有用。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/)、[XpsOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/xpsoptions/) 與 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 來控制符合性、隱藏投影片、備註、圖像品質、壓縮、像素格式與輸出大小。

## **HTML 與圖像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、Web 發佈與輕量分享。圖像匯出則在每張投影片需產生獨立預覽、縮圖或點陣資源時很有用。請參考 PNG、JPG 與 SVG 相關文章取得格式特定的渲染指引。

## **常見問答**

**我需要 Microsoft PowerPoint 才能轉換簡報嗎？**

不需要。Aspose.Slides for .NET 為獨立函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以一次批次轉換多份簡報嗎？**

可以。載入每份簡報後儲存為所需格式，處理完畢後釋放 `Presentation` 物件。若要平行處理，請使用不同的簡報實例，並遵循 [multithreading](/slides/zh-hant/net/multithreading/) 指南。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法允許傳入投影片索引或單獨渲染投影片，具體作法請參閱目標格式的專屬文章。

**匯出為 PDF 或 XPS 時我可以包含隱藏的投影片嗎？**

可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 或 [XpsOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/xpsoptions/) 中的 `ShowHiddenSlides` 屬性。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 符合性設定可透過 [PdfOptions.Compliance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/compliance/) 以及 [PdfCompliance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfcompliance/) 取得。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替換設定。請參閱 [Embedded Font](/slides/zh-hant/net/embedded-font/)、[Fallback Font](/slides/zh-hant/net/fallback-font/) 與 [Font Substitution](/slides/zh-hant/net/font-substitution/)。