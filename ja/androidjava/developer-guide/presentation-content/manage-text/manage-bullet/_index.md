---
title: Android のプレゼンテーションで箇条書きと番号付きリストを管理する
linktitle: リストの管理
type: docs
weight: 60
url: /ja/androidjava/manage-bullet/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 階層リスト
- 箇条書き作成
- 箇条書き追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで箇条書きと番号付きリストを管理する方法を学びます。ステップバイステップガイド。"
---

**Microsoft PowerPoint** では、Word やその他のテキストエディタと同じ方法で箇条書きリストと番号付きリストを作成できます。**Aspose.Slides for Android via Java** でも、プレゼンテーションのスライドで箇条書きや番号を使用できます。

## **箇条書きリストを使用する理由**

箇条書きリストは、情報を迅速かつ効率的に整理し、提示するのに役立ちます。

**箇条書きリストの例**

ほとんどの場合、箇条書きリストは次の3つの主な機能を果たします。

- 読者や視聴者の注意を重要な情報へ引きつけます
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにします
- 重要な詳細を効率的に伝達します。

## **番号付きリストを使用する理由**

番号付きリストも情報の整理と提示に役立ちます。エントリの順序（例: *step 1, step 2* など）が重要な場合や、エントリを参照する必要がある場合（例: *see step 3*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下は **Creating Bullets** 手順（ステップ 1 からステップ 15） の概要です。

1. プレゼンテーション クラスのインスタンスを作成します。
2. 複数のタスクを実行します（ステップ 3 からステップ 14）。
3. プレゼンテーションを保存します。

## **箇条書きを作成する**

このトピックは、テキスト段落の管理に関するシリーズの一部でもあります。このページでは、段落の箇条書きを管理する方法を示します。手順で何かを説明する場合、箇条書きは非常に便利です。さらに、箇条書きを使用するとテキストが整理されて見やすくなります。箇条書き段落は常に読みやすく理解しやすいです。開発者が Aspose.Slides for Android via Java のこの小さくも強力な機能をどのように使用できるかをご覧ください。以下の手順に従って Aspose.Slides for Android via Java を使用して段落の箇条書きを管理してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) にアクセスします。
1. TextFrame 内のデフォルトの段落を削除します。
1. [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成します。
1. 段落の箇条書きタイプを設定します。
1. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) に設定し、箇条書き文字を設定します。
1. 段落テキストを設定します。
1. 箇条書きを設定するために段落インデントを設定します。
1. 箇条書きの色を設定します。
1. 箇条書きの高さを設定します。
1. 作成した段落を TextFrame の段落コレクションに追加します。
1. 2 番目の段落を追加し、ステップ **7 から 13** のプロセスを繰り返します。
1. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape を追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // デフォルトの既存段落を削除する
    txtFrm.getParagraphs().removeAt(0);
    
    // 段落を作成する
    Paragraph para = new Paragraph();
    
    // 段落の箇条書きスタイルとシンボルを設定する
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 段落テキストを設定する
    para.setText("Welcome to Aspose.Slides");
    
    // 箇条書きインデントを設定する
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


## **画像箇条書きを作成する**

Aspose.Slides for Android via Java を使用すると、箇条書きリストの箇条書きを変更できます。箇条書きをカスタムシンボルや画像に置き換えることができます。リストに視覚的な興味を加えたり、リスト項目への注目度をさらに高めたい場合は、独自の画像を箇条書きとして使用できます。

{{% alert color="primary" %}} 
理想的には、通常の箇条書きシンボルを画像に置き換える場合は、透明な背景を持つシンプルなグラフィック画像を選択するとよいでしょう。そのような画像はカスタム箇条書きシンボルとして最適です。 

いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、リスト内で箇条書きシンボルの代替として見栄えの良い画像を選択することを強くお勧めします。 
{{% /alert %}} 

画像箇条書きを作成するには、以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) のデフォルト段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成します。
1. [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage) を使用してディスクから画像をロードします。
1. 箇条書きタイプを Picture に設定し、画像を設定します。
1. 段落テキストを設定します。
1. 箇条書きを設定するために段落インデントを設定します。
1. 箇条書きの色を設定します。
1. 箇条書きの高さを設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加します。
1. 2 番目の段落を追加し、前の手順で示されたプロセスを繰り返します。
1. プレゼンテーションを保存します。

```java
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // 箇条書き用の画像をインスタンス化する
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // AutoShape を追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.getTextFrame();
    // デフォルトの既存段落を削除する
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

    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **階層化箇条書きを作成する**

異なるレベルの項目（メイン箇条書きリストの下に追加リスト）を含む箇条書きリストを作成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) のデフォルト段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成し、depth を 0 に設定します。
1. Paragraph クラスを使用して第2の段落インスタンスを作成し、depth を 1 に設定します。
1. Paragraph クラスを使用して第3の段落インスタンスを作成し、depth を 2 に設定します。
1. Paragraph クラスを使用して第4の段落インスタンスを作成し、depth を 3 に設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);
    
    // AutoShape を追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");
    // デフォルトの既存段落を削除する
    txtFrm.getParagraphs().clear();
    
    // 最初の段落を作成する
    Paragraph para1 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 2 番目の段落を作成する
    Paragraph para2 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 3 番目の段落を作成する
    Paragraph para3 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 4 番目の段落を作成する
    Paragraph para4 = new Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //箇条書きレベルを設定する
    para4.getParagraphFormat().setDepth ((short)3);
    
    // 段落をテキストフレームに追加する
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

Aspose.Slides for Android via Java は、カスタム番号書式設定を使用した段落を管理するシンプルな API を提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) オブジェクトを使用してスライドコレクション内の目的のスライドにアクセスします。
1. 選択したスライドに autoshape を追加します。
1. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) にアクセスします。
1. [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) のデフォルト段落を削除します。
1. Paragraph クラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith** を 2 に設定します。
1. Paragraph クラスを使用して第2 の段落インスタンスを作成し、**NumberedBulletStartWith** を 3 に設定します。
1. Paragraph クラスを使用して第3 の段落インスタンスを作成し、**NumberedBulletStartWith** を 7 に設定します。
1. 作成した段落を [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) の段落コレクションに追加します。
1. プレゼンテーションを保存します。

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    // 最初のスライドにアクセスする
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape を追加してアクセスする
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセスする
    ITextFrame txtFrm = aShp.addTextFrame("");

    // デフォルトの既存段落を削除する
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

**Aspose.Slides で作成した箇条書きおよび番号付きリストは、PDF や画像などの他の形式にエクスポートできますか？**

はい、Aspose.Slides は、プレゼンテーションを PDF、画像などの形式にエクスポートする際に、箇条書きおよび番号付きリストの書式と構造を完全に保持し、一貫した結果を保証します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートすることは可能ですか？**

はい、Aspose.Slides は、既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持します。

**Aspose.Slides は、複数言語で作成されたプレゼンテーションの箇条書きおよび番号付きリストをサポートしますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートしており、特殊文字や非ラテン文字を含む任意の言語で箇条書きおよび番号付きリストを作成できます。