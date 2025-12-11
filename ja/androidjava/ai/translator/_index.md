---
title: AI搭載プレゼンテーション翻訳ツール
linktitle: AI搭載翻訳ツール
type: docs
weight: 20
url: /ja/androidjava/ai/translator/
keywords:
- AIプレゼンテーション翻訳
- AIスライド翻訳
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
- Android
- Java
- Aspose.Slides
description: "AIを使用して、Aspose.Slides for Android（Java）でPowerPointスライドを翻訳します。レイアウトを保持したままPPT、PPTX、ODPをローカライズでき、迅速かつ開発者に優しいです。ぜひお試しください。"
---

## **Aspose.Slides プレゼンテーション翻訳 API: AI 駆動の多言語スライド翻訳**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、AI 駆動の機能も提供します。たとえば、多言語スライド コンテンツ用の Presentation Translation API などです。

## **動作方法**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット上の外部 AI モデルと統合します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) クラスを通じて提供され、[IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続することも、別の AI プロバイダーや言語モデルを使用するために独自の [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) を実装することもできます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="primary" %}}
OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、指定した OpenAI の [model](https://platform.openai.com/docs/models) を使用して、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) で PowerPoint プレゼンテーションを日本語に翻訳します。
```java
// 翻訳するプレゼンテーションを読み込む。
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient を使用して AI クライアントを作成し、モデルと API キーを指定します。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI クライアントで SlidesAIAgent を初期化します。
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // プレゼンテーションを日本語に翻訳します。
    aiAgent.translate(presentation, "japanese");

    // 翻訳されたプレゼンテーションを PDF として保存します。
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


デフォルトでは、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) は独自の内部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、プロキシなどの重要な設定を構成したり、[URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) や別の [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) を使用してリソース管理やパフォーマンスを向上させるために、[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。
```java
// 事前に構成された HttpURLConnection インスタンスがあると仮定します（例: カスタムタイムアウトやプロキシ設定など）。
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **主なメリット**

Aspose.Slides Presentation Translation API は、AI 駆動の多言語 PowerPoint プレゼンテーション配信ソリューションを提供します。レイアウトとデザインを保持しながら翻訳を自動化することで、手動のワークフローに比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルな観客向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを向上させることができます。