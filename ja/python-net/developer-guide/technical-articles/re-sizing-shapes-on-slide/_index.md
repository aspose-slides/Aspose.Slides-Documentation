---
title: Python でプレゼンテーション スライドのシェイプをリサイズ
type: docs
weight: 130
url: /ja/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /ja/python-net/re-sizing-shapes-on-slide/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しい寸法に合わせてシェイプのサイズ変更と位置調整が必要になる場合があります。この記事では、シェイプを手動で拡大縮小する方法と、スライド、マスター、レイアウト上のテーブルを扱う方法を示します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを保持するには、水平座標と幅を「新しいスライド幅 ÷ 元の幅」の比率で掛けます。垂直座標と高さには、対応する高さの比率を適用します。

最初の例は、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更して結果を保存します。これは [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) と [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) を使用し、以降のループでスケーリングを制御します。比率は単位なしで、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪んだり、シェイプのサイズ変更だけではフォントサイズは拡大縮小されません。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 水平方向と垂直方向の独立したスケール係数を計算します。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さを個別に拡大縮小します。セルの内容が多い場合、行高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルに対応し、マスターやレイアウト上のシェイプも個々のスライドと同様に処理してからリサイズされたプレゼンテーションを保存します。ヘルパーは各 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を処理し、[Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) と [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) を拡大縮小します。その後、テーブル全体のサイズを別途拡大縮小せずに位置だけを拡大縮小します。

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # テーブルの寸法は列幅と行高さで制御されます。
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # 水平方向と垂直方向の独立したスケール係数を計算します。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # マスターとレイアウト、個別スライドで定義されたシェイプをリサイズします。
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**スライドサイズを変更した後、シェイプが歪んだり切り取られたりするのはなぜですか？**  
シェイプをスケーリングせずにスライドサイズだけを変更すると、シェイプは元の位置とサイズのままでスライドの外にはみ出す可能性があります。幅と高さの比率が異なるとシェイプが歪むこともあります。

**提供されたコードはすべてのシェイプタイプで動作しますか？**  
最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズを拡大縮小しないため、特にテキストやテーブルのレイアウトを確認してください。テーブルの内容が行高さを制約することがあります。

**スライドをリサイズするときにテーブルはどう扱いますか？**  
列幅を幅の比率で、最小行高さを高さの比率で拡大縮小し、最後にテーブルの位置を拡大縮小します。これは 2 番目の例に示されています。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**  
はい。2 番目の例は [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) を走査し、各マスターの [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) も同様にリサイズロジックを適用します。

**スライドの向き（縦・横）もリサイズと同時に変更できますか？**  
はい。スライドサイズを変更した後、ターゲット寸法を取得する前に [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) を設定すれば、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに上限はありますか？**  
[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) でカスタムサイズを指定できます。サポートされるサイズはプレゼンテーション形式や使用するアプリケーションにも依存します。

**固定アスペクト比を持つシェイプが歪むのを防ぐには？**  
幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに収めるには、幅と高さの比率のうち小さい方を両方の寸法と位置に適用します。これにより比率は保持されますが、片側に余白が残ることがあります。