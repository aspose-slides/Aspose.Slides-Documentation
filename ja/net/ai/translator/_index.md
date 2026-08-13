---
title: AI搭載 プレゼンテーション翻訳ツール
linktitle: AI搭載 翻訳ツール
type: docs
weight: 20
url: /ja/net/ai/translator/
keywords:
- AIプレゼンテーション翻訳ツール
- AIスライド翻訳ツール
- AI搭載機能
- 多言語プレゼンテーション
- 多言語スライド
- プレゼンテーション翻訳
- スライド翻訳
- AI駆動機能
- AI機能
- AIエージェント
- Webクライアント
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズし、迅速かつ開発者に優しい体験を提供します。ぜひお試しください。"
---
## **Introduction**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、AI 駆動機能も提供します。たとえば、多言語スライド コンテンツ向けの [Presentation Translation API](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/) があります。

## **How It Works**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット上の外部 AI モデルと統合します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/slidesaiagent) クラスを介して提供され、[IAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) を使用して OpenAI の API に接続することも、独自の [IAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/iaiwebclient/) を実装して別の AI プロバイダーや言語モデルを使用することもできます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式設定を保持しながら、翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" %}}
OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **Example**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) と指定された OpenAI [model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。

```csharp
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

// 翻訳するプレゼンテーションをロードします。
using var presentation = new Presentation("sample.pptx");

// OpenAIWebClient を使用して AI クライアントを作成し、モデルと API キーを指定します。
using var aiWebClient = new OpenAIWebClient(model: "gpt-4o-mini", apiKey: "apiKey", organizationId: null);

// AI クライアントで SlidesAIAgent を初期化します。
var aiAgent = new SlidesAIAgent(aiWebClient);

// プレゼンテーションを日本語に翻訳します。
await aiAgent.TranslateAsync(presentation, "japanese");

// 翻訳されたプレゼンテーションを PDF として保存します。
presentation.Save("sample_jp.pdf", SaveFormat.Pdf);
```

デフォルトでは、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) が独自の内部 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンスを作成・管理し、ライフサイクルと破棄を自動的に処理します。ただし、[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) を自分で管理したい場合—たとえば、リソース管理とパフォーマンス向上のために [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) を使用する場合—[OpenAIWebClient](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/openaiwebclient/) の構築時に独自の `HttpClient` インスタンスを提供できます。

```csharp
using System.Net.Http;
using Aspose.Slides.AI;

// 自分で管理する HttpClient を使用します - 例として IHttpClientFactory で作成されたもの
// 依存性注入により注入されます。
HttpClient httpClient = new HttpClient();
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, httpClient);
```

Aspose.Slides は一般的に同期環境で使用されます。このため、[SlidesAIAgent](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/slidesaiagent/) クラスは同期メソッドと非同期メソッドの両方を提供し、アプリケーションのワークフローに最適なアプローチを選択できます。

## **Key Benefits**

Aspose.Slides の [Presentation Translation API](https://reference.aspose.com/slides/ja/net/aspose.slides.ai/) は、AI を活用した多言語 PowerPoint プレゼンテーションの提供ソリューションです。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約しエラーを最小限に抑えます。開発者、教育者、ビジネス専門家のいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大しコミュニケーションを向上させることができます。