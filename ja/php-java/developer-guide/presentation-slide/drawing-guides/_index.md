---
title: PHP でプレゼンテーションの描画ガイドを管理
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/php-java/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 整列ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスター
- 配布資料マスター
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションに水平および垂直の描画ガイドを追加、取得、クリアします。"
---
## **概要**

描画ガイドは、調整可能な水平および垂直の線で、PowerPoint でプレゼンテーションを編集する際に図形を一貫して配置するのに役立ちます。アプリケーションが後で手動で調整されるプレゼンテーションを生成する場合に特に便利です。アプリケーションは、コンテンツを追加または移動する際に作者が従うべき同じ整列支援情報を保存できます。

描画ガイドは編集支援ツールであり、スライド コンテンツではありません。スライド ショーやレンダリングされた出力には表示されません。Aspose.Slides for PHP via Java は、[DrawingGuidesCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguidescollection/) クラスを介してこれらを提供します。ガイドは [DrawingGuide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguide/) で表され、方向、位置、色を持ちます。

位置は、対象スライドまたはマスターの左上隅からのポイントで測定されます。垂直ガイドは水平座標を使用し、通常は 0 からスライド幅までの範囲です。水平ガイドは垂直座標を使用し、通常は 0 からスライド高さまでの範囲です。

## **スライドビューにガイドを追加**

[CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) を使用して、通常のスライドを編集しているときに表示されるガイドを管理します。[DrawingGuidesCollection::add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguidescollection/#add) に [Orientation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/orientation/) の値とポイント単位の位置を指定して呼び出します。

次の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します。

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **描画ガイドへのアクセス**

[DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguidescollection/#getCount) および [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguidescollection/#get_Item) メソッドで既存のガイドにアクセスできます。[DrawingGuide::getOrientation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide::getPosition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguide/#getPosition)、[DrawingGuide::getColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguide/#getColor) メソッドは値を返し、対応するセッターで変更可能です。

次の例は、上記で作成したプレゼンテーションからスライドビュー ガイドを読み取ります。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **マスターおよびレイアウト スライドにガイドを追加**

スライド マスターとその各レイアウト スライドは、独自の描画ガイド コレクションを持つことができます。マスター スライドの場合は [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/#getDrawingGuides)、レイアウト スライドの場合は [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getDrawingGuides) を使用します。

次の例は、最初のマスター スライドに垂直ガイドを、最初のレイアウト スライドに水平ガイドを追加します。

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ノート マスターおよび配布資料 マスターにガイドを追加**

ノート マスターと配布資料 マスターも描画ガイドをサポートします。[MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masternotesslide/#getDrawingGuides) と [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) を使用してコレクションにアクセスします。プレゼンテーションにこれらのマスターが含まれていない場合は、[Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) または [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) で適切なマネージャーを取得し、`setDefaultMasterNotesSlide` または `setDefaultMasterHandoutSlide` でデフォルト マスターを作成します。

次の例は、ノート マスターに水平ガイドを、配布資料 マスターに垂直ガイドを追加します。

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **描画ガイドのクリア**

[DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguidescollection/#clear) を呼び出すと、特定のコレクション内のすべてのガイドが削除されます。あるコレクションをクリアしても、別のスコープに保存されているガイドには影響しません。

次の例は、スライドビュー ガイドとスライド マスター、レイアウト スライド、ノート マスター、配布資料 マスター上のすべてのガイドを、マスターが存在しない場合は作成せずにクリアします。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**描画ガイドはスライド ショーやエクスポートされた画像に表示されますか？**

いいえ。描画ガイドは編集時の整列支援であり、プレゼンテーション コンテンツとしてはレンダリングされません。

**描画ガイドを個々の通常スライドに直接追加できますか？**

通常スライドの編集ガイドはプレゼンテーションのスライドビュー プロパティに保存されます。スライド マスター、レイアウト スライド、ノート マスター、配布資料 マスター用の別個のガイド コレクションも利用可能です。

**ガイド位置の単位は何ですか？**

位置はポイントで指定され、72 ポイントが 1 インチに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアするとシェイプやスライド コンテンツが削除または変更されますか？**

いいえ。[DrawingGuidesCollection::clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/drawingguidescollection/#clear) メソッドは選択されたコレクション内のガイドのみを削除します。シェイプやその他のスライド コンテンツは変更されません。