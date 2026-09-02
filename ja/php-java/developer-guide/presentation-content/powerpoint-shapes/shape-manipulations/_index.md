---
title: PHPでプレゼンテーションのシェイプを管理する
linktitle: シェイプ操作
type: docs
weight: 40
url: /ja/php-java/shape-manipulations/
keywords:
- PowerPointシェイプ
- プレゼンテーションシェイプ
- スライド上のシェイプ
- シェイプの検索
- シェイプのクローン作成
- シェイプの削除
- シェイプの非表示
- シェイプの順序変更
- InteropシェイプIDの取得
- シェイプの代替テキスト
- シェイプの調整ポイント
- プリセットシェイプ調整
- シェイプジオメトリ
- シェイプのレイアウト書式
- SVGとしてのシェイプ
- シェイプをSVGへ変換
- シェイプの配置
- シェイプのフリップ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、プレゼンテーションシェイプの識別、調整、クローン作成、削除、非表示、順序変更、エクスポート、配置、フリップの方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、スライド上のシェイプを順序付けられた [ShapeCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/) として表現します。コレクションはシェイプを検索・変更する場所であると同時に、スタック順序の情報源でもあります。インデックス `0` が最背面のシェイプで、最後のインデックスが最前面のシェイプです。

この文章はそのモデルに従います。まずシェイプを確実に識別し、プリセットの調整ポイントを変更する方法を説明し、次にシェイプのクローン作成、削除、非表示、順序変更の方法を示します。最後のセクションではレイアウトレベルの書式設定、SVG エクスポート、配置、フリップ設定を取り上げます。各例は独立しているため、ワークフローで必要な操作だけを利用できます。

## **シェイプの識別と検索**

コレクションインデックスは既知のファイルを処理する際に便利ですが、安定した識別子ではありません。シェイプの追加、削除、順序変更によりインデックスは変わります。プレゼンテーションの作成・保守方法に応じて識別子を選択してください。

- [Name](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getname/) は開発者が管理するテンプレートで有用で、PowerPoint の選択ウィンドウで簡単に確認できます。名前は編集可能ですが一意である保証はないため、コードが名前に依存する場合は命名規則を設けてください。
- [AlternativeText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getalternativetext/) は、アクセシビリティ記述や作者が付与したタグでシェイプが既に識別されている場合に有用です。ユーザーに表示され、ローカライズやアクセシビリティ向上のために書き換えられることがありますが、一意である保証はありません。意味のあるアクセシビリティテキストをデータベースキーとして無音で再利用しないでください。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getofficeinteropshapeid/) は読み取り専用の識別子で、スライド内で一意であり、PowerPoint の Interop が使用するシェイプ ID に対応します。PowerPoint と統合する場合や、シェイプの存続期間中に曖昧でない参照が必要な場合に使用してください。クローンまたは再作成されたシェイプは別のシェイプとなり、独自の ID が付与されます。

関連する [Shape::getUniqueId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getuniqueid/) メソッドはプレゼンテーションスコープの識別子を返しますが、これはアドイン向けで再割り当てされる可能性があります。永続的な外部キーとして扱うべきではありません。長期的な同一性が必要な場合は、アプリケーションデータにマッピングを保持し、期待するシェイプが依然として存在するか検証してください。

以下の例は名前で完全一致検索し、スライドスコープの Interop ID を報告します。テンプレートに期待するシェイプが存在しない場合、コードはその結果を報告し、誤ったオブジェクトで続行しません。

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

操作がシェイプの種類に依存する場合は、型固有メンバーを使用する前に実行時クラスを確認してください。この例は、名前付きオブジェクトが [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) である場合にのみテキストと代替テキストを更新します。

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

## **プリセットシェイプ調整の識別と変更**

