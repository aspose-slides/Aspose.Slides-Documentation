---
title: バレットの管理
type: docs
weight: 60
url: /ja/java/manage-bullet/
keywords: "バレット, バレットリスト, 数字, 番号付きリスト, 画像バレット, 階層バレット, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションにバレットと番号付きリストを作成する"
---

**Microsoft PowerPoint**では、Wordや他のテキストエディタと同様に、バレットと番号付きリストを作成できます。**Aspose.Slides for Java**もプレゼンテーションのスライドでバレットと数字を使用することを可能にします。

## バレットリストを使用する理由は？

バレットリストは情報を迅速かつ効率的に整理し、提示するのに役立ちます。

**バレットリストの例**

ほとんどの場合、バレットリストは次の3つの主要な機能を果たします：

- 読者や視聴者の注意を重要な情報に引き付ける
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する。

## 番号付きリストを使用する理由は？

番号付きリストも情報の整理と提示に役立ちます。基本的に、エントリの順序（例えば、*ステップ1, ステップ2*など）が重要な場合や、エントリを参照しなければならない場合（例えば、*ステップ3を参照*）には、バレットの代わりに数字を使用するべきです。

**番号付きリストの例**

以下の**バレット作成**手順のまとめ（ステップ1からステップ15）です：

1. プレゼンテーションクラスのインスタンスを作成します。
2. いくつかのタスクを実行します（ステップ3からステップ14）。
3. プレゼンテーションを保存します。

## バレットの作成
このトピックは、テキスト段落の管理に関するトピックシリーズの一部でもあります。このページでは、段落のバレットを管理する方法を示します。何かをステップで説明する際には、バレットがより有用です。さらに、テキストはバレットを使用することでよく整理されて見えます。バレット付きの段落は常に読みやすく、理解しやすいです。開発者がAspose.Slides for Javaのこの小さくも強力な機能をどのように利用できるかを見ていきましょう。以下の手順に従って、Aspose.Slides for Javaを使用して段落バレットを管理してください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide)オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドに[AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText)を追加します。
1. 追加されたシェイプの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)にアクセスします。
1. TextFrame内のデフォルト段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph)クラスを使用して最初の段落インスタンスを作成します。
1. 段落のバレットタイプを設定します。
1. バレットタイプを[Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol)に設定し、バレット文字を設定します。
1. 段落テキストを設定します。
1. バレットを設定するために段落インデントを設定します。
1. バレットの色を設定します。
1. バレットの高さを設定します。
1. 作成した段落をTextFrame段落コレクションに追加します。
1. 2番目の段落を追加し、ステップ**7から13**で示されたプロセスを繰り返します。
1. プレゼンテーションを保存します。

上記のステップの実装であるこのJavaサンプルコードは、スライド内にバレットリストを作成する方法を示します：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshapeの追加とアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したAutoshapeのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // デフォルトの存在する段落を削除
    txtFrm.getParagraphs().removeAt(0);
    
    // 段落を作成
    Paragraph para = new Paragraph();
    
    // 段落のバレットスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 段落テキストを設定
    para.setText("Aspose.Slidesへようこそ");
    
    // バレットインデントを設定
    para.getParagraphFormat().setIndent(25);
    
    // バレットの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // 自分のバレット色を使用するためにIsBulletHardColorをtrueに設定
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // バレットの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para);
    
    // プレゼンテーションをPPTXファイルとして保存
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## 画像バレットの作成

Aspose.Slides for Javaでは、バレットリストのバレットを変更することができます。自分のシンボルや画像でバレットを置き換えることができます。リストに視覚的な興味を追加したり、リストの項目により多くの注意を引き付けたりする場合は、自分の画像をバレットとして使用できます。

{{% alert color="primary" %}}

理想的には、通常のバレットシンボルを画像で置き換えたい場合、透明な背景を持つシンプルなグラフィック画像を選ぶと良いでしょう。そのような画像はカスタムバレットシンボルとして最も適しています。

いずれにしても、選択した画像は非常に小さなサイズに縮小されるため、リストのバレットシンボルの置き換えとして見栄えの良い画像を選ぶことを強くお勧めします。

{{% /alert %}}

