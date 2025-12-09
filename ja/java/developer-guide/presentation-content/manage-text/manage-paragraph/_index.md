---
title: Java で PowerPoint テキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/java/manage-paragraph/
keywords:
- テキストの追加
- 段落の追加
- テキストの管理
- 段落の管理
- 箇条書きの管理
- 段落インデント
- ハングインデント
- 段落箇条書き
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用した段落書式設定のマスタリング—PPT、PPTX、ODP プレゼンテーションにおける配置、間隔、スタイルを最適化します。"
---

Aspose.Slides は、Java で PowerPoint のテキスト、段落、部分を操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは 1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、部分を表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは 1 つまたは複数の部分（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基盤となる `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数の部分を含む複数の段落を追加**

以下の手順は、3 つの段落を含み、各段落が 3 つの部分を持つテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) の `IParagraphs` コレクションに追加します。
6. 新しい `IParagraph` ごとに 3 つの [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) オブジェクトを作成（デフォルトの Paragraph には 2 つの Portion オブジェクト）し、各 `IPortion` オブジェクトをそれぞれの `IParagraph` の IPortion コレクションに追加します。
7. 各部分にテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各部分に好みの書式設定機能を適用します。
9. 変更したプレゼンテーションを保存します。

この Java コードは、部分を含む段落を追加する手順の実装例です:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // 矩形タイプの AutoShape を追加する
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape の TextFrame にアクセスする
    ITextFrame tf = ashp.getTextFrame();

    // 異なるテキストフォーマットを持つ段落と部分を作成する
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

    // PPTX をディスクに保存する
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
8. 段落の `Text` を設定します。
9. 箇条書きの段落 `Indent` を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を `TextFrame` の段落コレクションに追加します。
13. 2 番目の段落を追加し、手順 7 から 13 を繰り返します。
14. プレゼンテーションを保存します。

この Java コードは、段落の箇条書きを追加する方法を示しています:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加して取得する
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // オートシェイプのテキストフレームにアクセスする
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

    // 箇条書きのインデントを設定する
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

    // 箇条書きのインデントを設定する
    para2.getParagraphFormat().setIndent(25);

    // 箇条書きの色を設定する
    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // IsBulletHardColor を true に設定して独自の箇条書き色を使用する

    // 箇条書きの高さを設定する
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para2);
    
    // 変更したプレゼンテーションを保存する
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **画像箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) に画像をロードします。
8. 箇条書きタイプを [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きの段落 `Indent` を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順に従って繰り返します。
15. 変更したプレゼンテーションを保存します。

この Java コードは、画像箇条書きを追加および管理する方法を示しています:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
Presentation presentation = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = presentation.getSlides().get_Item(0);

    // 箇条書き用画像を生成する
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // オートシェイプを追加して取得する
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // オートシェイプのテキストフレームにアクセスする
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


## **階層型箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層型箇条書きは読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して2番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して3番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して4番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この Java コードは、階層型箇条書きを追加および管理する方法を示しています:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを生成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // オートシェイプを追加して取得する
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したオートシェイプのテキストフレームにアクセスする
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
    // 箇条書きレベルを設定する
    para1.getParagraphFormat().setDepth((short)0);

    // 2 番目の段落を追加する
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
    para2.getParagraphFormat().setDepth((short)1);

    // 3 番目の段落を追加する
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
    para3.getParagraphFormat().setDepth((short)2);

    // 4 番目の段落を追加する
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
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


## **カスタム番号付きリスト付き段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を 2 に設定します。
7. `Paragraph` クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この Java コードは、カスタム番号付けや書式設定を持つ段落を追加および管理する方法を示しています:
```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame textFrame = shape.getTextFrame();

    // 既定の既存段落を削除する
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


## **段落インデントの設定**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用して対象スライドの参照にアクセスします。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 矩形オートシェイプに 3 段落を持つ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) を追加します。
1. 矩形の線を非表示にします。
1. 各 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) の BulletOffset プロパティを使用してインデントを設定します。
1. 変更したプレゼンテーションを PPT ファイルとして書き出します。

