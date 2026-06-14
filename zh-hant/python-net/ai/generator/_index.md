---
title: AI 驅動的多語言投影片產生器
linktitle: AI 驅動的產生器
type: docs
weight: 40
url: /zh-hant/python-net/ai/generator/
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
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 從文字產生多語言投影片。套用您的範本並匯出精緻的簡報至 PowerPoint 和 OpenDocument。了解更多。"
---
## **Introduction**

Aspose.Slides 推出了一項新的 AI 驅動功能——Presentation Generator，讓開發人員能夠根據簡單的文字輸入（如主題描述、摘要、引言或項目符號）自動建立結構良好的 PowerPoint 簡報。

使用者可以調整內容細節層級，並可選擇套用自訂的簡報範本以定義視覺設計。

目前，AI Presentation Generator 以文字區塊、項目清單與表格來組織內容。尚未支援影像產生；不過，之後可使用 Aspose.Slides 工具或手動方式輕鬆加入影像。

輸出為完整的 PowerPoint 簡報，可直接使用或匯出為 Aspose.Slides API 所支援的任何格式。雖然產生器可提供高品質的結果，仍可能需要少量後期編輯以符合特定需求。

## **How it Works**

Aspose.Slides 並未內建 AI 模型；相反地，它透過網際網路整合外部 AI 服務。此整合由 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/slidesaiagent/) 類別處理，該類別使用 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/iaiwebclient/) 類別的實作來與 AI 模型通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/openaiwebclient/)，它會連接至 OpenAI 的 API，或提供自訂的 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/iaiwebclient/) 實作，以配合其他 AI 供應商或語言模型。Aspose.Slides 會管理與 AI 服務的所有通訊，並處理 AI 回應以產生投影片。請注意，OpenAI API 為付費服務，使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/openaiwebclient/) 時需要具備帳號與 API 金鑰。

## **Let's Code**

### **Example 1**

此範例示範如何使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/openaiwebclient/) 以 Aspose.Slides 為主題產生簡報。

```py
# 建立 OpenAIWebClient 的實例，這是內建的 OpenAI 網路客戶端實作。
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # 建立 SlidesAIAgent 的實例，可存取 AI 驅動功能。
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # 定義產生簡報的指示。
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # 根據指示產生內容量為中等的簡報。
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # 將產生的簡報儲存至本機磁碟，作為 PowerPoint（.pptx）檔案。
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **Example 2**

以下範例示範 [generate_presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) 方法的多載。此例中使用使用者的 `master presentation`。

```py
# 將 HttpClient 傳入 OpenAIWebClient 建構函式。
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # 建立 SlidesAIAgent 的實例。
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # 定義產生簡報的指示。
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # 從本機磁碟載入主簡報作為設計範本。
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # 使用指示和主範本產生詳細的簡報。
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # 將產生的簡報儲存為 PDF。
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **Key Benefits**

Aspose.Slides 的全新 AI Presentation Generator 提供快速且彈性的方式，從簡單文字提示產生結構化的投影片組。支援自訂範本，使其可無縫整合到各式應用程式中。

典型的使用案例包括製作行銷簡報、教育教材、客戶報告與內部投影片。雖然目前尚未支援影像產生，但此工具已提供穩固的自動化簡報建立基礎，未來亦預期會有更多功能提升。