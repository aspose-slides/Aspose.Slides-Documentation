---
title: Python でプレゼンテーションを作成
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /ja/python-net/create-presentation/
keywords:
- プレゼンテーション作成
- 新しいプレゼンテーション
- PPT 作成
- 新しい PPT
- PPTX 作成
- 新しい PPTX
- ODP 作成
- 新しい ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して PowerPoint プレゼンテーションを作成—PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで確実に保存できます。"
---

## **概要**

Aspose.Slides for Python を使用すると、コードだけで全く新しいプレゼンテーション ファイルを作成できます。本記事では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、シンプルなシェイプの挿入、結果の保存という基本的なワークフローを示し、Microsoft Office がなくてもプレゼンテーションを生成するために必要なセットアップがいかに少ないかを確認できます。同じ API が PPT、PPTX、ODP ファイルを書き出すため、単一のコードベースで従来の PowerPoint と OpenDocument の両方の形式を対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、最初のスライド デックが用意できたら、テキスト、画像、チャートなどのリッチ コンテンツを追加するための効率的な出発点となります。

## **プレゼンテーションの作成**

Aspose.Slides for Python で最初から PowerPoint ファイルを作成するのは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化するだけです。コンストラクタは自動的に 1 枚のスライドを持つ空のデックを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツのためのキャンバスをすぐに利用できます。そのスライドを変更したり新しいスライドを追加したりした後、PPTX、従来の PPT、あるいは OpenDocument 形式で結果を保存できます。以下の短いコード例は、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用して、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
4. オートシェイプにテキストを追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに雲形のシェイプが追加されています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
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

**新しいプレゼンテーションを保存できる形式は何ですか？**

[PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、および [画像](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズやアスペクト比を制御するには？**

[スライドサイズ](/slides/ja/python-net/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ポイントに相当します。

**メディアファイルが多数ある大規模なプレゼンテーションでメモリ使用量を減らすには？**

[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、テンポラリ ファイルを活用してインメモリ保存を制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並列で作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[複数スレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに分離されたインスタンスを実行してください。

**評価版の透かしと制限を削除するには？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)します。ライセンス XML は変更せず、複数スレッドで使用する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名できますか？**

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。