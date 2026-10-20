---
title: .NET でプレゼンテーション スライドのシェイプをリサイズ
type: docs
weight: 130
url: /ja/net/resizing-shapes-on-slide/
aliases:
  - /ja/net/re-sizing-shapes-on-slide/
keywords:
- シェイプのサイズ変更
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にリサイズできます。スライドレイアウトの調整を自動化し、生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、新しいサイズに合わせてシェイプのサイズ変更や位置再設定が必要になる場合があります。本記事では、シェイプを手動で拡大縮小する方法と、スライド、マスター、レイアウト上のテーブルの扱い方を示します。

## **シェイプのサイズ変更**

各シェイプの相対的な位置とサイズを維持するには、水平座標と幅に新しいスライド幅と元の幅の比率を掛けます。垂直座標と高さには、対応する高さの比率を掛けます。

最初の例は、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更し、結果を保存します。[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) を [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) と共に使用し、以降のループで拡大縮小を制御します。比率は単位を持たず、シェイプの位置とサイズはポイントで測定されます。幅と高さの比率が異なるとシェイプが歪み、シェイプのサイズを変更してもフォントサイズは拡大縮小されません。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 独立した水平および垂直の拡大縮小係数を計算します。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
テーブルは別途処理が必要です：テーブル全体の幅と高さを設定するのではなく、列幅と行高さを拡大縮小します。セルの内容がより多くのスペースを必要とする場合、行の高さは要求されたより大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルをサポートし、個々のスライドだけでなくマスターとレイアウト上のシェイプも処理してから、サイズ変更したプレゼンテーションを保存します。そのヘルパーは各 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) を [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) と [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) を拡大縮小して処理します。その後、テーブル全体のサイズを個別に拡大縮小することなく、テーブルの位置を拡大縮小します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 独立した水平および垂直の拡大縮小係数を計算します。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// マスターとレイアウト、そして個々のスライドに定義されたシェイプをリサイズします。
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // テーブルの寸法は列幅と行高さで制御されます。
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **よくある質問**

**スライドのサイズを変更した後、シェイプが歪んだり切れたりするのはなぜですか？**

スライドサイズを変更してシェイプを拡大縮小しないと、シェイプは元の位置とサイズのまま残り、スライドの外側にはみ出す可能性があります。幅と高さの比率が異なるとシェイプも歪みます。

**提供されたコードはすべてのシェイプタイプで動作しますか？**

最初の例はシェイプの境界を直接変更し、テーブルを含まないスライドを対象としています。2 番目の例はテーブルを別途処理します。これらの例はフォントサイズを拡大縮小しないため、特にテキストやテーブルのレイアウトを確認してください。

**スライドのサイズ変更時にテーブルをどのようにリサイズすればよいですか？**

列幅は幅の比率で、行の最小高さは高さの比率で拡大縮小し、最後にテーブル全体の位置を拡大縮小します。これは 2 番目の例に示されています。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい。2 番目の例は [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) と各マスターの [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) を走査し、同じリサイズロジックをシェイプに適用します。

**スライドの向き（縦向き/横向き）をリサイズと同時に変更できますか？**

はい。スライドサイズを変更した後、対象の寸法を取得する前に [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) を設定すれば、拡大縮小係数が最終的な向きを反映します。

**設定できるスライドサイズに上限はありますか？**

[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) を使用してカスタムスライド寸法を指定できます。サポートされる寸法はプレゼンテーションの形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比を持つシェイプが歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じ拡大縮小係数を使用します。元のレイアウトを新しいスライド寸法に収めるには、幅比率と高さ比率のうち小さい方を両方の寸法と位置に適用します。これにより比例は保たれますが、片側に未使用領域が残ることがあります。