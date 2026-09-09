---
title: Python via Java でプレゼンテーションを作成
linktitle: プレゼンテーションの作成
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
description: Aspose.Slides を使用して Python via Java でプレゼンテーションを作成し、PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して信頼できる結果を得られます。
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用してプレゼンテーションを作成し、最初のスライドにテキスト付きのシェイプを追加し、結果を PPTX ファイルとして保存する方法を示します。FAQ では、出力形式、テンプレート、スライドサイズ、メモリ使用量、スレッド処理、ライセンス、デジタル署名、VBA のサポートについて説明します。

## **プレゼンテーションの作成**

Aspose.Slides for Python via Java でゼロから PowerPoint ファイルを作成するのは、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスをインスタンス化するだけで簡単です。コンストラクターは自動的に単一スライドの空白デッキを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツのキャンバスがすぐに利用可能になります。そのスライドを変更するか、新しいスライドを追加したら、結果を PPTX、従来の PPT、あるいは OpenDocument 形式に保存できます。以下の簡単なコードサンプルは、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで最初のスライドを取得します。
1. [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) を使用して、[ShapeType.Cloud](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/#Cloud) タイプの [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
1. [TextFrame.setText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/#setText) でシェイプのテキストを設定します。
1. [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) と [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Pptx) を使用してプレゼンテーションを保存します。

次の例は Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。JVM が起動していない場合は起動し、最初のスライドに雲のシェイプを追加し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 1つの空白スライドでプレゼンテーションを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # 雲のシェイプを追加し、テキストを設定します。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![新しいプレゼンテーション](new_presentation.png)

## **FAQ**

**新しいプレゼンテーションをどの形式で保存できますか？**

[PPTX, PPT, and ODP](/slides/ja/python-java/save-presentation/) に保存でき、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-java/render-slide-as-svg/)、および [images](/slides/ja/python-java/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始して通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は [サポートされています](/slides/ja/python-java/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ／アスペクト比をどのように制御しますか？**

[スライドサイズ](/slides/ja/python-java/slide-size/) を設定します（4:3、16:9 などのプリセットやカスタム寸法）。コンテンツのスケーリング方法も選択できます。

**サイズや座標はどの単位で測定されますか？**

ポイント単位です。1 インチは 72 ユニットです。

**非常に大きなプレゼンテーション（多数のメディアファイル）でメモリ使用量を削減するには？**

[BLOB 管理戦略](/slides/ja/python-java/manage-blob/) を使用し、テンポラリファイルを活用してインメモリ保存を制限し、純粋なインメモリストリームよりもファイルベースのワークフローを優先します。

**プレゼンテーションを並列で作成／保存できますか？**

同じ [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/python-java/multithreading/) から操作することはできません。スレッドまたはプロセスごとに別々のインスタンスを使用してください。

**試用版の透かしと制限を削除するには？**

プロセスごとに一度だけ [ライセンスを適用](/slides/ja/python-java/licensing/) してください。ライセンス XML は変更せず、複数スレッドで使用する場合はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付加できますか？**

はい。プレゼンテーション向けの [デジタル署名](/slides/ja/python-java/digital-signature-in-powerpoint/)（追加および検証）がサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成／編集](/slides/ja/python-java/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。