---
title: JavaでPowerPointテキスト段落を管理する
linktitle: 段落を管理する
type: docs
weight: 40
url: /ja/java/manage-paragraph/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号リスト
- 箇条書きリスト
- 段落プロパティ
- HTMLをインポート
- テキストをHTMLに変換
- 段落をHTMLに変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Javaで段落の書式設定をマスターし、PPT、PPTX、ODP形式のプレゼンテーションにおける配置、間隔、スタイルを最適化します。"
---
Aspose.Slides は、Java で PowerPoint のテキスト、段落、そしてパーツを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにするための [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは 1 つまたは複数の段落を保持できます（各段落は改行で作成されます）。
* Aspose.Slides は、パーツを表すオブジェクトを追加できるようにするための [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは 1 つまたは複数のパーツ（iPortions オブジェクトのコレクション）を保持できます。
* Aspose.Slides は、テキストとその書式プロパティを表すオブジェクトを追加できるようにするための [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基礎になる `IPortion` オブジェクトを通じて、さまざまな書式プロパティを持つテキストを処理できます。

## **複数のパーツを含む複数の段落を追加する**

以下の手順は、3 段落を含むテキストフレームを追加し、各段落が 3 つのパーツを含む方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. その [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) オブジェクト（デフォルト段落の場合は 2 つの Portion オブジェクト）を作成し、各 `IPortion` オブジェクトを対応する `IParagraph` の IPortion コレクションに追加します。
7. 各パーツにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式プロパティを使用して、各パーツに好みの書式設定を適用します。
9. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape の TextFrame にアクセス
    ITextFrame tf = ashp.getTextFrame();

    // 異なるテキスト書式の段落とパーツを作成
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

    //PPTX をディスクに書き込む
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落の箇条書きを管理する**

箇条書きリストは、情報をすばやく効率的に整理・提示するのに役立ちます。箇条書きの段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の bullet `Type` を `Symbol` に設定し、箇条文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きの段落インデント `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 13 を繰り返します。
14. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshape を追加し、アクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape のテキストフレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();

    // デフォルトの段落を削除
    txtFrm.getParagraphs().removeAt(0);

    // 段落を作成
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 段落のテキストを設定
    para.setText("Welcome to Aspose.Slides");

    // 箇条書きインデントを設定
    para.getParagraphFormat().setIndent(25);

    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用

    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para);

    // 2 番目の段落を作成
    Paragraph para2 = new Paragraph();

    // 段落の箇条書きタイプとスタイルを設定
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 段落のテキストを追加
    para2.setText("This is numbered bullet");

    // 箇条書きインデントを設定
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用

    // 箇条書きの高さを設定
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para2);
    
    // 変更されたプレゼンテーションを保存
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像箇条書きを管理する**

箇条書きリストは、情報をすばやく効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) で画像を読み込みます。
8. bullet のタイプを [Picture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きの段落インデント `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順を繰り返します。
15. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = presentation.getSlides().get_Item(0);

    // 箇条書き用の画像をインスタンス化
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Autoshape を追加し、アクセス
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape のテキストフレームにアクセス
    ITextFrame textFrame = autoShape.getTextFrame();

    // デフォルトの段落を削除
    textFrame.getParagraphs().removeAt(0);

    // 新しい段落を作成
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 段落の箇条書きスタイルと画像を設定
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 箇条書きの高さを設定
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加
    textFrame.getParagraphs().add(paragraph);

    // プレゼンテーションを PPTX ファイルとして保存
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // プレゼンテーションを PPT ファイルとして保存
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **多層箇条書きを管理する**

箇条書きリストは、情報をすばやく効率的に整理・提示するのに役立ちます。多層箇条書きは読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshape を追加し、アクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した Autoshape のテキストフレームにアクセス
    ITextFrame text = aShp.addTextFrame("");

    // デフォルトの段落をクリア
    text.getParagraphs().clear();

    // Adds the first paragraph
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定
    para1.getParagraphFormat().setDepth((short)0);

    // 2 番目の段落を追加
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定
    para2.getParagraphFormat().setDepth((short)1);

    // 3 番目の段落を追加
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定
    para3.getParagraphFormat().setDepth((short)2);

    // 4 番目の段落を追加
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きのレベルを設定
    para4.getParagraphFormat().setDepth((short)3);

    // 段落をコレクションに追加
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタム番号付きリストの段落を管理する**

[IBulletFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更されたプレゼンテーションを保存します。

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した autoshape のテキストフレームにアクセス
    ITextFrame textFrame = shape.getTextFrame();

    // デフォルトの既存段落を削除
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

## **段落のファーストラインインデントを設定する**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドを使用して段落の最初の行のインデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に合わせて配置されたままです。

全体の段落を移動させたい場合は [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) を使用し、最初の行だけを移動させたい場合は [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用します。

以下の例は複数の段落を作成し、異なるインデント値を適用してファーストラインインデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 複数の段落を作成し、[Indent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) の値をそれぞれ異なるものに設定します。
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

![段落のファーストラインインデント](first_line_indent.png)

## **段落のハンギングインデントを設定する**

ハンギングインデントは、最初の行が残りの行より左側に開始する段落レイアウトです。Aspose.Slides では、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドでこの効果を作成します。インデントを負の値に設定すると、段落本文に対して最初の行が左に移動します。

実際には、[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) が段落本文の左位置を定義し、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、書誌情報、参考文献、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある段落で役立ちます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 値を設定します。
6. ハンギングインデント効果を作成するために負の [Indent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
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

## **段落の終了実行プロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. 位置で段落を含むスライドの参照を取得します。  
3. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。  
4. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を追加します。  
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

Aspose.Slides は、HTML テキストを段落にインポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用して対象スライドの参照にアクセスします。  
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。  
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を追加してアクセスします。  
5. `ITextFrame` のデフォルト段落を削除します。  
6. TextReader でソース HTML ファイルを読み取ります。  
7. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。  
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/) に追加します。  
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

    // 追加したテキストフレームのすべての段落をクリア
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダーで HTML ファイルを読み込む
    TextReader tr = new StreamReader("file.html");

    // テキストフレームに HTML ストリームリーダーからテキストを追加
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // プレゼンテーションを保存
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションを読み込みます。  
2. インデックスを使用して対象スライドの参照にアクセスします。  
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。  
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) にアクセスします。  
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを書き込みます。  
6. 開始インデックスを StreamWriter に指定し、必要な段落をエクスポートします。

```java
// プレゼンテーションファイルを読み込む
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 目的のインデックス
    int index = 0;

    // 追加したシェイプにアクセス
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 出力 HTML ファイルを作成
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //最初の段落を HTML として抽出
    // 段落の開始インデックスとコピーする段落数を指定して、段落データを書き出す
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落を画像として保存する**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。どちらの例も、段落を含むシェイプの画像を取得し、段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint のプレゼンテーションからテキストの特定部分を切り出して別々の画像として保存でき、さまざまなシナリオで活用できます。

サンプルとして、sample.pptx というファイルに 1 枚のスライドがあり、最初のシェイプが 3 段落を含むテキストボックスであると仮定します。

![3つの段落を含むテキスト ボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まずプレゼンテーションの最初のスライドからシェイプの画像を抽出し、次にシェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、特定の段落を正確なサイズと書式を保ったまま別画像として保存したい場合に特に有用です。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 形状をメモリ内にビットマップとして保存します。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリから形状ビットマップを作成します。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2 番目の段落の境界を計算します。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算します（最小サイズ - 1x1 ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 形状ビットマップを切り取って段落ビットマップのみ取得します。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前述のアプローチにスケーリング係数を追加します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。スケーリングは、たとえば高品質の印刷物で詳細な画像が必要な場合に有用です。

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリングを伴って形状をメモリ内にビットマップとして保存します。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリから形状ビットマップを作成します。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2 番目の段落の境界を計算します。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 出力画像の座標とサイズを計算します（最小サイズ - 1x1 ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 形状ビットマップを切り取って段落ビットマップのみ取得します。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **よくある質問**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[setWrapText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframeformat/#setWrapText-byte-)）を使用して折り返しをオフにすると、フレームの端で行が分割されません。

**特定の段落のスライド上の正確な境界はどう取得できますか？**

段落（場合によっては単一のパーツ）のバウンディング矩形を取得することで、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/両端揃え）はどこで設定しますか？**

[Alignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphformat/#setAlignment-int-) は [ParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphformat/) の段落レベル設定であり、個々のパーツの書式設定に関係なく段落全体に適用されます。

**段落の一部（例: 1語）だけにスペルチェックの言語を設定できますか？**

はい。言語はパーツレベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)）で設定されるため、単一の段落内で複数の言語を同居させることが可能です。