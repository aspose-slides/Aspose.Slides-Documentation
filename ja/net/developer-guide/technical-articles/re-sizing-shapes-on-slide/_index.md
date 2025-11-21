---
title: .NET のプレゼンテーション スライド上のシェイプサイズ変更
type: docs
weight: 130
url: /ja/net/re-sizing-shapes-on-slide/
keywords:
- シェイプのサイズ変更
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のスライド上のシェイプを簡単にサイズ変更し、スライドレイアウトの調整を自動化して生産性を向上させます。"
---

## **概要**

Aspose.Slides for .NET のお客様から最もよくある質問のひとつは、スライドサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この短い技術記事では、その手順を示します。

## **シェイプのサイズ変更**

スライドサイズが変更されたときにシェイプがずれないようにするには、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。
```c#
 // プレゼンテーション ファイルを読み込みます。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 元のスライドサイズを取得します。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 既存のシェイプをスケーリングせずにスライドサイズを変更します。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 新しいスライドサイズを取得します。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // すべてのスライドでシェイプのサイズと位置をリサイズします。
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
スライドにテーブルが含まれている場合、上記のコードは正しく動作しません。その場合は、テーブル内の各セルのサイズを変更する必要があります。
{{% /alert %}}

テーブルを含むスライドのサイズを変更するには、以下のコードを使用してください。テーブルの場合、幅または高さを設定するのは特別なケースであり、テーブル全体のサイズを変更するには個々の行の高さと列の幅を調整する必要があります。
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


## **FAQ**

**スライドのサイズ変更後にシェイプが歪んだり切り取られたりするのはなぜですか？**

スライドのサイズを変更すると、スケールが明示的に変更されない限り、シェイプは元の位置とサイズのままです。そのため、コンテンツが切り取られたりシェイプがずれたりすることがあります。

**提供されたコードはすべてのシェイプタイプで動作しますか？**

基本的な例はほとんどのシェイプタイプ（テキストボックス、画像、チャートなど）で機能します。ただし、テーブルの場合はセルごとのサイズがテーブル全体の幅と高さを決定するため、行と列を個別に処理する必要があります。

**スライドのサイズ変更時にテーブルのサイズを変更するにはどうすればよいですか？**

テーブルのすべての行と列をループし、2 番目のコード例に示すように高さと幅を比例して変更する必要があります。

**このサイズ変更はマスタースライドやレイアウトスライドでも機能しますか？**

はい、ただし [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) と [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) もループし、同じスケーリングロジックをシェイプに適用してプレゼンテーション全体の一貫性を保つ必要があります。

**スライドの向き（縦/横）もサイズ変更と同時に変更できますか？**

はい。[presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) を設定して向きを変更できます。レイアウトを保つためにスケーリングロジックも合わせて設定してください。

**設定できるスライドサイズに上限はありますか？**

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや一部の PowerPoint バージョンとの互換性に影響を与える可能性があります。

**固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？**

スケーリング前にシェイプの `AspectRatioLocked` プロパティを確認してください。ロックされている場合は、幅や高さを個別にスケーリングするのではなく、比例して調整します。