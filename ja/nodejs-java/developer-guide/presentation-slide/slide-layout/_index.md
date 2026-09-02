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
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッターの表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2 コンテンツ
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
description: "Java を介して Node.js 用 Aspose.Slides のスライドレイアウトを適用、作成、変更し、プレースホルダーを追加し、未使用レイアウトを削除し、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライドに一貫した構造が付与され、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **タイトルスライド**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーが含まれます。
- **空白**: コンテンツプレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の3つの関連レベルがあります。

1. A [master slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) はテーマ、共有書式、背景、および共通オブジェクトを定義します。
2. A [layout slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/) はマスターに属し、特定のプレースホルダー配置を定義します。
3. A [normal slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/) は1つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

ノーマルスライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。ノーマルスライドに直接設定された値は、そのレベルで継承された値を上書きします。ノーマルスライドが作成されると、プレースホルダー形状は選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツはノーマルスライドに属します。

スライドを作成する前に、レイアウトに必要なプレースホルダーを追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存のノーマルスライドに対応するプレースホルダー形状は自動的に追加されません。

この関係には2つの重要な結果があります：

- レイアウト上の継承された書式や既存のプレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新される可能性があります。すでに使用されているレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドにまだ使用されているレイアウトは削除できません。まず依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位についての詳細は、[Slide Master](/slides/ja/nodejs-java/slide-master/) を参照してください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、[SlideLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidelayouttype/) の値を使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

以下の例は、最初のマスターで **Title and Content** を検索します。そのレイアウトが利用できない場合、意図的に **Blank** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトのみが含まれる可能性があるために必要です。選択されたレイアウトは、[Slide.setLayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#setLayoutSlide) メソッドを使用して最初のノーマルスライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された通常の形状は削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウト間の対応が変わる可能性があるため、大きく異なるレイアウト間を切り替える際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しただけで、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) メソッドを呼び出します。

以下の例は常に `Report Title and Content` という名前の新しい **Title and Content** レイアウトを追加し、その後それに基づくノーマルスライドを追加します。レイアウト名はコレクション内で一意である必要があります。

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

テンプレートが本当に別の再利用可能な構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずにそれを選択して再利用してください。

## **レイアウトスライドへのプレースホルダーの追加**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドは、レイアウトにプレースホルダー形状を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `LayoutPlaceholderManager` メソッド |
| --------------------------- | --------------------------------- |
| ![コンテンツ](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![コンテンツ (縦)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![テキスト](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![テキスト (縦)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![画像](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![チャート](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![テーブル](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![メディア](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![オンライン画像](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

以下の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加してから、変更されたレイアウトを使用するノーマルスライドを作成します。順序は意図的で、プレースホルダーはノーマルスライドが作成される前に追加されるため、Aspose.Slides がそのスライド上に対応するプレースホルダー形状を生成できます。

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

結果は次のとおりです：

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存のレイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存のノーマルスライドには自動的に反映されません。プレゼンテーションのコピーでレイアウト変更をテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) メソッドを使用して、ノーマルスライドが参照していないレイアウトを削除します。このメソッドは、まだ使用中のレイアウトはそのまま残します。

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

特定のレイアウトを削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) または [getDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) メソッドを使用します。[LayoutSlide.remove](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#remove) を呼び出す前に、依存スライドを再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでフッターの表示制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーをレイアウト単位で制御するには、[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) メソッドを使用します。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しない場合に便利です。

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

## **マスターおよび子レイアウトでフッターの表示制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) メソッドを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslideheaderfootermanager/) の伝搬メソッドは、マスターとその依存レイアウトスライドおよびノーマルスライドに対して動作し、単一のノーマルスライドだけを対象にするわけではありません。

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

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を1つ定義します。ノーマルスライドはそれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションにコピーできますか？**

はい。[addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) メソッドを使用して、コピーを宛先コレクションに追加します。プレゼンテーション間でコピーする場合は、ソースレイアウトで使用されているフォント、テーマ、画像、その他のリソースも確認してください。

**すでに使用中のレイアウトを変更するとどうなりますか？**

依存スライドは、ローカルで対象の書式やオブジェクトを上書きしていない限り、レイアウトの変更を継承します。そのため、プレースホルダーのジオメトリや継承されたスタイルが多数のスライドで一度に変わる可能性があります。レイアウトを編集する前に、[getDependingSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) を使用して影響を受けるスライドを特定してください。

**まだ使用中のレイアウトを削除するとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てするか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用して参照されていないレイアウトのみを削除してください。