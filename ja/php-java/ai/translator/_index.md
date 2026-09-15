---
title: AI 搭載プレゼンテーション翻訳ツール
linktitle: AI 搭載翻訳ツール
type: docs
weight: 20
url: /ja/php-java/ai/translator/
keywords:
- AI プレゼンテーション翻訳ツール
- AI スライド翻訳ツール
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズ—高速で開発者に優しい。ぜひお試しください。"
---
## **はじめに**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで管理するための強力な API です。スライドの作成、編集、変換に加えて、AI 主導の機能も提供します。たとえば、マルチ言語スライドコンテンツ向けの Presentation Translation API などです。

## **仕組み**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部の AI モデルと連携します。この機能は [SlidesAIAgent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidesaiagent/) クラスを通じて AI サービスと通信するために公開されています。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続できます。

Aspose.Slides は通信を処理し、AI の応答を解析し、元のスライドのレイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="info" title="Note" %}}
OpenAI API は有料サービスです。そのため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/openaiwebclient/) を使用する際は、アカウントを作成し API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/openaiwebclient/) と指定した OpenAI の [model](https://platform.openai.com/docs/models) を使用して PowerPoint プレゼンテーションを日本語に翻訳します。

```php
// 翻訳するプレゼンテーションを読み込む。
$presentation = new Presentation("sample.pptx");

// OpenAIWebClient を使用して AI クライアントを作成し、モデルと API キーを指定する。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI クライアントで SlidesAIAgent を初期化する。
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // プレゼンテーションを日本語に翻訳する。
    $aiAgent->translate($presentation, "japanese");

    // 翻訳されたプレゼンテーションを PDF として保存する。
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/openaiwebclient/) が独自の内部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスを作成および管理し、ライフサイクルを自動的に処理します。ただし、プロキシの設定や [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) の使用、あるいはリソース管理とパフォーマンス向上のために別の [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) を利用したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。

```php
// 独自の HttpURLConnection インスタンスを作成し、事前設定する（カスタムタイムアウト、プロキシ設定など）。
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// 接続を AI クライアントに渡す。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI の例**

[OpenAICompatibleWebClient](https://reference.aspose.com/slides/ja/php-java/aspose.slides/openaicompatiblewebclient/) を使用して、Azure OpenAI デプロイメントを利用するように翻訳機能を構成できます。

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

このスニペットは、Azure OpenAI エンドポイントを使用してプレゼンテーションを翻訳する方法を示しています。プレースホルダーの値をデプロイメント名、API キー、エンドポイント URL に置き換えてください。

## **主な利点**

Aspose.Slides Presentation Translation API は、AI によるマルチ言語 PowerPoint プレゼンテーションの提供を可能にするソリューションです。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を短縮しエラーを最小限に抑えます。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を使用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチの拡大とコミュニケーションの向上につながります。