---
title: JavaScript でプレゼンテーション プレースホルダーを管理する
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- チャート プレースホルダー
- コンテンツ プレースホルダー
- プロンプト テキスト
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を利用して、テキスト、画像、チャート、コンテンツ プレースホルダーの検査と編集方法を学び、プレースホルダー継承を理解する方法をご紹介します。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウト スライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) メソッドを通じてプレースホルダー情報を公開します。このメソッドは、通常のシェイプの場合は `null`、それ以外の場合は [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) オブジェクトを返します。プレースホルダーが何を保持することを想定しているかを判断するには、[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) を使用します。

プレースホルダーのタイプが分かった後も、シェイプ クラスは重要です。

- 空のテキスト、画像、チャート、またはコンテンツ プレースホルダーは、通常 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) で表されます。
- 内容が入った画像プレースホルダーは、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) で表すことができます。
- 内容が入ったチャートプレースホルダーは、[Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) で表すことができます。
- コンテンツ プレースホルダーは複数の種類のコンテンツを保持できます。すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) であると仮定せず、[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) と実行時のシェイプ クラスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) はプレースホルダーの役割を示しますが、シェイプの実行時タイプを保証するものではありません。テキスト、画像、チャート、テーブル、またはメディア固有のメンバーにアクセスする前に、必ずタイプチェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは、1つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを含み、レイアウトから継承できます。

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) を呼び出すと、この階層で 1 レベル上に移動します。スライド プレースホルダーは通常、レイアウト プレースホルダーを返し、レイアウト プレースホルダーはマスター プレースホルダーを返すことができます。シェイプにベース プレースホルダーがない場合、メソッドは `null` を返します。

次の例は、最初のスライドのプレースホルダーを列挙し、それらのベース プレースホルダーを報告します：

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

通常スライド上でプレースホルダーを編集すると、そのスライド用のローカル オーバーライドが作成または変更されます。関連するレイアウトまたはマスターを編集すると、その設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの普通のシェイプはベース プレースホルダーを持たず、同じ座標にあるだけで継承を開始することはありません。

## **プレースホルダーのステータスを削除する**

テンプレートを調整する際は、[Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) を使用して既存のオブジェクトを普通のシェイプとして保持します。その [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) メソッドは `null` を返しますが、シェイプはスライドのコレクションに残ります。対照的に、[ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) はそのコレクションからシェイプを削除します。

次の例は、少なくとも1枚のスライドと最初のスライドに空でないテキスト プレースホルダーがある `template.pptx` が必要です。レイアウトまたはマスターから書式設定を継承したプレースホルダーを使用して、リレーションシップを削除した際の影響を確認します。この例では、同じシェイプが残っていることを確認し、普通のシェイプになった後に再度メソッドを呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例では意図的にこれらの設定を変更せずに残しているため、出力が異なる場合があります。位置とサイズが完全に継承されているシェイプは、呼び出し後に座標と寸法が 0 になることがあり、コレクションに残っていても見えなくなることがあります。
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // 普通のシェイプでメソッドを呼び出しても効果はありません。
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

一致するプレースホルダーの場合、3 つのチェックすべてが `true` を出力します。テキストは残りますが、プレースホルダーのリレーションシップが削除されると、継承された位置、サイズ、回転、フォント、段落の配置、テキストフレームの余白、垂直アンカリング、塗りつぶし、線の設定が変わることがあります。たとえば、継承されたタイトルの書式設定が普通のテキスト書式に戻ることがあります。レイアウトの詳細については、[Slide Layout](/slides/ja/nodejs-java/slide-layout/) を参照してください。

意図した外観を保持するには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な実効書式設定値を個別の変数にコピーします。これらの値は、[PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective), [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) を通じて取得します。リレーションシップが削除された後にテキスト書式設定値が変わる可能性があるため、実効フォーマット オブジェクトだけに依存しないでください。取得した値を普通のシェイプに明示的に適用し、フォント ファミリ、サイズ、スタイル、色、段落設定、テキスト フレーム設定、塗りつぶし、線などテンプレートで使用される設定を反映させます。

