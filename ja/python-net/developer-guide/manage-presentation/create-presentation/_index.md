---
title: Pythonでプレゼンテーションを作成する
linktitle: プレゼンテーション作成
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
description: "Aspose.Slidesを使用してPythonでPowerPointプレゼンテーションを作成し、PPT、PPTX、ODPファイルを生成し、OpenDocumentのサポートを活用し、プログラムで保存して信頼できる結果を得られます。"
---

## **概要**

Aspose.Slides for Python を使用すると、コードだけで完全に新しいプレゼンテーション ファイルを作成できます。このドキュメントでは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、シンプルな図形の挿入、結果の保存という基本的なワークフローを示し、Microsoft Office を使用せずにプレゼンテーションを生成するために必要な設定がいかに少ないかが分かります。同じ API で PPT、PPTX、ODP ファイルを書き出せるため、従来の PowerPoint と OpenDocument の両方のフォーマットを単一のコードベースで対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、最初のスライド デッキが用意された後に、テキスト、画像、チャートなどのリッチ コンテンツを追加するための効率的な出発点を Python アプリケーションに提供します。

## **プレゼンテーションの作成**

Aspose.Slides for Python でゼロから PowerPoint ファイルを作成することは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンス化と同じくらい簡単です。コンストラクタは自動的に単一のスライドだけを持つ空のデッキを提供し、図形、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツのための即時キャンバスを提供します。そのスライドを変更するか新しいスライドを追加すれば、結果を PPTX、従来の PPT、あるいは OpenDocument フォーマットに保存できます。以下の短いコードサンプルは、最初のスライドにシンプルな図形を追加することでこのワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用して、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
1. オートシェイプにテキストを追加します。  
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに雲形状が追加されます。
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

**新しいプレゼンテーションを保存できる形式は何ですか？**  
以下のリンク先に保存できます: [PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/)、そして [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、および [画像](/slides/ja/python-net/convert-powerpoint-to-png/) などです。

**テンプレート (POTX/POTM) から開始して通常の PPTX として保存できますか？**  
はい。テンプレートを読み込み、目的の形式で保存します。POTX、POTM、PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比を制御するにはどうすればよいですか？**  
[スライドサイズ](/slides/ja/python-net/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法を含む）ので、コンテンツのスケーリング方法を選択できます。

**サイズや座標の単位は何ですか？**  
ポイント単位です。1 インチは 72 ユニットに相当します。

**メディアファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？**  
[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、テンポラリ ファイルを活用してメモリ内ストレージを制限し、純粋なメモリ ストリームよりもファイルベースのワークフローを優先してください。

**プレゼンテーションを並行して作成/保存できますか？**  
同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[複数スレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**評価版の透かしと制限を削除するには？**  
プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)してください。ライセンス XML は変更せず、複数スレッドを使用する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付与できますか？**  
はい。プレゼンテーション向けの[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加と検証）がサポートされています。

**作成されたプレゼンテーションでマクロ (VBA) はサポートされていますか？**  
はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM や PPSM などのマクロ有効ファイルとして保存できます。