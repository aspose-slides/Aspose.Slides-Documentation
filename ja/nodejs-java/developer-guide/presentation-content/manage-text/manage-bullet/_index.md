---
title: 箇条書きの管理
type: docs
weight: 60
url: /ja/nodejs-java/manage-bullet/
keywords: "箇条書き, 箇条書きリスト, 数字, 番号付きリスト, 画像箇条書き, 階層化箇条書き, PowerPoint プレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "PowerPoint プレゼンテーションで JavaScript を使用して箇条書きと番号付きリストを作成する"
---

**Microsoft PowerPoint** では、Word や他のテキストエディタと同様の方法で箇条書きと番号付きリストを作成できます。**Aspose.Slides for Node.js via Java** でも、プレゼンテーションのスライドで箇条書きや番号付きを使用できます。

## **箇条書きを使用する理由**

箇条書きは、情報をすばやく効率的に整理・提示するのに役立ちます。

**箇条書き例**

ほとんどの場合、箇条書きは次の 3 つの主な機能を果たします。

- 読者や視聴者の注意を重要な情報に向ける
- 読者や視聴者が要点を簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達・提示する

## **番号付きリストを使用する理由**

番号付きリストも情報の整理と提示に役立ちます。エントリの順序（例: *step 1, step 2* など）が重要な場合や、エントリを参照する必要がある場合（例: *see step 3*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリスト例**

以下の **Creating Bullets** 手順のステップ（step 1 から step 15）をまとめたものです。

1. Presentation クラスのインスタンスを作成します。  
2. 複数のタスクを実行します（step 3 から step 14）。  
3. プレゼンテーションを保存します。  

## **箇条書きの作成**

このトピックは、テキスト段落の管理に関するトピックシリーズの一部です。このページでは段落の箇条書きを管理する方法を示します。箇条書きは手順を説明する際に便利です。また、箇条書きを使用するとテキストが整然と見え、読みやすくなります。開発者が Aspose.Slides for Node.js via Java のこの小さくても強力な機能を利用する方法を見てみましょう。以下の手順に従って、Aspose.Slides for Node.js via Java を使用して段落の箇条書きを管理してください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトを使用してスライド コレクションから目的のスライドにアクセスします。  
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) を追加します。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) にアクセスします。  
5. TextFrame 内のデフォルト段落を削除します。  
6. [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) クラスを使用して最初の段落インスタンスを作成します。  
7. 段落の箇条書きタイプを設定します。  
8. 箇条書きタイプを [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) に設定し、箇条書き文字を指定します。  
9. 段落テキストを設定します。  
10. 箇条書きを設定するために段落インデントを設定します。  
11. 箇条書きの色を設定します。  
12. 箇条書きの高さを設定します。  
13. 作成した段落を TextFrame の段落コレクションに追加します。  
14. 2 番目の段落を追加し、手順 **7 から 13** を繰り返します。  
15. プレゼンテーションを保存します。

この Java のサンプルコード（上記手順の実装）は、スライドで箇条書きリストを作成する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセスする
    var slide = pres.getSlides().get_Item(0);
    // オートシェイプを追加してアクセスする
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成したオートシェイプのテキストフレームにアクセスする
    var txtFrm = aShp.getTextFrame();
    // 既定の既存段落を削除する
    txtFrm.getParagraphs().removeAt(0);
    // 段落を作成する
    var para = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルとシンボルを設定する
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // 段落テキストを設定する
    para.setText("Welcome to Aspose.Slides");
    // 箇条書きインデントを設定する
    para.getParagraphFormat().setIndent(25);
    // 箇条書きの色を設定する
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 独自の箇条書き色を使用するために IsBulletHardColor を true に設定する
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // 箇条書きの高さを設定する
    para.getParagraphFormat().getBullet().setHeight(100);
    // テキストフレームに段落を追加する
    txtFrm.getParagraphs().add(para);
    // プレゼンテーションを PPTX ファイルとして保存する
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **画像箇条書きの作成**

Aspose.Slides for Node.js via Java を使用すると、箇条書きリストの箇条書きを変更できます。カスタムシンボルや画像に置き換えることが可能です。リストに視覚的なアクセントを加えたり、エントリへの注目度をさらに高めたりしたい場合は、独自の画像を箇条書きとして使用できます。

{{% alert color="primary" %}} 
通常の箇条書きシンボルを画像に置き換える場合は、透明な背景を持つシンプルなグラフィック画像を選択するとよいでしょう。そのような画像はカスタム箇条書きシンボルとして最適です。  

いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、リスト内で箇条書きシンボルの代わりとして見栄えが良い画像を選ぶことを強くおすすめします。 
{{% /alert %}} 

