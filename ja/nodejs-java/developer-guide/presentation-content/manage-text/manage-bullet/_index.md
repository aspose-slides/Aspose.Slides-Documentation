---
title: JavaScript を使用してプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リストの管理
type: docs
weight: 60
url: /ja/nodejs-java/manage-bullet/
keywords:
- 箇条書き
-箇条書きリスト
-番号付きリスト
-シンボル箇条書き
-画像箇条書き
-カスタム箇条書き
-階層化リスト
-箇条書き作成
-箇条書き追加
-リスト追加
-PowerPoint
-OpenDocument
-プレゼンテーション
-Node.js
-JavaScript
-Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、JavaScript で PowerPoint および OpenDocument のプレゼンテーションにおける箇条書きと番号付きリストの管理方法を学びます。ステップバイステップのガイドです。"
---

In **Microsoft PowerPoint** では、Word や他のテキストエディタと同様に、箇条書きと番号付きリストを作成できます。**Aspose.Slides for Node.js via Java** でも、プレゼンテーションのスライドで箇条書きと番号を使用できます。

## **箇条書きリストを使用する理由**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。

**箇条書きリストの例**

ほとんどの場合、箇条書きリストは次の3つの主な機能を果たします。

- 読者や視聴者の注意を重要な情報に引きつけます
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにします
- 重要な詳細を効率的に伝達します。

## **番号付きリストを使用する理由**

番号付きリストも情報の整理と提示に役立ちます。エントリの順序（例：*ステップ 1、ステップ 2* など）が重要な場合、またはエントリを参照する必要がある場合（例：*ステップ 3 を参照*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下の **Creating Bullets** 手順におけるステップ（ステップ 1 からステップ 15） の概要です。

1. プレゼンテーション クラスのインスタンスを作成します。
2. 複数のタスクを実行します（ステップ 3 からステップ 14）。
3. プレゼンテーションを保存します。

## **箇条書きの作成**

このトピックは、テキスト段落の管理に関するシリーズの一部です。このページでは、段落の箇条書きを管理する方法を示します。手順で何かを説明する際に箇条書きは非常に便利です。また、箇条書きを使用するとテキストが整理され、読みやすくなります。開発者が Aspose.Slides for Node.js via Java のこの小さくても強力な機能をどのように利用できるかを見てみましょう。以下の手順に従って、Aspose.Slides for Node.js via Java を使用して段落の箇条書きを管理してください：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) にアクセスします。
5. TextFrame のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成します。
7. 段落の箇条書きタイプを設定します。
8. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) に設定し、箇条書き文字を指定します。
9. 段落テキストを設定します。
10. 段落のインデントを設定して箇条書きを調整します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 作成した段落を TextFrame の段落コレクションに追加します。
14. 2 番目の段落を追加し、ステップ **7 から 13** の手順を繰り返します。
15. プレゼンテーションを保存します。

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // オートシェイプを追加し、アクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成されたオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.getTextFrame();
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().removeAt(0);
    // 段落を作成
    var para = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 段落テキストを設定
    para.setText("Welcome to Aspose.Slides");
    // 箇条書きインデントを設定
    para.getParagraphFormat().setIndent(25);
    // 箇条書きの色を設定
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 独自の箇条書き色を使用するために IsBulletHardColor を true に設定
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);
    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para);
    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **画像箇条書きの作成**

Aspose.Slides for Node.js via Java は、箇条書きリストの箇条書き記号を変更できる機能を提供します。カスタムシンボルや画像で箇条書きを置き換えることができます。リストに視覚的なアクセントを加えたり、項目への注目度を高めたい場合は、独自の画像を箇条書きとして使用できます。

{{% alert color="primary" %}} 
理想的には、通常の箇条書き記号を画像で置き換える場合、透明な背景を持つシンプルなグラフィック画像を選択するとよいでしょう。そのような画像はカスタム箇条書き記号として最適です。 
いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、リスト内の箇条書き記号の代替として見栄えの良い画像を選択することを強く推奨します。 
{{% /alert %}} 

画像箇条書きを作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
3. 選択したスライドに autoshape を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) にアクセスします。
5. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) のデフォルトの段落を削除します。
6. Paragraph クラスを使用して最初の段落インスタンスを作成します。
7. ディスクから画像を [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) にロードします。
8. 箇条書きタイプを Picture に設定し、画像を指定します。
9. 段落テキストを設定します。
10. 段落のインデントを設定して箇条書きを調整します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 作成した段落を [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) の段落コレクションに追加します。
14. 2 番目の段落を追加し、前の手順を繰り返します。
15. プレゼンテーションを保存します。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // 箇条書き用の画像をインスタンス化
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // オートシェイプを追加し、アクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成されたオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.getTextFrame();
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().removeAt(0);
    // 新しい段落を作成
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // 段落の箇条書きスタイルと画像を設定
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // 箇条書きの高さを設定
    para.getParagraphFormat().getBullet().setHeight(100);
    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para);
    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **階層化箇条書きの作成**

異なるレベルの項目（メインの箇条書きリストの下に追加リスト）を含む箇条書きリストを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
3. 選択したスライドに autoshape を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) にアクセスします。
5. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) のデフォルトの段落を削除します。
6. Paragraph クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. Paragraph クラスを使用して2番目の段落インスタンスを作成し、深さを 1 に設定します。
8. Paragraph クラスを使用して3番目の段落インスタンスを作成し、深さを 2 に設定します。
9. Paragraph クラスを使用して4番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 作成した段落を [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) の段落コレクションに追加します。
11. プレゼンテーションを保存します。

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // オートシェイプを追加し、アクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成されたオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.addTextFrame("");
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().clear();
    // 最初の段落を作成
    var para1 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth(0);
    // 2 番目の段落を作成
    var para2 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth(1);
    // 3 番目の段落を作成
    var para3 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth(2);
    // 4 番目の段落を作成
    var para4 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para4.getParagraphFormat().setDepth(3);
    // テキストフレームに段落を追加
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // プレゼンテーションを PPTX ファイルとして保存
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **カスタム番号付きリストの作成**

Aspose.Slides for Node.js via Java は、カスタム番号形式で段落を管理するためのシンプルな API を提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトを使用して、スライドコレクション内の目的のスライドにアクセスします。
3. 選択したスライドに autoshape を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) にアクセスします。
5. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) のデフォルトの段落を削除します。
6. Paragraph クラスを使用して最初の段落インスタンスを作成し、**NumberedBulletStartWith** を 2 に設定します。
7. Paragraph クラスを使用して2番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 3 に設定します。
8. Paragraph クラスを使用して3番目の段落インスタンスを作成し、**NumberedBulletStartWith** を 7 に設定します。
9. 作成した段落を [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) の段落コレクションに追加します。
10. プレゼンテーションを保存します。

```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // オートシェイプを追加し、アクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成されたオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.addTextFrame("");
    // デフォルトの既存段落を削除
    txtFrm.getParagraphs().clear();
    // 最初のリスト
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // 2 番目のリスト
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Aspose.Slides で作成した箇条書きおよび番号付きリストは、PDF や画像などの他の形式にエクスポートできますか？**

はい、Aspose.Slides は、PDF、画像などの形式にプレゼンテーションをエクスポートする際、箇条書きおよび番号付きリストの書式と構造を完全に保持し、一貫した結果を提供します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートすることは可能ですか？**

はい、Aspose.Slides は既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持します。

**Aspose.Slides は、複数言語で作成されたプレゼンテーションの箇条書きや番号付きリストをサポートしていますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートしており、任意の言語で箇条書きや番号付きリストを作成でき、特殊文字や非ラテン文字の使用も可能です。