継承されたシェイプのジオメトリも、[GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) を使用して明示的に割り当てる必要がある場合があります。長方形のテキスト プレースホルダーの場合、[ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle) を設定することを意味します。塗りつぶしと線だけを復元しても、表示上の長方形が復元されないことがあります。追加効果やより複雑な書式設定を持つテンプレートでは、これらの設定も同様に扱う必要があります。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、およびテキスト プレースホルダーは通常テキストをサポートします。[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) であるかを確認した上で、その [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) メソッドを使用してください。

この例は、最初のスライドの最初のタイトルプレースホルダーを更新し、結果を保存します：

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

このパターンは、画像、チャート、テーブル、メディア プレースホルダーを [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) オブジェクトとして扱うことを防ぎます。また、壊れやすいシェイプ インデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上のプロンプトテキストを設定する**

プロンプトテキストは、空のプレースホルダーに表示される設計時の指示で、例として *Click to add title*（タイトルを追加するにはクリック）があります。カスタム プロンプトテキストは、通常のスライドのシェイプ コレクションを経由せず、レイアウト プレースホルダーに直接設定してください。[Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide)でレイアウトにアクセスし、[BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)が返すコレクションを反復処理します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します：

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

プロンプトテキストは通常のスライド コンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示されることを目的としています。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、そのレイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

処理すべき2つのケースがあります：

- 画像プレースホルダーがすでに内容を持ち、[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) で表されている場合は、[PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture), [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) を使って画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) を使用してプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は、両方のケースをサポートし、プレゼンテーションを保存します：

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

空のプレースホルダー用に作成された置き換えは、[Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) にセッターが無いため、新しいプレースホルダーではなくローカルの画像フレームになります。予約された位置は保持しますが、プレースホルダー固有の動作は継承しなくなります。プレースホルダーとのリレーションシップを保持することが重要な場合は、まず PowerPoint でプレースホルダーを用意して内容を設定し、その後 Aspose.Slides で生成された [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) を更新してください。

画像の透過、トリミング、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/nodejs-java/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像塗りつぶしに関連し、プレースホルダーのメタデータには関係しません。

## **チャートおよびコンテンツ プレースホルダーの操作**

内容が入ったチャート プレースホルダーは、[Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) で表すことができます。この例では、プレースホルダータイプと実行時クラスの両方でそのチャートを検索し、タイトルを変更してファイルを保存します：

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

一般的なコンテンツ プレースホルダーは通常、[PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object) を持ちます。PowerPoint では、チャート、テーブル、図、画像、メディアなど複数のコンテンツタイプの起動装置として機能します。内容が設定された後は、実際のシェイプ クラスを確認して何が含まれているかを把握してください。特化したレイアウトでは、[PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media), [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram) を公開することもあります。

Aspose.Slides は、[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) を変更しただけで、空の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) に変換することはできません。タイプはオブジェクトを通じて変更できません。空のチャートまたはコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを実行します：

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

追加されたチャートは普通のローカル チャートです。プレースホルダーの領域を占有しますが、レイアウト プレースホルダーからは継承しません。カテゴリ、シリーズ、またはブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/nodejs-java/powerpoint-charts/) を使用してください。

## **完全例: テキストまたは画像コンテンツの更新**

以下のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認して、適切なコンテンツを更新し、出力を保存します。この例では、シェイプ インデックスを前提にしたり、すべてのプレースホルダーを同じクラスとして扱うことを意図的に回避しています。

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

**ベース プレースホルダーとは何ですか？**

ベース プレースホルダーとは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプです。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) を使用して取得します。普通のローカル シェイプは、プレースホルダー階層の一部ではないため `null` を返します。

**レイアウト プレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承された書式設定やプロンプトテキストは変更できますが、既存のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体で実際のタイトルテキストを置き換えるには、スライドを反復処理し、各タイトル プレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、またはハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用します。完全な例については、[Manage Presentation Header and Footer](/slides/ja/nodejs-java/presentation-header-and-footer/) を参照してください。