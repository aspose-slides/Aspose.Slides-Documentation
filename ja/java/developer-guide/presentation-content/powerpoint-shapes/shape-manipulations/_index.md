---
title: Java でプレゼンテーション シェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/java/shape-manipulations/
keywords:
- PowerPoint シェイプ
- プレゼンテーション シェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン作成
- シェイプの削除
- シェイプの非表示
- シェイプ順序の変更
- Interop シェイプ ID の取得
- シェイプの代替テキスト
- シェイプの調整ポイント
- プリセットシェイプの調整
- シェイプジオメトリ
- シェイプのレイアウト書式
- シェイプを SVG として
- シェイプを SVG に変換
- シェイプの配置
- シェイプのフリップ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、プレゼンテーション シェイプの識別、調整、クローン作成、削除、非表示、再配置、エクスポート、配置、フリップ方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、スライド上のシェイプを順序付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/) として表します。このコレクションはシェイプの検索・変更の場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面のシェイプで、最後のインデックスが最前面のシェイプです。

この記事はそのモデルに従います。まずシェイプを確実に識別し、プリセットの調整ポイントを変更する方法を説明し、次にシェイプのクローン作成、削除、非表示、再配置の方法を示します。最後にレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を扱います。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **シェイプの識別と検索**

コレクションインデックスは既知のファイルを処理する際には便利ですが、安定した識別子ではありません。シェイプの追加・削除・再配置によりインデックスは変わります。プレゼンテーションの作成・保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getName--) は、開発者が管理するテンプレートで有用で、PowerPoint の選択ウィンドウで確認しやすいです。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を策定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getAlternativeText--) は、アクセシビリティ用の説明や作者が付与したタグです。ユーザーに表示され、ローカライズやアクセシビリティ向けに書き換えられる可能性がありますが、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして黙って再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint Interop が使用するシェイプ ID に対応します。PowerPoint との統合や、シェイプの存続期間中に曖昧でない参照が必要な場合に使用してください。クローンまたは再作成されたシェイプは別のシェイプとなり、独自の ID を持ちます。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getUniqueId--) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けで再割り当てが可能です。永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待するシェイプが依然として存在するか検証してください。

代替テキストのタイトルと説明の読み取りと更新の実例については、[Manage Alternative Text Titles and Descriptions](/slides/ja/java/presentation-accessibility/) を参照してください。代替テキストはビジュアルの意味を読者に伝えるために使用し、コードがシェイプを検索する際に使用するシェイプ名とは別に管理してください。

次の例は、名前で完全一致検索を行い、スライドスコープの Interop ID を報告します。テンプレートに期待するシェイプが存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

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

操作がシェイプのタイプに依存する場合は、型固有メンバーを使用する前にインターフェイスをチェックしてください。この例は、名前付きオブジェクトが [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) である場合にのみテキストと代替テキストを更新します。

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

## **プリセットシェイプの調整の識別と変更**

