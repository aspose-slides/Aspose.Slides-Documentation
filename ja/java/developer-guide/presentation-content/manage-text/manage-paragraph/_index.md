---
title: JavaでPowerPointの段落を管理する
type: docs
weight: 40
url: /java/manage-paragraph/
keywords: "PowerPoint段落を追加, 段落管理, 段落インデント, 段落プロパティ, HTMLテキスト, 段落テキストをエクスポート, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションの段落、テキスト、インデント、およびプロパティを作成および管理します"
---

Aspose.Slidesは、JavaでPowerPointのテキスト、段落、および部分を操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slidesは、段落を表すオブジェクトを追加できるようにするために[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)インターフェイスを提供しています。`ITextFame`オブジェクトは、1つまたは複数の段落を持つことができます（各段落はキャリッジリターンを介して作成されます）。
* Aspose.Slidesは、部分を表すオブジェクトを追加できるようにするために[IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)インターフェイスを提供しています。`IParagraph`オブジェクトは、1つまたは複数の部分（iPortionsオブジェクトのコレクション）を持つことができます。
* Aspose.Slidesは、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにするために[IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/)インターフェイスを提供しています。

`IParagraph`オブジェクトは、基となる`IPortion`オブジェクトを通じて異なる書式設定プロパティを持つテキストを処理できます。

## **複数の部分を含む複数の段落を追加する**

これらの手順は、3つの段落を含み、各段落が3つの部分を含むテキストフレームを追加する方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに長方形の[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)に関連付けられたITextFrameを取得します。
5. 2つの[IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/)オブジェクトを作成し、それらを[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)の`IParagraphs`コレクションに追加します。
6. 各新しい`IParagraph`のために3つの[IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/)オブジェクトを作成し、各`IParagraph`のIPortionコレクションに各`IPortion`オブジェクトを追加します。
7. 各部分のテキストを設定します。
8. `IPortion`オブジェクトによって公開される書式設定プロパティを使用して、各部分に希望の書式設定機能を適用します。
9. 修正されたプレゼンテーションを保存します。

このJavaコードは、部分を含む段落を追加する手順の実装です：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 長方形タイプのAutoShapeを追加
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShapeのTextFrameにアクセス
    ITextFrame tf = ashp.getTextFrame();

    // 異なるテキスト形式を持つ段落と部分を作成
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

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. 選択したスライドに[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書き`Type`を`Symbol`に設定し、箇条書き文字を設定します。
8. 段落の`Text`を設定します。
9. 箇条書きのための段落の`Indent`を設定します。
10. 箇条書きの色を設定します。
11. 箇条書きの高さを設定します。
12. 新しい段落を`TextFrame`段落コレクションに追加します。
13. 2番目の段落を追加し、ステップ7から13のプロセスを繰り返します。
14. プレゼンテーションを保存します。

このJavaコードは、段落箇条書きを追加する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshapeを追加し、アクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshapeのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();

    // デフォルト段落を削除
    txtFrm.getParagraphs().removeAt(0);

    // 段落を作成
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 段落のテキストを設定
    para.setText("Aspose.Slidesへようこそ");

    // 箇条書きのインデントを設定
    para.getParagraphFormat().setIndent(25);

    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 独自の箇条書き色を使用するためにIsBulletHardColorをtrueに設定

    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);

    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para);

    // 2番目の段落を作成
    Paragraph para2 = new Paragraph();

    // 段落の箇条書きタイプとスタイルを設定
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 段落のテキストを追加
    para2.setText("これは番号付きの箇条書きです");

    // 箇条書きのインデントを設定
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 独自の箇条書き色を使用するためにIsBulletHardColorをtrueに設定

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

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)に画像を読み込みます。
8. 箇条書きのタイプを[Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)に設定し、画像を設定します。
9. 段落の`Text`を設定します。
10. 箇条書きのための段落の`Indent`を設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を`TextFrame`段落コレクションに追加します。
14. 2番目の段落を追加し、前のステップに基づいてプロセスを繰り返します。
15. 修正されたプレゼンテーションを保存します。

このJavaコードは、画像の箇条書きを追加および管理する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
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

    // Autoshapeを追加し、アクセス
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshapeのテキストフレームにアクセス
    ITextFrame textFrame = autoShape.getTextFrame();

    // デフォルト段落を削除
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

    // プレゼンテーションをPPTXファイルとして書き込み
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // プレゼンテーションをPPTファイルとして書き込み
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **マルチレベル箇条書きを管理する**

箇条書きリストは、情報を迅速かつ効率的に整理して提示するのに役立ちます。マルチレベル箇条書きは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. 新しいスライドに[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)クラスを介して最初の段落インスタンスを作成し、深さを0に設定します。
7. `Paragraph`クラスを介して2番目の段落インスタンスを作成し、深さを1に設定します。
8. `Paragraph`クラスを介して3番目の段落インスタンスを作成し、深さを2に設定します。
9. `Paragraph`クラスを介して4番目の段落インスタンスを作成し、深さを3に設定します。
10. 新しい段落を`TextFrame`の段落コレクションに追加します。
11. 修正されたプレゼンテーションを保存します。

