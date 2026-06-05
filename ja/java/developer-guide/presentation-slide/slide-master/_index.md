---
title: "Java でプレゼンテーション スライドマスターを管理する"
linktitle: "スライドマスター"
type: docs
weight: 70
url: /ja/java/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPT マスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの重複
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でスライドマスターを管理します：PowerPoint および OpenDocument のプレゼンテーションでマスタースライドにアクセス、編集、クローン作成、比較、削除を行う。"
---
## **概要**

スライド マスターは、スライド グループに対する共通のデザイン設定を定義します。共通の図形、ロゴ、背景、テキスト スタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライド マスターを編集することが、各スライドで同じ書式設定を繰り返さずにプレゼンテーションの一貫性を保つ一般的な方法です。

Aspose.Slides for Java は同じモデルをサポートします。プレゼンテーションは 1 つまたは複数のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを含むことができます。通常のスライドはマスタースライドを直接参照しません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属しています。

階層は次のとおりです。

1. **スライド マスター** - 共有デザインとテーマを定義します。
1. **レイアウト スライド** - プレースホルダーの配置とレイアウトレベルの書式設定を定義します。
1. **通常のスライド** - 実際のプレゼンテーション コンテンツを含み、1 つのレイアウト スライドを使用します。

![マスタースライド、レイアウトスライド、ノーマルスライドの階層](slide-master_2.jpg)

Aspose.Slides では、スライド マスターは [IMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation.getMasters](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getMasters--) コレクションを通じて取得でき、このコレクションは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) を実装しています。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方が背景を定義している場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[スライド レイアウトの適用または変更](/slides/ja/java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライド マスターへのアクセス**

PowerPoint では、**表示** ＞ **スライド マスター** からスライド マスター ビューを開くことができます。

![PowerPoint の表示タブにあるスライド マスター コマンド](slide-master_3.jpg)

Aspose.Slides では、`getMasters()` コレクションを使用してマスタースライドにアクセスします。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

通常のスライドが使用しているマスタースライドは、そのレイアウトを介して取得できます。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **スライド マスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。[IBaseSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/) を実装しているため、通常のスライドやレイアウトスライドと同様の多数のスライド プロパティにアクセスできます。マスター固有のメンバーは [IMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) API ページに一覧されています。

一般的に使用されるマスタースライド メンバーは次のとおりです。

| メンバー | 目的 |
| --- | --- |
| `getBackground()` | マスターレベルのスライド背景を設定します。 |
| `getShapes()` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `getLayoutSlides()` | マスターに属するレイアウトスライドを格納します。 |
| `getThemeManager()` | マスターのテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager()` | マスターおよびその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides()` | レイアウトを介してマスターに依存する通常のスライドを返します。 |

## **スライド マスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに表示されます。ロゴ、透かし、装飾バンド、その他繰り返し使用するビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

画像フレームの詳細については、[Picture Frame](/slides/ja/java/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、スライド マスター ビューでプレースホルダー コマンドが利用できます。

![PowerPoint のスライド マスター ビューにあるプレースホルダーの挿入コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

既存のプレースホルダー形状をフォーマットすることも可能です。次の例はタイトルプレースホルダーを検索し、線形グラデーション塗りを適用します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![通常のスライドに継承されるフォーマット済みタイトル プレースホルダー](slide-master_8.png)

プレースホルダーとテキストの書式設定オプションの詳細は、[Set Prompt Text in Placeholder](/slides/ja/java/manage-placeholder/) と [Text Formatting](/slides/ja/java/text-formatting/) を参照してください。

## **スライド マスターの背景を変更する**

マスターベースの背景は、レイアウトやスライドが上書きしない限り継承されます。次の例は、最初のマスタースライドに単色背景色を設定します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

関連トピックは、[Presentation Background](/slides/ja/java/presentation-background/) と [Presentation Theme](/slides/ja/java/presentation-theme/) を参照してください。

## **スライド マスターを別のプレゼンテーションにクローンする**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) を使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

マスターと一緒に通常のスライドもクローンする必要がある場合は、[Clone Slides](/slides/ja/java/clone-slides/) を参照してください。

## **複数のスライド マスターを追加する**

プレゼンテーションは複数のマスタースライドを含むことができます。セクションごとに異なるブランディング、ページ構造、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入および管理のための PowerPoint コマンド](slide-master_9.jpg)

次の例は、デフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、最後にそのレイアウトに基づく新しいスライドを追加します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スライド マスターを比較する**

マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/) から継承された `equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他のスライド設定）をチェックし、スライド ID などの固有識別子や現在の日付などの動的プレースホルダー値は比較しません。

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

詳細は、[Compare Presentation Slides](/slides/ja/java/compare-slides/) を参照してください。

## **スライド マスター ビューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/java/com.aspose.slides/viewproperties/) の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御できます。次の例は、プレゼンテーションをスライド マスター ビューで開きます。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

その他のビュー設定については、[Save Presentation](/slides/ja/java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常のスライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイル サイズが削減され、テンプレートの保守が簡素化されます。

`removeUnused` を使用して、`getMasters()` コレクションから未使用のマスターを削除します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

低コードの [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドも利用できます。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**スライド マスターとレイアウトスライドの違いは何ですか？**

スライド マスターはテーマ、背景、共通の図形、テキスト スタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常のスライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライド マスターを含められますか？**

はい。プレゼンテーションは複数のスライド マスターを含めることができます。異なるセクションで異なるビジュアル システムやブランディングが必要な場合に、複数のマスターを使用します。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有のビジュアル要素や共有書式はマスタースライドに配置し、コンテンツ用のプレースホルダーは通常のスライドが使用するレイアウトに配置します。

**使用中のマスタースライドを削除できますか？**

できません。依存スライドがあるマスタースライドは直接安全に削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用のマスターのみを削除するクリーンアップ メソッドを使用してください。