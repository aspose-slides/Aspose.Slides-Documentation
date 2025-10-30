---
title: Pythonでプレゼンテーションを作成する
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/python-net/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPTを作成
- 新しいPPT
- PPTXを作成
- 新しいPPTX
- ODPを作成
- 新しいODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint プレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活かし、プログラムで保存して信頼性の高い結果を得られます。"
---

## **概要**

Aspose.Slides for Python を使用すると、コードだけで全く新しいプレゼンテーション ファイルを作成できます。この記事では、[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、簡単なシェイプの挿入、結果の保存という基本的なワークフローを示し、Microsoft Office がなくてもプレゼンテーションを生成するために必要な設定がいかに少ないかを確認できます。 同じ API で PPT、PPTX、ODP ファイルを書き出せるため、単一のコードベースから従来の PowerPoint と OpenDocument の両形式を対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、初期のスライド デックが用意された後に、テキスト、画像、チャートなどのリッチ コンテンツを追加するための効率的な出発点を Python アプリケーションに提供します。

## **プレゼンテーションの作成**

Aspose.Slides for Python でスクラッチから PowerPoint ファイルを作成する手順は、[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化するだけです。コンストラクタは自動的に空のデッキを 1 枚のスライドで用意し、シェイプ、テキスト、チャート、その他必要なコンテンツのための即座に使えるキャンバスを提供します。そのスライドを変更するか、新しいスライドを追加したら、結果を PPTX、従来の PPT、あるいは OpenDocument 形式で保存できます。以下の短いコード例は、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用して、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
4. オートシェイプにテキストを追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに雲形のシェイプが追加されます。

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

[PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、および[画像](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存できます。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライド サイズ/アスペクト比を制御する方法は？**

[スライド サイズ](/slides/ja/python-net/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法）。コンテンツのスケーリング方法も選択できます。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットに相当します。

**非常に大きなプレゼンテーション（多数のメディア ファイル）でメモリ使用量を削減するには？**

[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、テンポラリ ファイルを活用してインメモリ ストレージを制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並列で作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**試用版の透かしと制限を解除するには？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)してください。ライセンス XML は変更せず、ライセンス設定は複数スレッドが関与する場合は同期させる必要があります。

**作成した PPTX にデジタル署名を付与できますか？**

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加と検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。