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
- 図形のクローン
- 図形の削除
- 図形の非表示
- 図形の順序変更
- Interop 図形 ID の取得
- 図形代替テキスト
- 図形レイアウト形式
- SVG としての図形
- 図形を SVG に変換
- 図形の整列
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で図形を作成、編集、最適化し、高性能な PowerPoint プレゼンテーションを提供する方法を学びます。"
---

## **スライド上の図形を検索する**
このトピックでは、開発者が内部 ID を使用せずにスライド上の特定の図形を見つけやすくするシンプルな手法を説明します。PowerPoint プレゼンテーション ファイルでは、スライド上の図形を識別できる手段は内部の一意 ID だけです。内部の一意 ID を使用して図形を見つけるのは開発者にとって困難です。スライドに追加されたすべての図形には代替テキストが設定されています。特定の図形を検索するために代替テキストの使用を推奨します。将来変更する予定のオブジェクトに対して、MS PowerPoint で代替テキストを定義できます。

任意の図形の代替テキストを設定した後、Aspose.Slides for .NET を使用してプレゼンテーションを開き、スライドに追加されたすべての図形を走査できます。各走査で図形の代替テキストを確認し、代替テキストが一致する図形が目的の図形になります。この手法をわかりやすく示すために、[FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1) メソッドを作成しました。このメソッドはスライド内の特定の図形を検索し、単にその図形を返します。
```c#
public static void Run()
{
    // プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
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
        
// 代替テキストを使用してスライド内の図形を検索するメソッド実装
public static IShape FindShape(ISlide slide, string alttext)
{
    // スライド内のすべての図形を反復処理する
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // スライドの代替テキストが要求されたものと一致する場合
        // 図形を返す
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```


## **図形をクローンする**
Aspose.Slides for .NET を使用して図形をスライドにクローンする手順:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソース スライドの図形コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソース スライドの図形コレクションから新しいスライドへ図形をクローンします。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ 図形を追加します。
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


## **図形を削除する**
Aspose.Slides for .NET では開発者は任意の図形を削除できます。スライドから図形を削除する手順は次のとおりです:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つ図形を検索します。
1. 図形を削除します。
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


## **図形を非表示にする**
Aspose.Slides for .NET では開発者は任意の図形を非表示にできます。スライドから図形を非表示にする手順は次のとおりです:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つ図形を検索します。
1. 図形を非表示にします。
1. ファイルをディスクに保存します。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();

// 最初のスライドを取得する
ISlide sld = pres.Slides[0];

// 矩形タイプのオートシェイプを追加する
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

// プレゼンテーションをディスクに保存する
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```


## **図形の順序を変更する**
Aspose.Slides for .NET では開発者は図形の順序を再配置できます。図形の再配置により、どの図形が前面にあるか、または背面にあるかを指定できます。スライド上の図形の順序を変更する手順は次のとおりです:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 図形を追加します。
1. 図形のテキスト フレームにテキストを追加します。
1. 同じ座標に別の図形を追加します。
1. 図形の順序を再配置します。
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


## **Interop 図形 ID を取得する**
Aspose.Slides for .NET では、プレゼンテーション スコープの UniqueId プロパティとは対照的に、スライド スコープで一意の図形識別子を取得できます。`OfficeInteropShapeId` プロパティが IShape インターフェイスと Shape クラスに追加されました。`OfficeInteropShapeId` プロパティが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// スライド スコープでの一意な図形識別子を取得
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```


## **図形の代替テキストを設定する**
Aspose.Slides for .NET では開発者は任意の図形の AlternateText を設定できます。プレゼンテーション内の図形は AlternativeText または Shape Name プロパティで識別できます。AlternativeText プロパティは Aspose.Slides と Microsoft PowerPoint の両方で読み取りおよび設定できます。このプロパティを使用すると、図形にタグを付け、図形の削除、非表示、スライド上での再配置などのさまざまな操作を実行できます。図形の AlternateText を設定する手順は次のとおりです:

