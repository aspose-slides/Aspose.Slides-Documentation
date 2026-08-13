---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/java/ai/translator/
keywords:
- AI プレゼンテーション翻訳ツール
- AI スライド翻訳ツール
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持したまま PPT、PPTX、ODP をローカライズし、高速で開発者に優しいです。ぜひお試しください。"
---
## **はじめに**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで操作するための強力な API です。スライドの作成、編集、変換に加えて、プレゼンテーション翻訳 API のような AI 駆動機能を提供し、多言語スライドコンテンツを実現します。

## **仕組み**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部 AI モデルと統合できます。この機能は、[SlidesAIAgent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesaiagent/) クラスを通じて提供され、[IAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続するか、別の AI プロバイダーや言語モデルを使用するために独自の[IAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaiwebclient/) を実装できます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" %}}
OpenAI API は有料サービスであるため、アカウントを作成し、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/) を使用する際に API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/) と指定した OpenAI の[model](https://platform.openai.com/docs/models) を使用して PowerPoint プレゼンテーションを日本語に翻訳します。

```java
import com.aspose.slides.*;

// プレゼンテーションを読み込み、翻訳します。
Presentation presentation = new Presentation("sample.pptx");

// OpenAIWebClient で AI クライアントを作成し、モデルと API キーを指定します。
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

デフォルトでは、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/) が独自の内部 `HttpURLConnection` インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、プロキシの設定や `URLStreamHandlerFactory` の使用、リソース管理とパフォーマンス向上のために別の `HttpClient` を使用したい場合など、`HttpURLConnection` を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// HttpURLConnection インスタンスを自分で構成します（カスタムタイムアウト、プロキシ設定など）。
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

## **主なメリット**

Aspose.Slides プレゼンテーション翻訳 API は、AI 駆動のソリューションを提供し、多言語 PowerPoint プレゼンテーションの配信を可能にします。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約しエラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大しコミュニケーションを向上させることができます。