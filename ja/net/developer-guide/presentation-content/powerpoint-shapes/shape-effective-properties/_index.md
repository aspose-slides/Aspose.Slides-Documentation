---
title: .NET のプレゼンテーションからシェイプの有効プロパティを取得
linktitle: 有効プロパティ
type: docs
weight: 50
url: /ja/net/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 形式
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が正確な PowerPoint のレンダリングのためにシェイプの有効プロパティを計算および適用する方法を紹介します。"
---

このトピックでは、**effective** プロパティと **local** プロパティについて説明します。これらのレベルで値を直接設定した場合

1. 部分のスライド上の portion プロパティで。
1. レイアウトまたはマスタースライド上のプロトタイプシェイプ テキストスタイルで (portion のテキストフレーム シェイプにそれがある場合)。
1. プレゼンテーション全体のテキスト設定で。

これらの値は **local** 値と呼ばれます。どのレベルでも **local** 値は定義されてもよく、省略されても構いません。しかし最終的にアプリケーションが部分の表示方法を知る必要があるときには **effective** 値が使用されます。**effective** 値は、ローカル フォーマットから **getEffective()** メソッドを呼び出すことで取得できます。

以下の例は **effective** 値の取得方法を示しています。
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




## **Get Effective Properties of Camera**
Aspose.Slides for .NET では、開発者はカメラの **effective** プロパティを取得できます。そのために **CameraEffectiveData** クラスが Aspose.Slides に追加されました。CameraEffectiveData クラスは、効果的なカメラ プロパティを保持する変更不可能なオブジェクトを表します。**CameraEffectiveData** のインスタンスは、ThreeDFormat クラスの **effective** 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、カメラの **effective** プロパティを取得する方法を示しています。
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



## **Get Effective Properties of Light Rig**
Aspose.Slides for .NET では、開発者は Light Rig の **effective** プロパティを取得できます。そのために **LightRigEffectiveData** クラスが Aspose.Slides に追加されました。LightRigEffectiveData クラスは、効果的なライトリグ プロパティを保持する変更不可能なオブジェクトを表します。**LightRigEffectiveData** のインスタンスは、ThreeDFormat クラスの **effective** 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、Light Rig の **effective** プロパティを取得する方法を示しています。
```c#
using (Presentation pres = new Presentation("Presentation1.pptx"))
{
	IThreeDFormatEffectiveData threeDEffectiveData = pres.Slides[0].Shapes[0].ThreeDFormat.GetEffective();

	Console.WriteLine("= Effective light rig properties =");
	Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
	Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
}
```



## **Get Effective Properties of Bevel Shape**
Aspose.Slides for .NET では、開発者はベベル シェイプの **effective** プロパティを取得できます。そのために **ShapeBevelEffectiveData** クラスが Aspose.Slides に追加されました。ShapeBevelEffectiveData クラスは、効果的なシェイプの表面リリーフ プロパティを保持する変更不可能なオブジェクトを表します。**ShapeBevelEffectiveData** のインスタンスは、ThreeDFormat クラスの **effective** 値ペアである **ThreeDFormatEffectiveData** クラスの一部として使用されます。

以下のコードサンプルは、ベベル シェイプの **effective** プロパティを取得する方法を示しています。
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




## **Get Effective Properties of Text Frame**
Aspose.Slides for .NET を使用すると、テキスト フレームの **effective** プロパティを取得できます。そのために **TextFrameFormatEffectiveData** クラスが Aspose.Slides に追加され、効果的なテキスト フレームの書式設定プロパティを保持します。

以下のコードサンプルは、テキスト フレームの書式設定 **effective** プロパティを取得する方法を示しています。
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




## **Get Effective Properties of Text Style**
Aspose.Slides for .NET を使用すると、テキスト スタイルの **effective** プロパティを取得できます。そのために **TextStyleEffectiveData** クラスが Aspose.Slides に追加され、効果的なテキスト スタイル プロパティを保持します。

以下のコードサンプルは、テキスト スタイルの **effective** プロパティを取得する方法を示しています。
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



## **Get Effective Font Height Value**
Aspose.Slides for .NET を使用すると、フォントの高さの **effective** プロパティを取得できます。以下のコードは、プレゼンテーション構造の異なるレベルでローカル フォント高さを設定した後に、部分の **effective** フォント高さがどのように変化するかを示しています。
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



## **Get Effective Fill Format for Table**
Aspose.Slides for .NET では、テーブルのさまざまな論理部位に対する **effective** 塗りつぶし書式を取得できます。そのために **IFillFormatEffectiveData** インターフェイスが Aspose.Slides に追加され、効果的な塗りつぶし書式プロパティを保持します。セルの書式設定は常に行の書式設定より優先され、行は列の書式設定より、列はテーブル全体の書式設定より優先されます。

したがって最終的には **CellFormatEffectiveData** のプロパティがテーブル描画に使用されます。以下のコードサンプルは、テーブルのさまざまな論理部位に対する **effective** 塗りつぶし書式を取得する方法を示しています。
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

EffectiveData オブジェクトは、呼び出し時点で計算された値の不変スナップショットです。シェイプのローカルまたは継承された設定を変更した場合は、再度 EffectiveData を取得して更新された値を取得してください。

**Does changing the layout/master slide affect effective properties that have already been retrieved?**

はい、ただし再取得した後にのみ反映されます。既に取得した EffectiveData オブジェクトは自動的に更新されません。レイアウトやマスターを変更したら、再度取得してください。

**Can I modify values through EffectiveData?**

できません。EffectiveData は読み取り専用です。ローカルの書式オブジェクト (shape/text/3D など) を変更し、必要に応じて再度 EffectiveData を取得して結果を確認してください。

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

そのプロパティの **effective** 値は、PowerPoint/Aspose.Slides のデフォルト設定に基づいて決定されます。決定されたデフォルト値が EffectiveData のスナップショットに含まれます。

**From an effective font value, can I tell which level provided the size or typeface?**

直接は分かりません。EffectiveData は最終的な値だけを返します。元の設定レベルを知りたい場合は、portion/paragraph/text frame のローカル値や、レイアウト/マスター/プレゼンテーションのテキスト スタイルを確認し、最初に明示的に定義された場所を特定してください。

**Why do EffectiveData values sometimes look identical to the local ones?**

ローカル値が最終的な値となり、上位レベルからの継承が必要なかった場合です。そのようなケースでは **effective** 値はローカル値と同一になります。

**When should I use effective properties, and when should I work only with local ones?**

すべての継承が適用された「実際に描画される」結果が必要なときは EffectiveData を使用します (例: 色、インデント、サイズの整合性確認)。特定のレベルで書式を変更したいときはローカル プロパティを操作し、必要に応じて EffectiveData を再取得して結果を検証してください。