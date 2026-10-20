---
title: Python でプレゼンテーション スライドのシェイプをリサイズする
type: docs
weight: 130
url: /ja/python-net/resizing-shapes-on-slide/
aliases:
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

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更と位置調整が必要になる場合があります。本記事では、シェイプを手動でスケーリングする方法と、スライド、マスター、レイアウト上のテーブルを扱う方法を示します。

## **シェイプのサイズ変更**

最初の例では、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更し、結果を保存します。それは [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) を [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) とともに使用し、以降のループでスケーリングを制御できるようにします。比率は単位なしで、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪む可能性があり、シェイプのサイズを変更してもフォントサイズはスケーリングされません。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 水平および垂直の独立したスケール係数を計算します。
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
テーブルは別途処理が必要です。テーブル全体の幅と高さを設定するのではなく、列幅と行高さをスケーリングします。セルの内容がより多くのスペースを必要とする場合、行の高さは要求されたサイズより大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスターやレイアウト、個々のスライド上のシェイプを処理します。そのヘルパーは各 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) を処理し、[Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) と [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) をスケーリングします。その後、テーブル全体のサイズを別途スケーリングせずに位置をスケーリングします。
```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # テーブルのサイズは列幅と行高さで制御されます。
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
    # 水平および垂直の独立したスケール係数を計算します。
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # マスターとレイアウト、および個々のスライドで定義されたシェイプをリサイズします。
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**スライドのサイズ変更後にシェイプが歪んだり切れたりするのはなぜですか？**  
スライドサイズを変更してシェイプをスケーリングしない場合、シェイプは元の位置とサイズを保持し、スライドの外にはみ出すことがあります。また、幅と高さを異なる比率でスケーリングするとシェイプが歪むことがあります。

**提供されたコードはすべてのシェイプタイプで機能しますか？**  
最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズをスケーリングせず、テーブルの内容が行の高さを制限する可能性があるため、結果のレイアウト、特にテキストとテーブルを確認してください。

**スライドをリサイズする際にテーブルのサイズを変更する方法は？**  
列幅を幅の比率で、最小行高さを高さの比率でスケーリングし、テーブルの位置をスケーリングします。これは 2 番目の例に示されています。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**  
はい。2 番目の例は [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) と各マスターの [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) を走査し、シェイプに同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦/横）を変更できますか？**  
はい。スライドサイズを変更した後、対象のサイズを取得する前に [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) を設定すると、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに上限はありますか？**  
[SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) を使用してカスタムスライドサイズを指定できます。サポートされるサイズはプレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**  
幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライドサイズに収める場合、幅と高さの比率の小さい方を両方の寸法と位置に使用します。これにより比率は保たれますが、片側に未使用領域が残ることがあります。