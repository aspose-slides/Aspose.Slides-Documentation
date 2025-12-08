---
title: プレゼンテーションスライド上の形状リサイズ
type: docs
weight: 130
url: /ja/net/re-sizing-shapes-on-slide/
keywords:
- 形状のリサイズ
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

Aspose.Slides for .NET の顧客から最もよくある質問の一つは、スライドサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この短い技術記事では、そのやり方を示します。

## **シェイプのサイズ変更**

スライドサイズが変更されたときにシェイプがずれないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。
```c#
// プレゼンテーションファイルを読み込みます。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 元のスライドサイズを取得します。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 既存のシェイプをスケールせずにスライドサイズを変更します。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 新しいスライドサイズを取得します。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 各スライドのシェイプをリサイズおよび再配置します。
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // シェイプのサイズをスケールします。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // シェイプの位置をスケールします。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
スライドにテーブルが含まれている場合、上記のコードは正しく動作しません。その場合、テーブル内の各セルをサイズ変更する必要があります。
{{% /alert %}}

テーブルを含むスライドのサイズを変更するには、以下のコードを使用してください。テーブルの場合、幅や高さを設定するのは特別なケースであり、テーブル全体のサイズを変更するには個々の行の高さと列の幅を調整する必要があります。
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 元のスライドサイズを取得します。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 既存のシェイプをスケーリングせずにスライドサイズを変更します。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // 新しいスライドサイズを取得します。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // シェイプのサイズをスケールします。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // シェイプの位置をスケールします。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // シェイプのサイズをスケールします。
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // シェイプの位置をスケールします。
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // シェイプのサイズをスケールします。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // シェイプの位置をスケールします。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドのサイズを変更すると、スケールを明示的に変更しない限り、シェイプは元の位置とサイズのまま残ります。その結果、コンテンツが切り取られたりシェイプがずれたりします。

**提供されたコードはすべてのシェイプタイプで動作しますか？**

基本的な例は、テキストボックス、画像、チャートなど、ほとんどのシェイプタイプで機能します。ただし、テーブルの場合は、テーブルの高さと幅が個々のセルの寸法によって決まるため、行と列を個別に処理する必要があります。

**スライドのサイズ変更時にテーブルのサイズを変更するにはどうすればよいですか？**

テーブルのすべての行と列をループし、2番目のコード例に示すように高さと幅を比例して変更する必要があります。

**このサイズ変更はマスタースライドやレイアウトスライドでも機能しますか？**

はい、ただし、[Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) と [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) もループし、同じスケーリングロジックをそれらのシェイプに適用して、プレゼンテーション全体で一貫性を保つ必要があります。

**サイズ変更に加えてスライドの向き（縦向き/横向き）を変更できますか？**

はい。[presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) を設定して向きを変更できます。レイアウトを保つために、スケーリングロジックもそれに合わせて設定してください。

**設定できるスライドサイズに制限はありますか？**

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや一部の PowerPoint バージョンとの互換性に影響を与える可能性があります。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

スケーリングする前にシェイプの `AspectRatioLocked` プロパティを確認できます。ロックされている場合は、幅と高さを個別にスケーリングするのではなく、比例して調整してください。