プリセットジオメトリシェイプは、角のサイズや矢印の比率、円弧の角度などを制御する調整ポイントを公開することがあります。これらは読み取り専用の [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ja/php-java/aspose.slides/geometryshape/#getAdjustments) コレクション経由でアクセスできます。コレクション自体はシェイプから提供されますが、各 [AdjustValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/) が変更可能な値を保持しています。

固定のコレクションインデックスだけに依存しないでください。調整項目を列挙し、読み取り専用の [AdjustValue::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/#getType) メソッドを確認します。このメソッドの [ShapeAdjustmentType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapeadjustmenttype/) 値が調整が制御する対象を示します。読み取り専用の [AdjustValue::getName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/getname/) メソッドは追加の識別情報を提供し、同じセマンティックタイプの調整が複数あるプリセットで特に有用です。

調整の意味に合ったメソッドを使用してください。

| 調整タイプ | 目的 | 変更する値 |
|---|---|---|
| `CornerSize` | 丸め角のサイズ | [setRawValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 矢尻の太さ | `setRawValue` |
| `ArrowheadLength` | 矢じりの長さ | `setRawValue` |
| `ArrowheadWidth` | 矢じりの幅 | `setRawValue` |
| `StartAngle` | パイまたは円弧の開始角度 | [setAngleValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | パイまたは円弧の終了角度 | `setAngleValue` |

`getType` と `getName` は読み取り専用情報を返します。`getRawValue` と `setRawValue` はプリセットのネイティブジオメトリ単位の整数で動作し、`getAngleValue` と `setAngleValue` は度数で角度を扱います。調整項目の数・順序・意味・有効範囲はプリセットの [GeometryShape::getShapeType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/geometryshape/#getShapeType) に依存します。あるプリセットで有効な値が別のプリセットでは無効、あるいは異なる効果を持つことがあります。

`getType` が `ShapeAdjustmentType::Custom` を返す場合、API は標準的な意味を認識していません。`getName`、プリセットタイプ、既存の値を確認し、期待する意味と範囲が分かっている場合以外は調整を変更しないでください。認識されたタイプでも、同じタイプが複数回出現するかどうかを確認してから値を選択します。コネクタの曲げ調整に関する例は [Connector](/slides/ja/php-java/connector/) 記事をご参照ください。

以下の完全な例は、3 つのプリセットシェイプのデフォルト版と変更版を作成します。すべての調整を列挙し、名前とタイプを報告し、サイズ関連の値は `setRawValue`、角度は `setAngleValue` で変更し、結果を保存します。左列はデフォルトジオメトリを保持し、右列は調整された角丸長方形、四方向矢印、パイを示します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // デフォルトと調整されたシェイプ列のヘッダーを追加します。
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

値を変更する前にセマンティックタイプを確認することで、コードは意図を明確にし、異なるプリセットシェイプ間で同じコレクションインデックスが同じ意味を持つと仮定することを防げます。

## **シェイプコレクションの変更**

追加、クローン、削除、順序変更のメソッドはコレクションに対して即座に作用します。操作によりシェイプ数や順序が変わった場合、事前に取得したインデックスに依存し続けないでください。

### **シェイプのクローン**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addclone/) は独立したコピーを作成し、対象コレクションの末尾に追加します。[ShapeCollection::insertClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/insertclone/) もコピーを作成しますが、指定した Z オーダーインデックスに配置します。座標のみを受け取るオーバーロードはサイズを変更せずにクローンを移動し、幅と高さを受け取るオーバーロードはサイズ変更も可能です。

以下の例は、宛先スライドを作成し、ラベル付き長方形を前面にクローンし、2 番目のクローンを背面に挿入します。いずれかのクローンを変更しても元のシェイプには影響しません。

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

クローンはシェイプのコンテンツと書式、名前、代替テキストをすべてコピーします。これらの値が一意である必要がある場合は、新しい論理識別子を割り当ててください。複雑なシェイプが使用するリソースはプレゼンテーションが管理しますが、クローンは新しいコレクション項目として新しいシェイプ ID を持ちます。

### **シェイプの削除**

[ShapeCollection::remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/remove/) は特定のシェイプオブジェクトをコレクションから削除します。インデックス付きイテレーション中に複数マッチを削除する場合は、残りのインデックスが有効なままになるように末尾から走査してください。

この例は、指定された名前を持つすべてのシェイプを削除します。固定のコレクション項目ではなく、現在のインデックスのシェイプを読み取り、不要なキャストも行っていません。

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

削除後はシェイプ数と後続シェイプのインデックスが変わります。影響を受けないシェイプへの参照は保存されたインデックスより信頼性が高くなります。また、コネクタ、アニメーション、その他のプレゼンテーション機能が削除対象オブジェクトを参照している場合があることに留意してください。可視シェイプを削除すると、スライドの見た目以外にも影響が及ぶことがあります。

### **シェイプの非表示**

[Shape::setHidden](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/sethidden/) を `true` に設定すると、シェイプはコレクションに残りますが、通常のスライドショーには表示されなくなります。インデックス、書式、コンテンツはコードから引き続き利用可能なので、後で復元できるオプション要素に適しています。

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

非表示は削除やセキュリティとは異なります。オブジェクトは依然として検出可能で、ユーザーやコードによって再表示できます。また、プレゼンテーションファイルの一部として残ります。

### **Z オーダーの変更**

重なったシェイプはコレクション順に描画されます。[ShapeCollection::reorder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/reorder/) は既存シェイプをクローンせずに指定インデックスへ移動します。インデックス `0` が背面、`size() - 1` が前面です。

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

長方形は最初に作成され、最初は楕円の背面にあります。最終インデックスへ移動させると前面に配置されます。すべての関連シェイプを追加またはクローンした後に Z オーダーを確定してください。これらの操作はコレクション項目を追加または挿入し、意図したスタック順序を変える可能性があります。

## **レイアウトスライド上のシェイプの検査**

通常スライド、レイアウトスライド、マスタースライドはそれぞれ別個のシェイプコレクションを持ちます。レイアウトコレクションのシェイプは、同じ位置にある通常スライドのシェイプとは別オブジェクトです。レイアウトが提供する書式を理解または変更する必要がある場合は、レイアウトシェイプを検査してください。

以下の例は、各レイアウトシェイプの [FillFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getfillformat/) と [LineFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getlineformat/) を取得し、すべてが `AutoShape` であると仮定しません。

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

レイアウトを編集すると、それを使用している複数のスライドに影響します。レイアウトシェイプを変更する前に、通常スライドがオブジェクトを継承しているかローカルで上書きしているかを判定し、該当レイアウトを使用しているすべてのスライドでテストしてください。

## **シェイプを SVG にエクスポート**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/writeassvg/) は、単一シェイプの描画結果をストリームに書き込みます。出力にはシェイプのみが含まれ、スライド全体の背景や隣接シェイプは含まれません。

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

レンダリング中はプレゼンテーションを開いたままにしてください。出力はシェイプの書式設定やフォント、画像といったリソースに依存します。全体の構成が必要な場合は、個別シェイプではなくスライド全体をエクスポートしてください。呼び出し側がストリームの所有権を持ち、閉じる必要があります。

## **シェイプの配置**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/alignshapes/) のオーバーロードは、すべてのシェイプまたは選択したコレクションインデックスを整列させます。[ShapesAlignmentType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapesalignmenttype/) はエッジ、中心線、または配分モードを指定します。`alignToSlide` を `true` に設定するとスライドのエッジに合わせ、`false` にすると選択シェイプ同士の相対位置で整列します。

この例は、3 つのシェイプをスライド上部のエッジに整列させます。返されたシェイプ参照は整列直前に現在のインデックスへ変換されます。

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

配置は位置を変更しますが、Z オーダーは変わりません。相対配置には通常最低 2 つのシェイプが必要で、水平または垂直の配分には間隔を定義できるだけのシェイプが必要です。メソッド呼び出し前にコレクションを変更した場合はインデックスを再計算してください。

## **シェイプのフリップ**

[ShapeFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapeframe/) クラスは位置、サイズ、水平・垂直フリップ設定、回転を保持します。その `getFlipH` と `getFlipV` の値は [NullableBool](https://reference.aspose.com/slides/ja/php-java/aspose.slides/nullablebool/) を使用し、`True` がフリップ有効、`False` が無効、`NotDefined` が未指定/デフォルト状態を保持します。

以下の入力プレゼンテーションにはフリップされていないシェイプが 1 つ含まれています。

![Flipping前のシェイプ](shape_to_be_flipped.png)

この例は他のフレーム値はすべて保持し、フリップ設定のみを置き換えます。これは新しい [Frame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/setframe/) を割り当てるとフレーム全体が置き換えられるため、重要です。

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

保存されたシェイプは水平・垂直に鏡像化されますが、位置、サイズ、回転はそのままです。

![Flipping後のシェイプ](flipped_shape.png)

## **FAQ**

**コレクションインデックスをシェイプの識別子として使用すべきですか？**

短時間の処理で、コレクションが操作前に変化しないことが保証されている場合にのみ使用してください。作成されたテンプレートでは `Name` や `AlternativeText` の命名規則を、スライドスコープの Interop 作業では `OfficeInteropShapeId` を優先してください。

**シェイプを非表示にすると Z オーダーから除外されますか？**

いいえ。非表示シェイプは同じインデックスでコレクションに残り、検索・順序変更・編集・再表示が可能です。

**クローンしたシェイプが別のシェイプの前に表示されたのはなぜですか？**

`addClone` はクローンをコレクションの末尾に追加します。コレクションの末尾は Z オーダーの前面に相当します。初期インデックスを指定したい場合は `insertClone` を使用するか、すべてのシェイプ追加後に `reorder` で位置を調整してください。

**プリセットシェイプの調整を固定インデックスで識別できますか？**

正確なプリセットとコレクション構造を検証した場合に限り可能です。`GeometryShape::getAdjustments` を列挙し、`AdjustValue::getType` を確認することを推奨します。同じセマンティックタイプが複数出現する場合は `AdjustValue::getName` を追加情報として利用してください。