---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/net/ai/translator/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用し、AI で PowerPoint スライドを翻訳します。レイアウトを保持したまま PPT、PPTX、ODP をローカライズし、迅速かつ開発者に優しいツールです。ぜひお試しください。"
---
## **イントロダクション**

Aspose.Slides は、プログラムから PowerPoint プレゼンテーションを管理するための強力な API です。スライドの作成、編集、変換に加えて、[プレゼンテーション翻訳 API](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/) などの AI 駆動機能を提供し、スライド コンテンツを多言語化できます。

## **動作概要**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部 AI モデルと統合できます。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/slidesaiagent) クラスを通じて公開されており、[IAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) を使用して OpenAI の API に接続するか、別の AI プロバイダーや言語モデルを使用するために独自の [IAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/iaiwebclient/) を実装できます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" title="Note" %}}
OpenAI API は有料サービスです。組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) を使用する際は、アカウントを作成し API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) と指定した OpenAI [モデル](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// 翻訳するプレゼンテーションを読み込む。
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient で AI クライアントを作成し、モデルと API キーを指定します。
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI クライアントで SlidesAIAgent を初期化します。
var aiAgent = new SlidesAIAgent(aiWebClient);

// プレゼンテーションを日本語に翻訳します。
await aiAgent.TranslateAsync(presentation, "japanese");

// 翻訳されたプレゼンテーションを PDF として保存します。
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) が独自の内部 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンスを作成・管理し、ライフサイクルと破棄を自動的に処理します。ただし、リソース管理とパフォーマンス向上のために [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) を使用したい場合などは、[OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) の構築時に独自の `HttpClient` インスタンスを渡すことができます。

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// 自分で管理する HttpClient を使用します - 例として、IHttpClientFactory で作成されたものです
// 依存性注入によって注入されます。
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides は主に同期環境で使用されます。このため、[SlidesAIAgent](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/slidesaiagent/) クラスは同期メソッドと非同期メソッドの両方を提供し、アプリケーションのワークフローに最適な方法を選択できます。

### **Azure OpenAI の例**

Aspose.Slides for .NET は Azure OpenAI を含む OpenAI 互換プロバイダーをサポートしています。[OpenAICompatibleWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaicompatiblewebclient/) を使用して、社内の Azure デプロイメントを翻訳に利用できます。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

var model = "your-azure-deployment-name";
var apiKey = "your-azure-api-key";
var baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

using var aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
var aiAgent = new SlidesAIAgent(aiWebClient);
using var presentation = new Presentation("Presentation.pptx");
aiAgent.Translate(presentation, "spanish");
presentation.Save("Translated.pptx", SaveFormat.Pptx);
```

このスニペットは Azure OpenAI エンドポイントを使用してプレゼンテーションを翻訳する例です。プレースホルダーの値をデプロイメント名、API キー、エンドポイント URL に置き換えてください。

## **主な利点**

Aspose.Slides の [プレゼンテーション翻訳 API](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/) は、AI を活用した多言語 PowerPoint プレゼンテーション配信ソリューションを提供します。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を利用してグローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチの拡大とコミュニケーションの向上につながります。