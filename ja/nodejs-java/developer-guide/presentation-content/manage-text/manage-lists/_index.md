---
title: JavaScript を使用したプレゼンテーションでの箇条書きと番号付きリストの管理
linktitle: リストの管理
type: docs
weight: 60
url: /ja/nodejs-java/manage-lists/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint および OpenDocument プレゼンテーションで箇条書き、画像箇条書き、階層リスト、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for Node.js via Java を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストと番号付きリストを作成および書式設定できます。リスト項目は段落であり、箇条書きの設定は段落の書式を通じて制御されます。

段落レベルのリスト設定にアクセスするには、[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) クラスを使用します。主なエントリポイントは `Paragraph.getParagraphFormat().getBullet()` で、[BulletFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、記号、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では次のことを示します：

- カスタム記号を使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して階層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式を検査および変更する

## **箇条書きリストの作成**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) オブジェクトを [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) に追加し、`BulletFormat.setType` を [BulletType.Symbol](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bullettype/) に設定します。その後、`BulletFormat.setChar`、`BulletFormat.getColor`、`BulletFormat.setHeight` を設定して箇条書きの外観を制御できます。

次の JavaScript コードは、スライドで箇条書きリストを作成する方法を示しています：

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は番号付きリストを使用します。`BulletFormat.setType` を [BulletType.Numbered](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bullettype/) に設定します。また、`BulletFormat.setNumberedBulletStyle` で番号形式を選択したり、リストを 1 以外の値から開始したい場合は `BulletFormat.setNumberedBulletStartWith` を設定できます。

次の JavaScript コードは、スライドで番号付きリストを作成する方法を示しています：

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides では、通常の箇条書き記号を画像に置き換えることができます。画像箇条書きは、小さいサイズでも可読性が保たれるシンプルな画像（アイコンや小さな透明 PNG ファイルなど）に最適です。

{{% alert color="primary" %}}
理想的には、通常の箇条書き記号を画像に置き換える場合、透明な背景を持つシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書き記号としてうまく機能します。

画像は非常に小さなサイズに縮小されることに留意してください。そのため、リストの箇条書きとして使用した際に鮮明で視覚的に効果的な画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条書きを作成するには、`Presentation.getImages().addImage` で画像を [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) に追加し、返される [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) オブジェクトを `BulletFormat.getPicture().setImage` に割り当てます。画像を割り当てる前に、`BulletFormat.setType` を [BulletType.Picture](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/bullettype/) に設定してください。

例えば、"image.png" があるとします：

![箇条書き用画像](picture_for_bullets.png)

次の JavaScript コードは、スライドで画像箇条書きを作成する方法を示しています：

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

結果：

![画像箇条書き](picture_bullets.png)

## **階層リストの作成**

`ParagraphFormat.setDepth` を使用して、リスト項目を異なるレベルに配置します。レベル0が最上位、レベル1はその下にネストされ、以下同様です。

次の JavaScript コードは、階層箇条書きリストを作成する方法を示しています：

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![階層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリストの書式を変更するには、対象の段落にアクセスし、その `ParagraphFormat.getBullet` 設定を更新します。リスト作成時に使用したのと同じプロパティを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更できます。

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**箇条書きおよび番号付きリストは PDF や画像にエクスポートできますか？**

はい。対象の形式が対応するテキストレイアウトと箇条書き機能をサポートしている場合、Aspose.Slides はリストの書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションをロードし、対象の段落にアクセスして、その `ParagraphFormat.getBullet` 設定を検査または更新し、プレゼンテーションを保存できます。

**リストにラテン文字以外のテキストを含めることはできますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。プレゼンテーションで使用するフォントが必要な文字をサポートしていることを確認してください。