1. `Presentation` クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 任意の図形をスライドに追加します。
1. 新しく追加した図形で作業を行います。
1. 図形を走査して対象の図形を見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```c#
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();

// 最初のスライドを取得する
ISlide sld = pres.Slides[0];

// 矩形タイプのオートシェイプを追加する
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

// プレゼンテーションをディスクに保存する
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```


## **図形のレイアウト形式にアクセスする**
Aspose.Slides for .NET は図形のレイアウト形式にアクセスするためのシンプルな API を提供します。この記事ではレイアウト形式へのアクセス方法を示します。

以下にサンプルコードを示します。
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


## **図形を SVG としてレンダリングする**
現在、Aspose.Slides for .NET は図形を SVG としてレンダリングする機能をサポートしています。`WriteAsSvg` メソッド（およびそのオーバーロード）が Shape クラスと IShape インターフェイスに追加されました。このメソッドにより、図形の内容を SVG ファイルとして保存できます。以下のコードスニペットは、スライド上の図形を SVG ファイルにエクスポートする方法を示しています。
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


## **図形を整列する**
[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index) のオーバーロード メソッドを使用すると、  

* スライドの余白に対して図形を整列できます。例 1 を参照してください。  
* 図形同士を相対的に整列できます。例 2 を参照してください。  

[ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype) 列挙体が利用可能な整列オプションを定義します。

**例 1**

この C# コードは、インデックス 1、2、4 の図形をスライド上部の境界に沿って整列させる方法を示します。  
以下のソースコードは、インデックス 1、2、4 の図形をスライド上部の境界に沿って整列させます。
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

この C# コードは、コレクション内のすべての図形をコレクション内の最下位図形に対して相対的に整列させる方法を示します:
``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```


## **反転プロパティ**

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) クラスが `FlipH` と `FlipV` プロパティを使用して図形の水平および垂直ミラーリングを制御します。両プロパティは [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 型で、`True` が反転、`False` が非反転、`NotDefined` がデフォルト動作を表します。これらの値は図形の [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) から取得できます。

反転設定を変更するには、図形の現在の位置とサイズ、目的の `FlipH` と `FlipV` の値、および回転角度で新しい [ShapeFrame](https://reference.aspose.com/slides/net/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスを図形の [Frame](https://reference.aspose.com/slides/net/aspose.slides/ishape/frame/) に割り当て、プレゼンテーションを保存すると、ミラー変換が適用され出力ファイルに反映されます。

例として、最初のスライドにデフォルトの反転設定が適用された単一の図形が含まれる sample.pptx ファイルがあるとします。

![反転される図形](shape_to_be_flipped.png)

以下のコード例は、図形の現在の反転プロパティを取得し、水平・垂直の両方で反転させます。
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
    NullableBool flipH = NullableBool.True; // 水平に反転します。
    NullableBool flipV = NullableBool.True; // 垂直に反転します。
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


結果:

![反転された図形](flipped_shape.png)

## **よくある質問**

**スライド上で図形を結合（union/intersect/subtract）できますか？**

組み込みのブール演算 API はありません。代わりに、目的のアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しい図形を作成し、元の図形を削除する方法があります。

**図形のスタック順序（z-order）を常に「最前面」に保つにはどうすればよいですか？**

スライドの [shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) コレクション内で挿入・移動順序を変更します。予測可能な結果を得るには、他のすべてのスライド変更が完了した後に z-order を最終決定してください。

**PowerPoint でユーザーが図形を編集できないように「ロック」できますか？**

はい。図形レベルの保護フラグを設定します（例: 選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロック）。必要に応じて、マスターやレイアウトでも同様の制限を設定できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強力な保護が必要な場合は、[読み取り専用の推奨やパスワード](/slides/ja/net/password-protected-presentation/) などのファイルレベルの制限と組み合わせてください。