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
description: "Aspose.Slides を使用して Python で PowerPoint プレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用してプログラムで保存し、信頼できる結果を得ることができます。"
---

## **概要**

Aspose.Slides for Python を使用すると、コードだけで全く新しいプレゼンテーション ファイルを作成できます。この記事では、[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、簡単なシェイプの挿入、結果の保存という基本的なワークフローを示し、Microsoft Office を使用せずにプレゼンテーションを生成するために必要なセットアップがいかに少ないかを確認できます。同じ API が PPT、PPTX、ODP ファイルを書き込めるため、単一のコードベースから従来の PowerPoint フォーマットと OpenDocument フォーマットの両方を対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、最初のスライド デッキが用意された後に、テキスト、画像、チャートなどのリッチ コンテンツを追加するための効率的な出発点を Python アプリケーションに提供します。

## **プレゼンテーションの作成**

Aspose.Slides for Python で最初から PowerPoint ファイルを作成するのは、[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化するだけです。コンストラクタは自動的に 1 つのスライドが含まれる空白のデッキを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツ用のキャンバスがすぐに得られます。そのスライドを変更するか新しいスライドを追加した後、PPTX、従来の PPT、あるいは OpenDocument フォーマットに結果を保存できます。以下の短いコード例は、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用して、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
4. オートシェイプにテキストを追加します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに雲形シェイプが追加されています。
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

**新しいプレゼンテーションをどの形式で保存できますか？**

[PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、および[画像](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート（POTX/POTM）から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、希望の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比をどのように制御しますか？**

[スライドサイズ](/slides/ja/python-net/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法を含む）。コンテンツのスケーリング方法も選択できます。

**サイズや座標の単位は何ですか？**

ポイントです。1 インチは 72 ユニットに相当します。

**メディアファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を削減するにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、テンポラリ ファイルを活用してインメモリ ストレージを制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションの作成/保存を並列に実行できますか？**

同じ [プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに分離されたインスタンスを実行してください。

**評価版の透かしと制限を削除するにはどうすればよいですか？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)します。ライセンス XML は変更せず、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付けられますか？**

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ（VBA）はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。