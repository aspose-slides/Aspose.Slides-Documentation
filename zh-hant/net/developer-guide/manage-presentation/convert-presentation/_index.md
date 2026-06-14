---
title: 在 .NET 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/net/convert-presentation/
keywords:
- 轉換簡報
- 匯出簡報
- PPT 轉換為 PPTX
- PPTX 轉換為 PPT
- ODP 轉換為 PPTX
- PPT 轉換為 PDF
- PPTX 轉換為 PDF
- ODP 轉換為 PDF
- PPT 轉換為 HTML
- PPTX 轉換為 HTML
- ODP 轉換為 HTML
- PPT 轉換為 PNG
- PPTX 轉換為 PNG
- ODP 轉換為 PNG
- PPTX 轉換為 JPG
- ODP 轉換為 JPG
- PPT 轉換為 XPS
- PPTX 轉換為 XPS
- ODP 轉換為 XPS
- PPT 轉換為 TIFF
- PPTX 轉換為 TIFF
- ODP 轉換為 TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 PowerPoint 和 OpenDocument 簡報轉換為 PPTX、PDF、HTML、圖像、XPS、TIFF 等格式。"
---
## **概述**

Aspose.Slides for .NET 能夠載入 PowerPoint 與 OpenDocument 簡報，並可在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其儲存或轉換為多種其他格式。您可以將舊版 PPT 檔案轉換為新版 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發佈為 HTML，或將投影片渲染為影像檔以供預覽、縮圖與存檔。

大多數文件轉換遵循相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣或向量圖像。下方連結的專題文章提供了各種情況的實作細節。

## **選擇轉換情境**

請參考下列文章，以取得完整的 C# 範例與特定格式的選項。

| 情境 | 當您需要 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉換為 PPTX | 現代化舊版 PPT 檔案、正規化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/net/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/net/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/net/save-presentation/) |
| PPTX 轉換為 PPT | 將現代的 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以相容舊有工作流程。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉換為 PDF | 建立可攜帶、可搜尋、固定版面的文件，以用於共享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉換為 含備註 PDF | 匯出投影片內容與講者備註。 | [將 PowerPoint 轉換為含備註的 PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉換為 HTML | 將簡報發佈為 HTML 頁面，並可控制圖像、字型、備註與回應式版面配置選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉換為 HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中保留格式與互動性地檢視。 | [將簡報匯出為 HTML5](/slides/zh-hant/net/export-to-html5/) |
| PPT/PPTX/ODP 轉換為 PNG | 將每張投影片渲染為 PNG 圖像，以作預覽、縮圖或網站輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉換為 JPG | 將投影片渲染為 JPG 圖像，並可控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/net/convert-powerpoint-to-jpg/) |
| 投影片轉換為 SVG | 將單一投影片匯出為可縮放向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉換為 XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉換為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或存檔流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉換為 含備註 TIFF | 將投影片與講者備註一起儲存為 TIFF。 | [將 PowerPoint 轉換為含備註的 TIFF](/slides/zh-hant/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉換為 Word | 當需要文件式輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/net/convert-powerpoint-to-word/) |
| PPT/PPTX 轉換為 Markdown | 將簡報內容提取為 Markdown，以用於文件編寫與文字為中心的工作流程。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX 轉換為 動態 GIF | 從投影片建立動態 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉換為 影片 | 從簡報投影片建立影片匯出工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/net/convert-powerpoint-to-video/) |
| 簡報轉換為 XAML | 將投影片匯出為 XAML，以供 .NET UI 場景使用。 | [將簡報匯出為 XAML](/slides/zh-hant/net/export-to-xaml/) |

若需更完整的輸入與輸出格式清單，請參閱[支援的檔案格式](/slides/zh-hant/net/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for .NET 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 以及 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案共用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，只要更換輸入檔案，即可同樣適用於 ODP。

轉換 ODP 檔案時，請注意 PowerPoint 與 OpenDocument 應用程式並未以完全相同的方式支援所有版面配置與格式設定。若 ODP 檔案是於 LibreOffice 或 OpenOffice Impress 建立，請檢查輸出結果，並在需要特定格式指引時，使用[轉換 OpenDocument 簡報](/slides/zh-hant/net/convert-openoffice-odp/)中描述的選項。

## **PPT 轉換為 PPTX**

PPT 為較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for .NET 支援高保真度的 PPT 轉換為 PPTX，並保留諸如母版、版面配置、投影片、圖表、群組圖形、占位符、文字框、紋理與圖片填充等複雜的簡報結構。

有關詳細資訊，請參閱[將 PPT 轉換為 PPTX](/slides/zh-hant/net/convert-ppt-to-pptx/)以及[PPT 與 PPTX 比較](/slides/zh-hant/net/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在輸出需在各裝置上保持相同外觀且不應被編輯為簡報時相當有用。請使用[PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/)、[XpsOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/xpsoptions/)、以及[TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/)來控制合規性、隱藏投影片、備註、圖像品質、壓縮、像素格式與輸出大小。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網站發布與輕量分享。影像匯出則在每張投影片必須成為獨立的預覽圖、縮圖或點陣資產時相當有用。請參考 PNG、JPG 與 SVG 相關文章，以取得特定格式的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 來轉換簡報嗎？**

不需要。Aspose.Slides for .NET 為獨立函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報，將其儲存為所需格式，處理完畢後釋放 `Presentation` 物件。若需平行處理，請使用不同的簡報實例，並遵循[多執行緒](/slides/zh-hant/net/multithreading/)指引。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法容許您傳入投影片索引或單獨渲染投影片，具體取決於輸出格式。請參閱該格式的專屬文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。請在[PdfOptions]或[XpsOptions]中使用 `ShowHiddenSlides` 屬性。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 合規性設定可透過[PdfOptions.Compliance]與[PdfCompliance]取得。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替代設定。請參閱[Embedded Font]、[Fallback Font]與[Font Substitution]。