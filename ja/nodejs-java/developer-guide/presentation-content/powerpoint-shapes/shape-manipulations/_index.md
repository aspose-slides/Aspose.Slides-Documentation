---
title: JavaScript でプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/nodejs-java/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- インタープリット図形 ID の取得
- 図形の代替テキスト
- 図形の調整ポイント
- プリセット図形の調整
- 図形ジオメトリ
- 図形レイアウト書式
- SVG としての図形
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、プレゼンテーション図形の識別、調整、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップ方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java は、スライド上の図形を順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/) として表します。コレクションは図形を検索・変更できる場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

この文章はそのモデルに従っています。まず図形を確実に識別し、プリセットの調整ポイントを変更する方法を説明し、次に図形の複製、削除、非表示、再配置の手順を示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定について解説します。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の識別と検索**

コレクションインデックスは既知のファイルを処理するときに便利ですが、安定した識別子ではありません。図形の追加・削除・再配置によりインデックスは変わります。プレゼンテーションの作成・保守方法に合わせて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getname/) は、開発者が管理するテンプレートで有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を設けてください。
- [AlternativeText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getalternativetext/) は、アクセシビリティ用の説明文や作者が付与したタグがすでに図形を特定している場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ用に書き換えられる可能性があるため、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint のインタープリットで使用される図形 ID と対応します。PowerPoint と連携する場合や、図形の存続期間中に曖昧さのない参照が必要な場合に使用してください。クローンや再作成された図形は別の図形となり、独自の ID が割り当てられます。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getuniqueid/) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けで再割り当てされる可能性があるため、永続的な外部キーとして扱うべきではありません。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待する図形が依然として存在するか検証してください。

以下の例は名前で完全一致検索を行い、スライドスコープのインタープリット ID を出力します。テンプレートに期待する図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

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

操作が特定の図形タイプに依存する場合、型固有メンバーを使用する前にランタイムクラスを確認してください。この例は、名前付きオブジェクトが [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) の場合にのみテキストと代替テキストを更新します。

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

## **プリセット図形の調整ポイントの識別と変更**

プリセットジオメトリ図形は、角のサイズや矢印の比率、円弧の角度などを制御する調整ポイントを公開しています。これらは読み取り専用の [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/geometryshape/) コレクションを通じて取得できます。コレクション自体は図形から提供されますが、各 [AdjustValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/) には変更可能な値が含まれます。

固定のコレクションインデックスだけに依存しないでください。調整項目を列挙し、読み取り専用の [getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/) メソッドで返される [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapeadjustmenttype/) が何を制御しているかを確認します。読み取り専用の [getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/getname/) メソッドは追加の識別情報を提供し、同一のセマンティックタイプが複数存在する場合に特に有用です。

調整の意味に合わせた値設定メソッドを使用してください。

