---
title: AI 驅動的多語言投影片產生器
linktitle: AI 驅動的產生器
type: docs
weight: 40
url: /zh-hant/java/ai/generator/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 從文字產生多語言投影片。套用您的模板，並將精緻的簡報匯出至 PowerPoint 與 OpenDocument。了解更多。"
---
## **簡介**

Aspose.Slides 推出了一項全新的 AI 驅動功能——Presentation Generator，可讓開發人員從主題說明、摘要、引述或項目符號等簡單文字輸入，自動建立結構完善的 PowerPoint 簡報。  
使用者可以調整內容詳盡程度，並可選擇套用自訂的簡報模板，以定義視覺設計。  
目前，AI Presentation Generator 以文字區塊、項目清單和表格來組織內容。尚未支援影像產生；不過，之後可使用 Aspose.Slides 工具或手動方式輕鬆加入影像。  
輸出為完整的 PowerPoint 簡報，可直接使用或匯出為 Aspose.Slides API 支援的任何格式。雖然產生器能提供高品質的結果，但可能仍需進行少量後置編輯以符合特定需求。

## **運作方式**

Aspose.Slides 本身不含內建 AI 模型；相反地，它透過網際網路與外部 AI 服務整合。此整合由 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesaiagent/) 類別負責處理，該類別使用 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaiwebclient/) 介面的實作來與 AI 模型通訊。  
您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/)，它會連接至 OpenAI 的 API，或自行提供 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaiwebclient/) 的自訂實作，以配合其他 AI 供應商或語言模型。Aspose.Slides 會管理與 AI 服務的所有通訊，並處理 AI 的回應以產生投影片。請注意，OpenAI API 為付費服務，使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 時需要擁有帳號與 API 金鑰。

## **讓我們編寫程式**

### **範例 1**

此範例示範如何使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/)，針對 Aspose.Slides 主題產生簡報。

```java
// 建立 OpenAIWebClient 實例，這是內建的 OpenAI 網路客戶端實作。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // 建立 SlidesAIAgent 實例，可存取 AI 驅動功能。
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // 定義產生簡報的指示內容。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 依據指示產生內容適中量的簡報。
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
        // 將產生的簡報儲存至本機磁碟為 PowerPoint (.pptx) 檔案。
        presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **範例 2**

以下範例示範 [generatePresentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) 方法的多載。此情況下，使用外部管理的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例以及使用者的 `master presentation`。  
預設情況下，內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 會建立並管理自己的內部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，自動處理其生命週期。然而，若您希望自行管理 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)——例如在使用 [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) 或 [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) 以提升資源管理與效能時——可在建構 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/openaiwebclient/) 時提供自訂的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例。

```java
// 將 HttpURLConnection 傳遞給 OpenAIWebClient 建構函式。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // 建立 SlidesAIAgent 的實例。
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // 定義產生簡報的指示。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 從本機磁碟載入主簡報以作為設計樣板。
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // 使用指示與主樣板產生詳細的簡報。
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // 將產生的簡報儲存為 PDF。
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **主要優勢**

Aspose.Slides 全新的 AI Presentation Generator 提供快速且彈性的方式，從簡單文字提示產生結構化的投影片組合。支援自訂模板與外部管理的 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) 實例，使其能無縫整合至各式應用程式中。  
典型的使用情境包括製作行銷簡報、教學教材、客戶報告以及內部投影片。雖然尚未支援影像產生，但此工具已提供堅實的基礎，用於自動化簡報製作，未來亦預計加入更多功能。