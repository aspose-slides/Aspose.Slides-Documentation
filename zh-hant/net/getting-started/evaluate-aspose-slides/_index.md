---
title: 評估 Aspose.Slides
type: docs
weight: 75
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
description: "評估 .NET 版的 Aspose.Slides，並探索 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能 — 開始免費試用。"
---
## **Aspose.Slides 評估**

您可以下載 Aspose.Slides 進行評估。評估套件與購買的套件相同；在加入少量程式碼以套用授權後，即可轉為授權版。

在未套用授權的情況下，Aspose.Slides 仍提供完整功能，但有兩項限制：它會在每個儲存的簡報的每張投影片上加入評估水印文字框，且程式碼從簡報讀取的文字會被截斷為前幾個字元，並附帶評估限制的通知。程式碼寫入的文字則會完整儲存。

![一張帶有評估水印的投影片](evaluate-aspose-slides_1.png)

{{% alert color="info" title="注意" %}}
如果您想測試 Aspose.Slides 而不受到評估版限制，可索取 **30 天臨時授權**。詳情請參考[如何取得臨時授權？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **安裝評估套件**

```bash
dotnet add package Aspose.Slides.NET
```

在 Linux 和 macOS 上，您可以改用 Aspose.Slides.NET6.CrossPlatform 套件；請參閱[安裝](/slides/zh-hant/net/installation/)。

## **套用授權**

以下即是將評估套件轉為授權版的「少量程式碼」。在應用程式啟動時一次套用授權，於任何 `Presentation` 物件建立之前執行——若之前已建立簡報，仍會保留評估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 也接受 `Stream`，當授權以嵌入資源形式提供而非磁碟檔案時，這是較佳的選擇。若路徑錯誤或檔案已過期，呼叫會拋出例外，因而在啟動時立即顯示失敗，而不會靜默回到評估模式。

一旦授權套用完成，儲存的簡報將不再帶有水印，且文字會完整讀取。

## **常見問題**

### 我可以在評估模式下於不同執行緒平行測試多個簡報嗎？

可以。您可以平行處理不同文件；只要不要在[執行緒間共享同一個簡報物件](/slides/zh-hant/net/multithreading/)。評估模式不影響此行為。

### 在伺服器或 CI 環境評估此函式庫是否需要安裝 Microsoft PowerPoint？

不需要。Aspose.Slides 為獨立引擎，無論是評估或正式使用，都不需要安裝 PowerPoint。

### 我能在評估模式下完整測試 PPT/PPTX 轉 PDF 及影像嗎？

可以。[轉換器](/slides/zh-hant/net/convert-presentation/) 可正常運作；輸出結果會帶有水印。

### 我可以使用臨時授權進行負載測試且不顯示水印嗎？

可以。30 天臨時授權會移除評估模式的限制，允許在沒有水印的情況下進行測試。