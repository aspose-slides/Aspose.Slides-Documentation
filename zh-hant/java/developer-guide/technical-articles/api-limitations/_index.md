---
title: 輸出中繼資料限制
type: docs
weight: 320
url: /zh-hant/java/api-limitations/
keywords:
- API 限制
- 匯出格式
- 應用程式
- 產生器
- 文件屬性
- 中繼資料
- 產生器
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 會將固定的應用程式、建立者和產生器中繼資料寫入已儲存的 PPTX、PDF 及 ODP 檔案，不論您設定的應用程式名稱為何。"
---
## **概觀**

當使用 Aspose.Slides 建立或匯出簡報時，會將某些技術中繼資料寫入輸出檔案。本文章說明與 PPTX、PDF 及 ODP 檔案中 `Application`、`Creator`、`Producer` 以及 generator 中繼資料欄位相關的限制。

## **Application 與 Producer**

當您使用 Aspose.Slides for Java 建立或匯出簡報時，會將一些技術中繼資料寫入檔案。通常會對兩個欄位產生疑問：

**Application** 識別建立或最後儲存 **PPTX** 簡報的程式。在 Aspose.Slides for Java 中，這個值是固定的，顯示的是函式庫名稱而非您的應用程式名稱，即使您使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)。

**Producer** 識別在匯出期間產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for Java 時，這兩個欄位皆為固定值，且會顯示函式庫及其版本。

**受限制的項目**

您無法透過 API 針對上述格式覆寫這些欄位。對於 **PPTX**，Application 屬性會寫入「Aspose.Slides for Java」。對於 **PDF**，Creator 與 Producer 屬性會寫入「Aspose.Slides for Java」並附加函式庫版本。對於 **ODP**，generator 欄位會寫入「Aspose.Slides for Java」並附加函式庫版本。此行為是設計如此，且無論您如何載入或儲存檔案，亦無論使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) 指定的值為何，都會如此。

此限制不適用於 **PPT** 檔案：在 PPT 檔案中，您使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) 設定的應用程式名稱會被保存。