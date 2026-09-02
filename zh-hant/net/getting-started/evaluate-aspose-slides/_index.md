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
description: "評估 .NET 版 Aspose.Slides，並探索支援 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能—立即開始免費試用。"
---
## **Aspose.Slides 評估**

您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買的套件相同。只要在程式碼中加入幾行以套用授權，即可將評估版轉為正式授權。

未指定授權的 Aspose.Slides 評估版提供完整的產品功能，但在開啟或儲存文件時會在文件頂部插入評估水印。從簡報投影片中擷取文字時，亦僅限於單一投影片。

![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 
如果您想測試 Aspose.Slides 而不受評估版限制，您可以申請 **30 天暫時授權**。更多資訊請參閱[如何取得暫時授權？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **安裝評估套件**

```bash
dotnet add package Aspose.Slides.NET
```

## **套用授權**

以下「幾行程式碼」可將評估套件轉為授權版。請在應用程式啟動時一次套用授權，且在建立任何 `Presentation` 物件之前完成—若先前已建立的簡報會保留評估水印。

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` 也接受 `Stream`，當授權以嵌入資源而非磁碟檔案形式提供時，這是較佳的選擇。若路徑錯誤或檔案已過期，呼叫會拋出例外，讓錯誤於啟動時即被發現，而不會靜默回復為評估模式。

套用授權後，水印會消失，且單投影片文字擷取的限制也會解除。

## **常見問題集**

### 在評估模式下，我可以在不同執行緒中同時測試多個簡報嗎？

可以。您可以平行處理不同的文件；不應該在執行緒之間共享同一個簡報物件 [跨執行緒](/slides/zh-hant/net/multithreading/)。評估模式不會影響此行為。

### 我是否需要安裝 Microsoft PowerPoint 才能在伺服器或 CI 上評估此函式庫？

不需要。Aspose.Slides 是獨立的引擎，無論是評估還是正式環境都不需要安裝 PowerPoint。

### 我能在評估模式下完整測試 PPT/PPTX 轉 PDF 與影像的功能嗎？

可以。[轉換器](/slides/zh-hant/net/convert-presentation/) 可正常運作；產出文件會包含水印。

### 我可以使用暫時授權進行負載測試而不出現水印嗎？

可以。30 天暫時授權會移除評估模式的限制，並允許在測試時不顯示水印。