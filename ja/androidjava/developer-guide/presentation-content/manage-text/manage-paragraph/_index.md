---
title: Android で PowerPoint テキスト段落を管理
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
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
- HTML をインポート
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
description: "Android 用 Aspose.Slides で段落書式設定をマスター—PPT、PPTX、ODP プレゼンテーションの配置、間隔、スタイルを Java で最適化。"
---
## **はじめに**

Aspose.Slides は、Java で PowerPoint のテキスト、段落、ポーションを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは 1 つまたは複数の段落を保持できます（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは 1 つまたは複数のポーション（iPortions オブジェクトのコレクション）を保持できます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基になる `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のテキストポーションを含む複数段落の追加**

以下の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを追加する方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. その [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/) オブジェクト（デフォルトの段落には 2 つの Portion）を作成し、各 `IParagraph` の IPortion コレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各ポーションに好みの書式を適用します。
9. 変更したプレゼンテーションを保存します。

この Java コードは、ポーションを含む段落を追加する手順の実装例です：

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

    // 異なるテキスト書式を持つ段落とポーションを作成
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

    // PPTX をディスクに保存
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落の箇条書き管理**

箇条書きリストは、情報を素早く効率的に整理・提示するのに役立ちます。箇条書き段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きのインデントを段落 `Indent` に設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7〜13 を繰り返します。
14. プレゼンテーションを保存します。

この Java コードは、段落の箇条書きを追加する方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape を追加し、アクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセス
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
    
    // 変更したプレゼンテーションを保存
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **画像箇条書きの管理**

箇条書きリストは、情報を素早く効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) で画像を読み込みます。
8. 箇条書きタイプを [Picture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントを段落 `Indent` に設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順を繰り返します。
15. 変更したプレゼンテーションを保存します。

この Java コードは、画像箇条書きを追加および管理する方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = presentation.getSlides().get_Item(0);

    // 箇条書き用画像をインスタンス化
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // AutoShape を追加し、アクセス
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセス
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


## **多階層箇条書きの管理**

箇条書きリストは、情報を素早く効率的に整理・提示するのに役立ちます。多階層箇条書きは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスで 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスで 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスで 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この Java コードは、多階層箇条書きを追加および管理する方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape を追加し、アクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセス
    ITextFrame text = aShp.addTextFrame("");

    // デフォルトの段落をクリア
    text.getParagraphs().clear();

    // 最初の段落を追加
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth((short)0);

    // 2 番目の段落を追加
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth((short)1);

    // 3 番目の段落を追加
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth((short)2);

    // 4 番目の段落を追加
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
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


## **カスタム番号付きリストを持つ段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を行う段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象段落があるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を 2 に設定します。
7. `Paragraph` クラスで 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスで 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この Java コードは、カスタム番号付けまたは書式設定を持つ段落を追加および管理する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセス
    ITextFrame textFrame = shape.getTextFrame();

    // 既存のデフォルト段落を削除
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

## **段落のファーストラインインデントの設定**

[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドを使用して、段落の最初の行のインデントを制御します。このメソッドは、段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動したい場合は [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) を使用し、最初の行だけを移動したい場合は [IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) を使用します。

以下の例は、複数の段落を作成し、異なるインデント値を適用して、ファーストラインインデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 複数の段落を作成し、それぞれに異なる [Indent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは、段落インデントを設定する方法を示しています：

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

## **段落のハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) メソッドでこの効果を実現します。インデントに負の値を設定すると、段落本文に対して最初の行が左にシフトします。

実際には、[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) が段落本文の左位置を決め、[IParagraphFormat.setIndent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) がその余白に対する最初の行の位置を決めます。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式は、文献リスト、参考文献、用語集エントリなど、折り返し行を段落本文の下に揃える必要がある段落で便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 値を設定します。
6. ハンギングインデント効果を作るために負の [Indent](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは、段落にハンギングインデントを設定する方法を示しています：

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

## **段落の End ラン プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置でスライドの参照を取得します。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
1. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を追加します。
1. 段落の `FontHeight` とフォント種別を設定します。
1. 段落の End プロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、PowerPoint の段落に End プロパティを設定する方法を示しています：

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

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) にアクセスして取得します。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この Java コードは、段落への HTML テキスト インポート手順の実装例です：

```java
// 空のプレゼンテーション インスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML コンテンツを収めるために AutoShape を追加
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // シェイプにテキストフレームを追加
    ashape.addTextFrame("");

    // 追加したテキストフレームのすべての段落をクリア
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダーを使って HTML ファイルを読み込む
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

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、対象のプレゼンテーションを読み込みます。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを指定し、好みの段落をエクスポートします。

この Java コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています：

```java
// プレゼンテーション ファイルを読み込む
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 目的のインデックス
    int index = 0;

    // 追加されたシェイプにアクセス
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 出力 HTML ファイルを作成
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //最初の段落を HTML として抽出
    // 段落開始インデックスとコピーする段落総数を指定して、段落データを書き出し HTML に変換
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落を画像として保存する**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。どちらの例も、[IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) インターフェイスの `getImage` メソッドで段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートする手順を示します。これにより、PowerPoint プレゼンテーションから特定のテキスト部分を切り出して別画像として保存でき、さまざまなシナリオで活用できます。

サンプルとして、sample.pptx という 1 スライドのプレゼンテーションを想定します。最初のシェイプは 3 段落を含むテキストボックスです。

![3 段落があるテキストボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まずプレゼンテーションの最初のスライドからシェイプの画像を取得し、次にシェイプのテキストフレーム内の 2 番目の段落の境界を計算します。計算した領域を新しいビットマップに描画し、PNG 形式で保存します。この方法は、特定の段落を別画像として保存したいが、テキストの寸法や書式を正確に保ちたい場合に有用です。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // シェイプをメモリ内にビットマップとして保存します。
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

    // シェイプのビットマップを切り取り、段落のビットマップのみ取得します。
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

この例では、先ほどの方法にスケーリング係数を加えて拡張します。シェイプを抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。段落の境界はスケールを考慮して計算されます。高品質な印刷物など、より詳細な画像が必要な場合に便利です。

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きでシェイプをメモリ内にビットマップとして保存します。
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

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームの改行設定 ([setWrapText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) をオフにすれば、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するには？**

段落（場合によっては単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/中央揃え/均等割付）はどこで制御しますか？**

[Alignment](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) は [ParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/paragraphformat/) の段落レベル設定で、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例：単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベルで設定されるため、[PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を使用すれば、同一段落内で複数の言語を共存させることが可能です。