---
title: 評估 Aspose.Slides
type: docs
weight: 120
url: /zh-hant/net/evaluate-aspose-slides/
keywords:
- 評估 Aspose.Slides
- Aspose.Slides 評估
- 評估版
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
description: "評估 .NET 版 Aspose.Slides，並探索針對 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能—開始您的免費試用。"
---
## **Aspose.Slides 評估版**

您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買的套件相同。只要新增幾行程式碼套用授權，即可將評估版轉為正式授權版。

Aspose.Slides 的評估版（未指定授權）提供完整的產品功能，但在開啟或儲存文件時會在文件頂部插入評估水印。從投影片中擷取文字時亦僅限於單一投影片。

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="info" %}} 
如果您想在不受評估版限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時許可證**。請參閱 [如何取得臨時授權？](https://purchase.aspose.com/temporary-license) 以取得更多資訊。
{{% /alert %}}

## **安裝評估套件**

```bash
dotnet add package Aspose.Slides.NET
```

## **套用授權**

以下這幾行程式碼會將評估套件轉換為授權版。請在應用程式啟動時於建立任何 `Presentation` 物件之前套用授權——先前建立的簡報仍會保留評估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 也接受 `Stream`，當授權以嵌入資源而非磁碟檔案方式提供時，這是較好的選擇。若路徑錯誤或檔案已過期，呼叫會拋出例外，讓失敗立即於啟動時顯示，而不是默默回復為評估模式。

授權套用後，水印即會消失，且單投影片文字擷取的限制也會解除。

## **FAQ**

### 我可以在評估模式下於不同執行緒中平行測試多個簡報嗎？

是的。您可以平行處理不同的文件；不要在多執行緒間共享同一個簡報物件 [跨執行緒](/slides/zh-hant/net/multithreading/)。評估模式不受此限制。

### 評估此函式庫於伺服器或 CI 時，我需要安裝 Microsoft PowerPoint 嗎？

不需要。Aspose.Slides 為獨立引擎，無論是評估或正式運行都不需要安裝 PowerPoint。

### 我可以在評估模式下完整測試 PPT/PPTX 轉 PDF 與影像的轉換嗎？

可以。[converters](/slides/zh-hant/net/convert-presentation/) 可正常運作，產出的檔案會加入水印。

### 我可以使用臨時授權進行負載測試且不出現水印嗎？

可以。30 天的臨時授權會移除評估模式的限制，並允許在測試時不顯示水印。