---
title: 評估 Aspose.Slides
type: docs
weight: 120
url: /zh-hant/net/evaluate-aspose-slides/
keywords:
- 評估 Aspose.Slides
- Aspose.Slides 評估
- 評估版本
- 完整功能
- 評估水印
- 購買 Aspose.Slides
- 限制
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "評估 .NET 版 Aspose.Slides，並探索針對 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能——立即開始免費試用。"
---
## **Aspose.Slides 評估**

您可以下載 Aspose.Slides 以進行評估。評估套件與購買的套件相同；在加入幾行程式碼套用授權後，即會取得授權。

在未取得授權的情況下，Aspose.Slides 於評估模式下仍提供完整功能，但有兩項限制：它會在每個儲存的簡報的每張投影片上加入評估水印文字方塊，且程式碼從簡報讀取的文字會被截斷為前幾個字元，並附加有關評估限制的說明。程式碼寫入的文字則會完整儲存。

![帶有評估水印的投影片](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
如果您想在不受評估版限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。請參考[如何取得臨時授權？](https://purchase.aspose.com/temporary-license)以獲得更多資訊。
{{% /alert %}}

## **安裝評估套件**

```bash
dotnet add package Aspose.Slides.NET
```

在 Linux 和 macOS 上，您可以改用 Aspose.Slides.NET6.CrossPlatform 套件；請參閱[安裝](/slides/zh-hant/net/installation/)。

## **套用授權**

以下這些「幾行程式碼」會將評估套件轉為授權版。於應用程式啟動時一次套用授權，於建立任何 `Presentation` 物件之前——較早建立的簡報會保留評估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 也接受 `Stream`，當授權以嵌入資源而非磁碟檔案形式提供時，這是較好的選擇。如果路徑錯誤或檔案已過期，呼叫會拋出例外，讓錯誤於啟動時立即顯示，而不會靜默回復為評估模式。

一旦套用授權，儲存的簡報將不再帶有水印，且文字會完整讀取。

## **FAQ**

### 我可以在評估模式下於不同執行緒平行測試多個簡報嗎？

是的。您可以平行處理不同的文件；不應該在[跨執行緒](/slides/zh-hant/net/multithreading/)共享同一個簡報物件。評估模式不會影響此行為。

### 在伺服器或 CI 上評估此函式庫是否需要安裝 Microsoft PowerPoint？

不需要。Aspose.Slides 為獨立引擎，無論在評估或正式環境皆不需要安裝 PowerPoint。

### 我可以在評估模式下完整測試 PPT/PPTX 轉換為 PDF 與影像嗎？

可以。[轉換器](/slides/zh-hant/net/convert-presentation/) 可正常使用；輸出會包含水印。

### 我可以使用臨時授權進行負載測試且不顯示水印嗎？

可以。30 天臨時授權會移除評估模式限制，允許在不顯示水印的情況下進行測試。