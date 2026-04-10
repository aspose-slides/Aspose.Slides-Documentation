---
title: JavaScript で PowerPoint テキスト段落を管理する
linktitle: 段落の管理
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
- 段落の箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML のインポート
- テキストから HTML へ
- 段落から HTML へ
- 段落を画像に変換
- テキストを画像に変換
- 段落のエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java 経由で Node.js 用 Aspose.Slides を使用し、PPT、PPTX、ODP プレゼンテーションの段落書式設定をマスターし、配置、間隔、スタイルを最適化する。"
---
Aspose.Slides は、Java で PowerPoint のテキスト、段落、およびポーションを操作するために必要なすべてのクラスとクラス群を提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) クラスを提供します。`TextFame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを提供します。`Paragraph` オブジェクトは、1 つまたは複数のポーション（テキストポーションオブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) クラスを提供します。

`Paragraph` オブジェクトは、内部の `Portion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のポーションを含む複数の段落を追加する**

以下の手順は、3 つの段落を含み、各段落が 3 つのポーションを含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドの参照にアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `Paragraph` に対して 3 つの [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) オブジェクトを作成（デフォルトの Paragraph には 2 つの Portion オブジェクト）し、各 `Paragraph` の IPortion コレクションにそれぞれの `Portion` オブジェクトを追加します。
7. 各ポーションにテキストを設定します。
8. `Portion` オブジェクトが提供する書式設定プロパティを使用して、各ポーションに好みの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この Javascript コードは、ポーションを含む段落を追加する手順の実装例です：

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
    // 異なるテキスト書式で段落とポーションを作成
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
    // PPTX をディスクに書き込む
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **段落の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は、常に読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドの参照にアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書き用に段落の `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 13 を繰り返します。
14. プレゼンテーションを保存します。

この Javascript コードは、段落の箇条書きを追加する方法を示しています：

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを生成
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
    // 段落の箇条書きスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 段落のテキストを設定
    para.setText("Welcome to Aspose.Slides");
    // 箇条書きのインデントを設定
    para.getParagraphFormat().setIndent(25);
    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用
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
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用
    // 箇条書きの高さを設定
    para2.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para2);
    // 変更したプレゼンテーションを保存
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **画像箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) で画像を読み込みます。
8. 箇条書きタイプを [Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書き用に段落の `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順を繰り返します。
15. 変更したプレゼンテーションを保存します。

この Javascript コードは、画像箇条書きを追加および管理する方法を示しています：

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを生成
var presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = presentation.getSlides().get_Item(0);
    // 箇条書き用画像を生成
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

## **多層箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多層箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドの参照にアクセスします。
3. 新しいスライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この Javascript コードは、多層箇条書きを追加および管理する方法を示しています：

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを生成
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
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth(0);
    // 2 番目の段落を追加
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth(1);
    // 3 番目の段落を追加
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth(2);
    // 4 番目の段落を追加
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
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

## **カスタム番号付きリストで段落を管理する**

[BulletFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/) クラスは、`NumberedBulletStartWith` プロパティなど、カスタム番号付けや書式設定を管理できる機能を提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 該当する段落を含むスライドにアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、`NumberedBulletStartWith` を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この Javascript コードは、カスタム番号付けまたは書式設定を持つ段落を追加および管理する方法を示しています：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセス
    var textFrame = shape.getTextFrame();
    // 既定の既存段落を削除
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

## **段落の先頭行インデントを設定する**

`ParagraphFormat.setIndent` メソッドを使用して段落の先頭行インデントを制御します。このメソッドは、段落本体の左余白に対して先頭行のみを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は `ParagraphFormat.setMarginLeft` を使用し、先頭行だけを移動したい場合は `ParagraphFormat.setIndent` を使用します。

以下の例は、複数の段落を作成し、異なるインデント値を適用して先頭行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 複数の段落を作成し、`Indent` の異なる値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントを設定する方法を示しています：

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

結果:

![The first-line indent of the paragraphs](first_line_indent.png)

