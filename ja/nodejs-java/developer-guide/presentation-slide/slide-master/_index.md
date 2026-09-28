---
title: JavaScript でプレゼンテーションのスライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/nodejs-java/slide-master/
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
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java でスライドマスターを管理します。PowerPoint および OpenDocument プレゼンテーションにおいて、マスタースライドのアクセス、編集、クローン作成、比較、削除が可能です。"
---
## **概要**

**スライドマスター** は、スライドのグループに共通するデザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することで、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つのが一般的です。

Aspose.Slides for Node.js via Java でも同じモデルがサポートされています。プレゼンテーションは 1 つ以上のマスタースライドを含めることができ、各マスタースライドは複数のレイアウトスライドを含むことができます。通常のスライドは直接マスタースライドを参照することはほとんどありません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属しています。

階層構造は次のとおりです。

1. **スライドマスター** - 共有デザインとテーマを定義します。  
1. **レイアウトスライド** - プレースホルダーとレイアウトレベルの書式設定の特定の配置を定義します。  
1. **通常スライド** - 実際のプレゼンテーションコンテンツを保持し、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは `Presentation.getMasters()` コレクションを通じて取得できます。

{{% alert color="info" title="Inheritance" %}}
複数レベルで同じプロパティが定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/nodejs-java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![PowerPoint の表示タブにあるスライドマスター コマンド](slide-master_3.jpg)

Aspose.Slides では、`getMasters()` コレクションを使用してマスタースライドにアクセスします:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

レイアウトを介して通常スライドが使用しているマスタースライドを取得することもできます:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。共通のスライド動作は [BaseSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/) から継承されるため、通常スライドやレイアウトスライドで使用される多数のスライドプロパティを公開します。マスター固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/) API ページに一覧があります。

主に使用されるマスタースライドメンバーは以下のとおりです。

| メンバー | 目的 |
| --- | --- |
| `getBackground()` | マスターレベルのスライド背景を設定します。 |
| `getShapes()` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `getLayoutSlides()` | マスターに属するレイアウトスライドを格納します。 |
| `getThemeManager()` | マスターテーマ API へのアクセスを提供します。 |
| `getHeaderFooterManager()` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `getDependingSlides()` | レイアウトを介してマスターに依存する通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに表示されます。ロゴ、透かし、装飾バンドなど、繰り返し使用するビジュアル要素に便利です。

以下の例は最初のマスタースライドにロゴを追加します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **マスター グラフィックの表示/非表示を制御する**

[BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) を使用すると、マスターから継承されたロゴや装飾形状などを削除せずに非表示にできます。該当スライドで [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#setShowMasterShapes) に `false` を渡し、表示したいスライドでは `true` のままにします。

以下の自己完結型サンプルは、マスターに青い装飾バンドを作成し、同じ空白レイアウトを使用する 2 枚のスライドを生成します。バンドは最初のスライドで表示され、2 枚目では非表示になります。入力プレゼンテーションや画像は不要です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この例は新規プレゼンテーションに同梱されている **Blank** レイアウトを使用し、最初のスライドのプレースホルダーを削除しています。

### **設定の範囲の選択**

通常スライドは [Slide.getLayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getLayoutSlide) と [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) を介してマスターにアクセスします。個々のスライドにプロパティを設定すると、そのスライドだけに影響します。`false` を [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) に渡すと、共有レイアウトを使用するすべてのスライドでマスター グラフィックが非表示になりますが、個々のスライド設定が `true` であっても同様です。1 枚だけ非表示にしたい場合は、スライドのプロパティを変更し、共有レイアウトは変更しません。

マスタースライド自体では可視性コントロールはサポートされていません。マスター上で [getShowMasterShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) は常に `false` を返し、[setShowMasterShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) に `true` を渡すと例外がスローされます。代わりに通常スライドまたはレイアウトに適用してください。

### **グラフィックと背景の違いを認識する**

| 操作 | 効果 |
| --- | --- |
| マスター グラフィックを非表示にする | 継承されたマスター形状を削除したりスライド独自の形状を変更したりせずに、表示/非表示を制御します。 |
| スライド背景の塗りつぶしを変更する | 背景色、グラデーション、画像を変更します。マスター グラフィックは別個の形状なので、背景の上に表示されたままにできます。詳細は [Presentation Background](/slides/ja/nodejs-java/presentation-background/) を参照してください。 |
| マスターから形状を削除する | 共有元の形状を削除するため、マスターを使用するすべてのスライドからその形状がなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーと配置位置を決定します。

PowerPoint では、スライドマスタービューでプレースホルダー コマンドが利用可能です。

![PowerPoint スライドマスタービューの「プレースホルダーの挿入」コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

既にマスタースライドに存在するプレースホルダー形状の書式設定も可能です。以下の例はタイトル プレースホルダーを見つけて線形グラデーション塗りつぶしを適用します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![通常スライドに継承された書式設定済みタイトル プレースホルダー](slide-master_8.png)

プレースホルダーとテキスト書式設定の詳細オプションについては、[Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) と [Text Formatting](/nodejs-java/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターベースの背景は、レイアウトやスライドで上書きされない限り継承されます。以下の例は最初のマスタースライドに単色背景色を設定します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

関連トピックについては、[Presentation Background](/nodejs-java/presentation-background/) と [Presentation Theme](/nodejs-java/presentation-theme/) を参照してください。

## **マスタースライドを別のプレゼンテーションにクローンする**

`MasterSlideCollection.addClone` を使用してマスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーション内のレイアウトやスライドで使用できます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

マスターと一緒に通常スライドもクローンしたい場合は、[Clone Slides](/nodejs-java/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。これは、セクションごとに異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理のための PowerPoint コマンド](slide-master_9.jpg)

以下の例はデフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、最後にそのレイアウトに基づく新しいスライドを追加しています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **スライドマスターを比較する**

マスタースライドは [BaseSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/) から継承した `equals` メソッドで比較できます。比較は構造と静的コンテンツ（形状、テキスト、書式設定、アニメーション、その他のスライド設定）を対象とし、スライド ID などの一意識別子や現在の日付といった動的プレースホルダーの値は比較対象外です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

詳細は [Compare Presentation Slides](/slides/ja/nodejs-java/compare-slides/) をご覧ください。

## **スライドマスタービューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/viewproperties/) の `setLastView` メソッドを使用して、PowerPoint が最初に開くビューを制御できます。以下の例はプレゼンテーションをスライドマスタービューで開きます:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

その他のビュー設定については、[Save Presentation](/slides/ja/nodejs-java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズの削減とテンプレート保守の簡素化が期待できます。

`removeUnused` を使用して `getMasters()` コレクションから未使用マスターを削除します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

低コードの `Compress.removeUnusedMasterSlides` メソッドも利用可能です:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターはテーマ、背景、共通図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含められますか？**

はい。プレゼンテーションは複数のスライドマスターを保持できます。セクションごとに異なる視覚体系やブランディングが必要な場合に、複数マスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有ビジュアル要素や共通書式はマスタースライドに配置し、コンテンツ用プレースホルダーは通常スライドが使用するレイアウトに置きます。

**使用中のマスタースライドを削除できますか？**

できません。依存スライドがあるマスタースライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用マスターのみを削除するクリーンアップ手法を利用してください。