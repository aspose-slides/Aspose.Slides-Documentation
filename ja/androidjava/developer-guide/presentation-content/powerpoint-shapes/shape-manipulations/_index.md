---
title: Android 用プレゼンテーション シェイプの管理
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/androidjava/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン
- シェイプの削除
- シェイプの非表示
- シェイプの順序変更
- Interop シェイプ ID の取得
- シェイプ代替テキスト
- シェイプのレイアウト形式
- SVG 形式のシェイプ
- シェイプを SVG に変換
- シェイプの配置
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でシェイプを作成、編集、最適化し、高性能な PowerPoint プレゼンテーションを提供する方法を学びます。"
---

## **スライド上のシェイプを見つける**
このトピックでは、開発者が内部 Id を使用せずにスライド上の特定のシェイプを簡単に見つけるためのシンプルな手法を説明します。PowerPoint プレゼンテーション ファイルは、内部の一意の Id 以外にスライド上のシェイプを識別する方法を持っていないことを知っておくことが重要です。内部の一意の Id を使用してシェイプを見つけるのは開発者にとって難しいことがあります。スライドに追加されたすべてのシェイプには Alt Text が設定されています。開発者には特定のシェイプを見つけるために代替テキストの使用を推奨します。将来変更する予定のオブジェクトの代替テキストは、MS PowerPoint で定義できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for Android via Java でプレゼンテーションを開き、スライドに追加されたすべてのシェイプを反復処理できます。各反復でシェイプの代替テキストを確認し、一致する代替テキストを持つシェイプが目的のシェイプとなります。この手法をより分かりやすく示すため、スライド内の特定のシェイプを見つけてそのシェイプを返すメソッド[findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)を作成しました。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    //    検索するシェイプの代替テキスト
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// スライド内のシェイプを代替テキストで検索するメソッド実装
public static IShape findShape(ISlide slide, String alttext)
{
    // スライド内のすべてのシェイプを反復処理
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // スライドの代替テキストが要求されたものと一致する場合
        // シェイプを返す
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **シェイプをクローンする**
Aspose.Slides for Android via Java を使用してシェイプをスライドにクローンする手順:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソース スライドのシェイプ コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソース スライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。
```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX ファイルをディスクに保存
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプを削除する**
Aspose.Slides for Android via Java は開発者に任意のシェイプを削除する機能を提供します。スライドからシェイプを削除するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。
```java
// Presentation オブジェクトを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプを非表示にする**
Aspose.Slides for Android via Java は開発者に任意のシェイプを非表示にする機能を提供します。スライドからシェイプを非表示にするには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプの順序を変更する**
Aspose.Slides for Android via Java は開発者にシェイプの順序変更を可能にします。シェイプの順序を変更すると、前面に表示するシェイプや背面に表示するシェイプを指定できます。スライド上のシェイプの順序を変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキスト フレームにテキストを追加します。
1. 同じ座標で別のシェイプを追加します。
1. シェイプの順序を変更します。
1. ファイルをディスクに保存します。
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Interop シェイプ ID を取得する**
Aspose.Slides for Android via Java は、[getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) メソッドがプレゼンテーション スコープで一意の識別子を取得できるのに対し、スライド スコープで一意のシェイプ識別子を取得できる機能を提供します。[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) インターフェイスと[Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) クラスにそれぞれ[ getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) メソッドが追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプル コードを示します。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // スライド スコープ内のユニークなシェイプ識別子を取得
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプの代替テキストを設定する**
Aspose.Slides for Android via Java は開発者が任意のシェイプの AlternateText を設定できるようにします。プレゼンテーション内のシェイプは[AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-)または[Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-)メソッドで区別できます。[setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-)および[getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) メソッドは、Aspose.Slides と Microsoft PowerPoint の両方で読み取りおよび設定できます。このメソッドを使用すると、シェイプにタグを付けて、シェイプの削除、非表示、スライド上のシェイプの順序変更などの操作を実行できます。シェイプの AlternateText を設定する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 任意のシェイプをスライドに追加します。
1. 追加したシェイプで作業を行います。
1. シェイプを走査して対象シェイプを見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```java
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプのレイアウト形式にアクセスする**
Aspose.Slides for Android via Java はシェイプのレイアウト形式にアクセスするためのシンプルな API を提供します。この記事ではレイアウト形式へのアクセス方法を示します。

以下にサンプル コードを示します。
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプを SVG としてレンダリングする**
Aspose.Slides for Android via Java はシェイプを SVG としてレンダリングする機能をサポートしています。メソッド[writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（およびそのオーバーロード）が[Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) クラスと[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) インターフェイスに追加されました。このメソッドを使用するとシェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示します。
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプを配置する**
Aspose.Slides はシェイプをスライドの余白に対してまたは相互に対して配置できます。この目的のために、オーバーロードされたメソッド[SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) 列挙体は可能な配置オプションを定義します。

**例 1**

以下のソースコードはインデックス 1、2、4 のシェイプをスライドの上端に沿って配置します。
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**例 2**

以下の例はコレクション内の最下部シェイプに対してコレクション全体を配置する方法を示します。
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **フリップ プロパティ**

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) クラスが `flipH` と `flipV` プロパティを使用したシェイプの水平および垂直ミラーリングを制御します。両プロパティは `byte` 型で、`1` がフリップ、`0` がフリップなし、`-1` がデフォルト動作を示します。これらの値はシェイプの[Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--)から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、希望する `flipH` と `flipV` の値、および回転角度で新しい[ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/)インスタンスを作成します。このインスタンスをシェイプの[Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--)に割り当て、プレゼンテーションを保存するとミラートランスフォーメーションが適用され、出力ファイルに反映されます。

以下のサンプルでは、最初のスライドにデフォルトのフリップ設定を持つ単一シェイプがある sample.pptx ファイルを使用します。

![The shape to be flipped](shape_to_be_flipped.png)

次のコード例はシェイプの現在のフリップ プロパティを取得し、水平および垂直にフリップします。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // シェイプの水平フリップ プロパティを取得します。
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // シェイプの垂直フリップ プロパティを取得します。
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // 水平にフリップします。
    byte flipV = NullableBool.True; // 水平にフリップします。
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The flipped shape](flipped_shape.png)

## **FAQ**

**スライド上でシェイプを結合（union/intersect/subtract）できますか？**

組み込みのブール演算 API はありません。代わりに、目的の輪郭を自分で構築して近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、元のシェイプを削除するといった方法です。

**シェイプを常に「最前面」に表示させるためのスタック順（z-order）を制御できますか？**

スライドの[shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のスライド変更がすべて完了した後に z-order を最終決定してください。

**PowerPoint でシェイプを「ロック」してユーザーが編集できないようにできますか？**

はい。シェイプレベルの保護フラグを設定します（例: 選択、移動、サイズ変更、テキスト編集のロック）。必要に応じてマスターやレイアウトでも同様の制限を適用できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強力な保護が必要な場合は、[読み取り専用推奨やパスワード](/slides/ja/androidjava/password-protected-presentation/) などのファイルレベルの制限と組み合わせて使用してください。