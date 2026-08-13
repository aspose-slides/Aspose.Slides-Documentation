---
title: .NET でプレゼンテーションスライド上のシェイプをリサイズする
type: docs
weight: 130
url: /ja/net/re-sizing-shapes-on-slide/
keywords:
- シェイプのリサイズ
- シェイプサイズの変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument のスライド上のシェイプを簡単にリサイズできます—スライドレイアウトの調整を自動化し、生産性を向上させます。"
---
## **概要**

Aspose.Slides for .NET の顧客から最も頻繁に寄せられる質問の1つは、スライドのサイズが変更されたときにデータが切り取られないようにシェイプのサイズを変更する方法です。この記事では、その手順を短く示します。

## **シェイプのサイズ変更**

スライドサイズが変更された際にシェイプが位置ずれしないように、各シェイプの位置とサイズを新しいスライドレイアウトに合わせて更新します。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // すべてのスライドでシェイプのサイズと位置を変更します。
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

{{% alert color="info" %}}
スライドにテーブルが含まれている場合、上記のコードは正しく動作しません。その場合、テーブルの各セルをサイズ変更する必要があります。
{{% /alert %}}

テーブルを含むスライドをサイズ変更するには、以下のコードを使用してください。テーブルの場合、シェイプの幅と高さではなく、個々の行の高さと列の幅をスケーリングします。両方を適用するとテーブルが二重に拡大され、スライドからはみ出してしまいます。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
            // シェイプのサイズをスケーリングします。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // シェイプの位置をスケーリングします。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // シェイプのサイズをスケーリングします。
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // シェイプの位置をスケーリングします。
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // テーブルのサイズを行と列でスケーリングします。
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
            else
            {
                // シェイプのサイズをスケーリングします。
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // シェイプの位置をスケーリングします。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **よくある質問**

### スライドをリサイズした後、シェイプが歪んだり切り取られたりするのはなぜですか？

スライドのサイズを変更すると、スケールを明示的に変更しない限り、シェイプは元の位置とサイズを保持します。その結果、コンテンツが切り取られたり、シェイプが位置ずれしたりすることがあります。

### 提供されたコードはすべてのシェイプタイプで機能しますか？

基本的な例は、テキストボックス、画像、チャートなど、ほとんどのシェイプタイプで機能します。ただし、テーブルの場合は、テーブルの高さと幅が個々のセルのサイズで決まるため、行と列を個別に処理する必要があります。

### スライドをリサイズする際にテーブルのサイズを変更するにはどうすればよいですか？

テーブルのすべての行と列をループし、2番目のコード例に示すように高さと幅を比例的に変更する必要があります。

### マスタースライドやレイアウトスライドでもこのリサイズは機能しますか？

はい。ただし、プレゼンテーション全体の一貫性を保つために、[Masters](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/masters/) と [LayoutSlides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/layoutslides/) もループし、同じスケーリングロジックをそれらのシェイプに適用する必要があります。

### リサイズと同時にスライドの向き（縦/横）を変更できますか？

はい。向きを変更するには [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/ja/net/aspose.slides/islidesize/orientation/) を設定できます。レイアウトを維持するために、スケーリングロジックを適切に設定してください。

### 設定できるスライドサイズに制限はありますか？

Aspose.Slides はカスタムサイズをサポートしていますが、非常に大きなサイズはパフォーマンスや PowerPoint の一部バージョンとの互換性に影響を与える可能性があります。

### 固定アスペクト比のシェイプが歪むのを防ぐにはどうすればよいですか？

`AspectRatioLocked` プロパティをスケーリング前に確認できます。ロックされている場合は、個別にスケールするのではなく、幅または高さを比例的に調整してください。