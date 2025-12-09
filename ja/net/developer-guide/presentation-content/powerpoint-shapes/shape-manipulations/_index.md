---
title: .NET でプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/net/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形の複製
- 図形の削除
- 図形の非表示
- 図形の順序変更
- Interop 図形 ID の取得
- 図形の代替テキスト
- 図形のレイアウト形式
- SVG としての図形
- 図形を SVG に変換
- 図形の配置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で図形を作成、編集、最適化し、高パフォーマンスな PowerPoint プレゼンテーションを提供する方法を学びます。"
---

## **スライド内の図形を検索する**
このトピックでは、開発者がスライド上の特定の図形を内部 ID を使用せずに簡単に見つけられるシンプルな手法をご紹介します。PowerPoint プレゼンテーション ファイルでは、内部の一意 ID 以外にスライド上の図形を識別する方法がないことを知っておくことが重要です。開発者が内部の一意 ID を使用して図形を見つけることは困難なようです。スライドに追加されたすべての図形には Alt テキストが設定されています。開発者には、特定の図形を見つけるために代替テキストを使用することを推奨します。将来変更する予定のオブジェクトに対して、MS PowerPoint で代替テキストを定義できます。

任意の図形の代替テキストを設定した後、Aspose.Slides for .NET を使用してそのプレゼンテーションを開き、スライドに追加されたすべての図形を列挙できます。各イテレーションで図形の代替テキストを確認し、代替テキストが一致する図形が目的の図形となります。この手法をより分かりやすく示すために、スライド内の特定の図形を検索し、その図形を返すメソッド [FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) を作成しました。
```c#
public static void Run()
{
    // プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 検索対象の図形の代替テキスト
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// 代替テキストを使用してスライド内の図形を検索するメソッドの実装
public static IShape FindShape(ISlide slide, string alttext)
{
    // スライド内のすべての図形を反復処理しています
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // スライドの代替テキストが目的のものと一致する場合は
        // 図形を返します
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```


## **図形の複製**
Aspose.Slides for .NET を使用してスライドに図形を複製するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. 元スライドの図形コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. 元スライドの図形コレクションから新しいスライドへ図形を複製します。
1.変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ図形を追加します。
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


## **図形の削除**
Aspose.Slides for .NET では、任意の図形を削除できます。スライドから図形を削除するには、以下の手順に従ってください。

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つ図形を検索します。
1. 図形を削除します。
1. ファイルをディスクに保存します。
```c#
// プレゼンテーション オブジェクトを作成
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 四角形タイプのオートシェイプを追加
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


## **図形の非表示**
Aspose.Slides for .NET では、任意の図形を非表示にできます。スライドから図形を非表示にするには、以下の手順に従ってください。

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つ図形を検索します。
1. 図形を非表示にします。
1. ファイルをディスクに保存します。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成します
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
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// プレゼンテーションをディスクに保存
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```


## **図形の順序変更**
Aspose.Slides for .NET では、図形の順序を変更できます。順序の変更により、どの図形が前面にあるか、どの図形が背面にあるかを指定できます。スライド上の図形の順序を変更するには、以下の手順に従ってください。

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 図形を追加します。
1. 図形のテキストフレームにテキストを追加します。
1. 同じ座標で別の図形を追加します。
1. 図形の順序を変更します。
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


