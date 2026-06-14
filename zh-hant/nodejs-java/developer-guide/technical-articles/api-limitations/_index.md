---
title: API 限制
type: docs
weight: 320
url: /zh-hant/nodejs-java/api-limitations/
keywords:
- API 限制
- 匯出格式
- 應用程式
- 產生器
- 文件屬性
- 中繼資料
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js 的限制：匯出時在 PPT、PPTX、ODP 與 PDF 中設定固定的 Application/Producer 中繼資料，協助您在整合時避免意外。"
---
## **概觀**

使用 Aspose.Slides 建立或匯出簡報時，某些技術中繼資料會寫入輸出檔案。本文說明 PPTX 與 PDF 檔案中與 `Application`、`Creator` 與 `Producer` 中繼資料欄位相關的限制。

## **應用程式與產生器**

使用 Aspose.Slides for Node.js via Java 建立或匯出簡報時，會將某些技術中繼資料寫入檔案。常會有疑問的兩個欄位如下：

**Application** 識別建立或最後一次儲存 **PPTX** 簡報的程式。在 Aspose.Slides for Node.js via Java 中，此值是固定的，顯示的是函式庫供應商而非您的應用程式名稱，即使您使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/setnameofapplication/)。

**Producer** 識別在匯出過程中產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for Node.js via Java 時，這兩個欄位皆為固定值，反映函式庫及其版本。

## **受限項目**

無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入「Aspose.Slides for Node.js via Java」。對於 **PDF**，Creator 與 Producer 屬性會寫入「Aspose.Slides for Node.js via Java x.x.x.」此行為是設計如此，且不論您如何載入或儲存檔案，亦不受使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/documentproperties/setnameofapplication/) 所指定的值影響。