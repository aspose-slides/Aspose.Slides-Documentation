---
title: Python（Java 経由）でプレゼンテーションに矩形を追加
linktitle: 矩形
type: docs
weight: 80
url: /ja/python-java/rectangle/
keywords:
- 矩形を追加
- 矩形を作成
- 矩形シェイプ
- シンプルな矩形
- 書式設定された矩形
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して矩形を追加し、PowerPoint プレゼンテーションを強化します。プログラムでシェイプを簡単に設計・変更できます。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint スライドに矩形シェイプを追加する方法を示します。シンプルな矩形の作成、書式設定された矩形の作成、および更新されたプレゼンテーションを PPTX ファイルとして保存する手順をカバーしています。

また、塗りつぶしの単色、線の色、線幅などの基本的な矩形書式設定の適用方法も確認できます。さらに、FAQ では、角丸、画像塗りつぶし、視覚効果、ハイパーリンク、シェイプロック、エクスポートオプション、効果的なプロパティなど、関連する矩形タスクへのリンクが提供されています。

## **スライドに矩形を追加する**

プレゼンテーションの選択したスライドにシンプルな矩形を追加するには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、矩形タイプの [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにシンプルな矩形を追加しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # 矩形シェイプを追加します。
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # PPTX ファイルをディスクに書き込みます。
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スライドに書式設定された矩形を追加する**

スライドに書式設定された矩形を追加するには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) オブジェクトが提供する [addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して、矩形タイプの [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) を追加します。
- 矩形の [fill type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を単色に設定します。
- [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/) オブジェクトの単色塗りつぶしに対して、[setColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/colorformat/#setColor) メソッドを使用して矩形の色を設定します。
- 矩形の輪郭の色を設定します。
- 矩形の輪郭の幅を設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き込みます。

上記の手順は、以下の例で実装されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # 矩形シェイプを追加します。
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # 矩形の塗りつぶしを設定します。
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # 矩形の輪郭を設定します。
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # PPTX ファイルをディスクに書き込みます。
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**角丸の矩形を追加するにはどうすればよいですか？**

角丸の [shape type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/) を使用し、シェイプのプロパティでコーナー半径を調整します。ジオメトリの調整により、コーナーごとに丸めることもできます。

**矩形を画像（テクスチャ）で塗りつぶすには？**

画像塗りつぶしの [fill type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) を選択し、画像ソースを指定して、[stretching/tiling modes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillmode/) を構成します。

**矩形に影やグローを付けられますか？**

はい。[Outer/inner shadow, glow, and soft edges](/slides/ja/python-java/shape-effect/) が利用可能で、パラメーターを調整できます。

**矩形をハイパーリンク付きのボタンにできますか？**

はい。シェイプのクリックに [Assign a hyperlink](/slides/ja/python-java/manage-hyperlinks/) を設定して、スライド、ファイル、Web アドレス、またはメールにジャンプできます。

**矩形の移動や変更から保護するには？**

[Use shape locks](/slides/ja/python-java/applying-protection-to-presentation/) を使用すると、移動、サイズ変更、選択、テキスト編集を禁止してレイアウトを保護できます。

**矩形をラスタ画像または SVG に変換できますか？**

はい。指定したサイズ/スケールでシェイプを画像に [render the shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) したり、ベクター用途のために [export it as SVG](/slides/ja/python-java/create-shape-thumbnails/) したりできます。

**テーマと継承を考慮した矩形の実際の（effective）プロパティをすばやく取得するには？**

[Use the shape’s effective properties](/slides/ja/python-java/shape-effective-properties/) を使用すると、API がテーマスタイル、レイアウト、ローカル設定を考慮した計算値を返し、書式分析を簡素化します。