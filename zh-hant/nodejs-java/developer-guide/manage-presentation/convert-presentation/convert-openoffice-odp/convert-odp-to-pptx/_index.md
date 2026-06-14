---
title: 將 ODP 轉換為 PPTX（JavaScript）
linktitle: ODP 轉換為 PPTX
type: docs
weight: 10
url: /zh-hant/nodejs-java/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 ODP
- OpenDocument 轉 PPTX
- ODP 轉 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 至 PPTX
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 將 ODP 轉換為 PPTX。乾淨的 JavaScript 程式碼範例、批次提示，以及高品質結果—無需 PowerPoint。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **將 ODP 轉換為 PPTX/PPT 簡報**

Aspose.Slides for Node.js via Java 提供表示簡報檔案的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。現在，當建立物件時，[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別也能透過 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) 建構函式存取 ODP。以下範例說明如何將 ODP 簡報轉換為 PPTX 簡報。

```javascript
// 開啟 ODP 檔案
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// 將 ODP 簡報儲存為 PPTX 格式
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **即時範例**

您可以造訪[**Aspose.Slides 轉換**](https://products.aspose.app/slides/zh-hant/conversion/) Web 應用程式，它是以 **Aspose.Slides API** 建置的。此應用程式展示了如何使用 Aspose.Slides API 實作 ODP 到 PPTX 的轉換。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 或 LibreOffice 來將 ODP 轉換為 PPTX 嗎？**

不需要。Aspose.Slides 可獨立運作，無需第三方應用程式即可讀寫 ODP/PPTX。

**在轉換過程中會保留母片、版面配置與主題嗎？**

會。此函式庫使用完整的簡報物件模型，保留結構，包括母片與版面配置，確保轉換後的設計保持正確。

**我能轉換受密碼保護的 ODP 檔案嗎？**

是。Aspose.Slides 支援偵測保護，當提供密碼時可開啟並處理[受保護的簡報](/slides/zh-hant/nodejs-java/password-protected-presentation/)（包括 ODP），同時可設定加密與存取文件屬性。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

是。您可以在自己的後端使用本機函式庫，或使用 [Aspose.Slides 雲端](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；兩種方式皆支援 ODP → PPTX 轉換。