---
title: 使用 Python 轉換簡報為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/python-java/convert-presentation/
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
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概觀**

Aspose.Slides for Python via Java 可以載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其儲存或轉換為多種其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發佈為 HTML，或將投影片渲染為圖像檔案以作預覽、縮圖與存檔。

大多數文件轉換使用相同的一般工作流程：載入來源檔案，選擇所需的輸出格式，然後在需要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣圖或向量圖像。下方的相關文章提供了每種情況的實作細節。

## **選擇轉換情境**

以下文章提供完整的 Python 範例與特定格式選項。

| 情境 | 使用需求 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 將舊版 PPT 檔案現代化、標準化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/python-java/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/python-java/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/python-java/save-presentation/) |
| PPTX to PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以符合舊有工作流程的相容性。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/python-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 建立可攜帶、可搜尋、固定版面的文件，以供分享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 同時匯出講者備註與投影片內容。 | [將 PowerPoint 轉換為 PDF（含備註）](/slides/zh-hant/python-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 將簡報發佈為 HTML 頁面，且可控制圖像、字型、備註與響應式版面選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中以保留格式與互動性的方式檢視。 | [將簡報匯出為 HTML5](/slides/zh-hant/python-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 將每張投影片渲染為 PNG 圖像，以作預覽、縮圖或網頁輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/python-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 將投影片渲染為 JPG 圖像，並可控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/python-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | 將單一投影片匯出為可縮放向量圖形（SVG）。 | [將投影片渲染為 SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或存檔工作流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/python-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 將含講者備註的投影片儲存為 TIFF。 | [將 PowerPoint 轉換為 TIFF（含備註）](/slides/zh-hant/python-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 當需要文檔式輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/python-java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | 將簡報內容提取為 Markdown，以供文件編寫與文字工作流程使用。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/python-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | 建立以文字為基礎的 PowerPoint XML 簡報，以供檢查、比較、故障排除或 XML 工作流程使用。 | [將 PowerPoint 轉換為 XML](/slides/zh-hant/python-java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/python-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 從簡報投影片建立影片匯出工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/python-java/convert-powerpoint-to-video/) |
| Presentation to XAML | 將投影片匯出為 XAML，以用於 WPF 應用程式。 | [將簡報匯出為 XAML](/slides/zh-hant/python-java/export-to-xaml/) |

若需更完整的輸入與輸出格式清單，請參閱[支援的檔案格式](/slides/zh-hant/python-java/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Python via Java 支援從常用的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 以及 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需將輸入檔案改為 ODP 即可套用。

轉換 ODP 檔案時，請記住 PowerPoint 與 OpenDocument 應用程式並未以完全相同的方式支援每項版面與格式功能。如果 ODP 檔案是使用 LibreOffice 或 OpenOffice Impress 建立的，請檢查輸出結果，並在需要特定格式指引時使用[將 OpenDocument 簡報轉換](/slides/zh-hant/python-java/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 是較舊的二進位 PowerPoint 格式，而 PPTX 是現代的 Office Open XML 格式。Aspose.Slides for Python via Java 支援高保真度的 PPT 轉換為 PPTX，並保留複雜的簡報結構，如母片、版面配置、投影片、圖表、群組圖形、佔位元、文字框、紋理與圖片填充。

欲了解詳情，請參閱[將 PPT 轉換為 PPTX](/slides/zh-hant/python-java/convert-ppt-to-pptx/)和[PPT 與 PPTX 比較](/slides/zh-hant/python-java/ppt-vs-pptx/)。

## **固定版面匯出**

當輸出需要在各裝置上保持相同外觀且不應被編輯為簡報時，PDF、XPS 與 TIFF 十分有用。專門的 PDF、XPS 與 TIFF 文章說明了如何控制合規性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出尺寸。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網頁發佈與輕量分享。影像匯出則在每張投影片需成為單獨的預覽、縮圖或點陣資產時非常有用。請參考 PNG、JPG 與 SVG 文章以取得特定格式的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 才能轉換簡報嗎？**

不需要。Aspose.Slides for Python via Java 是獨立的函式庫，並不需要 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報，將其儲存為所需格式，處理完畢後釋放簡報物件。若需平行處理，請使用獨立的簡報實例，並遵循[多執行緒](/slides/zh-hant/python-java/multithreading/) 指南。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳遞投影片索引或渲染單一投影片，具體取決於輸出格式。請參閱該目標格式的專門文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。使用在[將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)與[將 PowerPoint 轉換為 XPS](/slides/zh-hant/python-java/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供符合 PDF/A 的設定。詳情請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用嵌入式字型、字型備援與字型取代設定。請參閱[嵌入字型](/slides/zh-hant/python-java/embedded-font/)、[備援字型](/slides/zh-hant/python-java/fallback-font/)與[字型取代](/slides/zh-hant/python-java/font-substitution/)。