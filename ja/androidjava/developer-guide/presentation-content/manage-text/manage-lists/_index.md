---
title: Android でプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リストを管理する
type: docs
weight: 60
url: /ja/androidjava/manage-lists/
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument プレゼンテーションで箇条書き、画像箇条書き、多層リスト、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストおよび番号付きリストを作成および書式設定できます。リスト項目は、段落書式で箇条書き設定が制御される段落です。

[ IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) メソッドを使用して段落レベルのリスト設定にアクセスします。主要なエントリポイントは[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) で、[IBulletFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、記号、画像、色、サイズ、番号付けスタイル、開始番号を設定できます。

この記事では以下を示します。

- カスタム記号を使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して階層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリスト書式を検査および変更する

## **箇条書きリストの作成**

箇条書きリストを作成するには、[ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) に段落を追加し、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/bullettype/) に設定します。その後、[IBulletFormat.setChar](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)、[IBulletFormat.getColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#getColor--)、[IBulletFormat.setHeight](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) を設定して箇条書きの外観を制御できます。

次の Java コードはスライドで箇条書きリストを作成する方法を示しています。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![シンボルの箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は番号付きリストを使用します。[IBulletFormat.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/bullettype/) に設定します。また、[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) で番号付け形式を選択したり、リストを 1 以外の値から開始したい場合は [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を設定できます。

次の Java コードはスライドで番号付きリストを作成する方法を示しています。

```java
import com.aspose.slides.*;

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

Aspose.Slides は通常の箇条書き記号を画像で置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="info" %}}
理想的には、通常の箇条書き記号を画像に置き換える場合、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書き記号としてうまく機能します。
{{% /alert %}}

画像は非常に小さなサイズに縮小されることに留意してください。そのため、リスト内の箇条書きとして使用したときに鮮明さと視覚的な効果を保てる画像を選択することを強く推奨します。

画像箇条書きを作成するには、[Presentation.getImages](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#getImages--) に画像を追加し、返された [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトを [IBulletFormat.getPicture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#getPicture--) に割り当てます。画像を割り当てる前に、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Picture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/bullettype/) に設定してください。

例として "image.png" があるとします:

![箇条書き用画像](picture_for_bullets.png)

次の Java コードはスライドで画像箇条書きを作成する方法を示しています。

```java
import com.aspose.slides.*;

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

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) を使用してリスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされる、といった具合です。

次の Java コードは多層リストを作成する方法を示しています。

```java
import com.aspose.slides.*;

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

既存のプレゼンテーションでリスト書式を変更するには、対象の段落にアクセスし、その [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 設定を更新します。リスト作成時に使用した同じメソッドを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更できます。

次の Java コードはテキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```java
import com.aspose.slides.*;

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

## **よくある質問**

### 箇条書きと番号付きリストは PDF または画像にエクスポートできますか？

はい。Aspose.Slides は、対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、リスト書式を保持したままエクスポートします。

### 既存のプレゼンテーションでリストを編集できますか？

はい。プレゼンテーションをロードし、対象の段落にアクセスして [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 設定を検査または更新し、プレゼンテーションを保存できます。

### リストにラテン文字以外のテキストを含めることはできますか？

はい。リスト項目のテキストは Unicode 文字を含むことができるため、多言語プレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。