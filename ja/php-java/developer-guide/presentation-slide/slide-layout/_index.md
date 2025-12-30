---
title: PHPでスライドレイアウトを適用または変更
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/php-java/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッターの表示/非表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2コンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP（Java経由）でスライドレイアウトを管理・カスタマイズします。レイアウトタイプ、プレースホルダーの制御、フッターの表示/非表示をコード例で確認できます。"
---

## **概要**

スライドレイアウトは、スライド上のプレースホルダーボックスの配置とコンテンツの書式設定を定義します。利用可能なプレースホルダーとその表示位置を制御します。スライドレイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫してデザインできます。PowerPointで最も一般的なスライドレイアウトには次のものがあります。

**タイトル スライド レイアウト** – タイトル用とサブタイトル用の 2 つのテキストプレースホルダーが含まれます。

**タイトルとコンテンツ レイアウト** – 上部に小さなタイトルプレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメインコンテンツ用の大きなプレースホルダーがあります。

**空白レイアウト** – プレースホルダーがなく、スライドをゼロからデザインできる完全な自由度があります。

スライドレイアウトはスライドマスターの一部であり、プレゼンテーション全体のレイアウトスタイルを定義する最上位のスライドです。レイアウトスライドはスライドマスターを介して、タイプ、名前、または一意の ID でアクセスおよび変更できます。または、プレゼンテーション内で特定のレイアウトスライドを直接編集することも可能です。

Aspose.Slides for PHP でスライドレイアウトを操作するには、以下を使用できます。

- **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)** クラスの下にある **[getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides)** および **[getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters)** メソッド
- **[LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)**、**[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)**、**[LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/)**、および **[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)** タイプ

{{% alert title="Info" color="info" %}}

マスタースライドの操作方法の詳細は、[Slide Master](/slides/ja/php-java/slide-master/) 記事をご覧ください。

{{% /alert %}}

## **スライドレイアウトをプレゼンテーションに追加**

スライドの外観と構造をカスタマイズするために、プレゼンテーションに新しいレイアウトスライドを追加する必要がある場合があります。Aspose.Slides for PHP を使用すると、特定のレイアウトが既に存在するかどうかを確認し、必要に応じて新規追加し、そのレイアウトに基づいてスライドを挿入できます。

1. **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)** クラスのインスタンスを作成します。  
2. **[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)** にアクセスします。  
3. コレクション内に目的のレイアウトスライドが既に存在するか確認します。存在しない場合は必要なレイアウトスライドを追加します。  
4. 新しいレイアウトスライドに基づいて空のスライドを追加します。  
5. プレゼンテーションを保存します。

以下の PHP コードは、PowerPoint プレゼンテーションにスライドレイアウトを追加する方法を示しています:
```php
// PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("Sample.pptx");
try {
    // レイアウトスライドの種類を順に確認して、レイアウトスライドを選択します。
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // プレゼンテーションにすべてのレイアウト種類が含まれていない状況です。
        // プレゼンテーション ファイルには Blank と Custom のレイアウト種類のみが含まれています。
        // ただし、カスタムタイプのレイアウトスライドは認識可能な名前を持っている場合があります、
        // たとえば「Title」や「Title and Content」などで、レイアウトスライドの選択に利用できます。
        // プレースホルダー形状の種類のセットに依存することもできます。
        // 例として、Title スライドは Title プレースホルダータイプだけを持つべきです。
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 追加したレイアウトスライドを使用して空のスライドを追加します。
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // プレゼンテーションをディスクに保存します。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **未使用のレイアウトスライドを削除**

Aspose.Slides は **[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)** クラスの **[removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)** メソッドを提供し、不要または未使用のレイアウトスライドを削除できます。

以下の PHP コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **レイアウトスライドにプレースホルダーを追加**

Aspose.Slides は **[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager)** メソッドを提供し、レイアウトスライドに新しいプレースホルダーを追加できます。

このマネージャーは次のプレースホルダータイプ用のメソッドを含みます:

| PowerPoint プレースホルダー               | [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) メソッド |
| ----------------------------------- | ------------------------------------------------------------ |
| ![コンテンツ](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![コンテンツ (縦向き)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![テキスト](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![テキスト (縦向き)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![画像](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![チャート](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![表](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![メディア](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![オンライン画像](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

以下の PHP コードは、空白レイアウトスライドに新しいプレースホルダーシェイプを追加する方法を示しています:
```php
$presentation = new Presentation();
try {
    // Blank のレイアウトスライドを取得します。
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // レイアウトスライドのプレースホルダー マネージャーを取得します。
    $placeholderManager = $layout->getPlaceholderManager();

    // Blank のレイアウトスライドにさまざまなプレースホルダーを追加します。
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Blank のレイアウトを使用して新しいスライドを追加します。
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


結果:

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

## **レイアウトスライドのフッター表示を設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストなどのフッター要素を、レイアウトに応じて表示/非表示にできます。Aspose.Slides for PHP は、これらフッタープレースホルダーの可視性を制御する機能を提供します。特定のレイアウトだけフッター情報を表示し、他のレイアウトはシンプルに保ちたい場合に便利です。

1. **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)** クラスのインスタンスを作成します。  
2. インデックスでレイアウトスライドの参照を取得します。  
3. スライドフッタープレースホルダーを表示に設定します。  
4. スライド番号プレースホルダーを表示に設定します。  
5. 日付/時刻プレースホルダーを表示に設定します。  
6. プレゼンテーションを保存します。

以下の PHP コードは、スライドフッターの可視性を設定する方法を示しています:
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **スライドの子フッター表示を設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストなどのフッター要素をマスタースライドレベルで制御し、すべてのレイアウトスライドに一貫性を持たせることができます。Aspose.Slides for PHP は、マスタースライド上のこれらフッタープレースホルダーの可視性と内容を設定し、すべての子レイアウトスライドにその設定を伝播させる機能を提供します。この方法により、プレゼンテーション全体で統一されたフッター情報が保たれます。

1. **[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)** クラスのインスタンスを作成します。  
2. インデックスでマスタースライドの参照を取得します。  
3. マスターとすべての子レイアウトスライドのフッタープレースホルダーを表示に設定します。  
4. マスターとすべての子レイアウトスライドのスライド番号プレースホルダーを表示に設定します。  
5. マスターとすべての子レイアウトスライドの日付/時刻プレースホルダーを表示に設定します。  
6. プレゼンテーションを保存します。

以下の PHP コードはこの操作を示しています:
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **よくある質問**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドは全体的なテーマとデフォルト書式を定義し、レイアウトスライドは異なるコンテンツタイプ向けにプレースホルダーの具体的な配置を定義します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい。`addClone` メソッドを使用して、[getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) メソッドで取得できるレイアウトスライドコレクションからレイアウトスライドをクローンし、別のプレゼンテーションに挿入できます。

**使用中のレイアウトスライドを削除するとどうなりますか？**

プレゼンテーション内で少なくとも 1 つのスライドが参照しているレイアウトスライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) をスローします。この問題を回避するには、使用されていないレイアウトスライドだけを安全に削除できる **[removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)** を使用してください。