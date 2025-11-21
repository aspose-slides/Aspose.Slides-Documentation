---
title: シェイプ操作
type: docs
weight: 40
url: /ja/nodejs-java/shape-manipulations/
---

## **スライド内のシェイプを検索**
このトピックでは、開発者がスライド上の特定のシェイプを内部 Id を使用せずに見つけやすくするためのシンプルなテクニックを説明します。PowerPoint プレゼンテーション ファイルでは、スライド上のシェイプを識別できるのは内部の一意な Id だけであることを理解しておくことが重要です。内部の一意な Id を使ってシェイプを見つけるのは開発者にとって難しい場合があります。スライドに追加されたすべてのシェイプには Alt Text が設定されています。開発者には、特定のシェイプを検索するために代替テキストを使用することを推奨します。将来変更する予定のオブジェクトの代替テキストは、MS PowerPoint で定義できます。

任意のシェイプの代替テキストを設定した後、Aspose.Slides for Node.js via Java を使用してそのプレゼンテーションを開き、スライドに追加されたすべてのシェイプを反復処理できます。各反復でシェイプの代替テキストを確認し、代替テキストが一致するシェイプが目的のシェイプになります。このテクニックをより分かりやすく示すために、スライド内の特定のシェイプを検索し、単にそのシェイプを返すメソッド [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) を作成しました。
```javascript
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 見つけるシェイプの代替テキスト
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **シェイプのクローン作成**
Aspose.Slides for Node.js via Java を使用してシェイプをスライドにクローンするには、次の手順を実行します。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. 元スライドのシェイプ コレクションにアクセスします。
1. プレゼンテーションに新しいスライドを追加します。
1. 元スライドのシェイプ コレクションから新しいスライドへシェイプをクローンします。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加します。
```javascript
// Presentation クラスをインスタンス化します
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // PPTX ファイルをディスクに保存します
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプの削除**
Aspose.Slides for Node.js via Java を使用すると、開発者は任意のシェイプを削除できます。スライドからシェイプを削除するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを削除します。
1. ファイルをディスクに保存します。
```javascript
// Presentation オブジェクトを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 矩形タイプのオートシェイプを追加
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // プレゼンテーションをディスクに保存
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプの非表示**
Aspose.Slides for Node.js via Java を使用すると、開発者は任意のシェイプを非表示にできます。スライドからシェイプを非表示にするには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. 特定の AlternativeText を持つシェイプを検索します。
1. シェイプを非表示にします。
1. ファイルをディスクに保存します。
```javascript
// PPTX を表す Presentation クラスのインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 矩形タイプのオートシェイプを追加
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // プレゼンテーションをディスクに保存
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプの順序変更**
Aspose.Slides for Node.js via Java を使用すると、開発者はシェイプの順序を変更できます。シェイプの順序変更により、どのシェイプが前面に、どのシェイプが背面にあるかが決まります。スライド上でシェイプの順序を変更するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. シェイプを追加します。
1. シェイプのテキスト フレームにテキストを追加します。
1. 同じ座標で別のシェイプを追加します。
1. シェイプの順序を変更します。
1. ファイルをディスクに保存します。
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Interop シェイプ ID の取得**
Aspose.Slides for Node.js via Java を使用すると、開発者はスライド スコープで一意のシェイプ識別子を取得できます。これは、プレゼンテーション スコープで一意の識別子を取得できる [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) メソッドとは対照的です。[getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) メソッドが [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) クラスに追加されました。[getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) メソッドが返す値は、Microsoft.Office.Interop.PowerPoint.Shape オブジェクトの Id の値に対応します。以下にサンプルコードを示します。
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // スライド スコープでの一意のシェイプ識別子を取得
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプの代替テキストの設定**
Aspose.Slides for Node.js via Java を使用すると、開発者は任意のシェイプに AlternateText を設定できます。プレゼンテーション内のシェイプは、[AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) または [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) メソッドで区別できます。[setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) および [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) メソッドは、Aspose.Slides と Microsoft PowerPoint のいずれでも読み取り・設定できます。このメソッドを使用すると、シェイプにタグを付け、シェイプの削除、非表示、スライド上での順序変更などのさまざまな操作を実行できます。シェイプの AlternateText を設定するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. スライドに任意のシェイプを追加します。
1. 新しく追加したシェイプで何らかの処理を行います。
1. シェイプを走査して目的のシェイプを見つけます。
1. AlternativeText を設定します。
1. ファイルをディスクに保存します。
```javascript
// PPTX を表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var sld = pres.getSlides().get_Item(0);
    // 矩形タイプのオートシェイプを追加
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // プレゼンテーションをディスクに保存
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプのレイアウト形式へのアクセス**
Aspose.Slides for Node.js via Java は、シェイプのレイアウト形式にアクセスするためのシンプルな API を提供します。本記事では、レイアウト形式へのアクセス方法を示します。

以下にサンプルコードを示します。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプを SVG としてレンダリング**
現在、Aspose.Slides for Node.js via Java はシェイプを SVG としてレンダリングする機能をサポートしています。[writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) メソッド（およびそのオーバーロード）が [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) クラスに追加されました。このメソッドにより、シェイプの内容を SVG ファイルとして保存できます。以下のコード スニペットは、スライドのシェイプを SVG ファイルにエクスポートする方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **シェイプの配置**
Aspose.Slides は、シェイプをスライドの余白に対して、または相互に対して配置することができます。そのために、オーバーロードされたメソッド [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) が追加されました。[ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) 列挙型は、可能な配置オプションを定義しています。

**Example 1**

以下のソースコードは、インデックス 1、2、4 のシェイプをスライドの上端に沿って配置します。
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Example 2**

以下の例は、コレクション内の最下部のシェイプに対して、シェイプ全体のコレクションを配置する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **フリップ プロパティ**
Aspose.Slides では、[ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) クラスが `flipH` および `flipV` プロパティを通じてシェイプの水平・垂直ミラーリングを制御します。両プロパティは `byte` 型で、`1` はフリップ、`0` はフリップなし、`-1` はデフォルト動作を使用することを示します。これらの値はシェイプの [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) から取得できます。

フリップ設定を変更するには、シェイプの現在の位置とサイズ、希望する `flipH` と `flipV` の値、回転角度を指定して新しい [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) インスタンスを作成します。このインスタンスをシェイプの [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) に割り当て、プレゼンテーションを保存すると、ミラー変換が適用され、出力ファイルに反映されます。

例えば、sample.pptx ファイルの最初のスライドにデフォルトのフリップ設定のシェイプが 1 つだけ含まれているとします。下図のようになります。

![The shape to be flipped](shape_to_be_flipped.png)

以下のコード例は、シェイプの現在のフリップ プロパティを取得し、水平および垂直の両方でフリップします。
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // シェイプの水平フリップ プロパティを取得します。
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // シェイプの垂直フリップ プロパティを取得します。
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Flip horizontally.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Flip vertically.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


![The flipped shape](flipped_shape.png)

## **FAQ**

**Can I combine shapes (union/intersect/subtract) on a slide like in a desktop editor?**  
デスクトップ エディタのようにスライド上でシェイプを結合（union/ intersect/ subtract）する組み込みのブール演算 API はありません。代わりに、目的のアウトラインを自分で構築することで近似できます。たとえば、[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) を使用して結果のジオメトリを計算し、その輪郭で新しいシェイプを作成し、必要に応じて元のシェイプを削除します。

**How can I control the stacking order (z-order) so a shape always stays "on top"?**  
スライドの [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) コレクション内で挿入順序や移動順序を変更します。予測可能な結果を得るには、他のすべてのスライド変更が完了した後に z‑order を最終的に設定します。

**Can I "lock" a shape to prevent users from editing it in PowerPoint?**  
はい。[shape-level protection flags](/slides/ja/nodejs-java/applying-protection-to-presentation/) を設定して、選択、移動、サイズ変更、テキスト編集などをロックできます。必要に応じて、マスターやレイアウトでも制限を反映できます。これは UI レベルの保護であり、セキュリティ機能ではありません。より強固な保護が必要な場合は、[read-only 推奨やパスワード](/slides/ja/nodejs-java/password-protected-presentation/) などのファイルレベルの制限と組み合わせて使用してください。