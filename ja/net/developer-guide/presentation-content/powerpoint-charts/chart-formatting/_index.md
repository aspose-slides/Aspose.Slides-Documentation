---
title: チャートの書式設定
type: docs
weight: 60
url: /net/chart-formatting/
keywords: "チャートエンティティ, チャートプロパティ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーション内のチャートエンティティをフォーマットする"
---

## **チャートエンティティのフォーマット**
Aspose.Slides for .NET は、開発者がスライドにカスタムチャートをゼロから追加できるようにします。この記事では、チャートカテゴリおよび値軸を含む異なるチャートエンティティのフォーマット方法を説明します。

Aspose.Slides for .NET は、さまざまなチャートエンティティを管理し、カスタム値を使用してフォーマットするためのシンプルな API を提供します。

1. **Presentation** クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、任意の種類（この例では ChartType.LineWithMarkers を使用）を指定します。
1. チャートの値軸にアクセスし、以下のプロパティを設定します：
   1. 値軸の主要グリッド線の**線のフォーマット**を設定する
   1. 値軸のマイナーグリッド線の**線のフォーマット**を設定する
   1. 値軸の**数値形式**を設定する
   1. 値軸の**最小、最大、主要およびマイナー単位**を設定する
   1. 値軸データの**テキストプロパティ**を設定する
   1. 値軸の**タイトル**を設定する
   1. 値軸の**線のフォーマット**を設定する
1. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します：
   1. カテゴリ軸の主要グリッド線の**線のフォーマット**を設定する
   1. カテゴリ軸のマイナーグリッド線の**線のフォーマット**を設定する
   1. カテゴリ軸データの**テキストプロパティ**を設定する
   1. カテゴリ軸の**タイトル**を設定する
   1. カテゴリ軸の**ラベル位置**を設定する
   1. カテゴリ軸ラベルの**回転角度**を設定する
1. チャートの凡例にアクセスし、それらの**テキストプロパティ**を設定します
1. チャートが重ならないように凡例を表示します
1. チャートの**二次値軸**にアクセスし、以下のプロパティを設定します：
   1. 二次**値軸**を有効にする
   1. 二次値軸の**線のフォーマット**を設定する
   1. 二次値軸の**数値形式**を設定する
   1. 二次値軸の**最小、最大、主要およびマイナー単位**を設定する
1. これで、二次値軸に最初のチャート系列をプロットします
1. チャートの後面の壁の塗りつぶし色を設定します
1. チャートのプロット領域の塗りつぶし色を設定します
1. 修正されたプレゼンテーションを PPTX ファイルに書き込みます

```c#
// プレゼンテーションのインスタンス化
Presentation pres = new Presentation();

// 最初のスライドにアクセス
ISlide slide = pres.Slides[0];

// サンプルチャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// チャートタイトルの設定
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "サンプルチャート";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// 値軸の主要グリッド線のフォーマットを設定
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// 値軸のマイナーグリッド線のフォーマットを設定
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// 値軸の数値形式を設定
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// チャートの最大、最小値を設定
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// 値軸のテキストプロパティを設定
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// 値軸のタイトルを設定
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "プライマリ軸";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// カテゴリ軸の主要グリッド線のフォーマットを設定
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// カテゴリ軸のマイナーグリッド線のフォーマットを設定
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// カテゴリ軸のテキストプロパティを設定
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// カテゴリタイトルの設定
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "サンプルカテゴリ";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// カテゴリ軸のラベル位置を設定
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// カテゴリ軸のラベル回転角度を設定
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// 凡例のテキストプロパティを設定
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// チャートが重ならないように凡例を表示
chart.Legend.Overlay = true;

// 二次値軸に最初の系列をプロット
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// チャートの後面の壁の色を設定
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// プロット領域の色を設定
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// プレゼンテーションを保存
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **チャートのフォントプロパティを設定**
Aspose.Slides for .NET は、チャートのフォント関連のプロパティを設定するためのサポートを提供します。以下の手順に従って、チャートのフォントプロパティを設定してください。

- **Presentation** クラスオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```



## **数値の形式を設定**
Aspose.Slides for .NET は、チャートデータ形式を管理するためのシンプルな API を提供します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つチャートを追加し、任意の種類（この例では **ChartType.ClusteredColumn** を使用）を指定します。
1. 利用可能なプリセット値からプリセット数値形式を設定します。
1. 各チャート系列のチャートデータセルを移動し、チャートデータの数値形式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値形式を設定します。
1. 各チャート系列のチャートデータセル内を移動し、異なるチャートデータの数値形式を設定します。
1. プレゼンテーションを保存します。

```c#
// プレゼンテーションのインスタンス化
Presentation pres = new Presentation();

// 最初のプレゼンテーションスライドにアクセス
ISlide slide = pres.Slides[0];

// デフォルトの集合帯チャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// チャート系列コレクションにアクセス
IChartSeriesCollection series = chart.ChartData.Series;

// プリセット数値形式を設定
// 各チャート系列を移動
foreach (ChartSeries ser in series)
{
    // 系列内の各データセルを移動
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // 数値形式を設定
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// プレゼンテーションを保存
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

利用可能なプリセット数値形式の値とそのプリセットインデックスは以下の通りです：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;赤$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;赤$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;赤-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;赤-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **チャートエリアの角を丸める境界を設定**
Aspose.Slides for .NETは、チャートエリアを設定するサポートを提供します。**IChart.HasRoundedCorners** および **Chart.HasRoundedCorners** プロパティが Aspose.Slides に追加されました。

1. `Presentation` クラスオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します
1. ラウンドコーナーのプロパティを True に設定します。
1. 修正されたプレゼンテーションを保存します。

 以下にサンプル例を示します。 

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```