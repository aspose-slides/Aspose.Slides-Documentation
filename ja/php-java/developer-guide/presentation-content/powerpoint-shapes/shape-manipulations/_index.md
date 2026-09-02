---
title: PHPでプレゼンテーションの図形を管理する
linktitle: 図形操作
type: docs
weight: 40
url: /ja/php-java/shape-manipulations/
keywords:
- PowerPoint 図形
- プレゼンテーション図形
- スライド上の図形
- 図形の検索
- 図形のクローン作成
- 図形の削除
- 図形の非表示
- 図形の順序変更
- Interop 図形 ID の取得
- 図形の代替テキスト
- 図形のレイアウト書式
- 図形の SVG 変換
- 図形を SVG に変換
- 図形の配置
- 図形のフリップ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、プレゼンテーションの図形を識別、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップする方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、スライド上の図形を順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/) として表します。このコレクションは図形の取得・変更の場所であると同時に、スタック順序の情報源でもあり、インデックス `0` が最背面の図形、最後のインデックスが最前面の図形を表します。

本記事はこのモデルに従います。まず図形を確実に特定する方法を説明し、続いて図形のクローン作成、削除、非表示、並び替えを示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定について取り上げます。各例は独立しているため、ワークフローで必要な操作だけを使用できます。

## **図形の特定と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。図形の追加・削除・並び替えによりインデックスは変わります。プレゼンテーションの作成・保守方法に合わせて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getname/) は開発者が管理するテンプレートに有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能で一意であることは保証されないため、コードが名前に依存する場合は命名規則を設けてください。
- [AlternativeText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getalternativetext/) は、アクセシビリティ記述や作者が付与したタグで図形が特定できる場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ向けに書き換えられる可能性があり、一意であることは保証されません。意味のあるアクセシビリティテキストをデータベースキーとして無暗に再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getofficeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint の interop が使用する形状 ID に対応します。PowerPoint との統合や、図形の存続期間中に曖昧さのない参照が必要な場合に使用してください。クローンや再作成された図形は別の図形となり、独自の ID が付与されます。

関連する [Shape::getUniqueId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getuniqueid/) メソッドはプレゼンテーション スコープの識別子を返しますが、これはアドイン向けで再割り当てされる可能性があります。永続的な外部キーとして扱わないでください。長期的な同一性が必要な場合は、アプリケーション データにマッピングを保持し、期待する図形がまだ存在するか検証してください。

以下の例は名前で正確に比較検索し、スライド スコープの interop ID を報告します。テンプレートに期待した図形が存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

操作が特定の図形タイプに限定される場合は、型固有メンバーを使用する前にランタイム クラスを確認してください。この例は、名前付きオブジェクトが [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) である場合にのみテキストと代替テキストを更新します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **図形コレクションの変更**

add、clone、remove、reorder メソッドはコレクションに対して即座に作用します。操作により図形数や順序が変わった場合、操作前に取得したインデックスに依存し続けないでください。

### **図形のクローン作成**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[ShapeCollection::insertClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダー インデックスに配置します。座標のみを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはリサイズも可能です。

この例では、宛先スライドを作成し、ラベル付き矩形を前面にクローンし、2 番目のクローンを背面に挿入します。どちらのクローンに対する変更も元の図形に影響しません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

クローンは図形の内容と書式、名前、代替テキストをコピーします。これらの値が一意である必要がある場合は、クローンに新しい論理識別子を割り当ててください。複雑な図形が使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しい図形 ID を持ちます。

### **図形の削除**

[ShapeCollection::remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/remove/) は特定の図形オブジェクトをコレクションから削除します。インデックス順に複数マッチを削除する場合は、残りのインデックスが有効なままになるように末尾から走査してください。

この例は、指定された名前を持つすべての図形を削除します。固定されたコレクション項目ではなく、現在のインデックスの図形を取得し、不要なキャストも行っていません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

