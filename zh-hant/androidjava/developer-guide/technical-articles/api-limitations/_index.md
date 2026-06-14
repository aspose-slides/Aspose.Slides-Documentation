---
title: API 限制
type: docs
weight: 320
url: /zh-hant/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android 的限制：匯出時在 PPT、PPTX、ODP 與 PDF 中設定固定的 Application/Producer 中繼資料——協助您規劃整合並避免意外。"
---
## **概述**

在使用 Aspose.Slides 建立或匯出簡報時，會將某些技術性中繼資料寫入輸出檔案。本文說明 PPTX 與 PDF 檔案中 `Application`、`Creator` 與 `Producer` 中繼資料欄位的限制。

## **Application 和 Producer**

當您使用 Aspose.Slides for Android via Java 建立或匯出簡報時，會將一些技術性中繼資料寫入檔案。以下兩個欄位常會引發疑問：

**Application** 會識別建立或最後一次儲存 **PPTX** 簡報的程式。在 Aspose.Slides for Android via Java 中，此值是固定的，會顯示函式庫供應商，而非您的應用程式名稱，即使您使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)。

**Producer** 會識別於匯出過程中產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for Android via Java 時，這兩個欄位皆為固定值，會反映函式庫及其版本。

**限制內容**

您無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入「Aspose.Slides for Android via Java」。對於 **PDF**，Creator 與 Producer 屬性會寫入「Aspose.Slides for Android via Java x.x.x」。此行為為設計決定，無論您如何載入或儲存檔案，亦無論是否使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) 指定值，都會如此。