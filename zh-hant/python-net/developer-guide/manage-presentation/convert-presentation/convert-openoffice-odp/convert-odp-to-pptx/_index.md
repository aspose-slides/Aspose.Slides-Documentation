---
title: 在 Python 中將 ODP 轉換為 PPTX
linktitle: ODP 轉 PPTX
type: docs
weight: 10
url: /zh-hant/python-net/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換 ODP
- OpenDocument 轉 PPTX
- ODP 轉 PPTX
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 將 ODP 轉換為 PPTX。乾淨的程式碼範例、批次提示以及高品質結果——無需 PowerPoint。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **匯出 ODP 為 PPTX**

Aspose.Slides for Python via .NET 提供代表簡報檔案的 Presentation 類別。[**Presentation**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別現在也可以在實例化物件時透過 Presentation 建構函式存取 ODP。以下範例示範如何將 ODP 簡報轉換為 PPTX 簡報。

```py
# 匯入 Aspose.Slides for Python via .NET 模組
import aspose.slides as slides

# 開啟 ODP 檔案
pres = slides.Presentation("AccessOpenDoc.odp")

# 將 ODP 簡報儲存為 PPTX 格式
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **即時範例**

您可以造訪 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 網路應用程式，該應用程式是使用 **Aspose.Slides API** 建置的。此應用程式示範了如何使用 Aspose.Slides API 實作 ODP 轉換為 PPTX 的功能。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 或 LibreOffice 來將 ODP 轉換為 PPTX 嗎？**

不需要。Aspose.Slides 可獨立運作，無需第三方應用程式即可讀寫 ODP/PPTX。

**轉換過程中會保留母片、版面配置和佈景主題嗎？**

會。此函式庫使用完整的簡報物件模型，保留結構，包括母片和版面配置，因而在轉換後設計仍保持正確。

**我可以轉換受密碼保護的 ODP 檔案嗎？**

可以。Aspose.Slides 支援偵測保護，當您提供密碼時，可開啟並處理[受保護的簡報](/slides/zh-hant/python-net/password-protected-presentation/)（包括 ODP），同時也能設定加密和存取文件屬性。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

可以。您可以在自己的後端使用本機函式庫，或使用 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；這兩種方式皆支援 ODP → PPTX 轉換。