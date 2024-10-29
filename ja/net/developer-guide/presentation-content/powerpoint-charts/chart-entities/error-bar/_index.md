---
title: エラーバー
type: docs
url: /ja/net/error-bar/
keywords: "エラーバー, エラーバー値, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにエラーバーを追加する"
---

## **エラーバーの追加**
Aspose.Slides for .NET では、エラーバー値を管理するためのシンプルな API を提供しています。サンプルコードは、カスタム値タイプを使用する場合に適用されます。値を指定するには、系列の **DataPoints** コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 希望のスライドにバブルチャートを追加します。
3. 最初のチャート系列にアクセスし、エラーバー X 形式を設定します。
4. 最初のチャート系列にアクセスし、エラーバー Y 形式を設定します。
5. バーの値と形式を設定します。
6. 修正されたプレゼンテーションを PPTX ファイルに書き込みます。

```c#
// 空のプレゼンテーションの作成
using (Presentation presentation = new Presentation())
{
    // バブルチャートの作成
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // エラーバーを追加し、その形式を設定
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

    // プレゼンテーションの保存
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **カスタムエラーバー値の追加**
Aspose.Slides for .NET では、カスタムエラーバー値を管理するためのシンプルな API を提供しています。サンプルコードは、**IErrorBarsFormat.ValueType** プロパティが **Custom** に等しい場合に適用されます。値を指定するには、系列の **DataPoints** コレクション内の特定のデータポイントの **ErrorBarCustomValues** プロパティを使用します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 希望のスライドにバブルチャートを追加します。
3. 最初のチャート系列にアクセスし、エラーバー X 形式を設定します。
4. 最初のチャート系列にアクセスし、エラーバー Y 形式を設定します。
5. チャート系列の個々のデータポイントにアクセスし、個々の系列データポイントのエラーバー値を設定します。
6. バーの値と形式を設定します。
7. 修正されたプレゼンテーションを PPTX ファイルに書き込みます。

```c#
// 空のプレゼンテーションの作成
using (Presentation presentation = new Presentation())
{
    // バブルチャートの作成
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // カスタムエラーバーを追加し、その形式を設定
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

    // チャート系列のポイントのエラーバーを設定
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // プレゼンテーションの保存
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```