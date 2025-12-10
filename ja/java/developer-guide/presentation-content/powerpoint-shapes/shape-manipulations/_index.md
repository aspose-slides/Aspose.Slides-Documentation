---
title: Javaでプレゼンテーションのシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/java/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプを検索
- シェイプをクローン
- シェイプを削除
- シェイプを非表示
- シェイプの順序を変更
- Interop シェイプ ID を取得
- シェイプの代替テキスト
- シェイプのレイアウト フォーマット
- SVGとしてのシェイプ
- シェイプをSVGに変換
- シェイプを揃える
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でシェイプを作成、編集、最適化し、高性能な PowerPoint プレゼンテーションを提供する方法を学びます。"
---

## **スライド上でシェイプを検索する**
このトピックでは、開発者が内部 ID を使用せずにスライド上の特定のシェイプを見つけやすくするシンプルな手法について説明します。PowerPoint プレゼンテーション ファイルには、スライド上のシェイプを内部の一意 ID 以外で識別する方法がありません。内部の一意 ID を使用してシェイプを見つけるのは開発者にとって困難です。スライドに追加されたすべてのシェイプには代替テキストが設定されています。特定のシェイプを検索する際は、代替テキストを使用することを推奨します。将来変更する可能性のあるオブジェクトに対して、MS PowerPoint で代替テキストを設定できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for Java でプレゼンテーションを開き、スライドに追加されたすべてのシェイプを走査できます。走査中にシェイプの代替テキストを確認し、代替テキストが一致するシェイプが目的のシェイプになります。この手法をより分かりやすく示すために、スライド内の特定シェイプを検索し、単にそのシェイプを返すメソッド[findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)を作成しました。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // 検索対象シェイプの代替テキスト
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
// 代替テキストを使用してスライド内のシェイプを検索するメソッド実装
public static IShape findShape(ISlide slide, String alttext)
{
    // スライド内のすべてのシェイプをイテレートする
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
Aspose.Slides for Java を使用してシェイプをスライドにクローンする手順:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. ソーススライドのシェイプ コレクションにアクセスします。
1. 新しいスライドをプレゼンテーションに追加します。
1. ソーススライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX ファイルをディスクに書き込む
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプを削除する**
Aspose.Slides for Java では、開発者は任意のシェイプを削除できます。スライドからシェイプを削除するには、次の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。
```java
// Presentation オブジェクトを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加する
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

    // プレゼンテーションをディスクに保存する
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプを非表示にする**
Aspose.Slides for Java では、開発者は任意のシェイプを非表示にできます。スライドからシェイプを非表示にするには、次の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```java
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加する
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

    // プレゼンテーションをディスクに保存する
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプの順序を変更する**
Aspose.Slides for Java では、シェイプの順序を変更できます。シェイプの順序を変更すると、どのシェイプが前面に、どのシェイプが背面にあるかが決まります。スライド上のシェイプの順序を変更するには、次の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
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
Aspose.Slides for Java では、スライド スコープで一意のシェイプ識別子を取得できます。これは、プレゼンテーション スコープで一意の識別子を取得する[getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--)メソッドとは対照的です。[getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) メソッドが [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) インターフェイスと [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // スライドスコープで一意のシェイプ識別子を取得する
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプに代替テキストを設定する**
Aspose.Slides for Java では、任意のシェイプに AlternateText を設定できます。プレゼンテーション内のシェイプは、[AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) または [Shape Name](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-) メソッドで区別できます。[setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) と [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--) メソッドは、Aspose.Slides と Microsoft PowerPoint の両方で読み書きできます。このメソッドを使用するとシェイプにタグ付けでき、シェイプの削除、非表示、スライド上での順序変更などのさまざまな操作を実行できます。シェイプの AlternateText を設定する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 任意のシェイプをスライドに追加します。
1. 新しく追加したシェイプで作業を行います。
1. シェイプを走査して目的のシェイプを検索します。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```java
// PPTX を表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加する
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

    // プレゼンテーションをディスクに保存する
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプのレイアウト フォーマットにアクセスする**
Aspose.Slides for Java は、シェイプのレイアウト フォーマットにアクセスするシンプルな API を提供します。本記事では、レイアウト フォーマットへのアクセス方法を示します。

以下にサンプルコードを示します。
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
現在、Aspose.Slides for Java はシェイプを SVG としてレンダリングする機能をサポートしています。[writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（およびそのオーバーロード）メソッドが [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape) クラスと [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape) インターフェイスに追加されました。このメソッドにより、シェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示します。
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


## **シェイプを揃える**
Aspose.Slides では、シェイプをスライドの余白に対して、または互いに対して揃えることができます。そのために、オーバーロードされたメソッド[SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType) 列挙体は、利用可能な揃えオプションを定義します。

**例 1**

以下のソース コードは、インデックス 1、2、4 のシェイプをスライド上部の境界に揃えます。
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

次の例は、コレクション内の最下部シェイプに対して、コレクション全体を揃える方法を示しています。
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **フリップ プロパティ**

Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) クラスが `flipH` および `flipV` プロパティを通じてシェイプの水平・垂直ミラーリングを制御します。両プロパティは `byte` 型で、`1` がフリップ、`0` がフリップなし、`-1` がデフォルト 動作を示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、目的の `flipH` と `flipV` の値、および回転角度で新しい [ShapeFrame](https://reference.aspose.com/slides/java/com.aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getFrame--) に割り当て、プレゼンテーションを保存すると、ミラートランスフォーメーションが適用され、出力ファイルに反映されます。

たとえば、sample.pptx の最初のスライドにデフォルトのフリップ設定のシェイプが 1 つあるとします。以下の画像はその状態です。

![フリップ対象のシェイプ](shape_to_be_flipped.png)

次のコード例はシェイプの現在のフリップ プロパティを取得し、水平・垂直の両方でフリップします。
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
    byte flipH = NullableBool.True; // 水平に反転。
    byte flipV = NullableBool.True; // 水平に反転。
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![フリップされたシェイプ](flipped_shape.png)

## **FAQ**

**スライド上でシェイプを結合（union/intersect/subtract）できますか？**

組み込みのブーリアン演算 API はありません。代わりに、目的のアウトラインを自分で構築することで近似できます。たとえば、結果のジオメトリを計算し（[GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) を使用）、その輪郭で新しいシェイプを作成し、元のシェイプを削除するといった方法です。

**シェイプのスタック順序（z-order）を制御して常に「最前面」に表示させるには？**

スライドの [shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のスライド変更がすべて完了した後に z-order を最終決定してください。

**PowerPoint でシェイプを「ロック」してユーザーが編集できないようにできますか？**

できます。[shape-level protection flags](/slides/ja/java/applying-protection-to-presentation/)（選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロックなど）を設定します。必要に応じて、マスタやレイアウトでも同様の制限を適用できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強力な保護が必要な場合は、[読み取り専用推奨やパスワード](/slides/ja/java/password-protected-presentation/) などのファイルレベルの制限と組み合わせて使用してください。