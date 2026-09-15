---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/python-net/ai/translator/
keywords:
- AI プレゼンテーション翻訳
- AI スライド翻訳
- AI 搭載機能
- 多言語プレゼンテーション
- 多言語スライド
- プレゼンテーション翻訳
- スライド翻訳
- AI 駆動機能
- AI 機能
- AI エージェント
- Web クライアント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持したまま PPT、PPTX、ODP をローカライズでき、迅速で開発者に優しいです。ぜひお試しください。"
---
## **はじめに**

Aspose.Slides は、プログラムで PowerPoint プレゼンテーションを管理するための強力な API です。スライドの作成、編集、変換に加えて、AI 駆動の機能も提供しており、たとえば多言語スライド コンテンツ向けの [Presentation Translation API](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/) があります。

## **動作概要**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット越しに外部の AI モデルと統合します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/slidesaiagent/) クラスを通じて提供され、[IAIWebClient](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/iaiwebclient/) のサブクラスを使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/openaiwebclient/) を使用して OpenAI の API に接続することも、別の AI プロバイダーや言語モデルを使用するために独自の [IAIWebClient](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/iaiwebclient/) を実装することもできます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" %}}
OpenAI API は有料サービスである点に注意してください。そのため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/openaiwebclient/) を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、指定された OpenAI の [model](https://platform.openai.com/docs/models) を使用して、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/openaiwebclient/) による PowerPoint プレゼンテーションを日本語に翻訳します。

```py
import aspose.slides as slides

# 翻訳するプレゼンテーションをロードします。
with slides.Presentation("sample.pptx") as presentation:

    # OpenAIWebClient を使用して AI クライアントを作成し、モデルと API キーを指定します。
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # AI クライアントで SlidesAIAgent を初期化します。
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # プレゼンテーションを日本語に翻訳します。
        ai_agent.translate(presentation, "japanese")

        # 翻訳されたプレゼンテーションを PDF として保存します。
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **Azure OpenAI の例**

**26.7.0** 以降、Aspose.Slides for Python via .NET は Azure OpenAI を含む OpenAI 互換プロバイダーをサポートします。翻訳機能を社内の Azure デプロイメントで使用するように、[OpenAICompatibleWebClient](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/openaicompatiblewebclient/) で構成できます。

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

このスニペットは、Azure OpenAI エンドポイントを使用してプレゼンテーションを翻訳する方法を示しています。プレースホルダーの値をデプロイメント名、API キー、エンドポイント URL に置き換えてください。

## **主な利点**

Aspose.Slides の [Presentation Translation API](https://reference.aspose.com/slides/ja/python-net/aspose.slides.ai/) は、マルチ言語 PowerPoint プレゼンテーションを提供するための AI 駆動ソリューションを提供します。レイアウトとデザインを保持しながら翻訳を自動化することで、手作業のワークフローに比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すると、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを改善できます。