---
title: Androidでスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/androidjava/slide-layout/
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
- 縦のタイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Androidでスライドレイアウトを管理およびカスタマイズします。レイアウトタイプ、プレースホルダーの制御、フッター表示をJavaコード例で確認できます。"
---

## **概要**

スライドレイアウトは、プレースホルダー ボックスの配置とスライド上のコンテンツの書式設定を定義します。利用できるプレースホルダーとその表示位置を制御します。スライドレイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫して設計できます。PowerPoint で最も一般的なスライドレイアウトには次のものがあります。

**Title Slide layout** – タイトルとサブタイトル用の 2 つのテキスト プレースホルダーが含まれます。

**Title and Content layout** – 上部に小さなタイトル プレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメイン コンテンツ用の大きなプレースホルダーが配置されます。

**Blank layout** – プレースホルダーがなく、スライドをゼロからデザインできます。

スライドレイアウトはスライドマスターの一部であり、プレゼンテーション全体のレイアウト スタイルを定義する最上位スライドです。レイアウト スライドはスライドマスターから、タイプ、名前、または一意の ID でアクセスおよび変更できます。または、プレゼンテーション内で特定のレイアウト スライドを直接編集することもできます。

Aspose.Slides for Android でスライドレイアウトを操作するには、次のものを使用します。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスの [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) や [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) などのメソッド
- [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)、[ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) などの型

{{% alert title="Info" color="info" %}}
マスタースライドの操作方法の詳細は、[Slide Master](/slides/ja/androidjava/slide-master/) 記事をご覧ください。
{{% /alert %}}

## **プレゼンテーションへのスライドレイアウトの追加**

スライドの外観や構造をカスタマイズするために、プレゼンテーションに新しいレイアウト スライドを追加する必要がある場合があります。Aspose.Slides for Android を使用すると、特定のレイアウトが既に存在するか確認し、必要に応じて新規作成し、そのレイアウトに基づいてスライドを挿入できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/) にアクセスします。
1. コレクション内に目的のレイアウト スライドが既に存在するか確認します。存在しない場合は必要なレイアウト スライドを追加します。
1. 新しいレイアウト スライドを基に空のスライドを追加します。
1. プレゼンテーションを保存します。

以下の Java コードは、PowerPoint プレゼンテーションにスライドレイアウトを追加する方法を示しています:
```java
// PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // レイアウトスライドのタイプを順に確認して、レイアウトスライドを選択します。
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // プレゼンテーションにすべてのレイアウトタイプが含まれていない状況です。
        // プレゼンテーションファイルには Blank と Custom のレイアウトタイプのみが含まれています。
        // ただし、カスタムタイプのレイアウトスライドは認識しやすい名前が付いている場合があります、
        // 例えば "Title", "Title and Content", etc., で、レイアウトスライドの選択に使用できます。
        // プレースホルダー形状のタイプ集合に依存することもできます。
        // 例えば、Title スライドは Title プレースホルダータイプのみを持つべきです。
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

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスの [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) メソッドを提供し、不要または未使用のレイアウト スライドを削除できます。

以下の Java コードは、PowerPoint プレゼンテーションからレイアウト スライドを削除する方法を示しています:
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

Aspose.Slides は、[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) メソッドを提供し、レイアウト スライドに新しいプレースホルダーを追加できます。

このマネージャーは、次のプレースホルダー タイプに対応したメソッドを含みます:

| PowerPoint プレースホルダー | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) メソッド |
| --------------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x,float y,float width,float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x,float y,float width,float height) |
| ![Text](text.png) | addTextPlaceholder(float x,float y,float width,float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x,float y,float width,float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x,float y,float width,float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x,float y,float width,float height) |
| ![Table](table.png) | addTablePlaceholder(float x,float y,float width,float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x,float y,float width,float height) |
| ![Media](media.png) | addMediaPlaceholder(float x,float y,float width,float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x,float y,float width,float height) |

以下の Java コードは、Blank レイアウト スライドに新しいプレースホルダー シェイプを追加する方法を示しています:
```java
Presentation presentation = new Presentation();
try {
    // Blank レイアウトスライドを取得します。
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // レイアウトスライドのプレースホルダーマネージャーを取得します。
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Blank レイアウトスライドにさまざまなプレースホルダーを追加します。
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Blank レイアウトを使用して新しいスライドを追加します。
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果:

![The placeholders on the layout slide](add_placeholders.png)

## **レイアウトスライドのフッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタム テキストなどのフッター要素は、スライドレイアウトに応じて表示/非表示を切り替えることができます。Aspose.Slides for Android を使用すると、これらフッタープレースホルダーの表示状態を制御できます。特定のレイアウトでフッター情報を表示し、他のレイアウトはシンプルに保ちたい場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでレイアウト スライドを取得します。
1. スライドフッター プレースホルダーを表示に設定します。
1. スライド番号 プレースホルダーを表示に設定します。
1. 日付/時刻 プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の Java コードは、スライドフッターの表示状態を設定する方法を示しています:
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

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタム テキストなどのフッター要素をマスタースライドレベルで制御し、すべてのレイアウト スライドに一貫した表示を持たせることができます。Aspose.Slides for Android は、マスタースライド上のフッタープレースホルダーの表示と内容を設定し、これらの設定をすべての子レイアウト スライドに伝播させる機能を提供します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでマスタースライドを取得します。
1. マスターとすべての子フッタープレースホルダーを表示に設定します。
1. マスターとすべての子スライド番号プレースホルダーを表示に設定します。
1. マスターとすべての子日付/時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

以下の Java コードは、この操作を示しています:
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

マスタースライドは全体のテーマと既定の書式設定を定義し、レイアウトスライドはコンテンツタイプごとのプレースホルダー配置を定義します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい、[getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) メソッドで取得できるレイアウトスライドコレクションからレイアウトスライドをクローンし、`addClone` メソッドを使用して別のプレゼンテーションに挿入できます。

**使用中のスライドが参照しているレイアウトスライドを削除しようとするとどうなりますか？**

プレゼンテーション内で少なくとも 1 つのスライドが参照しているレイアウトスライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) をスローします。これを回避するには、未使用のレイアウトスライドのみを安全に削除できる [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) を使用してください。