## **段落のハンギングインデントを設定する**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、`ParagraphFormat.setIndent` メソッドでこの効果を実現します。インデントを負の値に設定すると、段落本体に対して最初の行が左に移動します。

実際には、`ParagraphFormat.setMarginLeft` が段落本文の左位置を決定し、`ParagraphFormat.setIndent` がその余白に対する最初の行の位置を決定します。ハンギングインデントを作成するには、正の `MarginLeft` と負の `Indent` を組み合わせて設定します。

この書式設定は、参考文献・引用・用語集エントリなど、折り返し行が段落本文の下に揃う必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 各段落に対して正の `MarginLeft` 値を設定します。
6. ハンギングインデント効果を作成するために負の `Indent` 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のハンギングインデントを設定する方法を示しています：

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

結果:

![The hanging indent of the paragraphs](hanging_indent.png)

## **段落の End ラン プロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 位置を基に段落を含むスライドの参照を取得します。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を追加します。
5. 段落の `FontHeight` とフォント種別を設定します。
6. 段落の End プロパティを設定します。
7. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Javascript コードは、PowerPoint の段落に End プロパティを設定する方法を示しています：

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

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この Javascript コードは、段落への HTML テキストインポート手順の実装例です：

```javascript
    // 空のプレゼンテーションインスタンスを作成
    var pres = new aspose.slides.Presentation();
    try {
        // プレゼンテーションのデフォルトの最初のスライドにアクセス
        var slide = pres.getSlides().get_Item(0);
        // HTML コンテンツを収容するために AutoShape を追加
        var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
        ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        // シェイプにテキストフレームを追加
        ashape.addTextFrame("");
        // 追加したテキストフレームのすべての段落をクリア
        ashape.getTextFrame().getParagraphs().clear();
        // ストリームリーダーで HTML ファイルを読み込む
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

## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落内のテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して対象のスライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを設定し、希望する段落をエクスポートします。

この Javascript コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています：

```javascript
// プレゼンテーションファイルを読み込む
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // 目的のインデックス
    var index = 0;
    // 追加されたシェイプにアクセス
    var ashape = slide.getShapes().get_Item(index);
    // 出力 HTML ファイルを作成
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // 最初の段落を HTML として抽出
    // 段落の開始インデックスとコピーする段落総数を指定して、段落データを HTML に書き込む
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

このセクションでは、[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。両方の例は、[Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/) クラスの `getImage` メソッドで段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオで活用できます。

サンプルとして、sample.pptx という 1 枚のスライドを持つプレゼンテーションがあり、最初のシェイプは 3 つの段落を含むテキスト ボックスです。

![The text box with three paragraphs](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まずプレゼンテーションの最初のスライドからシェイプの画像を抽出し、次にシェイプのテキストフレーム内で 2 番目の段落の境界を計算します。段落は新しいビットマップ画像に再描画され、PNG 形式で保存されます。この方法は、特定の段落を別画像として保存し、テキストの正確なサイズと書式を保持したい場合に特に有用です。

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

    // 2 番目の段落の境界を計算します。
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // シェイプのビットマップを切り抜いて段落のビットマップだけを取得します。
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

![The paragraph image](paragraph_to_image_output.png)

**例 2**

この例では、前述のアプローチに拡張を加え、段落画像にスケーリング係数を適用します。シェイプを抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。高解像度画像が必要な場合（例: 高品質な印刷物）に特に役立ちます。

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // シェイプをスケーリング付きでメモリ内にビットマップとして保存します。
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

    // 2 番目の段落の境界を計算します。
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

    // シェイプのビットマップを切り抜いて段落のビットマップだけを取得します。
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

はい。テキストフレームのラップ設定（[setWrapText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/setwraptext/)）を使用してラップをオフにすれば、フレームの端で行が折り返されません。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（あるいは単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/中央揃え/均等揃え）はどこで制御しますか？**

[setAlignment](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/setalignment/) は [ParagraphFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/) の段落レベル設定メソッドで、個々のポーションの書式設定に関わらず、段落全体に適用されます。

**段落の一部（例: 特定の単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベルで設定される（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)）ため、同一段落内で複数言語を共存させることが可能です。