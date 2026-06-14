---
title: AI 驅動簡報翻譯器
linktitle: AI 驅動翻譯器
type: docs
weight: 20
url: /zh-hant/python-net/ai/translator/
keywords:
- AI 簡報翻譯器
- AI 投影片翻譯器
- AI 驅動功能
- 多語言簡報
- 多語言投影片
- 簡報翻譯
- 投影片翻譯
- AI 驅動特徵
- AI 能力
- AI 代理
- Web 客戶端
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 的 AI 轉換 PowerPoint 投影片。將 PPT、PPTX 與 ODP 本地化，同時保留版面—快速且對開發人員友善。立即體驗。"
---
## **簡介**

Aspose.Slides 是一個功能強大的 API，用於以程式方式管理 PowerPoint 簡報。除了建立、編輯和轉換投影片外，它還提供 AI 驅動的功能，例如用於多語言投影片內容的 [Presentation Translation API](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/)。

## **運作方式**

Aspose.Slides 不包括內建的 AI 功能，但會透過網際網路與外部 AI 模型整合。此功能透過 [SlidesAIAgent](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/slidesaiagent/) 類別公開，該類別使用 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/iaiwebclient/) 子類別與 AI 服務通訊。

您可以使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/openaiwebclient/) 連接至 OpenAI 的 API，或實作自己的 [IAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/iaiwebclient/) 以使用其他 AI 提供者或語言模型。

Aspose.Slides 處理通訊、解析 AI 回應，並在保留原始投影片版面與格式的同時，智慧地插入翻譯後的內容。

{{% alert color="primary" %}}
請注意，OpenAI API 為付費服務，因此在使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/openaiwebclient/) 時，您需要建立帳號並提供 API 金鑰。
{{% /alert %}}

## **範例**

在此範例中，我們使用內建的 [OpenAIWebClient](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/openaiwebclient/) 與指定的 OpenAI [model](https://platform.openai.com/docs/models) 將 PowerPoint 簡報翻譯成日語。

```py
# 載入要翻譯的簡報。
with slides.Presentation("sample.pptx") as presentation:

    # 使用 OpenAIWebClient 建立 AI 客戶端，指定您的模型和 API 金鑰。
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # 使用 AI 客戶端初始化 SlidesAIAgent。
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # 將簡報翻譯成日文。
        ai_agent.translate(presentation, "japanese")

        # 將翻譯後的簡報儲存為 PDF。
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **主要好處**

Aspose.Slides 的 [Presentation Translation API](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.ai/) 提供 AI 驅動的解決方案，以提供多語言 PowerPoint 簡報。透過在保留版面與設計的同時自動化翻譯，相較於手動流程可節省時間並減少錯誤。無論您是開發人員、教育者或商業專業人士，此 API 都能讓您為全球觀眾建立有吸引力的本地化簡報，擴大影響範圍並提升溝通效果。