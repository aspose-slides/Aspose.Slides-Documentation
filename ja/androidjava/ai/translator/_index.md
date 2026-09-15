---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/androidjava/ai/translator/
keywords:
- AI プレゼンテーション翻訳ツール
- AI スライド翻訳ツール
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
description: "Java 経由で Android 用 Aspose.Slides を使用し、AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズし、迅速で開発者に優しい体験を提供します。ぜひお試しください。"
---
## **概要**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、プレゼンテーション翻訳 API などの AI 駆動機能も提供し、多言語のスライド コンテンツを実現します。

## **仕組み**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット越しに外部 AI モデルと連携します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidesaiagent/) クラスで公開されており、[IAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaiwebclient/) インターフェイスの実装を使用して AI サービスと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続することも、独自の [IAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaiwebclient/) を実装して別の AI プロバイダーや言語モデルを利用することもできます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライド レイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" title="Note" %}}
OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) を使用する際はアカウントを作成し、API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) と指定した OpenAI の [model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。

```java
import com.aspose.slides.*;

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

既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) が独自の内部 `HttpURLConnection` インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、プロキシの設定や `URLStreamHandlerFactory` の使用、またはリソース管理とパフォーマンス向上のために別の `HttpClient` を利用したい場合など、`HttpURLConnection` を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    // HttpURLConnection インスタンスを自分で構成します（例: カスタムタイムアウトやプロキシ設定など）。
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    // 接続を OpenAIWebClient コンストラクタに渡します。
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI の例**

[OpenAICompatibleWebClient](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/openaicompatiblewebclient/) を使用して、Azure OpenAI デプロイメントを翻訳に利用するよう設定できます。

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

このスニペットは、Azure OpenAI エンドポイントを使用してプレゼンテーションを翻訳する方法を示しています。プレースホルダーの値をご自身のデプロイ名、API キー、エンドポイント URL に置き換えてください。

## **主なメリット**

Aspose.Slides のプレゼンテーション翻訳 API は、AI を活用した多言語 PowerPoint プレゼンテーションの提供を可能にします。レイアウトやデザインを保持したまま翻訳を自動化することで、手作業に比べて時間を節約し、エラーを最小化します。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成し、リーチを拡大し、コミュニケーションを向上させることができます。