---
title: PHPでPowerPointテキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTMLのインポート
- テキストをHTMLに変換
- 段落をHTMLに変換
- 段落を画像に変換
- テキストを画像に変換
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTMLコンテンツ、段落画像の作成と書式設定の方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、テキストをテキストフレーム、段落、ポーションの階層として表します。

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) は、シェイプ内のテキストコンテナを表し、その段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) は、テキストフレーム内の1つの段落を表し、そのポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) は、段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用して、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

シェイプのテキストフレーム内に段落を作成し、ポーションを使用して個々のテキストランに書式を設定します。このセクションでは、各段落内で複数のポーションを組み合わせ、異なる色、フォントサイズ、スタイルを適用する方法を示します。

### **複数ポーションで段落を作成**

次の PHP の例は、[Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions) が返すコレクション内に 3 つのテキストランを含む 3 つの段落を作成します。デフォルトの段落と空のポーションを再利用し、残りの段落とポーションを追加します。書式設定は [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) を通じて適用されます。各段落の最初のポーションは赤、太字、15 ポイント、2 番目は青、斜体、18 ポイントです。3 番目のポーションはデフォルトの書式設定を保持します：

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **箇条書きと番号付きリストの作成**

段落テキストを記号、番号、またはカスタム画像を使用したリストに整理します。このセクションの例では、箇条書きの書式設定、多層リスト、カスタム開始番号をカバーします。

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けにより、関連項目を簡単にスキャンできるようになります。Aspose.Slides では、リスト設定は [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) を通じて定義されます。

この PHP の例は、同じテキストフレームにシンボル箇条書きと番号付き項目を追加します。[BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) は箇条書きのタイプを選択し、[BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) がシンボルを提供し、[BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) が番号付けスタイルを選択します。両方の項目は高さ 100% の黒い箇条書きを使用し、段落インデントは 25 ポイントです：

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **画像箇条書きの使用**

画像箇条書きを使用すると、記号や数字の代わりにカスタム画像を利用できます。

この PHP の例は、プレゼンテーションの画像コレクションに画像を [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) として追加し、段落箇条書きとして使用します。[BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) を呼び出して画像箇条書きを使用し、画像は [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) で割り当てます。[BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) は 100% に設定され、段落テキストに対する箇条書きのサイズが決まります：

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **多層リストの作成**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) を設定して、リストの異なるレベルに段落を配置します。最上位レベルの深さは `0` です。

この PHP の例は、[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) の値を 0 から 3 まで 4 つの段落に割り当て、1 つのテキストフレーム内に階層を作成します。各段落はシンボル箇条書きを使用し、[BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) が丸い箇条書きとハイフンを交互に使用して隣接レベルを区別します：

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **カスタム値で番号付きリスト項目を開始**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) を使用して、番号付き段落の最初に表示される番号を設定します。

この PHP の例は、3 つの段落に対して番号付けを使用するように [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) を設定し、[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) の値をそれぞれ 2、3、7 に設定します。開始値は段落ごとに個別に構成でき、表示される番号をスキップさせることが可能です：

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **段落のレイアウトと終端プロパティの制御**

段落の余白とインデントを調整して、最初の行と折り返し行の位置を制御します。また、表示テキストのポーションとは別に段落終端マークの書式設定も可能です。

### **最初の行のインデントを設定**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) メソッドを使用して段落の最初の行のインデントを制御します。この設定は段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右方向にシフトし、残りの行は段落本体に揃ったままです。

全体の段落を移動する必要がある場合は [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) を使用します。最初の行だけを移動したいときは [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) を使用します。

次の例は、3 つの段落すべてに同じ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) 20 ポイントと、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) の値を 0、20、40 ポイントで設定します。最初の行は徐々に大きなオフセットで開始し、折り返し行は同じ左余白を保持します：

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落の最初の行インデント](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行の左側から開始する段落レイアウトです。Aspose.Slides では、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) プロパティでこの効果を作成します。`Indent` に負の値を設定すると、段落本体に対して最初の行が左に移動します。

実際には、[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) が段落本体の左位置を定義し、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式は、参考文献、引用、用語集エントリ、その他折り返し行が段落本体の下に揃える必要がある段落で役立ちます。

次の PHP の例は、[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) の値を 40 と 60 ポイント、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) の値を -20 と -30 ポイントで組み合わせます。各段落で最初の行は折り返し行の左側から開始し、2 番目の段落はより深いハンギングインデントになります：

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果:

![段落のハンギングインデント](hanging_indent.png)

### **段落終端ラン属性の設定**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) メソッドは段落終端マークの書式設定を制御します。次の例は、[PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) を作成し、[BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) を 48 ポイント、[BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) を Times New Roman に設定します。この書式を 2 番目の段落の終端マークに割り当て、表示テキストのポーションは変更しません：

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **レンダリングされた行数のカウント**

