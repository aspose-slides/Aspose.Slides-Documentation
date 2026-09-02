---
title: JavaScriptでプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/nodejs-java/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- コンテンツプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、テキスト、画像、チャート、コンテンツのプレースホルダーを検査および編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保する形状です。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常の形状とは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を[Shape.getPlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getPlaceholder)メソッドで提供します。このメソッドは通常の形状に対しては`null`を返し、[Placeholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholder/)オブジェクトを返します。[Placeholder.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholder/#getType)を使用して、プレースホルダーが何を含むことを意図しているかを判定します。

プレースホルダーの種類が分かっても、形状クラスは依然として重要です。

- 空のテキスト、画像、チャート、またはコンテンツ プレースホルダーは、通常[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/)で表されます。
- 内容が入っている画像プレースホルダーは[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/)で表されます。
- 内容が入っているチャートプレースホルダーは[Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/)で表されます。
- コンテンツ プレースホルダーは複数の種類のコンテンツを含むことができます。[Placeholder.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholder/#getType)と実行時の形状クラスの両方を確認し、すべてのプレースホルダーが[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/)であると想定しないでください。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholder/#getType)はプレースホルダーの役割を示しますが、形状の実行時タイプを保証するものではありません。テキスト、画像、チャート、テーブル、メディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層を構成します:

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスター レベルのプレースホルダーも定義します。
2. レイアウトスライドは1つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライドのプレースホルダーを保持し、レイアウトから継承できます。

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getBasePlaceholder)を呼び出すと、この階層で1つ上のレベルに移動できます。スライドのプレースホルダーは通常、レイアウトのプレースホルダーを返し、レイアウトのプレースホルダーはマスターのプレースホルダーを返すことがあります。形状に基礎プレースホルダーがない場合、メソッドは`null`を返します。

次の例は、最初のスライド上のプレースホルダーを列挙し、それらの基礎プレースホルダーを報告します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

通常スライド上のプレースホルダーを編集すると、そのスライド用のローカル上書きが作成または変更されます。関連するレイアウトまたはマスターを編集すると、まだその設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの通常の形状には基礎プレースホルダーがなく、同じ座標に存在するだけで継承が開始されるわけではありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストのプレースホルダーは通常テキストをサポートしています。[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/)であるかを確認してから、その[getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/#getTextFrame)メソッドを使用してください。

この例は、最初のスライド上の最初のタイトルプレースホルダーを更新し、結果を保存します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

このパターンは、画像、チャート、テーブル、またはメディアのプレースホルダーを[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/)オブジェクトとして扱うことを回避します。また、壊れやすい形状インデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上のプロンプトテキストを設定する**

プロンプトテキストは、空のプレースホルダーに表示されるデザイン時の指示で、たとえば*Click to add title*（タイトルを追加するにはクリック）などがあります。通常スライドの形状コレクションを経由して取得しようとせず、レイアウトのプレースホルダーにカスタムプロンプトテキストを設定してください。レイアウトは[Slide.getLayoutSlide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getLayoutSlide)で取得し、[BaseSlide.getShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getShapes)が返すコレクションを反復処理します。

次の例は、最初のスライドで使用されるレイアウトのタイトルとサブタイトルのプロンプトを変更します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

プロンプトテキストは通常のスライド内容ではありません。PowerPointなどの編集アプリケーションで空のプレースホルダーに対して表示されることを意図しています。ユーザーやプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーの更新**

対応すべきケースは 2 つあります:

- 画像プレースホルダーがすでに内容を持ち、[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/)で表されている場合は、[PictureFrame.getPictureFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picturefillformat/#getPicture)、および[Picture.setImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/picture/#setImage)を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addPictureFrame)を使用してプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

空のプレースホルダーに対して作成された置換は新しいプレースホルダーではなくローカルの画像フレームです。これは[Shape.getPlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getPlaceholder)にセッターがないためです。予約された位置は保持されますが、プレースホルダー固有の振る舞いは継承されなくなります。プレースホルダーとの関係を保持することが重要な場合は、まずPowerPointでプレースホルダーを作成・内容を設定し、その後Aspose.Slidesで生成された[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/)を更新してください。

画像の透過、クロップ、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/nodejs-java/picture-frame/)を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りつぶしに対して行われます。

## **チャートおよびコンテンツプレースホルダーの操作**

内容が入っているチャートプレースホルダーは[Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/)で表されます。この例はプレースホルダーの種類と実行時クラスの両方でそのチャートを検索し、タイトルを変更してファイルを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

汎用コンテンツプレースホルダーは通常[PlaceholderType.Object](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholdertype/#Object)を持ちます。PowerPointでは、チャート、テーブル、図、画像、メディアなど複数のコンテンツタイプの起動元として機能します。コンテンツが設定された後は、実際の形状クラスを調べて何が含まれているかを確認してください。特殊なレイアウトでは、[PlaceholderType.Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholdertype/#Media)、または[PlaceholderType.Diagram](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholdertype/#Diagram)を示すこともあります。

Aspose.Slidesは、[Placeholder.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/placeholder/#getType)を変更しただけで、空の[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/)プレースホルダーを[Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/)に変換しません。タイプはオブジェクトを通じて変更できません。空のチャートまたはコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを行います:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

追加されたチャートは通常のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトのプレースホルダーからは継承しません。カテゴリ、系列、またはブックデータを置き換える必要がある場合は、専用の[chart management articles](/slides/ja/nodejs-java/powerpoint-charts/)を利用してください。

## **完全例: テキストまたは画像コンテンツの更新**

次のエンドツーエンドの例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーと形状のタイプを確認して、適切なコンテンツを更新し、結果を保存します。この例は、形状インデックスを想定したり、すべてのプレースホルダーを同一クラスとして扱うことを意図的に回避しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**ベースプレースホルダーとは何ですか？**

ベースプレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応する形状です。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getBasePlaceholder)を使用して取得します。通常のローカル形状はプレースホルダー階層の一部ではないため、`null`を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承された書式設定やプロンプトテキストは変更できますが、既存のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体の実際のタイトルテキストを置き換えるには、スライドを反復処理し、各タイトルプレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッタープレースホルダーはどのように管理しますか？**

対象となるスライド、レイアウト、マスター、ノート、配布資料のスコープでヘッダーおよびフッターマネージャーを使用します。完全な例については、[Manage Presentation Header and Footer](/slides/ja/nodejs-java/presentation-header-and-footer/)を参照してください。