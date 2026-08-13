---
title: AI搭載プレゼンテーション翻訳ツール
linktitle: AI搭載翻訳ツール
type: docs
weight: 20
url: /ja/androidjava/ai/translator/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズ—高速かつ開発者フレンドリーです。ぜひお試しください。"
---
## **はじめに**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、AI 駆動の機能も提供しており、たとえば多言語スライドコンテンツ用の Presentation Translation API があります。

## **仕組み**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部の AI モデルと統合します。この機能は、[SlidesAIAgent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesaiagent/) クラスを通じて提供され、[IAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続することも、別の AI プロバイダーや言語モデルを使用するために独自の[IAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaiwebclient/) を実装することもできます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" %}}
OpenAI API は有料サービスであるため、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) と指定した OpenAI の[model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。

```java
import com.aspose.slides.*;

// プレゼンテーションを読み込み、翻訳します。
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

既定では、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) は独自の内部[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、プロキシなどの必須設定を構成したり、[URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) や別の[HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) を使用してリソース管理やパフォーマンスを向上させたりするために、[HttpURLConnection] を自分で管理したい場合は、[OpenAIWebClient] の構築時に独自の `HttpURLConnection` インスタンスを提供できます。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // HttpURLConnection インスタンスを自分で設定します（例：カスタムタイムアウト、プロキシ設定など）。
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // 接続を OpenAIWebClient コンストラクタに渡します。
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

## **主なメリット**

Aspose.Slides Presentation Translation API は、マルチ言語の PowerPoint プレゼンテーションを提供するための AI 駆動ソリューションです。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業のワークフローに比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを向上させることができます。