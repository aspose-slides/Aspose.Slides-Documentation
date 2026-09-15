---
title: AI 搭載 プレゼンテーション翻訳ツール
linktitle: AI 搭載 翻訳ツール
type: docs
weight: 20
url: /ja/nodejs-java/ai/translator/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズ—高速で開発者に優しいです。ぜひお試しください。"
---
## **導入**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、プレゼンテーション翻訳 API などの AI 駆動機能を提供し、多言語スライド コンテンツを実現します。

## **仕組み**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部 AI モデルと統合します。この機能は[SlidesAIAgent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesaiagent/)クラスを介して提供され、AI サービスとの通信を行います。

組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/openaiwebclient/)を使用して OpenAI の API に接続できます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" title="注意" %}}

OpenAI API は有料サービスであるため、アカウントを作成し、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/openaiwebclient/)を使用する際に API キーを提供する必要があります。

{{% /alert %}}

## **例**

この例では、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/openaiwebclient/)と指定した OpenAI [model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 翻訳するプレゼンテーションをロードします。
let presentation = new aspose.slides.Presentation("sample.pptx");

// OpenAIWebClient を使用して AI クライアントを作成し、モデルと API キーを指定します。
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI クライアントで SlidesAIAgent を初期化します。
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // プレゼンテーションを日本語に翻訳します。
    aiAgent.translate(presentation, "japanese");

    // 翻訳されたプレゼンテーションを PDF として保存します。
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

デフォルトでは、組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/openaiwebclient/)が独自の内部[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、プロキシ設定などの必須設定を構成したり、[URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html)や別の[HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html)を使用してリソース管理やパフォーマンスを向上させたりするために、[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/openaiwebclient/)の構築時に独自の`HttpURLConnection`インスタンスを提供できます。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Create and pre-configure an HttpURLConnection instance (e.g., with custom timeouts, proxy settings, etc.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI の例**

[OpenAICompatibleWebClient](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/openaicompatiblewebclient/)を使用して、Azure OpenAI デプロイメントを利用するよう翻訳機能を構成できます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

このスニペットは、Azure OpenAI エンドポイントを使用してプレゼンテーションを翻訳する方法を示しています。プレースホルダーの値をデプロイメント名、API キー、エンドポイント URL に置き換えてください。

## **主なメリット**

Aspose.Slides のプレゼンテーション翻訳 API は、AI を活用した多言語 PowerPoint プレゼンテーションの提供ソリューションです。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約し、エラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチを拡大し、コミュニケーションを向上させることができます。