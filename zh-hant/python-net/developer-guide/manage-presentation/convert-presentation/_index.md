---
title: 在 Python 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/python-net/convert-presentation/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET，將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概述**

Aspose.Slides for Python via .NET 可以載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將它們儲存或轉換為許多其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發布為 HTML，或將投影片渲染為影像檔案以作預覽、縮圖與存檔。

大多數文件轉換使用相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣或向量影像。下面的專屬文章提供了每種情況的實作細節。

## **選擇轉換情境**

使用下列文章取得完整的 Python 範例與格式特定選項。

| 情境 | 當需要...時使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 將舊版 PPT 檔案現代化、正規化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/python-net/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/python-net/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/python-net/save-presentation/) |
| PPTX to PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以相容舊有工作流程。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 建立可攜帶、可搜尋、固定版面的文件，以供分享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 將投影片說明與投影片內容一起匯出。 | [將 PowerPoint 轉換為含說明的 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 將簡報發布為 HTML 頁面，並控制影像、字型、說明以及響應式版面選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中檢視，保留格式與互動性。 | [將簡報轉換為 HTML5](/slides/zh-hant/python-net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 將每張投影片渲染為 PNG 影像，以作預覽、縮圖或網頁輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 將投影片渲染為 JPG 影像，並控制影像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/python-net/convert-powerpoint-to-jpg/) |
| Slide to SVG | 將單一投影片匯出為可伸縮向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 將簡報儲存為多頁 TIFF 檔，用於列印、掃描、傳真或存檔工作流程。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 將含說明的投影片儲存為 TIFF。 | [將 PowerPoint 轉換為含說明的 TIFF](/slides/zh-hant/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP to Word | 在需要文件樣式輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP to Markdown | 將簡報內容提取為 Markdown，以便於文件編寫與文字工作流程。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to animated GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP to video | 從簡報投影片建立影片匯出工作流程。 | [將 PowerPoint 轉換為 Video](/slides/zh-hant/python-net/convert-powerpoint-to-video/) |
| Presentation to XAML | 將投影片匯出為 XAML，以用於 Python 或 .NET UI 情境。 | [Export Presentations to XAML](/slides/zh-hant/python-net/export-to-xaml/) |

欲查看更完整的輸入與輸出格式清單，請參閱[支援的檔案格式](/slides/zh-hant/python-net/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Python via .NET 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 與 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需將輸入檔案改為 ODP 即可套用。

轉換 ODP 檔案時，請留意 PowerPoint 與 OpenDocument 應用程式並非以完全相同的方式支援所有版面與格式功能。若 ODP 檔案是於 LibreOffice 或 OpenOffice Impress 中建立，請檢視輸出結果，並在需要特定格式指引時使用[轉換 OpenDocument 簡報](/slides/zh-hant/python-net/convert-openoffice-odp/)中描述的選項。

## **PPT 轉換為 PPTX**

PPT 為較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for Python via .NET 支援高保真度的 PPT 轉換為 PPTX，且能保留複雜的簡報結構，例如母片、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理與圖片填充。

欲了解更多，請參閱[將 PPT 轉換為 PPTX](/slides/zh-hant/python-net/convert-ppt-to-pptx/)以及[PPT 與 PPTX 比較](/slides/zh-hant/python-net/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在輸出需在各裝置上保持相同外觀且不作為簡報編輯時非常有用。專屬的 PDF、XPS 與 TIFF 文章說明了如何控制符合性、隱藏投影片、說明、影像品質、壓縮、像素格式與輸出尺寸。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網路發布與輕量分享。影像匯出則適合將每張投影片變為獨立的預覽、縮圖或點陣資產。請參考 PNG、JPG 與 SVG 文章，以取得特定格式的渲染指引。

## **FAQ**

**我需要 Microsoft PowerPoint 來轉換簡報嗎？**

不需要。Aspose.Slides for Python via .NET 是獨立的函式庫，並不需要 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報，將其儲存為所需格式，處理完畢後釋放簡報物件。如需平行處理，請使用獨立的簡報實例，並遵循[多執行緒](/slides/zh-hant/python-net/multithreading/)指引。

**我只能匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳遞投影片索引或單獨渲染投影片，具體取決於輸出格式。請參考目標格式的專屬文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。使用在[PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)與[XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供合規性設定。詳情請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型取代設定。請參閱[Embedded Font](/slides/zh-hant/python-net/embedded-font/)、[Fallback Font](/slides/zh-hant/python-net/fallback-font/)以及[Font Substitution](/slides/zh-hant/python-net/font-substitution/)。