---
title: バレットの管理
type: docs
weight: 60
url: /androidjava/manage-bullet/
keywords: "バレット, バレットリスト, 数字, 番号付きリスト, 画像バレット, 階層バレット, PowerPoint プレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointプレゼンテーションにバレットおよび番号付きリストを作成する"
---

**Microsoft PowerPoint** では、Wordや他のテキストエディターと同様に、バレットと番号付きリストを作成できます。 **Aspose.Slides for Android via Java** では、プレゼンテーションのスライドでバレットと番号を使用することもできます。

## なぜバレットリストを使用するのか？

バレットリストは、情報を迅速かつ効率的に整理し、提示するのに役立ちます。 

**バレットリストの例**

ほとんどの場合、バレットリストは次の3つの主な機能を果たします：

- 読者や視聴者の注意を重要な情報に引き付ける
- 読者や視聴者が主要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する。

## なぜ番号付きリストを使用するのか？

番号付きリストも情報の整理と提示に役立ちます。 理想的には、エントリーの順序（たとえば、*ステップ1、ステップ2* など）が重要な場合や、エントリーを参照する必要がある場合（たとえば、*ステップ3を参照*）には、バレットの代わりに数字を使用するべきです。

**番号付きリストの例**

これは、下記の**バレットの作成**手順（ステップ1からステップ15まで）の要約です：

1. プレゼンテーションクラスのインスタンスを作成します。
2. いくつかのタスクを実行します（ステップ3からステップ14まで）。
3. プレゼンテーションを保存します。 

## バレットの作成
このトピックは、テキスト段落の管理に関するトピックシリーズの一部です。このページでは、段落のバレットを管理する方法を示します。バレットは、何かをステップで説明する必要がある場合に特に有用です。また、テキストはバレットを使用することで見た目が整理されます。バレット付き段落は常に読みやすく、理解しやすくなります。Aspose.Slides for Android via Javaのこの小さくても強力な機能を開発者がどのように使用できるかを見ていきましょう。以下の手順に従って、Aspose.Slides for Android via Javaで段落のバレットを管理してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします。
1. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) を追加します。
1. 追加された形状の [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) にアクセスします。
1. TextFrame内のデフォルトの段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成します。
1. 段落のバレットタイプを設定します。
1. バレットタイプを [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) に設定し、バレットキャラクターを設定します。
1. 段落テキストを設定します。
1. バレットを設定するために段落インデントを設定します。
1. バレットの色を設定します。
1. バレットの高さを設定します。
1. 作成した段落をTextFrameの段落コレクションに追加します。
1. 2つ目の段落を追加し、**7から13**の手順を繰り返します。
1. プレゼンテーションを保存します。

このJavaのサンプルコードは、上記の手順を実装したもので、スライドにバレットリストを作成する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshapeを追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したautoshapeのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // デフォルトの既存の段落を削除する
    txtFrm.getParagraphs().removeAt(0);
    
    // 段落を作成する
    Paragraph para = new Paragraph();
    
    // 段落のバレットスタイルとシンボルを設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 段落テキストを設定する
    para.setText("Aspose.Slidesへようこそ");
    
    // バレットのインデントを設定する
    para.getParagraphFormat().setIndent(25);
    
    // バレットの色を設定する
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // 任意のバレットカラーを使用するためにIsBulletHardColorをtrueに設定する
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // バレットの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // テキストフレームに段落を追加する
    txtFrm.getParagraphs().add(para);
    
    // プレゼンテーションをPPTXファイルとして保存する
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## 画像バレットの作成

Aspose.Slides for Android via Javaを使用すると、バレットリストのバレットを変更できます。 カスタムシンボルや画像にバレットを置き換えることができます。 リストに視覚的な興味を追加したり、リスト上のエントリーにさらなる注目を集めたりしたい場合は、独自の画像をバレットとして使用できます。

{{% alert color="primary" %}} 

理想的には、通常のバレットシンボルを画像で置き換える場合、透明な背景のシンプルなグラフィック画像を選択することをお勧めします。そのような画像はカスタムバレットシンボルとして最適に機能します。