| 調整タイプ | 用途 | 変更すべきメソッド |
|---|---|---|
| `CornerSize` | 角丸のサイズ | [setRawValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 矢じりの太さ | `setRawValue` |
| `ArrowheadLength` | 矢じりの長さ | `setRawValue` |
| `ArrowheadWidth` | 矢じりの幅 | `setRawValue` |
| `StartAngle` | パイまたは円弧の開始角度 | [setAngleValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | パイまたは円弧の終了角度 | `setAngleValue` |

`getType` と `getName` は読み取り専用情報を返します。`getRawValue` と `setRawValue` はプリセットのネイティブジオメトリ単位の整数で操作し、`getAngleValue` と `setAngleValue` は度数で角度を操作します。調整項目の数・順序・意味・有効範囲はプリセットの [GeometryShape.getShapeType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/geometryshape/) に依存します。あるプリセットで有効な値が別のプリセットでは無効、または異なる効果を持つことがあります。

`getType` が `ShapeAdjustmentType.Custom` を返す場合、API は標準的なセマンティック意味を認識していません。`getName`、プリセットタイプ、既存の値を確認し、期待する意味と範囲が分かっている場合以外は調整を変更しないでください。認識可能なタイプであっても、同一タイプが複数出現するかどうかを確認してから値を設定してください。コネクタの曲げ調整に関する例は [Connector](/slides/ja/nodejs-java/connector/) 記事で示されています。

以下の完全な例は、3 つのプリセット図形のデフォルト版と変更版を作成します。すべての調整項目を走査し、名前とタイプを報告し、サイズ関連の値は `setRawValue`、角度は `setAngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリ、右列は調整後の角丸矩形、四方向矢印、パイです。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // デフォルト列と調整済み列のヘッダーを追加します。
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

値を変更する前にセマンティックタイプを確認することで、コードの意図が明確になり、異なるプリセット図形間で同じコレクションインデックスが同一意味であると推測することを防げます。

## **Shape Collection の操作**

追加、クローン、削除、再配置のメソッドはコレクションに対して即座に作用します。操作により図形数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/addclone/) は独立したコピーを作成し、ターゲットコレクションの末尾に追加します。[insertClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標だけを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはサイズ変更も行います。

以下の例は目的スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。どちらのクローンに対する変更も元の図形を変更しません。

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

クローンは図形の内容と書式、名前、代替テキストまでコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複合図形が使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しい図形 ID を持ちます。

### **図形の削除**

[remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/remove/) は特定の図形オブジェクトをコレクションから削除します。インデックスで列挙しながら複数の一致を削除する場合は、インデックスが有効なままになるように末尾から走査してください。

この例は指定された名前を持つすべての図形を削除します。現在のインデックスの図形を取得し、特定の図形タイプを仮定しません。

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

削除後は図形数と後続図形のインデックスが変わります。影響を受けない図形への参照は保存したインデックスよりも信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除されたオブジェクトを参照している可能性があることに留意してください。可視図形を削除すると、スライドの外観以上の変化が起こることがあります。

### **図形の非表示**

[Hidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/sethidden/) を `true` に設定すると、図形はコレクションに残りますが通常のスライドショーには表示されません。インデックス、書式、コンテンツはコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

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

非表示は削除でもセキュリティでもありません。ユーザーやコードが発見・再表示でき、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合う図形はコレクション順に描画されます。[reorder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/reorder/) は既存の図形をクローンせずに対象インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

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

矩形は最初に作成され、当初は楕円の背面にあります。最終インデックスへ移動すると前面に表示されます。すべての関連図形を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変える可能性があります。

## **レイアウトスライド上の図形の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別々の図形コレクションを持ちます。レイアウトコレクション内の図形は、同じ位置にある通常スライドの図形とは別オブジェクトです。レイアウトが提供する書式を理解・変更する必要がある場合は、レイアウト図形を検査してください。

以下の例は、各レイアウト図形の [FillFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getfillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getlineformat/) を取得し、すべてが `AutoShape` であるとは限らないことを前提にしています。

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

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響します。レイアウト図形を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを確認し、レイアウトを使用するすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[writeAsSvg](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/writeassvg/) は単一の図形のレンダリング結果をストリームに書き出します。出力にはその図形だけが含まれ、スライド全体の背景や隣接図形は含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式やフォント、画像などのリソースに依存します。全体の構成が必要な場合は、個別の図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、クローズする必要があります。

## **図形の配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slideutil/alignshapes/) のオーバーロードは、すべての図形または選択したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapesalignmenttype/) は辺、中心線、または配布モードを指定します。`alignToSlide` を `true` にするとスライドの端に合わせ、`false` にすると選択した図形同士の相対位置で整列します。

この例は 3 つの図形をスライドの上端に揃えます。返された図形参照は整列直前に現在のインデックスへ変換されます。

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

配置は位置を変更しますが Z オーダー には影響しません。相対配置には通常最低 2 つの図形が必要で、水平または垂直の配布には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/nullablebool/) を使用し、`True` でフリップ、`False` で非フリップ、`NotDefined` で未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションはフリップされていない図形を 1 つだけ含みます。

![フリップ前の図形](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、フリップ設定のみを置き換えます。これは新しい [Frame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/setframe/) を割り当てるとフレーム全体が置き換えられるため重要です。

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

保存された図形は水平・垂直に鏡像化されますが、位置、サイズ、回転はそのままです。

![フリップ後の図形](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきですか？**

コレクションが変更されない短時間の処理でのみ使用してください。テンプレートが作者管理の場合は検証済みの `Name` または `AlternativeText` を、スライドスコープのインタープリット作業では `OfficeInteropShapeId` を優先してください。

**図形を非表示にすると Z オーダーから除外されますか？**

いいえ。非表示の図形は同じインデックスに残り、検索、再配置、編集、再表示が可能です。

**クローンした図形が別の図形の前に表示されたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの最前面です。初期インデックスを指定したい場合は `insertClone` を使用するか、すべての図形追加後に `reorder` で調整してください。

**プリセット図形の調整を固定インデックスで識別できますか？**

正確なプリセットとコレクション構成を検証した場合に限ります。通常は `GeometryShape.getAdjustments` を走査し、`AdjustValue.getType` を確認してください。同一のセマンティックタイプが複数存在する場合は `AdjustValue.getName` を付加情報として利用してください。