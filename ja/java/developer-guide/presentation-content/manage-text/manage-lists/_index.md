---
title: Java でプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リストの管理
type: docs
weight: 60
url: /ja/java/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- 記号箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多層リスト
- 箇条書きの作成
- 箇条書きの追加
- リストの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで、箇条書き、画像箇条書き、多層、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Java を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストや番号付きリストを作成および書式設定できます。リスト項目は、段落形式で箇条書き設定が制御される段落です。

[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getParagraphFormat--) メソッドを使用して段落レベルのリスト設定にアクセスします。主なエントリーポイントは[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getBullet--) で、[IBulletFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、記号、画像、色、サイズ、番号付けスタイル、開始番号を設定できます。

この記事では以下を説明します。

- カスタム記号による箇条書きリストの作成
- 画像箇条書きの作成
- 段落の深さを設定しての多層リストの作成
- 番号付きリストの作成
- 既存のプレゼンテーションでリスト書式を調査および変更する方法

## **箇条書きリストの作成**

箇条書きリストを作成するには、[IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) オブジェクトを[ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) に追加し、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-byte-) を[BulletType.Symbol](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/#Symbol) に設定します。その後、[IBulletFormat.setChar](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setChar-char-)、[IBulletFormat.getColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#getColor--)、[IBulletFormat.setHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setHeight-float-) を設定して箇条書きの外観を制御できます。

以下の Java コードは、スライドで箇条書きリストを作成する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![記号箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は番号付きリストを使用します。[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-byte-) を[BulletType.Numbered](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/#Numbered) に設定します。また、[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) で番号付け形式を選択したり、[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を使用してリストの開始番号を 1 以外に設定したりできます。

以下の Java コードは、スライドで番号付きリストを作成する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides を使用すると、通常の箇条書き記号を画像に置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="primary" %}}
理想的には、通常の箇条書き記号を画像で置き換える場合、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書き記号としてうまく機能します。

画像は非常に小さなサイズに縮小されます。そのため、リスト内の箇条書きとして使用したときに鮮明さと視認性が保たれる画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条書きを作成するには、[Presentation.getImages](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getImages--) に画像を追加し、返された画像オブジェクトを[IBulletFormat.getPicture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#getPicture--) に割り当てます。画像を割り当てる前に、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-byte-) を[BulletType.Picture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/#Picture) に設定してください。

たとえば "image.png" があるとします。

![箇条書き用の画像](picture_for_bullets.png)

以下の Java コードは、スライドで画像箇条書きを作成する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![画像箇条書き](picture_bullets.png)

## **多層リストの作成**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDepth-short-) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位、レベル 1 がその下位、というように階層化されます。

以下の Java コードは、多層箇条書きリストを作成する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![多層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリスト書式を変更するには、対象の段落にアクセスし、その[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getBullet--) 設定を更新します。リスト作成時に使用したプロパティは、PPT、PPTX、ODP ファイルからロードしたリストを調査または変更する際にも使用できます。

以下の Java コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**箇条書きおよび番号付きリストは PDF や画像にエクスポートできますか？**

はい。Aspose.Slides は、対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、リスト書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションをロードし、対象の段落にアクセスして[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getBullet--) 設定を調査または更新し、プレゼンテーションを保存します。

**リストに非ラテン文字を含めることは可能ですか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。