---
title: Pythonでプレゼンテーションを作成する
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/python-net/create-presentation/
keywords:
- プレゼンテーション作成
- 新規プレゼンテーション
- PPT作成
- 新規PPT
- PPTX作成
- 新規PPTX
- ODP作成
- 新規ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slidesを使用してPythonでPowerPointプレゼンテーションを作成し、PPT、PPTX、ODPファイルを生成し、OpenDocumentのサポートを活用し、プログラムで保存して確実な結果を得られます。"
---

## **概要**

Aspose.Slides for Python を使用すると、完全にコードだけで新しいプレゼンテーションファイルを作成できます。この記事では、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの作成、最初のスライドの取得、シンプルなシェイプの挿入、そして結果の保存というコアワークフローを示します。Microsoft Office を使用せずにプレゼンテーションを生成するために必要な設定がいかに少ないかをご確認ください。同じ API で PPT、PPTX、ODP ファイルを書き込めるため、従来の PowerPoint と OpenDocument の両方の形式を単一のコードベースで対象にできます。Aspose.Slides はデスクトップ、Web、サーバー環境に適しており、最初のスライドデッキが用意された後に、テキスト、画像、チャートなどのリッチコンテンツを追加するための効率的な出発点を Python アプリケーションに提供します。

## **プレゼンテーションの作成**

Creating a PowerPoint file from scratch in Aspose.Slides for Python is as direct as instantiating the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. The constructor automatically supplies a blank deck with a single slide, giving you an immediate canvas for shapes, text, charts, or any other content your application needs. Once you modify that slide—or add new ones—you can persist the result to PPTX, legacy PPT, or even OpenDocument formats. The short code sample below illustrates this workflow by adding a simple shape onto the first slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.  
2. Get a reference to the slide by its index.  
3. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) object of `CLOUD` type using the `add_auto_shape` method exposed by the `shapes` collection.  
4. Add text to the auto-shape.  
5. Save the modified presentation as a PPTX file.

In the example below, a cloud shape is added to the first slide of the presentation.
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
新しいプレゼンテーションは [PPTX、PPT、ODP](/slides/ja/python-net/save-presentation/) に保存でき、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-net/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-net/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-net/convert-powerpoint-to-png/)、および [画像](/slides/ja/python-net/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**  
はい。テンプレートを読み込み、目的の形式で保存できます。POTX、POTM、PPTM などの形式は [サポートされています](/slides/ja/python-net/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比を制御するにはどうすればよいですか？**  
[スライドサイズ](/slides/ja/python-net/slide-size/) を設定し（4:3 や 16:9 などのプリセットやカスタム寸法を含む）、コンテンツのスケーリング方法を選択します。

**サイズや座標はどの単位で測定されますか？**  
ポイント単位です。1 インチは 72 ユニットに相当します。

**非常に大きなプレゼンテーション（多数のメディアファイルを含む）を扱う際、メモリ使用量を減らすにはどうすればよいですか？**  
[BLOB 管理戦略](/slides/ja/python-net/manage-blob/) を使用し、一時ファイルを活用してメモリ内の保存を制限し、純粋なインメモリ ストリームよりもファイルベースのワークフローを優先してください。

**プレゼンテーションを並列で作成/保存できますか？**  
同じ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/python-net/multithreading/) から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**トライアルの透かしや制限を削除するにはどうすればよいですか？**  
プロセスごとに一度だけ [ライセンスを適用](/slides/ja/python-net/licensing/) してください。ライセンス XML は変更せずにそのまま保持し、複数スレッドが関与する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付けることはできますか？**  
はい。プレゼンテーションでは [デジタル署名](/slides/ja/python-net/digital-signature-in-powerpoint/)（追加および検証）がサポートされています。

**作成されたプレゼンテーションでマクロ（VBA）はサポートされていますか？**  
はい。[VBA プロジェクトの作成/編集](/slides/ja/python-net/presentation-via-vba/) が可能で、PPTM や PPSM などのマクロ対応ファイルとして保存できます。