削除後は図形数と後続図形のインデックスが変わります。影響を受けない図形への参照は、保存したインデックスよりも信頼性が高くなります。また、コネクタやアニメーションなど、削除されたオブジェクトを参照するプレゼンテーション機能があることも考慮してください。可視図形を削除すると、スライドの外観以上の変化が生じることがあります。

### **図形の非表示**

[Shape::setHidden](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/sethidden/) を `true` に設定すると、図形はコレクションに残りますが通常のスライドショーには表示されなくなります。インデックス、書式、コンテンツはコードから利用可能なままであるため、後で復元できるオプション要素に適しています。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

非表示は削除でもセキュリティでもありません。オブジェクトはユーザーやコードによって発見・再表示でき、プレゼンテーション ファイルの一部として残ります。

### **Z オーダーの変更**

重なる図形はコレクション順に描画されます。[ShapeCollection::reorder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/reorder/) は既存の図形をクローンせずに対象インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

矩形は最初に作成され、当初は楕円の背面にあります。最終インデックスへ移動すると前面に配置されます。すべての関連図形を追加またはクローンした後に Z オーダーを確定してください。これらの操作は新しいコレクション項目を追加または挿入し、意図したスタック順を変える可能性があります。

## **レイアウトスライド上の図形の検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別々の図形コレクションを持ちます。レイアウトコレクション内の図形は、同じ位置にある通常スライド上の図形と同一オブジェクトではありません。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウト図形を検査してください。

以下の例は、各レイアウト図形の [FillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getfillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getlineformat/) を取得し、すべてが `AutoShape` であるという前提をせずに処理します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

レイアウトを編集すると、そのレイアウトを使用している複数のスライドに影響が及びます。レイアウト図形を変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判断し、レイアウトを使用しているすべてのスライドでテストしてください。

## **図形を SVG にエクスポート**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/writeassvg/) は単一図形のレンダリング結果をストリームに書き出します。結果にはその図形のみが含まれ、スライド全体の背景や隣接図形は含まれません。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

レンダリング中はプレゼンテーションを開いたままにしてください。出力は図形の書式設定およびフォントや画像といったリソースに依存します。全体の構成が必要な場合は、個別図形ではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じる必要があります。

## **図形の配置**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/alignshapes/) のオーバーロードは、すべての図形または選択したコレクションインデックスを配置します。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または分布モードを指定します。`alignToSlide` を `true` に設定するとスライドの辺に合わせ、`false` に設定すると選択図形同士の相対位置で配置します。

この例は、3 つの図形をスライド上部のエッジに揃えます。返された図形参照は、配置直前に現在のインデックスへ変換されます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

配置は位置を変更しますが Z オーダー には影響しません。相対配置は通常少なくとも 2 つの図形が必要で、水平または垂直の分布には間隔を定義できるだけの図形が必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **図形のフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/php-java/aspose.slides/nullablebool/) を使用し、`True` がフリップを有効、`False` が無効、`NotDefined` が未指定/既定状態を保持します。

以下の入力プレゼンテーションには、フリップされていない図形が 1 つ含まれています。

![フリップ前の図形](shape_to_be_flipped.png)

この例は他のすべてのフレーム値を保持し、フリップ設定の 2 つだけを置き換えます。新しい [Frame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/setframe/) を割り当てるとフレーム全体が置き換わるため、重要なポイントです。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存された図形は水平・垂直に鏡像化されますが、位置、サイズ、回転はそのまま保持されます。

![フリップ後の図形](flipped_shape.png)

## **FAQ**

**コレクションインデックスを図形識別子として使用すべきですか？**

短時間の処理でコレクションが変化しないことが保証される場合にのみ使用してください。テンプレート作成時には検証済みの `Name` または `AlternativeText` の規約を、スライドスコープの interop 作業には `OfficeInteropShapeId` を優先してください。

**図形を非表示にすると Z オーダーから除外されますか？**

いいえ。非表示の図形は同じインデックスでコレクションに残り、検索、並び替え、編集、再表示が可能です。

**クローンした図形が他の図形の前に現れたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダー の前面に相当します。初期インデックスを指定したい場合は `insertClone` を使用するか、すべての図形を追加した後で `reorder` してください。