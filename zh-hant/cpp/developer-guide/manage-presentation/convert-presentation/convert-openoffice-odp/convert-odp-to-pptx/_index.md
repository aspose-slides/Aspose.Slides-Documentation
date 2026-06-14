---
title: 在 C++ 中將 ODP 轉換為 PPTX
linktitle: ODP 轉換為 PPTX
type: docs
weight: 10
url: /zh-hant/cpp/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換簡報
- 轉換投影片
- 轉換 ODP
- OpenDocument 轉換為 PPTX
- ODP 轉換為 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 為 PPTX
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將 ODP 轉換為 PPTX。提供乾淨的程式碼範例、批次技巧與高品質結果—不需要 PowerPoint。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **ODP 轉換為 PPTX**

Aspose.Slides for .NET 提供表示簡報檔案的 Presentation 類別。[**Presentation**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別現在也可以透過在實例化物件時使用 Presentation 建構函式來存取 ODP。下列範例顯示如何將 ODP 簡報轉換為 PPTX 簡報。

``` cpp
// 文件目錄的路徑。
String dataDir = GetDataPath();

// 開啟 ODP 檔案
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// 將 ODP 簡報儲存為 PPTX 格式
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **即時範例**

您可以造訪[**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 網路應用程式，該應用程式是使用 **Aspose.Slides API** 建置的。此應用程式展示如何使用 Aspose.Slides API 實作 ODP 轉換為 PPTX 的功能。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 或 LibreOffice 來將 ODP 轉換為 PPTX 嗎？**

不需要。Aspose.Slides 可自行運作，無需第三方應用程式即可讀寫 ODP/PPTX。

**轉換過程中，會保留母片、版面配置和主題嗎？**

會。此函式庫使用完整的簡報物件模型，保留結構，包括母片與版面配置，因而在轉換後設計仍保持正確。

**我可以轉換受密碼保護的 ODP 檔案嗎？**

可以。Aspose.Slides 支援偵測保護、在提供密碼後開啟並處理[受保護的簡報](/slides/zh-hant/cpp/password-protected-presentation/)（包括 ODP），同時也能設定加密與文件屬性的存取權限。

**Aspose.Slides 適合用於雲端或基於 REST 的轉換服務嗎？**

可以。您可以在自己的後端使用本機函式庫，或使用[ Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；這兩種方式皆支援 ODP → PPTX 轉換。