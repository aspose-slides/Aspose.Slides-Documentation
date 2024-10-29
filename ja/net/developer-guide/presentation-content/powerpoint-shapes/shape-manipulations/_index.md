---
title: シェイプ操作
type: docs
weight: 40
url: /ja/net/shape-manipulations/
keywords: "PowerPoint シェイプ, スライドのシェイプ, シェイプを見つける, シェイプをクローンする, シェイプを削除する, シェイプを隠す, シェイプの順序を変更する, インターロップシェイプIDを取得する, シェイプの代替テキスト, シェイプのレイアウト形式, SVGとしてのシェイプ, シェイプを整列する, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint シェイプを操作する"
---

## **スライド内のシェイプを見つける**
このトピックでは、開発者が内部IDを使用せずにスライド上の特定のシェイプを見つけるための簡単なテクニックについて説明します。PowerPointプレゼンテーションファイルは、内部の一意のIDを除いて、スライド上のシェイプを識別する方法がないことを知っておくことが重要です。開発者が内部の一意のIDを使用してシェイプを見つけるのは難しいようです。スライドに追加されたすべてのシェイプには何らかの代替テキストがあります。特定のシェイプを見つけるための代替テキストを使用することをお勧めします。将来的に変更する予定のオブジェクトの代替テキストを定義するには、MS PowerPointを使用できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for .NETを使用してそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを反復処理できます。各反復中に、シェイプの代替テキストを確認し、一致する代替テキストを持つシェイプが必要なシェイプになります。このテクニックをより良く示すために、特定のシェイプをスライドで見つけてそのシェイプを単純に返すメソッド、[FindShape](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/findshape/#findshape_1)を作成しました。

```c#
public static void Run()
{
    // プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // 見つけるシェイプの代替テキスト
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("シェイプ名: " + shape.Name);
        }
    }
}
        
// 代替テキストを使用してスライド内のシェイプを見つけるメソッドの実装
public static IShape FindShape(ISlide slide, string alttext)
{
    // スライド内のすべてのシェイプを反復処理
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // スライドの代替テキストが必要なテキストと一致する場合
        // シェイプを返す
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **シェイプをクローンする**
Aspose.Slides for .NETを使用してスライドにシェイプをクローンするには:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドのシェイプコレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドのシェイプコレクションから新しいスライドにシェイプをクローンします。
1. 変更したプレゼンテーションをPPTXファイルとして保存します。

以下の例は、スライドにグループシェイプを追加します。

```c#
// Presentationクラスをインスタンス化
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// PPTXファイルをディスクに書き込む
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **シェイプを削除する**
Aspose.Slides for .NETを使用すると、開発者は任意のシェイプを削除できます。スライドからシェイプを削除するには、以下の手順に従ってください。

1. `Presentation`クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の代替テキストを持つシェイプを見つけます。
1. シェイプを削除します。
1. ファイルをディスクに保存します。

```c#
// Presentationオブジェクトを作成
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 長方形タイプのオートシェイプを追加
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "ユーザー定義";
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



## **シェイプを隠す**
Aspose.Slides for .NETを使用すると、開発者は任意のシェイプを隠すことができます。スライドからシェイプを隠すには、以下の手順に従ってください。

1. `Presentation`クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の代替テキストを持つシェイプを見つけます。
1. シェイプを隠します。
1. ファイルをディスクに保存します。

```c#
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 長方形タイプのオートシェイプを追加
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "ユーザー定義";
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



## **シェイプの順序を変更する**
Aspose.Slides for .NETを使用すると、開発者はシェイプの順序を変更できます。シェイプの順序を変更すると、どのシェイプが最前面にあるか、どのシェイプが最背面にあるかを指定できます。スライドからシェイプの順序を変更するには、以下の手順に従ってください。

1. `Presentation`クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキストフレームにテキストを追加します。
1. 同じ座標のシェイプを別のシェイプとして追加します。
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
portion.Text="ウォーターマークテキスト ウォーターマークテキスト ウォーターマークテキスト";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **インターロップシェイプIDを取得する**
Aspose.Slides for .NETを使用すると、プレゼンテーションスコープのUniqueIdプロパティとは対照的に、スライドスコープ内のシェイプの一意の識別子を取得できます。OfficeInteropShapeIdプロパティは、IShapeインターフェースおよびShapeクラスに追加されました。OfficeInteropShapeIdプロパティによって返される値は、Microsoft.Office.Interop.PowerPoint.ShapeオブジェクトのIDの値に対応します。以下にサンプルコードを示します。

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// スライドスコープ内のユニークシェイプ識別子を取得
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **シェイプの代替テキストを設定する**
Aspose.Slides for .NETを使用すると、任意のシェイプのAlternateTextを設定できます。
プレゼンテーション内のシェイプは、AlternativeTextまたはShape Nameプロパティによって区別できます。
AlternativeTextプロパティは、Aspose.SlidesおよびMicrosoft PowerPointを使用して読み込みまたは設定できます。
このプロパティを使用することで、シェイプにタグを付けて、シェイプの削除、シェイプの隠蔽、スライド内のシェイプの順序変更などの異なる操作を実行できます。
シェイプのAlternateTextを設定するには、以下の手順に従ってください。

1. `Presentation`クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意のシェイプを追加します。
1. 新たに追加したシェイプで何らかの作業を行います。
1. シェイプを見つけるためにシェイプを走査します。
1. 代替テキストを設定します。
1. ファイルをディスクに保存します。

```c#
// PPTXを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 長方形タイプのオートシェイプを追加
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
        ashp.AlternativeText = "ユーザー定義";
    }
}

// プレゼンテーションをディスクに保存
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **シェイプのレイアウト形式にアクセスする**
Aspose.Slides for .NETは、シェイプのレイアウト形式にアクセスするためのシンプルなAPIを提供します。この記事では、レイアウト形式にアクセスする方法を示します。

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

## **シェイプをSVGとしてレンダリング**
Aspose.Slides for .NETは、シェイプをSVGとしてレンダリングする機能をサポートしています。WriteAsSvgメソッド（およびそのオーバーロード）がShapeクラスとIShapeインターフェースに追加されました。このメソッドを使用すると、シェイプの内容をSVGファイルとして保存できます。以下のコードスニペットは、スライドのシェイプをSVGファイルにエクスポートする方法を示しています。

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

## シェイプを整列させる

[SlidesUtil.AlignShape()](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/alignshapes/index)のオーバーロードメソッドを使用すると、

* スライドのマージンに対してシェイプを整列させることができます。例1を参照してください。
* お互いに対してシェイプを整列させることができます。例2を参照してください。

[ShapesAlignmentType](https://reference.aspose.com/slides/net/aspose.slides/shapesalignmenttype)列挙型は、利用可能な整列オプションを定義しています。

### 例1

このC#コードは、スライドの上部の境界に沿ってインデックス1、2、4のシェイプを整列させる方法を示しています：
以下のソースコードは、スライドの上部境界に沿ってインデックス1、2、4のシェイプを整列させます。

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

### 例2

このC#コードは、コレクション内の下部のシェイプに対してコレクション全体のシェイプを整列させる方法を示しています：

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```