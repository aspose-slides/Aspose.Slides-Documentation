---
title: .NET でプレゼンテーション スライド上の形状をリサイズ
type: docs
weight: 130
url: /ja/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /ja/net/re-sizing-shapes-on-slide/
keywords:
  - 形状のサイズ変更
  - 形状サイズの変更
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のスライド上の形状を簡単にリサイズし、スライドレイアウトの調整を自動化して生産性を向上させます。"
---
## **概要**

プレゼンテーションのスライドサイズを変更すると、形状のサイズと位置を新しい寸法に合わせて調整する必要がある場合があります。本記事では、形状を手動でスケーリングする方法と、スライド、マスター、レイアウト上のテーブルの扱い方を示します。

## **形状のサイズ変更**

各形状の相対的な位置とサイズを保つには、水平座標と幅を新しいスライド幅と元の幅の比率で掛けます。同様に、垂直座標と高さには対応する高さの比率を適用します。

最初の例では、テーブルを含まないスライドを持つプレゼンテーションを読み込み、スライドサイズを A4 に変更し、結果を保存します。これは、[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) を [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) と共に使用し、その後のループでスケーリングを制御します。比率は単位なしで、形状の位置とサイズはポイントで測定されます。幅と高さの比率が異なると形状が歪む可能性があり、形状のサイズを変更してもフォントサイズはスケールされません。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 横方向と縦方向の独立したスケール係数を計算します。
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
テーブルは別途処理が必要です。テーブル全体の幅と高さを割り当てるのではなく、列幅と行高さをスケールします。セルの内容が多い場合、要求された高さよりも行の高さが大きくなることがあります。
{{% /alert %}}

2 番目の例はテーブルをサポートし、リサイズされたプレゼンテーションを保存する前に、マスターやレイアウト、および個々のスライド上の形状を処理します。そのヘルパーは、各 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) を [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) と [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) をスケールすることで処理します。その後、テーブル全体のサイズを別途スケールせずに位置だけをスケールします。
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 横方向と縦方向の独立したスケール係数を計算します。
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// マスターとレイアウト、そして個々のスライドで定義された形状をリサイズします。
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
            // テーブルのサイズは列幅と行高さで制御されます。
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

**スライドのサイズ変更後に形状が歪んだり切り取られたりするのはなぜですか？**

形状をスケーリングせずにスライドサイズを変更すると、形状は元の位置とサイズのままでスライドの外にはみ出す可能性があります。幅と高さを異なる比率でスケーリングすると、形状が歪むこともあります。

**提供されたコードはすべての形状タイプで機能しますか？**

最初の例は形状の境界を直接変更し、テーブルのないスライドを対象としています。2 番目の例はテーブルを別途処理します。結果のレイアウト（特にテキストとテーブル）を確認してください。これらの例ではフォントサイズはスケールされず、テーブルの内容が行の高さを制約する可能性があります。

**スライドのサイズ変更時にテーブルのサイズを変更するにはどうすればよいですか？**

幅の比率で列幅を、高さの比率で最小行高さをスケールし、そしてテーブルの位置をスケールします（2 番目の例を参照）。

**このリサイズはマスタースライドやレイアウトスライドでも機能しますか？**

はい。2 番目の例は [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) と各マスターの [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) を反復し、形状に同じリサイズロジックを適用します。

**リサイズと同時にスライドの向き（縦向き/横向き）を変更できますか？**

はい。スライドサイズを変更した後、対象の寸法を取得する前に [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) を設定すると、スケール係数が最終的な向きを反映します。

**設定できるスライドサイズに上限はありますか？**

[SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) を使用してカスタムスライド寸法を指定できます。サポートされる寸法は、プレゼンテーション形式やファイルを開くアプリケーションにも依存します。

**固定アスペクト比の形状が歪むのを防ぐにはどうすればよいですか？**

幅と高さに同じスケール係数を使用します。元のレイアウトを新しいスライド寸法に収めるには、幅と高さの比率のうち小さい方を両方の寸法と位置に使用します。これにより比例は保たれますが、一方の端に未使用スペースが残る場合があります。