この Java コードは、段落インデントを設定する方法を示しています:
```java
// Presentation クラスのインスタンスを生成する
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得する
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 矩形シェイプを追加する
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // 矩形に TextFrame を追加する
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // テキストをシェイプに合わせて自動調整する
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // 矩形の線を非表示にする
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // TextFrame の最初の段落を取得しインデントを設定する
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // 段落の箇条書きスタイルとシンボルを設定する
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // TextFrame の 2 番目の段落を取得しインデントを設定する
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // TextFrame の 3 番目の段落を取得しインデントを設定する
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // プレゼンテーションをディスクに保存する
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落のハングインデントの設定**

この Java コードは、段落のハングインデントを設定する方法を示しています:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Example");

    Paragraph para2 = new Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");

    Paragraph para3 = new Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落の End ラン プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 位置を指定して段落が含まれるスライドの参照を取得します。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
1. 矩形に 2 段落を持つ [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) を追加します。
1. 段落の `FontHeight` とフォント種別を設定します。
1. 段落の End プロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この Java コードは、PowerPoint の段落に対して End プロパティを設定する方法を示しています:
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

Aspose.Slides は、HTML テキストを段落にインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) を追加および取得します。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この Java コードは、段落への HTML テキスト インポート手順の実装例です:
```java
// 空のプレゼンテーションインスタンスを作成する
Presentation pres = new Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // HTML コンテンツを収容するために AutoShape を追加する
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // シェイプにテキストフレームを追加する
    ashape.addTextFrame("");

    // 追加したテキストフレームのすべての段落をクリアする
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダーで HTML ファイルを読み込む
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

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. StreamWriter に開始インデックスを指定し、希望する段落をエクスポートします。

この Java コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています:
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
    // 段落の開始インデックスとコピーする総段落数を指定して段落データを書き込み HTML に出力する
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落を画像として保存する**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。両例とも、[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) インターフェイスの `getImage` メソッドで段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションから特定のテキスト部分を抽出し、別々の画像として保存でき、さまざまなシナリオで活用できます。

サンプルとして、1 枚のスライドを持つ `sample.pptx` があり、最初のシェイプは 3 段落を含むテキストボックスです。

![The text box with three paragraphs](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を抽出し、シェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式を保持しながら特定の段落を別画像として保存したい場合に特に有用です。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 形状をメモリ内でビットマップとして保存する。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリからシェイプのビットマップを作成する。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2番目の段落の境界を計算する。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // 出力画像の座標とサイズを計算する（最小サイズは1x1ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // シェイプビットマップを切り取り、段落ビットマップだけを取得する。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


結果:

![The paragraph image](paragraph_to_image_output.png)

**例 2**

この例では、前述の手法に拡大率を加えて段落画像を生成します。プレゼンテーションからシェイプを抽出し、拡大率 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。拡大率を考慮して段落の境界を計算します。スケーリングは、例えば高品質印刷物での使用など、より詳細な画像が必要な場合に特に有用です。
```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // スケーリング付きで形状をメモリ内のビットマップとして保存する。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // メモリから形状のビットマップを作成する。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 2番目の段落の境界を計算する。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 出力画像の座標とサイズを計算する（最小サイズは1x1ピクセル）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 形状ビットマップを切り取り、段落ビットマップだけを取得する。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームの改行設定（[setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-)）をオフにすれば、フレームの端で行が折り返されなくなります。

**特定の段落のスライド上での正確な境界を取得するには？**

段落（および単一の部分）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**段落の配置（左揃え/右揃え/中央揃え/均等揃え）はどこで設定しますか？**

[Alignment](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setAlignment-int-) は [ParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/) の段落レベルの設定で、個々の部分の書式設定に関係なく段落全体に適用されます。

**段落の一部（例: 単語）だけにスペルチェック言語を設定できますか？**

はい。言語は部分レベル（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)）で設定されるため、同一段落内に複数言語を共存させることができます。