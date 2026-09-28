---
title: PHP でスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
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
- タイトル と コンテンツ
- セクション ヘッダー
- 2 カラム コンテンツ
- 比較
- タイトル のみ
- 空白 レイアウト
- キャプション付き コンテンツ
- キャプション付き 画像
- タイトル と 縦テキスト
- 縦 タイトル と テキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java を介して PHP 用 Aspose.Slides のスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用することで、スライドは一貫した構造を持ちつつ、各スライドが独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **タイトルスライド**: タイトルとサブタイトルのプレースホルダーを含みます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーを含みます。
- **空白**: コンテンツプレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の3つの関連レベルがあります：

1. A [master slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects. → **マスタースライド**は、テーマ、共有書式、背景、および共通オブジェクトを定義します。
2. A [layout slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders. → **レイアウトスライド**はマスターに属し、特定のプレースホルダー配置を定義します。
3. A [normal slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide. → **通常スライド**は1つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

通常スライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。通常スライドに直接設定された値は、そのレベルで継承された値を上書きします。通常スライドが作成されると、プレースホルダー形状は選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツは通常スライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の通常スライドに自動的に対応するプレースホルダー形状は追加されません。

この関係には2つの重要な結果があります：

- レイアウト上の継承された書式や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。すでに使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。先に依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトだけを削除してください。

この階層の最上位レベルの詳細については、[Slide Master](/slides/ja/php-java/slide-master/) を参照してください。

スライドまたは共有レイアウト上で継承されたロゴや装飾的なマスター形状を非表示にする方法は、[Control the Visibility of Master Graphics](/slides/ja/php-java/slide-master/) を参照してください。この例は同じマスターを使用する2枚のスライドを比較しています。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準的な PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理できない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスター上で **Title and Content** を探します。該当レイアウトがない場合は、意図的に **Blank** にフォールバックします。2 番目の null チェックは、プレゼンテーションにカスタムレイアウトだけが含まれる可能性があるために必要です。選択されたレイアウトは、[Slide.setLayoutSlide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/#setLayoutSlide) メソッドを介して最初の通常スライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された普通の図形は削除されません。ただし、プレースホルダーの位置、継承書式、および既存プレースホルダーと新レイアウト間の対応が変わる可能性があるため、レイアウトが大きく異なる場合は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存レイアウトを選択しており、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterlayoutslidecollection/#add) メソッドを呼び出します。

次の例は常に **Title and Content** レイアウトを `Report Title and Content` という名前で新規作成し、それに基づく通常スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

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

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトが既に存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダーの追加**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドは、レイアウトにプレースホルダー形状を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `LayoutPlaceholderManager` メソッド |
| --------------------------- | ----------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

次の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加してから、変更されたレイアウトを使用する通常スライドを作成します。順序は意図的です。プレースホルダーは通常スライドが作成される前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダー形状を生成できます。

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

結果：

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加したレイアウトプレースホルダーは既存の通常スライドには自動的に反映されません。プレゼンテーションのコピーでレイアウト変更をテストし、すべての依存スライドを確認してください。
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

特定のレイアウトを削除するには、まずそのレイアウトの [hasDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#hasDependingSlides) または [getDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getDependingSlides) メソッドを使用します。削除前に依存スライドを別のレイアウトに再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでのフッター表示の制御**

レイアウトには独自のフッター、スライド番号、日付/時刻プレースホルダーがあります。[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) メソッドを使用して、特定のレイアウトのこれらプレースホルダーを制御できます。たとえば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは表示しないといったケースに便利です。

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

## **マスターとその子レイアウトでのフッター表示の制御**

マスター階層全体で一貫したフッター設定を適用するには、[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslide/#getHeaderFooterManager) メソッドを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/php-java/aspose.slides/masterslideheaderfootermanager/) の伝搬メソッドは、マスターとその依存レイアウトスライドおよび通常スライドに対して動作し、単一の通常スライドだけを対象にすることはできません。

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

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を1つ定義します。通常スライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**あるプレゼンテーションから別のプレゼンテーションへレイアウトスライドをコピーできますか？**

はい。目的のコレクションに [addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/globallayoutslidecollection/#addClone) メソッドでコピーを追加します。コピー先のプレゼンテーションでは、フォント、テーマ、画像、その他ソースレイアウトが使用するリソースも確認してください。

**すでに使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承します（ローカルで上書きしていない限り）。プレースホルダーのジオメトリや継承されたスタイルが多くのスライドで同時に変わる可能性があります。編集前に [getDependingSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/layoutslide/#getDependingSlides) で影響を受けるスライドを特定してください。

**まだ使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pptxeditexception/) をスローします。先に依存スライドを別のレイアウトに再割り当てするか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用して未参照のレイアウトだけを削除してください。