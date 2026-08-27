---
title: Java でプレゼンテーションのシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/java/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- Interop シェイプ ID の取得
- シェイプ代替テキスト
- シェイプ調整ポイント
- プリセットシェイプ調整
- シェイプジオメトリ
- シェイプレイアウト形式
- SVG としてのシェイプ
- シェイプを SVG に変換
- シェイプの配置
- シェイプのフリップ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、プレゼンテーションのシェイプを特定、調整、クローン、削除、非表示、再配置、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、スライド上のシェイプを順序付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/) として表します。コレクションはシェイプを検索・変更する場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面のシェイプで、最後のインデックスが最前面のシェイプです。

このドキュメントはそのモデルに従います。まずシェイプを確実に特定し、プリセット形状調整ポイントを変更する方法を説明し、次にシェイプのクローン作成、削除、非表示、再配置の方法を示します。最終セクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **シェイプの特定と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。シェイプの追加、削除、再配置によりインデックスは変わります。プレゼンテーションの作成・保守方法に合わせて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getName--) は、開発者が管理するテンプレートに便利で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を確立してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getAlternativeText--) は、アクセシビリティ用の説明や作者が付与したタグですでにシェイプを識別できる場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ向けに書き換えられることがあり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして安易に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint のインタープリットで使用されるシェイプ ID に対応します。PowerPoint と連携する場合や、シェイプのライフタイム中に曖昧でない参照が必要な場合に使用してください。クローンや再作成されたシェイプは別のシェイプとなり、独自の ID が付与されます。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getUniqueId--) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けで再割り当てされる可能性があるため、永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待するシェイプがまだ存在するか検証してください。

以下の例は名前で正確に比較検索し、スライドスコープのインタープリット ID を報告します。テンプレートに期待するシェイプが存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

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

シェイプの種類に固有の操作を行う場合は、型固有のメンバーを使用する前にインターフェイスを確認してください。この例は、名前付きオブジェクトが [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) である場合にのみテキストと代替テキストを更新します。

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

## **プリセット形状調整の特定と変更**

