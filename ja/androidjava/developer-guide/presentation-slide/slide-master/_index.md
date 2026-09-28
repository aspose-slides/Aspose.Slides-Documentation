---
title: Android でプレゼンテーション スライドマスターを管理する
linktitle: スライドマスター
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
description: "Aspose.Slides for Android via Java でスライドマスターを管理し、PowerPoint および OpenDocument プレゼンテーションのマスタースライドにアクセス、編集、クローン、比較、削除を行います。"
---
## **概要**

**slide master** はスライドのグループに共通のデザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することで、すべてのスライドで同じ書式設定を繰り返すことなく、一貫性のあるプレゼンテーションを保つのが一般的です。

Aspose.Slides for Android via Java でも同じモデルがサポートされています。プレゼンテーションは 1 つ以上のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを含むことができます。通常のスライドは直接マスタースライドを参照しません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドはマスタースライドに属しています。

階層構造は以下の通りです。

1. **スライドマスター** - 共有デザインとテーマを定義します。  
1. **レイアウトスライド** - プレースホルダーの配置やレイアウトレベルの書式設定を定義します。  
1. **通常スライド** - 実際のプレゼンテーションコンテンツを保持し、1 つのレイアウトスライドを使用します。

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーション内のすべてのマスタースライドは [Presentation.getMasters](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getMasters--) コレクションを通じて取得でき、これは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) を実装しています。Android via Java の完全な API については、[com.aspose.slides API reference](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/) を参照してください。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。例えば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/androidjava/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Aspose.Slides では、`getMasters()` コレクションを使用してマスタースライドにアクセスします:

```java
import com.aspose.slides.*;

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

通常のスライドから、そのレイアウトを介して使用されているマスタースライドを取得することもできます:

```java
import com.aspose.slides.*;

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

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。[IBaseSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/) を実装しているため、通常のスライドやレイアウトスライドと同様の多数のスライドプロパティを公開します。

一般的に使用されるマスタースライドのメンバーは次のとおりです。

| メンバー | 目的 |
| --- | --- |
| `getBackground()` | マスターレベルのスライド背景を設定します。 |
| `getShapes()` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `getLayoutSlides()` | マスターに属するレイアウトスライドを格納します。 |
| `getThemeManager()` | マスターのテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager()` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides()` | レイアウトを介してマスターに依存する通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドに画像が表示されます。ロゴ、透かし、装飾バンドなど、繰り返し使用する視覚要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します:

```java
import com.aspose.slides.*;

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

## **マスターグラフィックの表示/非表示を制御する**

[IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) を使用して、ロゴや装飾形状などの継承されたマスターグラフィックを削除せずに非表示にできます。非表示にしたいスライドで [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) に `false` を渡し、表示したいスライドでは `true` を保持します。

次の自己完結型サンプルは、マスターに青い装飾バンドを作成し、同じ空白レイアウトを使用する 2 つのスライドを作成します。バンドは最初のスライドで表示され、2 番目のスライドで非表示になります。入力プレゼンテーションや画像は不要です。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この例は新規プレゼンテーションに同梱されている **Blank** レイアウトを使用し、最初のスライドの独自プレースホルダーを削除します。

### **設定のスコープを選択する**

通常スライドは [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/#getLayoutSlide--) と [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--) を介してマスターにアクセスします。個々のスライドにプロパティを設定すると、そのスライドにのみ影響します。`false` を [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) に渡すと、その共有レイアウトを使用するすべてのスライドでマスターグラフィックが非表示になります (そのスライド固有の設定が `true` でも)。1 枚のスライドだけでグラフィックを非表示にしたい場合は、スライドプロパティを変更し、共有レイアウトは変更しないでください。

この設定はマスタースライド自体の可視性制御としてはサポートされていません。マスター上で [getShowMasterShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) は常に `false` を返し、[setShowMasterShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) に `true` を渡すと例外がスローされます。代わりに通常スライドまたはレイアウトに適用してください。

### **グラフィックと背景を区別する**

| 操作 | 効果 |
| --- | --- |
| マスターグラフィックを非表示にする | マスターから継承された形状を削除せずに表示/非表示を制御します。 |
| スライドの背景塗りつぶしを変更する | 背景の色、グラデーション、画像を変更します。マスターグラフィックは別の形状として残り、背景の上に表示されます。[Presentation Background](/slides/ja/androidjava/presentation-background/) を参照してください。 |
| マスターから形状を削除する | 共有元の形状を削除し、以降そのマスターを使用するスライドから利用できなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、プレースホルダーコマンドはスライドマスタービューで利用できます。

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します:

```java
import com.aspose.slides.*;

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

既にマスタースライド上に存在するプレースホルダー形状の書式設定も可能です。次の例はタイトルプレースホルダーを検索し、線形グラデーション塗りつぶしを適用します:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

プレースホルダーとテキスト書式設定の詳細については、[Set Prompt Text in Placeholder](/slides/ja/androidjava/manage-placeholder/) および [Text Formatting](/slides/ja/androidjava/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスター背景は、上書きしないレイアウトやスライドに継承されます。次の例は最初のマスタースライドに単色背景色を設定します:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

関連トピックは、[Presentation Background](/slides/ja/androidjava/presentation-background/) と [Presentation Theme](/slides/ja/androidjava/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションにクローンする**

[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) を使用して、マスタースライドを別のプレゼンテーションにコピーします。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```java
import com.aspose.slides.*;

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

通常スライドとそのマスターを一緒にクローンする必要がある場合は、[Clone Slides](/slides/ja/androidjava/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。これは、セクションごとに異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

次の例はデフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、そのレイアウトに基づく新しいスライドを追加します:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **スライドマスターを比較する**

マスタースライドは [IBaseSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/) から継承した `equals` メソッドで比較できます。比較は構造と静的コンテンツ（形状、テキスト、書式設定、アニメーション、その他のスライド設定）をチェックします。スライド ID などの固有識別子や、現在の日付などの動的プレースホルダー値は比較しません。

```java
import com.aspose.slides.*;

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

詳細は [Compare Presentation Slides](/slides/ja/androidjava/compare-slides/) を参照してください。

## **スライドマスタービューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/viewproperties/) の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御します。次の例はプレゼンテーションをスライドマスタービューで開きます:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

その他のビュー設定については、[Save Presentation](/slides/ja/androidjava/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズが削減され、テンプレートの保守が簡素化されます。

`removeUnused` を使用して `getMasters()` コレクションから未使用マスターを削除します:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

低コードの [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドも使用できます:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターはテーマ、背景、共通図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含めることができますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、レイアウトスライドにプレースホルダーを追加します。共有ビジュアル要素と共有書式設定はマスタースライドに置き、コンテンツ用プレースホルダーは通常スライドが使用するレイアウトに配置します。

**使用中のマスタースライドを削除できますか？**

いいえ。依存するスライドがあるマスタースライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用のマスターのみを削除するクリーンアップメソッドを使用してください。