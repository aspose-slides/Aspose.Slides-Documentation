---
title: 產品概覽
type: docs
weight: 10
url: /zh-hant/jasperreports/product-overview/
description: "了解 Aspose.Slides for JasperReports 的功能、支援的 JasperReports 版本與輸出格式，以及它的兩個 jar 用途。"
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **產品說明**

Aspose.Slides for JasperReports 可將 JasperReports 的報表匯出為 PowerPoint 簡報，適用於 Java 應用程式與 JasperReports Server，且不需 Microsoft PowerPoint。它支援 JasperReports 3.7.2 到 6.16.0，各版本範圍皆有對應的 jar — 請參閱[安裝 Aspose.Slides for JasperReports](/slides/zh-hant/jasperreports/installing-aspose-slides-for-jasperreports/)。

它將已填寫的報表匯出為四種格式，每個報表頁面對應一張投影片或頁面：

- PPT – PowerPoint 97–2003 簡報
- PPTX – PowerPoint 簡報（Office Open XML）
- PDF
- HTML

此產品包含兩個部分：

- Library jar 為 JasperReports Library 新增匯出器 `ASPptExporter`、`ASPptxExporter`、`ASPdfExporter` 與 `ASHtmlExporter`。
- Server jar 提供相同四種格式的匯出動作，您需在 JasperReports Server 中註冊——請參閱[與 JasperServer 的整合](/slides/zh-hant/jasperreports/integration-with-jasperserver/)。

### **輸出範例**

這些匯出器繼承自 JasperReports 自身的匯出類別，使用方式相同：將已填寫的報表與輸出檔案傳入，然後呼叫 `exportReport`。欲取得填寫報表並匯出為 PPTX 的完整程式碼範例，請參閱[您的首次匯出](/slides/zh-hant/jasperreports/#your-first-export)；如需四種格式的範例，請參閱[PPT、PPTX、PDF 與 HTML 匯出](/slides/zh-hant/jasperreports/ppt-pptx-pdf-and-html-export/)。

![未授權的報表匯出為簡報，評估水印位於投影片中央](product-overview_2.png)