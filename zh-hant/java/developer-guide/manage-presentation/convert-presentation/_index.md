---
title: 在 Java 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、圖像、XPS、TIFF 等多種格式。"
---
## **概觀**

Aspose.Slides for Java 可以載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下將其儲存或轉換為許多其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX、將簡報匯出為 PDF 和 XPS 等固定版面文件、將投影片發佈為 HTML，或將投影片渲染為圖像檔案以作預覽、縮圖和存檔。

大多數文件轉換使用相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於圖像格式，每張投影片會分別渲染，然後儲存為點陣或向量圖像。以下連結的專門文章提供每種情況的實作細節。

## **選擇轉換情境**

使用以下文章取得完整的 Java 範例與特定格式的選項。

| 情境 | 何時需要使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉換為 PPTX | 將舊版 PPT 檔案現代化、標準化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/java/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/java/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/java/save-presentation/) |
| PPTX 轉換為 PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以符合舊有工作流程的相容性。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉換為 PDF | 建立可攜帶、可搜尋、固定版面的文件，以供分享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉換為 PDF 含備註 | 同時匯出講者備註與投影片內容。 | [將 PowerPoint 轉換為含備註的 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉換為 HTML | 將簡報發佈為 HTML 頁面，並控制圖像、字型、備註與響應式版面選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉換為 HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中保留格式與互動性進行檢視。 | [將簡報轉換為 HTML5](/slides/zh-hant/java/export-to-html5/) |
| PPT/PPTX/ODP 轉換為 PNG | 將每張投影片渲染為 PNG 圖像，以作預覽、縮圖或網頁輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉換為 JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/java/convert-powerpoint-to-jpg/) |
| 投影片轉換為 SVG | 將單一投影片匯出為可縮放向量圖形 (SVG)。 | [將投影片渲染為 SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉換為 XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉換為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以用於列印、掃描、傳真或存檔工作流程。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉換為 TIFF 含備註 | 將含講者備註的投影片儲存為 TIFF。 | [將 PowerPoint 轉換為含備註的 TIFF](/slides/zh-hant/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉換為 Word | 當需要文件式輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/java/convert-powerpoint-to-word/) |
| PPT/PPTX 轉換為 Markdown | 將簡報內容提取為 Markdown，供文件編寫與文字為主的工作流程使用。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP 轉換為 XML | 建立文字型 PowerPoint XML 簡報，以供檢查、比較、除錯或基於 XML 的工作流程使用。 | [將 PowerPoint 轉換為 XML](/slides/zh-hant/java/convert-powerpoint-to-xml/) |
| PPT/PPTX 轉換為動畫 GIF | 以投影片製作動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉換為影片 | 從簡報投影片建立影片匯出工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/java/convert-powerpoint-to-video/) |
| 簡報轉換為 XAML | 將投影片匯出為 XAML，以用於 Java UI 情境。 | [將簡報匯出為 XAML](/slides/zh-hant/java/export-to-xaml/) |

欲查看更完整的輸入與輸出格式清單，請參閱[支援的檔案格式](/slides/zh-hant/java/supported-file-formats/).

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Java 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 與 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需更改輸入檔案即可套用於 ODP 檔案。

在轉換 ODP 檔案時，請記得 PowerPoint 與 OpenDocument 應用程式並不完全以相同方式支援所有版面配置與格式設定。若 ODP 檔案是使用 LibreOffice 或 OpenOffice Impress 建立，請檢視輸出結果，並在需要特定格式指引時使用[轉換 OpenDocument 簡報](/slides/zh-hant/java/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 是較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for Java 支援高保真度的 PPT 轉換為 PPTX，並保留複雜的簡報結構，如母片、版面配置、投影片、圖表、群組圖形、占位符、文字框、紋理與圖片填充。

欲了解更多細節，請參閱[將 PPT 轉換為 PPTX](/slides/zh-hant/java/convert-ppt-to-pptx/) 與[PPT 與 PPTX 比較](/slides/zh-hant/java/ppt-vs-pptx/)。

## **固定版面匯出**

當輸出需要在各裝置上保持相同外觀且不應被編輯為簡報時，PDF、XPS 與 TIFF 非常有用。專門的 PDF、XPS、TIFF 文章說明如何控制相容性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出大小。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網路發佈與輕量分享。影像匯出則在每張投影片需成為獨立的預覽、縮圖或點陣資產時非常實用。請參考 PNG、JPG 與 SVG 文章取得特定格式的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 來轉換簡報嗎？**

不需要。Aspose.Slides for Java 為獨立庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報，將其儲存為所需格式，並在處理完畢後釋放簡報物件。若需平行處理，請使用不同的簡報實例，並遵循[多執行緒](/slides/zh-hant/java/multithreading/) 指南。

**我只能匯出選取的投影片嗎？**

可以。依據輸出格式，有多種匯出方法可讓您傳遞投影片索引或渲染單一投影片。請參閱目標格式的專門文章。

**在匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。使用在[PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) 與[XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供合規性設定以支援 PDF/A。詳情請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替代設定。請參閱[內嵌字型](/slides/zh-hant/java/embedded-font/)、[備援字型](/slides/zh-hant/java/fallback-font/) 與[字型替代](/slides/zh-hant/java/font-substitution/)。