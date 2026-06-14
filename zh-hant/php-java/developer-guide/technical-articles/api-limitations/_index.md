---
title: API 限制
type: docs
weight: 320
url: /zh-hant/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP 的限制：匯出時在 PPT、PPTX、ODP 及 PDF 中設定固定的 Application/Producer 中繼資料，協助您在整合時做好規劃，避免意外。"
---
## **概觀**

當使用 Aspose.Slides 建立或匯出簡報時，某些技術性中繼資料會寫入輸出檔案。本篇文章說明 PPTX 與 PDF 檔案中 `Application`、`Creator` 與 `Producer` 中繼資料欄位的限制。

## **應用程式與產生程式**

當您使用 Aspose.Slides for PHP via Java 建立或匯出簡報時，檔案中會寫入一些技術性中繼資料。以下兩個欄位常常引發疑問：

**Application** 識別建立或最後一次儲存 **PPTX** 簡報的程式。在 Aspose.Slides for PHP via Java 中，這個值是固定的，顯示的是函式庫供應商而非您的應用程式名稱，即使您使用[DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/setnameofapplication/)。

**Producer** 識別在匯出期間產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for PHP via Java 時，這兩個欄位皆為固定值，反映函式庫及其版本。

**受限項目**

您無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入 "Aspose.Slides for PHP via Java"。對於 **PDF**，Creator 與 Producer 屬性會寫入 "Aspose.Slides for PHP via Java x.x.x."。此行為屬於設計決策，無論您如何載入或儲存檔案，亦無論是否使用[DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/documentproperties/setnameofapplication/) 指定值，都會如此。