---
title: Pythonでプレゼンテーションを作成
linktitle: プレゼンテーション作成
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
description: "Aspose.Slides を使用して Python で PowerPoint プレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用して、プログラムで信頼性の高い結果として保存します。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用してプレゼンテーションを作成し、最初のスライドにテキスト付きのシェイプを追加し、その結果を PPTX ファイルとして保存する方法を示します。同じ API を使用すればプレゼンテーションを PPT および ODP 形式でも保存できるため、Microsoft Office が不要な状態で PowerPoint と OpenDocument の両方のフォーマットを同一コードベースから対象にできます。最後に掲載した短い FAQ では、フォーマット、テンプレート、スライドサイズ、単位、メモリ使用量、スレッド処理、ライセンス、デジタル署名、VBA のサポートに関する一般的な質問に答えています。

始める前に、`pip install aspose.slides` で PyPI からパッケージをインストールしてください。Linux と macOS に必要なライブラリ、および Debian と Ubuntu のシステム Python が必要とする仮想環境については、[インストール](/slides/ja/python-net/installation/) を参照してください。

## **プレゼンテーションの作成**

プレゼンテーションを作成し、最初のスライドにテキスト付きのシェイプを配置する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。新しいプレゼンテーションには空のスライドが 1 枚既に含まれています。  
2. そのスライドを、インデックス 0 で [slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slides/ja/) コレクションから取得します。  
3. スライドの [shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/shapes/) コレクションの [add_auto_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_auto_shape/) メソッドを使って、雲形の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) を追加し、その [text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/text/) を設定します。  
4. [save](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/save/) メソッドでプレゼンテーションを PPTX ファイルとして保存します。

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

雲の左上隅はスライドの左端から 20 ポイント、上端から 20 ポイントの位置にあり、幅が 200 ポイント、高さが 80 ポイントです。`with` ステートメントはブロックが終了したときにプレゼンテーションのリソースを解放します。スクリプトは現在のフォルダーに *new_presentation.pptx* を保存し、雲とテキストを保持したスライドが 1 枚含まれます。ライセンスが無い場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしを追加します。詳細は[ライセンス](/slides/ja/python-net/licensing/)をご覧ください。

結果:

![新しいプレゼンテーション](new_presentation.png)

## **FAQ**

### 新しいプレゼンテーションはどのフォーマットで保存できますか？

[PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、さらに [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/)、画像形式 [PNG](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

### テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-net/supported-file-formats/)。

### プレゼンテーション作成時にスライドサイズやアスペクト比を制御する方法は？

[スライドサイズ](/slides/ja/python-net/slide-size/) を設定します（4:3 や 16:9 などのプリセット、あるいはカスタム寸法）。コンテンツのスケーリング方法も選択できます。

### サイズや座標はどの単位で測定されていますか？

ポイント単位です。1 インチは 72 ポイントに相当します。

### 大容量のプレゼンテーション（多数のメディアファイルを含む）でメモリ使用量を減らすには？

[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、一時ファイルを活用してインメモリ保存を制限します。純粋なインメモリストリームよりもファイルベースのワークフローを優先してください。

### プレゼンテーションの作成/保存を並列で行うことはできますか？

同一の [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに分離されたインスタンスを実行してください。

### 評価用透かしや制限を削除するには？

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)します。ライセンス XML は変更せず、複数スレッドで使用する場合はライセンス設定を同期させる必要があります。

### 作成した PPTX にデジタル署名を付けることはできますか？

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

### 作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。