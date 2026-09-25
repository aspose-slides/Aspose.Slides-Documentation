---
title: Android でプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/androidjava/shape-manipulations/
keywords:
- PowerPoint の図形
- プレゼンテーションの図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- インターロップ図形 ID の取得
- 図形の代替テキスト
- 図形の調整ポイント
- プリセット図形調整
- 図形ジオメトリ
- 図形レイアウト書式
- SVG としての図形
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、プレゼンテーションの図形を識別、調整、クローン作成、削除、非表示、再配置、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java は、スライド上の図形を順序付けられた[IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/)として表します。コレクションは図形の検索・変更の場所であると同時に、スタック順序の元でもあります：インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

本記事はそのモデルに従います。まず図形を確実に特定し、プリセットの形状調整ポイントを変更する方法を説明し、次に図形のクローン作成、削除、非表示、再配置の方法を示します。最終セクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。図形の追加、削除、再配置によりインデックスは変わります。プレゼンテーションの作成・保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getName--) は、開発者が管理するテンプレートで有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能で一意である保証はないため、コードが名前に依存する場合は命名規則を設定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getAlternativeText--) は、アクセシビリティ説明や作者が付与したタグで既に図形を特定できるときに有用です。ユーザーに表示され、ローカライズやアクセシビリティ向上のために書き換えられる可能性があり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint インターロップで使用される形状 ID に対応します。PowerPoint との統合や、図形の存続期間中に曖昧でない参照が必要な場合に使用してください。クローンや再作成された図形は別の図形となり、独自の ID を取得します。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getUniqueId--) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けで再割り当てされる可能性があります。永続的な外部キーとして扱うべきではありません。長期的な同一性が重要な場合は、アプリケーションデータにマッピングを保持し、期待する図形が依然として存在するか検証してください。

代替テキストのタイトルと説明の読み取り・更新の実用例については、[Manage Alternative Text Titles and Descriptions](/slides/ja/androidjava/presentation-accessibility/) を参照してください。代替テキストは視覚情報の意味を読者に説明するために使用し、コードが図形を検索する際に使用する名前とは別に管理します。

以下の例は名前で完全一致検索し、スライドスコープのインターロップ ID を報告します。テンプレートに期待する図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

操作が特定の図形タイプに限定される場合は、型固有メンバーを使用する前にインターフェイスを確認してください。この例は、対象オブジェクトが [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) である場合にのみテキストと代替テキストを更新します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **プリセット形状調整の識別と変更**

プリセットジオメトリ形状は、角のサイズ、矢尻の比率、円弧の角度などを制御する調整ポイントを公開することがあります。これらは読み取り専用の [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) コレクションを介してアクセスします。コレクション自体は形状側から提供されますが、各 [IAdjustValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/) が変更可能な値を保持しています。

