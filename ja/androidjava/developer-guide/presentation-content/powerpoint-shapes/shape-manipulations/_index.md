---
title: Android でプレゼンテーション シェイプを管理する
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
- シェイプの代替テキスト
- シェイプのレイアウト書式
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

## **スライド上のシェイプを検索する**
このトピックでは、開発者が内部 ID を使用せずにスライド上の特定のシェイプを簡単に見つけるためのシンプルな手法について説明します。PowerPoint プレゼンテーションファイルでは、内部の一意な ID 以外にスライド上のシェイプを識別する方法がありません。内部の一意な ID を使用してシェイプを見つけるのは開発者にとって困難なようです。スライドに追加されたすべてのシェイプには代替テキスト（Alt Text）が設定されています。開発者には特定のシェイプを検索するために代替テキストを使用することを推奨します。将来変更する予定のオブジェクトの代替テキストは、MS PowerPoint で定義できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for Android via Java を使用してそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを反復処理できます。各反復でシェイプの代替テキストを確認し、一致する代替テキストを持つシェイプが目的のシェイプとなります。この手法を分かりやすく示すために、[findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) メソッドを作成しました。このメソッドはスライド内の特定のシェイプを検索し、単にそのシェイプを返します。
```java
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します
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
// スライド内のシェイプを代替テキストで検索するメソッド実装
public static IShape findShape(ISlide slide, String alttext)
{
    // スライド内のすべてのシェイプを走査
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // スライドの代替テキストが要求されたものと一致した場合
        // シェイプを返す
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **シェイプをクローンする**
Aspose.Slides for Android via Java を使用してスライドにシェイプをクローンするには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドのシェイプコレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドのシェイプコレクションから新しいスライドへシェイプをクローンします。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例はスライドにグループシェイプを追加します。
```java
// Presentation クラスをインスタンス化
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX ファイルを書き込む
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプの削除**
Aspose.Slides for Android via Java は開発者が任意のシェイプを削除できるようにします。任意のスライドからシェイプを削除するには、以下の手順に従ってください：

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

    // 四角形タイプのオートシェイプを追加
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


## **シェイプの非表示**
Aspose.Slides for Android via Java は開発者が任意のシェイプを非表示にできるようにします。任意のスライドからシェイプを非表示にするには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```java
// PPTX を表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加
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


## **シェイプの順序変更**
Aspose.Slides for Android via Java は開発者がシェイプの順序を変更できるようにします。シェイプの順序変更により、どのシェイプが前面に、どのシェイプが背面にあるかを指定できます。任意のスライドでシェイプの順序を変更するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキストフレームにテキストを追加します。
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


## **Interop シェイプ ID の取得**
Aspose.Slides for Android via Java は、プレゼンテーション スコープで一意な識別子を取得できる [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) メソッドとは対照的に、スライド スコープで一意なシェイプ識別子を取得できるようにします。メソッド [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) は、[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) インターフェイスおよび [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // スライドスコープでの一意なシェイプ識別子を取得
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **シェイプの代替テキストを設定する**
Aspose.Slides for Android via Java は、任意のシェイプの AlternateText を設定できるようにします。プレゼンテーション内のシェイプは、[AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) または [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) メソッドで識別できます。[setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) および [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) メソッドは、Aspose.Slides と Microsoft PowerPoint の両方で読み書きできます。このメソッドを使用すると、シェイプにタグを付け、シェイプの削除、非表示、スライド上での順序変更などのさまざまな操作を実行できます。シェイプの AlternateText を設定するには、以下の手順に従ってください：

1. [Presentation] クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意のシェイプを追加します。
1. 新しく追加したシェイプで何らかの処理を行います。
1. シェイプを走査して目的のシェイプを検索します。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```java
// PPTX を表す Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 矩形タイプのオートシェイプを追加
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


## **シェイプのレイアウト書式にアクセスする**
Aspose.Slides for Android via Java は、シェイプのレイアウト書式にアクセスするためのシンプルな API を提供します。この記事では、レイアウト書式へのアクセス方法を示します。

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
現在、Aspose.Slides for Android via Java はシェイプを SVG としてレンダリングする機能をサポートしています。[writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) メソッド（およびオーバーロード）が [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) クラスと [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) インターフェイスに追加されました。このメソッドを使用すると、シェイプの内容を SVG ファイルとして保存できます。以下のコードスニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
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


## **シェイプの配置**
Aspose.Slides は、シェイプをスライドの余白に対してまたは互いに対して配置できるようにします。この目的のために、オーバーロードされたメソッド [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) 列挙体は、利用可能な配置オプションを定義します。

**Example 1**

以下のソースコードは、インデックス 1、2、4 のシェイプをスライドの上端に沿って配置します。
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


**Example 2**

以下の例は、コレクション内の最下部のシェイプに対して、全シェイプのコレクションを配置する方法を示します。
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **反転プロパティ**
Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) クラスが `flipH` および `flipV` プロパティを介してシェイプの水平・垂直ミラーリングを制御します。これらのプロパティは `byte` 型で、`1` は反転、`0` は非反転、`-1` はデフォルトの動作を示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) から取得できます。

反転設定を変更するには、シェイプの現在の位置とサイズ、希望する `flipH` と `flipV` の値、回転角度を指定して新しい [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) に設定し、プレゼンテーションを保存すると、ミラー変換が適用され、出力ファイルに反映されます。

例として、sample.pptx ファイルの最初のスライドにデフォルトの反転設定を持つ単一のシェイプがあるとします。以下に示す通りです。

![The shape to be flipped](shape_to_be_flipped.png)

以下のコード例は、シェイプの現在の反転プロパティを取得し、水平・垂直の両方で反転させます。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // シェイプの水平反転プロパティを取得します。
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // シェイプの垂直反転プロパティを取得します。
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // 水平に反転します。
    byte flipV = NullableBool.True; // 水平に反転します。
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**デスクトップ エディタのように、スライド上でシェイプを結合（ユニオン/インターセクト/サブトラクト）できますか？**  
組み込みのブール演算 API はありません。目的のアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、元のシェイプをオプションで削除します。

**シェイプが常に「最上位」にあるように、スタック順序（z-order）を制御するにはどうすればよいですか？**  
スライドの [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) コレクション内で挿入/移動順序を変更します。予測可能な結果を得るには、他のすべてのスライド変更が完了した後に z-order を最終決定してください。

**PowerPoint でユーザーがシェイプを編集できないように「ロック」できますか？**  
はい。シェイプレベルの保護フラグ（選択ロック、移動ロック、サイズ変更ロック、テキスト編集ロックなど）を設定します。必要に応じて、マスターやレイアウトに制限を反映させることもできます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強力な保護が必要な場合は、[読み取り専用の推奨やパスワード](/slides/ja/androidjava/password-protected-presentation/) などのファイルレベルの制限と組み合わせて使用してください。