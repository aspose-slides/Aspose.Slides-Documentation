---
title: PHP でプレゼンテーション スライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/php-java/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPT マスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でスライドマスターを管理します。PowerPoint および OpenDocument のプレゼンテーションで、マスタースライドへのアクセス、編集、クローン作成、比較、削除が可能です。"
---
## **概要**

**スライドマスター** は、スライドのグループに対する共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することが、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つ一般的な方法です。

Aspose.Slides for PHP via Java は同じモデルをサポートしています。プレゼンテーションには 1 つ以上の **マスタースライド** を含めることができ、各マスタースライドは複数の **レイアウトスライド** を含むことができます。通常、通常のスライドはマスタースライドを直接参照しません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドはマスタースライドに属します。

階層は次のとおりです：

1. **スライドマスター** - 共有デザインとテーマを定義します。
1. **レイアウトスライド** - プレースホルダーとレイアウトレベルの書式設定の特定の配置を定義します。
1. **通常スライド** - 実際のプレゼンテーションコンテンツを含み、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、および通常スライドの階層](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation.getMasters](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getMasters) メソッドで取得でき、[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) オブジェクトが返されます。

{{% alert color="info" title="継承" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方が背景を定義している場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[スライドレイアウトの適用または変更](/slides/ja/php-java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![PowerPoint の表示タブのスライドマスターコマンド](slide-master_3.jpg)

Aspose.Slides では、`getMasters` メソッドを使用してマスタースライドにアクセスします：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

通常のスライドが使用しているマスタースライドは、レイアウトを通じて取得することもできます：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。[BaseSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/) を継承しているため、通常スライドやレイアウトスライドで使用される多くのスライドプロパティを公開しています。マスター固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) API ページに一覧されています。

一般的に使用されるマスタースライドのメンバーは以下のとおりです：

| メンバー | 目的 |
| --- | --- |
| `getBackground` | マスター レベルのスライド背景を設定します。 |
| `getShapes` | ロゴや画像フレーム、共有テキストなど、マスター上に配置された図形を保持します。 |
| `getLayoutSlides` | マスターに属するレイアウトスライドを保持します。 |
| `getThemeManager` | マスターのテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager` | マスターおよびその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides` | レイアウトを介してマスターに依存している通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドに表示されます。ロゴ、透かし、装飾帯、その他繰り返し使用されるビジュアル要素に便利です。

以下の例は、最初のマスタースライドにロゴを追加します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

画像フレームの詳細については、[画像フレーム](/slides/ja/php-java/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライドで定義されます。マスタースライドは、これらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、スライドマスタービューでプレースホルダーコマンドが利用できます。

![PowerPoint スライドマスタービューでのプレースホルダー挿入コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

マスタースライドに既に存在するプレースホルダーシェイプをフォーマットすることもできます。以下の例は、タイトルプレースホルダーを見つけて線形グラデーション塗りつぶしを適用します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![通常スライドに継承されるフォーマット済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーやテキスト書式設定の詳細オプションについては、[プレースホルダー内のプロンプトテキスト設定](/slides/ja/php-java/manage-placeholder/) および [テキスト書式設定](/slides/ja/php-java/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターベースの背景は、上書きしないレイアウトやスライドに継承されます。以下の例は、最初のマスタースライドに単色背景色を設定します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

関連トピックについては、[プレゼンテーションの背景](/slides/ja/php-java/presentation-background/) と [プレゼンテーションテーマ](/slides/ja/php-java/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションへクローンする**

[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) の `addClone` を使用して、マスタースライドを別のプレゼンテーションにコピーします。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

通常スライドとそのマスターを一緒にクローンする必要がある場合は、[スライドのクローン](/slides/ja/php-java/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションには複数のマスタースライドを含めることができます。異なるセクションで異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理のための PowerPoint コマンド](slide-master_9.jpg)

以下の例は、デフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、そしてそのレイアウトに基づく新しいスライドを追加します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **スライドマスターの比較**

マスタースライドは、[BaseSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/) から継承された `equals` メソッドで比較できます。比較は構造や静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他のスライド設定）をチェックしますが、スライド ID などの固有識別子や、現在の日付などの動的プレースホルダー値は比較しません。

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

詳細については、[プレゼンテーションスライドの比較](/slides/ja/php-java/compare-slides/) を参照してください。

## **スライドマスタービューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/) の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御します。以下の例は、プレゼンテーションをスライドマスタービューで開きます：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ビュー設定の詳細については、[プレゼンテーションの保存](/slides/ja/php-java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズが縮小し、テンプレートの保守が簡素化されます。

[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) の `removeUnused` を使用して、`getMasters` コレクションから未使用のマスターを削除します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[Compress](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/) クラスの低コード `removeUnusedMasterSlides` メソッドも使用できます：

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターは、テーマ、背景、共通の図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの特定の配置を定義します。通常スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含めることはできますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。異なるセクションで異なるビジュアルシステムやブランディングが必要な場合は、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有のビジュアル要素や共有書式設定はマスタースライドに配置し、コンテンツ用プレースホルダーは通常スライドが使用するレイアウトに置きます。

**まだ使用されているマスタースライドを削除できますか？**

いいえ。依存しているスライドがあるマスタースライドは、直接安全に削除できません。まずそのスライドを別のマスターの下のレイアウトに移動するか、未使用のマスターのみを削除するクリーンアップメソッドを使用してください。