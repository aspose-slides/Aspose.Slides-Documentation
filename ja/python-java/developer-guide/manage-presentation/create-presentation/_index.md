---
title: Python via Java でプレゼンテーションを作成
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/python-java/create-presentation/
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
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python via Java でプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用して、プログラムで保存し信頼できる結果を得ることができます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用してプレゼンテーションを作成し、最初のスライドにテキスト付きシェイプを追加して、結果を PPTX ファイルとして保存する方法を示します。FAQ では、出力形式、テンプレート、スライドサイズ、メモリ使用量、スレッド処理、ライセンス、デジタル署名、VBA のサポートについて説明します。

## **プレゼンテーションの作成**

Aspose.Slides for Python via Java で PowerPoint ファイルをゼロから作成することは、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスをインスタンス化するのと同じくらい簡単です。コンストラクタは自動的に 1 枚のスライドを持つ空のデッキを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツのためのすぐに使えるキャンバスを提供します。そのスライドを変更するか（または新しいスライドを追加する）ことで、結果を PPTX、従来の PPT、あるいは OpenDocument 形式で保存できます。以下の短いコードサンプルは、最初のスライドにシンプルなシェイプを追加することでこのワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで最初のスライドを取得します。
1. [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) を使用して、タイプが [ShapeType.Cloud](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#Cloud) の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. [TextFrame.setText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#setText) を使用してシェイプのテキストを設定します。
1. [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を使用し、[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) でプレゼンテーションを保存します。

以下の例は Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。JVM が起動していない場合は起動し、最初のスライドにクラウド形状を追加し、プレゼンテーションを保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 1枚の空白スライドでプレゼンテーションを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # クラウド形状を追加し、テキストを設定します。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![新しいプレゼンテーション](new_presentation.png)

## **よくある質問**

**新しいプレゼンテーションをどの形式で保存できますか？**

次の形式で保存できます: [PPTX, PPT, and ODP](/slides/ja/python-java/save-presentation/)、また、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-java/render-slide-as-svg/)、および[images](/slides/ja/python-java/convert-powerpoint-to-png/) などにエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存できます。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-java/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比をどのように制御しますか？**

[slide size](/slides/ja/python-java/slide-size/) を設定し（4:3 や 16:9 のプリセットやカスタム寸法を含む）、コンテンツのスケーリング方法を選択します。

**サイズと座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットに相当します。

**メディアファイルが多数ある非常に大きなプレゼンテーションでメモリ使用量を削減するにはどうすればよいですか？**

[BLOB management strategies](/slides/ja/python-java/manage-blob/) を使用し、一時ファイルを活用してメモリ内ストレージを制限し、純粋にメモリ上のストリームよりもファイルベースのワークフローを優先してください。

**プレゼンテーションを並行して作成/保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/python-java/multithreading/)から操作することはできません。スレッドまたはプロセスごとに別々の独立したインスタンスを実行してください。

**トライアルの透かしや制限を削除するにはどうすればよいですか？**

[Apply a license](/slides/ja/python-java/licensing/) をプロセスごとに一度実行してください。ライセンス XML は変更せず、その設定は複数スレッドが関与する場合は同期させる必要があります。

**作成した PPTX にデジタル署名できますか？**

はい。[Digital signatures](/slides/ja/python-java/digital-signature-in-powerpoint/)（追加および検証）はプレゼンテーションでサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[create/edit VBA projects](/slides/ja/python-java/presentation-via-vba/) を使用して VBA プロジェクトを作成/編集でき、PPTM/PPSM などのマクロ有効ファイルとして保存できます。