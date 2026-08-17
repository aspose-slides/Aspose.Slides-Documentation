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
description: "Aspose.Slides for Java でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式設定を定義します。レイアウトを適用すると、スライド全体に一貫した構造が与えられ、各スライドは独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **タイトル スライド**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーが含まれます。
- **空白**: コンテンツプレースホルダーがなく、すべての形状を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の3つの関連レベルがあります：

1. A [master slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) はテーマ、共有書式設定、背景、共通オブジェクトを定義します。
1. A [layout slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/) はマスターに属し、特定のプレースホルダー配置を定義します。
1. A [normal slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) は1つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

標準スライドはレイアウトからテーマと書式設定を継承し、レイアウトはマスターから継承します。標準スライド上で直接設定された値は、そのレベルで継承された値を上書きします。標準スライドが作成されると、選択されたレイアウトからプレースホルダー形状が生成され、プレースホルダーに入力されたコンテンツは標準スライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の標準スライドに対応するプレースホルダー形状は自動的に追加されません。

この関係には 2 つの重要な結果があります：

- レイアウト上の継承された書式設定や既存プレースホルダーのジオメトリを変更すると、該当レイアウトに依存するすべてのスライドが更新される可能性があります。使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。先に依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトだけを削除してください。

この階層の最上位レベルの詳細については、[Slide Master](/slides/ja/java/slide-master/) を参照してください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準的な PowerPoint レイアウト定義に従っている場合にレイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り名前ベースの選択はあまり信頼できません。

次の例は最初のマスター上で **Title and Content** を探します。そのレイアウトが利用できない場合は意図的に **Blank** にフォールバックします。2 番目の null チェックは、プレゼンテーションにカスタムレイアウトしか含まれない可能性があるために必要です。選択されたレイアウトは、[ISlide.setLayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) メソッドを介して最初の標準スライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された普通のシェイプは削除されません。ただし、プレースホルダー位置、継承された書式設定、および既存プレースホルダーと新レイアウト間の対応関係が変わる可能性があるため、レイアウトが大きく異なる場合は出力を必ず確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択しただけで、作成は行っていません。レイアウトを作成するには、対象マスターのレイアウトコレクション上で [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) メソッドを呼び出します。

次の例は常に新しい **Title and Content** レイアウト `Report Title and Content` を追加し、そのレイアウトを基に標準スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

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

テンプレートが実際に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダーの追加**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) メソッドは、レイアウトにプレースホルダー形状を追加するための [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `ILayoutPlaceholderManager` メソッド |
| --------------------------- | ----------------------------------- |
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

次の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加した後、変更されたレイアウトを使用する標準スライドを作成します。順序は意図的で、プレースホルダーは標準スライド作成前に追加されるため、Aspose.Slides がそのスライド上に対応するプレースホルダー形状を生成できます。

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

結果：

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
継承された書式設定や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存の標準スライドには自動で反映されません。レイアウト変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) メソッドを使用して、標準スライドが参照していないレイアウトを削除します。使用中のレイアウトはそのまま残ります。

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

特定のレイアウトを削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) または [getDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) メソッドを使用します。[ILayoutSlide.remove](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#remove--) を呼び出す前に依存スライドを再割り当てしてください。使用中のレイアウトを削除しようとすると [PptxEditException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでのフッター表示の制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーを 1 つのレイアウトで制御するには、[ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) メソッドを使用します。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しないといったシナリオで便利です。

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

## **マスターとその子レイアウトでのフッター表示の制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) メソッドを使用します。[IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslideheaderfootermanager/) の伝搬メソッドは、マスターとその依存レイアウトスライドおよび標準スライドに対して動作し、単一の標準スライドだけを対象にすることはできません。

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

マスタースライドはプレゼンテーションのテーマと共有書式設定を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を 1 つ定義します。標準スライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに対して [addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) メソッドを使用してコピーを追加します。プレゼンテーション間でコピーする場合は、フォント、テーマ、画像、その他のリソースがソースレイアウトで使用されていることも確認してください。

**すでに使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承します（ローカルで書式設定やオブジェクトを上書きしていない限り）。そのため、プレースホルダーのジオメトリや継承されたスタイルが多数のスライドで同時に変化する可能性があります。レイアウトを編集する前に、[getDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) を使用して影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てるか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) を使用して未参照のレイアウトだけを削除してください。