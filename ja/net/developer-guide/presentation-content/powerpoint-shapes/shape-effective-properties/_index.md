---
title: ".NET のプレゼンテーションからシェイプの実効プロパティを取得する"
linktitle: "実効プロパティ"
type: docs
weight: 50
url: /ja/net/shape-effective-properties/
keywords:
- "シェイプ プロパティ"
- "カメラ プロパティ"
- "ライトリグ"
- "ベベル シェイプ"
- "テキスト フレーム"
- "テキスト スタイル"
- "フォント 高さ"
- "塗りつぶし 書式"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET が正確な PowerPoint 表示のために実効シェイプ プロパティを計算し適用する方法を紹介します。"
---

このトピックでは、**effective** と **local** のプロパティについて説明します。これらのレベルで直接値を設定した場合

1. 部分スライド上の部分プロパティ。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプテキストスタイル（部分のテキストフレームシェイプにある場合）。
1. プレゼンテーション全体のテキスト設定。

これらの値は **local** 値と呼ばれます。任意のレベルで **local** 値は定義されても、されなくても構いません。しかし、アプリケーションが部分の表示を判断する必要がある瞬間には **effective** 値が使用されます。**effective** 値は、ローカルフォーマットから **getEffective()** メソッドを使用して取得できます。

以下の例は、effective 値の取得方法を示しています。
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


## **Get Effective Properties of a Camera**
Aspose.Slides for .NET は開発者がカメラの effective プロパティを取得できるようにします。そのために、Aspose.Slides に **CameraEffectiveData** クラスが追加されました。CameraEffectiveData クラスは、effective なカメラプロパティを保持する不変オブジェクトを表します。**CameraEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの effective 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

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


## **Get Effective Properties of a Light Rig**
Aspose.Slides for .NET は開発者が Light Rig の effective プロパティを取得できるようにします。そのために、Aspose.Slides に **LightRigEffectiveData** クラスが追加されました。LightRigEffectiveData クラスは、effective なライトリグプロパティを保持する不変オブジェクトを表します。**LightRigEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの effective 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

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


## **Get Effective Properties of a Bevel Shape**
Aspose.Slides for .NET は開発者がベベルシェイプの effective プロパティを取得できるようにします。そのために、Aspose.Slides に **ShapeBevelEffectiveData** クラスが追加されました。ShapeBevelEffectiveData クラスは、シェイプのフェイスリリーフプロパティを保持する不変オブジェクトを表します。**ShapeBevelEffectiveData** クラスのインスタンスは、ThreeDFormat クラスの effective 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、ベベルシェイプの effective プロパティを取得する方法を示しています。
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


## **Get Effective Properties of a Text Frame**
Aspose.Slides for .NET を使用すると、テキストフレームの effective プロパティを取得できます。そのために、Aspose.Slides に **TextFrameFormatEffectiveData** クラスが追加され、effective なテキストフレームの書式設定プロパティが含まれます。

以下のコードサンプルは、テキストフレームの effective 書式設定プロパティを取得する方法を示しています。
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


## **Get Effective Properties of a Text Style**
Aspose.Slides for .NET を使用すると、テキストスタイルの effective プロパティを取得できます。そのために、Aspose.Slides に **TextStyleEffectiveData** クラスが追加され、effective なテキストスタイルプロパティが含まれます。

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


## **Get the Effective Font Height Value**
Aspose.Slides for .NET を使用すると、フォント高さの effective プロパティを取得できます。以下は、異なるプレゼンテーション構造レベルでローカルフォント高さを設定した後に、部分の effective フォント高さが変化するコードです。
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


## **Get the Effective Fill Format for a Table**
Aspose.Slides for .NET を使用すると、テーブルのさまざまな論理パーツの effective 塗りつぶし書式を取得できます。そのために、Aspose.Slides に **IFillFormatEffectiveData** インターフェイスが追加され、effective な塗りつぶし書式プロパティが含まれます。セルの書式設定は常に行の書式設定より優先され、行は列より、列はテーブル全体より優先されることに注意してください。

したがって、最終的に **CellFormatEffectiveData** プロパティがテーブル描画に使用されます。以下のコードサンプルは、テーブルのさまざまな論理パーツの effective 塗りつぶし書式を取得する方法を示しています。
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


## **FAQ**

**How can I tell that I got a "snapshot" rather than a "live object," and when should I read effective properties again?**

EffectiveData オブジェクトは呼び出し時点の計算値の不変スナップショットです。シェイプのローカルまたは継承設定を変更した場合、再度 effective データを取得して更新された値を取得してください。

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

はい、ただし再度取得したときのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されません—レイアウトやマスタースライドを変更した後、再度要求してください。

**Can I modify values through EffectiveData?**

いいえ。EffectiveData は読み取り専用です。ローカル書式オブジェクト（シェイプ/テキスト/3D など）を変更し、必要に応じて再度 effective 値を取得してください。

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

effective 値はデフォルトメカニズム（PowerPoint/Aspose.Slides の既定値）によって決定されます。その解決された値が EffectiveData スナップショットの一部となります。

**From an effective font value, can I tell which level provided the size or typeface?**

直接は分かりません。EffectiveData は最終的な値を返します。ソースを特定するには、部分/段落/テキストフレームのローカル値や、レイアウト/マスター/プレゼンテーションのテキストスタイルを確認し、最初に明示的に定義された場所を探してください。

**Why do EffectiveData values sometimes look identical to the local ones?**

ローカル値が最終的な値となったためです（上位レベルからの継承が不要だった）。この場合、effective 値はローカル値と同一になります。

**When should I use effective properties, and when should I work only with local ones?**

すべての継承が適用された「実際に表示される」結果が必要な場合は EffectiveData を使用してください（例：色、インデント、サイズの調整）。特定のレベルで書式を変更したい場合はローカルプロパティを変更し、必要に応じて EffectiveData を再読み取りして結果を確認してください。