---
title: 評估 Aspose.Slides
type: docs
weight: 120
url: /zh-hant/nodejs-java/evaluate-aspose-slides/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "透過 Java 評估 Aspose.Slides for Node.js，探索 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報的 API 功能—立即開始免費試用。"
---
## **Aspose.Slides 評估**

您可以下載 Aspose.Slides 以進行評估。評估套件與購買的套件相同；在加入少許程式碼以套用授權後，即可取得授權。若要安裝，請參閱[Installation](/slides/zh-hant/nodejs-java/installation/)。

若未取得授權，Aspose.Slides 於評估模式下仍提供完整功能，但有兩項限制：它會在每個保存的簡報的每張投影片上添加評估水印文字框，且程式碼從簡報中讀取的文字若超過五個字元，將被截斷為前五個字元，後接 `... text has been truncated due to evaluation version limitation.`；五個字元或以下的文字會完整返回，程式碼寫入的文字則會完整儲存。每次保存都會添加水印，因此在評估模式下開啟後再次保存的簡報會在每張投影片上累積每次保存一次的水印。

{{% alert color="info" title="Note" %}}

如果您想在不受評估版限制的情況下測試 Aspose.Slides，您可以申請 **30 天暫時授權**。更多資訊請參閱[How to get a Temporary License?](https://purchase.aspose.com/temporary-license)。

{{% /alert %}}

## **常見問題**

### 我可以在評估模式下於不同執行緒中平行測試多個簡報嗎？

是的。您可以平行處理不同的文件；但不應在[across threads](/slides/zh-hant/nodejs-java/multithreading/) 中共享相同的簡報物件。評估模式不會影響此行為。

### 我需要在伺服器或 CI 上安裝 Microsoft PowerPoint 以評估此函式庫嗎？

不需要。Aspose.Slides 為獨立的引擎，無論在評估或正式環境皆不需安裝 PowerPoint。

### 我可以在評估模式下完整測試 PPT/PPTX 轉換為 PDF 與影像嗎？

可以。該[converters](/slides/zh-hant/nodejs-java/convert-presentation/) 可正常運作；輸出結果會包含水印。

### 我可以使用暫時授權進行負載測試且不產生水印嗎？

可以。30 天的暫時授權會移除評估模式的限制，讓測試時不會產生水印。