いずれにせよ、選択する画像は非常に小さなサイズに縮小されるため、リスト内でバレットシンボルの代わりとして見栄えが良い画像を選択することを強くお勧めします。

{{% /alert %}} 

画像バレットを作成するには、これらの手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします
1. 選択したスライドにautoshapeを追加します
1. 追加された形状の[TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)にアクセスします
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)内のデフォルトの段落を削除します
1. Paragraphクラスを使って最初の段落インスタンスを作成します
1. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage) からディスクの画像をロードします
1. バレットタイプをPictureに設定し、画像を設定します
1. 段落テキストを設定します
1. バレットを設定するために段落インデントを設定します
1. バレットの色を設定します
1. バレットの高さを設定します
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加します
1. 2つ目の段落を追加し、前の手順で説明されたプロセスを繰り返します
1. プレゼンテーションを保存します

このJavaコードは、スライドに画像バレットを作成する方法を示しています：

```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // バレット用の画像をインスタンス化する
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Autoshapeを追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したautoshapeのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    // デフォルトの既存の段落を削除する
    txtFrm.getParagraphs().removeAt(0);

    // 新しい段落を作成する
    Paragraph para = new Paragraph();
    para.setText("Aspose.Slidesへようこそ");

    // 段落のバレットスタイルと画像を設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // バレットの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);

    // テキストフレームに段落を追加する
    txtFrm.getParagraphs().add(para);

    // プレゼンテーションをPPTXファイルとして書き込む
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 階層バレットの作成

異なるレベルのアイテムを含むバレットリストを作成するには（メインのバレットリストの下に追加のリスト）以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします。
1. 選択したスライドにautoshapeを追加します。
1. 追加された形状の [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 内のデフォルトの段落を削除します。
1. 段落クラスを使って最初の段落インスタンスを作成し、深さを0に設定します。
1. 段落クラスを使って2番目の段落インスタンスを作成し、深さを1に設定します。
1. 段落クラスを使って3番目の段落インスタンスを作成し、深さを2に設定します。
1. 段落クラスを使って4番目の段落インスタンスを作成し、深さを3に設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

このコードは、上記の手順の実装で、Javaで階層バレットリストを作成する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Autoshapeを追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したautoshapeのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // デフォルトの既存の段落を削除する
    txtFrm.getParagraphs().clear();
    
    // 最初の段落を作成する
    Paragraph para1 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定する
    para1.setText("コンテンツ");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para1.getParagraphFormat().setDepth((short)0);
    
    // 2番目の段落を作成する
    Paragraph para2 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定する
    para2.setText("第二レベル");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para2.getParagraphFormat().setDepth((short)1);
    
    // 3番目の段落を作成する
    Paragraph para3 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定する
    para3.setText("第三レベル");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para3.getParagraphFormat().setDepth((short)2);
    
    // 4番目の段落を作成する
    Paragraph para4 = new Paragraph();
    // 段落のバレットスタイルとシンボルを設定する
    para4.setText("第四レベル");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // バレットレベルを設定する
    para4.getParagraphFormat().setDepth((short)3);
    
    // テキストフレームに段落を追加する
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // プレゼンテーションをPPTXファイルとして保存する
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## カスタム番号付きリストの作成
Aspose.Slides for Android via Javaは、カスタム番号形式で段落を管理するためのシンプルなAPIを提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします。
1. 選択したスライドにautoshapeを追加します。
1. 追加された形状の [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 内のデフォルトの段落を削除します。
1. 段落クラスを使って最初の段落インスタンスを作成し、**NumberedBulletStartWith** を2に設定します。
1. 段落クラスを使って2番目の段落インスタンスを作成し、**NumberedBulletStartWith** を3に設定します。
1. 段落クラスを使って3番目の段落インスタンスを作成し、**NumberedBulletStartWith** を7に設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

このJavaコードは、スライドに番号付きリストを作成する方法を示しています：

```java
// PPTXファイルを表すPresentationクラスをインスタンス化する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // Autoshapeを追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したautoshapeのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");

    // デフォルトの既存の段落を削除する
    txtFrm.getParagraphs().clear();

    // 最初のリスト
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("バレット 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("バレット 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // 2番目のリスト
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("バレット 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```