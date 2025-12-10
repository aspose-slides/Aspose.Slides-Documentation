---
title: .NET のプレゼンテーション チャートでエラーバーをカスタマイズ
linktitle: エラーバー
type: docs
url: /ja/net/error-bar/
keywords:
- エラーバー
- カスタム値
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してチャートにエラーバーを追加・カスタマイズし、PowerPoint プレゼンテーションのデータ可視化を最適化する方法を学びます。"
---

## **エラーバーの追加**
Aspose.Slides for .NET はエラーバーの値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの **DataPoints** コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X 形式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y 形式を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。
```c#
// 空のプレゼンテーションを作成
using (Presentation presentation = new Presentation())
{
    // バブルチャートを作成
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // エラーバーを追加し、書式を設定
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // プレゼンテーションを保存
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **カスタムエラーバー値の追加**
Aspose.Slides for .NET はカスタムエラーバー値を管理するためのシンプルな API を提供します。サンプルコードは **IErrorBarsFormat.ValueType** プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの **DataPoints** コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブルチャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X 形式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y 形式を設定します。
1. チャート系列の個々のデータポイントにアクセスし、個々の系列データポイントのエラーバー値を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。
```c#
// 空のプレゼンテーションを作成
using (Presentation presentation = new Presentation())
{
    // バブルチャートを作成
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // カスタムエラーバーを追加し、その書式を設定
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // チャート系列のデータポイントにアクセスし、個々のポイントのエラーバー値を設定
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // チャート系列のポイントにエラーバーを設定
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // プレゼンテーションを保存
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**エラーバーはプレゼンテーションを PDF または画像にエクスポートした場合、どうなりますか？**

互換性のあるバージョンまたはレンダラが使用されている場合、エラーバーはチャートの一部として描画され、変換中にチャートの書式設定とともに保持されます。

**エラーバーはマーカーやデータ ラベルと組み合わせることができますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと互換性があります。要素が重なる場合は、書式設定を調整する必要がある場合があります。

**API でエラーバーを操作するためのプロパティと列挙体の一覧はどこで確認できますか？**

API リファレンスで確認できます：[ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) クラスと、関連する列挙体 [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/)。