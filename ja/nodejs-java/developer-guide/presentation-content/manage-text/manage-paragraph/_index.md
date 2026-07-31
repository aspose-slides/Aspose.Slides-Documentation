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
  - ぶら下げインデント
  - 段落の箇条書き
  - 番号付きリスト
  - 箇条書きリスト
  - 段落プロパティ
  - HTML のインポート
  - テキストを HTML に変換
  - 段落を HTML に変換
  - 段落を画像に変換
  - テキストを画像に変換
  - 段落のエクスポート
  - PowerPoint
  - OpenDocument
  - プレゼンテーション
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js を Java 経由で活用し、JavaScript で PPT、PPTX、ODP プレゼンテーションの段落書式設定をマスター—配置、間隔、スタイルを最適化"
---
## **はじめに**

Aspose.Slides は、Java で PowerPoint のテキスト、段落、ポーションを操作するために必要なすべてのクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) クラスを提供します。`TextFrame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは、1 つまたは複数のポーション（テキストポーションオブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、基礎となる `Portion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のポーションを含む複数の段落を追加**

These steps show you how to add a text frame containing 3 paragraphs and each paragraph containing 3 portions:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add a Rectangle [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Get the ITextFrame associated with the [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/).
5. Create two [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) objects and add them to the `IParagraphs` collection of the [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
6. Create three [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) objects for each new `Paragraph` (two Portion objects for default Paragraph) and add each `Portion` object to the IPortion collection of each `Paragraph`.
7. Set some text for each portion.
8. Apply your preferred formatting features to each portion using the formatting properties exposed by the `Portion` object.
9. Save the modified presentation.

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape の TextFrame にアクセス
    var tf = ashp.getTextFrame();
    // 異なるテキスト書式の Paragraph と Portion を作成
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // PPTX をディスクに保存
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きの段落は常に読みやすく、理解しやすいです。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the selected slide.
4. Access the autoshape's [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance using the [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) class.
7. Set the bullet `Type` for the paragraph to `Symbol` and set the bullet character.
8. Set the paragraph `Text`.
9. Set the paragraph `Indent` for the bullet.
10. Set a color for the bullet.
11. Set a height of the bullet.
12. Add the new paragraph to the `TextFrame` paragraph collection.
13. Add the second paragraph and repeat the process from step 7 to step 12.
14. Save the presentation.

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // AutoShape を追加してアクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape のテキストフレームにアクセス
    var txtFrm = aShp.getTextFrame();
    // デフォルトの段落を削除
    txtFrm.getParagraphs().removeAt(0);
    // 段落を作成
    var para = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルと記号を設定
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 段落のテキストを設定
    para.setText("Welcome to Aspose.Slides");
    // 箇条書きのインデントを設定
    para.getParagraphFormat().setIndent(25);
    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para);
    // 2 番目の段落を作成
    var para2 = new aspose.slides.Paragraph();
    // 段落の箇条書きタイプとスタイルを設定
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // 段落のテキストを追加
    para2.setText("This is numbered bullet");
    // 箇条書きのインデントを設定
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
    // 箇条書きの高さを設定
    para2.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para2);
    // 変更されたプレゼンテーションを保存
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像箇条書きの段落は読みやすく、理解しやすいです。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Access the autoshape's [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance using the [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) class.
7. Load the image in [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/).
8. Set the bullet type to [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) and set the image.
9. Set the Paragraph `Text`.
10. Set the Paragraph `Indent` for the bullet.
11. Set a color for the bullet.
12. Set a height for the bullet.
13. Add the new paragraph to the `TextFrame` paragraph collection.
14. Add the second paragraph and repeat the process based on the previous steps.
15. Save the modified presentation.

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = presentation.getSlides().get_Item(0);
    // 箇条書き用の画像を作成
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape を追加してアクセス
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape のテキストフレームにアクセス
    var textFrame = autoShape.getTextFrame();
    // デフォルトの段落を削除
    textFrame.getParagraphs().removeAt(0);
    // 新しい段落を作成
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 段落の箇条書きスタイルと画像を設定
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 箇条書きの高さを設定
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加
    textFrame.getParagraphs().add(paragraph);
    // プレゼンテーションを PPTX ファイルとして保存
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // プレゼンテーションを PPT ファイルとして保存
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **階層的箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層的箇条書きは読みやすく、理解しやすいです。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) in the new slide.
4. Access the autoshape's [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance through the [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) class and set the depth to 0.
7. Create the second paragraph instance through the `Paragraph` class and set the depth set to 1.
8. Create the third paragraph instance through the `Paragraph` class and set the depth set to 2.
9. Create the fourth paragraph instance through the `Paragraph` class and set the depth set to 3.
10. Add the new paragraphs to the `TextFrame` paragraph collection.
11. Save the modified presentation.

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // AutoShape を追加してアクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセス
    var text = aShp.addTextFrame("");
    // デフォルトの段落をクリア
    text.getParagraphs().clear();
    // 最初の段落を追加
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定
    para1.getParagraphFormat().setDepth(0);
    // 2 番目の段落を追加
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定
    para2.getParagraphFormat().setDepth(1);
    // 3 番目の段落を追加
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定
    para3.getParagraphFormat().setDepth(2);
    // 4 番目の段落を追加
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定
    para4.getParagraphFormat().setDepth(3);
    // 段落をコレクションに追加
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **カスタム番号リスト付き段落の管理**

[BulletFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/) クラスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the slide containing the paragraph.
3. Add an [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Access the autoshape [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance through the [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) class and set [NumberedBulletStartWith](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) to 2.
7. Create the second paragraph instance through the `Paragraph` class and set `NumberedBulletStartWith` to 3.
8. Create the third paragraph instance through the `Paragraph` class and set `NumberedBulletStartWith` to 7.
9. Add the new paragraphs to the `TextFrame` paragraph collection.
10. Save the modified presentation.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセス
    var textFrame = shape.getTextFrame();
    // デフォルトの既存段落を削除
    textFrame.getParagraphs().removeAt(0);
    // 最初のリスト
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **段落の先頭行インデントの設定**

[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) メソッドを使用して、段落の先頭行インデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に合わせて配置されたままです。

段落全体を移動させる必要がある場合は [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) を使用します。先頭行だけを移動させる場合は [ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) を使用します。

以下の例では、複数の段落を作成し、異なるインデント値を適用して、先頭行インデントが段落レイアウトに与える影響を示します。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the target slide.
3. Add a rectangular [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Add an empty [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) to the shape and remove the default paragraph.
5. Create several paragraphs and set different [Indent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) values for them.
6. Add the paragraphs to the text frame.
7. Save the modified presentation.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![段落の先頭行インデント](first_line_indent.png)

## **段落のぶら下げインデントの設定**

ぶら下げインデントは、最初の行が残りの行より左側で始まる段落レイアウトです。Aspose.Slides では、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) メソッドを使用してこの効果を作成します。インデントに負の値を設定すると、段落本文に対して最初の行が左に移動します。

実際には、[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) が段落本文の左位置を定義し、[ParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) がその余白に対する最初の行の位置を定義します。ぶら下げインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、参考文献、引用、用語集の項目など、折り返し行が段落本文の下に揃える必要がある段落に便利です。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the target slide.
3. Add a rectangular [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Add an empty [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) to the shape and remove the default paragraph.
5. Create paragraphs and set a positive [MarginLeft](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) value for each paragraph.
6. Set a negative [Indent](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setindent/) value to create the hanging indent effect.
7. Add the paragraphs to the text frame.
8. Save the modified presentation.

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![段落のぶら下げインデント](hanging_indent.png)

## **段落の末尾ランプロパティの管理**

1. Create an instance of [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Get the reference for the slide containing the paragraph through its position.
3. Add a rectangle [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Add a [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) with two paragraphs to the Rectangle.
5. Set the `FontHeight` and Font type for the paragraphs.
6. Set the End properties for the paragraphs.
7. Write the modified presentation as a PPTX file.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **HTML テキストの段落へのインポート**

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Add and access `AutoShape`'s [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Read the source HTML file in a TextReader.
7. Create the first paragraph instance through the [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) class.
8. Add the HTML file content in the read TextReader to the TextFrame's [ParagraphCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphcollection/).
9. Save the modified presentation.

```javascript
// 空のプレゼンテーション インスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // HTML コンテンツを収めるために AutoShape を追加
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // シェイプにテキストフレームを追加
    ashape.addTextFrame("");
    // 追加したテキストフレームのすべての段落をクリア
    ashape.getTextFrame().getParagraphs().clear();
    // ストリームリーダーを使用して HTML ファイルを読み込み
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // テキストフレームに HTML ストリームリーダーからテキストを追加
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // プレゼンテーションを保存
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **段落テキストを HTML にエクスポート**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための高度なサポートを提供します。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) class and load the desired presentation.
2. Access the relevant slide's reference through its index.
3. Access the shape containing the text that will be exported to HTML.
4. Access the shape [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/).
5. Create an instance of `StreamWriter` and add the new HTML file.
6. Provide a starting index to StreamWriter and export your preferred paragraphs.

```javascript
    // プレゼンテーション ファイルをロード
    var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
    try {
        // プレゼンテーションのデフォルトの最初のスライドにアクセス
        var slide = pres.getSlides().get_Item(0);
        // 目的のインデックス
        var index = 0;
        // 追加したシェイプにアクセス
        var ashape = slide.getShapes().get_Item(index);
        // 出力 HTML ファイルを作成
        var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
        var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
        // 最初の段落を HTML として抽出
        // 段落の開始インデックスとコピーする総段落数を指定して段落データを HTML に書き込む
        writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
        writer.close();
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **段落を画像として保存**

このセクションでは、[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスで表されるテキスト段落を画像として保存する方法を示す 2 つの例を紹介します。どちらの例も、[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) クラスの `getImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。このアプローチにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの利用に便利です。

ここでは、sample.pptx というプレゼンテーション ファイルが 1 つのスライドを持ち、最初のシェイプが 3 つの段落を含むテキスト ボックスであると仮定します。

![3 つの段落を含むテキスト ボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。そのために、プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。次に、その段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式設定を保持したまま、特定の段落を別画像として保存したい場合に特に有用です。

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // シェイプをメモリ内にビットマップとして保存します。
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // メモリからシェイプのビットマップを作成します。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 第2段落の境界を計算します。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // シェイプのビットマップを切り取り、段落のビットマップのみを取得します。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、段落画像にスケーリング係数を追加して前のアプローチを拡張します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。その後、スケールを考慮して段落の境界を計算します。スケーリングは、たとえば高品質な印刷物で使用するために、より詳細な画像が必要な場合に特に有用です。

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きでシェイプをメモリ内にビットマップとして保存します。
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // メモリからシェイプのビットマップを作成します。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 第2段落の境界を計算します。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // シェイプのビットマップを切り取り、段落のビットマップのみを取得します。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **よくある質問**

**テキストフレーム内の改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[setWrapText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/setwraptext/)）を使用して折り返しをオフにすると、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（場合によっては単一のポーション）のバウンディング矩形を取得して、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで制御されますか？**

[setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setalignment/) は [ParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/) の段落レベルの設定用メソッドで、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例：1語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)）で設定されるため、1 つの段落内に複数の言語が共存できます。