プリセットジオメトリシェイプは、コーナーサイズ、矢印の比率、弧の角度などの機能を制御する調整ポイントを公開することがあります。これらは読み取り専用の [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igeometryshape/#getAdjustments--) コレクションを介してアクセスします。コレクション自体はシェイプから提供されますが、各 [IAdjustValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/) が変更可能な値を保持しています。

固定のコレクションインデックスのみに依存しないでください。調整を列挙し、読み取り専用の [getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#getType--) メソッドを調べます。このメソッドが返す [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapeadjustmenttype/) の値が、調整が制御する内容を示します。読み取り専用の [getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#getName--) メソッドは追加の識別情報を提供し、同一のセマンティックタイプを持つ調整が複数存在する場合に特に有用です。

調整の意味に合致したメソッドを使用してください。

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Size of rounded corners | [setRawValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Thickness of an arrow tail | `setRawValue` |
| `ArrowheadLength` | Length of an arrowhead | `setRawValue` |
| `ArrowheadWidth` | Width of an arrowhead | `setRawValue` |
| `StartAngle` | Start angle of a pie or arc | [setAngleValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | End angle of a pie or arc | `setAngleValue` |

`getType` と `getName` は読み取り専用情報を返します。`getRawValue` と `setRawValue` はプリセットのネイティブジオメトリ単位の整数で動作し、`getAngleValue` と `setAngleValue` は度数で角度を扱います。調整の数、順序、意味、有効範囲はプリセットの [ShapeType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igeometryshape/#getShapeType--) に依存します。あるプリセットで有効な値が別のプリセットでは無効または異なる効果になることがあります。

`getType` が `ShapeAdjustmentType.Custom` を返す場合、API は標準的なセマンティック意味を認識していません。`getName`、プリセットタイプ、既存の値を確認し、期待する意味と範囲が分かっている場合を除き、調整は変更しないでください。認識されたタイプであっても、同一タイプが複数回出現するかどうかを確認してから値を選択してください。[Connector](/slides/ja/java/connector/) 記事では、コネクタのベンド調整の例が示されています。

以下の完全な例は、3 つのプリセットシェイプのデフォルト版と変更版を作成します。すべての調整を列挙し、名前とタイプを報告し、`setRawValue` でサイズ関連の値を、`setAngleValue` で角度を変更し、結果を保存します。左列はデフォルトジオメトリ、右列は調整された角丸矩形、四方向矢印、円弧です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // デフォルト列と調整済みシェイプ列のヘッダーを追加します。
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

変更前にセマンティックタイプを確認することで、コードの意図が明確になり、異なるプリセットシェイプ間で同一インデックスが同じ意味を持つと仮定することを防げます。

## **シェイプコレクションの操作**

add、clone、remove、reorder メソッドはコレクションに即座に作用します。操作によりシェイプの数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **シェイプのクローン作成**

[addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) は独立したコピーを作成し、対象コレクションの末尾に追加します。[insertClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標を受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも可能です。

この例は、目的スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。いずれかのクローンを変更しても元シェイプは影響を受けません。

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

クローンはシェイプのコンテンツと書式、名前、代替テキストもコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑なシェイプが使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しいシェイプ ID を持ちます。

### **シェイプの削除**

[remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) は特定のシェイプオブジェクトをコレクションから削除します。インデックス付きイテレーション中に複数マッチを削除する場合は、残りのインデックスが有効なままであるように末尾から走査してください。

この例は、指定された名前を持つすべてのシェイプを削除します。固定のコレクション項目ではなく、現在のインデックスのシェイプを取得し、不要なキャストも行っていません。

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

削除後はシェイプ数と後続シェイプのインデックスが変わります。影響を受けないシェイプへの参照は、保存したインデックスよりも信頼性が高くなります。コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象オブジェクトを参照している可能性も考慮してください。表示上のシェイプを削除すると、スライドの見た目以外にも影響が及ぶことがあります。

### **シェイプの非表示**

[Hidden](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setHidden-boolean-) を `true` に設定すると、シェイプはコレクションに残りますが、通常のスライドショーには表示されなくなります。インデックス、書式、コンテンツはコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

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

非表示は削除やセキュリティとは異なります。ユーザーやコードがオブジェクトを検出し、再表示することができ、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なり合うシェイプはコレクション順に描画されます。[reorder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) は既存シェイプをクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

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

矩形は最初に作成され、最初は楕円の背面にあります。最終インデックスへ移動させると前面に表示されます。関連シェイプをすべて追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上のシェイプの確認**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個のシェイプコレクションを持ちます。レイアウトコレクションのシェイプは、通常スライド上の同位置シェイプとは別オブジェクトです。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウトシェイプを確認してください。

次の例は、各レイアウトシェイプの [FillFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getFillFormat--) と [LineFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getLineFormat--) を取得し、すべてが `AutoShape` であると仮定せずに処理します。

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

レイアウトを編集すると、それを使用している複数のスライドに影響が及びます。レイアウトシェイプを変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判断し、レイアウトを使用しているすべてのスライドでテストしてください。

## **シェイプを SVG にエクスポート**

[writeAsSvg](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) は、単一シェイプの描画結果をストリームに書き出します。出力にはシェイプ自身のみが含まれ、スライド全体の背景や隣接シェイプは含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力はシェイプの書式やフォント・画像といったリソースに依存します。全体の構成が必要な場合は、個別シェイプではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じる責任があります。

## **シェイプの配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) のオーバーロードは、すべてのシェイプまたは指定インデックスのシェイプを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapesalignmenttype/) でエッジ、中心線、分布モードを指定します。`alignToSlide` を `true` にするとスライドのエッジに合わせ、`false` にすると選択シェイプ同士の相対位置で整列します。

この例は、3 つのシェイプをスライド上部エッジに整列させます。返されたシェイプ参照は整列直前に現在のインデックスへ変換されます。

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

整列は位置を変更しますが、Z オーダーは変わりません。相対整列は通常少なくとも 2 つのシェイプが必要で、水平または垂直の分布には間隔を定義できるだけのシェイプが必要です。メソッド呼び出し前にコレクションを変更する場合はインデックスを再計算してください。

## **シェイプのフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。`getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/java/com.aspose.slides/nullablebool/) を使用し、`True` がフリップ有効、`False` が無効、`NotDefined` が未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションには、フリップされていないシェイプが 1 つ含まれています。

![The shape before flipping](shape_to_be_flipped.png)

この例は、他のフレーム値はすべて保持し、フリップ設定のみを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) を割り当てるとフレーム全体が置き換えられるため、重要なポイントです。

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

保存されたシェイプは水平・垂直に鏡像化されますが、位置、サイズ、回転は保持されます。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**シェイプの識別子としてコレクションインデックスを使用すべきですか？**

コレクションが変更されない短時間の処理に限り使用できます。テンプレートが作者によって管理される場合は、検証済みの `Name` または `AlternativeText` の規則を、スライドスコープの Interop 作業には `OfficeInteropShapeId` を使用してください。

**シェイプを非表示にすると Z オーダーから除外されますか？**

いいえ。非表示シェイプは同じインデックスでコレクションに残り、検索、再配置、編集、再表示が可能です。

**クローンしたシェイプが別のシェイプの前に表示されたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクション末尾は Z オーダーの前面に相当します。初期インデックスを指定したい場合は `insertClone` を使用するか、すべてのシェイプ追加後に `reorder` してください。

**プリセットシェイプの調整を固定インデックスで識別できますか？**

正確なプリセットとコレクション配置を検証した場合のみ可能です。`IGeometryShape.getAdjustments` を反復し、`IAdjustValue.getType` を確認する方法を推奨します。同一のセマンティックタイプが複数回現れる場合は、`IAdjustValue.getName` を追加情報として使用してください。