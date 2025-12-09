---
title: Java を使用したプレゼンテーションでの箇条書きと番号付きリストの管理
linktitle: リストの管理
type: docs
weight: 60
url: /ja/java/manage-bullet/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多階層リスト
- 箇条書きの作成
- 箇条書きの追加
- リストの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションの箇条書きと番号付きリストを管理する方法を学びます。ステップバイステップガイド。"
---

In **Microsoft PowerPoint**、Wordやその他のテキストエディタと同じ方法で箇条書きと番号付きリストを作成できます。**Aspose.Slides for Java** でもプレゼンテーションのスライドで箇条書きや番号付きを使用できます。 

## **箇条書きを使用する理由は？**

箇条書きは情報を迅速かつ効率的に整理・提示するのに役立ちます。 

**箇条書きの例**

ほとんどの場合、箇条書きは次の3つの主な機能を果たします。

- 読者や視聴者の注意を重要な情報へ引き付ける
- 読者や視聴者が要点を簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する

## **番号付きリストを使用する理由は？**

番号付きリストも情報の整理と提示に役立ちます。エントリの順序（例: *ステップ 1、ステップ 2* など）が重要な場合や、エントリを参照する必要がある場合（例: *ステップ 3 を参照*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下は **Creating Bullets** 手順の要約（ステップ 1 からステップ 15）です。

1. Presentation クラスのインスタンスを作成します。 
2. 複数のタスクを実行します（ステップ 3 からステップ 14）。 
3. プレゼンテーションを保存します。 

## **箇条書きの作成**

このトピックはテキスト段落の管理に関するシリーズの一部です。このページでは段落箇条書きの管理方法を示します。箇条書きは手順を説明する場合に特に有用です。また、箇条書きを使用するとテキストが整理され、読みやすくなります。開発者が Aspose.Slides for Java のこの小さくても強力な機能を使用できる方法を示します。以下の手順に従って Aspose.Slides for Java を使用して段落箇条書きを管理してください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします。
1. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) にアクセスします。
1. TextFrame のデフォルト段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成します。
1. 段落の箇条書きタイプを設定します。
1. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) に設定し、箇条書き文字を指定します。
1. 段落テキストを設定します。
1. 箇条書きを設定するために段落インデントを設定します。
1. 箇条書きの色を設定します。
1. 箇条書きの高さを設定します。
1. 作成した段落を TextFrame の段落コレクションに追加します。
1. 2 番目の段落を追加し、**7 から 13** の手順を繰り返します。
1. プレゼンテーションを保存します。

このサンプルコード（Java）は上記手順の実装例で、スライドに箇条書きを作成する方法を示します:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加してアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したオートシェイプのテキスト フレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().removeAt(0);
    
    // 段落を作成
    Paragraph para = new Paragraph();
    
    // 段落の箇条書きスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 段落のテキストを設定
    para.setText("Welcome to Aspose.Slides");
    
    // 箇条書きのインデントを設定
    para.getParagraphFormat().setIndent(25);
    
    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // 段落をテキスト フレームに追加
    txtFrm.getParagraphs().add(para);
    
    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **画像箇条書きの作成**

Aspose.Slides for Java では箇条書きリストの箇条書きを変更できます。カスタムシンボルや画像に置き換えることが可能です。リストに視覚的な興味を加えたり、項目への注意をさらに引き付けたい場合は、独自の画像を箇条書きとして使用できます。 

{{% alert color="primary" %}} 
通常の箇条書きシンボルを画像に置き換える場合は、透過背景のシンプルなグラフィック画像を選択するとよいでしょう。そのような画像はカスタム箇条書きシンボルとして最適です。 

いずれにせよ、画像は非常に小さく縮小されるため、リスト内で箇条書きシンボルの代替として見栄えの良い画像を選択することを強く推奨します。 
{{% /alert %}} 

画像箇条書きを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします
1. 選択したスライドに autoshape を追加します
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) にアクセスします
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) のデフォルト段落を削除します
1. Paragraph クラスを使用して最初の段落インスタンスを作成します
1. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage) からディスク上の画像を読み込みます
1. 箇条書きタイプを Picture に設定し、画像を指定します
1. 段落テキストを設定します
1. 箇条書きを設定するために段落インデントを設定します
1. 箇条書きの色を設定します
1. 箇条書きの高さを設定します
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の段落コレクションに追加します
1. 2 番目の段落を追加し、前述の手順を繰り返します
1. プレゼンテーションを保存します

この Java コードはスライドに画像箇条書きを作成する方法を示します:
```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // 箇条書き用の画像をインスタンス化
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // オートシェイプを追加してアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したオートシェイプのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.getTextFrame();
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().removeAt(0);

    // 新しい段落を作成
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // 段落の箇条書きスタイルと画像を設定
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para);

    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **多階層箇条書きの作成**

メインの箇条書きリストの下に追加のリストを持つ、異なるレベルの項目を含む箇条書きリストを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) のデフォルト段落を削除します。
1. Paragraph クラスを使用して深さ 0 の最初の段落インスタンスを作成します。
1. Paragraph クラスを使用して深さ 1 の2番目の段落インスタンスを作成します。
1. Paragraph クラスを使用して深さ 2 の3番目の段落インスタンスを作成します。
1. Paragraph クラスを使用して深さ 3 の4番目の段落インスタンスを作成します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

上記手順の実装例であるこのコードは、Java で多階層箇条書きリストを作成する方法を示します:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加してアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したオートシェイプのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.addTextFrame("");
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().clear();
    
    // 最初の段落を作成
    Paragraph para1 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 2 番目の段落を作成
    Paragraph para2 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 3 番目の段落を作成
    Paragraph para3 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 4 番目の段落を作成
    Paragraph para4 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定
    para4.getParagraphFormat().setDepth ((short)3);
    
    // 段落をテキストフレームに追加
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カスタム番号付きリストの作成**

Aspose.Slides for Java はカスタム番号書式設定で段落を管理するシンプルな API を提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライドコレクションから目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) のデフォルト段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith** を 2 に設定します
1. Paragraph クラスを使用して2番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 3 に設定します
1. Paragraph クラスを使用して3番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 7 に設定します
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

この Java コードはスライドに番号付きリストを作成する方法を示します:
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセス
    ISlide slide = pres.getSlides().get_Item(0);

    // オートシェイプを追加してアクセス
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したオートシェイプのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.addTextFrame("");

    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().clear();

    // 最初のリスト
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // 2 番目のリスト
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Aspose.Slidesで作成した箇条書きや番号付きリストは、PDFや画像などの他の形式にエクスポートできますか？**

はい、Aspose.Slides は PDF、画像などの形式にエクスポートする際に、箇条書きや番号付きリストの書式や構造を完全に保持し、一貫した結果を提供します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートできますか？**

はい、Aspose.Slides は既存のプレゼンテーションから箇条書きや番号付きリストをインポートおよび編集でき、元の書式や外観を保持します。

**Aspose.Slides は複数言語で作成されたプレゼンテーションの箇条書きや番号付きリストをサポートしていますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートし、任意の言語で箇条書きや番号付きリストを作成でき、特殊文字や非ラテン文字も使用可能です。