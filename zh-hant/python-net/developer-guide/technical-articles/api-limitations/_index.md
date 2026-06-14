---
title: API 限制
type: docs
weight: 210
url: /zh-hant/python-net/api-limitations/
keywords:
- API 限制
- 匯出格式
- 應用程式
- 製作者
- 文件屬性
- 中繼資料
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python 的限制：匯出時會在 PPT、PPTX、ODP 與 PDF 中設定固定的 Application / Producer 中繼資料，協助您規劃整合時不會出現意外。"
---
## **概述**

使用 Aspose.Slides 建立或匯出簡報時，會將某些技術性中繼資料寫入輸出檔案。本篇文章說明 PPTX 與 PDF 檔案中 `Application`、`Creator` 與 `Producer` 中繼資料欄位的限制。

## **應用程式與製作者**

使用 Aspose.Slides for Python via .NET 建立或匯出簡報時，會將一些技術性中繼資料寫入檔案。常會產生疑問的有兩個欄位：

**Application** 識別建立或最後一次儲存 **PPTX** 簡報的程式。在 Aspose.Slides for Python via .NET 中，此值是固定的，會顯示函式庫的供應商而非您的應用程式名稱，即使您已設定 [DocumentProperties.name_of_application](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/name_of_application/)。

**Producer** 識別在匯出過程中產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for Python via .NET 時，這兩個欄位皆為固定值，顯示函式庫及其版本。

**受限項目**

無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入「Aspose.Slides for Python via .NET」。對於 **PDF**，Creator 與 Producer 屬性會寫入「Aspose.Slides for Python via .NET x.x.x」。此行為屬於設計決定，無論您如何載入或儲存檔案，亦無論 [DocumentProperties.name_of_application](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/documentproperties/name_of_application/) 被設定為何值，皆會如此。