---
title: Android で PowerPoint のテキスト段落を管理する
linktitle: 段落を管理
type: docs
weight: 40
url: /ja/androidjava/manage-paragraph/
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
- テキストを HTML に変換
- 段落を HTML に変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して段落の書式設定をマスターし、Java で PPT、PPTX、ODP プレゼンテーションの配置、間隔、スタイルを最適化します。"
---
Aspose.Slides は、Java で PowerPoint のテキスト、段落、およびパーツを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは 1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、パーツを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは 1 つまたは複数のパーツ（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基礎となる `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のテキストパーツを含む複数の段落を追加する**

以下の手順では、3 つの段落を含むテキストフレームを追加し、各段落に 3 つのパーツを含める方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 新しい各 `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/) オブジェクトを作成（デフォルトの段落には 2 つの Portion オブジェクト）し、各 `IPortion` オブジェクトをそれぞれの `IParagraph` の IPortion コレクションに追加します。
7. 各パーツにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式プロパティを使用して、各パーツに好みの書式設定を適用します。
9. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape の TextFrame にアクセスする
    ITextFrame tf = ashp.getTextFrame();

    // 異なるテキスト書式を持つ段落とパーツを作成する
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // PPTX をディスクに書き込む
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きの段落は常に読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を設定します。
8. 段落の `Text` を設定します。
9. 箇条書きの段落 `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、ステップ 7 から 13 の手順を繰り返します。
14. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape を追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();

    // デフォルトの段落を削除する
    txtFrm.getParagraphs().removeAt(0);

    // 段落を作成する
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルとシンボルを設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 段落のテキストを設定する
    para.setText("Welcome to Aspose.Slides");

    // 箇条書きインデントを設定する
    para.getParagraphFormat().setIndent(25);

    // 箇条書きの色を設定する
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用する

    // 箇条書きの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para);

    // 2 番目の段落を作成する
    Paragraph para2 = new Paragraph();

    // 段落の箇条書きタイプとスタイルを設定する
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 段落のテキストを追加する
    para2.setText("This is numbered bullet");

    // 箇条書きインデントを設定する
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用する

    // 箇条書きの高さを設定する
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para2);
    
    // 変更されたプレゼンテーションを保存する
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像の段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) で画像をロードします。
8. 箇条書きのタイプを [Picture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) に設定し、画像を設定します。
9. 段落の `Text` を設定します。
10. 箇条書きの段落 `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前の手順に基づいて同じ操作を繰り返します。
15. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
Presentation presentation = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = presentation.getSlides().get_Item(0);

    // 箇条書き用の画像をインスタンス化する
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // AutoShape を追加してアクセスする
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセスする
    ITextFrame textFrame = autoShape.getTextFrame();

    // デフォルトの段落を削除する
    textFrame.getParagraphs().removeAt(0);

    // 新しい段落を作成する
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 段落の箇条書きスタイルと画像を設定する
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 箇条書きの高さを設定する
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    textFrame.getParagraphs().add(paragraph);

    // プレゼンテーションを PPTX ファイルとして保存する
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // プレゼンテーションを PPT ファイルとして保存する
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **多階層箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多階層箇条書きは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape を追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame text = aShp.addTextFrame("");

    // デフォルトの段落を削除する
    text.getParagraphs().clear();

    // 最初の段落を追加する
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定する
    para1.getParagraphFormat().setDepth((short)0);

    // 2 番目の段落を追加する
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定する
    para2.getParagraphFormat().setDepth((short)1);

    // 3 番目の段落を追加する
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定する
    para3.getParagraphFormat().setDepth((short)2);

    // 4 番目の段落を追加する
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定する
    para4.getParagraphFormat().setDepth((short)3);

    // 段落をコレクションに追加する
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタム番号リストを持つ段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できるようにします。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith] を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更されたプレゼンテーションを保存します。

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame textFrame = shape.getTextFrame();

    // デフォルトの既存段落を削除する
    textFrame.getParagraphs().removeAt(0);

    // 最初のリスト
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **段落の先頭行インデントの設定**

段落の先頭行インデントを制御するには、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドを使用します。このメソッドは、段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右へシフトし、残りの行は段落本体に揃ったままです。

