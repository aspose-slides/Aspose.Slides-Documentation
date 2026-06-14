---
title: 在 JavaScript 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概觀**

Aspose.Slides for Node.js via Java 能夠載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其儲存或轉換為許多其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發布為 HTML，或將投影片渲染為圖像檔案以供預覽、縮圖與存檔。

大多數文件轉換皆遵循相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣或向量圖像。下方連結的專屬文章提供了每種情況的實作細節。

## **選擇轉換情境**

使用下列文章取得完整的 JavaScript 範例與特定格式的選項。

| 情境 | 當您需要時使用 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉換為 PPTX | 將舊版 PPT 檔案現代化、標準化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/nodejs-java/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/nodejs-java/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/nodejs-java/save-presentation/) |
| PPTX 轉換為 PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以相容舊有工作流程。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉換為 PDF | 建立可攜帶、可搜尋、固定版面文件，以供分享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉換為 PDF（含備註） | 匯出投影片內容及講者備註。 | [將 PowerPoint 轉換為含備註的 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉換為 HTML | 將簡報發布為 HTML 頁面，並控制圖像、字型、備註以及回應式版面選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉換為 HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中保留格式與互動性進行檢視。 | [將簡報轉換為 HTML5](/slides/zh-hant/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP 轉換為 PNG | 將每張投影片渲染為 PNG 圖像，以作預覽、縮圖或網頁輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉換為 JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-jpg/) |
| 投影片轉換為 SVG | 將單獨投影片匯出為可縮放向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉換為 XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉換為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或存檔流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉換為 TIFF（含備註） | 將投影片與講者備註一起儲存為 TIFF。 | [將 PowerPoint 轉換為含備註的 TIFF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉換為 Markdown | 將簡報內容提取為 Markdown，以供文件編寫與文字為主的工作流程使用。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX 轉換為動畫 GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉換為影片 | 建立從投影片匯出為影片的工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) |
| 簡報轉換為 XAML | 將投影片匯出為 XAML，以用於 JavaScript 或 Java UI 情境。 | [將簡報匯出為 XAML](/slides/zh-hant/nodejs-java/export-to-xaml/) |

如需更完整的輸入與輸出格式清單，請參閱[受支援的檔案格式](/slides/zh-hant/nodejs-java/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Node.js via Java 支援從常用的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 與 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案皆使用相同的轉換 API，因而只要將輸入檔案改為 ODP，即可將原本儲存 PPTX 為 PDF 的工作流程套用於 ODP。

在轉換 ODP 檔案時，請記住 PowerPoint 與 OpenDocument 應用程式並未以完全相同的方式支援所有版面與格式設定。若 ODP 檔案是使用 LibreOffice 或 OpenOffice Impress 建立，請檢視輸出結果，並在需要特定格式指引時使用 [將 OpenDocument 簡報轉換](/slides/zh-hant/nodejs-java/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 是舊式的二進位 PowerPoint 格式，而 PPTX 則是現代的 Office Open XML 格式。Aspose.Slides for Node.js via Java 支援高保真度的 PPT 轉換為 PPTX，並保留如母片、版面配置、投影片、圖表、組合圖形、占位符、文字框、紋理與圖片填充等複雜簡報結構。

詳情請參閱 [將 PPT 轉換為 PPTX](/slides/zh-hant/nodejs-java/convert-ppt-to-pptx/) 與 [PPT 與 PPTX 比較](/slides/zh-hant/nodejs-java/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在需要讓輸出在各裝置上保持相同且不作為簡報編輯的情況下相當有用。專屬的 PDF、XPS 與 TIFF 文章說明了如何控制合規性、隱藏投影片、備註、圖像品質、壓縮、像素格式與輸出大小。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網頁發布與輕量共享。影像匯出則適合在每張投影片需成為單獨的預覽圖、縮圖或點陣資產時使用。請參考 PNG、JPG 與 SVG 文章以獲得特定格式的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 才能轉換簡報嗎？**

不需要。Aspose.Slides for Node.js via Java 是獨立的函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多個簡報嗎？**

可以。載入每個簡報後，將其儲存為所需格式，處理完畢再釋放簡報物件。若需平行處理，請使用不同的簡報實例，並遵循 [多執行緒](/slides/zh-hant/nodejs-java/multithreading/) 的指引。

**我能只匯出選取的投影片嗎？**

可以。依照輸出格式，某些匯出方法允許您傳遞投影片索引或渲染單一投影片。請參閱該格式的專屬文章。

**匯出為 PDF 或 XPS 時，我能包含隱藏的投影片嗎？**

可以。請使用在 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) 與 [XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我能產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供合規性設定以產生 PDF/A。詳情請參閱 [將 PowerPoint 轉換為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替換設定。請參閱 [內嵌字型](/slides/zh-hant/nodejs-java/embedded-font/)、[字型備援](/slides/zh-hant/nodejs-java/fallback-font/) 與 [字型替換](/slides/zh-hant/nodejs-java/font-substitution/)。