---
title: シェイプ操作
type: docs
weight: 40
url: /ja/net/shape-manipulations/
keywords: "PowerPoint シェイプ, スライド上のシェイプ, シェイプの検索, シェイプのクローン, シェイプの削除, シェイプの非表示, シェイプの順序変更, インターロップ シェイプ ID の取得, シェイプの代替テキスト, シェイプのレイアウト形式, SVG としてのシェイプ, シェイプの配置, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint シェイプを操作する"
---

## **スライド内のシェイプを検索**
このトピックでは、開発者が内部 Id を使用せずにスライド上の特定のシェイプを簡単に見つけるためのシンプルな手法を説明します。PowerPoint プレゼンテーション ファイルでは、内部の一意 Id 以外にスライド上のシェイプを識別する方法がありません。内部の一意 Id を使ってシェイプを見つけるのは開発者にとって難しいことがあります。スライドに追加されたすべてのシェイプは何らかの代替テキスト (Alt Text) を持ちます。開発者には、特定のシェイプを検索する際に代替テキストを使用することを推奨します。将来変更する可能性のあるオブジェクトの代替テキストは、MS PowerPoint で定義できます。

希望するシェイプの代替テキストを設定したら、Aspose.Slides for .NET を使用してプレゼンテーションを開き、スライドに追加されたすべてのシェイプを列挙できます。各イテレーションでシェイプの代替テキストを確認し、代替テキストが一致するシェイプが目的のシェイプになります。この手法をより分かりやすく示すために、スライド内の特定のシェイプを検索し、対象シェイプを返すメソッド [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) を作成しました。
```c#
public static void Run()
{
    // プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 見つけるシェイプの代替テキスト
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// スライド内で代替テキストを使用してシェイプを検索するメソッド実装
public static IShape FindShape(ISlide slide, string alttext)
{
    // スライド内のすべてのシェイプを反復処理
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // スライドの代替テキストが対象と一致する場合
        // シェイプを返す
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```


## **シェイプのクローン**
Aspose.Slides for .NET を使用してシェイプをスライドにクローンする手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドのシェイプ コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加するものです。
```c#
 // Presentation クラスをインスタンス化
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// PPTX ファイルをディスクに保存
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```


## **シェイプの削除**
Aspose.Slides for .NET では任意のシェイプを削除できます。スライドからシェイプを削除するには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。
```c#
// Presentation オブジェクトを作成
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 矩形タイプのオートシェイプを追加
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// プレゼンテーションをディスクに保存
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```


## **シェイプの非表示**
Aspose.Slides for .NET では任意のシェイプを非表示にできます。スライドからシェイプを非表示にするには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 長方形タイプのオートシェイプを追加
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// プレゼンテーションをディスクに保存
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```


## **シェイプの順序変更**
Aspose.Slides for .NET ではシェイプの順序を変更できます。順序を変更すると、どのシェイプが前面に、どのシェイプが背面にあるかが決まります。スライド上のシェイプの順序を変更するには、以下の手順に従ってください:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキスト フレームにテキストを追加します。
1. 同じ座標に別のシェイプを追加します。
1. シェイプの順序を変更します。
1. ファイルをディスクに保存します。
```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Interop シェイプ ID の取得**
Aspose.Slides for .NET では、プレゼンテーション スコープの UniqueId プロパティとは対照的に、スライド スコープで一意なシェイプ識別子を取得できます。`OfficeInteropShapeId` プロパティが `IShape` インターフェイスおよび `Shape` クラスに追加されました。`OfficeInteropShapeId` プロパティが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプル コードを示します。
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// スライドスコープ内で一意のシェイプ識別子を取得
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **シェイプの代替テキスト設定**
Aspose.Slides for .NET では任意のシェイプの AlternateText を設定できます。プレゼンテーション内のシェイプは AlternativeText または Shape Name プロパティで区別できます。AlternativeText プロパティは Aspose.Slides と Microsoft PowerPoint の両方で取得・設定可能です。このプロパティを使用すると、シェイプにタグを付けて、シェイプの削除、非表示、スライド上での順序変更などの操作を実行できます。シェイプの AlternateText を設定する手順は以下の通りです:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 任意のシェイプをスライドに追加します。
1. 新しく追加したシェイプで作業を行います。
1. シェイプを走査して目的のシェイプを見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 矩形タイプのオートシェイプを追加
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// プレゼンテーションをディスクに保存
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```


## **シェイプのレイアウト フォーマットへのアクセス**
Aspose.Slides for .NET はシェイプのレイアウト フォーマットにアクセスするためのシンプルな API を提供します。この記事ではレイアウト フォーマットへのアクセス方法を示します。

以下にサンプル コードを示します。
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```


