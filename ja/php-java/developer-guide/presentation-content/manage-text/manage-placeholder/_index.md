---
title: PHP でプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/php-java/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- グラフプレースホルダー
- コンテンツプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、テキスト、画像、グラフ、コンテンツのプレースホルダーを検査・編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。代表的な例として、タイトル、本文、画像、グラフ、および汎用コンテンツプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は [Shape::getPlaceholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getplaceholder/) メソッドでプレースホルダー情報を公開します。このメソッドは通常のシェイプに対しては `null` を返し、プレースホルダーの場合は [Placeholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholder/) オブジェクトを返します。プレースホルダーが何を保持することを想定しているかは [Placeholder::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholder/gettype/) で判定してください。

プレースホルダーの種類が分かった後でもシェイプクラスは重要です：

- 空のテキスト、画像、グラフ、またはコンテンツプレースホルダーは一般的に [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) で表されます。
- 内容が入った画像プレースホルダーは [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) で表すことができます。
- 内容が入ったグラフプレースホルダーは [Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/) で表すことができます。
- コンテンツプレースホルダーはさまざまな種類のコンテンツを保持できます。すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であると仮定せず、[Placeholder::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholder/gettype/) とランタイム時のシェイプクラスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholder/gettype/) はプレースホルダーの役割を示しますが、シェイプのランタイムクラスを保証するものではありません。テキスト、画像、グラフ、テーブル、メディア固有のメンバーにアクセスする前に必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承を理解する**

プレースホルダーは階層構造を形成します。

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは 1 つ以上の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド固有のプレースホルダーを保持し、レイアウトから継承できます。

[Shape::getBasePlaceholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getbaseplaceholder/) を呼び出すと、階層の 1 つ上のプレースホルダーに移動できます。スライドのプレースホルダーは通常レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返すことがあります。シェイプにベースプレースホルダーが存在しない場合は `null` が返ります。

以下の例は、最初のスライドにあるプレースホルダーを列挙し、そのベースプレースホルダーを表示します。

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

通常スライド上のプレースホルダーを編集すると、そのスライド固有のローカルオーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、まだその設定を継承しているすべてのスライドに影響を与えます。ローカルの通常シェイプにはベースプレースホルダーがなく、同じ座標にあるだけで継承が開始されるわけではありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタードタイトル、サブタイトル、本文、テキストプレースホルダーは通常テキストをサポートします。使用前にシェイプが [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) であることを確認し、[getTextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/gettextframe/) メソッドを使用してください。

この例は最初のスライドの最初のタイトルプレースホルダーを更新し、結果を保存します。

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

このパターンは画像、グラフ、テーブル、メディアプレースホルダーを [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) オブジェクトとして扱うことを防ぎます。また、脆弱なシェイプインデックスに依存せず、目的別にプレースホルダーを識別します。

## **レイアウト上でプロンプトテキストを設定する**

プロンプトテキストは空のプレースホルダーに表示されるデザイン時の指示で、例として *Click to add title* があります。カスタムプロンプトテキストは、通常スライドのシェイプコレクションを経由して取得しようとするのではなく、レイアウトプレースホルダーに直接設定してください。[Slide::getLayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getLayoutSlide) でレイアウトを取得し、[BaseSlide::getShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getShapes) が返すコレクションを走査します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します。

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

プロンプトテキストは通常のスライドコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示される指示です。ユーザーまたはプログラムが実際のコンテンツを入力するとプロンプトは表示されなくなります。また、プロンプトを変更しても、そのレイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

処理は 2 つのケースに分かれます：

- 画像プレースホルダーにすでに画像が設定され、[PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) で表されている場合は、[PictureFillFormat::getPicture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/picturefillformat/getpicture/) と [SlidesPicture::setImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidespicture/setimage/) を使って画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addpictureframe/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します。

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

空のプレースホルダーに対して作成された置き換えはローカルの画像フレームであり、新しいプレースホルダーではありません。これは [Shape::getPlaceholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getplaceholder/) にセッターがないためです。位置は確保されたままですが、プレースホルダー固有の継承動作は失われます。プレースホルダーとの関係を保持したまま置き換える必要がある場合は、最初に PowerPoint でプレースホルダーを用意しておき、Aspose.Slides で生成された [PictureFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pictureframe/) を更新してください。

画像の透過、クロッピング、その他画像固有の効果については [Manage Picture Frames](/slides/ja/php-java/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像フィルに対して行われ、プレースホルダーのメタデータには関係しません。

## **グラフおよびコンテンツプレースホルダーの操作**

内容が入ったグラフプレースホルダーは [Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/) で表すことができます。この例はプレースホルダータイプとランタイムクラスの両方でグラフを検索し、タイトルを変更してファイルを保存します。

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

汎用コンテンツプレースホルダーは通常 [PlaceholderType::Object](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、グラフ、テーブル、図、画像、メディアなど複数のコンテンツタイプの起動点として機能します。実際にコンテンツが入力された後は、保持しているシェイプクラスを調べて何が含まれているかを判断してください。特殊なレイアウトでは [PlaceholderType::Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholdertype/)、[PlaceholderType::Diagram](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、空の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/) に単に [Placeholder::getType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/placeholder/gettype/) を変更しただけで変換しません。型はクラスを通じて変更できません。空のグラフやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。以下の例はグラフに対してその操作を行います。

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

追加されたグラフはローカルの普通のグラフです。プレースホルダー領域を占有しますが、レイアウトプレースホルダーから継承はされません。カテゴリ、系列、ブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/php-java/powerpoint-charts/) を参照してください。

## **完全なサンプル: テキストまたは画像コンテンツの更新**

以下のエンドツーエンドサンプルはテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認して適切なコンテンツを更新し、結果を保存します。この例はシェイプインデックスに依存したり、すべてのプレースホルダーを同じクラスとみなしたりしないよう意図的に設計されています。

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

ベースプレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応シェイプです。[Shape::getBasePlaceholder](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getbaseplaceholder/) を使用して取得できます。ローカルの通常シェイプはプレースホルダー階層の一部ではないため `null` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを通じて継承された書式やプロンプトテキストは変更できますが、実際のタイトルコンテンツは通常スライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを走査して各タイトルプレースホルダーを更新する必要があります。

**日付、スライド番号、ヘッダー、フッタープレースホルダーはどう管理しますか？**

ヘッダーとフッターのマネージャーを適切なスライド、レイアウト、マスター、ノート、配布資料のスコープで使用してください。完全なサンプルは [Manage Presentation Header and Footer](/slides/ja/php-java/presentation-header-and-footer/) を参照してください。