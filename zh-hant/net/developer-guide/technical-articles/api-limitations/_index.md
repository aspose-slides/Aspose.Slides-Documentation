---
title: 輸出中繼資料限制
type: docs
weight: 320
url: /zh-hant/net/api-limitations/
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
- 投影片
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 將固定的應用程式、建立者與產生器中繼資料寫入已儲存的 PPTX、PDF 與 ODP 檔案，無論您設定的應用程式名稱為何。"
---
## **概覽**

使用 Aspose.Slides 建立或匯出投影片時，某些技術性中繼資料會寫入輸出檔案。本篇文章說明 PPTX、PDF 與 ODP 檔案中 `Application`、`Creator`、`Producer` 與 generator 中繼資料欄位的限制。

## **應用程式與產生器**

使用 Aspose.Slides for .NET 建立或匯出投影片時，會將一些技術性中繼資料寫入檔案。以下兩個欄位常會引起疑問：

**Application** 識別建立或最後儲存 **PPTX** 投影片的程式。於 Aspose.Slides for .NET 中，此值為固定，顯示的是函式庫名稱而非您的應用程式名稱，即使您設定了 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/nameofapplication/)。

**Producer** 識別在匯出過程中產生最終檔案的渲染引擎。於 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for .NET 時，這兩個欄位皆為固定，顯示函式庫及其版本。

**受限項目**

無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入「Aspose.Slides for .NET」。對於 **PDF**，Creator 與 Producer 屬性會寫入「Aspose.Slides for .NET」以及函式庫版本。對於 **ODP**，generator 欄位會寫入「Aspose.Slides for .NET」以及函式庫版本。此行為為設計上預期，且不論您如何載入或儲存檔案，也不論您在 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/nameofapplication/) 中設定的值如何，皆會如此。

此限制不適用於 **PPT** 檔案：在 PPT 檔案中，您於 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/documentproperties/nameofapplication/) 設定的應用程式名稱會被保存。