---
title: PHP でスライド レイアウトを適用または変更
linktitle: スライド レイアウト
type: docs
weight: 60
url: /ja/php-java/slide-layout/
keywords:
- スライド レイアウト
- コンテンツ レイアウト
- プレースホルダー
- プレゼンテーション デザイン
- スライド デザイン
- 未使用 レイアウト
- フッター 表示
- タイトル スライド
- タイトルとコンテンツ
- セクション ヘッダー
- 2 つのコンテンツ
- 比較
- タイトル のみ
- 空白 レイアウト
- キャプション付き コンテンツ
- キャプション付き 画像
- タイトルと縦書きテキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でスライド レイアウトを適用、作成、変更し、プレースホルダーを追加し、未使用のレイアウトを削除し、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライド全体に一貫した構造が与えられ、各スライドは独自のコンテンツを保持できます。

主なレイアウトは次のとおりです。

- **タイトル スライド**: タイトルとサブタイトルのプレースホルダーを含みます。
- **タイトルとコンテンツ**: タイトルプレースホルダーと汎用コンテンツ プレースホルダーを含みます。
- **空白**: コンテンツ プレースホルダーがなく、すべての図形を手動で配置したい場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには次の 3 つの関連レベルがあります。

1. A [master slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) はテーマ、共有書式、背景、共通オブジェクトを定義します。
1. A [layout slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) はマスターに属し、特定のプレースホルダー配置を定義します。
1. A [normal slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) は 1 つのレイアウトを使用し、そのスライド固有のコンテンツを保存します。

通常のスライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。通常のスライドで直接設定した値は、そのレベルで継承された値を上書きします。通常のスライドが作成されると、選択されたレイアウトからプレースホルダー形状が生成されますが、これらのプレースホルダーに入力されたコンテンツは通常のスライドに属します。

スライドを作成する前にレイアウトに必要なプレースホルダーを追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の通常スライドに自動的に対応するプレースホルダー形状は追加されません。

この関係には 2 つの重要な影響があります。

- レイアウト上の継承された書式や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- まだスライドで使用されているレイアウトは削除できません。先に依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位については、[Slide Master](/slides/ja/php-java/slide-master/) を参照してください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、テンプレートのソースを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は最初のマスター上で **Title and Content** を探します。そのレイアウトが利用できない場合は、意図的に **Blank** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトしか含まれていない可能性があるために必要です。選択されたレイアウトは、[Slide.setLayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#setLayoutSlide) メソッドを使って最初の通常スライドに適用されます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

スライドのレイアウトを変更しても、スライドに直接追加された通常の図形は削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウト間の対応が変わる可能性があるため、レイアウト間の大幅な違いを切り替える際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存レイアウトを選択しただけで、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクション上で [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterlayoutslidecollection/#add) メソッドを呼び出します。

次の例は常に **Title and Content** レイアウトを `Report Title and Content` という名前で新規追加し、そのレイアウトに基づく通常スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダー追加**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドは、レイアウトにプレースホルダー形状を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint Placeholder              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

次の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加した後、その修正済みレイアウトを使用する通常スライドを作成します。順序は意図的です。プレースホルダーは通常スライド作成前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダー形状を生成できます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存の通常スライドには自動的に反映されません。レイアウト変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) メソッドを使用して、通常スライドが参照していないレイアウトを削除します。このメソッドは、まだ使用中のレイアウトはそのまま残します。

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

特定のレイアウトを削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#hasDependingSlides) または [getDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getDependingSlides) メソッドを使用してください。依存スライドを別のレイアウトに再割り当てた後で [LayoutSlide.remove](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#remove) を呼び出します。使用中のレイアウトを削除しようとすると [PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドのフッター表示制御**

レイアウトには独自のフッター、スライド番号、日時プレースホルダーがあります。これらのプレースホルダーをレイアウト単位で制御するには、[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) メソッドを使用します。たとえば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは非表示にしたい場合に便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示可能にします。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **マスタと子レイアウトのフッター表示制御**

マスタ階層全体で一貫したフッター設定を適用するには、[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/#getHeaderFooterManager) メソッドを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslideheaderfootermanager/) の伝搬メソッドはマスターとその依存レイアウトスライドおよび通常スライドに作用し、単一の通常スライドだけを対象にはしません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を定義します。通常のスライドはそれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに対して [addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/globallayoutslidecollection/#addClone) メソッドでコピーを追加します。コピー元レイアウトで使用されているフォント、テーマ、画像、その他リソースも同時に確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承します（ローカルで書式やオブジェクトを上書きしていない限り）。プレースホルダーのジオメトリや継承スタイルが多くのスライドで一度に変わる可能性があります。編集前に [getDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getDependingSlides) で影響スライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを別のレイアウトに再割り当てるか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用して未参照のレイアウトのみを削除してください。