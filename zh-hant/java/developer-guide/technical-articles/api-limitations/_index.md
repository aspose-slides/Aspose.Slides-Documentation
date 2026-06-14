---
title: API 限制
type: docs
weight: 320
url: /zh-hant/java/api-limitations/
keywords:
- API 限制
- 匯出格式
- 應用程式
- 產生程式
- 文件屬性
- 中繼資料
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的限制：匯出時會在 PPT、PPTX、ODP 與 PDF 中設定固定的 Application/Producer 中繼資料，協助您在整合時做好規劃，避免意外。"
---
## **概覽**

使用 Aspose.Slides 建立或匯出簡報時，某些技術中繼資料會寫入輸出檔案。本文章說明 PPTX 與 PDF 檔案中與 `Application`、`Creator` 與 `Producer` 中繼資料欄位相關的限制。

## **Application and Producer**

使用 Aspose.Slides for Java 建立或匯出簡報時，會將一些技術中繼資料寫入檔案。通常會對兩個欄位產生疑問：

**Application** 識別建立或最後儲存 **PPTX** 簡報的程式。在 Aspose.Slides for Java 中，此值是固定的，顯示的是函式庫供應商而非您的應用程式名稱，即使您使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)。

**Producer** 識別在匯出過程中產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for Java 時，這兩個欄位皆為固定值，顯示函式庫及其版本。

**限制內容**

無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入為「Aspose.Slides for Java」。對於 **PDF**，Creator 與 Producer 屬性會寫入為「Aspose.Slides for Java x.x.x」。此行為是設計如此，且不受您如何載入或儲存檔案，也不受使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) 所設定之值的影響。