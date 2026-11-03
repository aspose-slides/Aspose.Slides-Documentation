---
title: PHPでプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/php-java/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- コンテンツプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、テキスト、画像、チャート、コンテンツのプレースホルダーを検査・編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、グラフ、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) メソッドで提供します。このメソッドは [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) オブジェクトを返すか、通常のシェイプの場合は `null` を返します。プレースホルダーが何を保持することを意図しているかは [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) で確認してください。

プレースホルダーのタイプが分かった後でもシェイプクラスは重要です:

- 空のテキスト、画像、グラフ、またはコンテンツのプレースホルダーは一般的に [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) で表されます。
- 内容が入った画像プレースホルダーは [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) で表されます。
- 内容が入ったグラフプレースホルダーは [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) で表されます。
- コンテンツプレースホルダーはさまざまな種類のコンテンツを保持できます。すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) であると想定せず、[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) と実行時のシェイプクラスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) はプレースホルダーの役割を示しますが、シェイプの実行時クラスを保証するものではありません。テキスト、画像、グラフ、テーブル、メディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層構造を形成します:

1. マスタースライドは再利用可能なスタイルと、場合によってはマスターレベルのプレースホルダーを定義します。
2. レイアウトスライドは1枚以上の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) を呼び出すと、階層の1つ上のプレースホルダーに移動できます。スライドのプレースホルダーは通常レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返すことがあります。シェイプにベースプレースホルダーがない場合、このメソッドは `null` を返します。

次の例は最初のスライド上のプレースホルダーを列挙し、ベースプレースホルダーを報告します:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

通常スライド上でプレースホルダーを編集すると、そのスライドのローカルオーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、まだその設定を継承しているすべてのスライドに影響します。ローカルの普通のシェイプはベースプレースホルダーを持たず、同じ座標に配置されているだけで継承を開始しません。

## **プレースホルダーのステータスを削除する**

テンプレートを調整する際は、[Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) を使用して、既存のオブジェクトを普通のシェイプとして残します。その [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) メソッドは `null` を返しますが、シェイプはスライドのコレクションに残ります。対照的に、[ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) はそのコレクションからシェイプを削除します。

以下の例は、少なくとも1枚のスライドと最初のスライドに非空テキストプレースホルダーがある `template.pptx` を前提としています。レイアウトまたはマスターから継承された書式設定を持つプレースホルダーを使用して、関係を削除したときの影響を確認してください。例は同じシェイプが残っていることをチェックし、普通のシェイプになった後にメソッドを再度呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例は意図的に設定を変更せずに残すようにしているため、出力が異なる可能性があります。位置とサイズが完全に継承されているシェイプは、呼び出し後に座標と寸法が 0 となり、コレクションに残っていても見えなくなることがあります。
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // 普通のシェイプでメソッドを呼び出しても効果はありません。
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

一致するプレースホルダーについては、3つのチェックすべてが `true` を出力します。テキストは残りますが、位置、サイズ、回転、フォント、段落の配置、テキストフレームの余白、垂直アンカリング、塗りつぶし、線の設定などの継承されたプロパティは、プレースホルダーの関係を削除すると変わることがあります。たとえば、継承されたタイトル書式は普通のテキスト書式にフォールバックします。レイアウトの詳細は [Slide Layout](/slides/ja/php-java/slide-layout/) を参照してください。

意図した外観を保持するには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な実効書式の値を個別の変数にコピーします。これらの値は [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/)、[ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/)、[TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/)、[FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/)、[LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) で取得できます。実効書式オブジェクトだけに依存しないでください。関係が削除された後にテキスト書式の値が変わる可能性があります。取得したフォントファミリ、サイズ、スタイル、色、段落設定、テキストフレーム設定、塗りつぶし、線などを普通のシェイプに明示的に適用してください。

継承されたシェイプのジオメトリも、[GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) を使用して明示的に設定する必要があります。矩形テキストプレースホルダーの場合、[ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) を割り当てる必要があります。塗りつぶしと線だけを復元しても、見える矩形が復元されないことがあります。追加効果や複雑な書式設定を持つテンプレートでは、これらの設定も同様に処理してください。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストプレースホルダーは通常テキストをサポートします。使用する前に [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) かどうかを確認し、その [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) メソッドを使用してください。

この例は最初のスライドの最初のタイトルプレースホルダーを更新し、結果を保存します:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

このパターンは画像、グラフ、テーブル、メディアのプレースホルダーを [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) オブジェクトとして扱うことを防ぎます。また、形状インデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上のプロンプトテキストを設定する**

プロンプトテキストは空のプレースホルダーに表示されるデザイン時の指示で、例: *Click to add title* のようになります。通常スライドのシェイプコレクションを介さず、レイアウトプレースホルダーに直接カスタムプロンプトテキストを設定してください。[Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) でレイアウトにアクセスし、[BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) が返すコレクションを走査します。

次の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

プロンプトテキストは普通のスライドコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに表示される指示です。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用するスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

対応すべきケースは2つあります:

- 画像プレースホルダーがすでに埋め込まれ、[PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) で表されている場合は、[PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) と [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) を使って画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースをサポートし、プレゼンテーションを保存します:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

空のプレースホルダー用に作成された置き換えはローカルの画像フレームであり、新しいプレースホルダーではありません。これは [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) にセッターがないためです。位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダー関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを作成・埋め込み、結果の [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) を Aspose.Slides で更新してください。

画像の透明度、トリミング、その他画像固有の効果については [Manage Picture Frames](/slides/ja/php-java/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像フィルに対して行います。

## **グラフおよびコンテンツプレースホルダーの操作**

内容が入ったグラフプレースホルダーは [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) で表されます。この例はプレースホルダータイプと実行時クラスの両方でグラフを検索し、タイトルを変更してファイルを保存します:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

汎用コンテンツプレースホルダーは通常 [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、グラフ、テーブル、ダイアグラム、画像、メディアなど複数のコンテンツタイプの起点として機能します。内容が入ったら、実際のシェイプクラスを調べて中身を判定してください。特化したレイアウトでは [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) も公開されます。

Aspose.Slides は、[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) を変更するだけで空の [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) に変換しません。タイプはクラスを通じて変更できません。空のグラフやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はグラフに対してそれを行います:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

追加されたグラフは普通のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトプレースホルダーからは継承しません。カテゴリ、シリーズ、ブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/php-java/powerpoint-charts/) を参照してください。

## **完全例: テキストまたは画像コンテンツの更新**

次のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認し、適切なコンテンツを更新して出力を保存します。例は形状インデックスに依存せず、すべてのプレースホルダーを同一クラスとみなすことを避けています。

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**ベースプレースホルダーとは何ですか？**

ベースプレースホルダーは、レイアウトまたはマスター上にある対応するシェイプで、他のプレースホルダーがそれから継承します。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) で取得できます。ローカルの普通シェイプはプレースホルダー階層の一部でないため `null` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承書式やプロンプトテキストは変更できますが、実際のタイトルコンテンツは通常スライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを走査して各タイトルプレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどう管理しますか？**

対象のスライド、レイアウト、マスター、ノート、ハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用します。完全な例は [Manage Presentation Header and Footer](/slides/ja/php-java/presentation-header-and-footer/) を参照してください。