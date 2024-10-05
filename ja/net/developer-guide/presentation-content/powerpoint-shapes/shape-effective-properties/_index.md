---
title: シェイプの効果的なプロパティ
type: docs
weight: 50
url: /net/shape-effective-properties/
keywords: "シェイププロパティ, カメラプロパティ, ライトリグ, ベベルシェイプ, テキストフレーム, テキストスタイル, フォントの高さ, テーブルの塗りつぶし形式, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにおける効果的なシェイププロパティを取得する"
---

このトピックでは、**効果的**および**ローカル**プロパティについて説明します。これらのレベルで値を直接設定した場合

1. ポーションのスライド上のポーションプロパティ。
2. レイアウトまたはマスタースライドのプロトタイプシェイプテキストスタイル（ポーションのテキストフレームシェイプに1つがある場合）。
3. プレゼンテーションのグローバルテキスト設定。

これらの値は**ローカル**値と呼ばれます。任意のレベルで、**ローカル**値は定義または省略できます。しかし、最終的にアプリケーションがポーションがどのように見えるべきかを知る必要がある瞬間が来たとき、それは**効果的**な値を使用します。**getEffective()**メソッドを使用してローカル形式から効果的な値を取得できます。

以下の例では、効果的な値を取得する方法を示します。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextFrameFormat localTextFrameFormat = shape.TextFrame.TextFrameFormat;
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

    IPortionFormat localPortionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.GetEffective();
}
```



## **カメラの効果的なプロパティを取得**
Aspose.Slides for .NETでは、開発者がカメラの効果的なプロパティを取得できます。この目的のために、**CameraEffectiveData**クラスがAspose.Slidesに追加されました。CameraEffectiveDataクラスは、効果的なカメラプロパティを含む不変オブジェクトを表します。**CameraEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値ペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

以下のコードサンプルでは、カメラの効果的なプロパティを取得する方法を示します。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= 効果的なカメラプロパティ =");
	Console.WriteLine("タイプ: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("視野角: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("ズーム: " + threeDEffectiveData.Camera.Zoom);
}
```


## **ライトリグの効果的なプロパティを取得**
Aspose.Slides for .NETでは、開発者がライトリグの効果的なプロパティを取得できます。この目的のために、**LightRigEffectiveData**クラスがAspose.Slidesに追加されました。LightRigEffectiveDataクラスは、効果的なライトリグプロパティを含む不変オブジェクトを表します。**LightRigEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値ペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

以下のコードサンプルでは、ライトリグの効果的なプロパティを取得する方法を示します。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= 効果的なライトリグプロパティ =");
	Console.WriteLine("タイプ: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("方向: " + threeDEffectiveData.LightRig.Direction);
}
```


## **ベベルシェイプの効果的なプロパティを取得**
Aspose.Slides for .NETでは、開発者がベベルシェイプの効果的なプロパティを取得できます。この目的のために、**ShapeBevelEffectiveData**クラスがAspose.Slidesに追加されました。ShapeBevelEffectiveDataクラスは、効果的なシェイプの表面の凹凸プロパティを含む不変オブジェクトを表します。**ShapeBevelEffectiveData**クラスのインスタンスは、ThreeDFormatクラスの効果的な値ペアである**ThreeDFormatEffectiveData**クラスの一部として使用されます。

以下のコードサンプルでは、ベベルシェイプの効果的なプロパティを取得する方法を示します。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= 効果的なシェイプの上面の凹凸プロパティ =");
	Console.WriteLine("タイプ: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("幅: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("高さ: " + threeDEffectiveData.BevelTop.Height);
}
```



## **テキストフレームの効果的なプロパティを取得**
Aspose.Slides for .NETを使用すると、テキストフレームの効果的なプロパティを取得できます。この目的のために、**TextFrameFormatEffectiveData**クラスがAspose.Slidesに追加され、効果的なテキストフレームの書式設定プロパティが含まれています。

以下のコードサンプルでは、効果的なテキストフレームの書式設定プロパティを取得する方法を示します。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("アンカリングタイプ: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("オートフィットタイプ: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("テキスト垂直タイプ: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("マージン");
	Console.WriteLine("   左: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   上: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   右: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   下: " + effectiveTextFrameFormat.MarginBottom);
}
```



## **テキストスタイルの効果的なプロパティを取得**
Aspose.Slides for .NETを使用すると、テキストスタイルの効果的なプロパティを取得できます。この目的のために、**TextStyleEffectiveData**クラスがAspose.Slidesに追加され、効果的なテキストスタイルプロパティが含まれています。

以下のコードサンプルでは、効果的なテキストスタイルのプロパティを取得する方法を示します。

```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= スタイルレベル #" + i + " の効果的な段落書式 =");

        Console.WriteLine("深さ: " + effectiveStyleLevel.Depth);
        Console.WriteLine("インデント: " + effectiveStyleLevel.Indent);
        Console.WriteLine("整列: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("フォントの整列: " + effectiveStyleLevel.FontAlignment);
    }
}

```


## **効果的なフォントの高さを取得**
Aspose.Slides for .NETを使用すると、フォントの高さの効果的なプロパティを取得できます。以下のコードは、異なるプレゼンテーション構造レベルでローカルフォントの高さ値を設定した後に、ポーションの効果的なフォントの高さ値が変わることを示しています。

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("最初のポーションのサンプルテキスト");
    IPortion portion1 = new Portion(" と2番目のポーション。");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("作成直後の効果的なフォントの高さ:");
    Console.WriteLine("ポーション #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("ポーション #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("プレゼンテーション全体のデフォルトフォントの高さを設定した後の効果的なフォントの高さ:");
    Console.WriteLine("ポーション #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("ポーション #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("段落のデフォルトフォントの高さを設定した後の効果的なフォントの高さ:");
    Console.WriteLine("ポーション #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("ポーション #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("ポーション #0のフォントの高さを設定した後の効果的なフォントの高さ:");
    Console.WriteLine("ポーション #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("ポーション #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("ポーション #1のフォントの高さを設定した後の効果的なフォントの高さ:");
    Console.WriteLine("ポーション #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("ポーション #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **テーブルの効果的な塗りつぶし形式を取得**
Aspose.Slides for .NETを使用すると、異なるテーブルの論理部分の効果的な塗りつぶしの書式設定を取得できます。この目的のために、**IFillFormatEffectiveData**インターフェースがAspose.Slidesに追加され、効果的な塗りつぶしの書式設定プロパティが含まれています。セルの書式設定は、常に行の書式設定よりも優先され、行は列よりも優先され、列は全体のテーブルよりも優先されます。

最終的に、**CellFormatEffectiveData**プロパティは、テーブルを描画するために常に使用されます。以下のコードサンプルでは、異なるテーブルの論理部分の効果的な塗りつぶしの書式設定を取得する方法を示します。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	ITable tbl = pres.Slides[0].Shapes[0] as ITable;
	ITableFormatEffectiveData tableFormatEffective = tbl.TableFormat.GetEffective();
	IRowFormatEffectiveData rowFormatEffective = tbl.Rows[0].RowFormat.GetEffective();
	IColumnFormatEffectiveData columnFormatEffective = tbl.Columns[0].ColumnFormat.GetEffective();
	ICellFormatEffectiveData cellFormatEffective = tbl[0, 0].CellFormat.GetEffective();

	IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.FillFormat;
	IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.FillFormat;
	IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.FillFormat;
	IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.FillFormat;
}
```