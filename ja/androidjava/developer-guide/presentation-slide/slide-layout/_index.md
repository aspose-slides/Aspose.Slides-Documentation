---
title: Androidでスライドレイアウトを適用または変更
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
- 2 つのコンテンツ
- 比較
- タイトルのみ
- ブランクレイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Javaでスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。"
---
## **概要**

スライド レイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライドに一貫した構造が付与され、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **タイトル スライド**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツ プレースホルダーが含まれます。
- **ブランク**: コンテンツ プレースホルダーがなく、すべての形状を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の 3 つの関連レベルがあります：

1. [マスタースライド](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) は、テーマ、共有書式、背景、および共通オブジェクトを定義します。
2. [レイアウトスライド](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/) はマスターに属し、特定のプレースホルダー配置を定義します。
3. [通常スライド](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) はレイアウトを 1 つ使用し、そのスライドに入力されたコンテンツを保存します。

通常スライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。通常スライドに直接設定された値は、そのレベルで継承された値を上書きします。通常スライドが作成されると、プレースホルダー形状は選択したレイアウトから生成され、プレースホルダーに入力されたコンテンツは通常スライドに属します。

スライドを作成する前に、レイアウトに必要なプレースホルダーを追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の通常スライドに自動的に対応するプレースホルダー形状は追加されません。

この関係には 2 つの重要な結果があります：

- レイアウト上で継承された書式や既存のプレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。既に使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用されているレイアウトは削除できません。まずその依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位に関する詳細は、[スライドマスター](/slides/ja/androidjava/slide-master/) を参照してください。

1 つのスライドや共有レイアウトで継承されたロゴや装飾的なマスターシェイプを非表示にするには、[マスター グラフィックの表示制御](/slides/ja/androidjava/slide-master/) を参照してください。この例は同じマスターを使用した 2 つのスライドを比較しています。

## **スライド レイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスターで **タイトルとコンテンツ** を探します。そのレイアウトが利用できない場合、意図的に **ブランク** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトのみが含まれる可能性があるために必要です。選択したレイアウトは、[ISlide.setLayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) メソッドを介して最初の通常スライドに適用されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

スライドのレイアウトを変更しても、スライドに直接追加された通常の形状は削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウトとの対応が変わる可能性があるため、実質的に異なるレイアウト間で切り替える際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しただけで、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) メソッドを呼び出します。

次の例は常に `Report Title and Content` という名前の新しい **タイトルとコンテンツ** レイアウトを追加し、そのレイアウトに基づく通常スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

テンプレートが本当に別の再利用可能な構造を必要とするときのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダー追加**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) メソッドは、レイアウトにプレースホルダー形状を追加するための [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `ILayoutPlaceholderManager` メソッド |
| -------------------------- | ----------------------------------- |
| ![コンテンツ](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![コンテンツ (縦)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![テキスト](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![テキスト (縦)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![画像](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![チャート](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![テーブル](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![スマートアート](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![メディア](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![オンライン画像](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

次の例は **ブランク** レイアウトが存在することを確認し、4 つのプレースホルダーを追加し、次に変更されたレイアウトを使用する通常スライドを作成します。順序は意図的です：プレースホルダーは通常スライドを作成する前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダー形状を生成できます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![レイアウトスライドのプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは、既存の通常スライドには自動的に補填されません。プレゼンテーションのコピーでレイアウト変更をテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) メソッドを使用して、通常スライドが参照していないレイアウトを削除します。このメソッドは、使用中のレイアウトはそのまま残します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

特定のレイアウトを削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) または [getDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) メソッドを使用します。[ILayoutSlide.remove](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#remove--) を呼び出す前に、すべての依存スライドを再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドのフッター表示制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。[ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) メソッドを使用して、特定のレイアウトのこれらのプレースホルダーを制御できます。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しないようにしたい場合に便利です。

次の例はレイアウトを安全に選択し、そのフッター要素を表示可能にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **マスターとその子レイアウトのフッター表示制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) メソッドを使用します。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) の伝搬メソッドは、マスターとその依存レイアウトスライドおよび通常スライドに対して動作し、単一の通常スライドのみを対象にするわけではありません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、再利用可能なプレースホルダー配置を 1 つ定義します。通常スライドはそれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに [addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) メソッドでコピーを追加します。プレゼンテーション間でコピーする場合は、ソースレイアウトで使用されているフォント、テーマ、画像、その他のリソースも確認してください。

**使用中のレイアウトを変更した場合、どうなりますか？**

依存スライドは、ローカルで影響を受ける書式やオブジェクトを上書きしていない限り、レイアウトの変更を継承します。そのため、プレースホルダーのジオメトリや継承されたスタイルが多数のスライドで同時に変更されることがあります。レイアウトを編集する前に、[getDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) を使用して影響を受けるスライドを特定してください。

**使用中のレイアウトを削除した場合、どうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てするか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) を使用して参照されていないレイアウトだけを削除してください。