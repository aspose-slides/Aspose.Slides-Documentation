---
title: PHPでプレゼンテーションのスライドマスターを管理
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/php-java/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPTマスタースライド
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
description: "Aspose.Slides for PHP via Javaでスライドマスターを管理します。PowerPoint と OpenDocument のプレゼンテーションでマスタースライドにアクセス、編集、クローン、比較、削除を行う方法です。"
---
## **概要**

**スライドマスター** は、スライドのグループに対して共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することで、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つのが一般的な方法です。

Aspose.Slides for PHP via Java も同じモデルをサポートしています。プレゼンテーションは 1 つ以上のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを保持できます。通常のスライドは直接マスタースライドを参照することはなく、レイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属しています。

階層構造は次のとおりです。

1. **スライドマスター** - 共有デザインとテーマを定義します。  
1. **レイアウトスライド** - プレースホルダーの配置とレイアウトレベルの書式設定を定義します。  
1. **通常スライド** - 実際のプレゼンテーションコンテンツを保持し、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation.getMasters](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getMasters) メソッドで取得でき、[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) オブジェクトが返されます。

{{% alert color="info" title="Inheritance" %}}
複数のレベルで同じプロパティが定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[スライドレイアウトの適用または変更](/slides/ja/php-java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![PowerPoint の表示タブにあるスライドマスター コマンド](slide-master_3.jpg)

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

通常スライドのレイアウトから、使用されているマスタースライドを取得することもできます：

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

マスタースライドはスライドに似たオブジェクトです。[BaseSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/) を継承しているため、通常スライドやレイアウトスライドと同じスライドプロパティの多くを公開します。マスター固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) API ページに一覧されています。

主なマスタースライドメンバーは次のとおりです。

| メンバー | 目的 |
| --- | --- |
| `getBackground` | マスターレベルのスライド背景を設定します。 |
| `getShapes` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `getLayoutSlides` | マスターに属するレイアウトスライドを格納します。 |
| `getThemeManager` | マスターのテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides` | レイアウトを介してマスターに依存する通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに表示されます。ロゴ、透かし、装飾バンド、その他繰り返し使用するビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します：

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

画像フレームの詳細については、[ピクチャーフレーム](/slides/ja/php-java/picture-frame/) を参照してください。

## **マスター グラフィックの表示/非表示を制御する**

[BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#setShowMasterShapes) を使用すると、マスターから継承されたロゴや装飾形状などのグラフィックを削除せずに非表示にできます。非表示にしたいスライドで [Slide::setShowMasterShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#setShowMasterShapes) に `false` を渡し、表示したいスライドでは `true` のままにします。

次の単体例は、マスター上に青い装飾バンドを作成し、同じ空白レイアウトを使用する 2 枚のスライドを生成します。バンドは 1 枚目のスライドで表示され、2 枚目では非表示になります。入力プレゼンテーションや画像は不要です。

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

この例は新規プレゼンテーションに付属する **Blank** レイアウトを使用し、最初のスライドのプレースホルダーを削除します。

### **設定の適用範囲を選択する**

通常スライドは [Slide::getLayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#getLayoutSlide) と [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getMasterSlide) を通じてマスターにアクセスします。個々のスライドにプロパティを設定すると、そのスライドだけに影響します。`false` を [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#setShowMasterShapes) に渡すと、その共有レイアウトを使用するすべてのスライドでマスターグラフィックが非表示になります（各スライドの設定が `true` でも同様）。1 枚のスライドだけを非表示にしたい場合は、スライドのプロパティを変更し、共有レイアウトはそのままにします。

マスタースライド自体では可視性コントロールはサポートされていません。マスター上では [getShowMasterShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/#getShowMasterShapes) が常に `false` を返し、[setShowMasterShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/#setShowMasterShapes) に `true` を渡すと例外がスローされます。代わりに通常スライドまたはレイアウトに適用してください。

### **背景とグラフィックを区別する**

| 操作 | 効果 |
| --- | --- |
| マスターグラフィックを非表示にする | マスターから継承された図形を削除せずに可視性を制御します。 |
| スライドの背景塗りを変更する | 背景色、グラデーション、画像を変更します。マスターグラフィックは別個の形状として残り、背景の上に表示できます。詳細は [プレゼンテーションの背景](/slides/ja/php-java/presentation-background/) を参照してください。 |
| マスターから図形を削除する | 共有元の図形が削除され、以降そのマスターを使用するスライドからは利用できなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトが利用可能なプレースホルダーと配置位置を決定します。

PowerPoint では、スライドマスタービューでプレースホルダーコマンドが使用できます。

![PowerPoint スライドマスタービューのプレースホルダー挿入コマンド](slide-master_5.png)

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

既存のプレースホルダー形状の書式設定も可能です。次の例はタイトルプレースホルダーを見つけて線形グラデーション塗りを適用します：

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

![通常スライドが継承した書式設定済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーとテキスト書式設定の詳細は、[プレースホルダーのプロンプトテキスト設定](/slides/ja/php-java/manage-placeholder/) と [テキスト書式設定](/slides/ja/php-java/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスター背景はレイアウトや、上書きしないスライドに継承されます。次の例は最初のマスタースライドに単色背景色を設定します：

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

関連トピックは、[プレゼンテーションの背景](/slides/ja/php-java/presentation-background/) と [プレゼンテーションテーマ](/slides/ja/php-java/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションにクローンする**

[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) の `addClone` を使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

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

通常スライドとそのマスターをまとめてクローンする必要がある場合は、[スライドのクローン](/slides/ja/php-java/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。これは、セクションごとに異なるブランディングやページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入および管理用 PowerPoint コマンド](slide-master_9.jpg)

次の例はデフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、そのレイアウトに基づく新しいスライドを追加します：

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

マスタースライドは、[BaseSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/) から継承された `equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他スライド設定）を対象とし、スライド ID のような一意の識別子や現在の日付などの動的プレースホルダー値は比較対象に含まれません。

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

詳細は [プレゼンテーションスライドの比較](/slides/ja/php-java/compare-slides/) を参照してください。

## **スライドマスタービューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/viewproperties/) の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御できます。次の例はプレゼンテーションをスライドマスタービューで開きます：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

その他のビュー設定については、[プレゼンテーションの保存](/slides/ja/php-java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズが削減され、テンプレートの保守が簡素化されます。

[MasterSlideCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslidecollection/) の `removeUnused` を使用して、`getMasters` コレクションから未使用マスターを削除します：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

低コードの `removeUnusedMasterSlides` メソッドは、[Compress](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/) クラスからも利用できます：

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
スライドマスターはテーマ、背景、共通図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含められますか？**  
はい。プレゼンテーションは複数のスライドマスターを保持できます。セクションごとに異なるビジュアル体系やブランディングが必要な場合に、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**  
ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有ビジュアル要素や共通書式はマスタースライドに置き、コンテンツ用プレースホルダーは通常スライドが使用するレイアウトに配置します。

**使用中のマスタースライドを削除できますか？**  
できません。依存スライドがあるマスタースライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用マスターのみを削除するクリーンアップ手法を使用してください。