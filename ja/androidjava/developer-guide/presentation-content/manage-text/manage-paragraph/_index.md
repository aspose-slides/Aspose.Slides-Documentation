---
title: JavaでPowerPointの段落を管理する
type: docs
weight: 40
url: /androidjava/manage-paragraph/
keywords: "PowerPoint段落の追加, 段落の管理, 段落のインデント, 段落のプロパティ, HTMLテキスト, 段落テキストのエクスポート, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションの段落、テキスト、インデント、およびプロパティを作成および管理します"
---

Aspose.Slidesは、JavaでPowerPointのテキスト、段落、およびポーションを操作するために必要なすべてのインターフェースとクラスを提供します。

* Aspose.Slidesは、段落を表すオブジェクトを追加するために[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)インターフェースを提供します。 `ITextFame`オブジェクトは1つまたは複数の段落を持つことができます（各段落はキャリッジリターンを通じて作成されます）。
* Aspose.Slidesは、ポーションを表すオブジェクトを追加するために[IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)インターフェースを提供します。 `IParagraph`オブジェクトは1つまたは複数のポーションを持つことができます（iPortionsオブジェクトのコレクション）。
* Aspose.Slidesは、テキストおよびそのフォーマットプロパティを表すオブジェクトを追加するために[IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/)インターフェースを提供します。

`IParagraph`オブジェクトは、その基盤となる`IPortion`オブジェクトを通じて異なるフォーマットプロパティを持つテキストを処理することができます。

## **複数のポーションを含む複数の段落を追加する**

これらのステップは、3つの段落を含むテキストフレームを追加し、各段落に3つのポーションを含める方法を示します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに長方形の[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)に関連付けられたITextFrameを取得します。
5. 2つの[IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/)オブジェクトを作成し、それらを[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)の`IParagraphs`コレクションに追加します。
6. 各新しい`IParagraph`に対して3つの[IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/)オブジェクトを作成し、それぞれの`IParagraph`のIPortionコレクションに各`IPortion`オブジェクトを追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion`オブジェクトによって公開されたフォーマットプロパティを使用して、各ポーションに好きなフォーマット機能を適用します。
9. 修正されたプレゼンテーションを保存します。

このJavaコードは、ポーションを含む段落を追加するためのステップの実装です：

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 長方形のAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShapeのTextFrameにアクセス
    ITextFrame tf = ashp.getTextFrame();

    // 異なるテキストフォーマットの段落とポーションを作成
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

    // PPTXをディスクに書き込む
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。箇条書きの段落は常に読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. 選択されたスライドに[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き`Type`を`Symbol`に設定し、箇条書き文字を設定します。
8. 段落の`Text`を設定します。
9. 箇条書きの段落に`Indent`を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を`TextFrame`の段落コレクションに追加します。
13. 2番目の段落を追加し、ステップ7から13のプロセスを繰り返します。
14. プレゼンテーションを保存します。

このJavaコードは、段落の箇条書きを追加する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShapeを追加しアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 自動形状テキストフレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();

    // デフォルトの段落を削除
    txtFrm.getParagraphs().removeAt(0);

    // 段落を作成
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 段落テキストを設定
    para.setText("Aspose.Slidesへようこそ");

    // 箇条書きのインデントを設定
    para.getParagraphFormat().setIndent(25);

    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 自分の箇条書き色を使用するにはIsBulletHardColorをtrueに設定

    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);

    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para);

    // 2番目の段落を作成
    Paragraph para2 = new Paragraph();

    // 段落の箇条書きタイプとスタイルを設定
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 段落テキストを追加
    para2.setText("これは番号付き箇条書きです");

    // 箇条書きのインデントを設定
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 自分の箇条書き色を使用するにはIsBulletHardColorをtrueに設定

    // 箇条書きの高さを設定
    para2.getParagraphFormat().getBullet().setHeight(100);

    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para2);
    
    // 修正されたプレゼンテーションを保存
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **画像の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。画像の段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)に画像を読み込みます。
8. 箇条書きのタイプを[Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)に設定し、画像を設定します。
9. 段落の`Text`を設定します。
10. 箇条書きの段落に`Indent`を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を`TextFrame`の段落コレクションに追加します。
14. 2番目の段落を追加し、前の手順に基づいてプロセスを繰り返します。
15. 修正されたプレゼンテーションを保存します。

このJavaコードは、画像の箇条書きを追加し、管理する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
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
    // AutoShapeを追加しアクセス
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 自動形状のテキストフレームにアクセス
    ITextFrame textFrame = autoShape.getTextFrame();

    // デフォルトの段落を削除
    textFrame.getParagraphs().removeAt(0);

    // 新しい段落を作成
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Aspose.Slidesへようこそ");

    // 段落の箇条書きスタイルと画像を設定
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 箇条書きの高さを設定
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // テキストフレームに段落を追加
    textFrame.getParagraphs().add(paragraph);

    // プレゼンテーションをPPTXファイルとして書き出し
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.PptX);

    // プレゼンテーションをPPTファイルとして書き出し
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **多階層の箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。多階層の箇条書きは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. 新しいスライドに[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、深さを0に設定します。
7. `Paragraph`クラスを通じて2番目の段落インスタンスを作成し、深さを1に設定します。
8. `Paragraph`クラスを通じて3番目の段落インスタンスを作成し、深さを2に設定します。
9. `Paragraph`クラスを通じて4番目の段落インスタンスを作成し、深さを3に設定します。
10. 新しい段落を`TextFrame`の段落コレクションに追加します。
11. 修正されたプレゼンテーションを保存します。

このJavaコードは、多階層の箇条書きを追加して管理する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShapeを追加しアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成された自動形状のテキストフレームにアクセス
    ITextFrame text = aShp.addTextFrame("");

    // デフォルトの段落をクリア
    text.getParagraphs().clear();

    // 最初の段落を追加
    IParagraph para1 = new Paragraph();
    para1.setText("コンテンツ");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth((short)0);

    // 2番目の段落を追加
    IParagraph para2 = new Paragraph();
    para2.setText("セカンドレベル");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth((short)1);

    // 3番目の段落を追加
    IParagraph para3 = new Paragraph();
    para3.setText("サードレベル");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth((short)2);

    // 4番目の段落を追加
    IParagraph para4 = new Paragraph();
    para4.setText("フォースレベル");
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

    // プレゼンテーションをPPTXファイルとして書き出し
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カスタム番号付きリストを持つ段落を管理する**

[IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/)インターフェースは、[NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)プロパティやその他を提供し、カスタム番号付けやフォーマットを持つ段落を管理することができます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`内のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)を2に設定します。
7. `Paragraph`クラスを使用して2番目の段落インスタンスを作成し、`NumberedBulletStartWith`を3に設定します。
8. `Paragraph`クラスを使用して3番目の段落インスタンスを作成し、`NumberedBulletStartWith`を7に設定します。
9. 新しい段落を`TextFrame`の段落コレクションに追加します。
10. 修正されたプレゼンテーションを保存します。

