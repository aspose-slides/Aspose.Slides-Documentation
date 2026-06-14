---
title: 在 Android 上將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/androidjava/convert-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等格式。"
---
## **概述**

Aspose.Slides for Android via Java 能夠載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其保存或轉換為多種其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發布為 HTML，或將投影片渲染為圖像檔案以供預覽、縮圖與存檔。

大多數文件轉換遵循相同的一般工作流程：載入來源檔案、選取所需的輸出格式，必要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣或向量影像。以下連結的專門文章提供各種情況的實作細節。

## **選擇轉換情境**

以下文章提供完整的 Java 範例與特定格式的選項。

| 情境 | 當您需要… | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 將舊版 PPT 檔案現代化、正規化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [轉換 PPT 為 PPTX](/slides/zh-hant/androidjava/convert-ppt-to-pptx/), [轉換 ODP 為 PPTX](/slides/zh-hant/androidjava/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/androidjava/save-presentation/) |
| PPTX to PPT | 將現代 PowerPoint 簡報儲存為舊的二進位 PPT 格式，以符合舊有工作流程的相容性。 | [轉換 PPTX 為 PPT](/slides/zh-hant/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 建立可攜帶、可搜尋、固定版面的文件，以供分享、列印或保存。 | [轉換 PowerPoint 為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 同時匯出講者備註與投影片內容。 | [轉換 PowerPoint 為 PDF（含備註）](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 將簡報發布為 HTML 頁面，並控制圖像、字型、備註與回應式版面選項。 | [轉換 PowerPoint 為 HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中保留格式與互動功能。 | [轉換簡報為 HTML5](/slides/zh-hant/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 將每張投影片渲染為 PNG 圖像，以供預覽、縮圖或網頁輸出。 | [轉換 PowerPoint 為 PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [轉換 PowerPoint 為 JPG](/slides/zh-hant/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | 將單一投影片匯出為可縮放向量圖形 (SVG)。 | [將投影片渲染為 SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 產生固定版面的 XPS 文件。 | [轉換 PowerPoint 為 XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或保存工作流程使用。 | [轉換 PowerPoint 為 TIFF](/slides/zh-hant/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 將投影片與講者備註一起儲存為 TIFF。 | [轉換 PowerPoint 為 TIFF（含備註）](/slides/zh-hant/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 當需要文檔樣式的輸出時，將投影片轉換為 Word 文件。 | [轉換 PowerPoint 為 Word](/slides/zh-hant/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | 將簡報內容提取為 Markdown，以用於文件編寫與文字流程。 | [轉換 PowerPoint 為 Markdown](/slides/zh-hant/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | 從投影片建立動畫 GIF。 | [轉換 PowerPoint 為動畫 GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 從簡報投影片建立影片匯出工作流程。 | [轉換 PowerPoint 為影片](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | 將投影片匯出為 XAML，以用於 Android 或 Java UI 情境。 | [匯出簡報為 XAML](/slides/zh-hant/androidjava/export-to-xaml/) |

欲檢視更完整的輸入與輸出格式清單，請參考 [支援的檔案格式](/slides/zh-hant/androidjava/supported-file-formats/).

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Android via Java 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 與 ODP）進行轉換。同一套轉換 API 可同時用於 PowerPoint 與 OpenDocument 檔案，因此只要將輸入檔案改為 ODP，即可使用將 PPTX 儲存為 PDF 的工作流程。

轉換 ODP 檔案時，請記得 PowerPoint 與 OpenDocument 應用程式在版面與格式功能的支援上並不完全相同。若 ODP 檔案是於 LibreOffice 或 OpenOffice Impress 中建立，請檢視輸出結果，並在需要特定格式指引時使用 [Convert OpenDocument Presentations](/slides/zh-hant/androidjava/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 為較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for Android via Java 支援高保真度的 PPT 轉換為 PPTX，並保留包括母片、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理與圖片填充等複雜結構。

詳情請參考 [Convert PPT to PPTX](/slides/zh-hant/androidjava/convert-ppt-to-pptx/) 與 [PPT vs PPTX](/slides/zh-hant/androidjava/ppt-vs-pptx/)。

## **固定版面匯出**

當輸出需要在各裝置上保持一致且不應被編輯為簡報時，PDF、XPS 與 TIFF 非常實用。專門的 PDF、XPS 與 TIFF 文章說明如何控制符合性、隱藏投影片、備註、圖像品質、壓縮、像素格式與輸出大小。

## **HTML 與圖像匯出**

HTML 與 HTML5 匯出適用於瀏覽器觀看、網路發布與輕量分享。圖像匯出則在每張投影片需轉為獨立的預覽、縮圖或點陣資產時非常有用。請參考 PNG、JPG 與 SVG 文章以取得特定格式的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 來轉換簡報嗎？**

不需要。Aspose.Slides for Android via Java 是獨立的函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報，將其保存為所需格式，處理完畢後釋放簡報物件。若要平行處理，請使用不同的簡報實例，並遵循 [multithreading](/slides/zh-hant/androidjava/multithreading/) 指南。

**我可以只匯出選取的投影片嗎？**

可以。依照輸出格式的不同，許多匯出方法允許您傳入投影片索引或渲染個別投影片。請參閱該目標格式的專門文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。請使用在 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) 與 [XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供符合 PDF/A 的設定。詳情請參閱 [Convert PowerPoint to PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可以使用內嵌字型、字型備援與字型替代設定。請參考 [Embedded Font](/slides/zh-hant/androidjava/embedded-font/)、[Fallback Font](/slides/zh-hant/androidjava/fallback-font/) 與 [Font Substitution](/slides/zh-hant/androidjava/font-substitution/)。