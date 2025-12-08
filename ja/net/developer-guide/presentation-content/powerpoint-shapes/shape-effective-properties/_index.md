---
title: シェイプの実効プロパティ
type: docs
weight: 50
url: /ja/net/shape-effective-properties/
keywords: "シェイプ プロパティ, カメラ プロパティ, ライトリグ, ベベル シェイプ, テキスト フレーム, テキスト スタイル, フォント 高さ 値, テーブル 用 塗りつぶし 書式, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションで C# または .NET を使用してシェイプの実効プロパティを取得する"
---

このトピックでは、**effective** と **local** プロパティについて説明します。これらのレベルで値を直接設定した場合

1. 部分のスライド上の部分プロパティで。
1. レイアウトまたはマスタースライド上のプロトタイプ形状テキストスタイルで（部分のテキストフレーム形状にある場合）。
1. プレゼンテーションのグローバルテキスト設定で。

これらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されても、されなくてもかまいません。しかし、最終的にアプリケーションが部分の表示を決定する必要がある時には **effective** 値が使用されます。**getEffective()** メソッドをローカルフォーマットから呼び出すことで、effective 値を取得できます。

以下の例は effective 値の取得方法を示しています。
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


## **カメラの Effective プロパティの取得**
Aspose.Slides for .NET は、開発者がカメラの effective プロパティを取得できるようにします。この目的のために、Aspose.Slides に **CameraEffectiveData** クラスが追加されました。CameraEffectiveData クラスは、effective カメラプロパティを含む不変オブジェクトを表します。**CameraEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの effective 値のペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、カメラの effective プロパティを取得する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective camera properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
	Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
	Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
}
```


## **ライトリグの Effective プロパティの取得**
Aspose.Slides for .NET は、開発者が Light Rig の effective プロパティを取得できるようにします。この目的のために、Aspose.Slides に **LightRigEffectiveData** クラスが追加されました。LightRigEffectiveData クラスは、effective ライトリグプロパティを含む不変オブジェクトを表します。**LightRigEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの effective 値のペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、Light Rig の effective プロパティを取得する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```


## **ベベル形状の Effective プロパティの取得**
Aspose.Slides for .NET は、開発者がベベル形状の effective プロパティを取得できるようにします。この目的のために、Aspose.Slides に **ShapeBevelEffectiveData** クラスが追加されました。ShapeBevelEffectiveData クラスは、effective な形状の面リリーフプロパティを含む不変オブジェクトを表します。**ShapeBevelEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの effective 値のペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、ベベル形状の effective プロパティを取得する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective shape's top face relief properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
	Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
	Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
}
```


## **テキストフレームの Effective プロパティの取得**
Aspose.Slides for .NET を使用すると、テキストフレームの effective プロパティを取得できます。この目的のために、Aspose.Slides に **TextFrameFormatEffectiveData** クラスが追加され、effective テキストフレーム書式プロパティを含みます。

以下のコードサンプルは、テキストフレームの effective 書式プロパティを取得する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

	ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;
	ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.GetEffective();


	Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
	Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
	Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
	Console.WriteLine("Margins");
	Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
	Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
	Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
	Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
}
```


## **テキストスタイルの Effective プロパティの取得**
Aspose.Slides for .NET を使用すると、テキストスタイルの effective プロパティを取得できます。この目的のために、Aspose.Slides に **TextStyleEffectiveData** クラスが追加され、effective テキストスタイルプロパティを含みます。

