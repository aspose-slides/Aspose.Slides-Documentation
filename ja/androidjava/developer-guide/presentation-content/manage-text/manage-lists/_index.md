---
title: Android でのプレゼンテーションにおける箇条書きと番号付きリストの管理
linktitle: リストの管理
type: docs
weight: 60
url: /ja/androidjava/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多層リスト
- 箇条書きの作成
- 箇条書きの追加
- リストの追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションで箇条書き、画像箇条書き、多層リスト、番号付きリストを作成および書式設定する方法を学びます。
---
## **概要**

Aspose.Slides for Android via Java は、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストと番号付きリストを作成および書式設定できるようにします。リスト項目は、段落書式を通じて箇条書き設定が制御される段落です。

段落レベルのリスト設定にアクセスするには、[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) メソッドを使用します。メインのエントリポイントは[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)で、[IBulletFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きのタイプ、記号、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では以下の方法を示します：

- カスタム記号を使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して多層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式を検査および変更する

## **箇条書きリストの作成**

箇条書きリストを作成するには、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) に段落を追加し、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/bullettype/) に設定します。その後、[IBulletFormat.setChar](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)、[IBulletFormat.getColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#getColor--)、[IBulletFormat.setHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) を設定して箇条書きの外観を制御できます。

以下の Java コードは、スライドで箇条書きリストを作成する方法を示しています：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[IBulletFormat.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/bullettype/) に設定します。また、[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) で番号付スタイルを選択したり、リストを 1 以外の値から開始したい場合は [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を設定できます。

以下の Java コードは、スライドで番号付きリストを作成する方法を示しています：

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

結果：

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides では、通常の箇条書き記号を画像で置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="primary" %}}
理想的には、通常の箇条書き記号を画像に置き換える場合、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書き記号としてうまく機能します。

画像は非常に小さいサイズに縮小されることに留意してください。そのため、リストの箇条書きとして使用した際にも鮮明で視覚的に効果的な画像を選択することを強くお勧めします。
{{% /alert %}}

画像箇条書きを作成するには、[Presentation.getImages](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getImages--) に画像を追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトを [IBulletFormat.getPicture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#getPicture--) に割り当てます。画像を割り当てる前に、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Picture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/bullettype/) に設定します。

例えば、"image.png" があるとします：

![箇条書き用画像](picture_for_bullets.png)

以下の Java コードは、スライドで画像箇条書きを作成する方法を示しています：

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

結果：

![画像箇条書き](picture_bullets.png)

## **多層リストの作成**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) を使用してリスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされる、といった具合です。

以下の Java コードは、多層箇条書きリストを作成する方法を示しています：

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

結果：

![多層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリストの書式を変更するには、対象の段落にアクセスし、[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 設定を更新します。リスト作成時に使用したのと同じメソッドを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更できます。

以下の Java コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します：

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

はい。対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、Aspose.Slides はリストの書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションを読み込み、対象の段落にアクセスし、[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 設定を検査または更新し、プレゼンテーションを保存します。

**リストにラテン文字以外のテキストを含められますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。使用しているフォントが必要な文字をサポートしていることを確認してください。