プリセットジオメトリシェイプは、角サイズ、矢印比率、弧角などの機能を制御する調整ポイントを公開できます。これらは読み取り専用の [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igeometryshape/#getAdjustments--) コレクションを通じてアクセスします。コレクション自体はシェイプから提供されますが、各 [IAdjustValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/) は変更可能な値を保持しています。

固定のコレクションインデックスのみに依存しないでください。調整項目を列挙し、読み取り専用の [getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#getType--) メソッドを調べます。このメソッドが返す [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapeadjustmenttype/) の値が、調整が何を制御するかを示します。読み取り専用の [getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#getName--) メソッドは追加の識別情報を提供し、同一の意味タイプが複数存在する場合に特に有用です。

調整の意味に合致した値設定メソッドを使用してください。

| 調整タイプ | 目的 | 変更する値 |
|---|---|---|
| `CornerSize` | 角丸のサイズ | [setRawValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | 矢尻の太さ | `setRawValue` |
| `ArrowheadLength` | 矢頭の長さ | `setRawValue` |
| `ArrowheadWidth` | 矢頭の幅 | `setRawValue` |
| `StartAngle` | 円弧または扇形の開始角度 | [setAngleValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | 円弧または扇形の終了角度 | `setAngleValue` |

`getType` と `getName` は読み取り専用情報を返します。`getRawValue` と `setRawValue` はプリセットのネイティブジオメトリ単位の整数で動作し、`getAngleValue` と `setAngleValue` は度単位の角度で動作します。調整項目の数・順序・意味・有効範囲はプリセットの [ShapeType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igeometryshape/#getShapeType--) に依存します。あるプリセットで有効な値が、別のプリセットでは無効または異なる効果を持つことがあります。

`getType` が `ShapeAdjustmentType.Custom` を返す場合、API は標準的な意味を認識しません。`getName`、プリセットの種類、既存の値を調べ、期待する意味と範囲が分からない限り調整は変更しないでください。認識されたタイプであっても、同一タイプが複数回出現するかどうかを確認してから値を選択してください。[Connector](/slides/ja/java/connector/) 記事ではコネクタの曲げ調整でこの状況が示されています。

以下の完全な例は、3 つのプリセットシェイプのデフォルト版と変更版を作成します。すべての調整を列挙し、名前とタイプを報告し、サイズ関連の値は `setRawValue`、角度は `setAngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリを保持し、右列は調整された角丸長方形、四方向矢印、円弧を示します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // デフォルト列と調整列のヘッダーを追加します。
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

値を変更する前に意味タイプを確認することで、コードの意図が明確になり、異なるプリセットシェイプ間で同一インデックスが同じ意味を持つという仮定を防げます。

## **シェイプコレクションの変更**

add、clone、remove、reorder メソッドはコレクションに即座に作用します。操作によりシェイプの数や順序が変わる場合、操作前に取得したインデックスに依存し続けないでください。

### **シェイプのクローン作成**

[addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) は独立したコピーを作成し、対象コレクションの末尾に追加します。[insertClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標だけを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはサイズ変更も可能です。

この例は、宛先スライドを作成し、ラベル付き長方形を前面にクローンし、2 番目のクローンを背面に挿入します。どちらのクローンに対する変更も元シェイプには影響しません。

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

クローンはシェイプの内容と書式（名前と代替テキストも含む）をコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑なシェイプで使用されるリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しいシェイプ ID を持ちます。

### **シェイプの削除**

[remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) は特定のシェイプオブジェクトをコレクションから削除します。インデックスで反復しながら複数の一致を削除する場合は、インデックスが有効なままになるように末尾から走査してください。

この例は、指定された名前を持つすべてのシェイプを削除します。固定のコレクション項目ではなく、現在のインデックスのシェイプを取得し、不要なキャストは行いません。

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

削除後、シェイプ数と後続シェイプのインデックスが変わります。影響を受けないシェイプへの参照は、保存されたインデックスよりも信頼性が高いです。コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象オブジェクトを参照している可能性も考慮してください。可視シェイプを削除すると、スライドの見た目以上の影響が出ることがあります。

### **シェイプの非表示**

[Hidden](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setHidden-boolean-) を `true` に設定すると、シェイプはコレクションに残りますが、通常のスライドショーには表示されなくなります。インデックス、書式、コンテンツはコードから引き続き利用できるため、後で復元可能なオプション要素に適しています。

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

非表示は削除やセキュリティではありません。ユーザーやコードでオブジェクトを検出し、再表示することが可能であり、プレゼンテーションファイルの一部として残ります。

### **Z-Order の変更**

重なり合うシェイプはコレクション順に描画されます。[reorder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) は既存シェイプをクローンせずに対象インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

長方形は最初に作成され、最初は楕円の背面にあります。最終インデックスに移動させると前面に配置されます。すべての関連シェイプを追加またはクローンした後に Z オーダーを確定してください。これらの操作はコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上のシェイプを検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個のシェイプコレクションを持ちます。レイアウトコレクション内のシェイプは、通常スライド上の同位置シェイプと同一オブジェクトではありません。レイアウトが提供する書式を理解・変更する必要がある場合は、レイアウトシェイプを検査してください。

以下の例は、各レイアウトシェイプの [FillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getFillFormat--) と [LineFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getLineFormat--) を取得し、すべてのシェイプが `AutoShape` であるという前提を置きません。

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

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響を与える可能性があります。レイアウトシェイプを変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判断し、そのレイアウトを使用するすべてのスライドでテストしてください。

## **シェイプを SVG にエクスポート**

[writeAsSvg](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) は、単一シェイプの描画内容をストリームに書き出します。結果にはシェイプだけが含まれ、スライド全体の背景や隣接シェイプは含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力はシェイプの書式設定やフォント、画像などのリソースに依存します。全体の構成が必要な場合は、個別シェイプではなくスライド全体をエクスポートしてください。ストリームの所有権は呼び出し元にあり、必ずクローズする必要があります。

## **シェイプの配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) のオーバーロードは、すべてのシェイプまたは選択したコレクションインデックスを配置します。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapesalignmenttype/) はエッジ、中心線、または分布モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジに合わせ、`false` にすると選択シェイプ同士の相対位置で配置します。

この例は 3 つのシェイプをスライド上部のエッジに合わせます。返されたシェイプ参照は配置直前に現在のインデックスに変換されます。

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

配置は位置を変更しますが、Z オーダーは変わりません。相対配置は通常少なくとも 2 つのシェイプが必要で、水平または垂直の分布には間隔を定義できるだけのシェイプが必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **シェイプのフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/java/com.aspose.slides/nullablebool/) を使用し、`True` がフリップを有効にし、`False` が無効にし、`NotDefined` が未指定/既定状態を保持します。

以下の入力プレゼンテーションにはフリップされていないシェイプが1つ含まれています。

![フリップ前のシェイプ](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、2 つのフリップ設定だけを置き換えます。これは新しい [Frame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) を割り当てるとフレーム全体が置き換わるため重要です。

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

保存されたシェイプは位置、サイズ、回転を保持したまま、水平・垂直にミラーリングされます。

![フリップ後のシェイプ](flipped_shape.png)

## **FAQ**

**コレクションインデックスをシェイプの識別子として使用すべきでしょうか？**

短時間の処理でコレクションが変更されないことが保証される場合にのみ使用してください。作成されたテンプレートでは検証済みの `Name` または `AlternativeText` の命名規則を、スライドスコープのインタープリット作業では `OfficeInteropShapeId` を優先してください。

**シェイプを非表示にすると Z-Order から除外されますか？**

いいえ。非表示のシェイプは同じインデックスでコレクションに残り、検索、再配置、編集、再表示が可能です。

**クローンしたシェイプが別のシェイプの前に表示されたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z-Order の前面に相当します。初期インデックスを指定したい場合は `insertClone` を使用するか、すべてのシェイプ追加後に `reorder` で位置を調整してください。

**固定インデックスを使ってプリセット形状調整を特定できますか？**

正確なプリセットとコレクションレイアウトを検証した場合に限り可能です。`IGeometryShape.getAdjustments` を列挙し、`IAdjustValue.getType` を確認することを推奨します。同一の意味タイプが複数出現する場合は、追加情報として `IAdjustValue.getName` を使用してください。