画像箇条書きを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトで目的のスライドにアクセスします。  
3. 選択したスライドに autoshape を追加します。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) にアクセスします。  
5. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) 内のデフォルト段落を削除します。  
6. Paragraph クラスを使用して最初の段落インスタンスを作成します。  
7. [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage) でディスクから画像を読み込みます。  
8. 箇条書きタイプを Picture に設定し、画像を指定します。  
9. 段落テキストを設定します。  
10. 箇条書きを設定するために段落インデントを設定します。  
11. 箇条書きの色を設定します。  
12. 箇条書きの高さを設定します。  
13. 作成した段落を [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) の段落コレクションに追加します。  
14. 2 番目の段落を追加し、前の手順を繰り返します。  
15. プレゼンテーションを保存します。

この JavaScript コードは、スライドで画像箇条書きを作成する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // 箇条書き用画像をインスタンス化
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // オートシェイプを追加してアクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成したオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.getTextFrame();
    // 既定の既存段落を削除
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
    // プレゼンテーションを PPTX ファイルとして書き出し
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **階層化箇条書きの作成**

メインの箇条書きリストの下にサブリストを持つ、階層化された箇条書きリストを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトで目的のスライドにアクセスします。  
3. 選択したスライドに autoshape を追加します。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) にアクセスします。  
5. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) 内のデフォルト段落を削除します。  
6. Paragraph クラスを使用し、depth を 0 に設定して最初の段落インスタンスを作成します。  
7. Paragraph クラスを使用し、depth を 1 に設定して 2 番目の段落インスタンスを作成します。  
8. Paragraph クラスを使用し、depth を 2 に設定して 3 番目の段落インスタンスを作成します。  
9. Paragraph クラスを使用し、depth を 3 に設定して 4 番目の段落インスタンスを作成します。  
10. 作成した段落を [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) の段落コレクションに追加します。  
11. プレゼンテーションを保存します。

上記手順の実装例であるこのコードは、JavaScript で階層化箇条書きリストを作成する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // オートシェイプを追加してアクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成したオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.addTextFrame("");
    // 既定の既存段落を削除
    txtFrm.getParagraphs().clear();
    // 最初の段落を作成
    var para1 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルと記号を設定
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para1.getParagraphFormat().setDepth(0);
    // 2 番目の段落を作成
    var para2 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルと記号を設定
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para2.getParagraphFormat().setDepth(1);
    // 3 番目の段落を作成
    var para3 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルと記号を設定
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para3.getParagraphFormat().setDepth(2);
    // 4 番目の段落を作成
    var para4 = new aspose.slides.Paragraph();
    // 段落の箇条書きスタイルと記号を設定
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 箇条書きレベルを設定
    para4.getParagraphFormat().setDepth(3);
    // 段落をテキストフレームに追加
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


## **カスタム番号リストの作成**

Aspose.Slides for Node.js via Java は、カスタム番号書式で段落を管理するシンプルな API を提供します。段落にカスタム番号リストを追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) オブジェクトで目的のスライドにアクセスします。  
3. 選択したスライドに autoshape を追加します。  
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) にアクセスします。  
5. [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) 内のデフォルト段落を削除します。  
6. Paragraph クラスを使用し、**NumberedBulletStartWith** を 2 に設定して最初の段落を作成します。  
7. Paragraph クラスを使用し、**NumberedBulletStartWith** を 3 に設定して 2 番目の段落を作成します。  
8. Paragraph クラスを使用し、**NumberedBulletStartWith** を 7 に設定して 3 番目の段落を作成します。  
9. 作成した段落を [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) の段落コレクションに追加します。  
10. プレゼンテーションを保存します。

この JavaScript コードは、スライドで番号付きリストを作成する方法を示しています:
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
    // オートシェイプを追加してアクセス
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // 作成したオートシェイプのテキストフレームにアクセス
    var txtFrm = aShp.addTextFrame("");
    // 既定の既存段落を削除
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

**Aspose.Slides で作成した箇条書きや番号付きリストは、PDF や画像など他の形式にエクスポートできますか？**

はい。Aspose.Slides は、PDF、画像などの形式にエクスポートする際に、箇条書きや番号付きリストの書式と構造を完全に保持し、一貫した結果を提供します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートすることはできますか？**

はい。Aspose.Slides は、既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持します。

**複数言語で作成されたプレゼンテーションでも、箇条書きや番号付きリストはサポートされますか？**

はい。Aspose.Slides は多言語プレゼンテーションを完全にサポートし、任意の言語で箇条書きや番号付きリストを作成でき、特殊文字や非ラテン文字も使用可能です。