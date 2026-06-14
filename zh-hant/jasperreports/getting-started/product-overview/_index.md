---
title: 產品概述
type: docs
weight: 10
url: /zh-hant/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **歡迎使用 Aspose.Slides for JasperReports！**

Aspose.Slides for JasperReports 是一個專門為需要在 Java 應用程式中輕鬆將 JasperReports 報表匯出為 Microsoft PowerPoint 簡報 (PPT) 與 Microsoft PowerPoint 幻燈片 (PPS) 格式的開發人員設計與開發的函式庫。所有報表功能皆以最高精度轉換為 Microsoft PowerPoint 簡報。Aspose.Slides for JasperReports 支援 JasperReports 5 以上版本。

## **產品說明**
JasperReports 與 JasperServer 並未內建將報表匯出為 Microsoft PowerPoint 簡報的功能，但 Aspose.Slides for JasperReports 為您提供了兩種額外的匯出格式：

- PPT – 透過 Aspose.Slides 的 PowerPoint 簡報
- PPS – 透過 Aspose.Slides 的 PowerPoint 幻燈片
- PPTX – 透過 Aspose.Slides 的 PowerPoint 簡報
- PPSX – 透過 Aspose.Slides 的 PowerPoint 幻燈片

Aspose.Slides for JasperReports 內部使用我們 100% 純 Java 函式庫 Aspose.Slides for Java 與 Aspose.Metafiles for Java，這些是伺服器端簡報與中繼檔處理的世界級函式庫。

Aspose.Slides for JasperReports 使任何報表都能匯出為 PPT 或 PPS 格式。

### **輸出範例**
ASPptExporter 類別繼承自 ASAbstractExporter 類別，因而可像其他標準匯出器一樣使用。此簡短範例顯示了典型程式碼以及在 MS PowerPoint 中檢視的報表螢幕截圖。詳細範例可在提供的示範報表中找到。

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**使用 JasperReports xmldatasource demo 產生的簡報** 

![使用 JasperReports 產生的簡報](product-overview_2.png)