---
title: Pythonでプレゼンテーションを作成
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/python-net/create-presentation/
keywords:
- プレゼンテーション作成
- 新しいプレゼンテーション
- PPT作成
- 新しいPPT
- PPTX作成
- 新しいPPTX
- ODP作成
- 新しいODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slidesを使用してPythonでPowerPointプレゼンテーションを作成し、PPT、PPTX、ODPファイルを生成し、OpenDocumentのサポートを活用し、プログラムで保存して信頼性の高い結果を得ることができます。"
---

## **概要**

Aspose.Slides for Python を使用すると、完全にコードだけで新しいプレゼンテーション ファイルを作成できます。この記事では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、シンプルな図形の挿入、結果の保存というコア ワークフローを示し、Microsoft Office を使用せずにプレゼンテーションを生成するために必要な設定がいかに少ないかをご確認いただけます。 同じ API が PPT、PPTX、ODP ファイルを書き込むため、単一のコードベースから従来の PowerPoint と OpenDocument の両方の形式を対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、Python アプリケーションに対して、最初のスライド デッキが用意された後にテキスト、画像、チャートなどのリッチ コンテンツを追加するための効率的な出発点を提供します。

## **プレゼンテーションの作成**

Aspose.Slides for Python でゼロから PowerPoint ファイルを作成するのは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンス化と同じくらい直接的です。 コンストラクタは自動的に単一のスライドを含む空のデッキを提供し、形状、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツのための即時キャンバスを提供します。そのスライドを変更するか、あるいは新しいスライドを追加した後、結果を PPTX、従来の PPT、または OpenDocument 形式に保存できます。以下の短いコードサンプルは、最初のスライドにシンプルな図形を追加することでこのワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用して、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。
1. オートシェイプにテキストを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにクラウド形状が追加されます。
```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # CLOUD タイプのオートシェイプを追加します。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![新しいプレゼンテーション](new_presentation.png)

## **FAQ**

**新しいプレゼンテーションを保存できる形式は何ですか？**

以下のリンク先の [PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、また [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、[画像](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比を制御するには？**

スライド サイズを[slide size](/slides/ja/python-net/slide-size/)で設定します（4:3 や 16:9 などのプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法を選択できます。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットです。

**メディア ファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を減らすにはどうすればよいですか？**

BLOB 管理戦略を[使用](/slides/ja/python-net/manage-blob/)し、一時ファイルを活用してメモリ内保存を制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先してください。

**プレゼンテーションを並列で作成/保存できますか？**

同一の[Presentation]インスタンスに対して[複数のスレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに別々の、独立したインスタンスを実行してください。

**試用版の透かしや制限を削除するには？**

プロセスごとに[ライセンスを適用](/slides/ja/python-net/licensing/)してください。ライセンス XML は変更せずに保持し、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付けられますか？**

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

**作成されたプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。