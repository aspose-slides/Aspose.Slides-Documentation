---
title: 在 PHP 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: 使用 Aspose.Slides for PHP via Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、圖像、XPS、TIFF 等多種格式。
---
## **概述**

Aspose.Slides for PHP via Java 能夠載入 PowerPoint 和 OpenDocument 簡報，且可在不依賴 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其保存或呈現為多種其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發布為 HTML，或將投影片渲染為圖像檔案，以用於預覽、縮圖與存檔。

大多數文件轉換都遵循相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用格式特定的選項。對於圖像格式，每張投影片會分別渲染，然後儲存為點陣圖或向量圖。以下連結的專門文章提供了各案例的實作細節。

## **選擇轉換情境**

請使用以下文章取得完整的 PHP 範例與格式特定的選項。

| 情境 | 需要時使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉換為 PPTX | 將舊版 PPT 檔案現代化、標準化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [轉換 PPT 為 PPTX](/slides/zh-hant/php-java/convert-ppt-to-pptx/), [轉換 ODP 為 PPTX](/slides/zh-hant/php-java/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/php-java/save-presentation/) |
| PPTX 轉換為 PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以兼容較舊的工作流程。 | [轉換 PPTX 為 PPT](/slides/zh-hant/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉換為 PDF | 建立可攜帶、可搜尋、固定版面的文件，以便分享、列印或存檔。 | [轉換 PowerPoint 為 PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉換為 PDF（含備註） | 匯出投影片內容與講者備註。 | [轉換 PowerPoint 為 PDF（含備註）](/slides/zh-hant/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉換為 HTML | 將簡報發布為 HTML 頁面，並控制圖像、字型、備註與回應式版面選項。 | [轉換 PowerPoint 為 HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉換為 HTML5 | 將投影片匯出為 HTML5，以便在瀏覽器中以保留格式與互動性的方式檢視。 | [轉換簡報為 HTML5](/slides/zh-hant/php-java/export-to-html5/) |
| PPT/PPTX/ODP 轉換為 PNG | 將每張投影片渲染為 PNG 圖像，以供預覽、縮圖或網頁輸出。 | [轉換 PowerPoint 為 PNG](/slides/zh-hant/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉換為 JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [轉換 PowerPoint 為 JPG](/slides/zh-hant/php-java/convert-powerpoint-to-jpg/) |
| 投影片轉換為 SVG | 將單一投影片匯出為可縮放向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉換為 XPS | 產生固定版面的 XPS 文件。 | [轉換 PowerPoint 為 XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉換為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或存檔工作流程使用。 | [轉換 PowerPoint 為 TIFF](/slides/zh-hant/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉換為 TIFF（含備註） | 將投影片與講者備註一起儲存為 TIFF。 | [轉換 PowerPoint 為含備註的 TIFF](/slides/zh-hant/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉換為 Markdown | 將簡報內容提取為 Markdown，以供文件編寫與文字為主的工作流程。 | [轉換 PowerPoint 為 Markdown](/slides/zh-hant/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP 轉換為 XML | 建立以文字為基礎的 PowerPoint XML 簡報，以便檢查、比較、故障排除或基於 XML 的工作流程。 | [轉換 PowerPoint 為 XML](/slides/zh-hant/php-java/convert-powerpoint-to-xml/) |
| PPT/PPTX 轉換為動畫 GIF | 從投影片建立動畫 GIF。 | [轉換 PowerPoint 為動畫 GIF](/slides/zh-hant/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉換為影片 | 建立從簡報投影片導出的影片工作流程。 | [轉換 PowerPoint 為影片](/slides/zh-hant/php-java/convert-powerpoint-to-video/) |
| 簡報轉換為 XAML | 將投影片匯出為 XAML，以供 PHP 或 Java UI 情境使用。 | [匯出簡報為 XAML](/slides/zh-hant/php-java/export-to-xaml/) |

欲查看更完整的輸入與輸出格式清單，請參閱[Supported File Formats](/slides/zh-hant/php-java/supported-file-formats/).

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for PHP via Java 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 與 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需將輸入檔案改為 ODP 即可套用。

在轉換 ODP 檔案時，請注意 PowerPoint 與 OpenDocument 應用程式並非以完全相同的方式支援所有版面配置與格式設定。如果 ODP 檔案是於 LibreOffice 或 OpenOffice Impress 中建立，請檢查輸出結果，並在需要格式特定指引時使用[轉換 OpenDocument 簡報](/slides/zh-hant/php-java/convert-openoffice-odp/)中所述的選項。

## **PPT 轉換為 PPTX**

PPT 是較舊的二進位 PowerPoint 格式，而 PPTX 則是現代的 Office Open XML 格式。Aspose.Slides for PHP via Java 支援高保真度的 PPT 轉換為 PPTX，並保留如母版、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理與圖片填充等複雜簡報結構。

如需詳細資訊，請參閱[轉換 PPT 為 PPTX](/slides/zh-hant/php-java/convert-ppt-to-pptx/)與[PPT 與 PPTX 比較](/slides/zh-hant/php-java/ppt-vs-pptx/)。

## **固定版面匯出**

當輸出需在各裝置上保持相同外觀且不應以簡報形式編輯時，PDF、XPS 與 TIFF 相當有用。專門的 PDF、XPS 與 TIFF 文章說明如何控制合規性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出尺寸。

## **HTML 與圖像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網站發布與輕量分享。圖像匯出則在每張投影片需成為單獨的預覽圖、縮圖或點陣資產時相當有用。請參考 PNG、JPG 與 SVG 文章以取得格式特定的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 來轉換簡報嗎？**

不需要。Aspose.Slides for PHP via Java 為獨立的函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報，將其儲存為所需格式，處理完畢後釋放簡報物件。若要平行處理，請使用個別的簡報實例，並遵循[多執行緒](/slides/zh-hant/php-java/multithreading/)指引。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳遞投影片索引或僅渲染個別投影片，具體取決於輸出格式。請參閱該目標格式的專門文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。使用在[PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)與[XPS](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供符合 PDF/A 的設定。詳情請參閱[轉換 PowerPoint 為 PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用嵌入字型、備用字型與字型取代設定。請參閱[嵌入字型](/slides/zh-hant/php-java/embedded-font/)、[備用字型](/slides/zh-hant/php-java/fallback-font/)與[字型取代](/slides/zh-hant/php-java/font-substitution/)。