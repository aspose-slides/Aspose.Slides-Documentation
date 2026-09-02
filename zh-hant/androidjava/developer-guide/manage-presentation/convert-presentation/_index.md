---
title: "在 Android 上將簡報轉換為多種格式"
linktitle: "轉換簡報"
type: docs
weight: 70
url: /zh-hant/androidjava/convert-presentation/
keywords:
- "轉換簡報"
- "匯出簡報"
- "PPT 轉 PPTX"
- "PPTX 轉 PPT"
- "ODP 轉 PPTX"
- "PPT 轉 PDF"
- "PPTX 轉 PDF"
- "ODP 轉 PDF"
- "PPT 轉 HTML"
- "PPTX 轉 HTML"
- "ODP 轉 HTML"
- "PPT 轉 PNG"
- "PPTX 轉 PNG"
- "ODP 轉 PNG"
- "PPTX 轉 JPG"
- "ODP 轉 JPG"
- "PPT 轉 XPS"
- "PPTX 轉 XPS"
- "ODP 轉 XPS"
- "PPT 轉 TIFF"
- "PPTX 轉 TIFF"
- "ODP 轉 TIFF"
- "PowerPoint"
- "OpenDocument"
- "Android"
- "Java"
- "Aspose.Slides"
description: "使用 Aspose.Slides for Android via Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、圖像、XPS、TIFF 等多種格式。"
---
## **概述**

Aspose.Slides for Android via Java 可以載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下儲存或轉譯為其他多種格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發佈為 HTML，或將投影片渲染為圖像檔案以供預覽、縮圖與存檔。

大多數文件轉換使用相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，並在需要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣或向量圖像。下方的專屬文章提供各情況的實作細節。

## **選擇轉換情境**

請使用下方的文章取得完整的 Java 範例與特定格式的選項。

| 情境 | 使用情況 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 將舊版 PPT 檔案現代化，統一現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/androidjava/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/androidjava/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/androidjava/save-presentation/) |
| PPTX to PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以相容較舊的工作流程。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 建立可攜帶、可搜尋的固定版面文件，以便分享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 匯出投影片內容及講者備註。 | [將 PowerPoint 轉換為 PDF（含備註）](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 將簡報發佈為 HTML 網頁，並控制圖像、字型、備註與回應式版面配置選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中保留格式與互動性進行檢視。 | [將簡報匯出為 HTML5](/slides/zh-hant/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 將每張投影片渲染為 PNG 圖像，以作預覽、縮圖或 Web 輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | 將單獨投影片匯出為可伸縮向量圖形（SVG）。 | [將投影片渲染為 SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或存檔工作流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 將投影片及講者備註儲存為 TIFF。 | [將 PowerPoint 轉換為 TIFF（含備註）](/slides/zh-hant/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 當需要文件樣式的輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | 將簡報內容提取為 Markdown，以供文件編寫與文字為主的工作流程使用。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | 建立文字型的 PowerPoint XML 簡報，以供檢查、比較、故障排除或 XML 為基礎的工作流程使用。 | [將 PowerPoint 轉換為 XML](/slides/zh-hant/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 從簡報投影片建構影片匯出工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | 將投影片匯出為 XAML，以供 Android 或 Java UI 情境使用。 | [將簡報匯出為 XAML](/slides/zh-hant/androidjava/export-to-xaml/) |

欲檢視更完整的輸入與輸出格式清單，請參閱[支援的檔案格式](/slides/zh-hant/androidjava/supported-file-formats/).

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Android via Java 支援從常用的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案皆使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需將輸入檔案改為 ODP 即可套用。

轉換 ODP 檔案時，請注意 PowerPoint 與 OpenDocument 應用程式對於版面與格式的支援並不完全相同。如果 ODP 檔案是由 LibreOffice 或 OpenOffice Impress 建立，請檢閱輸出結果，並於需要特定格式指引時使用[將 OpenDocument 簡報轉換](/slides/zh-hant/androidjava/convert-openoffice-odp/)中描述的選項。

## **PPT 轉換為 PPTX**

PPT 為較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for Android via Java 支援高保真度的 PPT 轉換為 PPTX，並保留如母片、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理與圖片填充等複雜簡報結構。

欲了解更多細節，請參閱[將 PPT 轉換為 PPTX](/slides/zh-hant/androidjava/convert-ppt-to-pptx/)與[ PPT 與 PPTX 比較](/slides/zh-hant/androidjava/ppt-vs-pptx/)。

## **固定版面匯出**

當輸出需在各裝置上保持外觀一致且不應以簡報方式編輯時，PDF、XPS 與 TIFF 非常有用。專屬的 PDF、XPS 與 TIFF 文章說明如何控制符合性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出大小。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網路發佈與輕量分享。影像匯出則適合將每張投影片轉為單獨的預覽、縮圖或點陣資產。請參考 PNG、JPG 與 SVG 文章取得特定格式的渲染指引。

## **常見問題**

**是否需要 Microsoft PowerPoint 來轉換簡報？**

不需要。Aspose.Slides for Android via Java 為獨立函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換大量簡報嗎？**

可以。載入每份簡報後儲存為所需格式，處理完畢後釋放簡報物件。若需平行處理，請使用不同的簡報實例，並遵循[多執行緒](/slides/zh-hant/androidjava/multithreading/)指引。

**我能只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳入投影片索引或渲染個別投影片，具體取決於輸出格式。請參閱該目標格式的專屬文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏投影片嗎？**

可以。請使用在[PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)與[XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供符合 PDF/A 的設定。詳情請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)。

**轉換過程中如何處理字型？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替換設定。請參閱[內嵌字型](/slides/zh-hant/androidjava/embedded-font/)、[備援字型](/slides/zh-hant/androidjava/fallback-font/)與[字型替換](/slides/zh-hant/androidjava/font-substitution/)。