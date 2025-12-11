---
title: Android のプレゼンテーションで箇条書きと番号付きリストを管理する
linktitle: リストを管理
type: docs
weight: 60
url: /ja/androidjava/manage-bullet/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- 記号箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多層リスト
- 箇条書き作成
- 箇条書き追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint と OpenDocument のプレゼンテーションで箇条書きと番号付きリストを管理する方法を学びます。ステップバイステップのガイド。"
---

**Microsoft PowerPoint** では、Word やその他のテキストエディタと同様に箇条書きや番号付きリストを作成できます。**Aspose.Slides for Android via Java** も、プレゼンテーションのスライドで箇条書きや番号を使用できるようにします。

## **箇条書きを使用する理由は？**

箇条書きは情報を迅速かつ効率的に整理・提示するのに役立ちます。

**箇条書きの例**

ほとんどの場合、箇条書きは次の 3 つの主な機能を果たします。

- 読者や視聴者の注意を重要な情報へ引き付ける  
- 読者や視聴者が要点を簡単にスキャンできるようにする  
- 重要な詳細を効率的に伝達・提供する  

## **番号付きリストを使用する理由は？**

番号付きリストも情報の整理・提示に役立ちます。項目の順序（例：*ステップ 1、ステップ 2* など）が重要な場合や、項目を参照する必要がある場合（例：*ステップ 3 を参照*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下の **Creating Bullets** 手順のステップ（ステップ 1〜15）の概要です。

1. Presentation クラスのインスタンスを作成します。  
2. 複数のタスクを実行します（ステップ 3〜ステップ 14）。  
3. プレゼンテーションを保存します。  

## **箇条書きを作成する**
このトピックは、テキスト段落の管理に関するトピックシリーズの一部です。このページでは段落の箇条書き管理方法を示します。手順を踏んで箇条書きを使用すると、テキストが整理され、読みやすくなります。開発者が Aspose.Slides for Android via Java のこの小さくても強力な機能を利用できるように、以下の手順に従って段落の箇条書きを管理してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成する。  
2. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライド コレクションから目的のスライドにアクセスする。  
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) を追加する。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) にアクセスする。  
5. TextFrame 内の既定の段落を削除する。  
6. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成する。  
7. 段落の箇条書きタイプを設定する。  
8. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) に設定し、箇条書き文字を指定する。  
9. 段落テキストを設定する。  
10. 箇条書きを設定するために段落インデントを設定する。  
11. 箇条書きの色を設定する。  
12. 箇条書きの高さを設定する。  
13. 作成した段落を TextFrame の段落コレクションに追加する。  
14. 2 番目の段落を追加し、手順 **7 から 13** を繰り返す。  
15. プレゼンテーションを保存する。

以下の Java サンプルコードは、上記手順を実装してスライドに箇条書きリストを作成する方法を示しています：
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加し、取得する
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // 既定の既存段落を削除する
    txtFrm.getParagraphs().removeAt(0);
    
    // 段落を作成する
    Paragraph para = new Paragraph();
    
    // 段落の箇条書きスタイルと記号を設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 段落テキストを設定する
    para.setText("Welcome to Aspose.Slides");
    
    // 箇条書きのインデントを設定する
    para.getParagraphFormat().setIndent(25);
    
    // 箇条書きの色を設定する
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // 独自の箇条書き色を使用するために IsBulletHardColor を true に設定する
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // 箙の高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para);
    
    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **画像箇条書きを作成する**

Aspose.Slides for Android via Java は、箇条書きリストの箇条書き記号を変更できます。カスタムシンボルや画像に置き換えることが可能です。リストに視覚的な興味を加えたり、項目への注意をさらに引き付けたい場合は、独自の画像を箇条書きとして使用できます。

{{% alert color="primary" %}} 
規定の箇条書き記号を画像に置き換える場合は、透明な背景を持つシンプルなグラフィック画像を選択すると効果的です。こうした画像はカスタム箇条書き記号として最適に機能します。  
いずれにせよ、画像は非常に小さなサイズに縮小されるため、リスト内の箇条書き記号として見栄えが良い画像を選択することを強く推奨します。 
{{% /alert %}} 

