---
title: Javaでスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/java/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッター表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2つのコンテンツ
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でスライドレイアウトを管理およびカスタマイズします。レイアウトタイプ、プレースホルダー制御、フッター表示を Java のコード例で確認できます。"
---

## **概要**

スライドレイアウトは、スライド上のプレースホルダーボックスの配置とコンテンツの書式設定を定義します。利用可能なプレースホルダーとその表示位置を制御します。スライドレイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫してデザインできます。PowerPoint で最も一般的なスライドレイアウトは次のとおりです。

**Title Slide layout** – タイトル用プレースホルダーとサブタイトル用プレースホルダーの 2 つが含まれます。

**Title and Content layout** – 上部に小さなタイトルプレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメインコンテンツ用の大きなプレースホルダーが配置されます。

**Blank layout** – プレースホルダーがなく、スライドを一から設計するための完全なコントロールが提供されます。

スライドレイアウトはスライドマスターの一部であり、プレゼンテーション全体のレイアウトスタイルを定義する最上位スライドです。スライドマスターを通じてレイアウトスライドにアクセスし、種類、名前、または一意の ID で変更できます。または、プレゼンテーション内で特定のレイアウトスライドを直接編集することも可能です。

Aspose.Slides for Java でスライドレイアウトを操作するには、次を使用します。

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスの [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) と [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) メソッド
- [ILayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/)、[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslideheaderfootermanager/) などの型

{{% alert title="Info" color="info" %}}
マスタースライドの操作方法の詳細については、[Slide Master](/slides/ja/java/slide-master/) 記事をご覧ください。
{{% /alert %}}

## **プレゼンテーションへのスライドレイアウトの追加**

スライドの外観と構造をカスタマイズするために、新しいレイアウトスライドをプレゼンテーションに追加する必要があります。Aspose.Slides for Java は、特定のレイアウトが既に存在するかどうかを確認し、必要に応じて新規作成し、そのレイアウトに基づいてスライドを挿入する機能を提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/) にアクセスします。
1. コレクション内に目的のレイアウトスライドが既に存在するか確認します。存在しない場合は必要なレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づく空のスライドを追加します。
1. プレゼンテーションを保存します。

以下の Java コードは、PowerPoint プレゼンテーションにスライドレイアウトを追加する方法を示しています。
```java
// PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // レイアウトスライドの種類を順に確認し、レイアウトスライドを選択します。
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // プレゼンテーションにすべてのレイアウトタイプが含まれていない状況です。
        // プレゼンテーションファイルには Blank と Custom のレイアウトタイプのみが含まれています。
        // ただし、カスタムタイプのレイアウトスライドは認識可能な名前を持つ場合があります、
        // 例えば "Title"、"Title and Content" などで、レイアウトスライドの選択に使用できます。
        // プレースホルダー形状の種類セットに依存することもできます。
        // 例として、Title スライドは Title プレースホルダーのみを持つべきです、など。
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // 追加したレイアウトスライドを使用して空のスライドを追加します。
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **未使用レイアウトスライドの削除**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) クラスの [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) メソッドを提供し、不要または未使用のレイアウトスライドを削除できます。

以下の Java コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています。
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **スライドレイアウトへのプレースホルダーの追加**

Aspose.Slides は、[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) メソッドを提供し、レイアウトスライドに新しいプレースホルダーを追加できます。

このマネージャーには、次のプレースホルダータイプに対応するメソッドがあります。

| PowerPoint プレースホルダー | ILayoutPlaceholderManager メソッド |
| --------------------------- | ----------------------------------- |
| ![コンテンツ](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![コンテンツ (縦)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![テキスト](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![テキスト (縦)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![画像](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![チャート](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![表](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![メディア](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![オンライン画像](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

以下の Java コードは、Blank レイアウトスライドに新しいプレースホルダーシェイプを追加する方法を示しています。
```java
Presentation presentation = new Presentation();
try {
    // Blankレイアウトスライドを取得します。
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // レイアウトスライドのプレースホルダーマネージャーを取得します。
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Blankレイアウトスライドにさまざまなプレースホルダーを追加します。
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Blankレイアウトを使用して新しいスライドを追加します。
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The placeholders on the layout slide](add_placeholders.png)

## **レイアウトスライドのフッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストなどのフッター要素は、スライドレイアウトに応じて表示・非表示を切り替えることができます。Aspose.Slides for Java は、これらフッタープレースホルダーの表示状態を制御でき、特定のレイアウトだけフッター情報を表示し、他のレイアウトはクリーンに保つことが可能です。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでレイアウトスライドを取得します。
1. スライドフッタープレースホルダーを表示に設定します。
1. スライド番号プレースホルダーを表示に設定します。
1. 日付・時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の Java コードは、スライドフッターの表示状態を設定する方法を示しています。
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **スライドの子フッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタムテキストなどのフッター要素は、マスタースライドレベルで制御でき、すべてのレイアウトスライドに一貫したフッター情報を提供します。Aspose.Slides for Java は、マスタースライド上のこれらフッタープレースホルダーの表示と内容を設定し、すべての子レイアウトスライドへその設定を伝搬させることができます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでマスタースライドを取得します。
1. マスターとすべての子フッタープレースホルダーを表示に設定します。
1. マスターとすべての子スライド番号プレースホルダーを表示に設定します。
1. マスターとすべての子日付・時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の Java コードは、この操作を実演しています。
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドは全体のテーマとデフォルトの書式設定を定義し、レイアウトスライドはさまざまなコンテンツタイプに対するプレースホルダーの具体的な配置を定義します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい、[getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) メソッドで取得できるレイアウトスライドコレクションからレイアウトスライドをクローンし、`addClone` メソッドを使用して別のプレゼンテーションに挿入できます。

**使用中のレイアウトスライドを削除するとどうなりますか？**

プレゼンテーション内で少なくとも 1 つのスライドが参照しているレイアウトスライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/) をスローします。この問題を回避するには、使用されていないレイアウトスライドだけを安全に削除できる [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) を使用してください。