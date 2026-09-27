---
title: 評估 Aspose.Slides
type: docs
weight: 130
url: /zh-hant/java/evaluate-aspose-slides/
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
- Java
- Aspose.Slides
description: "評估 Java 版 Aspose.Slides，探索 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能—立即開始免費試用。"
---
## **Aspose.Slides 評估**

您可以下載 Aspose.Slides 以進行評估。評估版下載與購買版下載相同；在加入少量程式碼套用授權後，即會獲得授權。

未取得授權時，Aspose.Slides 在評估模式下仍提供完整功能，但有兩項限制：它會在每個保存的簡報的每張投影片上加入評估水印文字框，且透過 API 讀取的文字（包括剛設定的文字）會被截斷為前幾個字元，並附帶評估限制的通知。程式碼寫入的文字則會完整保存。`[getPresentationText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationText-java.lang.String-int-)` 方法在不載入完整簡報的情況下提取文字，僅回傳評估通知而不會返回投影片文字。

![含評估水印的投影片](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
如果您想在不受評估版限制的情況下測試 Aspose.Slides，也可以申請 30 天的臨時授權。請參閱 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license)
{{% /alert %}}

## **常見問題**

### 我可以在評估模式下於不同執行緒中平行測試多個簡報嗎？

可以。您可以平行處理不同的文件；不應該在 [跨執行緒](/slides/zh-hant/java/multithreading/) 時共享同一個簡報物件。評估模式不會影響此行為。

### 我需要在伺服器或 CI 環境上安裝 Microsoft PowerPoint 以評估此函式庫嗎？

不需要。Aspose.Slides 為獨立引擎，無論是評估或正式環境都不需要安裝 PowerPoint。

### 我能在評估模式下完整測試 PPT/PPTX 轉換為 PDF 以及影像嗎？

可以。相關的 [轉換器](/slides/zh-hant/java/convert-presentation/) 能正常運作；輸出結果會包含水印。

### 我可以使用臨時授權進行負載測試且不顯示水印嗎？

可以。30 天的臨時授權會移除評估模式的限制，讓測試過程中不會出現水印。