---
title: Java でプレゼンテーションの箇条書きおよび番号付きリストを管理する
linktitle: リストの管理
type: docs
weight: 60
url: /ja/java/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多階層リスト
- 箇条書き作成
- 箇条書き追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションで箇条書き、画像、多階層、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Java は、PowerPoint および OpenDocument プレゼンテーションで箇条書きと番号付きリストを作成および書式設定できます。リスト項目は、段落の書式設定を通じて箇条書き設定が制御される段落です。

Use the [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/#getParagraphFormat--) メソッドで段落レベルのリスト設定にアクセスします。主なエントリポイントは [IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getBullet--) で、[IBulletFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きのタイプ、シンボル、画像、色、サイズ、番号付けスタイル、開始番号を設定できます。

この記事では次のことを示します。

- カスタムシンボルを使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して多階層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式設定を検査および変更する

## **箇条書きリストの作成**

箇条書きリストを作成するには、[IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) オブジェクトを [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) に追加し、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/#Symbol) に設定します。その後、[IBulletFormat.setChar](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setChar-char-)、[IBulletFormat.getColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#getColor--)、[IBulletFormat.setHeight](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setHeight-float-) を設定して箇条書きの外観を制御できます。

以下の Java コードは、スライド内で箇条書きリストを作成する方法を示しています。

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

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/#Numbered) に設定します。また、[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) で番号付け形式を選択したり、リストを 1 以外の値から開始したい場合は [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) を設定できます。

以下の Java コードは、スライド内で番号付きリストを作成する方法を示しています。

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

Aspose.Slides は、通常の箇条書きシンボルを画像に置き換えることを可能にします。画像箇条書きは、アイコンや小さな透明 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="info" %}}
理想的には、通常の箇条書きシンボルを画像に置き換える場合は、透明な背景を持つシンプルなグラフィックを選択するのが最良です。そのような画像はカスタム箇条書きシンボルとしてうまく機能します。

画像は非常に小さいサイズに縮小されることに留意してください。そのため、リスト内の箇条書きとして使用したときに鮮明さと視覚的有効性が保たれる画像を選択することを強くお勧めします。
{{% /alert %}}

画像箇条書きを作成するには、[Presentation.getImages](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#getImages--) に画像を追加し、返された画像オブジェクトを [IBulletFormat.getPicture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#getPicture--) に割り当てます。画像を割り当てる前に、[IBulletFormat.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibulletformat/#setType-byte-) を [BulletType.Picture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/bullettype/#Picture) に設定します。

たとえば、"image.png" という画像があるとします:

![箇条書き用の画像](picture_for_bullets.png)

以下の Java コードは、スライド内で画像箇条書きを作成する方法を示しています。

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

## **多階層リストの作成**

[IParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#setDepth-short-) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされるという形になります。

以下の Java コードは、多階層箇条書きリストを作成する方法を示しています。

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

![多階層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリストの書式設定を変更するには、対象の段落にアクセスし、[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getBullet--) 設定を更新します。リストを作成する際に使用したのと同じプロパティを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更できます。

以下の Java コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

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

### 箇条書きと番号付きリストは PDF や画像にエクスポートできますか？

はい。Aspose.Slides は、対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、リストの書式設定を保持したままエクスポートします。

### 既存のプレゼンテーションでリストを編集できますか？

はい。プレゼンテーションを読み込み、対象の段落にアクセスし、[IParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraphformat/#getBullet--) 設定を検査または更新して、プレゼンテーションを保存できます。

### リストに非ラテン文字テキストを含めることはできますか？

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。