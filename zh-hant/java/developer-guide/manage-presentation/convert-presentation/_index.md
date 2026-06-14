---
title: 將簡報轉換為 Java 中的多種格式
linktitle: 轉換簡報
type: docs
weight: 70
url: /zh-hant/java/convert-presentation/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 將 PowerPoint 與 OpenDocument 簡報轉換為 PPTX、PDF、HTML、影像、XPS、TIFF 等多種格式。"
---
## **概覽**

Aspose.Slides for Java 可以載入 PowerPoint 和 OpenDocument 簡報，並在不需要 Microsoft PowerPoint、OpenOffice 或 LibreOffice 的情況下，將它們儲存或轉換為許多其他格式。您可以將舊版 PPT 檔案轉換為現代 PPTX，將簡報匯出為 PDF、XPS 等固定版面文件，將投影片發佈為 HTML，或將投影片渲染為影像檔案以供預覽、縮圖與存檔使用。

大多數文件轉換使用相同的一般工作流程：載入來源檔案、選擇所需的輸出格式，必要時套用格式特定的選項。對於影像格式，每一張投影片皆會分別渲染，然後儲存為點陣圖或向量圖。下面的專門文章提供每種情況的實作細節。

## **選擇轉換情境**

使用下列文章取得完整的 Java 範例與格式特定的選項。

