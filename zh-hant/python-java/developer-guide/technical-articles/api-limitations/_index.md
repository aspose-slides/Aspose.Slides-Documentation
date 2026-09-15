---
title: API 限制
type: docs
weight: 320
url: /zh-hant/python-java/api-limitations/
keywords:
- API 限制
- 匯出格式
- 應用程式
- 產製者
- 文件屬性
- 中繼資料
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 的限制：PPTX 與 PDF 檔案中固定的 Application、Creator 與 Producer 中繼資料。"
---
## **概覽**

當使用 Aspose.Slides 建立或匯出簡報時，某些技術性中繼資料會寫入輸出檔案。本文說明 PPTX 與 PDF 檔案中 `Application`、`Creator` 與 `Producer` 中繼資料欄位的限制。

## **Application 與 Producer**

當您使用 Aspose.Slides for Python via Java 建立或匯出簡報時，會將一些技術性中繼資料寫入檔案。以下兩個欄位常會引起疑問：

**Application** 用來識別建立或最後儲存 **PPTX** 簡報的程式。在 Aspose.Slides for Python via Java 中，該值是固定的，會顯示函式庫供應商，而非您的應用程式名稱，即使您使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#setnameofapplication)。

**Producer** 用來識別在匯出期間產生最終檔案的渲染引擎。在 **PDF** 匯出時，中繼資料使用 **Creator** 與 **Producer** 欄位。使用 Aspose.Slides for Python via Java 時，這兩個欄位皆為固定，會反映函式庫及其版本。

**受限項目**

您無法透過 API 覆寫上述格式的這些欄位。對於 **PPTX**，Application 屬性會寫入「Aspose.Slides for Java」。對於 **PDF**，Creator 與 Producer 屬性會寫入「Aspose.Slides for Java x.x.x」。此行為為設計使然，無論您如何載入或儲存檔案，也無論使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#setnameofapplication) 指定何種值，都會如此。

## **FAQ**

**我可以將 PPTX 檔案中的 Application 值改成我的應用程式名稱嗎？**

不能。此值是固定的，即使您使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/documentproperties/#setnameofapplication)。

**我可以在 PDF 匯出時覆寫 Creator 和 Producer 欄位嗎？**

不能。這兩個欄位皆為固定，會反映函式庫及其版本，與您如何載入或儲存簡報無關。