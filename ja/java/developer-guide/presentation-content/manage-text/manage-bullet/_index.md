---
title: Java を使用してプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リストを管理する
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
- 階層型リスト
- 箇条書きを作成
- 箇条書きを追加
- リストを追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで箇条書きと番号付きリストを管理する方法を学びます。ステップバイステップのガイドです。"
---

**Microsoft PowerPoint**では、Word やその他のテキストエディタと同様の方法で箇条書きや番号付きリストを作成できます。**Aspose.Slides for Java**もプレゼンテーションのスライドで箇条書きや番号付きリストを使用できるようにします。 

## **箇条書きリストを使用する理由は？**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。 

**箇条書きリストの例**

ほとんどの場合、箇条書きリストは以下の3つの主な機能を果たします：

- 読者や視聴者の注意を重要な情報へ引きつける
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する。

## **番号付きリストを使用する理由は？**

番号付きリストも情報の整理と提示に役立ちます。エントリの順序（例：*step 1, step 2* など）が重要な場合や、エントリを参照する必要がある場合（例：*see step 3*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下は、**Creating Bullets** 手順のステップ（ステップ 1〜ステップ 15）の要約です：

1. Presentation クラスのインスタンスを作成します。 
2. いくつかのタスクを実行します（ステップ 3〜ステップ 14）。 
3. プレゼンテーションを保存します。 

## **箇条書きの作成**

このトピックは、テキスト段落の管理に関するシリーズの一部でもあります。このページでは段落の箇条書きを管理する方法を示します。ステップで何かを説明する場合に箇条書きは役立ちます。また、箇条書きを使用するとテキストが整理され、読みやすくなります。開発者が Aspose.Slides for Java のこの小さくても強力な機能を利用できる方法を紹介します。以下の手順に従って Aspose.Slides for Java で段落の箇条書きを管理してください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライド コレクションから目的のスライドにアクセスします。
1. 選択したスライドに AutoShape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) にアクセスします。
1. TextFrame の既定の段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成します。
1. 段落の箇条書きタイプを設定します。
1. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) に設定し、箇条書き文字を指定します。
1. 段落テキストを設定します。
1. 段落インデントを設定して箇条書きのインデントを調整します。
1. 箇条書きの色を設定します。
1. 箇条書きの高さを設定します。
1. 作成した段落を TextFrame の段落コレクションに追加します。
1. 2番目の段落を追加し、**7 から 13** の手順を繰り返します。
1. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // 既定の既存段落を削除する
    txtFrm.getParagraphs().removeAt(0);
    
    // 段落を作成する
    Paragraph para = new Paragraph();
    
    // 段落の箇条書きスタイルとシンボルを設定する
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
    
    // 箇条書きの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // 段落をテキストフレームに追加する
    txtFrm.getParagraphs().add(para);
    
    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **画像箇条書きの作成**

Aspose.Slides for Java は、箇条書きリストの箇条書きを変更できるようにします。箇条書きをカスタムシンボルや画像に置き換えることができます。リストに視覚的な興味を加えたり、項目への注目度をさらに高めたい場合は、独自の画像を箇条書きとして使用できます。 

{{% alert color="primary" %}} 

理想的には、通常の箇条書きシンボルを画像に置き換える場合、透明な背景を持つシンプルなグラフィック画像を選択するとよいでしょう。そのような画像はカスタム箇条書きシンボルとして最適に機能します。 

いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、リスト内の箇条書きシンボルの代替として見栄えが良い画像を選択することを強く推奨します。 

{{% /alert %}} 

画像箇条書きを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライド コレクションから目的のスライドにアクセスします
1. 選択したスライドに AutoShape を追加します
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) にアクセスします
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の既定の段落を削除します
1. Paragraph クラスを使用して最初の段落インスタンスを作成します
1. [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) を使用してディスクから画像をロードします
1. 箇条書きタイプを Picture に設定し、画像を指定します
1. 段落テキストを設定します
1. 段落インデントを設定して箇条書きのインデントを調整します
1. 箇条書きの色を設定します
1. 箇条書きの高さを設定します
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の段落コレクションに追加します
1. 2番目の段落を追加し、前の手順を繰り返します
1. プレゼンテーションを保存します

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

    // オートシェイプを追加してアクセスする
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

    // プレゼンテーションを PPTX ファイルとして書き込む
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **階層付き箇条書きの作成**

異なるレベルに項目を持つ箇条書きリスト（メイン箇条書きリストの下に追加リスト）を作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライド コレクションから目的のスライドにアクセスします。
1. 選択したスライドに AutoShape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の既定の段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成し、depth を 0 に設定します。
1. Paragraph クラスを使用して2番目の段落インスタンスを作成し、depth を 1 に設定します。
1. Paragraph クラスを使用して3番目の段落インスタンスを作成し、depth を 2 に設定します。
1. Paragraph クラスを使用して4番目の段落インスタンスを作成し、depth を 3 に設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // オートシェイプを追加し、アクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成したオートシェイプのテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // 既定の既存段落を削除する
    txtFrm.getParagraphs().clear();
    
    // 最初の段落を作成する
    Paragraph para1 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 二番目の段落を作成する
    Paragraph para2 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 三番目の段落を作成する
    Paragraph para3 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 四番目の段落を作成する
    Paragraph para4 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 箇条書きレベルを設定する
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


## **カスタム番号リストの作成**

Aspose.Slides for Java は、カスタム番号書式設定を伴う段落を管理するシンプルな API を提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) オブジェクトを使用してスライド コレクションから目的のスライドにアクセスします。
1. 選択したスライドに AutoShape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の既定の段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith** を 2 に設定します
1. Paragraph クラスを使用して2番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 3 に設定します
1. Paragraph クラスを使用して3番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 7 に設定します
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // オートシェイプを追加してアクセスする
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

はい、Aspose.Slides は PDF、画像、その他の形式へエクスポートする際に、箇条書きや番号付きリストの書式と構造を完全に保持し、一貫した結果を提供します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートすることは可能ですか？**

はい、Aspose.Slides は既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式と外観を保持します。

**Aspose.Slides は多言語で作成されたプレゼンテーションの箇条書きや番号付きリストをサポートしていますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートし、任意の言語で箇条書きや番号付きリストを作成でき、特殊文字や非ラテン文字の使用も可能です。