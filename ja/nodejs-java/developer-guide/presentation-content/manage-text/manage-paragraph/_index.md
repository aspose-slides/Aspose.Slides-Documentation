---
title: JavaScript で PowerPoint の段落を管理する
type: docs
weight: 40
url: /ja/nodejs-java/manage-paragraph/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 段落インデント
- 段落箇条書き
- 番号付きリスト
- 段落プロパティ
- HTML をインポート
- テキストを HTML に変換
- 段落を HTML に変換
- 段落を画像に変換
- 段落をエクスポート
- PowerPoint プレゼンテーション
- JavaScript
- Java 経由の Node.js 用 Aspose.Slides
description: "JavaScript で PowerPoint プレゼンテーションの段落を作成し、段落プロパティを管理します"
---

Aspose.Slides は、Java で PowerPoint のテキスト、段落、および部分を操作するために必要なすべてのクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) クラスを提供します。`ITextFame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、部分を表すオブジェクトを追加できるようにする [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを提供します。`IParagraph` オブジェクトは、1 つまたは複数の部分（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) クラスを提供します。

`IParagraph` オブジェクトは、基礎となる `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数の部分を含む複数の段落を追加**

この手順では、3 つの段落を含み、各段落が 3 つの部分を含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドをインデックスで取得します。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) オブジェクトを作成し、[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) オブジェクトを作成します（デフォルトの段落には 2 つの Portion オブジェクト）。各 `IPortion` オブジェクトを各 `IParagraph` の IPortion コレクションに追加します。
7. 各部分にテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各部分に好みの書式機能を適用します。
9. 変更したプレゼンテーションを保存します。

この Javascript コードは、部分を含む段落を追加する手順の実装例です。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // 矩形タイプの AutoShape を追加する
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // AutoShape の TextFrame にアクセスする
    var tf = ashp.getTextFrame();
    // 異なるテキスト形式を持つ段落と部分を作成する
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


## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は、常に読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドをインデックスで取得します。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を設定します。
8. 段落の `Text` を設定します。
9. 箇条書きの段落 `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7〜12 と同様に実行します。
14. プレゼンテーションを保存します。

この Javascript コードは、段落の箇条書きを追加する方法を示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var slide = pres.getSlides().get_Item(0);
    // AutoShape を追加し、アクセスします
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape のテキスト フレームにアクセスします
    var txtFrm = aShp.getTextFrame();
    // デフォルトの段落を削除します
    txtFrm.getParagraphs().removeAt(0);
    // 段落を作成します
    var para = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルと記号を設定します
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 段落のテキストを設定します
    para.setText("Welcome to Aspose.Slides");
    // 箇条書きのインデントを設定します
    para.getParagraphFormat().setIndent(25);
    // 箇条書きの色を設定します
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定します
    // 箇条書きの高さを設定します
    para.getParagraphFormat().getBullet().setHeight(100);
    // テキストフレームに段落を追加します
    txtFrm.getParagraphs().add(para);
    // 2 番目の段落を作成します
    var para2 = new aspose.slides.Paragraph();
    // 段落の箇条書きタイプとスタイルを設定します
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // 段落のテキストを追加します
    para2.setText("This is numbered bullet");
    // 箇条書きのインデントを設定します
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// 独自の箇条書き色を使用するために IsBulletHardColor を true に設定します
    // 箇条書きの高さを設定します
    para2.getParagraphFormat().getBullet().setHeight(100);
    // テキストフレームに段落を追加します
    txtFrm.getParagraphs().add(para2);
    // 変更されたプレゼンテーションを保存します
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドをインデックスで取得します。
3. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) で画像をロードします。
8. 箇条書きのタイプを [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きの段落 `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順と同様に実行します。
15. 変更したプレゼンテーションを保存します。

この Javascript コードは、画像箇条書きを追加および管理する方法を示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var presentation = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var slide = presentation.getSlides().get_Item(0);
    // 箇条書き用の画像をインスタンス化します
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // AutoShape を追加し、アクセスします
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // AutoShape のテキストフレームにアクセスします
    var textFrame = autoShape.getTextFrame();
    // デフォルトの段落を削除します
    textFrame.getParagraphs().removeAt(0);
    // 新しい段落を作成します
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // 段落の箇条書きスタイルと画像を設定します
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 箇条書きの高さを設定します
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // 段落をテキストフレームに追加します
    textFrame.getParagraphs().add(paragraph);
    // プレゼンテーションを PPTX ファイルとして保存します
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // プレゼンテーションを PPT ファイルとして保存します
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **多層箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多層箇条書きは読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象のスライドをインデックスで取得します。
3. 新しいスライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して2番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して3番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して4番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この Javascript コードは、多層箇条書きを追加および管理する方法を示します。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスします
    var slide = pres.getSlides().get_Item(0);
    // AutoShape を追加し、アクセスします
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセスします
    var text = aShp.addTextFrame("");
    // デフォルトの段落をクリアします
    text.getParagraphs().clear();
    // 最初の段落を追加します
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定します
    para1.getParagraphFormat().setDepth(0);
    // 2 番目の段落を追加します
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定します
    para2.getParagraphFormat().setDepth(1);
    // 3 番目の段落を追加します
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定します
    para3.getParagraphFormat().setDepth(2);
    // 4 番目の段落を追加します
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定します
    para4.getParagraphFormat().setDepth(3);
    // 段落をコレクションに追加します
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // プレゼンテーションを PPTX ファイルとして保存します
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタム番号付きリスト付き段落の管理**

[BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) クラスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 該当段落が含まれるスライドにアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. AutoShape の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith] を 2 に設定します。
7. `Paragraph` クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この Javascript コードは、カスタム番号付けや書式設定を持つ段落を追加および管理する方法を示します。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成した AutoShape のテキストフレームにアクセスします
    var textFrame = shape.getTextFrame();
    // 既存のデフォルト段落を削除します
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
2. インデックスで対象スライドの参照にアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. 矩形の AutoShape に、3 段落を持つ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を追加します。
5. 矩形の枠線を非表示にします。
6. 各 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) の BulletOffset プロパティを使用してインデントを設定します。
7. 変更したプレゼンテーションを PPT ファイルとして保存します。

この Javascript コードは、段落インデントを設定する方法を示します。
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
    // テキストをシェイプに合わせてサイズ調整する
    tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // 矩形の線を非表示にする
    rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    // TextFrame の最初の段落を取得し、インデントを設定する
    var para1 = tf.getParagraphs().get_Item(0);
    // 段落の箇条書きスタイルと記号を設定する
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para1.getParagraphFormat().setDepth(2);
    para1.getParagraphFormat().setIndent(30);
    // TextFrame の2番目の段落を取得し、インデントを設定する
    var para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar(8226);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para2.getParagraphFormat().setDepth(2);
    para2.getParagraphFormat().setIndent(40);
    // TextFrame の3番目の段落を取得し、インデントを設定する
    var para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
    para3.getParagraphFormat().setDepth(2);
    para3.getParagraphFormat().setIndent(50);
    // プレゼンテーションを書き出す
    pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **段落のハンギングインデントの設定**

この Javascript コードは、段落のハンギングインデントを設定する方法を示します。
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


## **段落の終了ランプロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 位置で段落を含むスライドの参照を取得します。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. 矩形に、2 段落を持つ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を追加します。
5. 段落の `FontHeight` とフォント種類を設定します。
6. 段落の End プロパティを設定します。
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この Javascript コードは、PowerPoint の段落に対して End プロパティを設定する方法を示します。
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


## **HTML テキストを段落にインポート**

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象スライドの参照にアクセスします。
3. スライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) を追加します。
4. `autoshape` の [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を追加し、アクセスします。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML ファイル内容を TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この Javascript コードは、段落に HTML テキストをインポートする手順の実装例です。
```javascript
// 空のプレゼンテーション インスタンスを作成する
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


## **段落テキストを HTML にエクスポート**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスで対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを指定し、希望する段落をエクスポートします。

この Javascript コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示します。
```javascript
// プレゼンテーション ファイルをロードする
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
    // 段落の開始インデックスとコピーする総段落数を指定して、段落データを書き込んで HTML に出力する
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

このセクションでは、[Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) インターフェイスで表されるテキスト段落を画像として保存する方法を示す 2 つの例を探ります。両方の例では、[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) インターフェイスの `getImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これらのアプローチにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別個の画像として保存でき、さまざまなシナリオでの活用が可能です。

sample.pptx という名前のプレゼンテーション ファイルが 1 枚のスライドを持ち、最初のシェイプが 3 段落を含むテキスト ボックスであると想定します。

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内で 2 番目の段落の境界を計算します。次に、その段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式を保持しながら、特定の段落を個別の画像として保存したい場合に特に有用です。
```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // シェイプをメモリ上にビットマップとして保存します。
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

    // シェイプのビットマップをクロップして段落のビットマップだけを取得します。
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

**Example 2**

この例では、前述のアプローチにスケーリング係数を追加します。シェイプを抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落のエクスポート時により高解像度の出力が得られます。その後、スケールを考慮して段落の境界を計算します。スケーリングは、例えば高品質な印刷物での使用など、より詳細な画像が必要な場合に特に有用です。
```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きでシェイプをメモリ上にビットマップとして保存します。
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

    // シェイプのビットマップを切り取って段落のビットマップだけを取得します。
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

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)）を使用して折り返しをオフにすれば、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（さらには単一の部分） のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで設定しますか？**

[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) は、[ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) における段落レベルの設定メソッドで、個々の部分の書式設定に関係なく、段落全体に適用されます。

**段落の一部（例: 単語）だけにスペルチェック言語を設定できますか？**

はい。言語は部分レベルで設定されるため（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)）、1 つの段落内に複数の言語を共存させることができます。