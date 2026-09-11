---
title: Python via Java でプレゼンテーションに線シェイプを追加
linktitle: 線
type: docs
weight: 50
url: /ja/python-java/line/
keywords:
- 線
- 線の作成
- 線の追加
- シンプルな線
- 線の構成
- 線のカスタマイズ
- 破線スタイル
- 矢印ヘッド
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションの線書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---
## **概要**

Aspose.Slides を使用すると、プログラムから PowerPoint スライドに線形シェイプを追加できます。この記事では、シンプルな線の作成方法と、線を矢印として表示するカスタマイズ方法を示します。

線形シェイプのスライドへの追加方法、外観の調整、更新されたプレゼンテーションの保存方法を学びます。例では、スタイル、幅、破線パターン、矢印ヘッドのオプション、塗りつぶし色など、実用的な線の書式設定に焦点を当てています。

## **単純な線の作成**

プレゼンテーションの選択したスライドにシンプルな線を追加するには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) オブジェクトの[addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape)メソッドを使用して線シェイプを追加します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

次の例は、プレゼンテーションの最初のスライドに線を追加します。

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

    # 線シェイプを追加します。
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # PPTX ファイルをディスクに書き込みます。
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **矢印形状の線の作成**

Aspose.Slides for Python via Java では、開発者が線のプロパティを設定して、線をより魅力的に見せることもできます。線を矢印のように見せるには、以下の手順に従います。

- [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
- インデックスでスライドへの参照を取得します。
- [ShapeCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/) オブジェクトの[addAutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addAutoShape)メソッドを使用して線シェイプを追加します。
- Aspose.Slides for Python via Java が提供する[line style](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linestyle/)のいずれかに設定します。
- 線の幅を設定します。
- Aspose.Slides for Python via Java が提供する[dash style](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linedashstyle/)のいずれかに設定します。
- 線の開始位置に[arrowhead style](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linearrowheadstyle/)と[length](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linearrowheadlength/)を設定します。
- 線の終了位置に[arrowhead style](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linearrowheadstyle/)と[length](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linearrowheadlength/)を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # 線シェイプを追加します。
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # 線に書式設定を適用します。
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # PPTX ファイルをディスクに書き込みます。
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**通常の線をコネクタに変換して図形に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) のタイプが[Line](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapetype/)）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の[Connector](https://reference.aspose.com/slides/ja/python-java/aspose.slides/connector/)タイプと、接続用の[corresponding APIs](/slides/ja/python-java/connector/) を使用してください。

**線のプロパティがテーマから継承されていて最終的な値が分かりにくい場合はどうすればよいですか？**

線とその塗りつぶしの[effective properties](/slides/ja/python-java/shape-effective-properties/)を読み取ります。これらは継承およびテーマスタイルを考慮した値です。

**線を編集（移動やサイズ変更）できないようにロックすることはできますか？**

はい。シェイプは[lock objects](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/#getAutoShapeLock)を提供しており、[editing operations を禁止](/slides/ja/python-java/applying-protection-to-presentation/)できます。