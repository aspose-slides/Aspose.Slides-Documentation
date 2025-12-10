---
title: AI搭載多言語スライドジェネレーター
linktitle: AI搭載ジェネレーター
type: docs
weight: 40
url: /ja/java/ai/generator/
keywords:
- 多言語プレゼンテーション
- 多言語スライド
- AIプレゼンテーションジェネレーター
- AIスライドジェネレーター
- AI搭載機能
- AIエージェント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してテキストから多言語スライドを生成します。テンプレートを適用し、洗練されたデッキを PowerPoint および OpenDocument にエクスポートできます。詳しくはこちら。"
---

## **Aspose.Slides プレゼンテーション AI API: AI 搭載スライドジェネレーター**

Aspose.Slides は新しい AI 搭載機能「Presentation Generator」を導入し、開発者がトピックの説明、要約、引用、箇条書きなどの簡単なテキスト入力から自動的に構造化された PowerPoint プレゼンテーションを作成できるようにします。

ユーザーはコンテンツの詳細レベルを調整でき、必要に応じてカスタム プレゼンテーション テンプレートを適用してビジュアル デザインを定義できます。

現在、AI Presentation Generator はテキストブロック、箇条書きリスト、テーブルを使用してコンテンツを構成します。画像生成はまだサポートされていませんが、画像は Aspose.Slides ツールや手動で後から簡単に追加できます。

出力は完全な PowerPoint プレゼンテーションで、そのまま使用するか、Aspose.Slides API がサポートする任意のフォーマットにエクスポートできます。ジェネレーターは高品質な結果を生成しますが、特定の要件を満たすために軽微な後編集が必要になる場合があります。

## **動作概要**

Aspose.Slides には組み込みの AI モデルは含まれておらず、代わりにインターネット経由で外部 AI サービスと統合します。この統合は [SlidesAIAgent](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/) クラスが処理し、[IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) インターフェイスの実装を使用して AI モデルと通信します。

組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) を使用して OpenAI の API に接続するか、別の AI プロバイダーや言語モデルと連携するために [IAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/iaiwebclient/) のカスタム実装を提供できます。Aspose.Slides は AI サービスとのすべての通信を管理し、AI の応答を処理してスライドを生成します。OpenAI API は有料サービスであるため、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) を使用する際にはアカウントと API キーが必要です。

## **コードを書いてみよう**

### **例 1**

この例では、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) を使用して Aspose.Slides をテーマとしたプレゼンテーションを生成する方法を示します。
```java
// OpenAIWebClient のインスタンスを作成します。これは OpenAI Web クライアントの組み込み実装です。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // SlidesAIAgent のインスタンスを作成し、AI 搭載機能にアクセスできるようにします。
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // プレゼンテーション生成のための指示を定義します。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // 指示に基づき、中程度のコンテンツ量でプレゼンテーションを生成します。
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // 生成されたプレゼンテーションをローカルディスクに PowerPoint（.pptx）ファイルとして保存します。
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


### **例 2**

以下の例では、[generatePresentation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) メソッドのオーバーロードを示します。このケースでは、外部で管理された [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスとユーザーの `master presentation` が使用されます。

デフォルトでは、組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) が独自の内部 [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスを作成・管理し、ライフサイクルを自動的に処理します。ただし、[URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) や [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) を使用してリソース管理やパフォーマンスを向上させる場合など、[HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) を自分で管理したい場合は、[OpenAIWebClient](https://reference.aspose.com/slides/java/com.aspose.slides/openaiwebclient/) を構築する際に独自の [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスを提供できます。
```java
// HttpURLConnection を OpenAIWebClient のコンストラクタに渡します。
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // SlidesAIAgent のインスタンスを作成します。
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // プレゼンテーション生成のための指示を定義します。
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // デザインテンプレートとして使用するために、ローカルディスクからマスタープレゼンテーションをロードします。
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // 指示とマスターテンプレートを使用して詳細なプレゼンテーションを生成します。
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // 生成されたプレゼンテーションを PDF として保存します。
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```


## **主なメリット**

Aspose.Slides の新しい AI Presentation Generator は、シンプルなテキストプロンプトから構造化されたスライドデッキを迅速かつ柔軟に作成する方法を提供します。カスタムテンプレートと外部で管理された [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) インスタンスをサポートしているため、さまざまなアプリケーションにシームレスに統合できます。

典型的なユースケースとしては、マーケティングプレゼンテーション、教育資料、クライアント向けレポート、社内スライドデッキの作成があります。画像生成はまだサポートされていませんが、ツールはプレゼンテーション作成の自動化に向けた強固な基盤を提供しており、将来的にさらなる機能拡張が期待されています。