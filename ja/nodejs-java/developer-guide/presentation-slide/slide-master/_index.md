---
title: JavaScript でプレゼンテーションのスライドマスタを管理する
linktitle: スライドマスタ
type: docs
weight: 70
url: /ja/nodejs-java/slide-master/
keywords:
- スライドマスタ
- マスタースライド
- PPT マスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java でスライドマスタを管理します：PowerPoint および OpenDocument プレゼンテーションにおけるマスタースライドの取得、編集、クローン、比較、削除を行います。"
---
## **概要**

**スライドマスタ** は、スライド グループの共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキスト スタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスタを編集することで、各スライドで同じ書式設定を繰り返すことなく、プレゼンテーションの一貫性を保つのが一般的な方法です。

Aspose.Slides for Node.js via Java も同じモデルをサポートしています。プレゼンテーションには 1 つ以上のマスタースライドを含めることができ、各マスタースライドには複数のレイアウトスライドが属します。通常のスライドはマスタースライドを直接参照することはなく、レイアウトスライドを使用し、レイアウトスライドがマスタースライドに所属します。

階層は次のとおりです。

1. **スライドマスタ** – 共有デザインとテーマを定義します。  
1. **レイアウトスライド** – プレースホルダーとレイアウトレベルの書式設定の具体的な配置を定義します。  
1. **通常スライド** – 実際のプレゼンテーション コンテンツを保持し、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスタは [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは `Presentation.getMasters()` コレクションから取得できます。

{{% alert color="info" title="Inheritance" %}}
複数のレベルで同じプロパティが定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/nodejs-java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスタへのアクセス**

PowerPoint では、**表示** > **スライドマスタ** からスライドマスタ ビューを開くことができます。

![PowerPoint の表示タブにあるスライドマスタ コマンド](slide-master_3.jpg)

Aspose.Slides では、`getMasters()` コレクションを使用してマスタースライドにアクセスします：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

通常スライドが使用しているマスタースライドは、そのレイアウトから取得できます：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **スライドマスタに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。[BaseSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/) から共通のスライド動作を継承しているため、通常スライドやレイアウトスライドと同様の多数のスライドプロパティを公開します。マスタ固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) API ページに一覧されています。

主に使用されるマスタースライド メンバーは次のとおりです。

| メンバー | 用途 |
| --- | --- |
| `getBackground()` | マスターレベルのスライド背景を設定します。 |
| `getShapes()` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `getLayoutSlides()` | マスターに属するレイアウトスライドを格納します。 |
| `getThemeManager()` | マスターテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager()` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides()` | レイアウトを介してマスターに依存している通常スライドを返します。 |

## **スライドマスタに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに画像が表示されます。ロゴ、透かし、装飾帯、その他繰り返し使用する視覚要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

画像フレームの詳細については、[Picture Frame](/nodejs-java/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上に定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーと配置場所を決定します。

PowerPoint では、スライドマスタ ビューでプレースホルダー コマンドが利用できます。

![PowerPoint スライドマスタ ビューのプレースホルダー挿入コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加する場合、マスターに属するレイアウトスライドを操作します：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

既存のプレースホルダー形状を書式設定することも可能です。以下の例はタイトル プレースホルダーを検索し、線形グラデーション塗りつぶしを適用します：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![通常スライドが継承する書式設定済みタイトルプレースホルダー](slide-master_8.png)

その他のプレースホルダーおよびテキスト書式設定オプションについては、[Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) と [Text Formatting](/nodejs-java/text-formatting/) を参照してください。

## **スライドマスタの背景を変更する**

マスターベースの背景は、レイアウトやスライドが上書きしない限り継承されます。次の例は、最初のマスタースライドに単色の背景色を設定します：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

関連トピックは、[Presentation Background](/nodejs-java/presentation-background/) と [Presentation Theme](/nodejs-java/presentation-theme/) を参照してください。

## **スライドマスタを別のプレゼンテーションへクローンする**

`MasterSlideCollection.addClone` を使用してマスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

マスターとともに通常スライドもクローンする必要がある場合は、[Clone Slides](/nodejs-java/clone-slides/) を参照してください。

## **複数のスライドマスタを追加する**

プレゼンテーションには複数のマスタースライドを含められます。セクションごとに異なるブランディングやページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理に関する PowerPoint コマンド](slide-master_9.jpg)

次の例は、デフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスター配下にレイアウトを作成し、最後にそのレイアウトに基づく新しいスライドを追加します：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **スライドマスタを比較する**

マスタースライドは、[BaseSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/) から継承した `equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他スライド設定）を対象とし、スライド ID のような固有識別子や現在の日付などの動的プレースホルダー値は比較対象外です。

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

詳細は、[Compare Presentation Slides](/nodejs-java/compare-slides/) をご覧ください。

## **スライドマスタ ビューをデフォルト ビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/) の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御できます。次の例は、プレゼンテーションをスライドマスタ ビューで開きます：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

他のビュー設定については、[Save Presentation](/nodejs-java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズの削減とテンプレート保守の簡素化につながります。

`removeUnused` を使用して `getMasters()` コレクションから未使用マスターを削除します：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

低コードの `Compress.removeUnusedMasterSlides` メソッドも利用可能です：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**スライドマスタとレイアウトスライドの違いは何ですか？**

スライドマスタはテーマ、背景、共通図形、テキスト スタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウトスライドを使用し、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスタを含められますか？**

はい。プレゼンテーションは複数のスライドマスタを含められます。セクションごとに異なるビジュアル体系やブランディングが必要な場合は、マスターを複数使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有の視覚要素や書式設定はマスタースライドに置き、コンテンツ用のプレースホルダーは通常スライドが使用するレイアウトに配置します。

**使用中のマスタースライドを削除できますか？**

できません。依存スライドがあるマスタースライドは直接安全に削除できません。まずそれらのスライドを別のマスター配下のレイアウトに移動するか、使用されていないマスターのみを削除するクリーンアップ手法を使用してください。