---
title: 支援的檔案格式
type: docs
weight: 20
url: /zh-hant/jasperreports/supported-file-formats/
description: "查看 Aspose.Slides for JasperReports 接受的輸入以及它匯出報表的檔案格式。"
---
## **輸入**

Aspose.Slides for JasperReports 會匯出報表；它不會轉換現有的簡報。它的匯出器會接收已填寫的 JasperReports 報表 (`JasperPrint`)，例如 `JasperFillManager` 的結果，或是從 *.jrprint* 檔案載入的已填寫報表。

## **輸出格式**

以下表格列出 Aspose.Slides for JasperReports 可匯出報表的格式，以及對應負責寫入的匯出類別。

|**格式**|**說明**|**匯出器**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 簡報；每個報表頁面對應一張投影片|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 簡報（Office Open XML）；每個報表頁面對應一張投影片|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|可攜式文件格式（PDF）；每個報表頁面對應一頁 PDF|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|單一 HTML 檔案，且每個報表頁面包含一張 SVG 圖像|`ASHtmlExporter`|

目前沒有支援 PPS 與 PPSX 投影片秀格式的匯出器。即使將 PPTX 匯出檔案名稱設為 *.ppsx*，仍會產生 PPTX 簡報，而非投影片秀。若要了解每個匯出器的使用方式，請參閱 [PPT, PPTX, PDF and HTML Export](/slides/zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/).