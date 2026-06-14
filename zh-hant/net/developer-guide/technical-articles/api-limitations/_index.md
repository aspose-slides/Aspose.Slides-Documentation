---
title: API 限制
type: docs
weight: 320
url: /zh-hant/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "瞭解 Aspose.Slides for .NET 的限制：匯出時在 PPT、PPTX、ODP 與 PDF 中設定固定的 Application/Producer 中繼資料—協助您規劃整合，避免意外。"
---
## **概觀**

當使用 Aspose.Slides 建立或匯出簡報時，某些技術性中繼資料會寫入輸出檔案。本文說明 PPTX 與 PDF 檔案中 `Application`、`Creator` 與 `Producer` 中繼資料欄位的限制。

## **Application 與 Producer**

使用 Aspose.Slides for .NET 建立或匯出簡報時，會將一些技術性中繼資料寫入檔案。常常會對以下兩個欄位產生疑問：

**Application** 識別建立或最後儲存 **PPTX** 簡報的程式。在 Aspose.Slides for .NET 中，該值為固定值，顯示的是函式庫供應商，而非您的應用程式名稱，即使您設定了 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/nameofapplication/) 亦如此。

**Producer** 識別在匯出期間產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for .NET 時，這兩個欄位皆為固定值，反映函式庫及其版本。

**What’s restricted**

您無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性寫入為 "Aspose.Slides for .NET"。對於 **PDF**，Creator 與 Producer 屬性寫入為 "Aspose.Slides for .NET x.x.x"。此行為為設計所致，無論您如何載入或儲存檔案，也無論 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/nameofapplication/) 設定為何，皆會套用。