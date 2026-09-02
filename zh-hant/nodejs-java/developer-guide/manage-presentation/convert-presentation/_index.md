---
title: 在 JavaScript 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: 使用 Aspose.Slides for Node.js via Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、圖像、XPS、TIFF 等格式。
---
## **概述**

Aspose.Slides for Node.js via Java 可以載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下將其儲存或轉換為多種其他格式。您可以將舊版 PPT 檔案轉換為現代的 PPTX，將簡報匯出為 PDF、XPS 等固定版面的文件，將投影片發布為 HTML，或將投影片渲染為圖像檔案以供預覽、縮圖和存檔使用。

大多數文件轉換遵循相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於圖像格式，每張投影片會分別渲染，然後儲存為點陣或向量圖像。下方連結的專門文章提供了每種情況的實作細節。

## **選擇轉換情境**

請使用下方文章取得完整的 JavaScript 範例與特定格式的選項。

| 情境 | 需要時使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉為 PPTX | 將舊版 PPT 檔案升級為現代 PPTX，標準化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/nodejs-java/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/nodejs-java/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/nodejs-java/save-presentation/) |
| PPTX 轉為 PPT | 將現代 PowerPoint 簡報儲存為舊版的二進位 PPT 格式，以符合舊有工作流程的相容性。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉為 PDF | 建立可攜帶、可搜尋且固定版面的文件，以供共享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉為 PDF（含備註） | 將投影片內容與投影片備註一起匯出。 | [將 PowerPoint 轉換為 PDF（含備註）](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉為 HTML | 將簡報發佈為 HTML 頁面，並可控制圖像、字型、備註以及回應式版面配置選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉為 HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中保留格式與互動功能。 | [將簡報轉換為 HTML5](/slides/zh-hant/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP 轉為 PNG | 將每張投影片渲染為 PNG 圖像以供預覽、縮圖或網頁輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉為 JPG | 將投影片渲染為 JPG 圖像，並可控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-jpg/) |
| 投影片 轉為 SVG | 將單一投影片匯出為可伸縮向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉為 XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或存檔工作流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉為 TIFF（含備註） | 將含講者備註的投影片儲存為 TIFF。 | [將 PowerPoint 轉換為 TIFF（含備註）](/slides/zh-hant/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉為 Markdown | 將簡報內容提取為 Markdown，以便文件編寫與文字為主的工作流程。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP 轉為 XML | 建立基於文字的 PowerPoint XML 簡報，以供檢查、比較、故障排除或 XML 為基礎的工作流程使用。 | [將 PowerPoint 轉換為 XML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX 轉為 動畫 GIF | 將投影片製作為動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉為 影片 | 建立從簡報投影片匯出的影片工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) |
| 簡報 轉為 XAML | 將投影片匯出為 XAML，以供 JavaScript 或 Java UI 場景使用。 | [匯出簡報為 XAML](/slides/zh-hant/nodejs-java/export-to-xaml/) |

如需更完整的輸入與輸出格式清單，請參閱 [支援的檔案格式](/slides/zh-hant/nodejs-java/supported-file-formats/).

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Node.js via Java 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 以及 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只要更換輸入檔案即可套用於 ODP。

轉換 ODP 檔案時，請記得 PowerPoint 與 OpenDocument 應用程式並非以完全相同的方式支援所有版面配置與格式設定。若 ODP 檔案是於 LibreOffice 或 OpenOffice Impress 中建立，請檢視輸出結果，並在需要特定格式指引時使用 [轉換 OpenDocument 簡報](/slides/zh-hant/nodejs-java/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 為較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for Node.js via Java 支援高保真度的 PPT 轉換為 PPTX，並保留諸如母片、版面配置、投影片、圖表、群組形狀、佔位符、文字框、紋理與圖片填充等複雜的簡報結構。

如需詳細資訊，請參閱 [將 PPT 轉換為 PPTX](/slides/zh-hant/nodejs-java/convert-ppt-to-pptx/) 以及 [PPT 與 PPTX 比較](/slides/zh-hant/nodejs-java/ppt-vs-pptx/)。

## **固定版面匯出**

當輸出需要在各種裝置上保持相同外觀且不應被編輯為簡報時，PDF、XPS 與 TIFF 非常實用。專門針對 PDF、XPS 與 TIFF 的文章說明了如何控制合規性、隱藏投影片、備註、圖像品質、壓縮、像素格式與輸出大小。

## **HTML 與圖像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網站發布與輕量共享。圖像匯出則在每張投影片需轉為單獨的預覽圖、縮圖或點陣資產時相當有用。請參考 PNG、JPG 與 SVG 文章，以取得特定格式的渲染指引。

## **常見問題**

**是否需要 Microsoft PowerPoint 來轉換簡報？**

不需要。Aspose.Slides for Node.js via Java 是獨立的函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報後，將其儲存為所需格式，並在處理完畢後釋放簡報物件。若要平行處理，請使用獨立的簡報實例，並遵循 [多執行緒](/slides/zh-hant/nodejs-java/multithreading/) 指南。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳遞投影片索引或渲染單一投影片，具體取決於輸出格式。請參閱針對目標格式的專門文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。使用在 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) 與 [XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供合規性設定。詳情請參閱 [將 PowerPoint 轉換為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)。

**轉換過程中如何處理字型？**

Aspose.Slides 可以使用嵌入字型、備援字型與字型替代設定。請參閱 [嵌入字型](/slides/zh-hant/nodejs-java/embedded-font/)、[備援字型](/slides/zh-hant/nodejs-java/fallback-font/) 與 [字型替代](/slides/zh-hant/nodejs-java/font-substitution/)。