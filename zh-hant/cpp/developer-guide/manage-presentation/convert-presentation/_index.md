---
title: 在 C++ 中將簡報轉換為多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/cpp/convert-presentation/
keywords:
- 轉換簡報
- 匯出簡報
- PPT 轉為 PPTX
- PPTX 轉為 PPT
- ODP 轉為 PPTX
- PPT 轉為 PDF
- PPTX 轉為 PDF
- ODP 轉為 PDF
- PPT 轉為 HTML
- PPTX 轉為 HTML
- ODP 轉為 HTML
- PPT 轉為 PNG
- PPTX 轉為 PNG
- ODP 轉為 PNG
- PPTX 轉為 JPG
- ODP 轉為 JPG
- PPT 轉為 XPS
- PPTX 轉為 XPS
- ODP 轉為 XPS
- PPT 轉為 TIFF
- PPTX 轉為 TIFF
- ODP 轉為 TIFF
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概述**

Aspose.Slides for C++ 能夠載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將其儲存或轉換為許多其他格式。您可以將舊版 PPT 檔案轉換為現代的 PPTX，將簡報匯出為固定版面的文件，例如 PDF 和 XPS，將投影片發佈為 HTML，或將投影片渲染為圖像檔案以用於預覽、縮圖和存檔。

大多數文件轉換使用相同的一般工作流程：載入來源檔案，選擇所需的輸出格式，並在需要時套用特定格式的選項。對於圖像格式，會分別渲染每張投影片，然後儲存為光柵或向量圖像。下面連結的專屬文章提供了每種情況的實作細節。

## **選擇轉換情境**

請使用以下文章取得完整的 C++ 範例與特定格式的選項。

| 情境 | 使用情況 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉換為 PPTX | 使舊版 PPT 檔案現代化，正規化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/cpp/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/cpp/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/cpp/save-presentation/) |
| PPTX 轉換為 PPT | 將現代的 PowerPoint 簡報儲存為舊的二進位 PPT 格式，以符合舊工作流程的相容性。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉換為 PDF | 建立可攜帶、可搜尋、固定版面的文件，以供分享、列印或存檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉換為含備註的 PDF | 將講者備註與投影片內容一起匯出。 | [將 PowerPoint 轉換為含備註的 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉換為 HTML | 將簡報發佈為 HTML 頁面，並控制圖像、字型、備註與回應式版面配置選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉換為 HTML5 | 將投影片匯出為 HTML5，以在瀏覽器中以保留格式與互動性的方式檢視。 | [將簡報轉換為 HTML5](/slides/zh-hant/cpp/export-to-html5/) |
| PPT/PPTX/ODP 轉換為 PNG | 將每張投影片渲染為 PNG 圖像，以作預覽、縮圖或網路輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉換為 JPG | 將投影片渲染為 JPG 圖像，並控制圖像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/cpp/convert-powerpoint-to-jpg/) |
| 投影片 轉換為 SVG | 將單一投影片匯出為可伸縮向量圖形 (SVG)。 | [將投影片渲染為 SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉換為 XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉換為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以用於列印、掃描、傳真或歸檔工作流程。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉換為含備註的 TIFF | 將含講者備註的投影片儲存為 TIFF。 | [將 PowerPoint 轉換為含備註的 TIFF](/slides/zh-hant/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉換為 Word | 當需要文件格式的輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX 轉換為 Markdown | 將簡報內容提取為 Markdown，以用於文件編寫與文字為主的工作流程。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP 轉換為 XML | 建立基於文字的 PowerPoint XML 簡報，用於檢查、比較、故障排除或 XML 為主的工作流程。 | [將 PowerPoint 轉換為 XML](/slides/zh-hant/cpp/convert-powerpoint-to-xml/) |
| PPT/PPTX 轉換為動畫 GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉換為影片 | 從簡報投影片建構影片匯出的工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/) |
| 簡報 轉換為 XAML | 將投影片匯出為 XAML，以用於 C++ UI 場景。 | [將簡報匯出為 XAML](/slides/zh-hant/cpp/export-to-xaml/) |

若要查看更完整的輸入與輸出格式清單，請參閱 [支援的檔案格式](/slides/zh-hant/cpp/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for C++ 支援從常見的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX 和 ODP）進行轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只需將輸入檔案改為 ODP，即可套用於 ODP 檔案。

在轉換 ODP 檔案時，請注意 PowerPoint 與 OpenDocument 應用程式並未以完全相同的方式支援每項版面配置與格式設定。如果 ODP 檔案是使用 LibreOffice 或 OpenOffice Impress 建立的，請檢查輸出結果，並在需要特定格式指引時，使用 [轉換 OpenDocument 簡報](/slides/zh-hant/cpp/convert-openoffice-odp/) 中描述的選項。

## **PPT 轉換為 PPTX**

PPT 是較舊的二進位 PowerPoint 格式，而 PPTX 是現代的 Office Open XML 格式。Aspose.Slides for C++ 支援高保真度的 PPT 轉換為 PPTX，並保留如母片、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理和圖片填充等複雜的簡報結構。

欲了解更多資訊，請參閱 [將 PPT 轉換為 PPTX](/slides/zh-hant/cpp/convert-ppt-to-pptx/)。

## **固定版面匯出**

當輸出需要在各裝置上保持相同外觀且不應被編輯為簡報時，PDF、XPS 和 TIFF 相當有用。專屬的 PDF、XPS 與 TIFF 文章說明了如何控制符合性、隱藏投影片、備註、圖像品質、壓縮、像素格式與輸出尺寸。

## **HTML 與圖像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網頁發佈與輕量分享。圖像匯出則在每張投影片必須成為獨立的預覽、縮圖或光柵資產時相當有用。請參考 PNG、JPG 與 SVG 文章以取得特定格式的渲染指引。

## **常見問題**

**我需要 Microsoft PowerPoint 來轉換簡報嗎？**

不需要。Aspose.Slides for C++ 是獨立的函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換大量簡報嗎？**

可以。載入每個簡報，將其儲存為所需格式，處理完畢後釋放簡報物件。若需平行處理，請使用不同的簡報實例，並遵循 [多執行緒](/slides/zh-hant/cpp/multithreading/) 指南。

**我可以僅匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳遞投影片索引或渲染單一投影片，視輸出格式而定。請參閱該目標格式的專屬文章。

**匯出為 PDF 或 XPS 時，我可以包含隱藏的投影片嗎？**

可以。使用在 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/) 與 [XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供符合 PDF/A 的設定。詳情請參閱 [將 PowerPoint 轉換為 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)。

**在轉換過程中，字型如何處理？**

Aspose.Slides 可使用嵌入字型、字型後備與字型替代設定。請參閱 [嵌入字型](/slides/zh-hant/cpp/embedded-font/)、[字型後備](/slides/zh-hant/cpp/fallback-font/) 與 [字型替代](/slides/zh-hant/cpp/font-substitution/)。