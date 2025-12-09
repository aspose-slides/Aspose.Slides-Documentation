---
title: JavaScript でスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/nodejs-java/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーション デザイン
- スライド デザイン
- 未使用レイアウト
- フッターの表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2 つのコンテンツ
- 比較
- タイトルのみ
- ブランクレイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でスライドレイアウトの管理とカスタマイズ方法を学びます。レイアウトの種類、プレースホルダーの制御、フッターの表示、そして JavaScript のコード例を通じたレイアウト操作について解説します。"
---

## **概要**

スライド レイアウトは、スライド上のプレースホルダー ボックスの配置とコンテンツの書式設定を定義します。利用可能なプレースホルダーとその表示位置を制御します。スライド レイアウトを使用すると、シンプルなものから複雑なものまで、プレゼンテーションを迅速かつ一貫してデザインできます。PowerPoint で最も一般的なスライド レイアウトは次のとおりです：

**タイトル スライド レイアウト** – タイトル用プレースホルダーとサブタイトル用プレースホルダーの 2 つが含まれます。

**タイトルとコンテンツ レイアウト** – 上部に小さめのタイトル プレースホルダー、下部にテキスト、箇条書き、チャート、画像などのメイン コンテンツ用プレースホルダーが配置されます。

**ブランク レイアウト** – プレースホルダーがなく、スライドをゼロからデザインできる自由度が提供されます。

スライド レイアウトはスライド マスターの一部であり、プレゼンテーション全体のレイアウト スタイルを定義する最上位スライドです。スライド マスター経由でレイアウト スライドにアクセスし、タイプ、名前、または固有 ID で取得または変更できます。あるいは、プレゼンテーション内で特定のレイアウト スライドを直接編集することも可能です。

Aspose.Slides for Node.js でスライド レイアウトを操作するには、次のものを使用します：

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスの [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) および [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) メソッド
- [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/)、[LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/)、[LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) などの型

{{% alert title="Info" color="info" %}}
マスタースライドの操作方法については、[Slide Master](/slides/ja/nodejs-java/slide-master/) 記事をご参照ください。
{{% /alert %}}

## **プレゼンテーションへのスライド レイアウトの追加**

スライドの外観や構造をカスタマイズするために、新しいレイアウト スライドをプレゼンテーションに追加する必要があります。Aspose.Slides for Node.js では、特定のレイアウトが既に存在するか確認し、必要に応じて新規作成し、そのレイアウトに基づいてスライドを挿入できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/) にアクセスします。  
1. 目的のレイアウト スライドがコレクションに存在するかチェックし、存在しなければ追加します。  
1. 新しいレイアウト スライドを基に空のスライドを追加します。  
1. プレゼンテーションを保存します。

以下の JavaScript コードは、PowerPoint プレゼンテーションにスライド レイアウトを追加する方法を示しています：
```js
// PowerPoint ファイルを表す Presentation クラスのインスタンスを作成します。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // レイアウト スライドの種類を走査して、レイアウト スライドを選択します。
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // プレゼンテーションにすべてのレイアウト タイプが含まれていない状況です。
        // プレゼンテーション ファイルには Blank と Custom のレイアウト タイプしか含まれていません。
        // ただし、カスタム タイプのレイアウト スライドは認識できる名前を持つ場合があります、
        // 例として "Title", "Title and Content", etc., which can be used for layout slide selection.
        // プレースホルダー シェイプ タイプの集合に頼ることもできます。
        // 例として、Title スライドは Title プレースホルダー タイプだけを持つべきです。
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // 追加したレイアウト スライドを使用して空のスライドを追加します。
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // プレゼンテーションをディスクに保存します。
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **未使用レイアウト スライドの削除**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) クラスの [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) メソッドを提供し、不要または未使用のレイアウト スライドを削除できます。

以下の JavaScript コードは、PowerPoint プレゼンテーションからレイアウト スライドを削除する方法を示しています：
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **スライド レイアウトへのプレースホルダーの追加**

Aspose.Slides は、[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドを提供し、レイアウト スライドに新しいプレースホルダーを追加できます。

このマネージャーは、以下のプレースホルダー タイプに対応するメソッドを提供します：

| PowerPoint プレースホルダー          | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) メソッド |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

以下の JavaScript コードは、Blank レイアウト スライドに新しいプレースホルダー シェイプを追加する方法を示しています：
```js
let presentation = new aspose.slides.Presentation();
try {
    // Blank レイアウト スライドを取得します。
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // レイアウト スライドのプレースホルダー マネージャーを取得します。
    let placeholderManager = layout.getPlaceholderManager();

    // Blank レイアウト スライドにさまざまなプレースホルダーを追加します。
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Blank レイアウトで新しいスライドを追加します。
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


結果：

![The placeholders on the layout slide](add_placeholders.png)

## **レイアウト スライドのフッター表示設定**

PowerPoint プレゼンテーションでは、フッター要素（日付、スライド番号、カスタム テキスト）をレイアウトに応じて表示・非表示を切り替えることができます。Aspose.Slides for Node.js は、これらフッター プレースホルダーの表示状態を制御でき、特定のレイアウトだけフッター情報を表示し、他はクリーンなままにできます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでレイアウト スライドの参照を取得します。  
1. スライド フッター プレースホルダーを表示に設定します。  
1. スライド番号 プレースホルダーを表示に設定します。  
1. 日付/時刻 プレースホルダーを表示に設定します。  
1. プレゼンテーションを保存します。

以下の JavaScript コードは、スライド フッターの表示設定と関連操作を示しています：
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **スライドの子フッター表示設定**

PowerPoint プレゼンテーションでは、日付、スライド番号、カスタム テキストなどのフッター要素をマスタースライド レベルで制御し、すべての子レイアウト スライドに一貫した情報を提供できます。Aspose.Slides for Node.js は、マスタースライド上でフッター プレースホルダーの表示状態と内容を設定し、これらの設定をすべての子レイアウト スライドに伝播させることができます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでマスタースライドの参照を取得します。  
1. マスターとすべての子フッター プレースホルダーを表示に設定します。  
1. マスターとすべての子スライド番号 プレースホルダーを表示に設定します。  
1. マスターとすべての子日付/時刻 プレースホルダーを表示に設定します。  
1. プレゼンテーションを保存します。

以下の JavaScript コードは、この操作を示しています：
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**マスタースライドとレイアウト スライドの違いは何ですか？**

マスタースライドは全体的なテーマとデフォルト書式を定義し、レイアウト スライドはコンテンツの種類ごとにプレースホルダーの具体的な配置を定義します。

**レイアウト スライドを別のプレゼンテーションにコピーできますか？**

はい、[getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) メソッドで取得できるレイアウト スライド コレクションからレイアウト スライドをクローンし、`addClone` メソッドを使用して別のプレゼンテーションに挿入できます。

**使用中のスライドが参照しているレイアウト スライドを削除するとどうなりますか？**

プレゼンテーション内で少なくとも 1 つのスライドが参照しているレイアウト スライドを削除しようとすると、Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) をスローします。この問題を回避するには、使用されていないレイアウト スライドだけを安全に削除できる [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用してください。