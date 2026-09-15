---
title: AI搭載 プレゼンテーション翻訳ツール
linktitle: AI搭載翻訳ツール
type: docs
weight: 20
url: /ja/java/ai/translator/
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
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズ—高速で開発者に優しい。ぜひお試しください。"
---
## **はじめに**

Aspose.Slides は、プログラムから PowerPoint プレゼンテーションを管理するための強力な API です。スライドの作成、編集、変換に加えて、プレゼンテーション 翻訳 API などの AI 駆動機能を提供します。

## **動作概要**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部 AI モデルと統合できます。この機能は[SlidesAIAgent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidesaiagent/)クラスを通じて公開されており、[IAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaiwebclient/)インターフェイスの実装を使用して AI サービスと通信します。

組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/)を使用して OpenAI の API に接続するか、別の AI プロバイダーや言語モデルを使用するために独自の[IAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaiwebclient/)を実装できます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" title="Note" %}}
OpenAI API は有料サービスであるため、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/)を使用する際にはアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/)と指定された OpenAI [model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。

```java
import com.aspose.slides.*;

// プレゼンテーションを読み込んで翻訳します。
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

デフォルトでは、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/)は内部の[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)インスタンスを作成・管理し、そのライフサイクルを自動的に処理します。ただし、プロキシの設定や[URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) の使用、またはリソース管理やパフォーマンス向上のために別の[HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) を利用したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。

```java
import com.aspose.slides.*;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.Proxy;
import java.net.URL;

// 自分で HttpURLConnection インスタンスを構成します（カスタムタイムアウト、プロキシ設定など）。
Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress("proxy.example.com", 8080));
HttpURLConnection urlConnection = (HttpURLConnection)new URL("https://api.openai.com/v1/chat/completions").openConnection(proxy);
urlConnection.setConnectTimeout(30000);
urlConnection.setReadTimeout(60000);

OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI の例**

Azure OpenAI デプロイメントを使用するように翻訳者を構成するには、[OpenAICompatibleWebClient](https://reference.aspose.com/slides/ja/java/com.aspose.slides/openaicompatiblewebclient/) を使用します。

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

このスニペットは、Azure OpenAI エンドポイントを使用してプレゼンテーションを翻訳する例です。プレースホルダーの値をデプロイ名、API キー、エンドポイント URL に置き換えてください。

## **主な利点**

Aspose.Slides のプレゼンテーション翻訳 API は、AI を活用した多言語 PowerPoint プレゼンテーション配信ソリューションです。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約しエラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用してグローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大しコミュニケーションを向上させます。