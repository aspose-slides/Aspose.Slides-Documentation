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
- フッターの表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 二つのコンテンツ
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
description: Aspose.Slides for Javaでスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式設定を定義します。レイアウトを適用することで、スライドに一貫した構造が与えられ、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです。

- **タイトルスライド**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **タイトルとコンテンツ**: タイトルプレースホルダーと汎用コンテンツプレースホルダーが含まれます。
- **空白**: コンテンツプレースホルダーがなく、すべての形状を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには 3 つの関連レベルがあります。

1. [マスタースライド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) はテーマ、共有書式設定、背景、および共通オブジェクトを定義します。
2. [レイアウトスライド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/) はマスターに属し、プレースホルダーの特定の配置を定義します。
3. [通常スライド](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) は 1 つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

通常スライドはレイアウトからテーマと書式設定を継承し、レイアウトはマスターから継承します。通常スライド上で直接設定された値は、そのレベルで継承された値を上書きします。通常スライドが作成されると、そのプレースホルダーシェイプは選択されたレイアウトから生成されますが、プレースホルダーに入力されたコンテンツは通常スライドに属します。

スライドを作成する前にレイアウトに必要なプレースホルダーを追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の通常スライドに自動的に対応するプレースホルダーシェイプは追加されません。

この関係には 2 つの重要な結果があります。

- レイアウト上で継承された書式設定や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。先に依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位レベルの詳細については、[Slide Master](/slides/ja/java/slide-master/) を参照してください。

スライドごと、または共有レイアウトを通じて継承されたロゴや装飾的なマスターシェイプを非表示にする方法については、[Control the Visibility of Master Graphics](/slides/ja/java/slide-master/) を参照してください。この例では、同じマスターを使用する 2 つのスライドを比較しています。

## **スライド レイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、テンプレートのソースを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスター上で **Title and Content** を検索します。そのレイアウトが利用できない場合は、意図的に **Blank** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトのみが含まれる可能性があるために必要です。選択されたレイアウトは、[ISlide.setLayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) メソッドを介して最初の通常スライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された通常のシェイプは削除されません。ただし、プレースホルダーの位置、継承された書式設定、および既存プレースホルダーと新しいレイアウト間の対応が変わる可能性があるため、レイアウトを大きく変更する際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しただけで、作成は行っていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) メソッドを呼び出します。

次の例は常に **Title and Content** レイアウト `Report Title and Content` を新規作成し、そのレイアウトに基づく通常スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

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

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダー追加**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) メソッドは、レイアウトにプレースホルダーシェイプを追加するための [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `ILayoutPlaceholderManager` メソッド |
| --------------------------- | ------------------------------------ |
| ![コンテンツ](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![コンテンツ (縦)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![テキスト](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![テキスト (縦)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![画像](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![チャート](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![テーブル](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![メディア](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![オンライン画像](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

次の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加した後、変更されたレイアウトを使用する通常スライドを作成します。順序は意図的です：プレースホルダーは通常スライド作成前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダーシェイプを生成できます。

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

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式設定や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存の通常スライドに自動的に反映されません。レイアウト変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) メソッドを使用して、通常スライドから参照されていないレイアウトを削除できます。このメソッドは使用中のレイアウトはそのまま残します。

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

特定のレイアウトを削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) または [getDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) メソッドを使用します。削除前に依存スライドを別のレイアウトに再割り当てし、[ILayoutSlide.remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#remove--) を呼び出してください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライド上のフッター表示の制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーをレイアウト単位で制御するには、[ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) メソッドを使用します。たとえば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは非表示にしたい場合に便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示可能にします。

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

## **マスターと子レイアウト全体のフッター表示の制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) メソッドを使用します。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslideheaderfootermanager/) の伝搬メソッドはマスターとその依存レイアウトスライドおよび通常スライドに作用し、単一の通常スライドだけを対象にすることはできません。

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

マスタースライドはプレゼンテーションのテーマと共有書式設定を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を定義します。通常スライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保持します。

**レイアウトスライドを別のプレゼンテーションへコピーできますか？**

はい。目的のコレクションに対して [addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) メソッドでコピーを追加します。プレゼンテーション間でコピーする場合は、フォント、テーマ、画像、その他のリソースがソースレイアウトで使用されているかも確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承します（ローカルで上書きしていない限り）。プレースホルダーのジオメトリや継承されたスタイルは多数のスライドで一度に変わる可能性があります。編集前に [getDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) で影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxeditexception/) をスローします。まず依存スライドを別のレイアウトに再割り当てするか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) を使用して未参照のレイアウトのみを削除してください。