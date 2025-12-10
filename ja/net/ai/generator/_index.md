---
title: AI搭載 多言語スライドジェネレーター
linktitle: AI搭載ジェネレーター
type: docs
weight: 40
url: /ja/net/ai/generator/
keywords:
- 多言語プレゼンテーション
- 多言語スライド
- AI プレゼンテーションジェネレーター
- AI スライドジェネレーター
- AI搭載機能
- AI エージェント
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してテキストから多言語スライドを生成します。テンプレートを適用し、洗練されたデッキを PowerPoint と OpenDocument にエクスポートできます。詳細をご覧ください。"
---

## **Aspose.Slides プレゼンテーション AI API: AI 搭載スライドジェネレーター**

Aspose.Slides は新しい AI 搭載機能である Presentation Generator を導入し、開発者がトピックの説明、要約、引用、箇条書きなどのシンプルなテキスト入力から、構造化された PowerPoint プレゼンテーションを自動的に作成できるようにします。

ユーザーはコンテンツの詳細レベルを調整でき、任意でカスタムプレゼンテーションテンプレートを適用してビジュアルデザインを定義できます。

現在、AI Presentation Generator はテキストブロック、箇条書きリスト、テーブルを使用してコンテンツを構成します。画像生成はまだサポートされていませんが、後から Aspose.Slides のツールや手動で画像を簡単に追加できます。

出力はそのまま使用できる完全な PowerPoint プレゼンテーションで、Aspose.Slides API がサポートする任意の形式へエクスポートできます。ジェネレーターは高品質な結果を生成しますが、特定の要件を満たすために軽微な後編集が必要になる場合があります。

## **動作概要**

Aspose.Slides には組み込みの AI モデルは含まれていません。その代わりに、インターネット経由で外部の AI サービスと統合します。この統合は [SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) クラスが処理し、[IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) インターフェイスの実装を使用して AI モデルと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) を使用して OpenAI の API に接続することも、別の AI プロバイダーや言語モデルと連携するために [IAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/iaiwebclient/) のカスタム実装を提供することもできます。Aspose.Slides は AI サービスとのすべての通信を管理し、AI の応答を処理してスライドを生成します。OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) を使用する場合はアカウントと API キーが必要です。

## **コード例**

この例は、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) を使用して Aspose.Slides に関するプレゼンテーションを生成する方法を示しています。

```csharp
// Create an instance of OpenAIWebClient, the built-in implementation of the OpenAI web client.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

// Create an instance of SlidesAIAgent, which provides access to AI-powered features.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Generate a presentation with a medium amount of content based on the instruction.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Medium);

// Save the generated presentation to the local disk as a PowerPoint (.pptx) file.
presentation.Save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
```

### **例 2**

以下の例は、[GeneratePresentation](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/generatepresentation/) メソッドのオーバーロードを示します。このケースでは、外部で管理された [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンスとユーザーの `master presentation` が使用されます。

既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) は独自の内部 [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンスを作成・管理し、ライフサイクルと破棄を自動的に処理します。ただし、リソース管理とパフォーマンス向上のために [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) を使用するなど、[HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/net/aspose.slides.ai/openaiwebclient/) の構築時に独自の [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンスを渡すことができます。

```csharp
// Create an externally managed HttpClient instance.
using var httpClient = new HttpClient();

// Pass the HttpClient to the OpenAIWebClient constructor.
using var aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", httpClient);

// Create an instance of SlidesAIAgent.
var aiAgent = new SlidesAIAgent(aiWebClient);

// Define the instruction for generating the presentation.
var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

// Load a master presentation from the local disk to use as the design template.
using var masterPresentation = new Presentation("masterPresentation.pptx");

// Generate a detailed presentation using the instruction and master template.
using IPresentation presentation = await aiAgent.GeneratePresentationAsync(instruction, PresentationContentAmountType.Detailed, masterPresentation);

// Save the generated presentation as a PDF.
presentation.Save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
```

多くの顧客が Aspose.Slides を同期的なコンテキストで使用していることは注目に値します。これをサポートするために、[SlidesAIAgent](https://reference.aspose.com/slides/net/aspose.slides.ai/slidesaiagent/) クラスは同期メソッドと非同期メソッドの両方を提供し、アプリケーションのワークフローに最適なアプローチを選択できます。

## **主な利点**

Aspose.Slides の新しい AI Presentation Generator は、シンプルなテキストプロンプトから構造化されたスライドデックを高速かつ柔軟に生成する方法を提供します。カスタムテンプレート、外部管理された [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) インスタンス、同期・非同期の両方のワークフローをサポートしているため、さまざまなアプリケーションにシームレスに統合できます。

典型的なユースケースとして、マーケティングプレゼンテーション、教育資料、クライアントレポート、社内スライドデックの作成があります。画像生成はまだサポートされていませんが、ツールはプレゼンテーション作成の自動化に向けた強固な基盤を提供しており、将来的にさらなる機能拡張が期待されています。