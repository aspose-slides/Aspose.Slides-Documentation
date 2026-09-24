---
title: JavaScript で PowerPoint テキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- テキストの追加
- 段落の追加
- テキストの管理
- 段落の管理
- 箇条書きの管理
- 段落インデント
- ハンギングインデント
- 段落の箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落のプロパティ
- HTML のインポート
- テキストから HTML へ
- 段落から HTML へ
- 段落から画像へ
- テキストから画像へ
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java は、テキストをテキストフレーム、段落、ポーションの階層として表します:

* [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) は、シェイプ内のテキストコンテナを表し、段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) は、テキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) は、段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

このため、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数のポーションを使用した段落の作成**

次の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します:

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) オブジェクトを追加します。
6. 各段落に 3 つのポーションを含めるために十分な数の [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [Portion.getPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/getportionformat/) を使用して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この JavaScript の例は上記手順を実装しています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **箇条書きおよび番号付きリストの作成**

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けは、関連項目を視認しやすくします。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/) で定義します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. シンボル箇条書き用の [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) を作成します。
7. [BulletFormat.setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/settype/) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落のテキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[BulletFormat.setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/settype/) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この JavaScript の例はシンボル箇条書きと番号付き箇条書きを作成します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **画像箇条書きの使用**

画像箇条書きでは、シンボルや数字の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加し、その [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) として追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [BulletFormat.setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/settype/) を [BulletType.Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bullettype/) に設定します。
8. [BulletFormat.getPicture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/getpicture/) を介して画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 変更したプレゼンテーションを保存します。

この JavaScript の例は画像箇条書きを作成します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **多階層リストの作成**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setdepth/) を設定して、段落をリストの異なるレベルに配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加し、そのテキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを構成します。
4. 各段落の [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setdepth/) 値をそれぞれ `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この JavaScript の例は 4 レベルの箇条書きリストを作成します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **番号付きリスト項目の開始番号をカスタム値に設定**

[BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) を使用して、番号付き段落の最初に表示される番号を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) を作成し、スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) をそれぞれ `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この JavaScript の例は各段落にカスタム開始番号を割り当てます:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **段落のレイアウトと終端プロパティの制御**

### **先頭行インデントの設定**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) を使用して、段落の先頭行インデントを制御します。このメソッドは、段落の左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) を使用します。先頭行だけを移動したいときは [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) を使用します。

以下の例は複数の段落を作成し、異なる [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) の値を適用して、先頭行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) の値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The first-line indent of the paragraphs](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) に負の値を渡すことで、この効果を実現します。

実際には、[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) が段落本文の左位置を定義し、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、`setMarginLeft` に正の値を、`setIndent` に負の値を渡します。

この書式設定は、参考文献、文献リスト、用語集のエントリなど、折り返し行が段落本文の下に揃える必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) に正の値を設定します。
6. [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) に負の値を渡してハンギングインデント効果を作成します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のハンギングインデント設定方法を示します:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The hanging indent of the paragraphs](hanging_indent.png)

### **段落末端プロパティの設定**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) は段落末端記号の書式設定を制御します。次の例では、2 番目の段落の末端記号にフォントサイズとラテン文字フォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) を作成またはロードし、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 2 番目の段落の末端記号用に [PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) を作成します。
5. [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) と [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) を設定します。
6. [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) で書式を割り当て、プレゼンテーションを保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **描画された行数の取得**

[Paragraph.getLinesCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getLinesCount) を使用すると、テキストレイアウト後の段落が占める行数（自動折り返しを含む）を取得できます。これは、プレゼンテーションテンプレート内のテキスト長やレイアウトをチェックする際に便利です。

段落は [TextFrame.getParagraphs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/#getParagraphs) の項目の 1 つであり、複数の描画行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは、テキストに明示的な改行文字を挿入せずに利用可能な幅に基づいて行を生成します。そのため、段落数や改行文字の数を数えても実際の描画行数は得られません。

以下の例はテキストシェイプを作成し、行数を取得し、シェイプを狭めてから短い文字列に置き換えます。折り返しは有効で、オートフィットは無効にしているため、シェイプ幅が折り返しを制御し、テキストやシェイプの自動縮小は行われません。シェイプの寸法はポイント単位です。最後に、別の段落を追加し、テキストフレーム全体の行数を合計します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

このテキストと寸法では、シェイプを狭めると行数が増え、短い文字列に置き換えると行数が減ります。正確なカウントはフォントの利用可否や置換、フォントサイズ、余白、インデント、折り返し、オートフィット設定に依存します。テンプレートをチェックする際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかは判断できません。利用可能な高さ、行の高さ、段落と行の間隔、オートフィット動作も重要です。折り返しが無効の場合、1 行でも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

[ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドにアクセスし、[AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソースとなる HTML 文字列を定義または取得します。
5. HTML 文字列を [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) に渡します。
6. 変更したプレゼンテーションを保存します。

この JavaScript の例は HTML をテキストフレームにインポートします:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **段落テキストを HTML にエクスポート**

[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) を使用して、選択した範囲の段落を HTML としてエクスポートします。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) のインスタンスを作成またはロードします。
2. スライドにアクセスし、テキストを含む [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を見つけます。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この自己完結型の JavaScript の例はテキストシェイプを作成し、すべての段落をエクスポートします:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **段落を画像としてレンダリング**

[Paragraph.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getImage) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/) を返します。返された画像は [IImage.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/iimage/#save) でファイルに保存できます。シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[Paragraph.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getImage) は、段落が親コレクションに見つからない、または有効な描画境界がない、あるいはレンダリングできない場合に `null` を返すことがあります。保存前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

次のテキストボックスには 3 つの段落が含まれています:

![The text box with three paragraphs](paragraph_to_image_input.png)

以下の例は、通常のテキストシェイプ内の 2 番目の段落をデフォルトスケールでレンダリングし、PNG 形式で画像を保存します。`finally` ブロックで画像が正しく破棄されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

結果:

![The paragraph image](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`scaleX` と `scaleY` パラメーターを受け取る [Paragraph.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getImage) のオーバーロードを使用して、水平および垂直のスケール係数を設定します。次の例はテーブルを作成し、最初のセルの段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

スケール係数が `1` の場合はデフォルトピクセルサイズが保たれます。たとえば、両方の係数を `2` にすると、幅と高さがほぼ 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力時にテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像になります。横横比を保ちたい場合は等しい係数を使用し、水平と垂直で異なる係数を設定すると出力が個別に伸縮します。

[Shape.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getImage) を使用してシェイプ全体をレンダリングすることは、シェイプの塗りつぶし、枠線、その他の視覚コンテキストを含める必要がある場合に有用です。段落だけの画像が必要なときは、[Paragraph.getImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/#getImage) を使用してください。

## **FAQ**

**テキストフレーム内の行折り返しを完全に無効にできますか？**

はい。 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/setwraptext/) を設定して折り返しを無効にすると、行はテキストフレームの端で改行されなくなります。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

[Paragraph.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/getrect/) を使用して段落の外接矩形を取得します。個々のポーションの境界は [Portion.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#getRect) で取得できます。

**段落の配置（左揃え、右揃え、中央揃え、均等割り付け）はどこで制御しますか？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setalignment/) は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に対して校正言語を設定できますか？**

はい。個々のポーションに対して [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) を設定すれば、1 つの段落内に複数の言語のテキストを含めることができます。