---
title: AI搭載 多言語スライドジェネレーター
linktitle: AI搭載 ジェネレーター
type: docs
weight: 40
url: /ja/python-java/ai/generator/
keywords:
- 多言語プレゼンテーション
- 多言語スライド
- AIプレゼンテーションジェネレーター
- AIスライドジェネレーター
- プレゼンテーションテンプレート
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用してテキストから多言語プレゼンテーションを生成します。コンテンツの詳細度を選択し、テンプレートを適用して PowerPoint または PDF にエクスポートできます。"
---
## **はじめに**

Aspose.Slides for Python via Java の AI プレゼンテーション ジェネレーターは、トピックの説明、要約、引用、または箇条書きからプレゼンテーションを作成します。プロンプトで必要な言語を指定し、コンテンツの量を選択し、オプションでレイアウトとデザインを定義するプレゼンテーション テンプレートを提供できます。

ジェネレーターはテキストブロック、箇条書きリスト、テーブルを使用してコンテンツを構造化します。画像は生成しませんので、生成後にプレゼンテーションに追加できます。プレゼンテーションを共有する前に、生成されたコンテンツとレイアウトを確認してください。

## **動作概要**

[SlidesAIAgent](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesaiagent/) は AI クライアントを使用して外部モデルと通信します。以下の例では組み込みの [OpenAIWebClient](https://reference.aspose.com/slides/ja/python-java/aspose.slides/openaiwebclient/) を使用しています。Aspose.Slides はモデルの応答を処理し、編集またはエクスポート可能なプレゼンテーションを構築します。

テキスト説明と [PresentationContentAmountType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationcontentamounttype/) の値を指定して [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesaiagent/#generatePresentation) を使用します。第3引数を使用したオーバーロードでは、デザインテンプレートとして使用するプレゼンテーションを受け取ります。

## **前提条件**

[インストール](/slides/ja/python-java/installation/) を参照して Python、Java、JPype、Aspose.Slides を設定します。サンプルを実行する前に `OPENAI_API_KEY` と `OPENAI_MODEL` 環境変数を設定してください。組み込みクライアントがサポートし、API アカウントで利用可能なモデルを選択します。

{{% alert color="info" title="注" %}}
AI サービスを利用するにはインターネット接続と別途 API アクセスが必要です。プロンプトは設定されたサービスに送信され、その使用料は Aspose.Slides のライセンスとは別に課金されます。
{{% /alert %}}

各例は JVM が未起動の場合にのみ起動し、その後の操作のために JVM を保持します。ノートブック用にコードを適用する際は [JVM ライフサイクル ガイダンス](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) を参照してください。

## **テキストからプレゼンテーションを生成**

この例は、コンテンツ量が [Medium](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationcontentamounttype/#Medium) の英語プレゼンテーションを生成し、PowerPoint ファイルとして保存します。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **テンプレートを使用してプレゼンテーションを生成**

`masterPresentation.pptx` を作業ディレクトリに配置します。この例では [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を使用してロードし、[Detailed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationcontentamounttype/#Detailed) コンテンツのスペイン語プレゼンテーションを生成して PDF にエクスポートします。生成または保存に失敗した場合でも、テンプレートと生成されたプレゼンテーションは解放されます。

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

プロキシや接続タイムアウトを設定する必要がある場合は、[HTTP 接続の構成](/slides/ja/python-java/ai/translator/#configure-the-http-connection) を参照してください。生成器に結果のクライアントを渡すこともできます。

## **主な利点**

生成により、トレーニング資料、製品概要、顧客レポート、社内プレゼンテーションの初期ドラフト作業を削減できます。プロンプトでトピックと言語を指定し、テンプレートを使用して既存のプレゼンテーションデザインを再利用できます。

## **FAQ**

**生成されるプレゼンテーションの長さはどう制御しますか？**

[Brief](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationcontentamounttype/#Brief)、[Medium](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationcontentamounttype/#Medium)、または [Detailed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationcontentamounttype/#Detailed) のいずれかを選択します。これらの設定はスライド数と各スライドの詳細度の両方に影響しますが、正確なスライド数を指定するものではありません。

**別の言語でスライドを生成できますか？**

はい。テキスト説明に希望する言語を含めます。結果は選択したモデルの言語対応能力に依存します。

**PDF にエクスポートする際に編集可能なバージョンを保持できますか？**

はい。生成されたプレゼンテーションを破棄する前に、最初の例と同様の方法で PPTX としても保存してください。