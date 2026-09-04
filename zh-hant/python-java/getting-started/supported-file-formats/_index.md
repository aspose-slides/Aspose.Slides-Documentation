---
title: 支援的檔案格式
type: docs
weight: 30
url: /zh-hant/python-java/supported-file-formats/
keywords:
- 支援的檔案格式
- 簡報格式
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- 投影片影像
- Python
- Aspose.Slides for Python via Java
description: "探索 Aspose.Slides for Python via Java 能載入、匯入、儲存與匯出的簡報、文件、網頁與影像格式。"
---
## **概觀**

Aspose.Slides for Python via Java 讀寫 PowerPoint 與 OpenDocument 簡報。它也能將 PDF 與 HTML 內容匯入至投影片，並將簡報或單一投影片匯出為文件、網頁與影像格式。

下表區分簡報載入、內容匯入與投影片呈現。欲了解編輯與呈現功能的概觀，請參考 [Features Overview](/slides/zh-hant/python-java/features-overview/)。

## **支援的 Microsoft PowerPoint 版本**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

## **支援的檔案格式**

以下表格列出支援的輸入與輸出格式。**Load / Import** 包含開啟簡報檔案與匯入 PDF 或 HTML 內容。**Save / Export** 包含儲存簡報與將投影片渲染為影像。破折號表示該操作不支援作為簡報轉換作業。

|**格式**|**描述**|**載入 / 匯入**|**儲存 / 匯出**|**備註**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 巨集啟用簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 巨集啟用投影片放映|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 巨集啟用範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}|封裝的 OpenDocument 格式。|
|FODP|Flat XML OpenDocument 簡報|{{< emoticons/tick >}}|{{< emoticons/tick >}}|將簡報儲存為單一 XML 文件。|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 簡報範本|{{< emoticons/tick >}}|{{< emoticons/tick >}}| |
|[TIFF](https://docs.fileformat.com/image/tiff/)|標記圖像檔案格式|—|{{< emoticons/tick >}}|支援多頁輸出。|
|[EMF](https://docs.fileformat.com/image/emf/)|增強型中繼圖形|—|{{< emoticons/tick >}}|將單張投影片匯出為向量圖像。|
|[PDF](https://docs.fileformat.com/pdf/)|可攜式文件格式|匯入|{{< emoticons/tick >}}|將 PDF 頁面匯入為投影片；將簡報匯出為 PDF。|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML 紙張規範|—|{{< emoticons/tick >}}|固定版面文件輸出。|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 圖像|—|{{< emoticons/tick >}}|將單張投影片渲染為點陣圖像。|
|[PNG](https://docs.fileformat.com/image/png/)|可攜式網路圖形|—|{{< emoticons/tick >}}|將單張投影片渲染為點陣圖像。|
|[GIF](https://docs.fileformat.com/image/gif/)|圖形交換格式|—|{{< emoticons/tick >}}|影像輸出。|
|[BMP](https://docs.fileformat.com/image/bmp/)|點陣圖影像|—|{{< emoticons/tick >}}|將單張投影片渲染為點陣圖像。|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|可縮放向量圖形|—|{{< emoticons/tick >}}|將單張投影片匯出為向量圖像。|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|小型網頁格式|—|{{< emoticons/tick >}}|Flash 輸出。|
|[HTML](https://docs.fileformat.com/web/html/)|超文字標記語言|匯入|{{< emoticons/tick >}}|將 HTML 內容匯入為投影片；支援 HTML 與 HTML5 匯出。|
|[XAML](https://docs.fileformat.com/web/xaml/)|可擴充應用程式標記語言|—|{{< emoticons/tick >}}|將簡報內容匯出為 XAML。|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|{{< emoticons/tick >}}|將簡報內容匯出為 Markdown。|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 簡報|—|{{< emoticons/tick >}}|PowerPoint 專屬的 XML 輸出，非任意 XML。|

## **匯入與匯出說明**

- **PDF 與 HTML 匯入：** 使用 [SlideCollection.addFromPdf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addfrompdf) 或 [SlideCollection.addFromHtml](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidecollection/#addfromhtml) 從來源內容建立投影片，並將其附加至簡報。
- **簡報輸出：** [SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 列出可用的簡報儲存格式，包含獨立的 HTML 與 HTML5 匯出選項。
- **影像輸出：** 將投影片匯出為影像會產生該投影片的視覺表示。輸入欄位未說明影像是否可以插入至簡報。

## **常見問題**

**我可以將 PPT 簡報轉換為 PPTX 或 ODP 嗎？**

可以。PPT 被支援為輸入格式，PPTX 與 ODP 則可作為輸出格式。轉換結果取決於目標格式可支援的功能。

**PDF 或 HTML 匯入會將來源視為 PowerPoint 檔案嗎？**

不會。匯入會從 PDF 頁面或 HTML 內容建立投影片。之後您可以將產生的簡報儲存為支援的簡報格式。

**我可以將匯出的 PNG 或 SVG 載入為可編輯的簡報嗎？**

不能。這些匯出僅表示投影片的外觀。若日後需要編輯文字、圖形、圖表等物件，請保留原始簡報。