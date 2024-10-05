---
title: チャートのエクスポート
type: docs
weight: 90
url: /net/export-chart/
keywords:
- チャート
- チャート画像
- チャート画像の抽出
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションからチャート画像を取得する"
---

## **チャート画像の取得**
Aspose.Slides for .NETは、特定のチャートの画像を抽出するサポートを提供します。以下にサンプル例を示します。

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```