このJavaコードは、カスタム番号付けやフォーマットを持つ段落を追加し、管理する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成された自動形状のテキストフレームにアクセス
    ITextFrame textFrame = shape.getTextFrame();

    // 既存のデフォルト段落を削除
    textFrame.getParagraphs().removeAt(0);

    // 最初のリスト
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("箇条書き 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("箇条書き 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("箇条書き 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **段落のインデントを設定する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じて関連するスライドの参照にアクセスします。
1. スライドに長方形の[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
1. 長方形の自動形状に3つの段落を持つ[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)を追加します。
1. 長方形の線を隠します。
1. 各[Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)のBulletOffsetプロパティを通じてインデントを設定します。
1. 修正されたプレゼンテーションをPPTファイルとして書き込みます。

このJavaコードは、段落のインデントを設定する方法を示しています：

```java
// Presentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 長方形の形状を追加
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // 長方形にTextFrameを追加
    ITextFrame tf = rect.addTextFrame("これは最初の行です \rこれは2行目です \rこれは3行目です");
    
    // テキストを形状にフィットさせる
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // 長方形の線を隠す
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // TextFrame内の最初の段落を取得し、インデントを設定
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // 段落の箇条書きスタイルとシンボルを設定
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // TextFrame内の2番目の段落を取得し、インデントを設定
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // TextFrame内の3番目の段落を取得し、インデントを設定
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    //プレゼンテーションをディスクに書き込む
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落の段落のハンギングインデントを設定する**

このJavaコードは、段落のハンギングインデントを設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("例");

    Paragraph para2 = new Paragraph();
    para2.setText("段落にハンギングインデントを設定");

    Paragraph para3 = new Paragraph();
    para3.setText("このC#コードは、段落にハンギングインデントを設定する方法を示しています：");

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

## **段落の終了段落実行プロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライドの位置を通じて段落を含むスライドの参照を取得します。
1. スライドに長方形の[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
1. Rectangleに2つの段落を持つ[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)を追加します。
1. 段落の`FontHeight`とフォントタイプを設定します。
1. 段落の終了プロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、PowerPointの段落に対する終了プロパティを設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("サンプルテキスト"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("サンプルテキスト2"));

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


## **HTMLテキストを段落にインポートする**

Aspose.Slidesは、段落へのHTMLテキストのインポートを強化サポートしています。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)を追加します。
4. 自動形状の[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)を追加してアクセスします。
5. `ITextFrame`内のデフォルトの段落を削除します。
6. TextReaderでソースHTMLファイルを読み込みます。
7. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
8. 読み取ったTextReaderのHTMLファイルコンテンツをTextFrameの[ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/)に追加します。
9. 修正されたプレゼンテーションを保存します。

このJavaコードは、段落にHTMLテキストをインポートする手順の実装です：

```java
// 空のプレゼンテーションインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // HTMLコンテンツを収容するためのAutoShapeを追加
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // 形状にテキストフレームを追加
    ashape.addTextFrame("");

    // 追加したテキストフレーム内のすべての段落をクリア
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダーを用いてHTMLファイルを読み込む
    TextReader tr = new StreamReader("file.html");

    // テキストフレームにHTMLストリームリーダーからのテキストを追加
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // プレゼンテーションを保存
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **段落テキストをHTMLにエクスポートする**

Aspose.Slidesは、段落に含まれるテキストをHTMLにエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスのインスタンスを作成し、必要なプレゼンテーションをロードします。
2. インデックスを通じて関連するスライドの参照にアクセスします。
3. HTMLにエクスポートされるテキストを含む形状にアクセスします。
4. 形状の[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/)にアクセスします。
5. `StreamWriter`のインスタンスを作成し、新しいHTMLファイルを追加します。
6. `StreamWriter`に開始インデックスを提供し、好みの段落をエクスポートします。

このJavaコードは、PowerPointの段落テキストをHTMLにエクスポートする方法を示しています：

```java
// プレゼンテーションファイルをロード
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 希望するインデックス
    int index = 0;

    // 追加された形状にアクセス
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 出力用HTMLファイルを作成
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // 最初の段落をHTMLとして抽出
    // 段落のデータをHTMLに書き込むために、段落の開始インデックスとコピーする合計段落数を提供
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```