---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を Java で使用し、AI で PowerPoint スライドを翻訳します。レイアウトを保持したまま PPT、PPTX、ODP をローカライズし、高速で開発者に優しいです。ぜひお試しください。"
---

## **Aspose.Slides プレゼンテーション翻訳 API: AI 搭載の多言語スライド翻訳**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムから管理できる強力な API です。スライドの作成、編集、変換に加えて、プレゼンテーション翻訳 API などの AI 駆動機能を提供し、多言語スライドコンテンツを実現します。

## **動作概要**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部 AI モデルと統合します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesaiagent/) クラスを通じて提供され、[IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続することも、別の AI プロバイダーや言語モデルを使用するために独自の [IAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaiwebclient/) を実装することもできます。

Aspose.Slides が通信を処理し、AI 応答を解析し、元のスライドレイアウトと書式設定を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="primary" %}}
OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) と指定された OpenAI [model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。
```java
// 翻訳するプレゼンテーションをロードします。
Presentation presentation = new Presentation("sample.pptx");

// モデルと API キーを指定して OpenAIWebClient で AI クライアントを作成します。
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


既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) が独自の内部 `HttpURLConnection` インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、プロキシの設定や `URLStreamHandlerFactory` の使用、またはリソース管理とパフォーマンス向上のために別の `HttpClient` を利用したい場合など、`HttpURLConnection` を自前で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。
```java
// 事前に設定された HttpURLConnection インスタンスがあると想定します（例: カスタムタイムアウトやプロキシ設定など）。
HttpURLConnection urlConnection = yourPreconfiguredConnection;
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```


## **主なメリット**

Aspose.Slides プレゼンテーション翻訳 API は、AI 駆動のソリューションを提供し、多言語 PowerPoint プレゼンテーションを実現します。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを向上させることができます。