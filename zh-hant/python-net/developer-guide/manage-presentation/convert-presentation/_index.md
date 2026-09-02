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
description: "使用 Aspose.Slides for Python via .NET 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概述**

Aspose.Slides for Python via .NET 能夠載入 PowerPoint 與 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將它們儲存或轉換為許多其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發佈為 HTML，或將投影片渲染為影像檔案，以供預覽、縮圖與封存使用。

大多數文件轉換使用相同的基本工作流程：載入來源檔案、選擇所需的輸出格式，必要時套用特定格式的選項。對於影像格式，每張投影片會分別渲染，然後儲存為點陣或向量影像。以下連結的專門文章說明了每種情況的實作細節。

## **選擇轉換情境**

使用下列文章取得完整的 Python 範例與格式特定選項。

| 情境 | 使用情況 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉換為 PPTX | 現代化舊版 PPT 檔案、正規化既有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/python-net/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/python-net/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/python-net/save-presentation/) |
| PPTX 轉換為 PPT | 將新版 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以相容舊有工作流程。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉換為 PDF | 建立可攜、可搜尋的固定版面文件，以供分享、列印或封存。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉換為含備註的 PDF | 匯出投影片內容與講者備註。 | [將 PowerPoint 轉換為含備註的 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉換為 HTML | 將簡報發佈為 HTML 頁面，並控制影像、字型、備註與響應式版面選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉換為 HTML5 | 匯出投影片為 HTML5，以在瀏覽器中保留格式與互動性。 | [將簡報匯出為 HTML5](/slides/zh-hant/python-net/export-to-html5/) |
| PPT/PPTX/ODP 轉換為 PNG | 將每張投影片渲染為 PNG 影像，以供預覽、縮圖或網路輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉換為 JPG | 將投影片渲染為 JPG 影像，並控制影像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/python-net/convert-powerpoint-to-jpg/) |
| 投影片轉換為 SVG | 匯出單一投影片為可伸縮向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉換為 XPS | 產生固定版面 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉換為 TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或封存工作流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉換為含備註的 TIFF | 將投影片與講者備註一起儲存為 TIFF。 | [將 PowerPoint 轉換為含備註的 TIFF](/slides/zh-hant/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP 轉換為 Word | 當需要文件式輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP 轉換為 Markdown | 將簡報內容擷取為 Markdown，以供文件與文字為主的工作流程使用。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP 轉換為 XML | 建立文字為主的 PowerPoint XML 簡報，以便檢視、比較、除錯或基於 XML 的工作流程。 | [將 PowerPoint 轉換為 XML](/slides/zh-hant/python-net/convert-powerpoint-to-xml/) |
| PPT/PPTX/ODP 轉換為動畫 GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP 轉換為影片 | 從簡報投影片建立影片匯出工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/python-net/convert-powerpoint-to-video/) |
| 簡報轉換為 XAML | 將投影片匯出為 XAML，以用於 Python 或 .NET UI 情境。 | [將簡報匯出為 XAML](/slides/zh-hant/python-net/export-to-xaml/) |

如需更完整的輸入與輸出格式清單，請參閱 [支援的檔案格式](/slides/zh-hant/python-net/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Python via .NET 支援從常用的簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX、ODP）轉換。PowerPoint 與 OpenDocument 檔案使用相同的轉換 API，因此將 PPTX 檔案儲存為 PDF 的工作流程，通常只要更換輸入檔案，即可套用於 ODP 檔案。

轉換 ODP 檔案時，請注意 PowerPoint 與 OpenDocument 應用程式並不完全以相同方式支援所有版面與格式功能。若 ODP 檔案是於 LibreOffice 或 OpenOffice Impress 產生，請檢查輸出結果，必要時參考 [轉換 OpenDocument 簡報](/slides/zh-hant/python-net/convert-openoffice-odp/) 內的格式特定指引。

## **PPT 轉換為 PPTX**

PPT 是較舊的二進位 PowerPoint 格式，PPTX 則是現代的 Office Open XML 格式。Aspose.Slides for Python via .NET 提供高忠實度的 PPT 轉換為 PPTX，並保留諸如母版、版面配置、投影片、圖表、群組圖形、佔位元、文字框、紋理與圖片填充等複雜結構。

相關細節請參閱 [將 PPT 轉換為 PPTX](/slides/zh-hant/python-net/convert-ppt-to-pptx/) 與 [PPT 與 PPTX 的差異](/slides/zh-hant/python-net/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在需要跨裝置保持一致且不允許編輯為簡報的情況下非常有用。專門的 PDF、XPS、TIFF 文章說明如何控制相容性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出尺寸。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網站發佈與輕量分享。影像匯出則在每張投影片必須成為獨立的預覽、縮圖或點陣資產時非常實用。請參考 PNG、JPG、SVG 文章取得格式特定的渲染指引。

## **常見問題**

**是否需要 Microsoft PowerPoint 才能轉換簡報？**

不需要。Aspose.Slides for Python via .NET 為獨立函式庫，無需 Microsoft PowerPoint 或 Office 自動化。

**可以批次轉換大量簡報嗎？**

可以。載入每個簡報、儲存為所需格式，處理完畢後釋放簡報物件。若要平行處理，請使用獨立的簡報實例，並遵循 [多執行緒](/slides/zh-hant/python-net/multithreading/) 指南。

**能只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳入投影片索引或單獨渲染投影片，具體作法請參考目標格式的專屬文章。

**匯出為 PDF 或 XPS 時可以包含隱藏投影片嗎？**

可以。使用在 [PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) 與 [XPS](/slides/zh-hant/python-net/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**可以產生 PDF/A 輸出嗎？**

可以。PDF 匯出提供相容性設定，請參閱 [將 PowerPoint 轉換為 PDF](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/) 取得詳細資訊。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型後備與字型替換設定。請參考 [內嵌字型](/slides/zh-hant/python-net/embedded-font/)、[後備字型](/slides/zh-hant/python-net/fallback-font/) 與 [字型替換](/slides/zh-hant/python-net/font-substitution/)。