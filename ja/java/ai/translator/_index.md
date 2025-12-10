---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/java/ai/translator/
keywords:
- AI プレゼンテーション翻訳
- AI スライド翻訳
- AI 搭載機能
- 多言語プレゼンテーション
- 多言語スライド
- プレゼンテーション翻訳
- スライド翻訳
- AI 主導機能
- AI 機能
- AI エージェント
- Web クライアント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して AI で PowerPoint スライドを翻訳します。レイアウトを維持しながら PPT、PPTX、ODP をローカライズ—高速で開発者に優しいです。ぜひお試しください。"
---

## **Aspose.Slides プレゼンテーション翻訳 API: AI 駆動の多言語スライド翻訳**

Aspose.Slides は、プログラムで PowerPoint プレゼンテーションを管理するための強力な API です。スライドの作成、編集、変換に加えて、AI 駆動の機能も提供しており、たとえば多言語スライド コンテンツ用の Presentation Translation API などがあります。

## **動作概要**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部の AI モデルと統合します。この機能は[SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/)クラスを介して提供され、[IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/)インターフェイスの実装を使用して AI サービスと通信します。

組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/)を使用して OpenAI の API に接続することも、独自の[IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/)を実装して別の AI プロバイダーや言語モデルを利用することもできます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="primary" %}}
OpenAI API は有料サービスであることに注意してください。そのため、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/)を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、指定した OpenAI の[model](https://platform.openai.com/docs/models)を使用して、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/)で PowerPoint プレゼンテーションを日本語に翻訳します。
```java
// 翻訳するためにプレゼンテーションを読み込む。
Presentation presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI クライアントで SlidesAIAgent を初期化する。
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // プレゼンテーションを日本語に翻訳する。
    aiAgent.translate(presentation, "japanese");

    // 翻訳されたプレゼンテーションを PDF として保存する。
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```


既定では、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/)は独自の内部[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)インスタンスを作成・管理し、そのライフサイクルを自動的に処理します。ただし、プロキシなどの重要な設定を構成したり、[URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html)やリソース管理とパフォーマンス向上のために別の[HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html)を使用したりするなど、[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/)を構築するときに独自の `HttpURLConnection` インスタンスを渡すことができます。
```java
// 事前に設定された HttpURLConnection インスタンスがあると仮定します（例: カスタムタイムアウトやプロキシ設定など）。
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **主なメリット**

Aspose.Slides Presentation Translation API は、多言語 PowerPoint プレゼンテーションを提供するための AI 駆動ソリューションです。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業のワークフローに比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを向上させることができます。