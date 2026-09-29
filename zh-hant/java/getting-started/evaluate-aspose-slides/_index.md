---
title: 評估 Aspose.Slides
type: docs
weight: 85
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
description: "評估 Aspose.Slides for Java 並探索針對 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能—開始您的免費試用。"
---
## **Aspose.Slides 評估**

您可以下載 Aspose.Slides 以進行評估。評估版下載與購買版下載相同；在加入少量程式碼以套用授權後，即會取得授權。

未授權時，Aspose.Slides 在評估模式下仍提供完整功能，但有兩項限制：它會在每個儲存的簡報的每張投影片上加入評估水印文字框；以及透過 API 讀取的文字（包括剛剛設定的文字）會被截斷為前幾個字元，並附加評估限制的訊息。程式寫入的文字則會完整儲存。[getPresentationText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentationfactory/#getPresentationText-java.lang.String-int-) 方法會在不載入整個簡報的情況下提取文字，但只會返回評估通知，且不會返回投影片文字。

![帶有評估水印的投影片](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
如果您想在不受評估版限制的情況下測試 Aspose.Slides，也可以申請 30 天的臨時授權。請參閱 [如何取得臨時授權？](https://purchase.aspose.com/temporary-license)
{{% /alert %}}

## **常見問題**

### 我可以在評估模式下於不同執行緒中同時測試多個簡報嗎？

是。您可以平行處理不同的文件；不應在不同執行緒之間共享同一個 presentation 物件 [across threads](/slides/zh-hant/java/multithreading/)。評估模式不會影響這點。

### 在伺服器或 CI 上評估此函式庫時，我需要安裝 Microsoft PowerPoint 嗎？

不需要。Aspose.Slides 為獨立引擎，無論是評估或正式環境皆不需安裝 PowerPoint。

### 我可以在評估模式下完整測試將 PPT/PPTX 轉換為 PDF 與影像嗎？

是。 [converters](/slides/zh-hant/java/convert-presentation/) 正常運作；輸出會包含水印。

### 我可以使用臨時授權進行負載測試而不出現水印嗎？

是。30 天的臨時授權會移除評估模式的限制，並允許在不出現水印的情況下測試。