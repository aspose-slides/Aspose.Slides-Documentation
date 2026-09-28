---
title: JavaScript でスライド レイアウトを適用または変更する
linktitle: スライド レイアウト
type: docs
weight: 60
url: /ja/nodejs-java/slide-layout/
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
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、スライド レイアウトを適用、作成、変更し、プレースホルダーを追加し、未使用レイアウトを削除し、フッターの表示を制御します。"
---
## **概要**

スライド レイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライドが一貫した構造を持つようになり、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです。

- **Title Slide**: タイトル プレースホルダーとサブタイトル プレースホルダーを含みます。
- **Title and Content**: タイトル プレースホルダーと汎用コンテンツ プレースホルダーを含みます。
- **Blank**: コンテンツ プレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには次の 3 つの関連レベルがあります。

1. [マスタースライド](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) はテーマ、共有書式、背景、共通オブジェクトを定義します。
1. [レイアウトスライド](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) はマスターに属し、特定のプレースホルダー配置を定義します。
1. [通常スライド](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/) は 1 つのレイアウトを使用し、そのスライド用に入力されたコンテンツを保持します。

通常スライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。通常スライド上で直接設定された値は、そのレベルで継承された値を上書きします。通常スライドが作成されると、選択されたレイアウトからプレースホルダー 図形が生成され、プレースホルダーに入力されたコンテンツは通常スライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の通常スライドに自動的に対応するプレースホルダー 図形は追加されません。

この関係には重要な結果が 2 つあります。

- レイアウト上の継承書式や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。既に使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。先に依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位レベルの詳細については、 [Slide Master](/slides/ja/nodejs-java/slide-master/) を参照してください。

1 枚のスライドまたは共有レイアウト上で継承ロゴや装飾的なマスター図形を非表示にする方法については、 [Control the Visibility of Master Graphics](/slides/ja/nodejs-java/slide-master/) を参照してください。例では、同じマスターを使用する 2 枚のスライドを比較しています。

## **スライド レイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、 [SlideLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidelayouttype/) 値を使用します。レイアウト名はユーザーが編集でき、ローカライズ可能なため、テンプレートのソースを管理できない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスターで **Title and Content** を検索します。そのレイアウトが利用できない場合は、意図的に **Blank** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタム レイアウトのみが含まれる可能性があるために必要です。選択されたレイアウトは、 [Slide.setLayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#setLayoutSlide) メソッドを介して最初の通常スライドに適用されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

スライドのレイアウトを変更しても、スライドに直接追加された通常の図形は削除されません。ただし、プレースホルダーの位置、継承書式、および既存プレースホルダーと新レイアウト間の対応が変わる可能性があるため、レイアウトが大きく異なる場合は出力を確認してください。

## **レイアウト スライドの追加**

選択と作成は別々の操作です。前の例は既存レイアウトを選択しただけで、作成は行っていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) メソッドを呼び出します。

次の例は常に **Title and Content** レイアウトを `Report Title and Content` という名前で新規追加し、そのレイアウトに基づく通常スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、作成して重複させるのではなく、選択して再利用してください。

## **レイアウト スライドへのプレースホルダーの追加**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドは、レイアウトにプレースホルダー 図形を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー          | `LayoutPlaceholderManager` メソッド |
| ----------------------------------- | ----------------------------------- |
| ![コンテンツ](content.png)          | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![コンテンツ (縦)](contentV.png)    | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![テキスト](text.png)              | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![テキスト (縦)](textV.png)        | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![画像](picture.png)               | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![チャート](chart.png)             | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![テーブル](table.png)             | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![メディア](media.png)             | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![オンライン画像](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

次の例は **Blank** レイアウトの存在を確認し、4 つのプレースホルダーを追加してから、変更されたレイアウトを使用する通常スライドを作成します。順序は意図的で、プレースホルダーは通常スライド作成前に追加されるため、Aspose.Slides がそのスライド上に対応するプレースホルダー 図形を生成できます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![レイアウト スライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承書式や既存レイアウト プレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウト プレースホルダーは既存の通常スライドには自動的に反映されません。レイアウトの変更はプレゼンテーションのコピー上でテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウト スライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) メソッドを使用して、通常スライドが参照していないレイアウトを削除します。このメソッドは、まだ使用中のレイアウトはそのまま残します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

特定のレイアウトを削除するには、まずそのレイアウトの [hasDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) または [getDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) メソッドを使用します。依存スライドを別のレイアウトに再割り当ててから [LayoutSlide.remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#remove) を呼び出してください。使用中のレイアウトを削除しようとすると、 [PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウト スライド上のフッター表示の制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーをレイアウト単位で制御するには、 [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) メソッドを使用します。たとえば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは表示しないといったシナリオに便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示可能にします。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **マスターとその子レイアウト上のフッター表示の制御**

マスター階層全体で一貫したフッター設定を適用するには、 [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) メソッドを使用します。 [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslideheaderfootermanager/) の伝播メソッドはマスターとその依存レイアウト スライドおよび通常スライドに作用し、単一の通常スライドだけを対象にすることはできません。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を 1 つ定義します。通常スライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに対して [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) メソッドでコピーを追加します。プレゼンテーション間でコピーする場合は、フォント、テーマ、画像、その他のリソースがソースレイアウトで使用されているかも確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウト変更を継承しますが、ローカルで書式やオブジェクトを上書きしている場合は除外されます。プレースホルダーのジオメトリや継承スタイルが多数のスライドで同時に変わる可能性があります。レイアウトを編集する前に、 [getDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) で影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを別のレイアウトに再割り当てるか、 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用して参照されていないレイアウトだけを削除してください。