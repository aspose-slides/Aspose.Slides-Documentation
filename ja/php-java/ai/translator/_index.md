---
title: AI搭載プレゼンテーション翻訳ツール
linktitle: AI搭載翻訳ツール
type: docs
weight: 20
url: /ja/php-java/ai/translator/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して AI で PowerPoint スライドを翻訳します。レイアウトを保持しながら PPT、PPTX、ODP をローカライズでき、速く開発者に優しいです。ぜひお試しください。"
---

## **Aspose.Slides プレゼンテーション翻訳 API: AI 駆動の多言語スライド翻訳**

Aspose.Slides は、PowerPoint プレゼンテーションをプログラムで操作できる強力な API です。スライドの作成、編集、変換に加えて、プレゼンテーション翻訳 API などの AI 駆動機能を提供し、多言語スライド コンテンツを実現します。

## **仕組み**

Aspose.Slides には組み込みの AI 機能はありませんが、インターネット経由で外部 AI モデルと統合できます。この機能は、AI サービスと通信するための [SlidesAIAgent](https://reference.aspose.com/slides/php-java/aspose.slides/slidesaiagent/) クラスとして公開されています。

OpenAI の API に接続するために、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) を使用できます。

Aspose.Slides は通信を処理し、AI のレスポンスを解析し、元のスライド レイアウトと書式を保持しながら翻訳されたコンテンツをインテリジェントに挿入します。

{{% alert color="primary" %}}
OpenAI API は有料サービスであるため、アカウントを作成し、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) を使用する際に API キーを提供する必要があります。
{{% /alert %}}

## **例**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) と指定した OpenAI の [model](https://platform.openai.com/docs/models) を使用して、PowerPoint プレゼンテーションを日本語に翻訳します。
```php
// 翻訳するプレゼンテーションを読み込む。
$presentation = new Presentation("sample.pptx");

// OpenAIWebClient で AI クライアントを作成し、モデルと API キーを指定します。
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // AI クライアントで SlidesAIAgent を初期化します。
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // プレゼンテーションを日本語に翻訳します。
    $aiAgent->translate($presentation, "japanese");

    // 翻訳されたプレゼンテーションを PDF として保存します。
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```


既定では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) が内部の [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスを作成・管理し、そのライフサイクルを自動的に処理します。ただし、プロキシの設定や [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) の使用、またはリソース管理とパフォーマンス向上のために別の [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) を利用したい場合など、[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/php-java/aspose.slides/openaiwebclient/) の構築時に独自の `HttpURLConnection` インスタンスを提供できます。
```php
// 前もって設定された HttpURLConnection インスタンスがあると想定します（例: カスタムタイムアウトやプロキシ設定など）。
$urlConnection = $yourPreconfiguredConnection;
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```


## **主なメリット**

Aspose.Slides プレゼンテーション翻訳 API は、AI 駆動の多言語 PowerPoint プレゼンテーション配信ソリューションを提供します。レイアウトやデザインを保持しながら翻訳を自動化することで、手作業に比べて時間を節約し、エラーを最小化します。開発者、教育者、ビジネスプロフェッショナルのいずれであっても、この API を利用すれば、グローバルなオーディエンス向けに魅力的でローカライズされたプレゼンテーションを作成でき、リーチの拡大とコミュニケーションの向上が実現します。