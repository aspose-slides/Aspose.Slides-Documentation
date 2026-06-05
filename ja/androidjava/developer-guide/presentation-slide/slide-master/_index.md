---
title: Android でプレゼンテーション スライド マスターを管理する
linktitle: スライド マスター
type: docs
weight: 70
url: /ja/androidjava/slide-master/
keywords:
- スライド マスター
- マスター スライド
- PPT マスター スライド
- 複数のマスター スライド
- マスター スライドの比較
- 背景
- プレースホルダー
- マスター スライドのクローン
- マスター スライドのコピー
- マスター スライドの複製
- 未使用のマスター スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でスライド マスターを管理し、PowerPoint および OpenDocument プレゼンテーションのマスター スライドにアクセス、編集、クローン、比較、削除を行います。"
---
## **概要**

**スライド マスター**は、スライドのグループに共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキスト スタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライド マスターを編集することが、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つ通常の方法です。

Aspose.Slides for Android via Java も同じモデルをサポートしています。プレゼンテーションは 1 つ以上のマスター スライドを含めることができ、各マスター スライドは複数のレイアウト スライドを保持できます。通常のスライドは直接マスター スライドを参照することはなく、レイアウト スライドを使用し、そのレイアウト スライドがマスター スライドに属しています。

階層は次のとおりです。

1. **スライド マスター** - 共有デザインとテーマを定義します。  
1. **レイアウト スライド** - プレースホルダーの配置とレイアウト レベルの書式設定を定義します。  
1. **普通のスライド** - 実際のプレゼンテーション コンテンツを含み、1 つのレイアウト スライドを使用します。

![マスタースライド、レイアウトスライド、普通のスライドの階層](slide-master_2.jpg)

Aspose.Slides では、スライド マスターは [IMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーション内のすべてのマスター スライドは、[Presentation.getMasters](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getMasters--) コレクションを通じて取得でき、これは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) を実装しています。Android via Java の完全な API 概要については、[com.aspose.slides API reference](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) を参照してください。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスター スライドとレイアウト スライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウト スライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/androidjava/slide-layout/) を参照してください。  
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**View** > **Slide Master** からスライド マスター ビューを開くことができます。

![PowerPoint の「表示」タブにあるスライド マスター コマンド](slide-master_3.jpg)

Aspose.Slides では、`getMasters()` コレクションを使用してマスター スライドにアクセスします。

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

また、普通のスライドが使用しているレイアウトを介して、そのマスター スライドを取得することもできます。

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

マスター スライドはスライドに似たオブジェクトです。`IBaseSlide` を実装しているため、普通のスライドやレイアウト スライドと同様の多くのスライド プロパティを公開します。

一般的に使用されるマスター スライド メンバーは次のとおりです。

| メンバー | 用途 |
| --- | --- |
| `getBackground()` | マスターレベルのスライド背景を設定します。 |
| `getShapes()` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置されたシェイプを格納します。 |
| `getLayoutSlides()` | マスターに属するレイアウト スライドを格納します。 |
| `getThemeManager()` | マスターのテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager()` | マスターおよびその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides()` | レイアウトを介してマスターに依存している普通のスライドを返します。 |

## **スライド マスターに画像を追加する**

マスター スライドに画像を追加すると、そのマスターのレイアウトを使用するすべてのスライドに表示されます。ロゴ、透かし、装飾バンド、その他繰り返し使用するビジュアル要素に便利です。

次の例は、最初のマスター スライドにロゴを追加します。

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

画像フレームの詳細については、[Picture Frame](/slides/ja/androidjava/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウト スライドで定義されます。マスター スライドは、これらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、スライド マスター ビューでプレースホルダー コマンドが利用可能です。

![PowerPoint のスライド マスター ビューにある「プレースホルダーの挿入」コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウト スライドで作業します。

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

既存のマスター スライド上のプレースホルダー シェイプをフォーマットすることもできます。次の例は、タイトル プレースホルダーを検索し、線形グラデーション塗りつぶしを適用します。

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![普通のスライドが継承するフォーマット済みタイトル プレースホルダー](slide-master_8.png)

プレースホルダーやテキストの書式設定オプションの詳細については、[Set Prompt Text in Placeholder](/slides/ja/androidjava/manage-placeholder/) と [Text Formatting](/slides/ja/androidjava/text-formatting/) を参照してください。

## **スライド マスターの背景を変更する**

マスターの背景は、レイアウトおよびそれを上書きしないスライドに継承されます。次の例は、最初のマスター スライドに単色の背景色を設定します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

関連トピックは、[Presentation Background](/slides/ja/androidjava/presentation-background/) と [Presentation Theme](/slides/ja/androidjava/presentation-theme/) を参照してください。

## **スライド マスターを別のプレゼンテーションにクローンする**

`[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-)` を使用して、マスター スライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

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

マスターとともに普通のスライドもクローンしたい場合は、[Clone Slides](/slides/ja/androidjava/clone-slides/) を参照してください。

## **複数のスライド マスターを追加する**

プレゼンテーションは複数のマスター スライドを含めることができます。異なるセクションで異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスター スライドの挿入と管理に関する PowerPoint コマンド](slide-master_9.jpg)

次の例は、デフォルトのマスターをクローンし、クローンに別の背景を設定し、そのクローンされたマスターの下にレイアウトを作成し、そのレイアウトに基づく新しいスライドを追加します。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **スライド マスターの比較**

マスター スライドは、`IBaseSlide` から継承された `equals` メソッドで比較できます。比較は構造と静的コンテンツ（シェイプ、テキスト、書式設定、アニメーション、その他のスライド設定）をチェックします。スライド ID などの固有識別子や、現在の日付などの動的プレースホルダー値は比較対象になりません。

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

詳細は、[Compare Presentation Slides](/slides/ja/androidjava/compare-slides/) を参照してください。

## **スライド マスター ビューをデフォルト ビューに設定する**

`[ViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewproperties/)` の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御できます。次の例は、プレゼンテーションをスライド マスター ビューで開きます。

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

その他のビュー設定については、[Save Presentation](/slides/ja/androidjava/save-presentation/) を参照してください。

## **未使用のマスター スライドを削除する**

プレゼンテーションには、もはや普通のスライドで使用されていないマスター スライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズが削減され、テンプレートの保守が簡素化されます。

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

低コードの `[Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)` メソッドも利用できます。

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

**スライド マスターとレイアウト スライドの違いは何ですか？**  
スライド マスターはテーマ、背景、共通シェイプ、テキスト スタイルなどの共有デザイン設定を定義します。レイアウト スライドはマスターに属し、プレースホルダーの具体的な配置を定義します。普通のスライドはレイアウト スライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライド マスターを含められますか？**  
はい。プレゼンテーションは複数のスライド マスターを保持できます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に、複数のマスターを使用してください。

**プレースホルダーはマスター スライドに追加すべきですか、レイアウト スライドに追加すべきですか？**  
ほとんどの場合、レイアウト スライドにプレースホルダーを追加します。共有のビジュアル要素や書式設定はマスター スライドに置き、コンテンツ用のプレースホルダーは普通のスライドが使用するレイアウトに配置します。

**使用中のマスター スライドを削除できますか？**  
いいえ。依存しているスライドがあるマスター スライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用のマスターだけを削除するクリーンアップ手順を使用してください。