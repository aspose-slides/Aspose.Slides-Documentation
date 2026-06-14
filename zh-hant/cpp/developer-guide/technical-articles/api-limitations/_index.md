---
title: API 限制
type: docs
weight: 320
url: /zh-hant/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 的限制：匯出時在 PPT、PPTX、ODP 和 PDF 中設定固定的 Application/Producer 中繼資料，協助您規劃整合時避免意外。"
---
## **概觀**

當使用 Aspose.Slides 建立或匯出簡報時，某些技術中繼資料會寫入輸出檔案。本篇文章說明 PPTX 與 PDF 檔案中與 `Application`、`Creator`、`Producer` 中繼資料欄位相關的限制。

## **Application 與 Producer**

當您使用 Aspose.Slides for C++ 建立或匯出簡報時，某些技術中繼資料會寫入檔案。以下兩個欄位常會引發疑問：

**Application** 識別建立或最後儲存 **PPTX** 簡報的程式。於 Aspose.Slides for C++ 中，該值是固定的，會顯示函式庫供應商而非您的應用程式名稱，即使您使用[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/documentproperties/set_nameofapplication/)。

**Producer** 識別在匯出期間產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for C++ 時，這兩個欄位皆為固定值，反映函式庫及其版本。

**受限制的項目**

您無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入為 "Aspose.Slides for C++"。對於 **PDF**，Creator 與 Producer 屬性會寫入為 "Aspose.Slides for C++ x.x.x"。此行為屬於設計決策，無論您如何載入或儲存檔案，亦不受使用[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/documentproperties/set_nameofapplication/)所指定的值影響。