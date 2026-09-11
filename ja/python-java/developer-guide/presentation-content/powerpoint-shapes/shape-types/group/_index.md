---
title: Python via Java でのグループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/python-java/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループ 追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint デッキでシェイプをグループ化およびグループ解除する方法を学びましょう — 無料の Python コード付きステップバイステップ ガイドです。"
---
## **概要**

この記事では、Aspose.Slides のグループ シェイプの使用方法について説明します。スライドにグループ シェイプを追加し、その中にシェイプを配置し、更新されたプレゼンテーションを保存する方法を示します。また、グループ内に格納されたシェイプにアクセスし、[getAlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) を使用して代替テキストを読み取る方法も示します。さらに、ネストされたグループ、Z オーダー、ロックオプションなど、関連するグループシェイプ機能について簡単に説明します。

## **グループ シェイプの追加**

Aspose.Slides はスライド上のグループ シェイプの操作をサポートしています。この機能により、開発者はよりリッチなプレゼンテーションを作成できます。Aspose.Slides for Python via Java はグループ シェイプの追加とアクセスをサポートしています。グループ シェイプにシェイプを配置したり、そのプロパティにアクセスしたりできます。Aspose.Slides for Python via Java を使用してスライドにグループ シェイプを追加するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドにグループ シェイプを追加します。
4. グループ シェイプにシェイプを追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Presentation クラスのインスタンスを作成します。
presentation = Presentation()
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    # スライドのシェイプ コレクションにアクセスします。
    slide_shapes = slide.getShapes()

    # スライドにグループ シェイプを追加します。
    group_shape = slide_shapes.addGroupShape()

    # グループ シェイプ内にシェイプを追加します。
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # グループ シェイプのフレームを設定します。
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # PPTX ファイルをディスクに書き込みます。
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **代替テキストへのアクセス**

このセクションでは、スライド上のグループ内のシェイプの代替テキストにアクセスする方法を示します。Aspose.Slides for Python via Java を使用してこのテキストにアクセスするには、次の手順を実行します。

1. PPTX ファイルを表す [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドのシェイプ コレクションにアクセスします。
4. グループ シェイプにアクセスします。
5. [getAlternativeText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getAlternativeText) を使用して、そのシェイプの代替テキストを読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
presentation = Presentation("AltText.pptx")
try:
    # 最初のスライドを取得します。
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # スライドのシェイプ コレクション内のシェイプにアクセスします。
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # グループ内のシェイプにアクセスします。
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # 代替テキストを読み取ります。
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**ネストされたグループ化（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshape/) には [getParentGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getParentGroup) メソッドがあり、階層サポートを示しています。グループは別のグループの子になることができます。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどう制御しますか？**

[GroupShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshape/) オブジェクトの [getZOrderPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getZOrderPosition) メソッドを使用して、表示スタック内での位置を確認できます。

**移動、編集、またはグループ解除を防止できますか？**

はい。グループのロックは [getGroupShapeLock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/groupshape/#getGroupShapeLock) を介して公開されており、オブジェクトに対する操作を制限できます。