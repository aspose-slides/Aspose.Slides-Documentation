---
title: JavaScript でプレゼンテーションのシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/nodejs-java/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン作成
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- インタープ シェイプ ID の取得
- シェイプの代替テキスト
- シェイプのレイアウト書式
- SVG としてのシェイプ
- シェイプを SVG に変換
- シェイプの配置
- シェイプのフリップ
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、プレゼンテーション シェイプの識別、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップ方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java は、スライド上のシェイプを順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/) として表します。このコレクションはシェイプを検索・変更する場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最も背面のシェイプで、最後のインデックスが最前面のシェイプです。

この記事はそのモデルに従います。まずシェイプを確実に識別する方法を説明し、次にシェイプのクローン作成、削除、非表示、並び替えの方法を示します。最終セクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを利用できます。

## **シェイプの識別と検索**

コレクションのインデックスは既知のファイルを処理する際には便利ですが、安定した識別子ではありません。シェイプを追加、削除、または並び替えるとインデックスが変わります。プレゼンテーションの作成・管理方法に応じて識別子を選択してください：

- [Name](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getname/) は、開発者が管理するテンプレートに便利で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を策定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getalternativetext/) は、アクセシビリティ説明や作者が付与したタグですでにシェイプが識別されている場合に便利です。ユーザーに表示され、ローカライズやアクセシビリティ向けに書き換えられる可能性があり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして静かに再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint インタープで使用されるシェイプ ID に対応します。PowerPoint と統合する場合や、シェイプの存続期間中に曖昧でない参照が必要なときに使用してください。クローン化または再作成されたシェイプは別のシェイプとなり、独自の ID を持ちます。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getuniqueid/) メソッドはプレゼンテーション単位の識別子を返しますが、これはアドイン向けに設計されており再割り当てされる可能性があります。永続的な外部キーとして扱うべきではありません。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待するシェイプがまだ存在するか検証してください。

以下の例は名前で完全一致検索を行い、スライド単位のインタープ ID を報告します。テンプレートに期待するシェイプが存在しない場合、コードはその結果を報告し、誤ったオブジェクトで処理を続行しません。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

操作が特定のシェイプタイプに限定される場合、タイプ固有のメンバーを使用する前にランタイムクラスを確認してください。この例は、名前付きオブジェクトが [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) の場合にのみテキストと代替テキストを更新します。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **シェイプコレクションの変更**

add、clone、remove、reorder の各メソッドはコレクションに即座に作用します。操作によりシェイプの数や順序が変わった場合、事前に取得したインデックスに依存し続けないでください。

### **シェイプのクローン作成**

[addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/addclone/) は独立したコピーを作成し、対象コレクションに追加します。[insertClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標を受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはサイズも変更できます。

この例は宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。各クローンへの変更は元のシェイプを変更しません。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

クローンはシェイプの内容と書式設定（名前と代替テキストを含む）をコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複合シェイプが使用するリソースはプレゼンテーションが管理しますが、クローンは新しいシェイプ ID を持つ新規コレクション項目となります。

### **シェイプの削除**

[remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/remove/) は特定のシェイプオブジェクトをコレクションから削除します。インデックス付きイテレーション中に複数の一致を削除する場合、残りのインデックスが有効なままになるよう末尾から走査してください。

この例は指定された名前を持つすべてのシェイプを削除します。現在のインデックスのシェイプを取得し、特定のシェイプタイプを前提としません。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

削除後、シェイプ数と後続シェイプのインデックスが変わります。影響を受けないシェイプへの参照は、保存したインデックスよりも信頼性が高いです。また、コネクタやアニメーションなど、削除対象オブジェクトを参照する可能性のあるプレゼンテーション機能も考慮してください。可視シェイプを削除すると、スライドの見た目以外にも影響が出ることがあります。

### **シェイプの非表示**

[Hidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/sethidden/) を `true` に設定すると、シェイプはコレクション内に残りますが、通常のスライドショーには表示されません。インデックス、書式設定、コンテンツはコードから引き続き利用可能なため、後で復元できるオプション要素の非表示に適しています。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

非表示は削除やセキュリティを意味しません。オブジェクトはユーザーやコードによって検出・再表示が可能であり、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合うシェイプはコレクションの順序で描画されます。[reorder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/reorder/) は既存のシェイプをクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形は最初に作成され、最初は楕円の背面に配置されます。最終インデックスへ移動すると前面になります。関連シェイプをすべて追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上のシェイプの検査**

標準スライド、レイアウトスライド、マスタースライドはそれぞれ別個のシェイプコレクションを持ちます。レイアウトコレクション内のシェイプは、同じ位置にある標準スライドのシェイプと同一オブジェクトではありません。レイアウトが提供する書式設定を理解または変更する必要がある場合は、レイアウトシェイプを検査してください。

以下の例は、各レイアウトシェイプの [FillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getfillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getlineformat/) を取得しますが、すべてのシェイプが `AutoShape` であると仮定しません。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響を与える可能性があります。レイアウトシェイプを変更する前に、標準スライドがオブジェクトを継承しているかローカルで上書きしているかを確認し、そのレイアウトを使用しているすべてのスライドでテストしてください。

## **シェイプを SVG にエクスポート**

[writeAsSvg](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/writeassvg/) は単一シェイプのレンダリング結果をストリームに書き出します。出力にはシェイプ自体のみが含まれ、スライド全体の背景や隣接シェイプは含まれません。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力はシェイプの書式設定やフォント・画像などのリソースに依存します。全体の構成が必要な場合は、個別シェイプではなくスライド全体をエクスポートしてください。ストリームの所有権は呼び出し側にあり、使用後にクローズする必要があります。

## **シェイプの配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/alignshapes/) のオーバーロードは、すべてのシェイプまたは指定したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapesalignmenttype/) でエッジ、中心線、または配置モードを指定します。`alignToSlide` を `true` に設定するとスライドの端に合わせ、`false` に設定すると選択したシェイプ同士の相対位置で整列します。

この例は、3 つのシェイプをスライドの上端に揃えます。返されたシェイプ参照は、整列直前に現在のインデックスに変換されます。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

配置は位置を変更しますが、Z オーダーは変わりません。相対配置には通常少なくとも 2 つのシェイプが必要で、水平または垂直の均等配置には間隔を定義できるだけのシェイプが必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **シェイプのフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/nullablebool/) を使用し、`True` がフリップを有効、`False` が無効、`NotDefined` が未指定／デフォルト状態を保持します。

![フリップ前のシェイプ](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、2 つのフリップ設定のみを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/setframe/) を割り当てるとフレーム全体が置き換わるため、重要なポイントです。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたシェイプは位置、サイズ、回転を保持したまま水平・垂直に鏡像化されます。

![フリップ後のシェイプ](flipped_shape.png)

## **よくある質問**

**コレクションインデックスをシェイプの識別子として使用すべきでしょうか？**

コレクションがインデックス使用前に変更されない一時的な処理にのみ使用してください。作成されたテンプレートでは検証済みの `Name` または `AlternativeText` の規約を、スライド単位のインタープ作業では `OfficeInteropShapeId` を使用することを推奨します。

**シェイプを非表示にすると Z オーダーから削除されますか？**

いいえ。非表示のシェイプは同じインデックスでコレクションに残ります。検索、再配置、編集、または再表示が可能です。

**なぜクローンしたシェイプが別のシェイプの前に表示されたのでしょうか？**

`addClone` はクローンをコレクションの末尾に追加し、これが Z オーダーの前面になります。初期インデックスを指定したい場合は `insertClone` を使用するか、すべてのシェイプを追加した後に `reorder` してください。