画像箇条書きを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成する。  
2. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトで目的のスライドにアクセスする。  
3. 選択したスライドにオートシェイプを追加する。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスする。  
5. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 内の既定の段落を削除する。  
6. Paragraph クラスで最初の段落インスタンスを作成する。  
7. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage) でディスクから画像を読み込む。  
8. 箇条書きタイプを Picture に設定し、画像を指定する。  
9. 段落テキストを設定する。  
10. 箇条書きを設定するために段落インデントを設定する。  
11. 箇条書きの色を設定する。  
12. 箇条書きの高さを設定する。  
13. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加する。  
14. 2 番目の段落を追加し、前述の手順を繰り返す。  
15. プレゼンテーションを保存する。

以下の Java コードは、スライドに画像箇条書きを作成する方法を示しています：
```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // 箇条書き用画像をインスタンス化する
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // オートシェイプを追加し取得する
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    // 既定の既存段落を削除する
    txtFrm.getParagraphs().removeAt(0);

    // 新しい段落を作成する
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // 段落の箇条書きスタイルと画像を設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 箇条書きの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);

    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para);

    // プレゼンテーションを PPTX ファイルとして書き出す
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **階層化された箇条書きを作成する**

メインの箇条書きリストの下にサブリストを持つ、階層構造の箇条書きリストを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成する。  
2. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトで目的のスライドにアクセスする。  
3. 選択したスライドにオートシェイプを追加する。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスする。  
5. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 内の既定の段落を削除する。  
6. 段落クラスで深さ 0 の最初の段落インスタンスを作成する。  
7. 段落クラスで深さ 1 の2番目の段落インスタンスを作成する。  
8. 段落クラスで深さ 2 の3番目の段落インスタンスを作成する。  
9. 段落クラスで深さ 3 の4番目の段落インスタンスを作成する。  
10. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加する。  
11. プレゼンテーションを保存する。

以下のコードは、上記手順を実装して Java で階層化された箇条書きリストを作成する方法を示しています：
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加し取得する
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // 既定の既存段落を削除する
    txtFrm.getParagraphs().clear();
    
    // 最初の段落を作成する
    Paragraph para1 = new Paragraph();
    // 段落の箇条書きスタイルと記号を設定する
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 2 番目の段落を作成する
    Paragraph para2 = new Paragraph();
    // 段落の箇条書きスタイルと記号を設定する
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 3 番目の段落を作成する
    Paragraph para3 = new Paragraph();
    // 段落の箇条書きスタイルと記号を設定する
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 4 番目の段落を作成する
    Paragraph para4 = new Paragraph();
    // 段落の箇条書きスタイルと記号を設定する
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para4.getParagraphFormat().setDepth ((short)3);
    
    // テキストフレームに段落を追加する
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カスタム番号付きリストを作成する**
Aspose.Slides for Android via Java は、カスタム番号書式で段落を管理するシンプルな API を提供します。段落にカスタム番号リストを追加するには、次の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成する。  
2. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトで目的のスライドにアクセスする。  
3. 選択したスライドにオートシェイプを追加する。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスする。  
5. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 内の既定の段落を削除する。  
6. Paragraph クラスで最初の段落インスタンスを作成し、**NumberedBulletStartWith** を 2 に設定する。  
7. Paragraph クラスで2番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 3 に設定する。  
8. Paragraph クラスで3番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 7 に設定する。  
9. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加する。  
10. プレゼンテーションを保存する。

以下の Java コードは、スライドに番号付きリストを作成する方法を示しています：
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // オートシェイプを追加し取得する
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");

    // 既定の既存段落を削除する
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

**Aspose.Slides で作成した箇条書きや番号付きリストは、PDF や画像などの他の形式にエクスポートできますか？**

はい。Aspose.Slides は、PDF、画像などの形式にエクスポートする際、箇条書きや番号付きリストの書式と構造を完全に保持し、一貫した結果を提供します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートできますか？**

はい。Aspose.Slides は、既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持します。

**多言語で作成されたプレゼンテーションでも、箇条書きや番号付きリストはサポートされていますか？**

はい。Aspose.Slides は多言語プレゼンテーションを完全にサポートし、任意の言語や特殊文字、非ラテン文字を使用した箇条書き・番号付きリストの作成が可能です。