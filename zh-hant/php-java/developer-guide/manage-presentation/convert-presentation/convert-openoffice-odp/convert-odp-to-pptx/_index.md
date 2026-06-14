---
title: 在 PHP 中將 ODP 轉換為 PPTX
linktitle: ODP 轉 PPTX
type: docs
weight: 10
url: /zh-hant/php-java/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 ODP
- OpenDocument 轉 PPTX
- ODP 轉 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 為 PPTX
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 將 ODP 轉換為 PPTX。乾淨的程式範例、批次提示以及高品質結果—無需 PowerPoint。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **將 ODP 轉換為 PPTX/PPT 簡報**
Aspose.Slides for PHP via Java 提供了代表簡報檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別。當建立物件時，[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別現在也可以透過其 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) 建構函式存取 ODP。以下範例顯示如何將 ODP 簡報轉換為 PPTX 簡報。

```php
// 開啟 ODP 檔案
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # 將 ODP 簡報儲存為 PPTX 格式
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **即時範例**
您可以造訪[**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 網路應用程式，此應用程式是使用**Aspose.Slides API**建置的。該應用程式示範了如何使用 Aspose.Slides API 實作 ODP 轉換為 PPTX。

## **常見問題集**

**我需要安裝 Microsoft PowerPoint 或 LibreOffice 來將 ODP 轉換為 PPTX 嗎？**

不需要。Aspose.Slides 可獨立運作，且不需要第三方應用程式來讀寫 ODP/PPTX。

**轉換過程中會保留母片、版面配置和主題嗎？**

會。此函式庫使用完整的簡報物件模型，並保留結構，包括母片和版面配置，因而在轉換後設計仍保持正確。

**我可以轉換受密碼保護的 ODP 檔案嗎？**

可以。Aspose.Slides 支援偵測保護，當提供密碼時即可開啟並處理[受保護的簡報](/slides/zh-hant/php-java/password-protected-presentation/)（包含 ODP），同時也支援設定加密與存取文件屬性。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

可以。您可以在自己的後端使用本機函式庫，或使用[Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；這兩種方式皆支援 ODP → PPTX 轉換。