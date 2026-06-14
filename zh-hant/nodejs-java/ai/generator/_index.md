---
title: AI 驅動多語言投影片產生器
linktitle: AI 驅動產生器
type: docs
weight: 40
url: /zh-hant/nodejs-java/ai/generator/
keywords:
- 多語言簡報
- 多語言投影片
- AI 簡報產生器
- AI 投影片產生器
- AI 驅動功能
- AI 代理
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 從文字產生多語言投影片。套用您的範本並將精緻的簡報匯出為 PowerPoint 與 OpenDocument。了解更多。"
---
## **簡介**

Aspose.Slides 引入了一項全新的 AI 驅動功能——簡報產生器，讓開發人員只需提供簡單的文字輸入（例如主題說明、摘要、引用或要點），即可自動建立結構良好的 PowerPoint 簡報。

使用者可以調整內容細節層級，並可選擇套用自訂的簡報範本，以定義視覺設計。

目前，AI 簡報產生器使用文字區塊、項目列表和表格來構建內容。尚未支援影像產生；但可在之後使用 Aspose.Slides 工具或手動輕鬆加入影像。

輸出是一個完整的 PowerPoint 簡報，可直接使用或匯出為 Aspose.Slides API 支援的任何格式。雖然產生器能提供高品質的結果，仍可能需要少量後製編輯以符合特定需求。

## **運作原理**

Aspose.Slides 本身不包含內建的 AI 模型，而是透過網路與外部 AI 服務整合。此整合由 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesaiagent/) 類別負責處理。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/)，它會連接至 OpenAI 的 API。Aspose.Slides 會管理與 AI 服務的所有通訊，並處理 AI 的回應以產生投影片。請注意，OpenAI API 為付費服務，使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 時需具備帳號與 API 金鑰。

## **讓我們編寫程式**

### **範例 1**

此範例示範如何使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 產生有關 Aspose.Slides 主題的簡報。

```js
// 建立 OpenAIWebClient 實例，這是 OpenAI 網路客戶端的內建實作。
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // 建立 SlidesAIAgent 實例，提供存取 AI 驅動功能。
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // 定義產生簡報的指示。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 根據指示產生內容量為中等的簡報。
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // 將產生的簡報儲存為 PowerPoint (.pptx) 檔案至本機磁碟。
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **範例 2**

以下範例示範 [generatePresentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) 方法的多載。此情況下使用外部管理的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 例項以及使用者的 `master presentation`。

預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 會自行建立與管理其內部的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 例項，並自動處理其生命週期。然而，如果您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)（例如在使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以改進資源管理與效能），便可在建立 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/openaiwebclient/) 時提供自訂的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 例項。

```js
// 將 HttpURLConnection 傳遞給 OpenAIWebClient 建構子。
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // 建立 SlidesAIAgent 的實例。
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // 定義產生簡報的指示。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 從本機磁碟載入主簡報作為設計範本。
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // 使用指示與主範本產生詳細的簡報。
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // 將產生的簡報儲存為 PDF。
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **主要優勢**

Aspose.Slides 中全新的 AI 簡報產生器提供了一種快速且彈性的方式，能從簡單的文字提示產生結構化的投影片套。支援自訂範本與外部管理的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 例項，使其能無縫整合至各種應用程式。

典型的使用情境包括製作行銷簡報、教學教材、客戶報告以及內部投影片套。雖然目前尚未支援影像產生，但此工具已為自動化簡報建立奠定了堅實基礎，未來亦預期會持續加入更多功能。