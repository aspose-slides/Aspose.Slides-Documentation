---
title: ".NETでプレゼンテーションチャートの書式設定"
linktitle: "チャートの書式設定"
type: docs
weight: 60
url: /ja/net/chart-formatting/
keywords:
- "チャートの書式設定"
- "チャートフォーマット"
- "チャートエンティティ"
- "チャートプロパティ"
- "チャート設定"
- "チャートオプション"
- "フォントプロパティ"
- "角丸境界線"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でのチャート書式設定を学び、プロフェッショナルで目を引くスタイリングにより PowerPoint プレゼンテーションを向上させましょう。"
---

## **チャート エンティティ の 書式設定**
Aspose.Slides for .NET は、開発者がスライドにカスタムチャートをゼロから追加できるようにします。この記事では、チャートのカテゴリ軸と値軸を含むさまざまなチャートエンティティの書式設定方法を説明します。

Aspose.Slides for .NET は、さまざまなチャートエンティティを管理し、カスタム値で書式設定するためのシンプルな API を提供します。

1. **Presentation** クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルト データを持つチャートを、目的のタイプのいずれかで追加します（この例では ChartType.LineWithMarkers を使用します）。
1. チャートの値軸にアクセスし、以下のプロパティを設定します。
   1. 値軸の主目盛線の **Line format** を設定する
   1. 値軸の副目盛線の **Line format** を設定する
   1. 値軸の **Number Format** を設定する
   1. 値軸の **Min, Max, Major and Minor units** を設定する
   1. 値軸データの **Text Properties** を設定する
   1. 値軸の **Title** を設定する
   1. 値軸の **Line Format** を設定する
1. チャートのカテゴリ軸にアクセスし、以下のプロパティを設定します。
   1. カテゴリ軸の主目盛線の **Line format** を設定する
   1. カテゴリ軸の副目盛線の **Line format** を設定する
   1. カテゴリ軸データの **Text Properties** を設定する
   1. カテゴリ軸の **Title** を設定する
   1. カテゴリ軸の **Label Positioning** を設定する
   1. カテゴリ軸ラベルの **Rotation Angle** を設定する
1. チャートの凡例にアクセスし、**Text Properties** を設定します。
1. チャートが重ならないように凡例を表示します。
1. チャートの **Secondary Value Axis** にアクセスし、以下のプロパティを設定します。
   1. **Secondary Value Axis** を有効にします
   1. Secondary Value Axis の **Line Format** を設定します
   1. Secondary Value Axis の **Number Format** を設定します
   1. Secondary Value Axis の **Min, Max, Major and Minor units** を設定します
1. 次に、First Chart Series を Secondary Value Axis にプロットします。
1. チャートの背面壁の塗りつぶし色を設定します。
1. チャートの描画領域の塗りつぶし色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。
```c#
// プレゼンテーションのインスタンス化// プレゼンテーションのインスタンス化
Presentation pres = new Presentation();

// Accessing the first slide
// 最初のスライドにアクセス
ISlide slide = pres.Slides[0];

// Adding the sample chart
// サンプルチャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// チャートタイトルを設定
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// 値軸の主目盛線の書式を設定
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// 値軸の副目盛線の書式を設定
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// 値軸の数値書式を設定
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// チャートの最大・最小値を設定
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// 値軸のテキストプロパティを設定
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// 値軸のタイトルを設定
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// 値軸の線書式を設定 : 現在は廃止予定
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// カテゴリ軸の主目盛線の書式を設定
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// カテゴリ軸の副目盛線の書式を設定
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// カテゴリ軸のテキストプロパティを設定
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// カテゴリタイトルを設定
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// カテゴリ軸ラベル位置を設定
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// カテゴリ軸ラベル回転角度を設定
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// 凡例のテキストプロパティを設定
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// 重なりのない凡例を表示

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// 第2軸に最初の系列をプロット
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// チャートの背面壁の色を設定
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// プロット領域の色を設定
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// プレゼンテーションを保存
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **チャートのフォント プロパティの設定**
Aspose.Slides for .NET は、チャートのフォント関連プロパティの設定をサポートしています。以下の手順に従ってチャートのフォントプロパティを設定してください。

- Presentation クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更したプレゼンテーションを保存します。

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **数値の書式設定**
Aspose.Slides for .NET は、チャート データの書式設定を管理するためのシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルト データを持つチャートを、目的のタイプのいずれかで追加します（この例では **ChartType.ClusteredColumn** を使用します）。
1. 利用可能なプリセット値から事前設定の数値書式を設定します。
1. 各チャート系列のチャート データ セルを走査し、数値書式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値書式を設定します。
1. 各チャート系列のチャート データ セルを走査し、異なる数値書式を設定します。
1. プレゼンテーションを保存します。
```c#
// プレゼンテーションをインスタンス化// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();

// 最初のプレゼンテーションスライドにアクセス
ISlide slide = pres.Slides[0];

// デフォルトのクラスター化列チャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// チャート系列コレクションにアクセス
IChartSeriesCollection series = chart.ChartData.Series;

// 事前設定の数値書式を設定
// すべてのチャート系列を走査
foreach (ChartSeries ser in series)
{
    // 系列内のすべてのデータセルを走査
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // 数値書式を設定
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// プレゼンテーションを保存
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


利用可能なプリセット数値書式のインデックスと値は以下のとおりです。

|**0**|全般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
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
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **チャート領域の角丸境界線の設定**
Aspose.Slides for .NET は、チャート領域の設定をサポートしています。**IChart.HasRoundedCorners** および **Chart.HasRoundedCorners** プロパティが Aspose.Slides に追加されました。

1. `Presentation` クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
1. 角丸プロパティを True に設定します。
1. 変更したプレゼンテーションを保存します。

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


## **FAQ**

**列/領域の半透明塗りつぶしを設定し、枠線を不透明に保つことはできますか？**

はい。塗りつぶしの透明度とアウトラインは別々に設定できます。これは、密集した可視化においてグリッドやデータの読みやすさを向上させるのに役立ちます。

**ラベルが重なる場合はどう対処すればよいですか？**

フォントサイズを小さくする、不要なラベル要素（例: カテゴリ）を無効にする、ラベルのオフセットや位置を設定する、必要に応じて選択されたポイントのみラベルを表示する、または書式を「値 + 凡例」に切り替えるなどの方法があります。

**シリーズにグラデーションまたはパターン塗りつぶしを適用できますか？**

はい。単色塗りつぶしと同様に、グラデーションやパターン塗りつぶしも利用できます。実際の使用では、グラデーションは控えめに使用し、グリッドやテキストとのコントラストを低下させる組み合わせは避けてください。