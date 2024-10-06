---
title: 形状の操作
type: docs
weight: 40
url: /ja/java/shape-manipulations/
---

## **スライド内の形状を見つける**
このトピックでは、開発者が内部IDを使用せずにスライド上の特定の形状を見つけるための簡単な技術を説明します。PowerPointプレゼンテーションファイルには、内部のユニークIDを除いてスライド上の形状を識別する方法がないことを知っておくことが重要です。開発者が内部のユニークIDを使用して形状を見つけるのは難しいようです。スライドに追加されたすべての形状には一部の代替テキストがあります。特定の形状を見つけるために代替テキストを使用することを開発者に推奨します。将来変更する予定のオブジェクトの代替テキストを定義するには、MS PowerPointを使用できます。

所望の形状の代替テキストを設定した後、Aspose.Slides for Javaを使用してそのプレゼンテーションを開き、スライドに追加されたすべての形状を反復処理できます。各反復処理中に、形状の代替テキストを確認し、一致する代替テキストを持つ形状が必要な形状になります。この技術をより良く示すために、スライド内の特定の形状を見つけてその形状を単純に返すメソッド、[findShape](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)を作成しました。

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // 見つけるべき形状の代替テキスト
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("形状名: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 代替テキストを使用してスライド内の形状を見つけるメソッドの実装
public static IShape findShape(ISlide slide, String alttext)
{
    // スライド内のすべての形状を反復処理
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // スライドの代替テキストが必要なものと一致する場合
        // 形状を返す
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **形状を複製**
Aspose.Slides for Javaを使用してスライドに形状を複製するには：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. ソーススライドの形状コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. ソーススライドの形状コレクションから新しいスライドへ形状を複製します。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例は、スライドにグループ形状を追加します。

```java
// Presentationクラスのインスタンスを作成
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTXファイルをディスクに書き込む
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **形状を削除**
Aspose.Slides for Javaを使用すると、開発者は任意の形状を削除できます。任意のスライドから形状を削除するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の代替テキストを持つ形状を見つけます。
1. その形状を削除します。
1. ファイルをディスクに保存します。

```java
// Presentationオブジェクトを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "ユーザー定義";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (altText.equals(ashp.getAlternativeText()))
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

## **形状を隠す**
Aspose.Slides for Javaを使用すると、開発者は任意の形状を隠すことができます。任意のスライドから形状を隠すには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の代替テキストを持つ形状を見つけます。
1. その形状を隠します。
1. ファイルをディスクに保存します。

```java
// PPTXを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);

    // 長方形タイプのオートシェイプを追加
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "ユーザー定義";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (altText.equals(ashp.getAlternativeText()))
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

## **形状の順序を変更**
Aspose.Slides for Javaを使用すると、開発者は形状の順序を再配置できます。形状の順序を変更すると、どの形状が前面にあり、どの形状が背面にあるかを指定します。任意のスライドから形状の順序を再配置するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 形状を追加します。
1. 形状のテキストフレームにいくつかのテキストを追加します。
1. 同じ座標で別の形状を追加します。
1. 形状の順序を再配置します。
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
    portion.setText("透かしのテキスト 透かしのテキスト 透かしのテキスト");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Interop形状IDを取得**
Aspose.Slides for Javaでは、[getUniqueId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getUniqueId--)メソッドと対照的に、スライドスコープ内で一意の形状識別子を取得できます。このメソッドは、プレゼンテーションスコープ内で一意の識別子を取得することを許可します。[getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--)メソッドは、それぞれ[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)インターフェースと[Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape)クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getOfficeInteropShapeId--)メソッドによって返される値は、Microsoft.Office.Interop.PowerPoint.ShapeオブジェクトのIDの値に対応します。以下にサンプルコードを示します。

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // スライドスコープ内のユニーク形状識別子を取得
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **形状の代替テキストを設定**
Aspose.Slides for Javaは、任意の形状の代替テキストを設定することを許可します。
プレゼンテーション内の形状は、[AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-)または[Shape Name](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setName-java.lang.String-)メソッドによって区別できます。
[setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-)および[getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--)メソッドは、Aspose.Slidesを使用するか、Microsoft PowerPointを使用して読み取りまたは設定できます。
このメソッドを使用すると、形状にタグを付けさまざまな操作を実行できます。形状の削除、
形状の隠蔽やスライド上の形状の順序の変更などです。
形状の代替テキストを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意の形状を追加します。
1. 新しく追加された形状で何らかの作業を行います。
1. 形状を見つけるために形状を反復します。
1. 代替テキストを設定します。
1. ファイルをディスクに保存します。

```java
// PPTXを表すPresentationクラスのインスタンスを作成
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
            shape.setAlternativeText("ユーザー定義");
        }
    }

    // プレゼンテーションをディスクに保存
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **形状のレイアウト形式にアクセス**
Aspose.Slides for Javaは、形状のレイアウト形式にアクセスするためのシンプルなAPIを提供します。このコラムでは、レイアウト形式にアクセスする方法を示します。

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

## **SVGとして形状をレンダリング**
現在、Aspose.Slides for Javaは形状をSVGとしてレンダリングするサポートを提供します。[writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)（およびそのオーバーロード）メソッドが[Shape](https://reference.aspose.com/slides/java/com.aspose.slides/Shape)クラスおよび[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape)インターフェースに追加されました。このメソッドを使用すると、形状の内容をSVGファイルとして保存できます。以下のコードスニペットは、スライドの形状をSVGファイルにエクスポートする方法を示しています。

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

## **形状の整列**
Aspose.Slidesは、形状をスライドの余白に対してまたは互いに対して整列させることができます。この目的のために、オーバーロードされたメソッド[SlidesUtil.alignShape()](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/java/com.aspose.slides/ShapesAlignmentType)列挙型は、可能な整列オプションを定義します。

**例 1**

以下のソースコードは、インデックス1、2、4の形状をスライドの上端に沿って整列させます。

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
```

**例 2**

以下の例は、コレクション内の最下部の形状に対して形状全体を整列させる方法を示しています。

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```