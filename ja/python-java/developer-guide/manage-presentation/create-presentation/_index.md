---
title: Python via Java でプレゼンテーションを作成
linktitle: プレゼンテーションを作成
type: docs
weight: 10
url: /ja/python-java/create-presentation/
keywords:
- プレゼンテーションを作成
- 新しいプレゼンテーション
- PPT を作成
- 新しい PPT
- PPTX を作成
- 新しい PPTX
- ODP を作成
- 新しい ODP
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python via Java でプレゼンテーションを作成 — PPT、PPTX、ODP ファイルを生成し、OpenDocument のサポートを活用し、プログラムで保存して信頼性の高い結果を得られます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用してプレゼンテーションを作成し、最初のスライドにテキスト付きシェイプを追加し、結果を PPTX ファイルとして保存する方法を示します。FAQ では、出力形式、テンプレート、スライドサイズ、メモリ使用量、スレッド、ライセンス、デジタル署名、VBA のサポートについて説明します。

開始する前に、Python、JDK、JPype、そして Aspose.Slides for Python via Java をインストールしてください。[インストール](/slides/ja/python-java/installation/) で Windows、Linux、macOS の手順を確認できます。

## **プレゼンテーションの作成**

Aspose.Slides for Python via Java で最初から PowerPoint ファイルを作成するのは、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスをインスタンス化するだけです。コンストラクターは自動的に 1 枚のスライドを含む空のデッキを提供し、シェイプ、テキスト、チャート、またはアプリケーションが必要とする任意のコンテンツ用のキャンバスがすぐに利用できます。そのスライドを変更するか新しいスライドを追加した後、結果を PPTX、従来の PPT、あるいは OpenDocument 形式に保存できます。以下の短いコードサンプルは、最初のスライドにシンプルなシェイプを追加するワークフローを示しています。

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックス 0 で最初のスライドを取得します。
1. [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) を使用して、タイプが [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) の [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) を追加します。
1. [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText) でシェイプのテキストを設定します。
1. [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) と [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) を使用してプレゼンテーションを保存します。

以下の例は、Java 仮想マシン (JVM) が起動していない場合に起動し、最初のスライドにテキスト付きの雲シェイプを追加し、プレゼンテーションを保存します。*create_presentation.py* として保存してください：

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

    # 雲形状を追加し、テキストを設定します。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # プレゼンテーションを PPTX ファイルとして保存します。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

インストールしたパッケージがある環境でスクリプトを実行します：

```sh
python create_presentation.py
```

雲の左上隅はスライドの左端と上端からそれぞれ 20 ポイント離れており、雲の幅は 200 ポイント、高さは 80 ポイントです。スクリプトは現在の作業ディレクトリに *new_presentation.pptx* を保存し、雲とそのテキストを含む 1 枚のスライドが作成されます。JVM は Python プロセスが終了するまで実行され続けます；詳しくは [Limitations and API Differences](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) を参照してください。ライセンスがない場合、Aspose.Slides は保存するすべてのスライドに評価用の透かしテキストボックスを追加します；詳細は [Licensing](/slides/ja/python-java/licensing/) をご覧ください。

結果：

![新しいプレゼンテーション](new_presentation.png)

## **FAQ**

**新しいプレゼンテーションを保存できる形式は何ですか？**

[PPTX、PPT、ODP](/slides/ja/python-java/save-presentation/) に保存でき、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[XPS](/slides/ja/python-java/convert-powerpoint-to-xps/)、[HTML](/slides/ja/python-java/convert-powerpoint-to-html/)、[SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/)、および[画像](/slides/ja/python-java/convert-powerpoint-to-png/) などにもエクスポートできます。

**テンプレート (POTX/POTM) から開始し、通常の PPTX として保存できますか？**

はい。テンプレートを読み込み、目的の形式で保存します。POTX/POTM/PPTM などの形式は[サポートされています](/slides/ja/python-java/supported-file-formats/)。

**プレゼンテーション作成時にスライドサイズ/アスペクト比をどのように制御しますか？**

[スライドサイズ](/slides/ja/python-java/slide-size/) を設定し（4:3、16:9 などのプリセットやカスタム寸法）、コンテンツのスケーリング方法を選択します。

**サイズと座標はどの単位で測定されますか？**

ポイントで測定します。1 インチは 72 ユニットです。

**非常に大きなプレゼンテーション（多数のメディア ファイル）でメモリ使用量を抑えるにはどうすればよいですか？**

[BLOB 管理戦略](/slides/ja/python-java/manage-blob/) を使用し、一時ファイルを活用してインメモリ保存を制限し、できるだけファイルベースのワークフローを選択してください。

**プレゼンテーションを並行して作成/保存できますか？**

同じ [Presentation]インスタンスを[複数のスレッド](/slides/ja/python-java/multithreading/) から操作することはできません。スレッドまたはプロセスごとに個別のインスタンスを実行してください。

**評価版の透かしと制限を削除するには？**

プロセスごとに一度だけ[ライセンスを適用](/slides/ja/python-java/licensing/)してください。ライセンス XML は変更せず、複数スレッド使用時はライセンス設定を同期させる必要があります。

**作成した PPTX にデジタル署名を付けられますか？**

はい。プレゼンテーション向けの[デジタル署名](/slides/ja/python-java/digital-signature-in-powerpoint/)（追加および検証）がサポートされています。

**作成したプレゼンテーションでマクロ (VBA) はサポートされていますか？**

はい。[VBA プロジェクトの作成/編集](/slides/ja/python-java/presentation-via-vba/) が可能で、PPTM/PPSM などのマクロ有効ファイルとして保存できます。