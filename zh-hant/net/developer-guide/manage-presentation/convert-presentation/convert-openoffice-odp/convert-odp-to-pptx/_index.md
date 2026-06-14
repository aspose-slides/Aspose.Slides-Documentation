---
title: 在 .NET 中將 ODP 轉換為 PPTX
linktitle: ODP 轉換為 PPTX
type: docs
weight: 10
url: /zh-hant/net/convert-odp-to-pptx/
keywords:
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 ODP
- OpenDocument 轉換為 PPTX
- ODP 轉換為 PPTX
- 將 ODP 儲存為 PPTX
- 匯出 ODP 為 PPTX
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 將 ODP 轉換為 PPTX。乾淨的 C# 程式碼範例、批次提示以及高品質結果—無需 PowerPoint。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 ODP 簡報轉換為 PPTX 格式。

## **ODP 轉換為 PPTX**

Aspose.Slides for .NET 提供表示簡報檔案的 Presentation 類別。[**Presentation**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別現在也可以透過在建立物件時的 Presentation 建構函式存取 ODP。以下範例說明如何將 ODP 簡報轉換為 PPTX 簡報。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>步驟：在 C# 中將 ODP 轉換為 PPTX</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>步驟：在 C# 中將 ODP 轉換為 PowerPoint</strong></a>

```c#
// 開啟 ODP 檔案
Presentation pres = new Presentation("AccessOpenDoc.odp");

// 將 ODP 簡報儲存為 PPTX 格式
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **即時範例**

您可以造訪使用 **Aspose.Slides API** 建置的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 網頁應用程式。此應用程式示範如何使用 Aspose.Slides API 實作 ODP 轉換為 PPTX 的功能。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 或 LibreOffice 才能將 ODP 轉換為 PPTX 嗎？**

不需要。Aspose.Slides 可獨立運作，無需第三方應用程式即可讀寫 ODP/PPTX。

**轉換過程中會保留母片投影片、版面配置與佈景主題嗎？**

會。此函式庫使用完整的簡報物件模型，保留結構，包括母片投影片與版面配置，因而在轉換後設計仍保持正確。

**我可以轉換受密碼保護的 ODP 檔案嗎？**

會。Aspose.Slides 支援偵測保護，當您提供密碼時可開啟並處理 [protected presentations](/slides/zh-hant/net/password-protected-presentation/)（包含 ODP），同時也能設定加密與存取文件屬性。

**Aspose.Slides 適用於雲端或基於 REST 的轉換服務嗎？**

會。您可以在自己的後端使用本機函式庫，或使用 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/zh-hant/family/)（REST API）；兩種方案皆支援 ODP → PPTX 轉換。