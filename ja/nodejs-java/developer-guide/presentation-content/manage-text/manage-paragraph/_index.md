---
title: JavaScript で PowerPoint テキスト段落を管理する
linktitle: 段落を管理する
type: docs
weight: 40
url: /ja/nodejs-java/manage-paragraph/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML のインポート
- テキストを HTML に変換
- 段落を HTML に変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を Java 経由で使用し、PPT、PPTX、ODP プレゼンテーションの段落書式設定をマスターし、配置、間隔、スタイルを最適化する。"
---

Aspose.Slides は、Java で PowerPoint のテキスト、段落、部分を操作するために必要なすべてのクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) クラスを提供します。`TextFame` オブジェクトは 1 つまたは複数の段落を持つことができ（各段落は改行で作成されます）。
* Aspose.Slides は、部分を表すオブジェクトを追加できるようにする [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは 1 つまたは複数の部分（テキスト部分オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式プロパティを表すオブジェクトを追加できるようにする [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、基礎となる `Portion` オブジェクトを通じて、さまざまな書式プロパティを持つテキストを扱うことができます。

## **複数の段落と複数の部分を含むテキストフレームを追加**

以下の手順は、3 つの段落を含み、各段落が 3 つの部分を含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) オブジェクトを作成し、`IParagraphs` コレクションに追加します。
6. 各新しい `Paragraph` に対して 3 つの [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) オブジェクト（デフォルト段落の場合は 2 つ）を作成し、各 `Paragraph` の IPortion コレクションに追加します。
7. 各部分にテキストを設定します。
8. `Portion` オブジェクトが提供する書式プロパティを使用して、各部分に好きな書式を適用します。
9. 変更したプレゼンテーションを保存します。

この Javascript コードは、部分を含む段落を追加する手順の実装例です:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // Rectangle タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape の TextFrame にアクセスする
    var tf = ashp.getTextFrame();
    // 異なるテキスト書式を持つ Paragraph と Portion を作成する
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
    // PPTX をディスクに保存する
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落の箇条書き管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きのインデントを `Indent` で設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を作成し、手順 7〜12 を繰り返します。
14. プレゼンテーションを保存します。

この Javascript コードは、段落の箇条書きを追加する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // AutoShape を追加し、取得する
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape のテキストフレームにアクセスする
    var txtFrm = aShp.getTextFrame();
    // デフォルトの段落を削除する
    txtFrm.getParagraphs().removeAt(0);
    // 段落を作成する
    var para = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 段落のテキストを設定する
    para.setText("Welcome to Aspose.Slides");
    // 箇条書きのインデントを設定する
    para.getParagraphFormat().setIndent(25);
    // 箇条書きの色を設定する
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定する
    // 箇条書きの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para);
    // 2 つ目の段落を作成する
    var para2 = new aspose.slides.Paragraph();
    // 段落の箇条書きタイプとスタイルを設定する
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // 段落のテキストを追加する
    para2.setText("This is numbered bullet");
    // 箇条書きのインデントを設定する
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定する
    // 箇条書きの高さを設定する
    para2.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para2);
    // 変更されたプレゼンテーションを保存する
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **画像箇条書き管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) で画像を読み込みます。
8. 箇条書きのタイプを [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントを `Indent` で設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を作成し、前の手順を繰り返します。
15. 変更したプレゼンテーションを保存します。

この Javascript コードは、画像箇条書きを追加および管理する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = presentation.getSlides().get_Item(0);
    // 箇条書き用の画像をインスタンス化する
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape を追加し、取得する
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape のテキストフレームにアクセスする
    var textFrame = autoShape.getTextFrame();
    // デフォルトの段落を削除する
    textFrame.getParagraphs().removeAt(0);
    // 新しい段落を作成する
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 段落の箇条書きスタイルと画像を設定する
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 箇条書きの高さを設定する
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加する
    textFrame.getParagraphs().add(paragraph);
    // プレゼンテーションを PPTX ファイルとして書き出す
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // プレゼンテーションを PPT ファイルとして書き出す
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **階層箇条書き管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層箇条書きは読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、Depth を 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、Depth を 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、Depth を 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、Depth を 3 に設定します。
10. 新しい段落をすべて `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この Javascript コードは、階層箇条書きを追加および管理する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // AutoShape を追加し、取得する
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセスする
    var text = aShp.addTextFrame("");
    // デフォルトの段落をクリアする
    text.getParagraphs().clear();
    // 最初の段落を追加する
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定する
    para1.getParagraphFormat().setDepth(0);
    // 2 番目の段落を追加する
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定する
    para2.getParagraphFormat().setDepth(1);
    // 3 番目の段落を追加する
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定する
    para3.getParagraphFormat().setDepth(2);
    // 4 番目の段落を追加する
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きのレベルを設定する
    para4.getParagraphFormat().setDepth(3);
    // 段落をコレクションに追加する
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // プレゼンテーションを PPTX ファイルとして書き出す
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタム番号リスト付き段落の管理**

[BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) クラスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象段落が含まれるスライドにアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この Javascript コードは、カスタム番号付けまたは書式設定された段落を追加および管理する方法を示しています:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセスする
    var textFrame = shape.getTextFrame();
    // デフォルトで既存の段落を削除する
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


## **段落インデントの設定**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用して対象スライドの参照にアクセスします。
1. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 矩形 AutoShape に 3 段落のある [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を追加します。
1. 矩形の枠線を非表示にします。
1. 各 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) の `BulletOffset` プロパティでインデントを設定します。
1. 変更したプレゼンテーションを書き出して PPT ファイルにします。

この Javascript コードは、段落インデントを設定する方法を示しています:
```javascript
// Presentation クラスをインスタンス化する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得する
    var sld = pres.getSlides().get_Item(0);
    // 矩形シェイプを追加する
    var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
    // 矩形に TextFrame を追加する
    var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    // テキストがシェイプに合わせるように設定する
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // 矩形の枠線を非表示にする
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // TextFrame の最初の段落を取得しインデントを設定する
    var para1 = tf.getParagraphs().get_Item(0);
    // 段落の箇条書きスタイルと記号を設定する
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // TextFrame の2番目の段落を取得しインデントを設定する
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // TextFrame の3番目の段落を取得しインデントを設定する
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // プレゼンテーションをディスクに書き出す
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落のハンギングインデント設定**

この Javascript コードは、段落のハンギングインデントを設定する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落の End プロパティ管理**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置で段落を含むスライドの参照を取得します。
1. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
1. 矩形に 2 段落のある [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を追加します。
1. 段落の `FontHeight` とフォント種別を設定します。
1. 段落の End プロパティを設定します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルにします。

この Javascript コードは、PowerPoint の段落に End プロパティを設定する方法を示しています:
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


## **HTML テキストを段落にインポートする**

Aspose.Slides は、HTML テキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. `AutoShape` の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML 内容を TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この Javascript コードは、段落への HTML テキスト インポート手順の実装例です:
```javascript
// 空のプレゼンテーションインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // HTML コンテンツを収めるために AutoShape を追加する
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // シェイプにテキストフレームを追加する
    ashape.addTextFrame("");
    // 追加したテキストフレームのすべての段落をクリアする
    ashape.getTextFrame().getParagraphs().clear();
    // ストリームリーダーを使用して HTML ファイルを読み込む
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // テキストフレームに HTML ストリームリーダーからテキストを追加する
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // プレゼンテーションを保存する
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、対象のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. `StreamWriter` に開始インデックスを指定し、目的の段落をエクスポートします。

この Javascript コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています:
```javascript
// プレゼンテーションファイルをロードする
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // 目的のインデックス
    var index = 0;
    // 追加されたシェイプにアクセスする
    var ashape = slide.getShapes().get_Item(index);
    // 出力 HTML ファイルを作成する
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // 最初の段落を HTML として抽出する
    // 段落の開始インデックスとコピーする段落数を指定して、段落データを書き込む
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落を画像として保存する**

このセクションでは、[Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。どちらの例も、[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) クラスの `getImage` メソッドで段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これらの手法により、PowerPoint プレゼンテーションからテキストの特定部分を切り出して画像として保存でき、さまざまなシナリオで再利用できます。

サンプルとして、sample.pptx というファイルに 1 スライドがあり、最初のシェイプが 3 段落を含むテキストボックスであるとします。

![3 段落を含むテキストボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内で 2 番目の段落の境界を計算します。段落は新しいビットマップ画像に再描画され、PNG 形式で保存されます。この方法は、段落を別画像として保存したいが、テキストのサイズや書式を正確に保持したい場合に便利です。
```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 形状をメモリ内にビットマップとして保存する。
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // メモリから形状ビットマップを作成する。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 2番目の段落の境界を計算する。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算する（最小サイズは 1x1 ピクセル）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 形状ビットマップを切り取り、段落ビットマップだけを取得する。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


結果:

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前例にスケーリング係数を加えて段落画像を拡大します。シェイプをプレゼンテーションから抽出し、スケール `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。スケーリングは、印刷物など高品質な画像が必要な場合に特に有用です。
```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きで形状をメモリ内にビットマップとして保存する。
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // メモリから形状ビットマップを作成する。
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // 2番目の段落の境界を計算する。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 出力画像の座標とサイズを計算する（最小サイズは 1x1 ピクセル）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // 形状ビットマップを切り取り、段落ビットマップだけを取得する。
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)）をオフにすれば、フレーム端で行が折り返されません。

**特定の段落のスライド上での正確な境界を取得する方法は？**

段落（あるいは単一の部分）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで設定しますか？**

[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) は [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) のメソッドで、段落全体に適用され、個々の部分の書式設定に関係なく機能します。

**段落の一部（たとえば単語）だけにスペルチェック言語を設定できますか？**

はい。言語は部分レベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)）で設定されるため、1 つの段落内に複数の言語を共存させることが可能です。