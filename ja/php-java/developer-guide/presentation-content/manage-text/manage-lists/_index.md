---
title: PHP を使用してプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リスト管理
type: docs
weight: 60
url: /ja/php-java/manage-lists/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument プレゼンテーション内で箇条書き、画像、階層、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストと番号付きリストを作成および書式設定できます。リスト項目は、段落書式を通じて箇条書き設定が制御される段落です。

段落レベルのリスト設定にアクセスするには、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getParagraphFormat--) メソッドを使用します。主なエントリポイントは[ParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getBullet--)で、[BulletFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、シンボル、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では、以下の方法を示します。

- カスタムシンボルを使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して階層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式を検査および変更する

## **箇条書きリストを作成する**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) オブジェクトを [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) に追加し、[BulletFormat.setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/#Symbol) に設定します。その後、[BulletFormat.setChar](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setChar-char-)、[BulletFormat.getColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#getColor--)、[BulletFormat.setHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setHeight-float-) を設定して、箇条書きの外観を制御できます。

以下の PHP コードは、スライド内に箇条書きリストを作成する方法を示しています。

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストを作成する**

項目の順序が重要な場合は、番号付きリストを使用します。[BulletFormat.setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/#Numbered) に設定します。また、[BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) で番号付スタイルを選択したり、リストの開始番号を 1 以外にしたい場合は [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) を設定できます。

以下の PHPコードは、スライド内に番号付きリストを作成する方法を示しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きを作成する**

Aspose.Slides を使用すると、通常の箇条書きシンボルを画像に置き換えることができます。画像箇条書きは、アイコンや小さい透過 PNG ファイルなど、小さなサイズでも読みやすいシンプルな画像で最適に機能します。

{{% alert color="primary" %}}
理想的には、通常の箇条書きシンボルを画像に置き換える場合は、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書きシンボルとしてうまく機能します。

画像は非常に小さなサイズに縮小されることに留意してください。そのため、リストの箇条書きとして使用したときに鮮明で視覚的に効果的な画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条書きを作成するには、画像を [Presentation.getImages](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getImages--) に追加し、返された [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) オブジェクトを [BulletFormat.getPicture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#getPicture--) に割り当てます。画像を割り当てる前に、[BulletFormat.setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-) を [BulletType.Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/#Picture) に設定してください。

例えば "image.png" があるとします：

![箇条書き用の画像](picture_for_bullets.png)

以下の PHP コードは、スライド内に画像箇条書きを作成する方法を示しています。

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![画像箇条書き](picture_bullets.png)

## **階層リストを作成する**

[ParagraphFormat.setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDepth-short-) を使用して、リスト項目を異なるレベルに配置します。レベル0が最上位レベル、レベル1がその下にネストされる、といった具合です。

以下の PHP コードは、階層的な箇条書きリストを作成する方法を示しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![階層リスト](multilevel_list.png)

## **既存のリストを変更する**

既存のプレゼンテーションでリストの書式を変更するには、対象の段落にアクセスし、その [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getBullet--) 設定を更新します。リスト作成時に使用したのと同じプロパティを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更できます。

以下の PHP コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**箇条書きリストと番号付きリストは PDF や画像にエクスポートできますか？**

はい。対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、Aspose.Slides はリストの書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションをロードし、対象の段落にアクセスして、その [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#getBullet--) 設定を検査または更新し、プレゼンテーションを保存します。

**リストにラテン文字以外のテキストを含めることはできますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。プレゼンテーションで使用するフォントが必要な文字をサポートしていることを確認してください。