段落全体を移動させたい場合は [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) を使用し、最初の行だけを移動させたい場合は [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用します。

以下の例では、複数の段落を作成し、異なるインデント値を適用して、先頭行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 複数の段落を作成し、それぞれに異なる [Indent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更されたプレゼンテーションを保存します。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![段落の先頭行インデント](first_line_indent.png)

## **段落のハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行より左側から始まる段落レイアウトです。Aspose.Slides では、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドを使用してこの効果を作成します。インデントに負の値を設定すると、段落本体に対して最初の行が左へ移動します。

実際には、[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) が段落本体の左位置を定義し、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、文献リスト、参照、用語集の項目など、折り返し行が段落本体の下に揃う必要がある段落に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 段落を作成し、各段落に正の [MarginLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 値を設定します。
6. ハンギングインデント効果を作成するために負の [Indent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更されたプレゼンテーションを保存します。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

![段落のハンギングインデント](hanging_indent.png)

## **段落末端実行プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 位置を基に段落が含まれるスライドの参照を取得します。
3. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を追加します。
5. 段落の `FontHeight` とフォントタイプを設定します。
6. 段落の End プロパティを設定します。
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **HTML テキストを段落にインポートする**

Aspose.Slides は、HTML テキストを段落にインポートするための拡張サポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を追加し、アクセスします。
5. `ITextFrame` のデフォルトの段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML ファイル内容を TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphcollection/) に追加します。
9. 変更されたプレゼンテーションを保存します。

```java
// 空のプレゼンテーションインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML コンテンツを収容するために AutoShape を追加
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // シェイプにテキストフレームを追加
    ashape.addTextFrame("");

    // 追加したテキストフレーム内のすべての段落をクリア
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダーを使用して HTML ファイルをロード
    TextReader tr = new StreamReader("file.html");

    // HTML ストリームリーダーからテキストをテキストフレームに追加
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // プレゼンテーションを保存
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための拡張サポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを指定し、希望する段落をエクスポートします。

```java
// プレゼンテーションファイルをロードする
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // 目的のインデックス
    int index = 0;

    // 追加されたシェイプにアクセスする
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 出力 HTML ファイルを作成する
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //最初の段落を HTML として抽出する
    // 段落の開始インデックスとコピーする総段落数を指定して、段落データを書き出して HTML に出力する
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落を画像として保存する**

このセクションでは、[IParagraph] インターフェイスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。両例とも、[IShape] インターフェイスの `getImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。この方法により、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオで活用できます。

ここでは、sample.pptx というプレゼンテーション ファイルが 1 枚のスライドを持ち、最初のシェイプが 3 つの段落を含むテキスト ボックスであると想定します。

![3 つの段落を含むテキストボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まず、プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、特定の段落を正確なサイズと書式設定を保持したまま別画像として保存するのに特に有用です。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // メモリ上にシェイプをビットマップとして保存します。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリからシェイプのビットマップを作成します。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2 番目の段落の境界を計算します。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // シェイプのビットマップを切り取り、段落のビットマップだけを取得します。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![段落の画像](paragraph_to_image_output.png)

**例 2**

この例では、前のアプローチにスケーリング係数を追加します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。その後、スケールを考慮して段落の境界を計算します。スケーリングは、たとえば高品質の印刷物で使用する詳細な画像が必要な場合に特に役立ちます。

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きでシェイプをメモリ上にビットマップとして保存します。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリからシェイプのビットマップを作成します。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2 番目の段落の境界を計算します。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // 出力画像の座標とサイズを計算します（最小サイズは 1x1 ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // シェイプのビットマップを切り取り、段落のビットマップだけを取得します。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**テキストフレーム内で行折り返しを完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[setWrapText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)）を使用して折り返しをオフにすると、フレームの端で行が改行されなくなります。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

段落（場合によっては単一のパーツ）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで制御されますか？**

[Alignment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) は、[ParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphformat/) の段落レベル設定であり、個々のパーツの書式設定に関係なく段落全体に適用されます。

**段落の一部（例: 単語）だけにスペルチェック言語を設定できますか？**

はい。言語はパーツレベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)）で設定されるため、1 つの段落内で複数の言語を共存させることができます。