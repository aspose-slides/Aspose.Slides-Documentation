---
title: Python（Java 経由）でプレゼンテーションに楕円を追加する
linktitle: 楕円
type: docs
weight: 30
url: /ja/python-java/ellipse/
keywords:
- 楕円
- 図形
- 楕円を追加
- 楕円を作成
- 楕円を描画
- 書式設定された楕円
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python（Java 経由）用 Aspose.Slides で PPT および PPTX プレゼンテーション向けに楕円形を作成、書式設定、操作する方法を学びます—Python のコード例付き。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint スライドに楕円形を追加する方法を示します。シンプルな楕円の作成、書式設定された楕円の作成、更新したプレゼンテーションを PPTX ファイルとして保存する手順をカバーします。また、楕円の位置とサイズの扱い、スタッキング順序の制御、アニメーション効果の適用に関する関連質問にも触れます。

## **楕円の作成**

プレゼンテーションの選択したスライドにシンプルな楕円を追加するには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) オブジェクトの [addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して楕円を追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

次の例は、最初のスライドに楕円を追加します。

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

    # 楕円形を追加します。
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # PPTX ファイルを書き込みます。
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **書式設定された楕円の作成**

スライドに書式設定された楕円を追加するには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) オブジェクトの [addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape) メソッドを使用して楕円を追加します。
- 楕円の塗りつぶしタイプを Solid に設定します。
- [Shape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/) オブジェクトに関連付けられた [FillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/) オブジェクトの [getSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#getSolidFillColor) を使用して塗りつぶし色を設定します。
- 楕円の輪郭色を設定します。
- 楕円の輪郭幅を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

次の例は、プレゼンテーションの最初のスライドに書式設定された楕円を追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # 楕円形を追加します。
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # 楕円の塗りつぶしを設定します。
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # 楕円の輪郭を設定します。
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # PPTX ファイルを書き込みます。
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**スライドの単位に対して楕円の正確な位置とサイズを設定するにはどうすればよいですか？**

座標とサイズは通常 **ポイント単位** で指定します。予測可能な結果を得るために、スライドサイズに基づいて計算し、必要なミリメートルやインチをポイントに変換してから値を設定してください。

**楕円を他のオブジェクトの上または下に配置してスタッキング順序を制御するには？**

オブジェクトの描画順序を前面に持ってくるか背面に送ることで順序を調整します。これにより、楕円が他のオブジェクトと重なったり、背後のオブジェクトを表示したりできます。

**楕円の表示や強調にアニメーションを付けるには？**

[適用](/slides/ja/python-java/shape-animation/) 入場、強調、または退場効果を形状に設定し、トリガーやタイミングを構成してアニメーションの再生タイミングと方法を調整します。