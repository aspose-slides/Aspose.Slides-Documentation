---
title: Python でプレゼンテーションを作成する
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/python-net/create-presentation/
keywords:
- プレゼンテーションの作成
- 新しいプレゼンテーション
- PPT の作成
- 新しい PPT
- PPTX の作成
- 新しい PPTX
- ODP の作成
- 新しい ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint プレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して信頼できる結果を得ることができます。"
---

## **概要**

Aspose.Slides for Python を使用すると、コードだけで新しいプレゼンテーション ファイルを作成できます。このガイドでは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、シンプルなシェイプの挿入、結果の保存というコアワークフローを示し、Microsoft Office を使用せずにプレゼンテーションを生成するために必要な設定がほとんどないことが分かります。同じ API で PPT、PPTX、ODP ファイルを書き出せるため、従来の PowerPoint と OpenDocument の両方の形式を単一のコードベースで対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、Python アプリケーションが初期のスライドデッキを作成した後、テキスト、画像、チャートなどのリッチコンテンツを効率的に追加できる出発点を提供します。

## **プレゼンテーションの作成**

Aspose.Slides for Python でゼロから PowerPoint ファイルを作成するのは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化するだけです。コンストラクタは自動的に空のデッキと単一のスライドを用意し、シェイプ、テキスト、チャート、その他必要なコンテンツをすぐに追加できるキャンバスを提供します。そのスライドを変更するか新しいスライドを追加した後、結果を PPTX、従来の PPT、あるいは OpenDocument 形式で保存できます。以下の短いコード例は、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用して、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
1. オートシェイプにテキストを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドにクラウド シェイプが追加されています。
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

## **よくある質問**

**新しいプレゼンテーションをどの形式で保存できますか？**

[PPTX, PPT, and ODP](/slides/ja/python-net/save-presentation/) に保存でき、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、[images](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズやアスペクト比をどう制御しますか？**

[スライドサイズ](/slides/ja/python-net/slide-size/) を設定します（4:3 や 16:9 などのプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットに相当します。

**多数のメディアファイルを含む非常に大きなプレゼンテーションでメモリ使用量を削減するにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を利用し、テンポラリ ファイルを活用してメモリ内ストレージを制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並行して作成/保存できますか？**

同一の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[複数スレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**体験版の透かしと制限を削除するには？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)します。ライセンス XML は変更せず、複数スレッドで使用する場合はライセンス設定を同期させてください。

**作成した PPTX にデジタル署名できますか？**

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。