行末の自動折り返しや句読点に影響する段落ルールについては、[行分割の制御](/slides/ja/php-java/text-formatting/#control-line-breaking) および [ハングパンクチュエーションの制御](/slides/ja/php-java/text-formatting/#control-hanging-punctuation) を参照してください。

[Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) を使用して、テキストレイアウト後の段落が占める行数をカウントできます。これは、プレゼンテーションテンプレートのテキスト長とレイアウトをチェックする際に便利です。

段落は [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) の項目の 1 つであり、複数のレンダリングされた行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を作成し、テキストに明示的な改行文字を挿入しません。そのため、段落数や改行文字の数を数えても実際のレンダリング行数は得られません。

次の例はテキストシェイプを作成し、その行数をカウントし、シェイプを狭め、テキストを短い文字列に置き換えます。例では [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) で折り返しを有効にし、[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) で自動フィットを無効にして、シェイプの幅が折り返しを制御し、テキストやシェイプの自動縮小が行われないようにしています。各測定は [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) を使用します。シェイプの寸法はポイント単位です。最後に、別の段落を追加し、テキストフレーム全体の行数を合計します。

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

このテキストとサイズでシェイプを狭めると行数が増え、短い文字列に置き換えると行数が減ります。正確なカウントはフォントの可用性と置換、フォントサイズ、余白、インデント、折り返し、自動フィット設定により変動します。テンプレートをチェックする際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかは判断できません。利用可能な高さ、行の高さ、段落と行間、そして自動フィットの挙動も重要です。折り返しが無効な場合、1 行でも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

HTML を使用してテキストをプレゼンテーションに取り込んだり、既存の段落を外部で使用できるようにエクスポートしたりできます。このセクションでは、テーブルセル内の段落を含む個別の段落を画像としてレンダリングする方法も紹介します。

### **HTML テキストを段落にインポート**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

この PHP の例はファイルから HTML を読み取り、マークアップを [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) に渡します。テキストフレームのデフォルト段落をクリアして、フレームにインポートされたコンテンツだけが含まれるようにします。矩形シェイプはスライドの各側に 10 ポイントの余白を残します：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **段落テキストを HTML にエクスポート**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) を使用して、選択した段落範囲を HTML としてエクスポートします。プレゼンテーションのテキストを Web サイトで再利用する場合、フォント、サイズ、テキストボックスのスタイルを持ち込まずにローカルの強調表示を保持したいことがあります。[TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) を設定して、エクスポート時の書式継承の深さを制御します。

[サンプル プレゼンテーション](text-inheritance.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドにはテキスト "Inherited text; explicit red 18pt" を含む 1 つのテキストシェイプがあります。入力は意図的に複数の書式レベルを使用しています。

- プレゼンテーションのデフォルトテキストスタイルは Calibri と 28 pt を提供します。
- テキストフレームの第一レベルテキストスタイルは青色テキストと斜体を提供します。
- 段落は太字テキストを明示的に設定します。
- 第二ポーション "explicit red 18pt" は赤色テキストと 18 pt のサイズを明示的に設定します。

以下の完全な例は同じ段落を 3 回エクスポートします。[TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) をエクスポートメソッドに渡し、各結果を別々の UTF-8 HTML ファイルとして書き出します：

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

生成された HTML には最初のポーション "Inherited text; " 用の次の CSS が含まれます。表は関連する宣言を示し、他の生成プロパティは簡潔さのために省略しています。

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | 28 pt Calibri が利用可能な場合、青色、太字、斜体テキスト |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 青色、太字、斜体テキスト；フォントファミリとサイズはページまたはブラウザが提供 |
| `ParagraphOnly.html` | `font-weight:bold` | 太字テキスト；フォントファミリ、サイズ、色、斜体はページまたはブラウザが提供 |

第二ポーションはすべての出力で `color:#ff0000`、`font-size:18pt`、`font-weight:bold` を保持します。また、`All` と `TextBox` ではイタリックが保持されますが、`ParagraphOnly` では保持されません。継承を制限しても、段落またはポーションに明示的に割り当てられた書式は削除されません。

同じブラウザでファイルを開いて比較してください。制限モードの省略された CSS プロパティは、宛先ページのスタイルまたはブラウザの既定値で解決されるため、最終的な外観は HTML が使用される場所に依存します。

### **段落を画像としてレンダリング**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) を返します。結果は [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) でファイルまたはストリームに保存できます。包含シェイプをレンダリングしたりビットマップを手動で切り取る必要はありません。

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) は、段落が親コレクションに見つからない、レンダリング境界が無効、またはレンダリングできない場合に `null` を返す可能性があります。保存する前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

例では、1 つのスライドに 3 段落を含むテキストボックスが配置されたプレゼンテーションを使用します。

![3 段落のテキストボックス](paragraph_to_image_input.png)

次の例はインデックス 1 の 2 番目の段落を選択し、スケールパラメータなしで [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) を呼び出します。シェイプが必要な段落を含んでいることと、レンダリングが画像を返すことを確認した上で、[IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) で PNG 形式で保存します。`finally` ブロックで使用後に画像を破棄します。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

結果:

![段落画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`$scaleX` と `$scaleY` パラメータを受け取る [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) のオーバーロードを使用して、水平および垂直のスケール係数を設定します。次の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

スケール係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば、両方の係数に `2` を指定すると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保つには同じ係数を使用し、異なる水平・垂直係数は出力を個別に伸ばします。

形状全体を [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) でレンダリングすることは、シェイプの塗りつぶし、境界線、その他のビジュアルコンテキストを含める必要がある場合に有用です。段落のみの画像の場合は、[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) を使用してください。

## **FAQ**

**テキストフレーム内で行の折り返しを完全に無効にできますか？**

はい。[TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) を設定して折り返しを無効にすると、行はテキストフレームの端で改行されません。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

[Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) を使用して段落のバウンディング矩形を取得します。[Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御しますか？**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) は段落レベルの設定であり、個々のポーションの書式設定に関係なく、段落全体に適用されます。

各行内でフォントサイズが異なるポーションを縦方向に揃える方法については、[行内フォントの揃え](/slides/ja/php-java/text-formatting/#align-fonts-within-a-line) を参照してください。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) を設定すれば、1 つの段落内に複数言語のテキストを含めることが可能です。