このJavaコードは、マルチレベル箇条書きを追加および管理する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshapeを追加し、アクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したautoshapeのテキストフレームにアクセス
    ITextFrame text = aShp.addTextFrame("");

    // デフォルト段落をクリア
    text.getParagraphs().clear();

    // 最初の段落を追加
    IParagraph para1 = new Paragraph();
    para1.setText("内容");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth((short)0);

    // 2番目の段落を追加
    IParagraph para2 = new Paragraph();
    para2.setText("第2レベル");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth((short)1);

    // 3番目の段落を追加
    IParagraph para3 = new Paragraph();
    para3.setText("第3レベル");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth((short)2);

    // 4番目の段落を追加
    IParagraph para4 = new Paragraph();
    para4.setText("第4レベル");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para4.getParagraphFormat().setDepth((short)3);

    // コレクションに段落を追加
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // PPTXファイルとしてプレゼンテーションを書き込む
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **カスタム番号付きリストの段落を管理する**

[IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/)インターフェイスは、段落をカスタム番号や書式設定で管理できるようにするために[NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)プロパティなどを提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)にアクセスします。
5. `TextFrame`のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)クラスを介して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)を2に設定します。
7. `Paragraph`クラスを介して2番目の段落インスタンスを作成し、`NumberedBulletStartWith`を3に設定します。
8. `Paragraph`クラスを介して3番目の段落インスタンスを作成し、`NumberedBulletStartWith`を7に設定します。
9. 新しい段落を`TextFrame`段落コレクションに追加します。
10. 修正されたプレゼンテーションを保存します。

このJavaコードは、カスタム番号や書式設定を持つ段落を追加および管理する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したautoshapeのテキストフレームにアクセス
    ITextFrame textFrame = shape.getTextFrame();

    // 既存のデフォルトの段落を削除します
    textFrame.getParagraphs().removeAt(0);

    // 最初のリスト
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("箇条書き2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("箇条書き3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("箇条書き7");
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

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介して関連するスライドの参照にアクセスします。
1. スライドに長方形の[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
1. 長方形のautoshapeに3つの段落を持つ[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)を追加します。
1. 長方形のラインを非表示にします。
1. 各段落のBulletOffsetプロパティを介して段落のインデントを設定します。
1. 修正されたプレゼンテーションをPPTファイルとして書き込みます。

このJavaコードは、段落のインデントを設定する方法を示しています：

```java
// Presentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 長方形のシェイプを追加
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // 長方形にテキストフレームを追加
    ITextFrame tf = rect.addTextFrame("これは最初の行です \rこれは2行目です \rこれは3行目です");
    
    // テキストをシェイプにフィットさせる
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // 長方形のラインを隠す
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // テキストフレームの最初の段落を取得し、そのインデントを設定
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // 段落の箇条書きスタイルとシンボルを設定
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // テキストフレームの2番目の段落を取得し、そのインデントを設定
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // テキストフレームの3番目の段落を取得し、そのインデントを設定
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // プレゼンテーションをディスクに書き込む
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落の吊り下げインデントを設定する**

このJavaコードは、段落の吊り下げインデントを設定する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("例");

    Paragraph para2 = new Paragraph();
    para2.setText("段落の吊り下げインデントを設定します");

    Paragraph para3 = new Paragraph();
    para3.setText("このC#コードは、段落の吊り下げインデントを設定する方法を示しています。");

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

## **段落の末尾プロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. 指定の位置を介して段落を含むスライドの参照を取得します。
1. スライドに長方形の[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
1. 長方形に2つの段落を持つ[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)を追加します。
1. 段落の`FontHeight`とフォントタイプを設定します。
1. 段落の末尾プロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このJavaコードは、PowerPointの段落の末尾プロパティを設定する方法を示しています：

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

Aspose.Slidesは、段落にHTMLテキストをインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)を追加します。
4. autoshapeの[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)に追加およびアクセスします。
5. `ITextFrame`のデフォルト段落を削除します。
6. テキストリーダを使用してソースHTMLファイルを読み込みます。
7. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/)クラスを介して最初の段落インスタンスを作成します。
8. 読み取ったTextReaderから内容をテキストフレームの[ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/)に追加します。
9. 修正されたプレゼンテーションを保存します。

このJavaコードは、段落にHTMLテキストをインポートする手順の実装です：

```java
// 空のプレゼンテーションインスタンスを作成
Presentation pres = new Presentation();
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // HTMLコンテンツを収容するためにAutoShapeを追加
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // シェイプにテキストフレームを追加
    ashape.addTextFrame("");

    // 追加されたテキストフレームのすべての段落をクリア
    ashape.getTextFrame().getParagraphs().clear();

    // ストリームリーダを使用してHTMLファイルを読み込む
    TextReader tr = new StreamReader("file.html");

    // テキストフレームにテキストを追加
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // プレゼンテーションを保存
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **段落テキストをHTMLにエクスポートする**

Aspose.Slidesは、段落に含まれるテキストをHTMLにエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、希望するプレゼンテーションをロードします。
2. インデックスを介して関連するスライドの参照にアクセスします。
3. HTMLにエクスポートされるテキストを含むシェイプにアクセスします。
4. シェイプの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)にアクセスします。
5. `StreamWriter`のインスタンスを作成し、新しいHTMLファイルを追加します。
6. StreamWriterに開始インデックスを提供し、希望の段落をエクスポートします。

このJavaコードは、PowerPoint段落テキストをHTMLにエクスポートする方法を示しています：

```java
// プレゼンテーションファイルをロード
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 希望のインデックス
    int index = 0;

    // 追加されたシェイプにアクセス
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 出力HTMLファイルを作成
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // 最初の段落をHTMLとして抽出
    // 段落の開始インデックス、コピーする総段落数を提供することによってHTMLに書き込む
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```