## **シェイプを SVG としてレンダリング**
現在、Aspose.Slides for .NET はシェイプを SVG としてレンダリングする機能をサポートしています。`WriteAsSvg` メソッド（およびそのオーバーロード）が `Shape` クラスと `IShape` インターフェイスに追加されました。このメソッドにより、シェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
```c#
public static void Run()
{
    string outSvgFileName = "SingleShape.svg";
    using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
    {
        using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
        {
            pres.Slides[0].Shapes[0].WriteAsSvg(stream);
        }
    }
}
```


## **シェイプの配置**

[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) のオーバーロード メソッドを使用して、以下を実行できます

* スライドの余白に対してシェイプを配置する。例 1 を参照。
* シェイプ同士を相対的に配置する。例 2 を参照。

[ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) 列挙型は利用可能な配置オプションを定義します。

**例 1**

この C# コードは、インデックス 1、2、4 のシェイプをスライド上部の境界に沿って配置する方法を示します:
以下のソース コードは、インデックス 1、2、4 のシェイプをスライド上部の境界に沿って配置します。
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```


**例 2**

この C# コードは、コレクション内のすべてのシェイプをコレクション内の最下部シェイプに相対的に配置する方法を示します:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **フリップ プロパティ**

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) クラスが `FlipH` および `FlipV` プロパティを通じてシェイプの水平・垂直ミラーリングを制御します。両プロパティは [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 型で、`True` がフリップ、`False` がフリップなし、`NotDefined` がデフォルト動作を表します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、希望する `FlipH` と `FlipV` の値、回転角度を指定して新しい [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) に割り当て、プレゼンテーションを保存するとミラー変換が適用され、出力ファイルに反映されます。

例として、最初のスライドにデフォルトのフリップ設定のシェイプが 1 つだけ含まれる sample.pptx ファイルがあります。

![The shape to be flipped](shape_to_be_flipped.png)

以下のコード例はシェイプの現在のフリップ プロパティを取得し、水平・垂直の両方でフリップします。
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // シェイプの水平フリップ プロパティを取得します。
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // シェイプの垂直フリップ プロパティを取得します。
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // 水平にフリップします。
    NullableBool flipV = NullableBool.True; // 垂直にフリップします。
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


結果:

![The flipped shape](flipped_shape.png)

## **FAQ**

**スライド上でシェイプを結合（union/intersect/subtract）できますか？**

組み込みのブール演算 API はありません。Desiredなアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、元のシェイプをオプションで削除します。

**シェイプのスタック順序（z-order）を常に「最前面」に保つにはどうすればよいですか？**

スライドの [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のすべてのスライド変更が完了した後に z-order を最終決定してください。

**シェイプを「ロック」して PowerPoint でユーザーが編集できないようにできますか？**

できます。[shape-level protection flags](/slides/ja/net/applying-protection-to-presentation/)（例：選択、移動、サイズ変更、テキスト編集のロック）を設定します。必要に応じて、マスターやレイアウトでも制限を反映できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強固な保護が必要な場合は、[read-only 推奨やパスワード](/slides/ja/net/password-protected-presentation/) などのファイルレベルの制限と組み合わせてください。