固定インデックスにのみ依存しないでください。調整項目を走査し、読み取り専用の [getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#getType--) メソッドで返される [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapeadjustmenttype/) を確認します。この型は調整が何を制御するかを示します。読み取り専用の [getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#getName--) メソッドは追加の識別情報を提供し、同一の意味タイプが複数存在する場合に特に有用です。

調整の意味に合ったメソッドを使用してください。

| 調整タイプ | 目的 | 変更する値 |
|---|---|---|
| `CornerSize` | 角丸のサイズ | [setRawValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 矢じりの太さ | `setRawValue` |
| `ArrowheadLength` | 矢尻の長さ | `setRawValue` |
| `ArrowheadWidth` | 矢尻の幅 | `setRawValue` |
| `StartAngle` | 円弧やパイの開始角度 | [setAngleValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 円弧やパイの終了角度 | `setAngleValue` |

`getType` と `getName` は読み取り専用情報を返します。`getRawValue` と `setRawValue` はプリセット固有のジオメトリ単位の整数で動作し、`getAngleValue` と `setAngleValue` は度単位の角度で動作します。調整項目の数・順序・意味・有効範囲はプリセットの [ShapeType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igeometryshape/#getShapeType--) に依存します。あるプリセットで有効な値が別のプリセットでは無効または異なる効果になることがあります。

`getType` が `ShapeAdjustmentType.Custom` を返す場合、API は標準的な意味を認識していません。`getName`、プリセットタイプ、既存の値を確認し、期待する意味と範囲が判明していない限り調整は変更しないでください。認識された型でも、同一タイプが複数回出現するかどうかを確認してから値を選択してください。コネクタの曲げ調整に関する例は [Connector](/slides/ja/androidjava/connector/) 記事で確認できます。

以下の完全な例は 3 つのプリセット形状のデフォルト版と変更版を作成します。すべての調整項目を走査し、名前とタイプを報告し、サイズ関連の値は `setRawValue`、角度は `setAngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリ、右列は調整された角丸矩形、四方向矢印、円弧です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // デフォルトと調整された形状列のヘッダーを追加します。
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

値を変更する前に意味タイプを確認することで、コードの意図が明確になり、異なるプリセット形状間で同一インデックスが同じ意味を持つという前提を避けられます。

## **図形コレクションの変更**

追加、クローン、削除、再配置の各メソッドはコレクションに即座に作用します。操作により図形の数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) は独立したコピーを作成し、対象コレクションの末尾に追加します。[insertClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) もコピーを作成しますが、指定した Z 順序インデックスに配置します。座標だけを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅・高さを受け取るオーバーロードはリサイズも可能です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

クローンは形状の内容と書式、名前、代替テキストまでコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を付与してください。複合形状で使用されるリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目であり、新しい形状 ID を持ちます。

### **図形の削除**

[remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) は特定の図形オブジェクトをそのコレクションから削除します。インデックス付きで複数の一致項目を削除する場合は、末尾から逆順に走査して各残存インデックスが有効なままになるようにしてください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

削除後は図形数と後続図形のインデックスが変わります。影響を受けない図形への参照は保存されたインデックスよりも信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象オブジェクトを参照している可能性があるため、可視図形の削除はスライドの見た目以上の影響を及ぼすことがあります。

### **図形の非表示**

[Hidden](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) を `true` に設定すると、図形はコレクションに残りますが通常のスライドショーには表示されなくなります。インデックス、書式、内容はコードから引き続き利用可能なため、後で復元できるオプション要素に適しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

非表示は削除やセキュリティとは異なります。オブジェクトは依然として検出可能で、ユーザーやコードによって再表示でき、プレゼンテーションファイルの一部として残ります。

### **Z順序の変更**

重なり合う図形はコレクション順に描画されます。[reorder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) は既存の図形をクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形は最初に作成され、最初は楕円の背面にあります。最終インデックスへ移動させると前面に配置されます。関連するすべての図形を追加またはクローンした後に Z 順序を確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上の図形の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個の図形コレクションを持ちます。レイアウトコレクション内の図形は、通常スライド上の同位置の図形とは別オブジェクトです。レイアウトが提供する書式を理解または変更する必要があるときは、レイアウト図形を検査してください。

以下の例は各レイアウト図形の [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getFillFormat--) と [LineFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getLineFormat--) を取得し、すべてが `AutoShape` であると仮定せずに処理します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判定し、レイアウトを使用するすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[writeAsSvg](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) は単一の図形の描画結果をストリームに書き出します。出力には図形自体のみが含まれ、スライド全体の背景や隣接図形は含まれません。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式やフォント、画像といったリソースに依存します。全体の構成が必要な場合は、個々の図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じる責任があります。

## **図形の配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) のオーバーロードはすべての図形または選択したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapesalignmenttype/) は端、中心線、または分布モードを指定します。`alignToSlide` を `true` に設定するとスライドの端に合わせ、`false` に設定すると選択図形同士の相対位置で整列します。

以下の例は 3 つの図形をスライド上部の端に整列させます。返された図形参照は整列直前に現在のインデックスに変換されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

整列は位置を変更しますが Z 順序は変わりません。相対整列は通常少なくとも 2 つの図形が必要で、水平または垂直分布には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。`getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/nullablebool/) を使用し、`True` がフリップ有効、`False` が無効、`NotDefined` が未指定/デフォルト状態を保持します。

入力プレゼンテーションはフリップされていない図形が 1 つだけ含まれています。

![フリップ前の図形](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、フリップ設定のみを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) を割り当てるとフレーム全体が上書きされるため、注意が必要です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存された図形は水平・垂直に鏡像になり、位置、サイズ、回転はそのままです。

![フリップ後の図形](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきでしょうか？**

コレクションが操作前後で変わらない短期的な処理以外では使用しないでください。テンプレートが開発者管理の場合は検証済みの `Name` または `AlternativeText` 規約を、スライドスコープのインターロップ作業の場合は `OfficeInteropShapeId` を優先してください。

**図形を非表示にすると Z 順序から除外されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残り、検索、再配置、編集、再表示が可能です。

**クローンした図形が別の図形の前に表示されたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z 順序の前面に相当します。初期インデックスを指定したい場合は `insertClone` を使用するか、すべての図形を追加した後に `reorder` で調整してください。

**固定インデックスでプリセット形状調整を識別できますか？**

正確なプリセットとコレクション構造を検証した場合に限り可能です。通常は `IGeometryShape.getAdjustments` を走査し、`IAdjustValue.getType` を確認し、同一意味タイプが複数ある場合は `IAdjustValue.getName` を補助情報として使用してください。