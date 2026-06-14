---
title: 在 PHP 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概要**

Aspose.Slides for PHP via Java 能夠載入 PowerPoint 與 OpenDocument 簡報，並在沒有 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其儲存或轉換成許多其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發布為 HTML，或將投影片渲染為影像檔，以供預覽、縮圖與存檔使用。

大多數文件轉換遵循相同的工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於影像格式，每一張投影片皆會分別渲染，然後儲存為點陣或向量影像。下列專屬文章提供每種情況的實作細節。

## **選擇轉換情境**

使用下列文章取得完整的 PHP 範例與格式特定選項。

| 情境 | 何時使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉 PPTX | 現代化舊版 PPT 檔案、統一現有 PPTX 檔案，或將 OpenDocument 簡報轉為 PowerPoint PPTX。 | [Convert PPT to PPTX](/slides/zh-hant/php-java/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/zh-hant/php-java/convert-odp-to-pptx/), [Save Presentations](/slides/zh-hant/php-java/save-presentation/) |
| PPTX 轉 PPT | 將現代 PowerPoint 簡報儲存為舊版二進位 PPT 格式，以相容舊有工作流程。 | [Convert PPTX to PPT](/slides/zh-hant/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉 PDF | 建立可攜帶、可搜尋的固定版面文件，以便分享、列印或存檔。 | [Convert PowerPoint to PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉 PDF（含備註） | 匯出投影片內容與講者備註。 | [Convert PowerPoint to PDF with Notes](/slides/zh-hant/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉 HTML | 將簡報發布為 HTML 頁面，並控制影像、字型、備註與回應式版面選項。 | [Convert PowerPoint to HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉 HTML5 | 匯出投影片為 HTML5，以在瀏覽器中保留格式與互動性。 | [Convert Presentations to HTML5](/slides/zh-hant/php-java/export-to-html5/) |
| PPT/PPTX/ODP 轉 PNG | 將每張投影片渲染為 PNG 影像，以供預覽、縮圖或網路輸出。 | [Convert PowerPoint to PNG](/slides/zh-hant/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉 JPG | 將投影片渲染為 JPG 影像，並控制尺寸與品質。 | [Convert PowerPoint to JPG](/slides/zh-hant/php-java/convert-powerpoint-to-jpg/) |
| 投影片轉 SVG | 匯出單一投影片為可縮放向量圖形。 | [Render Slide as SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉 XPS | 產生固定版面 XPS 文件。 | [Convert PowerPoint to XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉 TIFF | 將簡報儲存為多頁 TIFF 檔，以供列印、掃描、傳真或存檔工作流程使用。 | [Convert PowerPoint to TIFF](/slides/zh-hant/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉 TIFF（含備註） | 將投影片與講者備註一起儲存為 TIFF。 | [Convert PowerPoint to TIFF with Notes](/slides/zh-hant/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉 Markdown | 將簡報內容提取為 Markdown，供文件與文字工作流程使用。 | [Convert PowerPoint to Markdown](/slides/zh-hant/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX 轉動畫 GIF | 從投影片建立動畫 GIF。 | [Convert PowerPoint to Animated GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉影片 | 建立從簡報投影片導出的影片工作流程。 | [Convert PowerPoint to Video](/slides/zh-hant/php-java/convert-powerpoint-to-video/) |
| 簡報轉 XAML | 將投影片匯出為 XAML，供 PHP 或 Java UI 情境使用。 | [Export Presentations to XAML](/slides/zh-hant/php-java/export-to-xaml/) |

若需更完整的輸入與輸出格式清單，請參閱[Supported File Formats](/slides/zh-hant/php-java/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for PHP via Java 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 以及 ODP）進行轉換。同一套轉換 API 可同時用於 PowerPoint 與 OpenDocument 檔案，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只要將輸入檔改為 ODP 即可套用。

轉換 ODP 檔案時，請記得 PowerPoint 與 OpenDocument 應用程式並非完全以相同方式支援所有版面與格式功能。如果 ODP 檔案是使用 LibreOffice 或 OpenOffice Impress 建立，請檢視輸出結果，並在需要格式特定指引時參考[Convert OpenDocument Presentations](/slides/zh-hant/php-java/convert-openoffice-odp/)中的選項說明。

## **PPT 轉 PPTX 轉換**

PPT 為較舊的二進位 PowerPoint 格式，PPTX 則是現代的 Office Open XML 格式。Aspose.Slides for PHP via Java 支援高保真度的 PPT 轉 PPTX 轉換，並保留包含母片、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理與圖片填充等複雜結構。

更多細節請參閱[Convert PPT to PPTX](/slides/zh-hant/php-java/convert-ppt-to-pptx/)與[PPT vs PPTX](/slides/zh-hant/php-java/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在需要讓輸出在不同設備上保持一致且不被視為可編輯簡報時非常有用。各自的 PDF、XPS、TIFF 文章說明了如何控制合規性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出大小。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適合瀏覽器觀看、網路發布與輕量分享。影像匯出則適用於每張投影片需轉為單獨的預覽、縮圖或點陣資產的情境。請參考 PNG、JPG 與 SVG 文章取得格式特定的渲染指引。

## **FAQ**

**我需要 Microsoft PowerPoint 才能轉換簡報嗎？**

不需要。Aspose.Slides for PHP via Java 是獨立的程式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換大量簡報嗎？**

可以。載入每份簡報後，將其儲存為所需格式，處理完畢後釋放簡報物件。若需要平行處理，請使用獨立的簡報實例，並遵循[multithreading](/slides/zh-hant/php-java/multithreading/)指引。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳入投影片索引或單獨渲染投影片，具體視目標格式而定。請參閱該格式的專屬文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏投影片嗎？**

可以。請使用[PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)與[XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供合規性設定。詳情請參閱[Convert PowerPoint to PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替代設定。請參閱[Embedded Font](/slides/zh-hant/php-java/embedded-font/)、[Fallback Font](/slides/zh-hant/php-java/fallback-font/)與[Font Substitution](/slides/zh-hant/php-java/font-substitution/)。