| 情境 | 使用於需要 | 文章 |
| --- | --- | --- |
| PPT/PPTX/ODP 轉 PPTX | 現代化舊版 PPT 檔案、正規化現有 PPTX 檔案，或將 OpenDocument 簡報轉換為 PowerPoint PPTX。 | [將 PPT 轉換為 PPTX](/slides/zh-hant/java/convert-ppt-to-pptx/), [將 ODP 轉換為 PPTX](/slides/zh-hant/java/convert-odp-to-pptx/), [儲存簡報](/slides/zh-hant/java/save-presentation/) |
| PPTX 轉 PPT | 將現代 PowerPoint 簡報儲存為較舊的二進位 PPT 格式，以符合舊有工作流程的相容性。 | [將 PPTX 轉換為 PPT](/slides/zh-hant/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP 轉 PDF | 建立可攜、可搜尋、固定版面的文件以供分享、列印或歸檔。 | [將 PowerPoint 轉換為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP 轉 PDF（含備註） | 匯出講者備註與投影片內容。 | [將 PowerPoint 轉換為含備註的 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP 轉 HTML | 以 HTML 頁面發佈簡報，並控制影像、字型、備註與回應式版面選項。 | [將 PowerPoint 轉換為 HTML](/slides/zh-hant/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP 轉 HTML5 | 匯出投影片為 HTML5，以保留格式與互動性的瀏覽器檢視。 | [將簡報匯出為 HTML5](/slides/zh-hant/java/export-to-html5/) |
| PPT/PPTX/ODP 轉 PNG | 將每張投影片渲染為 PNG 影像，以供預覽、縮圖或網站輸出。 | [將 PowerPoint 轉換為 PNG](/slides/zh-hant/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP 轉 JPG | 將投影片渲染為 JPG 影像，並控制影像尺寸與品質。 | [將 PowerPoint 轉換為 JPG](/slides/zh-hant/java/convert-powerpoint-to-jpg/) |
| 投影片轉 SVG | 匯出單一投影片為可縮放向量圖形。 | [將投影片渲染為 SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP 轉 XPS | 產生固定版面的 XPS 文件。 | [將 PowerPoint 轉換為 XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP 轉 TIFF | 將簡報儲存為多頁 TIFF 檔案，以供列印、掃描、傳真或歸檔工作流程使用。 | [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP 轉 TIFF（含備註） | 將投影片與講者備註一起儲存為 TIFF。 | [將 PowerPoint 轉換為含備註的 TIFF](/slides/zh-hant/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX 轉 Word | 當需要文件式輸出時，將投影片轉換為 Word 文件。 | [將 PowerPoint 轉換為 Word](/slides/zh-hant/java/convert-powerpoint-to-word/) |
| PPT/PPTX 轉 Markdown | 將簡報內容抽取為 Markdown，以便文件編寫與文字工作流程。 | [將 PowerPoint 轉換為 Markdown](/slides/zh-hant/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX 轉動態 GIF | 從投影片建立動畫 GIF。 | [將 PowerPoint 轉換為動畫 GIF](/slides/zh-hant/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX 轉影片 | 建立從簡報投影片匯出的影片工作流程。 | [將 PowerPoint 轉換為影片](/slides/zh-hant/java/convert-powerpoint-to-video/) |
| 簡報轉 XAML | 將投影片匯出為 XAML 以供 Java UI 場景使用。 | [將簡報匯出為 XAML](/slides/zh-hant/java/export-to-xaml/) |

欲查閱更完整的輸入與輸出格式清單，請參閱[支援的檔案格式](/slides/zh-hant/java/supported-file-formats/)。

## **PowerPoint 與 OpenDocument 轉換**

Aspose.Slides for Java 支援從常見簡報格式（如 PPT、PPTX、PPS、PPSX、POT、POTX、ODP）進行轉換。相同的轉換 API 用於 PowerPoint 與 OpenDocument 檔案，因此將 PPTX 儲存為 PDF 的工作流程，通常只需將輸入檔案改為 ODP 即可套用。

轉換 ODP 檔案時，請記得 PowerPoint 與 OpenDocument 應用程式並未以完全相同的方式支援每項版面與格式設定。若 ODP 檔案是使用 LibreOffice 或 OpenOffice Impress 建立，請檢視輸出結果，並在需要格式特定指引時使用[轉換 OpenDocument 簡報](/slides/zh-hant/java/convert-openoffice-odp/)中描述的選項。

## **PPT 轉 PPTX 轉換**

PPT 為較舊的二進位 PowerPoint 格式，而 PPTX 為現代的 Office Open XML 格式。Aspose.Slides for Java 能夠高忠實度地將 PPT 轉換為 PPTX，並保留包括母片、版面配置、投影片、圖表、群組圖形、佔位符、文字框、紋理與圖片填色等複雜結構。

詳細資訊請參閱[將 PPT 轉換為 PPTX](/slides/zh-hant/java/convert-ppt-to-pptx/)以及[PPT 與 PPTX 比較](/slides/zh-hant/java/ppt-vs-pptx/)。

## **固定版面匯出**

PDF、XPS 與 TIFF 在需要跨裝置保持相同外觀且不希望被編輯為簡報時相當有用。專門的 PDF、XPS 與 TIFF 文章說明如何控制合規性、隱藏投影片、備註、影像品質、壓縮、像素格式與輸出尺寸。

## **HTML 與影像匯出**

HTML 與 HTML5 匯出適用於瀏覽器檢視、網站發佈與輕量共享。影像匯出則在每張投影片必須成為獨立的預覽圖、縮圖或點陣資產時非常實用。請參考 PNG、JPG 與 SVG 文章取得格式特定的渲染指導。

## **常見問題集**

**是否需要 Microsoft PowerPoint 才能轉換簡報？**

不需要。Aspose.Slides for Java 為獨立函式庫，無須 Microsoft PowerPoint 或 Office 自動化。

**我可以批次轉換多份簡報嗎？**

可以。載入每份簡報後儲存為所需格式，處理完畢後釋放簡報物件。若要平行處理，請使用獨立的簡報實例，並遵循[多執行緒](/slides/zh-hant/java/multithreading/)指引。

**我可以只匯出選取的投影片嗎？**

可以。多種匯出方法允許您傳入投影片索引或單獨渲染投影片，具體作法依輸出格式而異，請參閱該格式的專門文章。

**匯出為 PDF 或 XPS 時可以包含隱藏投影片嗎？**

可以。使用在[PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)與[XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/) 轉換文章中描述的隱藏投影片匯出設定。

**我可以建立 PDF/A 輸出嗎？**

可以。PDF 匯出提供合規性設定，相關細節請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)。

**轉換過程中字型如何處理？**

Aspose.Slides 可使用內嵌字型、字型備援與字型替代設定。請參閱[內嵌字型](/slides/zh-hant/java/embedded-font/)、[備援字型](/slides/zh-hant/java/fallback-font/)與[字型替代](/slides/zh-hant/java/font-substitution/)。