以下のコードサンプルは、テキストスタイルの effective プロパティを取得する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes[0] as IAutoShape;

    ITextStyleEffectiveData effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();

    for (int i = 0; i <= 8; i++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.GetLevel(i);
        Console.WriteLine("= Effective paragraph formatting for style level #" + i + " =");

        Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
        Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
        Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
        Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
    }
}
```


## **フォント高さの Effective 値の取得**
Aspose.Slides for .NET を使用すると、フォント高さの effective プロパティを取得できます。以下のコードは、プレゼンテーションのさまざまな構造レベルでローカルのフォント高さを設定した後に、部分の effective フォント高さの値が変化する様子を示しています。
```c#
using (Presentation pres = new Presentation())
{
    IAutoShape newShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    newShape.AddTextFrame("");
    newShape.TextFrame.Paragraphs[0].Portions.Clear();

    IPortion portion0 = new Portion("Sample text with first portion");
    IPortion portion1 = new Portion(" and second portion.");

    newShape.TextFrame.Paragraphs[0].Portions.Add(portion0);
    newShape.TextFrame.Paragraphs[0].Portions.Add(portion1);

    Console.WriteLine("Effective font height just after creation:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;

    Console.WriteLine("Effective font height after setting entire presentation default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 40;

    Console.WriteLine("Effective font height after setting paragraph default font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 55;

    Console.WriteLine("Effective font height after setting portion #0 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    newShape.TextFrame.Paragraphs[0].Portions[1].PortionFormat.FontHeight = 18;

    Console.WriteLine("Effective font height after setting portion #1 font height:");
    Console.WriteLine("Portion #0: " + portion0.PortionFormat.GetEffective().FontHeight);
    Console.WriteLine("Portion #1: " + portion1.PortionFormat.GetEffective().FontHeight);

    pres.Save("SetLocalFontHeightValues.pptx",SaveFormat.Pptx);
}
```


## **テーブルの Fill Format の Effective プロパティの取得**
Aspose.Slides for .NET を使用すると、テーブルのさまざまな論理パーツの effective 塗りつぶし書式を取得できます。この目的のために、Aspose.Slides に **IFillFormatEffectiveData** インターフェイスが追加され、effective 塗りつぶし書式プロパティを含みます。セルの書式設定は常に行の書式設定よりも優先度が高く、行は列よりも優先度が高く、列はテーブル全体よりも優先度が高いことに注意してください。

したがって最終的に、テーブルの描画には常に **CellFormatEffectiveData** プロパティが使用されます。以下のコードサンプルは、テーブルのさまざまな論理パーツの effective 塗りつぶし書式を取得する方法を示しています。
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


## **よくある質問**

**「スナップショット」か「ライブオブジェクト」かをどのように判別し、いつ effective プロパティを再取得すべきですか？**  
EffectiveData オブジェクトは、呼び出し時点で計算された値の不変のスナップショットです。形状のローカルまたは継承設定を変更した場合、再度 EffectiveData を取得して更新された値を取得してください。

**レイアウト／マスタースライドを変更すると、既に取得した effective プロパティに影響しますか？**  
はい、ただし再取得した後にのみ影響します。既に取得した EffectiveData オブジェクトは自動で更新されません。レイアウトやマスターを変更した後、再度取得してください。

**EffectiveData を通じて値を変更できますか？**  
いいえ。EffectiveData は読み取り専用です。ローカルの書式オブジェクト（shape、text、3D など）を変更し、必要に応じて再度 effective 値を取得してください。

**形状レベル、レイアウト／マスター、グローバル設定のいずれにもプロパティが設定されていない場合はどうなりますか？**  
effective 値はデフォルトメカニズム（PowerPoint / Aspose.Slides の既定値）により決定されます。その決定された値が EffectiveData のスナップショットに含まれます。

**effective フォント値から、どのレベルがサイズやフォント名を提供したか判別できますか？**  
直接的には判別できません。EffectiveData は最終的な値を返すだけです。元の設定箇所を特定するには、portion、paragraph、text frame のローカル値や、レイアウト／マスター／プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を探す必要があります。

**EffectiveData の値がローカルの値と同一に見えるのはなぜですか？**  
ローカル値が最終的な値となったためです（上位レベルからの継承が不要）。このような場合、effective 値はローカル値と同じになります。

**effective プロパティを使用すべきタイミングと、ローカルプロパティだけで作業すべきタイミングは？**  
すべての継承が適用された「実際に表示される」結果が必要な場合は EffectiveData を使用します（例：色、インデント、サイズの揃え等）。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて EffectiveData を再取得して結果を確認してください。