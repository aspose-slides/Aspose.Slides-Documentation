---
title: AI搭載プレゼンテーション翻訳ツール
linktitle: AI搭載翻訳ツール
type: docs
weight: 20
url: /ja/python-java/ai/translator/
keywords:
- AIプレゼンテーション翻訳
- AIスライド翻訳
- 多言語プレゼンテーション
- プレゼンテーション翻訳
- スライド翻訳
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して AI でプレゼンテーションを翻訳します。スライドのテキストをローカライズし、翻訳されたプレゼンテーションを PowerPoint または PDF として保存します。"
---
## **はじめに**

Aspose.Slides for Python via Java は、スライド コンテンツのローカライズ用 AI プレゼンテーション翻訳 API を提供します。既存のプレゼンテーションを指定した言語に翻訳し、対象のオーディエンスが必要とする形式で翻訳版を保存します。

## **仕組み**

[SlidesAIAgent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesaiagent/) は、AI クライアントを介して外部 AI サービスと通信します。例では組み込みの[OpenAIWebClient](https://reference.aspose.com/slides/ja/python-java/aspose.slides/openaiwebclient/) を使用しています。

[SlidesAIAgent.translate](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesaiagent/#translate) は、渡されたプレゼンテーションを更新します。Aspose.Slides は AI の応答を処理し、既存のレイアウトと書式設定を保持しながらスライドのテキストを置き換えます。結果を確認してください。翻訳されたテキストは元のテキストより長くなることがあり、レイアウト調整が必要になる場合があります。

## **前提条件**

[Installation](/slides/ja/python-java/installation/) に従ってライブラリとランタイムを構成します。サンプルを実行する前に `OPENAI_API_KEY` と `OPENAI_MODEL` 環境変数を設定してください。組み込みクライアントがサポートし、API アカウントで利用可能なモデルを選択します。

{{% alert color="info" title="Note" %}}
翻訳にはインターネット接続が必要で、プレゼンテーションのテキストは設定された AI サービスに送信されます。API のアクセスおよび使用料は Aspose.Slides のライセンスとは別途請求されます。
{{% /alert %}}

サンプルはアクティブな JVM を再利用するか、必要に応じて起動します。ノートブックでの使用方法は [JVM lifecycle guidance](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) を参照してください。

## **プレゼンテーションの翻訳**

作業ディレクトリに `sample.pptx` を配置します。この例は [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) でファイルを読み込み、テキストを日本語に翻訳し、結果を PDF として保存します。操作が失敗した場合でもプレゼンテーションを解放し、AI クライアントを閉じます。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **HTTP 接続の構成**

デフォルトでは、[OpenAIWebClient](https://reference.aspose.com/slides/ja/python-java/aspose.slides/openaiwebclient/) が HTTP 接続を内部で管理します。この 4 引数コンストラクタは、外部で管理された Java の [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) も受け取れます。プロキシや接続タイムアウトを構成する必要がある場合にこのオーバーロードを使用してください。

次の例は [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) を使用して Java HTTP プロキシを作成し、[URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) で接続を開きます。`proxy.example.com` とポート番号をプロキシ設定に置き換えてください。接続は JPype を介して直接渡され、Python の HTTP セッションは使用できません。

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **主な利点**

自動翻訳により、既存のスライド デザインを再利用しながら、多言語のトレーニング資料、製品プレゼンテーション、クライアント向けレポートを簡単に作成できます。編集可能なプレゼンテーションを保存してレビューを続行するか、配布用に PDF としてエクスポートできます。

## **よくある質問**

**翻訳は別のプレゼンテーション オブジェクトを作成しますか？**

いいえ。[SlidesAIAgent.translate](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesaiagent/#translate) は提供されたプレゼンテーションを直接変更します。元のファイルを保持したい場合は、新しいファイル名で保存してください。

**対象言語はどのように指定しますか？**

第二引数に言語名（例: `"Japanese"` や `"Spanish"`）を渡します。翻訳品質と対応言語は選択したモデルに依存します。

**プロキシを使用せずに翻訳できますか？**

はい。最初の例にある 3 引数クライアント コンストラクタを使用してください。カスタム接続の例は、アプリケーションで明示的な接続設定が必要な場合にのみ必要です。