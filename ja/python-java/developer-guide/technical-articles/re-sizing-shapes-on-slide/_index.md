---
title: Python（Java経由）でプレゼンテーション スライドの図形をリサイズする
type: docs
weight: 110
url: /ja/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/スライド上-図形-リサイズ/
  - /ja/python-java/re-sizing-shapes-on-slide/
keywords:
  - 図形リサイズ
  - 図形 サイズ変更
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint と OpenDocument のスライド上の図形を簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しい寸法に合わせて図形のサイズ変更と位置調整が必要になる場合があります。この記事では、図形を手動で拡大縮小する方法と、スライド、マスタ、レイアウト上のテーブルの処理方法を示します。

## **図形のサイズ変更**

各図形の相対的な位置とサイズを保持するには、水平座標と幅を新しいスライド幅と元の幅の比率で掛けます。対応する高さの比率を垂直座標と高さに適用します。

最初の例では、テーブルを含まないスライドを持つプレゼンテーションをロードし、スライドサイズをA4に変更して結果を保存します。スケーリングを制御するために、後続のループで使用できるよう、[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) を [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) と共に使用しています。比率は単位なしで、図形の位置と寸法はポイントで測定されます。幅と高さの比率が異なると図形が歪み、図形の寸法を変更してもフォントサイズは拡大縮小されません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
        # 水平および垂直方向の独立したスケール係数を計算します。
        original_size = presentation.getSlideSize().getSize()
        presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
        target_size = presentation.getSlideSize().getSize()
        width_ratio = target_size.getWidth() / original_size.getWidth()
        height_ratio = target_size.getHeight() / original_size.getHeight()

        for slide in presentation.getSlides():
            for shape in slide.getShapes():
                shape.setWidth(shape.getWidth() * width_ratio)
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setX(shape.getX() * width_ratio)
                shape.setY(shape.getY() * height_ratio)

        presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
テーブルは個別に処理する必要があります。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをスケーリングします。セルの内容がより多くのスペースを必要とする場合、行の高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2番目の例では、テーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスタとレイアウト上の図形、および個々のスライドの図形を処理します。そのヘルパーは、各[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) を[Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth)で列幅を、[Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight)で最小行高さをスケーリングして処理します。その後、テーブル全体の寸法を個別にスケーリングせずにテーブルの位置をスケーリングします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # テーブルの寸法は列幅と行高さで制御されます。
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # 水平および垂直方向の独立したスケール係数を計算します。
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # マスタとレイアウト、および個々のスライド上に定義された図形をリサイズします。
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**スライドのサイズ変更後に図形が歪んだり切り取られたりするのはなぜですか？**

スライドサイズを変更しても図形をスケーリングしないと、図形は元の位置と寸法を保持したままスライドの外にはみ出すことがあります。幅と高さを異なる比率でスケーリングすると、図形が歪むこともあります。

**提供されたコードはすべての図形タイプで機能しますか？**

最初の例は図形の境界を直接変更し、テーブルのないスライドを対象としています。2番目の例はテーブルを別途処理します。これらの例ではフォントサイズはスケーリングされず、テーブルの内容が行の高さを制限する可能性があるため、特にテキストやテーブルのレイアウトを確認してください。

**スライドのサイズ変更時にテーブルのサイズを変更するにはどうすればよいですか？**

幅の比率で列幅を、高さの比率で最小行高さをスケーリングし、テーブルの位置をスケーリングします（2番目の例を参照）。

**このリサイズはマスタスライドおよびレイアウトスライドでも機能しますか？**

はい。2番目の例では[Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) と各マスタの[MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) を反復し、図形に同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦横）を変更できますか？**

はい。スライドサイズを変更した後、対象の寸法を取得する前に[SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) を呼び出すことで、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに制限はありますか？**

[SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) を使用してカスタムスライド寸法を指定できます。サポートされる寸法は、プレゼンテーション形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比の図形が歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライド寸法に合わせるには、幅と高さの比率のうち小さい方を幅・高さ・位置のすべてに使用します。これにより比例が保たれますが、片方の端に未使用のスペースが残る場合があります。