---
title: Pythonでプレゼンテーションを作成
linktitle: プレゼンテーションの作成
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
description: "Aspose.Slides for Python を使用して PowerPoint プレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成、OpenDocument のサポートを活用し、プログラムで確実に保存できます。"
---

## **概要**

Aspose.Slides for Python を使用すると、コードだけでまったく新しいプレゼンテーション ファイルを作成できます。この記事では、コア ワークフロー—[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、シンプルなシェイプの挿入、結果の保存—を示し、Microsoft Office がなくてもプレゼンテーションを生成するために必要な設定がいかに少ないかを確認できます。同じ API が PPT、PPTX、ODP ファイルを書き出すため、単一のコードベースから従来の PowerPoint と OpenDocument の両方のフォーマットを対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、最初のスライド デッキが用意されたら、テキスト、画像、チャートなどのリッチ コンテンツを追加するための効率的な出発点を Python アプリケーションに提供します。

## **プレゼンテーションの作成**

Aspose.Slides for Python でゼロから PowerPoint ファイルを作成するのは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化するだけです。コンストラクタは自動的に空白のデッキと 1 枚のスライドを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツのための即座に使用できるキャンバスを得られます。そのスライドを変更するか、あるいは新しいスライドを追加した後、PPTX、従来の PPT、または OpenDocument フォーマットに結果を保存できます。以下の短いコード例は、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. `shapes` コレクションが提供する `add_auto_shape` メソッドを使用し、`CLOUD` タイプの [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトを追加します。  
4. オートシェイプにテキストを追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに雲形シェイプを追加しています。

```py
import aspose.slides as slides

# プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
with slides.Presentation() as presentation:
    # 最初のスライドを取得
    slide = presentation.slides[0]

    # CLOUD タイプのオートシェイプを追加
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # プレゼンテーションを PPTX ファイルとして保存
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![新しいプレゼンテーション](new_presentation.png)

## **よくある質問**

**新しいプレゼンテーションをどのフォーマットで保存できますか？**

[PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、[画像](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的のフォーマットで保存します。POTX/POTM/PPTM などのフォーマットは[サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比をどう制御しますか？**

[スライド サイズ](/slides/ja/python-net/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法）。コンテンツのスケーリング方法も選択できます。

**サイズや座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ポイントに相当します。

**メディア ファイルが多数ある非常に大きなプレゼンテーションのメモリ使用量を抑えるには？**

[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションの作成/保存を並行して行うことはできますか？**

同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを[複数スレッド](/slides/ja/python-net/multithreading/)から操作することはできません。スレッドまたはプロセスごとに分離されたインスタンスを使用してください。

**試用版の透かしと制限を削除するには？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-net/licensing/)してください。ライセンス XML は変更せず、複数スレッドで使用する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付与できますか？**

はい。[デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加と検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ対応ファイルとして保存できます。