---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/net/ai/translator/
keywords:
- AI プレゼンテーション翻訳
- AI スライド翻訳
- AI 駆動機能
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズでき、迅速で開発者に優しいです。ぜひお試しください。"
---

## **Aspose.Slides プレゼンテーション翻訳 API：AI で駆動する多言語スライド翻訳**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、[プレゼンテーション翻訳 API](https://reference.aspose.com/slides/net/aspose.slides.ai/) などの AI 駆動機能を提供し、多言語スライド コンテンツを実現します。

## **動作概要**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット上の外部 AI モデルと統合します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent) クラスを介して公開されており、[IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient) を使用して OpenAI の API に接続するか、別の AI プロバイダーや言語モデルを使用するために独自の [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient) を実装できます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライド レイアウトと書式設定を保持しながら翻訳済みコンテンツをインテリジェントに挿入します。

{{% alert color="primary" %}}
OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient) を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **サンプル**

このサンプルでは、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient) を使用し、指定した OpenAI [モデル](https://platform.openai.com/docs/models) で PowerPoint プレゼンテーションを日本語に翻訳します。

```csharp
// Load a presentation to translate.
using var presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// Initialize SlidesAIAgent with the AI client.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Translate the presentation to Japanese.
await aiAgent.TranslateAsync(presentation, "japanese");

// Save the translated presentation as a PDF.
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient) が独自の内部 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンスを作成および管理し、そのライフサイクルと破棄を自動的に処理します。ただし、[IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) を使用してリソース管理とパフォーマンスを向上させるために自分で [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) を管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient) の構築時に独自の `HttpClient` インスタンスを渡すことができます。

```csharp
// Assume you have an IHttpClientFactory instance (e.g., injected via dependency injection).
HttpClient httpClient = httpClientFactory.CreateClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides は同期環境で一般的に使用されます。これをサポートするために、[SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) クラスは同期メソッドと非同期メソッドの両方を提供し、アプリケーションのワークフローに最適なアプローチを選択できるようにします。

## **主なメリット**

Aspose.Slides の [プレゼンテーション翻訳 API](https://reference.aspose.com/slides/net/aspose.slides.ai/) は、AI 駆動の多言語 PowerPoint プレゼンテーション配信ソリューションを提供します。レイアウトとデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用してグローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを向上させます。