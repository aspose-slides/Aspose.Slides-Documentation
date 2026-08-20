---
title: Android でプレゼンテーション図形を管理
linktitle: 図形操作
type: docs
weight: 40
url: /ja/androidjava/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形順序の変更
- インタープ図形 ID の取得
- 図形の代替テキスト
- 図形のレイアウト書式
- SVG としての図形
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、プレゼンテーション図形の識別、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップの方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java は、スライド上の図形を順序付けられた [IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) として表します。このコレクションは図形を検索・変更する場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面の図形で、最後のインデックスが最前面の図形です。

この記事はこのモデルに従います。まず図形を確実に特定する方法を説明し、続いて図形のクローン作成、削除、非表示、並び替えを示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを利用できます。

## **図形の特定と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。図形の追加、削除、並び替えによりインデックスは変わります。プレゼンテーションの作成方法と保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getName--) は、開発者が管理するテンプレートで有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を策定してください。
- [AlternativeText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getAlternativeText--) は、アクセシビリティの説明や作者が付与したタグで図形がすでに識別されている場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ用に書き換えられる可能性があり、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして静かに再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint のインタープとで使用される形状 ID に対応します。PowerPoint と統合する場合や、図形の存続期間中に曖昧でない参照が必要な場合に使用してください。クローンまたは再作成された図形は別の図形となり、独自の ID が割り当てられます。

関連する [getUniqueId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getUniqueId--) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けに設計されており再割り当てされる可能性があります。永続的な外部キーとして扱わないでください。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待する図形が依然として存在するか検証してください。

次の例は名前で正確一致検索し、スライドスコープのインタープ ID を報告します。テンプレートに期待した図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで処理を続行しません。

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

操作が特定の図形タイプに限定される場合は、型固有メンバーを使用する前にインターフェイスを確認してください。この例は、名前付きオブジェクトが [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) の場合にのみテキストと代替テキストを更新します。

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

## **図形コレクションの操作**

追加、クローン、削除、並び替えのメソッドはコレクションに即座に反映されます。操作により図形の数や順序が変わった場合、事前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) は独立したコピーを作成し、対象コレクションの末尾に追加します。[insertClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標だけを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも可能です。

例は目的スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。いずれのクローンに対する変更も元の図形を変更しません。

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

クローンは図形の内容と書式、名前、代替テキストをすべてコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複合図形が使用するリソースはプレゼンテーション側で管理されますが、クローンは新しいコレクション項目として新しい図形 ID を持ちます。

### **図形の削除**

[remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) は特定の図形オブジェクトをそのコレクションから削除します。インデックス付きイテレーション中に複数一致を削除する場合は、末尾から走査して各残りインデックスが有効なままにしてください。

この例は指定された名前を持つすべての図形を削除します。固定のコレクション項目ではなく、現在のインデックスの図形を取得し、不要なキャストも行っていません。

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

削除後は図形数と後続図形のインデックスが変化します。影響を受けない図形への参照は保存したインデックスよりも信頼性が高くなります。また、コネクタやアニメーションなど、削除対象オブジェクトを参照しているプレゼンテーション機能があることも考慮してください。可視図形を削除すると、スライドの見た目以外にも影響が出る可能性があります。

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

非表示は削除やセキュリティではありません。ユーザーやコードによって再び検出・非表示解除され得るオブジェクトであり、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なった図形はコレクションの順序で描画されます。[reorder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) は既存の図形をクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

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

矩形は最初に作成され、最初は楕円の背面にあります。最終インデックスへ移動すると前面に配置されます。すべての関連図形を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順序を変更する可能性があります。

## **レイアウトスライド上の図形の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別々の図形コレクションを持ちます。レイアウトコレクション内の図形は、通常スライド上の同位置図形と同一オブジェクトではありません。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウト図形を検査してください。

次の例は各レイアウト図形の [FillFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getFillFormat--) と [LineFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getLineFormat--) を取得し、すべての図形が `AutoShape` であると仮定しません。

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

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを確認し、レイアウトを使用しているすべてのスライドでテストしてください。

## **図形を SVG へエクスポート**

[writeAsSvg](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) は単一の図形の描画内容をストリームに書き出します。結果にはその図形だけが含まれ、スライド全体の背景や隣接図形は含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式設定やフォント・画像等のリソースに依存します。全体の構成が必要な場合は、個別の図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じる責任があります。

## **図形の配置**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) のオーバーロードはすべての図形または選択されたコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapesalignmenttype/) はエッジ、中心線、または分布モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジに合わせ、`false` にすると選択した図形同士の相対位置で整列します。

この例は 3 つの図形をスライドの上部エッジに整列させます。返された図形参照は整列直前に現在のインデックスへ変換されます。

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

配置は位置を変更しますが Z オーダーは変わりません。相対配置は通常最低 2 つの図形が必要で、水平または垂直の分布には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/nullablebool/) を使用し、`True` がフリップ有効、`False` が無効、`NotDefined` が未指定/既定状態を保持します。

下図の入力プレゼンテーションにはフリップされていない図形が 1 つ含まれています。

![The shape before flipping](shape_to_be_flipped.png)

この例は他のすべてのフレーム値はそのままにし、フリップ設定だけを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) を割り当てるとフレーム全体が置き換えられるため、重要な手順です。

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

保存された図形は水平・垂直に鏡像化されますが、位置、サイズ、回転は保持されます。

![The shape after flipping](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形の識別子として使用すべきですか？**

短時間の処理でコレクションが変更されない場合に限り使用できます。テンプレートが作者管理の場合は検証済みの `Name` または `AlternativeText` の規約を、スライドスコープのインタープ作業には `OfficeInteropShapeId` を優先してください。

**図形を非表示にすると Z オーダーから除外されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残ります。検索、並び替え、編集、再表示が可能です。

**クローンした図形が別の図形の前に現れたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの前面に相当します。初期インデックスを指定したい場合は `insertClone` を使用するか、すべての図形を追加した後に `reorder` してください。