画像バレットを作成するために、以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide)オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします
1. 選択したスライドにオートシェイプを追加します
1. 追加されたシェイプの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)にアクセスします
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)内のデフォルト段落を削除します
1. 段落クラスを使用して最初の段落インスタンスを作成します
1. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage)からディスクの画像をロードします
1. バレットタイプを画像に設定し、画像を設定します
1. 段落テキストを設定します
1. バレットを設定するために段落インデントを設定します
1. バレットの色を設定します
1. バレットの高さを設定します
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)段落コレクションに作成した段落を追加します
1. 2番目の段落を追加し、前の手順で示されたプロセスを繰り返します
1. プレゼンテーションを保存します

このJavaコードは、スライドに画像バレットを作成する方法を示します：

```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // バレット用の画像をインスタンス化
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Autoshapeの追加とアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したAutoshapeのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();
    // デフォルトの存在する段落を削除
    txtFrm.getParagraphs().removeAt(0);

    // 新しい段落を作成
    Paragraph para = new Paragraph();
    para.setText("Aspose.Slidesへようこそ");

    // 段落のバレットスタイルと画像を設定
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // バレットの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);

    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para);

    // プレゼンテーションをPPTXファイルとして保存
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 階層バレットの作成

異なるレベルの項目を含むバレットリストを作成するには、メインのバレットリストの下に追加のリストを作成するために、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide)オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドにオートシェイプを追加します。
1. 追加されたシェイプの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)内のデフォルト段落を削除します。
1. 段落クラスを使用して、深さを0に設定した最初の段落インスタンスを作成します。
1. 段落クラスを使用して、深さを1に設定した2番目の段落インスタンスを作成します。
1. 段落クラスを使用して、深さを2に設定した3番目の段落インスタンスを作成します。
1. 段落クラスを使用して、深さを3に設定した4番目の段落インスタンスを作成します。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)段落コレクションに作成した段落を追加します。
1. プレゼンテーションを保存します。

以下のコードは、上記のステップの実装であり、Javaで階層バレットリストを作成する方法を示します：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshapeの追加とアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したAutoshapeのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // デフォルトの存在する段落を削除
    txtFrm.getParagraphs().clear();
    
    // 最初の段落を作成
    Paragraph para1 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定
    para1.setText("内容");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルの設定
    para1.getParagraphFormat().setDepth((short) 0);
    
    // 2番目の段落を作成
    Paragraph para2 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定
    para2.setText("第二レベル");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルの設定
    para2.getParagraphFormat().setDepth((short) 1);
    
    // 3番目の段落を作成
    Paragraph para3 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定
    para3.setText("第三レベル");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルの設定
    para3.getParagraphFormat().setDepth((short) 2);
    
    // 4番目の段落を作成
    Paragraph para4 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定
    para4.setText("第四レベル");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte) FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルの設定
    para4.getParagraphFormat().setDepth((short) 3);
    
    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // プレゼンテーションをPPTXファイルとして保存
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## カスタム番号付きリストの作成
Aspose.Slides for Javaは、カスタム番号書式で段落を管理するためのシンプルなAPIを提供しています。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide)オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドにオートシェイプを追加します。
1. 追加されたシェイプの[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)内のデフォルト段落を削除します。
1. 段落クラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith**を2に設定します。
1. 段落クラスを使用して2番目の段落インスタンスを作成し、**NumberedBulletStartWith**を3に設定します。
1. 段落クラスを使用して3番目の段落インスタンスを作成し、**NumberedBulletStartWith**を7に設定します。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)段落コレクションに作成した段落を追加します。
1. プレゼンテーションを保存します。

このJavaコードは、スライドに番号付きリストを作成する方法を示します：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshapeの追加とアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したAutoshapeのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.addTextFrame("");

    // デフォルトの存在する段落を削除
    txtFrm.getParagraphs().clear();

    // 最初のリスト
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("バレット2");
    paragraph1.getParagraphFormat().setDepth((short) 4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("バレット3");
    paragraph2.getParagraphFormat().setDepth((short) 4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // 2番目のリスト
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("バレット5");
    paragraph5.getParagraphFormat().setDepth((short) 4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```