## **Interop 図形 ID の取得**
Aspose.Slides for .NET では、スライド単位の一意な図形識別子を取得できます。これは、プレゼンテーション単位の一意識別子を取得できる UniqueId プロパティとは対照的です。IShape インターフェイスと Shape クラスには OfficeInteropShapeId プロパティが追加されました。OfficeInteropShapeId プロパティが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// スライド スコープで一意の図形識別子を取得
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **図形の代替テキストの設定**
Aspose.Slides for .NET では、任意の図形の AlternateText を設定できます。プレゼンテーション内の図形は AlternativeText または Shape Name プロパティで識別できます。AlternativeText プロパティは Aspose.Slides および Microsoft PowerPoint の両方で読み取りおよび設定できます。このプロパティを使用すると、図形にタグを付けて、図形の削除、非表示、スライド上での順序変更といったさまざまな操作を実行できます。図形の AlternateText を設定するには、以下の手順に従ってください。

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意の図形を追加します。
1. 新しく追加した図形で何らかの処理を行います。
1. 図形を走査して対象の図形を検索します。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```c#
// PPTX を表す Presentation クラスをインスタンス化
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


## **図形のレイアウト形式へのアクセス**
Aspose.Slides for .NET は、図形のレイアウト形式にアクセスするためのシンプルな API を提供します。本記事では、レイアウト形式へのアクセス方法を示します。
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


## **図形を SVG としてレンダリング**
現在、Aspose.Slides for .NET は図形を SVG としてレンダリングする機能をサポートしています。Shape クラスと IShape インターフェイスに WriteAsSvg メソッド（およびそのオーバーロード）が追加されました。このメソッドを使用すると、図形の内容を SVG ファイルとして保存できます。以下のコードスニペットは、スライド上の図形を SVG ファイルにエクスポートする方法を示しています。
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


## **図形の配置**
[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) のオーバーロードメソッドを使用すると、以下が可能です。

* スライドの余白に対して図形を配置できます。例 1 を参照してください。
* 図形同士を相対的に配置できます。例 2 を参照してください。

[ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) 列挙体は、利用可能な配置オプションを定義しています。

**Example 1**

この C# コードは、スライド上部の境界に沿ってインデックス 1,2,4 の図形を配置する方法を示しています。  
以下のソースコードは、スライド上部の境界にインデックス 1,2,4 の図形を配置します。
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


**Example 2**

この C# コードは、コレクション内の最下部の図形に対して、図形コレクション全体を配置する方法を示しています。
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **フリップ プロパティ**
In Aspose.Slides, the [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) class provides control over horizontal and vertical mirroring of shapes via its `FlipH` and `FlipV` properties. Both properties are of type [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/), allowing values of `True` to indicate a flip, `False` for no flip, or `NotDefined` to use default behavior. These values are accessible from a shape’s [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/). 

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) クラスが、`FlipH` および `FlipV` プロパティを通じて図形の水平・垂直ミラーリングを制御します。両プロパティは [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 型で、`True` はフリップ、`False` はフリップなし、`NotDefined` はデフォルト動作を使用することを示します。これらの値は図形の [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) から取得できます。

フリップ設定を変更するには、図形の現在の位置とサイズ、希望する `FlipH` と `FlipV` の値、回転角度を使用して新しい [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスを図形の [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) に割り当て、プレゼンテーションを保存すると、ミラー変換が適用され、出力ファイルに反映されます。

例として、最初のスライドにデフォルトのフリップ設定の単一図形が含まれる sample.pptx ファイルがあるとします。

![フリップ対象の図形](shape_to_be_flipped.png)

以下のコード例は、図形の現在のフリッププロパティを取得し、水平および垂直にフリップします。
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // 図形の水平フリップ プロパティを取得します。
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // 図形の垂直フリップ プロパティを取得します。
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


![フリップされた図形](flipped_shape.png)

## **FAQ**

**スライド上でデスクトップエディタのように図形を結合（合成/交差/減算）できますか？**

組み込みのブール演算 API はありません。Desiredなアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しい図形を作成し、元の図形をオプションで削除する方法があります。

**図形が常に「最前面」に表示されるようにスタック順序（z-order）を制御するにはどうすればよいですか？**

スライドの [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) コレクション内での挿入/移動順序を変更します。予測可能な結果を得るには、すべてのスライド変更が完了した後に z-order を最終決定してください。

**PowerPoint でユーザーが図形を編集できないように「ロック」できますか？**

はい。[shape-level protection flags](/slides/ja/net/applying-protection-to-presentation/)（例: 選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロック）を設定します。必要に応じて、マスターやレイアウトにも同様の制限を適用できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強力な保護が必要な場合は、[read-only recommendations or passwords](/slides/ja/net/password-protected-presentation/) などのファイルレベルの制限と組み合わせてください。