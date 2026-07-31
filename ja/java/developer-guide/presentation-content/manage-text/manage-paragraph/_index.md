---
title: Java で PowerPoint テキスト段落を管理する
linktitle: 段落を管理する
type: docs
weight: 40
url: /ja/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- バレットを管理
- 段落インデント
- ハンギングインデント
- 段落バレット
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で段落の書式設定をマスターし、Java の PPT、PPTX、ODP プレゼンテーションにおいて配置、間隔、スタイルを最適化します。"
---
## **イントロダクション**

Aspose.Slides は、Java で PowerPoint のテキスト、段落、そしてポーションを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにするために [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行によって作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにするために [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは、1 つまたは複数のポーション（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにするために [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基になる `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のポーションを含む段落を追加する**

以下の手順は、3 つの段落を持ち、各段落が 3 つのポーションを含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. その [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 各新規 `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/) オブジェクト（デフォルト段落用に 2 つの Portion オブジェクト）を作成し、各 `IParagraph` の IPortion コレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各ポーションに好みの書式を適用します。
9. 変更されたプレゼンテーションを保存します。

この Java コードは、ポーションを含む段落を追加する手順の実装例です：

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

    // 異なるテキスト形式の段落とポーションを作成する
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

## **段落のバレットを管理する**

バレットリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。バレット付き段落は常に読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` 内のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落のバレット `Type` を `Symbol` に設定し、バレット文字を指定します。
8. 段落の `Text` を設定します。
9. バレットのインデントを段落 `Indent` に設定します。
10. バレットの色を設定します。
11. バレットの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 13 を繰り返します。
14. プレゼンテーションを保存します。

この Java コードは、段落バレットを追加する方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape を追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();

    // デフォルトの段落を削除する
    txtFrm.getParagraphs().removeAt(0);

    // 段落を作成する
    Paragraph para = new Paragraph();

    // 段落のバレットスタイルとシンボルを設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 段落テキストを設定する
    para.setText("Welcome to Aspose.Slides");

    // バレットのインデントを設定する
    para.getParagraphFormat().setIndent(25);

    // バレットの色を設定する
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 独自のバレット色を使用するために IsBulletHardColor を true に設定する

    // バレットの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para);

    // 2 番目の段落を作成する
    Paragraph para2 = new Paragraph();

    // 段落のバレットタイプとスタイルを設定する
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 段落テキストを追加する
    para2.setText("This is numbered bullet");

    // バレットのインデントを設定する
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 独自のバレット色を使用するために IsBulletHardColor を true に設定する

    // バレットの高さを設定する
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para2);
    
    // 変更されたプレゼンテーションを保存する
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **画像バレットを管理する**

バレットリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` 内のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) で画像を読み込みます。
8. バレットタイプを [Picture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. バレット用に段落 `Indent` を設定します。
11. バレットの色を設定します。
12. バレットの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順に従って繰り返します。
15. 変更されたプレゼンテーションを保存します。

この Java コードは、画像バレットの追加と管理方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation presentation = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = presentation.getSlides().get_Item(0);

    // バレット用の画像を作成する
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // AutoShape を追加し、アクセスする
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセスする
    ITextFrame textFrame = autoShape.getTextFrame();

    // デフォルトの段落を削除する
    textFrame.getParagraphs().removeAt(0);

    // 新しい段落を作成する
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 段落のバレットスタイルと画像を設定する
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // バレットの高さを設定する
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    textFrame.getParagraphs().add(paragraph);

    // プレゼンテーションを PPTX ファイルとして書き込む
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // プレゼンテーションを PPT ファイルとして書き込む
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **多階層バレットを管理する**

バレットリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。多階層バレットは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` 内のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

この Java コードは、多階層バレットの追加と管理方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape を追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame text = aShp.addTextFrame("");

    // デフォルトの段落をクリアする
    text.getParagraphs().clear();

    // 最初の段落を追加する
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para1.getParagraphFormat().setDepth((short)0);

    // 2 番目の段落を追加する
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para2.getParagraphFormat().setDepth((short)1);

    // 3 番目の段落を追加する
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para3.getParagraphFormat().setDepth((short)2);

    // 4 番目の段落を追加する
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para4.getParagraphFormat().setDepth((short)3);

    // 段落をコレクションに追加する
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // プレゼンテーションを PPTX ファイルとして書き込む
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタム番号付きリストを持つ段落を管理する**

[IBulletFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` 内のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更されたプレゼンテーションを保存します。

この Java コードは、カスタム番号付けや書式設定を持つ段落の追加と管理方法を示しています：

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

## **段落のファーストラインインデントを設定する**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドを使用して、段落のファーストラインインデントを制御します。このメソッドは、段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本体に揃ったままです。

段落全体を移動させたい場合は [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) を使用し、最初の行だけを移動させたい場合は [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用します。

以下の例は、複数の段落を作成し、異なるインデント値を適用してファーストラインインデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 複数の段落を作成し、それぞれに異なる [Indent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更されたプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示します：

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

結果：

![段落のファーストラインインデント](first_line_indent.png)

## **段落のハンギングインデントを設定する**

ハンギングインデントは、最初の行が残りの行より左側に開始する段落レイアウトです。Aspose.Slides では、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドでこの効果を実現します。インデントを負の値に設定すると、段落本体に対して最初の行が左に移動します。

実際には、[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) が段落本体の左位置を定義し、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、文献一覧、参照、用語集エントリなど、折り返し行を段落本体の下に揃える必要がある段落に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 値を設定します。
6. ハンギングインデント効果を作るために負の [Indent](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更されたプレゼンテーションを保存します。

このコードは段落にハンギングインデントを設定する方法を示します：

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

結果：

![段落のハンギングインデント](hanging_indent.png)

## **段落末端の実行プロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置で段落を含むスライドの参照を取得します。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
1. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を追加します。
1. 段落の `FontHeight` とフォント種別を設定します。
1. 段落の End プロパティを設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、PowerPoint の段落に End プロパティを設定する方法を示します：

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
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を追加および取得します。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphcollection/) に追加します。
9. 変更されたプレゼンテーションを保存します。

この Java コードは、段落に HTML テキストをインポートする手順の実装例です：

```java
// 空のプレゼンテーションインスタンスを作成する
Presentation pres = new Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML コンテンツを収めるために AutoShape を追加する
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // シェイプにテキストフレームを追加する
    ashape.addTextFrame("");

    // 追加したテキストフレーム内のすべての段落をクリアする
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダーを使用して HTML ファイルを読み込む
    TextReader tr = new StreamReader("file.html");

    // HTML ストリームリーダーからテキストをテキストフレームに追加する
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // プレゼンテーションを保存する
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための高度なサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. インデックスを使用して対象スライドへの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを提供し、希望する段落をエクスポートします。

この Java コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示します：

```java
// プレゼンテーションファイルを読み込む
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
    // 段落の開始インデックスとコピーする総段落数を指定して段落データを HTML に書き込む
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落を画像として保存する**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。両例とも、段落を含むシェイプの画像を取得し、段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションから特定のテキスト部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの再利用が可能になります。

サンプルとして、sample.pptx というプレゼンテーションファイルに 1 枚のスライドがあり、最初のシェイプが 3 段落を含むテキストボックスであるとします。

![3 段落を含むテキストボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。次に、その段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、特定の段落を別画像として保存し、テキストの正確な寸法と書式を保持したい場合に便利です。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 形状をメモリ上でビットマップとして保存する。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリからシェイプのビットマップを作成する。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2 番目の段落の境界を計算する。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算する（最小サイズ - 1x1 ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // シェイプビットマップをトリミングして段落ビットマップのみ取得する。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

結果：

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前のアプローチにスケーリング係数を追加します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。高解像度画像が必要な場合、たとえば高品質の印刷物での使用などに有用です。

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きで形状をメモリ上のビットマップとして保存する。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリからシェイプのビットマップを作成する。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2 番目の段落の境界を計算する。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 出力画像の座標とサイズを計算する（最小サイズ - 1x1 ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // シェイプビットマップをトリミングして段落ビットマップのみ取得する。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームのラップ設定（[setWrapText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/textframeformat/#setWrapText-byte-)）をオフにすれば、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するには？**

段落（または単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/センター/両端揃え）はどこで制御しますか？**

[Alignment](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphformat/#setAlignment-int-) は [ParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/paragraphformat/) の段落レベル設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例：単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)）で設定されるため、同一段落内で複数言語を共存させることが可能です。